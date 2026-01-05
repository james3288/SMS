Public Class FStockpile_monitoring
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count_finesand, count_g1, count_3_4th As Integer

        For Each row As ListViewItem In lvlSelectedAggregates.Items
            For Each row1 As ListViewItem In FSelectedAggregates.lvlSelectedAggregates.Items

                If row1.SubItems(2).Text = row.SubItems(2).Text Then
                    If row1.SubItems(1).Text.Contains("Fine Sand") Then
                        count_finesand += 1
                    ElseIf row1.SubItems(1).Text.Contains("3/4 GRAVEL") Then
                        count_3_4th += 1
                    ElseIf row1.SubItems(1).Text.Contains("G-1") Then
                        count_g1 += 1
                    End If
                End If
            Next

            row.SubItems(3).Text = count_finesand
            row.SubItems(4).Text = count_3_4th
            row.SubItems(5).Text = count_g1

            count_finesand = 0
            count_3_4th = 0
            count_g1 = 0

        Next
    End Sub

    Public Sub FStockpile_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With FSelectedAggregates
            Dim count_finesand, count_g1, count_3_4th As String


            Dim a(10) As String
            For i = 0 To .local_array.GetUpperBound(0)

                For Each row1 As ListViewItem In .lvlSelectedAggregates.Items

                    If row1.SubItems(2).Text = .local_array(i, 1) Then
                        If row1.SubItems(1).Text.Contains("Fine Sand") Then
                            'count_finesand += 1
                            count_finesand &= row1.Text & " "
                        ElseIf row1.SubItems(1).Text.Contains("3/4 GRAVEL") Then
                            'count_3_4th += 1
                            count_3_4th &= row1.Text & " "
                        ElseIf row1.SubItems(1).Text.Contains("G-1") Then
                            'count_g1 += 1
                            count_g1 &= row1.Text & " "
                        End If
                    End If
                Next


                a(1) = .local_array(i, 0)
                a(2) = .local_array(i, 1)
                a(3) = count_finesand
                a(4) = count_3_4th
                a(5) = count_g1

                If a(1) = "" And a(2) = "" Then
                    Exit Sub
                End If

                Dim lvl As New ListViewItem(a)
                lvlSelectedAggregates.Items.Add(lvl)

                count_finesand = 0
                count_3_4th = 0
                count_g1 = 0

            Next


        End With


    End Sub

    Private Sub lvlSelectedAggregates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlSelectedAggregates.SelectedIndexChanged

    End Sub
End Class