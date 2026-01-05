Imports System.Data.Sql
Imports System.Data.SqlClient
Module Load_Request_Field
    Dim list_location As New List(Of List(Of String))
    Dim list_unit As New List(Of List(Of String))
    Dim list_requested_by As New List(Of List(Of String))
    Dim list_noted_by As New List(Of List(Of String))

    Public SQLcon As New SQLcon ' new declaration sa sqlconnection
    Public sqldr As SqlDataReader

    Sub load_names()
        Dim txt_location As String = "SELECT DISTINCT
                                        a.location  
                                        FROM dbrequisition_slip a 
                                        order by a.location"
        Dim txt_unit As String = "SELECT DISTINCT
                                        a.unit
                                        FROM dbrequisition_slip a 
                                        order by a.unit"
        Dim txt_requested_by As String = "SELECT DISTINCT
                                        a.requested_by
                                        FROM dbrequisition_slip a 
                                        order by a.requested_by"
        Dim txt_noted_by As String = "SELECT DISTINCT
                                        a.noted_by
                                        FROM dbrequisition_slip a 
                                        order by a.noted_by"
        Try
            Dim cmd1 As SqlCommand
            Dim cmd2 As SqlCommand
            Dim cmd3 As SqlCommand
            Dim cmd4 As SqlCommand
            SQLcon.connection.Open()

            cmd1 = New SqlCommand(txt_location, SQLcon.connection)
            cmd1.Parameters.Clear()
            cmd1.CommandType = CommandType.Text

            cmd2 = New SqlCommand(txt_unit, SQLcon.connection)
            cmd2.Parameters.Clear()
            cmd2.CommandType = CommandType.Text

            cmd3 = New SqlCommand(txt_requested_by, SQLcon.connection)
            cmd3.Parameters.Clear()
            cmd3.CommandType = CommandType.Text

            cmd4 = New SqlCommand(txt_noted_by, SQLcon.connection)
            cmd4.Parameters.Clear()
            cmd4.CommandType = CommandType.Text

            ''''''''''''''''''''''''''''''''''''''''''''''''''
            sqldr = cmd1.ExecuteReader
            While sqldr.Read
                Dim items As New List(Of String)
                items.Add(sqldr(0).ToString)
                list_location.Add(items)
            End While
            sqldr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            sqldr = cmd2.ExecuteReader
            While sqldr.Read
                Dim items As New List(Of String)
                items.Add(sqldr(0).ToString)
                list_unit.Add(items)
            End While
            sqldr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            sqldr = cmd3.ExecuteReader
            While sqldr.Read
                Dim items As New List(Of String)
                items.Add(sqldr(0).ToString)
                list_requested_by.Add(items)
            End While
            sqldr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            sqldr = cmd4.ExecuteReader
            While sqldr.Read
                Dim items As New List(Of String)
                items.Add(sqldr(0).ToString)
                list_noted_by.Add(items)
            End While
            sqldr.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & ex.StackTrace() & vbCrLf & "Info: " & ex.Message, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub

    Sub load_location_names(txtbox As TextBox)
        Dim data_names As New AutoCompleteStringCollection
        For Each item As List(Of String) In list_location.Distinct()
            data_names.Add(item(0))
        Next
        txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbox.AutoCompleteCustomSource = data_names
    End Sub
    Sub load_unit_names(txtbox As TextBox)
        Dim data_names As New AutoCompleteStringCollection
        'For Each item As List(Of String) In list_unit
        '    data_names.Add(item(0))
        'Next
        For Each row In Results.cListOfProperNaming
            data_names.Add(row.units)
        Next

        txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbox.AutoCompleteCustomSource = data_names
    End Sub
    Sub load_requested_by_names(txtbox As TextBox)
        Dim data_names As New AutoCompleteStringCollection
        'For Each item As List(Of String) In list_requested_by
        '    data_names.Add(item(0))
        'Next
        For Each row In cListOfEmployees
            data_names.Add(row.employee)
        Next
        txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbox.AutoCompleteCustomSource = data_names
    End Sub
    Sub load_noted_by_names(txtbox As TextBox)
        Dim data_names As New AutoCompleteStringCollection
        'For Each item As List(Of String) In list_noted_by
        '    data_names.Add(item(0))
        'Next
        For Each row In cListOfEmployees
            data_names.Add(row.employee)
        Next
        txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbox.AutoCompleteCustomSource = data_names
    End Sub
    Sub set_actual_casing(txtbox As TextBox)
        For Each item As String In txtbox.AutoCompleteCustomSource
            If txtbox.Text.ToUpper.Equals(item.ToUpper) Then
                txtbox.Text = item
                Exit For
            End If
        Next
    End Sub
End Module
