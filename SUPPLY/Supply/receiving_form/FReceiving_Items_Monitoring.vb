Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FReceiving_Items_Monitoring
    Private Sub FReceiving_Items_Monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_rr_info()
    End Sub

    Public Sub load_rr_info()
        ListView1.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim a(10) As String
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                a(0) = newDR.Item("rr_info_id").ToString
                a(1) = newDR.Item("po_no").ToString
                a(2) = newDR.Item("received_by").ToString
                a(3) = ""

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        With FReceiving_Info

            edit_receiving_info(CInt(ListView1.SelectedItems(0).Text))
            .btnReceive.Text = "Update"
            .ShowDialog()

        End With
    End Sub
    Public Sub edit_receiving_info(rr_info_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With FReceiving_Info
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 12)
                newCMD.Parameters.AddWithValue("@rr_info_id", rr_info_id)

                newDR = newCMD.ExecuteReader

                While newDR.Read
                    .cmbSupplier.Text = newDR.Item("Supplier_Name").ToString
                    .txtInvoiceNo.Text = newDR.Item("invoice_no").ToString
                    .txtPOno.Text = newDR.Item("po_no").ToString
                    .cmbPoNo.Items.Add(.txtPOno.Text)
                    .cmbPoNo.Text = .txtPOno.Text
                    .txtRSNo.Text = newDR.Item("rs_no").ToString
                    .txtSOno.Text = newDR.Item("so_no").ToString
                    .txtHauler.Text = newDR.Item("hauler").ToString
                    .txtRRno.Text = newDR.Item("rr_no").ToString
                    .DTPReceived.Text = Date.Parse(newDR.Item("date_received").ToString)
                    .txtReceivedby.Text = newDR.Item("received_by").ToString
                    .txtCheckedby.Text = newDR.Item("checked_by").ToString
                    .txtPlateNo.Text = newDR.Item("plateno").ToString
                End While
                newDR.Close()


            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With



    End Sub

    Private Sub EditReceivedItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditReceivedItemsToolStripMenuItem.Click
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim c As Integer = 0
        Dim rr_info_id As Integer = CInt(ListView1.SelectedItems(0).Text)
        Dim po_no As String = ListView1.SelectedItems(0).SubItems(1).Text

        Try

            With FReceiving_Items
                .DataGridView1.Rows.Clear()

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 2)
                newCMD.Parameters.AddWithValue("@rr_info_id", rr_info_id)
                newCMD.Parameters.AddWithValue("@po_no", po_no)
                newDR = newCMD.ExecuteReader

                While newDR.Read

                    Dim row(10) As String

                    row(0) = "> " & newDR.Item("whItem").ToString
                    row(1) = "-" 'CInt(newDR.Item("qty").ToString)
                    row(2) = newDR.Item("unit").ToString
                    row(5) = newDR.Item("po_det_id").ToString
                    row(6) = newDR.Item("rr_item_id").ToString
                    row(7) = CDec(CDec(newDR.Item("qty").ToString)) - CDec(newDR.Item("desired_qty").ToString)
                    row(8) = newDR.Item("desired_qty").ToString

                    .DataGridView1.Rows.Add(row)

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(c).DefaultCellStyle.ForeColor = Color.White
                    .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    set_cell_readonly(c, True)
                    .DataGridView1.Rows(c).Cells(4).ReadOnly = False
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

                    Dim gridComboBox1 As New DataGridViewComboBoxCell
                    gridComboBox1.Items.Add("Include")
                    gridComboBox1.Items.Add("Pending")
                    .DataGridView1.Item(4, c) = gridComboBox1

                    .DataGridView1.Item(4, c).Value = newDR.Item("selected").ToString
                    Dim sub_items_count As Integer = load_sub_items(CInt(newDR.Item("rr_item_id").ToString), c)

                    c += sub_items_count
                    c += 1
                End While
                newDR.Close()

                .Button2.Text = "Update"

                .DataGridView1.Columns("col_desired_qty").Visible = False

                .ShowDialog()

            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function load_sub_items(rr_item_id As Integer, c As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim n As Integer = 0
        Dim totalqty As Double
        Dim totalprice As Double
        Dim total_rr_item_id As Integer
        Dim t(10) As String
        With FReceiving_Items
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 3)
                newCMD.Parameters.AddWithValue("@rr_item_id", rr_item_id)

                newDR = newCMD.ExecuteReader

                While newDR.Read
                    Dim a(10) As String

                    a(0) = newDR.Item("item_desc").ToString
                    a(1) = newDR.Item("qty").ToString
                    a(2) = newDR.Item("unit").ToString
                    a(3) = CDec(check_if_numeric(newDR.Item("amount").ToString))
                    a(5) = newDR.Item("rr_item_sub_id").ToString
                    a(6) = newDR.Item("rr_item_id").ToString
                    a(8) = "-"

                    .DataGridView1.Rows.Add(a)
                    n += 1

                    .DataGridView1.Rows(c + n).DefaultCellStyle.BackColor = Color.LightGreen
                    .DataGridView1.Rows(c + n).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c + n).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(c + n).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c + n).Cells("col_desired_qty").ReadOnly = True

                    Dim gridComboBox11 As New DataGridViewComboBoxCell
                    gridComboBox11.Items.Add("Include")
                    gridComboBox11.Items.Add("Pending")
                    gridComboBox11.Items.Add("Fixed")

                    .DataGridView1.Item(4, c + n) = gridComboBox11
                    .DataGridView1.Item(4, c + n).Value = newDR.Item("selected").ToString
                    .DataGridView1.Item(4, c + n).ReadOnly = True

                    If newDR.Item("selected").ToString = "Include" Then
                        totalqty += CInt(a(1))
                        totalprice += CDec(a(3)) * CDec(newDR.Item("qty").ToString)
                        total_rr_item_id = newDR.Item("rr_item_id").ToString
                    End If
                End While

                newDR.Close()

                load_sub_items = n

                t(0) = "TOTAL"
                t(1) = totalqty
                t(2) = ""
                t(3) = FormatNumber(totalprice, 2,,, TriState.True)
                t(5) = ""
                t(6) = total_rr_item_id

                .DataGridView1.Rows.Add(t)

                set_cell_readonly(c + n + 1, True)
                .DataGridView1.Rows(c + n + 1).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                load_sub_items += 1

                Return load_sub_items
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Function

    Public Sub set_cell_readonly(n As Integer, enable As Boolean)
        For i = 0 To 6
            FReceiving_Items.DataGridView1.Rows(n).Cells(i).ReadOnly = enable
        Next
    End Sub
End Class