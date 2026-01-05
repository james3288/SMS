Public Class class_placeholder3
    Private cTextBox As TextBox
    Private cComboBox As ComboBox
    Private cTextHint As String
    Private cFont As Font = New Font("Century Gothic", 11, FontStyle.Italic)
    Private cPanel As Object
    Private cIcon As System.Drawing.Bitmap
    Private cAutoComplete As Object
    Private cMark As String
    Public Property textbox_name As String

    Public Property TextBox() As TextBox
        Get
            Return cTextBox
        End Get
        Set(value As TextBox)
            cTextBox = value
        End Set
    End Property

    Public Property text_hint() As String
        Get
            Return cTextHint
        End Get
        Set(value As String)
            cTextHint = value
        End Set
    End Property

    Public Property font() As Font
        Get
            Return cFont
        End Get
        Set(value As Font)
            cFont = value
        End Set
    End Property

    Public Property panel() As Object
        Get
            Return cPanel
        End Get
        Set(value As Object)
            cPanel = value
        End Set
    End Property

    Public Property mark() As String
        Get
            Return cMark
        End Get
        Set(value As String)
            cMark = value
        End Set
    End Property


    Public Property AutoComplete() As Object
        Get
            Return cAutoComplete
        End Get
        Set(value As Object)
            cAutoComplete = value
        End Set
    End Property

    Public Property icon() As System.Drawing.Bitmap
        Get
            Return cIcon
        End Get
        Set(value As System.Drawing.Bitmap)
            cIcon = value
        End Set
    End Property

    Public Property ComboBox() As ComboBox
        Get
            Return cComboBox
        End Get
        Set(value As ComboBox)
            cComboBox = value
        End Set
    End Property
    Public Function textbox_design()

        Dim label As New Label

        label.Name = "label_" & cTextBox.Name
        label.Text = ""
        label.Size = New Size(266, 30)
        label.BorderStyle = BorderStyle.FixedSingle
        label.BackColor = Color.White
        label.Location = New Point(cTextBox.Location.X - 35, cTextBox.Location.Y - 6)
        label.Image = cIcon
        label.ImageAlign = ContentAlignment.MiddleLeft
        label.Width = cTextBox.Width + 38
        Return label
    End Function
    Public Function combobox_design()

        Dim label As New Label

        label.Name = "label_" & cComboBox.Name
        label.Text = ""
        label.Size = New Size(266, 30)
        label.BorderStyle = BorderStyle.FixedSingle
        label.BackColor = Color.White
        label.Location = New Point(cComboBox.Location.X - 35, cComboBox.Location.Y - 3)
        label.Image = cIcon
        label.ImageAlign = ContentAlignment.MiddleLeft
        label.Width = cComboBox.Width + 38
        Return label
    End Function

    Private Sub auto_fill2()
        Dim searchlist As New AutoCompleteStringCollection

        If cAutoComplete Is Nothing Then
            Exit Sub
        End If

        Dim cListOfData = cAutoComplete

        For Each row In cListOfData
            If cMark = "FAggregates_Balance" Then
                searchlist.Add(row.requestor_desc)

            ElseIf cMark = "FReceiving_Searchby_supplier" Then
                searchlist.Add(row.supplier_name)
            ElseIf cMark = "FReceiving_Searchby_items" Then
                searchlist.Add(row.item_desc)
            Else
                searchlist.Add(row)
            End If

        Next

        cTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        cTextBox.AutoCompleteCustomSource = searchlist
        'searchlist = Nothing
    End Sub
    Public Sub Execute_1()
        If TypeOf (cPanel) Is Panel Then
            Dim panel As New Panel
            panel = cPanel
            panel.Controls.Add(combobox_design)

        ElseIf TypeOf (cPanel) Is Form Then
            Dim form As New Form
            form = cPanel
            form.Controls.Add(combobox_design)
        End If

        cComboBox.Font = cFont
        cComboBox.ForeColor = Color.Gray

        AddHandler cComboBox.GotFocus, AddressOf got_focus_cmb
        AddHandler cComboBox.Leave, AddressOf leaved_cmb
        AddHandler cComboBox.SelectedIndexChanged, AddressOf selected_index_changed
    End Sub

    Private Sub selected_index_changed()
        Try
            If cComboBox.BackColor = Color.OrangeRed Then
                cComboBox.BackColor = Color.White
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub got_focus_cmb()
        Try
            If cComboBox.Text = cTextHint Then
                cComboBox.Text = ""
                cComboBox.ForeColor = Color.Black
            ElseIf cComboBox.Text = "" Then
                cComboBox.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub leaved_cmb()
        Try
            If cComboBox.Text = "" Then
                cComboBox.Text = cTextHint
                cComboBox.ForeColor = Color.Gray
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Execute()
        If TypeOf (cPanel) Is Panel Then
            Dim panel As New Panel
            panel = cPanel
            panel.Controls.Add(textbox_design)

        ElseIf TypeOf (cPanel) Is Form Then
            Dim form As New Form
            form = cPanel
            form.Controls.Add(textbox_design)
        End If

        cTextBox.BorderStyle = BorderStyle.None
        cTextBox.Font = cFont
        cTextBox.ForeColor = Color.Gray

        AddHandler cTextBox.GotFocus, AddressOf got_focus
        AddHandler cTextBox.Leave, AddressOf leaved
        AddHandler cTextBox.KeyPress, AddressOf key_press
        auto_fill2()
    End Sub
    Private Sub key_press()
        Try
            If cTextBox.BackColor = Color.OrangeRed Then
                cTextBox.BackColor = Color.White
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub got_focus()
        Try
            If cTextBox.Text = cTextHint Then
                cTextBox.Text = ""
                cTextBox.ForeColor = Color.Black
            ElseIf cTextBox.Text = "" Then
                cTextBox.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub leaved()
        Try
            If cTextBox.Text = "" Then
                cTextBox.Text = cTextHint
                cTextBox.ForeColor = Color.Gray
                cTextBox.BackColor = Color.White
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
