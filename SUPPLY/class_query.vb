Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_query
    Dim cListOfParameter As New Dictionary(Of String, Object)
    Public cParameters As New Dictionary(Of String, Object)

    Public Sub addParameters()
        For Each pair As KeyValuePair(Of String, Object) In cParameters
            add_parameter(pair.Key, pair.Value)
        Next
    End Sub

    Public ReadOnly Property getParameters As Dictionary(Of String, Object)
        Get
            Return cParameters
        End Get
    End Property

    Public Function sql_data(procedure As String, con As SqlConnection, Optional timeout As Integer = 60) As SqlDataReader
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            con.Open()
            newCMD = New SqlCommand(procedure, con)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = timeout

            For Each item In cListOfParameter
                newCMD.Parameters.AddWithValue(item.Key, item.Value)
            Next

            sql_data = newCMD.ExecuteReader
            Return sql_data

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function insert_update(procedure As String, con As SqlConnection) As SqlCommand
        Dim newSQ As New SQLcon

        Try
            con.Open()
            insert_update = New SqlCommand(procedure, con)
            insert_update.Parameters.Clear()
            insert_update.CommandType = CommandType.StoredProcedure

            For Each item In cListOfParameter
                insert_update.Parameters.AddWithValue(item.Key, item.Value)
            Next


            Return insert_update

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function delete(procedure As String, con As SqlConnection) As SqlCommand
        Dim newSQ As New SQLcon

        Try
            con.Open()
            delete = New SqlCommand(procedure, con)
            delete.Parameters.Clear()
            delete.CommandType = CommandType.StoredProcedure

            For Each item In cListOfParameter
                delete.Parameters.AddWithValue(item.Key, item.Value)
            Next

            Return delete

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function check_paramater(data As Object)
        If TypeOf data Is String Then
            Dim str As String = data
            Return str
        ElseIf TypeOf data Is Integer Then
            Dim int As Integer = data
            Return int
        ElseIf TypeOf data Is Double Then
            Dim doub As Double = data
            Return doub
        ElseIf TypeOf data Is DateTime Then
            Dim datetime As DateTime = Date.Parse(data)
            Return datetime
        End If
    End Function

    Public Sub add_parameter(dic_keys As String, dic_value As Object)
        cListOfParameter.Add(dic_keys, check_paramater(dic_value))
    End Sub

    Public Function SQ_Data_Reader(proc_name As String, sqlparam As Dictionary(Of String, String), sq As SQLcon) As SqlDataReader

        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            sq.connection.Open()
            newCMD = New SqlCommand(proc_name, sq.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            For Each pair As KeyValuePair(Of String, String) In sqlparam

                If IsNumeric(pair.Value) = True Then
                    newCMD.Parameters.AddWithValue(pair.Key, Double.Parse(pair.Value))

                ElseIf IsDate(pair.Value) = True Then
                    newCMD.Parameters.AddWithValue(pair.Key, Date.Parse(pair.Value))
                Else
                    newCMD.Parameters.AddWithValue(pair.Key, pair.Value)
                End If
            Next

            newDR = newCMD.ExecuteReader
            SQ_Data_Reader = newDR

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class
