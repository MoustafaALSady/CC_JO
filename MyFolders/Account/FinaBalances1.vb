Imports System.Data.SqlClient
Imports CC_JO.PrintGridView
<<<<<<< HEAD
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid.Events

Public Class FinaBalances1
    Inherits Form

    Public Sub New()
        InitializeComponent()
        ' Add the event handler for CurrentCellChanged
        AddHandler GridView1.RowCellClick, AddressOf GridView_RowCellClick
        'AddHandler GridView1.FocusedRowChanged, AddressOf GridView1_CurrentCellChanged
    End Sub

    Private Sub Finabalances1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.BackWorker1 = New ComponentModel.BackgroundWorker With {
=======

Public Class FinaBalances1
    Inherits System.Windows.Forms.Form

    Dim NOROWS As String
    'Dim sqladp2 As New SqlDataAdapter("SELECT * FROM BALANCE", Consum)



    ''' <summary>
    ''' متغير خاص بضبط و تغير حجم العمود في القريد
    ''' </summary>
    ''' <remarks></remarks>
    Dim AutoSizeColumns As New DataGridViewAutoSizeColumnsMode

    ''' <summary>
    ''' اجراء تمهيدي للقريد و اضافة عمود ترقيم تلقائي لها
    ''' و اضافة كل الاعمدة المرئية في القريد المحددة
    ''' و كذلك اضافة الصفوف التي تحتويها
    ''' </summary>
    ''' <remarks></remarks>
    Private Function InitializeDataGridView() As DataGridView

        ' انشاء قريد جديد من اعمدة القريد المرسل و صفوفها
        If DataGridView1.Rows.Count <= 0 Then
            MsgBox("اما انه لا يوجد صفوف او لم تقم بتعين القريد المناسب")
        End If
        Dim Dg1 As New DataGridView
        Dg1.Columns.Clear()
        '--------------اضافة عمود الترقيم------------------------
        ' Dim cel1 As DataGridViewCell = New DataGridViewTextBoxCell
        Dim col1 As New DataGridViewTextBoxColumn With {
            .Name = "Num",
            .ValueType = GetType(Int16),
            .HeaderText = "Num"
        }
        Dg1.Columns.Add(col1)

        If Ck1.Checked = True Then
            col1.HeaderText = "م"
        End If
        '---------------------اضافة الاعمدة المرئية------------------------------
        For Each colmn2 As DataGridViewColumn In DataGridView1.Columns
            If colmn2.Visible = True Then
                Dg1.Columns.Add(colmn2.Name, colmn2.HeaderText)
            End If
        Next


        ' Dim columnHeaderStyle As New DataGridViewCellStyle

        ' columnHeaderStyle.Font = DataGridView1.Font
        ' columnHeaderStyle.ForeColor = DataGridView1.ForeColor


        ' Dg1.ColumnHeadersDefaultCellStyle.Font = columnHeaderStyle.Font


        '---------------اضافة الصفوف وتعين قيم الاعمدة المرئية------------------
        Dim f As Integer = 0
        Dim n As Integer = 1
        Dg1.Rows.Clear()
        '------------------------------------
        Do While f < DataGridView1.Rows.Count '- 1
            Dg1.Rows.Add()
            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.Visible = True Then
                    Dg1.Rows(f).Cells(col.Name).Value = DataGridView1.Rows(f).Cells(col.Name).Value
                    Dg1.Rows(f).Cells("Num").Value = n
                End If
            Next

            f += 1
            n += 1
        Loop
        '-------------------------------------------------------------------------------
        Dg1.ColumnHeadersVisible = True
        Dg1.RowHeadersVisible = True
        '------------------------------
        AutoSizeColumns = DataGridViewAutoSizeColumnsMode.DisplayedCells
        '--------------------------------

        '-----------------------------------
        Dg1.AutoResizeColumns(AutoSizeColumns)
        '----------------------------------

        Return Dg1
    End Function


    ''' <summary>
    ''' حدث الزر طباعة
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDocument.Click
        PrintDocument1.DefaultPageSettings = New Printing.PageSettings
        PrintDocument1.DefaultPageSettings = PageSetup1.PageSettings
        If PrintDocument1.DefaultPageSettings.Margins.Top < 100 Or PrintDocument1.DefaultPageSettings.Margins.Bottom < 100 Then
            PrintDocument1.DefaultPageSettings.Margins.Top = 60
            PrintDocument1.DefaultPageSettings.Margins.Bottom = 60
        End If
        '============================================
        PrintDialog1.AllowSomePages = True
        ' Show the help button.
        PrintDialog1.ShowHelp = True
        PrintDialog1.Document = PrintDocument1

        Dim result As DialogResult = PrintDialog1.ShowDialog()
        ' If the result is OK then print the document.
        If result = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub


    ''' <summary>
    ''' حدث الزر معاينة الطباعة
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintPInternalAuditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPInternalAuditor.Click
        Dim dlg As New PrintPreviewDialog With {
            .Document = PrintDocument1
        }
        PrintDocument1.DefaultPageSettings = New Printing.PageSettings
        PrintDocument1.DefaultPageSettings = PageSetup1.PageSettings
        If PrintDocument1.DefaultPageSettings.Margins.Top < 10 Or PrintDocument1.DefaultPageSettings.Margins.Bottom < 100 Then
            PrintDocument1.DefaultPageSettings.Margins.Top = 60
            PrintDocument1.DefaultPageSettings.Margins.Bottom = 60
        End If



        dlg.ShowDialog()
    End Sub



    ''' <summary>
    ''' حدث بدء الطباعة الخاص بالمستند
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

        OStringFormat = New StringFormat

        If Ck1.Checked = True Then
            ' oStringFormat.Alignment = StringAlignment.Far
            OStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
        Else
            OStringFormat.Alignment = StringAlignment.Center
        End If

        OStringFormat.LineAlignment = StringAlignment.Center
        OStringFormat.Trimming = StringTrimming.EllipsisCharacter

        OStringFormatComboBox = New StringFormat With {
            .LineAlignment = StringAlignment.Center,
            .FormatFlags = StringFormatFlags.NoWrap,
            .Trimming = StringTrimming.EllipsisCharacter
        }

        OButton = New Button
        OCheckbox = New CheckBox
        OComboBox = New ComboBox

        NTotalWidth = 0
        For Each oColumn As DataGridViewColumn In DataGridView1.Columns
            NTotalWidth += oColumn.Width
        Next
        NPageNo = 1
        NewPage = True
        NRowPos = 0
        '--------------------------------------------------
        '==============================================================


        PrintDocument1.DefaultPageSettings = New Printing.PageSettings
        PrintDocument1.DefaultPageSettings = PageSetup1.PageSettings

        If PrintDocument1.DefaultPageSettings.Margins.Left <= 1 Or PrintDocument1.DefaultPageSettings.Margins.Left <= 1 Then
            PageSetup1.PageSettings.Margins.Left = 2
            PageSetup1.PageSettings.Margins.Right = 2

        End If
        '=================================================================
        '---------------------------------------------------


    End Sub


    ''' <summary>
    ''' الحدث الرئيسي في معالجة عملية الطباعة
    ''' </summary>
    ''' <param name="sender">لكائن المرسل</param>
    ''' <param name="e">هنا يتم استقبال الكائن و معالجته , الكائن هنا من نوع غرافيك</param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' PrintDocument1
        Static oColumnLefts As New ArrayList
        Static oColumnWidths As New ArrayList
        Static oColumnTypes As New ArrayList
        Static nHeight As Int16

        Dim nWidth, i, nRowsPerPage As Int16
        Dim nTop As Int16 = e.MarginBounds.Top
        '=====================================================

        Dim PrintGrid As DataGridView = InitializeDataGridView()

        If PrintGrid.Rows.Count <= 0 Then
            MsgBox("القريد فارغة لا يمكن الطباعة")
            Exit Sub
        Else
            PrintGrid.Font = DataGridView1.Font
            PrintGrid.ForeColor = DataGridView1.ForeColor
            Me.Controls.Add(PrintGrid)
            PrintGrid.Visible = False

        End If

        '====================================================
        If Ck1.Checked = True Then 'الاتجاه اليمين

            'Dim nLeft As Int16 = e.MarginBounds.Width.ToString
            Dim nLeft As Int16 = e.MarginBounds.X + (e.MarginBounds.Width - 2)

            'Dim nLeft As Int16 = e.PageBounds.Right - e.PageSettings.Margins.Right
            'X = X * e.MarginBounds.Width / e.MarginBounds.Width
            'X = X + e.MarginBounds.X
            If NPageNo = 1 Then
                oColumnLefts.Clear()
                oColumnWidths.Clear()
                oColumnTypes.Clear()
                For Each oColumn As DataGridViewColumn In PrintGrid.Columns
                    If oColumn.Visible = True Then
                        oColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        nWidth = CType(Math.Floor(oColumn.Width), Int16)
                        nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11
                        oColumnWidths.Add(nWidth)
                        oColumnTypes.Add(oColumn.GetType)
                        nLeft -= nWidth
                        oColumnLefts.Add(nLeft)
                    End If
                Next
            End If
        Else 'الاتجاه اليسار
            Dim nLeft As Int16 = e.MarginBounds.Left
            If NPageNo = 1 Then
                oColumnLefts.Clear()
                oColumnWidths.Clear()
                oColumnTypes.Clear()
                For Each oColumn As DataGridViewColumn In PrintGrid.Columns
                    If oColumn.Visible = True Then
                        oColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        nWidth = CType(Math.Floor(oColumn.Width), Int16)
                        nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11
                        oColumnLefts.Add(nLeft)
                        oColumnWidths.Add(nWidth)
                        oColumnTypes.Add(oColumn.GetType)
                        nLeft += nWidth
                    End If
                Next
            End If
        End If
        '=====================================================
        Dim p(5, 0)
        Dim g(CheckedListBox1.Items.Count - 1, 0)

        Do While NRowPos < PrintGrid.Rows.Count - 1
            Dim oRow As DataGridViewRow = PrintGrid.Rows(NRowPos)
            If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top - 44 Then
                DrawFooter(e, nRowsPerPage)
                NewPage = True
                NPageNo += 1
                e.HasMorePages = True
                Dim s As Integer
                If CheckedListBox1.CheckedIndices.Count > 0 Then
                    For s = 0 To CheckedListBox1.Items.Count - 1
                        If CheckedListBox1.GetItemChecked(s) = True Then
                            'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(p(1, s), p(2, s), p(3, s), nHeight))
                            ''e.Graphics.DrawString(mg, oRow.InheritedStyle.Font, New SolidBrush(oRow.InheritedStyle.ForeColor), New RectangleF(p(1, s), p(2, s), p(3, s), nHeight), oStringFormat)
                            e.Graphics.DrawString(p(4, s), oRow.InheritedStyle.Font, New SolidBrush(oRow.InheritedStyle.ForeColor), New RectangleF(p(1, s), p(2, s), p(3, s), nHeight), OStringFormat)
                            e.Graphics.DrawString(p(0, s), oRow.InheritedStyle.Font, New SolidBrush(oRow.InheritedStyle.ForeColor), New RectangleF(p(1, s), p(2, s) - 28, p(3, s), nHeight), OStringFormat)

                        End If
                    Next
                End If
                Exit Sub
            Else
                If NewPage Then
                    ' Draw Header
                    e.Graphics.DrawString(Header, New Font(PrintGrid.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(PrintGrid.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)
                    ' Draw Columns
                    nTop = e.MarginBounds.Top
                    i = 0
                    For Each oColumn As DataGridViewColumn In PrintGrid.Columns
                        If oColumn.Visible = True Then
                            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            'e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                            e.Graphics.DrawString(oColumn.HeaderText, PrintGrid.Font, New SolidBrush(PrintGrid.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), OStringFormat)
                            Dim s As Integer
                            '====================
                            If CheckedListBox1.CheckedIndices.Count > 0 Then
                                For s = 0 To CheckedListBox1.Items.Count - 1
                                    If CheckedListBox1.GetItemChecked(s) = True Then
                                        If oColumn.Name = CheckedListBox1.Items(s).ToString Then
                                            ReDim Preserve p(5, s)
                                            p.SetValue(oColumn.Name, 0, s)
                                            p.SetValue(oColumnLefts(i), 1, s)
                                            p.SetValue(e.MarginBounds.Bottom - 4, 2, s) '=====
                                            p.SetValue(oColumnWidths(i), 3, s)
                                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(p(1, s), p(2, s) - 28, p(3, s), nHeight))
                                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(p(1, s), p(2, s), p(3, s), nHeight))

                                        End If
                                    End If
                                Next
                            End If
                            i += 1

                        End If
                    Next
                    NewPage = False
                End If
                nTop += nHeight
                i = 0
                Try
                    Dim svalue As String
                    For Each oCell As DataGridViewCell In oRow.Cells
                        If oCell.Visible = True Then
                            If IsNothing(oCell.Value) = True Or (IsDBNull(oCell.Value) = True) Then
                                svalue = "0"
                            Else
                                svalue = oCell.Value.ToString
                            End If
                            '==========================
                            If CheckedListBox1.CheckedIndices.Count > 0 Then
                                If oCell.OwningColumn.Name <> "Num" Then
                                    Try
                                        Dim s As Integer
                                        For s = 0 To CheckedListBox1.Items.Count - 1

                                            If IsNothing(oCell.Value) = True Or (IsDBNull(oCell.Value) = True) Then
                                                ReDim Preserve g(CheckedListBox1.Items.Count - 1, 0)
                                                g.SetValue(0 + g(s, 0), s, 0)
                                                p.SetValue(g(s, 0), 4, s)
                                            Else

                                                If CheckedListBox1.GetItemChecked(s) = True And oCell.OwningColumn.Name = CheckedListBox1.Items(s).ToString Then
                                                    'حساب المجاميع للاعمدةالمحددة
                                                    ReDim Preserve g(CheckedListBox1.Items.Count - 1, 0)
                                                    g.SetValue(Val(oCell.Value) + g(s, 0), s, 0)
                                                    p.SetValue(g(s, 0), 4, s)
                                                End If
                                            End If
                                        Next
                                    Catch ex As Exception

                                    End Try
                                End If
                            End If
                            '==========================
                            If oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then
                                e.Graphics.DrawString(svalue, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), OStringFormat)
                                'e.Graphics.DrawString(svalue, DataGridView1.Font, New SolidBrush(DataGridView1.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                            ElseIf oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then
                                OButton.Text = oCell.Value.ToString
                                OButton.Size = New Size(oColumnWidths(i), nHeight)
                                Dim oBitmap As New Bitmap(OButton.Width, OButton.Height)
                                OButton.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width,
                                                                            oBitmap.Height))
                                e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                            ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then
                                OCheckbox.Size = New Size(14, 14)
                                OCheckbox.Checked = CType(oCell.Value, Boolean)
                                Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
                                Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
                                oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0,
                                                            0, oBitmap.Width, oBitmap.Height))
                                OCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width _
                                          - OCheckbox.Width) / 2, Int32), CType((oBitmap.Height _
                                          - OCheckbox.Height) / 2, Int32), OCheckbox.Width,
                                          OCheckbox.Height))
                                e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                            ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then
                                OComboBox.Size = New Size(oColumnWidths(i), nHeight)
                                Dim oBitmap As New Bitmap(OComboBox.Width, OComboBox.Height)
                                OComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width,
                                                                              oBitmap.Height))
                                e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                                e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font,
                                           New SolidBrush(oCell.InheritedStyle.ForeColor), New _
                                           RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) _
                                           - 16, nHeight), OStringFormatComboBox)
                            ElseIf oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then
                                Dim oCellSize As New Rectangle(oColumnLefts(i), nTop,
                                                                           oColumnWidths(i), nHeight)
                                Dim oImageSize As Size = CType(oCell.Value, Image).Size
                                e.Graphics.DrawImage(oCell.Value, New Rectangle(oColumnLefts(i) _
                                           + CType((oCellSize.Width _
                                           - oImageSize.Width) / 2, Int32), nTop + CType _
                                           ((oCellSize.Height - oImageSize.Height) / 2, Int32),
                                           CType(oCell.Value, Image).Width, CType(oCell.Value,
                                           Image).Height))
                            End If
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i),
                                                                 nTop, oColumnWidths(i), nHeight))

                            i += 1
                        End If
                    Next
                Catch ex As Exception

                End Try
            End If
            NRowPos += 1
            If NRowPos = PrintGrid.Rows.Count - 1 Then
                Dim s As Integer
                If CheckedListBox1.CheckedIndices.Count > 0 Then
                    For s = 0 To CheckedListBox1.Items.Count - 1
                        If CheckedListBox1.GetItemChecked(s) = True Then
                            e.Graphics.DrawString(p(0, s), oRow.InheritedStyle.Font, New SolidBrush(oRow.InheritedStyle.ForeColor), New RectangleF(p(1, s), p(2, s) - 28, p(3, s), nHeight), OStringFormat)
                            e.Graphics.DrawString(p(4, s), oRow.InheritedStyle.Font, New SolidBrush(oRow.InheritedStyle.ForeColor), New RectangleF(p(1, s), p(2, s), p(3, s), nHeight), OStringFormat)
                        End If
                    Next
                End If

            End If
            nRowsPerPage += 1
        Loop
        DrawFooter(e, nRowsPerPage)
        e.HasMorePages = False
    End Sub


    ''' <summary>
    ''' لرسم مستطيلات اعلى و اسفل الصفحة و ادراج النصوص المناسبة
    ''' ترتبط النصوص المدرجة بمربعات النصوص على الفورم
    ''' </summary>
    ''' <param name="e">كائن الرسم الخاص بالصفحة</param>
    ''' <param name="RowsPerPage">عداد الصفوف</param>
    ''' <remarks></remarks>
    Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal RowsPerPage As Int32)
        Dim stformat As New StringFormat With {
            .LineAlignment = StringAlignment.Center,
            .Trimming = StringTrimming.EllipsisCharacter
        }

        'رسم المستطيل اسفل الصفحة
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(e.MarginBounds.Left, e.MarginBounds.Bottom + 24, e.MarginBounds.Width, 22))
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(e.MarginBounds.Left, e.MarginBounds.Bottom + 24, e.MarginBounds.Width, 22))
        'التاريخ
        Dim testdate As String = Format(ServerDateTime, "dd/MM/yyy") + " : " + ServerDateTime.ToShortTimeString
        stformat.Alignment = StringAlignment.Near
        e.Graphics.DrawString(testdate, DataGridView1.Font, New SolidBrush(Color.Black), New RectangleF(e.MarginBounds.Left, e.MarginBounds.Bottom + 24, e.MarginBounds.Width, 22), stformat)
        'الصفحات
        '-----------------------------------------------------------------------------------------
        Dim sPageNo As String = NPageNo.ToString + " of "
        If NPageNo = "1" Then
            ' rowsC = Math.Ceiling(DataGridView1.Rows.Count - 1)
            LPageNo = Math.Ceiling((DataGridView1.Rows.Count - 1) / RowsPerPage).ToString()
            sPageNo = NPageNo.ToString + " of " + LPageNo
        Else
            sPageNo = NPageNo.ToString + " of " + LPageNo
        End If
        '-----------------------------
        'oTable.Range.Tables(1).Rows.Alignment = WdRowAlignment.wdAlignRowCenter

        stformat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(NPageNo.ToString + " of ", DataGridView1.Font, New SolidBrush(Color.Black), New RectangleF(e.MarginBounds.Left, e.MarginBounds.Bottom + 24, e.MarginBounds.Width, 22), stformat)
        '------------اسم المستخدم في حال وجد--------------------------------------------------------------------------------
        stformat.Alignment = StringAlignment.Far
        'e.Graphics.DrawString(BotR.Text, DataGridView1.Font, New SolidBrush(Color.Black), New RectangleF(e.MarginBounds.Left, e.MarginBounds.Bottom + 24, e.MarginBounds.Width, 22), stformat)
        '----------------------
        If Ck1.Checked = True Then
            stformat.Alignment = StringAlignment.Far
            stformat.FormatFlags = StringFormatFlags.DirectionRightToLeft

        Else
            stformat.Alignment = StringAlignment.Near
        End If
        'رسم المستطيل اعلى الصفحة
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top - 25, e.MarginBounds.Width + 1, 22))
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top - 25, e.MarginBounds.Width + 1, 22))
        'e.Graphics.DrawString(TpUn.Text, DataGridView1.Font, New SolidBrush(Color.Black), New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top - 25, e.MarginBounds.Width + 1, 22), stformat)
        ''-----------------رسم مستطيلين اعلى الصفحة بجانب بعض--------------------------------------------------------------
        ''-------اليساري
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top - 48, e.MarginBounds.Width / 2, 22))
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top - 48, e.MarginBounds.Width / 2, 22))
        'e.Graphics.DrawString(TpL.Text, DataGridView1.Font, New SolidBrush(Color.Black), New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top - 48, (e.MarginBounds.Width / 2), 22), stformat)
        ''--------اليميني
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle((e.MarginBounds.Width / 2) + e.MarginBounds.Left, e.MarginBounds.Top - 48, e.MarginBounds.Width / 2, 22))
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle((e.MarginBounds.Width / 2) + e.MarginBounds.Left, e.MarginBounds.Top - 48, e.MarginBounds.Width / 2, 22))
        'e.Graphics.DrawString(TpR.Text, DataGridView1.Font, New SolidBrush(Color.Black), New Rectangle((e.MarginBounds.Width / 2) + e.MarginBounds.Left, e.MarginBounds.Top - 48, (e.MarginBounds.Width / 2), 22), stformat)

    End Sub


    ''' <summary>
    ''' حدث الزر اعدادات الطباعة
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetup.Click

        PageSetup1.Document = PrintDocument1

        PageSetup1.AllowOrientation = True
        PageSetup1.AllowPrinter = True
        PageSetup1.AllowMargins = True

        'Show the dialog storing the result.
        Dim result As DialogResult = PageSetup1.ShowDialog




    End Sub

    ''' <summary>
    ''' اجراء خاص باعدادات الطباعة
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Loadpagesetting()
        PageSetup1.PageSettings = New Printing.PageSettings
        PageSetup1.PageSettings.PaperSize.RawKind = 9
        Dim margins1 As New Drawing.Printing.Margins(4, 4, 60, 60)
        PageSetup1.PageSettings.Margins = margins1

        PrintDocument1.DefaultPageSettings = New Printing.PageSettings
        PrintDocument1.DefaultPageSettings = PageSetup1.PageSettings
    End Sub

    '''' <summary>
    '''' حدث تحميل الفورم
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks>يتم فيه تمرير اجراء اعدادات الطباعة
    ''''A4 و هو اجراء يستند على نوع الورق
    '''' </remarks>
    '''' 



    ''' <summary>
    ''' تغير اسماء الازرار وفق تغير حالة الطباعة
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ck1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ck1.CheckedChanged
        If Ck1.Checked = True Then
            PrintDocument.Text = "طباعة"
            PrintPInternalAuditor.Text = "معاينة الطباعة"
            PageSetup.Text = "اعدادات الصفحة"

            Label1.Text = "تستخدم هذه الحقول " & ControlChars.CrLf &
                                "لحساب مجموع" & ControlChars.CrLf &
                           "قيم الحقل عبر كل" & ControlChars.CrLf &
                           "الصفوف و هي للحقول " & ControlChars.CrLf &
                           "الرقمية فقط, بامكانك" & ControlChars.CrLf &
                                  "تعيين اكثر من" & ControlChars.CrLf &
                                 "حقل بنفس الوقت"
        Else
            PrintDocument.Text = "Print Document"
            PrintPInternalAuditor.Text = "Print PInternalAuditor"
            PageSetup.Text = "Page Setup"

            Label1.Text = "Use This Columns " & ControlChars.CrLf &
                          "To Create Sum Column" & ControlChars.CrLf &
                          "Throw All Rows" & ControlChars.CrLf &
                          "Just For Int Columns " & ControlChars.CrLf &
                          "You Can Use More" & ControlChars.CrLf &
                          "Than One Column" & ControlChars.CrLf &
                          "At The Same Time"

        End If
    End Sub

    ''' <summary>
    ''' تحميل الاعمدة الرقمية في القريد المحدد
    ''' في قائمة المجاميع
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadList1()

        If DataGridView1.Columns.Count > 0 Then
            For Each xcolumn As DataGridViewColumn In DataGridView1.Columns
                If xcolumn.Visible = True Then
                    If xcolumn.ValueType Is GetType(Int32) Then
                        CheckedListBox1.Items.Add(xcolumn.Name)
                    End If
                End If
            Next
        End If
    End Sub




    Private Sub Finabalances1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
        Me.BackWorker1 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker1.RunWorkerAsync()

    End Sub
<<<<<<< HEAD

    Sub SELECT_mov()

        'On Error Resume Next
        'Dim dataTable As New DataTable()

        If AccountantA = True Then
            'Call SELECT_MOVES2(Me.DataGridView1)
            'Call SELECT_MOVES2(Me.GridView1)
        ElseIf FinanceAuditA = True Then
            'Call SELECT_MOVES3(Me.DataGridView1)
            'Call SELECT_MOVES3(Me.GridView1)
        Else
            'Call SELECT_MOVES1(Me.DataGridView1)
            Call SELECT_MOVES1(Me.GridControl1)
        End If
        'GridView1.Columns
=======
    Sub SELECT_mov()

        On Error Resume Next

        If AccountantA = True Then
            Call SELECT_MOVES2(Me.DataGridView1)
        ElseIf FinanceAuditA = True Then
            Call SELECT_MOVES3(Me.DataGridView1)
        Else
            Call SELECT_MOVES1(Me.DataGridView1)
        End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorFinabalances1_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Sub CircularProgressA()
        On Error Resume Next
        Me.CircularProgress1.Value = 0
        Me.CircularProgress1.Visible = True
        Me.CircularProgress1.IsRunning = True
<<<<<<< HEAD
=======
        If Windows.Forms.RightToLeft.Inherit Or Windows.Forms.RightToLeft.Yes Then
            Ck1.Checked = True
        End If
        Loadpagesetting()
        LoadList1()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AccountantA = False
        FinanceAuditA = False
    End Sub

<<<<<<< HEAD
=======

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub BackWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker1.DoWork
        Me.CircularProgressA()

        BackWorker1.ReportProgress(100)
        Threading.Thread.Sleep(100)
    End Sub

    Private Sub BackWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker1.ProgressChanged
        Me.CircularProgress1.Value = e.ProgressPercentage
<<<<<<< HEAD
=======
        Me.Label1.Text = e.ProgressPercentage & " Percent Completed!"
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Sub

    Private Sub BackWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker1.RunWorkerCompleted
        Me.SELECT_mov()
        ' InitializeDataGridView()
        Me.CircularProgress1.IsRunning = False
        Me.CircularProgress1.Visible = False
<<<<<<< HEAD
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Try
            Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
            Dim value As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("ID"))
            Dim value1 As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("Date"))
            Dim TypeName As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("TypeName"))
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If TypeName = "المبيعات" Then
                    SEARCHDATA.SEARCHSLSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf TypeName = "المشتريات" Then
                    SEARCHDATA.SEARCHBUYSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView1_CurrentCellChanged(sender As Object, e As FocusedRowChangedEventArgs)
        Try
            Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
            Dim value As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("ID"))
            Dim value1 As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("Date"))
            Dim TypeName As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("TypeName"))
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If TypeName = "المبيعات" Then
                    SEARCHDATA.SEARCHSLSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf TypeName = "المشتريات" Then
                    SEARCHDATA.SEARCHBUYSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView_RowCellClick(ByVal sender As Object, ByVal e As RowCellClickEventArgs)
        Try
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCellClick", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Dim Consum As New SqlConnection(constring)
        Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
        Dim value As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("ID"))
        Dim value1 As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("Date"))
        Dim TypeName As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("TypeName"))

        If TypeName = "القيود المحاسبة" Then
            Dim f1 As New FrmDailyrestrictions With {
                .TB2 = value
=======
        Me.Label1.Text = "DONE!"
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        On Error Resume Next
        For Each r As DataGridViewRow In DataGridView1.Rows
            NOROWS = CDbl(r.Cells("IDNumber").Value)

            If r.Cells("Type1").Value = "المبيعات" Then
                SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells("RegistrationNumber").Value)
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            ElseIf r.Cells("Type1").Value = "المشتريات" Then
                SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells("RegistrationNumber").Value)
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
            End If
        Next
    End Sub
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        On Error Resume Next
        For Each r As DataGridViewRow In DataGridView1.Rows
            NOROWS = CDbl(r.Cells("IDNumber").Value)
            If r.Cells("Type1").Value = "المبيعات" Then
                SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells("RegistrationNumber").Value)
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            ElseIf r.Cells("Type1").Value = "المشتريات" Then
                SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells("RegistrationNumber").Value)
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
            End If
        Next

    End Sub


    Private Sub DataGridView1_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.DataGridView1.CurrentRow.Cells("Type1").Value = "القيود المحاسبة" Then
            Dim f1 As New FrmDailyrestrictions With {
                .TB2 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f1.Show()
            f1.Load_Click(sender, e)

<<<<<<< HEAD
        ElseIf TypeName = "الصندوق" Then
            Dim f As New FrmBanks5 With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "الصندوق" Then
            Dim f As New FrmBanks5 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f.Show()
            f.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "البنك" Then
            Dim f2 As New FrmJO With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "البنك" Then
            Dim f2 As New FrmJO With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f2.Show()
            f2.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "الموظفين" Then
            Dim f3 As New FrmEmpsolf With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "الموظفين" Then
            Dim f3 As New FrmEmpsolf With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f3.Show()
            f3.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "الشيكات" Then
            Dim f4 As New FrmChecks With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "الشيكات" Then
            Dim f4 As New FrmChecks With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f4.Show()
            f4.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "الاسهم" Then
            Dim f5 As New FrmDeposits With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "الاسهم" Then
            Dim f5 As New FrmDeposits With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f5.Show()
            f5.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "حركات السحب والايداعات النقدية" Then
            Dim f5 As New FrmTransaction With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "حركات السحب والايداعات النقدية" Then
            Dim f5 As New FrmTransaction With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f5.Show()
            f5.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "المبيعات" Then
            SEARCHDATA.SEARCHSLSCASH(value)
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "المبيعات" Then
            SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells("RegistrationNumber").Value)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            Dim f6 As New FrmCustomersA
            If Me.RadInvoiceStatus.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
<<<<<<< HEAD
            f6.TB1 = value
            f6.Show()
            f6.DanLOd()
        ElseIf TypeName = "المببعات_اليومية" Then
            Dim f8 As New Form_mabeat With {
                .TEST = True
            }
            f8.Textdaee1.Value = value1
            f8.Show()
            f8.BuakrT_Click(sender, e)

        ElseIf TypeName = "المشتريات" Then
            SEARCHDATA.SEARCHBUYSCASH(value)
=======
            f6.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("IDNumber").Value)
            f6.Show()
            f6.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "المببعات_اليومية" Then
            Dim f8 As New Form_mabeat With {
                .TEST = True
            }
            f8.Textdaee1.Value = Me.DataGridView1.CurrentRow.Cells("ColDate").Value
            f8.Show()
            f8.BuakrT_Click(sender, e)

        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "المشتريات" Then
            SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells("RegistrationNumber").Value)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
            Dim f7 As New FrmSuppliesA
            Cash = True
            If Me.RadInvoiceStatus.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
<<<<<<< HEAD
            f7.TB1 = value
            f7.Show()
            f7.DanLOd()

        ElseIf TypeName = "العملاء" Then
            Dim f8 As New FrmCUSTOMER1 With {
                .TB1 = value
=======
            f7.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("IDNumber").Value)
            f7.Show()
            f7.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "العملاء" Then
            Dim f8 As New FrmCUSTOMER1 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f8.Show()
            f8.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "مصاريف المشتريات" Then
            Dim f9 As New FrmCUSTOMER11 With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "مصاريف المشتريات" Then
            Dim f9 As New FrmCUSTOMER11 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f9.Show()
            f9.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "فاتورة نقل تفصيلية" Then
            Dim f10 As New FrmInvoice With {
                .TB1 = value,
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "فاتورة نقل تفصيلية" Then
            Dim f10 As New FrmInvoice With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value,
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .TB1_chk = True
            }
            f10.Show()
            f10.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "فاتورة نقل" Then
            Dim f11 As New FrmTRANSPORT With {
                .TB1 = value,
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "فاتورة نقل" Then
            Dim f11 As New FrmTRANSPORT With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value,
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .TB1_chk = True
            }
            f11.Show()
            f11.Load_Click(sender, e)
<<<<<<< HEAD
        ElseIf TypeName = "المصاريف العامة" Then
            Dim f12 As New FrmMyCosts With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "المصاريف العامة" Then
            Dim f12 As New FrmMyCosts With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f12.Show()
            f12.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "الموردين" Then
            Dim f13 As New FrmSuppliers1 With {
                .TB1 = value
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "الموردين" Then
            Dim f13 As New FrmSuppliers1 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("IDNumber").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f13.Show()
            f13.DanLOd()

<<<<<<< HEAD
        ElseIf TypeName = "المرتبات والاجور" Then
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "المرتبات والاجور" Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim ds14 As New DataSet
            Dim f14 As New FormEmployees4
            ds14.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ORDER BY SLY1", Consum)
<<<<<<< HEAD
            Dim SqlDataAdapter14 As New SqlDataAdapter(str)
=======
            Dim SqlDataAdapter14 As New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds14.Clear()
            SqlDataAdapter14.Fill(ds14, "SALARIES")
            f14.BS.DataMember = "SALARIES"
            f14.BS.DataSource = ds14
            Dim index As Integer
<<<<<<< HEAD
            index = f14.BS.Find("SLY1", value)
=======
            index = f14.BS.Find("SLY1", Me.DataGridView1.CurrentRow.Cells("IDNumber").Value)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f14.Show()
            f14.Load_Click(sender, e)
            f14.BS.Position = index

<<<<<<< HEAD
        ElseIf TypeName = "القروض" Then
            Dim f15 As New Loans With {
                .TB1 = Trim(value)
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "القروض" Then
            Dim f15 As New Loans With {
                .TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("IDNumber").Value)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f15.Show()
            f15.Load_Click(sender, e)

<<<<<<< HEAD
        ElseIf TypeName = "تسديدات العملاء" Then
            Dim f16 As New Loans2 With {
                .TB1 = Trim(value)
=======
        ElseIf Me.DataGridView1.CurrentRow.Cells("Type1").Value = "تسديدات العملاء" Then
            Dim f16 As New Loans2 With {
                .TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("IDNumber").Value)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            }
            f16.Show()
            f16.DanLOd()
        End If

    End Sub

<<<<<<< HEAD
    Sub ShowGridPreview(ByVal grid As GridControl)
        ' Check whether the GridControl can be previewed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If

        ' Opens the Preview window.
        grid.ShowPrintPreview()
    End Sub

    Sub PrintGrid(ByVal grid As GridControl)
        ' Check whether the GridControl can be printed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If

        ' Print.
        grid.Print()
    End Sub

    Private Sub PrintDocument_Click(sender As Object, e As EventArgs) Handles PrintDocument.Click
        ShowGridPreview(GridControl1)
    End Sub

    Private Sub PrintPInternalAuditor_Click(sender As Object, e As EventArgs) Handles PrintPInternalAuditor.Click
        PrintGrid(GridControl1)
    End Sub

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
End Class