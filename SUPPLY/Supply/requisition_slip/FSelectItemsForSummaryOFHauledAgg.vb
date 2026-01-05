Imports System.ComponentModel
Public Class FSelectItemsForSummaryOFHauledAgg
    Private r1, r2 As Boolean
    Private project As New class_summary_of_hauled_agg
    Public searchcategory As String
    Public specificProject As String

    Private cListOfTextbox As New List(Of class_placeholder3)
    Private clistOfCombobox As New List(Of class_placeholder3)

    Private cListOfDR
    Public alternateForm As Boolean
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub FSelectItemsForSummaryOFHauledAgg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filterListofTextbox_combobox.Clear()

        placeholder_textbox(txtSearch, "Search Item for Exemption", Nothing, Panel1, My.Resources.username_icon)
        placeholder_combobox(cmbMode, "MODE", Panel1, My.Resources.Access_icon)
        'trigger()

        'ListView2.Items.Clear()

        'For Each row In cListOfProj
        '    Dim a(10) As String
        '    a(0) = row.proj_id
        '    a(1) = row.project

        '    Dim lvl As New ListViewItem(a)
        '    ListView2.Items.Add(lvl)
        'Next

    End Sub

    Private Sub placeholder_textbox(tbox As TextBox, caption As String, AutoComplete_data As Object, panel_value As Panel, Optional icon As System.Drawing.Bitmap = Nothing)
        Dim pl As New class_placeholder3
        pl.textbox_name = tbox.Name
        pl.TextBox = tbox
        pl.text_hint = caption
        pl.icon = icon
        pl.panel = panel_value
        pl.AutoComplete = AutoComplete_data
        tbox.Text = pl.text_hint
        pl.Execute()

        cListOfTextbox.Add(pl)

        If panel_value Is Panel1 Then
            filterListofTextbox_combobox.Add(tbox, caption)
        End If
    End Sub

    Private Sub placeholder_combobox(cmb As ComboBox, caption As String, panel_value As Panel, Optional icon As System.Drawing.Bitmap = Nothing)
        Dim pl As New class_placeholder3

        pl.ComboBox = cmb
        pl.text_hint = caption
        pl.icon = icon
        pl.panel = panel_value
        cmb.Text = pl.text_hint
        pl.Execute_1()

        clistOfCombobox.Add(pl)

        If panel_value Is Panel1 Then
            filterListofTextbox_combobox.Add(cmb, caption)
        End If
    End Sub

    Private Sub trigger()
        project.cListOfProject.Clear()
        ListView2.Items.Clear()

        r1 = False
        r2 = False

        bw_check_if_done = New BackgroundWorker
        bw_check_if_done.WorkerSupportsCancellation = True
        bw_check_if_done.RunWorkerAsync()

        bw_get_project = New BackgroundWorker
        bw_get_project.WorkerSupportsCancellation = True
        bw_get_project.RunWorkerAsync()



        bw_get_charges = New BackgroundWorker
        bw_get_charges.WorkerSupportsCancellation = True
        bw_get_charges.RunWorkerAsync()

    End Sub
    Private Sub bw_get_project_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_project.DoWork

        project = Nothing
        project = New class_summary_of_hauled_agg

        project.get_project()

    End Sub

    Private Sub bw_get_project_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_project.RunWorkerCompleted
        r1 = True
    End Sub

    Private Sub check_if_done_process()
        While True
            If r1 = True And r2 = True Then
                Exit While
            End If
        End While
    End Sub

    Private Sub bw_check_if_done_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_check_if_done.DoWork
        check_if_done_process()
    End Sub

    Private Sub bw_check_if_done_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_check_if_done.RunWorkerCompleted

        Dim listofproject = project.cListOfProject

        For Each row In listofproject
            Dim a(5) As String

            If searchcategory = "Search by Specific Project" Then
                If row.project.ToUpper = specificProject.ToUpper Then
                    a(0) = row.proj_id
                    a(1) = row.project

                    Dim lvl As New ListViewItem(a)
                    ListView2.Items.Add(lvl)
                End If
            Else
                a(0) = row.proj_id
                a(1) = row.project

                Dim lvl As New ListViewItem(a)
                ListView2.Items.Add(lvl)
            End If


        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If alternateForm = True Then
            ListView1.Items.Clear()

            For Each rows As ListViewItem In ListView2.Items
                If rows.Checked = True Then
                    For Each row In FDRLIST2.DistinctListOfDRItems
                        If rows.SubItems(1).Text.ToUpper = row.requestor.ToString.ToUpper Then
                            Dim a(5) As String

                            a(0) = row.wh_id
                            a(1) = rows.SubItems(1).Text.ToUpper
                            a(2) = row.item_desc


                            Dim lvl As New ListViewItem(a)
                            ListView1.Items.Add(lvl)
                        End If
                    Next
                End If
            Next
            Exit Sub
        End If



        ListView1.Items.Clear()

        For Each rows As ListViewItem In ListView2.Items
            If rows.Checked = True Then
                For Each row In FDRLIST1.DistinctListOfDRItems
                    If rows.SubItems(1).Text.ToUpper = row.requestor.ToString.ToUpper Then
                        Dim a(5) As String

                        a(0) = row.wh_id
                        a(1) = rows.SubItems(1).Text.ToUpper
                        a(2) = row.item_desc


                        Dim lvl As New ListViewItem(a)
                        ListView1.Items.Add(lvl)
                    End If
                Next
            End If
        Next


        'Dim newProj As New class_summary_of_hauled_agg
        'newProj.cListOfProject_and_Items.Clear()

        'For Each row As ListViewItem In ListView2.Items
        '    If row.Checked = True Then
        '        newProj.get_items_from_project(row.Text, row.SubItems(1).Text)
        '    End If
        'Next

        'For Each row In newProj.cListOfProject_and_Items

        '    Dim a(5) As String
        '    a(0) = row.wh_id
        '    a(1) = row.project_name
        '    a(2) = row.items
        '    a(3) = row.stockpile
        '    a(4) = row.source

        '    Dim lvl As New ListViewItem(a)
        '    ListView1.Items.Add(lvl)
        'Next


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cListOfExemptedAggregates.Clear()

        For Each row As ListViewItem In ListView1.Items
            If row.Checked = True Then
                Dim listofexagg = New class_summary_of_hauled_agg.SELECTEDITEMS
                With listofexagg
                    .wh_id = row.Text
                    cListOfExemptedAggregates.Add(listofexagg)
                    'FRequistionForm.list_ListOfExAgg.Items.Add(row.SubItems(2).Text & "-" & row.SubItems(3).Text & "/" & row.SubItems(4).Text)
                End With
            End If
        Next

        'MsgBox(cListOfExemptedAggregates.Count)
        If alternateForm = True Then
            FPreparedbyvb.t = 3
        Else
            FPreparedbyvb.t = 1
        End If

        FPreparedbyvb.ShowDialog()


    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As ListViewItem In ListView2.Items
            row.Checked = True
        Next
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each row As ListViewItem In ListView2.Items
            row.Checked = False
        Next
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        For Each row As ListViewItem In ListView1.Items
            row.Checked = True
        Next
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        For Each row As ListViewItem In ListView1.Items
            row.Checked = False
        Next
    End Sub

    Private Sub bw_get_charges_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_get_charges.DoWork

        'DistinctListOfDR = From row In FDRLIST1.cNewListOfDr
        '                   Select row.requestor Distinct Order By requestor Ascending


        'For Each row In cListOfDR

        'Next

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'RESET
        'For Each row As ListViewItem In ListView1.Items
        '    row.BackColor = Color.White
        '    row.Checked = False
        'Next

        If cmbMode.Text = "SELECT" Then
            For Each row As ListViewItem In ListView1.Items
                If row.SubItems(2).Text.ToUpper.Contains(txtSearch.Text.ToUpper) Then
                    row.BackColor = Color.Orange
                    row.Checked = True
                End If
            Next
        ElseIf cmbMode.text = "UNSELECT" Then
            For Each row As ListViewItem In ListView1.Items
                If row.SubItems(2).Text.ToUpper.Contains(txtSearch.Text.ToUpper) Then
                    row.BackColor = Color.White
                    row.Checked = False
                End If
            Next
        End If

    End Sub

    Private Sub bw_get_charges_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw_get_charges.RunWorkerCompleted
        r2 = True
    End Sub
End Class