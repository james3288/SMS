Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports excel = Microsoft.Office.Interop.Excel
Imports System.ComponentModel
Imports OfficeOpenXml.ConditionalFormatting
Imports System.Windows.Interop
Imports OfficeOpenXml.ExcelErrorValue
Imports System.Drawing.Text
Imports CrystalDecisions.Windows.Forms

Public Class FWarehouseItems

    Dim x As Integer
    Public txtname As String
    Public SQLcon As New SQLcon
    Public sqldr As SqlDataReader
    Public da As SqlDataAdapter
    Public cmd As SqlCommand
    Dim thread As Threading.Thread
    Dim appXL As excel.Application
    Dim wbXl As excel.Workbook
    Dim shXL As excel.Worksheet
    Dim raXL As excel.Range
    Dim tor_id As Integer
    Dim inOut_id As Integer
    Dim tor_sub_id As Integer
    Dim tsp_id As Integer
    Dim y As Integer
    Dim mousex As Integer
    Dim mousey As Integer
    Dim IsFormBeingDragged As Boolean
    Dim set_item_id As Integer
    Dim set_det_id As Integer
    Dim txtbox As TextBox
    Public cIncharge_id As Integer
    Public whAreaId As Integer
    Public whAreaCategory As String = ""

    Private ListOfWarehouseItem As New List(Of Model._Mod_Warehouse_Item.Warehouse_Item_Fields)
    Private ListOfIncharge As New List(Of Model._Mod_Incharge.incharge_field)
    Private searchby, isTurnover As String
    Private search As String

    Private UISearch, UISearchBy, UISearchBy2, UIOldNewItems As New class_placeholder4

    Private customMsg As New customMessageBox
    Private whItemsModel, whInchargeModel, displayResultModel, properNamingModel, WhInchargeNewModel, EmployeeModel, AllChargesModel As New ModelNew.Model
    Dim cBgWorkerChecker, cBgWorkerDisplayResult As Timer
    Public cResult As New List(Of PropsFields.whItems_props_fields)
    Public cResult2 As New List(Of PropsFields.incharge_fields)
    Public cResult3 As New List(Of ListViewItem)

    Public cListOfListViewItem As New List(Of ListViewItem)
    Private buttonSaveTriggered As Boolean = False
    Public linkTriggered As Boolean = False
    Private cEdit As Boolean
    Public cWh_id As Integer
    Public AggregatesPricesForm As New FAggregatesPrices
    Public KPIForm As New FKeyPerformanceIndicator
    Public kpi_id As Integer
    Private Sub FWarehouseItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to clear data from textfields?", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                clear_fields()
            End If

            'clear_fields()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SAVE_UPDATE()
        End If

    End Sub

    Public Sub clear_fields()
        For Each ctr As Control In FlowLayoutPanel1.Controls
            If TypeOf ctr Is TextBox Then
                Dim txtbox As TextBox = ctr
                txtbox.Clear()
                lblSaveUpdate.Text = "Save Item"
            End If
        Next

        cmbDivision.SelectedIndex = -1
        cmbType.SelectedIndex = -1
        cmbItemSet.SelectedIndex = -1
        cmbListofSetsItem.SelectedIndex = -1
        cmbappforsets.SelectedIndex = -1
        cmbSub.Text = ""
        cmbIn.SelectedIndex = -1
        lvlItemList.Enabled = True
        'gboxSearch.Enabled = True
        lblCancel.Visible = False
        lbox.Visible = False
        txtDefaultPrice.Text = "0.00"

        wh_id = 0
        cIncharge_id = 0
        cEdit = False

        txtItemName.Focus()

    End Sub

    Private Sub txtReOrderPoint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReOrderPoint.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
           e.KeyCode = Keys.OemPeriod Or
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub txtDefaultPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDefaultPrice.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
          e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
          e.KeyCode = Keys.OemPeriod Or
         e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub txtSpecLoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSpecLoc.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox.Visible = True Then
                If lbox.Items.Count > 0 Then
                    lbox.Focus()
                    lbox.SelectedIndex = 0
                End If
            Else

            End If
        End If
    End Sub

    Private Sub txtIncharge_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIncharge.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox.Visible = True Then
                If lbox.Items.Count > 0 Then
                    lbox.Focus()
                    lbox.SelectedIndex = 0
                End If
            Else
            End If
        End If
    End Sub

    Private Sub cmbType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbType.Click
        cmbSub.SelectedIndex = -1
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            search_warehouse()
        End If
    End Sub

    Private Sub txtField_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemName.Leave, txtWhClass.Leave, txtWarehouseArea.Leave, txtSpecLoc.Leave,
     txtIncharge.Leave, txtUnit.Leave, txtReOrderPoint.Leave, txtDefaultPrice.Leave, cmbType.Leave, cmbSub.Leave, cmbIn.Leave, txtDesc.Leave, cmbDivision.Leave

        sender.backcolor = Color.White

        'If txtSpecLoc.Left = True Then
        '    lbox.Visible = False
        'ElseIf txtIncharge.Left Then
        '    lbox.Visible = False
        'End If

    End Sub
    'GIBSON'
    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemName.GotFocus, txtDesc.GotFocus, txtWhClass.GotFocus, txtWarehouseArea.GotFocus, txtSpecLoc.GotFocus,
     txtIncharge.GotFocus, txtUnit.GotFocus, txtReOrderPoint.GotFocus, txtDefaultPrice.GotFocus, cmbType.GotFocus, cmbSub.GotFocus, cmbIn.GotFocus, cmbDivision.GotFocus

        lbox.Visible = False
        If txtSpecLoc.Focused Then
            txtname = txtSpecLoc.Name
            txtSpecLoc.SelectAll()
        ElseIf txtIncharge.Focused Then
            txtname = txtIncharge.Name
            txtIncharge.SelectAll()
        ElseIf txtItemName.Focused Then
            txtname = txtItemName.Name
            txtItemName.SelectAll()
        ElseIf txtDesc.Focused Then
            txtname = txtDesc.Name
            txtDesc.SelectAll()
        End If
        sender.backcolor = Color.Yellow

    End Sub
#Region "Dragable Form"
    Private Sub FCashVoucher_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub FCashVoucher_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - mousex)
            temp.Y = Me.Location.Y + (e.Y - mousey)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub FCashVoucher_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

#End Region
    Private Sub FWarehouseItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TableLayoutPanel1.Dock = DockStyle.Fill

        Panel1.Visible = False
        lbox.Location = New Point(1000, 1000)

        lblSaveUpdate.Parent = pboxSaveTrans
        lblSaveUpdate.BringToFront()
        lblSaveUpdate.Location = New Point(50, 10)
        Label8.Parent = pboxSaveTrans
        Label8.BringToFront()
        Label8.Location = New Point(148, 13)

        ' Label15.Parent = pboxHeader
        lblCancel.Visible = False
        txtWarehouseArea.Enabled = False
        txtWhClass.Enabled = False

        pboxHeader.Width = FMain.Width - FMain.ToolStrip1.Width

        btnImport.Location = New Point(10000, 10000)

        'btnSearch1.Location = New Point(500, lvlItemList.Height + 90)
        'lblSearch.Location = New Point(525, lvlItemList.Height + 100)
        'txtSearch1.Location = New Point(255, lvlItemList.Height + 92)

        'gboxSearch.Location = New Point(260, lvlItemList.Height + 85)
        'txtSearch.Location = New Point(lvlItemList.Width, 1000)

        'view_warehouesItems()
        ' clear_fields()
        'search_warehouse()



        load_request_type(1, cmbType)

        'sets items
        set_item.add_data_on_combobox(cmbItemSet)

        formOpened()


        'USER INTERFACE
        UISearch.king_placeholder_textbox("Search Item Here...", txtSearch, Nothing, Panel9, My.Resources.received, False, "White", "")
        UISearchBy.king_placeholder_combobox("Search By", cmbSearch, Nothing, Panel9, My.Resources.received, "White", "")
        UISearchBy2.king_placeholder_combobox("Search By 2", cmbSearchReturn, Nothing, Panel9, My.Resources.received, "White", "")
        ' UIOldNewItems.king_placeholder_combobox("Items Option", cmbItemsOption, Nothing, Panel9, My.Resources.received, "White", "")
        btnSearch.BackColor = ColorTranslator.FromHtml("#2B7C92")
        PictureBox3.BackColor = ColorTranslator.FromHtml("#D4836D")
        Me.BackColor = ColorTranslator.FromHtml("#1A1E26")



        loadWhItems()
    End Sub
    Public Sub load_list_of_sets_item(set_item_id As Integer)
        cmbListofSetsItem.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String

        Try
            newSQ.connection.Open()
            query = "SELECT * FROM dbSet_Details WHERE set_item_id = '" & set_item_id & "'"

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmbListofSetsItem.Items.Add(newDR.Item("sub_details").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub load_request_type(ByVal n As Integer, ByVal cmbbox As ComboBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        cmbbox.Items.Clear()

        newSQ.connection.Open()

        Try
            If n = 1 Then
                query = "SELECT tor_desc FROM dbType_of_Request"
            ElseIf n = 2 Then
                query = "SELECT tor_sub_desc FROM dbType_of_Request_sub WHERE tor_id = " & tor_id
            End If

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 1 Then
                    cmbType.Items.Add(newDR.Item("tor_desc").ToString)
                ElseIf n = 2 Then
                    cmbSub.Items.Add(newDR.Item("tor_sub_desc").ToString)
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        FImportsWarehouseItems.ShowDialog()
    End Sub

    Public Sub view_warehouesItems()
        lvlItemList.Items.Clear()

        Try

            SQLcon.connection.Open()
            Dim query As String = "SELECT * FROM dbwarehouse_items"
            cmd = New SqlCommand(query, SQLcon.connection)
            sqldr = cmd.ExecuteReader

            While sqldr.Read
                Dim a(12) As String

                a(0) = sqldr.Item(0).ToString
                a(1) = sqldr.Item(1).ToString
                a(2) = sqldr.Item(2).ToString
                a(3) = sqldr.Item(3).ToString
                a(4) = sqldr.Item(10).ToString
                a(5) = sqldr.Item(4).ToString
                a(6) = sqldr.Item(5).ToString
                a(7) = sqldr.Item(6).ToString
                a(8) = sqldr.Item(7).ToString
                a(9) = FormatNumber(sqldr.Item(8).ToString, 2, , , TriState.True)
                a(10) = sqldr.Item(9).ToString

                If sqldr.Item(8).ToString = Nothing Or sqldr.Item(7).ToString = "0" Then
                    a(8) = 0
                Else
                    Dim value As String = CInt(sqldr.Item(7).ToString)
                    a(8) = value
                End If

                Dim lvl As New ListViewItem(a)
                lvlItemList.Items.Add(lvl)

            End While

            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
        clear_fields()
        lblSaveUpdate.Text = "Save Item"
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        lbox.Visible = False
        FWarehouseClassification.ShowDialog()
    End Sub

#Region "GUI"
    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

#End Region

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'search_item_name(txtSearch1.Text)
    End Sub

    Public Function search_item_name(ByVal val As String)
        lvlItemList.Items.Clear()

        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_get_data_from_warehouse", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@search", val)

            sqldr = cmd.ExecuteReader
            Dim a(10) As String

            While sqldr.Read
                a(0) = sqldr.Item("wh_id").ToString
                a(1) = sqldr.Item("whItem").ToString
                a(2) = sqldr.Item("whItemDesc").ToString
                a(3) = sqldr.Item("whClass").ToString
                a(4) = sqldr.Item("whArea").ToString
                a(5) = sqldr.Item("whSpecificLoc").ToString
                a(6) = sqldr.Item("whIncharge").ToString
                a(7) = sqldr.Item("whReorderPoint").ToString
                a(9) = sqldr.Item("unit").ToString

                If sqldr.Item("default_price").ToString = Nothing Or sqldr.Item("default_price").ToString = "0" Then
                    a(8) = 0
                Else
                    Dim value As String = FormatNumber(sqldr.Item("default_price").ToString, 2, , , TriState.True)
                    a(8) = value
                End If

                Dim lvl As New ListViewItem(a)
                lvlItemList.Items.Add(lvl)

            End While

            sqldr.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click



    End Sub
    Public Sub load_item_set_and_list_of_sets_item(ByVal x As Integer)
        Try
            SQLcon.connection.Open()

            cmd = New SqlCommand("proc_get_data_from_warehouse", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", 15)
            cmd.Parameters.AddWithValue("@wh_id", x)

            sqldr = cmd.ExecuteReader
            Dim a(12) As String

            While sqldr.Read
                cmbItemSet.Text = sqldr.Item("set_items").ToString
                cmbListofSetsItem.Text = sqldr.Item("sub_details").ToString
            End While

            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub pboxSaveTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxSaveTrans.Click, lblSaveUpdate.Click, Label8.Click


        'SAVE_UPDATE()
        saveUpdate()
    End Sub

    Private Sub saveUpdate()

        Try
            inOut_id = get_inout_id()
            tor_sub_id = get_tor_sub_id()
            tsp_id = getTspId()

#Region "FILTER FIELDS"
            If cmbDivision.Text = "" Then
                customMsg.message("error", "Please select a division first...", "SUPPLY INFO:")
                Exit Sub
            End If

            If txtItemName.Text = "" Or txtWhClass.Text = "" Or txtReOrderPoint.Text = "" Or txtDefaultPrice.Text = "" Or
               txtSpecLoc.Text = "" Or txtUnit.Text = "" Or txtWarehouseArea.Text = "" Then
                customMsg.message("error", "Fill-up all fields...", "SUPPLY INFO:")
                Exit Sub
            End If
#End Region

            Dim proceed As Boolean

#Region "Check Item name and item desc. exist"
            If Not cEdit = True Then
                If getWhId(txtItemName.Text, txtDesc.Text) > 0 Then
                    If customMsg.messageYesNo("Item name and item description already exists, still want to proceed?", "SUPPLY INFO:", MessageBoxIcon.Warning) Then
                        proceed = True
                    End If
                Else
                    proceed = True
                End If
            Else
                proceed = True
            End If

#End Region

            If proceed = True Then
                Dim properNamingId As Integer = checkProperNamingId(txtItemName.Text, txtDesc.Text)
                Dim cc As New ColumnValuesObj

                cc.add("whItem", txtItemName.Text)
                cc.add("whItemDesc", txtDesc.Text)
                cc.add("whClass", txtWhClass.Text)
                cc.add("whArea_category", whAreaCategory)
                cc.add("whArea", whAreaId)
                cc.add("whSpecificLoc", txtSpecLoc.Text)
                cc.add("whIncharge", txtIncharge.Text)
                cc.add("whReorderPoint", txtReOrderPoint.Text)
                cc.add("default_price", txtDefaultPrice.Text)
                cc.add("unit", txtUnit.Text)
                cc.add("typeOfItem", "")
                cc.add("tsp_id", tsp_id)
                cc.add("set_det_id", set_det_id)
                cc.add("division", cmbDivision.Text)
                cc.add("turnover", cmbTurnover.Text)
                cc.add("incharge_id", cIncharge_id)
                cc.add("wh_pn_id", properNamingId)
                cc.add("kpi_id", kpi_id)

                If cEdit = True Then
#Region "UPDATE"

                    'cWh_id = cc.insertQuery_and_return_id("dbwarehouse_items")/
                    cc.setCondition($"wh_id = {cWh_id}")
                    cc.updateQuery("dbwarehouse_items")

                    buttonSaveTriggered = True

                    If cWh_id > 0 Then
                        customMsg.message("info", "Successfully updated...", "SUPPLY INFO:")
                    End If
#End Region

                Else
#Region "SAVE"

                    cWh_id = cc.insertQuery_and_return_id("dbwarehouse_items")
                    buttonSaveTriggered = True

                    If cWh_id > 0 Then
                        customMsg.message("info", "Successfully saved...", "SUPPLY INFO:")
                    End If
#End Region

                End If

                cmbSearch.Text = cSearchBy.SEARCH_BY_ITEM_DESC
                txtSearch.Text = txtDesc.Text

                clear_fields()
                loadWhItems()
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


    Public Sub SAVE_UPDATE()

        'check proper naming if set
        Dim properNamingId As Integer = checkProperNamingId(txtItemName.Text, txtDesc.Text)

        If properNamingId = 0 Then
            customMsg.message("error", "you must select a proper naming...", "SUPPLY INFO:")
            Exit Sub

        End If

        lbox.Visible = False
        If lblSaveUpdate.Text = "Save Item" Then

            If cmbDivision.Text = "" Then
                MessageBox.Show("Please select a division first...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If txtItemName.Text = "" Or txtWhClass.Text = "" Or txtReOrderPoint.Text = "" Or txtDefaultPrice.Text = "" Or
               txtSpecLoc.Text = "" Or txtUnit.Text = "" Or txtWarehouseArea.Text = "" Then
                MessageBox.Show("Fill-up all fields", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If if_wh_item_desc_exist(txtItemName.Text, txtDesc.Text) > 0 Then
                    If MessageBox.Show("Item name and item description already exists, still want to proceed?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        'save_item()
                        save_update_warehouse_item(112)
                        createItemImageFile(searchItemID(txtItemName.Text, txtDesc.Text))
                        'search_warehouse()
                        'listfocus(lvlItemList, y)

                    Else
                        Return
                    End If

                Else
                    save_update_warehouse_item(112)
                    createItemImageFile(searchItemID(txtItemName.Text, txtDesc.Text))

                    'search_warehouse()
                    'listfocus(lvlItemList, y)
                    clear_fields()
                End If
            End If
        ElseIf lblSaveUpdate.Text = "Update Item" Then
            Dim ex = MessageBox.Show("Are you sure you want to Update the Selected Item?", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If ex = Windows.Forms.DialogResult.Yes Then
                save_update_warehouse_item(113)
                updateItemImageFile(searchItemID(txtItemName.Text, txtDesc.Text))
                clear_fields()

                'lvlItemList.Focus()
                'search_warehouse()
                '' view_warehouesItems()
                'listfocus(lvlItemList, x)

            Else
            End If
        End If
    End Sub

    Public Sub clear_all()
        txtItemName.Text = ""
        txtWhClass.Text = ""
        txtWarehouseArea.Text = ""
        txtSpecLoc.Text = ""
        txtIncharge.Text = ""
        txtReOrderPoint.Text = ""
        txtDefaultPrice.Text = ""
        txtUnit.Text = ""
        lblSaveUpdate.Text = "Save Item"
    End Sub

    Public Sub save_item()
        inOut_id = get_inout_id()
        tor_sub_id = get_tor_sub_id()
        tsp_id = get_tsp_id()

        If cmbappforsets.Text = "YES" Then
            set_det_id = get_set_det_id(set_item_id, cmbListofSetsItem.Text)
        ElseIf cmbappforsets.Text = "NO" Then
            set_det_id = 0
        End If

        'Try
        '    SQLcon.connection.Open()

        '    Dim wh_area_id As Integer = get_id("dbwh_area", "wh_area", txtWarehouseArea.Text, 0)

        '    publicquery = "SET NOCOUNT ON INSERT INTO dbwarehouse_items(whItem,whItemDesc,whClass,whArea,whSpecificLoc,whIncharge,whReorderPoint,default_price,unit,typeOfItem,tsp_id,set_det_id,division,turnover)"
        '    publicquery &= " VALUES('" & txtItemName.Text & "', '" & txtDesc.Text & "','" & txtWhClass.Text & "', '" & wh_area_id & "', '" & txtSpecLoc.Text & "','"
        '    publicquery &= txtIncharge.Text & "', '" & txtReOrderPoint.Text & "', '" & txtDefaultPrice.Text & "', '" & txtUnit.Text & "', '" & cmbType.Text & "','" & tsp_id & "','" & set_det_id & "','" & cmbDivision.Text & "','" & cmbTurnover.Text & "' Select SCOPE_IDENTITY()"
        '    cmd = New SqlCommand(publicquery, SQLcon.connection)
        '    y = cmd.ExecuteScalar

        '    MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception
        '    MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    SQLcon.connection.Close()
        'End Try


        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Dim wh_area_id As Integer = get_id("dbwh_area", "wh_area", txtWarehouseArea.Text, 0)

            newCMD.Parameters.AddWithValue("@n", 112)
            newCMD.Parameters.AddWithValue("@wh_item", txtItemName.Text)
            newCMD.Parameters.AddWithValue("@wh_desc", txtDesc.Text)
            newCMD.Parameters.AddWithValue("@wh_class", txtWhClass.Text)
            newCMD.Parameters.AddWithValue("@wh_area_id", wh_area_id)
            newCMD.Parameters.AddWithValue("@wh_specific_loc", txtSpecLoc.Text)
            newCMD.Parameters.AddWithValue("@wh_incharge", txtIncharge.Text)
            newCMD.Parameters.AddWithValue("@wh_reorder_point", txtReOrderPoint.Text)
            newCMD.Parameters.AddWithValue("@wh_default_price", txtDefaultPrice.Text)
            newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
            newCMD.Parameters.AddWithValue("@type_of_item", cmbTypeItem.Text)
            newCMD.Parameters.AddWithValue("@tsp_id", tsp_id)
            newCMD.Parameters.AddWithValue("@set_det_id", set_det_id)
            newCMD.Parameters.AddWithValue("@division", cmbDivision.Text)
            newCMD.Parameters.AddWithValue("@turnover", cmbTurnover.Text)

            Dim exec As Integer = newCMD.ExecuteScalar()

            If exec > 0 Then
                MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("There is something wrong with your query...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Sub

    Public Sub save_update_warehouse_item(n As Integer)
        inOut_id = get_inout_id()
        tor_sub_id = get_tor_sub_id()
        tsp_id = get_tsp_id()

        If cmbappforsets.Text = "YES" Then
            set_det_id = get_set_det_id(set_item_id, cmbListofSetsItem.Text)
        ElseIf cmbappforsets.Text = "NO" Then
            set_det_id = 0
        End If

        'Try
        '    SQLcon.connection.Open()

        '    Dim wh_area_id As Integer = get_id("dbwh_area", "wh_area", txtWarehouseArea.Text, 0)

        '    publicquery = "SET NOCOUNT ON INSERT INTO dbwarehouse_items(whItem,whItemDesc,whClass,whArea,whSpecificLoc,whIncharge,whReorderPoint,default_price,unit,typeOfItem,tsp_id,set_det_id,division,turnover)"
        '    publicquery &= " VALUES('" & txtItemName.Text & "', '" & txtDesc.Text & "','" & txtWhClass.Text & "', '" & wh_area_id & "', '" & txtSpecLoc.Text & "','"
        '    publicquery &= txtIncharge.Text & "', '" & txtReOrderPoint.Text & "', '" & txtDefaultPrice.Text & "', '" & txtUnit.Text & "', '" & cmbType.Text & "','" & tsp_id & "','" & set_det_id & "','" & cmbDivision.Text & "','" & cmbTurnover.Text & "' Select SCOPE_IDENTITY()"
        '    cmd = New SqlCommand(publicquery, SQLcon.connection)
        '    y = cmd.ExecuteScalar

        '    MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception
        '    MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    SQLcon.connection.Close()
        'End Try

        Dim properNamingId As Integer = checkProperNamingId(txtItemName.Text, txtDesc.Text)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_data_from_warehouse", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Dim wh_area_id As Integer = get_id("dbwh_area", "wh_area", txtWarehouseArea.Text, 0)

            Select Case n
                Case 112
                    newCMD.Parameters.AddWithValue("@n", 112)
                Case 113
                    newCMD.Parameters.AddWithValue("@n", 1113)
            End Select

            newCMD.Parameters.AddWithValue("@wh_item", txtItemName.Text)
            newCMD.Parameters.AddWithValue("@wh_desc", txtDesc.Text)
            newCMD.Parameters.AddWithValue("@wh_class", txtWhClass.Text)
            newCMD.Parameters.AddWithValue("@wh_area_id", wh_area_id)
            newCMD.Parameters.AddWithValue("@wh_specific_loc", txtSpecLoc.Text)
            newCMD.Parameters.AddWithValue("@wh_incharge", txtIncharge.Text)
            newCMD.Parameters.AddWithValue("@wh_reorder_point", CDbl(txtReOrderPoint.Text))
            newCMD.Parameters.AddWithValue("@wh_default_price", CDbl(txtDefaultPrice.Text))
            newCMD.Parameters.AddWithValue("@unit", txtUnit.Text)
            newCMD.Parameters.AddWithValue("@type_of_item", cmbTypeItem.Text)
            newCMD.Parameters.AddWithValue("@tsp_id", tsp_id)
            newCMD.Parameters.AddWithValue("@set_det_id", set_det_id)
            newCMD.Parameters.AddWithValue("@division", cmbDivision.Text)
            newCMD.Parameters.AddWithValue("@turnover", cmbTurnover.Text)
            newCMD.Parameters.AddWithValue("@incharge_id", cIncharge_id)
            newCMD.Parameters.AddWithValue("@wh_pn_id", properNamingId)


            Select Case n
                Case 112
                    Dim exec As Integer = newCMD.ExecuteScalar()


                    cWh_id = exec '<== public wh_id

                    If exec > 0 Then
                        MessageBox.Show("Successfully Saved...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        buttonSaveTriggered = True
                    Else
                        MessageBox.Show("There is something wrong with your query...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        buttonSaveTriggered = False
                    End If

                    search_warehouse()

                    listfocus(lvlItemList, exec)

                Case 113
                    Dim wh_id As Integer = IIf(lvlItemList.SelectedItems(0).Text = "", 0, lvlItemList.SelectedItems(0).Text)
                    Dim exec As Integer = wh_id

                    cWh_id = exec '<== public wh_id

                    newCMD.Parameters.AddWithValue("@wh_id", wh_id)
                    newCMD.ExecuteNonQuery()

                    search_warehouse()

                    listfocus(lvlItemList, exec)

                    MessageBox.Show("Successfully updated...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    buttonSaveTriggered = True
            End Select


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function get_set_det_id(ByVal x As Integer, ByVal y As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        Try
            newSQ.connection.Open()
            query = "SELECT set_det_id FROM dbSet_Details WHERE set_item_id = '" & x & "' and sub_details = '" & y & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_set_det_id = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_inout_id()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        newSQ.connection.Open()

        Try
            query = "SELECT inout_id FROM dbinout WHERE in_out_desc = '" & cmbIn.Text & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_inout_id = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_tor_sub_id()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        newSQ.connection.Open()
        Try
            query = "SELECT tor_sub_id FROM dbType_of_Request_sub WHERE tor_sub_desc='" & cmbSub.Text & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_tor_sub_id = newDR.Item(0).ToString
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function get_tsp_id()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        newSQ.connection.Open()
        Try
            query = "SELECT tsp_id FROM dbtor_sub_property WHERE tor_sub_id = '" & tor_sub_id & "' AND inout_id = '" & inOut_id & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_tsp_id = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Function getTspId() As Integer
        Try
            Dim cc As New ColumnValuesObj
            cc.addColumn("a.tsp_id")
            cc.setCondition($"a.tor_sub_id = '{get_tor_sub_id()}' and a.inout_id = '{get_inout_id()}'")
            Dim datas = cc.selectQuery_and_return_data("dbtor_sub_property", False, "a", cTableNameType.supply_table)

            If datas.count > 0 Then
                getTspId = CType(datas(0)("tsp_id"), Integer)
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getWhId(iteName As String, itemDesc As String) As Integer
        Try
            Dim cc As New ColumnValuesObj
            cc.addColumn("a.wh_id")
            cc.setCondition($"a.whItem = '{iteName}' and a.whItemDesc = '{itemDesc}'")
            Dim datas = cc.selectQuery_and_return_data("dbwarehouse_items", False, "a", cTableNameType.supply_table)

            If datas.count > 0 Then
                getWhId = CType(datas(0)("wh_id"), Integer)
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function if_wh_item_desc_exist(ByVal whItemName As String, ByVal whItemDesc As String) As Integer
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items WHERE whItem = '" & whItemName & "' AND whItemDesc = '" & whItemDesc & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                if_wh_item_desc_exist += 1
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function

    Public Sub update_item()
        Dim wh_area_id As Integer = get_id("dbwh_area", "wh_area", txtWarehouseArea.Text, 0)
        inOut_id = get_inout_id()
        tor_sub_id = get_tor_sub_id()
        tsp_id = get_tsp_id()

        If cmbappforsets.Text = "YES" Then
            set_det_id = get_set_det_id(set_item_id, cmbListofSetsItem.Text)
        ElseIf cmbappforsets.Text = "NO" Then
            set_det_id = 0

        End If

        Try
            SQLcon.connection.Open()
            publicquery = "UPDATE dbwarehouse_items SET whItem = '" & txtItemName.Text & "',whItemDesc = '" & txtDesc.Text & "',whClass = '" & txtWhClass.Text & "',whArea = '" & wh_area_id & "',whSpecificLoc = '" & txtSpecLoc.Text & "',whIncharge = '" & txtIncharge.Text & "',whReorderPoint = '" & txtReOrderPoint.Text & "',default_price = '" & txtDefaultPrice.Text & "',unit = '" & txtUnit.Text & "', typeOfItem = '" & cmbType.Text & "', tsp_id = '" & tsp_id & "', set_det_id = '" & set_det_id & "', division = '" & cmbDivision.Text & ", turnover = '" & cmbTurnover.Text & "' WHERE wh_id = " & wh_id
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            x = wh_id
            cmd.ExecuteNonQuery()

            MessageBox.Show("Successfully Updated...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub

    Private Sub cmsUpdate_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsUpdate.Opening


        For Each item As ToolStripItem In cmsUpdate.Items
            If lvlItemList.SelectedItems.Count > 0 Then
                item.Enabled = True
            Else
                item.Enabled = False
            End If
        Next

        'exempted to disable
        ImportExcelToSQLToolStripMenuItem.Enabled = True
        ViewProperNamingToolStripMenuItem.Enabled = True
    End Sub
    'GIBSON
    Private Sub lvlItemList_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lbox.Visible = False
    End Sub

    Private Sub lvlItemList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is TextBox Then
                    If ctr.Name = txtname Then
                        clear_fields()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("are you sure you want to delete the selected item?" & vbCrLf & "RS,PO transaction and etc will be affected..." & vbCrLf & "Be sure about deleting.", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ex = MsgBoxResult.Yes Then

            For Each row As ListViewItem In lvlItemList.Items
                If row.Selected = True Then
                    delete_warehouseItem(CInt(row.Text))
                    Results.cResult = Results.cResult.Where(Function(x) Not x.wh_id = CInt(row.Text)).ToList()
                    row.Remove()
                End If
            Next

            'MessageBox.Show("Successfully Deleted...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
        End If
    End Sub

    Public Sub delete_warehouseItem(ByVal parse_wh_id As Integer)
        Try

            SQLcon.connection.Open()
            publicquery = "DELETE FROM dbwarehouse_items WHERE wh_id = '" & parse_wh_id & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

        ' view_warehouesItems()

    End Sub

    Private Sub PictureBox7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

        If customMsg.messageYesNo("YES: for Stockpile/Warehouse Area" & vbCrLf & "NO: for Project Sites and Others", "SUPPLY INFO:") Then
            lbox.Visible = False

            'target_location_project = Me.Name.ToUpper()
            'FWarehouseArea.isFromWareHouse_link_whs_btn = True
            'FWarehouseArea.ShowDialog()
            With FWarehouseAreaNew
                .isFromWarehouseItem = True
                .ShowDialog()
            End With
        Else
            With FCharge_To
                charge_to_selection = 2
                .forStockpileLocation = True
                .ShowDialog()
            End With

        End If



    End Sub

    Public Sub txtPlateNo_clear(ByVal a As Object)
        lbox.Items.Clear()
        lbox.Visible = True
        a.Focus()
    End Sub

    Private Sub txtSpecLoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSpecLoc.TextChanged

        lbox.Location = New Point(txtSpecLoc.Bounds.Left + 5, txtSpecLoc.Bounds.Bottom + 42)
        lbox.Parent = Me
        lbox.BringToFront()

        If txtSpecLoc.Focus = True Then
            lbox.Visible = True
            list_box(0)
        End If

    End Sub

    Public Function if_wh_class_exist(ByVal whclass As String) As Integer
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items WHERE whSpecificLoc = '" & whclass & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                if_wh_class_exist += 1
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()

        End Try
    End Function


    Private Function list_box(ByVal n As Integer)
        lbox.Items.Clear()
        Dim counter As Integer = 0
        Try
            SQLcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_wh_items_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If n = 0 Then
                cmd.Parameters.AddWithValue("@txtSpecLoc", txtSpecLoc.Text)
                cmd.Parameters.AddWithValue("@crud", "1")
            ElseIf n = 1 Then
                cmd.Parameters.AddWithValue("@txtIncharge", txtIncharge.Text)
                cmd.Parameters.AddWithValue("@crud", "2")
            End If
            dr = cmd.ExecuteReader
            While dr.Read
                If n = 0 Then
                    Dim whSpecificLoc As String = dr.Item("whSpecificLoc").ToString
                    lbox.Items.Add(whSpecificLoc)
                    counter += 1
                ElseIf n = 1 Then
                    Dim whIncharge As String = dr.Item("whIncharge").ToString
                    lbox.Items.Add(whIncharge)
                    counter += 1
                End If

            End While

            If counter = 0 Then
                lbox.Visible = False
            Else
                lbox.Visible = True
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Private Sub lbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox.DoubleClick
        If lbox.SelectedItems.Count > 0 Then
            For Each ctr As Control In FlowLayoutPanel1.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox.Visible = False
        Else
            MessageBox.Show("Pls select data", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtIncharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncharge.TextChanged

        lbox.Location = New Point(txtIncharge.Location.X, txtIncharge.Location.Y + 26)
        If txtIncharge.Focus = True Then
            lbox.Visible = True
            list_box(1)
        End If
    End Sub

    Private Sub lbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox.KeyDown

        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In FlowLayoutPanel1.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox.Visible = False
        End If

        If lbox.SelectedIndex = 0 Then
            If e.KeyCode = Keys.Up Then
                txtbox.Focus()
            End If
        End If
    End Sub

    Public Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        ''search_warehouse()

        ''search_warehouse1()
        ''load_incharge()

        'searchby = cmbSearch.Text

        ''filter the searching
        'Select Case cmbSearch.Text
        '    Case "Search by Warehouse Incharge"
        '        search = ""
        '    Case "Search by Disabled Item"
        '        search = IIf(txtSearch.Text.ToLower() = UISearch.placeHolder.ToLower(), "", txtSearch.Text)
        '    Case Else
        '        search = txtSearch.Text
        'End Select

        ''search = IIf(cmbSearch.Text = "Search by Warehouse Incharge", "", txtSearch.Text)

        'lvlItemList.Items.Clear()

        'BW_proccess_data.WorkerSupportsCancellation = True
        'BW_proccess_data.RunWorkerAsync()

        lvlItemList.Items.Clear()
        loadingPanel.Visible = True
        search = txtSearch.Text
        searchby = cmbSearch.Text
        isTurnover = cmbSearchReturn.Text
        WhInchargeNewModel.clearParameter()

        Dim cv3 As New ColumnValues
        cv3.add("crud", "8")

        _initializing(cCol.forWhInchargeNew,
                      cv3.getValues(),
                      WhInchargeNewModel,
                      WhItemsBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDoneLoadIncharge, WhItemsBgWorker)

    End Sub

    Private Sub SuccessfullyDoneLoadIncharge()
        Try
            Results.rListOfIncharge = TryCast(WhInchargeNewModel.cData, List(Of PropsFields.inchargeNew_fields))

            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Public Sub loadWhItems()
        cListOfListViewItem.Clear()
        whItemsModel.clearParameter()
        whInchargeModel.clearParameter()
        properNamingModel.clearParameter()
        WhInchargeNewModel.clearParameter()
        EmployeeModel.clearParameter()
        AllChargesModel.clearParameter()

        loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)
        Dim cv3 As New ColumnValues
        cv3.add("crud", "8")


        _initializing(cCol.forWhItems,
                      values,
                      whItemsModel,
                      WhItemsBgWorker)

        _initializing(cCol.forWhIncharge,
                      values,
                      whInchargeModel,
                      WhItemsBgWorker)

        _initializing(cCol.forWhItem_ProperNames,
                      values,
                      properNamingModel,
                      WhItemsBgWorker)

        _initializing(cCol.forWhInchargeNew,
                      cv3.getValues(),
                      WhInchargeNewModel,
                      WhItemsBgWorker)

        _initializing(cCol.forEmployeeData,
                      cv3.getValues(),
                      EmployeeModel,
                      WhItemsBgWorker)

        _initializing(cCol.forAllCharges,
                        cv3.getValues(),
                        AllChargesModel,
                        WhItemsBgWorker)


        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, WhItemsBgWorker)

    End Sub

    Private Sub SuccessfullyDone()

        Results.cResult = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
        Results.cResult2 = TryCast(whInchargeModel.cData, List(Of PropsFields.incharge_fields))
        Results.rListOfIncharge = TryCast(WhInchargeNewModel.cData, List(Of PropsFields.inchargeNew_fields))
        Results.cListOfEmployees = TryCast(EmployeeModel.cData, List(Of PropsFields.employee_props_fields))
        Results.cListOfProperNaming = TryCast(properNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
        Results.rListOfAllCharges = TryCast(AllChargesModel.cData, List(Of PropsFields.AllCharges))

        If buttonSaveTriggered Or linkTriggered Then
            btnSearch.PerformClick()
        End If

        loadingPanel.Visible = False
        buttonSaveTriggered = False
        linkTriggered = False

    End Sub

    Private Sub displayResult()

        cListOfListViewItem.Clear()

        'Dim initData = From Wh_Item In Results.cResult
        '               Group Join Incharge In Results.cResult2
        '               On Wh_Item.incharge_id Equals Incharge.incharge_id
        '               Into WhItem_InchargeGroup = Group
        '               From final In WhItem_InchargeGroup.DefaultIfEmpty()
        '               Select
        '                     Wh_Item.wh_id,
        '                       Wh_Item.item_name,
        '                       Wh_Item.item_desc,
        '                       Wh_Item.classification,
        '                       Wh_Item.type_of_item,
        '                       Wh_Item.warehouse_area,
        '                       Wh_Item.specific_loc,
        '                       Wh_Item.incharge,
        '                       Wh_Item.reorder_point,
        '                       Wh_Item.default_price,
        '                       Wh_Item.units,
        '                       Wh_Item.inout,
        '                       Wh_Item.set_det_id,
        '                       Wh_Item.division,
        '                       Wh_Item.Turnover,
        '                       final?.firstname,
        '                       final?.lastname,
        '                       Wh_Item.incharge_id,
        '                       Wh_Item.disable,
        '                       Wh_Item.proper_item_name,
        '                       Wh_Item.proper_item_desc,
        '                       Wh_Item.wh_pn_id,
        '                       Wh_Item.quarry,
        '                       Wh_Item.wh_area_id,
        '                       Wh_Item.whArea_category



        'Dim dataResult As New Object

        Dim initData = Utilities.getFinalData()
        Dim dataResult As New List(Of PropsFields.whItemsFinal)


        Select Case searchby
            Case cSearchBy.SEARCH_BY_ITEM_NAME
                dataResult = initData.Where(Function(x) x.item_name.ToUpper().Contains(search.ToUpper())).ToList()

            Case cSearchBy.SEARCH_BY_ITEM_DESC
                dataResult = initData.Where(Function(x)
                                                Return $"{x.item_desc}{Utilities.formatProperNames(x.proper_item_name, x.proper_item_desc, x.wh_pn_id)}".
                                                ToUpper().
                                                Contains(search.ToUpper())
                                            End Function).ToList()

            Case cSearchBy.SEARCH_BY_SPECIFIC_LOC
                dataResult = initData.Where(Function(x) x.specific_loc.ToUpper().Contains(search.ToUpper())).ToList()

            Case cSearchBy.SEARCH_BY_WAREHOUSE_AREA
                dataResult = initData.Where(Function(x) x.warehouse_area.ToUpper().Contains(search.ToUpper())).ToList()

            Case cSearchBy.SEARCH_BY_RETURNED_ITEM
                dataResult = initData.Where(Function(x) x.Turnover.ToUpper().Contains(isTurnover.ToUpper())).ToList()

            Case cSearchBy.SEARCH_BY_WAREHOUSE_INCHARGE
                dataResult = initData.Where(Function(x)
                                                Dim fname As String = IIf(IsNothing(x.firstname), "", x.firstname)
                                                Dim lname As String = IIf(IsNothing(x.lastname), "", x.lastname)

                                                Dim inchargeNew As String = Utilities.getWhIncharge(x.wh_area_id, Results.rListOfIncharge)

                                                'Dim incharge As String = $"{x.incharge.ToUpper()} {fname}, {lname}"
                                                Return inchargeNew.Contains(search.ToUpper())
                                            End Function).ToList()

            Case cSearchBy.SEARCH_BY_DISABLED_ITEM
                dataResult = initData.Where(Function(x) x.disable = 1).ToList()

            Case cSearchBy.SEARCH_BY_PROPER_NAMING
                dataResult = initData.Where(Function(x) x.wh_pn_id > 0).ToList()
        End Select

        Dim a(18) As String

        For Each row In dataResult

            a(0) = row.wh_id
            a(1) = row.item_name
            a(2) = $"{row.item_desc}{Utilities.formatProperNames(row.proper_item_name, row.proper_item_desc, row.wh_pn_id)}"
            a(3) = row.classification '$"{row.lastname}, {row.firstname}"
            a(4) = row.type_of_item
            a(5) = Utilities.getWarehouseAreaStockpile(row.wh_area_id, row.whArea_category, row.warehouse_area) 'row.warehouse_area
            a(6) = row.specific_loc
            a(7) = Utilities.getWhIncharge(row.wh_area_id, Results.rListOfIncharge) 'IIf(row.incharge_id = 0, $"({row.incharge})", $"{row.lastname}, {row.firstname}")
            a(8) = row.reorder_point
            a(9) = row.default_price
            a(10) = row.units
            a(11) = row.inout
            a(12) = row.set_det_id
            a(13) = row.division
            a(14) = row.Turnover
            a(15) = row.disable
            a(16) = row.quarry
            a(17) = IIf(row.incharge_id = 0, $"({row.incharge})", $"{row.lastname}, {row.firstname}") 'row.incharge
            a(18) = row.kpi

            Dim lvl As New ListViewItem(a)

            'Dim lvl As New ListViewItem
            If row.disable = 1 Then
                lvl.BackColor = ColorTranslator.FromHtml("#D4836D")
                lvl.ForeColor = Color.White
                lvl.Font = New Font(New FontFamily(cFontsFamily.bombardier), 11, FontStyle.Regular)

                'lvl = customListviewItem(, a,,, Color.Black, "#D4836D")
            End If

            If row.wh_pn_id > 0 Then

                lvl.ForeColor = ColorTranslator.FromHtml("#5E7075")
                lvl.Font = New Font(New FontFamily(cFontsFamily.bombardier), 11, FontStyle.Regular)

                'lvl = customListviewItem(Color.White, a,,, Color.Gray)
            End If

            'lvlItemList.Items.Add(lvl)
            cListOfListViewItem.Add(lvl)
        Next

        listfocus(lvlItemList, cWh_id)

    End Sub



    Private Sub search_warehouse1()
        Dim warehouse_item As New Model._Mod_Warehouse_Item

        warehouse_item.parameter("@n", 114)
        warehouse_item.parameter("@searchby", searchby)
        warehouse_item.parameter("@search", search)
        warehouse_item.cStoreProcedureName = "proc_get_data_from_warehouse"

        ListOfWarehouseItem = warehouse_item.LISTOFWAREHOUSEITEM

        'Dim newData = ListOfWarehouseItem.Where(Function(x) x.item_desc.ToUpper() = "FINE SAND").ToList()
        'MsgBox(newData.Count)

    End Sub
    Private Sub load_incharge()

        Dim incharge As New Model._Mod_Incharge
        ListOfIncharge = incharge.LISTOFINCHARGE

    End Sub
    Public Sub search_warehouse()
        'GIBSON CODE UPDATE BY KING
        lbox.Visible = False
        lvlItemList.Items.Clear()

        searchby = IIf(cmbSearch.SelectedIndex = -1, cSearchBy.SEARCH_BY_PROPER_NAMING, cmbSearch.Text)
        search = txtDesc.Text

        cmbSearch.Text = searchby
        txtSearch.Text = search

        'reload
        loadWhItems()

        'Try
        '    SQLcon.connection.Open()

        '    cmd = New SqlCommand("proc_get_data_from_warehouse", SQLcon.connection)
        '    cmd.Parameters.Clear()
        '    cmd.CommandType = CommandType.StoredProcedure

        '    cmd.Parameters.AddWithValue("@n", 114)
        '    cmd.Parameters.AddWithValue("@searchby", cmbSearch.Text)

        '    If cmbSearch.Text = "Search by Returned Item" Then
        '        cmd.Parameters.AddWithValue("@search", cmbSearchReturn.Text)
        '    Else
        '        cmd.Parameters.AddWithValue("@search", txtSearch.Text)
        '    End If

        '    sqldr = cmd.ExecuteReader
        '    Dim a(20) As String

        '    If sqldr.HasRows Then
        '        While sqldr.Read

        '            a(0) = sqldr.Item("wh_id").ToString
        '            a(1) = sqldr.Item("whItem").ToString
        '            a(2) = sqldr.Item("whItemDesc").ToString
        '            a(3) = sqldr.Item("whClass").ToString
        '            a(4) = sqldr.Item("tor_desc").ToString & " - " & sqldr.Item("tor_sub_desc").ToString
        '            'a(5) = sqldr.Item("whArea").ToString
        '            a(5) = sqldr.Item("wh_area").ToString
        '            a(6) = sqldr.Item("whSpecificLoc").ToString
        '            ' a(7) = sqldr.Item("whIncharge").ToString
        '            a(7) = sqldr.Item("wh_incharge").ToString
        '            a(8) = sqldr.Item("whReorderPoint").ToString
        '            a(9) = sqldr.Item("default_price").ToString
        '            a(10) = sqldr.Item("unit").ToString
        '            ' a(11) = sqldr.Item("tor_sub_id").ToString
        '            a(11) = sqldr.Item("in_out_desc").ToString
        '            a(12) = sqldr.Item("set_det_id").ToString
        '            a(13) = sqldr.Item("division").ToString
        '            a(14) = sqldr.Item("turnover").ToString

        '            If sqldr.Item("default_price").ToString = Nothing Or sqldr.Item("whReorderPoint").ToString = "0" Then
        '                a(8) = 0
        '            Else
        '                Dim value As String = CInt(sqldr.Item("whReorderPoint").ToString)
        '                a(8) = value
        '            End If

        '            Dim lvl As New ListViewItem(a)
        '            lvlItemList.Items.Add(lvl)

        '        End While
        '    Else
        '        MessageBox.Show("Data doesn't exist...", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If

        '    sqldr.Close()

        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    SQLcon.connection.Close()
        'End Try


    End Sub

    Private Sub EditTypeOfItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditTypeOfItemToolStripMenuItem.Click
        'lvlItemList.Enabled = False
        pboxAddUnit.Visible = False
        pbox_remove.Visible = False
        cmbTypeItem.Text = ""
        'Panel1.Visible = True

        Label7.Text = "Type Of Item:"
        If Label7.Text = "Type Of Item:" Then
            With cmbTypeItem
                .Items.Add("Major")
                .Items.Add("Minor")
                .Items.Add("Admin and Misc.")
                .Items.Add("Equipment")
                .Items.Add("Warehouse")
                .Items.Add("Miscellaneous")
            End With
        End If

        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = True
                ctr.Parent = Me
                ctr.BringToFront()
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next



    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        For i = 0 To lvlItemList.Items.Count - 1
            If lvlItemList.Items(i).Selected = True Then
                wh_id = lvlItemList.Items(i).Text
                If Label7.Text = "Type Of Item:" Then
                    update_item_type(wh_id)
                ElseIf Label7.Text = "Unit:" Then
                    update_unit(wh_id)
                ElseIf Label7.Text = "Select Warehouse area:" Then
                    Dim wh_area_id As Integer = get_id("dbwh_area", "wh_area", cmbTypeItem.Text, 0)
                    update_warehousearea(wh_id, wh_area_id)
                End If
            End If
        Next

        MessageBox.Show("Successfully Updated...", "EUS Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' search_warehouse()
        cmbTypeItem.Items.Clear()
        Panel1.Visible = False
        lvlItemList.Focus()
        search_warehouse()
        ' view_warehouesItems()
        listfocus(lvlItemList, wh_id)
        lvlItemList.Enabled = True

        btnClose.PerformClick()

    End Sub
    Public Sub update_warehousearea(ByVal wh_id As Integer, ByVal wh_area_id As Integer)

        Dim query As String = "UPDATE dbwarehouse_items SET whArea = '" & wh_area_id & "' WHERE wh_id = " & wh_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

    End Sub
    Public Function update_item_type(ByVal id As Integer) As Integer
        Try
            SQLcon.connection.Open()
            publicquery = "UPDATE dbwarehouse_items SET typeOfItem = '" & cmbTypeItem.Text & "' WHERE wh_id = '" & id & "' "
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Public Function update_unit(ByVal id As Integer) As Integer
        Try
            SQLcon.connection.Open()
            publicquery = "UPDATE dbwarehouse_items SET unit = '" & cmbTypeItem.Text & "' WHERE wh_id = '" & id & "' "
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function


    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        'If exportToExcel.ShowDialog = Windows.Forms.DialogResult.OK Then
        exportExcel()
        'Else
        '    MessageBox.Show("You Clicked CANCEL...", "INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    Public Sub exportExcel()
        Dim xlApp As New excel.Application

        Try
            exportToExcel.ShowDialog()

            'exit if no file selected
            If exportToExcel.FileName = "" Then
                Exit Sub
            End If

            'create objects to interface to Excel
            Dim xls As New excel.Application
            Dim book As excel.Workbook
            Dim sheet As excel.Worksheet

            Dim chartRange As excel.Range

            thread = New Threading.Thread(AddressOf loading)
            thread.Start()

            'create a workbook and get reference to first worksheet
            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            'step through rows and columns and copy data to worksheet
            Dim row As Integer = 2
            Dim col As Integer = 1
            Dim c As Integer = 1
            Dim excel_array() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"}
            Dim excel_index As Integer = 1
            Dim iii As Integer = 0

            sheet.ListObjects.Add(excel.XlListObjectSourceType.xlSrcRange, sheet.Range("$A$1:$K$1"), , excel.XlYesNoGuess.xlYes).Name = "Table1"

            '~~> Format the table
            sheet.ListObjects("Table1").TableStyle = "TableStyleLight9"

            sheet.Cells(1, 1) = "ID"
            sheet.Cells(1, 2) = "Item Name"
            sheet.Cells(1, 3) = "Description"
            sheet.Cells(1, 4) = "Classification"
            sheet.Cells(1, 5) = "Type Of Item"
            sheet.Cells(1, 6) = "Warehouse Area"
            sheet.Cells(1, 7) = "Specific Location"
            sheet.Cells(1, 8) = "In-Charge"
            sheet.Cells(1, 9) = "Reorder Point"
            sheet.Cells(1, 10) = "Default Price"
            sheet.Cells(1, 11) = "Unit"

            'For Each item As ListViewItem In LVLEquipList.Items

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim col1, row1 As Integer
            row1 = 2
            col1 = 1

            For i = 0 To lvlItemList.Items.Count - 1

                If lvlItemList.Items(i).Selected Then

                    For ii = 1 To 11
                        If ii = 1 Then
                            sheet.Cells(row1, ii) = lvlItemList.Items(i).Text
                        Else
                            sheet.Cells(row1, ii) = lvlItemList.Items(i).SubItems(ii - 1).Text
                        End If
                        col1 += 1
                    Next

                    col1 += 1
                    row1 += 1
                End If

                chartRange = sheet.Range(excel_array(0) & 1, excel_array(10) & 1)

                With chartRange

                    .HorizontalAlignment = excel.XlVAlign.xlVAlignCenter
                    .VerticalAlignment = excel.XlVAlign.xlVAlignCenter
                    .Font.Size = 12
                    .Font.FontStyle = "Arial"
                    .EntireColumn.ColumnWidth = 15

                    .Borders(excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                    .Borders(excel.XlBordersIndex.xlEdgeRight).Weight = 2
                    .Borders(excel.XlBordersIndex.xlEdgeTop).Weight = 2
                    .Borders(excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                    'chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                    '.Range("F" & col1).Formula = "=(E" & col1 & "-D" & col1 & ")*24*60/60"
                    .EntireColumn.AutoFit()

                End With

            Next

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'save the workbook and clean up
            book.SaveAs(exportToExcel.FileName)
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

            thread.Abort()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub releaseObject(ByVal obj As Object)
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

    Public Sub loading()
        Floading.ShowDialog()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next
    End Sub

    Private Sub EditUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUnitToolStripMenuItem.Click


        pboxAddUnit.Visible = True
        pbox_remove.Visible = True
        cmbTypeItem.Text = ""

        Label7.Text = "Unit:"
        If Label7.Text = "Unit:" Then
            viewUnit()
        End If

        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = True
                ctr.Parent = Me
                ctr.BringToFront()
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next

    End Sub

    Public Sub addUnit()
        Dim sqlquery As String
        Try
            SQLcon.connection.Open()
            sqlquery = "INSERT INTO units(unit)VALUES('" & cmbTypeItem.Text & "')"
            cmd = New SqlCommand(sqlquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader

            MessageBox.Show("Successfully Added..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
            viewUnit()
        End Try
    End Sub

    Public Sub remove_unit(ByVal unit As String)
        Dim sqlquery As String
        Dim newsq As New SQLcon
        Try
            newsq.connection.Open()
            sqlquery = "DELETE FROM units WHERE unit = '" & unit & "'"
            cmd = New SqlCommand(sqlquery, newsq.connection)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Successfully Deleted..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
            viewUnit()
        End Try
    End Sub

    Public Sub viewUnit()
        Dim sqlquery As String
        Dim sq As New SQLcon
        Dim dr As SqlDataReader
        cmbTypeItem.Items.Clear()
        Try
            sq.connection.Open()
            sqlquery = "SELECT * FROM units"
            cmd = New SqlCommand(sqlquery, sq.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbTypeItem.Items.Add(dr.Item("unit").ToString)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
            cmbTypeItem.Text = ""
        End Try
    End Sub

    Private Sub pboxAddUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxAddUnit.Click
        If cmbTypeItem.Text = "" Then
            MessageBox.Show("Pls. fill up the field to proceed.", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTypeItem.Focus()
        Else
            If check_if_exist("units", "unit", (cmbTypeItem.Text), 0) > 0 Then
                MessageBox.Show(cmbTypeItem.Text & vbCrLf & "already exist in database..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                addUnit()
            End If
        End If
    End Sub

    Private Sub pbox_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbox_remove.Click
        If cmbTypeItem.Text = "" Then
            MessageBox.Show("Pls select data first..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTypeItem.Focus()
        Else
            If check_if_exist("units", "unit", (cmbTypeItem.Text), 0) > 0 Then
                remove_unit(cmbTypeItem.Text)
            Else
                MessageBox.Show("Pls select data first..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbTypeItem.Focus()
            End If
        End If
    End Sub


    Private Sub EditWarehouseAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditWarehouseAreaToolStripMenuItem.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "Panel1" Then
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next

        Label7.Text = "Select Warehouse area:"
        load_wh_area()

    End Sub

    Public Sub load_wh_area()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmbTypeItem.Items.Clear()

        Try
            newSQ.connection.Open()

            Dim query As String = "SELECT wh_area FROM dbwh_area"
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader
            While newDR.Read
                cmbTypeItem.Items.Add(newDR.Item("wh_area").ToString)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        tor_id = get_id_sub_type_of_request()
        load_request_type(2, cmbSub)
        If cmbType.Text = "Admin and Misc. Request" Then
            cmbSub.Items.Remove("Borrower")
        End If
    End Sub


    Public Function get_id_sub_type_of_request()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String
        newSQ.connection.Open()

        Try
            query = "SELECT tor_id FROM dbType_of_Request WHERE tor_desc='" & cmbType.Text & "'"
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_id_sub_type_of_request = newDR.Item(0).ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function



    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        inOut_id = get_inout_id()
        tor_sub_id = get_tor_sub_id()
        tsp_id = get_tsp_id()
        MsgBox(tsp_id)
        'MsgBox(tor_id)
        'save_warehouseItems_with_tsp_id()

    End Sub
    Public Sub save_warehouseItems_with_tsp_id()
        'Dim newSQ As New SQLcon
        'Dim newCMD As SqlCommand
        'Dim newDR As SqlDataReader
        'Dim query As String

        'newSQ.connection.Open()
        'Try
        '    query = "SELECT "
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearch.SelectedIndexChanged
        If cmbSearch.Text = "Search by Returned Item" Then
            cmbSearchReturn.Visible = True
            txtSearch.Visible = False
        ElseIf cmbSearch.Text = "Search by Disabled Item" Then

            searchby = cmbSearch.Text
            search = IIf(txtSearch.Text.ToLower() = UISearch.placeHolder.ToLower(), "", txtSearch.Text)
            lvlItemList.Items.Clear()

            BW_proccess_data.WorkerSupportsCancellation = True
            BW_proccess_data.RunWorkerAsync()
        Else
            cmbSearchReturn.Visible = False
            txtSearch.Visible = True
            txtSearch.Focus()
        End If

    End Sub

    Private Sub FWarehouseItems_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        'lvlItemList.Height = Me.Height - 180
        'lvlItemList.Width = Me.Width - 270

        ' btnExit.Location = New Point(lvlItemList.Width + 230, 10)
        ' gboxSearch.Location = New Point(lvlItemList.Location.X, lvlItemList.Bounds.Bottom)

        'btnExit.Parent = pboxHeader
        ' btnExit.Location = New Point(Me.Width - 30, 20)
    End Sub

    Private Sub pboxHeader_Click(sender As Object, e As EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub pboxHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub pboxHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - mousex)
            temp.Y = Me.Location.Y + (e.Y - mousey)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub pboxHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub txtUnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnit.TextChanged

    End Sub

    Private Sub txtDefaultPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDefaultPrice.TextChanged

    End Sub

    Private Sub txtSearch_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        SAVE_UPDATE()
        Panel2.Visible = False
    End Sub

    Private Sub btnUploadPic_Click(sender As Object, e As EventArgs) Handles btnUploadPic.Click
        Dim open As New OpenFileDialog()
        open.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp"
        If open.ShowDialog() = DialogResult.OK Then
            Dim fileName As String = System.IO.Path.GetFullPath(open.FileName)
            picItemImage.Image = New Bitmap(open.FileName)
            Me.picItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub lvlItemList_MouseClick(sender As Object, e As MouseEventArgs)
        'Dim itm As ListViewItem
        'itm = lvlItemList.GetItemAt(e.X, e.Y)
        'If Not itm Is Nothing Then
        '    If itm.Selected Then



        '        Form2.Label1.Text = itm.SubItems(1).Text & " - " & itm.SubItems(2).Text
        '        readItemImage(searchItemID(itm.SubItems(1).Text, itm.SubItems(2).Text))
        '        Form2.Show()
        '        Form2.BringToFront()
        '        Form2.Location = New Point(MousePosition.X, MousePosition.Y)
        '    End If
        'Else
        '    Form2.Dispose()
        'End If
        'itm = Nothing
    End Sub

    ' Place these procedures inside a Form class definition.
    Private Sub catchClose(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        ' Insert code to deal with impending closure of this form.
        ' MsgBox("sorry.")
    End Sub
    Private Sub doubleclicklistview(sender As Object, e As MouseEventArgs)
        'Dim itm As ListViewItem
        'itm = lvlItemList.GetItemAt(e.X, e.Y)
        'If Not itm Is Nothing Then
        '    If itm.Selected Then

        '        Form2.Label1.Text = itm.SubItems(1).Text & " - " & itm.SubItems(2).Text
        '        readItemImage(searchItemID(itm.SubItems(1).Text, itm.SubItems(2).Text))
        '        Form2.Show()
        '        Form2.BringToFront()
        '        Form2.Location = New Point(MousePosition.X, MousePosition.Y)
        '    End If
        'Else
        '    Form2.Dispose()
        'End If
        'itm = Nothing



    End Sub
    Public Sub formOpened()
        ' AddHandler Me.Closing, AddressOf catchClose
        'AddHandler lvlItemList.DoubleClick, AddressOf doubleclicklistview

    End Sub



    Private Sub lvlItemList_MouseMove(sender As Object, e As MouseEventArgs)


        'Dim itm As ListViewItem
        'itm = lvlItemList.GetItemAt(e.X, e.Y)

        'For Each item As ListViewItem In lvlItemList.Items
        '    item.Selected = False
        'Next

        'If itm IsNot Nothing Then
        '    itm.Selected = True
        'End If

        'If Not itm Is Nothing Then
        '    Form2.Dispose()
        'End If

        'itm = Nothing

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = False
        lvlItemList.Focus()
        lvlItemList.Items(lvlItemList.Items.Count - 1).Selected = True
        lvlItemList.EnsureVisible(lvlItemList.Items.Count - 1)

        search_warehouse()
        listfocus(lvlItemList, y)
        clear_fields()
    End Sub

    Private Sub cmbItemSet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItemSet.SelectedIndexChanged
        set_item_id = get_id("dbSet_Items", "set_items", cmbItemSet.Text, 0)
        load_list_of_sets_item(set_item_id)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbappforsets.SelectedIndexChanged
        If cmbappforsets.Text = "YES" Then
            GroupBox1.Visible = True
        Else
            GroupBox1.Visible = False
            cmbItemSet.SelectedIndex = -1
            cmbListofSetsItem.SelectedIndex = -1
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub cmbListofSetsItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListofSetsItem.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtbox_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged, txtDesc.TextChanged
        'txtbox = sender
        'Dim n As Integer
        '' If n = 0 Then : txtbox.Name = "txtItemName" : ElseIf n = 1 Then : txtbox.Name = "txtDesc" : End If
        'If txtbox.Name = "txtItemName" Then
        '    n = 0
        'ElseIf txtbox.Name = "txtDesc" Then
        '    n = 1
        'End If

        'lbox.Location = New Point(sender.Bounds.Left + 5, sender.Bounds.Bottom + 42)
        'lbox.Parent = Me
        'lbox.BringToFront()

        'If txtbox.Focus = True Then
        '    If txtbox.Text = "" Then
        '        lbox.Visible = False
        '    Else
        '        lbox.Visible = True
        '        ' list_box(0)
        '        list_box_1(txtbox, n)
        '    End If

        'End If
    End Sub
    Public Sub list_box_1(ByVal textbox As TextBox, ByVal n As Integer)
        lbox.Items.Clear()
        Dim counter As Integer = 0
        Try
            SQLcon.connection.Open()
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand("proc_wh_items_crud", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            If n = 0 Then
                cmd.Parameters.AddWithValue("@Item", textbox.Text)
                cmd.Parameters.AddWithValue("@crud", "3")
            ElseIf n = 1 Then
                cmd.Parameters.AddWithValue("@ItemDesc", textbox.Text)
                cmd.Parameters.AddWithValue("@crud", "6")

            End If
            dr = cmd.ExecuteReader
            While dr.Read
                If n = 0 Then
                    Dim whItem As String = dr.Item("whItem").ToString
                    lbox.Items.Add(whItem)
                    counter += 1
                ElseIf n = 1 Then
                    Dim ItemDesc As String = dr.Item(0).ToString
                    lbox.Items.Add(ItemDesc)
                    counter += 1
                End If

            End While

            If counter = 0 Then
                lbox.Visible = False
            Else
                lbox.Visible = True
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown, txtDesc.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox.Visible = True Then
                If lbox.Items.Count > 0 Then
                    lbox.Focus()
                    lbox.SelectedIndex = 0
                    ' txtbox.Text = lbox.SelectedItem.ToString
                End If
            Else

            End If
        End If
    End Sub

    Private Sub gboxSearch_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub lvlItemList_DoubleClick(sender As Object, e As EventArgs)

        If button_click_name = "btnLinktoWh" Then


        ElseIf button_click_name = "link_to_other_wh" Then
            With FWithdrawalList
                Dim wh_id As Integer = lvlItemList.SelectedItems(0).Text
                Dim po_det_id As Integer = .lvlwithdrawalList.SelectedItems(0).Text
                Dim qty As Double = .lvlwithdrawalList.SelectedItems(0).SubItems(5).Text
                Dim rs_id As Integer = .lvlwithdrawalList.SelectedItems(0).SubItems(16).Text

                insert_to_dbWarehouse_to_Warehouse_tbl(po_det_id, qty, wh_id, rs_id)

                Me.Close()

            End With



        End If
    End Sub

    Public Function insert_to_dbWarehouse_to_Warehouse_tbl(po_det_id As Integer, qty As Double, wh_id As Integer, rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_withdrawal_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@qty", qty)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE:  " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        'charge_to_selection = 14
        'FCharge_To.ShowDialog()
        FWH_Incharge.btnSelect.Enabled = False
        FWH_Incharge.ShowDialog()

    End Sub

    Private Sub BW_proccess_data_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW_proccess_data.DoWork
        search_warehouse1()
        load_incharge()

    End Sub

    Private Sub BW_proccess_data_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_proccess_data.RunWorkerCompleted

        Dim data = From Wh_Item In ListOfWarehouseItem
                   Group Join Incharge In ListOfIncharge On Wh_Item.incharge_id Equals Incharge.incharge_id Into WhItem_InchargeGroup = Group
                   From final In WhItem_InchargeGroup.DefaultIfEmpty()
                   Select
                     Wh_Item.wh_id,
                       Wh_Item.item_name,
                       Wh_Item.item_desc,
                       Wh_Item.classification,
                       Wh_Item.type_of_item,
                       Wh_Item.warehouse_area,
                       Wh_Item.specific_loc,
                       Wh_Item.incharge,
                       Wh_Item.reorder_point,
                       Wh_Item.default_price,
                       Wh_Item.unit,
                       Wh_Item.inout,
                       Wh_Item.set_det_id,
                       Wh_Item.division,
                       Wh_Item.Turnover,
                       final?.firstname,
                       final?.lastname,
                       Wh_Item.incharge_id,
                       Wh_Item.disable,
                       Wh_Item.proper_item_name,
                       Wh_Item.proper_item_desc


        Dim a(15) As String

        For Each row In data

            If searchby = "Search by Warehouse Incharge" Then
                Dim myIncharge As String = $"{row.incharge} - {row.lastname}, {row.firstname}" 'combine ang old incharge og new incharge
                Dim defaultSearch As String = ""

#Region "INVOKE TXTSEARCH"
                If txtSearch.InvokeRequired Then
                    txtSearch.Invoke(Sub()
                                         defaultSearch = txtSearch.Text
                                     End Sub)
                Else
                    defaultSearch = txtSearch.Text
                End If
#End Region

                If myIncharge.ToUpper().Contains(defaultSearch.ToUpper()) Then
                    GoTo continuehere1 'if naay makita nga whareincharge
                Else
                    GoTo continuehere2
                End If

            End If

continuehere1:

            a(0) = row.wh_id
            a(1) = row.item_name
            a(2) = $"{row.item_desc}"
            a(3) = row.classification '$"{row.lastname}, {row.firstname}"
            a(4) = row.type_of_item
            a(5) = row.warehouse_area
            a(6) = row.specific_loc
            a(7) = IIf(row.incharge_id = 0, $"({row.incharge})", $"{row.lastname}, {row.firstname}")
            a(8) = row.reorder_point
            a(9) = row.default_price
            a(10) = row.unit
            a(11) = row.inout
            a(12) = row.set_det_id
            a(13) = row.division
            a(14) = row.Turnover
            a(15) = row.disable

            Dim lvl As New ListViewItem(a)

            If row.disable = 1 Then
                lvl.BackColor = ColorTranslator.FromHtml("#D4836D")
                lvl.ForeColor = Color.White
            End If
            lvlItemList.Items.Add(lvl)

continuehere2:

        Next
    End Sub

    Private Function properNameFormat(wh_pn_id As Integer, itemName As String, itemDesc As String)
        If wh_pn_id = 0 Then
            Return ""
        Else
            Return $"({itemName} - {itemDesc})"
        End If

    End Function

    Private Delegate Function ListOfWarehouseItemDelegates() As String
    Public Function aaa() As String
        'cDict = dict
        Dim WarehouseItemInstance As ListOfWarehouseItemDelegates = AddressOf _wow_

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = WarehouseItemInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        aaa = WarehouseItemInstance.EndInvoke(asyncResult)
    End Function

    Private Function _wow_() As String

        For Each row In ListOfIncharge
            If row.incharge_id = cIncharge_id Then
                _wow_ = row.firstname
                Exit For
            End If
        Next

    End Function

    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click

        enable_disable_item(1)

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        displayResult()

    End Sub

    Private Sub btnResetProperNames_Click(sender As Object, e As EventArgs) Handles btnResetProperNames.Click
        txtItemName.Clear()
        txtDesc.Clear()
        txtUnit.Clear()

    End Sub

    Private Sub UnlinkProperNamingToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If customMsg.messageYesNo("Are you sure you want to unlink the proper naming?", "SUPPLY INFO") Then
            Dim c As New Model_King_Dynamic_Update()
            Dim cv As New ColumnValues

            Dim wh_id As Integer = lvlItemList.SelectedItems(0).Text
            cv.add("wh_pn_id", 0)
            c.UpdateData("dbwarehouse_items", cv.getValues(), $"wh_id = {wh_id}")
            linkTriggered = True

            loadWhItems()
        End If


    End Sub

    Private Sub ViewStockcardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewStockcardToolStripMenuItem.Click
        With FStockCard3
            .loadStockCard(lvlItemList.SelectedItems(0).Text)
            .ShowDialog()
        End With
    End Sub

    Private Sub LinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinkToolStripMenuItem.Click

    End Sub

    Private Sub LinkToProperNamingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LinkToProperNamingToolStripMenuItem1.Click
        FLinkToProperNaming.isFromWareHouse = True
        FLinkToProperNaming.ShowDialog()
    End Sub

    Private Sub UnlinkProperNamingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnlinkProperNamingToolStripMenuItem1.Click
        If customMsg.messageYesNo("Are you sure you want to unlink the proper naming?", "SUPPLY INFO") Then
            Dim c As New Model_King_Dynamic_Update()
            Dim cv As New ColumnValuesObj

            Dim wh_id As Integer = lvlItemList.SelectedItems(0).Text
            cv.add("wh_pn_id", 0)
            c.UpdateData("dbwarehouse_items", cv.getValues(), $"wh_id = {wh_id}")
            linkTriggered = True

            loadWhItems()
        End If

    End Sub

    Private Sub LinkQuarryCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinkQuarryCodeToolStripMenuItem.Click
        With FWarehouseArea
            target_location_project = Me.Name.ToUpper()
            .isFromWareHouse_link_quarry_btn = True

            .ShowDialog()
        End With
    End Sub

    Private Sub UnlinkQuarryCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnlinkQuarryCodeToolStripMenuItem.Click
        If customMsg.messageYesNo("Are you sure you want to unlink quarry code?", "SUPPLY INFO:") Then

            Dim _wh_id As Integer = lvlItemList.SelectedItems(0).Text

            Dim cc As New ColumnValuesObj
            cc.add("quarry_id", 0)
            cc.setCondition($"wh_id = {_wh_id}")
            cc.updateQuery("dbwarehouse_items")
            linkTriggered = True
            cWh_id = _wh_id

            loadWhItems()
        End If
    End Sub

    Private Sub SetPricesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPricesToolStripMenuItem.Click
        Try
            Dim selected As ListViewItem = lvlItemList.SelectedItems(0)

            AggregatesPricesForm = New FAggregatesPrices(lvlItemList.SelectedItems(0).Text)
            With AggregatesPricesForm
                '.cWhId = lvlItemList.SelectedItems(0).Text
                .Label2.Text = $"{selected.SubItems(2).Text}"
                .ShowDialog()
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        KPIForm.isFromWareHouse = True
        KPIForm.ShowDialog()

    End Sub

    Private Sub ViewProperNamingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProperNamingToolStripMenuItem.Click
        FLinkToProperNaming.isViewing = True
        FLinkToProperNaming.ShowDialog()

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadWhItems()
    End Sub

    Private Sub EditWarehouseAreaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditWarehouseAreaToolStripMenuItem1.Click
        With FWarehouseArea
            .isFromWareHouse_edit_warehouseArea = True
            .ShowDialog()
        End With
    End Sub

    Private Sub btnLinkToProperNaming_Click(sender As Object, e As EventArgs) Handles btnLinkToProperNaming.Click
        With FLinkToProperNaming
            .isFromWareHouse_link_btn = True
            .ShowDialog()
        End With

    End Sub

    Private Sub enable_disable_item(enable As Integer)
        If customMsg.messageYesNo($"Are you sure you want to { IIf(enable = 1, "disable", "enable") } this item?", "SUPPLY INFO:") = True Then
            Dim setDisable As New Model_King_Dynamic_Update()
            Dim wh_id As Integer = lvlItemList.SelectedItems(0).Text


            Dim columnValues As New Dictionary(Of String, Object)()
            columnValues.Add("disable_item", enable)

            setDisable.UpdateData("dbwarehouse_items", columnValues, $"wh_id = {wh_id}")

            customMsg.message("info", $"item has been { IIf(enable = 1, "disabled", "enabled")}", "SUPPLY INFO:")


            btnSearch.PerformClick()

            listfocus(lvlItemList, wh_id)
        End If

    End Sub


    Private Sub EnableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem.Click
        enable_disable_item(0)
    End Sub


    Private Sub LinkToProperNamingToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FLinkToProperNaming.isFromWareHouse = True
        FLinkToProperNaming.ShowDialog()

    End Sub

    Private Sub ImportExcelToSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportExcelToSQLToolStripMenuItem.Click
        Dim excelToSQL As New ModelExcelToSQL

        Dim filePath As String = excelToSQL.GetExcelFilePath()
        excelToSQL.ImportExcelToSQL(filePath)
    End Sub


    Private Sub EditInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInfoToolStripMenuItem.Click
        Try
            Dim selectedItems As ListViewItem = lvlItemList.SelectedItems(0)

            Dim data = Results.cResult.Where(Function(x) x.wh_id = selectedItems.Text).ToList()

            If data.Count > 0 Then

                Dim editData As New PropsFields.whItems_props_fields
                editData = getProperNameUsingWhPnId(selectedItems.Text)

                txtItemName.Text = editData.item_name
                txtDesc.Text = editData.item_desc


                With data(0)
                    txtWhClass.Text = .classification
                    Dim type_of_item_split() As String
                    type_of_item_split = .type_of_item.Split("-") 'lvlItemList.SelectedItems(0).SubItems(4).Text.Split("-")
                    cmbType.Text = type_of_item_split(0).Trim
                    cmbSub.Text = type_of_item_split(1).Trim
                    txtWarehouseArea.Text = .warehouse_area
                    txtSpecLoc.Text = .specific_loc
                    txtIncharge.Text = .incharge
                    cIncharge_id = .incharge_id
                    txtReOrderPoint.Text = .reorder_point
                    txtDefaultPrice.Text = .default_price
                    txtUnit.Text = .units
                    cmbIn.Text = .inout
                    cmbDivision.Text = .division
                    cmbTurnover.Text = .Turnover
                    cmbappforsets.Text = "NO"
                    whAreaCategory = .whArea_category
                    lblCancel.Visible = True
                    lbox.Visible = False
                    lvlItemList.Enabled = False
                    kpi_id = .kpi_id
                    txtKeyPerformanceIndicator.Text = .kpi
                    txtItemName.Focus()
                    lblSaveUpdate.Text = "Update Item"
                    cWh_id = selectedItems.Text
                    cEdit = True
                End With


            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


        'If lvlItemList.SelectedItems.Count > 0 Then
        '    wh_id = lvlItemList.SelectedItems(0).Text
        '    lblSaveUpdate.Text = "Update Item"
        '    lvlItemList.Enabled = False
        '    'gboxSearch.Enabled = False

        '    Dim editData As New PropsFields.whItems_props_fields
        '    editData = getProperNameUsingWhPnId(wh_id)

        '    Try

        '        txtItemName.Text = editData.item_name 'lvlItemList.SelectedItems(0).SubItems(1).Text
        '        txtDesc.Text = editData.item_desc 'lvlItemList.SelectedItems(0).SubItems(2).Text

        '        txtWhClass.Text = lvlItemList.SelectedItems(0).SubItems(3).Text
        '        ' cmbType.Text = lvlItemList.SelectedItems(0).SubItems(4).Text
        '        Dim type_of_item_split() As String
        '        type_of_item_split = lvlItemList.SelectedItems(0).SubItems(4).Text.Split("-")
        '        cmbType.Text = type_of_item_split(0).Trim
        '        cmbSub.Text = type_of_item_split(1).Trim
        '        txtWarehouseArea.Text = lvlItemList.SelectedItems(0).SubItems(5).Text
        '        txtSpecLoc.Text = lvlItemList.SelectedItems(0).SubItems(6).Text
        '        txtIncharge.Text = lvlItemList.SelectedItems(0).SubItems(7).Text
        '        txtReOrderPoint.Text = lvlItemList.SelectedItems(0).SubItems(8).Text
        '        txtDefaultPrice.Text = lvlItemList.SelectedItems(0).SubItems(9).Text
        '        txtUnit.Text = lvlItemList.SelectedItems(0).SubItems(10).Text
        '        cmbIn.Text = lvlItemList.SelectedItems(0).SubItems(11).Text
        '        cmbDivision.Text = lvlItemList.SelectedItems(0).SubItems(13).Text
        '        cmbTurnover.Text = lvlItemList.SelectedItems(0).SubItems(14).Text

        '        If lvlItemList.SelectedItems(0).SubItems(12).Text <> "0" Then
        '            cmbappforsets.Text = "YES"
        '            load_item_set_and_list_of_sets_item(lvlItemList.SelectedItems(0).SubItems(0).Text)
        '        Else
        '            cmbappforsets.Text = "NO"
        '        End If

        '        lblCancel.Visible = True
        '        lbox.Visible = False
        '        txtItemName.Focus()

        '    Catch ex As Exception
        '        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'Else
        '    MessageBox.Show("Select first!", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    Private Sub EditInchargeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FWH_Incharge.btnSelect.Enabled = True
        FWH_Incharge.ShowDialog()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        lvlItemList.Items.AddRange(cListOfListViewItem.ToArray)
        loadingPanel.Visible = False

        listfocus(lvlItemList, cWh_id)

    End Sub
End Class