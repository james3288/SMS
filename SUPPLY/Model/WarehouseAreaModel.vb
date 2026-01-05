Imports Microsoft.Office.Interop.Excel

Public Class WarehouseAreaModel
    Implements Interfaces.IWHArea

    Private cListOfWhArea As New List(Of PropsFields.whArea_stockpile_props_fields)
    Private cListOfEmployee As New List(Of PropsFields.employee_props_fields)
    Private cListOfIncharge As New List(Of PropsFields.inchargeNew_fields)
    Private cListOfAllCharges As New List(Of PropsFields.AllCharges)
    Private ListOfWhAreaNew As New List(Of PropsFields.whArea_stockpile_props_fields)

    Private customMsg As New customMessageBox
    Private whAreaStockpileModel,
        EmployeeModel,
        WhInchargeNewModel,
        cAllChargesModel As New ModelNew.Model

    Dim cBgWorkerChecker As Timer
    Dim cSearch As String = ""
    Private dgView As New DataGridView
    Private rowFocus As Boolean
    Private rowId As Integer

    Private cn As New PropsFields.whArea_stockpile_props_fields
    Public Property setRowFocus As Boolean
        Get
            Return rowFocus
        End Get
        Set(value As Boolean)
            rowFocus = value
        End Set
    End Property

    Public Property setRowId As Integer
        Get
            Return rowId
        End Get
        Set(value As Integer)
            rowId = value
        End Set
    End Property

    Public ReadOnly Property getClistOfWhArea() As List(Of PropsFields.whArea_stockpile_props_fields)
        Get
            Return cListOfWhArea
        End Get
    End Property
    Public ReadOnly Property getRefactoredListOfWhArea() As List(Of PropsFields.whArea_stockpile_props_fields)
        Get
            Return ListOfWhAreaNew
        End Get
    End Property
    Public Sub delete(id As Integer) Implements IWHArea.delete
        Try
            Dim c As New ColumnValuesObj

            Dim tables As New List(Of PropsFields.SMSTables)
            Dim table1, table2 As New PropsFields.SMSTables

            With table1
                .table = "dbwh_area"
                .condtion = $"wh_area_id = {id}"
            End With

            With table2
                .table = "db_wh_area_incharge"
                .condtion = $"wh_area_id = {id}"
            End With

            tables.Add(table1)
            tables.Add(table2)

            c.deleteDataUsingRollback(tables)

            customMsg.message("info", "Successfully removed!", "SUPPLY INFO:")
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Function saved(whAreaData As PropsFields.whArea_stockpile_props_fields, charge_to_id As Integer) As Integer Implements IWHArea.saved
        Try
            With whAreaData
                Dim cc As New ColumnValuesObj
                cc.add("wh_area", .wh_area)
                cc.add("wh_location", .wh_location)
                cc.add("wh_options", .wh_options)
                cc.add("charge_to_id", charge_to_id)

                saved = cc.insertQuery_and_return_id("dbwh_area")

                Return saved
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function update(whAreaData As PropsFields.whArea_stockpile_props_fields, charge_to_id As Integer, id As Integer) As Boolean Implements IWHArea.update
        Try
            With whAreaData
                Dim cc As New ColumnValuesObj
                cc.add("wh_area", .wh_area)
                cc.add("wh_location", .wh_location)
                cc.add("wh_options", .wh_options)
                cc.add("charge_to_id", charge_to_id)

                cc.setCondition($"wh_area_id = {id}")
                update = cc.updateQuery_return_true("dbwh_area")
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function updateWarehouseAreaStockpileFromWarehouseItem(wh_area_id As Integer, wh_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("whArea", wh_area_id)
            cc.add("whArea_category", "WAREHOUSE")
            cc.setCondition($"wh_id = {wh_id}")

            updateWarehouseAreaStockpileFromWarehouseItem = cc.updateQuery_return_true("dbwarehouse_items")

            Return updateWarehouseAreaStockpileFromWarehouseItem
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function updateQuarryFromWarehouseItem(wh_area_id As Integer, wh_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("quarry_id", wh_area_id)
            cc.add("whArea_category", "WAREHOUSE")
            cc.setCondition($"wh_id = {wh_id}")

            updateQuarryFromWarehouseItem = cc.updateQuery_return_true("dbwarehouse_items")

            Return updateQuarryFromWarehouseItem
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Sub initialize(Optional datagridView As DataGridView = Nothing)
        dgView = datagridView
    End Sub
    Public Sub getWareHouseArea(Optional search As String = "")
        Try
            whAreaStockpileModel.clearParameter()
            EmployeeModel.clearParameter()
            WhInchargeNewModel.clearParameter()
            cAllChargesModel.clearParameter()

            Dim cv As New ColumnValues
            cv.add("crud", 7)
            cv.add("search", "")

            Dim cv2 As New ColumnValues
            Dim cv3 As New ColumnValues
            cv3.add("crud", "8")

            _initializing(cCol.forWareHouseStockpileArea,
                      cv.getValues(),
                      whAreaStockpileModel,
                      whAreaStockpileBgWorker)

            _initializing(cCol.forEmployeeData,
                      cv2.getValues(),
                      EmployeeModel,
                      whAreaStockpileBgWorker)

            _initializing(cCol.forWhInchargeNew,
                      cv3.getValues(),
                      WhInchargeNewModel,
                      whAreaStockpileBgWorker)

            _initializing(cCol.forAllCharges,
                          cv2.getValues(),
                          cAllChargesModel,
                          whAreaStockpileBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, whAreaStockpileBgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub searchWarehouseArea(search As String) Implements IWHArea.searchWarehouseArea
        Try
            'refactor list to include searching incharge
            ListOfWhAreaNew.Clear()

            For Each row In cListOfWhArea
                Dim whAreaNew As New PropsFields.whArea_stockpile_props_fields
                With whAreaNew
                    .wh_area_id = row.wh_area_id
                    .wh_area = row.wh_area
                    .wh_area_proper_name = row.wh_area_proper_name
                    .wh_incharge = getWarehouseIncharge(row.wh_area_id)
                    .wh_location = row.wh_location
                    .wh_options = row.wh_options
                End With

                ListOfWhAreaNew.Add(whAreaNew)
            Next

            Dim datas As New List(Of PropsFields.whArea_stockpile_props_fields)
            datas = ListOfWhAreaNew.Where(Function(x)
                                              Dim searching As String = $"{x.wh_area} {x.wh_area_proper_name} {x.wh_incharge} {x.wh_location}"
                                              Return searching.ToUpper().Contains(search.ToUpper())
                                          End Function).ToList()

            preview(datas)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyDone()

        cListOfWhArea = TryCast(whAreaStockpileModel.cData, List(Of PropsFields.whArea_stockpile_props_fields))
        cListOfEmployee = TryCast(EmployeeModel.cData, List(Of PropsFields.employee_props_fields))
        cListOfIncharge = TryCast(WhInchargeNewModel.cData, List(Of PropsFields.inchargeNew_fields))
        cListOfAllCharges = TryCast(cAllChargesModel.cData, List(Of PropsFields.AllCharges))

        Dim searchListOfWhArea = cListOfWhArea.Where(Function(x)
                                                         Dim output As String = x.wh_area.ToUpper() & " " & x.wh_incharge.ToUpper() & " " & x.wh_location.ToUpper()
                                                         Return output.Contains(cSearch.ToUpper())
                                                     End Function).OrderBy(Function(x) x.wh_area).ToList()

        'refactor for warehouse incharge

        For Each row In searchListOfWhArea
            Dim whAreaNew As New PropsFields.whArea_stockpile_props_fields
            With whAreaNew
                .wh_area_id = row.wh_area_id
                .wh_area = row.wh_area
                .wh_area_proper_name = row.wh_area_proper_name
                .wh_incharge = getWarehouseIncharge(row.wh_area_id)
                .wh_location = row.wh_location
                .wh_options = row.wh_options
            End With

            ListOfWhAreaNew.Add(whAreaNew)
        Next

        preview(ListOfWhAreaNew)
    End Sub

    Private Sub preview(datas As List(Of PropsFields.whArea_stockpile_props_fields))
        If datas.Count > 0 Then
            dgView.DataSource = datas
            customizeDagrid()
        End If
    End Sub

    Private Function getWarehouseIncharge(whAreaId As Integer) As String
        getWarehouseIncharge = ""

        If whAreaId = 0 Then
            Return ""
            Exit Function
        End If

        Try
            Dim datas As New List(Of PropsFields.inchargeNew_fields)
            datas = cListOfIncharge.Where(Function(x) x.wh_area_id = whAreaId).ToList()
            Dim listOfIncharge As New List(Of String)
            For Each row In datas
                Dim emp = cListOfEmployee.Where(Function(x) x.employee_id = row.incharge_id).ToList()

                If emp.Count > 0 Then
                    listOfIncharge.Add($"{emp(0).first_name} {emp(0).last_name}")
                End If
            Next

            ' Convert the list of column names to an array of strings and join them with commas
            Return String.Join(", ", listOfIncharge.ToArray())
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function getCharges_id(charges As String) As Integer
        Try
            Dim data = cListOfAllCharges.Where(Function(x) x.charges.ToUpper() = charges.ToUpper() And x.charges_category.ToUpper() = "WAREHOUSES").ToList()

            If data.Count > 0 Then
                Return data(0).charges_id
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getSpecificWhArea(id As Integer) As PropsFields.whArea_stockpile_props_fields Implements IWHArea.getSpecificWhArea
        Try
            Dim datas = cListOfWhArea.Where(Function(x) x.wh_area_id = id).ToList()

            If datas.Count > 0 Then
                getSpecificWhArea = datas(0)
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Sub reloadItemsWithoutRefreshNew(wh_area_id As Integer,
                                          whatToUpdate As String,
                                          value As PropsFields.whArea_stockpile_props_fields,
                                          Optional id As Integer = 0)

        Dim finalData = ListOfWhAreaNew
        Dim rawData = cListOfWhArea

        Dim index As Integer = finalData.FindIndex(Function(x) x.wh_area_id = wh_area_id)
        Dim index2 As Integer = rawData.FindIndex(Function(x) x.wh_area_id = wh_area_id)

        With finalData(index)

            Select Case whatToUpdate
                Case "remove_proper_wharea", "add_proper_wharea"
                    .wh_area_proper_name = value.wh_area_proper_name
                    .wh_options = value.wh_options
                    .wh_area = value.wh_area

                Case "remove_incharge"
                    cListOfIncharge = cListOfIncharge.Where(Function(x)
                                                                Return x.incharge_id.ToString() <> value.wh_incharge
                                                            End Function).ToList()

                    FWarehouseItemsNew.getWhItemsModel().cListOfIncharge = cListOfIncharge
                    .wh_incharge = getWarehouseIncharge(wh_area_id)

                Case "add_incharge"
                    Dim newIncharge As New PropsFields.inchargeNew_fields
                    With newIncharge
                        .incharge_id = id
                        .whIncharge = value.wh_incharge
                        .wh_area_id = wh_area_id
                        .wh_area = value.wh_area
                    End With

                    cListOfIncharge.Add(newIncharge)

                    FWarehouseItemsNew.getWhItemsModel().cListOfIncharge = cListOfIncharge

                    .wh_incharge = getWarehouseIncharge(wh_area_id)
            End Select
        End With


        'this raw data must update also, gamiton ni nga list ddto sa pag search sa warehousearea
        With rawData(index2)

            Select Case whatToUpdate
                Case "remove_proper_wharea", "add_proper_wharea"
                    .wh_area_proper_name = value.wh_area_proper_name
                    .wh_options = value.wh_options
                    .wh_area = value.wh_area


                Case "remove_incharge"
                    cListOfIncharge = cListOfIncharge.Where(Function(x)
                                                                Return x.incharge_id.ToString() <> value.wh_incharge
                                                            End Function).ToList()

                    .wh_incharge = getWarehouseIncharge(wh_area_id)

            End Select

        End With

        dgView.DataSource = Nothing
        dgView.DataSource = finalData
        ListOfWhAreaNew = finalData
        cListOfWhArea = rawData

        customizeDagrid()

        Utilities.datagridviewSpecificRowFocus(dgView, wh_area_id, "wh_area_id")
        'data(index)
    End Sub
#Region "CRUD"
    Public Function removeLinkWarehouseArea(wh_area_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("charge_to_id", 0)
            cc.add("wh_options", "")
            cc.setCondition($"wh_area_id = {wh_area_id}")

            removeLinkWarehouseArea = cc.updateQuery_return_true("dbwh_area")
            customMsg.message("info", "Successfully removed!", "SUPPLY INFO:")

            ''remove Data from db_wh_area_incharges
            'Dim remove As New ColumnValuesObj

            'Dim tables As New List(Of PropsFields.SMSTables)
            'Dim table1 As New PropsFields.SMSTables

            'With table1
            '    .table = "db_wh_area_incharge"
            '    .condtion = $"wh_area_id = {wh_area_id}"
            'End With

            'tables.Add(table1)

            'remove.deleteDataUsingRollback(tables)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
#Region "DATAGRIDVIEW ROWS"
    Private Sub customizeDagrid()
        Try

            If dgView.Rows.Count > 0 Then
                'rename column header
                dgView.Columns(NameOf(cn.wh_area)).HeaderText = "WAREHOUSE AREA/STOCKPILE"
                dgView.Columns(NameOf(cn.wh_area_proper_name)).HeaderText = "WAREHOUSE AREA - (PROPER NAME)"
                dgView.Columns(NameOf(cn.wh_location)).HeaderText = "LOCATION"
                dgView.Columns(NameOf(cn.wh_incharge)).HeaderText = "INCHARGE"
                dgView.Columns(NameOf(cn.wh_options)).HeaderText = "CATEGORY"

                Dim customDgv As New CustomGridview
                customDgv.readonlyAllCells(dgView)
                customDgv.autoSizeColumn(dgView, True)

                If rowFocus Then
                    customDgv.rowFocus(dgView, NameOf(cn.wh_area_id), rowId)
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

End Class
