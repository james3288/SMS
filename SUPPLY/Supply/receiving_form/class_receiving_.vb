Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_receiving_
    Private trd, trd2 As Threading.Thread
    Public cListOfReceiving2 As New List(Of rr_data2)
    Public cListOfPO2 As New List(Of po_data2)

    Public search As String
    Public searchby As String
    Public po_det_id As Integer
    Public item As String
    Public DateFrom As DateTime
    Public DateTo As DateTime
    Public typeofpurchasing As String

    Private ListOfSearch As New List(Of String)

    Sub New()
        'Search By Charges
        'search By Date Received
        'search By Invoice No.
        'search By Items
        'search By PO And CV No
        'search By RR No
        'search By RS No
        'search By Supplier
        ListOfSearch.Clear()

        ListOfSearch.Add("Items")
        ListOfSearch.Add("Supplier")
        ListOfSearch.Add("Charges")

    End Sub

    Public Sub receiving()
        'cListOfReceiving.Clear()
        trd = New Threading.Thread(AddressOf get_receiving)
        trd.Start()
        trd.Join()

    End Sub

    Public Sub po()
        trd2 = New Threading.Thread(AddressOf get_po)
        trd2.Start()
        trd2.Join()

    End Sub

    Private Sub get_po()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new6", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@rs_no", search)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim po As New po_data2

                With po
                    .po_det_id = newDR.Item("po_det_id").ToString
                    .po_cvno = newDR.Item("po_cv_no").ToString
                    .rs_no = newDR.Item("rs_no").ToString
                    .supplier = newDR.Item("supplier").ToString
                    .po_date = IIf(newDR.Item("po_date").ToString = "", Date.Parse("1990-01-01"), newDR.Item("po_date").ToString)
                    .po_qty = newDR.Item("po_qty").ToString
                    .item_name = newDR.Item("item_name").ToString
                    .item_desc = newDR.Item("item_desc").ToString
                    .remarks = newDR.Item("remarks").ToString
                    .charges = newDR.Item("CHARGES").ToString
                    .wh_id = newDR.Item("wh_id").ToString
                    .inout = newDR.Item("IN_OUT").ToString
                    .rs_purpose = newDR.Item("rs_purpose").ToString
                    .unit = newDR.Item("unit").ToString

                    cListOfPO2.Add(po)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Function defined_search(s As String) As String
        defined_search = s

        For Each search As String In ListOfSearch
            If search.ToUpper = s.ToUpper Then
                defined_search = ""
                Exit For
            End If
        Next

        Return defined_search
    End Function
    Private Sub get_receiving()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_receiving_crud_new6", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            'newCMD.CommandTimeout = 100

            If searchby = "Search By PO and CV No" Then
                newCMD.Parameters.AddWithValue("@n", 4)

            ElseIf searchby = "Search By Supplier" Then

                newCMD.Parameters.AddWithValue("@n", 6)
                'newCMD.Parameters.AddWithValue("@item", IIf(item = "Items", "", item))
                newCMD.Parameters.AddWithValue("@item", defined_search(item))
                newCMD.Parameters.AddWithValue("@datefrom", DateFrom)
                newCMD.Parameters.AddWithValue("@dateto", DateTo)
                'newCMD.Parameters.AddWithValue("@item", IIf(item = "Items...", "", item)

            ElseIf searchby = "Search By Charges" Then

                newCMD.Parameters.AddWithValue("@n", 6)
                newCMD.Parameters.AddWithValue("@item", defined_search(item))
                newCMD.Parameters.AddWithValue("@datefrom", DateFrom)
                newCMD.Parameters.AddWithValue("@dateto", DateTo)

            Else
                newCMD.Parameters.AddWithValue("@n", 2)
            End If

            newCMD.Parameters.AddWithValue("@searchby", searchby)
            newCMD.Parameters.AddWithValue("@search", defined_search(search))

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim rr As New rr_data2

                With rr
                    .rr_item_id = newDR.Item("rr_item_id").ToString
                    .rr_info_id = IIf(newDR.Item("rr_info_id").ToString = "", 0, newDR.Item("rr_info_id").ToString)
                    .rs_id = newDR.Item("rs_id").ToString
                    .rr_no = newDR.Item("rr_no").ToString
                    .po_det_id = IIf(newDR.Item("po_det_id").ToString = "", 0, newDR.Item("po_det_id").ToString)
                    .rs_no = newDR.Item("rs_no").ToString
                    .invoice_no = newDR.Item("invoice_no").ToString
                    .supplier = newDR.Item("supplier").ToString
                    .date_received = IIf(newDR.Item("date_received").ToString = "", Date.Parse("1990-01-01").ToString, newDR.Item("date_received").ToString)
                    .rr_qty = newDR.Item("rr_qty").ToString
                    .price = newDR.Item("price").ToString
                    .item_desc = newDR.Item("item_description").ToString
                    .charges = newDR.Item("CHARGES").ToString
                    .remarks = newDR.Item("remarks").ToString
                    .wh_id = IIf(newDR.Item("wh_id").ToString = "", 0, newDR.Item("wh_id").ToString)
                    .type_of_purchasing = newDR.Item("type_of_purchasing").ToString
                    .checked_by = newDR.Item("checked_by").ToString
                    .received_by = newDR.Item("received_by").ToString
                    .unit = newDR.Item("unit").ToString
                    .date_submitted = IIf(newDR.Item("date_submitted").ToString = "", Date.Parse("1990-01-01"), newDR.Item("date_submitted").ToString)
                    .wh_pn_id = IIf(newDR.Item("wh_pn_id").ToString = "", 0, newDR.Item("wh_pn_id").ToString)

                    cListOfReceiving2.Add(rr)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Class po_data2
            Public Property po_cvno As String
            Public Property rs_no As String
            Public Property po_det_id As Integer
            Public Property supplier As String
            Public Property po_date As DateTime
            Public Property po_qty As Double
            Public Property item_name As String
            Public Property item_desc As String
            Public Property charges As String
            Public Property wh_id As Integer
            Public Property inout As String
            Public Property rs_purpose As String
            Public Property remarks As String
            Public Property unit As String


        End Class
    Public Class rr_data2
        Public Property rr_item_id As Integer
        Public Property rr_info_id As Integer
        Public Property rr_no As String
        Public Property po_det_id As Integer
        Public Property rs_no As String
        Public Property po_cv_no As String
        Public Property invoice_no As String
        Public Property supplier As String
        Public Property date_received As DateTime
        Public Property rr_qty As Double
        Public Property price As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property remarks As String
        Public Property type_of_purchasing As String
        Public Property total_amount As String
        Public Property status As String
        Public Property sorting As String
        Public Property charges As String
        Public Property wh_id As Integer
        Public Property inout As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property rs_purpose As String
        Public Property unit As String
        Public Property rs_id As Integer
        Public Property lead_time As String
        Public Property date_submitted As DateTime
        Public Property wh_pn_id As Integer
        Public Property serial_id As Integer

    End Class

End Class
