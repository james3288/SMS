Imports System.Data.SqlClient

Public Class class_withdrawal
    Public trd As Threading.Thread
    Public Property ws_id As Integer
    Public Property done As Boolean

    Public Structure struc_wsList

        Dim ws_id As Integer
        Dim ws_no As String
        Dim rs_no As String
        Dim date_withdrawn As DateTime
        Dim item_name As String
        Dim item_desc As String
        Dim qty As Double
        Dim unit As String
        Dim unit_price As Double
        Dim amount As Double
        Dim withdrawn_from As String
        Dim warehouse_area As String
        Dim withdrawn_by As String
        Dim released_by As String
        Dim status As String
        Dim charges As String
        Dim ws_info_id As Integer
        Dim rs_id As Integer
        Dim po_no As String
        Dim wh_id As Integer
        Dim remarks As String
        Dim dr_option As String
        Dim purpose As String


    End Structure
    Public cListOfWithdrawal As New List(Of struc_wsList)
    Public Sub _initialize()
        trd = New Threading.Thread(AddressOf get_withdrawal_by_charges)
        trd.Start()
        trd.Join()
        done = True
    End Sub


    Private Sub get_withdrawal_by_charges()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(22) As String

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@ws_id", ws_id)
            newCMD.CommandTimeout = 300

            newDR = newCMD.ExecuteReader
            Dim wslist As New struc_wsList

            While newDR.Read
                With wslist


                    Dim ws_id As Integer = CInt(newDR.Item("WS_ID").ToString)
                    Dim rs_id As Integer = CInt(newDR.Item("rs_id").ToString)
                    Dim if_exist As Integer = check_if_exist("dbwithdrawn_items", "ws_id", ws_id, 1)
                    Dim rs_qty As Integer = CInt(newDR.Item("RS_QTY").ToString)
                    Dim status As String

                    If if_exist > 0 Then

                        Dim qty_withdrawn As Integer
                        qty_withdrawn = 0 'check_qty_withdrawn(ws_id)

                        If qty_withdrawn < rs_qty Then
                            status = "PARTIALLY WITHDRAWN"
                        Else
                            status = "WITHDRAWN"
                        End If
                    Else
                        status = "WITHDRAWAL RELEASED"
                    End If

                    .ws_id = ws_id
                    .ws_no = newDR.Item("WS_NO").ToString
                    .rs_no = newDR.Item("RS_NO").ToString

                    If newDR.Item("DATE_WITHDRAWN").ToString = "" Then
                        .date_withdrawn = Format(Date.Parse("1991-01-01"), "MM/dd/yyyy")
                    Else
                        .date_withdrawn = Format(Date.Parse(newDR.Item("DATE_WITHDRAWN").ToString), "MM/dd/yyyy")
                    End If

                    .item_name = newDR.Item("ITEM_NAME").ToString
                    .item_desc = newDR.Item("ITEM_DESC").ToString
                    .qty = newDR.Item("qty").ToString
                    .unit = newDR.Item("unit").ToString
                    .unit_price = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2, , TriState.True)
                    .amount = FormatNumber(CDbl(newDR.Item("amount").ToString), 2, , TriState.True)
                    .warehouse_area = FRequistionForm.get_wh_area(newDR.Item("wh_id").ToString)
                    .withdrawn_by = newDR.Item("WITHDRAWN_BY").ToString
                    .released_by = newDR.Item("RELEASED_BY").ToString
                    .status = status
                    .charges = newDR.Item("charges").ToString
                    .ws_info_id = IIf(newDR.Item("WS_INFO_ID").ToString = "", 0, newDR.Item("WS_INFO_ID").ToString)
                    .rs_id = rs_id
                    .wh_id = newDR.Item("wh_id").ToString
                    .remarks = newDR.Item("remarks").ToString
                    .dr_option = newDR.Item("dr_option").ToString
                    .purpose = newDR.Item("purpose").ToString

                    cListOfWithdrawal.Add(wslist)
                End With

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function check_qty_withdrawn(ws_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT b.qty FROM dbwithdrawn_items a INNER JOIN dbPO_details b ON a.rs_id = b.rs_id WHERE a.ws_id = " & ws_id
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                check_qty_withdrawn += newDR.Item("qty").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try



    End Function
End Class
