Imports SUPPLY.class_placeholder5

Public Class CustomizedFields
    Private cOptionsDic As New Dictionary(Of String, Object)
    Private cFields As New Dictionary(Of String, Object)

    Public cListOfFields As New List(Of Fields)
    Public cListOfUIFields As New List(Of UIFields)
    Public Sub initializeOptions(param As Dictionary(Of String, Object))
        cOptionsDic = param
    End Sub

    Public Class UIFields
        Public Property fieldsName As String
        Public Property objFields As New class_placeholder5

    End Class

    Public Sub resetUIBackground(fieldsName As String)
        Dim ui = cListOfUIFields.FirstOrDefault(Function(x) x.fieldsName.ToUpper() = fieldsName.ToUpper())

        If ui IsNot Nothing Then
            ui.objFields.resetBgColor()
        End If
    End Sub


    Public Sub runByBatch()
        cListOfUIFields.Clear()

        With cOptionsDic
            If .ContainsKey("panel") And
                .ContainsKey("icon") And
                .ContainsKey("panelBox") Then

                If cListOfFields.Count > 0 Then
                    For Each fields In cListOfFields
                        Dim panel As New Panel
                        Dim caption As String
                        Dim model As New class_placeholder5
                        Dim justReadOnly As Boolean

                        If fields.panelName = "" Then
                            panel = CType(cOptionsDic("panel"), Panel)
                        Else
                            panel = CType(cOptionsDic("panelBox"), Panel)
                        End If

                        caption = fields.caption
                        justReadOnly = fields.justReadOnly

                        Dim icon As Bitmap
                        icon = CType(cOptionsDic("icon"), Bitmap)

                        If fields.fieldProperty = FieldsProperty.textBox Then
                            Dim textBoxNew As New TextBox
                            textBoxNew = CType(fields.fieldTBox, TextBox)
                            textBoxNew.TabIndex = fields.tabIndex

                            model.king_placeholder_textbox(caption,
                                                           textBoxNew,
                                                           Nothing,
                                                           panel,
                                                           icon,
                                                           fields.numbersOnly,
                                                           model.cCustomColor.Custom1,,,
                                                           justReadOnly)

                            Dim _UI As New UIFields
                            With _UI
                                .fieldsName = textBoxNew.Name
                                .objFields = model
                                cListOfUIFields.Add(_UI)

                            End With

                        ElseIf fields.fieldProperty = FieldsProperty.comboBox Then
                            Dim comboBox As New ComboBox
                            comboBox = CType(fields.fieldCBox, ComboBox)
                            caption = fields.caption
                            model.king_placeholder_combobox(caption,
                                                            comboBox,
                                                            Nothing,
                                                            panel,
                                                            icon,
                                                            model.cCustomColor.Custom1)

                            Dim _UI As New UIFields
                            With _UI
                                .fieldsName = comboBox.Name
                                .objFields = model
                                cListOfUIFields.Add(_UI)

                            End With

                        ElseIf fields.fieldProperty = FieldsProperty.dateTimePicker Then
                            Dim dtpicker As New DateTimePicker
                            dtpicker = CType(fields.fieldDTPicker, DateTimePicker)
                            caption = fields.caption
                            model.king_placeholder_datepicker(caption,
                                                              dtpicker,
                                                              panel,
                                                              icon,
                                                              model.cCustomColor.Custom1)

                            Dim _UI As New UIFields
                            With _UI
                                .fieldsName = dtpicker.Name
                                .objFields = model
                                cListOfUIFields.Add(_UI)
                            End With

                        End If
                    Next
                End If
            End If
        End With

        cListOfFields.Clear()
    End Sub

    Public Sub addCustomizeTextBox(paramTBox As TextBox,
                                   caption As String,
                                   Optional numbersOnly As Boolean = False,
                                   Optional tabIndex As Integer = 0,
                                   Optional panelName As String = "",
                                   Optional justReadOnly As Boolean = False)

        Dim field As New class_placeholder5.Fields

        With field
            .fieldTBox = paramTBox
            .caption = caption
            .fieldProperty = FieldsProperty.textBox
            .numbersOnly = numbersOnly
            .tabIndex = IIf(tabIndex = 0, paramTBox.TabIndex, tabIndex)
            .panelName = panelName
            .justReadOnly = justReadOnly
        End With

        cListOfFields.Add(field)
    End Sub

    Public Sub addCustomizeComboBox(paramCBox As ComboBox,
                                    caption As String,
                                    Optional tabIndex As Integer = 0,
                                    Optional panelName As String = "")

        Dim field As New class_placeholder5.Fields

        With field
            .fieldCBox = paramCBox
            .caption = caption
            .fieldProperty = FieldsProperty.comboBox
            .tabIndex = IIf(tabIndex = 0, paramCBox.TabIndex, tabIndex)
            .panelName = panelName
        End With

        cListOfFields.Add(field)
    End Sub

    Public Sub addCustomizeDatePicker(paramDTpicker As DateTimePicker,
                                      caption As String,
                                      Optional tabIndex As Integer = 0)

        Dim field As New class_placeholder5.Fields

        With field
            .fieldDTPicker = paramDTpicker
            .caption = caption
            .fieldProperty = FieldsProperty.dateTimePicker
            .tabIndex = IIf(tabIndex = 0, paramDTpicker.TabIndex, tabIndex)

        End With

        cListOfFields.Add(field)
    End Sub

    Public Sub automateList(rawList As List(Of String), textBox As TextBox)
        Dim searchlist As New AutoCompleteStringCollection

        For Each row In rawList
            searchlist.Add(row)
        Next
        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        textBox.AutoCompleteCustomSource = searchlist

    End Sub

    Public Sub resetAll()
        For Each row In cListOfUIFields
            If row.objFields.tbox IsNot Nothing Then
                row.objFields.refresh()
            End If
        Next
    End Sub

    Public Sub selectionStartToEnd()
        Try
            For Each row In cListOfUIFields
                If row.objFields.tbox IsNot Nothing Then
                    With row.objFields.tbox
                        .SelectionStart = .Text.Length
                        .SelectionLength = 0
                    End With

                End If
            Next
        Catch ex As Exception
            Dim ccc As New customMessageBox
            ccc.ErrorMessage(ex)
        End Try

    End Sub
End Class
