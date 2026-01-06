Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Web.UI.WebControls
Imports System.Windows.Interop

Public Class FCreateDeliveryReceipt
    Dim c As New CustomizedFields
    Private supplierModel, employeeModel, equipmentModel, driverModel, AllChargesModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer

    Private searchUI As New class_placeholder5
    Private whItemsModel As New ModelNew.Model
    Private cSearch As String
    Private customDgv As New CustomGridview
    Public cStockpileOut As New ITEMS
    Public cStockpileIn As New ITEMS
    Public cStockpileIn_storage As New ITEMS

    Public cCrusherFeed As New ITEMS

    Private cCustomMsg As New customMessageBox
    Private cEdit As Boolean
    Private cEditedData As New List(Of PropsFields.create_dr_props_fields)
    Private cListOfPendingDr As New List(Of PropsFields.create_dr_props_fields)
    Private cReleasedQty As Double
    Private cDeliveredQty As Double
    Public cTypeOfPurchasing1 As String
    Public cOpened As Boolean
    Public cWithDr As Boolean
    Public cDrOption As Integer

    Private AggregatesPrices As New FAggregatesPrices
    Private cFchargeTo As New FCharge_To
    Private cn As New PropsFields.create_dr_props_fields

    Public cTransaction As String
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Public Class ITEMS
        Public Property wh_id As Integer
        Public Property itemName As String
        Public Property stockpile As String
        Public Property quarry As String
        Public Property charges As String
        Public Property typeOfPurchasing As String
        Public Property supplier As String
        Public Property rs_id As Integer
        Public Property wsNoRrNo As String
        Public Property rsNo As String
        Public Property withDR As Boolean
        Public Property units As String
        Public Property defaultPrice As Double
        Public Property specificLocation As String

    End Class

    Public Class TRANSACTION_STATUS
        Public Property transaction As String
        Public Property requestor As String
        Public Property stockpile As String
        Public Property items As String

        Public Property quarry As String
    End Class

    Public Enum Transaction
        ws_dr 'withdrawal with dr stock to projects <-- type of purchasing: WITHDRAWAL
        ws_dr_sts 'withdrawal with dr but stockpile to stockpile <-- type of purchasing: WITHDRAWAL
        po_rr_dr 'po and rr with dr <-- type of purchasing: PURCHASE ORDER 
        rs_dr 'rs and dr <-- type of purchasing: DR
        rsNa_wsNa_dr 'out without rs
    End Enum

    Public Property ReleasedQty As Double
        Get
            Return cReleasedQty
        End Get
        Set(value As Double)
            cReleasedQty = value
        End Set
    End Property

    Public Property DeliveredQty As Double
        Get
            Return cDeliveredQty
        End Get
        Set(value As Double)
            cDeliveredQty = value
        End Set
    End Property

    Public ReadOnly Property GetAggregatesPrices As FAggregatesPrices
        Get
            Return AggregatesPrices
        End Get

    End Property

    Public ReadOnly Property GetFChargeToForm As FCharge_To
        Get
            Return cFchargeTo
        End Get

    End Property

    Public ReadOnly Property ListOfPendingDr As List(Of PropsFields.create_dr_props_fields)
        Get
            Return cListOfPendingDr
        End Get

    End Property
    Private Sub FCreateDeliveryReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            whItemsModel.clearParameter()
            Dim dic As New Dictionary(Of String, Object)

            dic.Add("panel", Panel8)
            dic.Add("panelBox", Panel12)
            dic.Add("icon", My.Resources.received)

            c.initializeOptions(dic)

            c.addCustomizeTextBox(txtPlateNo, "Plate No...")
            c.addCustomizeTextBox(txtDriver, "Driver/Operator...")
            c.addCustomizeTextBox(txtSupplier, "Supplier...")
            c.addCustomizeTextBox(txtConsession, "Concession...")
            c.addCustomizeTextBox(txtRemarks, "Remarks...")
            c.addCustomizeTextBox(txtCheckedBy, "Checked By...")
            c.addCustomizeTextBox(txtReceivedBy, "Received By...")
            c.addCustomizeTextBox(txtPrice, "Prices...", True,,, True)
            c.addCustomizeTextBox(txtDrQty, "Dr Qty...", True)
            c.addCustomizeTextBox(txtDrNo, "Dr No...")

            c.addCustomizeDatePicker(dtpDrDate, "")
            c.addCustomizeDatePicker(dtpDateSubmitted, "")

            c.addCustomizeComboBox(cmbDrOptions, "Dr options...")

            c.runByBatch()

            searchUI.king_placeholder_textbox("Search Items...",
                                              txtSearchItems,
                                              Nothing, Panel11,
                                              My.Resources.received,
                                              False,
                                              searchUI.cCustomColor.Custom1)

            'zero lng sa ang price for default
            txtPrice.Text = 0
            c.resetUIBackground(txtPrice.Name)

#Region "AGGREGATES PRICING"
            Dim whId As Integer
            If cTypeOfPurchasing1 = cTypeOfPurchasing.WITHDRAWAL Then
                whId = cStockpileOut.wh_id

            ElseIf cTypeOfPurchasing1 = cTypeOfPurchasing.PURCHASE_ORDER Or
                cTypeOfPurchasing1 = cTypeOfPurchasing.DR Then

                whId = cStockpileIn.wh_id
            End If

            AggregatesPrices.forViewing = False
            AggregatesPrices = New FAggregatesPrices(whId)

#End Region


            loadSomeData()

            customDgv.customDatagridview(DataGridView1, "#011526", 42)
            customDgv.customDatagridview(DataGridView2, "#20242C", 24)

            lblItems.Location = New Point(Panel17.Location.X + Panel17.Width, Panel17.Location.Y + 25)
            Panel19.Location = New Point(lblItems.Location.X + lblItems.Width + 20, Panel17.Location.Y)
            Panel18.Location = New Point(Panel19.Location.X + Panel19.Width, Panel19.Location.Y)

            'movable panel
            Dim myPanel As New MovablePanel
            myPanel.addPanel(Panel1)
            myPanel.addPanel(Panel10)

            myPanel.initializeForm(Me)
            myPanel.addPanelEventHandler()

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub loadSomeData()
        Try
            supplierModel.clearParameter()
            employeeModel.clearParameter()
            equipmentModel.clearParameter()
            driverModel.clearParameter()
            whItemsModel.clearParameter()
            AllChargesModel.clearParameter()

            Dim cv As New ColumnValues

            'loadingPanel.Visible = True
            enableDisableWhileInitializingData(True)

            _initializing(cCol.forSupplier,
                      cv.getValues(),
                      supplierModel,
                      createWithdrawalBgWorker)

            _initializing(cCol.forEmployees,
                      cv.getValues(),
                      employeeModel,
                      createWithdrawalBgWorker)

            _initializing(cCol.forWhItems,
                      cv.getValues(),
                      whItemsModel,
                      createWithdrawalBgWorker)

            _initializing(cCol.forPlateNo,
                          cv.getValues(),
                          equipmentModel,
                          createWithdrawalBgWorker)

            _initializing(cCol.forOperatorDriver,
                          cv.getValues(),
                          driverModel,
                          createWithdrawalBgWorker)

            _initializing(cCol.forAllCharges,
                        cv.getValues(),
                        AllChargesModel,
                        createWithdrawalBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, createWithdrawalBgWorker)


        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub SuccessfullyDone()
        Try
            Results.cListOfSupplier = CType(supplierModel.cData, List(Of PropsFields.supplier_props_fields))
            Results.cListOfEmployees = CType(employeeModel.cData, List(Of PropsFields.employee_props_fields))
            Results.cResult = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            Results.cListOfEquipments = CType(equipmentModel.cData, List(Of PropsFields.equipment_props_fields))
            Results.cListOfOperatorDriver = CType(driverModel.cData, List(Of PropsFields.operator_driver_props_fields))
            Results.rListOfAllCharges = CType(AllChargesModel.cData, List(Of PropsFields.AllCharges))


            enableDisableWhileInitializingData(False)

            lblWithdrawn.Text = cReleasedQty
            lblDelivered.Text = cDeliveredQty

            If cTransaction = cCrushingAndHaulingTransaction.STOCKPILE_TO_STOCKPILE Then
                txtRemarks.Text = "TRANSFER STOCKPILE"
                txtRemarks.ReadOnly = False

            End If

            loadSomeDataInTextBox()

            transactionAndBalanceStatus()

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub transactionAndBalanceStatus()
        Try

            Select Case cDrOption
                Case DROptions.in_with_rs_po_rr

                    If cStockpileIn IsNot Nothing Then
                        Dim whItemDatas = Results.cResult.FirstOrDefault(Function(x) x.wh_id = cStockpileIn.wh_id)

                        Dim transactionstatus As New TRANSACTION_STATUS

                        With transactionstatus
                            .transaction = transactionLabel(cStockpileIn.typeOfPurchasing, cStockpileIn.wsNoRrNo)
                            .requestor = requestorLabel(cStockpileIn.charges)
                            .stockpile = sourceLabel(cStockpileIn.supplier)
                            .items = itemLabel(whItemDatas.item_desc)
                        End With

                        _transactionStatus(transactionstatus)
                    End If

                    CheckBox1.Enabled = False

                Case DROptions.in_without_rs

                    If cStockpileIn IsNot Nothing Then

                        Dim whItemDatas = Results.cResult.FirstOrDefault(Function(x) x.wh_id = cStockpileIn.wh_id)

                        Dim transactionstatus As New TRANSACTION_STATUS
                        With transactionstatus
                            .transaction = transactionLabel(cStockpileIn.typeOfPurchasing, "IN WITHOUT RS")
                            .requestor = requestorLabel(whItemDatas.warehouse_area)
                            .stockpile = "waiting..." 'sourceLabel(whItemDatas.warehouse_area)
                            .quarry = quarryLabel(whItemDatas.quarry)
                            .items = itemLabel(whItemDatas.item_desc)
                        End With

                        _transactionStatus(transactionstatus)

                    End If

                    CheckBox1.Enabled = False

                Case DROptions.out_with_rs

                    If cStockpileOut IsNot Nothing Then

                        Dim whItemDatas = Results.cResult.FirstOrDefault(Function(x) x.wh_id = cStockpileOut.wh_id)

                        Dim transactionstatus As New TRANSACTION_STATUS
                        With transactionstatus
                            .transaction = transactionLabel(cStockpileOut.typeOfPurchasing, cStockpileOut.wsNoRrNo)
                            .requestor = requestorLabel(cStockpileOut.charges)
                            .stockpile = sourceLabel(whItemDatas.warehouse_area)
                            .quarry = quarryLabel(whItemDatas.quarry)
                            .items = itemLabel(whItemDatas.item_desc)
                        End With

                        _transactionStatus(transactionstatus)

                    End If

                    If cTransaction = cCrushingAndHaulingTransaction.STOCKPILE_TO_STOCKPILE Then
                        CheckBox1.Checked = True
                        CheckBox1.Enabled = False
                    Else
                        CheckBox1.Enabled = False
                        CheckBox1.Checked = False
                    End If

                Case DROptions.out_without_rs

                    If cStockpileOut IsNot Nothing Then

                        Dim whItemDatas = Results.cResult.FirstOrDefault(Function(x) x.wh_id = cStockpileOut.wh_id)

                        Dim transactionstatus As New TRANSACTION_STATUS
                        With transactionstatus
                            'transaction
                            Dim transaction As String = ""
                            If cStockpileIn IsNot Nothing Then
                                transaction = transactionLabel(cStockpileIn.typeOfPurchasing, "OUT WITHOUT RS")
                            End If

                            .transaction = transaction
                            .requestor = requestorLabel(cStockpileOut.charges)
                            .stockpile = sourceLabel(whItemDatas.warehouse_area)
                            .quarry = quarryLabel(whItemDatas.quarry)
                            .items = itemLabel(whItemDatas.item_desc)

                        End With

                        _transactionStatus(transactionstatus)

                    End If

                    CheckBox1.Enabled = False

                Case DROptions.others_without_rs

                    If cStockpileIn IsNot Nothing Then

                        Dim whItemDatas = Results.cResult.FirstOrDefault(Function(x) x.wh_id = cStockpileIn.wh_id)

                        Dim transactionstatus As New TRANSACTION_STATUS
                        With transactionstatus
                            'transaction
                            Dim transaction As String = ""
                            If cStockpileIn IsNot Nothing Then
                                transaction = transactionLabel(cStockpileIn.typeOfPurchasing,
                                                               "OTHERS WITHOUT RS")
                            End If

                            .transaction = transaction
                            .requestor = requestorLabel(cStockpileIn.charges)
                            .stockpile = sourceLabel(cStockpileIn.stockpile)
                            .quarry = quarryLabel(cStockpileIn.quarry)
                            .items = itemLabel(whItemDatas.item_desc)

                        End With

                        _transactionStatus(transactionstatus)

                    End If

                    CheckBox1.Enabled = False

                Case DROptions.others_with_rs, DROptions.in_with_rs
                    If cStockpileIn IsNot Nothing Then
                        Dim whItemDatas = Results.cResult.FirstOrDefault(Function(x) x.wh_id = cStockpileIn.wh_id)

                        Dim transactionstatus As New TRANSACTION_STATUS

                        With transactionstatus
                            .transaction = transactionLabel(cStockpileIn.typeOfPurchasing, cStockpileIn.wsNoRrNo)
                            .requestor = requestorLabel(whItemDatas.warehouse_area) 'requestorLabel(cStockpileIn.charges)
                            .stockpile = sourceLabel(whItemDatas.warehouse_area)
                            .items = itemLabel(whItemDatas.item_desc)

                            If cTransaction = cCrushingAndHaulingTransaction.QUARRY_TO_STOCKPILE Then
                                .requestor = requestorLabel(whItemDatas.warehouse_area)
                                .quarry = quarryLabel(whItemDatas.quarry)
                                .stockpile = "-"

                            ElseIf cTransaction = cCrushingAndHaulingTransaction.QUARRY_TO_PROJECT Then
                                .requestor = requestorLabel(cStockpileIn.charges)
                                .quarry = quarryLabel(whItemDatas.quarry)
                                .stockpile = "-"

                            ElseIf cTransaction = cCrushingAndHaulingTransaction.WASTE_DISPOSAL_AND_OTHERS Then

                                .requestor = requestorLabel(cStockpileIn.charges)
                                .quarry = "-"
                                .stockpile = sourceLabel(Results.rListOfAllCharges.FirstOrDefault(Function(x)
                                                                                                      Return x.charges_category.ToUpper() = whItemDatas.whArea_category.ToUpper() And
                                                                                          x.charges_id = whItemDatas.wh_area_id
                                                                                                  End Function).charges)
                            End If

                        End With

                        _transactionStatus(transactionstatus)
                    End If

                    CheckBox1.Enabled = False

                Case DROptions.in_with_rs
                    MsgBox("coming soon...")
            End Select

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub _transactionStatus(transactionStatus As TRANSACTION_STATUS)
        Try

            lblTransaction.Text = transactionStatus.transaction

            'requestor
            lblRequestor.Text = transactionStatus.requestor

            'stockpile
            lblStockpile.Text = transactionStatus.stockpile

            'quarry
            lblQuarry.Text = transactionStatus.quarry

            'items
            lblItems.Text = transactionStatus.items

            CheckBox1.Enabled = False
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Function requestorLabel(requestor As String)
        Return $"REQUESTOR: {requestor}"
    End Function

    Private Function transactionLabel(typeOfPurchasing As String, wsRrNo As String)
        Return $"{typeOfPurchasing} ({wsRrNo})"
    End Function

    Private Function sourceLabel(source As String)
        Return $"SOURCE: {source}"
    End Function

    Private Function quarryLabel(quarry As String)
        Return $"QUARRY: {quarry}"
    End Function

    Private Function itemLabel(itemDesc As String)
        Return $"{itemDesc}"
    End Function

    Private Sub loadSomeDataInTextBox()
        Try
            Dim listOfEmployees As New List(Of String)
            For Each row In cListOfEmployees
                listOfEmployees.Add(row.employee)
            Next

            Dim listOfSupplier As New List(Of String)
            For Each row In cListOfSupplier
                listOfSupplier.Add(row.supplierName)
            Next

            Dim listOfEquipment As New List(Of String)
            For Each row In Results.cListOfEquipments
                listOfEquipment.Add(row.PlateNo)
            Next

            Dim listofdriver As New List(Of String)
            For Each row In Results.cListOfOperatorDriver
                listofdriver.Add(row.operator_name)
            Next

            For Each row In c.cListOfUIFields

                Select Case row.fieldsName
                    Case NameOf(txtCheckedBy)
                        c.automateList(listOfEmployees, txtCheckedBy)
                    Case NameOf(txtReceivedBy)
                        c.automateList(listOfEmployees, txtReceivedBy)
                    Case NameOf(txtDriver)
                        c.automateList(listofdriver, txtDriver)
                    Case NameOf(txtSupplier)
                        c.automateList(listOfSupplier, txtSupplier)
                    Case NameOf(txtPlateNo)
                        c.automateList(listOfEquipment, txtPlateNo)
                End Select

                'If row.fieldsName = NameOf(txtCheckedBy) Then
                '    c.automateList(listOfEmployees, txtCheckedBy)
                'ElseIf row.fieldsName = NameOf(txtDriver) Then
                '    c.automateList(listofdriver, txtDriver)
                'ElseIf row.fieldsName = NameOf(txtSupplier) Then
                '    c.automateList(listOfSupplier, txtSupplier)
                'ElseIf row.fieldsName = NameOf(txtPlateNo) Then
                '    c.automateList(listOfEquipment, txtPlateNo)
                'End If
            Next



            cmbDrOptions.Items.Add(cDrCategory.WITH_DR)
            cmbDrOptions.Items.Add(cDrCategory.WITHOUT_DR)

            If cWithDr = True Then
                cmbDrOptions.SelectedIndex = 0
                cmbDrOptions.Enabled = False
                txtPlateNo.Focus()
            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub setCustomGridview(Optional dgv As DataGridView = Nothing)
        Try
            With customDgv
                Dim columnWidth As Integer = 280

                If dgv.Name = NameOf(DataGridView2) Then
                    'readonly cells
                    If dgv.Rows.Count > 0 Then
                        dgv.ReadOnly = True

                        Dim _a As New PropsFields.whItems_props_fields

                        'hide columns
                        For Each col As DataGridViewColumn In dgv.Columns
                            If col.Name = NameOf(ITEMS.typeOfPurchasing) Or
                                col.Name = NameOf(ITEMS.supplier) Or
                                col.Name = NameOf(ITEMS.rs_id) Or
                                col.Name = NameOf(ITEMS.rsNo) Or
                                col.Name = NameOf(ITEMS.wsNoRrNo) Or
                                col.Name = NameOf(ITEMS.charges) Or
                                col.Name = NameOf(ITEMS.withDR) Or
                                col.Name = NameOf(ITEMS.defaultPrice) Or
                                col.Name = NameOf(ITEMS.units) Then

                                col.Visible = False
                            Else
                                col.Visible = True

                                'default column width
                                col.Width = columnWidth

                                'customize width
                                If col.Name = NameOf(ITEMS.wh_id) Then
                                    col.Width = 80
                                End If
                            End If
                        Next

                    End If

                Else
                    If dgv.Rows.Count > 0 Then
                        .subcustomDatagridviewSettings("ReadOnlyCells", dgv, 1)
                        .subcustomDatagridviewSettings("ReadOnlyCells", dgv, 1)
                        .subcustomDatagridviewSettings("ReadOnlyCells", dgv, 2)
                        .subcustomDatagridviewSettings("ReadOnlyCells", dgv, 3)
                        .subcustomDatagridviewSettings("ReadOnlyCells", dgv, 4)

                        Dim _b As New PropsFields.whItems_props_fields
                        'set color row
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            row.DefaultCellStyle.Font = New Font(New FontFamily(cFontsFamily.bombardier), 11, FontStyle.Regular)

                            If row.Cells(NameOf(_b.inout)).Value = "IN" Then
                                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DFEDD1")
                                row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#0E2930")
                            End If
                        Next

                        Dim v As New PropsFields.create_dr_props_fields

                        If cDrOption = DROptions.out_without_rs Then

                            For Each col As DataGridViewColumn In dgv.Columns
                                If col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.stockpileAreaId) Or
                                    col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.transaction) Or
                                    col.Name = NameOf(v.recepient_category) Or
                                    col.Name = NameOf(v.recepient_id) Or
                                    col.Name = NameOf(v.stockpile_recepient) Or
                                    col.Name = NameOf(v.stockpile_source) Then

                                    col.Visible = False
                                Else
                                    col.Visible = True

                                End If
                            Next

                            'rename header text
                            renameHeaderText(dgv)

                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.recepient_for_screening), 280, "RECEPIENT")
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.stockpile_source), 280, "SOURCE")

                        ElseIf cDrOption = DROptions.others_without_rs Or
                            cDrOption = DROptions.in_with_rs Or
                            cDrOption = DROptions.others_with_rs Then

                            For Each col As DataGridViewColumn In dgv.Columns
                                If col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.stockpileAreaId) Or
                                    col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.transaction) Or
                                    col.Name = NameOf(v.recepient_category) Or
                                    col.Name = NameOf(v.recepient_id) Or
                                    col.Name = NameOf(v.stockpile_source) Or
                                    col.Name = NameOf(v.recepient_for_screening) Or
                                    col.Name = NameOf(v.id) Then

                                    col.Visible = False
                                Else
                                    col.Visible = True

                                End If
                            Next
                            'rename header text
                            renameHeaderText(dgv)

                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.recepient_for_screening), 280, "SOURCE")
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.stockpile_recepient), 280, "RECEPIENT")

                        ElseIf cDrOption = DROptions.in_without_rs Then

                            For Each col As DataGridViewColumn In dgv.Columns
                                If col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.stockpileAreaId) Or
                                    col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.transaction) Or
                                    col.Name = NameOf(v.recepient_category) Or
                                    col.Name = NameOf(v.recepient_id) Or
                                    col.Name = NameOf(v.stockpile_source) Or
                                    col.Name = NameOf(v.id) Then

                                    col.Visible = False
                                Else
                                    col.Visible = True

                                End If
                            Next
                            'rename header text
                            renameHeaderText(dgv)

                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.recepient_for_screening), 280, "SOURCE")
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.stockpile_recepient), 280, "RECEPIENT")

                        Else

                            For Each col As DataGridViewColumn In dgv.Columns
                                If col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.stockpileAreaId) Or
                                    col.Name = NameOf(v.wh_id) Or
                                    col.Name = NameOf(v.transaction) Or
                                    col.Name = NameOf(v.recepient_category) Or
                                    col.Name = NameOf(v.recepient_id) Or
                                    col.Name = NameOf(v.recepient_for_screening) Then

                                    col.Visible = False
                                Else
                                    col.Visible = True

                                End If
                            Next

                            'rename header text
                            renameHeaderText(dgv)

                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.stockpile_source), 280, "STOCKPILE/PROJECT")
                            .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.stockpile_recepient), 280, "RECEPIENT")
                        End If

                    End If

                End If

                .autoSizeColumn(dgv, False)
            End With
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub
    Private Sub renameHeaderText(dgv As DataGridView)

        Try
            Dim v As New PropsFields.create_dr_props_fields
            With customDgv


                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.concession), 280, "CONCESSION")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.driver), 280, "DRIVER")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.checkedBy), 280, "CHECKED BY")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.date_submitted), 280, "DATE SUBMITTED")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.drNo), 70, "DR NO.")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.drQty), 70, "QTY")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.dr_date), 280, "DR DATE")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.plateNo), 180, "PLATE NO")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.price), 70, "PRICE")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.items), 280, "ITEMS/MATERIALS")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.supplier), 280, "SUPPLIER")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.inout), 280, "IN/OUT")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.remarks), 280, "REMARKS")
                .subcustomDatagridviewSettings2("headerText", dgv, NameOf(v.receivedBy), 280, "RECEIVED BY")


                If cDrOption = DROptions.in_without_rs Then
                    dgv.Columns(NameOf(cn.items)).Visible = False
                    dgv.Columns(NameOf(cn.stockpile_recepient)).Visible = False
                End If
            End With
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try


    End Sub

    Private Sub FCreateDeliveryReceipt_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            enable_disable(DisableEnable.enableFieldsAfterEdit)
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnReleaseNow.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnFinalSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.X Then
            Panel10.Visible = False
            Panel7.Enabled = True
            'panelBoxClose()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            showPanelBox()
        End If
    End Sub

    Private Function filterBlankFields() As Integer
        Try
            If c.cListOfUIFields.Count > 0 Then
                For Each row In c.cListOfUIFields
                    If row.fieldsName.Contains("txt") Then
                        If row.objFields.ifBlankTexbox() Then

                            If cEdit = True Then
                                If row.objFields.tbox.Name = NameOf(txtSupplier) Or
                                    row.objFields.tbox.Name = NameOf(txtRemarks) Then

                                Else
                                    If row.objFields.tbox.Enabled = True Then
                                        cCustomMsg.message("error", $"{row.objFields.tbox.Name} must not be blank...", "SUPPLY INFO:")
                                        filterBlankFields += 1
                                        row.objFields.tbox.Focus()
                                    End If
                                    Exit For
                                End If
                            Else
                                If row.objFields.tbox.Enabled = True Then
                                    cCustomMsg.message("error", $"{row.objFields.tbox.Name} must not be blank...", "SUPPLY INFO:")
                                    filterBlankFields += 1
                                    row.objFields.tbox.Focus()
                                End If
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If
            Return filterBlankFields
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Function

    ''' <summary>
    ''' This function retrieves the zoning price.
    ''' -- parameter is (destination, source)
    ''' </summary>
    ''' <returns>A specific zoning price from source to destination (type: double).</returns>
    Public Function getSpecificPrice(Optional zoningArea As String = "",
                                     Optional zoningSource As String = "") As Double
        Try
            Dim aggregates_prices = AggregatesPrices.getData()

            If aggregates_prices.Count > 0 Then
                Dim result = aggregates_prices.Where(Function(x)
                                                         If cTypeOfPurchasing1 = cTypeOfPurchasing.WITHDRAWAL Then
                                                             'zoning source
                                                             Dim newZoningSource As String = Utilities.ifNothingReplaceToBlank(x.zoning_source)

                                                             Return x.zoning_area.ToUpper() = zoningArea.ToUpper() And
                                                                                newZoningSource.ToUpper() = zoningSource.ToUpper()

                                                         ElseIf cTypeOfPurchasing1 = cTypeOfPurchasing.PURCHASE_ORDER Then
                                                             'zoning source
                                                             Dim newZoningSource As String = Utilities.ifNothingReplaceToBlank(x.zoning_source)

                                                             Return x.zoning_area.ToUpper() = zoningArea.ToUpper() And
                                                                                newZoningSource.ToUpper() = zoningSource.ToUpper()

                                                         ElseIf cTypeOfPurchasing1 = cTypeOfPurchasing.DR Then
                                                             'zoning source
                                                             Dim newZoningSource As String = Utilities.ifNothingReplaceToBlank(x.zoning_source)

                                                             Return x.zoning_area.ToUpper() = zoningArea.ToUpper() And
                                                                                newZoningSource.ToUpper() = zoningSource.ToUpper()
                                                         End If

                                                     End Function).ToList()

                If result.Count > 0 Then
                    getSpecificPrice = Utilities.ifBlankReplaceToZero(CType(result(0).zoning_price, Double))
                Else
                    cCustomMsg.message("warning", "The price has not yet been set for this area.", "SMS INFO:")
                End If
            Else
                cCustomMsg.message("warning", "zoning price has not been set yet!", "SMS INFO:")
            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Sub btnReleaseNow_Click(sender As Object, e As EventArgs) Handles btnReleaseNow.Click
        Try
            c.selectionStartToEnd()

#Region "FILTER HANDLING"
            'FOR ERROR MSG IF FIELDS IS EMPTY
            If filterBlankFields() > 0 Then
                Exit Sub
            End If

            Dim pedingDrs = cListOfPendingDr.Where(Function(x)
                                                       If x.drNo IsNot Nothing Then
                                                           Return x.drNo.ToUpper() = txtDrNo.Text.ToUpper()
                                                       End If
                                                   End Function).ToList()

            If pedingDrs.Count > 0 And cEdit = False And
                cmbDrOptions.Text = "WITH DR" Then

                cCustomMsg.message("error", $"{pedingDrs(0).drNo} is already in the list!", "SUPPLY INFO:")
                Exit Sub
            End If
#End Region

            If cEdit = True Then 'FOR EDIT

                If cCustomMsg.messageYesNo("Are you sure you want to update selected items?", "SUPPLY INFO:") Then
                    Dim selectedRow = DataGridView1.SelectedRows(0)
                    Dim id As Integer = selectedRow.Cells(NameOf(cn.id)).Value

                    Dim index As Integer = cListOfPendingDr.FindIndex(Function(x) x.id = cEditedData(0).id)

                    Dim sts = cListOfPendingDr.Where(Function(x) x.drNo = cEditedData(0).drNo).ToList()

                    With cListOfPendingDr(index)

                        .drNo = txtDrNo.Text
                        .concession = txtConsession.Text
                        .date_submitted = dtpDateSubmitted.Text
                        .dr_date = dtpDrDate.Text
                        .checkedBy = txtCheckedBy.Text
                        .receivedBy = txtReceivedBy.Text
                        .drQty = txtDrQty.Text
                        .price = txtPrice.Text
                        .plateNo = txtPlateNo.Text
                        .driver = txtDriver.Text
                        .remarks = txtRemarks.Text

                    End With

                    'for stockpile to stockpile
                    If sts.Count = 2 Then

                        With cListOfPendingDr(index + 1)
                            .drNo = txtDrNo.Text
                            .concession = txtConsession.Text
                            .date_submitted = dtpDateSubmitted.Text
                            .dr_date = dtpDrDate.Text
                            .checkedBy = txtCheckedBy.Text
                            .receivedBy = txtReceivedBy.Text
                            .drQty = txtDrQty.Text
                            .price = txtPrice.Text
                            .plateNo = txtPlateNo.Text
                            .driver = txtDriver.Text
                            .wh_id = cStockpileIn.wh_id
                            .stockpile_recepient = cStockpileIn.stockpile
                            .remarks = txtRemarks.Text
                        End With

                    End If
                    'end for stockpile to stockpile

                    enable_disable(DisableEnable.enableFieldsAfterEdit)

                    resetAfterUpdateOrSave()

                    setCustomGridview(DataGridView1)

                    focusAfterEdit(id)
                End If

            Else 'FOR ADDING TO TEMP ROW

#Region "FILTER HANDLING"
                If cStockpileIn_storage.wh_id = 0 And CheckBox1.Checked = True Then
                    cCustomMsg.message("error", "You must select a recipient if you want to transfer from one stockpile to another.", "SUPPLY INFO")
                    showPanelBox()
                    Exit Sub
                End If

                'IF ALLOWED QTY LIMIT
                If exceededAllowedQtyLimit(Utilities.ifBlankReplaceToZero(txtDrQty.Text)) Then
                    Exit Sub
                End If
#End Region

                If cCustomMsg.messageYesNo("Are you sure you want add temporarily to gridview?...", "SUPPLY INFO:") Then

                    Select Case cTypeOfPurchasing1.ToUpper()

                        Case cTypeOfPurchasing.WITHDRAWAL

                            If CheckBox1.Checked = True Then 'stockpile to stockpile
                                'out:
                                release_out(Transaction.ws_dr_sts,
                                            cInOut._OUT,
                                            withDrLabel(cmbDrOptions.Text))

                                'in:
                                'get the source came from stockpile origin: out
                                Dim whItemDatas = Results.cResult.Where(Function(x)
                                                                            Return x.wh_id = IIf(cStockpileOut IsNot Nothing,
                                                                                        cStockpileOut.wh_id, 0)
                                                                        End Function).ToList()

                                release_in(Transaction.ws_dr_sts,
                                           cInOut._IN,
                                            withDrLabel(cmbDrOptions.Text),
                                           whItemDatas(0).warehouse_area)

                            Else
                                'out with rs
                                If cDrOption = DROptions.out_with_rs Then
                                    release_out(Transaction.ws_dr,
                                         cInOut._OUT,
                                         withDrLabel(cmbDrOptions.Text))

                                    'out without rs
                                ElseIf cDrOption = DROptions.out_without_rs Then
                                    release_out_without_rs(Transaction.rsNa_wsNa_dr,
                                                           cInOut._OUT,
                                                           withDrLabel(cmbDrOptions.Text))
                                End If
                            End If

                        Case cTypeOfPurchasing.PURCHASE_ORDER

                            release_others(Transaction.po_rr_dr,
                                           cInOut._OTHERS,
                                           withDrLabel(cmbDrOptions.Text))

                        Case cTypeOfPurchasing.DR

                            'in without rs
                            If cDrOption = DROptions.in_without_rs Then
                                release_others_without_rs(Transaction.rsNa_wsNa_dr,
                                                cInOut._IN,
                                                withDrLabel(cmbDrOptions.Text))

                                'others without rs
                            ElseIf cDrOption = DROptions.others_without_rs Then
                                release_others_without_rs(Transaction.rsNa_wsNa_dr,
                                                cInOut._OTHERS,
                                                withDrLabel(cmbDrOptions.Text))

                            ElseIf cDrOption = DROptions.others_with_rs Then

                                'DR: others with rs
                                release_others(Transaction.rs_dr,
                                               cInOut._OTHERS,
                                               withDrLabel(cmbDrOptions.Text))

                            ElseIf cDrOption = DROptions.in_with_rs Then
                                'DR: in with rs
                                release_others(Transaction.rs_dr,
                                              cInOut._IN,
                                              withDrLabel(cmbDrOptions.Text))
                            End If

                    End Select

                    resetAfterUpdateOrSave()

                    setCustomGridview(DataGridView1)

                    Utilities.datagridviewSpecificRowFocus(DataGridView1, cListOfPendingDr.Count, NameOf(cn.id))
                End If
            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function withDrLabel(droption As String) As String
        withDrLabel = IIf(droption = "WITH DR",
                                    DisableEnable.withDr,
                                    DisableEnable.withoutDr)

        Return withDrLabel
    End Function

    Private Sub resetAfterUpdateOrSave()

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = cListOfPendingDr

        txtPlateNo.Focus()
        cStockpileIn_storage = New ITEMS
        'lblItemIn.Text = ""
        lblToBeDelivered.Text = delivered()

        If cTypeOfPurchasing1 = cTypeOfPurchasing.PURCHASE_ORDER Or
            cTypeOfPurchasing1 = cTypeOfPurchasing.DR Then
            lblQty.Text = $"{delivered()} {cStockpileIn.units}"
        Else
            lblQty.Text = $"{delivered()} {cStockpileOut.units}"
        End If


        'setCustomGridview(DataGridView1)
    End Sub

    Private Sub focusAfterEdit(id As Integer)
        Try
            Utilities.datagridviewSpecificRowFocus(DataGridView1, id, NameOf(cn.id))
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub


    Private Sub release_out(transaction As Integer, Optional inout As String = "", Optional n As Integer = 0)
        Try
            Dim createdDrOut As New PropsFields.create_dr_props_fields
            Dim _a = Results.cResult.Where(Function(x) x.wh_id = IIf(cStockpileOut IsNot Nothing, cStockpileOut.wh_id, 0)).ToList()

            With createdDrOut

                .id = cListOfPendingDr.Count + 1
                .drNo = na(txtDrNo.Text, n)
                .drQty = txtDrQty.Text
                .dr_date = dtpDrDate.Text
                .date_submitted = dtpDateSubmitted.Text
                .wh_id = IIf(cStockpileOut IsNot Nothing, cStockpileOut.wh_id, 0)
                .inout = inout
                .driver = txtDriver.Text
                .concession = na(txtConsession.Text, n)
                .plateNo = na(txtPlateNo.Text, n)

#Region "FOR PRICE"
                .price = getSpecificPrice(cStockpileOut.charges,
                                          IIf(_a.Count > 0, _a(0).warehouse_area, ""))
#End Region

                .checkedBy = na(txtCheckedBy.Text, n)
                .receivedBy = na(txtReceivedBy.Text, n)
                .transaction = transaction
                .stockpileAreaId = _a(0).wh_area_id
                .remarks = txtRemarks.Text
                .supplier = na(txtSupplier.Text, n)

                If _a.Count > 0 Then
                    .stockpile_source = _a(0).warehouse_area

                    If CheckBox1.Checked = True Then
                        .stockpile_recepient = "-"
                    Else
                        .stockpile_recepient = cStockpileOut.charges
                    End If

                    .items = _a(0).item_desc
                Else
                    .stockpile_source = "-"
                    .items = "-"
                End If
            End With

            cListOfPendingDr.Add(createdDrOut)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub release_out_without_rs(transaction As Integer, Optional inout As String = "", Optional n As Integer = 0)
        Try
            Dim createdDrOut As New PropsFields.create_dr_props_fields
            Dim _a = Results.cResult.Where(Function(x) x.wh_id = IIf(cStockpileOut IsNot Nothing, cStockpileOut.wh_id, 0)).ToList()

            With createdDrOut

                .id = cListOfPendingDr.Count + 1
                .drNo = na(txtDrNo.Text, n)
                .drQty = Utilities.ifBlankReplaceToZero(txtDrQty.Text)
                .dr_date = dtpDrDate.Text
                .date_submitted = dtpDateSubmitted.Text
                .wh_id = IIf(cStockpileOut IsNot Nothing, cStockpileOut.wh_id, 0)
                .inout = inout
                .driver = txtDriver.Text
                .concession = na(txtConsession.Text, n)
                .plateNo = na(txtPlateNo.Text, n)
                .price = na(txtPrice.Text, n, False)
                .checkedBy = na(txtCheckedBy.Text, n)
                .receivedBy = na(txtReceivedBy.Text, n)
                .transaction = transaction
                .stockpileAreaId = _a(0).wh_area_id
                .remarks = txtRemarks.Text
                .supplier = na(txtSupplier.Text, n)

                If _a.Count > 0 Then
                    .stockpile_source = _a(0).warehouse_area

                    If CheckBox1.Checked = True Then
                        .stockpile_recepient = "-"
                    Else
                        .recepient_for_screening = "waiting"
                    End If

                    .items = _a(0).item_desc
                Else
                    .stockpile_source = "-"
                    .items = "-"
                End If
            End With

            cListOfPendingDr.Add(createdDrOut)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub release_in(transaction As Integer,
                           Optional inout As String = "",
                           Optional n As Integer = 0,
                           Optional source As String = "")
        Try
            Dim createdDrIn As New PropsFields.create_dr_props_fields

            Dim _b = isStockpileToStockpile()

            With createdDrIn
                .id = cListOfPendingDr.Count + 1
                .drNo = na(txtDrNo.Text, n)
                .drQty = txtDrQty.Text
                .dr_date = dtpDrDate.Text
                .date_submitted = dtpDateSubmitted.Text
                .wh_id = IIf(_b.Count > 0, _b(0).wh_id, 0)
                .inout = inout
                .driver = txtDriver.Text
                .concession = na(txtConsession.Text, n)
                .plateNo = na(txtPlateNo.Text, n)

#Region "PRICES"
                If CheckBox1.Checked = True Then
                    .price = getSpecificPrice(cStockpileOut.charges, source) 'na(txtPrice.Text, n, False)
                Else
                    .price = getSpecificPrice(cStockpileIn.charges, _b(0).warehouse_area) 'na(txtPrice.Text, n, False)
                End If
#End Region

                .checkedBy = na(txtCheckedBy.Text, n)
                .receivedBy = na(txtReceivedBy.Text, n)
                .transaction = transaction
                .stockpileAreaId = _b(0).wh_area_id
                .remarks = txtRemarks.Text
                .supplier = na(txtSupplier.Text, n)

                If _b.Count > 0 Then
                    .stockpile_recepient = _b(0).warehouse_area
                    .stockpile_source = "-"
                    .items = _b(0).item_desc
                Else
                    .stockpile_recepient = "-"
                    .items = "-"
                End If
            End With

            cListOfPendingDr.Add(createdDrIn)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub
    Private Sub release_others(transaction As Integer,
                               Optional inout As String = "",
                               Optional isWithDr As Integer = 0)
        Try
            Dim createdDrOut As New PropsFields.create_dr_props_fields
            Dim stockpileToStockpile = isStockpileToStockpile()

            Dim zoningArea As String
            Dim zoningSource As String

            If cTransaction = cCrushingAndHaulingTransaction.WASTE_DISPOSAL_AND_OTHERS Then
                zoningArea = cStockpileIn.charges
                zoningSource = Utilities.getWarehouseAreaStockpile(stockpileToStockpile(0).wh_area_id,
                                                                                       stockpileToStockpile(0).whArea_category,
                                                                                       stockpileToStockpile(0).warehouse_area)

            ElseIf cTransaction = cCrushingAndHaulingTransaction.QUARRY_TO_PROJECT Then
                zoningArea = cStockpileIn.charges
                zoningSource = stockpileToStockpile(0).quarry
            Else
                zoningArea = stockpileToStockpile(0).warehouse_area
                zoningSource = stockpileToStockpile(0).quarry
            End If

            With createdDrOut
                .id = cListOfPendingDr.Count + 1
                .drNo = na(txtDrNo.Text, isWithDr)
                .drQty = txtDrQty.Text
                .dr_date = dtpDrDate.Text
                .date_submitted = dtpDateSubmitted.Text
                .inout = inout
                .driver = txtDriver.Text
                .concession = na(txtConsession.Text, isWithDr)
                .plateNo = txtPlateNo.Text
                .price = getSpecificPrice(zoningArea, zoningSource) 'na(txtPrice.Text, n, False)
                .checkedBy = na(txtCheckedBy.Text, isWithDr)
                .receivedBy = na(txtReceivedBy.Text, isWithDr)
                .transaction = transaction
                .stockpileAreaId = stockpileToStockpile(0).wh_area_id
                .remarks = txtRemarks.Text
                .supplier = na(txtSupplier.Text, isWithDr)
                .dr_transaction = cTransaction

                If stockpileToStockpile.Count > 0 Then

                    If cStockpileIn.typeOfPurchasing = cTypeOfPurchasing.PURCHASE_ORDER Or
                        cStockpileIn.typeOfPurchasing = cTypeOfPurchasing.DR Then

#Region "Recepient/Source"
                        If cDrOption = DROptions.in_with_rs Or
                            cDrOption = DROptions.others_with_rs Then

                            .recepient_for_screening = "waiting"
                            '.stockpile_recepient = cStockpileIn.charges

                            If cTransaction = cCrushingAndHaulingTransaction.WASTE_DISPOSAL_AND_OTHERS Then
                                .stockpile_recepient = cStockpileIn.charges
                            Else
                                .stockpile_recepient = zoningArea
                            End If

                        Else
                            .stockpile_source = cStockpileIn.supplier
                            .stockpile_recepient = Utilities.getWarehouseAreaStockpile(stockpileToStockpile(0).wh_area_id,
                                                                                       stockpileToStockpile(0).whArea_category,
                                                                                       stockpileToStockpile(0).warehouse_area)
                        End If
#End Region
                        .wh_id = IIf(cStockpileIn IsNot Nothing, cStockpileIn.wh_id, 0)

#Region "Default Price"
                        If cStockpileIn.typeOfPurchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                            .price = cStockpileIn.defaultPrice
                        End If
#End Region

                    Else
#Region "Recepient/Source"
                        .stockpile_source = Utilities.getWarehouseAreaStockpile(stockpileToStockpile(0).wh_area_id,
                                                                                stockpileToStockpile(0).whArea_category,
                                                                                stockpileToStockpile(0).warehouse_area)
                        .stockpile_recepient = cStockpileIn.charges
#End Region
                        .wh_id = IIf(cStockpileOut IsNot Nothing, cStockpileOut.wh_id, 0)
                    End If

                    .wh_id = IIf(cStockpileIn IsNot Nothing, cStockpileIn.wh_id, 0)
                    .items = stockpileToStockpile(0).item_desc
                Else
                    .stockpile_source = "-"
                    .items = "-"
                End If

            End With

            cListOfPendingDr.Add(createdDrOut)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub release_others_without_rs(transaction As Integer,
                                          Optional inout As String = "",
                                          Optional n As Integer = 0)
        Try
            Dim createDrOthers As New PropsFields.create_dr_props_fields
            Dim stockpileToStockpileDatas = isStockpileToStockpile()

            With createDrOthers
                .id = cListOfPendingDr.Count + 1
                .drNo = na(txtDrNo.Text, n)
                .drQty = txtDrQty.Text
                .dr_date = dtpDrDate.Text
                .date_submitted = dtpDateSubmitted.Text
                .inout = inout
                .driver = txtDriver.Text
                .concession = na(txtConsession.Text, n)
                .plateNo = na(txtPlateNo.Text, n)
                .price = getSpecificPrice() ' na(txtPrice.Text, n, False)
                .checkedBy = na(txtCheckedBy.Text, n)
                .receivedBy = na(txtReceivedBy.Text, n)
                .transaction = transaction
                .stockpileAreaId = stockpileToStockpileDatas(0).wh_area_id
                .remarks = txtRemarks.Text
                .supplier = na(txtSupplier.Text, n)

                If stockpileToStockpileDatas.Count > 1 Then

                    If cStockpileIn.typeOfPurchasing = cTypeOfPurchasing.PURCHASE_ORDER Or
                        cStockpileIn.typeOfPurchasing = cTypeOfPurchasing.DR Then

                        .stockpile_source = cStockpileIn.supplier
                        .stockpile_recepient = Utilities.getWarehouseAreaStockpile(stockpileToStockpileDatas(0).wh_area_id,
                                                                                   stockpileToStockpileDatas(0).whArea_category,
                                                                                   stockpileToStockpileDatas(0).warehouse_area)
                        .recepient_for_screening = "waiting"
                        .wh_id = IIf(cStockpileIn IsNot Nothing, cStockpileIn.wh_id, 0)

                    Else
                        .stockpile_source = Utilities.getWarehouseAreaStockpile(stockpileToStockpileDatas(0).wh_area_id,
                                                                                stockpileToStockpileDatas(0).whArea_category,
                                                                                stockpileToStockpileDatas(0).warehouse_area)

                        .stockpile_recepient = cStockpileIn.charges
                        .recepient_for_screening = "waiting"
                        .wh_id = IIf(cStockpileOut IsNot Nothing, cStockpileOut.wh_id, 0)
                    End If

                    .items = stockpileToStockpileDatas(0).item_desc
                Else
                    .stockpile_source = "-"
                    .items = cStockpileIn.itemName
                    .stockpile_recepient = cStockpileIn.charges
                    .wh_id = IIf(cStockpileIn IsNot Nothing, cStockpileIn.wh_id, 0)

                    If cDrOption = DROptions.in_without_rs Then
                        .stockpile_recepient = stockpileToStockpileDatas(0).warehouse_area
                    End If

                End If
            End With

            cListOfPendingDr.Add(createDrOthers)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Function isStockpileToStockpile() As List(Of PropsFields.whItems_props_fields)
        If CheckBox1.Checked Then
            isStockpileToStockpile = Results.cResult.Where(Function(x) x.wh_id = IIf(cStockpileIn_storage IsNot Nothing, cStockpileIn_storage.wh_id, 0)).ToList()
        Else
            isStockpileToStockpile = Results.cResult.Where(Function(x) x.wh_id = IIf(cStockpileIn IsNot Nothing, cStockpileIn.wh_id, 0)).ToList()
        End If
    End Function

    Private Sub openPanelCreateWithdrawal()
        Try
            For Each ctr As Control In loadingPanel.Controls
                If ctr.Name = NameOf(Panel7) Then
                    ctr.Visible = True
                Else
                    ctr.Enabled = False
                End If
            Next

            For Each ctr As Control In Panel8.Controls
                ctr.Enabled = False
            Next

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button5.Click
        panelBoxClose()
    End Sub

    Private Sub picStoS_Click(sender As Object, e As EventArgs) Handles picStoS.Click

        If CheckBox1.Checked = True Then
            showPanelBox()
        End If

    End Sub

    Private Sub showPanelBox()

        Panel12.Enabled = False
        Panel11.Visible = True
        Panel11.Enabled = True

        setCustomGridview(DataGridView2)
        txtSearchItems.Focus()

    End Sub

    Private Sub panelBoxClose()
        Try
            For Each ctr As Control In loadingPanel.Controls
                If ctr.Name = NameOf(Panel7) Then
                    ctr.Visible = False
                Else
                    ctr.Enabled = True
                End If
            Next

            For Each ctr As Control In Panel8.Controls
                ctr.Enabled = True
            Next

            For Each ctr As Control In Panel2.Controls
                ctr.Enabled = True
            Next
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub picStoS_MouseHover(sender As Object, e As EventArgs) Handles picStoS.MouseHover
        picStoS.Image = My.Resources.icon_cp_plus_drop_activated
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel11.Visible = False
        Panel12.Enabled = True
    End Sub

    Private Sub txtSearchItems_TextChanged(sender As Object, e As EventArgs) Handles txtSearchItems.TextChanged
        cSearch = txtSearchItems.Text
    End Sub

    Private Sub picStoS_MouseLeave(sender As Object, e As EventArgs) Handles picStoS.MouseLeave
        picStoS.Image = My.Resources.icon_cp_plus_drop
    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        Try
            debounce_new.Stop()

            Dim searchResult
            searchResult = Results.cResult.Where(Function(x)
                                                     Dim output As String = x.wh_id &
                                                          " " & x.item_name.ToUpper() &
                                                          " " & x.item_desc.ToUpper() &
                                                          " " & x.quarry.ToUpper() &
                                                          " " & x.warehouse_area.ToUpper()
                                                     Return output.Contains(cSearch.ToUpper) And x.item_name.ToUpper().Contains("AGGREGATES")

                                                 End Function).
                                       OrderBy(Function(x) x.item_name).
                                       ThenBy(Function(x) x.item_desc).
                                       ThenBy(Function(x) x.warehouse_area).ToList()


            If searchResult.Count > 0 Then
                Dim listOfItems As New List(Of ITEMS)
                For Each row As PropsFields.whItems_props_fields In searchResult
                    Dim _items As New ITEMS
                    With _items
                        .wh_id = row.wh_id
                        .itemName = row.item_desc
                        .stockpile = row.warehouse_area
                        .quarry = row.quarry
                        .specificLocation = row.specific_loc
                    End With

                    listOfItems.Add(_items)
                Next

                DataGridView2.DataSource = listOfItems

            End If

            PictureBox3.Visible = False
            setCustomGridview(DataGridView2)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub txtSearchItems_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchItems.KeyDown
        Try
            If txtSearchItems.TextLength > 0 Then
                PictureBox3.Visible = True
                debounce_new.Start()
            Else
                PictureBox3.Visible = True
                cSearch = ""
                debounce_new.Start()

            End If

            If e.KeyCode = Keys.Down Then
                If txtSearchItems.SelectionStart = txtSearchItems.TextLength Then
                    DataGridView2.Focus()
                End If
            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked = True Then
                picStoS.Enabled = True
                showPanelBox()
            Else
                picStoS.Enabled = False
                cStockpileIn_storage = New ITEMS
                'lblItemIn.Text = ""

            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        selectItemsForStockpileToStockpile()
    End Sub

    Private Sub selectItemsForStockpileToStockpile()
        Try
            Dim aggregatesTransaction As New AggregatesTransactionFlow

            With DataGridView2.SelectedCells(0).OwningRow
                'lblItemIn.Visible = True

                'lblItemIn.Text = $"({ .Cells(NameOf(ITEMS.quarry)).Value}) { .Cells(NameOf(ITEMS.stockpile)).Value} → ✔ { .Cells(NameOf(ITEMS.itemName)).Value}"
                cStockpileIn_storage.wh_id = .Cells(NameOf(ITEMS.wh_id)).Value
                cStockpileIn_storage.stockpile = .Cells(NameOf(ITEMS.stockpile)).Value

                lblRequestor.Text = aggregatesTransaction.requestorLabel($"{ .Cells(NameOf(ITEMS.quarry)).Value} - { .Cells(NameOf(ITEMS.stockpile)).Value} → ✔ { .Cells(NameOf(ITEMS.itemName)).Value}")
            End With

            Button3.PerformClick()
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim selectedId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("id").Value)
            editDr(selectedId)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub editDr(id As Integer)
        Try
            Panel4.Visible = True
            cEditedData = cListOfPendingDr.Where(Function(x)
                                                     Return x.id = id
                                                 End Function).ToList()

            Dim sts = cListOfPendingDr.Where(Function(x) x.drNo = cEditedData(0).drNo).ToList()

            If sts.Count = 2 And cEditedData(0).inout = cInOut._IN Then
                cCustomMsg.message("error", "you must select out transaction to edit that data...", "SUPPLY INFO:")
                Exit Sub

                'this area is for stockpile to stockpile
            ElseIf sts.Count = 2 And cEditedData(0).inout = cInOut._OUT Then
                Dim stsIn = sts.Where(Function(x) x.inout = cInOut._IN).ToList()

                If Results.cResult.Count > 0 Then
                    Dim str = Results.cResult.Where(Function(x) x.wh_id = stsIn(0).wh_id).ToList()

                    'lblItemIn.Text = $"({ str(0).quarry}) {str(0).warehouse_area} → ✔ {str(0).item_desc}"

                    cStockpileIn.wh_id = stsIn(0).wh_id
                    cStockpileIn.stockpile = stsIn(0).stockpile_recepient
                End If
            End If

            If cEditedData.Count > 0 Then
                txtCheckedBy.Focus()

                With cEditedData(0)
                    dtpDrDate.Text = .dr_date
                    dtpDateSubmitted.Text = .date_submitted
                    txtConsession.Text = .concession
                    txtCheckedBy.Text = .checkedBy
                    txtReceivedBy.Text = .receivedBy
                    txtPrice.Text = .price
                    txtDrNo.Text = .drNo
                    txtDrQty.Text = .drQty
                    txtPlateNo.Text = .plateNo
                    txtDriver.Text = .driver
                    txtRemarks.Text = .remarks
                    cEdit = True
                    btnReleaseNow.Text = "Update (Ctrl + R)"

                    txtPlateNo.Focus()

                    'disable
                    enable_disable(DisableEnable.disableFieldsForEdit)
                End With

            End If

            For Each row In c.cListOfUIFields
                If row.objFields IsNot Nothing Then
                    row.objFields.resetBgColor()
                End If
            Next
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub enable_disable(n As Integer)
        Try
            If n = DisableEnable.disableFieldsForEdit Then
                cmbDrOptions.Enabled = False
                'txtRemarks.Enabled = False
                txtSupplier.Enabled = False
                DataGridView1.Enabled = False
                cEdit = True

            ElseIf n = DisableEnable.enableFieldsAfterEdit Then
                For Each row In c.cListOfUIFields
                    If row.objFields.tbox IsNot Nothing Then
                        row.objFields.tbox.Enabled = True
                    ElseIf row.objFields.cDatePicker IsNot Nothing Then
                        row.objFields.cDatePicker.Enabled = True
                    End If
                Next

                cmbDrOptions.Enabled = True

                c.resetAll()
                DataGridView1.Enabled = True
                cEdit = False
                btnReleaseNow.Text = "Deliver (Ctrl + R)"
                'lblItemIn.Text = ""

                'If Not cTypeOfPurchasing1 = cTypeOfPurchasing.PURCHASE_ORDER Then

                '    cStockpileIn = New ITEMS
                'End If

            ElseIf n = DisableEnable.withDr Then

                txtPlateNo.Enabled = True
                txtDriver.Enabled = True
                txtSupplier.Enabled = True
                txtConsession.Enabled = True
                txtCheckedBy.Enabled = True
                txtRemarks.Enabled = True
                txtPrice.Enabled = True
                txtDrQty.Enabled = True
                txtDrNo.Enabled = True
                txtReceivedBy.Enabled = True


            ElseIf n = DisableEnable.withoutDr Then

                txtPlateNo.Enabled = False
                txtDriver.Enabled = True
                txtSupplier.Enabled = False
                txtConsession.Enabled = False
                txtCheckedBy.Enabled = False
                txtRemarks.Enabled = True
                txtPrice.Enabled = False
                txtDrQty.Enabled = True
                txtDrNo.Enabled = False
                txtReceivedBy.Enabled = False

            End If

            'rest price to zero(0)
            txtPrice.Text = 0
            c.resetUIBackground(txtPrice.Name)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try


    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            If cCustomMsg.messageYesNo("Are you sure you want to remove this item?", "SUPPLY INFO:") Then

                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.id)).Value
                    Dim drNo As String = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.drNo)).Value
                    Dim inOut As String = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.inout)).Value

                    Dim _a = cListOfPendingDr.Where(Function(x)
                                                        If x.drNo <> "N/A" Then
                                                            Return x.drNo = drNo
                                                        End If
                                                    End Function).ToList()

                    If _a.Count > 1 And inOut = cInOut._IN Then
                        cCustomMsg.message("error", "Unable to remove this item. You must select the 'Out' transaction to completely remove it....", "SUPPLY INFO:")
                        Exit Sub

                    ElseIf _a.Count = 2 And inOut = cInOut._OUT Then
                        cListOfPendingDr = cListOfPendingDr.Where(Function(x) x.drNo <> drNo).ToList()
                    Else
                        cListOfPendingDr = cListOfPendingDr.Where(Function(x) x.id <> id).ToList()
                    End If

                    DataGridView1.DataSource = Nothing
                    DataGridView1.DataSource = cListOfPendingDr

                    lblToBeDelivered.Text = delivered()

                    If cTypeOfPurchasing1 = cTypeOfPurchasing.PURCHASE_ORDER Or
                       cTypeOfPurchasing1 = cTypeOfPurchasing.DR Then

                        lblQty.Text = $"{delivered()} {cStockpileIn.units}"
                    Else
                        lblQty.Text = $"{delivered()} {cStockpileOut.units}"
                    End If

                    If DataGridView1.Rows.Count = 0 Then
                        cCustomMsg.message("warning", "we need to restart the form to avoid errors...", "SUPPLY INFO:")
                        Me.Dispose()
                    Else
                        setCustomGridview(DataGridView1)
                    End If

                    Utilities.datagridviewSpecificRowFocus(DataGridView1, cListOfPendingDr.Count, NameOf(cn.id))
                End If
            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub FCreateDeliveryReceipt_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            Me.Dispose()
            cStockpileIn = Nothing
            cStockpileOut = Nothing
            cEdit = False
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Function checkIfDrExistInDb(drNo As String) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.addColumn("dr_no")
            cc.setCondition($"a.dr_no = '{drNo}'")
            Dim data = cc.selectQuery_and_return_data("dbDeliveryReport_items",, "a", cTableNameType.supply_table)

            If data.count > 0 Then
                Return True
            End If


        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Sub btnFinalSave_Click(sender As Object, e As EventArgs) Handles btnFinalSave.Click
        Try
#Region "FILTER SAVE HERE"
            If cListOfPendingDr.Count = 0 Then
                cCustomMsg.message("error", "you must add transactions first...", "SUPPLY INFO:")
                Exit Sub
            End If
#End Region

            If cCustomMsg.messageYesNo("are you sure you want to save all the dr information in the list?", "EUS INFO:", MessageBoxIcon.Question) Then

#Region "COUNT THE WAITING"
                Dim countPending As Integer

                If Not cDrOption = DROptions.in_without_rs AndAlso
                    Not cDrOption = DROptions.others_with_rs AndAlso
                    Not cDrOption = DROptions.others_without_rs Then

                    countPending = cListOfPendingDr.Where(Function(x)
                                                              Return x.recepient_for_screening = "waiting"
                                                          End Function).ToList().Count()
                End If


#End Region

                'check if drno already in database

#Region "CHECK DRNO ALREADY IN DB"
                Dim count As Integer
                Dim t As Threading.Thread
                t = New Threading.Thread(Sub()
                                             For Each row In cListOfPendingDr
                                                 Dim ifDrExist As Boolean = checkIfDrExistInDb(row.drNo)
                                                 If ifDrExist Then
                                                     If Not row.transaction = Transaction.rsNa_wsNa_dr Then
                                                         cCustomMsg.message("error", $"this DRNO: {row.drNo} already exist in the database.", "SUPPLY INFO:")
                                                         count += 1
                                                     End If
                                                 End If
                                             Next
                                         End Sub)
                t.Start()

                t.Join()

                If count > 0 Then
                    Exit Sub
                End If
#End Region

                For Each row In cListOfPendingDr

                    Select Case row.transaction
                        Case Transaction.ws_dr 'ws->dr

                            insert_for_ws_po_DR(row)

                        Case Transaction.ws_dr_sts 'ws->dr-out->dr-in

                            If row.inout = cInOut._OUT Then

                                insert_for_ws_po_DR(row)

                            ElseIf row.inout = cInOut._IN Then

                                insert_for_stockpile_to_stockpile(row)

                            End If

                        Case Transaction.po_rr_dr 'po->rr->dr

                            insert_for_ws_po_DR(row)

                        Case Transaction.rs_dr 'rs->dr

                            insert_for_rs_DR(row)

                        Case Transaction.rsNa_wsNa_dr 'no rs->no ws->dr

                            If Not countPending > 0 Then

                                insert_for_dr_without_rs(row)

                            End If
                    End Select

                Next

                If cDrOption = DROptions.out_without_rs Then

                    If countPending > 0 Then
                        cCustomMsg.message("error", "unable to save data without selecting recepient each rows...", "SUPPLY INFO:")
                    Else
                        'this use case intended for creating dr started from FRequesitionFormForDR
                        If cDrOption = DROptions.in_with_rs Or
                            cDrOption = DROptions.others_with_rs Then

                            'FRequistionForm.btnSearch.PerformClick()
                            FRequesitionFormForDR.btnSearch.PerformClick()
                        End If

                        cCustomMsg.message("info", "Successfully Saved...", "SUPPLY INFO:")
                        Me.Dispose()
                    End If

                Else
                    If Not cDrOption = DROptions.in_without_rs Then
                        'FRequistionForm.btnSearch.PerformClick()
                        FRequesitionFormForDR.btnSearch.PerformClick()
                    End If

                    cCustomMsg.message("info", "Successfully Saved...", "SUPPLY INFO:")
                    Me.Dispose()

                End If

            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub insert_for_ws_po_DR(row As PropsFields.create_dr_props_fields)
        Try
            Dim drInfo As New ColumnValuesObj
            Dim drItemDetails As New ColumnValuesObj

            'Dim drInfoId As Integer
            Dim equipListID As Integer = Results.cListOfEquipments.Where(Function(x) x.PlateNo.ToUpper() = row.plateNo.ToUpper()).ToList()(0).equipListID
            Dim operator_id As Integer = Results.cListOfOperatorDriver.Where(Function(x) x.operator_name.ToUpper() = row.driver.ToUpper()).ToList()(0).operator_id
            Dim supplier_id As Integer = Results.cListOfSupplier.Where(Function(x) x.supplierName.ToUpper() = row.supplier.ToUpper()).ToList()(0).supplier_id

            'for drinfo
            Dim drInfoData, drDetailsData As New PropsFields.create_dr_info_fields
            With drInfoData
                .dr_date = Utilities.DateConverter(row.dr_date)
                .date_submitted = Utilities.DateConverter(row.date_submitted)
                .equipListId = equipListID
                .operator_id = operator_id
                .concession = row.concession
                .checkedBy = row.checkedBy
                .dateLog = Date.Parse(Now)
                .options = "W/ DR"
                .remarks = row.remarks
                .supplier_id = supplier_id
                .typeOfPurchasing = cTypeOfPurchasing1
                .price = row.price

                If cTypeOfPurchasing1 = cTypeOfPurchasing.WITHDRAWAL Then
                    .wsNo = cStockpileOut.wsNoRrNo
                ElseIf cTypeOfPurchasing1 = cTypeOfPurchasing.PURCHASE_ORDER Then
                    .rrNo = cStockpileIn.wsNoRrNo
                End If

            End With

            With drDetailsData
                .drNo = row.drNo
                .stockpile_source = "WAREHOUSE"
                .stockpileAreaId = row.stockpileAreaId
                .wh_id = row.wh_id
                .drQty = row.drQty
                .typeOfPurchasing = cTypeOfPurchasing1
                .in_to_stockard = "NO"
                .user_id = pub_user_id

                If cTypeOfPurchasing1 = cTypeOfPurchasing.WITHDRAWAL Then
                    .rsId = cStockpileOut.rs_id
                ElseIf cTypeOfPurchasing1 = cTypeOfPurchasing.PURCHASE_ORDER Then
                    .rsId = cStockpileIn.rs_id
                End If

            End With

            Dim createdelivery As New CreateDeliveryReceiptForWithdrawalServices
            Dim dr_details_id As Integer = createdelivery.ExecuteWithReturnId(drInfoData, drDetailsData)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub insert_for_rs_DR(row As PropsFields.create_dr_props_fields)

        Dim SQLCONNECTION As New SQLcon
        Dim TRANSACTION As SqlTransaction = Nothing

        Try
            Dim drInfo As New ColumnValuesObj
            Dim drItemDetails As New ColumnValuesObj

            Dim drInfoId As Integer
            Dim equipListID As Integer = Results.cListOfEquipments.Where(Function(x) x.PlateNo.ToUpper() = row.plateNo.ToUpper()).ToList()(0).equipListID
            Dim operator_id As Integer = Results.cListOfOperatorDriver.Where(Function(x) x.operator_name.ToUpper() = row.driver.ToUpper()).ToList()(0).operator_id
            Dim supplier_id As Integer = Results.cListOfSupplier.Where(Function(x) x.supplierName.ToUpper() = row.supplier.ToUpper()).ToList()(0).supplier_id

            SQLCONNECTION.connection.Open()
            TRANSACTION = SQLCONNECTION.connection.BeginTransaction()

            'for drinfo
            With drInfo
                .add("date", Date.Parse(row.dr_date))
                .add("date_submitted", row.date_submitted)
                .add("equipListID", equipListID)
                .add("operator_id", operator_id)
                .add("concession_ticket_no", row.concession)
                .add("checkedBy", row.checkedBy)
                .add("receivedBy", row.receivedBy)
                .add("date_log", Date.Parse(Now))
                .add("options", "W/ DR")
                .add("remarks", row.remarks)
                .add("supplier_id", supplier_id)
                .add("price", row.price)

                drInfoId = .insertQueryRollBack_and_return_id("dbDeliveryReport_info", SQLCONNECTION, TRANSACTION)
            End With

            With drItemDetails
                .add("dr_info_id", drInfoId)
                .add("dr_no", row.drNo)
                .add("category", Utilities.ifNothingReplaceToBlank(row.recepient_category))
                .add("source_id", row.recepient_id)
                .add("wh_id", row.wh_id)
                .add("qty", row.drQty)
                .add("rs_id", cStockpileIn.rs_id)
                .add("in_to_stockcard", "NO")
                .add("user_id", pub_user_id)
                .add("dr_transaction", cTransaction)

                .insertQueryRollBack_and_return_id("dbDeliveryReport_items", SQLCONNECTION, TRANSACTION)
            End With
            TRANSACTION.Commit()

        Catch ex As Exception
            If TRANSACTION IsNot Nothing Then
                TRANSACTION.Rollback()
            End If
            cCustomMsg.ErrorMessage(ex)
        Finally
            SQLCONNECTION.connection.Close()
        End Try
    End Sub

    Private Sub cmbDrOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrOptions.SelectedIndexChanged
        If cmbDrOptions.Text = "WITH DR" Then
            enable_disable(DisableEnable.withDr)
        ElseIf cmbDrOptions.Text = "WITHOUT DR" Then
            enable_disable(DisableEnable.withoutDr)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        For Each item As ToolStripItem In ContextMenuStrip1.Items
            If TypeOf item Is ToolStripMenuItem AndAlso item.Name = NameOf(RecepientToolStripMenuItem) Then

                item.Enabled = (cDrOption = DROptions.out_without_rs Or
                                cDrOption = DROptions.in_without_rs Or
                                cDrOption = DROptions.others_without_rs Or
                                cDrOption = DROptions.in_with_rs Or
                                cDrOption = DROptions.others_with_rs)

                If cDrOption = DROptions.out_without_rs Then
                    item.Text = "Recepient"
                Else
                    item.Text = "Source"
                End If

            ElseIf TypeOf item Is ToolStripMenuItem AndAlso item.Name = NameOf(CopyThisRecepientToAllRowsToolStripMenuItem) Then
                If cDrOption = DROptions.out_without_rs Then
                    item.Text = "Copy this recepient to all rows"
                Else
                    item.Text = "Copy this source to all rows"
                End If
            End If
        Next

    End Sub

    Private Sub RecepientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecepientToolStripMenuItem.Click

        cFchargeTo = New FCharge_To
        charge_to_selection = 2

        If cCustomMsg.messageYesNo("YES: for stockpile and quarry!" & vbCrLf & "NO: for projects and others", "SUPPLY INFO:", MessageBoxIcon.Question) Then

            With FWarehouseAreaNew
                .cListOfPendingDr = cListOfPendingDr
                .cDgv = DataGridView1
                .forDrWithoutRs = cDrOption
                .cId = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.id)).Value
                .isFromCreateDeliveryReceipt_addRecepient = True
                .ShowDialog()
            End With

        Else
            With cFchargeTo
                .cListOfPendingDr = cListOfPendingDr
                .cDgv = DataGridView1
                .cId = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.id)).Value
                .forDrWithoutRs = cDrOption
                .forStockpileLocation = True

                .ShowDialog()
            End With
        End If


    End Sub

    Private Sub CopyThisRecepientToAllRowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyThisRecepientToAllRowsToolStripMenuItem.Click
        Try
            Dim recepient_category As String
            Dim recepient_id As Integer
            Dim recepient As String

            recepient_category = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.recepient_category)).Value
            recepient_id = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.recepient_id)).Value
            recepient = DataGridView1.SelectedRows(0).Cells(NameOf(PropsFields.create_dr_props_fields.recepient_for_screening)).Value

            If Not recepient_id = 0 Then
                For Each row In cListOfPendingDr
                    row.recepient_category = recepient_category
                    row.recepient_id = recepient_id
                    row.recepient_for_screening = recepient
                Next

                DataGridView1.Refresh()
            Else
                cCustomMsg.message("error", "select a recepient first...", "SUPPLY INFO:")
            End If



        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmbDrOptions.Text = "WITH DR"
        txtPlateNo.Text = "AAG 4016"
        txtDriver.Text = "ABARCA, ILDI BRIAN L."
        txtSupplier.Text = "A.B GORME"
        txtConsession.Text = "con-2309294"
        txtCheckedBy.Text = "ABARCA, ILDI BRIAN L."
        txtRemarks.Text = "TRANSFER"
        txtPrice.Text = "0"
        txtDrNo.Text = "dr-29329424"
        txtDrQty.Text = "2"

    End Sub

    Private Sub CopyFor5RowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyFor5RowsToolStripMenuItem.Click
        Try
            Dim createDrNew As New PropsFields.create_dr_props_fields
            Dim selectedDr = cListOfPendingDr.Where(Function(x) x.id = DataGridView1.SelectedRows(0).Cells(createDrNew.id).Value).ToList()
            Dim count As Integer = cListOfPendingDr.Count

            If selectedDr.Count > 0 Then
                createDrNew = selectedDr(0)
            End If

            For n = 0 To 4
                Dim createDrNew2 As New PropsFields.create_dr_props_fields
                With createDrNew2

                    .id = cListOfPendingDr.Count + 1
                    .inout = createDrNew.inout
                    .items = createDrNew.items
                    .plateNo = createDrNew.plateNo
                    .price = createDrNew.price
                    .recepient_category = createDrNew.recepient_category
                    .recepient_for_screening = createDrNew.recepient_for_screening
                    .recepient_id = createDrNew.recepient_id
                    .remarks = createDrNew.remarks
                    .stockpileAreaId = createDrNew.stockpileAreaId
                    .stockpile_recepient = createDrNew.stockpile_recepient
                    .stockpile_source = createDrNew.stockpile_source
                    .supplier = createDrNew.supplier
                    .transaction = createDrNew.transaction
                    .wh_id = createDrNew.wh_id
                    .checkedBy = createDrNew.checkedBy
                    .concession = createDrNew.concession
                    .date_submitted = createDrNew.date_submitted
                    .driver = createDrNew.driver
                    .drNo = IIf(createDrNew.drNo.Contains("N/A"), "N/A", $"dr-{cListOfPendingDr.Count + 1}")
                    .drQty = createDrNew.drQty
                    .dr_date = createDrNew.dr_date
                    .receivedBy = createDrNew.receivedBy

                    'IF EXCEED ALLOWED QTY LIMIT
                    If exceededAllowedQtyLimit(createDrNew.drQty) Then
                        Exit For
                        Exit Sub
                    End If

                    cListOfPendingDr.Add(createDrNew2)
                End With

            Next


            resetAfterUpdateOrSave()

            setCustomGridview(DataGridView1)

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function exceededAllowedQtyLimit(drQty As Double) As Boolean
        Try
            Dim toBedelivered As Double = (delivered() + drQty)
            Dim remaining As Double = (cReleasedQty - cDeliveredQty)

            If toBedelivered > remaining And cOpened = False Then
                If cDrOption = DROptions.out_with_rs Or
                    cDrOption = DROptions.in_with_rs Or
                    cDrOption = DROptions.others_with_rs Or
                    cDrOption = DROptions.in_with_rs_po_rr Then

                    cCustomMsg.message("error", "You have exceeded the allowed quantity limit.", "SUPPLY INFO:")
                    Return True
                End If
            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub insert_for_stockpile_to_stockpile(row As PropsFields.create_dr_props_fields)
        Dim SQLCONNECTION As New SQLcon
        Dim TRANSACTION As SqlTransaction = Nothing

        Try
            Dim _rsId, _poId, _poDetailsId, _rrInfoId, _rrItemId, _rrPartiallyId, _drInfoId As Integer
            Dim _rs, _poInfo, _poDetails, _rrInfo, _rrDetails, _rrPartially, _drInfo, _drDetails As New ColumnValuesObj

            SQLCONNECTION.connection.Open()
            TRANSACTION = SQLCONNECTION.connection.BeginTransaction()

#Region "REQUESITION"
            With _rs
                .add("rs_no", cStockpileOut.rsNo)
                .add("date_req", row.dr_date)
                .add("wh_id", row.wh_id)
                .add("qty", row.drQty)
                .add("date_log", Date.Parse(Now))
                .add("date_needed", Date.Parse(row.dr_date))
                .add("remarks", 0)
                .add("IN_OUT", cInOut._IN)
                .add("user_id", pub_user_id)

                '_rsId = .insertQuery_and_return_id("dbrequisition_slip")
                _rsId = .insertQueryRollBack_and_return_id("dbrequisition_slip", SQLCONNECTION, TRANSACTION)
            End With
#End Region

#Region "PURCHARSE ORDER"
            With _poInfo
                .add("po_date", row.dr_date)
                .add("rs_no", cStockpileOut.rsNo)
                .add("instructor", "n/a")
                .add("charge_type", "n/a")
                .add("prepared_by", "n/a")
                .add("checked_by", "n/a")
                .add("approved_by", "n/a")
                .add("user_id", pub_user_id)
                .add("date_log", Date.Parse(Now))
                .add("dr_option", "W/ DR")

                '_poId = .insertQuery_and_return_id("dbPO")
                _poId = .insertQueryRollBack_and_return_id("dbPO", SQLCONNECTION, TRANSACTION)

            End With

            With _poDetails
                .add("po_id", _poId)
                .add("qty", row.drQty)
                .add("rs_id", _rsId)
                .add("selected", "TRUE")
                .add("user_id_logs", pub_user_id)

                '_poDetailsId = .insertQuery_and_return_id("dbPO_details")
                _poDetailsId = .insertQueryRollBack_and_return_id("dbPO_details", SQLCONNECTION, TRANSACTION)
            End With
#End Region

#Region "RECEIVING"

            With _rrInfo
                .add("rr_no", "n/a")
                .add("invoice_no", "n/a")
                .add("supplier_id", 0)
                .add("po_no", "n/a")
                .add("rs_no", "n/a")
                .add("date_received", Date.Parse(row.dr_date))
                .add("received_by", "n/a")
                .add("checked_by", "n/a")
                .add("received_status", "PENDING")
                .add("so_no", "n/a")
                .add("hauler", "n/a")
                .add("plateno", "n/a")
                .add("date_log", Date.Parse(Now))
                .add("user_id", pub_user_id)
                .add("date_submitted", Date.Parse("1990-01-01"))

                '_rrInfoId = .insertQuery_and_return_id("dbreceiving_info")
                _rrInfoId = .insertQueryRollBack_and_return_id("dbreceiving_info", SQLCONNECTION, TRANSACTION)
            End With

            With _rrDetails
                .add("rr_info_id", _rrInfoId)
                .add("qty", row.drQty)
                .add("rs_id", _rsId)
                .add("po_det_id", _poDetailsId)
                .add("selected", "Include")

                '_rrItemId = .insertQuery_and_return_id("dbreceiving_items")
                _rrItemId = .insertQueryRollBack_and_return_id("dbreceiving_items", SQLCONNECTION, TRANSACTION)
            End With

            With _rrPartially
                .add("rr_item_id", _rrItemId)
                .add("desired_qty", row.drQty)

                '_rrPartiallyId = .insertQuery_and_return_id("dbreceiving_item_partially")
                _rrPartiallyId = .insertQueryRollBack_and_return_id("dbreceiving_item_partially", SQLCONNECTION, TRANSACTION)
            End With
#End Region

#Region "DELIVERY RECEIPT"
            Dim equipListID As Integer = Results.cListOfEquipments.Where(Function(x) x.PlateNo.ToUpper() = row.plateNo.ToUpper()).ToList()(0).equipListID
            Dim operator_id As Integer = Results.cListOfOperatorDriver.Where(Function(x) x.operator_name.ToUpper() = row.driver.ToUpper()).ToList()(0).operator_id
            Dim supplier_id As Integer = Results.cListOfSupplier.Where(Function(x) x.supplierName.ToUpper() = row.supplier.ToUpper()).ToList()(0).supplier_id

            With _drInfo
                .add("date", row.dr_date)
                .add("equipListID", equipListID)
                .add("operator_id", operator_id)
                .add("rs_no", cStockpileOut.rsNo)
                .add("concession_ticket_no", row.concession)
                .add("checkedBy", row.checkedBy)
                .add("date_log", Date.Parse(Now))
                .add("options", "W/ DR")
                .add("date_submitted", row.date_submitted)
                .add("remarks", row.remarks)
                .add("supplier_id", suppliers_id)

                '_drInfoId = .insertQuery_and_return_id("dbDeliveryReport_info")
                _drInfoId = .insertQueryRollBack_and_return_id("dbDeliveryReport_info", SQLCONNECTION, TRANSACTION)
            End With

            With _drDetails
                .add("dr_info_id", _drInfoId)
                .add("dr_no", row.drNo)
                .add("category", "WAREHOUSE")
                .add("source_id", row.stockpileAreaId)
                .add("wh_id", row.wh_id)
                .add("qty", row.drQty)
                .add("rs_id", _rsId)
                .add("par_rr_item_id", _rrPartiallyId)
                .add("in_to_stockcard", "YES")
                .add("user_id", pub_user_id)

                '.insertQuery("dbDeliveryReport_items")
                Dim drDetailsId As Integer = .insertQueryRollBack_and_return_id("dbDeliveryReport_items", SQLCONNECTION, TRANSACTION)
            End With
#End Region

            TRANSACTION.Commit()

        Catch ex As Exception
            If TRANSACTION IsNot Nothing Then
                TRANSACTION.Rollback()
            End If

            cCustomMsg.ErrorMessage(ex)
        Finally
            SQLCONNECTION.connection.Close()
        End Try
    End Sub

    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        Panel4.Visible = False
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Panel4.Visible = True
    End Sub

    Private Sub insert_for_dr_without_rs(row As PropsFields.create_dr_props_fields)
        Dim SQLCONNECTION As New SQLcon
        Dim TRANSACTION As SqlTransaction = Nothing

        Try
            Dim _rsId, _poId, _poDetailsId, _drInfoId, _rrInfoId, _rrItemId, _rrPartiallyId As Integer
            Dim _rs, _poInfo, _poDetails, _rrInfo, _rrDetails, _rrPartially, _drInfo, _drDetails As New ColumnValuesObj
            Dim notApplicable As String = "N/A"

            SQLCONNECTION.connection.Open()
            TRANSACTION = SQLCONNECTION.connection.BeginTransaction()
#Region "REQUESITION"
            With _rs
                .add("rs_no", notApplicable)
                .add("date_req", row.dr_date)
                .add("wh_id", row.wh_id)
                .add("qty", row.drQty)
                .add("date_log", Date.Parse(Now))
                .add("date_needed", Date.Parse(row.dr_date))
                .add("remarks", 1)
                .add("IN_OUT", row.inout)
                .add("user_id", pub_user_id)

                _rsId = .insertQueryRollBack_and_return_id("dbrequisition_slip", SQLCONNECTION, TRANSACTION) '.insertQuery_and_return_id("dbrequisition_slip")
            End With
#End Region

#Region "PO DETAILS AND PO INFO"
            With _poInfo
                .add("po_date", row.dr_date)
                .add("rs_no", notApplicable)
                .add("instructor", "n/a")
                .add("charge_type", "n/a")
                .add("prepared_by", "n/a")
                .add("checked_by", "n/a")
                .add("approved_by", "n/a")
                .add("user_id", pub_user_id)
                .add("date_log", Date.Parse(Now))
                .add("dr_option", "W/ DR")

                _poId = .insertQueryRollBack_and_return_id("dbPO", SQLCONNECTION, TRANSACTION) '.insertQuery_and_return_id("dbPO")


            End With

            With _poDetails
                .add("po_id", _poId)
                .add("qty", row.drQty)
                .add("rs_id", _rsId)
                .add("selected", "TRUE")
                .add("user_id_logs", pub_user_id)

                _poDetailsId = .insertQueryRollBack_and_return_id("dbPO_details", SQLCONNECTION, TRANSACTION) '.insertQuery_and_return_id("dbPO_details")
            End With
#End Region

#Region "RECEIVING"

            With _rrInfo
                .add("rr_no", "n/a")
                .add("invoice_no", "n/a")
                .add("supplier_id", 0)
                .add("po_no", "n/a")
                .add("rs_no", "n/a")
                .add("date_received", Date.Parse(row.dr_date))
                .add("received_by", "n/a")
                .add("checked_by", "n/a")
                .add("received_status", "PENDING")
                .add("so_no", "n/a")
                .add("hauler", "n/a")
                .add("plateno", "n/a")
                .add("date_log", Date.Parse(Now))
                .add("user_id", pub_user_id)
                .add("date_submitted", Date.Parse("1990-01-01"))

                _rrInfoId = .insertQueryRollBack_and_return_id("dbreceiving_info", SQLCONNECTION, TRANSACTION) '.insertQuery_and_return_id("dbreceiving_info")

            End With

            With _rrDetails
                .add("rr_info_id", _rrInfoId)
                .add("qty", row.drQty)
                .add("rs_id", _rsId)
                .add("po_det_id", _poDetailsId)
                .add("selected", "Include")

                _rrItemId = .insertQueryRollBack_and_return_id("dbreceiving_items", SQLCONNECTION, TRANSACTION) '.insertQuery_and_return_id("dbreceiving_items")
            End With

            With _rrPartially
                .add("rr_item_id", _rrItemId)
                .add("desired_qty", row.drQty)

                _rrPartiallyId = .insertQueryRollBack_and_return_id("dbreceiving_item_partially", SQLCONNECTION, TRANSACTION) '.insertQuery_and_return_id("dbreceiving_item_partially")
            End With
#End Region

#Region "DELIVERY RECEIPT"
            Dim equipListID As Integer = get_equipment_id(row.plateNo)

            Dim operator_id As Integer = get_operator_id(row.driver)

            Dim supplier_id As Integer = get_supplier_id(row.supplier)

            With _drInfo
                .add("date", row.dr_date)
                .add("equipListID", equipListID)
                .add("operator_id", operator_id)
                .add("rs_no", notApplicable)
                .add("concession_ticket_no", row.concession)
                .add("checkedBy", row.checkedBy)
                .add("date_log", Date.Parse(Now))
                .add("options", "W/ DR")
                .add("date_submitted", row.date_submitted)
                .add("remarks", row.remarks)
                .add("price", row.price)
                .add("operator_outsource", notApplicable)
                .add("supplier_id", suppliers_id)

                If cDrOption = DROptions.out_without_rs Then

                    .add("type_of_request", Utilities.ifNothingReplaceToBlank(row.recepient_category))
                    .add("requestor_id", row.recepient_id)

                Else

                    .add("type_of_request", "WAREHOUSE")
                    .add("requestor_id", row.stockpileAreaId)

                End If

                _drInfoId = .insertQueryRollBack_and_return_id("dbDeliveryReport_info", SQLCONNECTION, TRANSACTION) '.insertQuery_and_return_id("dbDeliveryReport_info")
            End With

            With _drDetails
                .add("dr_info_id", _drInfoId)
                .add("dr_no", row.drNo)
                .add("wh_id", row.wh_id)
                .add("qty", row.drQty)
                .add("rs_id", _rsId)
                .add("in_to_stockcard", "NO")
                .add("user_id", pub_user_id)

                If cDrOption = DROptions.out_without_rs Then

                    .add("category", "WAREHOUSE")
                    .add("source_id", row.stockpileAreaId)

                Else

                    .add("category", Utilities.ifNothingReplaceToBlank(row.recepient_category))
                    .add("source_id", row.recepient_id)

                End If

                .insertQueryRollBack_and_return_id("dbDeliveryReport_items", SQLCONNECTION, TRANSACTION) '.insertQuery("dbDeliveryReport_items")
            End With

#End Region

            TRANSACTION.Commit()
        Catch ex As Exception
            If TRANSACTION IsNot Nothing Then
                TRANSACTION.Rollback()
            End If
            cCustomMsg.ErrorMessage(ex)
        Finally
            SQLCONNECTION.connection.Close()
        End Try
    End Sub

    Private Sub AutofillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutofillToolStripMenuItem.Click
        Try
            Dim randomDr As String = Utilities.getRandomFiveDigitNumber()
            cmbDrOptions.Text = "WITH DR"
            txtPlateNo.Text = "N/A"
            txtDriver.Text = "NO OPERATOR"
            txtSupplier.Text = "N/A"
            txtConsession.Text = $"con-{randomDr}"
            txtCheckedBy.Text = "UAYAN,KING JAMES P."
            txtReceivedBy.Text = "UAYAN,KING JAMES P."
            txtRemarks.Text = "N/A"
            txtDrNo.Text = $"dr-{randomDr}"
            txtDrQty.Text = 2

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadSomeData()
    End Sub

    Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView2.KeyDown
        Try
            If e.KeyCode = Keys.Up Then
                If DataGridView2.CurrentCell IsNot Nothing Then
                    If DataGridView2.CurrentCell.RowIndex = 0 Then
                        txtSearchItems.Focus()
                    End If
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                selectItemsForStockpileToStockpile()
            End If
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Function delivered() As Double
        Dim tempList = cListOfPendingDr

        For Each row In cListOfPendingDr
            Dim _a = tempList.Where(Function(x) x.drNo = row.drNo).ToList()

            If _a.Count > 1 Then
                'out lng , walay labot ang in kung stockpile to stockpile
                If row.inout = cInOut._OUT Then
                    Dim qtyDelivered As Double = row.drQty
                    delivered += qtyDelivered
                End If
            Else
                Dim qtyDelivered As Double = row.drQty
                delivered += qtyDelivered
            End If
        Next
    End Function


    'UTILITIES
    Private Function enableDisableWhileInitializingData(isEnable As Boolean)
        Try
            loadingPanel.Visible = isEnable
            Panel8.Enabled = Not isEnable

            btnFinalSave.Enabled = Not isEnable
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Sub reloadDrWithoutRefresh(id As Integer,
                                          whatToUpdate As String,
                                          value As PropsFields.create_dr_props_fields)

        Dim data = cListOfPendingDr

        Dim index As Integer = data.FindIndex(Function(x) x.id = id)

        data(index) = value
        DataGridView1.DataSource = data

        'With data(index)

        '    Select Case whatToUpdate
        '        Case NameOf(cn.kpi)
        '            .kpi = value.kpi

        '        Case NameOf(cn.quarry)
        '            .quarry = value.quarry

        '        Case NameOf(cn.warehouse_area)
        '            .warehouse_area = value.warehouse_area
        '            .whArea_category = value.whArea_category

        '        Case NameOf(cn.wh_area_id)
        '            .wh_area_id = value.wh_area_id
        '            .incharge = value.incharge
        '            .warehouse_area = value.warehouse_area
        '            .whArea_category = value.whArea_category

        '        Case NameOf(cn.proper_item_desc)
        '            .wh_pn_id = value.wh_pn_id
        '            .item_desc = value.item_desc
        '    End Select

        'End With

        'dgView.DataSource = Nothing
        'dgView.DataSource = data

        'customizeDagrid()

        'Utilities.datagridviewSpecificRowFocus(dgView, wh_id, "wh_id")
        'data(index)
    End Sub


    Private Function get_operator_id(Name As String) As Integer
        Try
            Dim driver = Results.cListOfOperatorDriver.FirstOrDefault(Function(x)
                                                                          Return ifNothingReplaceToBlank(x.operator_name).ToUpper() = ifNothingReplaceToBlank(Name).ToUpper()
                                                                      End Function)
            If driver IsNot Nothing Then
                Return ifBlankReplaceToZero(driver.operator_id)
            Else
                Return 0
            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function get_equipment_id(plateNo As String) As Integer
        Try
            Dim equipment = Results.cListOfEquipments.FirstOrDefault(Function(x)
                                                                         Return ifNothingReplaceToBlank(x.PlateNo).ToUpper() = ifNothingReplaceToBlank(plateNo).ToUpper()
                                                                     End Function)
            If equipment IsNot Nothing Then
                Return ifBlankReplaceToZero(equipment.equipListID)
            Else
                Return 0
            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function get_supplier_id(supplierName As String) As Integer
        Try
            Dim supplier = Results.cListOfSupplier.FirstOrDefault(Function(x)
                                                                      Return ifNothingReplaceToBlank(x.supplierName).ToUpper() = ifNothingReplaceToBlank(supplierName).ToUpper()
                                                                  End Function)
            If supplier IsNot Nothing Then
                Return ifBlankReplaceToZero(supplier.supplier_id)
            Else
                Return 0
            End If

        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Function
End Class