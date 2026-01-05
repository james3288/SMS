Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_project
    Public trd As Threading.Thread
    Public Property proj_id As Integer
    Public Property datefrom As DateTime
    Public Property dateto As DateTime
    Public Property date_completion As DateTime
    Public Property proj_desc As String
    Public Property location As String
    Public Property contract_id As String
    Public Property contract_name As String
    Public Property project_engineer As String
    Public Property contract_amount As Double
    Public Property budgetary_amount As Double
    Public Property duration As String

    Public Property dateCloseOpen As String

    Public cListOfProject As New List(Of project)
    Public Sub update()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection1.Open()
            newCMD = New SqlCommand("proc_project_duration", newSQ.connection1)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@proj_id", proj_id)
            newCMD.Parameters.AddWithValue("@datefrom", datefrom)
            newCMD.Parameters.AddWithValue("@dateto", dateto)
            newCMD.Parameters.AddWithValue("@date_completion", date_completion)
            newCMD.Parameters.AddWithValue("@date_close_open", dateCloseOpen)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()
            MessageBox.Show("Duration Successfully updated...")
        End Try
    End Sub
    Public Sub edit()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection1.Open()
            newCMD = New SqlCommand("proc_project_duration", newSQ.connection1)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@proj_id", proj_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read

                proj_id = newDR.Item("proj_id").ToString
                datefrom = DateConverter(newDR.Item("datefrom").ToString)
                dateto = DateConverter(newDR.Item("dateto").ToString)
                date_completion = DateConverter(newDR.Item("date_completion").ToString)
                proj_desc = newDR.Item("project_desc").ToString
                location = newDR.Item("location").ToString
                contract_name = newDR.Item("contract_name").ToString
                duration = newDR.Item("project_duration").ToString

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()

        End Try
    End Sub
    Private Function DateConverter(sDate As String) As DateTime
        If IsDate(sDate) Then
            DateConverter = Date.Parse(sDate)
        Else
            DateConverter = Date.Parse("1990-01-01")
        End If

        Return DateConverter

    End Function
    Public Sub select_proj()
        trd = New Threading.Thread(AddressOf thread_select_project)
        trd.Start()
        trd.Join()

        'MsgBox("success")
    End Sub

    Private Sub thread_select_project()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection1.Open()
            newCMD = New SqlCommand("proc_project_duration", newSQ.connection1)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@search", proj_desc)
            newDR = newCMD.ExecuteReader

            While newDR.Read


                Dim duration As Double
                Dim cDatefrom As DateTime = DateConverter(newDR.Item("datefrom").ToString)
                Dim cDateto As DateTime = DateConverter(newDR.Item("dateto").ToString)
                Dim cDateCompletion As DateTime = DateConverter(newDR.Item("date_completion").ToString)
                Dim cDateClose As DateTime = IIf(cDateCompletion = Date.Parse("1990-01-01"), cDateCompletion, cDateCompletion.AddMonths(3))

                duration = cDateto.Subtract(cDatefrom).TotalDays

                Dim days_left As Double
                days_left = IIf(cDateClose = Date.Parse("1990-01-01"), 0, FormatNumber(cDateClose.Subtract(Date.Parse(Now)).TotalDays, 2,,, TriState.True))

                cListOfProject.Add(New project With {
                                   .proj_id = newDR.Item("proj_id").ToString,
                                   .proj_desc = newDR.Item("project_desc").ToString,
                                   .contract_id = newDR.Item("Contract_id").ToString,
                                   .contract_name = newDR.Item("contract_name").ToString,
                                   .datefrom = Format(cDatefrom, "MM/dd/yyyy"),
                                   .dateto = Format(cDateto, "MM/dd/yyyy"),
                                   .duration = newDR.Item("project_duration").ToString, 'duration,
                                   .days_left = days_left,
                                   .date_close = cDateClose,
                                   .project_engineer = newDR.Item("project_engineer").ToString,
                                   .date_completion = cDateCompletion,
                                   .dateCloseOpen = newDR.Item("set_completion").ToString
                                   })


            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection1.Close()

        End Try
    End Sub
    Public Class project
        Public Property proj_id As Integer
        Public Property datefrom As DateTime
        Public Property dateto As DateTime
        Public Property proj_desc As String
        Public Property location As String
        Public Property contract_id As String
        Public Property contract_name As String
        Public Property project_engineer As String
        Public Property contract_amount As Double
        Public Property budgetary_amount As Double
        Public Property duration As String
        Public Property days_left As Double
        Public Property date_completion As DateTime
        Public Property date_close As DateTime
        Public Property dateCloseOpen As String

    End Class

End Class
