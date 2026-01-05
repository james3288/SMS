Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FAggregatesForm
    Public exitbtn As Boolean
    Private cListOfItems 'As New List(Of Model._Mod_Warehouse_Item.Warehouse_Item_Fields)
    Private cListOfItemsNew As New List(Of Model._Mod_Warehouse_Item.Warehouse_Item_Fields)

    Public _forWhToWhMissingIn As Integer = 0
    Private Sub FAggregatesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'UI

        Dim UISearch As New class_placeholder4
        UISearch.king_placeholder_textbox("Search Aggregates Here...", txtSearchAggregates, Nothing, Panel1, My.Resources.search, False, "White", "Search Aggregates Here")

        'load_aggregates()

        Dim aggregatesItem As New Model._Mod_Warehouse_Item

        aggregatesItem.parameter("@n", 114)
        aggregatesItem.parameter("@searchby", "Search by Item Name")
        aggregatesItem.cStoreProcedureName = "proc_get_data_from_warehouse"

        cListOfItems = From a In aggregatesItem.LISTOFWAREHOUSEITEM Order By a.item_desc Ascending

        For Each row As Model._Mod_Warehouse_Item.Warehouse_Item_Fields In cListOfItems
            If row.item_name.ToLower().Contains("aggregate") Then
                cListOfItemsNew.Add(row)
            End If
        Next

        searchAggregates("")
    End Sub

    Private Sub searchAggregates(search As String)
        lvlListOfAggregates.Items.Clear()

        Dim cListOfListViewItem As New List(Of ListViewItem)


        For Each row In cListOfItemsNew
            'Dim items As String = $"{row.item_name} - {row.item_desc} {row.warehouse_area} {row.classification }"

            If row.item_name.ToLower().Contains(search.ToLower()) OrElse
                row.item_desc.ToLower().Contains(search.ToLower()) OrElse
                row.warehouse_area.ToLower().Contains(search.ToLower()) OrElse
                row.classification.ToLower().Contains(search.ToLower()) OrElse
                row.specific_loc.ToLower().Contains(search.ToLower()) Then
                'If items.ToLower().Contains(search.ToLower()) Then
                Dim a(5) As String

                a(0) = row.wh_id
                a(1) = row.item_name
                a(2) = row.item_desc
                a(3) = row.warehouse_area
                a(4) = row.classification
                a(5) = row.specific_loc

                Dim lvl As New ListViewItem(a)
                'lvlListOfAggregates.Items.Add(lvl)
                cListOfListViewItem.Add(lvl)
            End If
        Next

        lvlListOfAggregates.Items.AddRange(cListOfListViewItem.ToArray)

    End Sub

    Public Sub load_aggregates()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(10) As String

        lvlListOfAggregates.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 21)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                a(0) = newDR.Item("wh_id").ToString
                a(1) = newDR.Item("whItem").ToString
                a(2) = newDR.Item("whItemDesc").ToString
                a(3) = newDR.Item("wh_area").ToString
                a(4) = newDR.Item("whClass").ToString
                a(5) = newDR.Item("whSpecificLoc").ToString

                Dim lvl As New ListViewItem(a)
                lvlListOfAggregates.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'WH TO WH: missing IN
        If _forWhToWhMissingIn > 0 Then
            Dim wh_id As Integer = lvlListOfAggregates.SelectedItems(0).Text
            FWHtoWH.addWh_to_Wh_In(wh_id)
            Me.Close()
            Exit Sub
        End If



        For Each row As ListViewItem In lvlListOfAggregates.Items
            If row.Checked = True Then
                'update wh_id

                Dim wh_id As Integer = CInt(row.Text)
                Dim rs_id As Integer
                Dim in_out As String = ""

                If button_click_name = "EquipmentUseForHaulingToolStripMenuItem" Then
                    rs_id = pub_rs_id
                    in_out = "IN"

                ElseIf button_click_name = "EditInfoToolStripMenuItem" Then
                    'pub_dr_item_id = CInt(FDRLIST.lvlDRList.SelectedItems(0).Text)
                    If FDRLIST.lvl_drList.SelectedItems(0).SubItems(16).Text = "IN" Then
                        rs_id = pub_rs_id
                        in_out = "IN"
                    ElseIf FDRLIST.lvl_drList.SelectedItems(0).SubItems(16).Text = "OUT" Then
                        rs_id = pub_rs_id
                        in_out = "OUT"
                    End If

                ElseIf button_click_name = "ItemsToolStripMenuItem" Then
                    rs_id = pub_rs_id
                    in_out = "IN"
                End If

                Dim newSQ As New SQLcon
                Dim newCMD As SqlCommand

                Try
                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    If in_out = "IN" Then
                        newCMD.Parameters.AddWithValue("@n", 22)
                        newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                    ElseIf in_out = "OUT" Then
                        newCMD.Parameters.AddWithValue("@n", 24)
                        newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                    End If

                    newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                    newCMD.Parameters.AddWithValue("@dr_item_id", pub_dr_item_id)

                    newCMD.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()

                    If pub_button_name = "EquipmentUseForHaulingToolStripMenuItem" Then
                        FRequistionForm.cmbSearchByCategory.Text = "Search by RS.No."
                        FRequistionForm.txtSearch.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
                    End If

                    exitbtn = True
                    Me.Dispose()

                End Try
            End If
        Next
    End Sub

    Private Sub FAggregatesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub FAggregatesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If

        If exitbtn = True Then
            e.Cancel = False
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to close this form?", "SUPPLY Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '1: kwaon ang pub_dr_item_id

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_Delivery_Receipt1", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@pub_dr_item_id", pub_dr_item_id)
                newCMD.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
                e.Cancel = False
            End Try

        Else

        End If
    End Sub

    Private Sub txtSearchAggregates_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAggregates.TextChanged
        If txtSearchAggregates.Text = "" Then
            lvlListOfAggregates.Items.Clear()
        Else
            searchAggregates(txtSearchAggregates.Text)
        End If

    End Sub


End Class