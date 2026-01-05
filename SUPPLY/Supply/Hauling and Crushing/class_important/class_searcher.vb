Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_searcher

    Public cListOfDriver As New List(Of String)
    Public Sub driver()
        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        cListOfDriver.Clear()

        Try

            Dim cQuery As New class_query
            Dim param As New Dictionary(Of String, String) From {
                    {"@n", 8},
                    {"searchby", "DRIVER"}
            }

            newdr = cQuery.SQ_Data_Reader("proc_dr_list2", param, newSQ)

            While newdr.Read
                cListOfDriver.Add(newdr.Item("operator").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub txt_autoComplete(textbox As TextBox)
        Dim searchlist As New AutoCompleteStringCollection

        For Each row As String In cListOfDriver
            searchlist.Add(row)
        Next

        textbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        textbox.AutoCompleteSource = AutoCompleteSource.CustomSource
        textbox.AutoCompleteCustomSource = searchlist
    End Sub


End Class
