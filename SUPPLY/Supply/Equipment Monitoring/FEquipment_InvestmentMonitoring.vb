Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FEquipment_InvestmentMonitoring
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub FEquipment_InvestmentMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_searchby.SelectedIndexChanged
        If cmb_searchby.Text = "Equipment Type" Then
            FEquipment_monitoring.load_equipType(cmb_equip_type)
            cmb_equip_type.Enabled = True
            gbox_search.Visible = False
        Else
            cmb_equip_type.Enabled = False
            gbox_search.Visible = True
        End If
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        view_equip_InvestmentMonitoring(cmb_searchby.Text)
    End Sub

    Sub view_equip_InvestmentMonitoring(cmb As String)
        DataGridView1.Rows.Clear()
        Dim nwsqlcmd As New SqlCommand
        Dim a(20) As String
        Try
            SQ.connection.Open()

            nwsqlcmd.Connection = SQ.connection
            nwsqlcmd.CommandText = "proc_equipment_monitoring"
            nwsqlcmd.Parameters.Clear()
            nwsqlcmd.CommandType = CommandType.StoredProcedure

            If cmb = "All Type" Then
                nwsqlcmd.Parameters.AddWithValue("@eq_type", "%")
            Else
                nwsqlcmd.Parameters.AddWithValue("@eq_type", cmb_equip_type.Text)
            End If

            nwsqlcmd.Parameters.AddWithValue("@n", 17)
            nwsqlcmd.Parameters.AddWithValue("@datefrom", dtp_datefrom.Text)
            nwsqlcmd.Parameters.AddWithValue("@dateto", dtp_dateTo.Text)

            nwsqlcmd.CommandTimeout = 0
            dr = nwsqlcmd.ExecuteReader
            While dr.Read
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = dr.Item(7).ToString
                a(7) = dr.Item(6).ToString
                a(8) = dr.Item(8).ToString
                a(9) = dr.Item(9).ToString
                a(10) = dr.Item(10).ToString
                a(11) = dr.Item(11).ToString

                DataGridView1.Rows.Add(a)


            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

        gbox_search.Visible = False

    End Sub

    Private Sub gbox_search_MouseDown(sender As Object, e As MouseEventArgs) Handles gbox_search.MouseDown, Panel4.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub gbox_search_MouseMove(sender As Object, e As MouseEventArgs) Handles gbox_search.MouseMove, Panel4.MouseMove
        If drag Then
            Dim temp As Point = New Point()

            temp.X = gbox_search.Location.X + (e.X - mousex)
            temp.Y = gbox_search.Location.Y + (e.Y - mousey)
            gbox_search.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub gbox_search_MouseUp(sender As Object, e As MouseEventArgs) Handles gbox_search.MouseUp, Panel4.MouseUp
        If e.Button = MouseButtons.Left Then
            drag = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        gbox_search.Visible = False
    End Sub

    Private Sub cmb_equip_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_equip_type.SelectedIndexChanged
        gbox_search.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        view_report()
    End Sub

    Public Sub view_report()

        Dim dt As New DataTable

    With dt
            .Columns.Add("equiptype")
            .Columns.Add("plate_no")
            .Columns.Add("brand")
            .Columns.Add("model")
            .Columns.Add("year_purchased")
            .Columns.Add("acq_cost")
            .Columns.Add("rental_revenue")
            .Columns.Add("operation_cost")
            .Columns.Add("net_revenue")
            .Columns.Add("percentage_poi")
            .Columns.Add("equip_age")
            .Columns.Add("useful_life")
        End With

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add(
            DataGridView1.Rows(i).Cells(0).Value,
            DataGridView1.Rows(i).Cells(1).Value,
            DataGridView1.Rows(i).Cells(2).Value,
            DataGridView1.Rows(i).Cells(3).Value,
            DataGridView1.Rows(i).Cells(4).Value,
            DataGridView1.Rows(i).Cells(5).Value,
            DataGridView1.Rows(i).Cells(6).Value,
            DataGridView1.Rows(i).Cells(7).Value,
            DataGridView1.Rows(i).Cells(8).Value,
            DataGridView1.Rows(i).Cells(9).Value,
            DataGridView1.Rows(i).Cells(10).Value,
            DataGridView1.Rows(i).Cells(11).Value)
        Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FEquipment_InvestmentMonitoring_Viewer.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FEquipment_InvestmentMonitoring_Viewer.ShowDialog()
        FEquipment_InvestmentMonitoring_Viewer.Dispose()

    End Sub

End Class