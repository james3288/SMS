Imports System.Data.SqlClient

Public Class ModelOperator_Driver
    Private cSearch As String
    Private cDict As New Dictionary(Of String, Object)
#Region "DELEGATES"
    Private Delegate Function ListOfDriverDelegates() As List(Of driver)
#End Region

    Public Function LISTOFDRIVER(Optional dict As Dictionary(Of String, Object) = Nothing) As List(Of driver)
        'cDict = dict
        Dim DriverDataInstance As ListOfDriverDelegates = AddressOf _get_driver

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = DriverDataInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFDRIVER = DriverDataInstance.EndInvoke(asyncResult)
    End Function
    Private Function _get_driver() As List(Of driver)
        _get_driver = New List(Of driver)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data("proc_operator_driver", SQ.connection)

            While reader.Read
                Dim _driver As New driver
                With _driver
                    .driver_id = reader.Item("operator_id").ToString
                    .driver_name = reader.Item("operator_name").ToString
                    .position = reader.Item("position").ToString

                    _get_driver.Add(_driver)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Sub parameter(key As String, value As Object)
        cDict.Add(key, value)
    End Sub
    Class driver
        Public Property driver_id As Integer
        Public Property driver_name As String
        Public Property position As String

    End Class
End Class
