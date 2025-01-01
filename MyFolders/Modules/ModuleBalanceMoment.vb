Imports System.Data.SqlClient

Module ModuleBalanceMoment

    Public Function Fs1() As Double
        Try
            Dim Adp1 As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim strsq As New SqlCommand("SELECT Sum(CAB4-CAB5)  FROM CABLES WHERE CUser='" & CUser & "'and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'GROUP BY CAB6 HAVING CAB6='نقدا'", Consum)
            Consum = New SqlConnection(constring)
            Dim ds As New DataSet
            Adp1 = New SqlDataAdapter(strsq)
            ds.Clear()
            Adp1.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Fs1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Fs1 = "0"
            End If
            Adp1.Dispose()
            Consum.Close()
            Return Fs1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorFs1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Fs1
        End Try
    End Function
    Public Function Fs2() As Double
        Try
            Dim Adp2 As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim strsq2 As New SqlCommand("SELECT SUM(CSH7 - CSH8) As Result  FROM EMPSOLF  WHERE CUser='" & CUser & "'and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum = New SqlConnection(constring)
            Dim ds As New DataSet
            Adp2 = New SqlDataAdapter(strsq2)
            ds.Clear()
            Adp2.Fill(ds)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                Fs2 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Fs2 = "0"
            End If
            Adp2.Dispose()
            Consum.Close()
            Return Fs2
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "ErrorFs2", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Fs2
        End Try
    End Function

    Public Function Fs3() As Double
        Try
            Dim Adp3 As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim strsq3 As New SqlCommand("SELECT Sum(EBNK4 - EBNK5) AS Result  FROM BANKJO  WHERE CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum = New SqlConnection(constring)
            Dim ds As New DataSet
            Adp3 = New SqlDataAdapter(strsq3)
            ds.Clear()
            Adp3.Fill(ds)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                Fs3 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Fs3 = "0"
            End If
            Adp3.Dispose()
            Consum.Close()
            'Return Fs3()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "ErrorFs3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Fs3()
        End Try
    End Function
    Public Function Fs4() As Double
        Try
            Dim Adp1 As SqlDataAdapter
            Dim Adp2 As SqlDataAdapter
            Dim Adp3 As SqlDataAdapter
            Dim SUM1 As Double = 0
            Dim SUM2 As Double = 0
            Dim SUM3 As Double = 0
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(CAB4) As Result  FROM CABLES WHERE CUser='" & CUser & "'and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'AND CAB6='شيك'", Consum)
            Dim strsq2 As New SqlCommand("SELECT Sum(CCUST2) As Result  FROM CABLESCO WHERE CCUST5=1", Consum)
            Dim strsq3 As New SqlCommand("SELECT Sum(CEMP15) As Result  FROM CABLESCOEMPLOYEES WHERE CUser='" & CUser & "'and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'AND CABLESCOEMPLOYEES.[CEMP13]='شيك و نقدا'", Consum)
            Consum = New SqlConnection(constring)
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            Adp1 = New SqlDataAdapter(strsq1)
            Adp2 = New SqlDataAdapter(strsq2)
            Adp3 = New SqlDataAdapter(strsq3)
            ds.Clear()
            ds1.Clear()
            ds2.Clear()
            Adp1.Fill(ds)
            Adp2.Fill(ds1)
            Adp3.Fill(ds2)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                SUM1 = "0"
            End If
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                SUM2 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                SUM2 = "0"
            End If
            If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                SUM3 = Format(Val(ds2.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                SUM3 = "0"
            End If
            Adp1.Dispose()
            Adp2.Dispose()
            Adp3.Dispose()
            Consum.Close()
            Fs4 = Format(Val(SUM1) - Val(SUM2) + Val(SUM3), "0.000")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "ErrorFs4", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Fs4()
        End Try
    End Function
    Public Function Fs5() As Double
        Try
            Dim Adp5 As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim strsq5 As New SqlCommand("SELECT Sum(CSH7 - CSH8) As Result  FROM CASHIER  WHERE CUser='" & CUser & "'and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum = New SqlConnection(constring)
            Dim ds As New DataSet
            Adp5 = New SqlDataAdapter(strsq5)
            ds.Clear()
            Adp5.Fill(ds)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                Fs5 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Fs5 = "0"
            End If
            Adp5.Dispose()
            Consum.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "ErrorFs5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Fs5()
        End Try
    End Function

    Public Function Fs6() As Double
        Try
            Fs6 = Format(Val(Fs1) + Val(Fs2) + Val(Fs5) + Val(Fs3) + Val(Fs4), "0.000")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "ErrorFs6", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Fs6()
        End Try
    End Function
    Public Function NotNull(Of T)(ByVal Value As T, ByVal DefaultValue As T) As T
        If Value Is Nothing OrElse IsDBNull(Value) Then
            Return DefaultValue
        Else
            Return Value
        End If
    End Function


    Public Function Msg() As String
        Msg = "لديك رسالة جديدة"
    End Function
End Module
