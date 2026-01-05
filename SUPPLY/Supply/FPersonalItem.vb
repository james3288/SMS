Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FPersonalItem
    Public SQ As New SQLcon
    Public CMD As SqlCommand
    Public DR As SqlDataReader

    Private Sub FPersonalItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_personal_tools(txtSearch.Text)
    End Sub
    Public Sub load_personal_tools(ByVal search As String)
        lvlPersonalTools.Items.Clear()

        Try
            SQ.connection.Open()
            publicquery = "SELECT * FROM dbPersonal_tools WHERE item_desc LIKE '%" & search & "%'"
            SELECT_QUERY(publicquery, 4, lvlPersonalTools, "5-5", 5)


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is TextBox Then
                Dim txt As TextBox = ctr


                If txt.Text = "" Then
                    If txt.Name = "txtSearch" Then
                    Else
                        MessageBox.Show("Please complete the field before save thank you..." & vbCrLf & txt.Name, "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txt.Select()
                        txt.Focus()
                        Exit Sub
                    End If
                End If

            End If
        Next

        Dim n As Integer
        If btnSave.Text = "Save" Then
            publicquery = "INSERT INTO dbPersonal_tools(item_desc,specification,price,qty) VALUES('" & txtItemDesc.Text & "','"
            publicquery &= txtSpecification.Text & "',"
            publicquery &= txtPrice.Text & ","
            publicquery &= txtQty.Text & ") SELECT SCOPE_IDENTITY()"

            n = UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "INSERT")

            If n > 0 Then

                MessageBox.Show("Successfully Saved...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)


                load_personal_tools(txtSearch.Text)
                listfocus(lvlPersonalTools, n)

                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is TextBox Then
                        Dim txt As TextBox = ctr

                        If txt.Name = "txtSearch" Then

                        Else
                            txt.Clear()
                        End If

                    End If
                Next
            End If
        ElseIf btnSave.Text = "Update" Then
            publicquery = "UPDATE dbPersonal_tools SET item_desc = '" & txtItemDesc.Text & "', specification = '"
            publicquery &= txtSpecification.Text & "', price = "
            publicquery &= CDbl(txtPrice.Text) & ", qty = "
            publicquery &= CDbl(txtQty.Text)
            publicquery &= " WHERE p_tools_id = " & CDbl(lvlPersonalTools.SelectedItems(0).Text)

            UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "INSERT")

            Dim id As Integer = Val(lvlPersonalTools.SelectedItems(0).Text)
            MessageBox.Show("Successfully Updated...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            load_personal_tools(txtSearch.Text)
            listfocus(lvlPersonalTools, id)

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is TextBox Then
                    Dim txt As TextBox = ctr

                    If txt.Name = "txtSearch" Then

                    Else
                        txt.Clear()
                    End If

                End If
            Next

            btnEdit.PerformClick()

        End If




        txtItemDesc.Focus()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        load_personal_tools(txtSearch.Text)
    End Sub

    Private Sub txtPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrice.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
           e.KeyCode = Keys.OemPeriod Or _
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
           e.KeyCode = Keys.OemPeriod Or _
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        publicquery = "DELETE FROM dbPersonal_tools WHERE p_tools_id = " & Val(lvlPersonalTools.SelectedItems(0).Text)
        UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "DELETE")

        MessageBox.Show("Successfully Deleted...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        lvlPersonalTools.SelectedItems(0).Remove()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If btnEdit.Text = "Edit" Then
            If lvlPersonalTools.SelectedItems.Count > 0 Then
                lvlPersonalTools.Enabled = False
                txtItemDesc.Text = lvlPersonalTools.SelectedItems(0).SubItems(1).Text
                txtSpecification.Text = lvlPersonalTools.SelectedItems(0).SubItems(2).Text
                txtPrice.Text = CDbl(lvlPersonalTools.SelectedItems(0).SubItems(3).Text)
                txtQty.Text = CDbl(lvlPersonalTools.SelectedItems(0).SubItems(4).Text)

                btnEdit.Text = "Cancel"
                btnSave.Text = "Update"
                btnRemove.Enabled = False
            End If
          
        ElseIf btnEdit.Text = "Cancel" Then
            btnEdit.Text = "Edit"
            btnSave.Text = "Save"
            lvlPersonalTools.Enabled = True
            btnRemove.Enabled = True
        End If
      
    End Sub

    Private Sub lvlPersonalTools_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlPersonalTools.DoubleClick
        wh_id = Val(lvlPersonalTools.SelectedItems(0).Text)
        FRequestField.txtItemDesc.Text = lvlPersonalTools.SelectedItems(0).SubItems(2).Text
        Me.Close()

    End Sub

    Private Sub lvlPersonalTools_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvlPersonalTools.SelectedIndexChanged

    End Sub
End Class