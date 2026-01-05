Imports System.Data.Sql
Imports System.Data.SqlClient


Module Mod_Borrower_functions
    Public borrower_edit As Integer
    Public bs_id As Integer

    Public Function get_brand_name(ByVal fi_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        With FBorrower_Turnover

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_facilities", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 19)
                newCMD.Parameters.AddWithValue("@fi_id", fi_id)

                newDR = newCMD.ExecuteReader

                While newDR.Read
                    get_brand_name = newDR.Item("brand").ToString()
                End While
                newDR.Close()

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End With

    End Function


    Public Function GET_equip_desc_AND_proj_desc(ByVal id As Integer, ByVal n As Integer) As String
        'Dim sqlcon1 As New SQLcon2
        Dim sqlcon1 As New SQLcon
        Dim sqlconnew As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand

        Try
            If n = 1 Then
                'equipment
                'sqlcon1.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon1.sql_connect()

                sqlcon1.connection1.Open()

                publicquery = "SELECT plate_no FROM dbequipment_list WHERE equipListID = " & id
            ElseIf n = 2 Then
                'project
                'sqlcon1.set_sql("192.168.1.91", "eus", "sa", "adfil")
                'sqlcon1.sql_connect()

                sqlcon1.connection1.Open()

                publicquery = "SELECT project_desc FROM dbprojectdesc WHERE proj_id = " & id
            ElseIf n = 3 Then
                'adfil
                sqlconnew.connection.Open()

                publicquery = "SELECT charge_to FROM dbCharge_to WHERE charge_to_id = " & id
            ElseIf n = 4 Then
                'warehouse
                sqlconnew.connection.Open()

                publicquery = "SELECT wh_area FROM dbwh_area WHERE wh_area_id = " & id

            End If

            If n = 1 Or n = 2 Then
                newcmd = New SqlCommand(publicquery, sqlcon1.connection1)
            ElseIf n = 3 Or n = 4 Then
                newcmd = New SqlCommand(publicquery, sqlconnew.connection)
            End If

            newdr = newcmd.ExecuteReader

            While newdr.Read
                GET_equip_desc_AND_proj_desc = newdr.Item(0).ToString
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If n = 1 Or n = 2 Then
                sqlcon1.connection1.Close()
            ElseIf n = 3 Or n = 4 Then
                sqlconnew.connection.Close()

            End If

        End Try

    End Function
End Module
