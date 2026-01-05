Imports System.ComponentModel

Public Class FStockMonitoring_AggregatesList


    Dim listOfAggregates As New Model._Mod_Warehouse_Item
    Dim cListOfAggregates As New List(Of Model._Mod_Warehouse_Item.Warehouse_Item_Fields)
    Dim _aggregates
    Private Sub FStockMonitoring_AggregatesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        get_ListOfAggregates()
        get_ListOfSelectedAggregates()

    End Sub

    Private Sub get_ListOfAggregates()
        listOfAggregates = New Model._Mod_Warehouse_Item

        Dim searchby As String = "Search by Item Name"
        Dim search As String = "Aggregates"

        listOfAggregates.parameter("@n", 114)
        listOfAggregates.parameter("@searchby", searchby)
        listOfAggregates.parameter("@search", search)
        listOfAggregates.cStoreProcedureName = "proc_get_data_from_warehouse"


        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub get_ListOfSelectedAggregates()

        For Each row As String In FStockMonitoring.cListOfSelectedAggregates
            Dim a(0) As String
            a(0) = row

            Dim lvl As New ListViewItem(a)
            ListView2.Items.Add(lvl)
        Next
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        cListOfAggregates.Clear()
        cListOfAggregates = listOfAggregates.LISTOFWAREHOUSEITEM
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        display()
    End Sub

    Private Sub display()
        Dim a(3) As String
        _aggregates = (From aa In cListOfAggregates
                       Select aa Order By aa.item_desc Ascending
                       Select aa.item_desc.ToUpper()).Distinct()

        For Each row As String In _aggregates

            a(1) = row

            Dim lvl As New ListViewItem(a)

            ListView1.Items.Add(lvl)

        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListView2.Items.Clear()

        For Each row As ListViewItem In ListView1.Items
            If row.Checked = True Then
                Dim a(0) As String

                a(0) = row.SubItems(1).Text
                Dim lvl As New ListViewItem(a)
                ListView2.Items.Add(lvl)

            End If
        Next


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        For Each row As ListViewItem In ListView2.Items
            If row.Checked = True Then
                row.Remove()
                FStockMonitoring.cListOfSelectedAggregates.Remove(row.Text)
            End If
        Next

    End Sub

    Private Sub btnUnselectAll_Click(sender As Object, e As EventArgs) Handles btnUnselectAll.Click
        For Each row As ListViewItem In ListView1.Items
            row.Checked = False
        Next
    End Sub
End Class