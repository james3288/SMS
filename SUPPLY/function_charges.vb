Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class function_charges
    Dim charges_type As String() = {"EQUIPMENT", "PROJECT", "PERSONAL", "MAINOFFICE", "OTHERS"}
    Public Function charges_id(typeofcharges As String, desc As String) As Integer
        Dim query As String = query_id(typeofcharges, 1, desc)
        Dim whatdb As String = query_id(typeofcharges, 3, desc)

        charges_id = get_charges_id(query, whatdb)

    End Function
    Public Function charges_desc(typeofcharges As String, desc As String) As String
        Dim query As String = query_id(typeofcharges, 2, desc)
        Dim whatdb As String = query_id(typeofcharges, 3, desc)

        charges_desc = get_charges_desc(query, whatdb)

    End Function

    Private Function query_id(type As String, n As Integer, desc As String) As String
        If n = 1 Then

            Select Case type
                Case "EQUIPMENT"
                    query_id = "SELECT * FROM dbequipment_list WHERE plate_no = '" & desc & "'"
                Case "PROJECT"
                    query_id = "SELECT * FROM dbprojectdesc WHERE project_desc = '" & desc & "'"

                Case "MAINOFFICE", "PERSONAL", "OTHERS"
                    query_id = "SELECT * FROM dbCharge_to WHERE charge_to = '" & desc & "'"

                Case "WAREHOUSE"
                    query_id = "SELECT * FROM dbwh_area WHERE wh_area = '" & desc & "'"

            End Select

        ElseIf n = 2 Then

            Select Case type
                Case "EQUIPMENT"
                    query_id = "SELECT plate_no FROM dbequipment_list WHERE equipListID = " & CInt(desc)
                Case "PROJECT"
                    query_id = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = " & CInt(desc)

                Case "MAINOFFICE", "PERSONAL", "OTHERS"
                    query_id = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & CInt(desc)

                Case "WAREHOUSE"
                    query_id = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = '" & CInt(desc) & "'"
            End Select

        ElseIf n = 3 Then
            Select Case type
                Case "EQUIPMENT"
                    query_id = 2

                Case "PROJECT"
                    query_id = 2

                Case "MAINOFFICE", "PERSONAL", "OTHERS", "WAREHOUSE"
                    query_id = 1

            End Select
        End If


    End Function
    Private Function get_charges_id(query As String, whatdb As Integer) As Integer

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try

            If whatdb = 1 Then
                newSQ.connection.Open()
                newCMD = New SqlCommand(query, newSQ.connection)
                newDR = newCMD.ExecuteReader
                While newDR.Read
                    get_charges_id = CInt(newDR.Item(0).ToString)
                End While
                newDR.Close()

            ElseIf whatdb = 2 Then
                newSQ.connection1.Open()
                newCMD = New SqlCommand(query, newSQ.connection1)
                newDR = newCMD.ExecuteReader
                While newDR.Read
                    get_charges_id = CInt(newDR.Item(0).ToString)
                End While
                newDR.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If whatdb = 1 Then
                newSQ.connection.Close()
            ElseIf whatdb = 2 Then
                newSQ.connection1.Close()
            End If

        End Try

    End Function

    Private Function get_charges_desc(query As String, whatdb As Integer) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try

            If whatdb = 1 Then
                newSQ.connection.Open()
                newCMD = New SqlCommand(query, newSQ.connection)
                newDR = newCMD.ExecuteReader
                While newDR.Read
                    get_charges_desc = newDR.Item(0).ToString
                End While
                newDR.Close()

            ElseIf whatdb = 2 Then
                newSQ.connection1.Open()
                newCMD = New SqlCommand(query, newSQ.connection1)
                newDR = newCMD.ExecuteReader
                While newDR.Read
                    get_charges_desc = newDR.Item(0).ToString
                End While
                newDR.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If whatdb = 1 Then
                newSQ.connection.Close()
            ElseIf whatdb = 2 Then
                newSQ.connection1.Close()
            End If

        End Try

    End Function


End Class
