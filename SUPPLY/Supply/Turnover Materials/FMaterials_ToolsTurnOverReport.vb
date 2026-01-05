Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FMaterials_ToolsTurnOverReport
    Public Sqlcon As New SQLcon
    Dim name1 As String
    Public proj_id As Integer = 0
    Dim whID As Integer = 0
    Dim typeOfItem As String
    Dim opr As Boolean = True
    Dim typEItem As String
    Dim turn_over_id As Integer = 0

    Private Sub FMaterials_ToolsTurnOverReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmbSearchByCategory.Text = "Search by Project Code/Name"
        Label15.Parent = pboxHeader
        ListJobOrderNo.Location = New Point(1000, 1000)
        btnExit.Parent = pboxHeader
        btnExit.BringToFront()

        'viewMaterialToolsTurnOverList()

    End Sub

    Public Sub viewMaterialToolsTurnOverList()
        lvlMaterialToolsList.Items.Clear()
        Dim cnt As Integer = 0
        Try
            Sqlcon.connection.Open()
            Dim cmd As New SqlCommand("proc_dbMaterialTools_TurnOver", Sqlcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            If cmbSearchByCategory.Text = "Search by Turned-Over Date" Then
                cmd.Parameters.AddWithValue("@crud", "Search_by_turned_over_date")
                cmd.Parameters.AddWithValue("@turned_over_date", Date.Parse(DTP_search.Text))
            Else
                cmd.Parameters.AddWithValue("@crud", 0)
            End If

            Dim newdr As SqlDataReader = cmd.ExecuteReader

            While newdr.Read
                Dim a(15) As String

                a(0) = newdr.Item("mat_tools_id").ToString
                a(1) = get_project_desc(newdr.Item("project_code_id").ToString)

                If newdr.Item("bases").ToString = 1 Then 'new 
                    a(2) = get_newWhItemDesc(newdr.Item("type_of_material_id").ToString)
                ElseIf newdr.Item("bases").ToString = 2 Then 'old 
                    a(2) = get_whItemDesc(newdr.Item("type_of_material_id").ToString)
                End If

                a(3) = newdr.Item("qty").ToString
                a(4) = newdr.Item("unit").ToString
                a(5) = newdr.Item("condition_of_item").ToString
                a(6) = newdr.Item("turn_over_location").ToString
                a(7) = newdr.Item("whArea").ToString
                a(8) = newdr.Item("specLocation").ToString
                a(9) = newdr.Item("receiver").ToString
                a(10) = Format(Date.Parse(newdr.Item("turned_over_date").ToString))
                a(11) = newdr.Item("remarks").ToString
                a(12) = newdr.Item("typeOfItem").ToString

                If cmbSearchByCategory.Text = "Search by Project Code/Name" Then
                    If search_by(a(1), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchByCategory.Text = "Search by Type of Material" Then
                    If search_by(a(2), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchByCategory.Text = "Search by Receiver" Then
                    If search_by(a(9), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchByCategory.Text = "Search by Spec. Location" Then
                    If search_by(a(8), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                End If

                Dim lvlList As New ListViewItem(a)
                lvlMaterialToolsList.Items.Add(lvlList)

                cnt += 1
proceedhere:
            End While

            If cnt = 0 Then
                MessageBox.Show("No data found", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    Public Function get_newWhItemDesc(ByVal id As Integer)
        Dim sq As New SQLcon
        Try
            sq.connection.Open()
            publicquery = "SELECT Whitem_Desc,WHitem FROM warehouse_items_new WHERE id = '" & id & "'"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, sq.connection)
            Dim newdr As SqlDataReader = cmd.ExecuteReader
            While newdr.Read
                get_newWhItemDesc = newdr.Item("WHitem").ToString & " - " & newdr.Item("Whitem_Desc").ToString
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Function

    Public Function get_project_desc(ByVal project_desc_id As Integer) As String
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Dim newdr As SqlDataReader
        Try
            'sqlcon.set_sql("192.168.2.91", "eus", "sa", "adfil")
            'sqlcon.sql_connect()
            sqlcon.connection1.Open()
            publicquery = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = '" & project_desc_id & "' "
            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            newdr = cmd.ExecuteReader
            While newdr.Read
                get_project_desc = newdr.Item("project_desc").ToString
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()
        End Try
    End Function

    Public Function get_whItemDesc(ByVal warH_id As Integer)
        Dim SQLcon As New SQLcon
        Try
            SQLcon.connection.Open()
            publicquery = "SELECT whItemDesc,whItem FROM dbwarehouse_items WHERE wh_id = '" & warH_id & "'"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, SQLcon.connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                get_whItemDesc = dr.Item("whItem").ToString & " - " & dr.Item("whItemDesc").ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'viewMaterialToolsTurnOverList()
        'txtSearch.Focus()
        load_turnover_materials()
    End Sub
    Public Sub load_turnover_materials()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(20) As String

        lvlMaterialToolsList.Items.Clear()

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_turnover_items_to_wh", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 3)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                a(0) = newDR.Item("turnover_item_id").ToString
                a(1) = FProjectIncharge.get_specific_charges_name(newDR.Item("turnover_from_type").ToString, CInt(newDR.Item("turnover_from_id").ToString))
                a(2) = get_item_name_or_other_col(5, CInt(newDR.Item("wh_id").ToString), "item_name")
                a(3) = newDR.Item("qty").ToString
                a(4) = newDR.Item("unit").ToString
                a(5) = newDR.Item("condition_of_item").ToString
                a(6) = FProjectIncharge.get_specific_charges_name(newDR.Item("turnover_to_type").ToString, CInt(newDR.Item("turnover_to_id").ToString))
                a(8) = get_item_name_or_other_col(5, CInt(newDR.Item("wh_id").ToString), "spec_loc")
                a(9) = newDR.Item("receiver").ToString
                a(10) = newDR.Item("turnover_date").ToString
                a(11) = newDR.Item("remarks").ToString

                Dim lvl As New ListViewItem(a)
                lvlMaterialToolsList.Items.Add(lvl)

            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub Edit_turnover_materials()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim turnover_item_id As Integer = CInt(lvlMaterialToolsList.SelectedItems(0).Text)

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_turnover_items_to_wh", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 33)
            newCMD.Parameters.AddWithValue("@turnover_item_id", turnover_item_id)
            newDR = newCMD.ExecuteReader
            While newDR.Read

                With FMaterial_Turnover_Fields
                    turn_over_id = newDR.Item("turnover_from_id").ToString
                    .cmbRequestType.Text = newDR.Item("tor_desc").ToString
                    .cmbTOR_sub.Text = newDR.Item("tor_sub_desc").ToString
                    .cmbInOut.Text = "IN"
                    .cmb_projectcodeName.Text = newDR.Item("turnover_from_type").ToString

                    .cmbTurnoverFrom.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(1).Text
                    .cmb_selectItem.Text = newDR.Item("what_wh_area").ToString
                    .txtconditionofItem.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(5).Text
                    .txtReceiver.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(9).Text
                    .DTP_TurnedOverdate.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(10).Text
                    .txtRemarks.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(11).Text
                    .cmb_specLocation.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(8).Text

                    .txtTurnOverBy.Text = newDR.Item("turnover_by").ToString
                    .txtNotedby.Text = newDR.Item("noted_by").ToString
                    .DTP_NotedDate.Text = newDR.Item("noted_date").ToString
                    .txtQuantity.Text = newDR.Item("qty").ToString
                    .txtUnit.Text = newDR.Item("unit").ToString

                    If .cmb_selectItem.Text = "Warehouse Item" Or .cmb_selectItem.Text = "Turnovered Item" Then
                        get_type_of_material_description(newDR.Item("wh_id").ToString)
                    End If

                    .cmbTurnoverToType.Text = newDR.Item("turnover_to_type").ToString
                    .cmb_turnOverLocation.Text = get_turnover_type(newDR.Item("turnover_to_id").ToString, .cmbTurnoverToType.Text)

                    If .cmbTurnoverToType.Text = "WAREHOUSE" Then
                        .cmb_specLocation.Text = get_specLocation(newDR.Item("turnover_to_id").ToString)
                    Else
                        .cmb_specLocation.Text = "N/A"
                    End If

                End With

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function get_specLocation(ByVal id As Integer) As String
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT whSpecificLoc FROM dbwarehouse_items WHERE whArea = '" & id & "'"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, Sqlcon.connection)

            get_specLocation = cmd.ExecuteScalar

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Function

    Public Function get_type_of_material_description(ByVal id As Integer)
        Dim newsq As New SQLcon
        Try
            newsq.connection.Open()
            publicquery = "SELECT * FROM dbwarehouse_items_for_turnover WHERE wh_id = '" & id & "'"
            Dim newcmd As SqlCommand = New SqlCommand(publicquery, newsq.connection)
            Dim newdr As SqlDataReader = newcmd.ExecuteReader
            While newdr.Read
                With FMaterial_Turnover_Fields
                    .cmbTypeofMaterial.Text = newdr.Item("item_name").ToString
                    .cmb_materialDesc.Text = newdr.Item("item_desc").ToString
                End With
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Function

    Public Function get_turnover_type(ByVal turnover_to_id As Integer, ByVal turn_over_type As String) As String
        Dim sQ As New SQLcon
        Dim sqlcon As New SQLcon
        Dim cmd As SqlCommand
        Try
            If turn_over_type = "PROJECT" Or turn_over_type = "EQUIPMENT" Then
                'sQ.set_sql("192.168.2.91", "eus", "sa", "adfil")
                'sQ.sql_connect()
                sQ.connection1.Open()
            Else
                sqlcon.connection.Open()
            End If

            If turn_over_type = "PROJECT" Then
                publicquery = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = '" & turnover_to_id & "' "
            ElseIf turn_over_type = "EQUIPMENT" Then
                publicquery = "SELECT plate_no FROM dbequipment_list WHERE equipListID = '" & turnover_to_id & "' "
            ElseIf turn_over_type = "WAREHOUSE" Then
                publicquery = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = '" & turnover_to_id & "'"
            ElseIf turn_over_type = "MAINOFFICE" Or turn_over_type = "PERSONAL" Then
                publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = '" & turnover_to_id & "'"
            End If

            If turn_over_type = "PROJECT" Or turn_over_type = "EQUIPMENT" Then
                cmd = New SqlCommand(publicquery, sQ.connection1)
            Else
                cmd = New SqlCommand(publicquery, sqlcon.connection)
            End If

            Dim sqldr As SqlDataReader = cmd.ExecuteReader

            While sqldr.Read

                If turn_over_type = "PROJECT" Then
                    get_turnover_type = sqldr.Item("project_desc").ToString
                ElseIf turn_over_type = "EQUIPMENT" Then
                    get_turnover_type = sqldr.Item("plate_no").ToString
                ElseIf turn_over_type = "WAREHOUSE" Then
                    get_turnover_type = sqldr.Item("wh_area").ToString
                ElseIf turn_over_type = "MAINOFFICE" Or turn_over_type = "PERSONAL" Then
                    get_turnover_type = sqldr.Item("charge_to").ToString
                End If

            End While

            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            If turn_over_type = "PROJECT" Or turn_over_type = "EQUIPMENT" Then
                sQ.connection1.Close()
            Else
                sqlcon.connection.Close()
            End If

        End Try
    End Function

    Public Function get_item_name_or_other_col(ByVal wh_tbl As Integer, ByVal wh_id As Integer, ByVal col As String) As String
        'wh_tbl = 4 - old
        'wh_tbl = 5 - new

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            newCMD = New SqlCommand("proc_turnover_items_to_wh", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", wh_tbl)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader
            While newDR.Read

                If wh_tbl = 4 And col = "item_name" Then
                    get_item_name_or_other_col = newDR.Item("whItem").ToString & " - " & newDR.Item("whItemDesc").ToString

                ElseIf wh_tbl = 5 And col = "item_name" Then
                    get_item_name_or_other_col = newDR.Item("item_name").ToString & " - " & newDR.Item("item_desc").ToString

                ElseIf wh_tbl = 4 And col = "spec_loc" Then
                    get_item_name_or_other_col = newDR.Item("whSpecificLoc").ToString

                ElseIf wh_tbl = 5 And col = "spec_loc" Then
                    get_item_name_or_other_col = newDR.Item("spec_loc").ToString

                End If

            End While
            newDR.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub get_project_id(ByVal prjdesc As String)
        Dim sQ As New SQLcon
        Try
            'sQ.set_sql("192.168.2.91", "eus", "sa", "adfil")
            'sQ.sql_connect()
            sQ.connection1.Open()
            publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc = '" & prjdesc & "' "
            Dim cmd As SqlCommand = New SqlCommand(publicquery, sQ.connection1)
            Dim dr1 As SqlDataReader = cmd.ExecuteReader
            While dr1.Read
                proj_id = dr1.Item("proj_id").ToString
            End While
            dr1.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sQ.connection1.Close()
        End Try
    End Sub

    Public Sub get_wrhouseID(ByVal whItemDesc As String)
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT wh_id FROM dbwarehouse_items WHERE whItemDesc = '" & whItemDesc & "'"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, Sqlcon.connection)
            Dim newdr As SqlDataReader = cmd.ExecuteReader
            While newdr.Read
                whID = newdr.Item("wh_id").ToString
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    Public Sub get_newwrhouseID(ByVal newwhItemDesc As String)
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT id FROM warehouse_items_new WHERE Whitem_Desc = '" & newwhItemDesc & "'"
            Dim cmd1 As SqlCommand = New SqlCommand(publicquery, Sqlcon.connection)
            Dim newdr As SqlDataReader = cmd1.ExecuteReader
            While newdr.Read
                whID = newdr.Item("id").ToString
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub cmbSearchByCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchByCategory.SelectedIndexChanged
        Select Case cmbSearchByCategory.Text
            Case "Search by Turned-Over Date"
                DTP_search.Visible = True
                DTP_search.Location = New System.Drawing.Point(txtSearch.Location.X, txtSearch.Location.Y)
                DTP_search.Width = txtSearch.Width
                txtSearch.Visible = False
            Case Else
                txtSearch.Visible = True
                DTP_search.Visible = False
                txtSearch.Focus()
        End Select
    End Sub

    Private Sub DTP_search_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTP_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#Region "GUI"
    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub FMaterials_ToolsTurnOverReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lvlMaterialToolsList.Height = Me.Height - 158
        lvlMaterialToolsList.Width = Me.Width - 45
        btnExit.Location = New Point(lvlMaterialToolsList.Width + 5, 8)
        lblSearchByCategory.Location = New Point(lvlMaterialToolsList.Location.X, lvlMaterialToolsList.Bounds.Bottom + 5)
        cmbSearchByCategory.Location = New Point(lblSearchByCategory.Location.X, lblSearchByCategory.Bounds.Bottom + 2)
        txtSearch.Location = New Point(lblSearchByCategory.Location.X + 232, lblSearchByCategory.Bounds.Bottom + 1)
        btnSearch.Location = New Point(txtSearch.Location.X + 230, txtSearch.Bounds.Bottom - 28)
    End Sub

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtSearch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Leave
        sender.backcolor = Color.White
    End Sub
#End Region

    Private Sub btn_inputField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inputField.Click

        'For Each ctr As Control In Me.Controls
        '    ctr.Enabled = False
        'Next

        FMaterial_Turnover_Fields.ShowDialog()


    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        With FMaterial_Turnover_Fields
            .lbl_save.Text = "Update"
            .ShowDialog()
        End With

    End Sub

    Public Sub Edit_value()

        btn_inputField.Enabled = False
        FMaterials_ToolsTurnOverTextFields.lbl_save.Text = "Update Report"
        lbl_matID.Text = lvlMaterialToolsList.SelectedItems(0).Text
        FMaterials_ToolsTurnOverTextFields.cmb_projectcodeName.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(1).Text
        FMaterials_ToolsTurnOverTextFields.txtconditionofItem.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(5).Text
        FMaterials_ToolsTurnOverTextFields.cmb_turnOverLocation.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(6).Text

        If FMaterials_ToolsTurnOverTextFields.cmb_turnOverLocation.Text = "ADFIL" Then
            FMaterials_ToolsTurnOverTextFields.cmb_Location_adfil.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(7).Text
            FMaterials_ToolsTurnOverTextFields.cmb_specLocation.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(8).Text
        ElseIf FMaterials_ToolsTurnOverTextFields.cmb_turnOverLocation.Text = "PROJECT" Then
            FMaterials_ToolsTurnOverTextFields.cmb_Location_project.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(8).Text
        End If

        FMaterials_ToolsTurnOverTextFields.txtReceiver.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(9).Text
        FMaterials_ToolsTurnOverTextFields.DTP_TurnedOverdate.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(10).Text
        FMaterials_ToolsTurnOverTextFields.txtRemarks.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(11).Text
        FMaterials_ToolsTurnOverTextFields.txtQuantity.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(3).Text
        FMaterials_ToolsTurnOverTextFields.txtUnit.Text = lvlMaterialToolsList.SelectedItems(0).SubItems(4).Text

        get_materialdata(lbl_matID.Text)
        FMaterials_ToolsTurnOverTextFields.lbox_itemList.Visible = False
        FMaterials_ToolsTurnOverTextFields.cmb_materialDesc.Text = get_materialdata1(lbl_matID.Text)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim msg = MessageBox.Show("Are you sure yOu want to delete the data?...", "EUS INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If msg = Windows.Forms.DialogResult.Yes Then
            DeleteMaterialTolls_Report()
        Else
            Return
        End If
    End Sub

    Public Sub get_materialdata(ByVal id As Integer)
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT * FROM dbMaterialTools_TurnOver WHERE mat_tools_id = '" & id & "'"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, Sqlcon.connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                FMaterials_ToolsTurnOverTextFields.txtTurnOverBy.Text = dr.Item("turned_over_by").ToString
                FMaterials_ToolsTurnOverTextFields.txtNotedby.Text = dr.Item("noted_by").ToString
                FMaterials_ToolsTurnOverTextFields.DTP_NotedDate.Text = dr.Item("noted_date").ToString

                If dr.Item("bases").ToString = 1 Then
                    FMaterials_ToolsTurnOverTextFields.cmb_selectItem.Text = "Turnovered Item"
                    FMaterials_ToolsTurnOverTextFields.cmbTypeofMaterial.Text = get_typeofMaterial(dr.Item("type_of_material_id").ToString, 1)
                    'FMaterials_ToolsTurnOverTextFields.cmb_materialDesc.Text = get_material_desc(dr.Item("type_of_material_id").ToString, 1)
                ElseIf dr.Item("bases").ToString = 2 Then
                    FMaterials_ToolsTurnOverTextFields.cmb_selectItem.Text = "Exist Item"
                    FMaterials_ToolsTurnOverTextFields.cmbTypeofMaterial.Text = get_typeofMaterial(dr.Item("type_of_material_id").ToString, 2)
                    'FMaterials_ToolsTurnOverTextFields.cmb_materialDesc.Text = get_material_desc(dr.Item("type_of_material_id").ToString, 2)

                End If

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()

        End Try
    End Sub

    Public Function get_materialdata1(ByVal id As Integer) As String
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT * FROM dbMaterialTools_TurnOver WHERE mat_tools_id = '" & id & "'"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, Sqlcon.connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read

                If dr.Item("bases").ToString = 1 Then
                    get_materialdata1 = get_material_desc(dr.Item("type_of_material_id").ToString, 1)
                ElseIf dr.Item("bases").ToString = 2 Then
                    get_materialdata1 = get_material_desc(dr.Item("type_of_material_id").ToString, 2)
                End If

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()

        End Try
    End Function

    Public Function get_material_desc(ByVal id As Integer, ByVal n As Integer) As String
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr1 As SqlDataReader
        Try
            newsqlcon.connection.Open()

            If n = 2 Then
                publicquery = "SELECT * FROM dbwarehouse_items WHERE wh_id = '" & id & "'"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM warehouse_items_new WHERE id = '" & id & "'"
            End If

            newcmd = New SqlCommand(publicquery, newsqlcon.connection)
            newdr1 = newcmd.ExecuteReader
            While newdr1.Read

                If n = 2 Then
                    get_material_desc = newdr1.Item("whItemDesc").ToString
                ElseIf n = 1 Then
                    get_material_desc = newdr1.Item("Whitem_Desc").ToString
                End If

            End While
            newdr1.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection.Close()
        End Try
    End Function

    Public Function get_typeofMaterial(ByVal id As Integer, ByVal n As Integer) As String
        Dim sq As New SQLcon
        Dim newdr As SqlDataReader
        Try
            sq.connection.Open()

            If n = 2 Then
                publicquery = "SELECT whItem FROM dbwarehouse_items WHERE wh_id = '" & id & "'"
            ElseIf n = 1 Then
                publicquery = "SELECT WHitem FROM warehouse_items_new WHERE id = '" & id & "'"
            End If

            Dim cmd As SqlCommand = New SqlCommand(publicquery, sq.connection)
            newdr = cmd.ExecuteReader
            While newdr.Read

                If n = 2 Then
                    get_typeofMaterial = newdr.Item("whItem").ToString
                ElseIf n = 1 Then
                    get_typeofMaterial = newdr.Item("WHitem").ToString
                End If

            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Function

    Public Function get_newtypeofMaterial(ByVal newitemdesc As String) As String
        Dim sq1 As New SQLcon
        Dim newdr1 As SqlDataReader
        Try
            sq1.connection.Open()
            publicquery = "SELECT WHitem FROM warehouse_items_new WHERE Whitem_Desc = '" & newitemdesc & "'"
            Dim cmd As SqlCommand = New SqlCommand(publicquery, sq1.connection)
            newdr1 = cmd.ExecuteReader
            While newdr1.Read
                get_newtypeofMaterial = newdr1.Item("WHitem").ToString
            End While
            newdr1.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq1.connection.Close()
        End Try
    End Function

    Public Sub DeleteMaterialTolls_Report()
        Try
            Dim sqlcon As New SQLcon
            sqlcon.connection.Open()
            publicquery = "DELETE FROM dbMaterialTools_TurnOver WHERE mat_tools_id = " & lvlMaterialToolsList.SelectedItems(0).SubItems(0).Text & ""
            Dim cmd As SqlCommand = New SqlCommand(publicquery, sqlcon.connection)
            cmd.ExecuteNonQuery()

            lvlMaterialToolsList.SelectedItems(0).Remove()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class