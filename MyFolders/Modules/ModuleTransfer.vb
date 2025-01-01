Imports System.Windows.Forms
Module ModuleTransfer




    ''' <summary>
    ''' Checks if the transfer process can proceed based on initial conditions.
    ''' </summary>
    ''' <param name="testNet">Indicates if an internet connection is available.</param>
    ''' <param name="recordCount">Number of records in the data source.</param>
    ''' <param name="isRecordingChecked">Indicates if debt and purchases recording is active.</param>
    ''' <param name="hasTransferPermission">Indicates if the user has permission to transfer.</param>
    ''' <returns>True if the transfer can proceed, otherwise False.</returns>
    Public Function CanProceedWithTransfer(testNet As Boolean, recordCount As Integer, isRecordingChecked As Boolean, hasTransferPermission As Boolean) As Boolean
        If Not testNet Then
            MsgBox("The internet connection is not available.", 16, "Alert")
            Return False
        End If
        If recordCount = 0 Then
            Beep()
            Return False
        End If
        If isRecordingChecked Then
            MessageBox.Show("Alert: The debt and purchases recording is already transferred." & ControlChars.CrLf &
                                "1) Cancel the transfer of debt and purchases recording." & ControlChars.CrLf &
                                "2) Proceed with transferring to accounts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If Not hasTransferPermission Then
            MsgBox("Sorry, you are not allowed to transfer records.", 16, "Alert")
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Processes the transfer action based on conditions and user input.
    ''' </summary>
    ''' <param name="isSpecialCondition">A condition affecting transfer logic (e.g., OBCHK2).</param>
    ''' <param name="isTransferred">Indicates if the record is already transferred.</param>
    ''' <param name="batchValue">The batch identifier (e.g., "0" for no batch).</param>
    ''' <param name="customerName">The name of the customer for user prompts.</param>
    ''' <returns>A string indicating the action: "Transfer", "Update", "Delete", or "Cancel".</returns>
    Public Function ProcessTransferAction(isSpecialCondition As Boolean, isTransferred As Boolean, batchValue As String, customerName As String) As String
        Dim result As Integer
        If isSpecialCondition Then
            If Not isTransferred Then
                result = MessageBox.Show("Would you like to transfer the current record to the daily ledger for customer " & customerName & "?",
                                             "Transfer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                If result = vbYes Then
                    Return "Transfer"
                Else
                    Return "Cancel"
                End If
            Else
                result = MessageBox.Show("The current record was previously transferred. Would you like to update it?",
                                             "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                If result = vbYes Then
                    Return "Update"
                Else
                    result = MessageBox.Show("Would you like to delete the current record from the daily ledger?",
                                                 "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                    If result = vbYes Then
                        Return "Delete"
                    Else
                        Return "Cancel"
                    End If
                End If
            End If
        Else
            If batchValue = "0" Then
                ' No batch involved
                If Not isTransferred Then
                    result = MessageBox.Show("Would you like to transfer the current record to the daily ledger for customer " & customerName & "?",
                                                 "Transfer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If result = vbYes Then
                        Return "Transfer"
                    Else
                        Return "Cancel"
                    End If
                Else
                    result = MessageBox.Show("The current record was previously transferred. Would you like to update it?",
                                                 "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If result = vbYes Then
                        Return "Update"
                    Else
                        result = MessageBox.Show("Would you like to delete the current record from the daily ledger?",
                                                     "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                        If result = vbYes Then
                            Return "Delete"
                        Else
                            Return "Cancel"
                        End If
                    End If
                End If
            Else
                ' Batch involved
                If Not isTransferred Then
                    result = MessageBox.Show("Would you like to transfer the current record to the daily ledger and fund for customer " & customerName & "?",
                                                 "Transfer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If result = vbYes Then
                        Return "Transfer"
                    Else
                        Return "Cancel"
                    End If
                Else
                    result = MessageBox.Show("The current record was previously transferred. Would you like to update it?",
                                                 "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If result = vbYes Then
                        Return "Update"
                    Else
                        result = MessageBox.Show("Would you like to delete the current record from the daily ledger and fund?",
                                                     "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                        If result = vbYes Then
                            Return "Delete"
                        Else
                            Return "Cancel"
                        End If
                    End If
                End If
            End If
        End If
    End Function

End Module
