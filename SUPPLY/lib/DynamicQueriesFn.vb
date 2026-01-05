Imports System.Data.SqlClient
Imports OfficeOpenXml.Drawing

Public Class DynamicQueriesFn
    Public cWhatColumn As Integer
    Public cDict As New Dictionary(Of String, Object)
    Private customMsg As New customMessageBox

    Public Function _get_eu_dynamic() As List(Of PropsFields.eus_data_fields)
        _get_eu_dynamic = New List(Of PropsFields.eus_data_fields)
        Dim _select As New Model_Dynamic_Select

        Dim table As String = ""
        Dim condition As String = ""

        Try
            With _select
                Select Case cWhatColumn
                    Case cCol.forEu_Project
                        table = "dbeu a"
                        condition = $"a.project = '{cDict("project")}'"

                        'columns
                        .join_columns("a.plateno,")
                        .join_columns("a.project,")
                        .join_columns("a.eu_date,")
                        .join_columns("a.operator")
                        'end columns

                End Select

                'initialize data
                ._initialize(table, condition, .cJoinColumns, .cJoining)

                Dim euDatas As New List(Of Object) 'create a list of ojbect 
                euDatas = .select_query() 'get data

                'loop data to get values
                For Each row In euDatas

                    Dim _eu As New PropsFields.eus_data_fields
                    With _eu
                        Select Case cWhatColumn
                            Case cCol.forEu_Project

                                .plate_no = row("plateno")
                                .project = row("project")
                                .operator_driver = row("operator")
                                .eu_date = row("eu_date")

                        End Select

                    End With

                    _get_eu_dynamic.Add(_eu)
                Next
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Function

    Public Function _getListOfPlateNoDynamic() As List(Of PropsFields.equipment_props_fields)
        _getListOfPlateNoDynamic = New List(Of PropsFields.equipment_props_fields)
        Dim _select As New Model_Dynamic_Select

        Dim table As String = ""
        Dim condition As String = ""

        Try
            With _select
                Select Case cWhatColumn
                    Case cCol.forPlateNo
                        table = "dbequipment_list a"
                        condition = $"a.plate_no like '%' + { "" } + '%'"

                        'columns
                        .join_columns("a.equipListID,")
                        .join_columns("a.plate_no")
                        'end columns

                End Select

                'initialize data
                ._initialize(table, condition, .cJoinColumns, .cJoining, cDbName.eus_table)

                Dim euDatas As New List(Of Object) 'create a list of ojbect 
                euDatas = .select_query() 'get data

                'loop data to get values
                For Each row In euDatas

                    Dim _equipment As New PropsFields.equipment_props_fields
                    With _equipment
                        Select Case cWhatColumn
                            Case cCol.forPlateNo
                                .equipListID = row("equipListID")
                                .PlateNo = row("plate_no")
                        End Select

                    End With

                    _getListOfPlateNoDynamic.Add(_equipment)
                Next
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function _getStockCardPrevBalance() As Double
        _getStockCardPrevBalance = New Double

        Dim _select As New Model_Dynamic_Select

        Dim table As String = ""
        Dim condition As String = ""

        Try
            With _select
                Select Case cWhatColumn
                    Case cCol.forPrevBalance
                        table = "dbPrevious_stock_card a"
                        condition = $"a.wh_id = '{cDict("search")}'"

                        'columns
                        .join_columns("a.balance")

                        'end columns

                End Select

                'initialize data
                ._initialize(table, condition, .cJoinColumns, .cJoining)

                Dim euDatas As New List(Of Object) 'create a list of ojbect 
                euDatas = .select_query() 'get data

                'loop data to get values
                For Each row In euDatas

                    Select Case cWhatColumn
                        Case cCol.forPrevBalance
                            _getStockCardPrevBalance = row("balance")
                    End Select
                Next
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Function

    Public Function _getKPIData() As List(Of PropsFields.KPIprops_fields)
        Try
            Dim kpi As New KeyPerformanceIndicatorModel

            _getKPIData = kpi.getKPIData(kpi.enumSearchBy.all, "")
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function _getMultipleKPIData() As List(Of PropsFields.MultipleKPIprops_fields)
        Try
            Dim kpi As New KeyPerformanceIndicatorModel

            _getMultipleKPIData = kpi.getMultipleKPIData(kpi.enumSearchBy.all, "")
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function _getRsLocations() As List(Of String)
        Try
            _getRsLocations = New List(Of String)
            Dim query As String = "SELECT DISTINCT
                                        a.location  
                                        FROM dbrequisition_slip a 
                                        order by a.location"

            Dim SQNEW As New SQLcon
            Dim cmdNew As SqlCommand
            Dim SQLDr As SqlDataReader

            SQNEW.connection.Open()

            cmdNew = New SqlCommand(query, SQNEW.connection)
            cmdNew.Parameters.Clear()
            cmdNew.CommandType = CommandType.Text

            SQLDr = cmdNew.ExecuteReader
            While SQLDr.Read
                If cCol.forRsLocations Then
                    _getRsLocations.Add(SQLDr(0).ToString)
                End If
            End While

            SQLDr.Close()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

End Class
