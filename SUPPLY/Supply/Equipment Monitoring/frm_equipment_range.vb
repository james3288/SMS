Imports System.Globalization

Public Class frm_equipment_range
    Public itemlist As New List(Of List(Of String))
    Dim itemlist_for_range As New List(Of List(Of String))
    Dim total_pages As Integer = 0
    Dim current_page As Integer = 0
    Dim prev_selected_row As Integer = 0
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub frm_equipment_range_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Clear()
        viewlist_1()
        Button1.Enabled = False
        Button2.Enabled = False
        For i = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Height = 20
        Next
    End Sub
    Sub viewlist_1()
        Dim count As Integer = 1
        Dim a(20) As String
        For Each l As List(Of String) In itemlist
            a(0) = l(0)
            a(1) = l(1)
            a(2) = l(2)
            a(3) = l(3)
            a(4) = l(4)
            a(5) = l(5)
            a(6) = l(6)
            a(7) = l(7)
            a(8) = l(8)
            a(9) = l(9)
            a(10) = l(10)
            a(11) = l(11)
            Dim lvl As New ListViewItem(a)
            DataGridView1.Rows.Add(a)
            'ListView1.Items.Add(lvl)
            count = count + 1
        Next
    End Sub
    Sub view_page(ByVal default_val As Boolean, ByVal page_number As Integer)
        ListView2.Items.Clear()

        If default_val = False Then
            current_page = current_page + page_number
        Else
            current_page = page_number
        End If
        Dim count As Integer = 1
        Dim a(20) As String
        For Each l As List(Of String) In itemlist_for_range
            If l(0) = current_page Then
                ListView2.Columns(0).Text = l(1)
                a(0) = l(2)
                a(1) = l(3)
                a(2) = l(4)
                a(3) = l(5)
                Dim lvl As New ListViewItem(a)
                ListView2.Items.Add(lvl)
            End If

            count = count + 1
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        view_page(False, 1)
        If current_page >= total_pages Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        view_page(False, -1)
        If current_page <= 1 Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If
        Button1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        itemlist_for_range.Clear()
        total_pages = MonthDifference(DateTimePicker1.Text, DateTimePicker2.Text) + 1
        set_itemlist_for_range(DateTimePicker1.Text, DateTimePicker2.Text)
        view_page(True, 1)
        If total_pages <= 1 Then
            Button2.Enabled = False
            Button1.Enabled = False
        Else
            Button2.Enabled = False
            Button1.Enabled = True
        End If

    End Sub
    Public Shared Function MonthDifference(ByVal first As DateTime, ByVal second As DateTime) As Integer
        'MsgBox(first.Month & "==" & first.Day & "==" & first.Year)
        Dim res As Integer = 0
        If first.Day > second.Day Then
            res = (second.Month - first.Month) + 12 * (second.Year - first.Year) - 1
        Else
            res = (second.Month - first.Month) + 12 * (second.Year - first.Year)
        End If
        If res <= 0 Then
            Return 0
        Else
            Return res
        End If
    End Function


    Sub set_itemlist_for_range(ByVal first As DateTime, ByVal second As DateTime)
        Dim date_from As DateTime = first
        Dim date_to As DateTime = second
        Dim page_number As Integer = 1
        Dim i As Integer = 0
        While date_from <= date_to
            For Each item As DataGridViewRow In DataGridView1.Rows
                Dim cost As Decimal = CDbl(item.Cells(7).Value)
                Dim dep_month As Decimal = CDbl(item.Cells(9).Value)
                Dim month_year As String = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date_from.Month) & " " & date_from.Year
                Dim temp_date_to As DateTime = DateSerial(date_from.Year, date_from.Month, date_to.Day)
                Dim month_age As Integer = MonthDifference(item.Cells(0).Value, temp_date_to)
                Dim amount As Decimal = CDbl(item.Cells(11).Value)
                Dim cum_a_d As Decimal
                If dep_month <= month_age Then
                    cum_a_d = amount * dep_month

                Else
                    cum_a_d = amount * month_age
                End If
                '11
                Dim net_val As Decimal = cost - cum_a_d
                itemlist_for_range.Add(New List(Of String))
                itemlist_for_range(i).Add(page_number)
                itemlist_for_range(i).Add(month_year)
                If month_age > dep_month Then
                    itemlist_for_range(i).Add("0")
                Else
                    itemlist_for_range(i).Add(month_age)
                End If
                itemlist_for_range(i).Add(FormatNumber(amount))
                itemlist_for_range(i).Add(FormatNumber(cum_a_d))
                If net_val <= 0 Then
                    itemlist_for_range(i).Add("Fully Depreciated")
                Else
                    itemlist_for_range(i).Add(FormatNumber(net_val))
                End If

                i = i + 1
            Next
            '    itemlist_for_range.Add(New List(Of String))
            '    'lvl_equipment_monitoring.Columns.Add(date_from.Month.ToString & "/" & date_from.Year.ToString, -2, HorizontalAlignment.Center)
            '    'lvl_equipment_monitoring.Columns.Add("      Amount      ", -2, HorizontalAlignment.Center)
            '    'lvl_equipment_monitoring.Columns.Add("     Cum A/D      ", -2, HorizontalAlignment.Center)
            '    'lvl_equipment_monitoring.Columns.Add("     Net Val      ", -2, HorizontalAlignment.Center)
            date_from = date_from.AddMonths(1)
            date_from = LastDayOfMonth(date_from.Month, date_from.Year)
            'date_from = date_from.ToString("MM/dd/yyyy")
            page_number = page_number + 1
        End While
    End Sub
    Function LastDayOfMonth(theMonth As Long, theYear As Long) As Date
        LastDayOfMonth = DateSerial(theYear, theMonth + 1, 0)
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ListView2.Items(prev_selected_row).BackColor = Color.White
            ListView2.Items(prev_selected_row).ForeColor = Color.Black
            'ListView2.Items(ListView1.SelectedItems(0).Index).Selected = True
            ListView2.Items(DataGridView1.CurrentRow.Index).BackColor = Color.CornflowerBlue
            ListView2.Items(DataGridView1.CurrentRow.Index).ForeColor = Color.White
            prev_selected_row = DataGridView1.CurrentRow.Index
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            ListView2.Items(prev_selected_row).BackColor = Color.White
            ListView2.Items(prev_selected_row).ForeColor = Color.Black
            'ListView2.Items(ListView1.SelectedItems(0).Index).Selected = True
            ListView2.Items(DataGridView1.CurrentRow.Index).BackColor = Color.CornflowerBlue
            ListView2.Items(DataGridView1.CurrentRow.Index).ForeColor = Color.White
            ListView2.Items(DataGridView1.CurrentRow.Index).EnsureVisible()
            prev_selected_row = DataGridView1.CurrentRow.Index

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'DataGridView1.FirstDisplayedScrollingRowIndex = 100

    End Sub
End Class