Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class FBorrower
    Public SQ As SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim cancel As Integer = 0

    Private Sub btnAddFacName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFacName.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "PanelFAC" Then
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next
        cancel = 0
        load_fac_name(1, 0)
    End Sub
   
    Private Sub fac_btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fac_btnClose.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "PanelFAC" Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

        cancel = 0
        load_fac_name(2, 0)

    End Sub

    Private Sub btnAddBrand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBrand.Click
        Brand_cmbfac_name.Items.Clear()

        For Each ctr As Control In Me.Controls
            If ctr.Name = "PanelBrand" Then
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next

        cancel = 1

        load_fac_name(2, 0)
        load_brand_names()
        'load_brand_names()
    End Sub

    Private Sub brand_btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brand_btnClose.Click
        For Each ctr As Control In Me.Controls
            If ctr.Name = "PanelBrand" Then
                ctr.Visible = False
                Brand_Listview.Enabled = True
                brand_txtBrand.Clear()
                brand_txtBrand.Focus()

            Else
                ctr.Enabled = True
            End If
        Next
        cancel = 1
        brand_btnSave.Text = "Save"
    End Sub

    Private Sub FAC_btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAC_btnSave.Click

        Try
            If FAC_btnSave.Text = "Save" Then
                Dim save As Integer = FAC_NAME_INSERT()
                load_fac_name(1, 0)
                listfocus(FAC_listview, save)
                FAC_txtfac_name.Clear()
                FAC_txtfac_name.Focus()

            ElseIf FAC_btnSave.Text = "Update" Then
                Dim update As Integer = CInt(FAC_listview.SelectedItems(0).Text)
                FAC_NAME_UPDATE()

                load_fac_name(1, 0)
                listfocus(FAC_listview, update)
                FAC_txtfac_name.Clear()
                FAC_txtfac_name.Focus()
                FAC_listview.Enabled = True
                FAC_btnSave.Text = "Save"

            End If
           
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
     
    End Sub

   
#Region "INSERT QUERY"
    Public Function BRAND_NAME_INSERT()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Dim fac_id As Integer = get_id("dbfacilities_names", "facility_name", Brand_cmbfac_name.Text, 0)

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@fac_id", fac_id)
            newCMD.Parameters.AddWithValue("@brand", brand_txtBrand.Text)

            BRAND_NAME_INSERT = newCMD.ExecuteScalar()

            MessageBox.Show("Successfully Saved...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function FAC_NAME_INSERT()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@fac_name", FAC_txtfac_name.Text)
            newCMD.Parameters.AddWithValue("@facility_tools", cmbFacToolsType.Text)

            FAC_NAME_INSERT = newCMD.ExecuteScalar()

            MessageBox.Show("Successfully Saved...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

#End Region

#Region "UPDATE QUERY"
    Public Sub FAC_NAME_UPDATE()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@fac_id", CInt(FAC_listview.SelectedItems(0).Text))
            newCMD.Parameters.AddWithValue("@fac_name", FAC_txtfac_name.Text)
            newCMD.Parameters.AddWithValue("@facility_tools", cmbFacToolsType.Text)


            newCMD.ExecuteNonQuery()

            MessageBox.Show("Successfully Updated...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub dbfacilities_list_UPDATE()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Dim fac_id As Integer = get_id("dbfacilities_names", "facility_name", Brand_cmbfac_name.Text, 0)

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@lof_id", CInt(Brand_Listview.SelectedItems(0).Text))
            newCMD.Parameters.AddWithValue("@fac_id", fac_id)
            newCMD.Parameters.AddWithValue("@brand", brand_txtBrand.Text)

            newCMD.ExecuteNonQuery()

            MessageBox.Show("Successfully Updated...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
#End Region

#Region "DELETE QUERY"
    Public Sub FAC_NAME_DELETE()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@fac_id", CInt(FAC_listview.SelectedItems(0).Text))

            newCMD.ExecuteNonQuery()

            FAC_listview.SelectedItems(0).Remove()

            MessageBox.Show("Successfully Deleted...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub FAC_LIST_DELETE()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@lof_id", CInt(Brand_Listview.SelectedItems(0).Text))

            newCMD.ExecuteNonQuery()

            Brand_Listview.SelectedItems(0).Remove()

            MessageBox.Show("Successfully Deleted...", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
#End Region

#Region "SELECT QUERY"
    Public Sub load_fac_name(ByVal m As Integer, ByVal type As Integer)
        FAC_listview.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 3)

            If type = 0 Then
                newCMD.Parameters.AddWithValue("@facility_tools", cmbFacToolsType.Text)
            ElseIf type = 1 Then
                newCMD.Parameters.AddWithValue("@facility_tools", cmbFacToolsType1.Text)
            End If


            newDR = newCMD.ExecuteReader
            Dim a(5) As String
            While newDR.Read

                a(0) = newDR.Item("fac_id").ToString
                a(1) = newDR.Item("facility_name").ToString
                a(2) = newDR.Item("fac_tools").ToString

                If m = 1 Then
                    Dim lvl As New ListViewItem(a)
                    FAC_listview.Items.Add(lvl)

                ElseIf m = 2 Then
                    Brand_cmbfac_name.Items.Add(a(1))
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub load_brand_names()
        Brand_Listview.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 7)

            newDR = newCMD.ExecuteReader
            Dim a(5) As String

            While newDR.Read

                a(0) = newDR.Item("lof_id").ToString
                a(1) = newDR.Item("facility_name").ToString
                a(2) = newDR.Item("brand").ToString

                Dim lvl As New ListViewItem(a)
                Brand_Listview.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

#End Region

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        FAC_txtfac_name.Text = FAC_listview.SelectedItems(0).SubItems(1).Text
        cmbFacToolsType.Text = FAC_listview.SelectedItems(0).SubItems(2).Text
        FAC_listview.Enabled = False
        FAC_btnSave.Text = "Update"

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        FAC_NAME_DELETE()
      
    End Sub

    Private Sub brand_btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brand_btnSave.Click

        Try
            If brand_btnSave.Text = "Save" Then
                Dim save As Integer = BRAND_NAME_INSERT()
                brand_txtBrand.Clear()
                brand_txtBrand.Focus()
                load_brand_names()
                listfocus(Brand_Listview, save)

            ElseIf brand_btnSave.Text = "Update" Then
                Dim update As Integer = CInt(Brand_Listview.SelectedItems(0).Text)
                dbfacilities_list_UPDATE()
                brand_txtBrand.Clear()
                brand_txtBrand.Focus()
                load_brand_names()
                listfocus(Brand_Listview, update)
                brand_btnSave.Text = "Save"
                Brand_Listview.Enabled = True

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        Brand_cmbfac_name.Text = Brand_Listview.SelectedItems(0).SubItems(1).Text
        brand_txtBrand.Text = Brand_Listview.SelectedItems(0).SubItems(2).Text

        Brand_Listview.Enabled = False
        brand_btnSave.Text = "Update"

    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        FAC_LIST_DELETE()
    End Sub

    Private Sub pboxHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxHeader.Click

    End Sub

    Private Sub FBorrower_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If cancel = 0 Then

                FAC_txtfac_name.Focus()
                FAC_listview.Enabled = True
                FAC_btnSave.Text = "Save"

            ElseIf cancel = 1 Then

                brand_txtBrand.Focus()
                Brand_Listview.Enabled = True
                brand_btnSave.Text = "Save"
            End If
        End If
    End Sub

    Private Sub FBorrower_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub cmbFacToolsType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFacToolsType.SelectedIndexChanged
        load_fac_name(1, 0)
    End Sub

    Private Sub cmbFacToolsType1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFacToolsType1.SelectedIndexChanged
        Brand_cmbfac_name.Items.Clear()

        load_fac_name(2, 1)
    End Sub
End Class