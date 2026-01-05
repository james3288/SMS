Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Threading
Public Class StockCard2
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Dim mousex As Integer
    Dim mousey As Integer
    Dim th As Threading.Thread
    Dim ST_Data As New Class_StockCard_Hauling.search_wh_data
    Dim crs_data As New Class_SC_Hauling.SC_Hauling_Data
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        load_warehouse()
        FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbItemName)

    End Sub
    Sub load_warehouse()
        cmbWareHouse.Items.Clear()
        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("select DISTINCT wh_area from dbwh_area ORDER BY wh_area ASC", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                cmbWareHouse.Items.Add(sqldr("wh_area").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub
    Private Sub cmbItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItemName.SelectedIndexChanged
        FMaterials_ToolsTurnOverTextFields.get_WhItemDesc(cmbItemName.Text, 0, cmbItem_desc)
    End Sub
    Private Sub cmb_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_desc.GotFocus, cmbItemName.GotFocus, cmbWareHouse.GotFocus, cmbclassification.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Panel8.Visible = True
        cmbforClassification.SelectedIndex = 1
        cmbforClassification.Enabled = True
        cmbclassification.Enabled = True
        cmbforClassification.Focus()
        load_clasifications(cmbclassification)

    End Sub
    Public Sub load_clasifications(cmb As ComboBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmb.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 23)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmb.Items.Add(newDR.Item("wh_classification").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel8.Visible = False
    End Sub

    Private Sub Panel8_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel8.MouseMove
        If drag Then
            Panel8.Top = Windows.Forms.Cursor.Position.Y - mousey
            Panel8.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel8_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel8.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Panel8.Left
        mousey = Windows.Forms.Cursor.Position.Y - Panel8.Top
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel8.MouseUp
        drag = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Panel7.Visible = True
        With ST_Data

            .item_name = cmbItemName.Text
            .item_desc = cmbItem_desc.Text
            .classification = cmbclassification.Text
            .date_from = Date.Parse(dtpfrom.Text)
            .date_to = Date.Parse(dtpto.Text)
            .lvl = lvlStockCard

        End With

        Dim class_sh As New Class_StockCard_Hauling(ST_Data)
        class_sh.stock_card_for_hauling_and_crushing(11)

        'th = New System.Threading.Thread(AddressOf class_sh.stock_card_for_hauling_and_crushing)
        'th.Start(11)
        Timer1.Start()

    End Sub
    Private Sub loading()
        If Panel7.InvokeRequired Then
            Panel7.Invoke(Sub()
                              Panel7.Visible = True
                          End Sub)
        Else
            Panel7.Visible = True
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim class_sh As New Class_StockCard_Hauling(ST_Data)

        If class_sh.thread_status = "alive" Then
            Label12.Text = "alive..."
        Else
            Label12.Text = "not alive..."
            Timer1.Stop()
        End If
        'If Not th.IsAlive Then
        '    Panel7.Visible = False
        '    Timer1.Stop()

        'Else
        '    Panel7.Visible = True
        'End If
    End Sub

    Private Sub lvlStockCard_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlStockCard.SelectedIndexChanged

    End Sub

    Private Sub StockCard2_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        With crs_data

            .item_name = cmbItemName.Text
            .item_desc = cmbItem_desc.Text
            .classification = cmbclassification.Text
            .date_from = Date.Parse(dtpfrom.Text)
            .date_to = Date.Parse(dtpto.Text)
            .lvl = lvlStockCard
            .user_id = pub_user_id
        End With

        Dim c_search As New Class_SC_Hauling(crs_data)

        c_search.from_rs("OUT")

    End Sub
End Class