Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Class_Search_Charges
    Dim sch1 As search_charges_data
    Dim a As String
    Public specific_requestor As Boolean
    Public cDateFrom As DateTime
    Public cDateTo As DateTime

    Sub New(sch As search_charges_data)
        sch1 = sch

        a = "Type of Purchasing..."

        If sch1.type_of_purchasing = a Then
            sch1.type_of_purchasing = ""
        End If
    End Sub

    Public Structure search_charges_data

        Dim charges As String
        Dim items As String
        Dim date_from As DateTime
        Dim date_to As DateTime
        Dim lbox As ListBox
        Dim lview As ListView
        Dim progressbar As ProgressBar
        Dim searchby As String
        Dim options As String
        Dim aborted As Boolean
        Dim lbl As Label
        Dim bydaterange As Boolean

        Dim type_of_purchasing As String
        Dim typeofcharges As ComboBox
        Dim list_of_charges As ComboBox
        Dim n As Integer
    End Structure
    Public Sub load_type_of_request_to_listbox()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With sch1
            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 sch1.lbox.Items.Clear()
                                 sch1.lview.Items.Clear()
                             End Sub)
            End If

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                If .bydaterange = True Then
                    newCMD.Parameters.AddWithValue("@n", 37)
                Else
                    newCMD.Parameters.AddWithValue("@n", 38)
                End If

                newCMD.Parameters.AddWithValue("@charges", sch1.charges)
                newCMD.Parameters.AddWithValue("@items", sch1.items)
                newCMD.Parameters.AddWithValue("@date_from", sch1.date_from)
                newCMD.Parameters.AddWithValue("@date_to", sch1.date_to)
                newCMD.Parameters.AddWithValue("@type_of_purchasing", sch1.type_of_purchasing)

                newCMD.CommandTimeout = 100

                newDR = newCMD.ExecuteReader
                Dim a(10) As String

                While newDR.Read
                    If .lbox.InvokeRequired Then
                        .lbox.Invoke(Sub()
                                         .lbox.Items.Add(newDR.Item("rs_id").ToString)
                                     End Sub)
                    End If
                End While

            Catch ex As Exception
                If charges_abort = True Then
                    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    charges_abort = False

                    If sch1.lbl.InvokeRequired Then
                        sch1.lbl.Invoke(Sub()
                                            sch1.lbl.Visible = False
                                        End Sub)
                    Else
                        sch1.lbl.Visible = False
                    End If
                    Exit Sub
                End If

                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End With

    End Sub

    Public Sub load_charges_to_listbox()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With sch1
            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 sch1.lbox.Items.Clear()
                                 sch1.lview.Items.Clear()
                             End Sub)
            End If

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                If .bydaterange = True Then
                    If specific_requestor = True Then
                        newCMD.Parameters.AddWithValue("@n", 312)
                    Else
                        newCMD.Parameters.AddWithValue("@n", 29) '15
                    End If
                Else
                    newCMD.Parameters.AddWithValue("@n", 31) '15
                End If


                newCMD.Parameters.AddWithValue("@charges", sch1.charges)
                newCMD.Parameters.AddWithValue("@items", sch1.items)
                newCMD.Parameters.AddWithValue("@date_from", sch1.date_from)
                newCMD.Parameters.AddWithValue("@date_to", sch1.date_to)

                newCMD.CommandTimeout = 100

                newDR = newCMD.ExecuteReader
                Dim a(10) As String

                While newDR.Read
                    If .lbox.InvokeRequired Then
                        .lbox.Invoke(Sub()
                                         .lbox.Items.Add(newDR.Item("rs_id").ToString)
                                     End Sub)
                    End If
                End While

            Catch ex As Exception
                If charges_abort = True Then
                    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    charges_abort = False

                    If sch1.lbl.InvokeRequired Then
                        sch1.lbl.Invoke(Sub()
                                            sch1.lbl.Visible = False
                                        End Sub)
                    Else
                        sch1.lbl.Visible = False
                    End If
                    Exit Sub
                End If

                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End With

    End Sub
    Public Sub load_charges_to_listbox_hauling()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With sch1
            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 sch1.lbox.Items.Clear()
                                 sch1.lview.Items.Clear()
                             End Sub)
            End If

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure


                If .bydaterange = True Then
                    newCMD.Parameters.AddWithValue("@n", 30) '15
                Else
                    newCMD.Parameters.AddWithValue("@n", 33) '15
                End If

                newCMD.Parameters.AddWithValue("@charges", sch1.charges)
                newCMD.Parameters.AddWithValue("@items", sch1.items)
                newCMD.Parameters.AddWithValue("@date_from", sch1.date_from)
                newCMD.Parameters.AddWithValue("@date_to", sch1.date_to)

                newCMD.CommandTimeout = 100

                newDR = newCMD.ExecuteReader
                Dim a(10) As String

                While newDR.Read
                    If .lbox.InvokeRequired Then
                        .lbox.Invoke(Sub()
                                         .lbox.Items.Add(newDR.Item("rs_id").ToString)
                                     End Sub)
                    End If
                End While

            Catch ex As Exception
                If charges_abort = True Then
                    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    charges_abort = False

                    If sch1.lbl.InvokeRequired Then
                        sch1.lbl.Invoke(Sub()
                                            sch1.lbl.Visible = False
                                        End Sub)
                    Else
                        sch1.lbl.Visible = False
                    End If
                    Exit Sub
                End If

                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End With

    End Sub
    Public Sub load_charges()
        Dim rs_percent As Integer

        Dim rs_id_count As Integer
        For i = 0 To sch1.lbox.Items.Count - 1
            rs_id_count += 1
        Next

        Dim progbar As ProgressBar
        progbar = sch1.progressbar

        rs_percent = 1

        With sch1
            If progbar.InvokeRequired Then
                progbar.Invoke(Sub()
                                   progbar.Value = 0
                                   'ProgressBar1.Maximum = (rs_percent * 100)
                                   progbar.Maximum = rs_id_count
                               End Sub)

            Else
                progbar.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                progbar.Maximum = rs_id_count
            End If


            For i = 0 To sch1.lbox.Items.Count - 1
                load_the_charges(sch1.lbox.Items(i))

                If progbar.InvokeRequired Then
                    progbar.Invoke(Sub()
                                       If progbar.Value = rs_id_count Then ' 100 Then
                                       Else
                                           progbar.Value += CDbl(rs_percent)
                                       End If
                                   End Sub)
                Else
                    progbar.Value += CDbl(rs_percent)
                End If
            Next

            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 .lbox.Items.Clear()
                                 progbar.Value = 0
                             End Sub)
            Else
                .lbox.Items.Clear()
                progbar.Value = 0
            End If

        End With
    End Sub
    Private Sub load_the_charges(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With sch1

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 16)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)

                newCMD.CommandTimeout = 100

                newDR = newCMD.ExecuteReader
                Dim a(10) As String

                While newDR.Read
                    a(0) = newDR.Item("rs_no").ToString
                    a(1) = newDR.Item("item_desc_from_warehouse").ToString
                    a(2) = Date.Parse(newDR.Item("date_req").ToString)
                    a(3) = newDR.Item("wh_id").ToString
                    a(4) = newDR.Item("rs_id").ToString
                    a(6) = newDR.Item("item_desc_from_rs").ToString
                    a(8) = newDR.Item("type_of_purchasing").ToString

                    Dim lvl As New ListViewItem(a)

                    If .lview.InvokeRequired Then
                        .lview.Invoke(Sub() .lview.Items.Add(lvl))
                    Else
                        .lview.Items.Add(lvl)
                    End If

                End While

            Catch ex As Exception

                If charges_abort = True Then
                    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    charges_abort = False

                    If sch1.lbl.InvokeRequired Then
                        sch1.lbl.Invoke(Sub()
                                            sch1.lbl.Visible = False
                                        End Sub)
                    Else
                        sch1.lbl.Visible = False
                    End If

                    Exit Sub
                End If

                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End With
    End Sub

    Public Sub load_the_charges_hauling()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With sch1
            .lview.Items.Clear()

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                'newCMD.Parameters.AddWithValue("@n", 2)
                newCMD.Parameters.AddWithValue("@n", 22)

                If .searchby = "Search by Requested by" Then
                    'newCMD.Parameters.AddWithValue("@search_charges", IIf(search_charges = "Requested By...", "", search_charges))

                ElseIf .searchby = "Search by Charges" Then
                    'newCMD.Parameters.AddWithValue("@search_charges", IIf(search_charges = "Charges...", "", search_charges))
                    newCMD.Parameters.AddWithValue("@search_charges", .charges)
                    MsgBox(.charges & vbCrLf & .items & vbCrLf & .searchby)
                ElseIf FRequistionForm.cmbSearchByCategory.Text = "Search by User Name" Then
                    'newCMD.Parameters.AddWithValue("@search_charges", search_charges)
                End If

                'If item_name = "Items..." Then
                '    item_name = ""
                'End If

                newCMD.Parameters.AddWithValue("@iem_desc", .items)
                newCMD.Parameters.AddWithValue("@searchby", .searchby)
                newCMD.CommandTimeout = 300

                newDR = newCMD.ExecuteReader
                Dim a(10) As String

                While newDR.Read

                    a(0) = newDR.Item("rs_no").ToString
                    If newDR.Item("wh_id").ToString = 0 Then
                        a(1) = newDR.Item("items").ToString
                    Else
                        a(1) = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                    End If

                    a(2) = Format(Date.Parse(newDR.Item("rs_date").ToString), "MM/dd/yyyy")
                    a(3) = newDR.Item("wh_id").ToString
                    a(4) = newDR.Item("rs_id").ToString
                    a(6) = newDR.Item("items").ToString

                    Dim lvl As New ListViewItem(a)
                    If .lview.InvokeRequired Then
                        .lview.Invoke(Sub() .lview.Items.Add(lvl))
                    Else
                        .lview.Items.Add(lvl)
                    End If

                End While

            Catch ex As Exception
                If charges_abort = True Then
                    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    charges_abort = False

                    If sch1.lbl.InvokeRequired Then
                        sch1.lbl.Invoke(Sub()
                                            sch1.lbl.Visible = False
                                        End Sub)
                    Else
                        sch1.lbl.Visible = False
                    End If
                    Exit Sub
                End If

                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try


        End With
    End Sub

    Public Sub load_type_of_charges()
        Dim rs_percent As Integer

        Dim rs_id_count As Integer
        For i = 0 To sch1.lbox.Items.Count - 1
            rs_id_count += 1
        Next

        Dim progbar As ProgressBar
        progbar = sch1.progressbar

        rs_percent = 1

        With sch1
            If progbar.InvokeRequired Then
                progbar.Invoke(Sub()
                                   progbar.Value = 0
                                   'ProgressBar1.Maximum = (rs_percent * 100)
                                   progbar.Maximum = rs_id_count
                               End Sub)

            Else
                progbar.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                progbar.Maximum = rs_id_count
            End If


            For i = 0 To sch1.lbox.Items.Count - 1
                load_the_charges(sch1.lbox.Items(i))

                If progbar.InvokeRequired Then
                    progbar.Invoke(Sub()
                                       If progbar.Value = rs_id_count Then ' 100 Then
                                       Else
                                           progbar.Value += CDbl(rs_percent)
                                       End If
                                   End Sub)
                Else
                    progbar.Value += CDbl(rs_percent)
                End If
            Next

            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 .lbox.Items.Clear()
                                 progbar.Value = 0
                             End Sub)
            Else
                .lbox.Items.Clear()
                progbar.Value = 0
            End If

        End With
    End Sub


    Public Sub select_type_of_charges()

        With sch1
            If .typeofcharges.Text = "EQUIPMENT" Then
                charge_to(2)
            ElseIf .typeofcharges.Text = "PROJECT" Then
                charge_to(1)
            ElseIf .typeofcharges.Text = "WAREHOUSE" Then
                charge_to(6)
            Else
                charge_to(3)
            End If
        End With

    End Sub
    Private Sub charge_to(n As Integer)
        With sch1
            .list_of_charges.Items.Clear()

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("sp_charges_to", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@type_name", .typeofcharges.Text)

                newDR = newCMD.ExecuteReader

                While newDR.Read
                    If n = 1 Then
                        .list_of_charges.Items.Add(newDR.Item("project_desc").ToString)
                    ElseIf n = 2 Then
                        .list_of_charges.Items.Add(newDR.Item("plate_no").ToString)
                    ElseIf n = 3 Then
                        .list_of_charges.Items.Add(newDR.Item("charge_to").ToString)
                    ElseIf n = 6 Then
                        .list_of_charges.Items.Add(newDR.Item("wh_area").ToString)
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End With

    End Sub

    Public Sub ws_charges()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With sch1
            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 sch1.lbox.Items.Clear()
                                 sch1.lview.Items.Clear()
                             End Sub)
            End If

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                If .bydaterange = True Then
                    newCMD.Parameters.AddWithValue("@n", 34)
                Else
                    newCMD.Parameters.AddWithValue("@n", 36)
                End If

                newCMD.Parameters.AddWithValue("@charges", sch1.charges)
                newCMD.Parameters.AddWithValue("@items", sch1.items)
                newCMD.Parameters.AddWithValue("@date_from", sch1.date_from)
                newCMD.Parameters.AddWithValue("@date_to", sch1.date_to)

                newCMD.CommandTimeout = 100

                newDR = newCMD.ExecuteReader
                Dim a(10) As String

                While newDR.Read
                    If .lbox.InvokeRequired Then
                        .lbox.Invoke(Sub()
                                         .lbox.Items.Add(newDR.Item("ws_id").ToString)
                                     End Sub)
                    End If
                End While

            Catch ex As Exception
                If charges_abort = True Then
                    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    charges_abort = False

                    If sch1.lbl.InvokeRequired Then
                        sch1.lbl.Invoke(Sub()
                                            sch1.lbl.Visible = False
                                        End Sub)
                    Else
                        sch1.lbl.Visible = False
                    End If
                    Exit Sub
                End If

                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Sub
    Public Sub load_charges_ws()
        Dim rs_percent As Integer

        Dim rs_id_count As Integer
        For i = 0 To sch1.lbox.Items.Count - 1
            rs_id_count += 1
        Next

        Dim progbar As ProgressBar
        progbar = sch1.progressbar

        rs_percent = 1

        With sch1
            If progbar.InvokeRequired Then
                progbar.Invoke(Sub()
                                   progbar.Value = 0
                                   'ProgressBar1.Maximum = (rs_percent * 100)
                                   progbar.Maximum = rs_id_count
                               End Sub)

            Else
                progbar.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                progbar.Maximum = rs_id_count
            End If


            For i = 0 To sch1.lbox.Items.Count - 1
                load_the_charges_ws(sch1.lbox.Items(i))

                If progbar.InvokeRequired Then
                    progbar.Invoke(Sub()
                                       If progbar.Value = rs_id_count Then ' 100 Then
                                       Else
                                           progbar.Value += CDbl(rs_percent)
                                       End If
                                   End Sub)
                Else
                    progbar.Value += CDbl(rs_percent)
                End If
            Next

            If .lbox.InvokeRequired Then
                .lbox.Invoke(Sub()
                                 .lbox.Items.Clear()
                                 progbar.Value = 0
                             End Sub)
            Else
                .lbox.Items.Clear()
                progbar.Value = 0
            End If

        End With
    End Sub

    Private Sub load_the_charges_ws(ws_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With sch1

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_temp_proc_requisition_slip_search2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 35)
                newCMD.Parameters.AddWithValue("@ws_id", ws_id)

                newCMD.CommandTimeout = 100

                newDR = newCMD.ExecuteReader
                Dim a(10) As String

                While newDR.Read

                    a(0) = newDR.Item("ws_no").ToString
                    a(1) = newDR.Item("wh_item_from_ws").ToString
                    a(2) = Date.Parse(newDR.Item("ws_date").ToString)
                    a(3) = newDR.Item("wh_id").ToString
                    a(4) = newDR.Item("ws_id").ToString
                    a(6) = newDR.Item("wh_item_from_rs").ToString

                    Dim lvl As New ListViewItem(a)

                    If .lview.InvokeRequired Then
                        .lview.Invoke(Sub() .lview.Items.Add(lvl))
                    Else
                        .lview.Items.Add(lvl)
                    End If

                End While

            Catch ex As Exception

                If charges_abort = True Then
                    MessageBox.Show("Process has been aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    charges_abort = False

                    If sch1.lbl.InvokeRequired Then
                        sch1.lbl.Invoke(Sub()
                                            sch1.lbl.Visible = False
                                        End Sub)
                    Else
                        sch1.lbl.Visible = False
                    End If

                    Exit Sub
                End If

                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

        End With
    End Sub
End Class
