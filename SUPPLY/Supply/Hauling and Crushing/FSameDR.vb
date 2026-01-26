
Public Class FSameDR

    Public cDrToRemove As New List(Of PropsFields.dr_list_props_fields)
    Private customMsg As New customMessageBox
    Private customGrid As New CustomGridview
    Private cn As New PropsFields.dr_list_props_fields
    Private Sub FSameDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            customGrid.customDatagridview(DataGridView1)
            DataGridView1.DataSource = cDrToRemove

            customizeDataGridview(DataGridView1)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub customizeDataGridview(dgv As DataGridView)
        Try

            dgv.MultiSelect = True

            'hide columns
            For Each column As DataGridViewColumn In dgv.Columns
                If column.Name = NameOf(cn.dr_item_id) Or
                    column.Name = NameOf(cn.item_desc) Or
                    column.Name = NameOf(cn.dr_no) Or
                    column.Name = NameOf(cn.rs_no) Or
                    column.Name = NameOf(cn.inout) Then

                    column.Visible = True

                Else
                    column.Visible = False
                End If
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If customMsg.messageYesNo("STOCKPILE TO STOCKPILE?", "SMS INFO:", MessageBoxIcon.Question) Then
            removeByDrNoStockpileToStockpile()
        Else
            removeByDrItemId()
        End If

    End Sub
    Private Sub removeByDrNoStockpileToStockpile()
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Selected Then
                    Dim data = cDrToRemove.FirstOrDefault(Function(x)
                                                              Return x.dr_no = row.Cells(NameOf(cn.dr_no)).Value
                                                          End Function)
                    Dim remove As New RemoveAggregates
                    remove.initialize(data)
                    remove.initialize_datas(cDrToRemove)
                    remove.initialize_for_stockpile_to_stockpile(True)

                    remove.execute()
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub removeByDrItemId()
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Selected Then
                    Dim data = cDrToRemove.FirstOrDefault(Function(x)
                                                              Return x.dr_item_id = row.Cells(NameOf(cn.dr_item_id)).Value
                                                          End Function)
                    Dim remove As New RemoveAggregates
                    remove.initialize(data)
                    remove.execute()
                End If
            Next

            Me.Dispose()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Class RemoveAggregates

        Private _cCustomMsg As New customMessageBox
        Private _data As New PropsFields.dr_list_props_fields
        Private _datas As New List(Of PropsFields.dr_list_props_fields)
        Private _isForStockpileToStockpile As Boolean
        Public Sub initialize(data As PropsFields.dr_list_props_fields)

            _data = data

        End Sub

        Public Sub initialize_datas(datas As List(Of PropsFields.dr_list_props_fields))

            _datas = datas

        End Sub

        Public Sub initialize_for_stockpile_to_stockpile(isForStockpileToStockpile As Boolean)

            _isForStockpileToStockpile = isForStockpileToStockpile

        End Sub

        Public Sub execute()
            Try
                Select Case _data.inout
                    Case cInOut._OTHERS
                        removeOthersDrTransaction()
                    Case cInOut._OUT

                        If _isForStockpileToStockpile Then
                            removeDrStockToStockpileTransaction()
                        Else

                        End If

                    Case cInOut._IN

                        removeInDrTransaction()
                End Select
            Catch ex As Exception
                _cCustomMsg.ErrorMessage(ex)
            End Try
        End Sub

        Private Sub removeOthersDrTransaction()
            Try
                Dim drModel As New DeliveryReciptModel
                Dim result As Boolean
                Dim drListData = FDRLIST2.lvl_drList

                If Not _data.rs_no.ToUpper() = cNotApplicable Then
                    result = drModel.executeDeleteOthersOrInWithOrWithoutDrAndRs(_data, False)
                End If

                If result Then
                    Dim index As Integer = func_get_listview_rowindex(drListData, _data.dr_item_id)
                    drListData.Items.RemoveAt(index)
                Else
                    _cCustomMsg.message("error", "there is something wrong in deleting data...", "SMS INFO:")
                End If
            Catch ex As Exception
                _cCustomMsg.ErrorMessage(ex)
            End Try
        End Sub

        Private Sub removeDrStockToStockpileTransaction()
            Try
                Dim drModel As New DeliveryReciptModel
                Dim result As Boolean
                Dim drListData = FDRLIST2.lvl_drList

                If Not _data.rs_no.ToUpper() = cNotApplicable And _data.inout = cInOut._OUT Then
                    result = drModel.executeDeleteStockpileToStockpileDrNew(_data, _datas)
                End If

                If result Then
                    For Each row In _datas
                        Dim index As Integer = func_get_listview_rowindex(drListData, row.dr_item_id)
                        drListData.Items.RemoveAt(index)
                    Next
                Else
                    _cCustomMsg.message("error", "there is something wrong in deleting data or you must select the OUT transaction...", "SMS INFO:")
                End If
            Catch ex As Exception
                _cCustomMsg.ErrorMessage(ex)
            End Try
        End Sub

        Private Sub removeInDrTransaction()
            Try
                Dim drModel As New DeliveryReciptModel
                Dim result As Boolean
                Dim drListData = FDRLIST2.lvl_drList

                If Not _data.rs_no.ToUpper() = cNotApplicable Then
                    result = drModel.executeDeleteOthersOrInWithOrWithoutDrAndRs(_data, False)
                End If

                If result Then
                    Dim index As Integer = func_get_listview_rowindex(drListData, _data.dr_item_id)
                    drListData.Items.RemoveAt(index)
                Else
                    _cCustomMsg.message("error", "there is something wrong in deleting data...", "SMS INFO:")
                End If
            Catch ex As Exception
                _cCustomMsg.ErrorMessage(ex)
            End Try
        End Sub
    End Class
End Class

