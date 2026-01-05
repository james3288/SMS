Imports System.Data.SqlClient

Public Class Model

#Region "ALL ABOUT OPERATOR/DRIVER DATA"
    Public Class _Mod_Driver
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
#Region "DELEGATES"
        Private Delegate Function ListOfDriverDelegates() As List(Of driver)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function if_exist(Optional driver As String = "") As Integer

            'ADD PARAMETER TO DICTIONARY
            parameter("@n", 1)
            parameter("@where", $"where a.operator_name = '{driver}'")


            For Each row In LISTOFDRIVER()
                if_exist = row.driver_id
            Next

            Return if_exist

        End Function
        Public Function LISTOFDRIVER(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of driver)
            'cDict = dict
            Dim DriverDataInstance As ListOfDriverDelegates = AddressOf _get_driver

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = DriverDataInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFDRIVER = DriverDataInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_driver() As List(Of driver)
            _get_driver = New List(Of driver)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_model_query", SQ.connection)

                While reader.Read
                    Dim _driver As New driver
                    With _driver
                        .driver_id = reader.Item("operator_id").ToString
                        .driver_name = reader.Item("operator_name").ToString
                        .position = reader.Item("position").ToString

                        _get_driver.Add(_driver)
                    End With

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
#End Region
#Region "FIELDS"
        Class driver
            Public Property driver_id As Integer
            Public Property driver_name As String
            Public Property position As String

        End Class
#End Region

    End Class
#End Region

#Region "ALL ABOUT EQUIPMENTS DATA"
    Public Class _Mod_Equipment
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
#Region "DELEGATES"
        Private Delegate Function ListOfEquipMentDelegates() As List(Of Equipment)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function if_exist(Optional plateno As String = "") As Integer

            parameter("@n", 2)
            parameter("@where", $"where a.plate_no =  '{plateno}'")

            For Each row In LISTOFEQUIPMENT()
                if_exist = row.equipListID
            Next

            Return if_exist
        End Function
        Public Function LISTOFEQUIPMENT(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of Equipment)
            'cDict = dict
            Dim DriverDataInstance As ListOfEquipMentDelegates = AddressOf _get_Equipment

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = DriverDataInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFEQUIPMENT = DriverDataInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_Equipment() As List(Of Equipment)
            _get_Equipment = New List(Of Equipment)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_model_query", SQ.connection)

                While reader.Read
                    Dim _equipment As New Equipment
                    With _equipment
                        .equipListID = reader.Item("equipListID").ToString
                        .Equip_Type = reader.Item("equip_type").ToString
                        .PlateNo = reader.Item("plate_no").ToString

                        _get_Equipment.Add(_equipment)
                    End With

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
#End Region
#Region "FIELDS"
        Class Equipment
            Public Property equipListID As Integer
            Public Property Equip_Type As String
            Public Property PlateNo As String

        End Class
#End Region

    End Class
#End Region

#Region "ALL ABOUT SUPPLIER DATA"
    Public Class _Mod_Supplier
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)

#Region "DELEGATES"
        Private Delegate Function ListOfSupplierDelegates() As List(Of Supplier)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function if_exist(Optional suppliername As String = "") As Integer

            parameter("@n", 3)
            parameter("@where", $"where a.Supplier_Name = '{suppliername}'")

            For Each row In LISTOFSUPPLIER()
                if_exist = row.supplier_id
            Next

            Return if_exist
        End Function
        Public Function LISTOFSUPPLIER(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of Supplier)
            'cDict = dict
            Dim SupplierDataInstance As ListOfSupplierDelegates = AddressOf _get_Supplier

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = SupplierDataInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFSUPPLIER = SupplierDataInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_Supplier() As List(Of Supplier)
            _get_Supplier = New List(Of Supplier)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_model_query", SQ.connection)

                While reader.Read
                    Dim _supplier As New Supplier
                    With _supplier
                        .supplier_id = reader.Item("Supplier_Id").ToString
                        .supplier_name = reader.Item("Supplier_Name").ToString
                        .supplier_location = reader.Item("Supplier_Location").ToString
                        .terms = reader.Item("terms").ToString

                        _get_Supplier.Add(_supplier)
                    End With

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
#End Region
#Region "FIELDS"
        Class Supplier
            Public Property supplier_id As Integer
            Public Property supplier_name As String
            Public Property supplier_location As String
            Public Property terms As String

        End Class
#End Region

    End Class

#End Region

#Region "ALL ABOUT DELIVERY RECEIPT(DR) DATA"
    Public Class _Mod_DR
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
#Region "DELEGATES"
        Private Delegate Function ListOfDRDelegates() As List(Of drdata)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function if_exist(Optional dr_no As String = "") As Integer

            parameter("@n", 4)
            parameter("@where", $"where a.dr_no = '{dr_no}'")

            For Each row In LISTOFDR()
                if_exist = row.dr_items_id
            Next

            Return if_exist
        End Function
        Public Function LISTOFDR(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of drdata)
            'cDict = dict
            Dim DRDataInstance As ListOfDRDelegates = AddressOf _get_DR

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
            LISTOFDR = DRDataInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_DR() As List(Of drdata)
            _get_DR = New List(Of drdata)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_model_query", SQ.connection)

                While reader.Read
                    Dim _dr As New drdata
                    With _dr

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

                        _get_DR.Add(_dr)
                    End With

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
        Private Function datechecker(d As String)
            If IsDate(d) Then
                Return Date.Parse(d)
            Else
                Return Date.Parse("1990-01-01")
            End If

        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub


#End Region
#Region "FIELDS"
        Class drdata
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
#End Region

    End Class
#End Region

#Region "ALL ABOUT USER ACCESS"
    Public Class _Mod_User_Access
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
#Region "DELEGATES"
        Private Delegate Function ListOfUserAccessDelegates() As List(Of user_access_desc)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFUSERACCESS(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of user_access_desc)
            'cDict = dict
            Dim UserAccessInstance As ListOfUserAccessDelegates = AddressOf _get_user_access

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = UserAccessInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFUSERACCESS = UserAccessInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_user_access() As List(Of user_access_desc)
            _get_user_access = New List(Of user_access_desc)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_user_access", SQ.connection)

                While reader.Read
                    Dim _useraccess As New user_access_desc
                    With _useraccess
                        .access_desc_id = reader.Item("access_desc_id").ToString
                        .access_desc = reader.Item("access_desc").ToString
                        .access_no = reader.Item("access_no").ToString

                        _get_user_access.Add(_useraccess)
                    End With

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class user_access_desc
            Public Property access_desc_id As Integer
            Public Property access_desc As String
            Public Property access_no As Integer

        End Class
#End Region

    End Class
#End Region

#Region "ALL ABOUT CHARGES"
    Public Class _Mod_Charges
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)

#Region "DELEGATES"
        Private Delegate Function ListOfChargesAccessDelegates() As List(Of charges_info)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFCHARGES(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of charges_info)
            'cDict = dict
            Dim ChargesInstance As ListOfChargesAccessDelegates = AddressOf _get_charges

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = ChargesInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFCHARGES = ChargesInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_charges() As List(Of charges_info)
            _get_charges = New List(Of charges_info)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_Delivery_Receipt4", SQ.connection)

                While reader.Read
                    Dim _chargesInfo As New charges_info
                    With _chargesInfo
                        .charges_id = reader.Item("id").ToString
                        .charges_desc = reader.Item("charges").ToString
                        .category = reader.Item("type_of_charges").ToString

                        _get_charges.Add(_chargesInfo)
                    End With

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETERS"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class charges_info
            Public Property charges_id As Integer
            Public Property charges_desc As String
            Public Property category As String

        End Class

#End Region

    End Class
#End Region

#Region "ALL ABOUT PURCHASE ORDER"
    Public Class _Mod_Purchase_Order
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String
        Private customMsg As New customMessageBox
#Region "DELEGATES"
        Private Delegate Function ListOfPurchaseOrderDelegates() As List(Of Purchase_Order_Field)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFPURCHASEORDER(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of Purchase_Order_Field)
            'cDict = dict
            Dim PurchaseOrderInstance As ListOfPurchaseOrderDelegates = AddressOf _get_purchase_order

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = PurchaseOrderInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFPURCHASEORDER = PurchaseOrderInstance.EndInvoke(asyncResult)
        End Function

        Public Function LISTOFPURCHASEORDER_RECEIVING(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of Purchase_Order_Field)
            'cDict = dict
            Dim PurchaseOrderInstance As ListOfPurchaseOrderDelegates = AddressOf _get_purchase_order_receiving

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = PurchaseOrderInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFPURCHASEORDER_RECEIVING = PurchaseOrderInstance.EndInvoke(asyncResult)
        End Function

        Private Function _get_purchase_order() As List(Of Purchase_Order_Field)
            _get_purchase_order = New List(Of Purchase_Order_Field)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection, 600)

                While reader.Read
                    Dim _purchase_order As New Purchase_Order_Field

                    With _purchase_order
                        .po_id = Utilities.ifBlankReplaceToZero(reader.Item("po_id").ToString)
                        .po_det_id = IIf(reader.Item("po_det_id").ToString = "", 0, reader.Item("po_det_id").ToString)
                        .po_no = reader.Item("po_no").ToString
                        .rs_no = reader.Item("rs_no").ToString
                        .po_date = IIf(reader.Item("po_date").ToString = "", "1990-01-01", reader.Item("po_date").ToString)
                        .Supplier_Name = reader.Item("Supplier_Name").ToString
                        .Item_Name = reader.Item("Item_Name").ToString
                        .Item_Desc = reader.Item("Item_desc").ToString
                        .qty = reader.Item("qty").ToString
                        .unit = reader.Item("unit").ToString
                        .unit_price = IIf(reader.Item("unit_price").ToString = "", 0, reader.Item("unit_price").ToString)
                        .total_amount = IIf(reader.Item("total_amount").ToString = "", 0, reader.Item("total_amount").ToString)
                        .instructions = reader.Item("instructions").ToString
                        .address = reader.Item("address").ToString
                        .terms = reader.Item("terms").ToString
                        .charges = reader.Item("charges").ToString
                        .date_needed = IIf(reader.Item("date_needed").ToString = "", "1990-01-01", reader.Item("date_needed").ToString)
                        .prepared_by = reader.Item("prepared_by").ToString
                        .checked_by = reader.Item("checked_by").ToString
                        .approved_by = reader.Item("approved_by").ToString
                        .rs_id = IIf(reader.Item("rs_id").ToString = "", 0, reader.Item("rs_id").ToString)
                        .selected = reader.Item("selected").ToString
                        .inout = reader.Item("IN_OUT").ToString
                        .print_stats = reader.Item("print_stats").ToString
                        .orig_date_printed = IIf(reader.Item("print_date_logss").ToString = "", "1990-01-01", reader.Item("print_date_logss").ToString)
                        .updated_date_printed = IIf(reader.Item("print_date_update").ToString = "", "1990-01-01", reader.Item("print_date_update").ToString)
                        .user_logs = reader.Item("userss").ToString
                        .lead_time_rs_to_po = IIf(reader.Item("lead_time_rs_to_po").ToString = "", 0, reader.Item("lead_time_rs_to_po").ToString)
                        .rs_date = IIf(reader.Item("date_req").ToString = "", "1990-01-01", reader.Item("date_req").ToString)                        'DATE_REQ TO RS DATE FROM STORED BY MAKI
                        .type_of_request = reader.Item("type_of_request").ToString 'new added column (02/05/24) - king
                        .user_update_log = reader.Item("user_update_log").ToString
                        .requestor = reader.Item("requestor").ToString
                        .cancel_po = IIf(reader.Item("cancel_status").ToString = "", 0, reader.Item("cancel_status").ToString)
                        .wh_pn_id = Utilities.ifBlankReplaceToZero(reader.Item("wh_pn_id").ToString)
                        .properName = getProperName(.wh_pn_id)
                        .tax_category = reader.Item(NameOf(.tax_category)).ToString
                        .vat_value = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.vat_value)).ToString)
                        .remarks = reader.Item(NameOf(.remarks)).ToString
                        .po_ws_user_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.po_ws_user_id)).ToString)

                        'new added column (1/12/24)

                        _get_purchase_order.Add(_purchase_order)

                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function

        Private Function _get_purchase_order_receiving() As List(Of Purchase_Order_Field)
            _get_purchase_order_receiving = New List(Of Purchase_Order_Field)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection)

                While reader.Read
                    Dim _purchase_order As New Purchase_Order_Field

                    With _purchase_order

                        .po_det_id = IIf(reader.Item("po_det_id").ToString = "", 0, reader.Item("po_det_id").ToString)
                        .po_no = reader.Item("po_cv_no").ToString
                        .rs_no = reader.Item("rs_no").ToString
                        .po_date = IIf(reader.Item("po_date").ToString = "", "1990-01-01", reader.Item("po_date").ToString)
                        .Supplier_Name = reader.Item("supplier").ToString
                        .Item_Name = reader.Item("item_name").ToString
                        .Item_Desc = reader.Item("item_desc").ToString
                        .qty = reader.Item("po_qty").ToString
                        .unit = reader.Item("unit").ToString
                        .charges = reader.Item("CHARGES").ToString
                        .wh_id = IIf(reader.Item("wh_id").ToString = "", 0, reader.Item("wh_id").ToString)
                        .inout = reader.Item("IN_OUT").ToString
                        .rs_purpose = reader.Item("rs_purpose").ToString
                        .remarks = reader.Item("remarks").ToString
                        .rs_date = IIf(reader.Item("rs_date").ToString = "", Date.Parse("1990-01-01"), reader.Item("rs_date").ToString)

                        _get_purchase_order_receiving.Add(_purchase_order)

                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class Purchase_Order_Field
            Public Property po_det_id As Integer
            Public Property po_no As String
            Public Property rs_no As String
            Public Property po_date As DateTime
            Public Property Supplier_Name As String
            Public Property Item_Name As String
            Public Property Item_Desc As String
            Public Property qty As Double
            Public Property unit As String
            Public Property unit_price As Double
            Public Property total_amount As Double
            Public Property instructions As String
            Public Property address As String
            Public Property terms As String
            Public Property rs_id As Integer
            Public Property charges As String
            Public Property date_needed As DateTime
            Public Property prepared_by As String
            Public Property checked_by As String
            Public Property approved_by As String
            Public Property selected As String
            Public Property po_id As String
            Public Property inout As String
            Public Property lead_time_rs_to_po As Double
            Public Property print_stats As String
            Public Property orig_date_printed As DateTime
            Public Property updated_date_printed As DateTime
            Public Property user_logs As String
            Public Property rs_date As DateTime
            Public Property type_of_request As String

            Public Property rs_purpose As String
            Public Property wh_id As Integer
            Public Property remarks As String
            Public Property requestor As String
            Public Property user_update_log As String
            Public Property cancel_po As Integer
            Public Property wh_pn_id As Integer
            Public Property properName As String
            Public Property tax_category As String
            Public Property vat_value As Double
            Public Property po_ws_user_id As Integer

        End Class
#End Region
#Region "GET"
        Private Function getProperName(wh_pn_id As Integer) As String
            Try
                Dim properName = Results.cListOfProperNaming.FirstOrDefault(Function(x) x.wh_pn_id = wh_pn_id)

                If properName IsNot Nothing Then
                    Return $"{ properName?.item_name } - {properName?.item_desc}"
                End If

            Catch ex As Exception
                customMsg.ErrorMessage(ex)
            End Try
        End Function
#End Region
    End Class


#End Region

#Region "ALL ABOUT WITHDRAWAL"
    Public Class _Mod_Withdrawal
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String
#Region "DELEGATES"
        Private Delegate Function ListOfWithdrawalDelegates() As List(Of Withdrawal_Fields)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFWITHDRAWAL(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of Withdrawal_Fields)
            'cDict = dict
            Dim WithdrawalInstance As ListOfWithdrawalDelegates = AddressOf _get_withdrawal

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = WithdrawalInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFWITHDRAWAL = WithdrawalInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_withdrawal() As List(Of Withdrawal_Fields)
            _get_withdrawal = New List(Of Withdrawal_Fields)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection)

                While reader.Read
                    Dim _withdrawal As New Withdrawal_Fields

                    With _withdrawal

                        .ws_id = reader.Item("ws_id").ToString
                        .ws_no = reader.Item("ws_no").ToString
                        .rs_no = reader.Item("rs_no").ToString
                        .ws_date = reader.Item("ws_date").ToString
                        .item_name = reader.Item("item_name").ToString
                        .item_desc = reader.Item("item_desc").ToString
                        .rs_qty = reader.Item("rs_qty").ToString
                        .ws_qty = reader.Item("ws_qty").ToString
                        .qty_withdrawn = IIf(reader.Item("qty_withdrawn").ToString = "", 0, reader.Item("qty_withdrawn").ToString)
                        .unit = reader.Item("unit").ToString
                        .unit_price = reader.Item("unit_price").ToString
                        .amount = reader.Item("amount").ToString
                        .withdrawn_from = reader.Item("withdrawn_from").ToString
                        .withdrawn_by = reader.Item("withdrawn_by").ToString
                        .released_by = reader.Item("released_by").ToString
                        .charges = reader.Item("charges").ToString
                        .ws_info_id = reader.Item("ws_info_id").ToString
                        .rs_id = reader.Item("rs_id").ToString
                        .wh_id = reader.Item("wh_id").ToString
                        .remarks = reader.Item("remarks").ToString
                        .dr_option = reader.Item("dr_option").ToString
                        .purpose = reader.Item("purpose").ToString
                        .withdrawn_id = IIf(reader.Item("withdrawn_id").ToString = "", 0, reader.Item("withdrawn_id").ToString)
                        .status = reader.Item("stat").ToString
                        .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)
                        .issued_by = reader.Item(NameOf(.issued_by)).ToString
                        .date_needed = reader.Item(NameOf(.date_needed)).ToString

                        _get_withdrawal.Add(_withdrawal)

                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class Withdrawal_Fields
            Public Property ws_id As Integer
            Public Property ws_no As String
            Public Property rs_no As String
            Public Property ws_date As DateTime
            Public Property item_name As String
            Public Property item_desc As String
            Public Property rs_qty As Double
            Public Property ws_qty As Double
            Public Property qty_withdrawn As Double
            Public Property unit As String
            Public Property unit_price As Double
            Public Property amount As Double
            Public Property withdrawn_by As String
            Public Property withdrawn_from As String
            Public Property released_by As String
            Public Property charges As String
            Public Property ws_info_id As Integer
            Public Property rs_id As Integer
            Public Property wh_id As Integer
            Public Property remarks As String
            Public Property dr_option As String
            Public Property purpose As String
            Public Property withdrawn_id As Integer
            Public Property status As String
            Public Property wh_pn_id As Integer
            Public Property issued_by As String
            Public Property date_needed As DateTime
        End Class
#End Region

    End Class

#End Region

#Region "ALL ABOUT CHARGES CATEGORY"
    Public Class _Mod_Charges_Category
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String
#Region "DELEGATES"
        Private Delegate Function ListOfChargesCategoryDelegates() As List(Of Charges_Category_Fields)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFCHARGESCATEGORY(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of Charges_Category_Fields)
            'cDict = dict
            Dim ChargesCategoryInstance As ListOfChargesCategoryDelegates = AddressOf _get_charges_category

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = ChargesCategoryInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFCHARGESCATEGORY = ChargesCategoryInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_charges_category() As List(Of Charges_Category_Fields)
            _get_charges_category = New List(Of Charges_Category_Fields)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection)

                While reader.Read
                    Dim _charges_category As New Charges_Category_Fields

                    With _charges_category

                        .charge_cat_id = reader.Item("charge_cat_id").ToString
                        .charges_category_name = reader.Item("Charge_cat_name").ToString
                        .date_time_created = IIf(IsDate(reader.Item("date_time_created").ToString), Date.Parse(reader.Item("date_time_updated").ToString), Date.Parse("1990-01-01"))
                        .date_time_updated = IIf(IsDate(reader.Item("date_time_updated").ToString), Date.Parse(reader.Item("date_time_updated").ToString), Date.Parse("1990-01-01"))
                        _get_charges_category.Add(_charges_category)

                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function

#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class Charges_Category_Fields
            Public Property charge_cat_id As Integer
            Public Property charges_category_name As String
            Public Property date_time_created As DateTime
            Public Property date_time_updated As DateTime

        End Class
#End Region

    End Class
#End Region

#Region "ALL ABOUT WAREHOUSE ITEM"
    Public Class _Mod_Warehouse_Item

        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String

#Region "DELEGATES"
        Private Delegate Function ListOfWarehouseItemDelegates() As List(Of Warehouse_Item_Fields)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFWAREHOUSEITEM(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of Warehouse_Item_Fields)
            'cDict = dict
            Dim WarehouseItemInstance As ListOfWarehouseItemDelegates = AddressOf _get_warehouse_item

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = WarehouseItemInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFWAREHOUSEITEM = WarehouseItemInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_warehouse_item() As List(Of Warehouse_Item_Fields)
            _get_warehouse_item = New List(Of Warehouse_Item_Fields)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection)

                'example:
                'stored procedure: proc_get_data_from_warehouse
                '@n = 114

                While reader.Read
                    Dim _warehouse_item As New Warehouse_Item_Fields

                    With _warehouse_item

                        .wh_id = reader.Item("wh_id").ToString
                        .item_name = reader.Item("whItem").ToString
                        .item_desc = reader.Item("whItemDesc").ToString
                        .classification = reader.Item("whClass").ToString
                        .type_of_item = reader.Item("tor_desc").ToString & " - " & reader.Item("tor_sub_desc").ToString
                        .warehouse_area = reader.Item("wh_area").ToString
                        .specific_loc = reader.Item("whSpecificLoc").ToString
                        .incharge = reader.Item("wh_incharge").ToString
                        .reorder_point = reader.Item("whReorderPoint").ToString
                        .default_price = reader.Item("default_price").ToString
                        .unit = reader.Item("unit").ToString
                        .inout = reader.Item("in_out_desc").ToString
                        .set_det_id = IIf(reader.Item("set_det_id").ToString = "", 0, reader.Item("set_det_id").ToString)
                        .division = reader.Item("division").ToString
                        .Turnover = reader.Item("turnover").ToString
                        .incharge_id = IIf(reader.Item("incharge_id").ToString = "", 0, reader.Item("incharge_id").ToString)
                        .disable = IIf(reader.Item("disable_item").ToString = "", 0, reader.Item("disable_item").ToString)
                        .proper_item_name = reader.Item("proper_item_name").ToString
                        .proper_item_desc = reader.Item("proper_item_desc").ToString

                        _get_warehouse_item.Add(_warehouse_item)

                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function

#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class Warehouse_Item_Fields
            Public Property wh_id As Integer
            Public Property item_name As String
            Public Property item_desc As String
            Public Property classification As String
            Public Property type_of_item As String
            Public Property warehouse_area As String
            Public Property specific_loc As String
            Public Property incharge As String
            Public Property reorder_point As Integer
            Public Property default_price As Double
            Public Property unit As String
            Public Property set_det_id As Integer
            Public Property division As String
            Public Property Turnover As String
            Public Property inout As String
            Public Property incharge_id As Integer
            Public Property disable As Integer
            Public Property proper_item_name As String
            Public Property proper_item_desc As String
            Public Property wh_pn_id As Integer



        End Class
#End Region
    End Class

#End Region

#Region "ALL ABOUT INCHARGE"
    Public Class _Mod_Incharge
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String
#Region "DELEGATES"
        Private Delegate Function ListOfInchargeDelegates() As List(Of incharge_field)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFINCHARGE(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of incharge_field)
            'cDict = dict
            Dim InchargeInstance As ListOfInchargeDelegates = AddressOf _get_incharge

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = InchargeInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFINCHARGE = InchargeInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_incharge() As List(Of incharge_field)
            _get_incharge = New List(Of incharge_field)

            Dim SelectQuery As New Model_Dynamic_Select

            SelectQuery._initialize("db_wh_incharge",
                                    $"fname Like '%' + '{""}'",
                                    "incharge_id,fname,lname")

            Dim data = SelectQuery.getList()

            _get_incharge.AddRange(data.Select(Function(x) New incharge_field With {
                                                     .incharge_id = x("incharge_id").ToString(),
                                                     .firstname = x("fname").ToString(),
                                                     .lastname = x("lname").ToString()
                                                   }))

        End Function

#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class incharge_field
            Public Property incharge_id As Integer
            Public Property firstname As String
            Public Property lastname As String


        End Class
#End Region

    End Class
#End Region

#Region "ALL ABOUT RS"
    Public Class _Mod_RS
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String
        Public cRequestTimeOut As Integer
        Public cSearchBy As Integer = 0

        Public Enum searchByEnum
            default_only = 0
            rs_id_but_price_col_only = 1

        End Enum

#Region "DELEGATES"
        Private Delegate Function ListOfRsDelegates() As List(Of rs_fields)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFRS(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of rs_fields)
            'cDict = dict
            Dim RsInstance As ListOfRsDelegates = AddressOf _get_rs

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = RsInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFRS = RsInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_rs() As List(Of rs_fields)
            _get_rs = New List(Of rs_fields)
            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection, cRequestTimeOut)

                While reader.Read
                    Dim _rs As New rs_fields

                    With _rs

                        If cSearchBy = searchByEnum.default_only Then
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

                        ElseIf cSearchBy = searchByEnum.rs_id_but_price_col_only Then

                            .amount = IIf(reader.Item("amount").ToString = "", 0, reader.Item("amount").ToString)
                            .rs_id = reader.Item("rs_id").ToString

                        End If


                        _get_rs.Add(_rs)
                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
        Private Function datechecker(d As String)
            If IsDate(d) Then
                Return Date.Parse(d)
            Else
                Return Date.Parse("1990-01-01")
            End If

        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Public Class rs_fields
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

            Public Property amount As String


        End Class
#End Region

    End Class
#End Region

#Region "ALL ABOUT RR"
    Public Class _Mod_RR
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String
        Public cSearchBy As Integer = 0

        Public Enum searchByEnum
            default_only = 0
            rs_id_but_price_col_only = 1

        End Enum

#Region "DELEGATES"
        Private Delegate Function ListOfRRDelegates() As List(Of rr_fields)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFRR(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of rr_fields)
            'cDict = dict
            Dim RrInstance As ListOfRRDelegates = AddressOf _get_rr

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = RrInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==


            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFRR = RrInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_rr() As List(Of rr_fields)
            _get_rr = New List(Of rr_fields)
            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection)

                While reader.Read
                    Dim _rr As New rr_fields

                    With _rr

                        If cSearchBy = searchByEnum.default_only Then
                            .rr_item_id = reader.Item("rr_item_id").ToString
                            .rr_info_id = reader.Item("rr_info_id").ToString
                            .rs_id = IIf(reader.Item("rs_id").ToString = "", 0, reader.Item("rs_id").ToString)
                            .rr_no = reader.Item("rr_no").ToString
                            .po_det_id = IIf(reader.Item("po_det_id").ToString = "", 0, reader.Item("po_det_id").ToString)
                            .rs_no = reader.Item("rs_no").ToString
                            .invoice_no = reader.Item("invoice_no").ToString
                            .supplier = reader.Item("supplier").ToString
                            .date_received = Date.Parse(reader.Item("date_received").ToString)
                            .rr_qty = reader.Item("rr_qty").ToString
                            .price = reader.Item("price").ToString
                            .item_desc = reader.Item("item_description").ToString
                            .remarks = reader.Item("remarks").ToString
                            .wh_id = IIf(reader.Item("wh_id").ToString = "", 0, reader.Item("wh_id").ToString)
                            .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                            .checked_by = reader.Item("checked_by").ToString
                            .received_by = reader.Item("received_by").ToString
                            .unit = reader.Item("unit").ToString
                            .status = "received"
                            .date_submitted = IIf(reader.Item("date_submitted").ToString = "", Date.Parse("1990-01-01"), reader.Item("date_submitted").ToString)
                            .rs_date = IIf(reader.Item("rs_date").ToString = "", Date.Parse("1990-01-01"), reader.Item("rs_date").ToString)

                        ElseIf cSearchBy = searchByEnum.rs_id_but_price_col_only Then

                            .price = IIf(reader.Item("price").ToString = "", 0, reader.Item("price").ToString)
                            .rs_price = IIf(reader.Item("rs_price").ToString = "", 0, reader.Item("rs_price").ToString)
                            .rs_id = IIf(reader.Item("rs_id").ToString = "", 0, reader.Item("rs_id").ToString)
                            .type_of_purchasing = reader.Item("type_of_purchasing").ToString

                        End If

                        _get_rr.Add(_rr)
                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function

        Private Function _get_rr_but_price_only() As List(Of rr_fields)
            _get_rr_but_price_only = New List(Of rr_fields)
            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection)

                While reader.Read
                    Dim _rr As New rr_fields

                    With _rr

                        .rs_id = IIf(reader.Item("rs_id").ToString = "", 0, reader.Item("rs_id").ToString)
                        .price = reader.Item("price").ToString

                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function

        Private Function datechecker(d As String)
            If IsDate(d) Then
                Return Date.Parse(d)
            Else
                Return Date.Parse("1990-01-01")
            End If

        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Public Class rr_fields
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
            Public Property rs_price As String
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

            Public Property rs_date As DateTime

        End Class
#End Region

    End Class
#End Region

#Region "ALL ABOUT AGGREGATES REMAINING BALANCE"
    Public Class _Mod_StockCardAggregates
        Public dr_qty_using_wsno As Double
        Public supplier_recepient As String
        Private cDict As New Dictionary(Of String, Object)

#Region "PARAMETERS"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "DELEGATES"
        Private Delegate Function getAggregatesBalanceDelegate() As List(Of agg_data)
        Private Delegate Function getAggBalanceDelegate() As Double
#End Region
#Region "INTERFACE"
        Public Class agg_data
            Property drdate As DateTime
            Property rs_no As String
            Property drno_invoice As String
            Property rr_no As String
            Property ws_no As String
            Property supp_recipient As String
            Property qty_in As String
            Property qty_out As String
            Property balance As Double
            Property remarks As String
            Property sorting As String
            Property type_of_purchasing As String
            Property inout As String
            Property type_of_delivery As String
            Property stat As String

        End Class

#End Region

#Region "FUNCTIONS"
        Public Function LISTOFAGGREGATESSTOCKCARD() As List(Of agg_data)

            'INITIALIZING DATA HERE

            Dim getDataInstance As getAggregatesBalanceDelegate = Nothing
            getDataInstance = AddressOf _get_aggregatesStockCard

            Dim asyncResult As IAsyncResult = getDataInstance.BeginInvoke(Nothing, Nothing)

            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            LISTOFAGGREGATESSTOCKCARD = getDataInstance.EndInvoke(asyncResult)

        End Function

        Public Function AGGREGATESBALANCE() As Double
            'INITIALIZING DATA HERE

            Dim getDataInstance As getAggBalanceDelegate = Nothing
            getDataInstance = AddressOf _get_prev_balance

            Dim asyncResult As IAsyncResult = getDataInstance.BeginInvoke(Nothing, Nothing)

            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            AGGREGATESBALANCE = getDataInstance.EndInvoke(asyncResult)
        End Function

        Private Function _get_aggregatesStockCard() As List(Of agg_data)
            _get_aggregatesStockCard = New List(Of agg_data)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query
                Dim rowcount As Integer = 0

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_execute_tempstockcard2", SQ.connection)

                While reader.Read
                    Dim ws_no As String = reader.Item("WS_NO").ToString
                    Dim rs_no As String = reader.Item("rs_no").ToString

                    Dim newSc As New agg_data
                    With newSc

                        If reader.Item("WITHDRAWN").ToString = "NO" Then
                            GoTo proceedhere
                        End If

                        If reader.Item("stat").ToString = "" And reader.Item("dr_no").ToString = "" Then
                            GoTo proceedhere

                        ElseIf reader.Item("stat").ToString = "" And reader.Item("dr_no").ToString <> "" Then
                            .drno_invoice = reader.Item("dr_no").ToString
                            .rr_no = "N/A"
                            .ws_no = "N/A"
                        End If

                        .drdate = Format(Date.Parse(reader.Item("date").ToString), "MM/dd/yyyy")
                        .rs_no = reader.Item("rs_no").ToString

                        Dim stat As String = reader.Item("stat").ToString

                        .drno_invoice = reader.Item("dr_no").ToString.ToUpper
                        .ws_no = reader.Item("WS_NO").ToString.ToUpper
                        '.rr_no = IIf(reader.Item("RR_NO").ToString.ToUpper = "", "N/A", reader.Item("RR_NO").ToString.ToUpper)
                        .rr_no = reader.Item("RR_NO").ToString

                        .sorting = reader.Item("SORTING").ToString
                        .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                        .inout = reader.Item("IN_OUT").ToString
                        .type_of_delivery = reader.Item("type_of_delivery").ToString
                        .stat = reader.Item("stat").ToString

                        If reader.Item("IN_OUT").ToString = "OUT" Then
                            .supp_recipient = reader.Item("SOURCE_WH").ToString

                            If reader.Item("SORTING").ToString = "A" Then
                                .qty_in = 0

                                '_rs_no = .rs_no
                                '_ws_no = .ws_no

                                'count_qty_dr_using_ws_no()
                                '--COUNT DR QTY USING WSNO------------------------------
                                Dim tr4 As Threading.Thread
                                Dim dr_qty_using_wsno_dict As New Dictionary(Of String, String)

                                dr_qty_using_wsno_dict.Add("_rs_no", .rs_no)
                                dr_qty_using_wsno_dict.Add("_ws_no", .ws_no)

                                tr4 = New Threading.Thread(AddressOf get_qty_using_wsno)
                                tr4.Start(dr_qty_using_wsno_dict)
                                tr4.Join()
                                '-------------------------------------------------------

                                Dim count_qty_dr As Double = dr_qty_using_wsno
                                .qty_out = CDbl(reader.Item("qty_OUT").ToString) - count_qty_dr

                                If count_qty_dr = 0 Then
                                    .qty_out = CDbl(reader.Item("qty_OUT").ToString)
                                Else
                                    .qty_out = count_qty_dr & "/" & CDbl(reader.Item("qty_OUT").ToString)
                                End If

                                'RS->WS->NO DR (OUT)
                                If .stat = "OUT WITH RS AND WS BUT NO DR" And .drno_invoice = "" Then
                                    .drno_invoice = "N/A"
                                End If

                            ElseIf reader.Item("SORTING").ToString = "B" Then

                                If .stat = "" And .drno_invoice = "N/A" Then 'NO RS->NO DR (create transaction from items -> OUT)
                                    .supp_recipient = reader.Item("agg_supplier").ToString
                                ElseIf .stat = "" And .drno_invoice <> "N/A" Then
                                    .supp_recipient = reader.Item("agg_supplier").ToString
                                End If

                                .qty_in = 0
                                .qty_out = reader.Item("qty_OUT").ToString

                            End If

                            'THIS CODE IS FOR RS->PO->RR->DR IN
                        ElseIf reader.Item("IN_OUT").ToString = "IN" Then
                            If reader.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then 'RS->PO->RR->DR
                                'supplier_recepient()

                                '------GET SUPPLIER/RECEPIENT------------
                                Dim aaa As New Dictionary(Of String, String)

                                aaa.Add("dr_no", .drno_invoice)
                                aaa.Add("stat", .stat)
                                aaa.Add("type_of_purchasing", .type_of_purchasing)
                                aaa.Add("supprec", reader.Item("r2").ToString)
                                aaa.Add("dr_items_id", IIf(reader.Item("dr_items_id").ToString = "", 0, reader.Item("dr_items_id").ToString))

                                Dim t3 As Threading.Thread
                                t3 = New Threading.Thread(AddressOf get_supp_recepient)
                                t3.Start(aaa)
                                t3.Join()
                                '-----------------------------------------

                                .supp_recipient = supplier_recepient


                            ElseIf reader.Item("type_of_purchasing").ToString = "DR" And .stat = "IN WITH RS AND RR BUT WITH DR" Then 'RS->DR
                                '------GET SUPPLIER/RECEPIENT------------
                                .supp_recipient = reader.Item("agg_supplier").ToString

                                '-----------------------------------------
                            Else

                                .supp_recipient = reader.Item("SOURCE_WH").ToString
                            End If

                            .qty_in = reader.Item("qty_IN").ToString
                            .qty_out = 0

                        ElseIf reader.Item("IN_OUT").ToString = "OTHERS" Then

                        End If

                        If .qty_out = "" Then
                            .qty_out = 0
                        End If

                        If .qty_in = "" Then
                            .qty_in = 0
                        End If

                        .remarks = reader.Item("remarks").ToString

                        'THIS CODE IS FOR OUT AND IN WITHOUR RS AND DR
                        If .rs_no.Contains("N/A") And .drno_invoice.Contains("N/A") Or .rs_no.Contains("n/a") And .drno_invoice.Contains("n/a") Then
                            If .inout = "IN" Then

                                .supp_recipient = reader.Item("r2").ToString
                            ElseIf .inout = "OUT" Then
                                '.supp_recipient = reader.Item("SOURCE_WH").ToString 'reader.Item("r").ToString
                                .ws_no = "-"
                            End If
                        End If
                        '--------------------------------------

                        'THIS CODE IS FOR IN WITHOUT RS BUT WITH DR
                        If .rs_no.Contains("N/A") And .drno_invoice <> "" Or .rs_no.Contains("N/A") And Not .drno_invoice.Contains("N/A") Then
                            If .inout = "IN" Then
                                '.supp_recipient = reader.Item("r2").ToString
                                .supp_recipient = reader.Item("agg_supplier").ToString
                                .ws_no = "-"
                            ElseIf .inout = "OUT" Then
                                '.supp_recipient = reader.Item("SOURCE_WH").ToString
                                .ws_no = "-"
                            End If
                        End If


                        'THIS CODE IS FOR SUPPLIER RECEPIENT ONLY/ OVERWRITE TANAN SUPPRECEPIENT SA TAAS PINAAGI ANI NGA CODE, tungod ky naglibog nko sa code dli nalang nako deleton sa taas

                        _get_aggregatesStockCard.Add(newSc)

                        rowcount += 1
                    End With
proceedhere:

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function

        Public Function _get_prev_balance() As Double
            _get_prev_balance = New Double
            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_execute_tempstockcard2", SQ.connection)

                While reader.Read
                    _get_prev_balance = reader.Item("balance").ToString()
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function


        Public Function get_balances(listOfStockCard As List(Of agg_data)) As Double
            Try
                get_balances = 0
                Dim result As Double

                For Each row In listOfStockCard
                    '8 - IN
                    '9 - OUT

                    If row.qty_in = 0 Then
                        Dim out As String

                        If IsNumeric(row.qty_out) Then
                            out = row.qty_out

                        Else

                            Dim sp() As String = row.qty_out.Split("/")

                            If CDbl(sp(0)) < CDbl(sp(1)) Then
                                out = (CDbl(sp(1)) - CDbl(sp(0)))
                            Else
                                out = 0
                            End If
                        End If

                        result = CDbl(CStr(result)) - CDbl(out)
                        'row.cells(10).value = FormatNumber(CDbl(CStr(Result)), 2,,, TriState.True)

                    ElseIf CDbl(row.qty_in) > 0 Then
                        result = FormatNumber(result, 2,,, TriState.True) + CDbl(CStr(row.qty_in))
                        'row.cells(10).value = FormatNumber(CDbl(CStr(Result)), 2,,, TriState.True)
                    End If
                Next

                get_balances = result
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Function

        Private Sub get_qty_using_wsno(dr_qty_using_wsno_dict As Dictionary(Of String, String))
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 12)
                newCMD.Parameters.AddWithValue("@ws_no", dr_qty_using_wsno_dict("_ws_no"))
                newCMD.Parameters.AddWithValue("@rs_no", dr_qty_using_wsno_dict("_rs_no"))

                newDR = newCMD.ExecuteReader

                While newDR.Read
                    If newDR.Item("qty").ToString = "" Then
                        dr_qty_using_wsno = 0
                    Else
                        dr_qty_using_wsno = CDbl(newDR.Item("qty").ToString)
                    End If

                End While

                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub

        Private Function get_supp_recepient(data As Dictionary(Of String, String)) As String

            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                If data("stat") = "IN WITH RS AND RR BUT WITH DR" Then
                    newCMD.Parameters.AddWithValue("@n", 19)
                ElseIf data("stat") = "IN WITH RS AND RR BUT NO DR" Then
                    newCMD.Parameters.AddWithValue("@n", 191)
                End If

                newCMD.Parameters.AddWithValue("@dr_no", data("dr_no"))
                newCMD.Parameters.AddWithValue("@dr_items_id", data("dr_items_id"))
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    If data("stat") = "IN WITH RS AND RR BUT WITH DR" And data("type_of_purchasing") = "PURCHASE ORDER" Then
                        supplier_recepient = newDR.Item("Supp_Rec").ToString
                    ElseIf data("stat") = "IN WITH RS AND RR BUT WITH DR" And data("type_of_purchasing") = "DR" Then
                        'supplier_recepient = "wait a miinute"
                    ElseIf data("stat") = "IN WITH RS AND RR BUT NO DR" And data("type_of_purchasing") = "PURCHASE ORDER" Then
                        supplier_recepient = newDR.Item("Supp_Rec").ToString
                    Else
                        supplier_recepient = newDR.Item("Supp_Rec").ToString
                    End If

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Function

#End Region

    End Class

#End Region

#Region "ALL ABOUT ADFIL EMPLOYEE"
    Public Class _Mod_Adfil_Employee
        Private cDict As New Dictionary(Of String, Object)

#Region "PARAMETERS"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "DELEGATES"
        Private Delegate Function getEmployeeDataDelegates() As List(Of employee_data)
#End Region
#Region "INTERFACE"
        Class employee_data
            Property person_id As Integer
            Property employee As String
            Property position As String

        End Class
#End Region
#Region "FUNCTIONS"
        Public Function LISTOFADFILEMPLOYEE() As List(Of employee_data)

            'INITIALIZING DATA HERE

            Dim getDataInstance As getEmployeeDataDelegates = Nothing
            getDataInstance = AddressOf _get_adfilEmployee

            Dim asyncResult As IAsyncResult = getDataInstance.BeginInvoke(Nothing, Nothing)

            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            LISTOFADFILEMPLOYEE = getDataInstance.EndInvoke(asyncResult)
        End Function

        Private Function _get_adfilEmployee() As List(Of employee_data)
            _get_adfilEmployee = New List(Of employee_data)
            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data("proc_dr_list4", SQ.connection)

                While reader.Read
                    Dim data As New employee_data

                    With data
                        .person_id = reader.Item("person_id").ToString
                        .employee = reader.Item("Employee").ToString
                        .position = reader.Item("Position").ToString
                    End With

                    _get_adfilEmployee.Add(data)

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region

    End Class

#End Region

#Region "ALL ABOUT TYPE OF REQUEST"
    Public Class _Mod_Type_of_Request
        Private cSearch As String
        Private cDict As New Dictionary(Of String, Object)
        Public cStoreProcedureName As String
#Region "DELEGATES"
        Private Delegate Function ListOfToRDelegates() As List(Of type_of_request_field)
#End Region
#Region "FUNCTIONS AND QUERY"
        Public Function LISTOFTYPEOFREQUEST(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of type_of_request_field)
            'cDict = dict
            Dim ToRInstance As ListOfToRDelegates = AddressOf _get_type_of_request

            ' Begin the asynchronous operation
            Dim asyncResult As IAsyncResult = ToRInstance.BeginInvoke(Nothing, Nothing)

            ' The UI thread is free to continue executing here
            ' while the asynchronous operation is running in the background

            '==> UI thread is free to execute other code <==

            ' Wait for the asynchronous operation to complete
            While Not asyncResult.IsCompleted
                Application.DoEvents()
            End While

            ' Get the result of the asynchronous operation
            LISTOFTYPEOFREQUEST = ToRInstance.EndInvoke(asyncResult)
        End Function
        Private Function _get_type_of_request() As List(Of type_of_request_field)
            _get_type_of_request = New List(Of type_of_request_field)

            Dim SQ As New SQLcon
            Dim newSQ As New SQLcon

            Try
                Dim c As New class_query

                'LOOP THE PARAMETER GIVEN INTO class_query parameter
                For Each pair As KeyValuePair(Of String, Object) In cDict
                    c.add_parameter(pair.Key, pair.Value)
                Next

                Dim reader As SqlDataReader = c.sql_data(cStoreProcedureName, SQ.connection)

                While reader.Read
                    Dim _tor As New type_of_request_field

                    With _tor

                        .tsp_id = reader.Item("tsp_id").ToString
                        .inout_id = reader.Item("inout_id").ToString
                        .in_out_desc = reader.Item("in_out_desc").ToString
                        .tor_sub_desc = reader.Item("tor_sub_desc").ToString
                        .tor_desc = reader.Item("tor_desc").ToString

                        _get_type_of_request.Add(_tor)

                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                SQ.connection.Close()
            End Try
        End Function
#End Region
#Region "PARAMETER"
        Public Sub parameter(key As String, value As Object)
            cDict.Add(key, value)
        End Sub
        Public Sub clear_parameter()
            cDict = New Dictionary(Of String, Object)
        End Sub
#End Region
#Region "FIELDS"
        Class type_of_request_field
            Property tsp_id As Integer
            Property inout_id As Integer
            Property in_out_desc As String
            Property tor_sub_desc As String
            Property tor_desc As String

        End Class
#End Region
    End Class
#End Region

End Class

