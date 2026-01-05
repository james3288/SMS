Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class class_aggregates_monitoring
    Private agg As New BackgroundWorker
    Private agg_checker As New BackgroundWorker
    Private cCharges As String
    Private cItems As String
    Public cListOfRsMonAgg As New List(Of rs_monitoring_agg)
    Private cListview As New ListView
    Private cDatefrom As DateTime
    Private cDateto As DateTime
    Private cWhatAgg As String
    Private cNumberofAgg As Integer
    Private cLoadingPanel As Panel


    Sub New()
        '------ADD HANDLER HERE----------

        'SEARCH
        AddHandler agg.DoWork, AddressOf gg_DoWork
        AddHandler agg.RunWorkerCompleted, AddressOf gg_RunWorkerCompleted

        AddHandler agg_checker.DoWork, AddressOf agg_checker_DoWork
        AddHandler agg_checker.RunWorkerCompleted, AddressOf agg_checker_DoWork_RunWorkerCompleted
        '-----END HANDLER HERE-------------
    End Sub

    Public Sub _initialize(charges As String, items As String, Optional listview As ListView = Nothing, Optional datefrom As DateTime = Nothing, Optional dateto As DateTime = Nothing, Optional aggname As String = Nothing)
        cCharges = charges
        cItems = items
        cListview = listview
        cDatefrom = datefrom
        cDateto = dateto
        cWhatAgg = aggname

        agg.WorkerSupportsCancellation = True
        agg.RunWorkerAsync()

    End Sub

    Public Sub _initialize_checker(Optional listview As ListView = Nothing, Optional numberofagg As Integer = 0, Optional panel_loading As Panel = Nothing)
        cListview = listview
        cNumberofAgg = numberofagg
        cLoadingPanel = panel_loading

        agg_checker.WorkerSupportsCancellation = True
        agg_checker.RunWorkerAsync()

    End Sub
    'HANDLER FOR DISPLAYING AGGREGATES
    Private Sub gg_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf search_rs_for_aggregates)
        trd.Start()
        trd.Join()
    End Sub
    Private Sub gg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        pub_cbcb += 1

    End Sub

    'agg_checker
    'HANDLER FOR AGGR. IF ALL TRUE 
    Private Sub agg_checker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf checker)
        trd.Start()
        trd.Join()
    End Sub

    Private Sub agg_checker_DoWork_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

        'DISPLAY
        If Not agg.IsBusy And Not agg_checker.IsBusy Then
            agg.Dispose()
            agg_checker.Dispose()
        End If

        display_rs_agg_monitoring()


    End Sub


    'QUERY FOR SEARCHING AGGREGATES
    Private Sub search_rs_for_aggregates()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        cListOfRsMonAgg.Clear()

        Try
            Dim c As New class_query

            c.add_parameter("@charges", cCharges)
            c.add_parameter("@search", cItems)
            c.add_parameter("@datefrom", cDatefrom)
            c.add_parameter("@dateto", cDateto)

            Dim reader As SqlDataReader = c.sql_data("proc_aggregates_general_request3", SQ.connection, 300)

            While reader.Read
                Dim rma As New rs_monitoring_agg

                With rma
                    'For Each row In pub_list_of_agg_monitoring
                    '    If row.rs_id = reader.Item("rs_id").ToString Then
                    '        GoTo continuehere
                    '        Exit For
                    '    End If
                    'Next

                    .rs_id = reader.Item("rs_id").ToString
                    .wh_id = IIf(reader.Item("wh_id").ToString = "", 0, reader.Item("wh_id").ToString)
                    .type_of_aggregates = cItems
                    .items = reader.Item("items").ToString
                    .qty = IIf(reader.Item("rs_qty").ToString = "", 0, reader.Item("rs_qty").ToString)
                    .purpose = reader.Item("purpose").ToString
                    .rs_no = reader.Item("rs_no").ToString
                    .charges = reader.Item("charges").ToString
                    .qty_withdrawn = IIf(reader.Item("qty_withdrawn").ToString = "", 0, reader.Item("qty_withdrawn").ToString)
                    .dr_delivered = IIf(reader.Item("delivered_dr").ToString = "", 0, reader.Item("delivered_dr").ToString)
                    .rs_date = reader.Item("rs_date").ToString
                    .inout = reader.Item("IN_OUT").ToString
                    .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                    .dr_option = reader.Item("dr_option").ToString

                    pub_list_of_agg_monitoring.Add(rma)

continuehere:

                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub display_rs_agg_monitoring()
        Try
            Dim listoflistview As New List(Of ListViewItem)

            'Dim AGGDATA = From A In pub_list_of_agg_monitoring
            '              Select A Order By A.rs_date Ascending

            Dim AGGDATA = From A In pub_list_of_agg_monitoring
                          Select A Group By A.wh_id, A.items, A.qty,
                                       A.purpose, A.rs_no, A.charges, A.qty_withdrawn, A.dr_delivered, A.rs_date, A.type_of_purchasing,
                                       A.inout, A.rs_id, A.dr_option
                                       Into Group Order By items Ascending


            For Each row In AGGDATA
                Dim a(28) As String
                Dim sign As String = "-"
                a(0) = row.wh_id
                a(1) = row.items
                a(2) = row.qty
                a(3) = row.purpose
                a(4) = row.rs_no
                a(5) = row.charges
                a(6) = row.dr_option
                a(7) = "" 'IIf(row.type_of_aggregates = "SAND", "FINE SAND", row.type_of_aggregates)
                a(8) = IIf(row.qty_withdrawn = 0, sign, row.qty_withdrawn)
                a(9) = IIf(row.type_of_purchasing = "DR", IIf((row.qty - row.dr_delivered) = 0, sign, (row.qty - row.dr_delivered)), IIf((row.qty - row.qty_withdrawn) = 0, sign, (row.qty - row.qty_withdrawn)))
                'a(9) = IIf(row.type_of_purchasing = "DR", row.qty - row.dr_delivered, row.qty - row.qty_withdrawn)
                a(10) = IIf(row.dr_delivered = 0, sign, row.dr_delivered)
                a(11) = row.rs_date
                a(12) = row.type_of_purchasing
                a(13) = row.inout
                a(14) = row.rs_id
                'a(15) = IIf(row.type_of_purchasing = "DR", "-", IIf(row.dr_option = "WITHOUT DR", "-", IIf((row.qty_withdrawn - row.dr_delivered) = 0, "-", (row.qty_withdrawn - row.dr_delivered))))

                If row.dr_option = "WITHOUT DR" And row.dr_delivered > 0 Then
                    a(15) = row.qty_withdrawn - row.dr_delivered
                ElseIf row.dr_option = "WITHOUT DR" And row.dr_delivered = 0 Then
                    a(15) = sign
                ElseIf row.dr_option = "WITH DR" Then
                    a(15) = IIf((row.qty_withdrawn - row.dr_delivered) = 0, sign, (row.qty_withdrawn - row.dr_delivered))
                End If

                Dim lvl As New ListViewItem(a)
                listoflistview.Add(lvl)
            Next

            If cListview.InvokeRequired Then
                cListview.Invoke(Sub()
                                     cListview.Items.AddRange(listoflistview.ToArray)
                                     cLoadingPanel.Visible = False

                                 End Sub)
            End If



        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub checker()
        While pub_cbcb <> cNumberofAgg
            Threading.Thread.Sleep(100)
        End While

        display_rs_agg_monitoring()

    End Sub
    Public Class rs_monitoring_agg
        Public Property wh_id As Integer
        Public Property items As String
        Public Property qty As Double
        Public Property qty_withdrawn As Double
        Public Property dr_delivered As Double
        Public Property type_of_purchasing As String
        Public Property rs_date As DateTime
        Public Property inout As String
        Public Property purpose As String
        Public Property rs_no As String
        Public Property charges As String
        Public Property Item_Name As String
        Public Property type_of_aggregates As String
        Public Property rs_id As Integer
        Public Property dr_option As String

    End Class

End Class
