

Imports SUPPLY.pubEnum

Public Interface IAggregatesPrices
    Sub InitializeDatas()
    Sub Search()
    Sub LoadSuccessfully()
    Sub Preview()
    Function getData() As List(Of PropsFields.PROPS_AGG_PRICES)
    Sub ClosedAndDisposed()

    Sub resetStorage()


End Interface

Public Interface IAddUpdateDelete
    Property isSaved As Boolean
    Property isUpdate As Boolean
    Property isRemoved As Boolean
    Sub addData(datas As PropsFields.PROPS_AGG_PRICES)
    Sub updateData(id As Integer, datas As PropsFields.PROPS_AGG_PRICES)
    Sub deleteData(id As Integer)

End Interface

Public Interface IShowBox
    Sub show()
    Sub hide()

    Sub getAutoSuggestData()

End Interface

Public Class FAggregatesPrices

    Implements IAggregatesPrices, IAddUpdateDelete, IShowBox
    Private cCustomMsg As New customMessageBox
    Private cListOfAggZoningPrices As New List(Of PropsFields.PROPS_AGG_PRICES)
    Private cAggPricesModel, cAllChargesModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Dim cLoading As New ColumnValuesObj
    Private customDgv As New CustomGridview
    Public forViewing As Boolean = True
    Public forGetListOfZoningPrices As Boolean
    Public cWhId As Integer
    Public zoningAreaUI, zoningAreaSourceUI, priceUI As New class_placeholder5
    Dim cShowHide As New ColumnValuesObj
    Public data As New PropsFields.PROPS_AGG_PRICES
    Private aggPricingId As Integer
    Private cIsSaved, cIsUpdate, cIsRemoved As Boolean
    Private cn As New PropsFields.PROPS_AGG_PRICES

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Public ReadOnly Property GetListOfZoningPrices() As List(Of PropsFields.PROPS_AGG_PRICES)
        Get
            Return cListOfAggZoningPrices
        End Get
    End Property

    Sub New(Optional wh_id As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        initializeUI()

        cWhId = wh_id
        InitializeDatas()

        customDgv.customDatagridview(DataGridView1, "#011526", 42)
        customDgv.autoSizeColumn(DataGridView1, True)

    End Sub

    Public Property isSaved As Boolean Implements IAddUpdateDelete.isSaved
        Get
            Return cIsSaved
        End Get
        Set(value As Boolean)
            cIsSaved = value
        End Set
    End Property

    Public Property isUpdate As Boolean Implements IAddUpdateDelete.isUpdate
        Get
            Return cIsUpdate
        End Get
        Set(value As Boolean)
            cIsUpdate = value
        End Set
    End Property

    Public Property isRemoved As Boolean Implements IAddUpdateDelete.isRemoved
        Get
            Return cIsRemoved
        End Get
        Set(value As Boolean)
            cIsRemoved = value
        End Set
    End Property

    Public Sub initializeUI()
        Try
            zoningAreaUI.king_placeholder_textbox("Search Zoning Area", txtZoningArea, Nothing, panelBox, My.Resources.received, False, zoningAreaUI.cCustomColor.Custom1)
            zoningAreaSourceUI.king_placeholder_textbox("Search Zoning Area Source", txtZoningSource, Nothing, panelBox, My.Resources.received, False, zoningAreaSourceUI.cCustomColor.Custom1)

            priceUI.king_placeholder_textbox("Prices", txtPrices, Nothing, panelBox, My.Resources.received, True, zoningAreaUI.cCustomColor.Custom1)

            zoningAreaUI.tbox.ReadOnly = True
            zoningAreaSourceUI.tbox.ReadOnly = True

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub InitializeDatas() Implements IAggregatesPrices.InitializeDatas
        Try
            cAggPricesModel.clearParameter()
            cAllChargesModel.clearParameter()
            cListOfAggZoningPrices.Clear()

            'DataGridView1.Rows.Clear()
            cLoading.clearParameter()

            cLoading.add("loadingPanel", loadingPanel)
            disableEnableWhileLoading(cLoading.getValues(), False)

            Dim c As New ColumnValues

            _initializing(cCol.forAggPrices,
                          c.getValues(),
                          cAggPricesModel,
                          aggPricesBgWorker)

            _initializing(cCol.forAllCharges,
                          c.getValues(),
                          cAllChargesModel,
                          aggPricesBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf LoadSuccessfully, aggPricesBgWorker)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub LoadSuccessfully() Implements IAggregatesPrices.LoadSuccessfully
        Try
            Results.rListOfAggPrices = TryCast(cAggPricesModel.cData, List(Of PropsFields.aggregatesPrices_props_fields))
            Results.rListOfAllCharges = TryCast(cAllChargesModel.cData, List(Of PropsFields.AllCharges))

            If forViewing Then

                PreviewResult()
                disableEnableWhileLoading(cLoading.getValues(), True)

            ElseIf forGetListOfZoningPrices Then
                PreviewResult()
            End If


        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub PreviewResult() Implements IAggregatesPrices.Preview
        Try
            For Each row In Results.rListOfAggPrices.Where(Function(x) x.wh_id = cWhId).ToList()

                Dim zoningPrices As New PropsFields.PROPS_AGG_PRICES
                Dim zoningSourceCategory As String = IIf(row.zoning_source_category IsNot Nothing,
                                                         row.zoning_source_category, "")

                Dim zoningArea = Results.rListOfAllCharges.Where(Function(x)
                                                                     Return x.charges_id = row.zoning_area_id And
                                                                     x.charges_category.ToUpper() = row.zoning_area_category.ToUpper()
                                                                 End Function).ToList()

                Dim zoningSource = Results.rListOfAllCharges.Where(Function(x)


                                                                       Return x.charges_id = row.zoning_source_id And
                                                                     x.charges_category.ToUpper() = zoningSourceCategory.ToUpper()
                                                                   End Function).ToList()
                With zoningPrices
                    .aggPricingId = row.aggPricingId
                    .zoning_price = FormatNumber(row.zoning_price).ToString()

                    'zoning area
                    If zoningArea.Count > 0 Then
                        .zoning_area = zoningArea(0).charges
                        .zoning_area_category = row.zoning_area_category
                        .zoning_area_id = row.zoning_area_id
                    End If


                    'zoning source
                    If zoningSource.Count > 0 Then
                        .zoning_source = zoningSource(0).charges
                        .zoning_source_category = zoningSourceCategory
                        .zoning_source_id = row.zoning_source_id
                    End If


                End With

                cListOfAggZoningPrices.Add(zoningPrices)
            Next

            If forViewing Then
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = cListOfAggZoningPrices
                setCustomGridview(DataGridView1)

                If isSaved = True AndAlso isUpdate = False Then
                    Utilities.datagridviewSpecificRowFocus(DataGridView1, aggPricingId, NameOf(data.aggPricingId))
                Else
                    Utilities.datagridviewSpecificRowFocus(DataGridView1, aggPricingId, NameOf(data.aggPricingId))
                End If
            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        Finally
            isSaved = True
        End Try
    End Sub

    Private Sub setCustomGridview(Optional dgv As DataGridView = Nothing)
        Try
            With customDgv
                If dgv.Rows.Count > 0 Then

                    .readOnlyCells(NameOf(PropsFields.PROPS_AGG_PRICES.zoning_area), dgv)
                    .readOnlyCells(NameOf(PropsFields.PROPS_AGG_PRICES.zoning_price), dgv)

                    'hide columns

                    For Each col As DataGridViewColumn In dgv.Columns
                        If col.Name = NameOf(cn.wh_id) Or
                            col.Name = NameOf(cn.aggPricingId) Or
                            col.Name = NameOf(cn.zoning_area_id) Or
                            col.Name = NameOf(cn.zoning_area_category) Or
                            col.Name = NameOf(cn.zoning_source_category) Or
                            col.Name = NameOf(cn.zoning_source_id) Then

                            col.Visible = False
                        Else
                            col.Visible = True
                        End If
                    Next

                    'rename columns
                    dgv.Columns(NameOf(cn.zoning_price)).HeaderText = "PRICE (ZONING)"
                    dgv.Columns(NameOf(cn.zoning_source)).HeaderText = "SOURCE AREA"
                    dgv.Columns(NameOf(cn.zoning_area)).HeaderText = "DESTINATION AREA"

                    dgv.ReadOnly = True
                End If
            End With

            With dgv.Columns

                .Item(NameOf(cn.zoning_area_category)).DisplayIndex = 0
                .Item(NameOf(cn.zoning_source)).DisplayIndex = 1
                .Item(NameOf(cn.zoning_area)).DisplayIndex = 2
                .Item(NameOf(cn.zoning_price)).DisplayIndex = 3

            End With
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

#Region "GET/SEARCH"
    Public Sub Search() Implements IAggregatesPrices.Search
        Throw New NotImplementedException()
    End Sub

    Public Function getData() As List(Of PropsFields.PROPS_AGG_PRICES) Implements IAggregatesPrices.getData
        Try
            Return cListOfAggZoningPrices

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function

#End Region

#Region "OTHERS"
    Private Sub CloseAndDisposed() Implements IAggregatesPrices.ClosedAndDisposed
        Me.Dispose()
    End Sub

    Private Sub showBox() Implements IShowBox.show
        Try
            cShowHide.clearParameter()
            cShowHide.add("loadingPanel", panelBox)
            cShowHide.add(GetType(DataGridView).ToString, DataGridView1)

            disableEnableWhileLoading(cShowHide.getValues(), False)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub resetStorage() Implements IAggregatesPrices.resetStorage
        Try
            isUpdate = False
            isSaved = False
            isRemoved = False
            data = New PropsFields.PROPS_AGG_PRICES
            btnAdd.Text = "Add Zoning Prices"
            aggPricingId = 0

            zoningAreaUI.tbox.Clear()
            zoningAreaUI.tbox.Text = zoningAreaUI.placeHolder
            zoningAreaUI.resetBgColor()

            zoningAreaSourceUI.tbox.Clear()
            zoningAreaSourceUI.tbox.Text = zoningAreaSourceUI.placeHolder
            zoningAreaSourceUI.resetBgColor()

            priceUI.tbox.Clear()
            priceUI.tbox.Text = priceUI.placeHolder
            priceUI.resetBgColor()

            zoningAreaUI.tbox.Focus()

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub hideBox() Implements IShowBox.hide
        Try
            disableEnableWhileLoading(cShowHide.getValues(), True)
            resetStorage()

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub autoSuggestData() Implements IShowBox.getAutoSuggestData
        Try
            Dim list As New List(Of String)
            For Each agg In Results.rListOfAllCharges
                list.Add(agg.charges)
            Next

            zoningAreaUI.AutoCompleteData = list
            zoningAreaUI.set_autocomplete()

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub clearAllStorage()
        'Private cListOfAggZoningPrices As New List(Of PropsFields.PROPS_AGG_PRICES)
        'Private cAggPricesModel, cAllChargesModel As New ModelNew.Model
        'Dim cBgWorkerChecker As Timer
        'Dim cLoading As New ColumnValuesObj
        'Private customDgv As New CustomGridview
        'Public forViewing As Boolean = True
        'Public cWhId As Integer = 14982
        'Public searchUI, priceUI As New class_placeholder5
        'Dim cShowHide As New ColumnValuesObj
        'Public data As New PropsFields.PROPS_AGG_PRICES


    End Sub
#End Region

#Region "ADD/UPDATE/DELETE"
    Private Sub addData(datas As PropsFields.PROPS_AGG_PRICES) Implements IAddUpdateDelete.addData
        Try
            Dim insert As New ColumnValuesObj
            insert.add(NameOf(data.wh_id), datas.wh_id)
            insert.add(NameOf(data.zoning_price), datas.zoning_price)
            insert.add(NameOf(data.zoning_area_category), datas.zoning_area_category)
            insert.add(NameOf(data.zoning_area_id), datas.zoning_area_id)
            insert.add(NameOf(data.zoning_source_category), datas.zoning_source_category)
            insert.add(NameOf(data.zoning_source_id), datas.zoning_source_id)

            aggPricingId = insert.insertQuery_and_return_id("dbAggregatesPrices")

            If aggPricingId > 0 Then
                cCustomMsg.message("info", "Successfully inserted...", "SUPPLY INFO:")
                isSaved = True
                InitializeDatas()

            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub updateData(id As Integer, datas As PropsFields.PROPS_AGG_PRICES) Implements IAddUpdateDelete.updateData

        Try
            Dim update As New ColumnValuesObj
            update.add(NameOf(data.wh_id), datas.wh_id)
            update.add(NameOf(data.zoning_price), datas.zoning_price)
            update.add(NameOf(data.zoning_area_category), datas.zoning_area_category)
            update.add(NameOf(data.zoning_area_id), datas.zoning_area_id)
            update.add(NameOf(data.zoning_source_category), datas.zoning_source_category)
            update.add(NameOf(data.zoning_source_id), datas.zoning_source_id)

            update.setCondition($"{NameOf(data.aggPricingId)} = {id}")

            update.updateQuery("dbAggregatesPrices")
            cCustomMsg.message("info", "Successfully updated...", "SUPPLY INFO:")

            btnAdd.Text = "Add Zoning Prices"

            isSaved = True
            InitializeDatas()

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub


    Private Sub deleteData(id As Integer) Implements IAddUpdateDelete.deleteData
        Try
            Dim delete As New ColumnValuesObj
            delete.setCondition($"{NameOf(data.aggPricingId)} = {id}")
            delete.deleteData("dbAggregatesPrices")

            isRemoved = True

            cListOfAggZoningPrices = cListOfAggZoningPrices.Where(Function(x) x.aggPricingId <> id).ToList()
            DataGridView1.DataSource = Nothing

            If cListOfAggZoningPrices.Count > 0 Then
                DataGridView1.DataSource = cListOfAggZoningPrices
                setCustomGridview(DataGridView1)
            End If


        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub


    Private Sub FAggregatesPrices_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            'filter
            'Add Zoning Prices
#Region "FILTER"

            If data.zoning_area_category IsNot Nothing Then


                Dim filterSource = cListOfAggZoningPrices.Where(Function(x)
                                                                    Return x.zoning_source_category?.ToUpper() = data.zoning_source_category.ToUpper() And
                                                              x.zoning_source_id = data.zoning_source_id
                                                                End Function).ToList()

                Dim filterDestination = cListOfAggZoningPrices.Where(Function(x)
                                                                         Return x.zoning_area_category?.ToUpper() = data.zoning_area_category.ToUpper() And
                                                              x.zoning_area_id = data.zoning_area_id
                                                                     End Function).ToList()
                If Not isUpdate Then
                    If filterSource.Count > 0 And filterDestination.Count > 0 Then
                        cCustomMsg.message("error", "this zoning area already in the list....", "SUPPLY INFO:")
                        Exit Sub
                    End If
                End If

                If priceUI.tbox.Text = priceUI.placeHolder Then
                    cCustomMsg.message("error", "please input a price first...", "SUPPLY INFO:")
                    Exit Sub
                End If

                If data.zoning_area_id = 0 Then
                    cCustomMsg.message("error", "you must select a zoning area first...", "SUPPLY INFO:")
                    Exit Sub
                End If
            Else
                cCustomMsg.message("error", "you must select a zoning area first...", "SUPPLY INFO:")
                Exit Sub
            End If

#End Region

            If cCustomMsg.messageYesNo($"Are you sure you want {IIf(isUpdate = False, "add", "update")} this data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                With data
                    .wh_id = cWhId
                    .zoning_price = txtPrices.Text
                End With

                If isUpdate = False Then
                    addData(data)
                Else
                    aggPricingId = Utilities.datagridviewSelectId(DataGridView1, NameOf(data.aggPricingId))
                    updateData(aggPricingId, data)
                End If

            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim f As New FCharge_To
        f.forZoning = True
        f.ShowDialog()
    End Sub

    Private Sub FAggregatesPrices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox5.Location = New Point(Label2.Location.X + Label2.Width + 10, Label2.Location.Y - Label2.Height)

        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel1)
        myPanel.addPanel(Panel4)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim f As New FCharge_To
        f.forWhItemsProjectSiteAndOthers = False
        f.forZoningSource = True
        f.ShowDialog()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim edit = cListOfAggZoningPrices.Where(Function(x)
                                                        Return x.aggPricingId = DataGridView1.SelectedRows(0).Cells(NameOf(data.aggPricingId)).Value
                                                    End Function).ToList()

            If edit.Count > 0 Then
                With data
                    'zoning area
                    .zoning_area_category = edit(0).zoning_area_category
                    .zoning_area_id = edit(0).zoning_area_id
                    txtZoningArea.Text = edit(0).zoning_area
                    zoningAreaUI.resetBgColor()

                    'zoning source
                    .zoning_source_category = edit(0).zoning_source_category
                    .zoning_source_id = edit(0).zoning_source_id
                    txtZoningSource.Text = edit(0).zoning_source
                    zoningAreaSourceUI.resetBgColor()

                    'price
                    .zoning_price = edit(0).zoning_price
                    txtPrices.Text = edit(0).zoning_price
                    priceUI.resetBgColor()

                    btnAdd.Text = "Update Zoning Price"
                    isUpdate = True
                End With
            End If

            showBox()
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub



#End Region

#Region "EVENTS"
    Private Sub AddPricesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPricesToolStripMenuItem.Click
        showBox()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click

        If cCustomMsg.messageYesNo("Are you sure you want to remove this data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then

            aggPricingId = Utilities.datagridviewSelectId(DataGridView1, NameOf(data.aggPricingId))
            deleteData(aggPricingId)
        End If



    End Sub

    Private Sub btn_paneLExt_Click(sender As Object, e As EventArgs) Handles btn_paneLExt.Click
        hideBox()
    End Sub
#End Region




End Class