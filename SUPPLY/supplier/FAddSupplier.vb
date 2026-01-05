Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FAddSupplier
    Dim booleanOperator_Cancel As Boolean = False
    'Public Sqlcon As New SQLcon
    Dim sqlcmd As SqlCommand
    Dim sqldr As SqlDataReader
    Private customMsg As New customMessageBox
    Private Sub FAddSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel_Supplier.Visible = True
        FReceivingReport.show_supplier_list(lvList)

        If lvList.SelectedItems.Count > 0 Then
            Dim index As Integer = lvList.Items.Count - 1

            lvList.Items(index).Selected = True
            lvList.Items(index).EnsureVisible()
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not isAuthenticatedWithoutMessage(auth) AndAlso
            Not Utilities.isNotRestrictedTo(cDepartments.PURCHASING) Then
            customMsg.message("error", "You are not allowed to this transaction...", "SMS INFO:")
            Exit Sub
        End If

        If txt_SupplierName.Text <> "" And txt_SupplierLocation.Text <> "" Then
            If booleanOperator_Cancel = True Then
                btn_Update.Enabled = False
                txt_SupplierName.Text = ""
                txt_SupplierLocation.Text = ""
                lvList.Enabled = True
                btnAdd.Text = "Add"
                txtTerms.Clear()

            ElseIf btnAdd.Text = "Add" Then

                listfocus(lvList, FReceivingReport.Insert_Supplier(txt_SupplierName.Text, txt_SupplierLocation.Text, txtTerms.Text))
                txt_SupplierName.Text = ""
                txt_SupplierLocation.Text = ""
                txt_SupplierName.Focus()
                FReceivingReport.show_supplier_list(lvList)
            End If
        End If

        'load_suppliers_list()
        booleanOperator_Cancel = False
    End Sub

    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        Try

            If Not isAuthenticatedWithoutMessage(auth) AndAlso
                Not Utilities.isNotRestrictedTo(cDepartments.PURCHASING) Then
                customMsg.message("error", "You are not allowed to this transaction...", "SMS INFO:")
                Exit Sub
            End If

            'Dim ex = MsgBox("Are you sure u want to update the selected item?", MsgBoxStyle.YesNo, "Information")
            If customMsg.messageYesNo("Are you sure u want to update the selected item?", "SMS INFO:", MessageBoxIcon.Question) Then

                Dim supp_id As Integer = Val(lvList.SelectedItems(0).Text)

                FReceivingReport.UpdateRecord_Supplier(supp_id, txt_SupplierName, txt_SupplierLocation, txtTerms)
                FReceivingReport.show_supplier_list(lvList)
                listfocus(lvList, supp_id)

                btnAdd.Text = "Add"
                btn_Update.Enabled = False
                lvList.Enabled = True

            End If

            booleanOperator_Cancel = False
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If Not isAuthenticated(auth) Then
            Exit Sub
        End If


        If lvList.SelectedItems.Count > 0 Then
            lvList.Enabled = False
            txt_SupplierName.Text = lvList.SelectedItems.Item(0).SubItems(1).Text
            txt_SupplierLocation.Text = lvList.SelectedItems.Item(0).SubItems(2).Text
            txtTerms.Text = lvList.SelectedItems(0).SubItems(3).Text
            btnAdd.Text = "Cancel"
            btn_Update.Enabled = True
            booleanOperator_Cancel = True
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Not isAuthenticated(auth) Then
            Exit Sub
        End If

        Dim ex = MsgBox("Are you sure u want to DELETE the SELECTED item?", MsgBoxStyle.YesNo, "ERROR")
        If ex = MsgBoxResult.Yes Then

            Dim n As Integer = FReceivingReport.DeleteRecord_Supplier(lvList)
            FReceivingReport.show_supplier_list(lvList)
            listfocus(lvList, n)

            txt_SupplierName.Text = ""
            txt_SupplierLocation.Text = ""
            btn_Update.Enabled = False
            btnAdd.Text = "Add"
        Else
        End If

        booleanOperator_Cancel = False
    End Sub

    Private Sub lvList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvList.SelectedIndexChanged

    End Sub

    Private Sub lvList_DoubleClick(sender As Object, e As EventArgs) Handles lvList.DoubleClick
        If Label2.Text = "yes" Then
            Dim selected_supplier As String = lvList.SelectedItems(0).SubItems(1).Text
            Dim selected_sup_loc As String = lvList.SelectedItems(0).SubItems(2).Text
            Dim terms As String = lvList.SelectedItems(0).SubItems(3).Text

            FPOFORM.suplier_address = selected_sup_loc
            Me.Close()

            'FPOFORM.dgvPOList.Rows(Label3.Text).Cells(1).Value = selected_supplier

            With FPOFORM
                For Each row As DataGridViewRow In .dgvPOList.Rows
                    If row.Cells(1).Selected = True Then
                        row.Cells(1).Value = selected_supplier
                        row.Cells("Column5").Value = terms
                    End If

                Next
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        searchby(TextBox1.Text)
    End Sub
    Public Sub searchby(ByVal search As String)
        Dim SQcon As New SQLcon
        Dim SQcmd As SqlCommand
        Dim SQReader As SqlDataReader
        lvList.Items.Clear()
        Try
            SQcon.connection.Open()
            SQcmd = New SqlCommand("proc_supplier", SQcon.connection)
            SQcmd.Parameters.Clear()
            SQcmd.CommandType = CommandType.StoredProcedure

            If ComboBox1.Text = "Supplier Name" Then
                SQcmd.Parameters.AddWithValue("@n", 3)
            ElseIf ComboBox1.Text = "Supplier Location" Then
                SQcmd.Parameters.AddWithValue("@n", 4)
            ElseIf ComboBox1.Text = "Terms" Then
                SQcmd.Parameters.AddWithValue("@n", 5)
            Else
                MessageBox.Show("Please select Type of Search", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            SQcmd.Parameters.AddWithValue("@value", search)
            SQReader = SQcmd.ExecuteReader

            While SQReader.Read
                Dim a(5) As String
                a(0) = SQReader.Item("Supplier_Id").ToString
                a(1) = SQReader.Item("Supplier_Name").ToString
                a(2) = SQReader.Item("Supplier_Location").ToString
                a(3) = SQReader.Item("terms").ToString
                FPOFORM.suplier_address = SQReader.Item("Supplier_Location").ToString
                Dim list As New ListViewItem(a)
                lvList.Items.Add(list)
            End While
            SQReader.Close()
        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQcon.connection.Close()
        End Try
    End Sub

    Private Sub CMS_lvList_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_lvList.Opening

    End Sub
End Class