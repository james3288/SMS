Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FReceiving_Find_Related_Item
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbSearchby.Text = "Search By Item Name" Then
            'search_item_from_warehouse(txtSearch.Text, 2)
            search_item_from_wh(txtSearch.Text, 2)
        ElseIf cmbSearchby.Text = "Search By Item Desc." Then
            'search_item_from_warehouse(txtSearch.Text, 4)
            search_item_from_wh(txtSearch.Text, 4)
        End If
    End Sub

    Public Sub search_item_from_wh(ByVal val As String, ByVal n As Integer)
        lvl_whitems.Items.Clear()

        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            SQ.connection.Open()

            cmd = New SqlCommand("proc_get_data_from_warehouse", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@search", val)
            cmd.Parameters.AddWithValue("@n", n)

            dr = cmd.ExecuteReader
            Dim a(20) As String

            While dr.Read

                a(0) = dr.Item("wh_id").ToString
                a(1) = dr.Item("whItem").ToString
                a(2) = dr.Item("whItemDesc").ToString

                Dim lvl As New ListViewItem(a)
                lvl_whitems.Items.Add(lvl)

            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub lvl_whitems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvl_whitems.SelectedIndexChanged

    End Sub

    Private Sub lvl_whitems_DoubleClick(sender As Object, e As EventArgs) Handles lvl_whitems.DoubleClick
        With FReceiving_Items
            If MessageBox.Show("Are you sure you want to overwrite '" & .DataGridView1.SelectedCells(0).Value & "' to " & lvl_whitems.SelectedItems(0).SubItems(1).Text & " - " & lvl_whitems.SelectedItems(0).SubItems(2).Text, "SUPPLY INFO: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim rs_id As Integer = CInt(.DataGridView1.SelectedCells(9).Value)
                Dim wh_id As Integer = lvl_whitems.SelectedItems(0).Text
                Dim item_name As String = lvl_whitems.SelectedItems(0).SubItems(1).Text
                Dim item_desc As String = lvl_whitems.SelectedItems(0).SubItems(2).Text

                Dim query1 As String = "UPDATE dbrequisition_slip SET wh_id = " & wh_id & " WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")

                Dim query As String = "UPDATE dbPO_details SET wh_id = " & wh_id & " WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

                FReceiving_Items.DataGridView1.SelectedRows(0).Cells("col_sub_item_desc").Value = "> " & item_name & "(" & item_desc & ")"

                Dim rowindex As Integer = FReceiving_Items.DataGridView1.SelectedRows(0).Index + 1
                FReceiving_Items.DataGridView1.Rows(rowindex).Cells("col_sub_item_desc").Value = item_name & " " & item_desc

                'released_po(FReceiving_Info.txtRSNo.Text, FReceiving_Info.txtPOno.Text)

                Me.Close()
                'FReceiving_Info.btnReceive.PerformClick()

            End If
        End With

    End Sub

    Public Sub released_po(ByVal rs_no As String, ByVal po_no As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim c As Integer = 0
        Dim t(10) As String
        Try

            With FReceiving_Items
                .DataGridView1.Rows.Clear()

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_receiving_crud_new1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 1)
                newCMD.Parameters.AddWithValue("@rs_no", rs_no)
                newCMD.Parameters.AddWithValue("@po_no", po_no)
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    'FReceiving_Items.cmbItemName.Items.Add(newDR.Item("po_det_id").ToString & "-" & newDR.Item("whItem").ToString & "(" & (newDR.Item("whItemDesc").ToString) & ")")
                    Dim row(20) As String

                    If check_if_exist("dbreceiving_items", "po_det_id", CInt(newDR.Item("po_det_id").ToString), 1) > 0 Then

                        row(0) = "> " & newDR.Item("whItem").ToString & "(" & newDR.Item("whItemDesc").ToString & ")"
                        row(1) = CDec(newDR.Item("qty").ToString) - FReceiving_Info.get_remaining_qty(1, CInt(newDR.Item("po_det_id").ToString))
                        row(2) = newDR.Item("unit").ToString
                        ' row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = 0
                        row(8) = FReceiving_Info.get_remaining_qty(1, CInt(row(5)))
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    Else

                        row(0) = "> " & newDR.Item("whItem").ToString & "(" & newDR.Item("whItemDesc").ToString & ")"
                        row(1) = newDR.Item("qty").ToString
                        row(2) = "-" 'newDR.Item("unit").ToString
                        '  row(3) = "-"
                        row(5) = newDR.Item("po_det_id").ToString
                        row(6) = c
                        row(7) = newDR.Item("qty").ToString
                        row(8) = 0
                        row(9) = newDR.Item("rs_id").ToString
                        row(10) = newDR.Item("main_sub").ToString
                        row(11) = newDR.Item("rs_no").ToString

                    End If

                    If row(1) = 0 Then
                        GoTo proceedhere
                    End If

                    .DataGridView1.Rows.Add(row)

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.DarkGreen
                    .DataGridView1.Rows(c).DefaultCellStyle.ForeColor = Color.White

                    .DataGridView1.Rows(c).Cells("col_sub_item_desc").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_unit").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_price").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rs_id").ReadOnly = True

                    Dim gridComboBox1 As New DataGridViewComboBoxCell
                    gridComboBox1.Items.Add("Include") 'Populate the Combobox
                    gridComboBox1.Items.Add("Pending") 'Populate the Combobox
                    .DataGridView1.Item(4, c) = gridComboBox1

                    .DataGridView1.Item(4, c).Value = "Include"

                    Dim a(10) As String

                    a(0) = newDR.Item("whItem").ToString & " " & newDR.Item("whItemDesc").ToString
                    a(1) = 1
                    a(2) = row(2)
                    a(3) = FormatNumber(0, 2, , , TriState.True)
                    a(4) = "-"
                    a(5) = "-"
                    a(6) = c
                    a(7) = "-"
                    a(8) = "-"


                    .DataGridView1.Rows.Add(a)
                    c += 1

                    .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.LightGreen

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_po_det_id").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_rr_item_id").ReadOnly = True

                    'Dim gridComboBox11 As New DataGridViewComboBoxCell
                    'gridComboBox11.Items.Add("Include")
                    'gridComboBox11.Items.Add("Exclude")
                    'gridComboBox11.Items.Add("Fixed")
                    '.DataGridView1.Item(4, c) = gridComboBox11
                    .DataGridView1.Item(4, c).Value = "Include"

                    c += 1

                    t(0) = "TOTAL"
                    t(1) = 0
                    t(2) = "-"
                    t(3) = FormatNumber(0, 2, , , TriState.True)
                    t(4) = "-"
                    t(5) = "-"
                    t(6) = row(6)
                    t(7) = "-"
                    t(8) = "-"

                    .DataGridView1.Rows.Add(t)

                    FReceiving_Items_Monitoring.set_cell_readonly(c, True)
                    .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Italic)

                    .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                    .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

                    c += 1
proceedhere:

                End While
                newDR.Close()

                .DataGridView1.Columns("col_desired_qty").Visible = True

            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            Dim aa(10) As String
            Dim grandtotal As Double


            With FReceiving_Items

                For Each row As DataGridViewRow In .DataGridView1.Rows
                    If row.DefaultCellStyle.BackColor = Color.White Then
                        grandtotal = CDbl(row.Cells(3).Value)
                    End If
                Next

                aa(0) = "GRAND TOTAL"
                aa(1) = 0
                aa(2) = "-"
                aa(3) = FormatNumber(grandtotal, 2, , , TriState.True)
                aa(4) = "-"
                aa(5) = "-"
                aa(6) = 0
                aa(7) = "-"
                aa(8) = "-"

                .DataGridView1.Rows.Add(aa)

                FReceiving_Items_Monitoring.set_cell_readonly(c, True)
                .DataGridView1.Rows(c).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)

                .DataGridView1.Rows(c).DefaultCellStyle.BackColor = Color.Orange

                .DataGridView1.Rows(c).Cells("col_desired_qty").ReadOnly = True
                .DataGridView1.Rows(c).Cells("col_qty_received").ReadOnly = True

            End With

        End Try

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub FReceiving_Find_Related_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSearchby.SelectedIndex = 0
    End Sub
End Class