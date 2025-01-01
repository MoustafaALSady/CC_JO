


Imports System.Threading.Tasks
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors

Imports System.IO

Imports DevExpress.XtraBars
Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows.Forms

Imports DevExpress.XtraTab
Imports System.Diagnostics

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraTab.Buttons
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.Skins
Imports DevExpress.XtraBars.Navigation

Partial Public Class FormDocumentViewer

    Public Sub New()
        InitializeComponent()
    End Sub

    'Public Sub CreateTab()
    '    Dim control As New FormWebPage With {
    '    .Dock = DockStyle.Fill
    '    }
    '    control.IsMdiContainer = False
    '    control.TopLevel = False
    '    'control.MdiParent = New me
    '    'control.TextURL.EditValue = My.Settings.HoomBage
    '    Me.IsMdiContainer = True
    '    With control
    '        'sets the current multiple-document interface(MDI) parent form of this form
    '        .MdiParent = Me
    '        'show the form2
    '        .Show()
    '    End With

    '    'Pageweb.Controls.Add(New FormWebPage() With {.TopLevel = False, .Dock = DockStyle.Fill})

    '    Pageweb.Controls.Add(control)
    'End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSizeimges.SelectedIndexChanged
        Select Case ComboSizeimges.SelectedIndex
            Case 0
                Me.PictureEdit1.Properties.SizeMode = 0
            Case 1
                Me.PictureEdit1.Properties.SizeMode = 1
            Case 2
                Me.PictureEdit1.Properties.SizeMode = 2
            Case 3
                Me.PictureEdit1.Properties.SizeMode = 3
            Case 4
                Me.PictureEdit1.Properties.SizeMode = 4
            Case 5
                Me.PictureEdit1.Properties.SizeMode = 5
        End Select

        'Clip
        'Stretch
        'Zoom
        'StretchHorizontal
        'StretchVertical
        'Squeeze

    End Sub

    Private Sub FormDocumentViewer_LoadAsync(sender As Object, e As EventArgs) Handles MyBase.Load
        'CreateTab()
    End Sub

    Private Sub Butrotolaeft_Click(sender As Object, e As EventArgs) Handles Butrotolaeft.Click
        RotatlaftPictureEdit(Me.PictureEdit1)
    End Sub

    Private Sub Butrotorait_Click(sender As Object, e As EventArgs) Handles Butrotorait.Click
        RotatraeitPictureEdit(Me.PictureEdit1)
    End Sub


End Class
