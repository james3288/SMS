Public Class FEditUserInfo
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Select Case CheckBox1.Checked
            Case True
                txtPassword.PasswordChar = ""
            Case False
                txtPassword.PasswordChar = "*"

        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Dim errorcounter As Integer = 0

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is TextBox Then
                    If ctr.Text = "" Then
                        ctr.BackColor = Color.FromArgb(255, 128, 128)
                        errorcounter += 1
                    Else
                        ctr.BackColor = Color.FromArgb(255, 255, 255)
                    End If

                ElseIf TypeOf ctr Is ComboBox
                    If ctr.Text = "" Then
                        ctr.BackColor = Color.FromArgb(255, 128, 128)
                        errorcounter += 1
                    Else
                        ctr.BackColor = Color.FromArgb(255, 255, 255)
                    End If
                End If
            Next

            If errorcounter > 0 Then
                Exit Sub
            End If

            Dim fname, lname, username, password, gender As String

            fname = txtFname.Text.Replace("'", "`")
            lname = txtLastName.Text.Replace("'", "`")
            gender = cmbGender.Text
            username = txtUsername.Text.Replace("'", "`")
            password = txtPassword.Text.Replace("'", "`")

            Dim query As String = "UPDATE dbregistrationform SET fname = '" & fname & "',"
            query &= "lname = '" & lname & "',"
            query &= "gender = '" & gender & "',"
            query &= "username = '" & username & "',"
            query &= "password = '" & password & "' WHERE user_id = " & pub_user_id

            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

            MessageBox.Show("Information was succesfully updated...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If MessageBox.Show("We recommend that you restart your program to refresh your account.", "Supply Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                End
            End If

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FEditUserInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtFname.Text = fname
        txtLastName.Text = lname
        cmbGender.Text = gender
        txtUsername.Text = username
        txtPassword.Text = password


    End Sub
End Class