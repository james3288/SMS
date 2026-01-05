Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FSummary_of_AcquiredEquipment
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub FSummary_of_AcquiredEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_category(cmb_category)
    End Sub
    Public Sub view_category(cbox_category As ComboBox)
        cbox_category.Items.Clear()
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_equipment_monitoring"
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 13)
            sqlcommand.CommandTimeout = 0
            dr = sqlcommand.ExecuteReader
            While dr.Read
                cbox_category.Items.Add(dr.Item(1).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub
    Public Sub view_equipment_by_category(cbox As String)
        cmb_equipmentType.Items.Clear()
        Dim sqL As New SQLcon
        Dim sqlcommand As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqL.connection.Open()
            sqlcommand.Connection = sqL.connection
            sqlcommand.CommandText = "proc_equipment_monitoring"
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.Parameters.AddWithValue("@n", 14)
            sqlcommand.Parameters.AddWithValue("@eq_cat", cbox)
            sqlcommand.CommandTimeout = 0
            dr = sqlcommand.ExecuteReader
            While dr.Read
                cmb_equipmentType.Items.Add(dr.Item(6).ToString)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
        End Try
    End Sub

    Private Sub cmb_category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_category.SelectedIndexChanged
        FIncome_statement.load_equipType(cmb_equipmentType, cmb_category.Text)
    End Sub

    Public Sub view_summary_of_acquiredEquipment()
        lvl_summary_of_acquiredEquipment.Items.Clear()
        Dim cmd As New SqlCommand
        Dim a(15) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", 15)
            cmd.Parameters.AddWithValue("@eq_cat", cmb_category.Text)
            cmd.Parameters.AddWithValue("@eq_type", cmb_equipmentType.Text)

            cmd.Parameters.AddWithValue("@datefrom", Date.Parse(dtp_dateFrom.Text))
            cmd.Parameters.AddWithValue("@dateto", Date.Parse(dtp_dateTo.Text))
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read

                If cmb_category.Text = "Heavy Equipment" Then
                    a(0) = "Construction Equipment"
                Else
                    a(0) = cmb_category.Text
                End If

                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                a(5) = dr.Item(5).ToString
                a(6) = dr.Item(6).ToString
                a(7) = dr.Item(7).ToString

                Dim lvlList As New ListViewItem(a)
                lvl_summary_of_acquiredEquipment.Items.Add(lvlList)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        view_summary_of_acquiredEquipment()
        panel3.Visible = False
    End Sub

    Private Sub cmb_equipmentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_equipmentType.SelectedIndexChanged
        panel3.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        panel3.Visible = False
        cmb_category.Text = Nothing
        cmb_equipmentType.Text = Nothing
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles panel3.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles panel3.MouseMove
        If drag Then
            Dim temp As Point = New Point()

            temp.X = panel3.Location.X + (e.X - mousex)
            temp.Y = panel3.Location.Y + (e.Y - mousey)
            panel3.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles panel3.MouseUp
        If e.Button = MouseButtons.Left Then
            drag = False
        End If
    End Sub

    Private Sub btn_viewReport_Click(sender As Object, e As EventArgs) Handles btn_viewReport.Click
        If panel3.Visible = True Then
            panel3.Visible = False
        End If

        view_report()

    End Sub
    Public Sub view_report()

        Dim dt As New DataTable

        With dt
            .Columns.Add("Category")
            .Columns.Add("Type_of_Equipment")
            .Columns.Add("Plate_No")
            .Columns.Add("Date_Acquired")
            .Columns.Add("Model_Brand")
            .Columns.Add("Serial_No")
            .Columns.Add("Supplier")
            .Columns.Add("Acquisition_Cost")
        End With

        For i As Integer = 0 To lvl_summary_of_acquiredEquipment.Items.Count - 1
            dt.Rows.Add(lvl_summary_of_acquiredEquipment.Items(i).SubItems(0).Text, lvl_summary_of_acquiredEquipment.Items(i).SubItems(1).Text,
            lvl_summary_of_acquiredEquipment.Items(i).SubItems(2).Text, lvl_summary_of_acquiredEquipment.Items(i).SubItems(3).Text,
            lvl_summary_of_acquiredEquipment.Items(i).SubItems(4).Text, lvl_summary_of_acquiredEquipment.Items(i).SubItems(5).Text,
            lvl_summary_of_acquiredEquipment.Items(i).SubItems(6).Text, lvl_summary_of_acquiredEquipment.Items(i).SubItems(7).Text)

        Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FSumOfAquiredEquip.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FSumOfAquiredEquip.ShowDialog()
        FSumOfAquiredEquip.Dispose()

    End Sub
End Class