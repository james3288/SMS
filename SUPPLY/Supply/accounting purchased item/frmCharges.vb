Imports System.Data.SqlClient

Public Class frmCharges
    Dim account_charges_id As Integer = 0
    Dim list_charge_classification As New List(Of List(Of String))

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        account_charges_id = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        button1.Text = "Save"
        button1.Enabled = False
    End Sub

    Sub display_charges_classification(ByVal val As String)
        ListView1.Items.Clear()
        If val.Equals("") Then
            For Each item In list_charge_classification
                Dim a(50) As String
                a(0) = item(0)
                a(1) = item(1)
                a(2) = item(2)
                a(3) = item(3)
                Dim item2 As New ListViewItem(a)
                ListView1.Items.Add(item2)
            Next
        Else
            For Each item In list_charge_classification
                If item(1).ToUpper.Contains(TextBox3.Text.ToUpper) Then
                    Dim a(50) As String
                    a(0) = item(0)
                    a(1) = item(1)
                    a(2) = item(2)
                    a(3) = item(3)
                    Dim item2 As New ListViewItem(a)
                    ListView1.Items.Add(item2)
                End If
            Next
        End If

    End Sub
    Sub load_classification()
        Dim classification As New AutoCompleteStringCollection
        For Each item As List(Of String) In Summary_Purchased_Item.acc_class
            classification.Add(item(1))
        Next
        TextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox2.AutoCompleteCustomSource = classification
    End Sub
    Private Sub frmCharges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_charges_classification()
        display_charges_classification(TextBox3.Text)
        load_classification()
        load_account_title()
    End Sub

    Sub load_account_title()
        Dim account_titles As New AutoCompleteStringCollection
        For Each item As List(Of String) In Summary_Purchased_Item.acc_title
            account_titles.Add(item(1))
        Next
        TextBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox4.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox4.AutoCompleteCustomSource = account_titles
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        display_charges_classification(TextBox3.Text)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick

        account_charges_id = If(String.IsNullOrEmpty(ListView1.SelectedItems(0).SubItems(0).Text), 0, ListView1.SelectedItems(0).SubItems(0).Text)
        TextBox1.Text = ListView1.SelectedItems(0).SubItems(1).Text
        TextBox2.Text = ListView1.SelectedItems(0).SubItems(2).Text
        TextBox4.Text = ListView1.SelectedItems(0).SubItems(3).Text
        If account_charges_id = 0 Then
            button1.Text = "Save"
        Else
            button1.Text = "Update"
        End If
        button1.Enabled = True
        TextBox2.Focus()
    End Sub
    Sub update_charges_classification()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            Dim query As String = "Update dbAccount_Charges set account_charge = '" & TextBox1.Text & "', classification = '" & TextBox2.Text & "', account_title = '" & TextBox4.Text & "'  where account_charges_id = " & account_charges_id
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
    Sub add_charges_classification()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            Dim query As String = "insert into dbAccount_Charges (account_charge, classification,account_title) values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox4.Text & "')"
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
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim class_exist As Boolean = False
        For Each item As List(Of String) In Summary_Purchased_Item.acc_class
            If item(1).Equals(TextBox2.Text) Then
                class_exist = True
                Exit For
            End If
        Next
        If class_exist = False Or TextBox1.Text Is Nothing OrElse TextBox1.Text.Trim() = String.Empty Then
            MsgBox("The Charge is empty or Classification is not exist")
        Else
            If button1.Text = "Update" And account_charges_id <> 0 Then
                update_charges_classification()
            Else
                add_charges_classification()
            End If
            button1.Text = "Save"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox4.Text = ""
            account_charges_id = 0

            button1.Enabled = False
            list_charge_classification.Clear()
            load_charges_classification()
            display_charges_classification(TextBox3.Text)

        End If
    End Sub
    Sub load_charges_classification()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim query As String = ";with
                                    tbl_charges as (select distinct
                                    case when type_name = 'WAREHOUSE'
		                                    then (select top 1 aaa.wh_area from [supply_db].[dbo].[dbwh_area] aaa where aaa.wh_area_id = aa.all_charges_id)
	                                    when type_name = 'PROJECT'
		                                    then (select top 1 aaa.project_desc from [eus].[dbo].[dbprojectdesc] aaa where aaa.proj_id = aa.all_charges_id)
	                                    when type_name = 'EQUIPMENT'
		                                    then (select top 1 aaa.plate_no from [eus].[dbo].[dbequipment_list] aaa where aaa.equipListID = aa.all_charges_id)
	                                    else
		                                    (select top 1 aaa.charge_to from [supply_db].[dbo].[dbCharge_to] aaa where aaa.charge_to_id = aa.all_charges_id)
	                                    end as CHARGES
                                    from [supply_db].[dbo].[dbMultipleCharges] aa)

                                    select b.account_charges_id
	                                    ,a.CHARGES
	                                    ,b.classification
                                        ,b.account_title
                                    from tbl_charges a
                                    left join dbAccount_Charges b on b.account_charge = a.CHARGES
                                    order by CHARGES"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.CommandTimeout = 0
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim item As New List(Of String)
                item.Add(newDR.Item("account_charges_id").ToString())
                item.Add(newDR.Item("CHARGES").ToString())
                item.Add(newDR.Item("classification").ToString())
                item.Add(newDR.Item("account_title").ToString())
                list_charge_classification.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
End Class