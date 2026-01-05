Imports System.Linq
Public Class KeyPerformanceIndicatorModel
    Implements Interfaces.IKPI

    Private viewing As New enumKPIView
    Private customMsg As New customMessageBox
    Public enumSearchBy As New searchBy
    Private cn As New PropsFields.KPIprops_fields
    Private cn2 As New PropsFields.MultipleKPIprops_fields

    Private tableName As String = "dbKeyPerformanceIndicator"
    Private dbWarehouseItems_dbKPI_table As String = "dbWarehouseItems_dbKPI"

    Private cListOfKPIData As New List(Of PropsFields.KPIprops_fields)
    Public Shared kpi_category As String
    Public Class searchBy
        Public Property all As String = "all"
        Public Property indicator As String = "indicator"
        Public Property leadTimeCategory As String = "lead time category"
    End Class
    Public ReadOnly Property getListOfKpiData As List(Of PropsFields.KPIprops_fields)
        Get
            Return cListOfKPIData
        End Get
    End Property
    Public Function saved(kpiData As PropsFields.KPIprops_fields) As Integer Implements IKPI.saved
        Try
            Dim insert As New Model_King_Dynamic_Update
            Dim saveStorage As New CustomSaved

            With saveStorage
                .addParameter(NameOf(kpiData.indicator), kpiData.indicator)
                .addParameter(NameOf(kpiData.lead_time_days), kpiData.lead_time_days)
                .addParameter(NameOf(kpiData.lead_time_category), kpiData.lead_time_category)
            End With

            saved = insert.InsertData_and_return_id("dbKeyPerformanceIndicator", saveStorage.getParamData())

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function saved2(ByVal whsID As Integer, ByVal kpiID As Integer, ByVal kpiIndicator As String)

        Try
            Dim insert As New Model_King_Dynamic_Update
            Dim saveStorage As New CustomSaved
            Dim whsid1 As String = "wh_id"
            Dim kpiid1 As String = "kpi_id"
            Dim tor_id1 As String = "tor_id"
            Dim contruction_id As String = 1
            Dim equipment_id As String = 2
            Dim admin As String = 3

            If kpi_category = "Type Request Category" Then
                If kpiIndicator = "Project" Then
                    With saveStorage
                        .addParameter(whsid1, whsID)
                        .addParameter(kpiid1, kpiID)
                        .addParameter(tor_id1, contruction_id)
                    End With
                ElseIf kpiIndicator = "Equipment" Then
                    With saveStorage
                        .addParameter(whsid1, whsID)
                        .addParameter(kpiid1, kpiID)
                        .addParameter(tor_id1, equipment_id)
                    End With
                ElseIf kpiIndicator = "Admin and Miscellaneous" Then
                    With saveStorage
                        .addParameter(whsid1, whsID)
                        .addParameter(kpiid1, kpiID)
                        .addParameter(tor_id1, admin)
                    End With
                End If
            Else
                With saveStorage
                    .addParameter(whsid1, whsID)
                    .addParameter(kpiid1, kpiID)
                End With
            End If

            saved2 = insert.InsertData_and_return_id("dbWarehouseItems_dbKPI", saveStorage.getParamData())

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function update(kpiData As PropsFields.KPIprops_fields, id As Integer) As Boolean Implements IKPI.update
        Try
            Dim _update As New Model_King_Dynamic_Update
            Dim saveStorage As New CustomSaved
            Dim condition As String = $"kpi_id = {id}"
            With saveStorage
                .addParameter("indicator", kpiData.indicator)
                .addParameter("lead_time_days", kpiData.lead_time_days)
                .addParameter("lead_time_category", kpiData.lead_time_category)
            End With

            update = _update.UpdateData_and_return_true(tableName, saveStorage.getParamData(), condition)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Sub delete(id As Integer) Implements IKPI.delete
        Try

            Dim delete As New Model_King_Dynamic_Update
            Dim condition As String = $"{NameOf(cn.kpi_id)} = {id}"
            delete.DeleteData(tableName, condition)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Function getKPIData(searchBy As String, Optional search As String = "") As List(Of PropsFields.KPIprops_fields)
        getKPIData = New List(Of PropsFields.KPIprops_fields)

        Try
            Dim cc As New ColumnValuesObj
            Dim tnt As New tableNameType
            Dim a As String = "a"
            cc.addColumn($"{a}.{NameOf(cn.kpi_id)}")
            cc.addColumn($"{a}.{NameOf(cn.indicator)}")
            cc.addColumn($"{a}.{NameOf(cn.lead_time_days)}")
            cc.addColumn($"{a}.{NameOf(cn.lead_time_category)}")

            Select Case searchBy
                Case enumSearchBy.all
                    cc.setCondition($"{a}.{NameOf(cn.indicator)} like '%{search}%' and {a}.lead_time_category = '" & kpi_category & "'")
                    Dim data = cc.selectQuery_and_return_data(tableName, False, a, tnt.supply_table)
                    If data IsNot Nothing AndAlso data.Count > 0 Then
                        For Each item As Object In data
                            Dim dict = TryCast(item, Dictionary(Of String, Object))
                            If dict IsNot Nothing Then

                                Dim kpi As New PropsFields.KPIprops_fields

                                With kpi
                                    .kpi_id = dict(NameOf(cn.kpi_id))
                                    .indicator = dict(NameOf(cn.indicator))
                                    .lead_time_days = dict(NameOf(cn.lead_time_days))
                                    .lead_time_category = dict(NameOf(cn.lead_time_category))
                                End With
                                getKPIData.Add(kpi)
                            End If
                        Next
                    End If
            End Select

            Return getKPIData
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return getKPIData
        End Try

    End Function

    Public Function getMultipleKPIData(searchBy As String, Optional search As String = "") As List(Of PropsFields.MultipleKPIprops_fields)
        getMultipleKPIData = New List(Of PropsFields.MultipleKPIprops_fields)

        Try
            Dim cc As New ColumnValuesObj
            Dim tnt As New tableNameType
            Dim a As String = "a"
            Dim b As String = "b"
            Dim c As String = "c"


            cc.addColumn($"{c}.{NameOf(cn2.wh_id)}")
            cc.addColumn($"{b}.{NameOf(cn2.kpi_id)}")
            cc.addColumn($"{b}.{NameOf(cn2.indicator)}")
            cc.addColumn($"{b}.{NameOf(cn2.lead_time_days)}")
            cc.addColumn($"{b}.{NameOf(cn2.lead_time_category)}")

            Select Case searchBy
                Case enumSearchBy.all

                    cc.addJoinClause($"LEFT JOIN dbKeyPerformanceIndicator {b} ON {b}.kpi_id = {a}.kpi_id")
                    cc.addJoinClause($"LEFT JOIN dbwarehouse_items {c} ON {c}.wh_id = {a}.wh_id")
                    cc.setCondition($"{b}.{NameOf(cn2.indicator)} like '%{search}%'")

                    Dim data = cc.selectQuery_and_return_data(dbWarehouseItems_dbKPI_table, False, a, tnt.supply_table)

                    If data IsNot Nothing AndAlso data.Count > 0 Then
                        For Each item As Object In data
                            Dim dict = TryCast(item, Dictionary(Of String, Object))
                            If dict IsNot Nothing Then

                                Dim kpi As New PropsFields.MultipleKPIprops_fields

                                With kpi

                                    .wh_id = dict(NameOf(cn2.wh_id))
                                    .kpi_id = dict(NameOf(cn2.kpi_id))
                                    .indicator = dict(NameOf(cn2.indicator))
                                    .lead_time_days = dict(NameOf(cn2.lead_time_days))
                                    .lead_time_category = dict(NameOf(cn2.lead_time_category))

                                End With
                                getMultipleKPIData.Add(kpi)

                            End If
                        Next
                    End If
            End Select

            Return getMultipleKPIData
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return getMultipleKPIData
        End Try
    End Function

End Class

