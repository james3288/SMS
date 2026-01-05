Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_requestor

    Private cTypeOfRequestor As String
    Private trd As Threading.Thread

    Structure requestor_details

        Dim requestor_id As Integer
        Dim requestor_desc As String

    End Structure

    Public cListOfRequestor As New List(Of requestor_details)
    Public Sub _initialize(type_of_requestor As String)
        cTypeOfRequestor = type_of_requestor
        cListOfRequestor.Clear()
        trd = New Threading.Thread(AddressOf _requestor)
        trd.Start()
        trd.Join()

        'MsgBox("done ")
    End Sub

    Private Sub _requestor()
        Select Case cTypeOfRequestor
            Case "PROJECT"
                project()

        End Select
    End Sub


    Private Sub project()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requestor", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newDR = newCMD.ExecuteReader
            Dim newReqDet As New requestor_details

            While newDR.Read
                With newReqDet
                    .requestor_id = newDR.Item("proj_id").ToString
                    .requestor_desc = newDR.Item("proj_desc").ToString

                    cListOfRequestor.Add(newReqDet)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
End Class
