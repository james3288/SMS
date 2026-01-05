

Public Class class_placeholder5
    Private cPlaceholder As String
    Private t As New TextBox
    Private cCombobox As New ComboBox
    Private cAutocomplete As Object
    Private cIcon As System.Drawing.Bitmap
    Private cThemeColor As String = "White"
    Private cThemeHoverColor As String = "White"
    Private cDtp As New DateTimePicker
    Private cBg_label As New Label
    Private cToolTipMessage As String
    Public cCustomColor As New CustomColor

    Dim label As New Label
    Private cOptionsDic As New Dictionary(Of String, Object)
    Private cFields As New Dictionary(Of String, Object)
    Public cListOfFields As New List(Of Fields)
    Private cFont As String = "Century Gothic"
    Private cFontSize As Integer = 10
    Private cMyFontFamily As New Dictionary(Of String, Integer)
    Private cTextBoxBgColor As String = "#D9E4FF"
    Private cTextBoxForeColor As String = "#0D0F13"

    Private customMsg As New customMessageBox
    Public Class Fields
        Public Property fieldProperty As Integer
        Public Property caption As String
        Public Property fieldTBox As TextBox
        Public Property fieldCBox As ComboBox
        Public Property fieldDTPicker As DateTimePicker
        Public Property numbersOnly As Boolean
        Public Property tabIndex As Integer
        Public Property panelName As String
        Public Property justReadOnly As Boolean
    End Class

    Enum themeColorEnum
        backgroundColor = 0
        foreColor = 1
        placeHolder = 3
        hoverBgColor = 4
        hoverForeColor = 5
        leaveForeColor = 6
        defaultForeColor = 7

    End Enum



    Public Class CustomColor
        ReadOnly Property Custom1 As String = "Custom1"
    End Class

    'GET SET
    Public ReadOnly Property tbox As TextBox
        Get
            Return t
        End Get

    End Property

    Public Property tBox2 As TextBox
        Get
            Return t
        End Get
        Set(value As TextBox)
            t = value
        End Set
    End Property

    Public ReadOnly Property cBox As ComboBox
        Get
            Return cCombobox
        End Get

    End Property

    Public ReadOnly Property cDatePicker As DateTimePicker
        Get
            Return cDtp
        End Get

    End Property

    Public ReadOnly Property placeHolder As String
        Get
            Return cPlaceholder
        End Get
    End Property

    Public Property AutoCompleteData As Object
        Get
            Return cAutocomplete ' Retrieve the value of the field
        End Get
        Set(value As Object)
            cAutocomplete = value ' Assign the value to the field
        End Set
    End Property

    Private Sub txt_TextChanged(sender As Object, e As EventArgs)
        Dim tt As TextBox = sender

        If tt.Text = "" Then
            tt.ForeColor = Color.Gray
        Else
            tt.ForeColor = set_theme_color(1)
        End If
    End Sub

    Private Sub cmb_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = sender

        If cmb.Text = "" Then
            cmb.ForeColor = Color.Gray
        Else
            cmb.ForeColor = set_theme_color(1)
        End If
    End Sub

    Public Sub king_placeholder_textbox(caption As String,
                                        txt As TextBox,
                                        Optional autocomplete As List(Of String) = Nothing,
                                        Optional form As Object = Nothing,
                                        Optional icon As System.Drawing.Bitmap = Nothing,
                                        Optional numbersonly As Boolean = False,
                                        Optional theme_color As String = "White",
                                        Optional toolTipMsg As String = "",
                                        Optional theme_hover_color As String = "Custom1",
                                        Optional justReadonly As Boolean = False,
                                        Optional fontFamily As Dictionary(Of String, String) = Nothing)

        Dim tt As TextBox
        Dim panel As New Panel
        Dim forms As New Form
        Dim groupbox As New GroupBox


        cThemeColor = theme_color
        cThemeHoverColor = theme_hover_color
        cToolTipMessage = toolTipMsg

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontName") Then
                cFont = fontFamily("fontName")
            End If
        End If

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontSize") Then
                cFontSize = CInt(fontFamily("fontSize"))
            End If
        End If

        If TypeOf form Is Panel Then
            panel = form
            tt = _initialize_textbox(caption, autocomplete, txt.Location, txt, panel, icon, numbersonly, justReadonly)
            AddHandler tt.TextChanged, AddressOf txt_TextChanged

        ElseIf TypeOf form Is Form Then
            forms = form
            tt = _initialize_textbox(caption, autocomplete, txt.Location, txt, forms, icon, numbersonly, justReadonly)
            AddHandler tt.TextChanged, AddressOf txt_TextChanged

        ElseIf TypeOf form Is GroupBox Then
            groupbox = form
            tt = _initialize_textbox(caption, autocomplete, txt.Location, txt, groupbox, icon, numbersonly)
            AddHandler tt.TextChanged, AddressOf txt_TextChanged

        End If

    End Sub

    Public Sub king_placeholder_multipleLine_textbox(caption As String,
                                                     txt As TextBox,
                                                     Optional autocomplete As List(Of String) = Nothing,
                                                     Optional form As Object = Nothing,
                                                     Optional icon As System.Drawing.Bitmap = Nothing,
                                                     Optional numbersonly As Boolean = False,
                                                     Optional theme_color As String = "White",
                                                     Optional toolTipMsg As String = "",
                                                     Optional theme_hover_color As String = "Custom1",
                                                     Optional fontFamily As Dictionary(Of String, String) = Nothing)

        Dim tt As TextBox
        Dim panel As New Panel
        Dim forms As New Form
        Dim groupbox As New GroupBox

        cThemeColor = theme_color
        cThemeHoverColor = theme_hover_color

        cToolTipMessage = toolTipMsg

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontName") Then
                cFont = fontFamily("fontName")
            End If
        End If

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontSize") Then
                cFontSize = CInt(fontFamily("fontSize"))
            End If
        End If

        If TypeOf form Is Panel Then
            panel = form

            tt = _initialize_multipleLine_textbox(caption, autocomplete, txt.Location, txt, panel, icon, numbersonly)
            AddHandler tt.TextChanged, AddressOf txt_TextChanged


        ElseIf TypeOf form Is Form Then
            forms = form
            tt = _initialize_multipleLine_textbox(caption, autocomplete, txt.Location, txt, forms, icon)
            AddHandler tt.TextChanged, AddressOf txt_TextChanged

        ElseIf TypeOf form Is GroupBox Then
            groupbox = form
            tt = _initialize_multipleLine_textbox(caption, autocomplete, txt.Location, txt, groupbox, icon, numbersonly)
            AddHandler tt.TextChanged, AddressOf txt_TextChanged

        End If

    End Sub
    Public Sub king_placeholder_combobox(caption As String,
                                         combobox As ComboBox,
                                         Optional autocomplete As List(Of String) = Nothing,
                                         Optional form As Object = Nothing,
                                         Optional icon As System.Drawing.Bitmap = Nothing,
                                         Optional theme_color As String = "White",
                                         Optional toolTipMsg As String = "",
                                         Optional theme_hover_color As String = "Custom1",
                                         Optional fontFamily As Dictionary(Of String, String) = Nothing)

        Dim cmb As ComboBox
        Dim panel As New Panel
        Dim forms As New Form
        Dim groupbox As New GroupBox
        cThemeColor = theme_color
        cThemeHoverColor = theme_hover_color
        cToolTipMessage = toolTipMsg

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontName") Then
                cFont = fontFamily("fontName")
            End If
        End If

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontSize") Then
                cFontSize = CInt(fontFamily("fontSize"))
            End If
        End If

        If TypeOf form Is Panel Then
            panel = form
            cmb = _initialize_combobox(caption, autocomplete, combobox.Location, combobox, panel, icon)
            AddHandler cmb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged

        ElseIf TypeOf form Is Form Then
            forms = form
            cmb = _initialize_combobox(caption, autocomplete, combobox.Location, combobox, forms, icon)
            AddHandler cmb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged

        ElseIf TypeOf form Is GroupBox Then
            groupbox = form
            cmb = _initialize_combobox(caption, autocomplete, combobox.Location, combobox, groupbox, icon)
            AddHandler cmb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged

        End If

    End Sub

    Public Sub king_placeholder_datepicker(caption As String,
                                           dtp As DateTimePicker,
                                           Optional form As Object = Nothing,
                                           Optional icon As System.Drawing.Bitmap = Nothing,
                                           Optional theme_color As String = "White",
                                           Optional fontFamily As Dictionary(Of String, String) = Nothing)

        Dim dtpicker As DateTimePicker
        Dim panel As New Panel
        Dim forms As New Form
        cThemeColor = theme_color

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontName") Then
                cFont = fontFamily("fontName")
            End If
        End If

        If fontFamily IsNot Nothing Then
            If fontFamily.ContainsKey("fontSize") Then
                cFontSize = CInt(fontFamily("fontSize"))
            End If
        End If

        If TypeOf form Is Panel Then
            panel = form
            dtpicker = _initialize_datepicker(caption, Nothing, dtp.Location, dtp, panel, icon)
        ElseIf TypeOf form Is Form Then
            forms = form
            dtpicker = _initialize_datepicker(caption, Nothing, dtp.Location, dtp, forms, icon)
        End If

    End Sub

    Public Function _initialize_textbox(placeholder As String,
                                        Optional autocomplete As Object = Nothing,
                                        Optional loc As Drawing.Point = Nothing,
                                        Optional txt As TextBox = Nothing,
                                        Optional form As Object = Nothing,
                                        Optional icon As System.Drawing.Bitmap = Nothing,
                                        Optional numbersonly As Boolean = False,
                                        Optional justReadOnly As Boolean = False)

        t = txt
        t.Location = loc
        cPlaceholder = placeholder
        t.Text = cPlaceholder
        cAutocomplete = autocomplete
        t.BorderStyle = BorderStyle.None
        t.Font = New Font(cFont, cFontSize, FontStyle.Regular)
        cIcon = icon
        t.ReadOnly = justReadOnly

        'THEME COLOR
        t.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        t.ForeColor = set_theme_color(themeColorEnum.foreColor) 'Color.White 'set_theme_color(1)

        'AUTOCOMPLETE
        If autocomplete Is Nothing Then
        Else
            set_autocomplete()
        End If

        'TEXTBOX LOCATION
        If loc = Nothing Then
        Else
            t.Location = loc
        End If

        'ADD DESIGN
        If TypeOf form Is Panel Then
            Dim panel As New Panel
            panel = form

            Dim label1 As New Label
            label1 = textbox_design()

            panel.Controls.Add(label1)
            t.BringToFront()

        ElseIf TypeOf form Is GroupBox Then
            Dim panel As New GroupBox
            panel = form

            Dim label1 As New Label
            label1 = textbox_design()

            panel.Controls.Add(label1)
            t.BringToFront()
        End If

#Region "ADD HANDLER HERE"
        AddHandler t.GotFocus, AddressOf gotfocus
        AddHandler t.Leave, AddressOf leave
        AddHandler t.KeyUp, AddressOf textBoxKeyUp
        AddHandler t.KeyDown, AddressOf textBoxKeyDown
        AddHandler t.KeyDown, AddressOf textBoxKeyDown
        AddHandler t.MouseClick, AddressOf textBoxMouseClick
#End Region

        'this function is for set textbox input numbers only | default value: False
        set_numbers_only(numbersonly)

        'AddHandler t.KeyPress, AddressOf textbox_KeyPress

        'Add ToolTip
        Dim toolTip1 As New ToolTip()

        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 500
        toolTip1.ReshowDelay = 500

        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(t, cToolTipMessage)

        Return t
    End Function

    Public Function _initialize_multipleLine_textbox(placeholder As String, Optional autocomplete As Object = Nothing, Optional loc As Drawing.Point = Nothing, Optional txt As TextBox = Nothing, Optional form As Object = Nothing, Optional icon As System.Drawing.Bitmap = Nothing, Optional numbersonly As Boolean = False)

        t = txt
        t.Location = loc
        cPlaceholder = placeholder
        t.Text = cPlaceholder
        cAutocomplete = autocomplete
        t.BorderStyle = BorderStyle.None
        t.Font = New Font(cFont, cFontSize, FontStyle.Regular)
        cIcon = icon

        'THEME COLOR
        t.BackColor = set_theme_color(themeColorEnum.backgroundColor)
        t.ForeColor = set_theme_color(themeColorEnum.foreColor) 'Color.White 'set_theme_color(1)


        'AUTOCOMPLETE
        If autocomplete Is Nothing Then
        Else
            set_autocomplete()
        End If

        'TEXTBOX LOCATION
        If loc = Nothing Then
        Else
            t.Location = loc
        End If

        'ADD DESIGN
        If TypeOf form Is Panel Then
            Dim panel As New Panel
            panel = form

            Dim label1 As New Label
            label1 = multipleLine_textbox_design()

            panel.Controls.Add(label1)
            t.BringToFront()

        ElseIf TypeOf form Is GroupBox Then
            Dim panel As New GroupBox
            panel = form

            Dim label1 As New Label
            label1 = multipleLine_textbox_design()

            panel.Controls.Add(label1)
            t.BringToFront()
        End If

#Region "ADD HANDLER HERE"
        AddHandler t.GotFocus, AddressOf gotfocus
        AddHandler t.Leave, AddressOf leave
        AddHandler t.KeyUp, AddressOf textBoxKeyUp
        AddHandler t.KeyDown, AddressOf textBoxKeyDown
        AddHandler t.MouseClick, AddressOf textBoxMouseClick
#End Region


        'this function is for set textbox input numbers only | default value: False
        set_numbers_only(numbersonly)

        'AddHandler t.KeyPress, AddressOf textbox_KeyPress

        'Add ToolTip
        Dim toolTip1 As New ToolTip()

        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 500
        toolTip1.ReshowDelay = 500

        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(t, cToolTipMessage)

        Return t
    End Function
    Public Function _initialize_combobox(placeholder As String, Optional autocomplete As Object = Nothing, Optional loc As Drawing.Point = Nothing, Optional combobox As ComboBox = Nothing, Optional form As Object = Nothing, Optional icon As System.Drawing.Bitmap = Nothing)

        cCombobox = combobox
        With cCombobox
            .Location = loc
            cPlaceholder = placeholder
            .Text = cPlaceholder
            cAutocomplete = autocomplete

            .Font = New Font(cFont, cFontSize, FontStyle.Regular)

            cIcon = icon


            'COMBOBOX LOCATION
            If loc = Nothing Then
            Else
                .Location = loc
            End If

            'THEME COLOR
            .BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            .ForeColor = set_theme_color_new(themeColorEnum.foreColor)

            'ADD DESIGN
            If TypeOf form Is Panel Then
                Dim panel As New Panel
                panel = form
                panel.Controls.Add(combobox_design())
            ElseIf TypeOf form Is GroupBox Then
                Dim panel As New GroupBox
                panel = form
                panel.Controls.Add(combobox_design())
            Else

            End If


            AddHandler .GotFocus, AddressOf cmb_gotfocus
            AddHandler .Leave, AddressOf cmb_leave


        End With

        Dim toolTip1 As New ToolTip()
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 500
        toolTip1.ReshowDelay = 500

        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(cCombobox, cToolTipMessage)

        Return cCombobox
    End Function

    Public Function _initialize_datepicker(placeholder As String, Optional autocomplete As Object = Nothing, Optional loc As Drawing.Point = Nothing, Optional dtp As DateTimePicker = Nothing, Optional form As Object = Nothing, Optional icon As System.Drawing.Bitmap = Nothing)

        cDtp = dtp

        With cDtp
            .Location = loc
            .Font = New Font(cFont, cFontSize, FontStyle.Regular)
            cIcon = icon


            'DATETIMEPICKER LOCATION
            If loc = Nothing Then
            Else
                .Location = loc
            End If

            'THEME COLOR
            .BackColor = set_theme_color(themeColorEnum.backgroundColor)
            .ForeColor = set_theme_color(themeColorEnum.foreColor)

            'ADD DESIGN
            If TypeOf form Is Panel Then
                Dim panel As New Panel
                panel = form

                'Dim combobox1 As New ComboBox
                'combobox1 = combobox_design()
                cBg_label = datetimepicker_design()
                panel.Controls.Add(cBg_label)
            Else

            End If


#Region "ADD HANDLER HERE"
            AddHandler .GotFocus, AddressOf cmb_gotfocus
            AddHandler .Leave, AddressOf cmb_leave
#End Region

        End With

        Return cDtp
    End Function

    Public Function textbox_design()

        label.Name = "label_" & t.Name
        label.Text = ""
        label.Size = New Size(266, 30)
        label.BorderStyle = BorderStyle.FixedSingle
        label.Location = New Point(t.Location.X - 35, t.Location.Y - 5)
        label.Image = cIcon
        label.ImageAlign = ContentAlignment.MiddleLeft
        label.Width = t.Width + 38
        label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)

        Return label
    End Function

    Public Function multipleLine_textbox_design()

        label.Name = "label_" & t.Name
        label.Text = ""
        label.Size = New Size(266, 60)
        label.BorderStyle = BorderStyle.FixedSingle
        label.Location = New Point(t.Location.X - 35, t.Location.Y - 5)
        label.Image = cIcon
        label.ImageAlign = ContentAlignment.TopLeft
        label.Width = t.Width + 38
        label.BackColor = set_theme_color(themeColorEnum.backgroundColor)
        label.Height = label.Height + 10

        Return label
    End Function

    Public Function datetimepicker_design()

        Dim label As New Label

        label.Name = "label_" & cDtp.Name
        label.Text = ""
        label.Size = New Size(266, 30)
        label.BorderStyle = BorderStyle.FixedSingle
        label.Location = New Point(cDtp.Location.X - 35, cDtp.Location.Y - 3)
        label.Image = cIcon
        label.ImageAlign = ContentAlignment.MiddleLeft
        label.Width = cDtp.Width + 38
        label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        Return label

    End Function

    Private Function set_theme_color(n As Integer) As Color
        If n = themeColorEnum.backgroundColor Then
            'for backcolor 
            Select Case cThemeColor
                Case "Gray"
                    set_theme_color = Color.Gray
                Case "White"
                    set_theme_color = Color.White
                Case "Black"
                    set_theme_color = Color.Black
                Case "Orange"
                    set_theme_color = Color.Orange
                Case "Green"
                    set_theme_color = Color.Green
                Case "Yellow"
                    set_theme_color = Color.Yellow
                Case "Purple"
                    set_theme_color = Color.Purple
                Case "Custom1"
                    set_theme_color = ColorTranslator.FromHtml(cTextBoxBgColor)

            End Select
        End If

        If n = themeColorEnum.foreColor Then
            'for forecolor
            Select Case cThemeColor
                Case "White", "Orange", "Yellow"
                    set_theme_color = Color.Gray
                Case "Black", "Green", "Gray", "Purple"
                    set_theme_color = Color.White
                Case "Custom1"

                    If t.BackColor = set_theme_color(themeColorEnum.hoverBgColor) Then
                        set_theme_color = Color.Black
                    Else
                        'set_theme_color = ColorTranslator.FromHtml("#E9E7E9")
                        set_theme_color = Color.White
                    End If

            End Select
        End If

        If n = themeColorEnum.placeHolder Then
            'for placeholder color 
            Select Case cThemeColor
                Case "Gray", "Black"
                    set_theme_color = Color.LightGray
                Case "White"
                    set_theme_color = Color.Gray
                Case "Orange"
                    set_theme_color = Color.Yellow
                Case "Green"
                    set_theme_color = Color.LightYellow
                Case "Yellow"
                    set_theme_color = Color.Red
                Case "Purple"
                    set_theme_color = Color.LightBlue
                Case "Custom1"
                    set_theme_color = ColorTranslator.FromHtml("#E9E7E9")
            End Select
        End If

        If n = themeColorEnum.hoverBgColor Then
            Select Case cThemeHoverColor
                Case "Gray", "Black"
                    set_theme_color = Color.LightGray
                Case "White"
                    'set default #1C2837 instead of white for some reason
                    set_theme_color = ColorTranslator.FromHtml("#1C2837")
                Case "Orange"
                    set_theme_color = Color.Yellow
                Case "Green"
                    set_theme_color = Color.LightYellow
                Case "Yellow"
                    set_theme_color = Color.Red
                Case "Purple"
                    set_theme_color = Color.LightBlue
                Case "Custom1"
                    set_theme_color = ColorTranslator.FromHtml("#D9E4FF")
                    'set_theme_color = Color.Yellow
                    'label.BackColor = Color.Yellow
            End Select
        End If

        If n = themeColorEnum.hoverForeColor Then
            Select Case cThemeHoverColor
                Case "Gray", "Black"
                    set_theme_color = Color.LightGray
                Case "White"
                    'set default #1C2837 instead of white for some reason
                    set_theme_color = ColorTranslator.FromHtml("#1C2837")
                Case "Orange"
                    set_theme_color = Color.Yellow
                Case "Green"
                    set_theme_color = Color.LightYellow
                Case "Yellow"
                    set_theme_color = Color.Red
                Case "Purple"
                    set_theme_color = Color.LightBlue
                Case "Custom1"
                    ' set_theme_color = Color.Red
                    set_theme_color = ColorTranslator.FromHtml(cTextBoxBgColor)
            End Select
        End If

        If n = themeColorEnum.leaveForeColor Then
            Select Case cThemeHoverColor
                Case "Custom1"
                    set_theme_color = Color.Orange
            End Select
        End If

    End Function

    Private Function set_theme_color_new(n As Integer) As Color
        If n = themeColorEnum.backgroundColor Then
            Return getColor(cThemeColor)

        ElseIf n = themeColorEnum.hoverBgColor Then
            Return getColor(cThemeHoverColor)

        ElseIf n = themeColorEnum.hoverForeColor Then
            If t.Text = cPlaceholder Or t.Text = "" Then
                Return getForeColor("Default")
            Else
                Return getForeColor(cThemeHoverColor)
            End If
        ElseIf n = themeColorEnum.defaultForeColor Then
            If t.Text = cPlaceholder Or t.Text = "" Then
                Return getForeColor("Default")
            Else
                Return getForeColor(cThemeHoverColor)
            End If
        End If

    End Function

    Public Function combobox_design()

        ' Dim label As New Label

        label.Name = "label_" & cCombobox.Name
        label.Text = ""
        label.Size = New Size(266, 30)
        label.BorderStyle = BorderStyle.FixedSingle
        label.Location = New Point(cCombobox.Location.X - 35, cCombobox.Location.Y - 3)
        label.Image = cIcon
        label.ImageAlign = ContentAlignment.MiddleLeft
        label.Width = cCombobox.Width + 38
        label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        Return label

    End Function
    Public Sub set_autocomplete()
        Dim searchlist As New AutoCompleteStringCollection

        Dim cListOfData = cAutocomplete
        For Each row In cListOfData
            searchlist.Add(row)
        Next

        t.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        t.AutoCompleteSource = AutoCompleteSource.CustomSource
        t.AutoCompleteCustomSource = searchlist

    End Sub

#Region "TEXTBOX GOTFOCUS"
    Private Sub gotfocus()
        If t.Text = cPlaceholder Then
            't.Clear()
            t.SelectionStart = 0
            t.Font = New Font(t.Font, FontStyle.Italic)
            t.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            t.ForeColor = set_theme_color_new(themeColorEnum.hoverForeColor)
            label.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)

        Else
            t.Font = New Font(t.Font, FontStyle.Italic)
            t.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            t.ForeColor = set_theme_color_new(themeColorEnum.hoverForeColor)
            label.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)

        End If
    End Sub

#End Region

#Region "TEXTBOX EVENTS"
    Private Sub textBoxKeyUp()

        'If t.Text = "" And t.TextLength = 0 Then
        '    t.Text = cPlaceholder
        '    t.ForeColor = set_theme_color_new(themeColorEnum.hoverForeColor)
        '    t.Font = New Font(t.Font, FontStyle.Italic)
        'End If
    End Sub

    Private Sub textBoxKeyDown()
        If t.Text = placeHolder Then
            t.Clear()
            't.Font = New Font(t.Font, FontStyle.Regular)
        Else
            t.ForeColor = set_theme_color_new(themeColorEnum.hoverForeColor)
            't.Font = New Font(t.Font, FontStyle.Regular)
        End If
    End Sub

    Private Sub textBoxMouseClick()
        If t.Text = placeHolder Then
            t.SelectionStart = 0
        End If
    End Sub

    Private Sub cmb_gotfocus()
        If cCombobox.Text = cPlaceholder Then
            cCombobox.Text = ""
            cCombobox.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            cCombobox.ForeColor = set_theme_color_new(themeColorEnum.hoverForeColor)
            label.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
        Else
            cCombobox.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            cCombobox.ForeColor = set_theme_color_new(themeColorEnum.hoverForeColor)
            label.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
        End If
    End Sub

    Public Sub listViewItemsToTextbox(value As String)
        t.Text = value
        label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        t.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        t.ForeColor = set_theme_color_new(themeColorEnum.leaveForeColor)

    End Sub

    Public Sub refresh()

        If t.Focused Then
            t.Text = placeHolder
            label.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            t.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            t.ForeColor = set_theme_color_new(themeColorEnum.leaveForeColor)
            t.Font = New Font(t.Font, FontStyle.Italic)
        Else
            t.Text = placeHolder
            label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            t.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            t.ForeColor = set_theme_color_new(themeColorEnum.placeHolder)
            t.Font = New Font(t.Font, FontStyle.Regular)
        End If

    End Sub

    Public Sub refresh_without_clear()

        If t.Focused Then
            label.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            t.BackColor = set_theme_color_new(themeColorEnum.hoverBgColor)
            t.ForeColor = set_theme_color_new(themeColorEnum.leaveForeColor)
            t.Font = New Font(t.Font, FontStyle.Italic)

        Else
            label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            t.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            t.ForeColor = set_theme_color_new(themeColorEnum.placeHolder)
            t.Font = New Font(t.Font, FontStyle.Regular)

        End If

    End Sub
    Private Sub leave()
        If t.Text = "" Or t.Text = cPlaceholder Then
            t.Text = cPlaceholder
            t.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            t.ForeColor = Color.Gray 'set_theme_color_new(themeColorEnum.defaultForeColor)
            label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        Else
            t.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            t.ForeColor = set_theme_color_new(themeColorEnum.hoverForeColor)
            label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)

            'If t.Text = placeHolder Then
            '    t.ForeColor = set_theme_color_new(themeColorEnum.foreColor)
            'Else
            '    t.ForeColor = set_theme_color_new(themeColorEnum.leaveForeColor)
            'End If

            'label.BackColor = set_theme_color(themeColorEnum.backgroundColor)
        End If

        'resetBgColor()
    End Sub
#End Region


    Private Sub cmb_leave()
        If cCombobox.Text = "" Then
            cCombobox.Text = cPlaceholder
            cCombobox.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            cCombobox.ForeColor = set_theme_color_new(themeColorEnum.foreColor)
            label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        Else
            cCombobox.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
            cCombobox.ForeColor = set_theme_color_new(themeColorEnum.foreColor)
            label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        End If
    End Sub

    Public Function blank_textbox() As Boolean
        If t.Text.ToUpper = cPlaceholder.ToUpper Or t.Text = "" Then
            blank_textbox = True

            'Dim newMessage As New FMessageForm
            'With newMessage
            '    .title = "PCMBS Administrator Message:"
            '    .message = $"textbox '{cPlaceholder }' must not be blank!"
            '    .status = "error"
            '    .ShowDialog()
            'End With
            Dim customMsg As New customMessageBox
            customMsg.message("error", $"textbox { cPlaceholder } must not be blank!", "SUPPLY INFO:")


            'MessageBox.Show("textbox '" & cPlaceholder & "' must not be blank...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            t.Focus()
        End If

        Return blank_textbox
    End Function
    Public Function blank_combobox() As Boolean
        If cCombobox.Text.ToUpper = cPlaceholder.ToUpper Or cCombobox.Text = "" Then
            blank_combobox = True
            'Dim newMessage As New FMessageForm
            'With newMessage
            '    .title = "PCMBS Administrator Message:"
            '    .message = $"combobox '{cPlaceholder }' must not be blank!"
            '    .status = "error"
            '    .ShowDialog()
            'End With
            Dim customMsg As New customMessageBox
            customMsg.message("error", $"textbox { cPlaceholder } must not be blank!", "SUPPLY INFO:")


            cCombobox.Focus()
        End If

        Return blank_combobox
    End Function
    Public Sub set_numbers_only(trigger As Boolean)
        If trigger = True Then
            AddHandler t.KeyPress, AddressOf textbox_KeyPress
        ElseIf trigger = False Then
            RemoveHandler t.KeyPress, AddressOf textbox_KeyPress
        End If
    End Sub
    Private Sub textbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Allow only numbers, backspace and decimal point
        If (Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = ControlChars.Back) Then
            e.Handled = True
        End If
    End Sub
    Public Function ifBlankTexbox() As Boolean
        If t.Text.ToUpper = cPlaceholder.ToUpper OrElse t.Text = "" Then
            pubBlankTextFieldName = t.Name
            Return True
        End If
    End Function

    Public Function isBlankTextBox() As Boolean
        If t.Text.ToUpper = cPlaceholder.ToUpper OrElse t.Text = "" Then
            Return True
        End If
    End Function


    Public Function isBlankComboBox() As Boolean
        If cCombobox.Text.ToUpper = cPlaceholder.ToUpper OrElse cCombobox.Text = "" Then
            Return True
        End If
    End Function
    Public Function ifBlankCombobox() As Boolean
        If cCombobox.Text.ToUpper = cPlaceholder.ToUpper OrElse cCombobox.Text = "" Then
            Return True
        End If
    End Function

    Public Sub resetBgColor()
        t.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
        t.ForeColor = set_theme_color_new(themeColorEnum.defaultForeColor)
        label.BackColor = set_theme_color_new(themeColorEnum.backgroundColor)
    End Sub

    Public Sub initializeOptions(param As Dictionary(Of String, Object))
        cOptionsDic = param
    End Sub

    Public Sub runByBatch()
        With cOptionsDic
            If .ContainsKey("panel") And
                .ContainsKey("icon") Then

                If cListOfFields.Count > 0 Then
                    For Each fields In cListOfFields
                        Dim panel As New Panel
                        Dim caption As String

                        panel = CType(cOptionsDic("panel"), Panel)
                        caption = fields.caption

                        Dim icon As Bitmap
                        icon = CType(cOptionsDic("icon"), Bitmap)

                        If fields.fieldProperty = FieldsProperty.textBox Then
                            Dim textBoxNew As New TextBox
                            textBoxNew = CType(fields.fieldTBox, TextBox)

                            king_placeholder_textbox(caption, textBoxNew, Nothing, panel, icon, False, cCustomColor.Custom1)

                        ElseIf fields.fieldProperty = FieldsProperty.comboBox Then
                            Dim comboBox As New ComboBox
                            comboBox = CType(fields.fieldCBox, ComboBox)

                            caption = fields.caption
                            king_placeholder_combobox(caption, comboBox, Nothing, panel, icon, cCustomColor.Custom1)

                        End If
                    Next
                End If
            End If
        End With

    End Sub

    Public Sub clear_textBox()
        tbox.Text = cPlaceholder

    End Sub
    Public Sub clear_comboBox()
        cBox.Items.Clear()
        cBox.Text = cPlaceholder
    End Sub

    Public Sub readOnlyTextBox(setReadonly As Boolean)
        tbox.ReadOnly = setReadonly
    End Sub


    'Public Sub addFields(captions As String, fields As Object, fieldsOption As Integer)
    '    Dim dic As New Dictionary(Of String, Object)
    '    dic.Add(captions, fields)



    '    Dim _field As New Fields
    '    With _field
    '        .caption = captions
    '        .fieldProperty = fieldsOption
    '        ' .field = fields
    '    End With

    '    cListOfFields.Add(_field)
    'End Sub

#Region "PRIVATE GET"
    Private Function getColor(colorType As String) As Color
        Try
            Select Case colorType
                Case "Gray"
                    getColor = Color.Gray
                Case "White"
                    getColor = Color.White
                Case "Black"
                    getColor = Color.Black
                Case "Orange"
                    getColor = Color.Orange
                Case "Green"
                    getColor = Color.Green
                Case "Yellow"
                    getColor = Color.Yellow
                Case "Purple"
                    getColor = Color.Purple
                Case cCustomColor.Custom1
                    getColor = ColorTranslator.FromHtml(cTextBoxBgColor)
            End Select
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getForeColor(colorType As String) As Color
        Try
            Select Case colorType
                Case "Gray", "Default"
                    getForeColor = Color.Gray
                Case "White"
                    getForeColor = Color.White
                Case "Black"
                    getForeColor = Color.Black
                Case "Orange"
                    getForeColor = Color.Orange
                Case "Green"
                    getForeColor = Color.Green
                Case "Yellow"
                    getForeColor = Color.Yellow
                Case "Purple"
                    getForeColor = Color.Purple
                Case cCustomColor.Custom1
                    getForeColor = ColorTranslator.FromHtml(cTextBoxForeColor)
            End Select
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
End Class
