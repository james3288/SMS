Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class HauledReport
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Public Sub generate_summary_aggregates(item As String, remarks As String)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer = 0

        'LVL_HaulingReport.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("sp_HaulingReport", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            If cmbSearchby.Text = "PROJECT CHARGES" Then
                newCMD.Parameters.AddWithValue("@n", 8)
            Else
                newCMD.Parameters.AddWithValue("@n", 7)
            End If

            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(dtp_from.Text))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(dtp_to.Text))
            newCMD.Parameters.AddWithValue("@search", txtSearch.Text)
            newCMD.Parameters.AddWithValue("@Searchby", cmbSearchby.Text)
            'newCMD.Parameters.AddWithValue("@SearchItem", txtSearchItems.Text)
            newCMD.Parameters.AddWithValue("@SearchItem", item)
            newCMD.Parameters.AddWithValue("@remarks", remarks)
            newDR = newCMD.ExecuteReader

            Dim a(20) As String

            While newDR.Read
                Dim unit_price As Double

                If newDR.Item("unit_price").ToString = "" Then
                    unit_price = 0
                Else
                    unit_price = newDR.Item("unit_price").ToString
                End If

                Dim rs_no As String = newDR.Item("RS_NO").ToString
                Dim ws_no As String = newDR.Item("WS_NO").ToString

                a(0) = ""
                a(1) = newDR.Item("SOURCE_RECEPIENT").ToString
                a(2) = Format(Date.Parse(newDR.Item("DATE_SERVED").ToString), "MM/dd/yyyy")

                a(5) = newDR.Item("unit").ToString
                a(6) = Format(Date.Parse(newDR.Item("DATE_REQUEST").ToString), "MM/dd/yyyy")
                a(7) = newDR.Item("rs_no").ToString
                a(8) = newDR.Item("SAND_SOURCE").ToString
                'a(8) = newDR.Item("WH_AREA").ToString & " (" & newDR.Item("SAND_SOURCE").ToString & ")"
                a(9) = unit_price ' FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2,,, TriState.True) 'FormatNumber(CDbl(newDR.Item("unit_price").ToString),,, TriState.True)
                a(17) = newDR.Item("WH_AREA").ToString

                Dim inout As String = newDR.Item("IN_OUT").ToString

                If inout = "IN" Then

                    If newDR.Item("SORTING").ToString = "A" Then

                        'a(4) = newDR.Item("qty_IN").ToString
                        If newDR.Item("").ToString = "" Then

                        End If
                        a(4) = IIf(FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 14) = 0, newDR.Item("qty_IN").ToString,
                                  FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 14) & "/" & newDR.Item("qty_IN").ToString)

                    ElseIf newDR.Item("SORTING").ToString = "B" Then

                        a(4) = newDR.Item("qty_IN").ToString

                    End If

                ElseIf inout = "OUT" Then

                    If newDR.Item("SORTING").ToString = "A" Then

                        a(3) = newDR.Item("ITEM_DESC").ToString
                        a(4) = IIf(FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0, newDR.Item("qty_OUT").ToString,
                                   FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) & "/" & newDR.Item("qty_OUT").ToString)

                        If FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                            a(10) = FormatNumber((CDbl(newDR.Item("qty_OUT").ToString) * unit_price), 2,, TriState.True)
                        Else
                            a(10) = FormatNumber((FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) * unit_price), 2,, TriState.True)
                        End If

                    ElseIf newDR.Item("SORTING").ToString = "B" Then

                        a(3) = newDR.Item("ITEM_DESC").ToString
                        If a(3) = "Aggregates - Mixed Aggregates" Then
                            a(3) = a(3) & IIf(newDR.Item("remarks").ToString = "", "", " (" &
                                newDR.Item("remarks").ToString.ToUpper &
                                ")")
                        End If

                        a(4) = newDR.Item("qty_OUT").ToString
                        a(10) = FormatNumber((CDbl(newDR.Item("qty_OUT").ToString) * unit_price), 2,, TriState.True)
                    End If

                ElseIf inout = "OTHERS" Then

                    If newDR.Item("SORTING").ToString = "A" Then

                        a(3) = newDR.Item("ITEM_DESC").ToString
                        a(4) = IIf(FStockCard.count_qty_dr_using_po_no(ws_no, rs_no) = 0, newDR.Item("qty_OTHERS").ToString,
                         FStockCard.count_qty_dr_using_po_no(ws_no, rs_no) & "/" & newDR.Item("qty_OTHERS").ToString)
                        a(10) = FormatNumber((FStockCard.count_qty_dr_using_po_no(ws_no, rs_no) * unit_price), 2,, TriState.True)

                    ElseIf newDR.Item("SORTING").ToString = "B" Then

                        a(3) = newDR.Item("ITEM_DESC").ToString
                        If a(3) = "Aggregates - Mixed Aggregates" Then
                            a(3) = a(3) & IIf(newDR.Item("remarks").ToString = "", "", " (" &
                                newDR.Item("remarks").ToString.ToUpper &
                                ")")
                        End If

                        a(4) = newDR.Item("qty_OTHERS").ToString
                        a(10) = FormatNumber((CDbl(newDR.Item("qty_OTHERS").ToString) * unit_price), 2,, TriState.True)
                    End If

                End If

                a(11) = newDR.Item("SAND_SOURCE").ToString
                a(12) = newDR.Item("remarks").ToString
                a(13) = newDR.Item("SORTING").ToString
                a(14) = newDR.Item("IN_OUT").ToString
                a(15) = ws_no
                a(16) = newDR.Item("dr_no").ToString


                Dim lvl As New ListViewItem(a)
                LVL_HaulingReport.Items.Add(lvl)

                'If newDR.Item("SORTING").ToString = "A" Then

                '    ' MsgBox(FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12))

                '    If FStockCard.count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                '        If ws_no = "0" And inout = "OUT" Then
                '            LVL_HaulingReport.Items(counter).BackColor = Color.LightPink

                '        ElseIf inout = "OTHERS" And ws_no <> "N/A" Then

                '            LVL_HaulingReport.Items(counter).BackColor = Color.Black
                '            LVL_HaulingReport.Items(counter).ForeColor = Color.White
                '        Else
                '            If inout = "IN" And ws_no = "N/A" Then
                '                LVL_HaulingReport.Items(counter).BackColor = Color.LightYellow
                '                'ElseIf inout = "OTHERS" And ws_no = "N/A" Then
                '                '    LVL_HaulingReport.Items(counter).BackColor = Color.LightGreen
                '            ElseIf inout = "OTHERS" And ws_no = "N/A" Then
                '                LVL_HaulingReport.Items(counter).BackColor = Color.LightBlue
                '            Else
                '                LVL_HaulingReport.Items(counter).BackColor = Color.Lavender
                '            End If

                '        End If

                '    Else
                '        LVL_HaulingReport.Items(counter).BackColor = Color.LightGreen
                '        LVL_HaulingReport.Items(counter).ForeColor = Color.Black
                '    End If

                'ElseIf newDR.Item("SORTING").ToString = "B" Then

                '    If inout = "OTHERS" And ws_no <> "N/A" Then
                '        LVL_HaulingReport.Items(counter).BackColor = Color.LightSlateGray
                '        LVL_HaulingReport.Items(counter).ForeColor = Color.Black
                '    Else
                '        LVL_HaulingReport.Items(counter).BackColor = Color.Honeydew
                '        LVL_HaulingReport.Items(counter).ForeColor = Color.Black
                '    End If



                'End If

                counter += 1

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub
    Public Sub waste_excemption()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FWasteExcemption.lvlListOfAggregates.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 33)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtp_from.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtp_to.Text))
            newCMD.Parameters.AddWithValue("@Search", txtSearch.Text)
            newCMD.Parameters.AddWithValue("@Searchby", cmbSearchby.Text)
            'newCMD.Parameters.AddWithValue("@SearchItem", txtSearchItems.Text)
            newCMD.Parameters.AddWithValue("@SearchItem", txtSearchItems.Text)
            newCMD.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            newCMD.CommandTimeout = 50

            newDR = newCMD.ExecuteReader


            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("ITEM_DESC").ToString
                a(1) = newDR.Item("remarks").ToString

                Dim lvl As New ListViewItem(a)

                FWasteExcemption.lvlListOfAggregates.Items.Add(lvl)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        button_click_name = "HauledReport"
        waste_excemption()
        FWasteExcemption.ShowDialog()

        'generate_summary_aggregates(txtSearchItems.Text, txtRemarks.Text)

        For Each row As ListViewItem In LVL_HaulingReport.Items
            If row.BackColor = Color.LightPink Then
                row.Remove()
            End If
        Next

        'LVL_HaulingReport.Items.Clear()

        'Dim sqlcon As New SQLcon
        'Dim dr As SqlDataReader
        'Dim cmd As SqlCommand
        'Try
        '    sqlcon.connection.Open()
        '    cmd = New SqlCommand("sp_HaulingReport", sqlcon.connection)
        '    cmd.CommandTimeout = 0
        '    cmd.Parameters.Clear()
        '    cmd.CommandType = CommandType.StoredProcedure

        '    cmd.Parameters.AddWithValue("@date_from", Date.Parse(dtp_from.Text))
        '    cmd.Parameters.AddWithValue("@date_to", Date.Parse(dtp_to.Text))
        '    cmd.Parameters.AddWithValue("@Searchby", cmbSearchby.Text)
        '    cmd.Parameters.AddWithValue("@Search", txtSearch.Text)
        '    'cmd.Parameters.AddWithValue("@equiptype", cmb_equip_type.Text)
        '    cmd.Parameters.AddWithValue("@n", 6)

        '    dr = cmd.ExecuteReader

        '    While dr.Read
        '        Dim a(20) As String
        '        a(0) = dr.Item(0).ToString
        '        a(1) = dr.Item(1).ToString
        '        a(2) = Date.Parse(dr.Item(2).ToString)
        '        a(3) = dr.Item(3).ToString
        '        a(4) = dr.Item(4).ToString
        '        a(5) = dr.Item(5).ToString
        '        a(6) = (dr.Item(6).ToString)
        '        a(7) = dr.Item(7).ToString
        '        a(8) = dr.Item(8).ToString
        '        a(9) = FormatNumber(dr.Item(9).ToString, 2,,, TriState.True)
        '        a(10) = FormatNumber(dr.Item(10).ToString, 2,,, TriState.True)
        '        a(11) = dr.Item(11).ToString
        '        a(12) = dr.Item(12).ToString

        '        Dim lvl As New ListViewItem(a)
        '        LVL_HaulingReport.Items.Add(lvl)

        '    End While
        '    'MsgBox("ian")
        '    dr.Close()
        'Catch ex As Exception
        '    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    sqlcon.connection.Close()
        'End Try
    End Sub

    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click
        view_report()
    End Sub
    Public Sub view_report()
        Dim dt As New DataTable

        With dt
            .Columns.Add("project")
            .Columns.Add("date_served")
            .Columns.Add("item_name")
            .Columns.Add("quantity")
            .Columns.Add("unit")
            .Columns.Add("date_of_request")
            .Columns.Add("rs_no")
            .Columns.Add("source")
            .Columns.Add("unit_price")
            .Columns.Add("total_amount")
            .Columns.Add("remarks")
        End With

        For i As Integer = 0 To LVL_HaulingReport.Items.Count - 1
            If LVL_HaulingReport.Items(i).BackColor = Color.LightGreen Then
            ElseIf LVL_HaulingReport.Items(i).BackColor = Color.Black Then

            Else
                dt.Rows.Add(
                LVL_HaulingReport.Items(i).SubItems(1).Text,
                LVL_HaulingReport.Items(i).SubItems(2).Text,
                LVL_HaulingReport.Items(i).SubItems(3).Text.Replace("› ", ""),
                LVL_HaulingReport.Items(i).SubItems(4).Text,
                LVL_HaulingReport.Items(i).SubItems(5).Text,
                LVL_HaulingReport.Items(i).SubItems(6).Text,
                LVL_HaulingReport.Items(i).SubItems(7).Text,
                LVL_HaulingReport.Items(i).SubItems(8).Text,
                LVL_HaulingReport.Items(i).SubItems(9).Text,
                LVL_HaulingReport.Items(i).SubItems(10).Text,
                LVL_HaulingReport.Items(i).SubItems(12).Text)

            End If
        Next

        Dim view As New DataView(dt)

        FHaulingReportView.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FHaulingReportView.ShowDialog()
        FHaulingReportView.Dispose()

        PanelPriview.Visible = False
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelPriview.Visible = False
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        PanelPriview.Visible = True
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click
        Dim sum_qty As Double

        For Each row As ListViewItem In LVL_HaulingReport.Items
            If row.Selected = True Then
                sum_qty = sum_qty + row.SubItems(4).Text
            End If

        Next

        MessageBox.Show("Sum qty: " & sum_qty, "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim dt As New DataTable

        With dt
            .Columns.Add("project")
            .Columns.Add("date_served")
            .Columns.Add("item_name")
            .Columns.Add("quantity")
            .Columns.Add("unit")
            .Columns.Add("date_of_request")
            .Columns.Add("rs_no")
            .Columns.Add("source")
            .Columns.Add("unit_price")
            .Columns.Add("total_amount")
            .Columns.Add("remarks")
        End With

        For i As Integer = 0 To 15

            dt.Rows.Add(
               "",
               "",
               "",
               "",
               "",
               "",
               "",
               "CABSP (CABADBARAN SOURCE)",
               0,
               0,
               "")

        Next

        Dim view As New DataView(dt)

        FHaulingReportView.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        FHaulingReportView.ShowDialog()
        FHaulingReportView.Dispose()
    End Sub
End Class