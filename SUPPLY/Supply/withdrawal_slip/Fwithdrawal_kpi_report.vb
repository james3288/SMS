Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop

Public Class Fwithdrawal_kpi_report
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub AddPercentSymbol(tb As TextBox)
        If tb.Text = "" Then Exit Sub
        If Not tb.Text.EndsWith("%") Then
            tb.Text = tb.Text.Replace("%", "").Trim() & "%"
            tb.SelectionStart = tb.Text.Length - 1
        End If
    End Sub
    Private Sub txtProjectPercent_TextChanged(sender As Object, e As EventArgs) Handles txtProjectPercent.TextChanged,
                                                                                   txtEquipPercent.TextChanged,
                                                                                   txtAdminPercent.TextChanged,
                                                                                   txtFastMovingPercent.TextChanged,
                                                                                   txtMediumMovingPercent.TextChanged,
                                                                                   txtSlowMovingPercent.TextChanged
        AddPercentSymbol(DirectCast(sender, TextBox))
    End Sub


    Private Sub Fwithdrawal_kpi_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panelDateRange.Visible = True
        panelDateRange.Location = New Point(
        (panelDateRange.Parent.ClientSize.Width - panelDateRange.Width) \ 2,
        (panelDateRange.Parent.ClientSize.Height - panelDateRange.Height) \ 2
    )
        getIndicators(1)
        getIndicators(2)


    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If ((txtProjectPercent.Text = "" Or 0) Or
            (txtEquipPercent.Text = "" Or 0) Or
            (txtAdminPercent.Text = "" Or 0) Or
            (txtFastMovingPercent.Text = "" Or 0) Or
            (txtMediumMovingPercent.Text = "" Or 0) Or
            (txtSlowMovingPercent.Text = "" Or 0)) Then
            MsgBox("Please Insert a valid Target Percentage")
        Else

            Fwarehouse_Kpi_Preview_Report.ShowDialog()
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        display_project()
        display_equipment()
        display_admin()
        display_fast_moving()
        display_medium_moving()
        display_slow_moving()

        panelDateRange.Visible = False
    End Sub


    Private Sub display_project()
        lvlProject.Items.Clear()

        Dim count1 As Integer = 1
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_withdrawal_report_kpi"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 1)
            sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
            sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
            sqlcomm.Parameters.AddWithValue("@kpi_category1", Cmb1.Text)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(5) As String

                a(0) = count1
                a(1) = dr.Item(0).ToString()
                a(2) = dr.Item(1).ToString()
                count1 = count1 + 1

                Dim lvl As New ListViewItem(a)
                lvlProject.Items.Add(lvl)
            End While
            dr.Close()


        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Private Sub display_equipment()

        lvlEquipment.Items.Clear()
        Dim count1 As Integer = 1
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_withdrawal_report_kpi"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 2)
            sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
            sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
            sqlcomm.Parameters.AddWithValue("@kpi_category2", cmb2.Text)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(5) As String

                a(0) = count1
                a(1) = dr.Item(0).ToString()
                a(2) = dr.Item(1).ToString()
                count1 = count1 + 1

                Dim lvl As New ListViewItem(a)
                lvlEquipment.Items.Add(lvl)
            End While
            dr.Close()


        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Private Sub display_admin()

        lvlAdmin.Items.Clear()
        Dim count1 As Integer = 1
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_withdrawal_report_kpi"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 3)
            sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
            sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
            sqlcomm.Parameters.AddWithValue("@kpi_category3", cmb3.Text)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(5) As String
                a(0) = count1
                a(1) = dr.Item(0).ToString()
                a(2) = dr.Item(1).ToString()
                count1 = count1 + 1

                Dim lvl As New ListViewItem(a)
                lvlAdmin.Items.Add(lvl)
            End While
            dr.Close()

        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Sub


    Private Sub display_slow_moving()

        lvlSlowMoving.Items.Clear()
        Dim count1 As Integer = 1
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_withdrawal_report_kpi"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 7)
            sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
            sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
            sqlcomm.Parameters.AddWithValue("@kpi_category6", cmb6.Text)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(5) As String
                a(0) = count1
                a(1) = dr.Item(0).ToString()
                a(2) = dr.Item(1).ToString()
                count1 = count1 + 1

                Dim lvl As New ListViewItem(a)
                lvlSlowMoving.Items.Add(lvl)
            End While
            dr.Close()

        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Private Sub display_medium_moving()

        lvlMediumMoving.Items.Clear()
        Dim count1 As Integer = 1
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_withdrawal_report_kpi"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 9)
            sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
            sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
            sqlcomm.Parameters.AddWithValue("@kpi_category5", cmb5.Text)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(5) As String
                a(0) = count1
                a(1) = dr.Item(0).ToString()
                a(2) = dr.Item(1).ToString()
                count1 = count1 + 1

                Dim lvl As New ListViewItem(a)
                lvlMediumMoving.Items.Add(lvl)
            End While
            dr.Close()

        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Sub

    Private Sub display_fast_moving()

        lvlFastMoving.Items.Clear()
        Dim count1 As Integer = 1
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_withdrawal_report_kpi"
            sqlcomm.CommandType = CommandType.StoredProcedure

            sqlcomm.Parameters.AddWithValue("@n", 8)
            sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
            sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
            sqlcomm.Parameters.AddWithValue("@kpi_category4", cmb4.Text)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(5) As String
                a(0) = count1
                a(1) = dr.Item(0).ToString()
                a(2) = dr.Item(1).ToString()
                count1 = count1 + 1

                Dim lvl As New ListViewItem(a)
                lvlFastMoving.Items.Add(lvl)
            End While
            dr.Close()

        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Sub




    Private Sub ViewSupportingDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSupportingDataToolStripMenuItem.Click
        display_supporting_data(1, 1)
    End Sub


    Private Sub display_supporting_data(ByVal x As Integer, ByVal x2 As Integer)

        lblSuportingData.Items.Clear()
        Dim count1 As Integer = 1
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_withdrawal_report_kpi"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 1 Then
                'PROJECT DISPLAYING SUPPORTING DATA
                If x2 = 1 Then
                    sqlcomm.Parameters.AddWithValue("@n", 4)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category1", Cmb1.Text)
                ElseIf x2 = 2 Then
                    sqlcomm.Parameters.AddWithValue("@n", 5)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category1", Cmb1.Text)
                ElseIf x2 = 3 Then
                    sqlcomm.Parameters.AddWithValue("@n", 6)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category1", Cmb1.Text)
                End If

                'EQUIPMENT DISPLAYING SUPPORTING DATA
            ElseIf x = 2 Then
                If x2 = 4 Then
                    sqlcomm.Parameters.AddWithValue("@n", 12)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category2", cmb2.Text)
                ElseIf x2 = 5 Then
                    sqlcomm.Parameters.AddWithValue("@n", 13)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category2", cmb2.Text)
                ElseIf x2 = 6 Then
                    sqlcomm.Parameters.AddWithValue("@n", 14)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category2", cmb2.Text)
                End If

                'ADMIN MISSELANEOUS DISPLAYING DATA
            ElseIf x = 3 Then
                If x2 = 7 Then
                    sqlcomm.Parameters.AddWithValue("@n", 15)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category3", cmb3.Text)
                ElseIf x2 = 8 Then
                    sqlcomm.Parameters.AddWithValue("@n", 16)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category3", cmb3.Text)
                ElseIf x2 = 9 Then
                    sqlcomm.Parameters.AddWithValue("@n", 17)
                    sqlcomm.Parameters.AddWithValue("@rsDateFrom", dtp_dateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@rsDateTo", dtp_dateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category3", cmb3.Text)
                End If
                'FAST MOVING DISPLAYING DATA
            ElseIf x = 4 Then
                If x2 = 10 Then
                    sqlcomm.Parameters.AddWithValue("@n", 18)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category4", cmb4.Text)
                ElseIf x2 = 11 Then
                    sqlcomm.Parameters.AddWithValue("@n", 19)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category4", cmb4.Text)
                ElseIf x2 = 12 Then
                    sqlcomm.Parameters.AddWithValue("@n", 20)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category4", cmb4.Text)
                End If

                'MEDIUM MOVING DISPLAYING DATA
            ElseIf x = 5 Then
                If x2 = 13 Then
                    sqlcomm.Parameters.AddWithValue("@n", 21)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category5", cmb5.Text)
                ElseIf x2 = 14 Then
                    sqlcomm.Parameters.AddWithValue("@n", 22)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category5", cmb5.Text)
                ElseIf x2 = 15 Then
                    sqlcomm.Parameters.AddWithValue("@n", 23)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category5", cmb5.Text)
                End If

                'SLOW MOVING DISPLAYING DATA
            ElseIf x = 6 Then
                If x2 = 16 Then
                    sqlcomm.Parameters.AddWithValue("@n", 24)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category6", cmb6.Text)
                ElseIf x2 = 17 Then
                    sqlcomm.Parameters.AddWithValue("@n", 25)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category6", cmb6.Text)
                ElseIf x2 = 18 Then
                    sqlcomm.Parameters.AddWithValue("@n", 26)
                    sqlcomm.Parameters.AddWithValue("@wsDateFrom", dtp_WSdateFrom_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@wsDateTo", dtp_WSdateTo_Log.Text)
                    sqlcomm.Parameters.AddWithValue("@kpi_category6", cmb6.Text)
                End If
            End If

            dr = sqlcomm.ExecuteReader
            While dr.Read
                Dim a(8) As String

                a(0) = count1
                a(1) = dr.Item(0).ToString()
                a(2) = dr.Item(1).ToString()
                a(3) = dr.Item(2).ToString()
                a(4) = dr.Item(3).ToString()
                a(5) = dr.Item(4).ToString()
                a(6) = dr.Item(5).ToString()
                a(7) = dr.Item(6).ToString()
                a(8) = dr.Item(7).ToString()
                count1 = count1 + 1

                Dim lvl As New ListViewItem(a)
                lblSuportingData.Items.Add(lvl)

            End While

            lblTotalDataFound.Text = (count1 - 1) & " Records Found"
            dr.Close()


        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub ViewProcessOnTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProcessOnTimeToolStripMenuItem.Click
        display_supporting_data(1, 2)
    End Sub

    Private Sub ViewDataLateProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDataLateProcessToolStripMenuItem.Click
        display_supporting_data(1, 3)
    End Sub

    Private Sub getIndicators(ByVal x As Integer)
        Try
            SQ.connection.Open()


            If x = 1 Then
                Dim sqlcomm As New SqlCommand
                sqlcomm.Connection = SQ.connection
                sqlcomm.CommandText = "sp_withdrawal_report_kpi"
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@n", 10)
                dr = sqlcomm.ExecuteReader
                While dr.Read
                    Cmb1.Items.Add(dr.Item(0).ToString())
                    cmb2.Items.Add(dr.Item(0).ToString())
                    cmb3.Items.Add(dr.Item(0).ToString())
                End While


            ElseIf x = 2 Then
                Dim sqlcomm As New SqlCommand
                sqlcomm.Connection = SQ.connection
                sqlcomm.CommandText = "sp_withdrawal_report_kpi"
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@n", 11)
                dr = sqlcomm.ExecuteReader
                While dr.Read
                    cmb4.Items.Add(dr.Item(0).ToString())
                    cmb5.Items.Add(dr.Item(0).ToString())
                    cmb6.Items.Add(dr.Item(0).ToString())
                End While

            End If

            dr.Close()


        Catch ex As Exception
            Dim msg1 As New customMessageBox
            msg1.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        display_supporting_data(2, 4)
    End Sub

    Private Sub ViewProcessOnTimeDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProcessOnTimeDataToolStripMenuItem.Click
        display_supporting_data(2, 5)
    End Sub

    Private Sub ViewLateProcessDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewLateProcessDataToolStripMenuItem.Click
        display_supporting_data(2, 6)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        display_supporting_data(3, 7)
    End Sub

    Private Sub ViewProcessOnTimeDataToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewProcessOnTimeDataToolStripMenuItem1.Click
        display_supporting_data(3, 8)
    End Sub

    Private Sub ViewLateProcessDataToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewLateProcessDataToolStripMenuItem1.Click
        display_supporting_data(3, 9)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        display_supporting_data(5, 13)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        display_supporting_data(4, 10)
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        display_supporting_data(4, 11)
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        display_supporting_data(4, 12)
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        display_supporting_data(5, 14)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        display_supporting_data(5, 15)
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        display_supporting_data(6, 16)
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        display_supporting_data(6, 17)
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        display_supporting_data(6, 18)
    End Sub

    Private Sub txtFastMovingPercent_Leave(sender As Object, e As EventArgs) Handles txtFastMovingPercent.Leave
        If txtFastMovingPercent.Text = "" Then
            txtFastMovingPercent.Text = "0%"

        End If
    End Sub

    Private Sub txtMediumMovingPercent_Leave(sender As Object, e As EventArgs) Handles txtMediumMovingPercent.Leave
        If txtMediumMovingPercent.Text = "" Then
            txtMediumMovingPercent.Text = "0%"
        End If
    End Sub

    Private Sub txtSlowMovingPercent_Leave(sender As Object, e As EventArgs) Handles txtSlowMovingPercent.Leave
        If txtSlowMovingPercent.Text = "" Then
            txtSlowMovingPercent.Text = "0%"
        End If
    End Sub

    Private Sub txtProjectPercent_Leave(sender As Object, e As EventArgs) Handles txtProjectPercent.Leave
        If txtProjectPercent.Text = "" Then
            txtProjectPercent.Text = "0%"
        End If
    End Sub

    Private Sub txtEquipPercent_Leave(sender As Object, e As EventArgs) Handles txtEquipPercent.Leave
        If txtEquipPercent.Text = "" Then
            txtEquipPercent.Text = "0%"
        End If
    End Sub

    Private Sub txtAdminPercent_Leave(sender As Object, e As EventArgs) Handles txtAdminPercent.Leave
        If txtAdminPercent.Text = "" Then
            txtAdminPercent.Text = "0%"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class