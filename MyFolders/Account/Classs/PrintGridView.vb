Public Class PrintGridView

    Private Shared _dataGrid1 As New DataGridView
    Private Shared _lPageNo As String = ""
    Private Shared _sPageNo As String = ""
    Private Shared _oStringFormat As StringFormat
    Private Shared _oStringFormatComboBox As StringFormat
    Private Shared _oButton As Button
    Private Shared _oCheckbox As CheckBox
    Private Shared _oComboBox As ComboBox
    Private Shared _nTotalWidth As Short
    Private Shared _nRowPos As Short
    Private Shared _newPage As Boolean
    Private Shared _nPageNo As Short
    Private Shared _header As String
    Private Shared _sUserName As String = "nonoms"


    ''' <summary>
    ''' خاصية اسناد القريد لتمهيدها للطباعة
    ''' </summary>
    ''' <value>اي اداة داتا قريد</value>
    ''' <remarks></remarks>
    Public Shared Property SetGrid As DataGridView
        Get
            Return DataGrid1
        End Get

        Set(ByVal value As DataGridView)
            If value.Rows.Count <= 0 Then
                MsgBox("القريد المحددة لا تحتوي على صفوف")

            End If

            DataGrid1 = value
            Dim columnHeaderStyle As New DataGridViewCellStyle With {
                .Font = value.Font,
                .ForeColor = value.ForeColor
            }
            DataGrid1.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        End Set

    End Property

    Protected Friend Shared Property LPageNo As String
        Get
            Return _lPageNo
        End Get
        Set(value As String)
            _lPageNo = value
        End Set
    End Property

    Protected Friend Shared Property DataGrid1 As DataGridView
        Get
            Return _dataGrid1
        End Get
        Set(value As DataGridView)
            _dataGrid1 = value
        End Set
    End Property

    Protected Friend Shared Property SPageNo As String
        Get
            Return _sPageNo
        End Get
        Set(value As String)
            _sPageNo = value
        End Set
    End Property

    Protected Friend Shared Property OButton As Button
        Get
            Return _oButton
        End Get
        Set(value As Button)
            _oButton = value
        End Set
    End Property

    Protected Friend Shared Property OStringFormat As StringFormat
        Get
            Return _oStringFormat
        End Get
        Set(value As StringFormat)
            _oStringFormat = value
        End Set
    End Property

    Protected Friend Shared Property OCheckbox As CheckBox
        Get
            Return _oCheckbox
        End Get
        Set(value As CheckBox)
            _oCheckbox = value
        End Set
    End Property

    Protected Friend Shared Property OStringFormatComboBox As StringFormat
        Get
            Return _oStringFormatComboBox
        End Get
        Set(value As StringFormat)
            _oStringFormatComboBox = value
        End Set
    End Property

    Protected Friend Shared Property OComboBox As ComboBox
        Get
            Return _oComboBox
        End Get
        Set(value As ComboBox)
            _oComboBox = value
        End Set
    End Property

    Protected Friend Shared Property NTotalWidth As Short
        Get
            Return _nTotalWidth
        End Get
        Set(value As Short)
            _nTotalWidth = value
        End Set
    End Property

    Protected Friend Shared Property NRowPos As Short
        Get
            Return _nRowPos
        End Get
        Set(value As Short)
            _nRowPos = value
        End Set
    End Property

    Protected Friend Shared Property NewPage As Boolean
        Get
            Return _newPage
        End Get
        Set(value As Boolean)
            _newPage = value
        End Set
    End Property

    Protected Friend Shared Property NPageNo As Short
        Get
            Return _nPageNo
        End Get
        Set(value As Short)
            _nPageNo = value
        End Set
    End Property

    Protected Friend Shared Property Header As String
        Get
            Return _header
        End Get
        Set(value As String)
            _header = value
        End Set
    End Property

    Protected Friend Shared Property SUserName As String
        Get
            Return _sUserName
        End Get
        Set(value As String)
            _sUserName = value
        End Set
    End Property

    ''' <summary>
    ''' اجراء لتحميل النموذج الخاص بالطباعة
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ShowPrintWizared()
        Dim f As New FinaBalances1

        f.Show()

    End Sub



End Class

