Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FLaborcostInputFields
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each ctr As Control In FLaborCost.Controls
            ctr.Enabled = True
        Next
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub FLaborcostInputFields_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        get_projdesc(2, cmb_projdesc)
        With cmb_category
            .Text = "Labor"
            .Enabled = False
        End With
    End Sub

    Public Function get_projdesc(ByVal n As Integer, ByVal cmb As ComboBox) As String
        cmb.Items.Clear()

        Try
            Sqlcon.connection.Open()
            sqlcmd = New SqlCommand("proc_dbmonthly_project_cost_report", Sqlcon.connection)
            sqlcmd.Parameters.Clear()
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.Parameters.AddWithValue("@n", n)
            sqldr = sqlcmd.ExecuteReader
            While sqldr.Read
                cmb.Items.Add(sqldr.Item("project_desc").ToString)

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sqlcon.connection.Close()
        End Try

    End Function

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        If cmb_projdesc.Text = "" Or cmb_category.Text = "" Or txt_amount.Text = "" Then
            MessageBox.Show("You must fill up all the input fields to continue.", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            If btn_save.Text = "Save" Then
                MessageBox.Show("Successfully saved", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                save_edit(4)

            ElseIf btn_save.Text = "Update" Then
                If MessageBox.Show("Are you sure you want to update this data ?. ", "SUPPLY INFO.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    MessageBox.Show("Successfully updated", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    save_edit(9)
                Else
                    Return
                End If
            End If

            For Each ctr As Control In FLaborCost.Controls
                ctr.Enabled = True
            Next
            Me.Close()
            Me.Dispose()

        End If

    End Sub

    Public Sub save_edit(ByVal n As Integer)
        Dim sqLCOn As New SQLcon
        Dim newcmd As SqlCommand
        Try
            sqLCOn.connection.Open()
            newcmd = New SqlCommand("proc_dbmonthly_project_cost_report", sqLCOn.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure
            newcmd.Parameters.AddWithValue("@n", n)

            If n = 4 Then
            Else

                newcmd.Parameters.AddWithValue("@labor_cost_id", FLaborCost.lcost_id)
            End If

            newcmd.Parameters.AddWithValue("@proj_id", get_projdesc_id(3))
            newcmd.Parameters.AddWithValue("@category", 1)
            newcmd.Parameters.AddWithValue("@datefrom", Format(Date.Parse(dtp_datefrom.Value.ToString), "yyyy-MM-dd"))
            newcmd.Parameters.AddWithValue("@dateto", Format(Date.Parse(dtp_dateto.Value.ToString), "yyyy-MM-dd"))
            newcmd.Parameters.AddWithValue("@amount", txt_amount.Text.ToString)
            newcmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqLCOn.connection.Close()
            FLaborCost.load_LaborCost(5)

            If n = 4 Then
                listfocus(FLaborCost.lvl_LaborCost, Focus)
                FLaborCost.lvl_LaborCost.Items(FLaborCost.lvl_LaborCost.Items.Count - 1).Selected = True
                FLaborCost.lvl_LaborCost.EnsureVisible(FLaborCost.lvl_LaborCost.Items.Count - 1)
            Else
                listfocus(FLaborCost.lvl_LaborCost, FLaborCost.lcost_id)
            End If

        End Try
    End Sub
    Public Function get_projdesc_id(ByVal n As Integer) As Integer
        Dim sQL As New SQLcon
        Dim cmd As SqlCommand
        Dim dir As SqlDataReader
        Try
            sQL.connection.Open()
            cmd = New SqlCommand("proc_dbmonthly_project_cost_report", sQL.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@n", n)
            cmd.Parameters.AddWithValue("@proj_desc", cmb_projdesc.Text.ToString)
            dir = cmd.ExecuteReader
            While dir.Read
                get_projdesc_id = dir.Item("proj_id").ToString
            End While
            dir.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sQL.connection.Close()
        End Try
    End Function

#Region "Hover/DragForm"
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.close_button
    End Sub

    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.close_button3
    End Sub

    Private Sub pboxHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub pboxHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub pboxHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles pboxHeader.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

#End Region
End Class