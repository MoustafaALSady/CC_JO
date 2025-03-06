Imports System.Threading
Public Class Memstatform
<<<<<<< HEAD
    Inherits Form
=======
    Inherits System.Windows.Forms.Form
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    ReadOnly frmmain As New Calculatorform()
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
<<<<<<< HEAD
    Friend WithEvents Lblm1 As Label
    Friend WithEvents Lblm4 As Label
    Friend WithEvents Lblm3 As Label
    Friend WithEvents Lblm2 As Label
    Friend WithEvents Lblm1value As Label
    Friend WithEvents Lblm2value As Label
    Friend WithEvents Lblm3value As Label
    Friend WithEvents Lblm4value As Label
    Friend WithEvents Btm1copy As Button
    Friend WithEvents Btm2copy As Button
    Friend WithEvents Btm3copy As Button
    Friend WithEvents Btm4copy As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Btexit As Button
    <Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New ComponentModel.ComponentResourceManager(GetType(Memstatform))
        Me.Lblm1 = New Label()
        Me.Lblm4 = New Label()
        Me.Lblm3 = New Label()
        Me.Lblm2 = New Label()
        Me.Lblm1value = New Label()
        Me.Lblm2value = New Label()
        Me.Lblm3value = New Label()
        Me.Lblm4value = New Label()
        Me.Btm1copy = New Button()
        Me.Btm2copy = New Button()
        Me.Btm3copy = New Button()
        Me.Btm4copy = New Button()
        Me.Btexit = New Button()
        Me.Panel1 = New Panel()
=======
    Friend WithEvents Lblm1 As System.Windows.Forms.Label
    Friend WithEvents Lblm4 As System.Windows.Forms.Label
    Friend WithEvents Lblm3 As System.Windows.Forms.Label
    Friend WithEvents Lblm2 As System.Windows.Forms.Label
    Friend WithEvents Lblm1value As System.Windows.Forms.Label
    Friend WithEvents Lblm2value As System.Windows.Forms.Label
    Friend WithEvents Lblm3value As System.Windows.Forms.Label
    Friend WithEvents Lblm4value As System.Windows.Forms.Label
    Friend WithEvents Btm1copy As System.Windows.Forms.Button
    Friend WithEvents Btm2copy As System.Windows.Forms.Button
    Friend WithEvents Btm3copy As System.Windows.Forms.Button
    Friend WithEvents Btm4copy As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Btexit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Memstatform))
        Me.Lblm1 = New System.Windows.Forms.Label()
        Me.Lblm4 = New System.Windows.Forms.Label()
        Me.Lblm3 = New System.Windows.Forms.Label()
        Me.Lblm2 = New System.Windows.Forms.Label()
        Me.Lblm1value = New System.Windows.Forms.Label()
        Me.Lblm2value = New System.Windows.Forms.Label()
        Me.Lblm3value = New System.Windows.Forms.Label()
        Me.Lblm4value = New System.Windows.Forms.Label()
        Me.Btm1copy = New System.Windows.Forms.Button()
        Me.Btm2copy = New System.Windows.Forms.Button()
        Me.Btm3copy = New System.Windows.Forms.Button()
        Me.Btm4copy = New System.Windows.Forms.Button()
        Me.Btexit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblm1
        '
        Me.Lblm1.BackColor = System.Drawing.Color.Black
        Me.Lblm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
<<<<<<< HEAD
        Me.Lblm1.Font = New Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm1.Location = New Point(9, 10)
        Me.Lblm1.Name = "lblm1"
        Me.Lblm1.Size = New Size(58, 35)
=======
        Me.Lblm1.Font = New System.Drawing.Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm1.Location = New System.Drawing.Point(9, 10)
        Me.Lblm1.Name = "lblm1"
        Me.Lblm1.Size = New System.Drawing.Size(58, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm1.TabIndex = 1
        Me.Lblm1.Text = "M1"
        '
        'lblm4
        '
        Me.Lblm4.BackColor = System.Drawing.Color.Black
        Me.Lblm4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblm4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
<<<<<<< HEAD
        Me.Lblm4.Font = New Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm4.Location = New Point(9, 118)
        Me.Lblm4.Name = "lblm4"
        Me.Lblm4.Size = New Size(58, 35)
=======
        Me.Lblm4.Font = New System.Drawing.Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm4.Location = New System.Drawing.Point(9, 118)
        Me.Lblm4.Name = "lblm4"
        Me.Lblm4.Size = New System.Drawing.Size(58, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm4.TabIndex = 2
        Me.Lblm4.Text = "M4"
        '
        'lblm3
        '
        Me.Lblm3.BackColor = System.Drawing.Color.Black
        Me.Lblm3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblm3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
<<<<<<< HEAD
        Me.Lblm3.Font = New Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm3.Location = New Point(9, 82)
        Me.Lblm3.Name = "lblm3"
        Me.Lblm3.Size = New Size(58, 35)
=======
        Me.Lblm3.Font = New System.Drawing.Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm3.Location = New System.Drawing.Point(9, 82)
        Me.Lblm3.Name = "lblm3"
        Me.Lblm3.Size = New System.Drawing.Size(58, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm3.TabIndex = 3
        Me.Lblm3.Text = "M3"
        '
        'lblm2
        '
        Me.Lblm2.BackColor = System.Drawing.Color.Black
        Me.Lblm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
<<<<<<< HEAD
        Me.Lblm2.Font = New Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm2.Location = New Point(9, 46)
        Me.Lblm2.Name = "lblm2"
        Me.Lblm2.Size = New Size(58, 35)
=======
        Me.Lblm2.Font = New System.Drawing.Font("Mongolian Baiti", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblm2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lblm2.Location = New System.Drawing.Point(9, 46)
        Me.Lblm2.Name = "lblm2"
        Me.Lblm2.Size = New System.Drawing.Size(58, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm2.TabIndex = 4
        Me.Lblm2.Text = "M2"
        '
        'lblm1value
        '
        Me.Lblm1value.BackColor = System.Drawing.Color.Black
        Me.Lblm1value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
<<<<<<< HEAD
        Me.Lblm1value.Font = New Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm1value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm1value.Location = New Point(68, 10)
        Me.Lblm1value.Name = "lblm1value"
        Me.Lblm1value.Size = New Size(364, 35)
=======
        Me.Lblm1value.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm1value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm1value.Location = New System.Drawing.Point(68, 10)
        Me.Lblm1value.Name = "lblm1value"
        Me.Lblm1value.Size = New System.Drawing.Size(364, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm1value.TabIndex = 5
        Me.Lblm1value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblm2value
        '
        Me.Lblm2value.BackColor = System.Drawing.Color.Black
        Me.Lblm2value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
<<<<<<< HEAD
        Me.Lblm2value.Font = New Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm2value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm2value.Location = New Point(68, 46)
        Me.Lblm2value.Name = "lblm2value"
        Me.Lblm2value.Size = New Size(364, 35)
=======
        Me.Lblm2value.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm2value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm2value.Location = New System.Drawing.Point(68, 46)
        Me.Lblm2value.Name = "lblm2value"
        Me.Lblm2value.Size = New System.Drawing.Size(364, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm2value.TabIndex = 6
        Me.Lblm2value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblm3value
        '
        Me.Lblm3value.BackColor = System.Drawing.Color.Black
        Me.Lblm3value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
<<<<<<< HEAD
        Me.Lblm3value.Font = New Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm3value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm3value.Location = New Point(68, 82)
        Me.Lblm3value.Name = "lblm3value"
        Me.Lblm3value.Size = New Size(364, 35)
=======
        Me.Lblm3value.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm3value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm3value.Location = New System.Drawing.Point(68, 82)
        Me.Lblm3value.Name = "lblm3value"
        Me.Lblm3value.Size = New System.Drawing.Size(364, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm3value.TabIndex = 7
        Me.Lblm3value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblm4value
        '
        Me.Lblm4value.BackColor = System.Drawing.Color.Black
        Me.Lblm4value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
<<<<<<< HEAD
        Me.Lblm4value.Font = New Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm4value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm4value.Location = New Point(68, 118)
        Me.Lblm4value.Name = "lblm4value"
        Me.Lblm4value.Size = New Size(364, 35)
=======
        Me.Lblm4value.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lblm4value.ForeColor = System.Drawing.Color.LimeGreen
        Me.Lblm4value.Location = New System.Drawing.Point(68, 118)
        Me.Lblm4value.Name = "lblm4value"
        Me.Lblm4value.Size = New System.Drawing.Size(364, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Lblm4value.TabIndex = 8
        Me.Lblm4value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btm1copy
        '
        Me.Btm1copy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btm1copy.FlatStyle = System.Windows.Forms.FlatStyle.System
<<<<<<< HEAD
        Me.Btm1copy.Font = New Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm1copy.Location = New Point(665, 6)
        Me.Btm1copy.Name = "btm1copy"
        Me.Btm1copy.Size = New Size(113, 21)
=======
        Me.Btm1copy.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm1copy.Location = New System.Drawing.Point(665, 6)
        Me.Btm1copy.Name = "btm1copy"
        Me.Btm1copy.Size = New System.Drawing.Size(113, 21)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Btm1copy.TabIndex = 0
        Me.Btm1copy.Text = "copy"
        '
        'btm2copy
        '
        Me.Btm2copy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btm2copy.FlatStyle = System.Windows.Forms.FlatStyle.System
<<<<<<< HEAD
        Me.Btm2copy.Font = New Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm2copy.Location = New Point(665, 49)
        Me.Btm2copy.Name = "btm2copy"
        Me.Btm2copy.Size = New Size(113, 21)
=======
        Me.Btm2copy.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm2copy.Location = New System.Drawing.Point(665, 49)
        Me.Btm2copy.Name = "btm2copy"
        Me.Btm2copy.Size = New System.Drawing.Size(113, 21)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Btm2copy.TabIndex = 9
        Me.Btm2copy.Text = "copy"
        '
        'btm3copy
        '
        Me.Btm3copy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btm3copy.FlatStyle = System.Windows.Forms.FlatStyle.System
<<<<<<< HEAD
        Me.Btm3copy.Font = New Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm3copy.Location = New Point(665, 92)
        Me.Btm3copy.Name = "btm3copy"
        Me.Btm3copy.Size = New Size(113, 21)
=======
        Me.Btm3copy.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm3copy.Location = New System.Drawing.Point(665, 92)
        Me.Btm3copy.Name = "btm3copy"
        Me.Btm3copy.Size = New System.Drawing.Size(113, 21)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Btm3copy.TabIndex = 10
        Me.Btm3copy.Text = "copy"
        '
        'btm4copy
        '
        Me.Btm4copy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btm4copy.FlatStyle = System.Windows.Forms.FlatStyle.System
<<<<<<< HEAD
        Me.Btm4copy.Font = New Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm4copy.Location = New Point(665, 134)
        Me.Btm4copy.Name = "btm4copy"
        Me.Btm4copy.Size = New Size(113, 21)
=======
        Me.Btm4copy.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btm4copy.Location = New System.Drawing.Point(665, 134)
        Me.Btm4copy.Name = "btm4copy"
        Me.Btm4copy.Size = New System.Drawing.Size(113, 21)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Btm4copy.TabIndex = 11
        Me.Btm4copy.Text = "copy"
        '
        'btexit
        '
        Me.Btexit.BackColor = System.Drawing.Color.Transparent
        Me.Btexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btexit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btexit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Btexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
<<<<<<< HEAD
        Me.Btexit.Font = New Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btexit.Location = New Point(0, 179)
        Me.Btexit.Name = "btexit"
        Me.Btexit.Size = New Size(451, 26)
=======
        Me.Btexit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btexit.Location = New System.Drawing.Point(0, 179)
        Me.Btexit.Name = "btexit"
        Me.Btexit.Size = New System.Drawing.Size(451, 26)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Btexit.TabIndex = 12
        Me.Btexit.Text = "Exit"
        Me.Btexit.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lblm4value)
        Me.Panel1.Controls.Add(Me.Lblm1)
        Me.Panel1.Controls.Add(Me.Lblm4)
        Me.Panel1.Controls.Add(Me.Lblm3)
        Me.Panel1.Controls.Add(Me.Lblm2)
        Me.Panel1.Controls.Add(Me.Lblm1value)
        Me.Panel1.Controls.Add(Me.Lblm2value)
        Me.Panel1.Controls.Add(Me.Lblm3value)
<<<<<<< HEAD
        Me.Panel1.Location = New Point(3, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(443, 164)
=======
        Me.Panel1.Location = New System.Drawing.Point(3, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 164)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Panel1.TabIndex = 13
        '
        'memstatform
        '
<<<<<<< HEAD
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.Btexit
        Me.ClientSize = New Size(451, 205)
=======
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.Btexit
        Me.ClientSize = New System.Drawing.Size(451, 205)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Btexit)
        Me.Controls.Add(Me.Btm4copy)
        Me.Controls.Add(Me.Btm3copy)
        Me.Controls.Add(Me.Btm2copy)
        Me.Controls.Add(Me.Btm1copy)
        Me.DoubleBuffered = True
<<<<<<< HEAD
        Me.Font = New Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
=======
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "memstatform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Õ«·… «·–«ﬂ—…"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
<<<<<<< HEAD
    Private Sub Memstatform_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub Memstatform_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


<<<<<<< HEAD
    Private Sub Memstatform_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
=======
    Private Sub Memstatform_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'frmmain.lineargradientbrush()
    End Sub


<<<<<<< HEAD
    Private Sub Btm1copy_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Btm1copy.Click
=======
    Private Sub Btm1copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btm1copy.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Clipboard.SetDataObject(Lblm1value.Text)
        Me.Text += "       " & "..." & "       " & "m1 contents copied to clipboard"
        Thread.Sleep(1000)
        Me.Text = "memory status"
    End Sub


<<<<<<< HEAD
    Private Sub Btm2copy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btm2copy.Click
=======
    Private Sub Btm2copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm2copy.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Clipboard.SetDataObject(Lblm2value.Text)
        Me.Text += "       " & "..." & "       " & "m1 contents copied to clipboard"
        Thread.Sleep(1000)
        Me.Text = "memory status"
    End Sub


<<<<<<< HEAD
    Private Sub Btm3copy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btm3copy.Click
=======
    Private Sub Btm3copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm3copy.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Clipboard.SetDataObject(Lblm3value.Text)
        Me.Text += "       " & "..." & "       " & "m1 contents copied to clipboard"
        Thread.Sleep(1000)
        Me.Text = "memory status"
    End Sub


<<<<<<< HEAD
    Private Sub Btm4copy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btm4copy.Click
=======
    Private Sub Btm4copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm4copy.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Clipboard.SetDataObject(Lblm4value.Text)
        Me.Text += "       " & "..." & "       " & "m1 contents copied to clipboard"
        Thread.Sleep(1000)
        Me.Text = "memory status"
    End Sub


<<<<<<< HEAD
    Private Sub Btexit_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Btexit.Click
=======
    Private Sub Btexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btexit.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Close()
    End Sub


<<<<<<< HEAD
    Private Sub Btm1copy_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Btm1copy.MouseEnter
=======
    Private Sub Btm1copy_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm1copy.MouseEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm1.ForeColor = Color.Black
        Lblm1.BackColor = Color.White
        Lblm1value.ForeColor = Color.Lime
    End Sub

<<<<<<< HEAD
    Private Sub Btm1copy_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Btm1copy.MouseLeave
=======
    Private Sub Btm1copy_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm1copy.MouseLeave
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm1.ForeColor = Color.White
        Lblm1.BackColor = Color.Black
        Lblm1value.ForeColor = Color.LimeGreen
    End Sub

<<<<<<< HEAD
    Private Sub Btm2copy_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Btm2copy.MouseEnter
=======
    Private Sub Btm2copy_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm2copy.MouseEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm2.ForeColor = Color.Black
        Lblm2.BackColor = Color.White
        Lblm2value.ForeColor = Color.Lime
    End Sub

<<<<<<< HEAD
    Private Sub Btm2copy_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Btm2copy.MouseLeave
=======
    Private Sub Btm2copy_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm2copy.MouseLeave
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm2.ForeColor = Color.White
        Lblm2.BackColor = Color.Black
        Lblm2value.ForeColor = Color.LimeGreen
    End Sub

<<<<<<< HEAD
    Private Sub Btm3copy_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Btm3copy.MouseEnter
=======
    Private Sub Btm3copy_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm3copy.MouseEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm3.ForeColor = Color.Black
        Lblm3.BackColor = Color.White
        Lblm3value.ForeColor = Color.Lime
    End Sub

<<<<<<< HEAD
    Private Sub Btm3copy_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Btm3copy.MouseLeave
=======
    Private Sub Btm3copy_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm3copy.MouseLeave
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm3.ForeColor = Color.White
        Lblm3.BackColor = Color.Black
        Lblm3value.ForeColor = Color.LimeGreen
    End Sub


<<<<<<< HEAD
    Private Sub Btm4copy_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles Btm4copy.MouseEnter
=======
    Private Sub Btm4copy_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm4copy.MouseEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm4.ForeColor = Color.Black
        Lblm4.BackColor = Color.White
        Lblm4value.ForeColor = Color.Lime
    End Sub

<<<<<<< HEAD
    Private Sub Btm4copy_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Btm4copy.MouseLeave
=======
    Private Sub Btm4copy_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btm4copy.MouseLeave
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Lblm4.ForeColor = Color.White
        Lblm4.BackColor = Color.Black
        Lblm4value.ForeColor = Color.LimeGreen
    End Sub

<<<<<<< HEAD
    Private Sub Memstatform_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
=======
    Private Sub Memstatform_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'lblm1value.Text = calculatorform.m1
        'lblm2value.Text = calculatorform.m2
        'lblm3value.Text = calculatorform.m3
        'lblm4value.Text = calculatorform.m4
    End Sub



<<<<<<< HEAD
    Private Sub Memstatform_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Memstatform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class
