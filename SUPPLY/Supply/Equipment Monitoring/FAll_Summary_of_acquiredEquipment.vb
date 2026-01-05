Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FAll_Summary_of_acquiredEquipment
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Private Sub FAll_Summary_of_acquiredEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_viewReport.Text = "Search"
    End Sub
    Public Sub view_all_summary_acquiredEquipment()
        lvl_all_acquiredEquipment.Items.Clear()
        Dim cmd As New SqlCommand
        Dim a(15) As String
        Try
            SQ.connection.Open()
            cmd.Connection = SQ.connection
            cmd.CommandText = "proc_equipment_monitoring"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", 16)
            'cmd.Parameters.AddWithValue("@eq_cat", cmb_category.Text)
            'cmd.Parameters.AddWithValue("@eq_type", cmb_equipmentType.Text)

            cmd.Parameters.AddWithValue("@datefrom", Date.Parse(dtp_dateFrom.Text))
            cmd.Parameters.AddWithValue("@dateto", Date.Parse(dtp_dateTo.Text))
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader
            While dr.Read

                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                Dim lvlList As New ListViewItem(a)
                lvl_all_acquiredEquipment.Items.Add(lvlList)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub btn_viewReport_Click(sender As Object, e As EventArgs) Handles btn_viewReport.Click
        If btn_viewReport.Text = "Search" Then
            view_all_summary_acquiredEquipment()
            btn_viewReport.Text = "View Report"
        Else
            'Report'
            view_report()
        End If

    End Sub

    Private Sub dtp_dateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtp_dateFrom.ValueChanged, dtp_dateTo.ValueChanged
        btn_viewReport.Text = "Search"
    End Sub
    Public Sub view_report()

        Dim dt As New DataTable

        With dt
            .Columns.Add("Category")
            .Columns.Add("Number_Of_Units")
            .Columns.Add("Acquisition_Cost")
            .Columns.Add("EquipmentType")
        End With

        For i As Integer = 0 To lvl_all_acquiredEquipment.Items.Count - 1
            dt.Rows.Add(lvl_all_acquiredEquipment.Items(i).SubItems(0).Text, lvl_all_acquiredEquipment.Items(i).SubItems(2).Text,
            lvl_all_acquiredEquipment.Items(i).SubItems(3).Text, lvl_all_acquiredEquipment.Items(i).SubItems(1).Text)
        Next

        'For Each item As ListViewItem In Me.ListView1.Items
        'Next

        Dim view As New DataView(dt)

        FSumOf_All_AquiredEqui_report.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FSumOf_All_AquiredEqui_report.ShowDialog()
        FSumOf_All_AquiredEqui_report.Dispose()

    End Sub
End Class