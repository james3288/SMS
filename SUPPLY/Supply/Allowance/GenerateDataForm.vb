Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class GenerateDataForm
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public public_query As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GenerateDataForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        DTP_PrevFrom.Focus()
    End Sub



    Public Sub Search_date_report(ByVal x As Integer)
        listview1.Items.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 0 Then
                If Allowance_sum.CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 404)
                    sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                    sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                    sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                    sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)
                Else
                    If cmbSelectCat.Text = "ADMIN" Or cmbSelectCat.Text = "OPERATION" Or cmbSelectCat.Text = "EQUIP" Or cmbSelectCat.Text = "PROJECT" Then

                        sqlcomm.Parameters.AddWithValue("@n", 405)
                        sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)
                        sqlcomm.Parameters.AddWithValue("@selectionCategory", cmbSelectCat.Text)



                    Else
                        sqlcomm.Parameters.AddWithValue("@n", 403)
                        sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)
                    End If

                End If



            End If
            dr = sqlcomm.ExecuteReader
            While dr.Read

                Dim a(23) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString

                Dim lvl As New ListViewItem(a)
                listview1.Items.Add(lvl)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Search_date_report(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If listview1.Items.Count = 0 Then
            MsgBox("no data")
        Else
            preview_allwance_report()
        End If
    End Sub


    Public Sub preview_allwance_report()
        Dim PrevFromDate As DateTime = DTP_PrevFrom.Value
        Dim PrevToDate As DateTime = DTP_PrevTo.Value

        Dim CurFromDate As DateTime = DTP_CurFrom.Value
        Dim CurToDate As DateTime = DTP_CurTo.Value

        Dim resultStringPrev As String = $"{PrevFromDate.ToString("MMM d", CultureInfo.InvariantCulture)}-{PrevToDate.ToString("MMM d, yyyy", CultureInfo.InvariantCulture)}"
        lblDatePrevRange.Text = resultStringPrev

        Dim resultStringCur As String = $"{CurFromDate.ToString("MMM d", CultureInfo.InvariantCulture)}-{CurToDate.ToString("MMM d, yyyy", CultureInfo.InvariantCulture)}"
        lblDateCurRange.Text = resultStringCur

        Dim allawance_data As New DataTable
        Dim i As Integer = 0
        With allawance_data
            .Columns.Add("Charges")
            .Columns.Add("NoPerson1")
            .Columns.Add("Amount1")
            .Columns.Add("NoPerson2")
            .Columns.Add("Amount2")

        End With
        For i = 0 To listview1.Items.Count - 1
            allawance_data.Rows.Add(allawance_data.NewRow)
            allawance_data.Rows(i).Item("Charges") = listview1.Items(i).SubItems(0).Text
            allawance_data.Rows(i).Item("NoPerson1") = listview1.Items(i).SubItems(1).Text
            allawance_data.Rows(i).Item("Amount1") = listview1.Items(i).SubItems(2).Text
            allawance_data.Rows(i).Item("NoPerson2") = listview1.Items(i).SubItems(3).Text
            allawance_data.Rows(i).Item("Amount2") = listview1.Items(i).SubItems(4).Text

        Next
        Dim viewEMs As New DataView(allawance_data)
        AllowanceReportFormNew.ReportViewer1.LocalReport.DataSources.Item(0).Value = viewEMs
        AllowanceReportFormNew.ShowDialog()
        AllowanceReportFormNew.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        try1(0)
    End Sub


    Public Sub try1(ByVal x As Integer)
        listview1.Items.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Allowance"
            sqlcomm.CommandType = CommandType.StoredProcedure

            If x = 0 Then
                If Allowance_sum.CheckBox1.Checked = True Then
                    sqlcomm.Parameters.AddWithValue("@n", 404)
                    sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                    sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                    sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                    sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)
                Else
                    If ComboBox1.Text = "Plant & Equipment" Or ComboBox1.Text = "Project-Based" Or ComboBox1.Text = "Project-Based (local)" Or ComboBox1.Text = "General" Or ComboBox1.Text = "JQG-2go" Then

                        sqlcomm.Parameters.AddWithValue("@n", 408)
                        sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)
                        sqlcomm.Parameters.AddWithValue("@selectionCategory", ComboBox1.Text)

                    ElseIf ComboBox1.Text = "General / Plant & Equipment / JQG-2go" Then
                        sqlcomm.Parameters.AddWithValue("@n", 410)
                        sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)
                        'sqlcomm.Parameters.AddWithValue("@selectionCategory", "")

                    ElseIf ComboBox1.Text = "Project-Based / Project-Based (local)" Then
                        sqlcomm.Parameters.AddWithValue("@n", 413)
                        sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)


                    Else
                        sqlcomm.Parameters.AddWithValue("@n", 403)
                        sqlcomm.Parameters.AddWithValue("@prevDateFrom", DTP_PrevFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@prevDateTo", DTP_PrevTo.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateFrom", DTP_CurFrom.Text)
                        sqlcomm.Parameters.AddWithValue("@nextDateTo", DTP_CurTo.Text)
                    End If

                End If



            End If
            dr = sqlcomm.ExecuteReader
            While dr.Read

                Dim a(23) As String
                a(0) = dr.Item(0).ToString
                a(1) = dr.Item(1).ToString
                a(2) = dr.Item(2).ToString
                a(3) = dr.Item(3).ToString
                a(4) = dr.Item(4).ToString
                'a(5) = dr.Item(5).ToString

                Dim lvl As New ListViewItem(a)
                listview1.Items.Add(lvl)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class