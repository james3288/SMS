Imports System.Data.SqlClient
Imports SUPPLY.FCreateDeliveryReceipt

Public Class FEditRSQtyOnly
    Public cRsQty, cRrQty As Double
    Public cUnit As String
    Private rsQtyUI As New class_placeholder5
    Private unitsUI As New class_placeholder5

    Private customMsg As New customMessageBox
    Public cRsId, cRrItemSubId, cRrItemId As Integer
    Public isFromReceiving As Boolean

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub FEditRSQtyOnly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Dim class_RsQty As New class_placeholder4
            'class_RsQty.king_placeholder_textbox("RS QTY...", txtRSQTY, Nothing, Panel1, My.Resources.product, True)

            'txtRSQTY.Text = cRsQty
            Dim fontFamily As New Dictionary(Of String, String)
            fontFamily.Add("fontName", cFontsFamily.bombardier)
            fontFamily.Add("fontSize", 12)

            rsQtyUI.king_placeholder_textbox("RS QTY...",
                                             txtRSQTY,
                                             Nothing,
                                             Panel1,
                                             My.Resources.received,
                                             True,,,,,
                                             fontFamily)

            unitsUI.king_placeholder_textbox("UNITS...",
                                             txtUnit,
                                             Nothing,
                                             Panel1,
                                             My.Resources.received,
                                             False,,,, False,
                                             fontFamily)

            If isFromReceiving Then
                txtRSQTY.Text = cRrQty
                txtUnit.Text = cUnit
            Else
                txtRSQTY.Text = cRsQty
                txtUnit.Text = cUnit
            End If

            'movable panel
            Dim myPanel As New MovablePanel

            myPanel.addPanel(Panel1)
            myPanel.initializeForm(Me)
            myPanel.addPanelEventHandler()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            If isFromReceiving Then
                updateRrQtyUseCase()
            Else
                updateRsQtyUseCase()
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
        Exit Sub

        '==== condemed code =====

        Dim remaining_b As New class_main_rs_qty
        Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        Dim type_of_purchasing As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(18).Text
        Dim openclose As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(19).Text
        Dim cAgg = FRequistionForm.cAggregates

        Dim listofmainrs = remaining_b.LISTOFMAINRS(rs_no)
        Dim listofmainrs_sub = remaining_b.LISTOFMAINRS_SUB(rs_no)

        Dim remaining_balance As Double

        '<=== OPEN/CLOSE QTY | validate
        If openclose = "OPEN QTY" Then
            remaining_balance = 0
        Else
            remaining_balance = remaining_b.get_remaining_balance(listofmainrs, listofmainrs_sub, FRequistionForm.cAggregates, rs_id)
        End If '===>

        If CDbl(txtRSQTY.Text) > remaining_balance Then
            MessageBox.Show("The RS quantity cannot be changed at this moment," & vbCrLf & vbCrLf & $"in order to continue, the RS quantity '{ txtRSQTY.Text }' must be smaller than the balance '{ remaining_balance }'.!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If remaining_balance < 0 Then
            MessageBox.Show("Unable to change RS quantity; negative remaining balance!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        Select Case type_of_purchasing
            '<== THIS CODE IS FOR FILTER RS QTY VS SA TOTAL WITHDRAWN 
            Case "WITHDRAWAL"
                Dim listofws = cAgg.LISTOFWS
                Dim total_withdrawn As Double = 0

                For Each row In listofws
                    If row.rs_id = rs_id Then
                        total_withdrawn += row.ws_qty
                    End If
                Next

                If total_withdrawn > CDbl(txtRSQTY.Text) Then
                    MessageBox.Show("Unable to edit rs qty, total withrawn is greater than rs qty you'd put!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

            '<== THIS CODE IS FOR FILTER RS QTY VS SA TOTAL PURCHASED 
            Case "PURCHASE ORDER"
                Dim listofpo = cAgg.LISTOFPO
                Dim total_po As Double = 0

                For Each row In listofpo
                    If row.rs_id = rs_id Then
                        total_po += row.qty
                    End If
                Next

                If total_po > CDbl(txtRSQTY.Text) Then
                    MessageBox.Show("Unable to edit rs qty, total purhcased is greater than rs qty you'd put!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

        End Select


        'OG OK ANG TANAN
        remaining_b.update_sub_rs_qty(rs_id, CDbl(txtRSQTY.Text))
        Me.Close()
        FRequistionForm.btnSearch.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

#Region "CRUD"
    Private Function updateRSQuantity(rsQty As Double, units As String) As Boolean
        Try
            Dim updateRsQty As New ColumnValuesObj
            With updateRsQty
                .add("qty", rsQty)
                .add("unit", units)
                .add("user_id_updated", pub_user_id)
                .add("date_log_updated", Date.Parse(Now))

                .setCondition($"rs_id = {cRsId}")

                updateRSQuantity = .updateQuery_return_true("dbrequisition_slip")

                Return updateRSQuantity
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function updateRRQuantity(rrQty As Double, units As String) As Boolean
        Dim transaction As SqlTransaction = Nothing
        Dim newSQLcon As New SQLcon

        Try
            Dim rr_items_result As Boolean
            Dim rr_item_sub_result As Boolean

            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()

            Dim updateRsQty As New ColumnValuesObj
            With updateRsQty
                .add("qty", rrQty)
                .add("unit", units)

                .setCondition($"rr_item_sub_id = {cRrItemSubId}")

                'updateRRQuantity = .updateQuery_return_true("dbreceiving_items_sub")
                rr_item_sub_result = .updateQueryRollBack_and_return_true("dbreceiving_items_sub",
                                                                       newSQLcon,
                                                                       transaction)

            End With


            Dim dbReceivingItems As New ColumnValuesObj
            With dbReceivingItems

                .add("updatedAt", Date.Parse(Now))
                .add("updatedById", pub_user_id)

                .setCondition($"rr_item_id = {cRrItemId}")

                rr_items_result = .updateQueryRollBack_and_return_true("dbreceiving_items",
                                                                       newSQLcon,
                                                                       transaction)
            End With

            transaction.Commit()
            Return rr_item_sub_result

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
        End Try
    End Function

#End Region

#Region "GET"
    Private Function isYou() As Boolean
        Try
            Dim rsModel = FRequesitionFormForDR.getNewDrModel()
            Dim rsRow = rsModel.getListOfRsDatas.FirstOrDefault(Function(x) x.rs_id = cRsId)


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

#Region "BUSINESS LOGIC"
    Private Sub updateRsQtyUseCase()
        Try
            If customMsg.messageYesNo("Are you sure you want update the RS Quantity?", "SMS INFO:", MessageBoxIcon.Question) Then
                Dim updateResult = updateRSQuantity(txtRSQTY.Text, txtUnit.Text)

                If updateResult Then
                    customMsg.message("info", "RS Quantity Successfully Updated...", "SMS INFO:")

                    Dim model = FRequesitionFormForDR.getNewDrModel()
                    model.isUpdateRsQtyOnly = True
                    model.cRsId = cRsId

                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub updateRrQtyUseCase()
        Try
            If customMsg.messageYesNo("Are you sure you want update the RR Quantity?", "SMS INFO:", MessageBoxIcon.Question) Then
                Dim updateResult = updateRRQuantity(txtRSQTY.Text, txtUnit.Text)

                If updateResult Then
                    customMsg.message("info", "RR Quantity Successfully Updated...", "SMS INFO:")

                    Dim model = FReceivingReportListNew.getNEWRRMODEL()
                    model.isUpdateReceiving = True
                    model.cRrItemSubId = cRrItemSubId

                    FReceivingReportListNew.btnSearch.PerformClick()
                    Me.Dispose()
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region
End Class