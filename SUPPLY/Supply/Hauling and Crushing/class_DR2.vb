Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class class_DR2

#Region "VARIABLES"
    Private cSearch As String
    Private cListOfDr As New List(Of drdata)
    Private cListOfWs As New List(Of wsdata)
    Private cListOfRs As New List(Of rsdata)
    Private cListOfPo As New List(Of podata)
    Private cListOfRR As New List(Of rrdata)
    Private cListOfMergeDR As New List(Of drlist2)

    Private myListOfDR As New BindingList(Of drdata2)()
    'Private finalSortDr


    Private cN As Integer = 0
    Private cColumnName As New List(Of String)
    Private cDrItemId As Integer = 0

    Private cListOfListViewItem As New List(Of ListViewItem)

    'Components
    Private cListView As New ListView
    Private cDataGridView As New DataGridView

#End Region

#Region "INITILAIZE"

    Public Sub _initialize(Optional rsno As String = "", Optional listview As ListView = Nothing, Optional dtview As DataGridView = Nothing, Optional n As Integer = 0, Optional dr_item_id As Integer = 0)
        cColumnName.Clear()
        cSearch = rsno
        cN = n
        cDrItemId = dr_item_id

        If cN = 1 Then
            cListView = listview

        ElseIf cN = 2 Then

            cDataGridView.AutoGenerateColumns = False
            cDataGridView = dtview

        End If

        cListOfRs = LISTOFRSDATA()
        cListOfDr = LISTOFDRDATA()
        cListOfWs = LISTOFWSDATA()
        cListOfPo = LISTOFPODATA()
        cListOfRR = LISTOFRRDATA()

        'MsgBox(cListOfRs.Count & vbCrLf & cListOfWs.Count & vbCrLf & cListOfWs.Count & vbCrLf & cListOfPo.Count & vbCrLf & cListOfRR.Count)
        merge()

    End Sub

    Public Function _initialize_new(Optional rsno As String = "", Optional listview As ListView = Nothing, Optional dtview As DataGridView = Nothing, Optional n As Integer = 0, Optional dr_item_id As Integer = 0) As List(Of drlist2)
        cColumnName.Clear()
        cSearch = rsno
        cN = n
        cDrItemId = dr_item_id

        If cN = 1 Then
            cListView = listview

        ElseIf cN = 2 Then

            cDataGridView.AutoGenerateColumns = False
            cDataGridView = dtview

        End If

        If cListOfRs.Count = 0 AndAlso cListOfDr.Count = 0 AndAlso cListOfWs.Count = 0 AndAlso cListOfPo.Count = 0 AndAlso cListOfRR.Count = 0 Then
            cListOfRs = LISTOFRSDATA()
            cListOfDr = LISTOFDRDATA()
            cListOfWs = LISTOFWSDATA()
            cListOfPo = LISTOFPODATA()
            cListOfRR = LISTOFRRDATA()

        End If

        _initialize_new = LISTOFMERGEDATA()



        'MsgBox(cListOfRs.Count & vbCrLf & cListOfWs.Count & vbCrLf & cListOfWs.Count & vbCrLf & cListOfPo.Count & vbCrLf & cListOfRR.Count)


    End Function
#End Region

#Region "DISPLAY"
    Private Sub merge()
        Dim sortedrs = From RS In cListOfRs
                       Select RS Order By RS.rs_date, RS.item_desc Ascending

        Dim sortws = From WS In cListOfWs
                     Select WS Order By WS.ws_date Ascending

        Dim sortdr = From DR In cListOfDr
                     Select DR Order By DR.dr_date Ascending

        Dim sortpo = From PO In cListOfPo
                     Select PO Order By PO.po_date Ascending

        Dim sortRR = From RR In cListOfRR
                     Select RR Order By RR.date_received Ascending

        For Each req In sortedrs
            '==> RS
            Dim a(40) As String
            With req

                If .inout = "IN" And .type_of_purchasing = "DR" And .request_type = "" And .process = "" Then
                Else
                    '<=== RS data here
                End If
            End With

            'RS ==> WITHDRAWAL
            If req.inout = "OUT" And req.type_of_purchasing = "WITHDRAWAL" Then

                For Each withraw In sortws
                    Dim b(50) As String
                    If withraw.rs_id = req.rs_id Then
                        With withraw
                            '<== withdrawal data here
                        End With
                    End If

                    'RS ==> WS ==> DR
                    For Each dr In sortdr
                        Dim c(50) As String
                        If withraw.ws_no = dr.ws_no And dr.rs_id = req.rs_id Then
                            With dr
                                Dim newDr2 As New drlist2

                                newDr2.dr_item_id = dr.dr_items_id
                                newDr2.rs_no = req.rs_no
                                newDr2.requestor = req.charges
                                newDr2.dr_date = dr.dr_date
                                newDr2.date_request = req.rs_date
                                newDr2.dr_no = dr.dr_no
                                newDr2.plateNo = dr.plateno
                                newDr2.driver = dr.driver
                                newDr2.ws_po_no = withraw.ws_no
                                newDr2.rr_no = "N/A"
                                newDr2.item_name = req.item_name
                                newDr2.item_desc = req.item_desc
                                newDr2.unit = withraw.unit
                                newDr2.source = req.source
                                newDr2.stockpile = req.wh_area
                                newDr2.withdrawn_by = withraw.withdrawn_by
                                newDr2.concession_ticket = dr.concession
                                newDr2.qty = dr.dr_qty
                                newDr2.price = dr.price
                                newDr2.total_amount = dr.price * dr.dr_qty
                                newDr2.supplier = "coming soon.."
                                newDr2.checked_by = dr.checked_by
                                newDr2.received_by = dr.received_by
                                newDr2.remarks = dr.remarks
                                newDr2.user = dr.users
                                newDr2.dr_option = withraw.dr_option
                                newDr2.rs_id = req.rs_id
                                newDr2.inout = req.inout
                                newDr2.wh_id = req.wh_id
                                newDr2.dr_info_id = dr.dr_info_id
                                newDr2.in_to_stockcard = dr.in_to_stockcard
                                newDr2.supplier = dr.supplier

                                cListOfMergeDR.Add(newDr2)

                            End With
                        End If
                    Next
                Next

                'RS ==> OTHERS OR IN AND PURCHASEORDER
            ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "PURCHASE ORDER" Or req.inout = "IN" And req.type_of_purchasing = "PURCHASE ORDER" Then
                For Each p In sortpo
                    Dim e(50) As String

                    If req.rs_id = p.rs_id Then
                        '<== PO data here

                        'RS ==> OTHERS/IN ==> RR
                        For Each rr In sortRR
                            Dim f(40) As String
                            If p.po_det_id = rr.po_det_id Then
                                '<=== RR Data here

                                'RS ==> OTHERS/IN ==> RR ==> DR
                                For Each dr In sortdr
                                    Dim g(50) As String
                                    If dr.rr_no = rr.rr_no And dr.rs_id = req.rs_id Then
                                        With dr

                                            Dim newDr2 As New drlist2

                                            newDr2.dr_item_id = dr.dr_items_id
                                            newDr2.rs_no = req.rs_no
                                            newDr2.requestor = req.charges
                                            newDr2.dr_date = dr.dr_date
                                            newDr2.date_request = req.rs_date
                                            newDr2.dr_no = dr.dr_no
                                            newDr2.plateNo = dr.plateno
                                            newDr2.driver = dr.driver
                                            newDr2.ws_po_no = p.po_no
                                            newDr2.rr_no = rr.rr_no
                                            newDr2.item_name = req.item_name
                                            newDr2.item_desc = req.item_desc
                                            newDr2.unit = dr.unit
                                            newDr2.source = req.source
                                            newDr2.stockpile = req.wh_area
                                            newDr2.withdrawn_by = "coming soon.."
                                            newDr2.concession_ticket = dr.concession
                                            newDr2.qty = dr.dr_qty
                                            newDr2.price = dr.price
                                            newDr2.total_amount = dr.price * dr.dr_qty
                                            newDr2.supplier = "coming soon.."
                                            newDr2.checked_by = dr.checked_by
                                            newDr2.received_by = dr.received_by
                                            newDr2.remarks = dr.remarks
                                            newDr2.user = dr.users
                                            newDr2.dr_option = p.dr_option
                                            newDr2.rs_id = req.rs_id
                                            newDr2.inout = req.inout
                                            newDr2.wh_id = req.wh_id
                                            newDr2.dr_info_id = dr.dr_info_id
                                            newDr2.in_to_stockcard = dr.in_to_stockcard
                                            newDr2.supplier = dr.supplier

                                            cListOfMergeDR.Add(newDr2)
                                        End With
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next

            ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "DR" Or
                req.inout = "IN" And req.type_of_purchasing = "DR" And req.process <> "" And req.unit <> "" And req.type_of_request <> "" Then

                'RS OTHERS =>= DR
                For Each dr In sortdr
                    Dim h(50) As String
                    If dr.rs_id = req.rs_id Then
                        With dr
                            Dim newDr2 As New drlist2

                            newDr2.dr_item_id = dr.dr_items_id
                            newDr2.rs_no = req.rs_no
                            newDr2.requestor = req.charges
                            newDr2.dr_date = dr.dr_date
                            newDr2.date_request = req.rs_date
                            newDr2.dr_no = dr.dr_no
                            newDr2.plateNo = dr.plateno
                            newDr2.driver = dr.driver
                            newDr2.ws_po_no = "N/A"
                            newDr2.rr_no = "N/A"
                            newDr2.item_name = req.item_name
                            newDr2.item_desc = req.item_desc
                            newDr2.unit = dr.unit
                            newDr2.source = req.source
                            newDr2.stockpile = req.wh_area
                            newDr2.withdrawn_by = "coming soon.."
                            newDr2.concession_ticket = dr.concession
                            newDr2.qty = dr.dr_qty
                            newDr2.price = dr.price
                            newDr2.total_amount = dr.price * dr.dr_qty
                            newDr2.supplier = "coming soon.."
                            newDr2.checked_by = dr.checked_by
                            newDr2.received_by = dr.received_by
                            newDr2.remarks = dr.remarks
                            newDr2.user = dr.users
                            newDr2.dr_option = "N/A"
                            newDr2.rs_id = req.rs_id
                            newDr2.inout = req.inout
                            newDr2.wh_id = req.wh_id
                            newDr2.dr_info_id = dr.dr_info_id
                            newDr2.in_to_stockcard = dr.in_to_stockcard
                            newDr2.supplier = dr.supplier

                            cListOfMergeDR.Add(newDr2)
                        End With
                    End If
                Next
            End If
        Next

        'MsgBox(cListOfDr2.Count)

        If cN = 1 Then
            display()

        ElseIf cN = 2 Then
            display2()

        End If

    End Sub

    Private Function get_merge_data() As List(Of drlist2)
        get_merge_data = New List(Of drlist2)

        Dim sortedrs = From RS In cListOfRs
                       Select RS Order By RS.rs_date, RS.item_desc Ascending

        Dim sortws = From WS In cListOfWs
                     Select WS Order By WS.ws_date Ascending

        Dim sortdr = From DR In cListOfDr
                     Select DR Order By DR.dr_date Ascending

        Dim sortpo = From PO In cListOfPo
                     Select PO Order By PO.po_date Ascending

        Dim sortRR = From RR In cListOfRR
                     Select RR Order By RR.date_received Ascending

        For Each req In sortedrs
            '==> RS
            Dim a(40) As String
            With req

                If .inout = "IN" And .type_of_purchasing = "DR" And .request_type = "" And .process = "" Then
                Else
                    '<=== RS data here
                End If
            End With

            'RS ==> WITHDRAWAL
            If req.inout = "OUT" And req.type_of_purchasing = "WITHDRAWAL" Then

                For Each withraw In sortws
                    Dim b(50) As String
                    If withraw.rs_id = req.rs_id Then
                        With withraw
                            '<== withdrawal data here
                        End With
                    End If

                    'RS ==> WS ==> DR
                    For Each dr In sortdr
                        Dim c(50) As String
                        If withraw.ws_no = dr.ws_no And dr.rs_id = req.rs_id Then
                            With dr
                                Dim newDr2 As New drlist2

                                newDr2.dr_item_id = dr.dr_items_id
                                newDr2.rs_no = req.rs_no
                                newDr2.requestor = req.charges
                                newDr2.dr_date = dr.dr_date
                                newDr2.date_request = req.rs_date
                                newDr2.dr_no = dr.dr_no
                                newDr2.plateNo = dr.plateno
                                newDr2.driver = dr.driver
                                newDr2.ws_po_no = withraw.ws_no
                                newDr2.rr_no = "N/A"
                                newDr2.item_name = req.item_name
                                newDr2.item_desc = req.item_desc
                                newDr2.unit = withraw.unit
                                newDr2.source = req.source
                                newDr2.stockpile = req.wh_area
                                newDr2.withdrawn_by = withraw.withdrawn_by
                                newDr2.concession_ticket = dr.concession
                                newDr2.qty = dr.dr_qty
                                newDr2.price = dr.price
                                newDr2.total_amount = dr.price * dr.dr_qty
                                newDr2.supplier = "coming soon.."
                                newDr2.checked_by = dr.checked_by
                                newDr2.received_by = dr.received_by
                                newDr2.remarks = dr.remarks
                                newDr2.user = dr.users
                                newDr2.dr_option = withraw.dr_option
                                newDr2.rs_id = req.rs_id
                                newDr2.inout = req.inout
                                newDr2.wh_id = req.wh_id
                                newDr2.dr_info_id = dr.dr_info_id
                                newDr2.in_to_stockcard = dr.in_to_stockcard
                                newDr2.supplier = dr.supplier

                                get_merge_data.Add(newDr2)

                            End With
                        End If
                    Next
                Next

                'RS ==> OTHERS OR IN AND PURCHASEORDER
            ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "PURCHASE ORDER" Or req.inout = "IN" And req.type_of_purchasing = "PURCHASE ORDER" Then
                For Each p In sortpo
                    Dim e(50) As String

                    If req.rs_id = p.rs_id Then
                        '<== PO data here

                        'RS ==> OTHERS/IN ==> RR
                        For Each rr In sortRR
                            Dim f(40) As String
                            If p.po_det_id = rr.po_det_id Then
                                '<=== RR Data here

                                'RS ==> OTHERS/IN ==> RR ==> DR
                                For Each dr In sortdr
                                    Dim g(50) As String
                                    If dr.rr_no = rr.rr_no And dr.rs_id = req.rs_id Then
                                        With dr

                                            Dim newDr2 As New drlist2

                                            newDr2.dr_item_id = dr.dr_items_id
                                            newDr2.rs_no = req.rs_no
                                            newDr2.requestor = req.charges
                                            newDr2.dr_date = dr.dr_date
                                            newDr2.date_request = req.rs_date
                                            newDr2.dr_no = dr.dr_no
                                            newDr2.plateNo = dr.plateno
                                            newDr2.driver = dr.driver
                                            newDr2.ws_po_no = p.po_no
                                            newDr2.rr_no = rr.rr_no
                                            newDr2.item_name = req.item_name
                                            newDr2.item_desc = req.item_desc
                                            newDr2.unit = dr.unit
                                            newDr2.source = req.source
                                            newDr2.stockpile = req.wh_area
                                            newDr2.withdrawn_by = "coming soon.."
                                            newDr2.concession_ticket = dr.concession
                                            newDr2.qty = dr.dr_qty
                                            newDr2.price = dr.price
                                            newDr2.total_amount = dr.price * dr.dr_qty
                                            newDr2.supplier = "coming soon.."
                                            newDr2.checked_by = dr.checked_by
                                            newDr2.received_by = dr.received_by
                                            newDr2.remarks = dr.remarks
                                            newDr2.user = dr.users
                                            newDr2.dr_option = p.dr_option
                                            newDr2.rs_id = req.rs_id
                                            newDr2.inout = req.inout
                                            newDr2.wh_id = req.wh_id
                                            newDr2.dr_info_id = dr.dr_info_id
                                            newDr2.in_to_stockcard = dr.in_to_stockcard
                                            newDr2.supplier = dr.supplier

                                            get_merge_data.Add(newDr2)
                                        End With
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next

            ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "DR" Or
                req.inout = "IN" And req.type_of_purchasing = "DR" And req.process <> "" And req.unit <> "" And req.type_of_request <> "" Then

                'RS OTHERS =>= DR
                For Each dr In sortdr
                    Dim h(50) As String
                    If dr.rs_id = req.rs_id Then
                        With dr
                            Dim newDr2 As New drlist2

                            newDr2.dr_item_id = dr.dr_items_id
                            newDr2.rs_no = req.rs_no
                            newDr2.requestor = req.charges
                            newDr2.dr_date = dr.dr_date
                            newDr2.date_request = req.rs_date
                            newDr2.dr_no = dr.dr_no
                            newDr2.plateNo = dr.plateno
                            newDr2.driver = dr.driver
                            newDr2.ws_po_no = "N/A"
                            newDr2.rr_no = "N/A"
                            newDr2.item_name = req.item_name
                            newDr2.item_desc = req.item_desc
                            newDr2.unit = dr.unit
                            newDr2.source = req.source
                            newDr2.stockpile = req.wh_area
                            newDr2.withdrawn_by = "coming soon.."
                            newDr2.concession_ticket = dr.concession
                            newDr2.qty = dr.dr_qty
                            newDr2.price = dr.price
                            newDr2.total_amount = dr.price * dr.dr_qty
                            newDr2.supplier = "coming soon.."
                            newDr2.checked_by = dr.checked_by
                            newDr2.received_by = dr.received_by
                            newDr2.remarks = dr.remarks
                            newDr2.user = dr.users
                            newDr2.dr_option = "N/A"
                            newDr2.rs_id = req.rs_id
                            newDr2.inout = req.inout
                            newDr2.wh_id = req.wh_id
                            newDr2.dr_info_id = dr.dr_info_id
                            newDr2.in_to_stockcard = dr.in_to_stockcard
                            newDr2.supplier = dr.supplier

                            get_merge_data.Add(newDr2)
                        End With
                    End If
                Next
            End If
        Next

        'MsgBox(cListOfDr2.Count)



    End Function


    Private Sub display()
        Dim a(50) As String
        Dim NEWLISTOFDR = From DR In cListOfMergeDR
                          Select DR Order By DR.dr_date, DR.item_desc Ascending

        'FOR WH TO WH
        Dim sortdr = From DR In cListOfDr
                     Select DR Order By DR.dr_date Ascending

        For Each row In NEWLISTOFDR
            a(0) = row.dr_item_id
            a(1) = row.dr_no
            a(2) = row.rs_no
            a(3) = row.dr_date
            a(4) = row.item_name
            a(5) = row.source
            a(6) = IIf(row.inout <> "OUT", row.qty, "-")
            a(7) = row.unit
            a(8) = row.concession_ticket
            a(9) = row.driver
            a(10) = row.requestor
            a(12) = row.checked_by
            a(13) = row.received_by
            a(15) = row.rs_id
            a(16) = row.inout
            a(19) = row.ws_po_no
            a(21) = row.remarks
            a(22) = row.supplier
            a(23) = row.user
            a(24) = row.plateNo
            a(25) = row.rr_no
            a(26) = IIf(row.inout = "OUT", row.qty, "-")
            a(36) = row.stockpile

            Dim lvl As New ListViewItem(a)
            cListOfListViewItem.Add(lvl)

            If row.inout = "OUT" Then
                'RS==> WS ==> -DR == > +DR | check if wh to wh 
                For Each dr2 In sortdr
                    Dim d(50) As String

                    If dr2.dr_no = row.dr_no And dr2.dr_items_id <> row.dr_item_id And dr2.ws_no = row.ws_po_no Then
                        a(0) = dr2.dr_items_id
                        a(1) = dr2.dr_no
                        a(2) = dr2.rs_no
                        a(3) = dr2.dr_date
                        a(4) = row.item_name
                        a(5) = dr2.wh_area
                        a(6) = row.qty
                        a(7) = row.unit
                        a(8) = row.concession_ticket
                        a(9) = row.driver
                        a(10) = row.requestor
                        a(12) = row.checked_by
                        a(13) = row.received_by
                        a(15) = row.rs_id
                        a(16) = row.inout
                        a(19) = row.ws_po_no
                        a(21) = row.remarks
                        a(22) = row.supplier
                        a(23) = row.user
                        a(24) = row.plateNo
                        a(25) = row.rr_no
                        a(26) = "-"
                        a(36) = dr2.wh_area

                        Dim lvl2 As New ListViewItem(a)
                        cListOfListViewItem.Add(lvl2)

                    End If
                Next
            End If

        Next

        If cListView.InvokeRequired Then
            cListView.Invoke(Sub()
                                 cListView.Items.AddRange(cListOfListViewItem.ToArray)
                             End Sub)
        Else
            cListView.Items.AddRange(cListOfListViewItem.ToArray)
        End If
    End Sub

    Private Sub display2()

        Dim a(50) As String
        Dim NEWLISTOFDR = From DR In cListOfMergeDR
                          Select DR Order By DR.dr_date, DR.item_desc Ascending

        'FOR WH TO WH
        Dim sortdr = From DR In cListOfDr
                     Select DR Order By DR.dr_date Ascending

        For Each row In NEWLISTOFDR

            If row.dr_item_id = cDrItemId Then
                Dim mydrdata As New drdata

                With mydrdata
                    .dr_items_id = row.dr_item_id
                    .dr_info_id = row.dr_info_id
                    .dr_no = row.dr_no
                    .rs_no = row.rs_no
                    .dr_date = row.dr_date
                    .item_name = $"{row.item_name} - {row.item_desc }"
                    .source = row.source
                    'a(6) = IIf(row.inout <> "OUT", row.qty, "-")
                    .dr_qty = row.qty
                    .unit = row.unit
                    .price = row.price
                    .concession = row.concession_ticket
                    .driver = row.driver
                    .requestor = $"OUT FROM: {row.stockpile  }"
                    .checked_by = row.checked_by
                    .received_by = row.received_by
                    .withdrawn_by = row.withdrawn_by
                    .rs_id = row.rs_id
                    .inout = row.inout
                    .ws_no = row.ws_po_no
                    .remarks = row.remarks
                    'a(22) = row.supplier
                    .users = row.user
                    .plateno = row.plateNo
                    .rr_no = row.rr_no
                    'a(26) = IIf(row.inout = "OUT", row.qty, "-")
                    .wh_area = row.stockpile
                    .withdrawn_by = row.withdrawn_by
                    .plateno = row.plateNo
                    .wh_id = row.wh_id
                    .in_to_stockcard = row.in_to_stockcard
                    .supplier = row.supplier

                    myListOfDR.Add(New drdata2(mydrdata))

                End With

                'Dim lvl As New ListViewItem(a)
                'cListOfListViewItem.Add(lvl)

                If row.inout = "OUT" Then
                    'RS==> WS ==> -DR == > +DR | check if wh to wh 
                    For Each dr2 In sortdr
                        Dim d(50) As String

                        If dr2.dr_no = row.dr_no And dr2.dr_items_id <> row.dr_item_id And dr2.ws_no = row.ws_po_no Then

                            Dim mydrdata2 As New drdata

                            With mydrdata2
                                .dr_items_id = dr2.dr_items_id
                                .dr_info_id = dr2.dr_info_id
                                .dr_no = dr2.dr_no
                                .rs_no = dr2.rs_no
                                .dr_date = dr2.dr_date
                                .item_name = $"{row.item_name} - {row.item_desc }"
                                .wh_area = dr2.wh_area
                                .dr_qty = row.qty
                                .unit = row.unit
                                .price = row.price
                                .concession = row.concession_ticket
                                .driver = row.driver
                                .requestor = $"IN TO: {dr2.wh_area}"
                                .checked_by = row.checked_by
                                .received_by = row.received_by
                                .withdrawn_by = row.withdrawn_by
                                .rs_id = dr2.rs_id
                                .inout = "IN"
                                .ws_no = row.ws_po_no
                                .remarks = row.remarks
                                'a(22) = row.supplier
                                .users = row.user
                                .plateno = row.plateNo
                                .rr_no = row.rr_no
                                'a(26) = "-"
                                .wh_area = dr2.wh_area
                                .plateno = dr2.plateno
                                .wh_id = dr2.wh_id
                                .in_to_stockcard = dr2.in_to_stockcard
                                .supplier = dr2.supplier

                                myListOfDR.Add(New drdata2(mydrdata2))
                            End With

                        End If
                    Next
                End If
            End If

proceedhere:

        Next

        If cDataGridView.InvokeRequired Then
            cDataGridView.Invoke(Sub()

                                     'For Each column In cColumnName

                                     '    ' Create a DataGridViewTextBoxColumn for the name column
                                     '    Dim nameColumn As New DataGridViewTextBoxColumn()
                                     '    nameColumn.DataPropertyName = column
                                     '    nameColumn.HeaderText = column
                                     '    cDataGridView.Columns.Add(nameColumn)

                                     'Next

                                     cDataGridView.DataSource = myListOfDR
                                 End Sub)
        Else
            'For Each column In cColumnName

            '    ' Create a DataGridViewTextBoxColumn for the name column
            '    Dim nameColumn As New DataGridViewTextBoxColumn()
            '    nameColumn.DataPropertyName = column
            '    nameColumn.HeaderText = column
            '    cDataGridView.Columns.Add(nameColumn)

            'Next

            cDataGridView.DataSource = myListOfDR
        End If
    End Sub
    Public Sub display3(Optional dgv As DataGridView = Nothing, Optional mergeDR As List(Of drlist2) = Nothing)
        'myListOfDR.Clear()

        Dim a(50) As String
        Dim NEWLISTOFDR = From DR In mergeDR
                          Select DR Order By DR.dr_date, DR.item_desc Ascending

        'FOR WH TO WH
        Dim sortdr = From DR In cListOfDr
                     Select DR Order By DR.dr_date Ascending

        For Each row In NEWLISTOFDR

            If row.dr_item_id = cDrItemId Then
                Dim mydrdata As New drdata

                With mydrdata
                    .dr_items_id = row.dr_item_id
                    .dr_info_id = row.dr_info_id
                    .dr_no = row.dr_no
                    .rs_no = row.rs_no
                    .dr_date = row.dr_date
                    .item_name = $"{row.item_name} - {row.item_desc }"
                    .source = row.source
                    'a(6) = IIf(row.inout <> "OUT", row.qty, "-")
                    .dr_qty = row.qty
                    .unit = row.unit
                    .price = row.price
                    .concession = row.concession_ticket
                    .driver = row.driver
                    .requestor = $"OUT FROM: {row.stockpile  }"
                    .checked_by = row.checked_by
                    .received_by = row.received_by
                    .withdrawn_by = row.withdrawn_by
                    .rs_id = row.rs_id
                    .inout = row.inout
                    .ws_no = row.ws_po_no
                    .remarks = row.remarks
                    'a(22) = row.supplier
                    .users = row.user
                    .plateno = row.plateNo
                    .rr_no = row.rr_no
                    'a(26) = IIf(row.inout = "OUT", row.qty, "-")
                    .wh_area = row.stockpile
                    .withdrawn_by = row.withdrawn_by
                    .plateno = row.plateNo
                    .wh_id = row.wh_id
                    .in_to_stockcard = row.in_to_stockcard
                    .supplier = row.supplier

                    myListOfDR.Add(New drdata2(mydrdata))

                End With

                'Dim lvl As New ListViewItem(a)
                'cListOfListViewItem.Add(lvl)

                If row.inout = "OUT" Then
                    'RS==> WS ==> -DR == > +DR | check if wh to wh 
                    For Each dr2 In sortdr
                        Dim d(50) As String

                        If dr2.dr_no = row.dr_no And dr2.dr_items_id <> row.dr_item_id And dr2.ws_no = row.ws_po_no Then

                            Dim mydrdata2 As New drdata

                            With mydrdata2
                                .dr_items_id = dr2.dr_items_id
                                .dr_info_id = dr2.dr_info_id
                                .dr_no = dr2.dr_no
                                .rs_no = dr2.rs_no
                                .dr_date = dr2.dr_date
                                .item_name = $"{row.item_name} - {row.item_desc }"
                                .wh_area = dr2.wh_area
                                .dr_qty = row.qty
                                .unit = row.unit
                                .price = row.price
                                .concession = row.concession_ticket
                                .driver = row.driver
                                .requestor = $"IN TO: {dr2.wh_area}"
                                .checked_by = row.checked_by
                                .received_by = row.received_by
                                .withdrawn_by = row.withdrawn_by
                                .rs_id = dr2.rs_id
                                .inout = "IN"
                                .ws_no = row.ws_po_no
                                .remarks = row.remarks
                                'a(22) = row.supplier
                                .users = row.user
                                .plateno = row.plateNo
                                .rr_no = row.rr_no
                                'a(26) = "-"
                                .wh_area = dr2.wh_area
                                .plateno = dr2.plateno
                                .wh_id = dr2.wh_id
                                .in_to_stockcard = dr2.in_to_stockcard
                                .supplier = dr2.supplier

                                myListOfDR.Add(New drdata2(mydrdata2))
                            End With

                        End If
                    Next
                End If
            End If

proceedhere:

        Next

        If cDataGridView.InvokeRequired Then
            cDataGridView.Invoke(Sub()
                                     dgv.DataSource = myListOfDR
                                 End Sub)
        Else
            dgv.DataSource = myListOfDR
        End If
    End Sub

#End Region

#Region "QUERY"
    Private Function get_rs() As List(Of rsdata)
        get_rs = New List(Of rsdata)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 1)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim rs As New rsdata
                With rs
                    .rs_id = reader.Item("rs_id").ToString
                    .rs_date = datechecker(reader.Item("rs_date").ToString)
                    .date_needed = datechecker(reader.Item("date_needed").ToString)
                    .rs_no = reader.Item("rs_no").ToString
                    .wh_id = reader.Item("wh_id").ToString
                    .rs_items = reader.Item("rs_items").ToString
                    .inout = reader.Item("inout").ToString
                    .item_name = reader.Item("item_name").ToString
                    .item_desc = reader.Item("item_desc").ToString
                    .wh_location = reader.Item("wh_location").ToString
                    .charges = reader.Item("charges").ToString
                    .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                    .request_type = reader.Item("typeRequest").ToString
                    .process = reader.Item("process").ToString
                    .rs_qty = reader.Item("rs_qty").ToString
                    .type_of_request = reader.Item("type_of_request").ToString
                    .users = reader.Item("users").ToString
                    .cons_item = reader.Item("cons_item").ToString
                    .cons_item_desc = reader.Item("cons_item_desc").ToString
                    .qty_takeoff_desc = reader.Item("qty_takeoff_desc").ToString
                    .job_order_no = reader.Item("job_order_no").ToString
                    .unit = reader.Item("unit").ToString
                    .location = reader.Item("location").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .type_of_charges = reader.Item("type_of_charges").ToString
                    .requested_by = reader.Item("requested_by").ToString
                    .wh_area = reader.Item("wh_area").ToString
                    .unit2 = reader.Item("unit2").ToString
                    .source = reader.Item("source").ToString

                    get_rs.Add(rs)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function
    Private Function get_dr() As List(Of drdata)
        get_dr = New List(Of drdata)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.add_parameter("@n", 2)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim dr As New drdata
                With dr
                    .dr_items_id = reader.Item("dr_items_id").ToString
                    .dr_info_id = reader.Item("dr_info_id").ToString
                    .dr_date = reader.Item("dr_date").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .dr_no = reader.Item("dr_no").ToString
                    .dr_qty = reader.Item("dr_qty").ToString
                    .rs_no = reader.Item("rs_no").ToString
                    .rs_id = reader.Item("rs_id").ToString
                    .inout = reader.Item("inout").ToString
                    .ws_no = reader.Item("ws_no").ToString
                    .rr_no = reader.Item("rr_no").ToString
                    .wh_area = reader.Item("wh_area").ToString
                    .price = reader.Item("price").ToString
                    .unit = reader.Item("unit").ToString
                    .wh_id = reader.Item("wh_id").ToString
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString
                    .concession = reader.Item("concession").ToString
                    .checked_by = reader.Item("checked_by").ToString
                    .received_by = reader.Item("received_by").ToString
                    .plateno = reader.Item("plate_no").ToString
                    .driver = reader.Item("driver").ToString
                    .in_to_stockcard = reader.Item("in_to_stockcard").ToString
                    .supplier = reader.Item("supplier").ToString

                    get_dr.Add(dr)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Private Function get_ws() As List(Of wsdata)
        get_ws = New List(Of wsdata)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 3)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim ws As New wsdata
                With ws
                    .rs_id = reader.Item("rs_id").ToString
                    .ws_id = reader.Item("ws_id").ToString
                    .ws_no = reader.Item("ws_no").ToString
                    .ws_qty = reader.Item("qty").ToString
                    .ws_date = datechecker(reader.Item("ws_date").ToString)
                    .inout = reader.Item("inout").ToString
                    .qty_withdrawn = IIf(reader.Item("qty_withdrawn").ToString = "", 0, reader.Item("qty_withdrawn").ToString)
                    .price = IIf(reader.Item("price").ToString = "", 0, reader.Item("price").ToString)
                    .unit = reader.Item("unit").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString
                    .dr_option = reader.Item("dr_option").ToString
                    .withdrawn_by = reader.Item("withdrawn_by").ToString

                    get_ws.Add(ws)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Private Function get_po() As List(Of podata)
        get_po = New List(Of podata)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 4)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim po As New podata
                With po
                    .rs_id = reader.Item("rs_id").ToString
                    .po_det_id = reader.Item("po_det_id").ToString
                    .po_no = reader.Item("po_no").ToString
                    .qty = reader.Item("qty").ToString
                    .po_date = datechecker(reader.Item("po_date").ToString)
                    .inout = reader.Item("inout").ToString
                    .unit = reader.Item("unit").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString
                    .dr_option = reader.Item("dr_option").ToString

                    get_po.Add(po)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Private Function get_rr() As List(Of rrdata)
        get_rr = New List(Of rrdata)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 5)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim rr As New rrdata
                With rr
                    .rs_id = reader.Item("rs_id").ToString
                    .rr_item_id = reader.Item("rr_item_id").ToString
                    .date_received = datechecker(reader.Item("date_received").ToString)
                    .rr_no = reader.Item("rr_no").ToString
                    .qty = reader.Item("qty").ToString
                    .po_det_id = reader.Item("po_det_id").ToString
                    .unit = reader.Item("unit").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString

                    get_rr.Add(rr)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "DELEGATES"
    Private Delegate Function ListOfRsDelegates() As List(Of rsdata)
    Private Delegate Function ListOfDrDelegates() As List(Of drdata)
    Private Delegate Function ListOfWsDelegates() As List(Of wsdata)
    Private Delegate Function ListOfPoDelegates() As List(Of podata)
    Private Delegate Function ListOfRrDelegates() As List(Of rrdata)
    Private Delegate Function ListOfMergeDataDelegates() As List(Of drlist2)


#End Region

#Region "FUNCTIONS"
    Private Function datechecker(d As String)
        If IsDate(d) Then
            Return Date.Parse(d)
        Else
            Return Date.Parse("1990-01-01")
        End If

    End Function
    Public Function LISTOFRSDATA() As List(Of rsdata)

        Dim RSDataInstance As ListOfRsDelegates = AddressOf get_rs

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = RSDataInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFRSDATA = RSDataInstance.EndInvoke(asyncResult)
    End Function
    Public Function LISTOFDRDATA() As List(Of drdata)

        Dim DRDataInstance As ListOfDrDelegates = AddressOf get_dr

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = DRDataInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFDRDATA = DRDataInstance.EndInvoke(asyncResult)
    End Function
    Public Function LISTOFWSDATA() As List(Of wsdata)

        Dim WSDataInstance As ListOfWsDelegates = AddressOf get_ws

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = WSDataInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFWSDATA = WSDataInstance.EndInvoke(asyncResult)

    End Function
    Public Function LISTOFPODATA() As List(Of podata)

        Dim PODataInstance As ListOfPoDelegates = AddressOf get_po

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = PODataInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFPODATA = PODataInstance.EndInvoke(asyncResult)

    End Function
    Public Function LISTOFRRDATA() As List(Of rrdata)

        Dim RRDataInstance As ListOfRrDelegates = AddressOf get_rr

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = RRDataInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFRRDATA = RRDataInstance.EndInvoke(asyncResult)

    End Function
    Public Function LISTOFMERGEDATA() As List(Of drlist2)

        Dim RRDataInstance As ListOfMergeDataDelegates = AddressOf get_merge_data

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = RRDataInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFMERGEDATA = RRDataInstance.EndInvoke(asyncResult)

    End Function
#End Region

#Region "CLEAR DATA"

    Public Sub clearData()
        myListOfDR.Clear()
        cListOfMergeDR.Clear()

    End Sub
#End Region

#Region "CLASS"
    Public Class rsdata
        Public Property rs_id As Integer
        Public Property rs_date As DateTime
        Public Property date_needed As DateTime
        Public Property date_log As DateTime
        Public Property rs_no As String
        Public Property wh_id As Integer
        Public Property rs_items As String
        Public Property inout As String
        Public Property item_name As String
        Public Property type_of_purchasing As String
        Public Property request_type As String
        Public Property item_desc As String
        Public Property wh_location As String
        Public Property charges As String
        Public Property rs_qty As Double
        Public Property process As String
        Public Property unit As String
        Public Property type_of_request As String
        Public Property users As String
        Public Property cons_item As String
        Public Property cons_item_desc As String
        Public Property qty_takeoff_desc As String
        Public Property job_order_no As String
        Public Property location As String
        Public Property type_of_charges As String
        Public Property requested_by As String
        Public Property wh_area As String
        Public Property unit2 As String
        Public Property source As String

    End Class
    Public Class drdata
        Public Property dr_items_id As Integer
        Public Property dr_date As DateTime
        Public Property date_log As DateTime
        Public Property dr_no As String
        Public Property dr_qty As Double
        Public Property rs_no As String
        Public Property ws_no As String
        Public Property rs_id As Integer
        Public Property inout As String
        Public Property rr_no As String
        Public Property users As String
        Public Property wh_area As String
        Public Property price As String
        Public Property unit As String
        Public Property wh_id As Integer
        Public Property remarks As String
        Public Property concession As String
        Public Property driver As String
        Public Property address As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property dr_info_id As String
        Public Property item_name As String
        Public Property source As String
        Public Property requestor As String
        Public Property withdrawn_by As String
        Public Property plateno As String
        Public Property requestor_category As String
        Public Property requestor_id As Integer
        Public Property in_to_stockcard As String
        Public Property supplier As String



    End Class

    Public Class drdata2
        Public Property dr_items_id As Integer
        Public Property dr_date As DateTime
        Public Property rs_no As String
        Public Property dr_no As String
        Public Property ws_no As String
        Public Property rr_no As String
        Public Property item_name As String
        Public Property dr_qty As Double
        Public Property price As Double
        Public Property unit As String
        Public Property wh_area As String
        Public Property requestor As String
        Public Property concession As String
        Public Property inout As String
        Public Property users As String
        Public Property address As String
        Public Property driver As String
        Public Property plateno As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property withdrawn_by As String
        Public Property supplier As String
        Public Property wh_id As Integer
        Public Property rs_id As Integer
        Public Property remarks As String
        Public Property dr_info_id As String
        Public Property date_log As DateTime
        Public Property in_to_stockcard As String


        Public Sub New(mydrdata As drdata)

            With mydrdata

                Me.dr_items_id = .dr_items_id
                Me.dr_date = .dr_date
                Me.rs_no = .rs_no
                Me.dr_no = .dr_no
                Me.dr_qty = .dr_qty
                Me.inout = .inout
                Me.rs_id = .rs_id
                Me.item_name = .item_name
                Me.requestor = .requestor
                Me.ws_no = .ws_no
                Me.price = .price
                Me.unit = .unit
                Me.concession = .concession
                Me.checked_by = .checked_by
                Me.received_by = .received_by
                Me.rr_no = "N/A"
                Me.plateno = .plateno
                Me.wh_id = .wh_id
                Me.driver = .driver
                Me.dr_info_id = .dr_info_id
                Me.in_to_stockcard = .in_to_stockcard
                Me.supplier = .supplier

            End With

        End Sub


    End Class
    Public Class wsdata
        Public Property ws_id As Integer
        Public Property rs_id As Integer
        Public Property ws_no As String
        Public Property ws_qty As Double
        Public Property ws_date As DateTime
        Public Property date_log As DateTime
        Public Property inout As String
        Public Property qty_withdrawn As Double
        Public Property price As Double
        Public Property unit As String
        Public Property remarks As String
        Public Property users As String
        Public Property dr_option As String
        Public Property withdrawn_by As String

    End Class
    Public Class podata
        Public Property rs_id As Integer
        Public Property po_det_id As Integer
        Public Property po_no As String
        Public Property qty As Double
        Public Property po_date As DateTime
        Public Property date_log As DateTime
        Public Property inout As String
        Public Property unit As String
        Public Property remarks As String
        Public Property users As String
        Public Property dr_option As String
    End Class
    Public Class rrdata
        Public Property rs_id As Integer
        Public Property rr_item_id As Integer
        Public Property date_received As DateTime
        Public Property date_log As DateTime
        Public Property rr_no As String
        Public Property qty As Double
        Public Property po_det_id As Integer
        Public Property unit As String
        Public Property remarks As String
        Public Property users As String
    End Class
    Public Class drlist2
        Public Property dr_item_id As Integer
        Public Property rs_no As String
        Public Property requestor As String
        Public Property dr_date As DateTime
        Public Property date_request As DateTime
        Public Property dr_no As String
        Public Property plateNo As String
        Public Property driver As String
        Public Property ws_po_no As String
        Public Property rr_no As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property unit As String
        Public Property source As String
        Public Property stockpile As String
        Public Property withdrawn_by As String
        Public Property concession_ticket As String
        Public Property qty As Double
        Public Property price As Double
        Public Property total_amount As Double
        Public Property supplier As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property remarks As String
        Public Property user As String
        Public Property reported_by As String
        Public Property dr_option As String
        Public Property wh_id As Integer
        Public Property rs_id As Integer
        Public Property dr_info_id As Integer
        Public Property inout As String
        Public Property in_to_stockcard As String
    End Class
#End Region
End Class
