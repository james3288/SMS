Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frmQuanitityTakeOff
    Public SQLcon As New SQLcon ' new declaration sa sqlconnection
    Public sqldr As SqlDataReader
    Public project_code As String
    Dim local_project_id As Integer
    Dim list_of_items As New List(Of List(Of String))
    Private Sub frmQuanitityTakeOff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        local_project_id = get_project_id(project_code)
        'MsgBox(project_id)
        If local_project_id > 0 Then
            display_variation_order(local_project_id, "")
            display_revision_codes(local_project_id)
        Else
            MsgBox("1. Project Code not exist, check spelling or remove spaces")
            Me.Dispose()
        End If

    End Sub
    Sub search_item(ByVal val As String)
        ListView1.Items.Clear()
        For Each item_0 In list_of_items
            If item_0(2).ToLower.Contains(val.ToLower) Or item_0(3).ToLower.Contains(val.ToLower) Or item_0(4).ToLower.Contains(val.ToLower) Or item_0(5).ToLower.Contains(val.ToLower) Or item_0(6).ToLower.Contains(val.ToLower) Then
                Dim item As New ListViewItem(item_0(0).ToString())
                item.SubItems.Add(item_0(1).ToString())
                item.SubItems.Add(item_0(2).ToString().ToUpper)
                item.SubItems.Add(item_0(3).ToString())
                item.SubItems.Add(item_0(4).ToString())
                item.SubItems.Add(item_0(5).ToString())
                item.SubItems.Add(item_0(6).ToString())
                ListView1.Items.Add(item)
            End If

        Next
    End Sub
    Sub display_revision_codes(ByVal project_id As String)

        ComboBox1.Items.Clear()
            Dim query As String = "select a.variation_name from [PCMBS].[dbo].[VariationOrder] a where a.project_id = " & project_id
            Try
                Dim cmd As SqlCommand
            SQLcon.connection.Open()

            cmd = New SqlCommand(query, SQLcon.connection)
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.Text

                sqldr = cmd.ExecuteReader
                While sqldr.Read
                    ComboBox1.Items.Add(sqldr(0).ToString)
                End While
                sqldr.Close()
            Catch ex As Exception
                MsgBox("Something is Wrong in combobox in frmQuantityTakeOff!")
            Finally
                SQLcon.connection.Close()
            End Try
    End Sub
    Sub display_variation_order(ByVal project_id As String, ByVal revision As String)
        ListView1.Items.Clear()
        Dim str_rev As String = ""
        If revision.Equals("") Then
            str_rev = "and b.variation_order_id = (select max(aa.variation_order_id) from [PCMBS].[dbo].VariationOrder aa where aa.variation_order_no = b.variation_order_no and aa.project_id = a.project_id)"
        Else
            str_rev = "and b.variation_name = '" & revision & "'"
        End If
        Dim query As String = "select 
	                                c.item_list_id
	                                ,d.item_details_id
	                                ,a.project_code
	                                ,a.contract_id
	                                ,b.variation_order_no
	                                ,b.variation_name
	                                ,e.item_no
	                                ,e.item_description
	                                ,c.unit
	                                ,c.quantity
	                                ,d.[item_details_description]
	                                ,d.unit
	                                ,d.quantity
                                    ,c.item_list_description
                                    ,(select top 1 aa.part_code from [PCMBS].[dbo].Parts aa where aa.part_id = c.part_id and aa.status = 'active') as PART
                                    ,c.remarks
                                FROM [PCMBS].[dbo].[Projects] a
                                inner join [PCMBS].[dbo].[VariationOrder] b on b.project_id = a.project_id and b.status = 'active'
                                inner join [PCMBS].[dbo].[ItemList] c on c.variation_order_id = b.variation_order_id and c.status = 'active'
                                inner join [PCMBS].[dbo].[ItemDetails] d on d.item_list_id = c.item_list_id and d.status = 'active' 
                                left join [PCMBS].[dbo].[Items] e on e.item_id = c.item_id
                                where b.variation_order_no = (select MAX(CAST(variation_order_no AS INT)) from [PCMBS].[dbo].[VariationOrder] aa where aa.project_id = a.project_id and status = 'active')
                                " & str_rev & "
                                and a.project_id = " & project_id & "
                                ORDER BY 
                                    -- Alphabetical part before the first number
                                    CASE 
                                        WHEN PATINDEX('%[0-9]%', e.item_no) > 1 
                                        THEN LEFT(e.item_no, PATINDEX('%[0-9]%', e.item_no) - 1)
                                        ELSE e.item_no 
                                    END,

                                    -- First numeric part (before parentheses or period)
                                    CASE 
                                        WHEN PATINDEX('%[0-9]%', e.item_no) > 0 
                                             AND ISNUMERIC(REPLACE(SUBSTRING(e.item_no, PATINDEX('%[0-9]%', e.item_no), 
                                             CHARINDEX('(', e.item_no + '(') - PATINDEX('%[0-9]%', e.item_no)), '.', '')) = 1
                                        THEN CAST(REPLACE(SUBSTRING(e.item_no, PATINDEX('%[0-9]%', e.item_no), 
                                            CHARINDEX('(', e.item_no + '(') - PATINDEX('%[0-9]%', e.item_no)), '.', '') AS INT)
                                        ELSE NULL 
                                    END,

                                    -- Number inside parentheses, if present (handle them as numbers)
                                    CASE 
                                        WHEN CHARINDEX('(', e.item_no) > 0 
                                             AND ISNUMERIC(REPLACE(SUBSTRING(e.item_no, CHARINDEX('(', e.item_no) + 1, 
                                             CHARINDEX(')', e.item_no) - CHARINDEX('(', e.item_no) - 1), ')', '')) = 1
                                        THEN CAST(REPLACE(SUBSTRING(e.item_no, CHARINDEX('(', e.item_no) + 1, 
                                            CHARINDEX(')', e.item_no) - CHARINDEX('(', e.item_no) - 1), ')', '') AS INT)
                                        ELSE NULL 
                                    END,

                                    -- Handle any remaining numeric parts after parentheses or dots
                                    CASE 
                                        WHEN CHARINDEX('.', e.item_no) > 0 
                                             AND ISNUMERIC(SUBSTRING(e.item_no, CHARINDEX('.', e.item_no) + 1, LEN(e.item_no))) = 1
                                        THEN CAST(SUBSTRING(e.item_no, CHARINDEX('.', e.item_no) + 1, LEN(e.item_no)) AS INT)
                                        ELSE NULL 
                                    END
                                    ,c.unit desc"
        'MsgBox(query)
        Try
            Dim cmd As SqlCommand
            SQLcon.connection.Open()
            cmd = New SqlCommand(query, SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            sqldr = cmd.ExecuteReader
            While sqldr.Read
                txtPCMProject.Text = sqldr(2).ToString()
                TextBox1.Text = sqldr(4).ToString
                TextBox2.Text = sqldr(3).ToString
                ComboBox1.Text = sqldr(5).ToString
                Dim item As New ListViewItem(sqldr(0).ToString())
                item.SubItems.Add(sqldr(1).ToString())
                item.SubItems.Add(sqldr(6).ToString().ToUpper)
                item.SubItems.Add(sqldr(13).ToString())
                item.SubItems.Add(sqldr(10).ToString())
                item.SubItems.Add(sqldr(11).ToString())
                item.SubItems.Add(sqldr(12).ToString())
                item.SubItems.Add(sqldr(14).ToString())
                item.SubItems.Add(sqldr(15).ToString())
                ListView1.Items.Add(item)

                Dim list_sample As New List(Of String)
                list_sample.Add(sqldr(0).ToString())
                list_sample.Add(sqldr(1).ToString())
                list_sample.Add(sqldr(6).ToString().ToUpper)
                list_sample.Add(sqldr(13).ToString())
                list_sample.Add(sqldr(10).ToString())
                list_sample.Add(sqldr(11).ToString())
                list_sample.Add(sqldr(12).ToString())
                list_sample.Add(sqldr(14).ToString())
                list_sample.Add(sqldr(15).ToString())
                list_of_items.Add(list_sample)
            End While
            sqldr.Close()
        Catch ex As Exception
            MsgBox("Something is Wrong in Listview in frmQuantityTakeOff!")
            MessageBox.Show(ex.Message)
        Finally
            'MsgBox("asd")
            SQLcon.connection.Close()
        End Try

    End Sub

    Function get_project_id(ByVal project_code As String) As Integer
        Dim query As String = "select a.project_id from [PCMBS].[dbo].[Projects] a where REPLACE(REPLACE(REPLACE(a.project_code, ' ', ''), CHAR(9), ''), CHAR(10), '') = REPLACE(REPLACE(REPLACE('" & project_code & "', ' ', ''), CHAR(9), ''), CHAR(10), '')"

        Dim project_id As Integer = 0
        Try
            Dim cmd As SqlCommand
            SQLcon.connection.Open()

            cmd = New SqlCommand(query, SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            sqldr = cmd.ExecuteReader
            While sqldr.Read
                project_id = sqldr(0).ToString
            End While
            sqldr.Close()
        Catch ex As Exception
            MsgBox("Something is Wrong!")
        Finally
            SQLcon.connection.Close()
        End Try
        Return project_id
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub frmQuanitityTakeOff_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'ListView1.Items.Clear()
        Me.Dispose()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If FCreateChargesNew.Visible Then
            FCreateChargesNew.item_details_id = ListView1.SelectedItems(0).SubItems(1).Text
            FCreateChargesNew.item_details_desc = ListView1.SelectedItems(0).SubItems(2).Text & " " & ListView1.SelectedItems(0).SubItems(3).Text & " - " & ListView1.SelectedItems(0).SubItems(4).Text

        ElseIf FRequisition_Non_Item.Visible Then

            FRequisition_Non_Item.item_details_id = ListView1.SelectedItems(0).SubItems(1).Text
            FRequisition_Non_Item.item_details_desc = ListView1.SelectedItems(0).SubItems(2).Text & " " & ListView1.SelectedItems(0).SubItems(3).Text & " - " & ListView1.SelectedItems(0).SubItems(4).Text
        ElseIf FLiquidationReport.Visible Then

            FLiquidationReport.item_details_id = ListView1.SelectedItems(0).SubItems(1).Text
            FLiquidationReport.item_details_desc = ListView1.SelectedItems(0).SubItems(2).Text & " " & ListView1.SelectedItems(0).SubItems(3).Text & " - " & ListView1.SelectedItems(0).SubItems(4).Text

        Else
            MsgBox("something is wrong in form request")
        End If

        Me.Dispose()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If local_project_id > 0 Then
            display_variation_order(local_project_id, ComboBox1.Text)
            'display_revision_codes(local_project_id)
        Else
            MsgBox("Project Code not exist, check spelling or remove spaces")
            Me.Dispose()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        search_item(TextBox3.Text)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class