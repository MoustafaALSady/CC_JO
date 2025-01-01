Imports System.Threading
Imports WhatsAppApi
Imports WhatsAppApi.ApiBase
Imports WhatsAppApi.Helper

Public Class FormWhatsAppApi
    Private wa As WhatsApp
    Private Delegate Sub UpdateTextBox(ByVal textbox As TextBox, ByVal value As String)
    Public Sub UpdateDataTextBox(ByVal textbox As TextBox, ByVal value As String)
        Dim box As TextBox = textbox
        box.Text &= value
    End Sub




    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If ((Not String.IsNullOrEmpty(Me.txtMessage.Text) AndAlso (Me.wa IsNot Nothing)) AndAlso (Me.wa.ConnectionStatus = CONNECTION_STATUS.LOGGEDIN)) Then
            Me.wa.SendMessage(Me.txtTo.Text, Me.txtMessage.Text)
            Dim txtStatus As TextBox = Me.txtStatus
            txtStatus.Text &= String.Format(Environment.NewLine & "{0}:{1}", txtName.Text, Me.txtMessage.Text)
            Me.txtMessage.Clear()
            Me.txtMessage.Focus()
        End If
    End Sub





    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim thread = New Thread(AddressOf ThreadTask) With {
            .IsBackground = True
        }
        thread.Start()
    End Sub
    ''https://api.ultramsg.com/instance95126/messages/chat?token=n6orpwqgb6dp0ukd&to=+962791908159&body=%D8%B1%D8%B3%D8%A7%D9%84%D8%A9+%D8%AA%D8%AC%D8%B1%D9%8A%D8%A8%D9%8A%D8%A9+%D9%85%D9%86+UltraMsg.com&priority=10
    Private Sub ThreadTask()
        Try


            Dim TextBox As New UpdateTextBox(AddressOf Me.UpdateDataTextBox)
            Me.wa = New WhatsApp(Me.txtPhoneNumber.Text, Me.txtPassword.Text, Me.txtName.Text, True, False)
            AddHandler Me.wa.OnConnectSuccess, Sub()
                                                   If Me.txtStatus.InvokeRequired Then
                                                       Dim objArray1 As Object() = New Object() {Me.txtStatus, "Connected..."}
                                                       Me.Invoke(TextBox, objArray1)
                                                   End If
                                                   AddHandler Me.wa.OnLoginSuccess, Sub(ByVal phone As String, ByVal data As Byte())
                                                                                        If Me.txtStatus.InvokeRequired Then
                                                                                            Dim args As Object() = New Object() {Me.txtStatus, Environment.NewLine & "Login success !"}
                                                                                            Me.Invoke(TextBox, args)
                                                                                        End If
                                                                                        While Me.wa IsNot Nothing
                                                                                            Me.wa.PollMessages()
                                                                                            Thread.Sleep(200)
                                                                                            Continue While
                                                                                        End While
                                                                                    End Sub

                                                   AddHandler Me.wa.OnLoginFailed, Sub(ByVal data As String)
                                                                                       If Me.txtStatus.InvokeRequired Then
                                                                                           Dim args As Object() = New Object() {Me.txtStatus, String.Format(Environment.NewLine & "Login failed: {0}", data)}
                                                                                           Me.Invoke(TextBox, args)
                                                                                       End If
                                                                                   End Sub

                                                   AddHandler Me.wa.OnGetMessage, Sub(ByVal node As ProtocolTreeNode, ByVal from As String, ByVal id As String, ByVal name As String, ByVal message As String, ByVal receipt_sent As Boolean)
                                                                                      If Me.txtStatus.InvokeRequired Then
                                                                                          Dim args As Object() = New Object() {Me.txtStatus, String.Format(Environment.NewLine & "{0}:{1}", name, message)}
                                                                                          Me.Invoke(TextBox, args)
                                                                                      End If
                                                                                  End Sub
                                                   Me.wa.Login(Nothing)
                                               End Sub
            AddHandler Me.wa.OnConnectFailed, Sub(ByVal ex As Exception)
                                                  If Me.txtStatus.InvokeRequired Then
                                                      Dim args As Object() = New Object() {Me.txtStatus, String.Format(Environment.NewLine & "Connect failed: {0}", ex.StackTrace)}
                                                      Me.Invoke(TextBox, args)
                                                  End If
                                              End Sub
            Me.wa.Connect()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorThreadTask", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

End Class