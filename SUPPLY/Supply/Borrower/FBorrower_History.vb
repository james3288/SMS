Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrower_History
    Public rr_item_sub_id As Integer

    Private Sub FBorrower_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbSearchBy.Text = "Sub Item Desc."
        'load_borrower_history()
    End Sub

    Public Sub load_borrower_history()
        lvlBorrowerItem.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim a(30) As String
        Dim c As Integer

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 44)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                a(0) = newDR.Item("rr_item_sub_id").ToString
                a(1) = newDR.Item("sub_item_desc").ToString
                a(2) = newDR.Item("qty").ToString
                a(3) = newDR.Item("rr_item_id").ToString
                a(4) = newDR.Item("br_tr_det_id").ToString
                a(5) = newDR.Item("typeofborrow").ToString
                a(6) = newDR.Item("bs_no").ToString
                a(7) = Format(Date.Parse(newDR.Item("date_borrow").ToString), "MM/dd/yyyy")
                a(8) = newDR.Item("purpose").ToString
                a(9) = newDR.Item("typeofcharges").ToString
                a(10) = FListofBorrowerItem.load_multiple_charges(newDR.Item("multiple_charges").ToString) & FReceivingReport.multiplecharges(CInt(newDR.Item("rs_id").ToString), 0)
                a(11) = newDR.Item("withdrawn_by").ToString
                a(12) = newDR.Item("released_by").ToString
                a(13) = newDR.Item("noted_by").ToString
                a(14) = newDR.Item("approved_by").ToString
                a(15) = newDR.Item("remarks").ToString
                a(16) = newDR.Item("br_tr_id").ToString
                a(17) = calc_month_and_days(Date.Parse(a(7)), Now)

                Dim br_tr_det_id As Integer = CInt(newDR.Item("br_tr_det_id").ToString)

                Dim estimateddays As Integer = FListofBorrowerItem.return_estimated_days(br_tr_det_id, 1)
                Dim extendeddays As Integer = FListofBorrowerItem.return_estimated_days(br_tr_det_id, 2)

                'a(18) = calc_month_and_days(Date.Parse(a(7)), Date.Parse(a(7)).AddDays(estimateddays + extendeddays))
                a(18) = Date.Parse(a(7)).AddDays(estimateddays + extendeddays)

                If check_if_exist("dbborrower_turnover_details", "br_tr_det_id", br_tr_det_id, 1) > 0 Then
                    'a(2) = get_borrower_turnover_data(br_tr_det_id, 1)
                    a(19) = get_borrower_turnover_data(br_tr_det_id, 2)


                    Dim return_from As String = get_borrower_turnover_data(br_tr_det_id, 4)
                    Dim split() As String = return_from.Split(": ,")

                    For count As Integer = 0 To split.Length - 1
                        a(21) = split(1)
                        a(22) = split(3)
                    Next

                    'Dim return_from As String = FListofBorrowerItem.return_from(get_borrower_turnover_data(br_tr_det_id, 4))
                    'Dim return_to As String = FListofBorrowerItem.return_to(get_borrower_turnover_data(br_tr_det_id, 4))

                    'a(20) = get_borrower_turnover_data(br_tr_det_id, 3)

                    'a(21) = IIf(return_from = Nothing, ";", return_from)
                    'a(22) = IIf(return_to = Nothing, ";", return_to)

                    'a(21) = a(21).Replace("PROJECT:", "").Replace("MAINOFFICE:", "").Replace("EQUIPMENT:", "").Replace("PERSONAL:", "").Replace("OTHERS:", "").Replace(":", ",").Replace("WAREHOUSE", "").Replace(",,", ",")
                    'a(22) = a(22).Replace("PROJECT:", "").Replace("MAINOFFICE:", "").Replace("EQUIPMENT:", "").Replace("PERSONAL:", "").Replace("OTHERS:", "").Replace(":", ",").Replace("WAREHOUSE", "").Replace(",,", ",")

                    'a(21) = remove_last_character(a(21))
                    'a(22) = remove_last_character(a(22))

                Else
                    a(19) = ""
                    a(21) = ""
                    a(22) = ""
                    a(24) = newDR.Item("rs_id").ToString

                End If

                a(25) = IIf(get_borrower_turnover_data(br_tr_det_id, 5) = "", "Waiting for turnover", get_borrower_turnover_data(br_tr_det_id, 5))
                a(26) = IIf(get_borrower_turnover_data(br_tr_det_id, 6) = "", 0, get_borrower_turnover_data(br_tr_det_id, 6))

                If a(21) = "" Then
                    a(23) = "BORROWED"
                Else
                    If CInt(a(26)) < CInt(a(2)) Then
                        a(23) = "PARTIALLY TURNOVER"
                    Else
                        a(23) = "TURNOVER"
                    End If


                End If


                If cmbSearchBy.Text = "Sub Item Desc." Then
                    If search_by(a(1), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchBy.Text = "Custodian" Then
                    If search_by(a(10), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchBy.Text = "Turnover by" Then
                    If search_by(a(20), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchBy.Text = "Turnover from" Then
                    If search_by(a(21), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchBy.Text = "Turnover to" Then
                    If search_by(a(22), txtSearch.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                ElseIf cmbSearchBy.Text = "Date Borrow" Then
                    If search_by(a(7), DTP_search.Text) = True Then
                    Else
                        GoTo proceedhere
                    End If
                End If

                Dim lvl As New ListViewItem(a)
                lvlBorrowerItem.Items.Add(lvl)

                Dim timespan1 As TimeSpan = Now - Date.Parse(a(7))
                Dim timespan2 As TimeSpan = Date.Parse(a(7)).AddDays(estimateddays + extendeddays) - Date.Parse(a(7))

                If timespan1.TotalDays >= timespan2.TotalDays Then
                    If a(5) = "BS" And a(23) <> "TURNOVER" Then
                        lvlBorrowerItem.Items(c).BackColor = Color.Brown
                        lvlBorrowerItem.Items(c).ForeColor = Color.White

                    ElseIf a(5) = "BS" And a(23) = "TURNOVER" Then
                        lvlBorrowerItem.Items(c).BackColor = Color.Orange
                        lvlBorrowerItem.Items(c).ForeColor = Color.Black
                    End If

                ElseIf timespan1.TotalDays < timespan2.TotalDays Then
                    If a(5) = "BS" And a(23) <> "TURNOVER" Then
                        lvlBorrowerItem.Items(c).BackColor = Color.White
                        lvlBorrowerItem.Items(c).ForeColor = Color.Black

                    ElseIf a(5) = "BS" And a(23) = "TURNOVER" Then
                        lvlBorrowerItem.Items(c).BackColor = Color.Yellow
                        lvlBorrowerItem.Items(c).ForeColor = Color.Black
                    End If

                End If

                c += 1

proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function get_borrower_turnover_data(ByVal br_tr_det_id As Integer, ByVal n As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim qty As Decimal
        Dim borrower_turnover_date As DateTime

        get_borrower_turnover_data = ""

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 88)
            newCMD.Parameters.AddWithValue("@br_tr_det_id", br_tr_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                If n = 1 Then
                    get_borrower_turnover_data &= CDec(newDR.Item("qty").ToString) & ","

                ElseIf n = 2 Then
                    borrower_turnover_date = Format(Date.Parse(newDR.Item("date_turnover").ToString), "MM/dd/yyyy")
                    get_borrower_turnover_data &= borrower_turnover_date & ","

                ElseIf n = 3 Then
                    get_borrower_turnover_data = newDR.Item("turnover_by").ToString

                ElseIf n = 4 Then
                    get_borrower_turnover_data = newDR.Item("return_from_to").ToString

                ElseIf n = 5 Then
                    get_borrower_turnover_data = newDR.Item("item_stat").ToString
                ElseIf n = 6 Then
                    qty += CDec(newDR.Item("qty").ToString)
                    get_borrower_turnover_data = qty
                End If

            End While

            newDR.Close()

            If n = 2 Or n = 1 Then
                get_borrower_turnover_data = remove_last_character(get_borrower_turnover_data)
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try

    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        load_borrower_history()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown, DTP_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchBy.SelectedIndexChanged

        Select Case cmbSearchBy.Text
            Case "Date Borrow"
                DTP_search.Parent = gboxSearch
                DTP_search.Visible = True
                DTP_search.Location = New Point(txtSearch.Bounds.Left, txtSearch.Bounds.Top)

                DTP_search.Width = txtSearch.Width
                txtSearch.Visible = False
            Case Else
                txtSearch.Visible = True
                txtSearch.Focus()
                DTP_search.Visible = False
        End Select

    End Sub

    Private Sub FBorrower_History_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lvlBorrowerItem.Width = Me.Width - 16
        lvlBorrowerItem.Height = Me.Height - 100
        gboxSearch.Location = New Point(lvlBorrowerItem.Location.X + 2, lvlBorrowerItem.Bounds.Bottom)
    End Sub

    Private Sub TURNOVERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TURNOVERToolStripMenuItem.Click
        Dim a(10) As String

        FBorrower_Turnover_Items.DataGridView1.Rows.Clear()

        For Each row As ListViewItem In lvlBorrowerItem.Items
            Dim stat As String = ""

            stat = row.SubItems(23).Text

            If row.Checked = True And stat <> "TURNOVER" Then

                a(1) = row.SubItems(6).Text
                a(2) = row.SubItems(1).Text
                a(3) = row.SubItems(2).Text
                a(4) = row.SubItems(2).Text
                a(5) = "Functional"
                a(6) = row.SubItems(4).Text
                a(7) = row.SubItems(24).Text

                FBorrower_Turnover_Items.DataGridView1.Rows.Add(a)

            End If
        Next


        With FBorrower_Turnover_Items

            For i = 0 To .DataGridView1.Rows.Count - 1
                .DataGridView1.Rows(i).Cells(0).Value = True
            Next


            .ShowDialog()

        End With

    End Sub
End Class