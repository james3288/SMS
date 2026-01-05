Public Class class_combobox_placeholder
    Private cmbBox As New ComboBox
    Private dot As String
    Private cbgColor As New Color
    Private cFontColor As New Color
    Private cFontSize As Integer
    Private cFontStyle As String
    Sub New(cbox As ComboBox, Optional tBoxColor As Color = Nothing, Optional FontColor As Color = Nothing, Optional font_size As Integer = Nothing, Optional font_style As String = "Arial")

        cmbBox = cbox

        dot = "..."
        cbgColor = IIf(tBoxColor = Nothing, Color.White, tBoxColor)
        cFontColor = IIf(FontColor = Nothing, Color.Black, FontColor)
        cFontSize = IIf(font_size = Nothing, 12, font_size)
        cFontStyle = font_style

        cmbBox.Font = New Font(cFontStyle, cFontSize, FontStyle.Regular)
    End Sub

    Public Sub leave(Optional bgColor As Color = Nothing)
        Try
            cmbBox.BackColor = IIf(bgColor = Nothing, cbgColor, bgColor)

            Dim placeholder As String = ""

            For Each row In Module1.clistofCombobox
                If row.Key.Name = cmbBox.Name Then
                    placeholder = row.Value
                    Exit For
                End If
            Next

            placeholder = placeholder & dot

            If cmbBox.Text = "" Then
                cmbBox.Text = placeholder
                cmbBox.ForeColor = cFontColor
                cmbBox.Font = New Font(cFontStyle, cFontSize, FontStyle.Italic)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub gotFocus(Optional bgColor As Color = Nothing)
        Try
            cmbBox.BackColor = IIf(bgColor = Nothing, cbgColor, bgColor)

            Dim placeholder As String = ""

            For Each row In Module1.clistofCombobox
                If row.Key.Name = cmbBox.Name Then
                    placeholder = row.Value
                    Exit For
                End If
            Next

            placeholder = placeholder & dot


            If cmbBox.Text = placeholder Then
                cmbBox.Text = ""
                cmbBox.Focus()
                cmbBox.ForeColor = Color.Black
                cmbBox.Font = New Font(cFontStyle, cFontSize, FontStyle.Regular)
            Else

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub txt_leave(sender As Object, e As EventArgs)
        Dim pholder As New class_combobox_placeholder(sender, , cFontColor, cFontSize, cFontStyle)
        pholder.leave()
    End Sub
    Public Sub txt_Got_Focus(sender As Object, e As EventArgs)
        Dim pholder As New class_combobox_placeholder(sender, cbgColor, cFontColor, cFontSize, cFontStyle)
        pholder.gotFocus()
    End Sub
End Class
