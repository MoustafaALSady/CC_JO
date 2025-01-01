Public Class FrmCustoms
    Private Sub FrmCustoms_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub FrmCALACCUSTOMS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        On Error Resume Next
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next

        FILLCOMBOBOX1("STOCKSITEMS", "SKITM5", "CUser", CUser, Me.COMBO3)
        Me.COMBO1.Text = "”Ì›"
        Me.COMBO2.Text = "œÊ·«— «„—ÌﬂÏ"
        Me.COMBO3.Text = "»Ê·Ï √ÌÀ·Ì‰"
        Me.COMBO4.Text = "Ê«—œ ‰Â«∆Ï"
        Me.ComboBox1.Text = "«Ê—»Ì…"
        Me.TEXT10.Text = 16
        Me.TEXT12.Text = 25
        Me.TEXT17.Enabled = False
        Me.ComboBox1.Enabled = False
    End Sub
    Private Sub TEXT1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXT1.TextChanged, TEXT10.TextChanged, TEXT11.TextChanged, TEXT12.TextChanged, TEXT13.TextChanged, TEXT14.TextChanged, TEXT15.TextChanged, TEXT16.TextChanged, TEXT17.TextChanged, TEXT2.TextChanged, TEXT3.TextChanged, TEXT4.TextChanged, TEXT5.TextChanged, TEXT6.TextChanged, TEXT7.TextChanged, TEXT8.TextChanged, TEXT9.TextChanged, TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged
        On Error Resume Next
        TEXT7.Text = Format(Val(TEXT3.Text) + Val(TEXT4.Text) + Val(TEXT5.Text) + Val(TEXT6.Text), "0.000")
        If Me.CheckBox2.Checked = True Then
            TEXT9.Text = Format(Val(TEXT7.Text) * Val(TEXT8.Text) / 100 * Val(TEXT17.Text) / 100, "0.000")
        Else
            TEXT17.Text = 0
            TEXT9.Text = Format(Val(TEXT7.Text) * Val(TEXT8.Text) / 100, "0.000")
        End If
        TEXT11.Text = Format(Val(TEXT10.Text) * (Val(TEXT7.Text) + Val(TEXT9.Text)) / 100, "0.000")
        If Me.CheckBox1.Checked = False Then
            TEXT13.Text = Format(Val(TEXT7.Text) * Val(TEXT12.Text) / 100, "0.000")
        Else
            TEXT12.Text = 25
            TEXT13.Text = 0
        End If
        If Me.COMBO1.Text = "«ﬂ” Ê—Êﬂ" Then
            Me.TextBox5.Text = Format(Val(TEXT1.Text) * Val(TEXT2.Text) * 0.05, "0.000")
            TEXT3.Text = Format(Val(TEXT1.Text) * Val(TEXT2.Text) + Val(Me.TextBox5.Text), "0.000")
        Else
            Me.TextBox5.Text = 0
            TEXT3.Text = Format(Val(TEXT1.Text) * Val(TEXT2.Text), "0.000")
        End If
        If Val(Me.TextBox3.Text) > 0 Then
            Me.TEXT4.Text = Format(Val(TEXT3.Text) * Val(Me.TextBox3.Text) / 100, "0.000")
        End If
        If Val(Me.TextBox2.Text) > 0 Then
            Me.TEXT5.Text = Format(Val(TEXT3.Text) * Val(Me.TextBox2.Text) / 100, "0.000")
        End If
        If Val(Me.TextBox1.Text) > 0 Then
            Me.TEXT6.Text = Format(Val(TEXT3.Text) * Val(Me.TextBox1.Text) / 100, "0.000")
        End If
        If Me.COMBO4.Text = "”„«Õ „ƒﬁ " Then
            TEXT15.Text = Format((Val(TEXT9.Text) + Val(TEXT11.Text) + Val(TEXT13.Text) + Val(TEXT14.Text)) / 4, "0.000")
        Else
            TEXT15.Text = Format(Val(TEXT9.Text) + Val(TEXT11.Text) + Val(TEXT13.Text) + Val(TEXT14.Text), "0.000")
        End If
        Me.TEXT16.Text = CurrencyJO(Me.TEXT15.Text, "jO")
    End Sub
    Private Sub COMBO1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles COMBO1.SelectedIndexChanged
        On Error Resume Next
        TEXT1_TextChanged(sender, e)
        Select Case Me.COMBO1.Text
            Case "”Ì›"
                Me.TEXT4.Enabled = False
                Me.TEXT5.Enabled = False
                Me.TextBox3.Enabled = False
                Me.TextBox2.Enabled = False
                Me.TextBox5.Enabled = False
            Case "ﬁÊ»"
                Me.TEXT4.Enabled = True
                Me.TEXT5.Enabled = True
                Me.TextBox3.Enabled = True
                Me.TextBox2.Enabled = True
                Me.TextBox5.Enabled = False
            Case "”Ï «‰œ «›"
                Me.TEXT4.Enabled = False
                Me.TEXT5.Enabled = True
                Me.TextBox3.Enabled = False
                Me.TextBox2.Enabled = True
                Me.TextBox5.Enabled = False
            Case "”Ï «‰œ «Ï"
                Me.TEXT4.Enabled = True
                Me.TEXT5.Enabled = False
                Me.TextBox3.Enabled = True
                Me.TextBox2.Enabled = False
                Me.TextBox5.Enabled = False
            Case "«ﬂ” Ê—Êﬂ"
                Me.TEXT4.Enabled = True
                Me.TEXT5.Enabled = True
                Me.TextBox3.Enabled = True
                Me.TextBox2.Enabled = True
                Me.TextBox5.Enabled = True
        End Select
    End Sub
    Private Sub COMBO2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles COMBO2.SelectedIndexChanged
        On Error Resume Next
        TEXT1_TextChanged(sender, e)
        Select Case Me.COMBO2.Text
            Case "œÊ·«— «„—ÌﬂÏ"
                Me.TEXT2.Text = 0.7
            Case "ÌÊ—Ê"
                Me.TEXT2.Text = 0.85
            Case "œÌ‰«— √—œ‰Ì"
                Me.TEXT2.Text = 1
            Case "Ã‰Ì… «” —·Ì‰Ï"
                Me.TEXT2.Text = 0.92
            Case "—Ì« · ”⁄ÊœÏ"
                Me.TEXT2.Text = 4.5
        End Select
    End Sub
    Private Sub COMBO3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles COMBO3.SelectedIndexChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As String = "SELECT cust4 ,cust6 FROM CUSTOMSTABLE WHERE cust2='" & Me.COMBO3.Text & "'"
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1, Consum)
        ds.Clear()
        Adp1.Fill(ds, "CUSTOMSTABLE")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXT8.Text = Val(ds.Tables(0).Rows(0).Item(1))
            Me.TextBox4.Text = Val(ds.Tables(0).Rows(0).Item(0))
            Me.TEXT10.Text = 10
            If Me.CheckBox1.Checked = False Then
                TEXT12.Text = 0.5
            Else
                TEXT12.Text = 0
            End If
        Else
            Me.TEXT8.Text = "0"
            Me.TEXT10.Text = 16
            Me.TEXT12.Text = 25
        End If
        Adp1.Dispose()
        Consum.Close()
        ComboBox1_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub COMBO4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles COMBO4.SelectedIndexChanged
        On Error Resume Next
        TEXT1_TextChanged(sender, e)
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = False Then
            TEXT13.Text = Format(Val(TEXT7.Text) * Val(TEXT12.Text) / 100, "0.000")
        Else
            TEXT12.Text = 0
            TEXT13.Text = 0
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            Me.TEXT17.Enabled = True
            Me.ComboBox1.Enabled = True
            TEXT12.Text = 0.5
            TEXT9.Text = Format(Val(TEXT7.Text) * Val(TEXT8.Text) / 100 * Val(TEXT17.Text) / 100, "0.000")
        Else
            Me.TEXT17.Enabled = False
            Me.ComboBox1.Enabled = False
            TEXT12.Text = 25
            TEXT17.Text = 0
            TEXT9.Text = Format(Val(TEXT7.Text) * Val(TEXT8.Text) / 100, "0.000")
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As String = "SELECT cust7 ,cust8 FROM CUSTOMSTABLE WHERE cust2='" & Me.COMBO3.Text & "'"
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1, Consum)
        ds.Clear()
        Adp1.Fill(ds, "CUSTOMSTABLE")
        If ds.Tables(0).Rows.Count > 0 Then
            If Me.ComboBox1.Text = "«Ê—»Ì…" Then
                Me.TEXT17.Text = Val(100 - Val(ds.Tables(0).Rows(0).Item(0)))

            Else
                Me.TEXT17.Text = Val(100 - Val(ds.Tables(0).Rows(0).Item(1)))
            End If
            If Me.CheckBox1.Checked = False Then
                TEXT12.Text = 0.5
            Else
                TEXT12.Text = 0
            End If
        Else
            Me.TEXT8.Text = "0"
            Me.TEXT10.Text = 16
            Me.TEXT12.Text = 25
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class