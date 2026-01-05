Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_rs
    Private cRS_No As String
    Private cRs_id As Integer

    Structure rs

        Dim rs_id As Integer
        Dim rs_no As String
        Dim date_request As DateTime
        Dim charges As String
        Dim wh_id As Integer
        Dim type_of_purchasing As String
        Dim inout As String
        Dim rs_qty As Double

    End Structure

    Public cListOfRsId As New List(Of rs)
    Public Sub _initialize(rs_id As String)
        cRs_id = rs_id
    End Sub

    Private Sub get_rs()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newRs As New rs
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                'newDR.Item("charges").ToString
                newRs.rs_id = newDR.Item("rs_id").ToString
                newRs.rs_no = newDR.Item("rs_no").ToString
                newRs.date_request = newDR.Item("date_req").ToString
                newRs.charges = newDR.Item("charges").ToString
                newRs.rs_qty = newDR.Item("rs_qty").ToString
                newRs.wh_id = newDR.Item("wh_id").ToString
                newRs.type_of_purchasing = newDR.Item("type_of_purchasing").ToString
                newRs.inout = newDR.Item("IN_OUT").ToString

                cListOfRsId.Add(newRs)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
End Class
