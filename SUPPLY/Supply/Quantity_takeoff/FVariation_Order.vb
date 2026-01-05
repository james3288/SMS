Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FVariation_Order
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub FVariation_Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim proj_id As Integer = 0
            Dim qto_id As Integer = 0
            Dim const_id As Integer = 0

            'With FQty_takeoff
            '    proj_id = CInt(.lbl_proj_id.Text)
            '    qto_id = CInt(.lbl_qto_id.Text)
            '    const_id = CInt(.lbl_const_id.Text)
            'End With

            load_Fvariation_order(proj_id, qto_id, const_id)
        Catch ex As Exception

        End Try

        load_const_item()
    End Sub
    Public Sub load_Fvariation_order(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer)
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        lvl_vo.Items.Clear()
        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_Quantity_takeoff"
            sqlcommand.Parameters.Clear()
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 26)
            sqlcommand.Parameters.AddWithValue("@proj_id", x)
            sqlcommand.Parameters.AddWithValue("@qty_off_id", y)
            sqlcommand.Parameters.AddWithValue("@const_id", z)

            sqlcommand.CommandTimeout = 0

            dr = sqlcommand.ExecuteReader
            While dr.Read
                Dim a(15) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = dr.Item(6).ToString
                a(7) = dr.Item(7).ToString
                a(8) = dr.Item(8).ToString
                a(9) = dr.Item(9).ToString
                a(10) = dr.Item(10).ToString
                a(11) = dr.Item(11).ToString
                a(12) = dr.Item(12).ToString
                a(13) = dr.Item(13).ToString
                a(14) = dr.Item(14).ToString

                Dim newList As New ListViewItem(a)
                lvl_vo.Items.Add(newList)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub
    Public Sub load_vo(value As String)
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        lvl_vo.Items.Clear()
        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_Quantity_takeoff"
            sqlcommand.Parameters.Clear()
            sqlcommand.CommandType = CommandType.StoredProcedure

            If cmb_searchby.Text = "All" Then
                sqlcommand.Parameters.AddWithValue("@n", 25)
                sqlcommand.Parameters.AddWithValue("@const_item_name", cmb_itemName.Text)
                sqlcommand.Parameters.AddWithValue("@const_item_desc", cmb_itemDesc.Text)
            Else
                sqlcommand.Parameters.AddWithValue("@n", 21)
            End If

            sqlcommand.Parameters.AddWithValue("@value", value)
            sqlcommand.CommandTimeout = 0

            dr = sqlcommand.ExecuteReader
            While dr.Read
                Dim a(15) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = dr.Item(6).ToString
                a(7) = dr.Item(7).ToString
                a(8) = dr.Item(8).ToString
                a(9) = dr.Item(9).ToString
                a(10) = dr.Item(10).ToString
                a(11) = dr.Item(11).ToString
                a(12) = dr.Item(12).ToString
                a(13) = dr.Item(13).ToString
                a(14) = dr.Item(14).ToString

                Dim newList As New ListViewItem(a)
                lvl_vo.Items.Add(newList)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub

    Sub load_const_item()
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        cmb_itemName.Items.Clear()

        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_Quantity_takeoff"
            sqlcommand.Parameters.Clear()
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 22)
            sqlcommand.CommandTimeout = 0

            dr = sqlcommand.ExecuteReader
            While dr.Read
                cmb_itemName.Items.Add(dr.Item(1).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub

    Private Sub cmb_itemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_itemName.SelectedIndexChanged
        get_const_itemDesc(cmb_itemName.Text)
    End Sub

    Sub get_const_itemDesc(item_name As String)
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        cmb_itemDesc.Items.Clear()

        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_Quantity_takeoff"
            sqlcommand.Parameters.Clear()
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 23)
            sqlcommand.Parameters.AddWithValue("@value", item_name)
            sqlcommand.CommandTimeout = 0

            dr = sqlcommand.ExecuteReader
            While dr.Read
                cmb_itemDesc.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_searchby.SelectedIndexChanged
        If cmb_searchby.Text = "All" Then
        Else
            gbox_search.Visible = False
            cmb_itemName.Text = Nothing
            cmb_itemDesc.Text = Nothing
        End If
        get_proj_desc()
    End Sub

    Private Sub cmb_project_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_projectDesc.SelectedIndexChanged
        Select Case cmb_searchby.Text
            Case "All"
                gbox_search.Visible = True
            Case Else
                gbox_search.Visible = False
                load_vo(cmb_projectDesc.Text)

        End Select
    End Sub

    Sub get_proj_desc()
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        cmb_projectDesc.Items.Clear()

        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_Quantity_takeoff"
            sqlcommand.Parameters.Clear()
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 24)
            sqlcommand.CommandTimeout = 0

            dr = sqlcommand.ExecuteReader
            While dr.Read
                cmb_projectDesc.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        gbox_search.Visible = False
        cmb_itemName.Text = Nothing
        cmb_itemDesc.Text = Nothing
    End Sub

    Private Sub Btn_search_Click(sender As Object, e As EventArgs) Handles Btn_search.Click
        load_vo(cmb_projectDesc.Text)
    End Sub

    Private Sub gbox_search_MouseDown(sender As Object, e As MouseEventArgs) Handles gbox_search.MouseDown, Panel3.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub gbox_search_MouseMove(sender As Object, e As MouseEventArgs) Handles gbox_search.MouseMove, Panel3.MouseMove
        If drag Then
            Dim temp As Point = New Point()

            temp.X = gbox_search.Location.X + (e.X - mousex)
            temp.Y = gbox_search.Location.Y + (e.Y - mousey)
            gbox_search.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub gbox_search_MouseUp(sender As Object, e As MouseEventArgs) Handles gbox_search.MouseUp, Panel3.MouseUp
        If e.Button = MouseButtons.Left Then
            drag = False
        End If
    End Sub
End Class