Imports Microsoft.VisualBasic
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace WindowsFormsApplication1
    Public Class StaticsticsVisitor
        Implements IDocumentVisitor
        Private ReadOnly buffer_Renamed As StringBuilder

        Public Sub New()
            WordCount = 0
            Me.buffer_Renamed = New StringBuilder()
        End Sub

        Public Overridable Sub Visit(ByVal text As DocumentText) Implements IDocumentVisitor.Visit
            Buffer.Append(text.Text)
        End Sub

        Public Overridable Sub Visit(ByVal paragraphEnd As DocumentParagraphEnd) Implements IDocumentVisitor.Visit
            FinishParagraph()
        End Sub

        Private Sub FinishParagraph()
            Dim text As String = Buffer.ToString()
            Me.WordCount += text.Split(New Char() {" "c, "."c, "!"c, "?"c}, StringSplitOptions.RemoveEmptyEntries).Length
            Buffer.Length = 0
        End Sub

        Public Overridable Sub Visit(ByVal cellBorder As DocumentTableCellBorder) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal sectionStart As DocumentSectionStart) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal fieldCodeStart As DocumentFieldCodeStart) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal fieldCodeEnd As DocumentFieldCodeEnd) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal fieldResultEnd As DocumentFieldResultEnd) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal bookmarkStart As DocumentBookmarkStart) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal bookmarkEnd As DocumentBookmarkEnd) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal commentStart As DocumentCommentStart) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal sectionEnd As DocumentSectionEnd) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal commentEnd As DocumentCommentEnd) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal rangePermissionStart As DocumentRangePermissionStart) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal rangePermissionEnd As DocumentRangePermissionEnd) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal textBox As DocumentTextBox) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal paragraphStart As DocumentParagraphStart) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal inlinePicture As DocumentInlinePicture) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal picture As DocumentPicture) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal hyperlinkStart As DocumentHyperlinkStart) Implements IDocumentVisitor.Visit
        End Sub
        Public Overridable Sub Visit(ByVal hyperlinkEnd As DocumentHyperlinkEnd) Implements IDocumentVisitor.Visit
        End Sub

        Public Sub Visit(checkBox As DocumentCheckBox) Implements IDocumentVisitor.Visit
            Throw New NotImplementedException()
        End Sub

        Public Sub Visit(footnoteReference As DocumentFootnoteReference) Implements IDocumentVisitor.Visit
            Throw New NotImplementedException()
        End Sub

        Public Sub Visit(endnoteReference As DocumentEndnoteReference) Implements IDocumentVisitor.Visit
            Throw New NotImplementedException()
        End Sub

        Public Sub Visit(footnoteEmptyReference As DocumentFootnoteEmptyReference) Implements IDocumentVisitor.Visit
            Throw New NotImplementedException()
        End Sub

        Public Sub Visit(endnoteEmptyReference As DocumentEndnoteEmptyReference) Implements IDocumentVisitor.Visit
            Throw New NotImplementedException()
        End Sub

        Public Sub Visit(footnoteCustomMark As DocumentFootnoteCustomMark) Implements IDocumentVisitor.Visit
            Throw New NotImplementedException()
        End Sub

        Public Sub Visit(endnoteCustomMark As DocumentEndnoteCustomMark) Implements IDocumentVisitor.Visit
            Throw New NotImplementedException()
        End Sub

        Private privateWordCount As Integer
        Public Property WordCount() As Integer
            Get
                Return privateWordCount
            End Get
            Private Set(ByVal value As Integer)
                privateWordCount = value
            End Set
        End Property
        Protected ReadOnly Property Buffer() As StringBuilder
            Get
                Return buffer_Renamed
            End Get
        End Property
    End Class

	Public Class CustomLayoutVisitor
		Inherits LayoutVisitor
        Private ReadOnly document As Document

        Public Sub New(ByVal doc As Document)
			Me.document = doc
			RowIndex = 0
			ColIndex = 0
			IsFound = False
		End Sub

		Protected Overrides Sub VisitRow(ByVal row As LayoutRow)
			If (Not IsFound) Then
				RowIndex += 1
				If row.Range.Contains(document.CaretPosition.ToInt()) Then
					IsFound = True
					ColIndex = document.CaretPosition.ToInt() - row.Range.Start
				End If
			End If
			MyBase.VisitRow(row)
		End Sub

		Private privateColIndex As Integer
		Public Property ColIndex() As Integer
			Get
				Return privateColIndex
			End Get
			Private Set(ByVal value As Integer)
				privateColIndex = value
			End Set
		End Property
		Private privateRowIndex As Integer
		Public Property RowIndex() As Integer
			Get
				Return privateRowIndex
			End Get
			Private Set(ByVal value As Integer)
				privateRowIndex = value
			End Set
		End Property
		Private privateIsFound As Boolean
		Public Property IsFound() As Boolean
			Get
				Return privateIsFound
			End Get
			Private Set(ByVal value As Boolean)
				privateIsFound = value
			End Set
		End Property
	End Class
End Namespace
