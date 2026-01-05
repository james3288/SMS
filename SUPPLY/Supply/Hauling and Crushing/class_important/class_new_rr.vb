Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class class_new_rr
    Private cRRNo As String
    Public trd As Threading.Thread

    Structure rr_details

        Dim rr_item_id As Integer
        Dim wh_id As Integer
        Dim rr_no As String
        Dim rr_date As DateTime
        Dim item_name As String
        Dim item_desc As String

    End Structure

    Public cListOFRR As New List(Of rr_details)
    Public Sub _initialize(Optional rr_no As String = "")
        cListOFRR.Clear()
        cRRNo = rr_no
        trd = New Threading.Thread(AddressOf get_rr)
        trd.Start()

    End Sub

    Private Sub get_rr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim new_rr As New rr_details


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@search", cRRNo)
            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader

            While newDR.Read
                new_rr.rr_item_id = newDR.Item("rr_item_id").ToString
                new_rr.rr_no = newDR.Item("rr_no").ToString
                new_rr.rr_date = newDR.Item("date_received").ToString
                new_rr.wh_id = newDR.Item("wh_id").ToString
                new_rr.item_name = newDR.Item("item_name").ToString
                new_rr.item_name = newDR.Item("item_desc").ToString

                cListOFRR.Add(new_rr)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

End Class
