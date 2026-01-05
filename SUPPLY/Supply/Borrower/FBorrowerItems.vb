Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class FBorrowerItems

    Private Sub FBorrowerItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        load_borrower_items()

    End Sub

#Region "SELECT QUERY"

    Public Sub load_borrower_items()
        lvlFacTools.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_facilities", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@facility_tools", lbl_Fac_tools.Text)

            newDR = newCMD.ExecuteReader
            Dim a(5) As String
            While newDR.Read
                a(0) = newDR.Item("fac_id").ToString
                a(1) = newDR.Item("facility_name").ToString

                Dim lvl As New ListViewItem(a)
                lvlFacTools.Items.Add(lvl)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
#End Region

    Private Sub lvlFacTools_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlFacTools.DoubleClick
        wh_id = CInt(lvlFacTools.SelectedItems(0).Text)
        FRequestField.txtItemDesc.Text = lvlFacTools.SelectedItems(0).SubItems(1).Text
        Me.Close()
    End Sub

End Class