Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FQty_takeoff_balances
    Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader
    Dim list_listview_data As New List(Of List(Of String))
    Dim global_row As Integer

    Public Sub load_variation_no_every_project(ByVal n As Integer, ByVal project_name As String)
        cmb_search_variation_no.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            CMD1.Parameters.AddWithValue("@project_desc", project_name)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmb_search_variation_no.Items.Add(DR.Item("variation_order").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Private Sub load_qty_takeoff_to_listview(ByVal x As Integer, ByVal value As String)
        lvl_qty_takeoff_balances.Items.Clear()
        list_listview_data.Clear()
        'lblVo_value.Text = x
        'lblProjectName_value.Text = value

        Dim nwsqlcmd As New SqlCommand
        Dim a(40) As String
        Dim count As Integer = 0
        Dim qty_takeoff As Double

        Sqlcon.connection.Open()
        nwsqlcmd.Connection = Sqlcon.connection
        nwsqlcmd.CommandText = "proc_Quantity_takeoff"
        nwsqlcmd.CommandType = CommandType.StoredProcedure
        nwsqlcmd.Parameters.AddWithValue("@n", 20)
        nwsqlcmd.Parameters.AddWithValue("@value", value)
        nwsqlcmd.Parameters.AddWithValue("@variance_order", x)
        ' nwsqlcmd.CommandTimeout = 300
        sqldr = nwsqlcmd.ExecuteReader
        While sqldr.Read
            a(0) = sqldr.Item("qty_takeoff_id").ToString
            a(1) = sqldr.Item("project_desc").ToString
            a(2) = sqldr.Item("whItem").ToString
            a(3) = sqldr.Item("whItemDesc").ToString
            a(4) = sqldr.Item("qto_id").ToString
            a(5) = sqldr.Item("qto_item_name").ToString
            a(6) = sqldr.Item("qto_item_desc").ToString
            a(7) = FormatNumber(sqldr.Item("qty_takeoff").ToString)
            If a(7) = "" Then
                qty_takeoff = 0.00
            Else
                qty_takeoff = CDbl(a(7))
            End If
            a(8) = sqldr.Item("unit").ToString
            a(9) = FormatNumber(sqldr.Item("price").ToString)
            a(10) = FormatNumber(sqldr.Item("amount").ToString)
            a(11) = sqldr.Item("category_quantity_take_off").ToString
            a(12) = sqldr.Item("contract_item_name").ToString
            a(13) = sqldr.Item("contract_item_desc").ToString
            a(14) = sqldr.Item("const_unit").ToString
            a(15) = FormatNumber(sqldr.Item("const_qty").ToString)
            a(16) = FormatNumber(sqldr.Item("const_unitCost").ToString)
            a(17) = FormatNumber(sqldr.Item("const_totalCost").ToString)
            a(18) = FormatNumber(sqldr.Item("RS_QTY").ToString)
            a(19) = FormatNumber(sqldr.Item("SERVED").ToString)
            'If a(19) = "" Then
            '    served = 0.00
            'Else
            '    served = CDbl(a(19))
            'End If
            a(20) = FormatNumber(sqldr.Item("PENDING_FOR_RS").ToString)
            a(21) = FormatNumber(sqldr.Item("PENDING_FOR_QTY_TAKEOFF").ToString)
            a(22) = sqldr.Item("variation_order").ToString
            a(23) = sqldr.Item("main_sub").ToString
            a(24) = sqldr.Item("contract_id").ToString
            a(25) = sqldr.Item("proj_id").ToString
            a(26) = sqldr.Item("category").ToString
            a(27) = sqldr.Item("equip_category").ToString
            a(28) = sqldr.Item("equip_typeOf").ToString
            a(29) = sqldr.Item("equip_labor_qty").ToString
            a(30) = FormatNumber(sqldr.Item("duration").ToString)
            'a(31) = sqldr.Item("rental").ToString
            a(31) = sqldr.Item("equip_cat_id").ToString
            a(32) = sqldr.Item("equip_type_id").ToString
            a(33) = sqldr.Item("part_cat_id").ToString
            a(34) = sqldr.Item("Part_Category").ToString
            a(35) = sqldr.Item("name_category").ToString
            a(36) = sqldr.Item("man_power_id").ToString
            a(37) = sqldr.Item("man_power_type").ToString
            a(38) = sqldr.Item("vo_history").ToString

            Dim lvlList As New ListViewItem(a)
            lvl_qty_takeoff_balances.Items.Add(lvlList)
        End While
        sqldr.Close()
        Sqlcon.connection.Close()
        lblVo_value.Text = lvl_qty_takeoff_balances.Items(0).SubItems(22).Text
        lblProjectName_value.Text = lvl_qty_takeoff_balances.Items(0).SubItems(1).Text
    End Sub
    Private Sub category_header(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(11).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("category")
        global_row = global_row + 1
    End Sub
    Private Sub category_details_material(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(5).Text & " " & lvl_qty_takeoff_balances.Items(i).SubItems(6).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(8).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(7).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(18).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(19).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(20).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(21).Text)
        list_listview_data(global_row).Add("details")
        global_row = global_row + 1
    End Sub
    Private Sub category_details_equipment(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(28).Text & " =  " & lvl_qty_takeoff_balances.Items(i).SubItems(29).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(8).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(30).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("details")
        global_row = global_row + 1
    End Sub
    Private Sub category_details_labor(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(37).Text & " =  " & lvl_qty_takeoff_balances.Items(i).SubItems(29).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(8).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(30).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("details")
        global_row = global_row + 1
    End Sub
    Private Sub header_minor_request(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(12).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(13).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(14).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(15).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("title")
        global_row = global_row + 1
    End Sub
    Private Sub header_major_request(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(12).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(13).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(14).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(15).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("title")
        global_row = global_row + 1
    End Sub
    Private Sub part_details(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(34).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff_balances.Items(i).SubItems(35).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("part")
        global_row = global_row + 1
    End Sub
    Private Sub category_details_miscellanious(ByVal misc As String, ByVal amount As String, ByVal id As String)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(misc)
        list_listview_data(global_row).Add(amount)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub spacing()
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub load_to_griedview()
        Dim get_previous_value_contract_id As Integer = 0
        Dim get_previous_value_cat_id As Integer = 0
        Dim get_previous_value_part_cat_id As Integer = 0
        Dim boolean_space_value As Boolean = True
        global_row = 0
        Dim misc As String = ""
        Dim amount As String = ""
        Dim id As String = ""

        For i As Integer = 0 To lvl_qty_takeoff_balances.Items.Count - 1
            If lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 4 Then 'miscellanious
                misc = lvl_qty_takeoff_balances.Items(i).SubItems(11).Text
                amount = lvl_qty_takeoff_balances.Items(i).SubItems(10).Text
                id = lvl_qty_takeoff_balances.Items(i).SubItems(0).Text
            Else
                'header sa part
                If CInt(lvl_qty_takeoff_balances.Items(i).SubItems(33).Text) <> get_previous_value_part_cat_id Then
                    spacing()
                    part_details(i)
                    boolean_space_value = False
                End If
                get_previous_value_part_cat_id = lvl_qty_takeoff_balances.Items(i).SubItems(33).Text
                '*****end sa header part******

                If lvl_qty_takeoff_balances.Items(i).SubItems(23).Text = 2 Then 'major
                    If boolean_space_value = True Then
                        spacing()
                    End If
                    boolean_space_value = True
                    header_major_request(i) 'data
                ElseIf lvl_qty_takeoff_balances.Items(i).SubItems(23).Text = 1 Then 'minor
                    If get_previous_value_contract_id = CInt(lvl_qty_takeoff_balances.Items(i).SubItems(24).Text) Then  'pag pareha ang contract id
                        If get_previous_value_cat_id = CInt(lvl_qty_takeoff_balances.Items(i).SubItems(26).Text) Then  'pag pareha og category id
                            If lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 1 Then 'materials
                                category_details_material(i)
                            ElseIf lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 2 Then 'equipment
                                category_details_equipment(i)
                            ElseIf lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 3 Then 'labor
                                category_details_labor(i)
                            End If
                        Else 'pag dili pareha og category id
                            category_header(i) 'header sa category
                            If lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 1 Then 'materials
                                category_details_material(i)
                            ElseIf lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 2 Then 'equipment
                                category_details_equipment(i)
                            ElseIf lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 3 Then 'labor
                                category_details_labor(i)
                            End If
                        End If
                    Else 'pag dili pareha og contract id
                        If boolean_space_value = True Then
                            spacing()
                        End If
                        boolean_space_value = True
                        header_minor_request(i)  'header
                        If lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 1 Then 'category = materials
                            category_header(i)
                            category_details_material(i)
                        ElseIf lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 2 Then 'category = equipment
                            category_header(i)
                            category_details_equipment(i)
                        ElseIf lvl_qty_takeoff_balances.Items(i).SubItems(26).Text = 3 Then 'category = labor
                            category_header(i)
                            category_details_labor(i)
                        End If
                    End If
                    get_previous_value_contract_id = lvl_qty_takeoff_balances.Items(i).SubItems(24).Text
                    get_previous_value_cat_id = lvl_qty_takeoff_balances.Items(i).SubItems(26).Text
                End If
            End If
        Next
        spacing()
        spacing()
        category_details_miscellanious(misc, amount, id)  'category = misc
        spacing()
        spacing()

        'gridview Data clear
        gridview_takeoff_balances.Rows.Clear()

        For i As Integer = 0 To list_listview_data.Count - 1
            Dim a(10) As String
            a(0) = list_listview_data(i)(0)
            a(1) = list_listview_data(i)(1)
            a(2) = list_listview_data(i)(2)
            a(3) = list_listview_data(i)(3)
            a(4) = list_listview_data(i)(4)
            a(5) = list_listview_data(i)(5)
            a(6) = list_listview_data(i)(6)
            a(7) = list_listview_data(i)(7)
            a(8) = list_listview_data(i)(8)
            a(9) = list_listview_data(i)(9)
            gridview_takeoff_balances.Rows.Add(a)
        Next

        For i As Integer = 0 To gridview_takeoff_balances.RowCount - 1
            If gridview_takeoff_balances.Rows(i).Cells(9).Value = "title" Then
                gridview_takeoff_balances.Rows(i).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)
                'gridview_takeoff_balances.Rows(i).Cells(9).Value = gridview_takeoff_balances.Rows(i).Cells(9).Value
            ElseIf gridview_takeoff_balances.Rows(i).Cells(9).Value = "category" Then
                gridview_takeoff_balances.Rows(i).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Underline)
            ElseIf gridview_takeoff_balances.Rows(i).Cells(9).Value = "part" Then
                gridview_takeoff_balances.Rows(i).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
            ElseIf gridview_takeoff_balances.Rows(i).Cells(9).Value = "details" Then
                gridview_takeoff_balances.Rows(i).Cells(2).Value = "            " + gridview_takeoff_balances.Rows(i).Cells(2).Value
            End If

            '***color sa qty takeoff og served*****
            Dim qty_takeoff As Double
            Dim served As Double

            If gridview_takeoff_balances.Rows(i).Cells(4).Value = "" Or gridview_takeoff_balances.Rows(i).Cells(6).Value = "" Then
                qty_takeoff = 0.00
                served = 0.00
            Else
                qty_takeoff = CDbl(gridview_takeoff_balances.Rows(i).Cells(4).Value)
                served = CDbl(gridview_takeoff_balances.Rows(i).Cells(6).Value)
            End If

            If qty_takeoff < served Then
                gridview_takeoff_balances.Rows(i).DefaultCellStyle.BackColor = Color.Red
                gridview_takeoff_balances.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        load_qty_takeoff_to_listview(CInt(cmb_search_variation_no.Text), cmb_search_project_name.Text)
        load_to_griedview()

    End Sub
    Private Sub FQty_takeoff_balances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FProjectIncharge.load_all(cmb_search_project_name, 1, "PROJECT")
    End Sub
    Private Sub cmb_search_project_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search_project_name.SelectedIndexChanged
        load_variation_no_every_project(65, cmb_search_project_name.Text)
    End Sub
    Private Sub lbl_search_Click(sender As Object, e As EventArgs) Handles lbl_search.Click

    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
    Private Sub cmb_search_variation_no_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search_variation_no.SelectedIndexChanged

    End Sub
    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class