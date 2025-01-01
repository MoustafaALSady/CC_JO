Option Explicit Off
Imports System.Data.SqlClient

Public Class FormAuditorsnotes
    Inherits System.Windows.Forms.Form
    Public SqlDataAdapter1 As SqlDataAdapter
    Dim dt As New DataTable
    Dim NOROWS As String

    Private Sub FormAuditorsnotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT   AN, AN1, AN2, AN3, AN4, AN5, AN6, USERNAME, CUser  FROM Auditorsnotes  WHERE AN7 ='" & True & "' and CUser ='" & CUser & "'"
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()

        SqlDataAdapter1 = New SqlDataAdapter(strSQL)
        dt = New DataTable
        Me.SqlDataAdapter1.Fill(dt)
        Me.DataGridView1.DataSource = dt
        Consum.Close()
        Me.DataGridView1.Columns.Item("AN6").Visible = False
        Me.DataGridView1.Columns.Item("CUser").Visible = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        If Me.DataGridView1.Rows.Count > 0 Then
            Connection.AN = Me.DataGridView1.CurrentRow.Cells("AN").Value
        Else
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
        End If

        Call MangUsers()
        If Me.TextAconet.Text = Nothing Then
            AudiSearchMoves()
        End If
    End Sub

    Public Sub Audi()
        If InternalAuditor = False Then
            Accountingprocedure = True
        Else
            Auditorsnotes = True
        End If
        If Me.DataGridView1.Rows.Count > 0 Then
            Connection.AN = Me.DataGridView1.CurrentRow.Cells("AN").Value
        Else
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
        End If
        Me.TextXx.Text = String.Join(Environment.NewLine, (From item As Object In Me.ListAconet.Items Select Me.ListAconet.GetItemText(item).Trim()).ToArray())
    End Sub
    Public Sub AudiSearchMoves()
        Me.TextAconet.Clear()
        Audi()
        Connection.ACONET.Clear()
        Dim xCount As Integer
        For XX As Integer = 0 To Me.TextXx.Lines.Length - 1
            xCount = XX + 1
            Connection.ACONET.Add(xCount & "- " & " " & "تم تعديل حساب " & String.Concat(New String() {Me.TextXx.Lines(XX).ToString}) & " " & "الى حساب" & " ")
        Next
        Try
            If Not IsNothing(Connection.ACONET) Then
                For x As Integer = 0 To Connection.ACONET.Count - 1
                    Me.TextAconet.AppendText(Connection.ACONET(x) & vbCrLf)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information, "معلومات")
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        'On Error Resume Next
        If Me.DataGridView1.Rows.Count > 0 Then
            For Each r As DataGridViewRow In DataGridView1.Rows
                NOROWS = CDbl(r.Cells("AN1").Value)

                If r.Cells("AN5").Value = "المبيعات" Then
                    SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf r.Cells("AN5").Value = "المشتريات" Then
                    SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
                Connection.AN = Me.DataGridView1.CurrentRow.Cells("AN").Value
                SEARCHDATA.SEARCHMOVESDATA(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
                Connection.AN2 = MOV2.ToString.Trim
            Next
        Else
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
        End If

        Me.TextXx.Clear()
        Dim unused = TextXx.Lines.ToArray()
        Me.ListAconet.Items.Clear()
        ModuleGeneral.FILLCOMBOBOX2("MOVESDATA", "MOVD3", "MOV2", Connection.AN2, Me.ListAconet)
        Me.TextXx.Text = String.Join(Environment.NewLine, (From item As Object In Me.ListAconet.Items Select Me.ListAconet.GetItemText(item).Trim()).ToArray())
        If Me.DataGridView1.Rows.Count > 0 Then
            Connection.AN = Me.DataGridView1.CurrentRow.Cells("AN").Value
        Else
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
        End If
        'If Me.TextBox2.Text = Nothing Then
        AudiSearchMoves()
        'End If
        'LisrBCount = Me.TextBox1.Lines.Count
        'MsgBox(LisrBCount)
    End Sub
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        ''On Error Resume Next
        If Me.DataGridView1.Rows.Count > 0 Then
            For Each r As DataGridViewRow In DataGridView1.Rows
                NOROWS = CDbl(r.Cells("AN1").Value)
                If r.Cells("AN5").Value = "المبيعات" Then
                    SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf r.Cells("AN5").Value = "المشتريات" Then
                    SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
                Connection.AN = Me.DataGridView1.CurrentRow.Cells("AN").Value
                SEARCHDATA.SEARCHMOVESDATA(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
                Connection.AN2 = MOV2.ToString.Trim
            Next
            Me.TextXx.Clear()
            Dim unused = TextXx.Lines.ToArray()
            ''ListBox1.Items.Clear()

        Else
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
        End If

        If Me.DataGridView1.Rows.Count > 0 Then
            FILLCOMBOBOX2("MOVESDATA", "MOVD3", "MOV2", Connection.AN2, Me.ListAconet)
            Me.TextXx.Text = String.Join(Environment.NewLine, (From item As Object In Me.ListAconet.Items Select Me.ListAconet.GetItemText(item).Trim()).ToArray())
            Connection.AN = Me.DataGridView1.CurrentRow.Cells("AN").Value
        Else
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
        End If
        'If Me.TextBox2.Text = Nothing Then
        AudiSearchMoves()
        'End If
        'LisrBCount = Me.TextBox1.Lines.Count
        'MsgBox(LisrBCount)
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'If Me.TextBox2.Text = Nothing Then
        AudiSearchMoves()
        'End If
        'LisrBCount = Me.TextBox1.Lines.Count
        'MsgBox(LisrBCount)
        Dim Consum As New SqlClient.SqlConnection(constring)
        Connection.AN = Me.DataGridView1.CurrentRow.Cells("AN").Value
        If Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmDailyrestrictions.Text Then
            Dim f1 As New FrmDailyrestrictions With {
                .TB2 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f1.Show()
            f1.Load_Click(sender, e)
        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmBanks5.Text Then
            Dim f As New FrmBanks5 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f.Show()
            f.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmJO.Text Then
            Dim f2 As New FrmJO With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f2.Show()
            f2.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmEmpsolf.Text Then
            Dim f3 As New FrmEmpsolf With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f3.Show()
            f3.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmChecks.Text Then
            Dim f4 As New FrmChecks With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f4.Show()
            f4.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmDeposits.Text Then
            Dim f5 As New FrmDeposits With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f5.Show()
            f5.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmTransaction.Text Then
            Dim f5 As New FrmTransaction With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f5.Show()
            f5.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmCustomersA.Text Then
            SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
            Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            Dim f6 As New FrmCustomersA
            If Me.RadInvoiceStatus.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
            f6.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("AN1").Value)
            f6.Show()
            f6.DanLOd()
        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = Form_mabeat.Text Then
            Dim f8 As New Form_mabeat
            f8.Textdaee1.Text = Me.DataGridView1.CurrentRow.Cells("AN3").Value
            f8.Show()
            f8.BuakrT_Click(sender, e)

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmSuppliesA.Text Then
            SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells("AN2").Value)
            Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
            Dim f7 As New FrmSuppliesA
            Cash = True
            If Me.RadInvoiceStatus.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
            f7.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("AN1").Value)
            f7.Show()
            f7.DanLOd()
        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmCUSTOMER1.Text Then
            Dim f8 As New FrmCUSTOMER1 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f8.Show()
            f8.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmCUSTOMER11.Text Then
            Dim f9 As New FrmCUSTOMER11 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f9.Show()
            f9.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmInvoice.Text Then
            Dim f10 As New FrmInvoice With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f10.Show()
            f10.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmTRANSPORT.Text Then
            Dim f11 As New FrmTRANSPORT With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f11.Show()
            f11.Load_Click(sender, e)

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmMyCosts.Text Then
            Dim f12 As New FrmMyCosts With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f12.Show()
            f12.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FrmSuppliers1.Text Then
            Dim f13 As New FrmSuppliers1 With {
                .TB1 = Me.DataGridView1.CurrentRow.Cells("AN1").Value
            }
            f13.Show()
            f13.DanLOd()

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = FormEmployees4.Text Then
            Dim ds14 As New DataSet
            Dim f14 As New FormEmployees4
            ds14.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ORDER BY SLY1", Consum)
            Dim SqlDataAdapter14 As New SqlClient.SqlDataAdapter
            ds14.Clear()
            SqlDataAdapter14.Fill(ds14, "SALARIES")
            f14.BS.DataMember = "SALARIES"
            f14.BS.DataSource = ds14
            Dim index As Integer
            index = f14.BS.Find("SLY1", Me.DataGridView1.CurrentRow.Cells("AN1").Value)
            f14.Show()
            f14.Load_Click(sender, e)
            f14.BS.Position = index

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = Loans.Text Then
            Dim f15 As New Loans With {
                .TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("AN1").Value)
            }
            f15.Show()
            f15.Load_Click(sender, e)

        ElseIf Me.DataGridView1.CurrentRow.Cells("AN5").Value = Loans2.Text Then
            Dim f16 As New Loans2 With {
                .TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("AN1").Value)
            }
            f16.Show()
            f16.DanLOd()
        End If

    End Sub

End Class