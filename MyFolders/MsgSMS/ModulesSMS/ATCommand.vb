'Imports System.Threading.Tasks
Imports System.Diagnostics

Namespace ICS.EnterpriseResourcePlaning
    Module MyPhoneExplorere
        Public ReadOnly Property MyPhoneExplorerApplicationName() As String
            Get
                Return "MyPhoneExplorer"
            End Get
        End Property

        Public ReadOnly Property MyPhoneExplorerFullPath() As String
            Get

                For Each clsProcess As Process In Process.GetProcesses()

                    If clsProcess.ProcessName.Contains(MyPhoneExplorerApplicationName) Then
                        Return clsProcess.Modules(0).FileName
                    End If
                Next

                MessageBox.Show("MyPhoneExplorer ist nicht offen!", "MyPhoneExplorer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return String.Empty
            End Get
        End Property

        Function SendSMS(ByVal phoneNumber As String, ByVal messageText As String) As Boolean
            Dim fileName As String = MyPhoneExplorerFullPath

            If fileName <> String.Empty Then
                Dim arguments As String = String.Format(" action=sendmessage savetosent=1 number={0} text=""{1}""", phoneNumber, messageText.Replace(""""c, "*"c))
                StartPhoneExplorerWithArguments(fileName, arguments)
                Return True
            End If

            Return False
        End Function

        Sub CallPhoneNumber(ByVal phoneNumber As String)
            Dim fileName As String = MyPhoneExplorerFullPath

            If fileName <> String.Empty Then
                Dim arguments As String = String.Format(" action=dial number={0}", phoneNumber)
                StartPhoneExplorerWithArguments(fileName, arguments)
            End If
        End Sub

        Private Sub StartPhoneExplorerWithArguments(ByVal fileName As String, ByVal arguments As String)
            Dim MyPhoneExplorer As New Process()
            MyPhoneExplorer.StartInfo.FileName = fileName
            MyPhoneExplorer.StartInfo.Arguments = arguments
            MyPhoneExplorer.Start()
        End Sub
    End Module
End Namespace