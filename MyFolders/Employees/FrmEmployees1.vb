Imports System.Data.SqlClient
Public Class FrmEmployees1
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()

    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim Click1 As Boolean = False
    Dim Click2 As Boolean = False
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents InternalAuditorERBUTTON As System.Windows.Forms.Button
    Friend WithEvents TEXTReviewDate As System.Windows.Forms.TextBox
    Friend WithEvents TextTimeAdd As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCancellationAuditingAndACheckingAccounts As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TEXTAddDate As System.Windows.Forms.TextBox
    Friend WithEvents CheckLogReview As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextreviewTime As System.Windows.Forms.TextBox
    Friend WithEvents TEXTUserName As System.Windows.Forms.TextBox
    Friend WithEvents TextDefinitionDirectorate As System.Windows.Forms.TextBox
    Friend WithEvents TEXTReferenceName As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ButtonAttachDocument As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Load1 As System.Windows.Forms.Button
    Friend WithEvents ButtonUpdateA As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextExtraBalance As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckPermanentEmployee As System.Windows.Forms.CheckBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Panel13 As Panel
    Friend WithEvents DOC1 As DataGridViewTextBoxColumn
    Friend WithEvents DOC2 As DataGridViewTextBoxColumn
    Friend WithEvents DOC4 As DataGridViewTextBoxColumn
    Friend WithEvents DOC5 As DataGridViewTextBoxColumn
    Friend WithEvents LO11 As DataGridViewTextBoxColumn
    Friend WithEvents TEXTEmployeeCode As Label
    Friend WithEvents TEXTPHONE As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ButtonViewDocuments As Button
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView

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
    Friend WithEvents LblOFFICERADDRESS As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERBIRTH As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERCODE As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERCRTIFICATE As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERDEPARTMENT As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERHABSENCE As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERHDISCOUNT As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERHPREVIOUS As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERHTOTAL As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERHWITHOUTSALARY As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERHYEAR As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERINSURANCE As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERNAME As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERNATION As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERPHONE As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERPOSITION As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERSOCIAL As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERWAR As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERWORKBEGIN As System.Windows.Forms.Label
    Friend WithEvents LblOFFICERWORKFINISH As System.Windows.Forms.Label
    Friend WithEvents DateOfBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateOfHiring As System.Windows.Forms.DateTimePicker
    Friend WithEvents EndOfServiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TEXTAddress As System.Windows.Forms.TextBox
    Friend WithEvents TEXTDaysOfAbsence As System.Windows.Forms.TextBox
    Friend WithEvents TEXTSanctionsDays As System.Windows.Forms.TextBox
    Friend WithEvents TEXTPreviousLeaveBalance As System.Windows.Forms.TextBox
    Friend WithEvents TEXTTotalLeaveBalance As System.Windows.Forms.TextBox
    Friend WithEvents TEXTUnpaidLeave As System.Windows.Forms.TextBox
    Friend WithEvents TEXTAnnualLeaveBalance As System.Windows.Forms.TextBox
    Friend WithEvents TEXTNumberOfInsurance As System.Windows.Forms.TextBox
    Friend WithEvents TEXTTextNationalNo As System.Windows.Forms.TextBox
    Friend WithEvents ComboMaritalStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ComboQualification As System.Windows.Forms.ComboBox
    Friend WithEvents ComboFunction As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAdministration As System.Windows.Forms.ComboBox
    Friend WithEvents ComboEmployeeName As System.Windows.Forms.ComboBox
    Friend WithEvents ComboMilitaryService As System.Windows.Forms.ComboBox
    Friend WithEvents LASTBUTTON As System.Windows.Forms.Button
    Friend WithEvents FIRSTBUTTON As System.Windows.Forms.Button
    Friend WithEvents NEXTBUTTON As System.Windows.Forms.Button
    Friend WithEvents PREVIOUSBUTTON As System.Windows.Forms.Button
    Friend WithEvents DELETEBUTTON As System.Windows.Forms.Button
    Friend WithEvents BUTTONCANCEL As System.Windows.Forms.Button
    Friend WithEvents SAVEBUTTON As System.Windows.Forms.Button
    Friend WithEvents EDITBUTTON As System.Windows.Forms.Button
    Friend WithEvents ADDBUTTON As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextEmployeeCredit As System.Windows.Forms.TextBox
    Friend WithEvents RECORDSLABEL As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Panel2 As System.Windows.Forms.Panel
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmployees1))
        Dim Panel3 As System.Windows.Forms.Panel
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TEXTPHONE = New DevExpress.XtraEditors.TextEdit()
        Me.TEXTEmployeeCode = New System.Windows.Forms.Label()
        Me.LblOFFICERCODE = New System.Windows.Forms.Label()
        Me.LblOFFICERSOCIAL = New System.Windows.Forms.Label()
        Me.ComboQualification = New System.Windows.Forms.ComboBox()
        Me.LblOFFICERCRTIFICATE = New System.Windows.Forms.Label()
        Me.ComboMaritalStatus = New System.Windows.Forms.ComboBox()
        Me.LblOFFICERNAME = New System.Windows.Forms.Label()
        Me.LblOFFICERPHONE = New System.Windows.Forms.Label()
        Me.TEXTAddress = New System.Windows.Forms.TextBox()
        Me.DateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.LblOFFICERBIRTH = New System.Windows.Forms.Label()
        Me.ComboEmployeeName = New System.Windows.Forms.ComboBox()
        Me.LblOFFICERADDRESS = New System.Windows.Forms.Label()
        Me.TEXTUnpaidLeave = New System.Windows.Forms.TextBox()
        Me.TEXTPreviousLeaveBalance = New System.Windows.Forms.TextBox()
        Me.TEXTDaysOfAbsence = New System.Windows.Forms.TextBox()
        Me.LblOFFICERHABSENCE = New System.Windows.Forms.Label()
        Me.LblOFFICERHYEAR = New System.Windows.Forms.Label()
        Me.TEXTSanctionsDays = New System.Windows.Forms.TextBox()
        Me.LblOFFICERHTOTAL = New System.Windows.Forms.Label()
        Me.LblOFFICERHWITHOUTSALARY = New System.Windows.Forms.Label()
        Me.LblOFFICERHPREVIOUS = New System.Windows.Forms.Label()
        Me.LblOFFICERHDISCOUNT = New System.Windows.Forms.Label()
        Me.TEXTTotalLeaveBalance = New System.Windows.Forms.TextBox()
        Me.TEXTAnnualLeaveBalance = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CheckPermanentEmployee = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextExtraBalance = New System.Windows.Forms.TextBox()
        Me.LblOFFICERNATION = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextEmployeeCredit = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TEXTTextNationalNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblOFFICERINSURANCE = New System.Windows.Forms.Label()
        Me.EndOfServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.TEXTNumberOfInsurance = New System.Windows.Forms.TextBox()
        Me.LblOFFICERWORKFINISH = New System.Windows.Forms.Label()
        Me.LblOFFICERWAR = New System.Windows.Forms.Label()
        Me.DateOfHiring = New System.Windows.Forms.DateTimePicker()
        Me.ComboMilitaryService = New System.Windows.Forms.ComboBox()
        Me.LblOFFICERWORKBEGIN = New System.Windows.Forms.Label()
        Me.LblOFFICERDEPARTMENT = New System.Windows.Forms.Label()
        Me.LblOFFICERPOSITION = New System.Windows.Forms.Label()
        Me.ComboFunction = New System.Windows.Forms.ComboBox()
        Me.ComboAdministration = New System.Windows.Forms.ComboBox()
        Me.LASTBUTTON = New System.Windows.Forms.Button()
        Me.FIRSTBUTTON = New System.Windows.Forms.Button()
        Me.NEXTBUTTON = New System.Windows.Forms.Button()
        Me.PREVIOUSBUTTON = New System.Windows.Forms.Button()
        Me.RECORDSLABEL = New System.Windows.Forms.Label()
        Me.DELETEBUTTON = New System.Windows.Forms.Button()
        Me.BUTTONCANCEL = New System.Windows.Forms.Button()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.EDITBUTTON = New System.Windows.Forms.Button()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TextDefinitionDirectorate = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextreviewTime = New System.Windows.Forms.TextBox()
        Me.TEXTReferenceName = New System.Windows.Forms.TextBox()
        Me.TEXTReviewDate = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TEXTUserName = New System.Windows.Forms.TextBox()
        Me.TextTimeAdd = New System.Windows.Forms.TextBox()
        Me.TEXTAddDate = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.InternalAuditorERBUTTON = New System.Windows.Forms.Button()
        Me.ButtonCancellationAuditingAndACheckingAccounts = New System.Windows.Forms.Button()
        Me.CheckLogReview = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ButtonAttachDocument = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DOC1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOC2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOC4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOC5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LO11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Load1 = New System.Windows.Forms.Button()
        Me.ButtonUpdateA = New System.Windows.Forms.Button()
        Me.ButtonViewDocuments = New System.Windows.Forms.Button()
        Panel2 = New System.Windows.Forms.Panel()
        Panel3 = New System.Windows.Forms.Panel()
        Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.TEXTPHONE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Panel2.BackColor = System.Drawing.Color.Transparent
        Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Panel2.Controls.Add(Me.GroupBox2)
        Panel2.Location = New System.Drawing.Point(334, 6)
        Panel2.Name = "Panel2"
        Panel2.Size = New System.Drawing.Size(512, 222)
        Panel2.TabIndex = 954
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel10)
        Me.GroupBox2.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(504, 222)
        Me.GroupBox2.TabIndex = 957
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "»Ì«‰«  «”«”Ì…"
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TEXTPHONE)
        Me.Panel10.Controls.Add(Me.TEXTEmployeeCode)
        Me.Panel10.Controls.Add(Me.LblOFFICERCODE)
        Me.Panel10.Controls.Add(Me.LblOFFICERSOCIAL)
        Me.Panel10.Controls.Add(Me.ComboQualification)
        Me.Panel10.Controls.Add(Me.LblOFFICERCRTIFICATE)
        Me.Panel10.Controls.Add(Me.ComboMaritalStatus)
        Me.Panel10.Controls.Add(Me.LblOFFICERNAME)
        Me.Panel10.Controls.Add(Me.LblOFFICERPHONE)
        Me.Panel10.Controls.Add(Me.TEXTAddress)
        Me.Panel10.Controls.Add(Me.DateOfBirth)
        Me.Panel10.Controls.Add(Me.LblOFFICERBIRTH)
        Me.Panel10.Controls.Add(Me.ComboEmployeeName)
        Me.Panel10.Controls.Add(Me.LblOFFICERADDRESS)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 18)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(498, 201)
        Me.Panel10.TabIndex = 958
        '
        'TEXTPHONE
        '
        Me.TEXTPHONE.EditValue = "07-______"
        Me.TEXTPHONE.Location = New System.Drawing.Point(3, 99)
        Me.TEXTPHONE.Name = "TEXTPHONE"
        Me.TEXTPHONE.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTPHONE.Properties.Appearance.Options.UseFont = True
        Me.TEXTPHONE.Properties.BeepOnError = False
        Me.TEXTPHONE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TEXTPHONE.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far
        Me.TEXTPHONE.Properties.ContextImageOptions.Image = CType(resources.GetObject("TEXTPHONE.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.TEXTPHONE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEXTPHONE.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.SimpleMaskManager))
        Me.TEXTPHONE.Properties.MaskSettings.Set("mask", "0000-000000")
        Me.TEXTPHONE.Properties.NullText = "07"
        Me.TEXTPHONE.Properties.UseMaskAsDisplayFormat = True
        Me.TEXTPHONE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTPHONE.Size = New System.Drawing.Size(383, 22)
        Me.TEXTPHONE.TabIndex = 1007
        '
        'TEXTEmployeeCode
        '
        Me.TEXTEmployeeCode.BackColor = System.Drawing.Color.SteelBlue
        Me.TEXTEmployeeCode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TEXTEmployeeCode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TEXTEmployeeCode.ForeColor = System.Drawing.Color.White
        Me.TEXTEmployeeCode.Location = New System.Drawing.Point(3, 3)
        Me.TEXTEmployeeCode.Name = "TEXTEmployeeCode"
        Me.TEXTEmployeeCode.Size = New System.Drawing.Size(383, 22)
        Me.TEXTEmployeeCode.TabIndex = 1006
        Me.TEXTEmployeeCode.Text = "000000"
        Me.TEXTEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblOFFICERCODE
        '
        Me.LblOFFICERCODE.AutoSize = True
        Me.LblOFFICERCODE.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERCODE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERCODE.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERCODE.Location = New System.Drawing.Point(465, 7)
        Me.LblOFFICERCODE.Name = "LblOFFICERCODE"
        Me.LblOFFICERCODE.Size = New System.Drawing.Size(28, 15)
        Me.LblOFFICERCODE.TabIndex = 5
        Me.LblOFFICERCODE.Text = "«·—ﬁ„"
        Me.LblOFFICERCODE.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LblOFFICERSOCIAL
        '
        Me.LblOFFICERSOCIAL.AutoSize = True
        Me.LblOFFICERSOCIAL.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERSOCIAL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERSOCIAL.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERSOCIAL.Location = New System.Drawing.Point(415, 128)
        Me.LblOFFICERSOCIAL.Name = "LblOFFICERSOCIAL"
        Me.LblOFFICERSOCIAL.Size = New System.Drawing.Size(78, 15)
        Me.LblOFFICERSOCIAL.TabIndex = 29
        Me.LblOFFICERSOCIAL.Text = "«·Õ«·… «·«Ã „«⁄Ì…"
        Me.LblOFFICERSOCIAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboQualification
        '
        Me.ComboQualification.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboQualification.Items.AddRange(New Object() {"œﬂ Ê—«…", "„«Ã” Ì—", "Â‰œ”…", "ÿ»", "’Ìœ·…", "«⁄·«„", "«ﬁ ’«œ Ê⁄·Ê„ ”Ì«”Ì…", "«À«—", "«·”‰", " Ã«—…", "ÕﬁÊﬁ", "“—«⁄…", "Œœ„… «Ã „«⁄Ì…", "Õ«”» ¬·Ï", "œ»·Ê„«   ›‰Ì…", "»œÊ‰ „ƒÂ·"})
        Me.ComboQualification.Location = New System.Drawing.Point(3, 148)
        Me.ComboQualification.Name = "ComboQualification"
        Me.ComboQualification.Size = New System.Drawing.Size(383, 23)
        Me.ComboQualification.TabIndex = 5
        '
        'LblOFFICERCRTIFICATE
        '
        Me.LblOFFICERCRTIFICATE.AutoSize = True
        Me.LblOFFICERCRTIFICATE.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERCRTIFICATE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERCRTIFICATE.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERCRTIFICATE.Location = New System.Drawing.Point(457, 152)
        Me.LblOFFICERCRTIFICATE.Name = "LblOFFICERCRTIFICATE"
        Me.LblOFFICERCRTIFICATE.Size = New System.Drawing.Size(36, 15)
        Me.LblOFFICERCRTIFICATE.TabIndex = 6
        Me.LblOFFICERCRTIFICATE.Text = "«·„ƒÂ·"
        Me.LblOFFICERCRTIFICATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboMaritalStatus
        '
        Me.ComboMaritalStatus.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboMaritalStatus.Items.AddRange(New Object() {"„ “ÊÃ", "«⁄“»", "„ÿ·ﬁ", "«—„·"})
        Me.ComboMaritalStatus.Location = New System.Drawing.Point(3, 122)
        Me.ComboMaritalStatus.Name = "ComboMaritalStatus"
        Me.ComboMaritalStatus.Size = New System.Drawing.Size(383, 23)
        Me.ComboMaritalStatus.TabIndex = 4
        '
        'LblOFFICERNAME
        '
        Me.LblOFFICERNAME.AutoSize = True
        Me.LblOFFICERNAME.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERNAME.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERNAME.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERNAME.Location = New System.Drawing.Point(452, 31)
        Me.LblOFFICERNAME.Name = "LblOFFICERNAME"
        Me.LblOFFICERNAME.Size = New System.Drawing.Size(41, 15)
        Me.LblOFFICERNAME.TabIndex = 25
        Me.LblOFFICERNAME.Text = "«·„ÊŸ›"
        Me.LblOFFICERNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblOFFICERPHONE
        '
        Me.LblOFFICERPHONE.AutoSize = True
        Me.LblOFFICERPHONE.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERPHONE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERPHONE.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERPHONE.Location = New System.Drawing.Point(463, 101)
        Me.LblOFFICERPHONE.Name = "LblOFFICERPHONE"
        Me.LblOFFICERPHONE.Size = New System.Drawing.Size(30, 15)
        Me.LblOFFICERPHONE.TabIndex = 27
        Me.LblOFFICERPHONE.Text = "Â« ›"
        Me.LblOFFICERPHONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TEXTAddress
        '
        Me.TEXTAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTAddress.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTAddress.ForeColor = System.Drawing.Color.Black
        Me.TEXTAddress.Location = New System.Drawing.Point(3, 50)
        Me.TEXTAddress.Multiline = True
        Me.TEXTAddress.Name = "TEXTAddress"
        Me.TEXTAddress.Size = New System.Drawing.Size(383, 47)
        Me.TEXTAddress.TabIndex = 2
        '
        'DateOfBirth
        '
        Me.DateOfBirth.Checked = False
        Me.DateOfBirth.CustomFormat = "yyyy/MM/dd"
        Me.DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateOfBirth.Location = New System.Drawing.Point(3, 172)
        Me.DateOfBirth.Name = "DateOfBirth"
        Me.DateOfBirth.RightToLeftLayout = True
        Me.DateOfBirth.Size = New System.Drawing.Size(383, 22)
        Me.DateOfBirth.TabIndex = 8
        '
        'LblOFFICERBIRTH
        '
        Me.LblOFFICERBIRTH.AutoSize = True
        Me.LblOFFICERBIRTH.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERBIRTH.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERBIRTH.Location = New System.Drawing.Point(433, 177)
        Me.LblOFFICERBIRTH.Name = "LblOFFICERBIRTH"
        Me.LblOFFICERBIRTH.Size = New System.Drawing.Size(60, 15)
        Me.LblOFFICERBIRTH.TabIndex = 4
        Me.LblOFFICERBIRTH.Text = " «—ÌŒ «·„Ì·«œ"
        Me.LblOFFICERBIRTH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboEmployeeName
        '
        Me.ComboEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboEmployeeName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboEmployeeName.Location = New System.Drawing.Point(3, 26)
        Me.ComboEmployeeName.Name = "ComboEmployeeName"
        Me.ComboEmployeeName.Size = New System.Drawing.Size(383, 23)
        Me.ComboEmployeeName.TabIndex = 1
        '
        'LblOFFICERADDRESS
        '
        Me.LblOFFICERADDRESS.AutoSize = True
        Me.LblOFFICERADDRESS.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERADDRESS.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERADDRESS.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERADDRESS.Location = New System.Drawing.Point(455, 54)
        Me.LblOFFICERADDRESS.Name = "LblOFFICERADDRESS"
        Me.LblOFFICERADDRESS.Size = New System.Drawing.Size(38, 15)
        Me.LblOFFICERADDRESS.TabIndex = 3
        Me.LblOFFICERADDRESS.Text = "«·⁄‰Ê«‰"
        Me.LblOFFICERADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Panel3.BackColor = System.Drawing.Color.Transparent
        Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Panel3.Controls.Add(Me.TEXTUnpaidLeave)
        Panel3.Controls.Add(Me.TEXTPreviousLeaveBalance)
        Panel3.Controls.Add(Me.TEXTDaysOfAbsence)
        Panel3.Controls.Add(Me.LblOFFICERHABSENCE)
        Panel3.Controls.Add(Me.LblOFFICERHYEAR)
        Panel3.Controls.Add(Me.TEXTSanctionsDays)
        Panel3.Controls.Add(Me.LblOFFICERHTOTAL)
        Panel3.Controls.Add(Me.LblOFFICERHWITHOUTSALARY)
        Panel3.Controls.Add(Me.LblOFFICERHPREVIOUS)
        Panel3.Controls.Add(Me.LblOFFICERHDISCOUNT)
        Panel3.Controls.Add(Me.TEXTTotalLeaveBalance)
        Panel3.Controls.Add(Me.TEXTAnnualLeaveBalance)
        Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Panel3.Location = New System.Drawing.Point(3, 18)
        Panel3.Name = "Panel3"
        Panel3.Size = New System.Drawing.Size(495, 77)
        Panel3.TabIndex = 24
        '
        'TEXTUnpaidLeave
        '
        Me.TEXTUnpaidLeave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTUnpaidLeave.ForeColor = System.Drawing.Color.Black
        Me.TEXTUnpaidLeave.Location = New System.Drawing.Point(2, 51)
        Me.TEXTUnpaidLeave.Name = "TEXTUnpaidLeave"
        Me.TEXTUnpaidLeave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTUnpaidLeave.Size = New System.Drawing.Size(128, 22)
        Me.TEXTUnpaidLeave.TabIndex = 19
        Me.TEXTUnpaidLeave.Text = "0"
        Me.TEXTUnpaidLeave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTPreviousLeaveBalance
        '
        Me.TEXTPreviousLeaveBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTPreviousLeaveBalance.ForeColor = System.Drawing.Color.Black
        Me.TEXTPreviousLeaveBalance.Location = New System.Drawing.Point(265, 3)
        Me.TEXTPreviousLeaveBalance.Name = "TEXTPreviousLeaveBalance"
        Me.TEXTPreviousLeaveBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTPreviousLeaveBalance.Size = New System.Drawing.Size(121, 22)
        Me.TEXTPreviousLeaveBalance.TabIndex = 14
        Me.TEXTPreviousLeaveBalance.Text = "0"
        Me.TEXTPreviousLeaveBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTDaysOfAbsence
        '
        Me.TEXTDaysOfAbsence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTDaysOfAbsence.ForeColor = System.Drawing.Color.Black
        Me.TEXTDaysOfAbsence.Location = New System.Drawing.Point(2, 3)
        Me.TEXTDaysOfAbsence.Name = "TEXTDaysOfAbsence"
        Me.TEXTDaysOfAbsence.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTDaysOfAbsence.Size = New System.Drawing.Size(128, 22)
        Me.TEXTDaysOfAbsence.TabIndex = 17
        Me.TEXTDaysOfAbsence.Text = "0"
        Me.TEXTDaysOfAbsence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOFFICERHABSENCE
        '
        Me.LblOFFICERHABSENCE.AutoSize = True
        Me.LblOFFICERHABSENCE.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERHABSENCE.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERHABSENCE.Location = New System.Drawing.Point(176, 6)
        Me.LblOFFICERHABSENCE.Name = "LblOFFICERHABSENCE"
        Me.LblOFFICERHABSENCE.Size = New System.Drawing.Size(51, 15)
        Me.LblOFFICERHABSENCE.TabIndex = 8
        Me.LblOFFICERHABSENCE.Text = "«Ì«„ «·€Ì«»"
        '
        'LblOFFICERHYEAR
        '
        Me.LblOFFICERHYEAR.AutoSize = True
        Me.LblOFFICERHYEAR.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERHYEAR.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERHYEAR.Location = New System.Drawing.Point(400, 27)
        Me.LblOFFICERHYEAR.Name = "LblOFFICERHYEAR"
        Me.LblOFFICERHYEAR.Size = New System.Drawing.Size(93, 15)
        Me.LblOFFICERHYEAR.TabIndex = 23
        Me.LblOFFICERHYEAR.Text = "—’Ìœ «Ã«“«  ”‰ÊÏ"
        '
        'TEXTSanctionsDays
        '
        Me.TEXTSanctionsDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTSanctionsDays.ForeColor = System.Drawing.Color.Black
        Me.TEXTSanctionsDays.Location = New System.Drawing.Point(2, 27)
        Me.TEXTSanctionsDays.Name = "TEXTSanctionsDays"
        Me.TEXTSanctionsDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTSanctionsDays.Size = New System.Drawing.Size(128, 22)
        Me.TEXTSanctionsDays.TabIndex = 18
        Me.TEXTSanctionsDays.Text = "0"
        Me.TEXTSanctionsDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOFFICERHTOTAL
        '
        Me.LblOFFICERHTOTAL.AutoSize = True
        Me.LblOFFICERHTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERHTOTAL.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERHTOTAL.Location = New System.Drawing.Point(392, 52)
        Me.LblOFFICERHTOTAL.Name = "LblOFFICERHTOTAL"
        Me.LblOFFICERHTOTAL.Size = New System.Drawing.Size(101, 15)
        Me.LblOFFICERHTOTAL.TabIndex = 11
        Me.LblOFFICERHTOTAL.Text = "«Ã„«·Ï —’Ìœ «·«Ã«“« "
        '
        'LblOFFICERHWITHOUTSALARY
        '
        Me.LblOFFICERHWITHOUTSALARY.AutoSize = True
        Me.LblOFFICERHWITHOUTSALARY.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERHWITHOUTSALARY.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERHWITHOUTSALARY.Location = New System.Drawing.Point(147, 55)
        Me.LblOFFICERHWITHOUTSALARY.Name = "LblOFFICERHWITHOUTSALARY"
        Me.LblOFFICERHWITHOUTSALARY.Size = New System.Drawing.Size(80, 15)
        Me.LblOFFICERHWITHOUTSALARY.TabIndex = 12
        Me.LblOFFICERHWITHOUTSALARY.Text = "«Ã«“… »œÊ‰ „— »"
        '
        'LblOFFICERHPREVIOUS
        '
        Me.LblOFFICERHPREVIOUS.AutoSize = True
        Me.LblOFFICERHPREVIOUS.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERHPREVIOUS.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERHPREVIOUS.Location = New System.Drawing.Point(403, 6)
        Me.LblOFFICERHPREVIOUS.Name = "LblOFFICERHPREVIOUS"
        Me.LblOFFICERHPREVIOUS.Size = New System.Drawing.Size(90, 15)
        Me.LblOFFICERHPREVIOUS.TabIndex = 10
        Me.LblOFFICERHPREVIOUS.Text = "—’Ìœ «Ã«“«  ”«»ﬁ"
        '
        'LblOFFICERHDISCOUNT
        '
        Me.LblOFFICERHDISCOUNT.AutoSize = True
        Me.LblOFFICERHDISCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERHDISCOUNT.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERHDISCOUNT.Location = New System.Drawing.Point(163, 32)
        Me.LblOFFICERHDISCOUNT.Name = "LblOFFICERHDISCOUNT"
        Me.LblOFFICERHDISCOUNT.Size = New System.Drawing.Size(64, 15)
        Me.LblOFFICERHDISCOUNT.TabIndex = 9
        Me.LblOFFICERHDISCOUNT.Text = "«Ì«„ «·Ã“«¡« "
        '
        'TEXTTotalLeaveBalance
        '
        Me.TEXTTotalLeaveBalance.BackColor = System.Drawing.Color.SteelBlue
        Me.TEXTTotalLeaveBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTTotalLeaveBalance.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEXTTotalLeaveBalance.ForeColor = System.Drawing.Color.White
        Me.TEXTTotalLeaveBalance.Location = New System.Drawing.Point(265, 51)
        Me.TEXTTotalLeaveBalance.Name = "TEXTTotalLeaveBalance"
        Me.TEXTTotalLeaveBalance.ReadOnly = True
        Me.TEXTTotalLeaveBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTTotalLeaveBalance.Size = New System.Drawing.Size(121, 22)
        Me.TEXTTotalLeaveBalance.TabIndex = 16
        Me.TEXTTotalLeaveBalance.Text = "0"
        Me.TEXTTotalLeaveBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTAnnualLeaveBalance
        '
        Me.TEXTAnnualLeaveBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTAnnualLeaveBalance.ForeColor = System.Drawing.Color.Black
        Me.TEXTAnnualLeaveBalance.Location = New System.Drawing.Point(265, 27)
        Me.TEXTAnnualLeaveBalance.Name = "TEXTAnnualLeaveBalance"
        Me.TEXTAnnualLeaveBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTAnnualLeaveBalance.Size = New System.Drawing.Size(121, 22)
        Me.TEXTAnnualLeaveBalance.TabIndex = 15
        Me.TEXTAnnualLeaveBalance.Text = "0"
        Me.TEXTAnnualLeaveBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Panel3)
        Me.GroupBox6.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox6.Location = New System.Drawing.Point(331, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(501, 98)
        Me.GroupBox6.TabIndex = 957
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "—’Ìœ «·«Ã«“« "
        '
        'CheckPermanentEmployee
        '
        Me.CheckPermanentEmployee.AutoSize = True
        Me.CheckPermanentEmployee.Location = New System.Drawing.Point(147, 177)
        Me.CheckPermanentEmployee.Name = "CheckPermanentEmployee"
        Me.CheckPermanentEmployee.Size = New System.Drawing.Size(73, 19)
        Me.CheckPermanentEmployee.TabIndex = 30
        Me.CheckPermanentEmployee.Text = "„ÊŸ› œ«∆„"
        Me.CheckPermanentEmployee.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(245, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 726
        Me.Label2.Text = "—’Ìœ «·«÷«›Ï"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextExtraBalance
        '
        Me.TextExtraBalance.BackColor = System.Drawing.Color.SteelBlue
        Me.TextExtraBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextExtraBalance.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextExtraBalance.ForeColor = System.Drawing.Color.White
        Me.TextExtraBalance.Location = New System.Drawing.Point(5, 10)
        Me.TextExtraBalance.Name = "TextExtraBalance"
        Me.TextExtraBalance.ReadOnly = True
        Me.TextExtraBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextExtraBalance.Size = New System.Drawing.Size(217, 22)
        Me.TextExtraBalance.TabIndex = 725
        Me.TextExtraBalance.Text = "0.000"
        Me.TextExtraBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOFFICERNATION
        '
        Me.LblOFFICERNATION.AutoSize = True
        Me.LblOFFICERNATION.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERNATION.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERNATION.Location = New System.Drawing.Point(248, 58)
        Me.LblOFFICERNATION.Name = "LblOFFICERNATION"
        Me.LblOFFICERNATION.Size = New System.Drawing.Size(62, 15)
        Me.LblOFFICERNATION.TabIndex = 26
        Me.LblOFFICERNATION.Text = "«·—ﬁ„ «·Êÿ‰Ì"
        Me.LblOFFICERNATION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.CC_JO.My.Resources.Resources.indecator1
        Me.PictureBox1.Location = New System.Drawing.Point(3, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 723
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TextEmployeeCredit
        '
        Me.TextEmployeeCredit.BackColor = System.Drawing.Color.SteelBlue
        Me.TextEmployeeCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEmployeeCredit.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextEmployeeCredit.ForeColor = System.Drawing.Color.White
        Me.TextEmployeeCredit.Location = New System.Drawing.Point(5, 38)
        Me.TextEmployeeCredit.Name = "TextEmployeeCredit"
        Me.TextEmployeeCredit.ReadOnly = True
        Me.TextEmployeeCredit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextEmployeeCredit.Size = New System.Drawing.Size(217, 22)
        Me.TextEmployeeCredit.TabIndex = 463
        Me.TextEmployeeCredit.Text = "0.000"
        Me.TextEmployeeCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(3, 38)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 723
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TEXTTextNationalNo
        '
        Me.TEXTTextNationalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTTextNationalNo.ForeColor = System.Drawing.Color.Black
        Me.TEXTTextNationalNo.Location = New System.Drawing.Point(3, 54)
        Me.TEXTTextNationalNo.Name = "TEXTTextNationalNo"
        Me.TEXTTextNationalNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTTextNationalNo.Size = New System.Drawing.Size(217, 22)
        Me.TEXTTextNationalNo.TabIndex = 11
        Me.TEXTTextNationalNo.Text = "0"
        Me.TEXTTextNationalNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(245, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 462
        Me.Label1.Text = "—’Ìœ «·„ÊŸ›"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblOFFICERINSURANCE
        '
        Me.LblOFFICERINSURANCE.AutoSize = True
        Me.LblOFFICERINSURANCE.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERINSURANCE.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERINSURANCE.Location = New System.Drawing.Point(246, 81)
        Me.LblOFFICERINSURANCE.Name = "LblOFFICERINSURANCE"
        Me.LblOFFICERINSURANCE.Size = New System.Drawing.Size(64, 15)
        Me.LblOFFICERINSURANCE.TabIndex = 24
        Me.LblOFFICERINSURANCE.Text = "«·—ﬁ„ «· √„Ì‰Ï"
        Me.LblOFFICERINSURANCE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EndOfServiceDate
        '
        Me.EndOfServiceDate.Checked = False
        Me.EndOfServiceDate.CustomFormat = "yyyy/MM/dd"
        Me.EndOfServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndOfServiceDate.Location = New System.Drawing.Point(3, 151)
        Me.EndOfServiceDate.Name = "EndOfServiceDate"
        Me.EndOfServiceDate.RightToLeftLayout = True
        Me.EndOfServiceDate.Size = New System.Drawing.Size(217, 22)
        Me.EndOfServiceDate.TabIndex = 10
        '
        'TEXTNumberOfInsurance
        '
        Me.TEXTNumberOfInsurance.BackColor = System.Drawing.Color.White
        Me.TEXTNumberOfInsurance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTNumberOfInsurance.ForeColor = System.Drawing.Color.Black
        Me.TEXTNumberOfInsurance.Location = New System.Drawing.Point(3, 78)
        Me.TEXTNumberOfInsurance.Name = "TEXTNumberOfInsurance"
        Me.TEXTNumberOfInsurance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTNumberOfInsurance.Size = New System.Drawing.Size(217, 22)
        Me.TEXTNumberOfInsurance.TabIndex = 12
        Me.TEXTNumberOfInsurance.Text = "0"
        Me.TEXTNumberOfInsurance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOFFICERWORKFINISH
        '
        Me.LblOFFICERWORKFINISH.AutoSize = True
        Me.LblOFFICERWORKFINISH.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERWORKFINISH.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERWORKFINISH.Location = New System.Drawing.Point(224, 156)
        Me.LblOFFICERWORKFINISH.Name = "LblOFFICERWORKFINISH"
        Me.LblOFFICERWORKFINISH.Size = New System.Drawing.Size(86, 15)
        Me.LblOFFICERWORKFINISH.TabIndex = 32
        Me.LblOFFICERWORKFINISH.Text = " «—ÌŒ ‰Â«Ì… «·Œœ„…"
        Me.LblOFFICERWORKFINISH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblOFFICERWAR
        '
        Me.LblOFFICERWAR.AutoSize = True
        Me.LblOFFICERWAR.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERWAR.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERWAR.Location = New System.Drawing.Point(234, 106)
        Me.LblOFFICERWAR.Name = "LblOFFICERWAR"
        Me.LblOFFICERWAR.Size = New System.Drawing.Size(76, 15)
        Me.LblOFFICERWAR.TabIndex = 30
        Me.LblOFFICERWAR.Text = "«·Œœ„… «·⁄”ﬂ—Ì…"
        Me.LblOFFICERWAR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateOfHiring
        '
        Me.DateOfHiring.Checked = False
        Me.DateOfHiring.CustomFormat = "yyyy/MM/dd"
        Me.DateOfHiring.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateOfHiring.Location = New System.Drawing.Point(3, 127)
        Me.DateOfHiring.Name = "DateOfHiring"
        Me.DateOfHiring.RightToLeftLayout = True
        Me.DateOfHiring.Size = New System.Drawing.Size(217, 22)
        Me.DateOfHiring.TabIndex = 9
        '
        'ComboMilitaryService
        '
        Me.ComboMilitaryService.Items.AddRange(New Object() {"«œÏ «·Œœ„…", "«⁄›«¡ ‰Â«∆Ï", "«⁄›«¡ „ƒﬁ ", " √ÃÌ·", "·„ Ì’»Â «·œÊ—"})
        Me.ComboMilitaryService.Location = New System.Drawing.Point(3, 101)
        Me.ComboMilitaryService.Name = "ComboMilitaryService"
        Me.ComboMilitaryService.Size = New System.Drawing.Size(217, 23)
        Me.ComboMilitaryService.TabIndex = 13
        '
        'LblOFFICERWORKBEGIN
        '
        Me.LblOFFICERWORKBEGIN.AutoSize = True
        Me.LblOFFICERWORKBEGIN.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERWORKBEGIN.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERWORKBEGIN.Location = New System.Drawing.Point(246, 131)
        Me.LblOFFICERWORKBEGIN.Name = "LblOFFICERWORKBEGIN"
        Me.LblOFFICERWORKBEGIN.Size = New System.Drawing.Size(64, 15)
        Me.LblOFFICERWORKBEGIN.TabIndex = 31
        Me.LblOFFICERWORKBEGIN.Text = " «—ÌŒ «· ⁄ÌÌ‰"
        Me.LblOFFICERWORKBEGIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblOFFICERDEPARTMENT
        '
        Me.LblOFFICERDEPARTMENT.AutoSize = True
        Me.LblOFFICERDEPARTMENT.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERDEPARTMENT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERDEPARTMENT.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERDEPARTMENT.Location = New System.Drawing.Point(277, 33)
        Me.LblOFFICERDEPARTMENT.Name = "LblOFFICERDEPARTMENT"
        Me.LblOFFICERDEPARTMENT.Size = New System.Drawing.Size(33, 15)
        Me.LblOFFICERDEPARTMENT.TabIndex = 7
        Me.LblOFFICERDEPARTMENT.Text = "«·«œ«—…"
        Me.LblOFFICERDEPARTMENT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblOFFICERPOSITION
        '
        Me.LblOFFICERPOSITION.AutoSize = True
        Me.LblOFFICERPOSITION.BackColor = System.Drawing.Color.Transparent
        Me.LblOFFICERPOSITION.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOFFICERPOSITION.ForeColor = System.Drawing.Color.Black
        Me.LblOFFICERPOSITION.Location = New System.Drawing.Point(271, 7)
        Me.LblOFFICERPOSITION.Name = "LblOFFICERPOSITION"
        Me.LblOFFICERPOSITION.Size = New System.Drawing.Size(39, 15)
        Me.LblOFFICERPOSITION.TabIndex = 28
        Me.LblOFFICERPOSITION.Text = "«·ÊŸÌ›…"
        Me.LblOFFICERPOSITION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboFunction
        '
        Me.ComboFunction.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboFunction.Items.AddRange(New Object() {"„Õ«”»", "«Œ’«∆Ï ﬂ„»ÌÊ —", "›‰Ï", "”«∆ﬁ", "⁄«„·"})
        Me.ComboFunction.Location = New System.Drawing.Point(3, 3)
        Me.ComboFunction.Name = "ComboFunction"
        Me.ComboFunction.Size = New System.Drawing.Size(217, 23)
        Me.ComboFunction.TabIndex = 6
        '
        'ComboAdministration
        '
        Me.ComboAdministration.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboAdministration.ForeColor = System.Drawing.Color.Black
        Me.ComboAdministration.Items.AddRange(New Object() {"„Ã·” «·«œ«—…", "„ﬂ » —∆Ì” «·ﬁÿ«⁄", "«·«œ«—… «·Â‰œ”Ì…", "«·«œ«—… «·„«·Ì…", "‘∆Ê‰ «·⁄«„·Ì‰", "«·‘∆Ê‰ «·ﬁ«‰Ê‰Ì…", "«·„»Ì⁄« ", "«·„‘ —Ì« ", "«·„Œ«“‰", "«·’Ì«‰…", "«·Ã—«Ã"})
        Me.ComboAdministration.Location = New System.Drawing.Point(3, 29)
        Me.ComboAdministration.Name = "ComboAdministration"
        Me.ComboAdministration.Size = New System.Drawing.Size(217, 23)
        Me.ComboAdministration.TabIndex = 7
        '
        'LASTBUTTON
        '
        Me.LASTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.LASTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left_2
        Me.LASTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LASTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LASTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LASTBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LASTBUTTON.Location = New System.Drawing.Point(249, 3)
        Me.LASTBUTTON.Name = "LASTBUTTON"
        Me.LASTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LASTBUTTON.Size = New System.Drawing.Size(45, 34)
        Me.LASTBUTTON.TabIndex = 455
        Me.LASTBUTTON.UseVisualStyleBackColor = False
        '
        'FIRSTBUTTON
        '
        Me.FIRSTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.FIRSTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right_2
        Me.FIRSTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FIRSTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FIRSTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FIRSTBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FIRSTBUTTON.Location = New System.Drawing.Point(809, 3)
        Me.FIRSTBUTTON.Name = "FIRSTBUTTON"
        Me.FIRSTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FIRSTBUTTON.Size = New System.Drawing.Size(45, 34)
        Me.FIRSTBUTTON.TabIndex = 453
        Me.FIRSTBUTTON.UseVisualStyleBackColor = False
        '
        'NEXTBUTTON
        '
        Me.NEXTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.NEXTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left
        Me.NEXTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NEXTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NEXTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NEXTBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NEXTBUTTON.Location = New System.Drawing.Point(295, 3)
        Me.NEXTBUTTON.Name = "NEXTBUTTON"
        Me.NEXTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NEXTBUTTON.Size = New System.Drawing.Size(44, 34)
        Me.NEXTBUTTON.TabIndex = 456
        Me.NEXTBUTTON.UseVisualStyleBackColor = False
        '
        'PREVIOUSBUTTON
        '
        Me.PREVIOUSBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PREVIOUSBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right
        Me.PREVIOUSBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PREVIOUSBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PREVIOUSBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PREVIOUSBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PREVIOUSBUTTON.Location = New System.Drawing.Point(764, 3)
        Me.PREVIOUSBUTTON.Name = "PREVIOUSBUTTON"
        Me.PREVIOUSBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PREVIOUSBUTTON.Size = New System.Drawing.Size(44, 34)
        Me.PREVIOUSBUTTON.TabIndex = 454
        Me.PREVIOUSBUTTON.UseVisualStyleBackColor = False
        '
        'RECORDSLABEL
        '
        Me.RECORDSLABEL.BackColor = System.Drawing.Color.Transparent
        Me.RECORDSLABEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RECORDSLABEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RECORDSLABEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RECORDSLABEL.ForeColor = System.Drawing.Color.Black
        Me.RECORDSLABEL.Location = New System.Drawing.Point(340, 3)
        Me.RECORDSLABEL.Name = "RECORDSLABEL"
        Me.RECORDSLABEL.Size = New System.Drawing.Size(423, 34)
        Me.RECORDSLABEL.TabIndex = 452
        Me.RECORDSLABEL.Text = "⁄œœ «·”Ã·« "
        Me.RECORDSLABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DELETEBUTTON
        '
        Me.DELETEBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.DELETEBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DELETEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DELETEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DELETEBUTTON.Image = Global.CC_JO.My.Resources.Resources.delete1
        Me.DELETEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DELETEBUTTON.Location = New System.Drawing.Point(249, 38)
        Me.DELETEBUTTON.Name = "DELETEBUTTON"
        Me.DELETEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DELETEBUTTON.Size = New System.Drawing.Size(120, 34)
        Me.DELETEBUTTON.TabIndex = 461
        Me.DELETEBUTTON.Text = "Õ–› F6"
        Me.DELETEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DELETEBUTTON.UseVisualStyleBackColor = False
        '
        'BUTTONCANCEL
        '
        Me.BUTTONCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BUTTONCANCEL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BUTTONCANCEL.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BUTTONCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BUTTONCANCEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BUTTONCANCEL.Image = Global.CC_JO.My.Resources.Resources.Cancel_16x16
        Me.BUTTONCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BUTTONCANCEL.Location = New System.Drawing.Point(371, 38)
        Me.BUTTONCANCEL.Name = "BUTTONCANCEL"
        Me.BUTTONCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BUTTONCANCEL.Size = New System.Drawing.Size(120, 34)
        Me.BUTTONCANCEL.TabIndex = 460
        Me.BUTTONCANCEL.Text = "«·€«¡ F4"
        Me.BUTTONCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUTTONCANCEL.UseVisualStyleBackColor = False
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SAVEBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.Location = New System.Drawing.Point(613, 38)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SAVEBUTTON.Size = New System.Drawing.Size(120, 34)
        Me.SAVEBUTTON.TabIndex = 459
        Me.SAVEBUTTON.Text = "Õ›Ÿ F2"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.UseVisualStyleBackColor = False
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.EDITBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EDITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EDITBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EDITBUTTON.Location = New System.Drawing.Point(492, 38)
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EDITBUTTON.Size = New System.Drawing.Size(120, 34)
        Me.EDITBUTTON.TabIndex = 458
        Me.EDITBUTTON.Text = " ⁄œÌ· F3"
        Me.EDITBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EDITBUTTON.UseVisualStyleBackColor = False
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.ADDBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.Location = New System.Drawing.Point(734, 38)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ADDBUTTON.Size = New System.Drawing.Size(120, 34)
        Me.ADDBUTTON.TabIndex = 457
        Me.ADDBUTTON.Text = "«÷«›… F1"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Panel8)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(499, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(344, 153)
        Me.GroupBox3.TabIndex = 831
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "«·„” Œœ„Ì‰"
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.TextDefinitionDirectorate)
        Me.Panel8.Controls.Add(Me.Label36)
        Me.Panel8.Controls.Add(Me.Label24)
        Me.Panel8.Controls.Add(Me.TextreviewTime)
        Me.Panel8.Controls.Add(Me.TEXTReferenceName)
        Me.Panel8.Controls.Add(Me.TEXTReviewDate)
        Me.Panel8.Controls.Add(Me.Label29)
        Me.Panel8.Controls.Add(Me.Label25)
        Me.Panel8.Controls.Add(Me.TEXTUserName)
        Me.Panel8.Controls.Add(Me.TextTimeAdd)
        Me.Panel8.Controls.Add(Me.TEXTAddDate)
        Me.Panel8.Controls.Add(Me.Label26)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 18)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(338, 132)
        Me.Panel8.TabIndex = 958
        '
        'TextDefinitionDirectorate
        '
        Me.TextDefinitionDirectorate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDefinitionDirectorate.Enabled = False
        Me.TextDefinitionDirectorate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextDefinitionDirectorate.ForeColor = System.Drawing.Color.Black
        Me.TextDefinitionDirectorate.Location = New System.Drawing.Point(13, 99)
        Me.TextDefinitionDirectorate.Name = "TextDefinitionDirectorate"
        Me.TextDefinitionDirectorate.ReadOnly = True
        Me.TextDefinitionDirectorate.Size = New System.Drawing.Size(216, 22)
        Me.TextDefinitionDirectorate.TabIndex = 749
        Me.TextDefinitionDirectorate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(251, 106)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(73, 15)
        Me.Label36.TabIndex = 834
        Me.Label36.Text = " ⁄—Ì› «·„œÌ—Ì…"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(259, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 15)
        Me.Label24.TabIndex = 751
        Me.Label24.Text = "«”„ «·„” Œœ„"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextreviewTime
        '
        Me.TextreviewTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextreviewTime.Enabled = False
        Me.TextreviewTime.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextreviewTime.ForeColor = System.Drawing.Color.Black
        Me.TextreviewTime.Location = New System.Drawing.Point(13, 75)
        Me.TextreviewTime.Name = "TextreviewTime"
        Me.TextreviewTime.ReadOnly = True
        Me.TextreviewTime.Size = New System.Drawing.Size(95, 22)
        Me.TextreviewTime.TabIndex = 754
        Me.TextreviewTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTReferenceName
        '
        Me.TEXTReferenceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTReferenceName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTReferenceName.ForeColor = System.Drawing.Color.Black
        Me.TEXTReferenceName.Location = New System.Drawing.Point(13, 51)
        Me.TEXTReferenceName.Name = "TEXTReferenceName"
        Me.TEXTReferenceName.ReadOnly = True
        Me.TEXTReferenceName.Size = New System.Drawing.Size(216, 22)
        Me.TEXTReferenceName.TabIndex = 832
        Me.TEXTReferenceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTReviewDate
        '
        Me.TEXTReviewDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTReviewDate.Enabled = False
        Me.TEXTReviewDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTReviewDate.ForeColor = System.Drawing.Color.Black
        Me.TEXTReviewDate.Location = New System.Drawing.Point(109, 75)
        Me.TEXTReviewDate.Name = "TEXTReviewDate"
        Me.TEXTReviewDate.ReadOnly = True
        Me.TEXTReviewDate.Size = New System.Drawing.Size(120, 22)
        Me.TEXTReviewDate.TabIndex = 750
        Me.TEXTReviewDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(265, 59)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(59, 15)
        Me.Label29.TabIndex = 753
        Me.Label29.Text = "«”„ «·„—«Ã⁄"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(229, 83)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(95, 15)
        Me.Label25.TabIndex = 752
        Me.Label25.Text = " «—ÌŒ Êﬁ   «·„—«Ã⁄…"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TEXTUserName
        '
        Me.TEXTUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTUserName.Enabled = False
        Me.TEXTUserName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTUserName.ForeColor = System.Drawing.Color.Black
        Me.TEXTUserName.Location = New System.Drawing.Point(13, 5)
        Me.TEXTUserName.Name = "TEXTUserName"
        Me.TEXTUserName.ReadOnly = True
        Me.TEXTUserName.Size = New System.Drawing.Size(216, 22)
        Me.TEXTUserName.TabIndex = 748
        Me.TEXTUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextTimeAdd
        '
        Me.TextTimeAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTimeAdd.Enabled = False
        Me.TextTimeAdd.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextTimeAdd.ForeColor = System.Drawing.Color.Black
        Me.TextTimeAdd.Location = New System.Drawing.Point(13, 28)
        Me.TextTimeAdd.Name = "TextTimeAdd"
        Me.TextTimeAdd.ReadOnly = True
        Me.TextTimeAdd.Size = New System.Drawing.Size(95, 22)
        Me.TextTimeAdd.TabIndex = 757
        Me.TextTimeAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTAddDate
        '
        Me.TEXTAddDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTAddDate.Enabled = False
        Me.TEXTAddDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTAddDate.ForeColor = System.Drawing.Color.Black
        Me.TEXTAddDate.Location = New System.Drawing.Point(109, 28)
        Me.TEXTAddDate.Name = "TEXTAddDate"
        Me.TEXTAddDate.ReadOnly = True
        Me.TEXTAddDate.Size = New System.Drawing.Size(120, 22)
        Me.TEXTAddDate.TabIndex = 755
        Me.TEXTAddDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(235, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 15)
        Me.Label26.TabIndex = 756
        Me.Label26.Text = " «—ÌŒ Êﬁ   «·«÷«›…"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InternalAuditorERBUTTON
        '
        Me.InternalAuditorERBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.InternalAuditorERBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InternalAuditorERBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InternalAuditorERBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.InternalAuditorERBUTTON.Image = Global.CC_JO.My.Resources.Resources.Apply_16x16
        Me.InternalAuditorERBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InternalAuditorERBUTTON.Location = New System.Drawing.Point(2, 66)
        Me.InternalAuditorERBUTTON.Name = "InternalAuditorERBUTTON"
        Me.InternalAuditorERBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.InternalAuditorERBUTTON.Size = New System.Drawing.Size(482, 30)
        Me.InternalAuditorERBUTTON.TabIndex = 831
        Me.InternalAuditorERBUTTON.Text = "„‹—«Ã‹‹‹‹‹‹‹‹‹‹⁄‹… Ê  œﬁÌ‹‹‹‹ﬁ «·Õ”‹‹‹‹‹‹«»‹«  F7"
        Me.InternalAuditorERBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InternalAuditorERBUTTON.UseVisualStyleBackColor = False
        '
        'ButtonCancellationAuditingAndACheckingAccounts
        '
        Me.ButtonCancellationAuditingAndACheckingAccounts.BackColor = System.Drawing.Color.Transparent
        Me.ButtonCancellationAuditingAndACheckingAccounts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCancellationAuditingAndACheckingAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancellationAuditingAndACheckingAccounts.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonCancellationAuditingAndACheckingAccounts.Image = Global.CC_JO.My.Resources.Resources.HistoryItem_16x16
        Me.ButtonCancellationAuditingAndACheckingAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancellationAuditingAndACheckingAccounts.Location = New System.Drawing.Point(2, 98)
        Me.ButtonCancellationAuditingAndACheckingAccounts.Name = "ButtonCancellationAuditingAndACheckingAccounts"
        Me.ButtonCancellationAuditingAndACheckingAccounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCancellationAuditingAndACheckingAccounts.Size = New System.Drawing.Size(482, 30)
        Me.ButtonCancellationAuditingAndACheckingAccounts.TabIndex = 829
        Me.ButtonCancellationAuditingAndACheckingAccounts.Text = "«·€«¡ „‹—«Ã‹‹‹‹‹‹‹‹‹‹⁄‹… Ê  œﬁÌﬁ «·Õ”«»«  F8"
        Me.ButtonCancellationAuditingAndACheckingAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancellationAuditingAndACheckingAccounts.UseVisualStyleBackColor = False
        '
        'CheckLogReview
        '
        Me.CheckLogReview.AutoSize = True
        Me.CheckLogReview.BackColor = System.Drawing.Color.Transparent
        Me.CheckLogReview.Enabled = False
        Me.CheckLogReview.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckLogReview.ForeColor = System.Drawing.Color.Black
        Me.CheckLogReview.Location = New System.Drawing.Point(361, 35)
        Me.CheckLogReview.Name = "CheckLogReview"
        Me.CheckLogReview.Size = New System.Drawing.Size(123, 19)
        Me.CheckLogReview.TabIndex = 828
        Me.CheckLogReview.Text = " „  „—«Ã⁄… Â–« «·”Ã·"
        Me.CheckLogReview.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(859, 364)
        Me.TabControl1.TabIndex = 921
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.Panel13)
        Me.TabPage1.Controls.Add(Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(851, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "»Ì«‰«  ⁄«„…"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel13
        '
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.GroupBox5)
        Me.Panel13.Controls.Add(Me.GroupBox6)
        Me.Panel13.Location = New System.Drawing.Point(6, 232)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(840, 103)
        Me.Panel13.TabIndex = 958
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Panel12)
        Me.GroupBox5.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox5.Location = New System.Drawing.Point(2, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(326, 94)
        Me.GroupBox5.TabIndex = 959
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "—’Ìœ «·„ÊŸ›"
        '
        'Panel12
        '
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.TextEmployeeCredit)
        Me.Panel12.Controls.Add(Me.Label2)
        Me.Panel12.Controls.Add(Me.Label1)
        Me.Panel12.Controls.Add(Me.TextExtraBalance)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 18)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(320, 73)
        Me.Panel12.TabIndex = 958
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(334, 222)
        Me.Panel1.TabIndex = 955
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Panel11)
        Me.GroupBox4.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(326, 222)
        Me.GroupBox4.TabIndex = 958
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "»Ì«‰«  «·ÊŸÌ›…"
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.CheckPermanentEmployee)
        Me.Panel11.Controls.Add(Me.ComboAdministration)
        Me.Panel11.Controls.Add(Me.LblOFFICERDEPARTMENT)
        Me.Panel11.Controls.Add(Me.LblOFFICERPOSITION)
        Me.Panel11.Controls.Add(Me.LblOFFICERNATION)
        Me.Panel11.Controls.Add(Me.ComboFunction)
        Me.Panel11.Controls.Add(Me.TEXTTextNationalNo)
        Me.Panel11.Controls.Add(Me.LblOFFICERWORKFINISH)
        Me.Panel11.Controls.Add(Me.TEXTNumberOfInsurance)
        Me.Panel11.Controls.Add(Me.LblOFFICERWAR)
        Me.Panel11.Controls.Add(Me.LblOFFICERWORKBEGIN)
        Me.Panel11.Controls.Add(Me.EndOfServiceDate)
        Me.Panel11.Controls.Add(Me.ComboMilitaryService)
        Me.Panel11.Controls.Add(Me.DateOfHiring)
        Me.Panel11.Controls.Add(Me.LblOFFICERINSURANCE)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 18)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(320, 201)
        Me.Panel11.TabIndex = 958
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.ButtonViewDocuments)
        Me.TabPage2.Controls.Add(Me.ButtonAttachDocument)
        Me.TabPage2.Controls.Add(Me.DataGridView3)
        Me.TabPage2.Controls.Add(Me.TextBox5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(851, 336)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "„—›ﬁ«  Ê„” ‰œ« "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ButtonAttachDocument
        '
        Me.ButtonAttachDocument.BackColor = System.Drawing.Color.Transparent
        Me.ButtonAttachDocument.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAttachDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAttachDocument.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonAttachDocument.Image = Global.CC_JO.My.Resources.Resources.AddItem_16x16
        Me.ButtonAttachDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAttachDocument.Location = New System.Drawing.Point(439, 302)
        Me.ButtonAttachDocument.Name = "ButtonAttachDocument"
        Me.ButtonAttachDocument.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonAttachDocument.Size = New System.Drawing.Size(409, 30)
        Me.ButtonAttachDocument.TabIndex = 800
        Me.ButtonAttachDocument.Text = "«÷«›… „” ‰œ«  «·„ÊŸ›Ì‰ "
        Me.ButtonAttachDocument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAttachDocument.UseVisualStyleBackColor = False
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridView3.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DOC1, Me.DOC2, Me.DOC4, Me.DOC5, Me.LO11})
        Me.DataGridView3.Location = New System.Drawing.Point(3, 2)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersWidth = 25
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DataGridView3.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView3.Size = New System.Drawing.Size(845, 296)
        Me.DataGridView3.TabIndex = 802
        '
        'DOC1
        '
        Me.DOC1.DataPropertyName = "DOC1"
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DOC1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DOC1.FillWeight = 40.0!
        Me.DOC1.HeaderText = "«·„⁄—›"
        Me.DOC1.Name = "DOC1"
        Me.DOC1.ReadOnly = True
        '
        'DOC2
        '
        Me.DOC2.DataPropertyName = "DOC2"
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DOC2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DOC2.FillWeight = 50.0!
        Me.DOC2.HeaderText = "—ﬁ„ «·„·›"
        Me.DOC2.Name = "DOC2"
        Me.DOC2.ReadOnly = True
        '
        'DOC4
        '
        Me.DOC4.DataPropertyName = "DOC4"
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DOC4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DOC4.FillWeight = 60.0!
        Me.DOC4.HeaderText = "«”„ «·„·›"
        Me.DOC4.Name = "DOC4"
        Me.DOC4.ReadOnly = True
        '
        'DOC5
        '
        Me.DOC5.DataPropertyName = "DOC5"
        Me.DOC5.HeaderText = "Ê’› «·„·›"
        Me.DOC5.Name = "DOC5"
        Me.DOC5.ReadOnly = True
        '
        'LO11
        '
        Me.LO11.DataPropertyName = "lo"
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LO11.DefaultCellStyle = DataGridViewCellStyle5
        Me.LO11.HeaderText = "Column4"
        Me.LO11.Name = "LO11"
        Me.LO11.ReadOnly = True
        Me.LO11.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Enabled = False
        Me.TextBox5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.Black
        Me.TextBox5.Location = New System.Drawing.Point(494, 200)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(86, 22)
        Me.TextBox5.TabIndex = 801
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox5.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.BackgroundImage = Global.CC_JO.My.Resources.Resources.BG3
        Me.TabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage4.Controls.Add(Me.Panel6)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(851, 336)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "»Ì«‰«  «Œ—Ï"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.GroupBox1)
        Me.Panel6.Controls.Add(Me.GroupBox3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(845, 155)
        Me.Panel6.TabIndex = 957
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel9)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(495, 153)
        Me.GroupBox1.TabIndex = 956
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "«·„—«Ã⁄…"
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.InternalAuditorERBUTTON)
        Me.Panel9.Controls.Add(Me.CheckLogReview)
        Me.Panel9.Controls.Add(Me.ButtonCancellationAuditingAndACheckingAccounts)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 18)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(489, 132)
        Me.Panel9.TabIndex = 958
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.Load1)
        Me.Panel4.Controls.Add(Me.ButtonUpdateA)
        Me.Panel4.Controls.Add(Me.DELETEBUTTON)
        Me.Panel4.Controls.Add(Me.LASTBUTTON)
        Me.Panel4.Controls.Add(Me.BUTTONCANCEL)
        Me.Panel4.Controls.Add(Me.EDITBUTTON)
        Me.Panel4.Controls.Add(Me.NEXTBUTTON)
        Me.Panel4.Controls.Add(Me.SAVEBUTTON)
        Me.Panel4.Controls.Add(Me.ADDBUTTON)
        Me.Panel4.Controls.Add(Me.RECORDSLABEL)
        Me.Panel4.Controls.Add(Me.PREVIOUSBUTTON)
        Me.Panel4.Controls.Add(Me.FIRSTBUTTON)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 363)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(859, 79)
        Me.Panel4.TabIndex = 955
        '
        'Load1
        '
        Me.Load1.BackColor = System.Drawing.Color.Transparent
        Me.Load1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Load1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Load1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Load1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Load1.Image = Global.CC_JO.My.Resources.Resources.UpdateTableOfContents_16x16
        Me.Load1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Load1.Location = New System.Drawing.Point(3, 3)
        Me.Load1.Name = "Load1"
        Me.Load1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Load1.Size = New System.Drawing.Size(245, 34)
        Me.Load1.TabIndex = 955
        Me.Load1.Text = " Õ„Ì· «·»Ì«‰« "
        Me.Load1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Load1.UseVisualStyleBackColor = False
        '
        'ButtonUpdateA
        '
        Me.ButtonUpdateA.BackColor = System.Drawing.Color.Transparent
        Me.ButtonUpdateA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonUpdateA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUpdateA.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonUpdateA.Image = Global.CC_JO.My.Resources.Resources.Refresh_16x16
        Me.ButtonUpdateA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonUpdateA.Location = New System.Drawing.Point(3, 38)
        Me.ButtonUpdateA.Name = "ButtonUpdateA"
        Me.ButtonUpdateA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonUpdateA.Size = New System.Drawing.Size(245, 34)
        Me.ButtonUpdateA.TabIndex = 956
        Me.ButtonUpdateA.Text = " ÕœÌÀ Alt + R"
        Me.ButtonUpdateA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonUpdateA.UseVisualStyleBackColor = False
        '
        'ButtonViewDocuments
        '
        Me.ButtonViewDocuments.BackColor = System.Drawing.Color.Transparent
        Me.ButtonViewDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonViewDocuments.Image = Global.CC_JO.My.Resources.Resources.PInternalAuditor_16x16
        Me.ButtonViewDocuments.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonViewDocuments.Location = New System.Drawing.Point(3, 302)
        Me.ButtonViewDocuments.Name = "ButtonViewDocuments"
        Me.ButtonViewDocuments.Size = New System.Drawing.Size(435, 30)
        Me.ButtonViewDocuments.TabIndex = 803
        Me.ButtonViewDocuments.Text = "⁄—÷ „” ‰œ«  «·„ÊŸ›Ì‰"
        Me.ButtonViewDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonViewDocuments.UseVisualStyleBackColor = False
        '
        'FrmEmployees1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(859, 442)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmployees1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "«·„ÊŸ›Ì‰"
        Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.TEXTPHONE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmEmployees1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F1
                        ADDBUTTON_Click(sender, e)
                    Case Keys.F2
                        SAVEBUTTON_Click(sender, e)
                    Case Keys.F3
                        EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        BUTTONCANCEL_Click(sender, e)
                    Case Keys.F6
                        DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        ButtonXP3_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        ButtonXP5_Click(sender, e)
                    Case Keys.PageDown
                        PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmEmployees1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage4.Show()
    End Sub
    Private Sub FrmEmployees1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonAttachDocument.Enabled = False
        Me.ButtonViewDocuments.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
    End Sub

    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load1.Click
        On Error Resume Next
        ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        ConnectDataBase.RunWorkerAsync()
        Me.Load1.Enabled = False
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            myds.EnforceConstraints = False
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  EMP1, EMP2, EMP3, EMP4, EMP5, EMP6, EMP7, EMP8, EMP9, EMP10, EMP11, EMP12, EMP13, EMP14, EMP15, EMP16, EMP17, EMP18, EMP19, EMP20, EMP21, EMP22, EMP23, EMP24, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM EMPLOYEES  WHERE  CUser='" & CUser & "'ORDER BY EMP1"
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                myds = New DataSet
                If Consum.State = ConnectionState.Closed Then Consum.Open()
                SqlDataAdapter1.TableMappings.Add("Table1", "EMPLOYEES")
                SqlDataAdapter1.Fill(myds, "EMPLOYEES")
                myds.RejectChanges()
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            Consum.Close()
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then

            Else
                Me.Close()

            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            BS.DataSource = myds.Tables("EMPLOYEES")
            RowCount = BS.Count
            TEXTEmployeeCode.DataBindings.Add("text", BS, "EMP1", True, 1, "")
            ComboEmployeeName.DataBindings.Add("text", BS, "EMP2", True, 1, "")
            TEXTAddress.DataBindings.Add("text", BS, "EMP3", True, 1, "")
            TEXTPHONE.DataBindings.Add("text", BS, "EMP4", True, 1, "")
            ComboMaritalStatus.DataBindings.Add("text", BS, "EMP5", True, 1, "")
            ComboQualification.DataBindings.Add("text", BS, "EMP6", True, 1, "")
            ComboFunction.DataBindings.Add("text", BS, "EMP7", True, 1, "")
            ComboAdministration.DataBindings.Add("text", BS, "EMP8", True, 1, "")
            DateOfBirth.DataBindings.Add("text", BS, "EMP9", True, 1, "")
            DateOfHiring.DataBindings.Add("text", BS, "EMP10", True, 1, "")
            EndOfServiceDate.DataBindings.Add("text", BS, "EMP11", True, 1, "")
            TEXTTextNationalNo.DataBindings.Add("text", BS, "EMP12", True, 1, "")
            TEXTNumberOfInsurance.DataBindings.Add("text", BS, "EMP13", True, 1, "")
            ComboMilitaryService.DataBindings.Add("text", BS, "EMP14", True, 1, "")
            TEXTPreviousLeaveBalance.DataBindings.Add("text", BS, "EMP15", True, 1, "")
            TEXTAnnualLeaveBalance.DataBindings.Add("text", BS, "EMP16", True, 1, "")
            TEXTTotalLeaveBalance.DataBindings.Add("text", BS, "EMP17", True, 1, "")
            TEXTDaysOfAbsence.DataBindings.Add("text", BS, "EMP18", True, 1, "")
            TEXTSanctionsDays.DataBindings.Add("text", BS, "EMP19", True, 1, "")
            TEXTUnpaidLeave.DataBindings.Add("text", BS, "EMP20", True, 1, "")
            TextEmployeeCredit.DataBindings.Add("text", BS, "EMP21", True, 1, "")
            CheckPermanentEmployee.DataBindings.Add("Checked", BS, "EMP22", True, 1, "")
            TextExtraBalance.DataBindings.Add("text", BS, "EMP23", True, 1, "")
            CheckLogReview.DataBindings.Add("Checked", BS, "EMP24", True, 1, "")
            TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
            TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
            TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
            TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            TEXTReviewDate.DataBindings.Add("text", BS, "da1", True, 1, "")
            TextreviewTime.DataBindings.Add("text", BS, "ne1", True, 1, "")
            RecordCount()
            SHOWBUTTON()
            Me.SAVEBUTTON.Enabled = False
            Call MangUsers()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Consum.Close()
        End Try

    End Sub
    Private Sub SAVERECORD()
        Try
            Dim N As Double
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(EMP1) FROM EMPLOYEES", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()
            Dim SQL As String = "INSERT INTO EMPLOYEES( EMP2, EMP3, EMP4, EMP5, EMP6, EMP7, EMP8, EMP9, EMP10, EMP11, EMP12, EMP13, EMP14, EMP15, EMP16, EMP17, EMP18, EMP19, EMP20, EMP21, EMP22, EMP24, USERNAME, Cuser, COUSER, da, ne) VALUES     ( @EMP2, @EMP3, @EMP4, @EMP5, @EMP6, @EMP7, @EMP8, @EMP9, @EMP10, @EMP11, @EMP12, @EMP13, @EMP14, @EMP15, @EMP16, @EMP17, @EMP18, @EMP19, @EMP20, @EMP21, @EMP22, @EMP24, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EMP1", SqlDbType.NVarChar).Value = Val(N) + 1
                .Parameters.Add("@EMP2", SqlDbType.NVarChar).Value = Me.ComboEmployeeName.Text
                .Parameters.Add("@EMP3", SqlDbType.NVarChar).Value = Me.TEXTAddress.Text
                .Parameters.Add("@EMP4", SqlDbType.NVarChar).Value = Me.TEXTPHONE.EditValue
                .Parameters.Add("@EMP5", SqlDbType.NVarChar).Value = Me.ComboMaritalStatus.Text
                .Parameters.Add("@EMP6", SqlDbType.NVarChar).Value = Me.ComboQualification.Text
                .Parameters.Add("@EMP7", SqlDbType.NVarChar).Value = Me.ComboFunction.Text
                .Parameters.Add("@EMP8", SqlDbType.NVarChar).Value = Me.ComboAdministration.Text
                .Parameters.Add("@EMP9", SqlDbType.NVarChar).Value = Me.DateOfBirth.Text
                .Parameters.Add("@EMP10", SqlDbType.NVarChar).Value = Me.DateOfHiring.Text
                .Parameters.Add("@EMP11", SqlDbType.NVarChar).Value = Me.EndOfServiceDate.Text
                .Parameters.Add("@EMP12", SqlDbType.NVarChar).Value = Me.TEXTTextNationalNo.Text
                .Parameters.Add("@EMP13", SqlDbType.NVarChar).Value = Me.TEXTNumberOfInsurance.Text
                .Parameters.Add("@EMP14", SqlDbType.NVarChar).Value = Me.ComboMilitaryService.Text
                .Parameters.Add("@EMP15", SqlDbType.NVarChar).Value = Me.TEXTPreviousLeaveBalance.Text
                .Parameters.Add("@EMP16", SqlDbType.NVarChar).Value = Me.TEXTAnnualLeaveBalance.Text
                .Parameters.Add("@EMP17", SqlDbType.NVarChar).Value = Me.TEXTTotalLeaveBalance.Text
                .Parameters.Add("@EMP18", SqlDbType.NVarChar).Value = Me.TEXTDaysOfAbsence.Text
                .Parameters.Add("@EMP19", SqlDbType.NVarChar).Value = Me.TEXTSanctionsDays.Text
                .Parameters.Add("@EMP20", SqlDbType.NVarChar).Value = Me.TEXTUnpaidLeave.Text
                .Parameters.Add("@EMP21", SqlDbType.NVarChar).Value = Me.TextEmployeeCredit.Text
                .Parameters.Add("@EMP22", SqlDbType.NVarChar).Value = Convert.ToInt32(Me.CheckPermanentEmployee.Checked)
                .Parameters.Add("@EMP24", SqlDbType.NVarChar).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update EMPLOYEES SET  EMP2 = @EMP2, EMP3 = @EMP3, EMP4 = @EMP4, EMP5 = @EMP5, EMP6 = @EMP6, EMP7 = @EMP7, EMP8 = @EMP8, EMP9 = @EMP9, EMP10 = @EMP10, EMP11 = @EMP11, EMP12 = @EMP12, EMP13 = @EMP13, EMP14 = @EMP14, EMP15 = @EMP15, EMP16 = @EMP16, EMP17= @EMP17, EMP18 = @EMP18, EMP19 = @EMP19, EMP20 = @EMP20, EMP21 = @EMP21, EMP22 = @EMP22, EMP24 = @EMP24, USERNAME = @USERNAME, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE EMP1 = @EMP1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EMP1", SqlDbType.NVarChar).Value = Me.TEXTEmployeeCode.Text
                .Parameters.Add("@EMP2", SqlDbType.NVarChar).Value = Me.ComboEmployeeName.Text
                .Parameters.Add("@EMP3", SqlDbType.NVarChar).Value = Me.TEXTAddress.Text
                .Parameters.Add("@EMP4", SqlDbType.NVarChar).Value = Me.TEXTPHONE.EditValue
                .Parameters.Add("@EMP5", SqlDbType.NVarChar).Value = Me.ComboMaritalStatus.Text
                .Parameters.Add("@EMP6", SqlDbType.NVarChar).Value = Me.ComboQualification.Text
                .Parameters.Add("@EMP7", SqlDbType.NVarChar).Value = Me.ComboFunction.Text
                .Parameters.Add("@EMP8", SqlDbType.NVarChar).Value = Me.ComboAdministration.Text
                .Parameters.Add("@EMP9", SqlDbType.NVarChar).Value = Me.DateOfBirth.Text
                .Parameters.Add("@EMP10", SqlDbType.NVarChar).Value = Me.DateOfHiring.Text
                .Parameters.Add("@EMP11", SqlDbType.NVarChar).Value = Me.EndOfServiceDate.Text
                .Parameters.Add("@EMP12", SqlDbType.NVarChar).Value = Me.TEXTTextNationalNo.Text
                .Parameters.Add("@EMP13", SqlDbType.NVarChar).Value = Me.TEXTNumberOfInsurance.Text
                .Parameters.Add("@EMP14", SqlDbType.NVarChar).Value = Me.ComboMilitaryService.Text
                .Parameters.Add("@EMP15", SqlDbType.NVarChar).Value = Me.TEXTPreviousLeaveBalance.Text
                .Parameters.Add("@EMP16", SqlDbType.NVarChar).Value = Me.TEXTAnnualLeaveBalance.Text
                .Parameters.Add("@EMP17", SqlDbType.NVarChar).Value = Me.TEXTTotalLeaveBalance.Text
                .Parameters.Add("@EMP18", SqlDbType.NVarChar).Value = Me.TEXTDaysOfAbsence.Text
                .Parameters.Add("@EMP19", SqlDbType.NVarChar).Value = Me.TEXTSanctionsDays.Text
                .Parameters.Add("@EMP20", SqlDbType.NVarChar).Value = Me.TEXTUnpaidLeave.Text
                .Parameters.Add("@EMP21", SqlDbType.NVarChar).Value = Me.TextEmployeeCredit.Text
                .Parameters.Add("@EMP22", SqlDbType.NVarChar).Value = Convert.ToInt32(Me.CheckPermanentEmployee.Checked)
                .Parameters.Add("@EMP24", SqlDbType.NVarChar).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub


    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            myds = New DataSet
            SqlDataAdapter1.Fill(myds, "EMPLOYEES")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            BS.DataSource = myds.Tables("EMPLOYEES")
            PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Count()
            If DelRow = False Then
                If BS.Count < RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & RowCount - BS.Count, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                ElseIf BS.Count > RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & BS.Count - RowCount, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
            Call CloseDB()
1:

            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            'Call ConnectDB()
            'SqlDataAdapter1.Update(myds, "EMPLOYEES")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "EMPLOYEES")

        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                PictureBox2False()
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            Call CloseDB()
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                ButtonXP5_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If

            Application.DoEvents()
            BS.DataSource = myds.Tables("EMPLOYEES")
            Me.Cursor = Cursors.Default

            Count()
            Label1.Text = Now
            If BS.Count < RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & RowCount - BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & BS.Count - RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")

                Exit Sub
            End If

            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTEmployeeCode.Text.Trim, "Õ›Ÿ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTEmployeeCode.Text.Trim, " ⁄œÌ·", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
            Me.SAVEBUTTON.Enabled = False
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            ComboEmployeeName.Focus()
            ComboEmployeeName.SelectAll()
        End If
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = BS.Count
        CurrenRecordst = BS.Position + 1
        RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If BS.Position < myds.Tables("EMPLOYEES").Rows.Count - 1 Then
            Forward = True
        End If
        FIRSTBUTTON.Enabled = Back
        PREVIOUSBUTTON.Enabled = Back
        NEXTBUTTON.Enabled = Forward
        LASTBUTTON.Enabled = Forward
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL1 As New SqlClient.SqlCommand("SELECT  DOC1, LO, DOC2, DOC4, DOC5 FROM MYDOCUMENTSHOME WHERE  CUser='" & ModuleGeneral.CUser & "' and LO ='" & Me.TEXTTextNationalNo.Text.Trim & "'", Consum)
        Dim ds11 As New DataSet
        Dim dt As New DataTable
        Dim Adp1 As New SqlClient.SqlDataAdapter(strSQL1)
        ds11.Clear()
        Adp1.Fill(ds11, "MYDOCUMENTSHOME")
        Adp1.Fill(dt)
        DataGridView3.DataSource = ds11
        DataGridView3.DataMember = "MYDOCUMENTSHOME"
        InternalAuditorType()
        Me.SAVEBUTTON.Enabled = False
    End Sub

    Public Sub Count()
        On Error Resume Next
        RECORDSLABEL.Text = BS.Position + 1 & " „‰ " & BS.Count
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        RecordCount()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonAttachDocument.Enabled = LockUpdate
        Me.ButtonViewDocuments.Enabled = True
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub
    Private Sub COMBOBOX1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboEmployeeName.KeyDown, DateOfBirth.KeyDown, DateOfHiring.KeyDown, EndOfServiceDate.KeyDown, TEXTAddress.KeyDown, TEXTTextNationalNo.KeyDown, TEXTNumberOfInsurance.KeyDown, TEXTPreviousLeaveBalance.KeyDown, TEXTAnnualLeaveBalance.KeyDown, TEXTTotalLeaveBalance.KeyDown, TEXTDaysOfAbsence.KeyDown, TEXTSanctionsDays.KeyDown, TEXTUnpaidLeave.KeyDown, ComboMaritalStatus.KeyDown, ComboQualification.KeyDown, ComboFunction.KeyDown, ComboAdministration.KeyDown, ComboMilitaryService.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub CLEARDATA()
        On Error Resume Next
        Dim txt As Control
        For Each txt In Me.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If
        Next
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(EMP1) FROM EMPLOYEES", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            TEXTEmployeeCode.Text = 1
        Else
            TEXTEmployeeCode.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()

    End Sub
    Private Sub SEARCHUSERS()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT EMP2  FROM EMPLOYEES  WHERE (EMPLOYEES.EMP2)='" & Me.ComboEmployeeName.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "EMPLOYEES")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show(" „  ”ÃÌ· »Ì«‰«  «·„ÊŸ› ”«»ﬁ«", " ﬂ—«— »Ì«‰«  «·„ÊŸ›", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TEXTAddress.Focus()
            flag = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        BS.Position = 0
        RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position - 1
        RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position + 1
        RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Count - 1
        RecordCount()
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If LockAddRow = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            BS.Position = BS.Count - 1
            BS.EndEdit()
            BS.AddNew()
            CLEARDATA1(Me)
            MAXRECORD()
            Me.ComboMaritalStatus.Text = "„ “ÊÃ"
            Me.ComboMilitaryService.Text = "«⁄›«¡ ‰Â«∆Ï"
            Me.DateOfHiring.Value = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextEmployeeCredit.Text = "0"
            Me.TEXTPreviousLeaveBalance.Text = "0"
            Me.TEXTAnnualLeaveBalance.Text = "30"
            Me.TEXTTotalLeaveBalance.Text = "60"
            Me.TEXTDaysOfAbsence.Text = "0"
            Me.TEXTSanctionsDays.Text = "0"
            Me.TEXTUnpaidLeave.Text = "30"
            Me.CheckPermanentEmployee.Checked = True
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.CheckLogReview.Checked = True
            Me.CheckLogReview.Checked = False
            Count()
            Me.ComboEmployeeName.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Dim Sound As System.IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        Try

            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.Cursor = Cursors.WaitCursor
            PictureBox2.Visible = True
            UPDATERECORD()
            BS.EndEdit()
            RowCount = BS.Count
            SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            SaveTab.RunWorkerAsync()
            Click2 = True
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Count
        SEARCHUSERS()
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.Cursor = Cursors.WaitCursor
        PictureBox2.Visible = True
        SAVERECORD()
        BS.EndEdit()
        RowCount = BS.Count
        SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        SaveTab.RunWorkerAsync()
        BS.Position = P
        ADDBUTTON.Enabled = True
        SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        BS.CancelEdit()
        RecordCount()
        InternalAuditorType()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim strsql1 As New SqlClient.SqlCommand("SELECT DISTINCT EWRK1 FROM EXTRAWORK WHERE EWRK2 = '" & Me.ComboEmployeeName.Text & "'", Consum)
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
        On Error Resume Next
        ds1.Clear()
        Adp1.Fill(ds1, "Suppliers1")
        If ds1.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·«÷«›Ì ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim strsql2 As New SqlClient.SqlCommand("SELECT DISTINCT SLY1 FROM SALARIES WHERE SLY2 = '" & Me.ComboEmployeeName.Text & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp2 As New SqlClient.SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp2.Fill(ds2, "SALARIES")
        If ds2.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·„— »«  ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If

        Dim strsql3 As New SqlClient.SqlCommand("SELECT DISTINCT CST1 FROM EMPCOST WHERE CST3 = '" & Me.TEXTEmployeeCode.Text & "'", Consum)
        Dim ds3 As New DataSet
        Dim Adp3 As New SqlClient.SqlDataAdapter(strsql3)
        On Error Resume Next
        ds3.Clear()
        Adp3.Fill(ds3, "EMPCOST")
        If ds3.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·”·› ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If

        Dim strsql4 As New SqlClient.SqlCommand("SELECT DISTINCT IDCH FROM Checks WHERE CH8 = '" & Me.TEXTEmployeeCode.Text & "'", Consum)
        Dim ds4 As New DataSet
        Dim Adp4 As New SqlClient.SqlDataAdapter(strsql4)
        On Error Resume Next
        ds4.Clear()
        Adp4.Fill(ds4, "Checks")
        If ds4.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·‘Ìﬂ«  ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If

        Dim strsql5 As New SqlClient.SqlCommand("SELECT DISTINCT CSH1 FROM EMPSOLF WHERE CSH15 = '" & Me.TEXTEmployeeCode.Text & "'", Consum)
        Dim ds5 As New DataSet
        Dim Adp5 As New SqlClient.SqlDataAdapter(strsql5)
        On Error Resume Next
        ds5.Clear()
        Adp5.Fill(ds5, "EMPSOLF")
        If ds5.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  ⁄Âœ… «·„ÊŸ›Ì‰ ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        MYDELETERECORD("EMPLOYEES", "EMP1", TEXTEmployeeCode, BS, True)
        Consum.Close()
        FrmEmployees1_Load(sender, e)
        Insert_Actions(Me.TEXTEmployeeCode.Text.Trim, "Õ–›", Me.Text)
    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.DELETEBUTTON.Enabled = False
        Else
            Me.SHOWBUTTON()
        End If
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.RecordCount()
        Me.SAVEBUTTON.Enabled = False
        Me.InternalAuditorType()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        MsgBox(" „  ⁄„·Ì… «·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
        Insert_Actions(Me.TEXTEmployeeCode.Text.Trim, "«·„—«Ã⁄", Me.Text)
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        MsgBox(" „  ⁄„·Ì… ≈·€«¡«·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
        Insert_Actions(Me.TEXTEmployeeCode.Text.Trim, "≈·€«¡ «·„—«Ã⁄…", Me.Text)
    End Sub
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim XLO As Int64
            XLO = Me.DataGridView3.RowCount

            'Dim LOMyDOCUMENTSFL As Object
            'Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            'Dim NumberMyDOCUMENTS As Object = "ME" & Year & Me.TEXTTextNationalNo.Text
            'GetAutoNumberMyDOCUMENTSFL(NumberMyDOCUMENTS)
            'LOMyDOCUMENTSFL = SEARCHDATA.NumberMyDOCUMENTSFL

            Dim f As New FrmJPG0
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = True



            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextLO.Text = TEXTTextNationalNo.Text
            f.TEXTFileNo.Text = Val(XLO) + 1
            f.TEXTFileSubject.Text = "„” ‰œ«  «·„ÊŸ›Ì‰"
            f.TextFileDescription.Text = ""
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDocuments.Click
        Try
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
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Trim(Me.TextBox5.Text), "'"}), Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextBox5.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextBox5.Text)
                f.Show()
                f.TEXTBOX1.Text = Trim(Me.TextBox5.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()

    End Sub
    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellEnter
        Try
            Me.TextBox5.Text = CDbl(DataGridView3("DOC1", DataGridView3.CurrentRow.Index).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DataGridView3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView3.DoubleClick
        Try
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
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Trim(Me.TextBox5.Text), "'"}), Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextBox5.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextBox5.Text)
                f.Show()
                f.TEXTBOX1.Text = Trim(Me.TextBox5.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub

    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            PictureBox2.Visible = True
            RefreshTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
