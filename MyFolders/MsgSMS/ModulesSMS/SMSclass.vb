Imports System.IO.Ports
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Public Class SMSclass
    Private Declare Sub Sleep Lib "kernel32" (ByVal milsec As Long)
    Public receiveNow As New AutoResetEvent(False)
    Shared ReadOnly readNow As New AutoResetEvent(False)

    Public Function OpenPort(ByVal comport As String) As SerialPort
        Dim serialport As New IO.Ports.SerialPort

        Try
            If comport <> Nothing Then
                With serialport
                    .PortName = comport
                    .BaudRate = 96000
                    .Parity = Parity.None
                    .DataBits = 8
                    .StopBits = StopBits.One
                    .Handshake = Handshake.RequestToSend
                    .ReadTimeout = 300
                    .WriteTimeout = 300
                    .Encoding = Encoding.GetEncoding("iso-8859-1")
                    .DtrEnable = True
                    .RtsEnable = True
                    .NewLine = vbCrLf
                End With
                serialport.Open()
                Return serialport
            Else
                Return serialport
            End If
        Catch ex As Exception
            Throw
        End Try


    End Function
    Public Shared Sub ClosePort(ByVal serialport As SerialPort)
        Try
            serialport.Close()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Port_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        If e.EventType = SerialData.Chars Then
            receiveNow.Set()
        End If
    End Sub
    Private Shared Sub DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        If e.EventType = SerialData.Chars Then
            readNow.Set()
        End If
    End Sub
    'Public Function ExecCommand(ByVal port As SerialPort, ByVal strcommand As String, ByVal errmess As String)
    '    port.WriteLine(strcommand)
    '    'ConnSMS.SendMsg.Text = ConnSMS.SendMsg.Text & strcommand
    '    Dim input As String = ReadResponse(port, 400)

    '    SendMsg.Text = SendMsg.Text & input
    '    Return input
    'End Function



    Public Function ExecCommand(ByVal port As SerialPort, ByVal command As String, ByVal responseTimeout As Integer, ByVal errorMessage As String) As String
        If errorMessage Is Nothing Then
            Throw New ArgumentNullException(NameOf(errorMessage))
        End If

        Try
            port.DiscardOutBuffer()
            port.DiscardInBuffer()
            receiveNow.Reset()
            port.Write(command & vbCr)
            Dim input As String = ReadResponse(port, responseTimeout)
            If (input.Length = 0) OrElse ((Not input.EndsWith(vbCrLf & "> ")) AndAlso (Not input.EndsWith(vbCrLf & "OK" & vbCrLf))) Then Throw New ApplicationException("No success message was received.")
            Return input
        Catch ex As Exception
            Throw
        End Try
    End Function




    Public Shared Function ReadResponse(ByVal port As SerialPort, ByVal timeout As Integer)

        Dim buff As String = ""
        Try
            Do
                Dim t As String = port.ReadExisting()
                buff &= t
            Loop Until buff.EndsWith(vbCrLf & "OK" & vbCrLf) Or buff.EndsWith(vbCrLf & "> ") Or buff.EndsWith(vbCrLf & "ERROR" & vbCrLf)
        Catch ex As Exception
            Throw
        End Try
        Return buff
    End Function

    Public Function SendSMS(ByVal port As SerialPort, ByVal PhoneNo As String, ByVal Message As String) As Boolean
        Dim isSent As Boolean = False

        Dim unused As String = ExecCommand(port, "AT" & vbCr, 300, "Unable to connect.")
        System.Threading.Thread.Sleep(200)
        Dim unused1 As String = ExecCommand(port, "AT+CMGF=1" & vbCr, 300, "Failed to set message format.")
        System.Threading.Thread.Sleep(200)
        Dim unused2 As String = ExecCommand(port, "AT+CMGS=" & Chr(34) & PhoneNo & Chr(34) & vbCr, 300, "Failed to accept phoneNo")
        System.Threading.Thread.Sleep(200)
        Dim receivedData As String = ExecCommand(port, vbBack & vbBack & "FROM PICTU SMS: " & Message & Chr(26), 300, "Failed to send message")
        System.Threading.Thread.Sleep(200)

        If receivedData.EndsWith(vbCrLf & "OK" & vbCrLf) Then
            isSent = True
        ElseIf receivedData.Contains("ERROR") Then
            isSent = False
        End If
        Return isSent

    End Function

    Public Function ReadSMS(ByVal port As SerialPort, ByVal command As String)
        If command Is Nothing Then
            Throw New ArgumentNullException(NameOf(command))
        End If

        ExecCommand(port, "AT" & vbCr, 300, "Unable to connect.")
        System.Threading.Thread.Sleep(200)
        ExecCommand(port, "AT+CMGF=1" & vbCr, 300, "Failed to set message format.")
        System.Threading.Thread.Sleep(200)
        ExecCommand(port, "AT+CSCS=" & Chr(34) & "PCCP437" & Chr(34), 300, "Failed to set character set.")
        System.Threading.Thread.Sleep(200)
        ExecCommand(port, "AT+CPMS=" & Chr(34) & "ME" & Chr(34), 300, "Failed to select message storage.")
        System.Threading.Thread.Sleep(200)
        Dim receivedData As String = ExecCommand(port, "AT+CMGL=" & Chr(34) & "REC UNREAD" & Chr(34), 300, "Failed to read all message.")
        System.Threading.Thread.Sleep(200)
        Dim messages As ShrotMessageCollection = ParseMessages(receivedData)

        If Nothing IsNot Nothing Then
            Return Nothing
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function ParseMessages(ByVal input As String) As ShrotMessageCollection
        Dim messages As New ShrotMessageCollection()
        Try
            Dim r As New Regex("\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n")
            Dim m As Match = r.Match(input)
            While m.Success
                'msg.Index = int.Parse(m.Groups[1].Value);
                Dim msg As New ShortMessage With {
                    .Index = m.Groups(1).Value,
                    .Status = m.Groups(2).Value,
                    .Sender = m.Groups(3).Value,
                    .Alphabet = m.Groups(4).Value,
                    .Sent = m.Groups(5).Value,
                    .Message = m.Groups(6).Value
                }
                messages.Add(msg)

                m = m.NextMatch()

            End While
        Catch ex As Exception
            Throw
        End Try
        Return messages
    End Function



End Class
