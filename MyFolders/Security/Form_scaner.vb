Option Explicit On

Imports System.Data.SqlClient
Imports Word

Public Class Form_scaner
    Dim pagingAdapter As SqlDataAdapter
    Dim pagingDS As DataSet
    ReadOnly scrollVal As Integer
    Dim WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Public haj As String
    Public mel As String
    Private Sub BuakrT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BuakrT.Click
        Try
            Dascan.Columns.Clear()
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()

            Dim SQL As New SqlCommand("", Consum)
            With SQL
                If Me.RadioButton1.Checked = True Then
                    .CommandText = "SELECT  Op1,Op2,Op3,Op4,Op8,Op5,Op6 FROM  Operationsuser where Op4 LIKE '%" & Me.Textdaee.Text.ToString & "%'" & "AND Op6='" & Me.ComboBox1.Text.ToString & "'"
                ElseIf Me.RadioButton2.Checked = True Then
                    .CommandText = "SELECT  Op1,Op2,Op3,Op4,Op8,Op5,Op6 FROM Operationsuser  WHERE Op4 BETWEEN '" & Format(Me.dat1.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.dat2.Value, "yyyy/MM/dd") & "'  AND Op6='" & Me.ComboBox1.Text & "'"
                End If
            End With
            pagingAdapter = New SqlClient.SqlDataAdapter(SQL)
            pagingDS = New DataSet()

            pagingAdapter.Fill(pagingDS, scrollVal, 10000000, "Operationsuser")
            Consum.Close()
            Dascan.DataSource = pagingDS
            Dascan.DataMember = "Operationsuser"
            Dascan.Sort(Dascan.Columns(0), System.ComponentModel.ListSortDirection.Ascending)


            Dascan.Columns(0).HeaderText = "ID"
            Dascan.Columns(1).HeaderText = "رقم العملية"
            Dascan.Columns(2).HeaderText = "نوع العملية"
            Dascan.Columns(3).HeaderText = "التاريخ"
            Dascan.Columns(4).HeaderText = "الوقت"
            Dascan.Columns(5).HeaderText = "مصدر الحركة"
            Dascan.Columns(6).HeaderText = "اسم المستخدم"
            If pagingDS.Tables(0).Rows.Count > 0 Then
                Dascan.FirstDisplayedScrollingRowIndex = Dascan.Rows.Count - 1
            Else
                MsgBox("ليس هنالك حركات لهذا المستخدم", 64 + 524288, "معلومات")
            End If

            Consum.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim dgvRow As New DataGridViewRow
        For Each dgvRow In Dascan.Rows
            If dgvRow.Index Mod 2 = 0 Then
                Dascan.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            End If
        Next
    End Sub

    Private Sub Form_scaner_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Me.Opacity = a / 10
        Next
        haj = Now.ToString("dd/MM/yyyy", New Globalization.CultureInfo("ar-sa"))
        mel = Now.ToString("dd/MM/yyyy", New Globalization.CultureInfo("ar-eg"))
        mel = DateFormating(mel)
        haj = DateConvert(mel)
        Textdaee.Text = ServerDateTime.ToString
        Me.Textdaee.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim str1 As New SqlCommand("", Consum)
            Dim ds1 As New DataSet
            With str1
                .CommandText = "SELECT ID, Realname FROM Users  WHERE  COUser='" & COUser & "'  ORDER BY ID"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
            End With
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "Users")
            BS.DataSource = ds1
            BS.DataMember = "Users"
            ComboBox1.DataSource = ds1.Tables("Users")
            ComboBox1.DisplayMember = "Realname"
            Call MangUsers()
            Consum.Close()
            Call Me.AddType1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        BuakrT.PerformClick()

    End Sub
    Private Sub Textdaee_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Textdaee.TextChanged
        If Textdaee.Text.Trim = "" Then
            Textdaee.Text = ServerDateTime.ToString
        End If
    End Sub
    Private Sub Chern_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Chern.CheckedChanged
        If Chern.Checked = True Then
            Textdaee.Text = ServerDateTime.ToString("yyyy-MM-dd")
            BuakrT.Enabled = False
            Textdaee.Enabled = False
            Timrn.Start()
            Timrn.Interval = Domain0.Text.Trim
        ElseIf Chern.Checked = False Then
            BuakrT.Enabled = True
            Textdaee.Enabled = True
            Timrn.Stop()
        End If
    End Sub
    Private Sub Timrn_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timrn.Tick
        Try
            Dim txtFromDate As String
            Dim txtToDate As String
            txtFromDate = Format(Me.dat1.Value, "yyyy, MM, dd, 00, 00, 00")
            txtToDate = Format(Me.dat2.Value, "yyyy, MM, dd, 00, 00, 00")

            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim SQL As New SqlCommand("", Consum)
            With SQL
                If Me.RadioButton1.Checked = True Then
                    .CommandText = "SELECT  Op1,Op2,Op3,Op4,Op8,Op5,Op6 FROM  Operationsuser where Op4 LIKE '%" & Me.Textdaee.Text.ToString & "%'" & "AND Op6='" & Me.ComboBox1.Text.ToString & "'"
                ElseIf Me.RadioButton2.Checked = True Then
                    .CommandText = "SELECT  Op1,Op2,Op3,Op4,Op8,Op5,Op6 FROM Operationsuser  WHERE Op4 BETWEEN '" & Format(Me.dat1.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.dat2.Value, "yyyy/MM/dd") & "'  AND Op6='" & Me.ComboBox1.Text & "' "
                End If
            End With
            pagingAdapter = New SqlClient.SqlDataAdapter(SQL)
            pagingDS = New DataSet()

            pagingAdapter.Fill(pagingDS, scrollVal, 10000000, "Operationsuser")
            Consum.Close()
            Dascan.DataSource = pagingDS
            Dascan.DataMember = "Operationsuser"
            Dascan.Sort(Dascan.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            Dascan.Columns(0).HeaderText = "ID"
            Dascan.Columns(1).HeaderText = "رقم العملية"
            Dascan.Columns(2).HeaderText = "نوع العملية"
            Dascan.Columns(3).HeaderText = "التاريخ"
            Dascan.Columns(4).HeaderText = "الوقت"
            Dascan.Columns(5).HeaderText = "مصدر الحركة"
            Dascan.Columns(6).HeaderText = "اسم المستخدم"

            If pagingDS.Tables(0).Rows.Count > 0 Then
                Dascan.FirstDisplayedScrollingRowIndex = Dascan.Rows.Count - 1
            Else
                MsgBox("ليس هنالك حركات لهذا المستخدم", 64 + 524288, "معلومات")
            End If
            Consum.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim dgvRow As New DataGridViewRow
        For Each dgvRow In Dascan.Rows
            If dgvRow.Index Mod 2 = 0 Then
                Dascan.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            End If
        Next
    End Sub


    Public Sub ExportToWord()
        Try
            Dascan.AllowUserToAddRows = False
            Dascan.AllowUserToDeleteRows = False
            Dascan.ReadOnly = True
            Dascan.MultiSelect = False
            Dascan.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Dim oWord As Word.Application = DirectCast(CreateObject("Word.Application"), Word.Application)
            oWord.Caption = "المؤسسة التعاونية الأردنية"
            Dim oDoc As Word.Document = oWord.Documents.Add()
            Dim oPara1 As Word.Paragraph, oPara2 As Word.Paragraph
            Dim oPara3 As Word.Paragraph, oPara4 As Word.Paragraph
            Dim oPara5 As Word.Paragraph
            'Dim oRng As Word.Range
            'Dim Pos As Double
            Dim oSec As Word.Section

            oWord.Visible = True
            Dim headers = (From ch In Dascan.Columns
                           Let header = DirectCast(DirectCast(ch, DataGridViewColumn).HeaderCell, DataGridViewColumnHeaderCell)
                           Select header.Value).ToArray()


            oSec = oDoc.Sections(1)
            oSec.PageSetup.DifferentFirstPageHeaderFooter = True
            oSec.Range.InsertAfter("بسم الله الرحمن الرحيم")
            oSec.Range.InsertAfter("Text on Page 2 (Section 1)")

            oSec.Headers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Text = "بسم الله الرحمن الرحيم"
            oSec.Headers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Font.SizeBi = 18
            oSec.Headers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Font.NameBi = "DecoType Naskh Swashes"

            oSec.Headers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Font.Bold = True
            oSec.Headers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oSec.Headers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.InsertParagraphAfter()

            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Text = "ـــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ"
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.InsertParagraphAfter()
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Text = "العنوان :" & Adrss.Trim & " _ " & " هاتف :" & Phone.Trim & " _ " & Phone1.Trim
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Font.SizeBi = 16
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Font.NameBi = "Times New Roman"
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter

            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Text = "ـــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ"
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertParagraphAfter()
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Text = "العنوان :" & Adrss.Trim & " _ " & " هاتف :" & Phone.Trim & " _ " & Phone1.Trim
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Font.SizeBi = 16
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Font.NameBi = "Times New Roman"
            oSec.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter

            oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara2.Range.Text = "المؤسسة التعاونية الأردنية"
            oPara2.Range.Font.Size = 16
            oPara2.Format.SpaceAfter = 1
            oPara2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            oPara2.Range.InsertParagraphAfter()


            Dim pic As New Bitmap(Me.PictureBox1.Image)
            Clipboard.SetImage(pic)
            Dim newbitmap As New Bitmap(CInt(100%), CInt(100%))
            oPara1 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            Dim g As Graphics = Graphics.FromImage(newbitmap)
            g.DrawImage(pic, 98, 44, newbitmap.Width, newbitmap.Height)
            oPara1.Range.Shading.ForegroundPatternColor = Word.WdColor.wdColorAutomatic 'Transparent
            oPara1.Format.SpaceAfter = 1
            oPara1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            oPara1.Range.InsertParagraphAfter()
            oPara1.Range.Select()

            oWord.Selection.Paste()

            oPara3 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara3.Range.Text = AssociationName
            oPara3.Range.Font.Size = 12
            oPara3.Range.Font.Bold = False
            oPara3.Format.SpaceAfter = 0
            oPara3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            oPara3.Range.InsertParagraphAfter()

            oPara5 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara5.Range.InsertParagraphBefore()
            oPara5.Range.Text = "ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ"
            oPara5.Format.SpaceAfter = 0
            oPara5.Range.InsertParagraphAfter()

            oPara5 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara5.Range.InsertParagraphBefore()
            oPara5.Range.Text = "كشف حركات المستخدمين"
            oPara5.Format.SpaceAfter = 0
            oPara5.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            oPara5.Range.InsertParagraphAfter()



            'Public Function GetCount(ByVal collection As ICollection(Of Integer)) As Integer
            '    Return collection.Count()
            'End Function



            Dim oTable As Table = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, CType((From r In Dascan.Rows
                                                                                                 Let row = DirectCast(r, DataGridViewRow)
                                                                                                 Where Not row.IsNewRow
                                                                                                 Select (From cell In row.Cells
                                                                                                         Let c = DirectCast(cell, DataGridViewCell)
                                                                                                         Select c.Value).ToArray()).ToArray(), Object()).Count + 2, 6)

            With oTable
                .Borders.InsideLineStyle = 1
                .Borders.OutsideLineStyle = 1
                .Range.Font.Size = 9
                .Range.Font.Name = "Times New Roman"


                For i As Integer = 0 To CType((From r In Dascan.Rows
                                               Let row = DirectCast(r, DataGridViewRow)
                                               Where Not row.IsNewRow
                                               Select (From cell In row.Cells
                                                       Let c = DirectCast(cell, DataGridViewCell)
                                                       Select c.Value).ToArray()).ToArray(), Object()).Count - 1

                    Call .Columns(1).SetWidth(ColumnWidth:=50, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                    .Columns(2).SetWidth(ColumnWidth:=90, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                    .Columns(3).SetWidth(ColumnWidth:=70, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                    .Columns(4).SetWidth(ColumnWidth:=70, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                    .Columns(5).SetWidth(ColumnWidth:=125, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)
                    .Columns(6).SetWidth(ColumnWidth:=90, RulerStyle:=Word.WdRulerStyle.wdAdjustFirstColumn)

                    .Rows(1).Cells(1).Range.Text = Me.Dascan.Columns(1).HeaderText
                    .Rows(1).Cells(2).Range.Text = Me.Dascan.Columns(2).HeaderText
                    .Rows(1).Cells(3).Range.Text = Me.Dascan.Columns(3).HeaderText
                    .Rows(1).Cells(4).Range.Text = Me.Dascan.Columns(4).HeaderText
                    .Rows(1).Cells(5).Range.Text = Me.Dascan.Columns(5).HeaderText
                    .Rows(1).Cells(6).Range.Text = Me.Dascan.Columns(6).HeaderText

                    .Rows(i + 2).Cells(1).Range.Text = Me.Dascan.Rows(i).Cells(1).Value
                    .Rows(i + 2).Cells(2).Range.Text = Me.Dascan.Rows(i).Cells(2).Value
                    .Rows(i + 2).Cells(3).Range.Text = Me.Dascan.Rows(i).Cells(3).Value
                    .Rows(i + 2).Cells(4).Range.Text = Me.Dascan.Rows(i).Cells(4).Value
                    .Rows(i + 2).Cells(5).Range.Text = Me.Dascan.Rows(i).Cells(5).Value
                    .Rows(i + 2).Cells(6).Range.Text = Me.Dascan.Rows(i).Cells(6).Value
                Next
                .Range.InsertParagraphAfter()
            End With

            oTable.Range.Tables(1).Rows.Alignment = WdRowAlignment.wdAlignRowCenter

            oPara4 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara4.Range.InsertParagraphBefore()
            oPara4.Range.Text = ": مـديـر التــعاون "
            oPara4.Range.Font.Size = 16
            oPara4.Format.SpaceAfter = 2
            oPara4.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            oPara4.Range.InsertParagraphAfter()

            oPara5 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara5.Range.InsertParagraphBefore()
            oPara5.Range.Text = "ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ"
            oPara5.Format.SpaceAfter = 2
            oPara5.Range.InsertParagraphAfter()

            oTable.Rows.Item(1).Range.Font.Bold = &H98967E
            oTable.Rows.Item(1).Range.Font.Size = 10
            oTable.Rows.Item(1).Range.Font.Color = Word.WdColor.wdColorBlack

            oTable.Rows.Item(1).Range.Shading.Texture = Word.WdTextureIndex.wdTextureNone
            oTable.Rows.Item(1).Range.Shading.ForegroundPatternColor = Word.WdColor.wdColorAutomatic
            oTable.Rows.Item(1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray125

            With oTable.Range.Tables(1)
                With .Borders(Word.WdBorderType.wdBorderLeft)
                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                    .LineWidth = Word.WdLineWidth.wdLineWidth100pt
                    .Color = Word.WdColor.wdColorAutomatic
                End With
                With .Borders(Word.WdBorderType.wdBorderRight)
                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                    .LineWidth = Word.WdLineWidth.wdLineWidth100pt
                    .Color = Word.WdColor.wdColorAutomatic
                End With
                With .Borders(Word.WdBorderType.wdBorderTop)
                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                    .LineWidth = Word.WdLineWidth.wdLineWidth100pt
                    .Color = Word.WdColor.wdColorAutomatic
                End With
                With .Borders(Word.WdBorderType.wdBorderBottom)
                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                    .LineWidth = Word.WdLineWidth.wdLineWidth100pt
                    .Color = Word.WdColor.wdColorAutomatic
                End With
                With .Borders(Word.WdBorderType.wdBorderHorizontal)
                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                    .Color = Word.WdColor.wdColorAutomatic
                End With
                With .Borders(Word.WdBorderType.wdBorderVertical)
                    .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                    .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                    .Color = Word.WdColor.wdColorAutomatic
                End With
                .Borders(Word.WdBorderType.wdBorderDiagonalDown).LineStyle = Word.WdLineStyle.wdLineStyleNone
                .Borders(Word.WdBorderType.wdBorderDiagonalUp).LineStyle = Word.WdLineStyle.wdLineStyleNone
                .Borders.Shadow = False
            End With
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Buconvert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buconvert.Click
        Dim Row = Dascan.CurrentRow
        If Row Is Nothing Then
            MsgBox(" لا يوجد بيانات للطباعة There are no print ", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If

        ExportToWord()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboBox1, e, )
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT  Op1,Op2,Op3,Op4,Op8,Op5,Op6 FROM  Operationsuser WHERE Op6 ='" & Me.ComboBox1.Text & "'", Consum)
        pagingDS = New DataSet()
        pagingAdapter.Fill(pagingDS, scrollVal, 10000000, "Operationsuser")
        Consum.Close()
        Dascan.DataSource = pagingDS
        Dascan.DataMember = "Operationsuser"
        Dascan.Sort(Dascan.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        Consum.Close()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If Me.RadioButton1.Checked = True Then
            Me.Textdaee.Enabled = True
            Me.dat1.Enabled = False
            Me.dat2.Enabled = False
        ElseIf Me.RadioButton2.Checked = True Then
            Me.Textdaee.Enabled = False
            Me.dat1.Enabled = True
            Me.dat2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Call Me.AddType1()
    End Sub


End Class