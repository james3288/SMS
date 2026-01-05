Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_charges

    Public trd, trd2 As Threading.Thread
    Public done As Boolean = False
    Public Property charges_desc As String
    Public Property division As String
    Public Property items As String
    Public Property bydate As String
    Public Property datefrom As DateTime
    Public Property dateto As DateTime


    Public cListOFCharges As New List(Of charges)
    Public cListOfWsCharges As New List(Of struc_ws_charges)
    Public cListOfTypeOfCharges As New List(Of Type_Of_Charges)
    Public cListOfChargesCategory As New List(Of Charges_Category)
    Public cListChargesCatName As New List(Of Charges_Category)
    Public cListOfChargesCatData As New List(Of Charges_Category_Data)
    'GET CHARGES CATEGORY DATA
    Public Sub get_charges_category_data(category As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        cListOfChargesCatData.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("sp_charges_to", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Select Case category
                Case "EQUIPMENT"
                    newCMD.Parameters.AddWithValue("@n", 2)
                Case "PROJECT"
                    newCMD.Parameters.AddWithValue("@n", 1)
                Case "WAREHOUSE"
                    newCMD.Parameters.AddWithValue("@n", 4)
                Case Else
                    newCMD.Parameters.AddWithValue("@n", 3)
                    newCMD.Parameters.AddWithValue("@type_name", category)
            End Select

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim ccatdata As New Charges_Category_Data

                Select Case category
                    Case "EQUIPMENT"
                        ccatdata.charges_cat_data = newDR.Item("plate_no").ToString
                    Case "PROJECT"
                        ccatdata.charges_cat_data = newDR.Item("project_desc").ToString
                    Case "WAREHOUSE"
                        ccatdata.charges_cat_data = newDR.Item("wh_area").ToString
                    Case Else
                        ccatdata.charges_cat_data = newDR.Item("charge_to").ToString
                End Select

                cListOfChargesCatData.Add(ccatdata)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    'GET ALL CHARGES NAME
    Public Sub get_charges_category_name()
        cListChargesCatName.Clear()
        trd2 = New Threading.Thread(AddressOf charges_cat_name)
        trd2.Start()
        trd2.Join()

    End Sub

    Private Sub charges_cat_name()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("sp_crud_Requisition_Non_Item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 13)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim cc As New Charges_Category

                cc.charges_cat = newDR.Item(0).ToString
                cListChargesCatName.Add(cc)

                'cmbox.Items.Add(newDR.Item(0).ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub get_charges_category()

        cListOfChargesCategory.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            publicquery = "select distinct a.[type_name] as charges_category from dbCharge_to a where a.[type_name] != '' order by a.[type_name] asc"
            newCMD = New SqlCommand(publicquery, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read

                Dim toc As New Charges_Category
                toc.charges_cat = newDR.Item("charges_category").ToString

                cListOfChargesCategory.Add(toc)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub get_type_of_charges()

        cListOfTypeOfCharges.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            publicquery = "SELECT * FROM dbType_of_charges ORDER BY type_of_charges ASC"
            newCMD = New SqlCommand(publicquery, newSQ.connection)
            newDR = newCMD.ExecuteReader
            While newDR.Read

                Dim toc As New Type_Of_Charges

                toc.type_of_req_id = newDR.Item("type_of_req_id").ToString
                toc.type_of_charges = newDR.Item("type_of_charges").ToString

                cListOfTypeOfCharges.Add(toc)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    Public Class Type_Of_Charges
        Public Property type_of_req_id As Integer
        Public Property type_of_charges As String

    End Class

    Public Class Charges_Category
        Public Property charges_cat As String
    End Class

    Public Class Charges_Category_Data
        Public Property charges_cat_data As String
    End Class

    Structure struc_ws_charges
        Dim rs_id As Integer
        Dim ws_no As String
        Dim charges As String
        Dim item_desc_from_rs As String
        Dim item_desc_from_warehouse As String
        Dim ws_date As DateTime
        Dim ws_id As Integer
        Dim inout As String

    End Structure
    Public Sub _initialize()

        trd = New Threading.Thread(AddressOf charges_data)
        trd.Start()
        trd.Join()

    End Sub

    Public Sub _initialize2()
        trd = New Threading.Thread(AddressOf ws_charges)
        trd.Start()
        trd.Join()

    End Sub

    Public Sub ws_charges()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", IIf(bydate = "BY DATE FROM THE BEGINNING", 4, 5))
            newCMD.Parameters.AddWithValue("@charges", charges_desc)
            newCMD.Parameters.AddWithValue("@item", items)
            newCMD.Parameters.AddWithValue("@datefrom", datefrom)
            newCMD.Parameters.AddWithValue("@dateto", dateto)
            newCMD.CommandTimeout = 200
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim c As New struc_ws_charges

                c.rs_id = newDR.Item("rs_id").ToString
                c.ws_date = IIf(newDR.Item("ws_date").ToString = "", Date.Parse("1990-01-01"), newDR.Item("ws_date").ToString)
                c.ws_no = newDR.Item("ws_no").ToString
                c.item_desc_from_rs = newDR.Item("item_desc_from_rs").ToString
                c.item_desc_from_warehouse = newDR.Item("item_name").ToString & " - " & newDR.Item("item_desc").ToString
                c.charges = newDR.Item("charges").ToString
                c.ws_id = newDR.Item("ws_id").ToString
                c.inout = newDR.Item("IN_OUT").ToString

                cListOfWsCharges.Add(c)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function search_item(item As String) As List(Of charges.rs)
        search_item = New List(Of charges.rs)

        For Each row In cListOFCharges
            row._initialize()

            If row.rs1.item_desc Is Nothing Then
            Else
                If (row.rs1.item_desc.ToUpper).Contains(item.ToUpper) Then
                    search_item.Add(row.rs1)
                End If
            End If
        Next

        Return search_item
    End Function

    Private Sub charges_data()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_withdrawal_new2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@charges", charges_desc)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim c As New charges
                c.charges_id = newDR.Item("charges_id").ToString
                c.charges = newDR.Item("charges").ToString
                c.type = newDR.Item("charges_type").ToString
                c.rs_id = newDR.Item("rs_id").ToString
                c.division = division

                cListOFCharges.Add(c)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Class charges
        Public Property charges_id As Integer
        Public Property charges As String
        Public Property type As String
        Public Property rs_id As Integer
        Public Property rs1 As New rs
        Public Property division As String

        Public trd As Threading.Thread

        Public Sub _initialize()
            trd = New Threading.Thread(AddressOf rs_data)
            trd.Start()
            trd.Join()

        End Sub

        Private Sub rs_data()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_withdrawal_new2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 2)
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                newCMD.Parameters.AddWithValue("@division", division)
                newDR = newCMD.ExecuteReader

                While newDR.Read

                    rs1.rs_id = newDR.Item("rs_id").ToString
                    rs1.item_desc = newDR.Item("item_desc").ToString
                    rs1.inout = newDR.Item("IN_OUT").ToString
                    rs1.rs_no = newDR.Item("rs_no").ToString
                    rs1.charges = charges

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub
        Public Class rs
            Public trd As Threading.Thread
            Public Property rs_id As Integer
            Public Property item_desc As String
            Public Property inout As String
            Public Property rs_no As String

            Public Property charges As String

            Public cListOfWs As New List(Of ws)
            Public Sub _initialize()
                cListOfWs.Clear()
                trd = New Threading.Thread(AddressOf ws_data)
                trd.Start()
                trd.Join()
            End Sub
            Private Sub ws_data()
                Dim newSQ As New SQLcon
                Dim newCMD As SqlCommand
                Dim newDR As SqlDataReader

                Try
                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_withdrawal_new2", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    newCMD.Parameters.AddWithValue("@n", 3)
                    newCMD.Parameters.AddWithValue("@rs_id", rs_id)

                    newDR = newCMD.ExecuteReader

                    While newDR.Read
                        Dim ws1 As New ws

                        ws1.ws_no = newDR.Item("ws_no").ToString
                        ws1.ws_date = newDR.Item("ws_date").ToString

                        cListOfWs.Add(ws1)

                    End While

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()
                End Try
            End Sub
            Public Class ws
                Public Property ws_date As DateTime
                Public Property ws_no As String

            End Class
        End Class


    End Class

End Class
