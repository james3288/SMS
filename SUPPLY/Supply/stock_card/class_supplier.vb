Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_supplier

    Public cListOfSupplier As New List(Of supplier)

    Public Sub supplier_data()
        Dim trd As Threading.Thread

        trd = New Threading.Thread(AddressOf get_supplier)
        trd.Start()
        trd.Join()

    End Sub

    Public Sub get_supplier()
        cListOfSupplier.Clear()

        Dim sqlcon As New SQLcon
        Dim newdr As SqlDataReader
        Dim cmd As SqlCommand

        Try
            sqlcon.connection.Open()
            publicquery = "SELECT * FROM dbSupplier ORDER BY Supplier_Name ASC"
            cmd = New SqlCommand(publicquery, sqlcon.connection)
            newdr = cmd.ExecuteReader

            While newdr.Read
                Dim sup As New supplier
                sup.supplier_id = newdr.Item("Supplier_Id").ToString
                sup.supplier_name = newdr.Item("Supplier_Name").ToString
                sup.supplier_location = newdr.Item("Supplier_Location").ToString
                sup.terms = newdr.Item("terms").ToString

                cListOfSupplier.Add(sup)

            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection.Close()
        End Try
    End Sub

    Public Class supplier
        Public Property supplier_id As Integer
        Public Property supplier_name As String
        Public Property supplier_location As String
        Public Property terms As String

    End Class
End Class
