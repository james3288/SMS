
Imports System.Drawing.Color
Public Class class_placeholder
    Private cTBox As New TextBox
    Private dot As String
    Private cbgColor As New Color
    Private cFontColor As New Color
    Private cFontSize As Integer
    Private cFontStyle As String
    Private cFire As Integer

    Sub New(tbox As TextBox, Optional tBoxColor As Color = Nothing, Optional FontColor As Color = Nothing, Optional font_size As Integer = Nothing, Optional font_style As String = "Arial")

        cTBox = tbox
        dot = "..."
        cbgColor = IIf(tBoxColor = Nothing, Color.White, tBoxColor)
        cFontColor = IIf(FontColor = Nothing, Color.Black, FontColor)
        cFontSize = IIf(font_size = Nothing, 10, font_size)
        cFontStyle = font_style

        'compString(cTBox)

    End Sub
    Public Sub leave(Optional bgColor As Color = Nothing)
        Try
            cTBox.BackColor = IIf(bgColor = Nothing, cbgColor, bgColor)

            Dim placeholder As String = ""

            For Each row In Module1.cListofTextbox
                If row.Key.Name = cTBox.Name Then
                    placeholder = row.Value
                    Exit For
                End If
            Next

            placeholder = placeholder & dot

            If cTBox.Text = "" Then
                cTBox.Text = placeholder
                cTBox.ForeColor = cFontColor
                cTBox.Font = New Font(cFontStyle, cFontSize, FontStyle.Italic)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cFire = 0
        End Try

    End Sub

    Public Sub gotFocus(Optional bgColor As Color = Nothing)

        Dim placeholder As String = ""

        Try
            cTBox.BackColor = IIf(bgColor = Nothing, cbgColor, bgColor)

            For Each row In Module1.cListofTextbox
                If row.Key.Name = cTBox.Name Then
                    placeholder = row.Value
                    Exit For
                End If
            Next

            placeholder = placeholder & dot
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub l(txt As TextBox)

        Dim project As New class_requestor
        project._initialize("PROJECT")

        Dim listofproj = project.cListOfRequestor

        Dim searchlist As New AutoCompleteStringCollection

        For Each row In listofproj
            searchlist.Add(row.requestor_desc)
        Next

        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt.AutoCompleteCustomSource = searchlist

        searchlist = Nothing

    End Sub
    Private Sub compString(txt As TextBox)
        Dim txtbox As New List(Of String)
        txtbox.Add("king")
        txtbox.Add("james")

        Dim txtbox2 As New List(Of String)
        txtbox2.Add("Ian")
        txtbox2.Add("Jophet")

        Dim row As New AutoCompleteStringCollection
        For Each item In txtbox
            row.Add(item)
        Next

        Dim row2 As New AutoCompleteStringCollection
        For Each item In txtbox2
            row2.Add(item)
        Next

        If txt.Name = "txtSearch" Then
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt.AutoCompleteCustomSource = row2
            cFire += 1
        Else
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt.AutoCompleteCustomSource = row
        End If


    End Sub

    Public Sub txt_leave(sender As Object, e As EventArgs)
        Dim pholder As New class_placeholder(sender, , cFontColor, cFontSize, cFontStyle)
        pholder.leave()
    End Sub

    Public Sub txt_Got_Focus(sender As Object, e As EventArgs)
        Dim pholder As New class_placeholder(sender, cbgColor, cFontColor, cFontSize, cFontStyle)

        pholder.gotFocus()
    End Sub

End Class

Public Class TextBoxFilterError
    Private dot As String
    Sub New()
        dot = "..."
        For Each row In cListofTextbox
            If row.Key.Text = row.Value & dot Then
                row.Key.BackColor = Color.Red
                row.Key.ForeColor = Color.White
                MessageBox.Show(row.Value & " not fill in.", "Placeholder:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                row.Key.Focus()
                Exit For
            End If
        Next
    End Sub
End Class

Public Class Suppress
    Public Sub txt_suppress(sender As Object, e As KeyEventArgs)
        Dim tbox As TextBox = sender
        Dim supress As New TextBoxFilterNumbersOnly(e, tbox)
    End Sub
End Class

Public Class TextBoxFilterNumbersOnly

    Sub New(e As System.Windows.Forms.KeyEventArgs, tbox As TextBox)

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or
        e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or
        e.KeyCode = Keys.OemPeriod Or
       e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 110 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        Else
            Dim countdot As Integer
            For Each s As String In tbox.Text
                If s = "." Then
                    countdot += 1
                End If
            Next

            If countdot > 0 Then
                If e.KeyCode = Keys.OemPeriod Then
                    e.SuppressKeyPress() = True
                End If

            End If

        End If
    End Sub
End Class


Public Class KJ_Label
    Public cLisOfLabel As New List(Of Label)
    Public Sub _initialize_textbox(listoftextbox As Dictionary(Of TextBox, System.Drawing.Bitmap))
        'FOR LABEL


        For Each row In listoftextbox
            Dim label As New Label
            label.Name = "label_" & row.Key.Name
            label.Text = ""
            label.Size = New Size(266, 30)
            label.BorderStyle = BorderStyle.FixedSingle
            label.BackColor = Color.White
            label.Location = New Point(row.Key.Location.X - 35, row.Key.Location.Y - 6)
            label.Image = row.Value
            label.ImageAlign = ContentAlignment.MiddleLeft

            cLisOfLabel.Add(label)
        Next

    End Sub

    Public Sub _initialize_combobox(listofcombobox As Dictionary(Of ComboBox, System.Drawing.Bitmap))
        'FOR LABEL


        For Each row In listofcombobox
            Dim label As New Label
            label.Name = "label_" & row.Key.Name
            label.Text = ""
            label.Size = New Size(266, 30)
            label.BorderStyle = BorderStyle.FixedSingle
            label.BackColor = Color.White
            label.Location = New Point(row.Key.Location.X - 28, row.Key.Location.Y - 3)
            label.Image = row.Value
            label.ImageAlign = ContentAlignment.MiddleLeft

            cLisOfLabel.Add(label)
        Next

    End Sub

End Class
