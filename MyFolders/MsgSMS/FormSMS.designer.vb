<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSMS
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSMS))
        Me.cmdSend = New DevComponents.DotNetBar.ButtonX
        Me.phoneNumBox = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.txtSend = New System.Windows.Forms.RichTextBox
        Me.cmdOpen = New DevComponents.DotNetBar.ButtonX
        Me.cmdClose = New DevComponents.DotNetBar.ButtonX
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx
        Me.lblstatStrip = New System.Windows.Forms.Label
        Me.rtbDisplay = New System.Windows.Forms.RichTextBox
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.rdoText = New System.Windows.Forms.RadioButton
        Me.rdoHex = New System.Windows.Forms.RadioButton
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label5 = New System.Windows.Forms.Label
        Me.cboData = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.cboStop = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.cboParity = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBaud = New System.Windows.Forms.ComboBox
        Me.cboPort = New System.Windows.Forms.ComboBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSend
        '
        Me.cmdSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdSend.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdSend.Location = New System.Drawing.Point(3, 294)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(91, 31)
        Me.cmdSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmdSend.TabIndex = 0
        Me.cmdSend.Text = "إرسال"
        '
        'phoneNumBox
        '
        Me.phoneNumBox.Location = New System.Drawing.Point(3, 183)
        Me.phoneNumBox.Name = "phoneNumBox"
        Me.phoneNumBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.phoneNumBox.Size = New System.Drawing.Size(225, 20)
        Me.phoneNumBox.TabIndex = 1
        Me.phoneNumBox.Text = "+962772493821"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.Doveofpeace
        Me.PictureBox2.Location = New System.Drawing.Point(464, 289)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(63, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 193
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox3.Location = New System.Drawing.Point(482, 289)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 730
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 10000
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.CC_JO.My.Resources.Resources.indecator1
        Me.PictureBox4.Location = New System.Drawing.Point(482, 289)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 733
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'txtSend
        '
        Me.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSend.Location = New System.Drawing.Point(0, 209)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtSend.Size = New System.Drawing.Size(228, 76)
        Me.txtSend.TabIndex = 734
        Me.txtSend.Text = "+962772493821"
        '
        'cmdOpen
        '
        Me.cmdOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdOpen.Font = New System.Drawing.Font("Traditional Arabic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdOpen.Location = New System.Drawing.Point(464, 183)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(80, 31)
        Me.cmdOpen.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.cmdOpen.TabIndex = 735
        Me.cmdOpen.Text = "Connect"
        '
        'cmdClose
        '
        Me.cmdClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdClose.Font = New System.Drawing.Font("Traditional Arabic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(464, 220)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(80, 29)
        Me.cmdClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.cmdClose.TabIndex = 737
        Me.cmdClose.Text = "Disconnect"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ButtonX2)
        Me.PanelEx1.Controls.Add(Me.PanelEx2)
        Me.PanelEx1.Controls.Add(Me.PictureBox2)
        Me.PanelEx1.Controls.Add(Me.cmdSend)
        Me.PanelEx1.Controls.Add(Me.PictureBox4)
        Me.PanelEx1.Controls.Add(Me.PictureBox3)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(2, 1)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(643, 329)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 737
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonX2.Location = New System.Drawing.Point(100, 294)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(91, 31)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 742
        Me.ButtonX2.Text = "إعادة تحميل"
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.cmdClose)
        Me.PanelEx2.Controls.Add(Me.lblstatStrip)
        Me.PanelEx2.Controls.Add(Me.rtbDisplay)
        Me.PanelEx2.Controls.Add(Me.cmdOpen)
        Me.PanelEx2.Controls.Add(Me.groupBox3)
        Me.PanelEx2.Controls.Add(Me.LabelX2)
        Me.PanelEx2.Controls.Add(Me.LabelX1)
        Me.PanelEx2.Controls.Add(Me.groupBox2)
        Me.PanelEx2.Controls.Add(Me.phoneNumBox)
        Me.PanelEx2.Controls.Add(Me.txtSend)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx2.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(643, 288)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 737
        '
        'lblstatStrip
        '
        Me.lblstatStrip.AutoSize = True
        Me.lblstatStrip.Location = New System.Drawing.Point(243, 272)
        Me.lblstatStrip.Name = "lblstatStrip"
        Me.lblstatStrip.Size = New System.Drawing.Size(19, 13)
        Me.lblstatStrip.TabIndex = 741
        Me.lblstatStrip.Text = "..."
        '
        'rtbDisplay
        '
        Me.rtbDisplay.Location = New System.Drawing.Point(1, 3)
        Me.rtbDisplay.Name = "rtbDisplay"
        Me.rtbDisplay.Size = New System.Drawing.Size(543, 174)
        Me.rtbDisplay.TabIndex = 742
        Me.rtbDisplay.Text = ""
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.rdoText)
        Me.groupBox3.Controls.Add(Me.rdoHex)
        Me.groupBox3.Location = New System.Drawing.Point(550, 225)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(94, 60)
        Me.groupBox3.TabIndex = 741
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Mode"
        '
        'rdoText
        '
        Me.rdoText.AutoSize = True
        Me.rdoText.Checked = True
        Me.rdoText.Location = New System.Drawing.Point(15, 37)
        Me.rdoText.Name = "rdoText"
        Me.rdoText.Size = New System.Drawing.Size(47, 17)
        Me.rdoText.TabIndex = 1
        Me.rdoText.TabStop = True
        Me.rdoText.Text = "Text"
        Me.rdoText.UseVisualStyleBackColor = True
        '
        'rdoHex
        '
        Me.rdoHex.AutoSize = True
        Me.rdoHex.Location = New System.Drawing.Point(15, 15)
        Me.rdoHex.Name = "rdoHex"
        Me.rdoHex.Size = New System.Drawing.Size(44, 17)
        Me.rdoHex.TabIndex = 0
        Me.rdoHex.Text = "Hex"
        Me.rdoHex.UseVisualStyleBackColor = True
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Enabled = False
        Me.LabelX2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(234, 213)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(51, 19)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "رســــالـــة"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(234, 183)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(54, 19)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "رقم الهاتف"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.cboData)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.cboStop)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.cboParity)
        Me.groupBox2.Controls.Add(Me.Label1)
        Me.groupBox2.Controls.Add(Me.cboBaud)
        Me.groupBox2.Controls.Add(Me.cboPort)
        Me.groupBox2.Location = New System.Drawing.Point(550, 0)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(96, 221)
        Me.groupBox2.TabIndex = 741
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Options"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 179)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(50, 13)
        Me.label5.TabIndex = 19
        Me.label5.Text = "Data Bits"
        '
        'cboData
        '
        Me.cboData.FormattingEnabled = True
        Me.cboData.Items.AddRange(New Object() {"7", "8", "9"})
        Me.cboData.Location = New System.Drawing.Point(9, 195)
        Me.cboData.Name = "cboData"
        Me.cboData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboData.Size = New System.Drawing.Size(76, 21)
        Me.cboData.TabIndex = 14
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(7, 139)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(49, 13)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Stop Bits"
        '
        'cboStop
        '
        Me.cboStop.FormattingEnabled = True
        Me.cboStop.Location = New System.Drawing.Point(9, 155)
        Me.cboStop.Name = "cboStop"
        Me.cboStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboStop.Size = New System.Drawing.Size(76, 21)
        Me.cboStop.TabIndex = 13
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 98)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(35, 13)
        Me.label3.TabIndex = 17
        Me.label3.Text = "Parity"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 58)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(57, 13)
        Me.label2.TabIndex = 16
        Me.label2.Text = "Baud Rate"
        '
        'cboParity
        '
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Location = New System.Drawing.Point(9, 114)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboParity.Size = New System.Drawing.Size(76, 21)
        Me.cboParity.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Port"
        '
        'cboBaud
        '
        Me.cboBaud.FormattingEnabled = True
        Me.cboBaud.Items.AddRange(New Object() {"300", "600", "1200", "2400", "4800", "9600", "14400", "28800", "36000", "115000"})
        Me.cboBaud.Location = New System.Drawing.Point(9, 74)
        Me.cboBaud.Name = "cboBaud"
        Me.cboBaud.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboBaud.Size = New System.Drawing.Size(76, 21)
        Me.cboBaud.TabIndex = 11
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(9, 34)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPort.Size = New System.Drawing.Size(76, 21)
        Me.cboPort.TabIndex = 10
        '
        'FormSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 332)
        Me.Controls.Add(Me.PanelEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSMS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMS"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSend As DevComponents.DotNetBar.ButtonX
    Friend WithEvents phoneNumBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents txtSend As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdOpen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblstatStrip As System.Windows.Forms.Label
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdClose As DevComponents.DotNetBar.ButtonX
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents cboData As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents cboStop As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cboParity As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cboBaud As System.Windows.Forms.ComboBox
    Private WithEvents cboPort As System.Windows.Forms.ComboBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents rdoText As System.Windows.Forms.RadioButton
    Private WithEvents rdoHex As System.Windows.Forms.RadioButton
    Private WithEvents rtbDisplay As System.Windows.Forms.RichTextBox
End Class
