Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop

Public Class Class_Receiving
    Dim rr1 As rr_data
    Dim sortColumn As Integer = -1
    Dim a, b, c, d, e, f, g As String
    Dim thread As System.Threading.Thread
    Dim counter As Integer
    Sub New(rr As rr_data)
        rr1 = rr

        a = "RR No..."
        b = "Po/CV No..."
        c = "Items..."
        d = "Charges..."
        e = "Supplier..."
        f = "Invoice No..."
        g = "Items..."

    End Sub

    Private Function placeholder(value As String) As String
        If value = a Then
            placeholder = ""
        ElseIf value = b Then
            placeholder = ""
        ElseIf value = c Then
            placeholder = ""
        ElseIf value = d Then
            placeholder = ""
        ElseIf value = e Then
            placeholder = ""
        ElseIf value = f Then
            placeholder = ""
        ElseIf value = f Then
            placeholder = ""
        Else
            placeholder = value
        End If
    End Function
    Public Structure rr_data

        Dim date_from As Date
        Dim date_to As Date
        Dim type_of_request As String
        Dim listview As ListView
        Dim lbox As ListBox
        Dim searchby As String
        Dim items As String
        Dim search As String
        Dim lbox2 As ListBox
        Dim panel As Panel
        Dim waiting_label As Label
        Dim old_rs As String
        Dim total_price As Decimal
        Dim total_amount As Decimal
        Dim lvlreceivingview As ListView
        Dim division As String
        Dim th As System.Threading.Thread

    End Structure
    Public Sub back_rr_items_in_listbox_final()
        With rr1
            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 .lbox.Items.Clear()
                                 For i = 0 To .listview.Items.Count - 1
                                     .lbox.Items.Add(.listview.Items(i).Text)
                                 Next
                             End Sub)
            End If

        End With
    End Sub

    Public Sub store_rr_items_in_listbox()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With rr1
            Try
                If .lbox2.InvokeRequired Then
                    .lbox2.Invoke(Sub()
                                      .lbox2.Items.Clear()
                                  End Sub)
                Else
                    .lbox2.Items.Clear()
                End If


                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                If .searchby = "Search By Charges" Then
                    newCMD.Parameters.AddWithValue("@n", 6)
                    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(.date_from))
                    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(.date_to))

                ElseIf .searchby = "Search By RS No" Or .searchby = "Search By Items" Then
                    newCMD.Parameters.AddWithValue("@n", 3)

                ElseIf .searchby = "Search By RR No" Then
                    newCMD.Parameters.AddWithValue("@n", 7)

                ElseIf .searchby = "Search By Invoice No." Then
                    newCMD.Parameters.AddWithValue("@n", 8)

                ElseIf .searchby = "Search By Supplier" Then
                    newCMD.Parameters.AddWithValue("@n", 9)
                    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(.date_from))
                    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(.date_to))
                    newCMD.Parameters.AddWithValue("@items", placeholder(.items))

                ElseIf .searchby = "Search By Date Received" Then
                    newCMD.Parameters.AddWithValue("@n", 27) '10,22
                    newCMD.Parameters.AddWithValue("@date_from", Date.Parse(.date_from))
                    newCMD.Parameters.AddWithValue("@date_to", Date.Parse(.date_to))
                    newCMD.Parameters.AddWithValue("@type_of_request", .type_of_request)
                    newCMD.Parameters.AddWithValue("@division", .division)

                ElseIf .searchby = "Search By PO and CV No" Then
                    newCMD.Parameters.AddWithValue("@n", 3)

                End If

                newCMD.Parameters.AddWithValue("@search", placeholder(.search))
                newCMD.Parameters.AddWithValue("@searchby", .searchby)

                newCMD.CommandTimeout = 100

                newDR = newCMD.ExecuteReader

                While newDR.Read
                    If .lbox2.InvokeRequired Then
                        .lbox2.Invoke(Sub()
                                          .lbox2.Items.Add(newDR.Item("po_det_id").ToString)
                                          c1 += 1
                                      End Sub)
                    Else
                        .lbox2.Items.Add(newDR.Item("po_det_id").ToString)
                        c1 += 1
                    End If

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Sub

    Public Sub store_rr_items_in_listview()
        With rr1


            For i = 0 To .lbox2.Items.Count - 1
                If .lbox2.InvokeRequired Then
                    .lbox2.Invoke(Sub()
                                      '.listview.Visible = False
                                      get_rr_items(.lbox2.Items(i))
                                  End Sub)
                End If
            Next

            'If .lbox2.InvokeRequired Then
            '    .lbox2.Invoke(Sub()
            '                      For Each a As String In .lbox2.Items
            '                          get_rr_items(a)
            '                      Next
            '                  End Sub)
            'End If


        End With


    End Sub

    Public Sub get_rr_items(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With rr1
            Try

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new4", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 23)

                newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

                newDR = newCMD.ExecuteReader

                While newDR.Read

                    Dim a(3) As String
                    a(0) = newDR.Item("po_det_id").ToString
                    a(1) = newDR.Item("po_date").ToString
                    a(2) = newDR.Item("rs_no").ToString

                    Dim lvl As New ListViewItem(a)
                    If .listview.InvokeRequired Then
                        .listview.Invoke(Sub()
                                             .listview.Items.Add(lvl)
                                         End Sub)
                    Else
                        .listview.Items.Add(lvl)
                    End If


                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With
    End Sub

    Public Sub sort_listview(n As Integer)
        With rr1
            If .listview.InvokeRequired Then
                .listview.Invoke(Sub()
                                     ' If current column is not the previously clicked column
                                     ' Add
                                     If Not n = sortColumn Then

                                         ' Set the sort column to the new column
                                         sortColumn = n

                                         'Default to ascending sort order
                                         .listview.Sorting = SortOrder.Ascending

                                     Else

                                         'Flip the sort order
                                         If .listview.Sorting = SortOrder.Ascending Then
                                             .listview.Sorting = SortOrder.Descending
                                         Else
                                             .listview.Sorting = SortOrder.Ascending
                                         End If
                                     End If

                                     'Set the ListviewItemSorter property to a new ListviewItemComparer object
                                     .listview.ListViewItemSorter = New ListViewItemComparer(n, .listview.Sorting)

                                     ' Call the sort method to manually sort
                                     .listview.Sort()
                                 End Sub)
            Else
                .listview.Invoke(Sub()
                                     ' If current column is not the previously clicked column
                                     ' Add
                                     If Not n = sortColumn Then

                                         ' Set the sort column to the new column
                                         sortColumn = n

                                         'Default to ascending sort order
                                         .listview.Sorting = SortOrder.Ascending

                                     Else

                                         'Flip the sort order
                                         If .listview.Sorting = SortOrder.Ascending Then
                                             .listview.Sorting = SortOrder.Descending
                                         Else
                                             .listview.Sorting = SortOrder.Ascending
                                         End If
                                     End If

                                     'Set the ListviewItemSorter property to a new ListviewItemComparer object
                                     .listview.ListViewItemSorter = New ListViewItemComparer(n, .listview.Sorting)

                                     ' Call the sort method to manually sort
                                     .listview.Sort()
                                 End Sub)
            End If

        End With

    End Sub

    Public Sub rr_search()
        'If rr1.lbox.InvokeRequired Then
        '    rr1.lbox.Invoke(Sub()
        '                        rr1.lbox2.Items.Clear()
        '                    End Sub)
        'Else
        '    rr1.lbox2.Items.Clear()
        'End If


        store_rr_items_in_listbox()
        store_rr_items_in_listview()
        sort_listview(1)
        back_rr_items_in_listbox_final()
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        'Release an automation object
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub



End Class
