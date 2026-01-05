Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Class_DR
    Public Sub New()

    End Sub

    'first check sa og warehouse to warehouse ba
    'pinaagi sa consession ticket #
    Public Function concession_exist(inout As String, consession As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@inout", inout)
            newCMD.Parameters.AddWithValue("@consession", consession)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                concession_exist = newDR.Item("con_exist").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function dr_exist(inout As String, dr_no As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@inout", inout)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                dr_exist = newDR.Item("dr_exist").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
End Class
