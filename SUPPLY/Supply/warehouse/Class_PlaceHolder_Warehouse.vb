Public Class Class_PlaceHolder_Warehouse
    Dim a, b, c, d, e, f, g As String

    Sub New()

        a = "Item Name..."
        b = "Item Description..."
        c = "Warehouse Area..."

    End Sub

    Public Sub load_what_you_search(txt As TextBox, list_of As List(Of List(Of String)))

        Dim searchlist As New AutoCompleteStringCollection
        Dim text As New TextBox

        Dim list_of_new As New List(Of List(Of String))
        list_of_new = Nothing

        list_of_new = list_of
        text = txt

        For Each item As List(Of String) In list_of_new
            searchlist.Add(item(0))
        Next

        text.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        text.AutoCompleteSource = AutoCompleteSource.CustomSource
        text.AutoCompleteCustomSource = searchlist

        searchlist = Nothing
    End Sub

    Public Sub t_gotfocus(texbox As TextBox)
        Dim textbox1 As New TextBox
        Dim text As New textbox_font

        textbox1 = texbox

        If textbox1.Text = a Or textbox1.Text = b Or textbox1.Text = c Then
            textbox1.Clear()
        Else
            text.focused(textbox1)
            'placeholder_font_focus(textbox1)
        End If
    End Sub

    Private Sub placeholder_font_focus(txt As TextBox)
        If IsNothing(txt) Then
            Exit Sub
        End If

        Dim txt1 As New TextBox
        txt1 = txt
        Try
            Dim objFont As System.Drawing.Font
            objFont = New System.Drawing.Font("Arial", 11, FontStyle.Regular)


            txt1.Font = objFont
            txt1.ForeColor = Color.Black

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function placeholder_font_focus1() As TextBox

        Try
            Dim objFont As System.Drawing.Font
            objFont = New System.Drawing.Font("Arial", 11, FontStyle.Regular)

            Dim txt1 As New TextBox

            txt1.Font = objFont
            txt1.ForeColor = Color.Black

            placeholder_font_focus1 = txt1
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub t_leave(texbox As TextBox)
        Dim textbox1 As New TextBox
        textbox1 = texbox

        Dim tf As New textbox_font

        If textbox1.Text = "" Then
            If textbox1.Name = "txtSearch" Then

                textbox1.Text = a
                tf.leave(textbox1)

                'placeholder_font(textbox1)
                'texbox = placeholder_font1(a)
                'textbox1.Text = a

            ElseIf textbox1.Name = "txtItemDesc" Then

                textbox1.Text = b
                tf.leave(textbox1)

                'texbox = placeholder_font1(b)
                ' textbox1.Text = b
                'placeholder_font(textbox1)

            ElseIf textbox1.Name = "txtWarehouseArea" Then

                textbox1.Text = c
                tf.leave(textbox1)

                'texbox = placeholder_font1(c)
                ' textbox1.Text = c
                'placeholder_font(textbox1)

            End If
        Else
            'placeholder_font_focus(textbox1)

            tf.focused(textbox1)
        End If
    End Sub
    Private Sub placeholder_font(txt As TextBox)
        Try
            Dim objFont As System.Drawing.Font
            objFont = New System.Drawing.Font("Arial", 11, FontStyle.Italic)

            Dim txt2 As New TextBox

            txt2 = txt

            txt2.Font = objFont
            txt2.ForeColor = Color.Gray

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function placeholder_font1(caption As String) As TextBox
        Try
            Dim objFont As System.Drawing.Font
            objFont = New System.Drawing.Font("Arial", 11, FontStyle.Italic)
            Dim txt As New TextBox

            txt.Text = caption
            txt.Font = objFont
            txt.ForeColor = Color.Gray

            placeholder_font1 = txt
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Class textbox_font
        Public Sub leave(t As TextBox)
            Try

                'Dim objFont As System.Drawing.Font
                'objFont = New System.Drawing.Font("Arial", 11, FontStyle.Italic)

                Dim tt As New TextBox
                tt = t
                tt.ForeColor = Color.Gray

                'tt.Font = objFont
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        End Sub
        Public Function leave1() As TextBox
            Dim objFont As System.Drawing.Font
            objFont = New System.Drawing.Font("Arial", 11, FontStyle.Italic)
            Dim tt As New TextBox

            tt.ForeColor = Color.Gray
            tt.Font = objFont

            leave1 = tt

        End Function

        Public Sub focused(t As TextBox)
            'Dim objFont As System.Drawing.Font
            'objFont = New System.Drawing.Font("Arial", 11, FontStyle.Regular)

            Dim tt As New TextBox
            tt = t

            'tt.Font = objFont
            tt.ForeColor = Color.Black

        End Sub
    End Class

End Class
