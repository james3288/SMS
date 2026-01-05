Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FChargeTo
    Public sq As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Private Sub lvlChargeTo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlChargeTo.DoubleClick
        Try
            charge_to_id = Val(lvlChargeTo.SelectedItems(0).Text)

            FRequestField.txtChargeTo.Text = lvlChargeTo.SelectedItems(0).SubItems(1).Text
            FRequestField.txtLoc.Text = lvlChargeTo.SelectedItems(0).SubItems(2).Text

            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub lvlChargeTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvlChargeTo.SelectedIndexChanged

    End Sub

    Private Sub FChargeTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If charge_to_selection = 1 Then
            lvlChargeTo.Items.Clear()
            load_charge_to(0)
        ElseIf charge_to_selection = 2 Then
            lvlChargeTo.Items.Clear()
            load_charge_to(1)
        End If
    End Sub
    
    Public Sub load_charge_to(ByVal n As Integer)

        Try
            sq.connection.Open()

            If n = 0 Then
                publicquery = "SELECT * FROM dbwh_area"
            ElseIf n = 1 Then
                publicquery = "SELECT * FROM dbCharge_to"
            End If

            cmd = New SqlCommand(publicquery, sq.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a(5) As String

                If n = 0 Then
                    a(0) = dr.Item(0).ToString
                    a(1) = dr.Item(1).ToString
                    a(2) = dr.Item(3).ToString
                ElseIf n = 1 Then
                    a(0) = dr.Item(0).ToString
                    a(1) = dr.Item(1).ToString
                End If

                Dim lvl As New ListViewItem(a)
                lvlChargeTo.Items.Add(lvl)

            End While

            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sq.connection.Close()

        End Try

    End Sub
End Class