Imports System.Data.OleDb

Public Class OLEDBcon

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim myCommand As System.Data.OleDb.OleDbCommand
    'Public strDestination As String = "D:\JOPHET FILES\supply system\General Directory.xlsx"
    Public strDestination As String = ""
    Public connection As System.Data.OleDb.OleDbConnection

    Public Sub setDestination(ByVal value As String)
        strDestination = value
    End Sub

    Public Sub OLEConnection(ByVal strDestination As String)
        'Dim con As New System.Data.OleDb.OleDbConnection With {.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDestination & ";Extended Properties='Excel 8.0 Xml;HDR=YES;IMEX=1;'"}
        Dim con As New System.Data.OleDb.OleDbConnection With {.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & strDestination & "';Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'"}
        connection = con
    End Sub

    Public Function hasConnection() As Boolean
        Try
            connection.Open()
            connection.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
            Return False
        End Try
    End Function

End Class

