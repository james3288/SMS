Public Class FReceiving_Searchby

    Private cListOfTextbox As New List(Of class_placeholder3)
    Private clistOfCombobox As New List(Of class_placeholder3)
    Public listofsupplier As New class_supplier
    Public listofcharges As New class_charges
    Public listofitems As New class_items

    Public txtname As String
    Public searchUI, itemUI, modeUI, typeOfChargesUI As New class_placeholder4
    Private Sub btnExit_panel_duration_Click(sender As Object, e As EventArgs) Handles btnExit_panel_duration.Click
        Me.Dispose()

    End Sub

    Private Sub FReceiving_Searchby_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        filterListofTextbox_combobox.Clear()

        'placeholder_textbox(txtSearch, txtname, listofsupplier.cListOfSupplier, Panel1, My.Resources.username_icon, "FReceiving_Searchby_supplier")
        'placeholder_textbox(txtItem, "Items", listofitems.cListOfItems, Panel1, My.Resources.username_icon, "FReceiving_Searchby_items")
        'placeholder_combobox(cmbMode, "MODE", Panel1, My.Resources.Access_icon)
        'placeholder_combobox(cmbCharges, "TYPE OF CHARGES", Panel1, My.Resources.Access_icon)



        searchUI.king_placeholder_textbox(txtname, txtSearch, Nothing, Panel1, My.Resources.username_icon, False, "White")

        itemUI.king_placeholder_textbox("Items", txtItem, Nothing, Panel1, My.Resources.username_icon, False, "White")

        modeUI.king_placeholder_combobox("Mode", cmbMode, Nothing, Panel1, My.Resources.username_icon, "White")

        modeUI.king_placeholder_combobox("Type of Charges", cmbCharges, Nothing, Panel1, My.Resources.username_icon, "White")

        For Each charges In listofcharges.cListChargesCatName
            cmbCharges.Items.Add(charges.charges_cat)
        Next

    End Sub

    Private Sub placeholder_textbox(tbox As TextBox, caption As String, AutoComplete_data As Object, panel_value As Panel, Optional icon As System.Drawing.Bitmap = Nothing, Optional mark As String = "")
        Dim pl As New class_placeholder3
        tbox.Clear()

        pl.textbox_name = tbox.Name
        pl.TextBox = tbox
        pl.text_hint = caption
        pl.icon = icon
        pl.panel = panel_value
        pl.AutoComplete = AutoComplete_data
        tbox.Text = pl.text_hint
        pl.mark = mark

        pl.Execute()

        cListOfTextbox.Add(pl)

        If panel_value Is Panel1 Then
            filterListofTextbox_combobox.Add(tbox, caption)
        End If


    End Sub

    Private Sub placeholder_combobox(cmb As ComboBox, caption As String, panel_value As Panel, Optional icon As System.Drawing.Bitmap = Nothing)
        Dim pl As New class_placeholder3

        pl.ComboBox = cmb
        pl.text_hint = caption
        pl.icon = icon
        pl.panel = panel_value
        cmb.Text = pl.text_hint
        pl.Execute_1()

        clistOfCombobox.Add(pl)

        If panel_value Is Panel1 Then
            filterListofTextbox_combobox.Add(cmb, caption)
        End If
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
        If cmbMode.Text = "ENABLE" Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        With FReceivingReportList
            .mR1 = False
            .cListOfReceiving.Clear()
            .mSearchBy = .cmbSearch.Text
            .mSearch = txtSearch.Text
            .mItems = txtItem.Text

            .DateFrom = Date.Parse(dtpfrom.Text)
            .DateTo = Date.Parse(dtpto.Text)

            'Panel3.Location = New Point(Me.Location.X - Me.Width, Me.Location.Y)
            '.Panel3.Visible = True

            '.start_search()
            Dim item As String = IIf(itemUI.placeHolder.ToUpper = txtItem.Text.ToUpper, "", txtItem.Text)
            Dim search As String = IIf(searchUI.placeHolder.ToUpper = txtSearch.Text.ToUpper, "", txtSearch.Text)
            .start_search2(Date.Parse(dtpfrom.Text), Date.Parse(dtpto.Text), item, .cmbSearch.Text, search)
        End With



    End Sub

    Private Sub cmbCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCharges.SelectedIndexChanged
        txtSearch.Clear()
        Dim chargesdata As New class_charges

        chargesdata.get_charges_category_data(cmbCharges.Text)

        Dim cListOfData = chargesdata.cListOfChargesCatData
        Dim chargesdatalist As New AutoCompleteStringCollection

        For Each row In cListOfData
            chargesdatalist.Add(row.charges_cat_data)
        Next

        txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtSearch.AutoCompleteCustomSource = chargesdatalist
        'searchlist = Nothing
    End Sub

End Class