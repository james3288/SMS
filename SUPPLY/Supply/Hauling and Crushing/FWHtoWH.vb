Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Web.Services.Discovery
Imports System.Windows
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.VisualBasic.FileIO

Public Class FWHtoWH
    Private Class itemData
        Property wh_id As Integer
        Property itemName As String
        Property itemDesc As String
        Property whArea As String
        Property source As String
    End Class

    Public rs_no As String
    Public dr_item_id As Integer

    Private rowIndex As Integer
    Private colIndex As Integer
    Private newTblNameType As New tableNameType
    Private cListOfItems As New List(Of itemData)

    Dim UISearch As New class_placeholder4
    Private customMsgBox As New customMessageBox
    Dim cProps As New PropsFields.dr_list_props_fields

    Private Class buttonClickName
        Public Property whToWhIn As String = "whToWhUpdateIn"
        Public Property updateDriver As String = "updatedriver"
        Public Property updatePlateNo As String = "updateplateno"
        Public Property updateSupplier As String = "updatesupplier"

    End Class


    Private Sub FWHtoWH_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Dim driver_name As String = "'AMANTE, ENRICO C.'"

        ''add parameter first

        'Driver.parameter("@n", 1)
        'Driver.parameter("@where", $"where a.operator_name like '%' +  {driver_name}  + '%'")

        'MsgBox(Driver.LISTOFDRIVER().Count)

        default_style2()



    End Sub
    Public Sub default_style2()

        For Each row As DataGridViewRow In dgvData.Rows
            row.Height = 40

            For Each cells As DataGridViewCell In row.Cells
                cells.ReadOnly = True
            Next
        Next

        Dim s As New PropsFields.dr_list_props_fields
        Try
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

            For Each row As DataGridViewRow In dgvData.Rows

                If row.Cells("inout").Value = "OUT" Then

                    row.Cells("dr_date").ReadOnly = False 'dr date
                    row.Cells("dr_no").ReadOnly = False 'dr no
                    'dgvData.Rows(0).Cells("price").ReadOnly = False 'price
                    row.Cells("unit").ReadOnly = False 'unit
                    row.Cells("concession_ticket").ReadOnly = False 'concession
                    row.Cells("checked_by").ReadOnly = False 'checked_by 
                    row.Cells("received_by").ReadOnly = False 'received by
                    row.Cells("supplier").ReadOnly = False 'supplier

                    row.Cells("dr_date").Style.BackColor = Color.Blue
                    row.Cells("dr_date").Style.ForeColor = Color.White

                    row.Cells("dr_no").Style.BackColor = Color.Blue
                    row.Cells("dr_no").Style.ForeColor = Color.White


                    row.Cells("concession_ticket").Style.BackColor = Color.Blue
                    row.Cells("concession_ticket").Style.ForeColor = Color.White

                    row.Cells("driver").Style.BackColor = Color.Blue
                    row.Cells("driver").Style.ForeColor = Color.White

                    row.Cells("plateno").Style.BackColor = Color.Blue
                    row.Cells("plateno").Style.ForeColor = Color.White

                    row.Cells("checked_by").Style.BackColor = Color.Blue
                    row.Cells("checked_by").Style.ForeColor = Color.White

                    row.Cells("received_by").Style.BackColor = Color.Blue
                    row.Cells("received_by").Style.ForeColor = Color.White

                    row.Cells("supplier").Style.BackColor = Color.Blue
                    row.Cells("supplier").Style.ForeColor = Color.White

                ElseIf row.Cells("inout").Value = "IN" Then

                    row.Cells("requestor").Style.BackColor = Color.Blue
                    row.Cells("requestor").Style.ForeColor = Color.White
                End If
            Next

            'populate_data()
            Button2.Enabled = True

            With dgvData
                .Columns(NameOf(s.withdrawn_by)).Visible = False
                .Columns(NameOf(s.date_request)).Visible = False


            End With

        Catch ex As Exception
            MessageBox.Show($"Not Applicable! " & vbCrLf & vbCrLf & ex.Message, "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Button2.Enabled = False
        End Try

    End Sub

    Public Sub default_style()

        For Each row As DataGridViewRow In dgvData.Rows
            row.Height = 40

            For Each cells As DataGridViewCell In row.Cells
                cells.ReadOnly = True
            Next
        Next

        Try

            dgvData.Rows(0).Cells("dr_date").ReadOnly = False 'dr date
            dgvData.Rows(0).Cells("dr_no").ReadOnly = False 'dr no
            'dgvData.Rows(0).Cells("price").ReadOnly = False 'price
            dgvData.Rows(0).Cells("unit").ReadOnly = False 'unit
            dgvData.Rows(0).Cells(NameOf(cProps.concession_ticket)).ReadOnly = False 'concession
            dgvData.Rows(0).Cells("checked_by").ReadOnly = False 'checked_by 
            dgvData.Rows(0).Cells("received_by").ReadOnly = False 'received by
            dgvData.Rows(0).Cells("supplier").ReadOnly = False 'supplier

            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

            dgvData.Rows(0).Cells("dr_date").Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells("dr_date").Style.ForeColor = Color.White

            dgvData.Rows(0).Cells("dr_no").Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells("dr_no").Style.ForeColor = Color.White

            'dgvData.Rows(0).Cells("price").Style.BackColor = Color.Blue
            'dgvData.Rows(0).Cells("price").Style.ForeColor = Color.White

            'dgvData.Rows(0).Cells(9).Style.BackColor = Color.Blue
            'dgvData.Rows(0).Cells(9).Style.ForeColor = Color.White

            dgvData.Rows(1).Cells("requestor").Style.BackColor = Color.Blue
            dgvData.Rows(1).Cells("requestor").Style.ForeColor = Color.White

            dgvData.Rows(0).Cells(NameOf(cProps.concession_ticket)).Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells(NameOf(cProps.concession_ticket)).Style.ForeColor = Color.White

            dgvData.Rows(0).Cells("driver").Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells("driver").Style.ForeColor = Color.White

            dgvData.Rows(0).Cells("plateno").Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells("plateno").Style.ForeColor = Color.White

            dgvData.Rows(0).Cells("checked_by").Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells("checked_by").Style.ForeColor = Color.White

            dgvData.Rows(0).Cells("received_by").Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells("received_by").Style.ForeColor = Color.White

            dgvData.Rows(0).Cells("supplier").Style.BackColor = Color.Blue
            dgvData.Rows(0).Cells("supplier").Style.ForeColor = Color.White
            Button2.Enabled = True


        Catch ex As Exception
            MessageBox.Show($"Not Applicable! " & vbCrLf & vbCrLf & ex.Message, "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Button2.Enabled = False
        End Try

    End Sub
    Private Sub populate_data()

        Dim wh_to_wh As New class_DR2

        wh_to_wh._initialize("09283515253", Nothing, dgvData, 2)

    End Sub

    Private Sub dgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellValueChanged

        ' Check if the changed cell is the one you want to copy from
        'If e.ColumnIndex = 3 AndAlso e.RowIndex = 0 Then
        'End If

        Dim s As New PropsFields.dr_wh_to_wh_pros_fields

        If dgvData.Columns(e.ColumnIndex).Name = NameOf(s.dr_no) Then
            ''drno

            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            'Dim destinationColumnIndex As Integer = 3

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.dr_no)).Value = newValue


        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.dr_date) Then
            'dr date
            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            'Dim destinationColumnIndex As Integer = 1

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.dr_date)).Value = newValue

        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.price) Then
            'price
            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            'Dim destinationColumnIndex As Integer = 8

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.price)).Value = newValue

        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.unit) Then
            'unit
            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            ' Dim destinationColumnIndex As Integer = 9

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.unit)).Value = newValue

        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.concession_ticket) Then
            'concession
            'Dim sourcevalue As String = dgvData.Rows(e.RowIndex).Cells("concession").Value
            'dgvData.Rows(1).Cells(12).Value = sourcevalue

            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            ' Dim destinationColumnIndex As Integer = 12

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.concession_ticket)).Value = newValue

        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.driver) Then
            'driver

            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            'Dim destinationColumnIndex As Integer = 16

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.driver)).Value = newValue


        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.plateno) Then
            'plateno
            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            'Dim destinationColumnIndex As Integer = 17

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.plateno)).Value = newValue

        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.checked_by) Then
            'checked by
            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            ' Dim destinationColumnIndex As Integer = 18

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.checked_by)).Value = newValue

        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.received_by) Then
            'received by
            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            'Dim destinationColumnIndex As Integer = 19

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.received_by)).Value = newValue

        ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.supplier) Then
            'supplier
            ' Get the new value from the source cell
            Dim newValue As Object = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Define the destination cell (you can adjust the row and column index)
            Dim destinationRowIndex As Integer = rowIndex + 1
            'Dim destinationColumnIndex As Integer = 21

            ' Update the value in the destination cell
            dgvData.Rows(destinationRowIndex).Cells(NameOf(s.supplier)).Value = newValue

        End If

        'Check If the changed cell Is in the first row And a specific column (e.g., column with index 0)

        'MsgBox(e.RowIndex)


    End Sub

    Private Sub disable_enable_context_items(item As Integer,
                                             Optional exclude As List(Of Integer) = Nothing)

        ContextMenuStrip1.Items(item).Enabled = False

        If exclude IsNot Nothing Then

            For Each n In exclude
                If n = item Then

                    ContextMenuStrip1.Items(n).Enabled = True

                    Exit For
                    Exit Sub
                End If
            Next

            'ContextMenuStrip1.Items(item).Enabled = True

        End If

    End Sub

    Private Sub dgvData_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseClick
        Dim s As New PropsFields.dr_wh_to_wh_pros_fields
        ' Check if the right mouse button was clicked
        If e.Button = MouseButtons.Right Then

            rowIndex = e.RowIndex

            ' Show the ContextMenuStrip at the clicked location
            dgvData.CurrentCell = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex)

            If dgvData.Columns(e.ColumnIndex).Name = NameOf(s.requestor) And
                dgvData.Rows(rowIndex).Cells(NameOf(s.requestor)).Style.BackColor = Color.Blue Then

                Dim exclude As New List(Of Integer) From {1, 4}

                For i = 0 To 4
                    disable_enable_context_items(i, exclude)
                Next

                ContextMenuStrip1.Show(MousePosition)

            ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.driver) And
                dgvData.Rows(rowIndex).Cells(NameOf(s.driver)).Style.BackColor = Color.Blue Then
                Dim exclude As New List(Of Integer) From {2, 4}

                For i = 0 To 4
                    disable_enable_context_items(i, exclude)
                Next

                ContextMenuStrip1.Show(MousePosition)

            ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.supplier) And
                dgvData.Rows(rowIndex).Cells(NameOf(s.supplier)).Style.BackColor = Color.Blue Then

                Dim exclude As New List(Of Integer) From {3, 4}

                For i = 0 To 4
                    disable_enable_context_items(i, exclude)
                Next

                ContextMenuStrip1.Show(MousePosition)

            ElseIf dgvData.Columns(e.ColumnIndex).Name = NameOf(s.plateno) And
                dgvData.Rows(rowIndex).Cells(NameOf(s.plateno)).Style.BackColor = Color.Blue Then

                Dim exclude As New List(Of Integer) From {0, 4}

                For i = 0 To 4
                    disable_enable_context_items(i, exclude)
                Next

                ContextMenuStrip1.Show(MousePosition)
            Else

                For i = 0 To 4
                    disable_enable_context_items(i, Nothing)
                Next

                ContextMenuStrip1.Show(MousePosition)
            End If



            ' Check if it is the desired column and row

            'If e.ColumnIndex = 11 AndAlso dgvData.Rows(e.RowIndex).Cells("inout").Value = "IN" Or
            '    e.ColumnIndex = 16 AndAlso dgvData.Rows(e.RowIndex).Cells("inout").Value = "OUT" Or
            '    e.ColumnIndex = 17 AndAlso dgvData.Rows(e.RowIndex).Cells("inout").Value = "OUT" Or
            '    e.ColumnIndex = 21 AndAlso dgvData.Rows(e.RowIndex).Cells("inout").Value = "OUT" Then


            '    rowIndex = e.RowIndex

            '    ' Show the ContextMenuStrip at the clicked location
            '    dgvData.CurrentCell = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex)


            '    Select Case e.ColumnIndex
            '        Case 11 'requestor
            '            ContextMenuStrip1.Items(0).Enabled = False
            '            ContextMenuStrip1.Items(1).Enabled = True
            '            ContextMenuStrip1.Items(2).Enabled = False
            '            ContextMenuStrip1.Items(3).Enabled = False
            '            ContextMenuStrip1.Items(4).Enabled = True

            '            ContextMenuStrip1.Show(MousePosition)

            '        Case 16 'driver
            '            ContextMenuStrip1.Items(0).Enabled = False
            '            ContextMenuStrip1.Items(1).Enabled = False
            '            ContextMenuStrip1.Items(2).Enabled = True
            '            ContextMenuStrip1.Items(3).Enabled = False
            '            ContextMenuStrip1.Items(4).Enabled = True

            '            ContextMenuStrip1.Show(MousePosition)

            '        Case 17 'plateno
            '            ContextMenuStrip1.Items(0).Enabled = True
            '            ContextMenuStrip1.Items(1).Enabled = False
            '            ContextMenuStrip1.Items(2).Enabled = False
            '            ContextMenuStrip1.Items(3).Enabled = False
            '            ContextMenuStrip1.Items(4).Enabled = True

            '            ContextMenuStrip1.Show(MousePosition)

            '        Case 21
            '            ContextMenuStrip1.Items(0).Enabled = False
            '            ContextMenuStrip1.Items(1).Enabled = False
            '            ContextMenuStrip1.Items(2).Enabled = False
            '            ContextMenuStrip1.Items(3).Enabled = True
            '            ContextMenuStrip1.Items(4).Enabled = True
            '            ContextMenuStrip1.Show(MousePosition)

            '    End Select


            '    'ElseIf e.ColumnIndex = 16 And e.RowIndex = 0 Then
            'Else
            '    ContextMenuStrip1.Items(0).Enabled = False
            '    ContextMenuStrip1.Items(1).Enabled = False
            '    ContextMenuStrip1.Items(2).Enabled = False
            '    ContextMenuStrip1.Items(3).Enabled = False
            '    ContextMenuStrip1.Items(4).Enabled = False

            '    ContextMenuStrip1.Show(MousePosition)
            'End If
        End If
    End Sub

    Private Sub UpdateRequestorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateRequestorToolStripMenuItem.Click
        button_click_name = "WHtoWH"
        Dim ListOfItems As New FListOfItems

        ListOfItems.Show()

    End Sub

    Private Sub UpdateDriverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDriverToolStripMenuItem.Click
        txtSearch.Clear()
        button_click_name = "updatedriver"

        Dim search As New class_placeholder4

        search.king_placeholder_textbox("Driver/Operator...", txtSearch, ListOfDriver(), Panel2, My.Resources.username_icon, False, "White")

        Panel2.Visible = True
        Panel2.Location = New System.Drawing.Point((Me.Panel1.Width - Panel2.Width) / 2, (Me.Panel1.Height - Panel2.Height) / 2)

        dgvData.Enabled = False

    End Sub

    Private Sub UpdatePlateNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePlateNoToolStripMenuItem.Click
        txtSearch.Clear()
        button_click_name = "updateplateno"

        Dim search As New class_placeholder4

        search.king_placeholder_textbox("Plate No...", txtSearch, ListOfEquipment(), Panel2, My.Resources.username_icon, False, "White")

        Panel2.Visible = True
        Panel2.Location = New System.Drawing.Point((Me.Panel1.Width - Panel2.Width) / 2, (Me.Panel1.Height - Panel2.Height) / 2)

        dgvData.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = False
        dgvData.Enabled = True
    End Sub

#Region "VIEW"
    Private Function ListOfDriver() As List(Of String)
        Dim Driver As New Model._Mod_Driver

        ListOfDriver = New List(Of String)
        Dim driver_name As String = ""

        Driver.parameter("@n", 1)
        Driver.parameter("@where", $"where a.operator_name Like '%' +  {driver_name}  + '%'")

        For Each row In Driver.LISTOFDRIVER()
            ListOfDriver.Add(row.driver_name)
        Next
    End Function

    Private Function ListOfEquipment() As List(Of String)
        Dim Equipment As New Model._Mod_Equipment

        ListOfEquipment = New List(Of String)
        Dim plateno As String = ""

        Equipment.parameter("@n", 2)
        Equipment.parameter("@where", $"where a.plate_no like '%' +  {plateno}  + '%'")

        For Each row In Equipment.LISTOFEQUIPMENT()
            ListOfEquipment.Add(row.PlateNo)
        Next
    End Function

    Private Function ListOfSupplier() As List(Of String)
        Dim Supplier As New Model._Mod_Supplier

        ListOfSupplier = New List(Of String)
        Dim supplier_name As String = ""

        Supplier.parameter("@n", 3)
        Supplier.parameter("@where", $"where a.Supplier_Name like '%' +  {supplier_name}  + '%'")

        For Each row In Supplier.LISTOFSUPPLIER()
            ListOfSupplier.Add(row.supplier_name)
        Next

    End Function



    Private Function ListOfItems() As List(Of itemData)
        ListOfItems = New List(Of itemData)

        Dim aggregatesItems As New Model_Dynamic_Select

        With aggregatesItems
            Dim table As String = "dbwarehouse_items a" 'table
            Dim condition As String = $"a.division = 'CRUSHING AND HAULING'" 'conditions

            'columns
            .join_columns("a.wh_id,")
            .join_columns("a.whItem,")
            .join_columns("a.whItemDesc,")
            .join_columns("b.wh_area,")
            .join_columns("a.whClass")
            'end columns

            'inner or left join
            .joining("LEFT JOIN dbwh_area b ")
            .joining("ON b.wh_area_id = a.whArea")
            'end inner or left join

            'initialize data
            ._initialize(table, condition, .cJoinColumns, .cJoining)


            Dim rrData As New List(Of Object) 'create a list of ojbect 
            rrData = .select_query() 'get data

            'loop data to get values
            For Each row In rrData
                Dim n As Integer = 0
                Dim data As New itemData


                For Each kvp As KeyValuePair(Of String, Object) In row
                    'MsgBox($"{kvp.Key}: {kvp.Value.ToString()}")

                    Select Case kvp.Key
                        Case "wh_id"
                            data.wh_id = kvp.Value.ToString()
                        Case "whItem"
                            data.itemName = kvp.Value.ToString.ToUpper()
                        Case "whItemDesc"
                            data.itemDesc = kvp.Value.ToString.ToUpper()
                        Case "wh_area"
                            data.whArea = kvp.Value.ToString.ToUpper()
                        Case "whClass"
                            data.source = kvp.Value.ToString.ToUpper()
                    End Select
                Next

                ListOfItems.Add(data)
            Next
        End With


    End Function
#End Region

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim newBtnClickName As New buttonClickName

        If button_click_name = newBtnClickName.updateDriver Then
            dgvData.Rows(rowIndex).Cells("driver").Value = txtSearch.Text

        ElseIf button_click_name = newBtnClickName.updatePlateNo Then
            dgvData.Rows(rowIndex).Cells("plateno").Value = txtSearch.Text

        ElseIf button_click_name = newBtnClickName.updateSupplier Then
            dgvData.Rows(rowIndex).Cells("supplier").Value = txtSearch.Text

        ElseIf button_click_name = newBtnClickName.whToWhIn Then

            'get wh_id from the specific words you type
            Dim whId As Integer
            For Each item In cListOfItems
                If UISearch.tbox.Text = $"{item.itemDesc.ToUpper()} | {item.whArea.ToUpper()} | {item.source.ToUpper() }" Then
                    whId = item.wh_id
                End If
            Next

            'if there is no id found
            If whId = 0 Then
                customMsgBox.message("error", "The item you selected was not found in the database!", "SUPPLY EXCEPINFO:")
                Exit Sub
            End If

            'add in transaction
            addWh_to_Wh_In(whId)
        End If

        Panel2.Visible = False
        dgvData.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim dynamicUpdater As New Model_King_Dynamic_Update()

        'Dim columnValues As New Dictionary(Of String, Object)()

        'columnValues.Add("conversation", "hello gwapo 123")
        'columnValues.Add("date", Date.Parse("2023-06-17"))

        'dynamicUpdater.UpdateData("eus.dbo.dbChat", columnValues, "chat_id = 19")


        firstrow2()

    End Sub

    Private Structure list_of_errors
        Dim dr_no As String
        Dim error_msg As String

    End Structure

    Private Structure list_of_ids
        Dim dr_item_id As Integer
        Dim driver_id As Integer
        Dim equipListID As Integer
        Dim supplier_id As Integer
        Dim inout As String

    End Structure
    Private Sub firstrow2()

        Dim errorHandler_out As New List(Of list_of_errors)
        Dim errorHandler_in As New List(Of list_of_errors)
        Dim idsHandler_out As New List(Of list_of_ids)
        Dim idsHandler_in As New List(Of list_of_ids)

        Dim driver_id As Integer = 0
        Dim equipListID As Integer = 0
        Dim supplier_id As Integer = 0

        For Each row As DataGridViewRow In dgvData.Rows
            'filter sa ang mga ids and others og nag exist ba sa database

            If row.Cells("inout").Value = "OUT" Then

#Region "FILTER OUT DATA TO CHECK IF SOME ID EXIST"
                Dim err As New list_of_errors

                Dim dr_item_id As Integer = row.Cells(NameOf(cProps.dr_item_id)).Value
                Dim wh_id As Integer = row.Cells("wh_id").Value
                Dim rs_id As Integer = row.Cells("rs_id").Value
                Dim dr_no As String = row.Cells("dr_no").Value


                Dim driver As String = row.Cells("driver").Value
                Dim mod_driver As New Model._Mod_Driver
                driver_id = mod_driver.if_exist(driver)

                If driver_id = 0 Then
                    'If MessageBox.Show("Driver name not exist in database, still want to continue?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    '    Exit Sub
                    'End If
                    err.dr_no = row.Cells("dr_no").Value
                    err.error_msg = "Driver name not exist in database"
                    errorHandler_out.Add(err)
                    Exit Sub
                End If

                Dim plateno As String = row.Cells("plateno").Value
                Dim mod_plateno As New Model._Mod_Equipment
                equipListID = mod_plateno.if_exist(plateno)

                If equipListID = 0 Then
                    'If MessageBox.Show("plateno not exist in database, still want to continue?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    '    Exit Sub
                    'End If
                    err.dr_no = row.Cells("dr_no").Value
                    err.error_msg = "plateno not exist in database"
                    errorHandler_out.Add(err)
                    Exit Sub
                End If

                Dim supplier As String = row.Cells("supplier").Value
                Dim mod_supplier As New Model._Mod_Supplier
                supplier_id = mod_supplier.if_exist(supplier)

                If supplier_id = 0 Then
                    'If MessageBox.Show("supplier not exist in database!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
                    '    Exit Sub
                    'End If
                    err.dr_no = row.Cells("dr_no").Value
                    err.error_msg = "supplier not exist in database"
                    errorHandler_out.Add(err)
                    Exit Sub
                End If

                Dim ids As New list_of_ids

                ids.dr_item_id = dr_item_id
                ids.driver_id = driver_id
                ids.supplier_id = supplier_id
                ids.equipListID = equipListID
                ids.inout = row.Cells("inout").Value

                idsHandler_out.Add(ids)
#End Region

            ElseIf row.Cells("inout").Value = "IN" Then

#Region "FILTER IN DATA TO CHECK IF SOME ID EXIST"
                Dim err1 As New list_of_errors

                Dim dr_item_id As Integer = row.Cells(NameOf(cProps.dr_item_id)).Value
                Dim wh_id As Integer = row.Cells("wh_id").Value
                Dim rs_id As Integer = row.Cells("rs_id").Value
                Dim dr_no As String = row.Cells("dr_no").Value


                Dim driver As String = row.Cells("driver").Value
                Dim mod_driver As New Model._Mod_Driver
                driver_id = mod_driver.if_exist(driver)

                If driver_id = 0 Then
                    'If MessageBox.Show("Driver name not exist in database, still want to continue?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    '    Exit Sub
                    'End If
                    err1.dr_no = row.Cells("dr_no").Value
                    err1.error_msg = "Driver name not exist in database"
                    errorHandler_in.Add(err1)
                    Exit Sub
                End If

                Dim plateno As String = row.Cells("plateno").Value
                Dim mod_plateno As New Model._Mod_Equipment
                equipListID = mod_plateno.if_exist(plateno)

                If equipListID = 0 Then
                    'If MessageBox.Show("plateno not exist in database, still want to continue?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    '    Exit Sub
                    'End If
                    err1.dr_no = row.Cells("dr_no").Value
                    err1.error_msg = "plateno not exist in database"
                    errorHandler_in.Add(err1)
                    Exit Sub
                End If

                Dim supplier As String = row.Cells("supplier").Value
                Dim mod_supplier As New Model._Mod_Supplier
                supplier_id = mod_supplier.if_exist(supplier)

                If supplier_id = 0 Then
                    'If MessageBox.Show("supplier not exist in database!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
                    '    Exit Sub
                    'End If
                    err1.dr_no = row.Cells("dr_no").Value
                    err1.error_msg = "supplier not exist in database"
                    errorHandler_in.Add(err1)
                    Exit Sub
                End If

                Dim ids As New list_of_ids

                ids.dr_item_id = dr_item_id
                ids.driver_id = driver_id
                ids.supplier_id = supplier_id
                ids.equipListID = equipListID
                ids.inout = row.Cells("inout").Value

                idsHandler_in.Add(ids)
#End Region

            End If
        Next

#Region "UPDATE FOR OUT"

        If errorHandler_out.Count > 0 Then 'IF THERES AN ERROR
            Dim msg As String = ""
            For Each row As list_of_errors In errorHandler_out
                msg = msg & "DR: " & row.dr_no & " - " & row.error_msg & vbCrLf
            Next

            MessageBox.Show(msg, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        Else
            'OG OK ANG LAHAT SA TAAS FILTER | UPDATE NA!
            'dr and dr info update

            For Each row As list_of_ids In idsHandler_out

                update_drdata_out2(row.driver_id, row.equipListID, row.supplier_id, row.dr_item_id)

            Next

            'rs update
            'update_rs_data2()
        End If
#End Region

#Region "UPDATE FOR IN"
        If errorHandler_in.Count > 0 Then 'IF THERE IS AN ERROR
            Dim msg As String = ""
            For Each row As list_of_errors In errorHandler_in
                msg = msg & "DR: " & row.dr_no & " - " & row.error_msg & vbCrLf
            Next
            MessageBox.Show(msg, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        Else
            'OG OK ANG LAHAT SA TAAS FILTER | UPDATE NA!
            'dr and dr info update

            For Each row As list_of_ids In idsHandler_in

                'update_drdata_out2(row.driver_id, row.equipListID, row.supplier_id, row.dr_item_id)
                update_drdata_in2(row.driver_id, row.equipListID, row.supplier_id, row.dr_item_id)

                'rs update
                update_rs_data2(row.dr_item_id)
            Next

            'rs update
            'update_rs_data2()
        End If
#End Region

        MessageBox.Show("Successfully Updated!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FDRLIST1.whTOwh.Close()
        FDRLIST1.btnSearch.PerformClick()

    End Sub
    Private Sub firstrow()
        Dim no_of_errors As Integer

        For Each row As DataGridViewRow In dgvData.Rows

        Next

        'filter sa ang mga ids and others og nag exist ba sa database

        Dim wh_id As Integer = dgvData.Rows(0).Cells("wh_id").Value
        Dim rs_id As Integer = dgvData.Rows(0).Cells("rs_id").Value
        Dim dr_no As String = dgvData.Rows(0).Cells("dr_no").Value

        Dim driver As String = dgvData.Rows(0).Cells("driver").Value
        Dim mod_driver As New Model._Mod_Driver
        Dim driver_id As Integer = mod_driver.if_exist(driver)

        If driver_id = 0 Then
            If MessageBox.Show("Driver name not exist in database, still want to continue?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim plateno As String = dgvData.Rows(0).Cells("plateno").Value
        Dim mod_plateno As New Model._Mod_Equipment
        Dim equipListID As Integer = mod_plateno.if_exist(plateno)

        If equipListID = 0 Then
            If MessageBox.Show("plateno not exist in database, still want to continue?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim supplier As String = dgvData.Rows(0).Cells("supplier").Value
        Dim mod_supplier As New Model._Mod_Supplier
        Dim supplier_id As Integer = mod_supplier.if_exist(supplier)

        If supplier_id = 0 Then
            If MessageBox.Show("supplier not exist in database!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
                Exit Sub
            End If
        End If


        'OG OK ANG LAHAT SA TAAS FILTER | UPDATE NA!
        'dr and dr info update

        'update_drdata_out(driver_id, equipListID, supplier_id)
        update_drdata_out(driver_id, equipListID, supplier_id)
        update_drdata_in(driver_id, equipListID, supplier_id)

        'rs update
        update_rs_data()

        MessageBox.Show("Successfully Updated!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FDRLIST1.whTOwh.Close()
        FDRLIST1.btnSearch.PerformClick()


    End Sub
    Private Sub update_drdata_out2(Optional driver_id As Integer = 0, Optional equipListID As Integer = 0, Optional supplier_id As Integer = 0, Optional dr_item_id As Integer = 0)

        For Each row As DataGridViewRow In dgvData.Rows
            If row.Cells(NameOf(cProps.dr_item_id)).Value = dr_item_id Then
                'DR DESC
                Dim dbDeliveryReport_items As New Model_King_Dynamic_Update()

                Dim cv As New Dictionary(Of String, Object)()
                cv.Add("dr_no", row.Cells("dr_no").Value)

                dbDeliveryReport_items.UpdateData("dbDeliveryReport_items", cv, $"dr_items_id = {dr_item_id}")

                '=======================================================

                'DR INFO
                Dim dbDeliveryReport_info As New Model_King_Dynamic_Update()
                Dim dr_info_id As Integer = row.Cells("dr_info_id").Value


                Dim c As New Dictionary(Of String, Object)()
                c.Add("date", row.Cells("dr_date").Value)
                c.Add("price", dgvData.Rows(0).Cells("price").Value)
                c.Add("concession_ticket_no", row.Cells(NameOf(cProps.concession_ticket)).Value)
                c.Add("operator_id", driver_id)
                c.Add("operator_outsource", row.Cells("driver").Value)
                c.Add("equipListID", equipListID)
                c.Add("plate_no_outsource", row.Cells("plateno").Value)
                c.Add("checkedBy", row.Cells("checked_by").Value)
                c.Add("receivedby", row.Cells("received_by").Value)
                c.Add("supplier_id", supplier_id)

                dbDeliveryReport_info.UpdateData("dbDeliveryReport_info", c, $"dr_info_id = {dr_info_id}")

                '=======================================================

                'WS INFO
                Dim dbPO_details As New Model_King_Dynamic_Update()
                Dim rs_id As Integer = row.Cells("rs_id").Value

                Dim cc As New Dictionary(Of String, Object)()
                cc.Add("unit_price", row.Cells("price").Value)

                dbPO_details.UpdateData("dbPO_details", cc, $"rs_id = {rs_id}")
            End If
        Next

    End Sub


    Private Sub update_drdata_out(Optional driver_id As Integer = 0, Optional equipListID As Integer = 0, Optional supplier_id As Integer = 0)
        'DR DESC
        Dim dbDeliveryReport_items As New Model_King_Dynamic_Update()
        Dim dr_item_id As Integer = dgvData.Rows(0).Cells(NameOf(cProps.dr_item_id)).Value


        Dim columnValues As New Dictionary(Of String, Object)()
        columnValues.Add("dr_no", dgvData.Rows(0).Cells("dr_no").Value)

        dbDeliveryReport_items.UpdateData("dbDeliveryReport_items", columnValues, $"dr_items_id = {dr_item_id}")

        '=======================================================

        'DR INFO
        Dim dbDeliveryReport_info As New Model_King_Dynamic_Update()
        Dim dr_info_id As Integer = dgvData.Rows(0).Cells("dr_info_id").Value


        Dim columnValues2 As New Dictionary(Of String, Object)()
        columnValues2.Add("date", dgvData.Rows(0).Cells("dr_date").Value)
        'columnValues2.Add("price", dgvData.Rows(0).Cells("price").Value)
        columnValues2.Add("concession_ticket_no", dgvData.Rows(0).Cells(NameOf(cProps.concession_ticket)).Value)
        columnValues2.Add("operator_id", driver_id)
        columnValues2.Add("operator_outsource", dgvData.Rows(0).Cells("driver").Value)
        columnValues2.Add("equipListID", equipListID)
        columnValues2.Add("plate_no_outsource", dgvData.Rows(0).Cells("plateno").Value)
        columnValues2.Add("checkedBy", dgvData.Rows(0).Cells("checked_by").Value)
        columnValues2.Add("receivedby", dgvData.Rows(0).Cells("received_by").Value)
        columnValues2.Add("supplier_id", supplier_id)

        dbDeliveryReport_info.UpdateData("dbDeliveryReport_info", columnValues2, $"dr_info_id = {dr_info_id}")


        '=======================================================

        'WS INFO
        Dim dbPO_details As New Model_King_Dynamic_Update()
        Dim rs_id As Integer = dgvData.Rows(0).Cells("rs_id").Value

        Dim columnValues3 As New Dictionary(Of String, Object)()
        columnValues3.Add("unit_price", dgvData.Rows(0).Cells("price").Value)

        dbPO_details.UpdateData("dbPO_details", columnValues3, $"rs_id = {rs_id}")
    End Sub


    Private Sub update_drdata_in2(Optional driver_id As Integer = 0, Optional equipListID As Integer = 0, Optional supplier_id As Integer = 0, Optional dr_item_id As Integer = 0)
        'DR DESC
        For Each row As DataGridViewRow In dgvData.Rows
            If row.Cells(NameOf(cProps.dr_item_id)).Value = dr_item_id Then
                Dim dynamicUpdater As New Model_King_Dynamic_Update()
                'Dim dr_item_id As Integer = row.Cells("dr_items_id").Value

                Dim columnValues As New Dictionary(Of String, Object)()
                columnValues.Add("dr_no", row.Cells("dr_no").Value)
                columnValues.Add("wh_id", row.Cells("wh_id").Value)

                dynamicUpdater.UpdateData("dbDeliveryReport_items", columnValues, $"dr_items_id = {dr_item_id}")

                '=======================================================

                'DR INFO
                Dim dbDeliveryReport_info As New Model_King_Dynamic_Update()
                Dim dr_info_id As Integer = row.Cells("dr_info_id").Value


                Dim columnValues2 As New Dictionary(Of String, Object)()
                columnValues2.Add("date", row.Cells("dr_date").Value)
                'columnValues2.Add("price", dgvData.Rows(1).Cells("price").Value)
                columnValues2.Add("concession_ticket_no", row.Cells(NameOf(cProps.concession_ticket)).Value)
                columnValues2.Add("operator_id", driver_id)
                columnValues2.Add("operator_outsource", row.Cells("driver").Value)
                columnValues2.Add("equipListID", equipListID)
                columnValues2.Add("plate_no_outsource", row.Cells("plateno").Value)
                columnValues2.Add("checkedBy", row.Cells("checked_by").Value)
                columnValues2.Add("receivedby", row.Cells("received_by").Value)
                columnValues2.Add("supplier_id", supplier_id)

                dbDeliveryReport_info.UpdateData("dbDeliveryReport_info", columnValues2, $"dr_info_id = {dr_info_id}")

                'MsgBox("Successfully Updated..!")
            End If
        Next


    End Sub

    Private Sub update_drdata_in(Optional driver_id As Integer = 0, Optional equipListID As Integer = 0, Optional supplier_id As Integer = 0)
        'DR DESC
        Dim dynamicUpdater As New Model_King_Dynamic_Update()
        Dim dr_item_id As Integer = dgvData.Rows(1).Cells(NameOf(cProps.dr_item_id)).Value

        Dim columnValues As New Dictionary(Of String, Object)()
        columnValues.Add("dr_no", dgvData.Rows(1).Cells("dr_no").Value)
        columnValues.Add("wh_id", dgvData.Rows(1).Cells("wh_id").Value)

        dynamicUpdater.UpdateData("dbDeliveryReport_items", columnValues, $"dr_items_id = {dr_item_id}")

        '=======================================================

        'DR INFO
        Dim dbDeliveryReport_info As New Model_King_Dynamic_Update()
        Dim dr_info_id As Integer = dgvData.Rows(1).Cells("dr_info_id").Value


        Dim columnValues2 As New Dictionary(Of String, Object)()
        columnValues2.Add("date", dgvData.Rows(1).Cells("dr_date").Value)
        'columnValues2.Add("price", dgvData.Rows(1).Cells("price").Value)
        columnValues2.Add("concession_ticket_no", dgvData.Rows(1).Cells(NameOf(cProps.concession_ticket)).Value)
        columnValues2.Add("operator_id", driver_id)
        columnValues2.Add("operator_outsource", dgvData.Rows(1).Cells("driver").Value)
        columnValues2.Add("equipListID", equipListID)
        columnValues2.Add("plate_no_outsource", dgvData.Rows(1).Cells("plateno").Value)
        columnValues2.Add("checkedBy", dgvData.Rows(1).Cells("checked_by").Value)
        columnValues2.Add("receivedby", dgvData.Rows(1).Cells("received_by").Value)
        columnValues2.Add("supplier_id", supplier_id)

        dbDeliveryReport_info.UpdateData("dbDeliveryReport_info", columnValues2, $"dr_info_id = {dr_info_id}")

        'MsgBox("Successfully Updated..!")
    End Sub

    Private Sub update_rs_data2(Optional dr_item_id As Integer = 0)
        For Each row As DataGridViewRow In dgvData.Rows

            If row.Cells(NameOf(cProps.dr_item_id)).Value = dr_item_id Then
                Dim dynamicUpdater As New Model_King_Dynamic_Update()
                Dim rs_id As Integer = row.Cells("rs_id").Value

                Dim c As New Dictionary(Of String, Object)()
                c.Add("wh_id", row.Cells("wh_id").Value)

                dynamicUpdater.UpdateData("dbrequisition_slip", c, $"rs_id = {rs_id}")
            End If

        Next
    End Sub

    Private Sub update_rs_data()
        Dim dynamicUpdater As New Model_King_Dynamic_Update()
        Dim dr_item_id As Integer = dgvData.Rows(1).Cells(NameOf(cProps.dr_item_id)).Value
        Dim rs_id As Integer = dgvData.Rows(1).Cells("rs_id").Value

        Dim columnValues As New Dictionary(Of String, Object)()
        columnValues.Add("wh_id", dgvData.Rows(1).Cells("wh_id").Value)

        dynamicUpdater.UpdateData("dbrequisition_slip", columnValues, $"rs_id = {rs_id}")

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub UpdateSupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateSupplierToolStripMenuItem.Click
        txtSearch.Clear()
        button_click_name = "updatesupplier"

        Dim search As New class_placeholder4

        search.king_placeholder_textbox("Supplier...", txtSearch, ListOfSupplier(), Panel2, My.Resources.username_icon, False, "White")

        Panel2.Visible = True
        Panel2.Location = New System.Drawing.Point((Me.Panel1.Width - Panel2.Width) / 2, (Me.Panel1.Height - Panel2.Height) / 2)

        dgvData.Enabled = False
    End Sub

    Private Sub dgvData_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellEnter
        rowIndex = e.RowIndex
    End Sub


    Private Sub PlateNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlateNoToolStripMenuItem.Click
        Dim newValue As String = dgvData.Rows(rowIndex).Cells("plateno").Value

        For Each row As DataGridViewRow In dgvData.Rows
            row.Cells("plateno").Value = newValue
        Next

    End Sub

    Private Sub DriverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DriverToolStripMenuItem.Click
        Dim newValue As String = dgvData.Rows(rowIndex).Cells("driver").Value

        For Each row As DataGridViewRow In dgvData.Rows
            row.Cells("driver").Value = newValue
        Next

    End Sub

    Private Sub SupplierColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierColumnToolStripMenuItem.Click
        Dim newValue As String = dgvData.Rows(rowIndex).Cells("supplier").Value

        For Each row As DataGridViewRow In dgvData.Rows
            row.Cells("supplier").Value = newValue
        Next

    End Sub

    Private Sub RequestorColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestorColumnToolStripMenuItem.Click

        Dim requestor As String = dgvData.Rows(rowIndex).Cells("requestor").Value
        Dim wh_id As Integer = dgvData.Rows(rowIndex).Cells("wh_id").Value

        For Each row As DataGridViewRow In dgvData.Rows
            If row.Cells("inout").Value = "IN" Then
                row.Cells("requestor").Value = requestor
                row.Cells("wh_id").Value = wh_id
            End If
        Next

    End Sub

    Private Sub WhToWhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhToWhToolStripMenuItem.Click
        Dim whToWhIn As New WHtoWH
        Dim mydrdata As New class_DR2.drdata

        Dim whId As Integer = get_id("", "", "", 0)


        With mydrdata
            .wh_id = dgvData.SelectedRows(0).Cells("wh_id").Value
            .rs_no = dgvData.SelectedRows(0).Cells("rs_no").Value

        End With

        MsgBox(mydrdata.wh_id)

        'whToWhIn.insert_data_to_rs("09283515253", Date.Parse(Now), )
    End Sub


    Private Class WHtoWH

        Private Class TableNames
            Public ReadOnly Property REQUISITION As String = "dbrequisition_slip"
            Public ReadOnly Property PO_DETAILS As String = "dbPO_details"
            Public ReadOnly Property PO As String = "dbPO"
            Public ReadOnly Property RECEIVING_ITEMS As String = "dbreceiving_items"
            Public ReadOnly Property RECEIVING_INFO As String = "dbreceiving_info"
            Public ReadOnly Property RECEIVING_ITEM_PARTIALLY As String = "dbreceiving_item_partially"
            Public ReadOnly Property RECEIVING_ITEMS_SUB As String = "dbreceiving_items_sub"
            Public ReadOnly Property DELIVERYREPORT_INFO As String = "dbDeliveryReport_info"
            Public ReadOnly Property DELIVERYREPORT_ITEMS As String = "dbDeliveryReport_items"
        End Class
        '+++++++++++++ IN PROCESS +++++++++++++

        'step 1: insert data to requesition table
        Public Function insert_data_to_rs(rsNo As String,
                                          dateReq As DateTime,
                                          wh_id As Integer,
                                          qty As Double,
                                          date_needed As DateTime,
                                          inOut As String,
                                          typeOfPurchasing As String,
                                          user_id As Integer)

            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("rs_no", rsNo)
                .Add("date_req", dateReq)
                .Add("job_order_no", 0)
                .Add("charge_to", 0)
                .Add("wh_id", wh_id)
                .Add("item_desc", "")
                .Add("qty", qty)
                .Add("unit", "")
                .Add("typeRequest", "")
                .Add("process", "")
                .Add("purpose", "")
                .Add("date_needed", date_needed)
                .Add("requested_by", "")
                .Add("noted_by", "")
                .Add("wh_incharge", "")
                .Add("approved_by", "")
                .Add("IN_OUT", inOut)
                .Add("date_log", Now)
                .Add("type_of_purchasing", typeOfPurchasing)
                .Add("user_id", user_id)
                .Add("remarks", 0)
            End With

            insert_data_to_rs = _dr.InsertData_and_return_id(newTableNames.REQUISITION, columnValues)

        End Function

        'step 2: insert data to Po table with po_id
        Public Function insert_data_to_po(poDate As DateTime,
                                          rsNo As String,
                                          dateNeeded As DateTime,
                                          dateLog As DateTime,
                                          drOption As String,
                                          user_id As Integer)

            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("po_date", poDate)
                .Add("rs_no", rsNo)
                .Add("instructor", "n/a")
                .Add("charge_to_id", 0)
                .Add("charge_type", "n/a")
                .Add("date_needed", dateNeeded)
                .Add("prepared_by", "n/a")
                .Add("checked_by", "n/a")
                .Add("approved_by", "n/a")
                .Add("user_id", user_id)
                .Add("date_log", dateLog)
                .Add("dr_option", drOption)

            End With

            insert_data_to_po = _dr.InsertData_and_return_id(newTableNames.PO, columnValues)

        End Function

        'step 3: insert data to PoDetails table with rs_id

        Public Function insert_data_to_poDetails(poId As Integer,
                                                 qty As String,
                                                 rs_id As Integer
                                                 )

            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("po_id", poId)
                .Add("supplier_id", 0)
                .Add("wh_id", 0)
                .Add("item_desc", "")
                .Add("po_no", 0)
                .Add("terms", "")
                .Add("qty", qty)
                .Add("unit", "")
                .Add("unit_price", 0)
                .Add("amount", 0)
                .Add("rs_id", rs_id)
                .Add("selected", "TRUE")
                .Add("lof_id", 0)
                .Add("print_status", "")
                .Add("print_date_logs", Date.Parse("1990-01-01"))
                .Add("user_id_logs", 0)
            End With

            insert_data_to_poDetails = _dr.InsertData_and_return_id(newTableNames.PO_DETAILS, columnValues)
        End Function

        'step 4: insert data to receiving_info with supplier_id, date_received ...

        Public Function insert_data_to_receiving_info(supplierId As Integer,
                                                      dateReceived As DateTime,
                                                      dateLog As DateTime,
                                                      user_id As Integer,
                                                      dateSubmitted As DateTime)
            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("rr_no", "n/a")
                .Add("invoice_no", "n/a")
                .Add("supplier_id", supplierId)
                .Add("po_no", "n/a")
                .Add("rs_no", "n/a")
                .Add("date_received", dateReceived)
                .Add("received_by", "n/a")
                .Add("checked_by", "n/a")
                .Add("received_status", "PENDING")
                .Add("so_no", "n/a")
                .Add("hauler", "n/a")
                .Add("plateno", "n/a")
                .Add("Plateno_id", 0)
                .Add("insource_outsource", "")
                .Add("operator_id", 0)
                .Add("operator_name", "")
                .Add("date_log", dateLog)
                .Add("user_id", user_id)
                .Add("date_submitted", dateSubmitted)
            End With

            insert_data_to_receiving_info = _dr.InsertData_and_return_id(newTableNames.RECEIVING_INFO, columnValues)
        End Function

        'step 5: insert data to receiving_items with rr_info_id, qty rs_id and po_det_id
        Public Function insert_data_to_receiving_items(rrInfoId As Integer,
                                                       qty As Double,
                                                       rs_id As Integer,
                                                       po_det_id As Integer)
            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("rr_info_id", rrInfoId)
                .Add("qty", qty)
                .Add("item_description", "")
                .Add("remarks", "")
                .Add("wh_id", 0)
                .Add("rs_id", rs_id)
                .Add("po_det_id", po_det_id)
                .Add("selected", "Include")

            End With

            insert_data_to_receiving_items = _dr.InsertData_and_return_id(newTableNames.RECEIVING_ITEMS, columnValues)
        End Function

        'step 6: insert data to receiving_item_partially with rr_item_id and qty

        Public Function insert_data_to_receiving_item_partially(rrItemId As Integer,
                                                                desiredQty As Double) As Integer
            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("rr_item_id", rrItemId)
                .Add("desired_qty", desiredQty)

            End With

            insert_data_to_receiving_item_partially = _dr.InsertData_and_return_id(newTableNames.RECEIVING_ITEM_PARTIALLY, columnValues)

        End Function

        'step 7: insert data to DeliveryReport_info with 

        Public Function insert_data_to_deliveryReport_info(drDate As DateTime,
                                                           equipListId As Integer,
                                                           operatorId As Integer,
                                                           requestorId As Integer,
                                                           rsNo As String,
                                                           supplierId As Integer,
                                                           concession As String,
                                                           checkedBy As String,
                                                           receivedBy As String,
                                                           wsNo As String,
                                                           plateNo As String,
                                                           price As Double,
                                                           plateNoOutsource As String,
                                                           operatorOutsource As String,
                                                           remarks As String)
            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("date", drDate)
                .Add("time_from", Date.Parse("1991-01-01"))
                .Add("time_to", Date.Parse("1991-01-01"))
                .Add("equipListID", equipListId)
                .Add("operator_id", operatorId)
                .Add("type_of_request", "")
                .Add("requestor_id", 0)
                .Add("address", "")
                .Add("rs_no", rsNo)
                .Add("supplier_id", supplierId)
                .Add("concession_ticket_no", concession)
                .Add("checkedBy", checkedBy)
                .Add("receivedBy", receivedBy)
                .Add("options", "W/ DR")
                .Add("ws_no", wsNo)
                .Add("remarks", remarks)
                .Add("plate_no", plateNo)
                .Add("price", 0)
                .Add("rr_no", "")
                .Add("plate_no_outsource", plateNoOutsource)
                .Add("operator_outsource", operatorOutsource)

            End With

            insert_data_to_deliveryReport_info = _dr.InsertData_and_return_id(newTableNames.DELIVERYREPORT_INFO, columnValues)
        End Function

        'step 8: insert data to DeliveryReport_items

        Public Sub insert_data_to_deliveryReport_items(drInfoId As Integer,
                                                            drNo As String,
                                                            category As String,
                                                            sourceId As Integer,
                                                            whId As Integer,
                                                            qty As Double,
                                                            par_rr_item_id As Integer,
                                                            rsId As Integer,
                                                            user_id As Integer)
            Dim _dr As New Model_King_Dynamic_Update
            Dim newTableNames As New TableNames

            Dim columnValues As New Dictionary(Of String, Object)()
            With columnValues
                .Add("dr_info_id", drInfoId)
                .Add("dr_no", drNo)
                .Add("category", category)
                .Add("source_id", sourceId)
                .Add("wh_id", whId)
                .Add("qty", qty)
                .Add("rs_id", rsId)
                .Add("ws_id", 0)
                .Add("par_rr_item_id", par_rr_item_id)
                .Add("in_to_stockcard", "YES")
                .Add("user_id", user_id)
            End With

            _dr.InsertData(newTableNames.DELIVERYREPORT_ITEMS, columnValues)
        End Sub

    End Class

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If dgvData.Rows.Count = 1 Then
            button_click_name = "whToWhUpdateIn"
            cListOfItems = ListOfItems()

            Dim _items As New List(Of String)
            For Each item In cListOfItems
                _items.Add($"{item.itemDesc.ToUpper()} | {item.whArea.ToUpper()} | {item.source.ToUpper() }")
            Next

            UISearch.king_placeholder_textbox("Aggregates/Items....", txtSearch, _items, Panel2, My.Resources.username_icon, False, "White")

            Panel2.Visible = True
            Panel2.Location = New System.Drawing.Point((Me.Panel1.Width - Panel2.Width) / 2, (Me.Panel1.Height - Panel2.Height) / 2)

            dgvData.Enabled = False
        ElseIf dgvData.Rows.Count > 1 Then
            customMsgBox.message("error", "you can't add transaction if IN transaction has been added!", "SUPPLY INFO:")

        ElseIf dgvData.Rows.Count = 0 Then
            customMsgBox.message("error", "there is no items has been found!", "SUPPLY INFO:")
        End If

    End Sub

    Public Sub addWh_to_Wh_In(paramWhId As Integer)
        Dim drdata As New class_DR2.drdata

        'start: ======== get id's and specific column data =============
        Dim supplierId As Integer = get_id2("dbSupplier a",
                                            $"a.Supplier_Name = '{dgvData.Rows(0).Cells("supplier").Value}'",
                                            "a.Supplier_Id")

        Dim equipListId As Integer = get_id2("dbequipment_list a",
                                             $"UPPER(a.plate_no) = '{dgvData.Rows(0).Cells("plateno").Value.ToString.ToUpper()}'",
                                             "a.equipListID",
                                             newTblNameType.eus_table)

        Dim operatorId As Integer = get_id2("dboperator a",
                                            $"UPPER(a.operator_name) = '{dgvData.Rows(0).Cells("driver").Value.ToString.ToUpper()}'",
                                            "a.operator_id",
                                            newTblNameType.eus_table)

        Dim plateNoOutSource As String = get_specific_data("dbDeliveryReport_info a",
                                                           $"a.dr_info_id = {dgvData.Rows(0).Cells("dr_info_id").Value}",
                                                           "a.plate_no_outsource")

        Dim operatorOutsource As String = get_specific_data("dbDeliveryReport_info a",
                                                           $"a.dr_info_id = {dgvData.Rows(0).Cells("dr_info_id").Value}",
                                                           "a.operator_outsource")

        Dim remarks As String = get_specific_data("dbDeliveryReport_info a",
                                                  $"a.dr_info_id = {dgvData.Rows(0).Cells("dr_info_id").Value}",
                                                  "a.remarks")

        Dim sourceId As Integer = get_specific_data("dbDeliveryReport_items a",
                                                    $"a.dr_items_id = {dgvData.Rows(0).Cells(NameOf(cProps.dr_item_id)).Value}",
                                                    "a.source_id")
        'end 

        'if rows only 1: pasabot walay in
        If dgvData.Rows.Count = 1 Then
            With drdata
                .rs_no = dgvData.Rows(0).Cells("rs_no").Value
                .dr_date = dgvData.Rows(0).Cells("dr_date").Value
                .wh_id = dgvData.Rows(0).Cells("wh_id").Value
                .dr_qty = dgvData.Rows(0).Cells("dr_qty").Value
                .dr_no = dgvData.Rows(0).Cells("dr_no").Value
                .inout = "IN"
                .concession = dgvData.Rows(0).Cells(NameOf(cProps.concession_ticket)).Value
                .checked_by = dgvData.Rows(0).Cells("checked_by").Value
                .received_by = dgvData.Rows(0).Cells("received_by").Value
                .ws_no = dgvData.Rows(0).Cells("ws_po_no").Value
                .plateno = dgvData.Rows(0).Cells("plateno").Value
                .price = dgvData.Rows(0).Cells("price").Value
                .rs_id = dgvData.Rows(0).Cells("rs_id").Value
            End With
        Else
            customMsgBox.message("error", "IN transaction has been already added!", "SUPPLY INFO:")
            Exit Sub
        End If


        Dim _drNew As New WHtoWH

        With drdata

            '------ RS --------
            Dim rs_id As Integer = _drNew.insert_data_to_rs(.rs_no,
                                    .dr_date,
                                    paramWhId,
                                    .dr_qty,
                                    .dr_date,
                                    .inout,
                                    "DR",
                                    pub_user_id
                                    )

            '------ PO --------
            Dim po_id As Integer = _drNew.insert_data_to_po(
                                    .dr_date,
                                    .rs_no,
                                    .dr_date,
                                    Now,
                                    "W/ DR",
                                    pub_user_id)

            Dim po_det_id As Integer = _drNew.insert_data_to_poDetails(po_id, .dr_qty, rs_id)

            '------ RR INFO --------
            Dim rr_info_id As Integer = _drNew.insert_data_to_receiving_info(supplierId,
                                                                             .dr_date,
                                                                             Now,
                                                                             pub_user_id,
                                                                              Date.Parse("1990-01-01"))

            '------ RR ITEMS --------
            Dim rr_item_id As Integer = _drNew.insert_data_to_receiving_items(rr_info_id, .dr_qty, rs_id, po_det_id)

            '------ RR ITEM PARTIALLY--------
            Dim par_rr_item_id As Integer = _drNew.insert_data_to_receiving_item_partially(rr_item_id, .dr_qty)

            '------ DR INFO --------
            Dim dr_info_id As Integer = _drNew.insert_data_to_deliveryReport_info(.dr_date,
                                                                                 equipListId,
                                                                                 operatorId,
                                                                                 .requestor_id,
                                                                                 .rs_no,
                                                                                 supplierId,
                                                                                 .concession,
                                                                                 .checked_by,
                                                                                 .received_by,
                                                                                 .ws_no,
                                                                                 .plateno,
                                                                                 .price,
                                                                                 plateNoOutSource,
                                                                                 operatorOutsource,
                                                                                 remarks)

            ''------ DR ITEMS --------
            _drNew.insert_data_to_deliveryReport_items(dr_info_id,
                                                        .dr_no,
                                                        "WAREHOUSE",
                                                        sourceId,
                                                        paramWhId,
                                                        .dr_qty,
                                                        par_rr_item_id,
                                                        rs_id,
                                                        pub_user_id
                                                        )


        End With
    End Sub

    Private Sub FWHtoWH_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub



    'GET


End Class




