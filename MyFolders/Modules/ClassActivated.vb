
Imports System.Management
Imports System.Security.Cryptography
Imports System.Text

Public Class COManagement

    Public Shared Function SECU() As String
        Dim VA1 As String = ""
        Dim ma As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
        Try
            For Each MO As ManagementObject In ma.Get()
                VA1 = MO("SerialNumber").ToString.Trim
                Return VA1
            Next

        Catch ex As ManagementException
            Return ""
        End Try
        Return VA1
    End Function
    Public Shared Function Md5ha(ByVal Text As String) As String
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Text))
        Dim resuilt As Byte() = md5.Hash
        Dim strbuil As New StringBuilder
        For I As Integer = 0 To resuilt.Length - 1
            strbuil.Append(resuilt(I).ToString("x2"))
        Next
        Dim f1 As String = strbuil.ToString()
        Dim f2 As String = f1.Substring(0, 5) + "_" + f1.Substring(5, 5) + "_" + f1.Substring(10, 5) + "_" + f1.Substring(15, 5) + "_" + f1.Substring(20, 5)
        Return f2

    End Function

End Class
