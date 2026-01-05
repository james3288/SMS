Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FchangePassword
    Dim SQ As New SQLcon
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand

    Public Sub check_username_password()
        Try
            SQ.connection.Open()

            Dim query As String = "select username,password from dbregistrationform where username='" & txtUsername.Text & "' and password='" & txtOldpassword.Text & "'"
            cmd = New SqlCommand(query, SQ.connection)

            dr = cmd.ExecuteReader

            If dr.HasRows Then
                save_changes()
            Else
                MessageBox.Show("Invalid Username or Password", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsername.Focus()
            End If
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_changes()
        Dim sqconn As New SQLcon
        Try
            If txtNewpassword.Text = txtConfirmedpass.Text And (txtNewpassword.Text <> "" Or txtConfirmedpass.Text <> "") Then
                sqconn.connection.Open()
                Dim query As String = "update dbregistrationform set password='" & txtConfirmedpass.Text & "' where username='" & txtUsername.Text & "'"
                cmd = New SqlCommand(query, sqconn.connection)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Successfully updated", "EUS INFO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
                Me.Close()
                'Flogin.Show()
            ElseIf txtNewpassword.Text = "" Then
                MessageBox.Show("Empty New Password", "EUS INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNewpassword.Focus()
            ElseIf txtConfirmedpass.Text = "" Then
                MessageBox.Show("Empty Confirmed Password", "EUS INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConfirmedpass.Focus()
            Else
                MessageBox.Show("New password and confirmed password didn't match", "EUS INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNewpassword.Focus()
            End If
          

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqconn.connection.Close()
        End Try
    End Sub
    Public Sub clear()
        txtUsername.Text = ""
        txtOldpassword.Text = ""
        txtNewpassword.Text = ""
        txtConfirmedpass.Text = ""

        txtUsername.Focus()
    End Sub

    Private Sub FchangePassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            check_username_password()
        End If
    End Sub

    Private Sub FchangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSave.Parent = pboxSave
        lblSave.BringToFront()
        lblSave.Location = New Point(35, 10)

    End Sub

    Private Sub lblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSave.Click, pboxSave.Click
        check_username_password()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus, txtOldpassword.GotFocus, txtNewpassword.GotFocus, txtConfirmedpass.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtField_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.Leave, txtOldpassword.Leave, txtNewpassword.Leave, txtConfirmedpass.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged

    End Sub
End Class