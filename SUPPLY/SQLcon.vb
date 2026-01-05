Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class SQLcon

    Dim fso As New FileIO.FileSystem
    Dim iniFile, inifile1, inifile2 As String

    Protected SQ As SqlConnection
    Protected server As String '= "192.168.1.92"
    Protected database As String '= "supply_db"
    Protected userid As String '= "sa"
    Protected pass As String '= "adfil"

    'for eus database (192.168.2.93)
    Protected server1 As String '= "192.168.1.92"
    Protected database1 As String '= "supply_db"
    Protected userid1 As String '= "sa"
    Protected pass1 As String '= "adfil"

    'for eus database (192.168.2.92)
    Protected server2 As String '= "192.168.1.92"
    Protected database2 As String '= "supply_db"
    Protected userid2 As String '= "sa"
    Protected pass2 As String '= "adfil"

    Public connection As SqlConnection
    Public connection1 As SqlConnection
    Public connection2 As SqlConnection
    ' Public cn As New SqlConnection

    Public Sub New()

        Dim spl As String
        Dim sp As System.Array

        'for eus data
        Dim spl1 As String
        Dim sp1 As System.Array

        iniFile = Application.StartupPath & "\syscon.ini" 'supply database 192.168.2.96
        inifile1 = Application.StartupPath & "\syscon1.ini" 'eus database 192.168.2.96
        inifile2 = Application.StartupPath & "\syscon2.ini" 'eus database 192.168.2.96

        If FileIO.FileSystem.FileExists(iniFile) Then
            spl = FileIO.FileSystem.ReadAllText(iniFile)
            sp = Split(spl, ";")

            server = sp(0)
            database = sp(1)
            userid = sp(2)
            pass = sp(3)

            connection = New SqlConnection("Data Source=" & server & ";Initial Catalog=" & database & ";User ID=" & userid & ";Password=" & pass & "; Trusted_Connection=false;")
            'connection = New SqlConnection($"Data Source={server},{10013};Network Library=DBMSSOCN;Initial Catalog={database};User ID={userid};Password={pass};")
        End If

        If FileIO.FileSystem.FileExists(inifile1) Then
            spl1 = FileIO.FileSystem.ReadAllText(inifile1)
            sp1 = Split(spl1, ";")

            server1 = sp1(0)
            database1 = sp1(1)
            userid1 = sp1(2)
            pass1 = sp1(3)

            connection1 = New SqlConnection("Data Source=" & server1 & ";Initial Catalog=" & database1 & ";User ID=" & userid1 & ";Password=" & pass1 & "; Trusted_Connection=false;")
        Else
        End If


        If FileIO.FileSystem.FileExists(inifile2) Then
            spl1 = FileIO.FileSystem.ReadAllText(inifile2)
            sp1 = Split(spl1, ";")

            server2 = sp1(0)
            database2 = sp1(1)
            userid2 = sp1(2)
            pass2 = sp1(3)

            connection2 = New SqlConnection("Data Source=" & server2 & ";Initial Catalog=" & database2 & ";User ID=" & userid2 & ";Password=" & pass2 & "; Trusted_Connection=false;")
        Else
        End If

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

Public Class SQLcon2
    Public SQ As SqlConnection
    Public server As String
    Public database As String
    Public userid As String
    Public pass As String

    Public connection As SqlConnection

    Public Function set_sql(ByVal sver As String, ByVal db As String, ByVal uid As String, ByVal ups As String)

        server = sver
        database = db
        userid = uid
        pass = ups

    End Function

    Public Function sql_connect()
        connection = New SqlConnection("Server = " & server & ";Database=" & database & ";User Id=" & userid & ";Password=" & pass & "; Trusted_Connection=false")

    End Function

End Class
