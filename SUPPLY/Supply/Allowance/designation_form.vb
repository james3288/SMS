Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class designation_form
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txt_desig.Text = "" Then
            MessageBox.Show("Dont leave blank...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            save_designation()
            Allowance_sum.load_adfil_charge(2)
            txt_desig.Text = ""
        End If
    End Sub

    Public Sub save_designation()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand()
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 21)
            sqlcomm.Parameters.AddWithValue("@designation_name", txt_desig.Text)
            sqlcomm.ExecuteScalar()
            MessageBox.Show("Successfully Saved...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Allowance_sum.cmbDesignation.Items.Clear()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub pboxHeader_Click(sender As Object, e As EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub designation_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_desig.Focus()

    End Sub

    Private Sub designation_form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            txt_desig.Text = ""
        End If
    End Sub
End Class