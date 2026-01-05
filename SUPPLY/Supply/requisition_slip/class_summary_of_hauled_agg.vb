Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_summary_of_hauled_agg
    Dim trd As Threading.Thread
    Public cListOfProject As New List(Of C_PROJECT)
    Public cListOfProject_and_Items As New List(Of SELECTEDITEMS)

    Private _charges_id As Integer
    Private _project_name As String

    Public Sub _initialize()

    End Sub

    Public Sub get_project()

        cListOfProject.Clear()
        trd = New Threading.Thread(AddressOf set_project)
        trd.Start()
        trd.Join()

    End Sub

    Public Sub get_items_from_project(charges_id As Integer, project_name As String)
        _charges_id = charges_id
        _project_name = project_name

        trd = New Threading.Thread(AddressOf set_items_from_project)
        trd.Start()
        trd.Join()
    End Sub

    Private Sub set_project()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection1.Open()
            Dim query As String = "SELECT a.proj_id,a.project_desc,a.location FROM dbprojectdesc a order by a.project_desc asc"
            newCMD = New SqlCommand(query, newSQ.connection1)
            newCMD.Parameters.Clear()
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim cp As New C_PROJECT
                With cp
                    .proj_id = newDR.Item("proj_id").ToString
                    .project = newDR.Item("project_desc").ToString
                    .location = newDR.Item("location").ToString

                End With

                cListOfProject.Add(cp)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
        End Try
    End Sub

    Private Sub set_items_from_project()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_summary_of_hauled_aggregates", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@charges_id", _charges_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim cc As New SELECTEDITEMS
                With cc
                    .wh_id = newDR.Item("wh_id").ToString
                    .proj_id = _charges_id
                    .project_name = _project_name
                    .items = newDR.Item("items").ToString
                    .stockpile = newDR.Item("stockpile").ToString
                    .source = newDR.Item("source_area").ToString
                End With

                cListOfProject_and_Items.Add(cc)

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Class C_PROJECT
        Public Property proj_id As Integer
        Public Property project As String
        Public Property location As String
    End Class

    Public Class SELECTEDITEMS
        Public Property proj_id As Integer
        Public Property project_name As String
        Public Property wh_id As Integer
        Public Property items As String
        Public Property stockpile As String
        Public Property source As String


    End Class
End Class
