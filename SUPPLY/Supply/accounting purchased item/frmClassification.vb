Imports System.Data.SqlClient

Public Class frmClassification
    Dim classification_id As Integer = 0

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
    Sub update_classification()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            Dim query As String = "Update dbAccount_Classification set account_classification = '" & TextBox1.Text & "', accnt_title = '" & TextBox2.Text & "'  where accnt_classification_id = " & classification_id
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
    Sub add_classification()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            Dim query As String = "insert into dbAccount_Classification (account_classification, accnt_title) values ('" & TextBox1.Text & "', '" & TextBox2.Text & "')"
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
    Sub load_account_title()
        Dim account_titles As New AutoCompleteStringCollection
        For Each item As List(Of String) In Summary_Purchased_Item.acc_title
            account_titles.Add(item(1))
        Next
        TextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox2.AutoCompleteCustomSource = account_titles
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        button1.Text = "Add"
        TextBox1.Text = ""
        TextBox2.Text = ""
        classification_id = 0
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim accnt_exist As Boolean = False
        For Each item As List(Of String) In Summary_Purchased_Item.acc_title
            If item(1).Equals(TextBox2.Text) Then
                accnt_exist = True
                Exit For
            End If
        Next
        If accnt_exist = False Or TextBox1.Text Is Nothing OrElse TextBox1.Text.Trim() = String.Empty Then
            MsgBox("The Classification is empty or Account title is not exist")
        Else
            If button1.Text = "Update" And classification_id <> 0 Then
                update_classification()
            Else
                add_classification()
            End If
            button1.Text = "Add"
            TextBox1.Text = ""
            TextBox2.Text = ""
            classification_id = 0
            display_classification()
        End If
    End Sub

    Private Sub frmClassification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display_classification()
        load_account_title()
    End Sub

    Sub display_classification()
        ListView1.Items.Clear()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT a.[accnt_classification_id]
                                      ,b.account_title
                                      ,a.[account_classification]
                                  FROM [dbAccount_Classification] a
                                  left join dbAccount_Title b on b.account_title = a.[accnt_title]"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader
            While newDR.Read
                Dim a(50) As String
                a(0) = newDR.Item("accnt_classification_id").ToString
                a(1) = newDR.Item("account_classification").ToString
                a(2) = newDR.Item("account_title").ToString
                Dim item As New ListViewItem(a)
                ListView1.Items.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        classification_id = ListView1.SelectedItems(0).SubItems(0).Text
        TextBox1.Text = ListView1.SelectedItems(0).SubItems(1).Text
        button1.Text = "Update"
        TextBox2.Focus()
    End Sub
End Class