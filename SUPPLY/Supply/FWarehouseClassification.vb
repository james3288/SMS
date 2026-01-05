Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FWarehouseClassification
    Dim sqlcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim cmd As SqlCommand
    Dim wh_class_id As Integer
    Public isFromCreateWarehouseItem As Boolean
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If if_wh_exist(txtWhClass.Text) > 0 Then
                MessageBox.Show("Warehouse classification already exists..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return

            Else
                If txtWhClass.Text = "" Then
                    MessageBox.Show("Fill-up the field first!..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    Dim newSQL As New SQLcon
                    Dim newCMD As SqlCommand

                    newSQL.connection.Open()

                    publicquery = "INSERT INTO dbwh_classification(wh_classification) VALUES('" & txtWhClass.Text & "')"
                    newCMD = New SqlCommand(publicquery, newSQL.connection)
                    Dim n As Integer = newCMD.ExecuteScalar()

                    newSQL.connection.Close()

                    MessageBox.Show("SUCCESSFULLY SAVE..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    load_wh_class()

                    listfocus(lvlWhClassList, n)
                    txtWhClass.Clear()

                End If
              
            End If

        ElseIf btnSave.Text = "Update" Then
            publicquery = "UPDATE dbwh_classification SET wh_classification = '" & txtWhClass.Text & "' "
            publicquery &= "WHERE wh_class_id = " & lvlWhClassList.SelectedItems(0).Text

            UPDATE_INSERT_DELETE_QUERY(publicquery, 1, "UPDATE")
            Dim n As Integer = lvlWhClassList.SelectedItems(0).Text

            MessageBox.Show("SUCCESSFULLY UPDATED..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            load_wh_class()

            listfocus(lvlWhClassList, n)
            lvlWhClassList.Enabled = True

            btnEdit.PerformClick()

        End If

    End Sub

    Public Function if_wh_exist(ByVal whclass As String) As Integer
        Try
            sqlcon.connection.Open()
            publicquery = "SELECT * FROM dbwh_classification WHERE wh_classification = '" & whclass & "'"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                if_wh_exist += 1
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()

        End Try
    End Function

    Public Sub load_wh_class()
        lvlWhClassList.Items.Clear()
        Dim a(5) As String

        Try
            sqlcon.connection.Open()
            publicquery = "SELECT * FROM dbwh_classification"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read

                a(0) = sqldr.Item("wh_class_id").ToString
                a(1) = sqldr.Item("wh_classification").ToString

                If search_by(a(1), txt_search.Text) = True Then
                Else
                    GoTo proceedhere
                End If

                Dim lvl As New ListViewItem(a)
                lvlWhClassList.Items.Add(lvl)

proceedhere:

            End While
            sqldr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try

        'SELECT_QUERY(publicquery, 1, lvlWhClassList, "50-50", -1)

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvlWhClassList.SelectedItems.Count > 0 Then

            If MessageBox.Show("Are you sure you want to delete this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                publicquery = "DELETE FROM dbwh_classification WHERE wh_class_id = " & Val(lvlWhClassList.SelectedItems(0).Text)
                UPDATE_INSERT_DELETE_QUERY(publicquery, 0, "DELETE")

                lvlWhClassList.SelectedItems(0).Remove()

            End If
        Else
            MessageBox.Show("Select first!..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
  

    End Sub

    Private Sub FWarehouseClassification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        refresh_all()
        load_wh_class()

    End Sub

    Public Sub refresh_all()
        lvlWhClassList.Items.Clear()
        lvlWhClassList.Enabled = True
        btnRemove.Enabled = True
        btnEdit.Text = "Edit"
        btnSave.Text = "Save"
        txtWhClass.Text = ""
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Cancel" Then
            lvlWhClassList.Enabled = True
            txtWhClass.Clear()

            txtWhClass.Focus()
            btnEdit.Text = "Edit"
            btnSave.Text = "Save"
            btnRemove.Enabled = True

        ElseIf btnEdit.Text = "Edit" Then

            If lvlWhClassList.SelectedItems.Count > 0 Then
                lvlWhClassList.Enabled = False
                txtWhClass.Text = lvlWhClassList.SelectedItems(0).SubItems(1).Text

                txtWhClass.Focus()
                btnEdit.Text = "Cancel"
                btnSave.Text = "Update"
                btnRemove.Enabled = False
            Else
                MessageBox.Show("Select first!..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If

    End Sub

    Private Sub lvlWhClassList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlWhClassList.DoubleClick
        'wh_class_id = lvlWhClassList.SelectedItems(0).Text
        If isFromCreateWarehouseItem Then
            With FCreateWarehouseItemForm.whitemStorage
                .classification = lvlWhClassList.SelectedItems(0).SubItems(1).Text
                FCreateWarehouseItemForm.txtWhClassificationAndOthers.Text = lvlWhClassList.SelectedItems(0).SubItems(1).Text
            End With

            Me.Dispose()
        End If
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        load_wh_class()
    End Sub

    Private Sub lvlWhClassList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvlWhClassList.MouseDoubleClick

        If e.Button = Windows.Forms.MouseButtons.Left Then
            With FWarehouseItems
                .txtWhClass.Text = lvlWhClassList.SelectedItems(0).SubItems(1).Text
            End With
            Me.Close()
        End If
    End Sub

    Private Sub lvlWhClassList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvlWhClassList.SelectedIndexChanged

    End Sub
End Class