Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FLaborCost
    Public SQLcon As New SQLcon
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Public lcost_id As Integer = 0
    Private Sub FLaborCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_LaborCost(5)
        cmb_search.Enabled = False
    End Sub

    Public Sub load_LaborCost(ByVal n As Integer)
        lvl_LaborCost.Items.Clear()

        Try
            SQLcon.connection.Open()
            cmd = New SqlCommand("proc_dbmonthly_project_cost_report", SQLcon.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", n)

            If n = 7 Or n = 8 Then
                cmd.Parameters.AddWithValue("@search", cmb_search.Text)
            End If

            dr = cmd.ExecuteReader
            While dr.Read
                Dim x(10) As String

                x(0) = dr.Item("labor_cost_id").ToString
                x(1) = dr.Item("project_desc").ToString
                x(2) = dr.Item("category_id").ToString
                x(3) = Format(Date.Parse(dr.Item("date_from").ToString), "yyyy-MM-dd")
                x(4) = Format(Date.Parse(dr.Item("date_to").ToString), "yyyy-MM-dd")
                x(5) = dr.Item("amount").ToString

                Dim lvList As New ListViewItem(x)
                lvl_LaborCost.Items.Add(lvList)

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        For Each ctr As Control In Me.Controls
            ctr.Enabled = False
        Next
        FLaborcostInputFields.Show()
    End Sub
    Private Sub cmb_searchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_searchby.SelectedIndexChanged
        If cmb_searchby.Text = "Project Description" Then
            cmb_search.Enabled = True
            FLaborcostInputFields.get_projdesc(2, cmb_search)
        Else
            cmb_search.Enabled = False
            load_LaborCost(5)
        End If
    End Sub
    Private Sub cmb_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_search.SelectedIndexChanged
        If cmb_searchby.Text = "Project Description" Then
            load_LaborCost(7)
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to delete this data ?. ", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            delete_laborCost(10)
        End If
    End Sub
    Public Sub delete_laborCost(ByVal n As Integer)
        Dim sq As New SQLcon
        Dim nwcmd As SqlCommand
        Try
            sq.connection.Open()
            nwcmd = New SqlCommand("proc_dbmonthly_project_cost_report", sq.connection)
            nwcmd.Parameters.Clear()
            nwcmd.CommandType = CommandType.StoredProcedure
            nwcmd.Parameters.AddWithValue("@n", n)
            nwcmd.Parameters.AddWithValue("@labor_cost_id", lvl_LaborCost.SelectedItems(0).SubItems(0).Text.ToString)
            nwcmd.ExecuteNonQuery()

            lvl_LaborCost.SelectedItems(0).Remove()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()
        End Try
    End Sub
#Region "Hover"
    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.close_button
    End Sub
#End Region
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Button2.PerformClick()
        lcost_id = lvl_LaborCost.SelectedItems(0).SubItems(0).Text.ToString

        With FLaborcostInputFields
            .btn_save.Text = "Update"
            .cmb_projdesc.Text = lvl_LaborCost.SelectedItems(0).SubItems(1).Text.ToString
            .cmb_category.Text = lvl_LaborCost.SelectedItems(0).SubItems(2).Text.ToString
            .txt_amount.Text = lvl_LaborCost.SelectedItems(0).SubItems(5).Text.ToString
            .dtp_datefrom.Value = lvl_LaborCost.SelectedItems(0).SubItems(3).Text.ToString
            .dtp_dateto.Value = lvl_LaborCost.SelectedItems(0).SubItems(4).Text.ToString
        End With
    End Sub
End Class