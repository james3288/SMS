Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_new_po
    Structure PO_details
        Dim po_no As String
        Dim wh_id As Integer
        Dim item_name As String
        Dim item_desc As String
        Dim rs_id As Integer
        Dim po_date As DateTime
        Dim inout As String
        Dim type_of_purchasing As String
        Dim dr_option As String

    End Structure

    Public trd As Threading.Thread

    Public cListofHaulingPO As New List(Of PO_details)
    Public Sub _initialize()
        cListofHaulingPO.Clear()
        trd = New Threading.Thread(AddressOf get_hauling_po)
        trd.Name = "tr_get_hauling_po"
        trd.Start()

    End Sub

    Private Sub get_hauling_po()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim new_rr As New PO_details

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newDR = newCMD.ExecuteReader
            newCMD.CommandTimeout = 300

            While newDR.Read
                With new_rr
                    .po_no = newDR.Item("po_no").ToString
                    .wh_id = newDR.Item("wh_id").ToString
                    .item_name = newDR.Item("item_name").ToString
                    .item_desc = newDR.Item("item_desc").ToString
                    .rs_id = newDR.Item("rs_id").ToString
                    .po_date = IIf(newDR.Item("po_date").ToString = "", Date.Parse("1990-01-01"), newDR.Item("po_date").ToString)
                    .inout = newDR.Item("IN_OUT").ToString
                    .type_of_purchasing = newDR.Item("type_of_purchasing").ToString
                    .dr_option = "WITHOUT DR"
                End With


                cListofHaulingPO.Add(new_rr)
                Module_public_var.pub_stat = new_rr.po_no
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    Public Function hauled_with_po(rs_id As Integer) As String
        hauled_with_po = ""

        For Each row As PO_details In cListofHaulingPO
            If row.rs_id = rs_id Then
                hauled_with_po = row.po_no
                Exit For
            End If
        Next
    End Function


End Class
