Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FWasteExcemption
    Private Sub FWasteExcemption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For Each row As ListViewItem In lvlListOfAggregates.Items
        '    row.Checked = True
        'Next
        CheckBox1.Checked = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        FDRLIST.lvl_drList.Items.Clear()

        For Each row As ListViewItem In lvlListOfAggregates.Items
            If row.Checked = True Then
                'HauledReport.generate_summary_aggregates(row.Text, row.SubItems(1).Text)

                If FDRLIST.cmbSearchBy.Text = "Search by Project/Requestor" Then
                    If FSORTBY.cmbEnable_Disable.Text = "ENABLE" Then
                        FDRLIST.dr_list(37, row.Text, row.SubItems(1).Text)
                    Else
                        FDRLIST.dr_list(36, row.Text, row.SubItems(1).Text)
                    End If

                ElseIf FDRLIST.cmbSearchBy.Text = "Search by Warehouse/Stockpile" Then
                    If FSORTBY.cmbEnable_Disable.Text = "ENABLE" Then
                        FDRLIST.dr_list(377, row.Text, row.SubItems(1).Text)
                    Else
                        FDRLIST.dr_list(366, row.Text, row.SubItems(1).Text)
                    End If

                End If

            End If
        Next

        Dim ws, rs, dr, inout As String

        For Each row As ListViewItem In FDRLIST.lvl_drList.Items
            ws = row.SubItems(19).Text
            dr = row.SubItems(1).Text
            rs = row.SubItems(2).Text
            inout = row.SubItems(16).Text

            Dim result As Double = 0.000

            'lvlDRList.Items(rowcount).SubItems(3).Text = ""




            If inout = "OUT" Then
                If row.Text = 0 Then
                    row.BackColor = Color.Gold
                Else
                    row.BackColor = Color.LightGreen
                End If


                If Double.TryParse(row.SubItems(26).Text, result) = False Then
                    row.BackColor = Color.Green
                    row.ForeColor = Color.White
                    row.Font = New Font(row.Font, FontStyle.Italic)

                    row.SubItems(3).Text = ""
                End If

            ElseIf inout = "IN" Or inout = "OTHERS" Then
                If Double.TryParse(row.SubItems(6).Text, result) = False Then
                    row.BackColor = Color.Green
                    row.ForeColor = Color.White
                    row.Font = New Font(row.Font, FontStyle.Bold)

                    row.SubItems(3).Text = ""
                End If
            End If



            'If ws = "N/A" And dr = "N/A" And rs = "N/A" Then
            '    row.BackColor = Color.Pink

            'ElseIf ws <> "" And inout = "OUT" Then

            '    If ws <> "" And inout = "OUT" And dr <> "" Then
            '        row.BackColor = Color.LightGreen
            '    Else
            '        row.BackColor = Color.Honeydew
            '    End If
            'End If

            'If IsNumeric(row.SubItems(4).Text) = True Then
            'Else
            '    row.BackColor = Color.Green
            '    row.ForeColor = Color.White
            'End If

            If row.BackColor = Color.Green And row.Text = 0 And ws = "N/A" Then
                row.Remove()
            End If

        Next

        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            For Each row As ListViewItem In lvlListOfAggregates.Items
                If row.Checked = False Then
                    row.Checked = True
                End If
            Next
        Else
            For Each row As ListViewItem In lvlListOfAggregates.Items
                If row.Checked = True Then
                    row.Checked = False
                End If
            Next
        End If
    End Sub

    Private Sub CheckSelectedItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckSelectedItemToolStripMenuItem.Click
        For Each row As ListViewItem In lvlListOfAggregates.Items
            If row.Selected = True Then
                row.Checked = True
            End If
        Next
    End Sub

    Private Sub UncheckSelectedItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UncheckSelectedItemToolStripMenuItem.Click
        For Each row As ListViewItem In lvlListOfAggregates.Items
            If row.Selected = True Then
                row.Checked = False
            End If
        Next
    End Sub
End Class