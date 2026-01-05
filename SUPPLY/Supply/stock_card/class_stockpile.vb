Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_stockpile
    Private cWh_id As Integer
    Private cDateFrom As DateTime
    Private cdateTo As DateTime
    Private _rs_no2, _ws_no2, _dr_qty_using_ws_no2 As String
    Private cBalance, cPrev_balance As Double
    Private cItem, cWarehouseArea, cSource As String

    Structure prev_bal
        Dim qty_in As Double
        Dim qty_out As String
        Dim rs_no As String
        Dim ws_no As String
        Dim inout As String
        Dim dr_date As DateTime
        Dim sorting As String

    End Structure

    Public trd, trd5, trd6, trd7, trd8 As Threading.Thread

    Public cListOfQty As New List(Of prev_bal)
    Public Property myWh_id() As Integer
        Get
            Return cWh_id
        End Get
        Set(ByVal value As Integer)
            cWh_id = value
        End Set
    End Property

    Public Property myDateFrom() As DateTime
        Get
            Return cDateFrom
        End Get
        Set(ByVal value As DateTime)
            cDateFrom = value
        End Set
    End Property

    Public Property myDateTo() As DateTime
        Get
            Return cdateTo
        End Get
        Set(ByVal value As DateTime)
            cdateTo = value
        End Set
    End Property

    Public Property myItem() As String
        Get
            Return cItem
        End Get
        Set(ByVal value As String)
            cItem = value
        End Set
    End Property

    Public Property myWarehouseArea() As String
        Get
            Return cWarehouseArea
        End Get
        Set(ByVal value As String)
            cWarehouseArea = value
        End Set
    End Property

    Public Property mySource() As String
        Get
            Return cSource
        End Get
        Set(ByVal value As String)
            cSource = value
        End Set
    End Property

    Public Sub _initialize()
        trd = New Threading.Thread(AddressOf get_balance)
        trd.Start()
        trd.Join()

        'MsgBox(cWh_id & " done..")
        trd6 = New Threading.Thread(AddressOf initializing_balance)
        trd6.Start()
        trd6.Join()

        trd7 = New Threading.Thread(AddressOf get_prev_item_balance)
        trd7.Start()
        trd7.Join()

        Dim result As Double
        result = CStr(cBalance + cPrev_balance)
        'Row.cells(10).value = FormatNumber(CDbl(CStr(result)), 2,,, TriState.True)

        Dim ls As New mod_stock_pile.ls
        ls.wh_id = cWh_id
        ls.balance = FormatNumber(result, 2,,, TriState.True)
        ls.items = cItem
        ls.wharea = cWarehouseArea
        ls.source = cSource

        mod_stock_pile.cListOfStockPile_Final.Add(ls)
    End Sub

    Private Sub get_balance()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@wh_id", cWh_id)
            newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
            newCMD.Parameters.AddWithValue("@date_to", cDateTo)
            newCMD.CommandTimeout = 200

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            Dim newSc As New prev_bal

            While newDR.Read

                With newSc
                    .rs_no = newDR.Item("rs_no").ToString
                    .ws_no = newDR.Item("WS_NO").ToString.ToUpper
                    .inout = newDR.Item("IN_OUT").ToString
                    .dr_date = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                    .sorting = newDR.Item("SORTING").ToString

                    If newDR.Item("WITHDRAWN").ToString = "NO" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        If newDR.Item("SORTING").ToString = "A" Then
                            .qty_in = 0

                            _rs_no2 = .rs_no
                            _ws_no2 = .ws_no

                            count_qty_dr_using_ws_no2()

                            Dim count_qty_dr As Double = _dr_qty_using_ws_no2
                            .qty_out = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr

                            If count_qty_dr = 0 Then
                                .qty_out = CDbl(newDR.Item("qty_OUT").ToString)
                            Else
                                .qty_out = count_qty_dr & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                            End If
                        Else
                            .qty_in = 0
                            .qty_out = newDR.Item("qty_OUT").ToString

                        End If

                    ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                        .qty_in = newDR.Item("qty_IN").ToString
                        .qty_out = 0

                    End If
                    cListOfQty.Add(newSc)
                End With
proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function count_qty_dr_using_ws_no2() As Double
        trd5 = New Threading.Thread(AddressOf get_dr_qty_using_ws_no2)
        trd5.Start()
        trd5.Join()
    End Function

    Private Sub get_dr_qty_using_ws_no2()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@ws_no", _ws_no2)
            newCMD.Parameters.AddWithValue("@rs_no", _rs_no2)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("qty").ToString = "" Then
                    _dr_qty_using_ws_no2 = 0
                Else
                    _dr_qty_using_ws_no2 = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub initializing_balance()

        cBalance = 0

        'For Each row In cListOfQty
        '    If row.inout = "OUT" Then
        '        If IsNumeric(row.qty_out) Then
        '            cBalance = Math.Round(cBalance, 2) - FormatNumber(CDbl(row.qty_out), 2,,, TriState.True)
        '        Else
        '            Dim sp() As String = row.qty_out.ToString.Split("/")

        '            If CDbl(sp(0)) < CDbl(sp(1)) Then
        '                cBalance = Math.Round(cBalance, 2) - (FormatNumber(CDbl(sp(1)), 2,,, TriState.True) - FormatNumber(CDbl(sp(0)), 2,,, TriState.True))
        '            End If
        '        End If

        '    ElseIf row.inout = "IN" Then
        '        cBalance = Math.Round(cBalance, 2) + row.qty_in
        '    End If
        'Next


        Dim qty_out, qty_in As Double
        For Each row In cListOfQty
            If row.inout = "OUT" Then
                If IsNumeric(row.qty_out) Then
                    qty_out += CDbl(CStr(row.qty_out))
                Else
                    Dim sp() As String = row.qty_out.ToString.Split("/")

                    If CDbl(sp(0)) < CDbl(sp(1)) Then
                        qty_out += CDbl(CStr((CDbl(sp(1)) - CDbl(sp(0)))))

                    End If
                End If
            End If

            If row.inout = "IN" Then
                qty_in += row.qty_in
            End If
        Next

        cBalance = (qty_in) - CDbl(CStr(qty_out)) 'FormatNumber((qty_in) - CDbl(CStr(qty_out)), 2,,, TriState.False)

    End Sub

    Public Sub get_prev_item_balance()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT a.balance FROM dbPrevious_stock_card a WHERE a.wh_id = " & cWh_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cPrev_balance = newDR.Item("balance").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub



End Class
