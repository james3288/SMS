Imports System.Data.SqlClient

Public Class frmAccountTitle
    Dim accnt_title_id As Integer = 0
    Private Sub frmAccountTitle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display_account_titles()
    End Sub

    Sub display_account_titles()
        ListView1.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT [accnt_title_id]
                                      ,[account_title]
                                  FROM [supply_db].[dbo].[dbAccount_Title]"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim a(50) As String
                a(0) = newDR.Item("accnt_title_id").ToString
                a(1) = newDR.Item("account_title").ToString
                Dim item As New ListViewItem(a)
                ListView1.Items.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Sub update_account_titles()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            Dim query As String = "Update [supply_db].[dbo].[dbAccount_Title] set account_title = '" & TextBox1.Text & "' where accnt_title_id = " & accnt_title_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newCMD.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Sub add_account_titles()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            Dim query As String = "insert into dbAccount_Title ([account_title]) values ('" & TextBox1.Text & "')"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newCMD.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        button1.Text = "Add"
        TextBox1.Text = ""
        accnt_title_id = 0
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        accnt_title_id = ListView1.SelectedItems(0).SubItems(0).Text
        TextBox1.Text = ListView1.SelectedItems(0).SubItems(1).Text
        button1.Text = "Update"
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        If TextBox1.Text Is Nothing OrElse TextBox1.Text.Trim() = String.Empty Then
            MessageBox.Show("The Account Title is empty")
            TextBox1.Text = ""
        Else
            If button1.Text = "Update" And accnt_title_id <> 0 Then
                update_account_titles()
                display_account_titles()
                button1.Text = "Add"
                TextBox1.Text = ""
                accnt_title_id = 0
            Else
                add_account_titles()
                display_account_titles()
                button1.Text = "Add"
                TextBox1.Text = ""
                accnt_title_id = 0
            End If
        End If

    End Sub
End Class