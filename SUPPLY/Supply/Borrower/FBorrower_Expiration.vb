Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrower_Expiration
    'Dim bs_id As Integer = CInt(FBorrowed_Item_Monitoring.lvlBorrowerList.SelectedItems(0).Text)

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveUpdate.Click
        If btnSaveUpdate.Text = "Update" Then
            Save_update(0)
            'FBorrowed_Item_Monitoring.borrower_slip_list(0)

            FBorrowed_Item_Monitoring.btnSearch.PerformClick()
            'listfocus(FBorrowed_Item_Monitoring.lvlBorrowerList, CInt(lbl_bs_id.Text))

        ElseIf btnSaveUpdate.Text = "Save" Then
            Save_update(1)
            'FBorrowed_Item_Monitoring.borrower_slip_list(0)

            FBorrowed_Item_Monitoring.btnSearch.PerformClick()
            'listfocus(FBorrowed_Item_Monitoring.lvlBorrowerList, CInt(lbl_bs_id.Text))

        End If

    End Sub

    Public Sub Save_update(ByVal n As Integer)
        Try
            If n = 0 Then

                Dim query As String = "UPDATE dbBorrower_expiration SET estimated_days_return = " & CInt(txtEdR.Text)
                query &= ", extended = " & CInt(txtExtended.Text) & " WHERE bs_id = " & CInt(lbl_bs_id.Text)

                UPDATE_INSERT_DELETE_QUERY(query, 1, "UPDATE")
                Me.Dispose()

            ElseIf n = 1 Then

                Dim query As String = "INSERT INTO dbBorrower_expiration(estimated_days_return,extended,bs_id) VALUES(" & CInt(txtEdR.Text)
                query &= "," & CInt(txtExtended.Text) & "," & CInt(lbl_bs_id.Text) & ")"

                UPDATE_INSERT_DELETE_QUERY(query, 1, "INSERT")
                Me.Dispose()

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FBorrower_Expiration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        newSQ.connection.Open()

        Try
            If check_if_exist("dbBorrower_expiration", "bs_id", CInt(lbl_bs_id.Text), 0) > 0 Then
                btnSaveUpdate.Text = "Update"

                Dim query As String = "SELECT * FROM dbBorrower_expiration WHERE bs_id = " & CInt(lbl_bs_id.Text)
                newCMD = New SqlCommand(query, newSQ.connection)
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    txtEdR.Text = newDR.Item("estimated_days_return").ToString
                    txtExtended.Text = newDR.Item("extended").ToString

                End While
                newDR.Close()
            Else
                btnSaveUpdate.Text = "Save"
                txtEdR.Text = 0
                txtExtended.Text = 0
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

        End Try
    End Sub

    Private Sub txtEdR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdR.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
           e.KeyCode = Keys.OemPeriod Or _
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If

    End Sub

  
    Private Sub txtExtended_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExtended.KeyDown

        If Not (e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 48 Or e.KeyValue = 49 Or e.KeyValue = 50 Or e.KeyValue = 51 Or e.KeyValue = 52 Or e.KeyValue = 53 Or e.KeyValue = 54 Or _
           e.KeyValue = 55 Or e.KeyValue = 56 Or e.KeyValue = 57 Or e.KeyValue = 96 Or e.KeyValue = 97 Or e.KeyValue = 98 Or e.KeyValue = 99 Or _
           e.KeyCode = Keys.OemPeriod Or _
          e.KeyValue = 100 Or e.KeyValue = 101 Or e.KeyValue = 102 Or e.KeyValue = 103 Or e.KeyValue = 104 Or e.KeyValue = 105 Or e.KeyValue = 37 Or e.KeyValue = 39) Then

            e.SuppressKeyPress() = True
        End If
    End Sub


End Class