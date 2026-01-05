Imports System.Data.SqlClient
Public Class Model_UserInfo
    Private cDict As New Dictionary(Of String, Object)
    Private userInfoObj As New CUserInfo

#Region "PARAMETERS"
    Public Sub parameter(key As String, value As Object)
        cDict.Add(key, value)
    End Sub
    Public Sub clear_parameter()
        cDict = New Dictionary(Of String, Object)
    End Sub
#End Region
#Region "DELEGATES"
    Private Delegate Function getUserInfoDelegates() As CUserInfo
#End Region
#Region "INTERFACE"
    Class CUserInfo
        Property user_id As Integer
        Property fname As String
        Property lname As String
        Property username As String
        Property password As String
        Property restriction As String
        Property access As String
        Property gender As String

    End Class

    Class CUserAccessDesc
        Property user_id As Integer
        Property access_desc As String
        Property access_no As Integer

    End Class


#End Region
#Region "FUNCTIONS"
    Public Function _initialize(n As Integer, username As String, password As String) As CUserInfo

        parameter("@n", n)
        parameter("@username", username)
        parameter("@password", password)

        _initialize = getUserInfo()


    End Function
    Public Function getUserInfo() As CUserInfo

        'INITIALIZING DATA HERE

        Dim getDataInstance As getUserInfoDelegates = Nothing
        getDataInstance = AddressOf _getUserInfo

        Dim asyncResult As IAsyncResult = getDataInstance.BeginInvoke(Nothing, Nothing)

        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        getUserInfo = getDataInstance.EndInvoke(asyncResult)
    End Function

    Private Function _getUserInfo() As CUserInfo
        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        _getUserInfo = New CUserInfo

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data("proc_user_access", SQ.connection)

            While reader.Read
                'loop here
                With _getUserInfo
                    .user_id = reader.Item("user_id").ToString
                    .fname = reader.Item("fname").ToString
                    .lname = reader.Item("lname").ToString
                    .username = reader.Item("username").ToString
                    .password = reader.Item("password").ToString
                    .restriction = reader.Item("restriction").ToString
                    .access = reader.Item("access").ToString
                    .gender = reader.Item("gender").ToString
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function
#End Region




End Class
