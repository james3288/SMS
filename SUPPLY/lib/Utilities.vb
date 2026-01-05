Imports System.ComponentModel
Imports System.Reflection



Module Utilities
    Private customMsg As New customMessageBox
    Public Function DateConverter(sDate As String) As DateTime
        If IsDate(sDate) Then
            DateConverter = Date.Parse(sDate)
        Else
            DateConverter = Date.Parse("1990-01-01")
        End If

        Return DateConverter

    End Function

    Public Function is1990(value As String) As String
        If value.Contains("1990") Then
            Return "-"
        Else
            Return value
        End If
    End Function

    Public Function formatProperNames(propItemName As String, propItemDesc As String, wh_pn_id As Integer)
        If wh_pn_id = 0 Then
            Return ""
        Else
            Return $" → {propItemDesc}"
        End If
    End Function

    Public Function withProperName(properName As String)
        Return $" → {properName}"
    End Function

    Public Function checkProperNamingId(itemName As String, itemDesc As String) As Integer
        'check proper naming if set
        Dim checkProperNaming = Results.cListOfProperNaming.Where(Function(x)
                                                                      Return x.item_name.ToUpper() = itemName.ToUpper() And
                                                          x.item_desc.ToUpper() = itemDesc.ToUpper()
                                                                  End Function).ToList()
        If checkProperNaming.Count > 0 Then
            checkProperNamingId = checkProperNaming(0).wh_pn_id
            Return checkProperNamingId
        Else
            Return 0
        End If

    End Function


    ''' <summary>
    ''' This function retrieves the proper name using the warehouse ID (wh_id) and returns a selected warehouse items with the proper names.
    ''' </summary>
    ''' <returns>A selected warehouse items with their proper names.</returns>
    Public Function getProperNameUsingWhPnId(wh_id As Integer) As PropsFields.whItems_props_fields
        Dim checkProperNaming = Results.cResult.Where(Function(x)
                                                          Return x.wh_id = wh_id
                                                      End Function).ToList()

        If checkProperNaming.Count > 0 Then
            getProperNameUsingWhPnId = checkProperNaming(0)
        End If
    End Function


    ''' <summary>
    ''' This function retrieves the proper name using the warehouse proper name ID (wh_pn_id) and returns a selected warehouse items with the proper names.
    ''' </summary>
    ''' <returns>A selected warehouse items with their proper names.</returns>
    Public Function getProperNameUsingWhPnId2(wh_pn_id As Integer) As PropsFields.whItems_properName_fields
        Dim checkProperNaming = Results.cListOfProperNaming.Where(Function(x)
                                                                      Return x.wh_pn_id = wh_pn_id
                                                                  End Function).ToList()

        If checkProperNaming.Count > 0 Then
            getProperNameUsingWhPnId2 = checkProperNaming(0)
            Return getProperNameUsingWhPnId2
        End If
    End Function

    ''' <summary>
    ''' This function retrieves the proper name using the dbwarehouse_items item name and item desc. (sample: item - description) and returns a selected warehouse items with the proper names.
    ''' </summary>
    ''' <returns>A selected warehouse items with their proper names.</returns>
    Public Function getProperNameIdUsingItemNameAndItemDesc(itemNameAndItemDesc As String) As Integer

        Dim checkProperNaming = Results.cListOfProperNaming.Where(Function(x)
                                                                      Return (x.item_name & " - " & x.item_desc).ToUpper() = itemNameAndItemDesc.ToUpper()
                                                                  End Function).ToList()
        If checkProperNaming.Count > 0 Then
            getProperNameIdUsingItemNameAndItemDesc = checkProperNaming(0).wh_pn_id

            Return getProperNameIdUsingItemNameAndItemDesc
        Else
            Return 0
        End If

    End Function

    Public Function getProperNameUsingWhId(wh_id As Integer, Optional itemDescOnly As Boolean = False) As String
        If wh_id > 0 Then
            Dim checkProperNaming = Results.cResult.Where(Function(x)
                                                              Return x.wh_id = wh_id
                                                          End Function).ToList()

            If checkProperNaming.Count > 0 And checkProperNaming(0).wh_pn_id > 0 Then
                If itemDescOnly = True Then
                    getProperNameUsingWhId = $"{checkProperNaming(0).proper_item_desc}"
                Else
                    getProperNameUsingWhId = $"{checkProperNaming(0).proper_item_name} - {checkProperNaming(0).proper_item_desc}"
                End If

            Else
                Return ""
            End If

        Else
            Return ""
        End If

    End Function

    Public Function formatNumberWithComma(value As Double) As String

        formatNumberWithComma = FormatNumber(value, 2, vbTrue, vbFalse, vbTrue)

        Return formatNumberWithComma

    End Function

    Public Sub setSelectedIndex(cmb As ComboBox, find As String)
        Dim index As Integer = cmb.FindStringExact(find)

        If index <> -1 Then
            cmb.SelectedIndex = index  ' Selects the matching item
        End If
    End Sub

    Public Function ListOfFormNames() As List(Of String)
        ListOfFormNames = New List(Of String)

        Dim formTypes = Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) t.IsSubclassOf(GetType(Form)))

        For Each t As Type In formTypes
            ListOfFormNames.Add(t.Name)
        Next
    End Function

    Public Function TrimLastBlank(inputString As String) As String
        If Len(inputString) > 0 And Right(inputString, 1) = " " Then
            TrimLastBlank = Left(inputString, Len(inputString) - 1)
        Else
            TrimLastBlank = inputString
        End If

        Return TrimLastBlank
    End Function

    Public Function ReplaceSingleQuote(inputString As String) As String
        ReplaceSingleQuote = Replace(inputString, "'", "`")
    End Function

    Public Sub searchBoxLocation(lView As Object, n As Integer, panel As Panel)
        Dim dgv As New DataGridView
        Dim lvl As New ListView

        If n = 0 Then
            dgv = lView
        ElseIf n = 1 Then
            lvl = lView

        End If
        Dim x As Integer = ((IIf(n = 0, dgv.Width, lvl.Width) / 2) - (panel.Width / 2))
        Dim y As Integer = ((IIf(n = 0, dgv.Height, dgv.Height) / 2) - (panel.Height / 2))


        panel.Location = New Point(x, y)
        panel.Visible = True
    End Sub

    Public Sub selectedRows(dgv As DataGridView, cellIndex As Integer, searchValue As String)
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(cellIndex).Value IsNot Nothing AndAlso row.Cells(cellIndex).Value.ToString() = searchValue Then
                row.Selected = True
                dgv.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            End If
        Next
    End Sub

    Public Function ifInchargeAlreadyChecked(paramInchargeId As Integer,
                                              paramWhAreaId As Integer,
                                              Optional paramListOfIncharge As List(Of PropsFields.inchargeNew_fields) = Nothing) As List(Of PropsFields.inchargeNew_fields)

        ifInchargeAlreadyChecked = paramListOfIncharge.Where(Function(x) x.incharge_id = paramInchargeId And x.wh_area_id = paramWhAreaId).ToList()

    End Function

    Public Function getWhIncharge(paramWhAreaId As Integer,
                                   Optional paramListOfIncharge As List(Of PropsFields.inchargeNew_fields) = Nothing) As String

        Try
            Dim result = paramListOfIncharge.Where(Function(x) x.wh_area_id = paramWhAreaId).ToList()
            'Dim result = Utilities.ifInchargeAlreadyChecked(paramInchargeId, paramWhAreaId, cListOfIncharge)
            Dim columnNames As New List(Of String)

            For Each row In result
                columnNames.Add(row.whIncharge)
            Next

            ' Convert the list of column names to an array of strings and join them with commas
            Return String.Join(", ", columnNames.ToArray())
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function ifBlankReplaceToZero(value As Object) As Double
        If IsDBNull(value) OrElse
            value Is Nothing OrElse
            value.ToString().Trim() = "" OrElse
            Not IsNumeric(value) Then

            Return 0
        Else
            Return CDbl(value)
        End If
    End Function
    Public Function ifNothingReplaceToBlank(value As Object) As String
        If value = "" Then
            Return ""
        Else
            Return value
        End If
    End Function
    Public Function ifNothingReplaceToDash(value As Object) As String
        If value = "" Then
            Return "-"
        Else
            Return value
        End If
    End Function
    Public Function formatProperNamingNew_RS_WS_RR_DR(param_wh_pn_id As Integer,
                                          Optional param_wh_id As Integer = 0,
                                          Optional param_rs_item As String = "",
                                          Optional param_item_desc As String = "") As String

        Dim rsProperName As String = getProperNameUsingWhId(param_wh_id)
        Dim wh_pn_id As Integer = Utilities.ifBlankReplaceToZero(param_wh_pn_id)
        Dim properNameWithoutWhId = Results.cListOfProperNaming.Where(Function(x) x.wh_pn_id = wh_pn_id).ToList()

        If param_wh_id = 0 Then
            If properNameWithoutWhId.Count > 0 Then
                formatProperNamingNew_RS_WS_RR_DR = $"{param_rs_item} → {properNameWithoutWhId(0).item_desc}"
            Else
                formatProperNamingNew_RS_WS_RR_DR = $"{param_rs_item}"
            End If
        Else
            formatProperNamingNew_RS_WS_RR_DR = IIf(rsProperName = "", $"{param_rs_item} ({param_item_desc})", $"{param_rs_item} ✔ ({rsProperName})")
        End If
    End Function

    Public Function addSlashToColumn(noOfColumn As Integer) As String()
        Dim a(noOfColumn) As String

        For i = 0 To noOfColumn
            a(i) = "-"
        Next

        Return a
    End Function

    Public Function removeLastCharacter(value As String) As String
        Try
            removeLastCharacter = ""
            If value.Length > 0 Then
                removeLastCharacter = value.Substring(0, value.Length - 1)
            End If
            Return removeLastCharacter

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function na(value As String, n As Integer, Optional nan As Boolean = True) As String

        If n = DisableEnable.withDr Then
            Return value
        ElseIf n = DisableEnable.withoutDr And nan = True Then
            na = "N/A"
            Return na
        ElseIf n = DisableEnable.withoutDr And nan = False Then
            Return 0
        End If

    End Function

    Public Function calculateTax(tax_category As String, unitPrice As Double, taxValue As Double) As Double
        Try
            Try
                If tax_category = cTaxCategory.VAT Then
                    Dim vat As Double = taxValue / 100
                    calculateTax = FormatNumber(unitPrice + (unitPrice * vat)).ToString()

                ElseIf tax_category = cTaxCategory.EWT Then

                    Dim vat As Double = taxValue / 100
                    Dim ewt As Double = unitPrice * vat

                    calculateTax = FormatNumber(unitPrice - ewt).ToString()

                ElseIf tax_category = cTaxCategory.NOT_APPLICABLE Then

                    calculateTax = unitPrice
                End If

            Catch ex As Exception
                customMsg.ErrorMessage(ex)
            End Try
        Catch ex As Exception

        End Try
    End Function

    Public Function customListviewItem(Optional param_backColor As Color = Nothing,
                                        Optional param_datas As String() = Nothing,
                                        Optional param_fonts As FontStyle = FontStyle.Regular,
                                        Optional fontSize As Integer = 11,
                                        Optional param_forColor As Color = Nothing,
                                        Optional param_forColorTrans As String = Nothing) As ListViewItem

        Dim lvl As New ListViewItem(param_datas)
        lvl.Font = New Font(New FontFamily(cFontsFamily.bombardier), fontSize, param_fonts)
        lvl.ForeColor = param_forColor
        lvl.BackColor = IIf(param_backColor = Nothing, ColorTranslator.FromHtml(param_forColorTrans), param_backColor)

        Return lvl
    End Function

    Public Sub isEditForListView(isEdit As Boolean, listView As ListView, id As Integer)

        If isEdit = True Then
            listfocus1(listView, id)
        End If

        isEdit = False
        id = 0

    End Sub

    Public Function isItemChecked(wh_id As Integer) As String
        If wh_id > 0 Then
            Return ChrW(&H2714)
        End If

        Return ChrW(&H274E)
    End Function

    Public Function checkBox() As String
        Return ChrW(&H2611)
    End Function

    Public Function plusSign() As String
        Return "+"
    End Function
    Public Function minusSign() As String
        Return "-"
    End Function
    Public Function getWarehouseAreaStockpile(id As Integer, category As String, Optional defaultArea As String = "") As String
        Try

            If category = "" Then
                getWarehouseAreaStockpile = defaultArea
            Else
                Dim areaData = Results.rListOfAllCharges.Where(Function(x)
                                                                   Return x.charges_id = id And x.charges_category.ToUpper() = category.ToUpper()
                                                               End Function).ToList()

                If areaData.Count > 0 Then
                    getWarehouseAreaStockpile = areaData(0).charges
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Sub disableEnableWhileLoading(param As Dictionary(Of String, Object), paramDisable As Boolean)
        Try
            For Each kvp As KeyValuePair(Of String, Object) In param
                If kvp.Key = GetType(Button).ToString Then

                    Dim button As New Button
                    button = TryCast(kvp.Value, Button)

                    If button.InvokeRequired Then
                        button.Invoke(Sub()
                                          button.Enabled = paramDisable
                                      End Sub)
                    Else
                        button.Enabled = paramDisable
                    End If

                ElseIf kvp.Key = GetType(ToolStripMenuItem).ToString Then

                    Dim toolstripmenuitem As New ToolStripMenuItem
                    toolstripmenuitem = TryCast(kvp.Value, ToolStripMenuItem)
                    toolstripmenuitem.Enabled = paramDisable

                ElseIf kvp.Key = GetType(ContextMenuStrip).ToString Then

                ElseIf kvp.Key = GetType(DataGridView).ToString Then

                    Dim datagridview As New DataGridView
                    datagridview = TryCast(kvp.Value, DataGridView)
                    datagridview.Enabled = paramDisable

                ElseIf kvp.Key = "loadingPanel" Then

                    Dim panel As New Panel
                    panel = TryCast(kvp.Value, Panel)

                    If panel.InvokeRequired Then
                        panel.Invoke(Sub()
                                         panel.Visible = Not paramDisable
                                     End Sub)
                    Else
                        panel.Visible = Not paramDisable
                    End If
                End If
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub datagridviewLastRowFocus(dgv As DataGridView)
        Try
            If dgv.Rows.Count > 1 Then
                dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(0)

                ' Optionally, make the row selected
                dgv.Rows(dgv.Rows.Count - 1).Selected = True
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


    Public Function datagridviewSelectId(dgv As DataGridView, columnName As String) As Integer
        Try
            datagridviewSelectId = dgv.SelectedRows(0).Cells(columnName).Value
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Sub ErrorMessage(name As String)
        Try
            customMsg.message("error", $"{name} must not be empty!", "SUPPLY INFO:")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub SomethingWentWrong(message As String)
        customMsg.message("error", $"something went wrong in {message}...", "SUPPLY INFO:")
    End Sub

    Public Function DateDifference(dateTo As DateTime, dateFrom As DateTime) As String
        Try
            Dim diff As TimeSpan = dateTo - dateFrom
            Dim days As Integer = diff.Days

            Dim result As String
            If days = 1 Then
                result = "1 day"
            Else
                result = days.ToString() & " days"
            End If

            Return result

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function IsNothingOrEmpty(data As Object, col As String) As Boolean
        If data.IsNull(col) Then
            Return True
        End If
    End Function

    Public Function isAuthenticated(auth As String) As Boolean
        Try
            If auth.ToUpper() = cUserAuthentication.ADMIN Then
                Return True
            Else
                customMsg.message("error", "You are not allowed to this transaction, Please contact KJ from IT", "SUPPLY INFO:")
                Return False
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function isAuthenticatedWithoutMessage(auth As String) As Boolean
        Try
            If auth.ToUpper() = cUserAuthentication.ADMIN Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function converToDouble(value As String) As Double
        Try
            converToDouble = Double.Parse(value, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture)
            Return converToDouble

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function getRandomFiveDigitNumber() As String
        Try
            Dim rnd As New Random()
            Dim number As Integer = rnd.Next(10000, 100000) ' Range: 10000 to 99999
            getRandomFiveDigitNumber = number.ToString()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function customListViewHeight(lView As ListView, Optional height As Integer = 28)
        Try
            Dim imgList As New ImageList()
            imgList.ImageSize = New Size(1, height) ' Width doesn’t matter, height = 40px
            lView.SmallImageList = imgList   ' Attach to ListView

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function customListViewRowColorAndFonts(a As String(),
                                                   backColor As Color,
                                                   foreColor As Color,
                                                   font As String) As ListViewItem
        Try
            customListViewRowColorAndFonts = New ListViewItem(a)
            customListViewRowColorAndFonts.BackColor = backColor
            customListViewRowColorAndFonts.ForeColor = foreColor
            customListViewRowColorAndFonts.Font = New Font(font, 13, FontStyle.Regular)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


#Region "WAREHOUSING"

    Public Function getFinalData() As List(Of PropsFields.whItemsFinal)
        getFinalData = New List(Of PropsFields.whItemsFinal)

        Dim data = From Wh_Item In Results.cResult
                   Group Join Incharge In Results.cResult2
                       On Wh_Item.incharge_id Equals Incharge.incharge_id
                       Into WhItem_InchargeGroup = Group
                   From final In WhItem_InchargeGroup.DefaultIfEmpty()
                   Select
                            Wh_Item.wh_id,
                            Wh_Item.item_name,
                            Wh_Item.item_desc,
                            Wh_Item.classification,
                            Wh_Item.type_of_item,
                            Wh_Item.warehouse_area,
                            Wh_Item.specific_loc,
                            Wh_Item.incharge,
                            Wh_Item.reorder_point,
                            Wh_Item.default_price,
                            Wh_Item.units,
                            Wh_Item.inout,
                            Wh_Item.set_det_id,
                            Wh_Item.division,
                            Wh_Item.Turnover,
                            final?.firstname,
                            final?.lastname,
                            Wh_Item.incharge_id,
                            Wh_Item.disable,
                            Wh_Item.proper_item_name,
                            Wh_Item.proper_item_desc,
                            Wh_Item.wh_pn_id,
                            Wh_Item.quarry,
                            Wh_Item.wh_area_id,
                            Wh_Item.whArea_category,
                            Wh_Item.kpi


        For Each row In data
            Dim c As New PropsFields.whItemsFinal

            With c
                .wh_id = row.wh_id
                .item_name = row.item_name
                .item_desc = row.item_desc
                .classification = row.classification
                .type_of_item = row.type_of_item
                .warehouse_area = row.warehouse_area
                .specific_loc = row.specific_loc
                .incharge = row.incharge
                .reorder_point = row.reorder_point
                .default_price = row.default_price
                .units = row.units
                .inout = row.inout
                .set_det_id = row.set_det_id
                .division = row.division
                .Turnover = row.Turnover
                .firstname = row.firstname
                .lastname = row.lastname
                .incharge_id = row.incharge_id
                .disable = row.disable
                .proper_item_name = row.proper_item_name
                .proper_item_desc = row.proper_item_desc
                .wh_pn_id = row.wh_pn_id
                .quarry = row.quarry
                .wh_area_id = row.wh_area_id
                .whArea_category = row.whArea_category
                .kpi = row.kpi
            End With

            getFinalData.Add(c)
        Next
        Return getFinalData
    End Function

    Public Function convertWarehouseToWarehouseStockpile(area As String)
        Try
            If area.Contains("WAREHOUSE") Then
                Return $"{area}/STOCKPILE".ToUpper()

            ElseIf area.Contains("STOCKPILE") Then
                Return $"WAREHOUSE/{area}"

            Else
                Return area
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

#Region "DATAGRIDVIEW"
    Public Sub datagridviewSpecificRowFocus(dgv As DataGridView, id As Integer, columnName As String)
        Try
            If dgv.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgv.Rows
                    If Not CStr(row.Cells(columnName).Value) = "-" Then
                        If Not row.IsNewRow AndAlso Convert.ToInt32(row.Cells(columnName).Value) = id Then
                            row.Selected = True
                            If dgv.CurrentCell IsNot Nothing Then
                                dgv.CurrentCell = row.Cells(0) ' focus on the first cell of the row
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#End Region

#Region "MAINTENANCE"
    Public Sub UnderMaintenance()
        FUnderMaintenance.ShowDialog()
    End Sub
#End Region

#Region "CONTEXT MENU"
    Public Sub disableAllItemsFromContextMenu(contextMenuStrip As ContextMenuStrip)
        For Each item As ToolStripMenuItem In contextMenuStrip.Items
            If item.HasDropDownItems Then
                For Each subItem As ToolStripItem In item.DropDownItems
                    If TypeOf subItem Is ToolStripMenuItem Then
                        ' Recursive call if there are nested dropdowns
                        subItem.Enabled = False
                    Else
                        subItem.Enabled = False
                    End If
                Next
            Else
                item.Enabled = False
            End If

        Next
    End Sub
    Public Sub enableDisableToolStrip(item As ToolStripMenuItem, isEnable As Boolean)
        If item.HasDropDownItems Then
            For Each subItem As ToolStripItem In item.DropDownItems
                If TypeOf subItem Is ToolStripMenuItem Then
                    ' Recursive call if there are nested dropdowns
                    subItem.Enabled = isEnable
                Else
                    subItem.Enabled = isEnable
                End If
            Next
        Else
            item.Enabled = isEnable
        End If

        item.Enabled = isEnable
    End Sub
#End Region

#Region "RESTRICTION"
    Public Function isNotRestrictedTo(param_department As String)
        Try
            If department?.ToUpper().Contains(param_department.ToUpper()) Then
                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function isOnwerOfData(userId As Integer)
        Try

            If userId = pub_user_id Then
                Return True
            End If

            Return False
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

#Region "USERS"
    Public Function getUserCompleteNameFromHrmsData(userId As Integer) As String

        Try
            If Results.cListOfSmsUsers IsNot Nothing And
                Results.cListOfEmployeeDatas IsNot Nothing Then

                Dim smsUser = Results.cListOfSmsUsers.FirstOrDefault(Function(x) x.user_id = userId)

                If smsUser IsNot Nothing Then
                    Dim hrmsUser = Results.cListOfEmployeeDatas.FirstOrDefault(Function(x) x.employee_id = smsUser.employee_id)

                    Return $"{hrmsUser?.last_name}, {hrmsUser.first_name}"
                End If

            End If

            Return ""
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
#End Region
End Module
