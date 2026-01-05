Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_operator
    Public cListOfOperator As New List(Of equipment_operator)
    Public Sub get_operator()
        cListOfOperator.Clear()

        Dim sqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim cmd As SqlCommand

        Try
            sqlcon.connection1.Open()
            publicquery = "SELECT * FROM dboperator ORDER BY operator_name ASC"
            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            newdr = cmd.ExecuteReader
            While newdr.Read
                Dim eo As New equipment_operator
                eo.operator_id = newdr.Item("operator_id").ToString
                eo.operator_name = newdr.Item("operator_name").ToString
                eo.position = newdr.Item("position").ToString

                cListOfOperator.Add(eo)
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()

        End Try
    End Sub
    Public Class equipment_operator
        Public Property operator_id As Integer
        Public Property operator_name As String
        Public Property position As String

    End Class
End Class
