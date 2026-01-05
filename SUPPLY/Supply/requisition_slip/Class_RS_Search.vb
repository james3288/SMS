Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Class_RS_Search

    Dim swh1 As search_wh_data

    Sub New(swh As search_wh_data)
        swh1 = swh
    End Sub

    Public Structure search_wh_data

        Dim search As String
        Dim lvl As ListView
        Dim panel1 As Panel
        Dim txtsearch As TextBox
        Dim panel2 As Panel

    End Structure

    Public Sub search_by_items()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer

        If swh1.lvl.InvokeRequired Then
            swh1.lvl.Invoke(Sub()
                                swh1.lvl.Items.Clear()
                                swh1.txtsearch.Enabled = False
                                swh1.lvl.Visible = False
                                swh1.panel2.Visible = True
                            End Sub)
        End If

        If swh1.search = "" Then
            Exit Sub
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 28)
            newCMD.Parameters.AddWithValue("@search", swh1.search)
            newDR = newCMD.ExecuteReader

            While newDR.Read

                Dim a(6) As String
                a(0) = newDR.Item("wh_id").ToString
                a(1) = newDR.Item("item_name").ToString
                a(2) = newDR.Item("item_desc").ToString
                a(3) = newDR.Item("wh_area").ToString
                a(4) = newDR.Item("proper_item_name").ToString
                a(5) = newDR.Item("proper_item_desc").ToString

                Dim lvl1 As New ListViewItem(a)
                InvokeRequiredList(swh1.lvl, lvl1)

                counter += 1
            End While

            If counter = 0 Then
                If swh1.panel1.InvokeRequired Then
                    swh1.panel1.Invoke(Sub()
                                           swh1.panel1.Visible = False
                                           swh1.txtsearch.Enabled = True
                                       End Sub)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub InvokeRequiredList(listview As ListView, lvl As ListViewItem)

        If listview.InvokeRequired Then
            listview.Invoke(Sub() listview.Items.Add(lvl))
        Else
            listview.Items.Add(lvl)
        End If

    End Sub
End Class
