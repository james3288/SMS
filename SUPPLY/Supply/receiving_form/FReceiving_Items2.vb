Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FReceiving_Items2
    Dim old_input_qty As Decimal
    Private WithEvents CurrentEditControl As Control = Nothing
    Public date_submitted As DateTime
    Private Sub FReceiving_Items2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i = 0 To 9
            Me.DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.DataGridView1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Next

        For i = 0 To DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(i).Height = 30
        Next
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        CurrentEditControl = Nothing
        Dim grand_total As Decimal

        If DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.DarkGreen Then
            Dim qty_to_be_received As Decimal
            Dim input_qty As Decimal
            Dim total_qty_received As Decimal

            qty_to_be_received = IIf(IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(2).Value) = True, DataGridView1.Rows(e.RowIndex).Cells(2).Value, 0)
            input_qty = IIf(IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(3).Value) = True, DataGridView1.Rows(e.RowIndex).Cells(3).Value, 0)
            total_qty_received = IIf(IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(4).Value) = True, DataGridView1.Rows(e.RowIndex).Cells(4).Value, 0)


            If IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(3).Value) = False Then
                MessageBox.Show("must be numeric..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                DataGridView1.Rows(e.RowIndex).Cells(3).Value = 1
                Exit Sub
            End If

            If crusher_receiving = 0 Then

                If input_qty > (qty_to_be_received - total_qty_received) Then
                    MessageBox.Show("Input qty must not greather than qty to be received..thanks", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    DataGridView1.Rows(e.RowIndex).Cells(3).Value = 0
                    Exit Sub
                End If

            ElseIf crusher_receiving = 1 Then

                If input_qty > qty_to_be_received Then
                    MessageBox.Show("Input qty must not greather than qty to be received..thanks", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    DataGridView1.Rows(e.RowIndex).Cells(3).Value = 0
                    Exit Sub
                End If

            End If


        ElseIf DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen Then

            If IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(2).Value) = False Then
                MessageBox.Show("must be numeric..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                DataGridView1.Rows(e.RowIndex).Cells(2).Value = 1
                Exit Sub
            End If


            Dim price As Decimal = IIf(IsNumeric(DataGridView1.Rows(e.RowIndex).Cells("col_price").Value), DataGridView1.Rows(e.RowIndex).Cells("col_price").Value, 0)

            'DataGridView1.Rows(e.RowIndex).Cells("col_price").Value = FormatNumber(price, 2,,, TriState.True)
            DataGridView1.Rows(e.RowIndex).Cells("col_price").Value = price.ToString("G17", CultureInfo.InvariantCulture)

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.DefaultCellStyle.BackColor = Color.LightGreen Then
                    grand_total += (CDec(row.Cells("col_price").Value) * CDec(row.Cells("col_po_qty").Value))

                ElseIf row.DefaultCellStyle.BackColor = Color.Orange Then
                    row.Cells("col_price").Value = FormatNumber(grand_total, 2,,, TriState.True)
                End If
            Next

        End If

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'Dim get_rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text

        If btnSave.Text = "Save" Then

            If MessageBox.Show("Are you sure you want to save this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim include As Boolean = False

                Dim row_number As Integer = 0
                Dim get_rr_info_id As Integer = save_rr_info()
                Dim get_rr_items_id As Integer

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.DefaultCellStyle.BackColor = Color.DarkGreen Then
                        include = False 'set as default false 
                        row_number = row.Cells("col_number").Value

                        If row.Cells("col_selection").Value = "Include" Then
                            include = True
                            'insert to rr_info and rr_items and get the rr_items_id
                            get_rr_items_id = save_rr_items(get_rr_info_id, row.Cells("col_po_qty").Value, row.Cells("col_sub_item_desc").Value, row.Cells("col_selection").Value, row.Cells("col_rs_id").Value)

                            'insert pd ang partial
                            save_rr_partial(get_rr_items_id, row.Cells("col_desired_qty").Value)
                        End If
                    End If

                    If row.DefaultCellStyle.BackColor = Color.LightGreen Then
                        If row_number = row.Cells("col_number").Value Then
                            'aya ra mo insert sa rr_items_sub  
                            If include = True Then
                                'insert rr_items_sub 
                                save_rr_items_sub(get_rr_items_id, row.Cells("col_sub_item_desc").Value, row.Cells("col_po_qty").Value, row.Cells("col_price").Value, row.Cells("col_unit").Value, "Include", 4)
                            Else
                                'walay mahitabo
                            End If
                        End If
                    End If

                Next

                MessageBox.Show("RR Successfully Saved..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Dispose()
                FReceiving_Info.Dispose()

                FRequistionForm.btnSearch.PerformClick()
            End If
        Else

            If MessageBox.Show("Are you sure you want to update this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.DefaultCellStyle.BackColor = Color.LightGreen Then
                        'update rr_item_sub
                        'MsgBox(row.Cells("col_rr_item_id").Value)
                        save_rr_items_sub(row.Cells("col_rr_item_id").Value, row.Cells("col_sub_item_desc").Value, row.Cells("col_po_qty").Value, row.Cells("col_price").Value, row.Cells("col_unit").Value, "Include", 5)
                    End If
                Next

                MessageBox.Show("RR Successfully Updated..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()
                FReceivingReportList.btnSearch.PerformClick()
            End If

        End If

    End Sub
    Private Sub save_rr_items_sub(rr_item_id As Integer, item_desc As String, qty As Decimal, amount As Decimal, unit As String, selected As String, n As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new5", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            If n = 4 Then
                newCMD.Parameters.AddWithValue("@rr_items_id", rr_item_id)
            ElseIf n = 5 Then
                newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_id)
            End If

            newCMD.Parameters.AddWithValue("@item_description", item_desc)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@amount", amount)
            newCMD.Parameters.AddWithValue("@unit", unit)
            newCMD.Parameters.AddWithValue("@selected", selected)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub save_rr_partial(rr_item_id As Integer, desired_qty As Decimal)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new5", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@rr_items_id", rr_item_id)
            newCMD.Parameters.AddWithValue("@desired_qty", desired_qty)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Function save_rr_items(rr_info_id As Integer, qty As Decimal, item_desc As String, selected As String, get_rs_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Dim po_det_id As Integer

        If crusher_receiving = 1 Then
            po_det_id = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(35).Text
        End If

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new5", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@rr_info_id", rr_info_id)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@item_description", item_desc)
            newCMD.Parameters.AddWithValue("@rs_id", get_rs_id)
            newCMD.Parameters.AddWithValue("@selected", selected)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

            save_rr_items = newCMD.ExecuteScalar

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Function save_rr_info() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        With FReceiving_Info

            Dim rr_no As String = .txtRRno.Text
            Dim invoice_no As String = .txtInvoiceNo.Text
            Dim supplier As String = .cmbSupplier.Text
            Dim rs_no As String = .txtRSNo.Text
            Dim date_received As DateTime = Date.Parse(.DTPReceived.Text)
            Dim received_by As String = .txtReceivedby.Text
            Dim checked_by As String = .txtCheckedby.Text
            Dim hauler As String = .txtHauler.Text
            Dim plateno As String = .txtPlateNo.Text
            Dim operator_name As String = .cmbOperator.Text
            Dim date_log As DateTime = Format(Date.Parse(Now), "yyyy-MM-dd HH:mm:ss")
            Dim user_id As Integer = user_id

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new5", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 1)
                newCMD.Parameters.AddWithValue("@rr_no", rr_no)
                newCMD.Parameters.AddWithValue("@invoice_no", invoice_no)
                newCMD.Parameters.AddWithValue("@supplier", supplier)
                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.Parameters.AddWithValue("@date_received", date_received)
                newCMD.Parameters.AddWithValue("@received_by", received_by)
                newCMD.Parameters.AddWithValue("@checked_by", checked_by)
                newCMD.Parameters.AddWithValue("@hauler", hauler)
                newCMD.Parameters.AddWithValue("@plateno", plateno)
                newCMD.Parameters.AddWithValue("@operator_name", operator_name)
                newCMD.Parameters.AddWithValue("@date_log", date_log)
                newCMD.Parameters.AddWithValue("@user_id", pub_user_id)
                newCMD.Parameters.AddWithValue("@date_submitted", FReceiving_Info.date_submitted)

                save_rr_info = newCMD.ExecuteScalar

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With
    End Function


    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.CurrentCell IsNot Nothing Then
            If e.RowIndex = DataGridView1.CurrentCell.RowIndex And e.ColumnIndex = DataGridView1.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.SteelBlue
                e.CellStyle.SelectionForeColor = Color.White
            Else
                e.CellStyle.SelectionBackColor = DataGridView1.DefaultCellStyle.SelectionBackColor

            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False Then
                DataGridView1.ClearSelection()
                DataGridView1.CurrentCell = DataGridView1.Item(e.ColumnIndex, e.RowIndex)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then

            CurrentEditControl = e.Control

        End If
    End Sub

    Public Sub EditControl_KeyDown(ByVal sender As Object, ByVal e As EventArgs) Handles CurrentEditControl.TextChanged
        Dim price As Decimal

        If CurrentEditControl.Text = "Pending" Then
            Dim row_number As Integer = DataGridView1.SelectedRows(0).Cells(12).Value

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.DefaultCellStyle.BackColor = Color.LightGreen Then
                    Dim row_number1 As Integer = row.Cells(12).Value

                    If row_number = row_number1 Then
                        row.Cells("col_price").Value = FormatNumber(0, 2,,, TriState.True)
                        row.Cells("col_sub_item_desc").ReadOnly = True
                        row.Cells("col_po_qty").ReadOnly = True
                        row.Cells("col_unit").ReadOnly = True
                        row.Cells("col_price").ReadOnly = True
                        row.Cells("col_qty_received").ReadOnly = True
                        row.Cells("col_po_det_id").ReadOnly = True
                        row.Cells("col_rr_item_id").ReadOnly = True
                        row.Cells("col_rs_id").ReadOnly = True
                    Else
                        price += row.Cells("col_price").Value
                    End If

                ElseIf row.DefaultCellStyle.BackColor = Color.Orange Then
                    row.Cells("col_price").Value = FormatNumber(price, 2,,, TriState.True)
                End If
            Next

        ElseIf CurrentEditControl.Text = "Include" Then
            Dim row_number As Integer = DataGridView1.SelectedRows(0).Cells(12).Value

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.DefaultCellStyle.BackColor = Color.LightGreen Then
                    Dim row_number1 As Integer = row.Cells(12).Value

                    If row_number = row_number1 Then

                        row.Cells("col_sub_item_desc").ReadOnly = False
                        row.Cells("col_po_qty").ReadOnly = False
                        row.Cells("col_unit").ReadOnly = False
                        row.Cells("col_price").ReadOnly = False
                        row.Cells("col_qty_received").ReadOnly = True
                        row.Cells("col_po_det_id").ReadOnly = True
                        row.Cells("col_rr_item_id").ReadOnly = True
                        row.Cells("col_rs_id").ReadOnly = True
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub FReceiving_Items2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        crusher_receiving = 0
    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub


End Class