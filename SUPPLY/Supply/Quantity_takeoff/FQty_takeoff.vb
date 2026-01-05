Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FQty_takeoff
    Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader
    Dim txtbox As TextBox
    Public textname As String
    Dim z As Integer
    Dim vo_z As Integer
    Dim qto_z As Integer
    Dim global_vo_boolean As Boolean
    Dim get_previous_value_contract_id_vo As Integer
    Dim get_previous_value_cat_id_vo As Integer
    Dim boolean_space_value_vo As Boolean = True
    Dim get_previous_value_part_cat_id_vo As Integer
    Dim variation_number_vo As Integer
    Dim vo_insert_edit_delele_value As String
    Dim global_vo_number As Integer
    Dim list_id_lvl_history As New List(Of String)
    ' Dim global_boolean_part_cat_id As Boolean
    '---VO DATA---
    Dim vo_proj_id As Integer
    Dim vo_qto_id As Integer
    Dim vo_category As Integer
    Dim vo_qty_takeOff As Decimal
    Dim vo_const_id As Integer
    Dim vo_const_unit As String
    Dim vo_const_qty As Double
    Dim vo_const_unitCost As Decimal
    Dim vo_const_totalCost As Decimal
    Dim vo_equip_qty As Integer
    Dim vo_unit As String
    Dim vo_price As Decimal
    Dim vo_amount As Decimal
    Dim vo_main_sub As Integer
    Dim vo_date_log As DateTime
    Dim vo_qty_takeoff_id As Integer
    Dim takeoff_id_form As Integer
    Dim control As Boolean = False
    Dim list_listview_data As New List(Of List(Of String))
    Dim list_item_name As New List(Of String)
    Dim list_materials_name As New List(Of String)
    Dim list_part_category As New List(Of List(Of String))
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim global_row As Integer = 0
    Private MouseIsDown As Boolean = False
    Private MouseIsDownLoc As Point = Nothing
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel_excel_form.MouseMove

        If e.Button = MouseButtons.Left Then
            If MouseIsDown = False Then
                MouseIsDown = True
                MouseIsDownLoc = New Point(e.X, e.Y)
            End If

            Panel_excel_form.Location = New Point(Panel_excel_form.Location.X + e.X - MouseIsDownLoc.X, Panel_excel_form.Location.Y + e.Y - MouseIsDownLoc.Y)
        End If
    End Sub
    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel_excel_form.MouseUp
        MouseIsDown = False
    End Sub
    Private Sub FQty_takeoff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        part_boolean_mod = False
        cmb_searchby.Text = "By Project"
        FProjectIncharge.load_all(cmb_project, 1, "PROJECT")
        FProjectIncharge.load_all(cmb_search_project_name, 1, "PROJECT")
        item_name(42)
        load_db_qto_maintenance(15)

        'save data for  item name list and materials name list
        save_data_item_name_list(51)
        save_data_material_list(52)

        'save data for list part category
        save_data_part_category(57)
        load_list_part_category()

        'btn formation
        Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
        Panel_btnSave.BringToFront()
    End Sub
    Private Sub FQty_takeoff_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to cancel Update?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                clear_field_all()
                btn_save.Text = "Save"
                Panel_for_equipment_cat.Visible = False
                Panel_split_equi_cat.Visible = False
                Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
                Panel_btnSave.BringToFront()
                txtvariance_order.Focus()
            End If
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btn_save.PerformClick()
        End If
    End Sub
    Private Sub load_list_materials_name()
        Dim row As New AutoCompleteStringCollection

        For Each item In list_materials_name
            row.Add(item)
        Next

        txt_search.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_search.AutoCompleteCustomSource = row
    End Sub
    Private Sub save_data_material_list(ByVal n As Integer)
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                list_materials_name.Add(DR.Item(0).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Private Function get_ManPower_id(ByVal name As String) As Integer
        Dim SQ3 As New SQLcon
        Dim CMD3 As New SqlCommand
        Dim DR3 As SqlDataReader
        Try
            SQ3.connection.Open()
            CMD3.Connection = SQ3.connection
            CMD3.CommandText = "proc_Quantity_takeoff"
            CMD3.CommandType = CommandType.StoredProcedure
            CMD3.Parameters.AddWithValue("@n", 60)
            CMD3.Parameters.AddWithValue("@man_power", name)

            DR3 = CMD3.ExecuteReader
            While DR3.Read
                get_ManPower_id = DR3.Item(0).ToString
            End While
            DR3.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ3.connection.Close()
        End Try
    End Function
    Public Function get_equipType_id(ByVal name As String) As Integer
        Dim SQ2 As New SQLcon
        Dim CMD2 As New SqlCommand
        Dim DR2 As SqlDataReader
        Try
            SQ2.connection.Open()
            CMD2.Connection = SQ2.connection
            CMD2.CommandText = "proc_Quantity_takeoff"
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.AddWithValue("@n", 56)
            CMD2.Parameters.AddWithValue("@equip_typeOf", name)

            DR2 = CMD2.ExecuteReader
            While DR2.Read
                get_equipType_id = DR2.Item("equipTypeID").ToString
            End While
            DR2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ2.connection.Close()
        End Try
    End Function
    Public Function get_category_id(ByVal name As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR1 As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 55)
            CMD1.Parameters.AddWithValue("@equip_category", name)

            DR1 = CMD1.ExecuteReader
            While DR1.Read
                get_category_id = DR1.Item("equipCatID").ToString
            End While
            DR1.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Private Sub load_list_item_name_list()
        Dim row As New AutoCompleteStringCollection

        For Each item In list_item_name
            row.Add(item)
        Next

        txt_search.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_search.AutoCompleteCustomSource = row
    End Sub
    Private Sub load_equipType(ByVal n As Integer)
        cmb_equip_type.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 54)
            CMD1.Parameters.AddWithValue("@equipCatID", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmb_equip_type.Items.Add(DR.Item(0).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Public Sub load_list_part_category()
        Dim row As New AutoCompleteStringCollection
        For Each item As List(Of String) In list_part_category
            '' MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1))
            row.Add(item(0))
        Next
        txtPart_category.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtPart_category.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtPart_category.AutoCompleteCustomSource = row
    End Sub
    Public Sub save_data_part_category(ByVal n As Integer)
        list_part_category.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Dim Row As Integer
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                list_part_category.Add(New List(Of String))
                list_part_category(Row).Add(DR.Item("Part_Category").ToString + " - " + DR.Item("name_category").ToString)
                'list_part_category(Row).Add(DR.Item("name_category").ToString)
                Row = Row + 1
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try

        'load Part Category
        'load_list_part_category()
    End Sub
    Private Sub save_data_item_name_list(ByVal n As Integer)
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                list_item_name.Add(DR.Item(0).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Public Sub item_name(ByVal n As Integer)
        cmbItem_No.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmbItem_No.Items.Add(DR.Item("Item_name_no").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Public Sub load_db_man_power(ByVal n As Integer)
        cmb_man_power.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmb_man_power.Items.Add(DR.Item(1).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub

    Public Sub load_db_qto_maintenance(ByVal n As Integer)
        cmb_item_name.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmb_item_name.Items.Add(DR.Item("qto_item_name").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Public Sub load_db_qto_maintenance_description(ByVal n As Integer, ByVal value As String)
        cmb_item_desc.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            CMD1.Parameters.AddWithValue("@qto_item_name", value)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmb_item_desc.Items.Add(DR.Item("qto_item_desc").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Private Sub cmbItemNo_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_No.GotFocus
    End Sub
    Public Sub cons_itemDesc(ByVal n As Integer, cmb As ComboBox)
        cmbItemDesc.Items.Clear()
        Dim SQ2 As New SQLcon
        Dim CMD2 As New SqlCommand
        Dim DR2 As SqlDataReader
        Dim i As Integer = get_contract_item_name_id(cmb.Text)

        Try
            SQ2.connection.Open()
            CMD2.Connection = SQ2.connection
            CMD2.CommandText = "proc_Quantity_takeoff"
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.AddWithValue("@n", n)
            CMD2.Parameters.AddWithValue("@id", i)
            DR2 = CMD2.ExecuteReader
            While DR2.Read
                cmbItemDesc.Items.Add(DR2.Item("contract_item_desc").ToString)
            End While
            DR2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ2.connection.Close()
        End Try
    End Sub
    Private Function id_part_category(ByVal x As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 59)
            CMD1.Parameters.AddWithValue("@Part_Category", x)

            DR = CMD1.ExecuteReader
            While DR.Read
                id_part_category = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Function get_contract_item_name_id(ByVal item As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 44)
            CMD1.Parameters.AddWithValue("@const_item_name", item)

            DR = CMD1.ExecuteReader
            While DR.Read
                get_contract_item_name_id = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Sub cmbContract_unit_value(ByVal n As Integer, ByVal cmbitem As String, ByVal cmbitemDesc As String)
        cmbContract_Unit.Items.Clear()
        Dim SQ2 As New SQLcon
        Dim CMD2 As New SqlCommand
        Dim DR2 As SqlDataReader
        Dim i As Integer = get_contract_item_name_id(cmbitem)
        Try
            SQ2.connection.Open()
            CMD2.Connection = SQ2.connection
            CMD2.CommandText = "proc_Quantity_takeoff"
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.AddWithValue("@n", n)
            CMD2.Parameters.AddWithValue("@contract_id", i)
            CMD2.Parameters.AddWithValue("@contract_item_desc", cmbitemDesc)
            DR2 = CMD2.ExecuteReader
            While DR2.Read
                cmbContract_Unit.Items.Add(DR2.Item("const_unit").ToString)
            End While
            DR2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ2.connection.Close()
        End Try
    End Sub
    Private Sub cmbItemNO_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbItem_No.SelectedIndexChanged
        cons_itemDesc(43, cmbItem_No)
        'cmbItemDesc.Text = ""
    End Sub
    Private Sub load_lvl_vo_history_to_listview()
        lvl_vo_history.Items.Clear()
        list_id_lvl_history.Clear()
        Dim nwsqlcmd As New SqlCommand
        Dim a(40) As String
        Dim count As Integer = 0
        'Dim qty_takeoff As Double
        Dim value As String = lvl_qty_takeoff.Items(0).SubItems(1).Text

        Sqlcon.connection.Open()
        nwsqlcmd.Connection = Sqlcon.connection
        nwsqlcmd.CommandText = "proc_Quantity_takeoff"
        nwsqlcmd.CommandType = CommandType.StoredProcedure
        nwsqlcmd.Parameters.AddWithValue("@n", 62)
        nwsqlcmd.Parameters.AddWithValue("@value", value)
        'nwsqlcmd.Parameters.AddWithValue("@variance_order", CInt(txtvariance_order.Text))

        sqldr = nwsqlcmd.ExecuteReader
        While sqldr.Read
            a(0) = sqldr.Item("qty_takeoff_id").ToString
            a(1) = sqldr.Item("project_desc").ToString
            a(2) = sqldr.Item("qto_id").ToString
            a(3) = sqldr.Item("qto_item_name").ToString
            a(4) = sqldr.Item("qto_item_desc").ToString
            a(5) = FormatNumber(sqldr.Item("qty_takeoff").ToString)
            a(6) = sqldr.Item("unit").ToString
            a(7) = FormatNumber(sqldr.Item("price").ToString)
            a(8) = FormatNumber(sqldr.Item("amount").ToString)
            a(9) = sqldr.Item("category_quantity_take_off").ToString
            a(10) = sqldr.Item("const_unit").ToString
            a(11) = FormatNumber(sqldr.Item("const_qty").ToString)
            a(12) = FormatNumber(sqldr.Item("const_unitCost").ToString)
            a(13) = FormatNumber(sqldr.Item("const_totalCost").ToString)
            a(14) = sqldr.Item("proj_id").ToString
            a(15) = sqldr.Item("contract_id").ToString
            a(16) = sqldr.Item("variation_order").ToString
            a(17) = sqldr.Item("main_sub").ToString
            a(18) = sqldr.Item("category").ToString
            a(19) = sqldr.Item("contract_item_name").ToString
            a(20) = sqldr.Item("contract_item_desc").ToString
            a(21) = sqldr.Item("equip_cat_id").ToString
            a(22) = FormatNumber(sqldr.Item("equip_type_id").ToString)
            a(23) = sqldr.Item("equip_category").ToString
            a(24) = sqldr.Item("equip_typeOf").ToString
            a(25) = sqldr.Item("equip_labor_qty").ToString
            a(26) = sqldr.Item("duration").ToString
            a(27) = sqldr.Item("part_cat_id").ToString
            a(28) = sqldr.Item("Part_Category").ToString
            a(29) = sqldr.Item("name_category").ToString
            a(30) = sqldr.Item("man_power_id").ToString
            a(31) = sqldr.Item("man_power_type").ToString
            a(32) = sqldr.Item("status_saving").ToString
            a(33) = sqldr.Item("date_log").ToString
            a(34) = sqldr.Item("Vo_number").ToString

            Dim lvl_item As New ListViewItem(a)
            lvl_vo_history.Items.Add(lvl_item)
        End While

        sqldr.Close()
        Sqlcon.connection.Close()
    End Sub
    Private Sub load_qty_for_save(ByVal x As Integer, ByVal value As String)
        lvl_qty_takeoff.Items.Clear()
        lblVo_value.Text = x
        lblProjectName_value.Text = value

        Dim nwsqlcmd As New SqlCommand
        Dim a(40) As String
        Dim count As Integer = 0
        Dim qty_takeoff As Double

        Sqlcon.connection.Open()
        nwsqlcmd.Connection = Sqlcon.connection
        nwsqlcmd.CommandText = "proc_Quantity_takeoff"
        nwsqlcmd.CommandType = CommandType.StoredProcedure
        nwsqlcmd.Parameters.AddWithValue("@n", 53)
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
            ' a(18) = FormatNumber(sqldr.Item("RS_QTY").ToString)
            '' a(19) = FormatNumber(sqldr.Item("SERVED").ToString)
            'If a(19) = "" Then
            '    served = 0.00
            'Else
            '    served = CDbl(a(19))
            'End If
            'a(20) = FormatNumber(sqldr.Item("PENDING_FOR_RS").ToString)
            'a(21) = FormatNumber(sqldr.Item("PENDING_FOR_QTY_TAKEOFF").ToString)
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
            lvl_qty_takeoff.Items.Add(lvlList)
        End While
        sqldr.Close()
        Sqlcon.connection.Close()
    End Sub
    Public Sub load_qty_takeoff(ByVal cmb As Object, ByVal value As Integer, ByVal x As Integer)
        lvl_qty_takeoff.Items.Clear()

        Dim nwsqlcmd As New SqlCommand
        Dim a(30) As String
        Dim count As Integer = 0
        Dim qty_takeoff As Double
        Dim served As Double
        'Try
        Sqlcon.connection.Open()

        nwsqlcmd.Connection = Sqlcon.connection
        nwsqlcmd.CommandText = "proc_Quantity_takeoff"
        nwsqlcmd.CommandType = CommandType.StoredProcedure

        If cmb = "By Project" Then
            nwsqlcmd.Parameters.AddWithValue("@n", 20)
            nwsqlcmd.Parameters.AddWithValue("@value", value)
            nwsqlcmd.Parameters.AddWithValue("@variance_order", x)
        ElseIf cmb = "By Item Name" Then
            nwsqlcmd.Parameters.AddWithValue("@n", 1)
            nwsqlcmd.Parameters.AddWithValue("@value", txt_search.Text)
        ElseIf cmb = "By Materials" Then
            nwsqlcmd.Parameters.AddWithValue("@n", 2)
            nwsqlcmd.Parameters.AddWithValue("@value", txt_search.Text)
        End If

        nwsqlcmd.CommandTimeout = 300
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
            If a(19) = "" Then
                served = 0.00
            Else
                served = CDbl(a(19))
            End If
            a(20) = FormatNumber(sqldr.Item("PENDING_FOR_RS").ToString)
            a(21) = FormatNumber(sqldr.Item("PENDING_FOR_QTY_TAKEOFF").ToString)
            a(22) = sqldr.Item("variation_order").ToString
            a(23) = sqldr.Item("main_sub").ToString
            a(24) = sqldr.Item("contract_id").ToString
            a(25) = sqldr.Item("proj_id").ToString
            a(26) = sqldr.Item("category").ToString
            'a(27) = sqldr.Item("contract_item_name").ToString
            'a(28) = sqldr.Item("contract_item_name").ToString
            'a(5) = get_total_of_qty_req(sqldr.Item("wh_id").ToString)
            'a(6) = a(4) - a(5)

            Dim lvlList As New ListViewItem(a)
            lvl_qty_takeoff.Items.Add(lvlList)

            If qty_takeoff < served Then
                lvl_qty_takeoff.Items(count).BackColor = Color.Red
                lvl_qty_takeoff.Items(count).ForeColor = Color.White
            End If

            count += 1
        End While
        sqldr.Close()
        Sqlcon.connection.Close()
    End Sub
    Public Function get_total_of_qty_req(ByVal whid As Integer) As Integer
        Dim nwsqLcon As New SQLcon
        Dim nwsqlcom As SqlCommand
        Dim nwsqLdr As SqlDataReader
        Try
            nwsqLcon.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE wh_id = " & whid
            nwsqlcom = New SqlCommand(publicquery, nwsqLcon.connection)
            nwsqLdr = nwsqlcom.ExecuteReader
            While nwsqLdr.Read
                get_total_of_qty_req += nwsqLdr.Item("qty").ToString
            End While
            nwsqLdr.Close()
        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            nwsqLcon.connection.Close()
        End Try
    End Function
    Public Sub clear_fields()
        '***for materials
        cmb_item_name.Text = ""
        cmb_item_desc.Text = ""
        txtUnit.Clear()
        txt_takeoff.Clear()
        txtbox_price.Clear()
        '***for equipments
        cmbEquipCategory.Text = ""
        cmb_equip_type.Text = ""
        txtEquip_labor_qty.Text = ""
        txtEquip_Labor_unit.Text = ""
        txtEquip_Labor_duration.Text = ""
        txtEquip_Labor_amount.Text = ""
        '***for labor
        cmb_man_power.Text = ""
    End Sub
    Private Sub clear_fields_misc()
        txtPart_category.Text = ""
        cmbItem_No.Text = ""
        cmbItemDesc.Text = ""
        cmbContract_Unit.Text = ""
        txtContractQty.Text = ""
        txtContractUnitCost.Text = ""
        txtTotalCost.Text = ""
        '***for materials
        cmb_item_name.Text = ""
        cmb_item_desc.Text = ""
        txtUnit.Clear()
        txt_takeoff.Clear()
        txtbox_price.Clear()
        '***for equipments
        cmbEquipCategory.Text = ""
        cmb_equip_type.Text = ""
        txtEquip_labor_qty.Text = ""
        txtEquip_Labor_unit.Text = ""
        txtEquip_Labor_duration.Text = ""
        txtEquip_Labor_amount.Text = ""
        '***for labor
        cmb_man_power.Text = ""
    End Sub
    Private Sub cmb_project_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_project.SelectedIndexChanged

    End Sub
    Private Sub cmb_item_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_item_name.SelectedIndexChanged
        load_db_qto_maintenance_description(16, cmb_item_name.Text)

    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If cmb_searchby.Text = "By Project" Then
            load_qty_for_save(CInt(cmb_search_variation_no.Text), cmb_search_project_name.Text)
            load_lvl_vo_history_to_listview()
            load_qty_takeoff_gridview_form()
        End If
    End Sub
    Private Sub txt_search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_search.PerformClick()
        End If
    End Sub

    Private Sub cmb_searchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_searchby.SelectedIndexChanged
        If cmb_searchby.Text = "By Project" Then
            cmb_search_project_name.Visible = True
            txt_search.Visible = False
        ElseIf cmb_searchby.Text = "By Item Name" Then
            cmb_search_project_name.Visible = False
            txt_search.Visible = True
            txt_search.Location = New System.Drawing.Point(cmb_search_project_name.Location.X, cmb_search_project_name.Location.Y)
            load_list_item_name_list()
        ElseIf cmb_searchby.Text = "By Materials" Then
            cmb_search_project_name.Visible = False
            txt_search.Visible = True
            txt_search.Location = New System.Drawing.Point(cmb_search_project_name.Location.X, cmb_search_project_name.Location.Y)
            load_list_materials_name()
        End If
    End Sub
    Private Sub txt_takeoff_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_takeoff.KeyDown, txtContractQty.KeyDown, txtContractUnitCost.KeyDown, txtTotalCost.KeyDown

    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If ChkboxMain.Checked = False And ChkboxSub.Checked = True Then
            If cmbCategory.Text = "Materials" Then
                If txtvariance_order.Text = "" Then
                    MsgBox("Please input data")
                    txtvariance_order.Focus()
                ElseIf cmb_project.Text = "" Then
                    MsgBox("Please input data")
                    cmb_project.Focus()
                    'ElseIf txtPart_category.Text = "" Then
                    '    MsgBox("Please input data")
                    '    txtPart_category.Focus()
                ElseIf cmbItem_No.Text = "" Then
                    MsgBox("Please input data")
                    cmbItem_No.Focus()
                ElseIf cmbItemDesc.Text = "" Then
                    MsgBox("Please input data")
                    cmbItemDesc.Focus()
                ElseIf cmbCategory.Text = "" Then
                    MsgBox("Please input data")
                    cmbCategory.Focus()
                ElseIf cmbContract_Unit.Text = "" Then
                    MsgBox("Please input data")
                    cmbContract_Unit.Focus()
                ElseIf txtContractQty.Text = "" Then
                    MsgBox("Please input data")
                    txtContractQty.Focus()
                ElseIf txtContractUnitCost.Text = "" Then
                    MsgBox("Please input data")
                    txtContractUnitCost.Focus()
                ElseIf txtTotalCost.Text = "" Then
                    MsgBox("Please input data")
                    txtTotalCost.Focus()
                ElseIf cmb_item_name.Text = "" Then
                    MsgBox("Please input data")
                    cmb_item_name.Focus()
                ElseIf cmb_item_desc.Text = "" Then
                    MsgBox("Please input data")
                    cmb_item_desc.Focus()
                ElseIf txtUnit.Text = "" Then
                    MsgBox("Please input data")
                    txtUnit.Focus()
                ElseIf txt_takeoff.Text = "" Then
                    MsgBox("Please input data")
                    txt_takeoff.Focus()
                ElseIf txtbox_price.Text = "" Then
                    MsgBox("Please input data")
                    txtbox_price.Focus()
                Else
                    insert_update_qty_takeoff(FBorrowed_Item_Monitoring.get_id_proj_equip(0, cmb_project.Text), get_contract_item_name_id(cmbItem_No.Text))
                End If
            ElseIf cmbCategory.Text = "Equipment" Then
                If txtvariance_order.Text = "" Then
                    MsgBox("Please input data")
                    txtvariance_order.Focus()
                ElseIf cmb_project.Text = "" Then
                    MsgBox("Please input data")
                    cmb_project.Focus()
                    'ElseIf txtPart_category.Text = "" Then
                    '    MsgBox("Please input data")
                    '    txtPart_category.Focus()
                ElseIf cmbItem_No.Text = "" Then
                    MsgBox("Please input data")
                    cmbItem_No.Focus()
                ElseIf cmbItemDesc.Text = "" Then
                    MsgBox("Please input data")
                    cmbItemDesc.Focus()
                ElseIf cmbCategory.Text = "" Then
                    MsgBox("Please input data")
                    cmbCategory.Focus()
                ElseIf cmbContract_Unit.Text = "" Then
                    MsgBox("Please input data")
                    cmbContract_Unit.Focus()
                ElseIf txtContractQty.Text = "" Then
                    MsgBox("Please input data")
                    txtContractQty.Focus()
                ElseIf txtContractUnitCost.Text = "" Then
                    MsgBox("Please input data")
                    txtContractUnitCost.Focus()
                ElseIf txtTotalCost.Text = "" Then
                    MsgBox("Please input data")
                    txtTotalCost.Focus()
                ElseIf cmbEquipCategory.Text = "" Then
                    MsgBox("Please input data")
                    cmbEquipCategory.Focus()
                ElseIf cmb_equip_type.Text = "" Then
                    MsgBox("Please input data")
                    cmb_equip_type.Focus()
                ElseIf txtEquip_labor_qty.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_labor_qty.Focus()
                ElseIf txtEquip_Labor_unit.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_Labor_unit.Focus()
                ElseIf txtEquip_Labor_duration.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_Labor_duration.Focus()
                ElseIf txtEquip_Labor_amount.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_Labor_amount.Focus()
                Else
                    insert_update_qty_takeoff(FBorrowed_Item_Monitoring.get_id_proj_equip(0, cmb_project.Text), get_contract_item_name_id(cmbItem_No.Text))
                End If
            ElseIf cmbCategory.Text = "Labor" Then
                If txtvariance_order.Text = "" Then
                    MsgBox("Please input data")
                    txtvariance_order.Focus()
                ElseIf cmb_project.Text = "" Then
                    MsgBox("Please input data")
                    cmb_project.Focus()
                    'ElseIf txtPart_category.Text = "" Then
                    '    MsgBox("Please input data")
                    '    txtPart_category.Focus()
                ElseIf cmbItem_No.Text = "" Then
                    MsgBox("Please input data")
                    cmbItem_No.Focus()
                ElseIf cmbItemDesc.Text = "" Then
                    MsgBox("Please input data")
                    cmbItemDesc.Focus()
                ElseIf cmbCategory.Text = "" Then
                    MsgBox("Please input data")
                    cmbCategory.Focus()
                ElseIf cmbContract_Unit.Text = "" Then
                    MsgBox("Please input data")
                    cmbContract_Unit.Focus()
                ElseIf txtContractQty.Text = "" Then
                    MsgBox("Please input data")
                    txtContractQty.Focus()
                ElseIf txtContractUnitCost.Text = "" Then
                    MsgBox("Please input data")
                    txtContractUnitCost.Focus()
                ElseIf txtTotalCost.Text = "" Then
                    MsgBox("Please input data")
                    txtTotalCost.Focus()
                ElseIf cmb_man_power.Text = "" Then
                    MsgBox("Please input data")
                    cmb_man_power.Focus()
                ElseIf txtEquip_labor_qty.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_labor_qty.Focus()
                ElseIf txtEquip_Labor_unit.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_Labor_unit.Focus()
                ElseIf txtEquip_Labor_duration.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_Labor_duration.Focus()
                ElseIf txtEquip_Labor_amount.Text = "" Then
                    MsgBox("Please input data")
                    txtEquip_Labor_amount.Focus()
                Else
                    insert_update_qty_takeoff(FBorrowed_Item_Monitoring.get_id_proj_equip(0, cmb_project.Text), get_contract_item_name_id(cmbItem_No.Text))
                End If
            End If
        ElseIf ChkboxMain.Checked = True And ChkboxSub.Checked = False Then
            If txtvariance_order.Text = "" Then
                MsgBox("Please input data")
                txtvariance_order.Focus()
            ElseIf cmb_project.Text = "" Then
                MsgBox("Please input data")
                txtvariance_order.Focus()
            ElseIf cmbItem_No.Text = "" Then
                MsgBox("Please input data")
                cmbItem_No.Focus()
            ElseIf cmbItemDesc.Text = "" Then
                MsgBox("Please input data")
                cmbItemDesc.Focus()
            ElseIf cmbContract_Unit.Text = "" Then
                MsgBox("Please input data")
                cmbContract_Unit.Focus()
            ElseIf txtContractQty.Text = "" Then
                MsgBox("Please input data")
                txtContractQty.Focus()
            ElseIf txtContractUnitCost.Text = "" Then
                MsgBox("Please input data")
                txtContractUnitCost.Focus()
            ElseIf txtTotalCost.Text = "" Then
                MsgBox("Please input data")
                txtTotalCost.Focus()
            Else
                insert_update_qty_takeoff(FBorrowed_Item_Monitoring.get_id_proj_equip(0, cmb_project.Text), get_contract_item_name_id(cmbItem_No.Text))
            End If
        ElseIf ChkboxMain.Checked = False And ChkboxSub.Checked = False Then
            If txtvariance_order.Text = "" Then
                MsgBox("Please input data")
                txtvariance_order.Focus()
            ElseIf cmb_project.Text = "" Then
                MsgBox("Please input data")
                txtvariance_order.Focus()
            ElseIf txtbox_price.Text = "" Then
                MsgBox("Please input data")
                txtbox_price.Focus()
            ElseIf cmbCategory.Text = "" Then
                MsgBox("Please input data")
                cmbCategory.Focus()
            Else
                insert_update_qty_takeoff(FBorrowed_Item_Monitoring.get_id_proj_equip(0, cmb_project.Text), get_contract_item_name_id(cmbItem_No.Text))
            End If
        End If
    End Sub
    Public Sub insert_update_qty_takeoff(ByVal proj_id As Integer, ByVal cmbItemno As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim qty_takeoff_id As Integer
        Dim amount As Decimal
        Dim id_category_value As Integer = id_category(cmbCategory.Text)
        Dim str As String
        Dim strArr() As String
        str = txtPart_category.Text
        strArr = str.Split("-")
        Dim part_category_id As Integer = id_part_category(strArr(0).TrimEnd)
        ' Dim boolean_save As Boolean = False
        Dim w As Integer

        Try
            newSQ.connection.Open()
            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.CommandType = CommandType.StoredProcedure

            If btn_save.Text = "Save" Then
                newCMD.Parameters.AddWithValue("@query", "INSERT")
            ElseIf btn_save.Text = "Update" Then
                qty_takeoff_id = gridview_excel_form.SelectedRows(0).Cells(4).Value
                newCMD.Parameters.AddWithValue("@query", "UPDATE")
                newCMD.Parameters.AddWithValue("@qty_take_off_id", qty_takeoff_id)
            End If

            If ChkboxSub.Checked = True And ChkboxMain.Checked = False Then
                newCMD.Parameters.AddWithValue("@proj_id", proj_id)
                newCMD.Parameters.AddWithValue("@main_sub", 1)
                newCMD.Parameters.AddWithValue("@category", id_category_value)
                newCMD.Parameters.AddWithValue("@variance_order", CInt(txtvariance_order.Text))
                newCMD.Parameters.AddWithValue("@part_cat_id", part_category_id)

                If id_category_value = 1 Then
                    newCMD.Parameters.AddWithValue("@qty_off_id", get_qty_id(cmb_item_name.Text, cmb_item_desc.Text))
                    newCMD.Parameters.AddWithValue("@qty_take_off", CDec(txt_takeoff.Text))
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                    newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                    newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                    newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
                    newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                    newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                    newCMD.Parameters.AddWithValue("@price", CDec(txtbox_price.Text))
                    amount = CDec(txt_takeoff.Text) * CDec(txtbox_price.Text)
                    newCMD.Parameters.AddWithValue("@amount", amount)
                ElseIf id_category_value = 2 Then
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                    newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                    newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                    newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                    newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                    newCMD.Parameters.AddWithValue("@equip_labor_qty", CInt(txtEquip_labor_qty.Text))
                    newCMD.Parameters.AddWithValue("@equip_cat", get_category_id(cmbEquipCategory.Text))
                    newCMD.Parameters.AddWithValue("@equip_type", get_equipType_id(cmb_equip_type.Text))
                    newCMD.Parameters.AddWithValue("@unit", txtEquip_Labor_unit.Text)
                    newCMD.Parameters.AddWithValue("@duration", CInt(txtEquip_Labor_duration.Text))
                    newCMD.Parameters.AddWithValue("@amount", CDec(txtEquip_Labor_amount.Text))
                ElseIf id_category_value = 3 Then
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                    newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                    newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                    newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                    newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                    newCMD.Parameters.AddWithValue("@man_power_id", get_ManPower_id(cmb_man_power.Text))
                    newCMD.Parameters.AddWithValue("@equip_labor_qty", CInt(txtEquip_labor_qty.Text))
                    newCMD.Parameters.AddWithValue("@unit", txtEquip_Labor_unit.Text)
                    newCMD.Parameters.AddWithValue("@duration", CInt(txtEquip_Labor_duration.Text))
                    newCMD.Parameters.AddWithValue("@amount", CDec(txtEquip_Labor_amount.Text))
                    'ElseIf id_category_value = 4 Then
                    '    newCMD.Parameters.AddWithValue("@amount", CDec(txtbox_price.Text))
                End If
                ' boolean_save = True
            ElseIf ChkboxMain.Checked = True And ChkboxSub.Checked = False Then
                newCMD.Parameters.AddWithValue("@proj_id", proj_id)
                newCMD.Parameters.AddWithValue("@main_sub", 2)
                newCMD.Parameters.AddWithValue("@variance_order", CInt(txtvariance_order.Text))
                newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                newCMD.Parameters.AddWithValue("@part_cat_id", part_category_id)
                newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                'newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
                'newCMD.Parameters.AddWithValue("@qty_take_off", CDec(txt_takeoff.Text))
                ' boolean_save = True
            ElseIf ChkboxMain.Checked = False And ChkboxSub.Checked = False Then
                If id_category_value = 4 Then
                    newCMD.Parameters.AddWithValue("@proj_id", proj_id)
                    ' newCMD.Parameters.AddWithValue("@main_sub", 1)
                    newCMD.Parameters.AddWithValue("@category", id_category_value)
                    newCMD.Parameters.AddWithValue("@variance_order", CInt(txtvariance_order.Text))
                    ' newCMD.Parameters.AddWithValue("@part_cat_id", part_category_id)
                    newCMD.Parameters.AddWithValue("@amount", CDec(txtbox_price.Text))
                End If
                ' boolean_save = True
            End If

            ' If boolean_save = True Then
            If btn_save.Text = "Save" Then
                z = newCMD.ExecuteScalar
                MessageBox.Show("Successfully saved.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MessageBox.Show("Are you sure you want to update the data?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    newCMD.ExecuteNonQuery()
                End If
                w = qty_takeoff_id
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

        If global_vo_boolean = True Then 'pag mo adto og vo-insert item
            If vo_insert_edit_delele_value = "Insert" Then
                update_vo_history_dbQuantity_takeoff(z)
                save_to_qty_takeoff_for_vo(z, "Inserted")
            ElseIf vo_insert_edit_delele_value = "Edit" Then
                save_to_qty_takeoff_for_vo(global_vo_number, "Edited")
            End If
            load_qty_for_save(CInt(txtvariance_order.Text), cmb_project.Text)
            load_lvl_vo_history_to_listview()
            load_qty_takeoff_gridview_form()
            data_focus(z)
            clear_field_all()
        Else
            load_qty_for_save(CInt(txtvariance_order.Text), cmb_project.Text)
            load_lvl_vo_history_to_listview()
            load_qty_takeoff_gridview_form()

            If btn_save.Text = "Save" Then
                data_focus(z)
                clear_fields()
            ElseIf btn_save.Text = "Update" Then
                data_focus(w)
                clear_field_all()
                btn_save.Text = "Save"
            End If
        End If
        global_vo_boolean = False
        btn_save.Text = "Save"
        'insert_contract_item_desc(cmbItem_No.Text, cmbItemDesc.Text)

    End Sub
    Private Sub update_vo_history_dbQuantity_takeoff(ByVal value As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Try
            newSQ.connection.Open()
            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 64)
            newCMD.Parameters.AddWithValue("@vo_history", value)
            newCMD.Parameters.AddWithValue("@qty_takeoff_id", value)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub save_to_qty_takeoff_for_vo(ByVal id As Integer, ByVal value As String)
        Dim newSQ1 As New SQLcon
        Dim newCMD1 As New SqlCommand

        Try
            newSQ1.connection.Open()
            newCMD1.Connection = newSQ1.connection
            newCMD1.CommandText = "proc_Quantity_takeoff"
            newCMD1.CommandType = CommandType.StoredProcedure
            newCMD1.Parameters.AddWithValue("@n", 61)
            newCMD1.Parameters.AddWithValue("@qty_takeoff_id", id)
            newCMD1.Parameters.AddWithValue("@status_saving", value)
            newCMD1.Parameters.AddWithValue("@date_log", Date.Now)
            newCMD1.Parameters.AddWithValue("@Vo_number", lvl_qty_takeoff.Items(0).SubItems(22).Text)

            vo_z = newCMD1.ExecuteScalar
            MessageBox.Show("Successfully saved. to database db_vo", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ1.connection.Close()
        End Try
        ' MsgBox("save to vo table")
    End Sub
    Private Sub save_vo_history()
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        ' Dim qty_takeoff_id As Integer
        Dim amount As Decimal
        Dim id_category_value As Integer = id_category(cmbCategory.Text)
        Dim str As String
        Dim strArr() As String
        str = txtPart_category.Text
        strArr = str.Split("-")
        Dim part_category_id As Integer = id_part_category(strArr(0).TrimEnd)
        Dim proj_id As Integer = FBorrowed_Item_Monitoring.get_id_proj_equip(0, cmb_project.Text)

        Try
            newSQ.connection.Open()
            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 61)

            If ChkboxSub.Checked = True And ChkboxMain.Checked = False Then
                newCMD.Parameters.AddWithValue("@proj_id", proj_id)
                newCMD.Parameters.AddWithValue("@main_sub", 1)
                newCMD.Parameters.AddWithValue("@category", id_category_value)
                newCMD.Parameters.AddWithValue("@variance_order", CInt(txtvariance_order.Text))
                newCMD.Parameters.AddWithValue("@part_cat_id", part_category_id)
                newCMD.Parameters.AddWithValue("@qty_takeoff_id", qto_z) '
                newCMD.Parameters.AddWithValue("@status", "Insert")
                newCMD.Parameters.AddWithValue("@date_log", Date.Now)

                If id_category_value = 1 Then
                    newCMD.Parameters.AddWithValue("@qto_id", get_qty_id(cmb_item_name.Text, cmb_item_desc.Text))
                    newCMD.Parameters.AddWithValue("@qty_take_off", CDec(txt_takeoff.Text))
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                    newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                    newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                    newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
                    newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                    newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                    newCMD.Parameters.AddWithValue("@price", CDec(txtbox_price.Text))
                    amount = CDec(txt_takeoff.Text) * CDec(txtbox_price.Text)
                    newCMD.Parameters.AddWithValue("@amount", amount)

                ElseIf id_category_value = 2 Then
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                    newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                    newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                    newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                    newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                    newCMD.Parameters.AddWithValue("@equip_labor_qty", CInt(txtEquip_labor_qty.Text))
                    newCMD.Parameters.AddWithValue("@equip_cat", get_category_id(cmbEquipCategory.Text))
                    newCMD.Parameters.AddWithValue("@equip_type", get_equipType_id(cmb_equip_type.Text))
                    newCMD.Parameters.AddWithValue("@unit", txtEquip_Labor_unit.Text)
                    newCMD.Parameters.AddWithValue("@duration", CInt(txtEquip_Labor_duration.Text))
                    newCMD.Parameters.AddWithValue("@amount", CDec(txtEquip_Labor_amount.Text))
                ElseIf id_category_value = 3 Then
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                    newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                    newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                    newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                    newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                    newCMD.Parameters.AddWithValue("@man_power_id", get_ManPower_id(cmb_man_power.Text))
                    newCMD.Parameters.AddWithValue("@equip_labor_qty", CInt(txtEquip_labor_qty.Text))
                    newCMD.Parameters.AddWithValue("@unit", txtEquip_Labor_unit.Text)
                    newCMD.Parameters.AddWithValue("@duration", CInt(txtEquip_Labor_duration.Text))
                    newCMD.Parameters.AddWithValue("@amount", CDec(txtEquip_Labor_amount.Text))
                End If

            ElseIf ChkboxMain.Checked = True And ChkboxSub.Checked = False Then
                newCMD.Parameters.AddWithValue("@proj_id", proj_id)
                newCMD.Parameters.AddWithValue("@main_sub", 2)
                newCMD.Parameters.AddWithValue("@variance_order", CInt(txtvariance_order.Text))
                newCMD.Parameters.AddWithValue("@contract_id", get_contract_item_name_id(cmbItem_No.Text))
                newCMD.Parameters.AddWithValue("@contract_item_desc", cmbItemDesc.Text)
                newCMD.Parameters.AddWithValue("@part_cat_id", part_category_id)
                newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                newCMD.Parameters.AddWithValue("@const_qty", CDec(txtContractQty.Text))
                newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
            End If

            vo_z = newCMD.ExecuteScalar
            MessageBox.Show("Successfully saved.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub clear_field_2()
        lbl_note.Visible = False
        lvl_qty_takeoff.Enabled = True

        cmb_project.Text = ""
        cmbItem_No.Text = ""
        cmbItemDesc.Text = ""
        cmbContract_Unit.Text = ""
        ' txtContractUnit.Clear()
        txtContractQty.Clear()
        txtContractUnitCost.Clear()
        txtTotalCost.Clear()
        txtbox_price.Clear()
        txtbox_eqp_qty.Clear()
        cmbEquipCategory.Text = ""
        cmbCategory.Text = ""
        txtvariance_order.Text = ""
        txtvariance_order.Enabled = True
    End Sub
    Private Sub clear_field_all()
        txtvariance_order.Text = ""
        cmb_project.Text = ""
        txtPart_category.Text = ""
        cmbItem_No.Text = ""
        cmbItemDesc.Text = ""
        cmbCategory.Text = ""
        cmbContract_Unit.Text = ""
        txtContractQty.Text = ""
        txtContractUnitCost.Text = ""
        txtTotalCost.Text = ""
        cmb_item_name.Text = ""
        cmb_item_desc.Text = ""
        txtUnit.Text = ""
        txt_takeoff.Text = ""
        txtbox_price.Text = ""
        '****
        cmbEquipCategory.Text = ""
        cmb_equip_type.Text = ""
        txtEquip_labor_qty.Text = ""
        txtEquip_Labor_unit.Text = ""
        txtEquip_Labor_duration.Text = ""
        txtEquip_Labor_amount.Text = ""
        cmb_man_power.Text = ""
    End Sub
    Private Sub data_focus(ByVal value As Integer)
        Dim count As Integer = 0
        For i As Integer = 0 To gridview_excel_form.RowCount - 1
            If gridview_excel_form.Rows(i).Cells(4).Value = CStr(value) Then
                gridview_excel_form.Rows(count).Selected = DataGridViewSelectionMode.FullRowSelect
                ' MsgBox(count)
                Exit For
            End If
            count = count + 1
        Next
    End Sub
    Public Sub insert_contract_item_desc(ByVal x As String, ByVal y As String)
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim i As Integer = get_contract_item_name_id(x)
        Try

            newSQ.connection.Open()

            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 48)
            newCMD.Parameters.AddWithValue("@contract_id", i)
            newCMD.Parameters.AddWithValue("@contract_item_desc", y)


            newCMD.ExecuteNonQuery()
            '  MsgBox("ian")
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Function get_wh_id(ByVal x As String, ByVal y As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 12)
            CMD1.Parameters.AddWithValue("@wh_item", x)
            CMD1.Parameters.AddWithValue("@whItemDesc", y)
            DR = CMD1.ExecuteReader

            While DR.Read
                get_wh_id = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Function get_qty_id(ByVal x As String, ByVal y As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 18)
            CMD1.Parameters.AddWithValue("@qto_item_name", x)
            CMD1.Parameters.AddWithValue("@qto_item_desc", y)
            DR = CMD1.ExecuteReader

            While DR.Read
                get_qty_id = DR.Item(0).ToString
                'MsgBox(DR.Item("qto_item_name").ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Function get_equipment_id(ByVal x As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 11)
            CMD1.Parameters.AddWithValue("@equip_typeOf", x)

            DR = CMD1.ExecuteReader
            While DR.Read
                get_equipment_id = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Function id_category(ByVal category As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 8)
            CMD1.Parameters.AddWithValue("@category_quantity_take_off", category)
            DR = CMD1.ExecuteReader
            While DR.Read
                id_category = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Sub delete_qty_takeoff(qty_takeoff_id As Integer)
        Dim sqlcmd As New SqlCommand
        Try
            Sqlcon.connection.Open()
            sqlcmd.Connection = Sqlcon.connection
            sqlcmd.CommandText = "proc_Quantity_takeoff"
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.Parameters.AddWithValue("@query", "DELETE")
            sqlcmd.Parameters.AddWithValue("@qty_take_off_id", qty_takeoff_id)
            sqlcmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Public Sub edit_qt_Data(ByVal qt_id As Integer, ByVal x As Integer)
        Dim SQ2 As New SQLcon
        Dim CMD2 As New SqlCommand
        Dim DR2 As SqlDataReader
        Try
            SQ2.connection.Open()
            CMD2.Connection = SQ2.connection
            CMD2.CommandText = "proc_Quantity_takeoff"
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.AddWithValue("@n", 5)
            CMD2.Parameters.AddWithValue("@value", qt_id)
            DR2 = CMD2.ExecuteReader
            While DR2.Read
                If x = 1 Then
                    cmbItem_No.Text = DR2.Item("item").ToString
                    cmbItemDesc.Text = DR2.Item("item_desc").ToString
                    cmbContract_Unit.Text = DR2.Item("const_unit").ToString
                    txtContractQty.Text = DR2.Item("const_qty").ToString
                    txtContractUnitCost.Text = DR2.Item("const_unitCost").ToString
                    txtTotalCost.Text = DR2.Item("const_totalCost").ToString
                    txtUnit.Text = DR2.Item("unit").ToString
                ElseIf x = 2 Then
                    txtbox_eqp_qty.Text = DR2.Item("equip_qty").ToString
                End If

            End While
            DR2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ2.connection.Close()
            cmb_searchby.Enabled = False
            txt_search.Enabled = False
            btn_search.Enabled = False
            ListBox1.Visible = False
        End Try
    End Sub
    Public Function get_main_sub_id(ByVal x As Integer) As Integer
        Dim SQ2 As New SQLcon
        Dim CMD2 As New SqlCommand
        Dim DR2 As SqlDataReader
        Try
            SQ2.connection.Open()
            CMD2.Connection = SQ2.connection
            CMD2.CommandText = "proc_Quantity_takeoff"
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.AddWithValue("@n", 14)
            CMD2.Parameters.AddWithValue("@qty_takeoff_id", x)
            DR2 = CMD2.ExecuteReader
            While DR2.Read
                get_main_sub_id = DR2.Item(0).ToString

            End While
            DR2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Function
    Private Sub txtContractUnit_TextChanged(sender As Object, e As EventArgs) Handles txtUnit.TextChanged
        txtbox = sender

        With ListBox1
            .Location = New Point(txtbox.Bounds.Left + 14, txtbox.Bounds.Bottom + 49)
            .Width = txtbox.Width
            .Parent = Me
            .BringToFront()

            If txtbox.Text = "" Then
                .Visible = False
            Else
                .Visible = True
                listbox_data(txtbox)
            End If
        End With

    End Sub

    Private Sub listbox_data(ByVal txbox As TextBox)
        With ListBox1
            .Items.Clear()
            Dim SQ1 As New SQLcon
            Dim CMD1 As New SqlCommand
            Dim DR As SqlDataReader
            Dim count As Integer = 0
            Try
                SQ1.connection.Open()
                CMD1.Connection = SQ1.connection
                CMD1.CommandText = "proc_Quantity_takeoff"
                CMD1.CommandType = CommandType.StoredProcedure

                If txbox.Name = "txtContractUnit" Then
                    CMD1.Parameters.AddWithValue("@n", 6)
                ElseIf txbox.Name = "txtUnit" Then
                    CMD1.Parameters.AddWithValue("@n", 7)
                End If

                CMD1.Parameters.AddWithValue("@value", txbox.Text)
                DR = CMD1.ExecuteReader

                While DR.Read
                    If txbox.Name = "txtContractUnit" Then
                        .Items.Add(DR.Item("units").ToString)
                    ElseIf txbox.Name = "txtUnit" Then
                        .Items.Add(DR.Item("unit").ToString)
                    End If
                End While
                DR.Close()

                If .Items.Count > 0 Then
                    .Visible = True
                Else
                    .Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ1.connection.Close()
            End Try
        End With
    End Sub
    Private Sub txtContractUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnit.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            With ListBox1
                If .Visible = True Then
                    If .Items.Count > 0 Then
                        .Focus()
                        .SelectedIndex = 0
                    End If
                Else
                End If
            End With
        End If
    End Sub

    Private Sub txtContractUnit_GotFocus(sender As Object, e As EventArgs) Handles txtUnit.GotFocus

        If txtUnit.Focused Then
            textname = txtUnit.Name
        End If
    End Sub
    Private Sub cmb_item_name_GotFocus(sender As Object, e As EventArgs) Handles cmb_item_name.GotFocus

    End Sub

    Private Sub cmbItemNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbItem_No.KeyPress, cmb_project.KeyPress, cmbItemDesc.KeyPress, cmb_item_name.KeyPress, cmb_item_desc.KeyPress
        'e.Handled = True
    End Sub

    Private Sub FQty_takeoff_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Panel1.Controls
                If ctr.Name = textname Then
                    ctr.Text = ListBox1.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            ListBox1.Visible = False
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        For Each ctr As Control In Panel1.Controls
            If ctr.Name = textname Then
                ctr.Text = ListBox1.SelectedItem.ToString
                ctr.Focus()
            End If
        Next
        ListBox1.Visible = False
    End Sub
    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        If cmbCategory.Text = "Equipment" Then
            Panel_split_equi_cat.Visible = True
            Panel_split_equi_cat.BringToFront()
            Panel_for_equipment_cat.Visible = True
            Panel_for_equipment_cat.BringToFront()

            Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y + 50)

            Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
            Panel_btnSave.BringToFront()
            cmb_equip_type.Visible = True
            cmb_equip_type.BringToFront()
            lblEquipType_ManPower.Text = "Equipment Type"

            '****tab index******
            Panel_split_equi_cat.TabIndex = 12
            cmbEquipCategory.TabIndex = 13
            Panel_for_equipment_cat.TabIndex = 14
            cmb_equip_type.TabIndex = 15
            txtEquip_labor_qty.TabIndex = 16
            txtEquip_Labor_unit.TabIndex = 17
            txtEquip_Labor_duration.TabIndex = 18
            txtEquip_Labor_amount.TabIndex = 19
            Panel_btnSave.TabIndex = 20
            btn_save.TabIndex = 21
            'cmb_man_power.TabIndex = 0
        ElseIf cmbCategory.Text = "Labor" Then
            load_db_man_power(58)
            Panel_for_equipment_cat.Visible = True
            Panel_for_equipment_cat.BringToFront()
            Panel_split_equi_cat.Visible = False
            Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y)

            Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
            Panel_btnSave.BringToFront()

            cmb_equip_type.Visible = False
            lblEquipType_ManPower.Text = "ManPower"
            cmb_man_power.Location = New System.Drawing.Point(cmb_equip_type.Location.X, cmb_equip_type.Location.Y)
            cmb_man_power.BringToFront()

            '****tab index******
            'Panel_split_equi_cat.TabIndex = 12
            'cmbEquipCategory.TabIndex = 13
            Panel_for_equipment_cat.TabIndex = 12
            ' cmb_equip_type.TabIndex = 15
            cmb_man_power.TabIndex = 13
            txtEquip_labor_qty.TabIndex = 14
            txtEquip_Labor_unit.TabIndex = 15
            txtEquip_Labor_duration.TabIndex = 16
            txtEquip_Labor_amount.TabIndex = 17
            Panel_btnSave.TabIndex = 18
            btn_save.TabIndex = 19
        ElseIf cmbCategory.Text = "Materials" Then
            Panel_for_equipment_cat.Visible = False
            Panel_split_equi_cat.Visible = False
            Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
            Panel_btnSave.BringToFront()
        ElseIf cmbCategory.Text = "Miscellaneous" Then
            Panel_for_equipment_cat.Visible = False
            Panel_split_equi_cat.Visible = False
            Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
            Panel_btnSave.BringToFront()
            clear_fields_misc()
            'txtbox_price.Focus()
        End If
    End Sub
    Private Sub cmbCategory_GotFocus(sender As Object, e As EventArgs) Handles cmbCategory.GotFocus
        category_qty_take_off(9)
    End Sub
    Public Sub category_qty_take_off(ByVal n As Integer)
        cmbCategory.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmbCategory.Items.Add(DR.Item(0).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Private Sub cmbEquipType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEquipCategory.SelectedIndexChanged
        If cmbEquipCategory.Text = "Heavy Equipment" Then
            load_equipType(1)
        ElseIf cmbEquipCategory.Text = "Light Equipment" Then
            load_equipType(2)
        End If
    End Sub
    Private Sub cmbEquipType_GotFocus(sender As Object, e As EventArgs) Handles cmbEquipCategory.GotFocus
    End Sub
    Public Sub equipment_type(ByVal n As Integer)
        cmbEquipCategory.Items.Clear()
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            DR = CMD1.ExecuteReader
            While DR.Read
                cmbEquipCategory.Items.Add(DR.Item(1).ToString)
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbox_add.Click
        FQTO_Maintenance.ShowDialog()
        load_db_qto_maintenance(15)
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FContract_Item_Name.ShowDialog()
        item_name(42)
    End Sub

    Private Sub cmbItemDesc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItemDesc.SelectedIndexChanged
        cmbContract_unit_value(36, cmbItem_No.Text, cmbItemDesc.Text)
    End Sub

    Private Sub ChkboxMain_CheckedChanged(sender As Object, e As EventArgs) Handles ChkboxMain.CheckedChanged
        If ChkboxMain.Checked = True And ChkboxSub.Checked = False Then
            clear_fields()
            disable_txtbox_cmbbox()
            cmbCategory.Text = ""
            cmbCategory.Enabled = False
        ElseIf ChkboxMain.Checked = False And ChkboxSub.Checked = True Then
            clear_fields()
            enabled_txtbox_cmbbox()
            cmbCategory.Enabled = True
        ElseIf ChkboxMain.Checked = False And ChkboxSub.Checked = False Then
            Panel_for_equipment_cat.Visible = False
            Panel_split_equi_cat.Visible = False
            Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X, txtbox_price.Location.Y + 23)
            Panel_btnSave.BringToFront()

            enabled_txtbox_cmbbox()
            cmbCategory.Enabled = True
        End If
    End Sub
    Private Sub disable_txtbox_cmbbox()
        '***for materials
        cmb_item_name.Enabled = False
        cmb_item_desc.Enabled = False
        txtUnit.Enabled = False
        txt_takeoff.Enabled = False
        txtbox_price.Enabled = False
        '***for equipments
        cmbEquipCategory.Enabled = False
        cmb_equip_type.Enabled = False
        txtEquip_labor_qty.Enabled = False
        txtEquip_Labor_unit.Enabled = False
        txtEquip_Labor_duration.Enabled = False
        txtEquip_Labor_amount.Enabled = False
        '***for labor
        cmb_man_power.Enabled = False
    End Sub
    Private Sub enabled_txtbox_cmbbox()
        '***for materials
        cmb_item_name.Enabled = True
        cmb_item_desc.Enabled = True
        txtUnit.Enabled = True
        txt_takeoff.Enabled = True
        txtbox_price.Enabled = True
        '***for equipments
        cmbEquipCategory.Enabled = True
        cmb_equip_type.Enabled = True
        txtEquip_labor_qty.Enabled = True
        txtEquip_Labor_unit.Enabled = True
        txtEquip_Labor_duration.Enabled = True
        txtEquip_Labor_amount.Enabled = True
        '***for labor
        cmb_man_power.Enabled = True
    End Sub
    Private Sub cmbItemDesc_GotFocus(sender As Object, e As EventArgs) Handles cmbItemDesc.GotFocus

    End Sub
    Private Sub cmbItemDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbItemDesc.KeyDown

    End Sub
    Private Sub cmb_item_desc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_item_desc.SelectedIndexChanged

    End Sub
    Private Sub cmb_item_desc_GotFocus(sender As Object, e As EventArgs) Handles cmb_item_desc.GotFocus

    End Sub
    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub txtTotalCost_TextChanged(sender As Object, e As EventArgs) Handles txtTotalCost.TextChanged

    End Sub

    Private Sub lvl_qty_takeoff_DoubleClick(sender As Object, e As EventArgs) Handles lvl_qty_takeoff.DoubleClick
    End Sub
    Private Sub lvl_qty_takeoff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvl_qty_takeoff.SelectedIndexChanged

    End Sub
    Public Function get_const_id(ByVal item As String, ByVal desc As String) As Integer
        Dim sqlcon1 As New SQLcon
        Dim cmd1 As SqlCommand
        Dim dr1 As SqlDataReader
        Dim publicquery1 As String

        Try
            'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'sqlcon.sql_connect()

            sqlcon1.connection.Open()

            publicquery1 = "SELECT const_id FROM dbContruct_quantities WHERE item = '" & item & "' and item_desc = '" & desc & "'"

            cmd1 = New SqlCommand(publicquery1, sqlcon1.connection) : dr1 = cmd1.ExecuteReader
            While dr1.Read : get_const_id = CInt(dr1.Item(0).ToString) : End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon1.connection.Close()
        End Try

    End Function
    Public Function get_id_projectDesc(ByVal search As String) As Integer
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            'sqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'sqlcon.sql_connect()

            sqlcon.connection1.Open()

            publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & search & "'"


            cmd = New SqlCommand(publicquery, sqlcon.connection1) : dr = cmd.ExecuteReader
            While dr.Read : get_id_projectDesc = CInt(dr.Item(0).ToString) : End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try

    End Function
    Public Sub save_to_vo_1()
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand

        'Try
        newSQ.connection.Open()

        newCMD.Connection = newSQ.connection
        newCMD.CommandText = "proc_Quantity_takeoff"
        newCMD.CommandType = CommandType.StoredProcedure
        newCMD.Parameters.AddWithValue("@n", 19)

        newCMD.Parameters.Add("@vo_proj_id", SqlDbType.Int).Value = vo_proj_id
        newCMD.Parameters.AddWithValue("@vo_qto_id", SqlDbType.Int).Value = vo_qto_id
        newCMD.Parameters.AddWithValue("@vo_category", SqlDbType.Int).Value = vo_category
        newCMD.Parameters.AddWithValue("@vo_qty_takeOff", SqlDbType.Decimal).Value = vo_qty_takeOff
        newCMD.Parameters.AddWithValue("@vo_const_id", SqlDbType.Int).Value = vo_const_id
        newCMD.Parameters.AddWithValue("@vo_const_unit", SqlDbType.NVarChar).Value = vo_const_unit
        newCMD.Parameters.AddWithValue("@vo_const_qty", SqlDbType.Decimal).Value = vo_const_qty
        newCMD.Parameters.AddWithValue("@vo_const_unitCost", SqlDbType.Decimal).Value = vo_const_unitCost
        newCMD.Parameters.AddWithValue("@vo_const_totalCost", SqlDbType.Decimal).Value = vo_const_totalCost
        newCMD.Parameters.AddWithValue("@vo_unit", SqlDbType.NVarChar).Value = vo_unit
        newCMD.Parameters.AddWithValue("@vo_price", SqlDbType.Decimal).Value = vo_price
        newCMD.Parameters.AddWithValue("@vo_amount", SqlDbType.Decimal).Value = vo_amount
        newCMD.Parameters.AddWithValue("@vo_date_log", SqlDbType.DateTime).Value = vo_date_log
        newCMD.Parameters.AddWithValue("@vo_qty_takeoff_id", SqlDbType.Int).Value = vo_qty_takeoff_id
        newCMD.ExecuteNonQuery()
        MessageBox.Show("Successfully saved to vo form.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        newSQ.connection.Close()
    End Sub
    Public Sub update_qty_takeoff_table()
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim qty_takeoff_id As Integer
        Dim amount As Decimal
        Dim proj_id As Integer = get_id_projectDesc(cmb_project.Text)
        Dim id_category_value As Integer = id_category(cmbCategory.Text)
        Dim cmbItemno As Integer = get_const_id(cmbItem_No.Text, cmbItemDesc.Text)
        'MsgBox(id_category_value)

        Try
            newSQ.connection.Open()

            newCMD.Connection = newSQ.connection
            newCMD.CommandText = "proc_Quantity_takeoff"
            newCMD.CommandType = CommandType.StoredProcedure

            qty_takeoff_id = lvl_qty_takeoff.SelectedItems(0).Text
            newCMD.Parameters.AddWithValue("@query", "UPDATE")
            newCMD.Parameters.AddWithValue("@qty_take_off_id", qty_takeoff_id)


            If ChkboxSub.Checked = True And ChkboxMain.Checked = False Then

                newCMD.Parameters.AddWithValue("@proj_id", proj_id)
                newCMD.Parameters.AddWithValue("@main_sub", 1)
                newCMD.Parameters.AddWithValue("@category", id_category_value)
                newCMD.Parameters.AddWithValue("@qty_take_off", CDec(txt_takeoff.Text))

                If id_category_value = 3 Or id_category_value = 4 Or id_category_value = 2 Then
                    newCMD.Parameters.AddWithValue("@const_id", 0)
                    newCMD.Parameters.AddWithValue("@const_unit", "n/a")
                    newCMD.Parameters.AddWithValue("@const_qty", 0)
                    newCMD.Parameters.AddWithValue("@const_unitCost", 0)
                    newCMD.Parameters.AddWithValue("@const_totalCost", 0)
                    newCMD.Parameters.AddWithValue("@equip_qty", 0)
                    newCMD.Parameters.AddWithValue("@unit", "n/a")
                    newCMD.Parameters.AddWithValue("@wh_id", 0)
                    newCMD.Parameters.AddWithValue("@qty_off_id", 0)
                    'ElseIf id_category_value = 2 Then
                    '    newCMD.Parameters.AddWithValue("@const_id", cmbItemno)
                    '    newCMD.Parameters.AddWithValue("@const_unit", txtContractUnit.Text)
                    '    newCMD.Parameters.AddWithValue("@const_qty", txtContractQty.Text)
                    '    newCMD.Parameters.AddWithValue("@const_unitCost", txtContractUnitCost.Text)
                    '    newCMD.Parameters.AddWithValue("@const_totalCost", txtTotalCost.Text)
                    '    newCMD.Parameters.AddWithValue("@equip_qty", txtbox_eqp_qty.Text)
                    '    newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
                ElseIf id_category_value = 1 Then
                    newCMD.Parameters.AddWithValue("@const_id", cmbItemno)
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", txtContractQty.Text)
                    newCMD.Parameters.AddWithValue("@const_unitCost", CDec(txtContractUnitCost.Text))
                    newCMD.Parameters.AddWithValue("@const_totalCost", CDec(txtTotalCost.Text))
                    newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
                    newCMD.Parameters.AddWithValue("@wh_id", 0)
                    newCMD.Parameters.AddWithValue("@qty_off_id", get_qty_id(cmb_item_name.Text, cmb_item_desc.Text))
                    newCMD.Parameters.AddWithValue("@variance_order", "VO")
                End If

                newCMD.Parameters.AddWithValue("@price", CDec(txtbox_price.Text))
                amount = CDec(txt_takeoff.Text) * CDec(txtbox_price.Text)
                newCMD.Parameters.AddWithValue("@amount", amount)


            ElseIf ChkboxMain.Checked = True And ChkboxSub.Checked = False Then

                newCMD.Parameters.AddWithValue("@proj_id", proj_id)
                newCMD.Parameters.AddWithValue("@main_sub", 2)

                'If id_category_value = 2 Then
                '    newCMD.Parameters.AddWithValue("@wh_id", 0)
                '    newCMD.Parameters.AddWithValue("@qty_off_id", 0)

                newCMD.Parameters.AddWithValue("@category", id_category_value)
                newCMD.Parameters.AddWithValue("@qty_take_off", 0)


                'If id_category_value = 2 Then
                '    newCMD.Parameters.AddWithValue("@const_id", cmbItemno)
                '    newCMD.Parameters.AddWithValue("@const_unit", txtContractUnit.Text)
                '    newCMD.Parameters.AddWithValue("@const_qty", txtContractQty.Text)
                '    newCMD.Parameters.AddWithValue("@const_unitCost", txtContractUnitCost.Text)
                '    newCMD.Parameters.AddWithValue("@const_totalCost", txtTotalCost.Text)
                '    newCMD.Parameters.AddWithValue("@equip_qty", 0)
                '    newCMD.Parameters.AddWithValue("@unit", "n/a")
                If id_category_value = 1 Then
                    newCMD.Parameters.AddWithValue("@const_id", cmbItemno)
                    newCMD.Parameters.AddWithValue("@const_unit", cmbContract_Unit.Text)
                    newCMD.Parameters.AddWithValue("@const_qty", txtContractQty.Text)
                    newCMD.Parameters.AddWithValue("@const_unitCost", txtContractUnitCost.Text)
                    newCMD.Parameters.AddWithValue("@const_totalCost", txtTotalCost.Text)
                    newCMD.Parameters.AddWithValue("@unit", "n/a")
                    newCMD.Parameters.AddWithValue("@wh_id", 0)
                    newCMD.Parameters.AddWithValue("@qty_off_id", 0)
                    newCMD.Parameters.AddWithValue("@variance_order", "VO")
                End If

                newCMD.Parameters.AddWithValue("@price", 0)
                ' amount = CDec(txt_takeoff.Text) * CDec(txtbox_price.Text)
                newCMD.Parameters.AddWithValue("@amount", 0)

            End If

            newCMD.ExecuteNonQuery()

            MessageBox.Show("Successfully updated", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cmb_searchby.Enabled = True
            txt_search.Enabled = True
            btn_search.Enabled = True

            cmb_searchby.Text = "By Project"
            txt_search.Text = cmb_project.Text
            btn_search.PerformClick()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            listfocus(lvl_qty_takeoff, qty_takeoff_id)

            btn_save.Text = "Save"
            lbl_note.Visible = False
            lvl_qty_takeoff.Enabled = True

            cmb_project.Text = ""
            cmbItem_No.Text = ""
            cmbItemDesc.Text = ""
            cmbContract_Unit.Text = ""
            txtContractQty.Clear()
            txtContractUnitCost.Clear()
            txtTotalCost.Clear()
            txtbox_price.Clear()
            txtbox_eqp_qty.Clear()
            cmbEquipCategory.Text = ""
            cmbCategory.Text = ""

            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Public Sub add_data_to_takeoff()
        Dim proj_id As Integer = FBorrowed_Item_Monitoring.get_id_proj_equip(0, cmb_project.Text)
        Dim const_id As Integer = get_const_id(cmbItem_No.Text, cmbItemDesc.Text)
        Dim id_category_value As Integer = id_category(cmbCategory.Text)
        Dim qty_off_id = get_qty_id(cmb_item_name.Text, cmb_item_desc.Text)
        Dim amount As Decimal

        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand

        'Try
        newSQ.connection.Open()

        newCMD.Connection = newSQ.connection
        newCMD.CommandText = "proc_Quantity_takeoff"
        newCMD.CommandType = CommandType.StoredProcedure
        newCMD.Parameters.AddWithValue("@query", "INSERT")

        If ChkboxSub.Checked = True And ChkboxMain.Checked = False Then
            newCMD.Parameters.Add("@proj_id", SqlDbType.Int).Value = proj_id
            newCMD.Parameters.AddWithValue("@qty_off_id", SqlDbType.Int).Value = qty_off_id
            newCMD.Parameters.AddWithValue("@category", SqlDbType.Int).Value = id_category_value
            newCMD.Parameters.AddWithValue("@qty_take_off", SqlDbType.Decimal).Value = CDec(txt_takeoff.Text)
            newCMD.Parameters.AddWithValue("@const_id", SqlDbType.Int).Value = const_id
            newCMD.Parameters.AddWithValue("@const_unit", SqlDbType.NVarChar).Value = cmbContract_Unit.Text
            newCMD.Parameters.AddWithValue("@const_qty", SqlDbType.Decimal).Value = CDec(txtContractQty.Text)
            newCMD.Parameters.AddWithValue("@const_unitCost", SqlDbType.Decimal).Value = CDec(txtContractUnitCost.Text)
            newCMD.Parameters.AddWithValue("@const_totalCost", SqlDbType.Decimal).Value = CDec(txtTotalCost.Text)
            newCMD.Parameters.AddWithValue("@unit", SqlDbType.NVarChar).Value = txtUnit.Text
            newCMD.Parameters.AddWithValue("@price", SqlDbType.Decimal).Value = txtbox_price.Text
            amount = CDec(txt_takeoff.Text) * CDec(txtbox_price.Text)
            newCMD.Parameters.AddWithValue("@amount", SqlDbType.Decimal).Value = amount
            newCMD.Parameters.AddWithValue("@main_sub", SqlDbType.Int).Value = 1
            newCMD.Parameters.AddWithValue("@variance_order", SqlDbType.VarChar).Value = "VO"

        ElseIf ChkboxSub.Checked = False And ChkboxMain.Checked = True Then
            newCMD.Parameters.Add("@proj_id", SqlDbType.Int).Value = proj_id
            newCMD.Parameters.AddWithValue("@qty_off_id", SqlDbType.Int).Value = 0
            newCMD.Parameters.AddWithValue("@category", SqlDbType.Int).Value = id_category_value
            newCMD.Parameters.AddWithValue("@qty_take_off", SqlDbType.Decimal).Value = 0
            newCMD.Parameters.AddWithValue("@const_id", SqlDbType.Int).Value = const_id
            newCMD.Parameters.AddWithValue("@const_unit", SqlDbType.NVarChar).Value = cmbContract_Unit.Text
            newCMD.Parameters.AddWithValue("@const_qty", SqlDbType.Decimal).Value = CDec(txtContractQty.Text)
            newCMD.Parameters.AddWithValue("@const_unitCost", SqlDbType.Decimal).Value = CDec(txtContractUnitCost.Text)
            newCMD.Parameters.AddWithValue("@const_totalCost", SqlDbType.Decimal).Value = CDec(txtTotalCost.Text)
            newCMD.Parameters.AddWithValue("@unit", SqlDbType.NVarChar).Value = "n/a"
            newCMD.Parameters.AddWithValue("@price", SqlDbType.Decimal).Value = 0
            newCMD.Parameters.AddWithValue("@amount", SqlDbType.Decimal).Value = 0
            newCMD.Parameters.AddWithValue("@main_sub", SqlDbType.Int).Value = 2
            newCMD.Parameters.AddWithValue("@variance_order", SqlDbType.VarChar).Value = "VO"
        End If

        z = newCMD.ExecuteScalar
        MessageBox.Show("Successfully saved.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        newSQ.connection.Close()

    End Sub
    Public Sub update_qty_takeoff_with_vo(ByVal x As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand

        newSQ.connection.Open()

        newCMD.Connection = newSQ.connection
        newCMD.CommandText = "proc_Quantity_takeoff"
        newCMD.CommandType = CommandType.StoredProcedure
        newCMD.Parameters.AddWithValue("@n", 28)
        newCMD.Parameters.AddWithValue("@variance_order", SqlDbType.VarChar).Value = "VO"
        newCMD.Parameters.AddWithValue("@qty_off_id", SqlDbType.Int).Value = x

        newCMD.ExecuteNonQuery()

        MessageBox.Show("Successfully updated ian", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        newSQ.connection.Close()

    End Sub
    Public Sub load_qty_takeoff_delete(ByVal id As String)
        For Each item As ListViewItem In lvl_qty_takeoff.Items
            If item.SubItems(0).Text = id Then
                ' MsgBox(id)
                item.Remove()
            End If
            Exit For
        Next
    End Sub
    Public Sub s(project_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Quantity_takeoff", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 32)
            newCMD.Parameters.AddWithValue("@proj_id", project_id)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Function PROJECT_ID(ByVal project_name As String) As Integer

        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 31)
            CMD1.Parameters.AddWithValue("@project_desc", project_name)
            DR = CMD1.ExecuteReader
            While DR.Read
                PROJECT_ID = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Function contruct_id(ByVal item As String, ByVal item_desc As String) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 33)
            CMD1.Parameters.AddWithValue("@const_item_name", item)
            CMD1.Parameters.AddWithValue("@const_item_desc", item_desc)
            DR = CMD1.ExecuteReader
            While DR.Read
                contruct_id = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Function MAX_VALUE_VARIATION_NO(ByVal PROJ_ID As Integer) As Integer
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", 34)
            CMD1.Parameters.AddWithValue("@proj_id", PROJ_ID)

            DR = CMD1.ExecuteReader
            While DR.Read
                MAX_VALUE_VARIATION_NO = DR.Item(0).ToString
            End While
            DR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection.Close()
        End Try
    End Function
    Public Sub load_variation_no_every_project(ByVal n As Integer)
        cmb_search_variation_no.Items.Clear()
        Dim proj_id As Integer = PROJECT_ID(cmb_search_project_name.Text)
        Dim SQ1 As New SQLcon
        Dim CMD1 As New SqlCommand
        Dim DR As SqlDataReader
        Try
            SQ1.connection.Open()
            CMD1.Connection = SQ1.connection
            CMD1.CommandText = "proc_Quantity_takeoff"
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.AddWithValue("@n", n)
            CMD1.Parameters.AddWithValue("@proj_id", proj_id)
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
    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged

    End Sub
    Private Sub cmb_search_project_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search_project_name.SelectedIndexChanged
        load_variation_no_every_project(35)
    End Sub
    Private Sub part_details(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(34).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(35).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("part")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub header_major_request(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(12).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(13).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(14).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(15).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add("title")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(38).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(22).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_details_material(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(5).Text & " " & lvl_qty_takeoff.Items(i).SubItems(6).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(8).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(7).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(38).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(22).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_details_equipment(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(28).Text & " =  " & lvl_qty_takeoff.Items(i).SubItems(29).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(8).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(30).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(38).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(22).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_details_labor(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(37).Text & " =  " & lvl_qty_takeoff.Items(i).SubItems(29).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(8).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(30).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(38).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(22).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_header(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(11).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("category")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub header_minor_request(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(12).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(13).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(14).Text)
        list_listview_data(global_row).Add(lvl_qty_takeoff.Items(i).SubItems(15).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("title")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub category_details_miscellanious(ByVal misc As String, ByVal amount As String, ByVal id As String)
        list_listview_data.Add(New List(Of String))
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

    Private Sub load_qty_takeoff_gridview_form()
        Panel_excel_form.Visible = True
        list_listview_data = New List(Of List(Of String))
        Dim get_previous_value_contract_id As Integer
        Dim get_previous_value_cat_id As Integer
        Dim get_previous_value_part_cat_id As Integer = 0
        Dim boolean_space_value As Boolean = True
        Dim boolean_part_cat_id As Boolean = True
        Dim count As Integer = 0
        Dim misc As String = ""
        Dim amount As String = ""
        Dim id As String = ""
        global_row = 0

        For i As Integer = 0 To lvl_qty_takeoff.Items.Count - 1
            If lvl_qty_takeoff.Items(i).SubItems(26).Text = 4 Then
                misc = lvl_qty_takeoff.Items(i).SubItems(11).Text
                amount = lvl_qty_takeoff.Items(i).SubItems(10).Text
                id = lvl_qty_takeoff.Items(i).SubItems(0).Text
            Else
                'header sa part
                If CInt(lvl_qty_takeoff.Items(i).SubItems(33).Text) <> get_previous_value_part_cat_id Then
                    spacing()
                    part_details(i)
                    boolean_space_value = False
                End If
                get_previous_value_part_cat_id = lvl_qty_takeoff.Items(i).SubItems(33).Text
                '------- end header sa part-------

                If lvl_qty_takeoff.Items(i).SubItems(23).Text = 2 Then 'major request
                    If boolean_space_value = True Then
                        spacing()
                    End If
                    boolean_space_value = True
                    header_major_request(i)
                ElseIf lvl_qty_takeoff.Items(i).SubItems(23).Text = 1 Then 'minor request
                    If get_previous_value_contract_id = lvl_qty_takeoff.Items(i).SubItems(24).Text Then 'pag pareha ang contract id
                        If get_previous_value_cat_id = lvl_qty_takeoff.Items(i).SubItems(26).Text Then  'pag pareha og category id
                            If lvl_qty_takeoff.Items(i).SubItems(26).Text = 1 Then 'materials
                                category_details_material(i)
                            ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 2 Then 'equipment
                                category_details_equipment(i)
                            ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 3 Then 'labor
                                category_details_labor(i)
                            End If
                        Else '****pag dili pareha og category id
                            category_header(i)
                            If lvl_qty_takeoff.Items(i).SubItems(26).Text = 1 Then 'materials
                                category_details_material(i)
                            ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 2 Then 'equipment
                                category_details_equipment(i)
                            ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 3 Then 'labor
                                category_details_labor(i)
                            End If
                        End If

                    Else   'pag dili pareha contract id
                        If boolean_space_value = True Then
                            spacing()
                        End If
                        boolean_space_value = True
                        header_minor_request(i)   'header
                        If lvl_qty_takeoff.Items(i).SubItems(26).Text = 1 Then 'category = materials
                            category_header(i)
                            category_details_material(i)
                        ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 2 Then 'category = equipment
                            category_header(i)
                            category_details_equipment(i)
                        ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 3 Then 'category = labor
                            category_header(i)
                            category_details_labor(i)
                        End If
                    End If
                    get_previous_value_contract_id = lvl_qty_takeoff.Items(i).SubItems(24).Text
                    get_previous_value_cat_id = lvl_qty_takeoff.Items(i).SubItems(26).Text
                End If
            End If
        Next
        spacing()
        spacing()
        category_details_miscellanious(misc, amount, id)  'category = misc
        spacing()
        spacing()

        '***** VO History *******
        Dim previous_vo_number As Integer = 0
        For i As Integer = 0 To lvl_vo_history.Items.Count - 1
            If lvl_vo_history.Items(i).SubItems(34).Text = previous_vo_number Then
                vo_form_in_list(i)
            Else '****pag dli pareho og vo
                spacing()
                '*****reset value******
                get_previous_value_contract_id_vo = 0
                get_previous_value_cat_id_vo = 0
                get_previous_value_part_cat_id_vo = 0
                '*****end reset value*******
                variation_order_details(i)
                vo_form_in_list(i)
            End If
            previous_vo_number = lvl_vo_history.Items(i).SubItems(34).Text
        Next
        spacing()
        '***** end vo history ********

        '****insert data to list_id_lvl_history******
        For i As Integer = 0 To lvl_vo_history.Items.Count - 1
            Dim vo_id As Integer = CInt(lvl_qty_takeoff.Items(0).SubItems(22).Text)
            If CInt(lvl_vo_history.Items(i).SubItems(34).Text) = vo_id Then
                list_id_lvl_history.Add(lvl_vo_history.Items(i).SubItems(0).Text)
            End If
        Next

        'gridview Data clear
        gridview_excel_form.Rows.Clear()
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

            gridview_excel_form.Rows.Add(a)
        Next

        For i As Integer = 0 To gridview_excel_form.RowCount - 1
            If gridview_excel_form.Rows(i).Cells(5).Value = "title" Then
                gridview_excel_form.Rows(i).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)
                gridview_excel_form.Rows(i).Cells(5).Value = gridview_excel_form.Rows(i).Cells(5).Value
            ElseIf gridview_excel_form.Rows(i).Cells(5).Value = "category" Then
                gridview_excel_form.Rows(i).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Underline)
            ElseIf gridview_excel_form.Rows(i).Cells(5).Value = "part" Then
                gridview_excel_form.Rows(i).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
            Else
                gridview_excel_form.Rows(i).Cells(1).Value = "            " + gridview_excel_form.Rows(i).Cells(1).Value
            End If
        Next
        '****loop para sa color backgroud***
        For Each item In list_id_lvl_history
            For i As Integer = 0 To gridview_excel_form.RowCount - 1
                If gridview_excel_form.Rows(i).Cells(6).Value = item And gridview_excel_form.Rows(i).Cells(8).Value = lvl_qty_takeoff.Items(0).SubItems(22).Text Then 'vo lvl_qty_takeoff id
                    gridview_excel_form.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                    gridview_excel_form.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If
            Next
        Next
        '***end loop*****
    End Sub
    Private Sub variation_order_details(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("*************")
        list_listview_data(global_row).Add("V0 " + lvl_vo_history.Items(i).SubItems(34).Text + " " + "HISTORY")
        list_listview_data(global_row).Add("*************")
        list_listview_data(global_row).Add("*************")
        list_listview_data(global_row).Add("*************")
        list_listview_data(global_row).Add("part")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub part_details_Vo(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(28).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(29).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("part")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub header_major_request_Vo(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(19).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(20).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(10).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(11).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("title")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(32).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(34).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_details_material_Vo(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(3).Text & " " & lvl_vo_history.Items(i).SubItems(4).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(6).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(5).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(32).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(34).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_details_equipment_Vo(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(24).Text & " =  " & lvl_vo_history.Items(i).SubItems(25).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(6).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(26).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(32).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(34).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_details_labor_Vo(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(31).Text & " =  " & lvl_vo_history.Items(i).SubItems(25).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(6).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(26).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(0).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(32).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(34).Text)
        global_row = global_row + 1
    End Sub
    Private Sub category_header_Vo(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(9).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("category")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub header_minor_request_Vo(ByVal i As Integer)
        list_listview_data.Add(New List(Of String))
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(19).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(20).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(10).Text)
        list_listview_data(global_row).Add(lvl_vo_history.Items(i).SubItems(11).Text)
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("title")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        list_listview_data(global_row).Add("")
        global_row = global_row + 1
    End Sub
    Private Sub vo_form_in_list(ByVal i As Integer)
        'header sa part
        If lvl_vo_history.Items(i).SubItems(27).Text <> get_previous_value_part_cat_id_vo Then
            spacing()
            part_details_Vo(i)
            boolean_space_value_vo = False
        End If
        get_previous_value_part_cat_id_vo = lvl_vo_history.Items(i).SubItems(27).Text
        '------- end header sa part-------

        If lvl_vo_history.Items(i).SubItems(17).Text = 2 Then 'major request
            If boolean_space_value_vo = True Then
                spacing()
            End If
            boolean_space_value_vo = True
            header_major_request_Vo(i)
        ElseIf lvl_vo_history.Items(i).SubItems(17).Text = 1 Then 'minor request
            If get_previous_value_contract_id_vo = lvl_vo_history.Items(i).SubItems(15).Text Then 'pag pareha ang contract id
                If get_previous_value_cat_id_vo = lvl_vo_history.Items(i).SubItems(18).Text Then  'pag pareha og category id
                    If lvl_vo_history.Items(i).SubItems(18).Text = 1 Then 'materials
                        category_details_material_Vo(i)
                    ElseIf lvl_vo_history.Items(i).SubItems(18).Text = 2 Then 'equipment
                        category_details_equipment_Vo(i)
                    ElseIf lvl_vo_history.Items(i).SubItems(18).Text = 3 Then 'labor
                        category_details_labor_Vo(i)
                    End If
                Else 'pag dili pareha og category id
                    category_header_Vo(i)
                    If lvl_vo_history.Items(i).SubItems(18).Text = 1 Then 'materials
                        category_details_material_Vo(i)
                    ElseIf lvl_vo_history.Items(i).SubItems(18).Text = 2 Then 'equipment
                        category_details_equipment_Vo(i)
                    ElseIf lvl_vo_history.Items(i).SubItems(18).Text = 3 Then 'labor
                        category_details_labor_Vo(i)
                    End If
                End If
            Else   'pag dili pareha contract id
                If boolean_space_value_vo = True Then
                    spacing()
                End If
                boolean_space_value_vo = True
                header_minor_request_Vo(i)  'header
                If lvl_vo_history.Items(i).SubItems(18).Text = 1 Then 'category = materials
                    category_header_Vo(i)
                    category_details_material_Vo(i)
                ElseIf lvl_vo_history.Items(i).SubItems(18).Text = 2 Then 'category = equipment
                    category_header_Vo(i)
                    category_details_equipment_Vo(i)
                ElseIf lvl_vo_history.Items(i).SubItems(18).Text = 3 Then 'category = labor
                    category_header_Vo(i)
                    category_details_labor_Vo(i)
                End If
            End If
            get_previous_value_contract_id_vo = lvl_vo_history.Items(i).SubItems(15).Text
            get_previous_value_cat_id_vo = lvl_vo_history.Items(i).SubItems(18).Text
        End If
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
        global_row = global_row + 1
    End Sub
    Private Sub EditTools(ByVal id As Integer)
        For i As Integer = 0 To lvl_qty_takeoff.Items.Count - 1
            If lvl_qty_takeoff.Items(i).SubItems(0).Text = id Then
                txtvariance_order.Text = lvl_qty_takeoff.Items(i).SubItems(22).Text
                cmb_project.Text = lvl_qty_takeoff.Items(i).SubItems(1).Text
                '*****para sa dili equal sa misc
                If lvl_qty_takeoff.Items(i).SubItems(26).Text <> 4 Then
                    If lvl_qty_takeoff.Items(i).SubItems(33).Text = 0 Then 'kung wlay part_id
                    Else
                        txtPart_category.Text = lvl_qty_takeoff.Items(i).SubItems(34).Text + " - " + lvl_qty_takeoff.Items(i).SubItems(35).Text
                    End If
                    cmbItem_No.Text = lvl_qty_takeoff.Items(i).SubItems(12).Text
                    cmbItemDesc.Text = lvl_qty_takeoff.Items(i).SubItems(13).Text
                    cmbCategory.Text = lvl_qty_takeoff.Items(i).SubItems(11).Text
                    cmbContract_Unit.Text = lvl_qty_takeoff.Items(i).SubItems(14).Text
                    txtContractQty.Text = lvl_qty_takeoff.Items(i).SubItems(15).Text
                    txtContractUnitCost.Text = lvl_qty_takeoff.Items(i).SubItems(16).Text
                    txtTotalCost.Text = lvl_qty_takeoff.Items(i).SubItems(17).Text
                End If
                '*******

                If lvl_qty_takeoff.Items(i).SubItems(23).Text = 1 Then 'minor
                    ChkboxSub.Checked = True
                    ChkboxMain.Checked = False
                ElseIf lvl_qty_takeoff.Items(i).SubItems(23).Text = 2 Then 'major
                    ChkboxSub.Checked = False
                    ChkboxMain.Checked = True
                    Panel_split_equi_cat.Visible = False
                    Panel_for_equipment_cat.Visible = False
                End If
                If lvl_qty_takeoff.Items(i).SubItems(26).Text = 1 Then 'materials
                    Panel_for_equipment_cat.Visible = False
                    Panel_split_equi_cat.Visible = False
                    Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
                    Panel_btnSave.BringToFront()
                    txtvariance_order.Focus()
                    '****supply data****
                    cmb_item_name.Text = lvl_qty_takeoff.Items(i).SubItems(5).Text
                    cmb_item_desc.Text = lvl_qty_takeoff.Items(i).SubItems(6).Text
                    txtUnit.Text = lvl_qty_takeoff.Items(i).SubItems(8).Text
                    txt_takeoff.Text = lvl_qty_takeoff.Items(i).SubItems(7).Text
                    txtbox_price.Text = lvl_qty_takeoff.Items(i).SubItems(9).Text
                    ListBox1.Visible = False
                ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 2 Then 'equipment
                    Panel_split_equi_cat.Visible = True
                    Panel_split_equi_cat.BringToFront()
                    Panel_for_equipment_cat.Visible = True
                    Panel_for_equipment_cat.BringToFront()
                    Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y + 50)
                    Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
                    Panel_btnSave.BringToFront()
                    cmb_equip_type.Visible = True
                    cmb_equip_type.BringToFront()
                    lblEquipType_ManPower.Text = "Equipment Type"
                    '****supply data****
                    cmbEquipCategory.Text = lvl_qty_takeoff.Items(i).SubItems(27).Text
                    cmb_equip_type.Text = lvl_qty_takeoff.Items(i).SubItems(28).Text
                    txtEquip_labor_qty.Text = lvl_qty_takeoff.Items(i).SubItems(29).Text
                    txtEquip_Labor_unit.Text = lvl_qty_takeoff.Items(i).SubItems(8).Text
                    txtEquip_Labor_duration.Text = lvl_qty_takeoff.Items(i).SubItems(30).Text
                    txtEquip_Labor_amount.Text = lvl_qty_takeoff.Items(i).SubItems(10).Text

                    '****tab index******
                    Panel_split_equi_cat.TabIndex = 12
                    cmbEquipCategory.TabIndex = 13
                    Panel_for_equipment_cat.TabIndex = 14
                    cmb_equip_type.TabIndex = 15
                    txtEquip_labor_qty.TabIndex = 16
                    txtEquip_Labor_unit.TabIndex = 17
                    txtEquip_Labor_duration.TabIndex = 18
                    txtEquip_Labor_amount.TabIndex = 19
                    Panel_btnSave.TabIndex = 20
                    btn_save.TabIndex = 21
                ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 3 Then  'labor
                    load_db_man_power(58)
                    Panel_for_equipment_cat.Visible = True
                    Panel_for_equipment_cat.BringToFront()
                    Panel_split_equi_cat.Visible = False
                    Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y)
                    Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
                    Panel_btnSave.BringToFront()
                    cmb_equip_type.Visible = False
                    lblEquipType_ManPower.Text = "ManPower"
                    cmb_man_power.Location = New System.Drawing.Point(cmb_equip_type.Location.X, cmb_equip_type.Location.Y)
                    cmb_man_power.BringToFront()
                    '****supply data****
                    cmb_man_power.Text = lvl_qty_takeoff.Items(i).SubItems(37).Text
                    txtEquip_labor_qty.Text = lvl_qty_takeoff.Items(i).SubItems(29).Text
                    txtEquip_Labor_unit.Text = lvl_qty_takeoff.Items(i).SubItems(8).Text
                    txtEquip_Labor_duration.Text = lvl_qty_takeoff.Items(i).SubItems(30).Text
                    txtEquip_Labor_amount.Text = lvl_qty_takeoff.Items(i).SubItems(10).Text

                    '****tab index******
                    Panel_for_equipment_cat.TabIndex = 12
                    cmb_man_power.TabIndex = 13
                    txtEquip_labor_qty.TabIndex = 14
                    txtEquip_Labor_unit.TabIndex = 15
                    txtEquip_Labor_duration.TabIndex = 16
                    txtEquip_Labor_amount.TabIndex = 17
                    Panel_btnSave.TabIndex = 18
                    btn_save.TabIndex = 19
                ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 4 Then 'misc
                    Panel_for_equipment_cat.Visible = False
                    Panel_split_equi_cat.Visible = False
                    Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
                    Panel_btnSave.BringToFront()
                    ChkboxSub.Checked = False
                    ChkboxMain.Checked = False
                    '****supply data****
                    cmbCategory.Text = lvl_qty_takeoff.Items(i).SubItems(11).Text
                    txtbox_price.Text = lvl_qty_takeoff.Items(i).SubItems(10).Text
                    ' txtbox_price.Focus()
                End If
                Exit For
            End If
        Next
        txtvariance_order.Focus()
        btn_save.Text = "Update"
    End Sub
    Private Sub cmb_man_power_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_man_power.SelectedIndexChanged

    End Sub
    Private Sub ChkboxSub_CheckedChanged(sender As Object, e As EventArgs) Handles ChkboxSub.CheckedChanged
        If ChkboxMain.Checked = False And ChkboxSub.Checked = True Then
            clear_fields()
            enabled_txtbox_cmbbox()
            cmbCategory.Enabled = True
        ElseIf ChkboxMain.Checked = True And ChkboxSub.Checked = False Then
            clear_fields()
            disable_txtbox_cmbbox()
            cmbCategory.Text = ""
            cmbCategory.Enabled = False
        ElseIf ChkboxMain.Checked = False And ChkboxSub.Checked = False Then
            Panel_for_equipment_cat.Visible = False
            Panel_split_equi_cat.Visible = False
            Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
            Panel_btnSave.BringToFront()
            enabled_txtbox_cmbbox()
            cmbCategory.Enabled = True
        End If
    End Sub
    Private Sub txtContractUnitCost_TextChanged(sender As Object, e As EventArgs) Handles txtContractUnitCost.TextChanged

    End Sub

    Private Sub txtContractUnitCost_Leave(sender As Object, e As EventArgs) Handles txtContractUnitCost.Leave

    End Sub

    Private Sub txtvariance_order_TextChanged(sender As Object, e As EventArgs) Handles txtvariance_order.TextChanged

    End Sub

    Private Sub txtbox_cmbbox_GotFocus(sender As Object, e As EventArgs) Handles txtvariance_order.GotFocus, cmb_project.GotFocus, txtPart_category.GotFocus, cmbItem_No.GotFocus, cmbItemDesc.GotFocus, cmbCategory.GotFocus, cmbContract_Unit.GotFocus, txtContractQty.GotFocus, txtContractUnitCost.GotFocus, txtTotalCost.GotFocus, cmb_item_name.GotFocus, cmb_item_desc.GotFocus, txtUnit.GotFocus, txt_takeoff.GotFocus, txtbox_price.GotFocus, cmbEquipCategory.GotFocus, cmb_equip_type.GotFocus, txtEquip_labor_qty.GotFocus, txtEquip_Labor_unit.GotFocus, txtEquip_Labor_duration.GotFocus, txtEquip_Labor_amount.GotFocus, cmb_man_power.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtvariance_order_Leave(sender As Object, e As EventArgs) Handles txtvariance_order.Leave, cmb_project.Leave, txtPart_category.Leave, cmbItem_No.Leave, cmbItemDesc.Leave, cmbCategory.Leave, cmbContract_Unit.Leave, txtContractQty.Leave, txtContractUnitCost.Leave, txtTotalCost.Leave, cmb_item_name.Leave, cmb_item_desc.Leave, txtUnit.Leave, txt_takeoff.Leave, txtbox_price.Leave, cmbEquipCategory.Leave, cmb_equip_type.Leave, txtEquip_labor_qty.Leave, txtEquip_Labor_unit.Leave, txtEquip_Labor_duration.Leave, txtEquip_Labor_amount.Leave, cmb_man_power.Leave
        sender.backcolor = Color.White
    End Sub
    Private Function increament_variation_number(ByVal name As String) As Integer
        Dim SQ3 As New SQLcon
        Dim CMD3 As New SqlCommand
        Dim DR3 As SqlDataReader
        Try
            SQ3.connection.Open()
            CMD3.Connection = SQ3.connection
            CMD3.CommandText = "proc_Quantity_takeoff"
            CMD3.CommandType = CommandType.StoredProcedure
            CMD3.Parameters.AddWithValue("@n", 63)
            CMD3.Parameters.AddWithValue("@proj_id", name)

            DR3 = CMD3.ExecuteReader
            While DR3.Read
                increament_variation_number = DR3.Item(0).ToString
            End While
            DR3.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ3.connection.Close()
        End Try
    End Function
    Private Sub Panel_excel_form_Paint(sender As Object, e As PaintEventArgs) Handles Panel_excel_form.Paint

    End Sub
    Private Sub Panel_btnSave_Paint(sender As Object, e As PaintEventArgs) Handles Panel_btnSave.Paint

    End Sub

    Private Sub txtPart_category_TextChanged(sender As Object, e As EventArgs) Handles txtPart_category.TextChanged

    End Sub

    Private Sub QtyTakeOffBalances2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QtyTakeOffBalances2ToolStripMenuItem.Click
        FQty_takeoff_balances.Show()
    End Sub

    Private Sub VODeleteItem2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VODeleteItem2ToolStripMenuItem.Click
        If gridview_excel_form.SelectedRows(0).Cells(4).Value = "" Or gridview_excel_form.SelectedRows(0).Cells(4).Value = "*************" Then
            MsgBox("Select to the appropriate item")
        Else
            If MessageBox.Show("Are you want to create this to vo?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                global_vo_number = gridview_excel_form.SelectedRows(0).Cells(6).Value
                save_to_qty_takeoff_for_vo(global_vo_number, "Deleted")
                delete_qty_takeoff(gridview_excel_form.SelectedRows(0).Cells(4).Value)
                load_qty_for_save(CInt(lvl_qty_takeoff.Items(0).SubItems(22).Text), lvl_qty_takeoff.Items(0).SubItems(1).Text)
                load_lvl_vo_history_to_listview()
                load_qty_takeoff_gridview_form()
            Else : Return
            End If
        End If
    End Sub

    Private Sub VOEditItem2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VOEditItem2ToolStripMenuItem.Click
        If gridview_excel_form.SelectedRows(0).Cells(4).Value = "" Or gridview_excel_form.SelectedRows(0).Cells(4).Value = "*************" Then
            MsgBox("Select to the appropriate item")
        Else
            clear_field_all()  '****clear all fields
            Dim get_id As Integer = gridview_excel_form.SelectedRows(0).Cells(4).Value
            EditTools(get_id)
            global_vo_boolean = True
            vo_insert_edit_delele_value = "Edit"
            global_vo_number = gridview_excel_form.SelectedRows(0).Cells(6).Value
        End If
    End Sub

    Private Sub VOInsertItem2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VOInsertItem2ToolStripMenuItem.Click
        If gridview_excel_form.SelectedRows(0).Cells(4).Value = "" Then
            clear_field_all()
            txtvariance_order.Text = lvl_qty_takeoff.Items(0).SubItems(22).Text
            cmb_project.Text = lvl_qty_takeoff.Items(0).SubItems(1).Text
            txtPart_category.Focus()
        ElseIf gridview_excel_form.SelectedRows(0).Cells(4).Value = "*************" Then
            MsgBox("Select to the appropriate item")
        Else
            clear_field_all()  '****clear all fields
            Dim get_id As Integer = gridview_excel_form.SelectedRows(0).Cells(4).Value
            For i As Integer = 0 To lvl_qty_takeoff.Items.Count - 1
                If lvl_qty_takeoff.Items(i).SubItems(0).Text = get_id Then
                    txtvariance_order.Text = lvl_qty_takeoff.Items(i).SubItems(22).Text
                    cmb_project.Text = lvl_qty_takeoff.Items(i).SubItems(1).Text
                    txtPart_category.Text = lvl_qty_takeoff.Items(i).SubItems(34).Text + " - " + lvl_qty_takeoff.Items(i).SubItems(35).Text
                    cmbItem_No.Text = lvl_qty_takeoff.Items(i).SubItems(12).Text
                    cmbItemDesc.Text = lvl_qty_takeoff.Items(i).SubItems(13).Text
                    cmbCategory.Text = lvl_qty_takeoff.Items(i).SubItems(11).Text
                    cmbContract_Unit.Text = lvl_qty_takeoff.Items(i).SubItems(14).Text
                    txtContractQty.Text = lvl_qty_takeoff.Items(i).SubItems(15).Text
                    txtContractUnitCost.Text = lvl_qty_takeoff.Items(i).SubItems(16).Text
                    txtTotalCost.Text = lvl_qty_takeoff.Items(i).SubItems(17).Text

                    If lvl_qty_takeoff.Items(i).SubItems(23).Text = 1 Then 'minor
                        ChkboxSub.Checked = True
                        ChkboxMain.Checked = False
                    ElseIf lvl_qty_takeoff.Items(i).SubItems(23).Text = 2 Then 'major
                        ChkboxSub.Checked = False
                        ChkboxMain.Checked = True
                        Panel_split_equi_cat.Visible = False
                        Panel_for_equipment_cat.Visible = False
                    End If
                    If lvl_qty_takeoff.Items(i).SubItems(26).Text = 1 Then 'materials
                        Panel_for_equipment_cat.Visible = False
                        Panel_split_equi_cat.Visible = False
                        Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
                        Panel_btnSave.BringToFront()
                        cmb_item_name.Focus()

                    ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 2 Then 'equipment
                        Panel_split_equi_cat.Visible = True
                        Panel_split_equi_cat.BringToFront()
                        Panel_for_equipment_cat.Visible = True
                        Panel_for_equipment_cat.BringToFront()

                        Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y + 50)

                        Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
                        Panel_btnSave.BringToFront()
                        cmb_equip_type.Visible = True
                        cmb_equip_type.BringToFront()
                        lblEquipType_ManPower.Text = "Equipment Type"
                        cmbEquipCategory.Focus()

                        '****tab index******
                        Panel_split_equi_cat.TabIndex = 12
                        cmbEquipCategory.TabIndex = 13
                        Panel_for_equipment_cat.TabIndex = 14
                        cmb_equip_type.TabIndex = 15
                        txtEquip_labor_qty.TabIndex = 16
                        txtEquip_Labor_unit.TabIndex = 17
                        txtEquip_Labor_duration.TabIndex = 18
                        txtEquip_Labor_amount.TabIndex = 19
                        Panel_btnSave.TabIndex = 20
                        btn_save.TabIndex = 21
                    ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 3 Then  'labor
                        load_db_man_power(58)
                        Panel_for_equipment_cat.Visible = True
                        Panel_for_equipment_cat.BringToFront()
                        Panel_split_equi_cat.Visible = False
                        Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y)

                        Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
                        Panel_btnSave.BringToFront()

                        cmb_equip_type.Visible = False
                        lblEquipType_ManPower.Text = "ManPower"
                        cmb_man_power.Location = New System.Drawing.Point(cmb_equip_type.Location.X, cmb_equip_type.Location.Y)
                        cmb_man_power.BringToFront()
                        cmb_man_power.Focus()

                        '***tab index*****
                        Panel_for_equipment_cat.TabIndex = 12
                        cmb_man_power.TabIndex = 13
                        txtEquip_labor_qty.TabIndex = 14
                        txtEquip_Labor_unit.TabIndex = 15
                        txtEquip_Labor_duration.TabIndex = 16
                        txtEquip_Labor_amount.TabIndex = 17
                        Panel_btnSave.TabIndex = 18
                        btn_save.TabIndex = 19
                    End If
                    Exit For
                End If
            Next
            global_vo_boolean = True
            vo_insert_edit_delele_value = "Insert"
            btn_save.Text = "Save"
        End If
    End Sub

    Private Sub CreateVariationOrder2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateVariationOrder2ToolStripMenuItem.Click
        variation_number_vo = increament_variation_number(CInt(lvl_qty_takeoff.Items(0).SubItems(25).Text)) + 1
        If MessageBox.Show("Are you want to create this to Variation Order No.: " + CStr(variation_number_vo) + " ?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            For i As Integer = 0 To lvl_qty_takeoff.Items.Count - 1
                Dim newSQ As New SQLcon
                Dim newCMD As New SqlCommand

                Try
                    newSQ.connection.Open()
                    newCMD.Connection = newSQ.connection
                    newCMD.CommandText = "proc_Quantity_takeoff"
                    newCMD.CommandType = CommandType.StoredProcedure
                    newCMD.Parameters.AddWithValue("@query", "INSERT")

                    If lvl_qty_takeoff.Items(i).SubItems(23).Text = 1 Then 'main_sub
                        If lvl_qty_takeoff.Items(i).SubItems(26).Text = 1 Then 'materials
                            ' MsgBox("main or sub   " & lvl_qty_takeoff.Items(i).SubItems(23).Text & "category id   " & lvl_qty_takeoff.Items(i).SubItems(26).Text)
                            newCMD.Parameters.AddWithValue("@variance_order", variation_number_vo)
                            newCMD.Parameters.AddWithValue("@proj_id", lvl_qty_takeoff.Items(i).SubItems(25).Text)
                            newCMD.Parameters.AddWithValue("@part_cat_id", lvl_qty_takeoff.Items(i).SubItems(33).Text)
                            newCMD.Parameters.AddWithValue("@contract_id", lvl_qty_takeoff.Items(i).SubItems(24).Text)
                            newCMD.Parameters.AddWithValue("@contract_item_desc", lvl_qty_takeoff.Items(i).SubItems(13).Text)
                            newCMD.Parameters.AddWithValue("@main_sub", 1)
                            newCMD.Parameters.AddWithValue("@category", lvl_qty_takeoff.Items(i).SubItems(26).Text)
                            newCMD.Parameters.AddWithValue("@const_unit", lvl_qty_takeoff.Items(i).SubItems(14).Text)
                            newCMD.Parameters.AddWithValue("@const_qty", CDec(lvl_qty_takeoff.Items(i).SubItems(15).Text))
                            newCMD.Parameters.AddWithValue("@const_unitCost", CDec(lvl_qty_takeoff.Items(i).SubItems(16).Text))
                            newCMD.Parameters.AddWithValue("@const_totalCost", CDec(lvl_qty_takeoff.Items(i).SubItems(17).Text))
                            newCMD.Parameters.AddWithValue("@qty_off_id", lvl_qty_takeoff.Items(i).SubItems(4).Text)
                            newCMD.Parameters.AddWithValue("@unit", lvl_qty_takeoff.Items(i).SubItems(8).Text)
                            newCMD.Parameters.AddWithValue("@qty_take_off", CDec(lvl_qty_takeoff.Items(i).SubItems(7).Text))
                            newCMD.Parameters.AddWithValue("@price", CDec(lvl_qty_takeoff.Items(i).SubItems(9).Text))
                            newCMD.Parameters.AddWithValue("@amount", CDec(lvl_qty_takeoff.Items(i).SubItems(10).Text))
                            newCMD.Parameters.AddWithValue("@vo_history", lvl_qty_takeoff.Items(i).SubItems(0).Text)
                        ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 2 Then 'equipment
                            ' MsgBox("main or sub   " & lvl_qty_takeoff.Items(i).SubItems(23).Text & "category id   " & lvl_qty_takeoff.Items(i).SubItems(26).Text)
                            newCMD.Parameters.AddWithValue("@variance_order", variation_number_vo)
                            newCMD.Parameters.AddWithValue("@proj_id", lvl_qty_takeoff.Items(i).SubItems(25).Text)
                            newCMD.Parameters.AddWithValue("@part_cat_id", lvl_qty_takeoff.Items(i).SubItems(33).Text)
                            newCMD.Parameters.AddWithValue("@contract_id", lvl_qty_takeoff.Items(i).SubItems(24).Text)
                            newCMD.Parameters.AddWithValue("@contract_item_desc", lvl_qty_takeoff.Items(i).SubItems(13).Text)
                            newCMD.Parameters.AddWithValue("@main_sub", 1)
                            newCMD.Parameters.AddWithValue("@category", lvl_qty_takeoff.Items(i).SubItems(26).Text)
                            newCMD.Parameters.AddWithValue("@const_unit", lvl_qty_takeoff.Items(i).SubItems(14).Text)
                            newCMD.Parameters.AddWithValue("@const_qty", CDec(lvl_qty_takeoff.Items(i).SubItems(15).Text))
                            newCMD.Parameters.AddWithValue("@const_unitCost", CDec(lvl_qty_takeoff.Items(i).SubItems(16).Text))
                            newCMD.Parameters.AddWithValue("@const_totalCost", CDec(lvl_qty_takeoff.Items(i).SubItems(17).Text))
                            newCMD.Parameters.AddWithValue("@equip_cat", lvl_qty_takeoff.Items(i).SubItems(31).Text)
                            newCMD.Parameters.AddWithValue("@equip_type", lvl_qty_takeoff.Items(i).SubItems(32).Text)
                            newCMD.Parameters.AddWithValue("@equip_labor_qty", CInt(lvl_qty_takeoff.Items(i).SubItems(29).Text))
                            newCMD.Parameters.AddWithValue("@unit", lvl_qty_takeoff.Items(i).SubItems(8).Text)
                            newCMD.Parameters.AddWithValue("@duration", CInt(lvl_qty_takeoff.Items(i).SubItems(30).Text))
                            newCMD.Parameters.AddWithValue("@amount", CDec(lvl_qty_takeoff.Items(i).SubItems(10).Text))
                            newCMD.Parameters.AddWithValue("@vo_history", lvl_qty_takeoff.Items(i).SubItems(0).Text)
                        ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 3 Then 'labor
                            '  MsgBox("main or sub   " & lvl_qty_takeoff.Items(i).SubItems(23).Text & "category id   " & lvl_qty_takeoff.Items(i).SubItems(26).Text)
                            newCMD.Parameters.AddWithValue("@variance_order", variation_number_vo)
                            newCMD.Parameters.AddWithValue("@proj_id", lvl_qty_takeoff.Items(i).SubItems(25).Text)
                            newCMD.Parameters.AddWithValue("@part_cat_id", lvl_qty_takeoff.Items(i).SubItems(33).Text)
                            newCMD.Parameters.AddWithValue("@contract_id", lvl_qty_takeoff.Items(i).SubItems(24).Text)
                            newCMD.Parameters.AddWithValue("@contract_item_desc", lvl_qty_takeoff.Items(i).SubItems(13).Text)
                            newCMD.Parameters.AddWithValue("@main_sub", 1)
                            newCMD.Parameters.AddWithValue("@category", lvl_qty_takeoff.Items(i).SubItems(26).Text)
                            newCMD.Parameters.AddWithValue("@const_unit", lvl_qty_takeoff.Items(i).SubItems(14).Text)
                            newCMD.Parameters.AddWithValue("@const_qty", CDec(lvl_qty_takeoff.Items(i).SubItems(15).Text))
                            newCMD.Parameters.AddWithValue("@const_unitCost", CDec(lvl_qty_takeoff.Items(i).SubItems(16).Text))
                            newCMD.Parameters.AddWithValue("@const_totalCost", CDec(lvl_qty_takeoff.Items(i).SubItems(17).Text))
                            newCMD.Parameters.AddWithValue("@man_power_id", lvl_qty_takeoff.Items(i).SubItems(36).Text)
                            newCMD.Parameters.AddWithValue("@equip_labor_qty", CInt(lvl_qty_takeoff.Items(i).SubItems(29).Text))
                            newCMD.Parameters.AddWithValue("@unit", lvl_qty_takeoff.Items(i).SubItems(8).Text)
                            newCMD.Parameters.AddWithValue("@duration", CInt(lvl_qty_takeoff.Items(i).SubItems(30).Text))
                            newCMD.Parameters.AddWithValue("@amount", CDec(lvl_qty_takeoff.Items(i).SubItems(10).Text))
                            newCMD.Parameters.AddWithValue("@vo_history", lvl_qty_takeoff.Items(i).SubItems(0).Text)
                        End If
                    ElseIf lvl_qty_takeoff.Items(i).SubItems(23).Text = 2 Then 'main
                        ' MsgBox(lvl_qty_takeoff.Items(i).SubItems(23).Text)
                        newCMD.Parameters.AddWithValue("@variance_order", variation_number_vo)
                        newCMD.Parameters.AddWithValue("@proj_id", lvl_qty_takeoff.Items(i).SubItems(25).Text)
                        newCMD.Parameters.AddWithValue("@part_cat_id", lvl_qty_takeoff.Items(i).SubItems(33).Text)
                        newCMD.Parameters.AddWithValue("@contract_id", lvl_qty_takeoff.Items(i).SubItems(24).Text)
                        newCMD.Parameters.AddWithValue("@contract_item_desc", lvl_qty_takeoff.Items(i).SubItems(13).Text)
                        newCMD.Parameters.AddWithValue("@main_sub", 2)
                        newCMD.Parameters.AddWithValue("@const_unit", lvl_qty_takeoff.Items(i).SubItems(14).Text)
                        newCMD.Parameters.AddWithValue("@const_qty", CDec(lvl_qty_takeoff.Items(i).SubItems(15).Text))
                        newCMD.Parameters.AddWithValue("@const_unitCost", CDec(lvl_qty_takeoff.Items(i).SubItems(16).Text))
                        newCMD.Parameters.AddWithValue("@const_totalCost", CDec(lvl_qty_takeoff.Items(i).SubItems(17).Text))
                        newCMD.Parameters.AddWithValue("@vo_history", lvl_qty_takeoff.Items(i).SubItems(0).Text)
                    ElseIf lvl_qty_takeoff.Items(i).SubItems(23).Text = 0 Then 'miscellaneous
                        If lvl_qty_takeoff.Items(i).SubItems(26).Text = 4 Then
                            newCMD.Parameters.AddWithValue("@variance_order", variation_number_vo)
                            newCMD.Parameters.AddWithValue("@proj_id", lvl_qty_takeoff.Items(i).SubItems(25).Text)
                            newCMD.Parameters.AddWithValue("@main_sub", 0)
                            newCMD.Parameters.AddWithValue("@category", lvl_qty_takeoff.Items(i).SubItems(26).Text)
                            newCMD.Parameters.AddWithValue("@amount", CDec(lvl_qty_takeoff.Items(i).SubItems(10).Text))
                            newCMD.Parameters.AddWithValue("@vo_history", lvl_qty_takeoff.Items(i).SubItems(0).Text)
                        End If
                    End If

                    z = newCMD.ExecuteScalar
                    ' MessageBox.Show("Successfully saved.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()
                End Try
            Next
            load_qty_for_save(variation_number_vo, lvl_qty_takeoff.Items(0).SubItems(1).Text)
            load_lvl_vo_history_to_listview()
            load_qty_takeoff_gridview_form()
        Else
            variation_number_vo = 0
        End If
    End Sub

    Private Sub DeleteItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteItemToolStripMenuItem.Click
        If gridview_excel_form.SelectedRows(0).Cells(4).Value = "" Then
            MsgBox("select to the appropriate item")
        Else
            If MessageBox.Show("Are you sure you want to Delete the data?.", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                delete_qty_takeoff(gridview_excel_form.SelectedRows(0).Cells(4).Value)
                load_qty_for_save(CInt(lvl_qty_takeoff.Items(0).SubItems(22).Text), lvl_qty_takeoff.Items(0).SubItems(1).Text)
                load_qty_takeoff_gridview_form()
            Else : Return
            End If
        End If
    End Sub

    Private Sub EditItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditItemToolStripMenuItem.Click
        If gridview_excel_form.SelectedRows(0).Cells(4).Value = "" Or gridview_excel_form.SelectedRows(0).Cells(4).Value = "*************" Then
            MsgBox("Select to the appropriate item")
        Else
            clear_field_all()  '****clear all fields
            Dim get_id As Integer = gridview_excel_form.SelectedRows(0).Cells(4).Value
            EditTools(get_id)
        End If
    End Sub

    Private Sub InsertItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertItemToolStripMenuItem.Click
        If gridview_excel_form.SelectedRows(0).Cells(4).Value = "" Then
            clear_field_all()
            txtvariance_order.Text = lvl_qty_takeoff.Items(0).SubItems(22).Text
            cmb_project.Text = lvl_qty_takeoff.Items(0).SubItems(1).Text
            txtPart_category.Focus()
        ElseIf gridview_excel_form.SelectedRows(0).Cells(4).Value = "*************" Then
            MsgBox("Select to the appropriate item")
        Else
            clear_field_all()  '****clear all fields
            Dim get_id As Integer = gridview_excel_form.SelectedRows(0).Cells(4).Value
            For i As Integer = 0 To lvl_qty_takeoff.Items.Count - 1
                If lvl_qty_takeoff.Items(i).SubItems(0).Text = get_id Then
                    txtvariance_order.Text = lvl_qty_takeoff.Items(i).SubItems(22).Text
                    cmb_project.Text = lvl_qty_takeoff.Items(i).SubItems(1).Text
                    txtPart_category.Text = lvl_qty_takeoff.Items(i).SubItems(34).Text + " - " + lvl_qty_takeoff.Items(i).SubItems(35).Text
                    cmbItem_No.Text = lvl_qty_takeoff.Items(i).SubItems(12).Text
                    cmbItemDesc.Text = lvl_qty_takeoff.Items(i).SubItems(13).Text
                    cmbCategory.Text = lvl_qty_takeoff.Items(i).SubItems(11).Text
                    cmbContract_Unit.Text = lvl_qty_takeoff.Items(i).SubItems(14).Text
                    txtContractQty.Text = lvl_qty_takeoff.Items(i).SubItems(15).Text
                    txtContractUnitCost.Text = lvl_qty_takeoff.Items(i).SubItems(16).Text
                    txtTotalCost.Text = lvl_qty_takeoff.Items(i).SubItems(17).Text

                    If lvl_qty_takeoff.Items(i).SubItems(23).Text = 1 Then 'minor
                        ChkboxSub.Checked = True
                        ChkboxMain.Checked = False
                    ElseIf lvl_qty_takeoff.Items(i).SubItems(23).Text = 2 Then 'major
                        ChkboxSub.Checked = False
                        ChkboxMain.Checked = True
                        Panel_split_equi_cat.Visible = False
                        Panel_for_equipment_cat.Visible = False
                    End If
                    If lvl_qty_takeoff.Items(i).SubItems(26).Text = 1 Then 'materials
                        Panel_for_equipment_cat.Visible = False
                        Panel_split_equi_cat.Visible = False
                        Panel_btnSave.Location = New System.Drawing.Point(txtbox_price.Location.X - 5, txtbox_price.Location.Y + 23)
                        Panel_btnSave.BringToFront()
                        cmb_item_name.Focus()

                    ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 2 Then 'equipment
                        Panel_split_equi_cat.Visible = True
                        Panel_split_equi_cat.BringToFront()
                        Panel_for_equipment_cat.Visible = True
                        Panel_for_equipment_cat.BringToFront()

                        Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y + 50)

                        Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
                        Panel_btnSave.BringToFront()
                        cmb_equip_type.Visible = True
                        cmb_equip_type.BringToFront()
                        lblEquipType_ManPower.Text = "Equipment Type"
                        cmbEquipCategory.Focus()

                        '****tab index******
                        Panel_split_equi_cat.TabIndex = 12
                        cmbEquipCategory.TabIndex = 13
                        Panel_for_equipment_cat.TabIndex = 14
                        cmb_equip_type.TabIndex = 15
                        txtEquip_labor_qty.TabIndex = 16
                        txtEquip_Labor_unit.TabIndex = 17
                        txtEquip_Labor_duration.TabIndex = 18
                        txtEquip_Labor_amount.TabIndex = 19
                        Panel_btnSave.TabIndex = 20
                        btn_save.TabIndex = 21
                    ElseIf lvl_qty_takeoff.Items(i).SubItems(26).Text = 3 Then  'labor
                        load_db_man_power(58)
                        Panel_for_equipment_cat.Visible = True
                        Panel_for_equipment_cat.BringToFront()
                        Panel_split_equi_cat.Visible = False
                        Panel_for_equipment_cat.Location = New System.Drawing.Point(Panel_split_equi_cat.Location.X, Panel_split_equi_cat.Location.Y)

                        Panel_btnSave.Location = New System.Drawing.Point(Panel_for_equipment_cat.Location.X, Panel_for_equipment_cat.Location.Y + 220)
                        Panel_btnSave.BringToFront()

                        cmb_equip_type.Visible = False
                        lblEquipType_ManPower.Text = "ManPower"
                        cmb_man_power.Location = New System.Drawing.Point(cmb_equip_type.Location.X, cmb_equip_type.Location.Y)
                        cmb_man_power.BringToFront()
                        cmb_man_power.Focus()

                        '***tab index*****
                        Panel_for_equipment_cat.TabIndex = 12
                        cmb_man_power.TabIndex = 13
                        txtEquip_labor_qty.TabIndex = 14
                        txtEquip_Labor_unit.TabIndex = 15
                        txtEquip_Labor_duration.TabIndex = 16
                        txtEquip_Labor_amount.TabIndex = 17
                        Panel_btnSave.TabIndex = 18
                        btn_save.TabIndex = 19
                    End If
                    Exit For
                End If
            Next
            'global_vo_boolean = True
            ' vo_insert_edit_delele_value = "Insert"
            btn_save.Text = "Save"
        End If
    End Sub
End Class