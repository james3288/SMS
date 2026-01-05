Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FMaterials_ToolsTurnOverTextFields
    Public Sqlcon As New SQLcon
    Dim cmd As SqlCommand
    Dim name1 As String
    Public proj_id As Integer = 0
    Public bases As Integer = 0
    Public whID As Integer = 0
    Dim typeOfItem As String
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub FMaterials_ToolsTurnOverTextFields_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Are you sure you want to Cancel?", "SUPPLY INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                For Each ctr As Control In FMaterials_ToolsTurnOverReport.Controls
                    ctr.Enabled = True
                Next
                clear_fields()
                Me.Dispose()
            Else
                Return
            End If
        End If
    End Sub

    Private Sub FMaterials_ToolsTurnOverTextFields_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btnExit.Parent = PictureBox1
        btnExit.BringToFront()

        lbl_save.Parent = btn_save
        lbl_save.BringToFront()
        lbl_save.Location = New Point(55, 11)

        get_projectDesc()

        With cmb_turnOverLocation
            .Items.Add("ADFIL")
            .Items.Add("PROJECT")
        End With

        lbl_specLocation.Visible = False
        cmb_specLocation.Visible = False
        cmb_projectcodeName.Focus()

    End Sub

    Public Sub get_projectDesc()
        cmb_projectcodeName.Items.Clear()
        Dim sqlcon1 As New SQLcon
        Try
            'sqlcon1.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'sqlcon1.sql_connect()
            sqlcon1.connection1.Open()
            publicquery = "SELECT DISTINCT project_desc FROM dbprojectdesc ORDER BY project_desc ASC"
            cmd = New SqlCommand(publicquery, sqlcon1.connection1)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                cmb_projectcodeName.Items.Add(dr.Item("project_desc").ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon1.connection1.Close()
        End Try
    End Sub

    Public Sub get_whItem(ByVal n As Integer, ByVal cmbox As ComboBox)
        cmbox.Items.Clear()
        Try
            Sqlcon.connection.Open()

            If n = 0 Then
                publicquery = "SELECT DISTINCT whItem FROM dbwarehouse_items ORDER BY whItem ASC"
            ElseIf n = 1 Then
                publicquery = "SELECT DISTINCT WHitem FROM warehouse_items_new ORDER BY WHitem ASC"
            End If

            cmd = New SqlCommand(publicquery, Sqlcon.connection)
            Dim dr1 As SqlDataReader = cmd.ExecuteReader
            While dr1.Read

                If n = 0 Then
                    cmbox.Items.Add(dr1.Item("whItem").ToString)
                ElseIf n = 1 Then
                    cmbox.Items.Add(dr1.Item("WHitem").ToString)
                End If

            End While
            dr1.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub cmbTypeofMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeofMaterial.SelectedIndexChanged

        'If cmb_selectItem.Text = "Exist Item" Then
        '    get_typeOfItem(cmbTypeofMaterial.Text, 0)
        'Else
        '    get_typeOfItem(cmbTypeofMaterial.Text, 1)
        'End If

        If cmb_selectItem.Text = "Exist Item" Then
            get_WhItemDesc(cmbTypeofMaterial.Text, 0, cmb_materialDesc)
        Else
            get_WhItemDesc(cmbTypeofMaterial.Text, 1, cmb_materialDesc)
        End If
    End Sub

    Public Sub get_typeOfItem(ByVal itemtype As String, ByVal nn As Integer)
        Dim sq As New SQLcon
        Try
            sq.connection.Open()

            If nn = 0 Then
                publicquery = "SELECT typeOfItem FROM dbwarehouse_items WHERE whItem = '" & itemtype & "'"
            ElseIf nn = 1 Then
                publicquery = "SELECT typeOfItem FROM warehouse_items_new WHERE WHitem = '" & itemtype & "'"
            End If

            cmd = New SqlCommand(publicquery, sq.connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read

                If nn = 0 Then
                    typeOfItem = dr.Item("typeOfItem").ToString
                ElseIf nn = 1 Then
                    typeOfItem = dr.Item("typeOfItem").ToString
                End If

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Sub

    Private Sub cmb_materialDesc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_materialDesc.GotFocus

        'If cmb_selectItem.Text = "Exist Item" Then
        '    get_WhItemDesc(cmbTypeofMaterial.Text, 0)
        'Else
        '    get_WhItemDesc(cmbTypeofMaterial.Text, 1)
        'End If

    End Sub

    Public Function get_WhItemDesc(ByVal wh_item As String, ByVal nnn As Integer, ByVal obj As Object)
        Dim combox As ComboBox
        Dim listview As ListView

        If TypeOf obj Is ComboBox Then
            combox = obj
            combox.Items.Clear()
        ElseIf TypeOf obj Is ListView Then
            listview = obj
        End If

        Dim newsq As New SQLcon
        Try
            newsq.connection.Open()

            If nnn = 0 Then
                publicquery = "SELECT DISTINCT whItemDesc FROM dbwarehouse_items WHERE WHitem = '" & wh_item & "' ORDER BY whItemDesc ASC"
            ElseIf nnn = 1 Then
                publicquery = "SELECT DISTINCT Whitem_Desc FROM warehouse_items_new WHERE WHitem = '" & wh_item & "' ORDER BY Whitem_Desc ASC"
            ElseIf nnn = 2 Then
                publicquery = "SELECT wh_id,whItemDesc FROM dbwarehouse_items WHERE WHitem = '" & wh_item & "' ORDER BY whItemDesc ASC"
            End If

            cmd = New SqlCommand(publicquery, newsq.connection)
            Dim dr2 As SqlDataReader = cmd.ExecuteReader
            While dr2.Read

                If nnn = 0 Then
                    If TypeOf obj Is ComboBox Then
                        combox.Items.Add(dr2.Item("whItemDesc").ToString)
                    ElseIf TypeOf obj Is ListView Then
                        Dim a(2) As String
                        a(0) = CInt(dr2.Item("wh_id").ToString)
                        a(1) = dr2.Item("whItemDesc").ToString

                        Dim lvl As New ListViewItem(a)
                        listview.Items.Add(lvl)
                    End If

                ElseIf nnn = 1 Then
                    If TypeOf obj Is ComboBox Then
                        combox.Items.Add(dr2.Item("Whitem_Desc").ToString)
                    ElseIf TypeOf obj Is ListView Then
                        Dim a(2) As String
                        a(0) = CInt(dr2.Item("id").ToString)
                        a(1) = dr2.Item("Whitem_Desc").ToString

                        Dim lvl As New ListViewItem(a)
                        listview.Items.Add(lvl)
                    End If

                ElseIf nnn = 2 Then
                    If TypeOf obj Is ComboBox Then
                        combox.Items.Add(dr2.Item("whItemDesc").ToString)
                    ElseIf TypeOf obj Is ListView Then
                        Dim a(2) As String
                        a(0) = CInt(dr2.Item("wh_id").ToString)
                        a(1) = dr2.Item("whItemDesc").ToString

                        Dim lvl As New ListViewItem(a)
                        listview.Items.Add(lvl)
                    End If

                End If

            End While
            dr2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        For Each ctr As Control In FMaterials_ToolsTurnOverReport.Controls
            ctr.Enabled = True
        Next
        Me.Dispose()
    End Sub

#Region "MoveForm"
    Private Sub FMaterials_ToolsTurnOverTextFields_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub FMaterials_ToolsTurnOverTextFields_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub FMaterials_ToolsTurnOverTextFields_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        drag = False
    End Sub

#End Region

#Region "GUI"

    Private Sub txtQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
          e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
                  e.KeyCode = Keys.OemPeriod Or _
                 e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then
            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub cmb_projectcodeName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_projectcodeName.GotFocus, cmbTypeofMaterial.GotFocus, cmb_materialDesc.GotFocus, _
    txtconditionofItem.GotFocus, cmb_turnOverLocation.GotFocus, cmb_Location_adfil.GotFocus, cmb_Location_project.GotFocus, txtReceiver.GotFocus, txtTurnOverBy.GotFocus, txtNotedby.GotFocus, _
    txtQuantity.GotFocus, txtUnit.GotFocus, txtRemarks.GotFocus, DTP_TurnedOverdate.GotFocus, DTP_NotedDate.GotFocus, cmb_specLocation.GotFocus, cmb_selectItem.GotFocus

        sender.backcolor = Color.Yellow

        lbox_itemList.Visible = False
        If txtReceiver.Focused Then
            name1 = txtReceiver.Name
            txtReceiver.SelectAll()
        ElseIf txtTurnOverBy.Focused Then
            name1 = txtTurnOverBy.Name
            txtTurnOverBy.SelectAll()
        ElseIf txtNotedby.Focused Then
            name1 = txtNotedby.Name
            txtNotedby.SelectAll()
        End If

        If cmb_Location_adfil.Text = "" Then
            cmb_specLocation.Items.Clear()
        End If

    End Sub

    Private Sub cmb_projectcodeName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_projectcodeName.Leave, cmbTypeofMaterial.Leave, cmb_materialDesc.Leave, _
    txtconditionofItem.Leave, cmb_turnOverLocation.Leave, cmb_Location_adfil.Leave, cmb_Location_project.Leave, txtReceiver.Leave, txtTurnOverBy.Leave, txtNotedby.Leave, _
    txtQuantity.Leave, txtUnit.Leave, txtRemarks.Leave, cmb_selectItem.Leave

        sender.backcolor = Color.White

    End Sub

    Private Sub btnExit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = My.Resources.close_button
    End Sub

#End Region

    Private Sub cmb_turnOverLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_turnOverLocation.SelectedIndexChanged
        If cmb_turnOverLocation.Text = "ADFIL" Then
            With cmb_Location_adfil
                .Items.Clear()
                .Items.Add("WHS Bulldog")
                .Items.Add("WHS Alviola")
                .Items.Add("WHS Bravo")
                .Items.Add("WHS Baan")
            End With
            cmb_Location_project.Visible = False
            cmb_Location_adfil.Visible = True
            lbl_specLocation.Location = New Point(12, 452)
            lbl_specLocation.Visible = True
            cmb_specLocation.Visible = True
            lbl_wharea.Visible = True
        ElseIf cmb_turnOverLocation.Text = "PROJECT" Then
            Dim Sqlcon As New SQLcon
            Dim dr As SqlDataReader
            cmb_Location_project.Items.Clear()
            Try
                'Sqlcon.set_sql("192.168.1.92", "eus_031916", "sa", "adfil")
                'Sqlcon.sql_connect()

                Sqlcon.connection1.Open()
                publicquery = "SELECT DISTINCT project_desc FROM dbprojectdesc ORDER BY project_desc ASC "
                cmd = New SqlCommand(publicquery, Sqlcon.connection1)
                dr = cmd.ExecuteReader

                While dr.Read
                    cmb_Location_project.Items.Add(dr.Item("project_desc").ToString)
                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection1.Close()
                cmb_Location_adfil.Visible = False
                lbl_specLocation.Location = New Point(12, 394)
                lbl_specLocation.Visible = True
                cmb_specLocation.Visible = False
                lbl_wharea.Visible = False
                cmb_Location_project.Visible = True
                cmb_Location_project.Location = New Point(15, 413)
            End Try
        End If
    End Sub

    Private Sub cmbTypeofMaterial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTypeofMaterial.Click
        cmb_materialDesc.Text = ""
    End Sub

    Private Sub txtReceiver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceiver.KeyDown, txtTurnOverBy.KeyDown, txtNotedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            If lbox_itemList.Visible = True Then
                If lbox_itemList.Items.Count > 0 Then
                    lbox_itemList.Focus()
                    lbox_itemList.SelectedIndex = 0

                End If
            Else
            End If
        End If
    End Sub

    Private Sub txtRemarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnaccept.PerformClick()
        End If
    End Sub

    Private Sub cmb_projectcodeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_projectcodeName.SelectedIndexChanged
        get_project_id(cmb_projectcodeName.Text)
    End Sub

    Private Sub lbl_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_save.Click, btn_save.Click, btnaccept.Click
        If check_if_exist("dbwarehouse_items", "whItemDesc", (cmb_materialDesc.Text), 0) > 0 Then
            get_wrhouseID(cmb_materialDesc.Text)
        ElseIf check_if_exist("warehouse_items_new", "Whitem_Desc", (cmb_materialDesc.Text), 0) > 0 Then
            get_newwrhouseID(cmb_materialDesc.Text)
        Else
            insert_newWHdesc(cmbTypeofMaterial.Text, cmb_materialDesc.Text, typeOfItem)
        End If
        insert_updatecode()
    End Sub

    Public Function insert_newWHdesc(ByVal materialType As String, ByVal materialDesc As String, ByVal typeofitem As String)
        Try
            Sqlcon.connection.Open()
            publicquery = "INSERT INTO warehouse_items_new (WHitem, Whitem_Desc, typeOfItem) VALUES ('" & materialType & "','" & materialDesc & "','" & typeofitem & "')"
            cmd = New SqlCommand(publicquery, Sqlcon.connection)
            cmd.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
            get_newid(cmb_materialDesc.Text)
        End Try
    End Function

    Public Sub get_newid(ByVal itemdesc As String)
        Dim sQ1 As New SQLcon
        Try
            sQ1.connection.Open()
            publicquery = "SELECT id FROM warehouse_items_new WHERE Whitem_Desc = '" & itemdesc & "'"
            cmd = New SqlCommand(publicquery, sQ1.connection)
            Dim newdr2 As SqlDataReader = cmd.ExecuteReader
            While newdr2.Read
                whID = newdr2.Item("id").ToString
                bases = 1
            End While
            newdr2.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sQ1.connection.Close()
        End Try
    End Sub

    Public Function get_whID(ByVal whitemDesc As String)
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT wh_id FROM dbwarehouse_items WHERE whItemDesc = '" & whitemDesc & "'"
            cmd = New SqlCommand(publicquery, Sqlcon.connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                whID = dr.Item("wh_id").ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Function

    Public Function get_project_id(ByVal project_desc As String) As Integer
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader
        Try
            'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'newsqlcon.sql_connect()
            newsqlcon.connection1.Open()
            publicquery = "SELECT proj_id FROM dbprojectdesc WHERE project_desc =  '" & project_desc & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection1)
            newsqldr = newcmd.ExecuteReader()
            While newsqldr.Read
                get_project_id = CInt(newsqldr.Item("proj_id").ToString)
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection1.Close()
        End Try
    End Function

    Public Function get_equipment_id(ByVal plateno As String) As Integer
        Dim newsqlcon As New SQLcon
        Dim newcmd As SqlCommand
        Dim newsqldr As SqlDataReader
        Try
            'newsqlcon.set_sql("192.168.1.91", "eus", "sa", "adfil")
            'newsqlcon.sql_connect()
            newsqlcon.connection1.Open()
            publicquery = "SELECT equipListID FROM dbequipment_list WHERE plate_no =  '" & plateno & "'"
            newcmd = New SqlCommand(publicquery, newsqlcon.connection1)
            newsqldr = newcmd.ExecuteReader()
            While newsqldr.Read
                get_equipment_id = CInt(newsqldr.Item("equipListID").ToString)
            End While
            newsqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsqlcon.connection1.Close()
        End Try
    End Function


    Public Sub insert_updatecode()
        If proj_id = 0 Or cmb_projectcodeName.Text = "" Then
            MessageBox.Show("Pls select one item in Project Code/Name:", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_projectcodeName.Focus()
            Return
        ElseIf cmbTypeofMaterial.Text = "" Then
            MessageBox.Show("Pls select one item in Type of Material:", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTypeofMaterial.Focus()
            Return
        ElseIf whID = 0 Or cmb_materialDesc.Text = "" Then
            MessageBox.Show("Pls select one item in Material Description:", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_materialDesc.Focus()
            Return
        ElseIf txtconditionofItem.Text = "" Then
            MessageBox.Show("Pls. fill up Condition of Item: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtconditionofItem.Focus()
        ElseIf cmb_turnOverLocation.Text = "" Then
            MessageBox.Show("Pls. select one item in Turn-Over Location: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_turnOverLocation.Focus()
        ElseIf cmb_Location_adfil.Text = "" And cmb_turnOverLocation.Text = "ADFIL" Then
            MessageBox.Show("Pls. select one item in Warehouse Area: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_Location_adfil.Focus()
        ElseIf cmb_Location_project.Text = "" And cmb_turnOverLocation.Text = "PROJECT" Then
            MessageBox.Show("Pls. select one item in Spec. Location: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_Location_project.Focus()
        ElseIf cmb_turnOverLocation.Text = "ADFIL" And cmb_specLocation.Text = "" And cmb_Location_adfil.Text IsNot "" Then
            MessageBox.Show("Pls. select one item in Spec. Location: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_specLocation.Focus()
        ElseIf txtReceiver.Text = "" Then
            MessageBox.Show("Pls. fill up Receiver: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReceiver.Focus()
        ElseIf txtTurnOverBy.Text = "" Then
            MessageBox.Show("Pls. fill up Turned-over by: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTurnOverBy.Focus()
        ElseIf txtNotedby.Text = "" Then
            MessageBox.Show("Pls. fill up Noted by: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNotedby.Focus()
        ElseIf txtQuantity.Text = "" Then
            MessageBox.Show("Pls. fill up Quantity: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtQuantity.Focus()
        ElseIf txtUnit.Text = "" Then
            MessageBox.Show("Pls. fill up Unit: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUnit.Focus()
        ElseIf txtRemarks.Text = "" Then
            MessageBox.Show("Pls. fill up Remarks: ", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRemarks.Focus()
        Else
            Dim n As String = FMaterials_ToolsTurnOverReport.lbl_matID.Text
            Try
                Sqlcon.connection.Open()
                Dim cmd As SqlCommand
                cmd = New SqlCommand("proc_dbMaterialTools_TurnOver", Sqlcon.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@project_code_id", proj_id)
                cmd.Parameters.AddWithValue("@type_of_material_id", whID)
                cmd.Parameters.AddWithValue("@qty", txtQuantity.Text)
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text)
                cmd.Parameters.AddWithValue("@condition_of_item", txtconditionofItem.Text)
                cmd.Parameters.AddWithValue("@turn_over_location", cmb_turnOverLocation.Text)
                If cmb_turnOverLocation.Text = "ADFIL" Then
                    cmd.Parameters.AddWithValue("@whArea", cmb_Location_adfil.Text)
                    cmd.Parameters.AddWithValue("@specLocation", cmb_specLocation.Text)
                ElseIf cmb_turnOverLocation.Text = "PROJECT" Then
                    cmd.Parameters.AddWithValue("@whArea", "N/A")
                    cmd.Parameters.AddWithValue("@specLocation", cmb_Location_project.Text)
                End If
                cmd.Parameters.AddWithValue("@receiver", txtReceiver.Text)
                cmd.Parameters.AddWithValue("@turned_over_by", txtTurnOverBy.Text)
                cmd.Parameters.AddWithValue("@turned_over_date", DTP_TurnedOverdate.Text)
                cmd.Parameters.AddWithValue("@noted_by", txtNotedby.Text)
                cmd.Parameters.AddWithValue("@noted_date", DTP_NotedDate.Text)
                cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                cmd.Parameters.AddWithValue("@typeOfItem", typeOfItem)
                cmd.Parameters.AddWithValue("@bases", bases)
                If lbl_save.Text = "Save Report" Then
                    cmd.Parameters.AddWithValue("@crud", "INSERT")
                    cmd.ExecuteReader()

                    MessageBox.Show("Successfully Saved...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ElseIf lbl_save.Text = "Update Report" Then

                    cmd.Parameters.AddWithValue("@crud", "Update")
                    cmd.Parameters.AddWithValue("@mat_tools_id", FMaterials_ToolsTurnOverReport.lbl_matID.Text)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Successfully Updated...", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Sqlcon.connection.Close()
                FMaterials_ToolsTurnOverReport.viewMaterialToolsTurnOverList()
                If lbl_save.Text = "Save Report" Then
                    listfocus(FMaterials_ToolsTurnOverReport.lvlMaterialToolsList, Focus)
                    FMaterials_ToolsTurnOverReport.lvlMaterialToolsList.Items(FMaterials_ToolsTurnOverReport.lvlMaterialToolsList.Items.Count - 1).Selected = True
                    FMaterials_ToolsTurnOverReport.lvlMaterialToolsList.EnsureVisible(FMaterials_ToolsTurnOverReport.lvlMaterialToolsList.Items.Count - 1)
                ElseIf lbl_save.Text = "Update Report" Then
                    listfocus(FMaterials_ToolsTurnOverReport.lvlMaterialToolsList, n)
                End If
                Me.Close()
                For Each ctr As Control In FMaterials_ToolsTurnOverReport.Controls
                    ctr.Enabled = True
                Next
            End Try
        End If
    End Sub

    Public Sub get_wrhouseID(ByVal whItemDesc As String)
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT wh_id FROM dbwarehouse_items WHERE whItemDesc = '" & whItemDesc & "'"
            cmd = New SqlCommand(publicquery, Sqlcon.connection)
            Dim newdr As SqlDataReader = cmd.ExecuteReader
            While newdr.Read
                whID = newdr.Item("wh_id").ToString
                bases = 2
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
            cmd = New SqlCommand(publicquery, Sqlcon.connection)
            Dim newdr As SqlDataReader = cmd.ExecuteReader
            While newdr.Read
                whID = newdr.Item("id").ToString
                bases = 1
            End While
            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub
    Public Sub clear_fields()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is TextBox Then
                Dim tbox As TextBox = ctr
                tbox.Clear()
            End If
        Next

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ComboBox Then
                Dim cmb As ComboBox = ctr
                cmb.Text = Nothing
            End If
        Next

        proj_id = 0
        bases = 0
        whID = 0
        typeOfItem = ""

    End Sub

    Public Sub itemList(ByVal recno As String, ByVal n As Integer)
        Dim counter As Integer = 0
        Try
            Sqlcon.connection.Open()
            If n = 0 Then
                publicquery = "SELECT receiver FROM dbMaterialTools_TurnOver WHERE receiver LIKE '%" & recno & "%' ORDER BY receiver ASC "
            ElseIf n = 1 Then
                publicquery = "SELECT turned_over_by FROM dbMaterialTools_TurnOver WHERE turned_over_by LIKE '%" & recno & "%' ORDER BY turned_over_by ASC"
            ElseIf n = 2 Then
                publicquery = "SELECT noted_by FROM dbMaterialTools_TurnOver WHERE noted_by LIKE '%" & recno & "%' ORDER BY noted_by ASC"
            End If

            cmd = New SqlCommand(publicquery, Sqlcon.connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                If n = 0 Then
                    lbox_itemList.Items.Add(dr.Item("receiver").ToString)
                    counter += 1
                ElseIf n = 1 Then
                    lbox_itemList.Items.Add(dr.Item("turned_over_by").ToString)
                    counter += 1
                ElseIf n = 2 Then
                    lbox_itemList.Items.Add(dr.Item("noted_by").ToString)
                    counter += 1
                End If
            End While

            If counter > 0 Then
                lbox_itemList.Visible = True
            Else
                lbox_itemList.Visible = False
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub txtReceiver_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiver.TextChanged
        With lbox_itemList
            .Location = New System.Drawing.Point(txtReceiver.Location.X, txtReceiver.Location.Y + txtReceiver.Height)
            .Visible = True
            .Items.Clear()
            .Width = txtReceiver.Width
        End With
        itemList(txtReceiver.Text, 0)
    End Sub

    Private Sub txtTurnOverBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTurnOverBy.TextChanged
        With lbox_itemList
            .Location = New System.Drawing.Point(txtTurnOverBy.Location.X, txtTurnOverBy.Location.Y + txtTurnOverBy.Height)
            .Visible = True
            .Items.Clear()
            .Width = txtTurnOverBy.Width
        End With
        itemList(txtTurnOverBy.Text, 1)
    End Sub

    Private Sub txtNotedby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotedby.TextChanged
        With lbox_itemList
            .Location = New System.Drawing.Point(txtNotedby.Location.X, txtNotedby.Location.Y + txtNotedby.Height)
            .Visible = True
            .Items.Clear()
            .Width = txtNotedby.Width
        End With
        itemList(txtNotedby.Text, 2)
    End Sub

    Private Sub lbox_itemList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_itemList.DoubleClick
        If lbox_itemList.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name1 Then
                    ctr.Text = lbox_itemList.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_itemList.Visible = False
        Else
            MessageBox.Show("Pls select one item", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbox_itemList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_itemList.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = name1 Then
                    ctr.Text = lbox_itemList.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_itemList.Visible = False
        End If
    End Sub

    Private Sub cmb_Location_adfil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Location_adfil.SelectedIndexChanged
        get_specLocation(cmb_Location_adfil.Text, cmb_specLocation)
    End Sub

    Public Sub get_specLocation(ByVal wharea As String, ByVal cmb As ComboBox)
        cmb.Items.Clear()
        Try
            Sqlcon.connection.Open()
            publicquery = "SELECT DISTINCT a.whSpecificLoc FROM dbwarehouse_items a INNER JOIN dbwh_area b ON a.whArea = b.wh_area_id WHERE b.wh_area = '" & wharea & "' ORDER BY a.whSpecificLoc ASC "
            cmd = New SqlCommand(publicquery, Sqlcon.connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                With cmb
                    .Items.Add(dr.Item("whSpecificLoc").ToString)
                End With
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try
    End Sub

    Private Sub cmb_selectItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_selectItem.SelectedIndexChanged
        If cmb_selectItem.Text = "Exist Item" Then

            get_whItem(0, cmbTypeofMaterial)
            cmb_materialDesc.DropDownStyle = ComboBoxStyle.DropDownList
        Else
            get_whItem(1, cmbTypeofMaterial)
            cmb_materialDesc.DropDownStyle = ComboBoxStyle.DropDown

        End If
    End Sub

    Private Sub cmb_materialDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_materialDesc.SelectedIndexChanged

    End Sub
End Class