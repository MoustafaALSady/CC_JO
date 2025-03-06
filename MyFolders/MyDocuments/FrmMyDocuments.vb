Imports System.Diagnostics
Imports System.IO
'Imports Syncfusion.Pdf
'Imports Syncfusion.Pdf.Graphics
'Imports Syncfusion.Pdf.Parsing
'Imports Syncfusion.Pdf.Security
Imports DevExpress.Pdf

Public Class FrmMyDocuments
    'Dim ds1 As New DataSet
    'Dim WithEvents BS As New BindingSource
<<<<<<< HEAD
    Private Sub FrmMyDocuments_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmMyDocuments_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.CMDBROWSE_Click(sender, e)
                Case Keys.F2
                    Me.CMDBROWSE2_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmDOC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
=======
    Private Sub FrmDOC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        'ds1.EnforceConstraints = False
        'Dim str1 As New SqlCommand("", Consum)
        'With str1
        '    .CommandText = "SELECT * FROM CABLESCOEMPLOYEES  WHERE  CUser='" & CUser & "' ORDER BY CEMP1 "
        '    If Consum.State = ConnectionState.Open Then Consum.Close()
        '    Consum.Open()
        '    SqlDataAdapter1 = New SqlDataAdapter(str1)
        '    Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
        '    ds.Clear()
        '    SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
        '    BS.DataSource = ds
        '    BS.DataMember = "CABLESCOEMPLOYEES"
        'End With
        'Me.ComboBox1.DataSource = BS
        'Me.ComboBox1.DisplayMember = "CEMP3"
        'ds.EnforceConstraints = True
        'SqlDataAdapter1.Dispose()
        'Consum.Close()
        FILLCOMBOBOX3("DOCUMENTS", "DOC4", "CUser", CUser, "DOC3", Trim(".pdf"), Me.ComboBox1)
    End Sub
<<<<<<< HEAD
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMDBROWSE.Click
=======
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.OpenFileDialog1.RestoreDirectory = True
            Me.OpenFileDialog1.InitialDirectory = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|Adobe PDF Files (*.pdf)|*.pdf|AllFiles (*.*)|*.*"
            With Me.OpenFileDialog1
                .FilterIndex = 2
                .Title = "Õœœ «·„·› «·–Ï  —Ìœ › Õ…"
                .ShowDialog()
                If Len(.FileName) > 0 Then
                    If .FilterIndex <> 2 Then
                        Me.ComboBox1.Text = Me.OpenFileDialog1.FileName
                        Exit Sub
                    End If
                    Me.ComboBox1.Text = Me.OpenFileDialog1.FileName
                    'Me.AxAcroPDF1.Visible = False
                    Me.AxAcroPDF1.Visible = True
                    Me.AxAcroPDF1.src = Me.OpenFileDialog1.FileName
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            'Me.AxAcroPDF1.Visible = False
            Me.AxAcroPDF1.Visible = True
            Me.AxAcroPDF1.LoadFile(Me.OpenFileDialog1.FileName)
            Me.AxAcroPDF1.setShowToolbar(True)
            Me.AxAcroPDF1.setView("fit width")
            Me.AxAcroPDF1.setLayoutMode("continuous")
            Me.AxAcroPDF1.Show()
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub CMDBROWSE2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMDBROWSE2.Click
=======
    Private Sub CMDBROWSE2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If File.Exists(mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA") & "\" & Me.ComboBox1.Text + ".pdf") = True Then
                'Me.AxAcroPDF1.Visible = False
                'Me.AxAcroPDF1.Visible = True
                Me.OpenFileDialog1.FileName = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA") & "\" & Me.ComboBox1.Text + ".pdf"
                'Me.AxAcroPDF1.Navigate(Me.ComboBox1.Text + ".pdf")
                Me.ComboBox1.Text = Me.OpenFileDialog1.FileName
                Me.AxAcroPDF1.src = Me.ComboBox1.Text
            Else
                MessageBox.Show(" Â–« «·„·› €Ì— „ÊÃÊœ ﬁÏ «·„”«— «·„Õœœ", Me.ComboBox1.Text + ".pdf", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub CMDBROWSE3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMDBROWSE3.Click
=======
    Private Sub CMDBROWSE3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE3.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            'Me.OpenFileDialog1.RestoreDirectory = True
            'Me.OpenFileDialog1.InitialDirectory = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            'Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|Adobe PDF Files (*.pdf)|*.pdf|AllFiles (*.*)|*.*"
            'With Me.OpenFileDialog1
            '    .FilterIndex = 2
            '    .Title = "Õœœ «·„·› «·–Ï  —Ìœ › Õ…"
            '    .ShowDialog()
            '    If Len(.FileName) > 0 Then
            '        Process.Start(Me.OpenFileDialog1.FileName)
            '    Else
            '        Exit Sub
            '    End If
            'End With


            MainOpenFileDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub MainOpenFileDialog()

        Me.OpenFileDialog1.RestoreDirectory = True
        Me.OpenFileDialog1.InitialDirectory = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|Adobe PDF Files (*.pdf)|*.pdf|AllFiles (*.*)|*.*"
        With Me.OpenFileDialog1
            .FilterIndex = 2
            .Title = "Õœœ «·„·› «·–Ï  —Ìœ › Õ…"
            .ShowDialog()
            If Len(.FileName) > 0 Then
                Process.Start(Me.OpenFileDialog1.FileName)
            Else
                Exit Sub
            End If
        End With



        'Dim loadedDocument As PdfLoadedDocument = New PdfLoadedDocument(Me.OpenFileDialog1.FileName)
        'Dim page As PdfLoadedPage = TryCast(loadedDocument.Pages(0), PdfLoadedPage)
        'Dim form As PdfLoadedForm = loadedDocument.Form
        'TryCast(form.Fields("Name"), PdfLoadedTextBoxField).Text = "Simons"
        'TryCast(form.Fields("Email address"), PdfLoadedTextBoxField).Text = "simonsbistro@outlook.com"
        'TryCast(form.Fields("Phone"), PdfLoadedTextBoxField).Text = "31 12 34 56"
        'TryCast(form.Fields("Gender"), PdfLoadedRadioButtonListField).SelectedIndex = 0
        'TryCast(form.Fields("JobTitle"), PdfLoadedComboBoxField).SelectedIndex = 1
        'TryCast(form.Fields("Languages"), PdfLoadedListBoxField).SelectedIndex = New Integer(0) {2}
        'TryCast(form.Fields("Associate degree"), PdfLoadedCheckBoxField).Items(0).Checked = True
        'Dim signatureField As PdfLoadedSignatureField = TryCast(loadedDocument.Form.Fields(9), PdfLoadedSignatureField)
        'Dim certificate As PdfCertificate = New PdfCertificate(Path.Combine(Application.StartupPath, "PDF.pfx"), "syncfusion")


        'signatureField.Signature = New PdfSignature(loadedDocument, page, certificate, "Signature", signatureField)
        'Dim signatureImage As PdfBitmap = New PdfBitmap(Path.Combine(Application.StartupPath, USERNAME & ".Png"))

        'signatureField.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage, New PointF(5, 5), New SizeF(100, 20))
        'loadedDocument.Save("Form.pdf")
        'loadedDocument.Close(True)
        'Process.Start("Form.pdf")

        'Using processor As New PdfDocumentProcessor()
        ' Create an empty document. 
        'processor.CreateEmptyDocument(Me.OpenFileDialog1.FileName)
        ' Create graphics and draw a signature field.
        'Using graphics As PdfGraphics = processor.CreateGraphics()
        '    DrawFormFields(graphics)
        ' Render a page with graphics.

        'processor.RenderNewPage(PdfPaperSize.Letter, graphics)

        'With Me.OpenFileDialog1
        '    .FilterIndex = 2
        '    .Title = "Õœœ «·„·› «·–Ï  —Ìœ › Õ…"
        '    .ShowDialog()
        '    If Len(.FileName) > 0 Then
        '        'Me.AxAcroPDF1.Visible = False
        '        Me.AxAcroPDF1.Visible = True
        '        Me.AxAcroPDF1.src = processor.RenderNewPage(PdfPaperSize.Letter, graphics)
        '    Else
        '        Exit Sub
        '    End If
        'End With



        '    End Using
        'End Using
    End Sub
    Private Shared Sub DrawFormFields(ByVal graphics As PdfGraphics)
        ' Create a text box field and specify its location on the page.
        ' Specify text and appearance parameters.
        Dim textBox As New PdfGraphicsAcroFormTextBoxField("text box", New RectangleF(30, 10, 200, 30)) With {
            .Text = "Text Box"
        }
        textBox.Appearance.FontSize = 12
        textBox.Appearance.BackgroundColor = Color.AliceBlue
        ' Add the text box field to graphics.
        graphics.AddFormField(textBox)
        ' Create a radio group field.
        Dim radioGroup As New PdfGraphicsAcroFormRadioGroupField("First Group")
        ' Add the first radio button to the group and specify its location.
        radioGroup.AddButton("button1", New RectangleF(30, 60, 20, 20))
        ' Add the second radio button to the group.
        radioGroup.AddButton("button2", New RectangleF(30, 90, 20, 20))
        ' Specify radio group selected index,
        radioGroup.SelectedIndex = 0
        ' Specify appearance parameters
        radioGroup.Appearance.BorderAppearance = New PdfGraphicsAcroFormBorderAppearance() With {.Color = Color.Red, .Width = 3}
        ' Add the radio group field to graphics.
        graphics.AddFormField(radioGroup)
    End Sub
    Private Shared Sub DrawSignatureField(ByVal graphics As PdfGraphics)
        ' Create a signature field
        Dim signature As New PdfGraphicsAcroFormSignatureField("signature", New RectangleF(0, 20, 120, 130))

        ' Specify a content image for the signature field.
        Dim image As Image = System.Drawing.Image.FromFile(Path.Combine(Application.StartupPath, USERNAME & ".Png"))
        signature.ContentImage = image
        ' Add the field to the document.
        graphics.AddFormField(signature)

    End Sub

    Private Sub BtnSaveSignature_Click(sender As Object, e As EventArgs) Handles btnSaveSignature.Click



        'PDFDocumentExpress(Me.ComboBox1.Text)
        DigitalSignature(Me.ComboBox1.Text)
        'PDFDocumentExpress()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If Me.CheckEdit1.Checked = True Then
            OfficialSeal = True

        Else
            OfficialSeal = False
        End If
    End Sub



    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        OfficialSealTOPDF(Me.ComboBox1.Text)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        If OfficialSeal = True Then
            AddOfficialSealToDocxInMemory(Me.ComboBox1.Text)
            AddSignatureToDocxInMemory(Me.ComboBox1.Text)
        ElseIf OfficialSeal = False Then
            AddSignatureToDocxInMemory(Me.ComboBox1.Text)
        End If







    End Sub
End Class