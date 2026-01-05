Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FSORTBY
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FDRLIST.lvl_drList.Items.Clear()

        'FDRLIST.load_DR(55)
        'If cmbEnable_Disable.Text = "ENABLE" Then
        '    FDRLIST.dr_list(35, txtItemDesc.Text)
        'Else
        '    FDRLIST.dr_list(36, txtItemDesc.Text)
        'End If

        'ElseIf cmbSortBy.Text = "DR DATE" Then
        '    FDRLIST.dr_list(31, txtItemDesc.Text)
        'Else
        '    'FDRLIST.load_DR(57)
        '    FDRLIST.dr_list(30, txtItemDesc.Text)

        'dr_month_export = Date.Parse(dtpfrom.Text)
        'waste_excemption()
        'FWasteExcemption.ShowDialog()

        If cmbEnable_Disable.Text = "ENABLE" Then
            MOTHER_RS1(3992)
            'If FDRLIST.cmbRequestor.Text = "" Then
            '    MOTHER_RS1(3992)
            'Else
            '    MOTHER_RS(392)
            '    SUB_RS(40)
            'End If

        Else
            'If cmbSortBy.Text = "DR NO" Then
            '    get_dr1(42)
            'Else
            '    MOTHER_RS(392)
            '    SUB_RS(42)
            'End If

            MOTHER_RS(392)
            'MOTHER_RS(393)
            SUB_RS(42)
        End If

            'SUB_RS(41)

            'try_lng()

            Me.Close()

    End Sub
    Private Sub try_lng()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 42)
            newCMD.Parameters.AddWithValue("@project", FDRLIST.txtSearch.Text)
            newCMD.Parameters.AddWithValue("@rs_no", txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@inout", cmbINOUT.Text)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))
            newCMD.CommandTimeout = 220

            newDR = newCMD.ExecuteReader

            Dim a(35) As String

            While newDR.Read
                a(0) = 0
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "dd/MM/yyyy")
                a(4) = newDR.Item("item_name").ToString
                a(29) = newDR.Item("item_desc").ToString
                a(5) = newDR.Item("SUPP_SOURCE").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("DRIVER").ToString
                a(10) = newDR.Item("PROJECT").ToString
                a(11) = newDR.Item("SUPPLIER").ToString 'a(7) source_wh
                a(12) = newDR.Item("checkedBy").ToString
                a(13) = newDR.Item("receivedby").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("username").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(30) = Format(Date.Parse(newDR.Item("date_request").ToString), "dd/MM/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                End If

                Dim lvl As New ListViewItem(a)

                FDRLIST.lvl_drList.Items.Add(lvl)

                Application.DoEvents()

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub MOTHER_RS(n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FDRLIST.lvl_drList.Groups.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If FDRLIST.cmbRequestor.Text = "" Then
                newCMD.Parameters.AddWithValue("@n", n)
            Else
                'newCMD.Parameters.AddWithValue("@n", 391)
                Dim lvlgroup1 As New ListViewGroup(FDRLIST.cmbRequestor.Text, HorizontalAlignment.Left)
                lvlgroup1.Name = FDRLIST.cmbRequestor.Text
                FDRLIST.lvl_drList.Groups.Add(lvlgroup1)
                Exit Sub
            End If

            'newCMD.Parameters.AddWithValue("@project", FDRLIST.txtSearch.Text)
            newCMD.Parameters.AddWithValue("@project", FDRLIST.cmbRequestor.Text)
            newCMD.Parameters.AddWithValue("@searchby1", cmbSortBy.Text)
            newCMD.Parameters.AddWithValue("@search", txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                With FDRLIST
                    a(10) = newDR.Item("PROJECT").ToString

                    Dim lvlgroup As New ListViewGroup(newDR.Item("PROJECT").ToString, HorizontalAlignment.Left)
                    lvlgroup.Name = newDR.Item("PROJECT").ToString

                    .lvl_drList.Groups.Add(lvlgroup)

                End With

                Application.DoEvents()
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub MOTHER_RS1(n As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FDRLIST.ComboBox2.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            'newCMD.Parameters.AddWithValue("@project", FDRLIST.txtSearch.Text)
            newCMD.Parameters.AddWithValue("@project", FDRLIST.cmbRequestor.Text)
            newCMD.Parameters.AddWithValue("@searchby1", cmbSortBy.Text)
            newCMD.Parameters.AddWithValue("@search", txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                With FDRLIST
                    If newDR.Item("countrow").ToString = 0 Then
                    Else
                        If newDR.Item("PROJECT").ToString = "" Then
                        Else
                            FDRLIST.ComboBox2.Items.Add(newDR.Item("PROJECT").ToString)
                        End If

                    End If

                End With

                Application.DoEvents()
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

        FDRLIST.SyncToOracle(FDRLIST.ProgressBar1)
    End Sub
    Private Sub SUB_RS(n As Integer)
        Dim a(4) As String
        With FDRLIST
            For Each row As ListViewGroup In .lvl_drList.Groups
                get_dr(row.Name, row, n)
                'MsgBox(row.Name)
            Next
        End With

    End Sub
    Private Function get_dr(project As String, lvlgroup As ListViewGroup, n As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@project", project)
            newCMD.Parameters.AddWithValue("@rs_no", txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@search", txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@item_desc", txtItems.Text)
            newCMD.Parameters.AddWithValue("@inout", cmbINOUT.Text)
            newCMD.Parameters.AddWithValue("@searchby1", cmbSortBy.Text)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))
            newCMD.CommandTimeout = 220

            newDR = newCMD.ExecuteReader

            Dim a(35) As String

            While newDR.Read
                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("SUPP_SOURCE").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("DRIVER").ToString
                a(10) = newDR.Item("PROJECT").ToString
                a(11) = newDR.Item("SUPPLIER").ToString 'a(7) source_wh
                a(12) = newDR.Item("checkedBy").ToString
                a(13) = newDR.Item("receivedby").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = newDR.Item("PO_WS_NO").ToString
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("username").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("RR_NO").ToString

                Dim sp() As String = newDR.Item("date_submitted").ToString.Split(" ")
                a(31) = sp(0)


                If newDR.Item("unit_price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                FDRLIST.lvl_drList.Items.Add(New ListViewItem(a, lvlgroup))

                Application.DoEvents()

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Sub get_dr1(n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@project", FDRLIST.cmbRequestor.Text)
            newCMD.Parameters.AddWithValue("@rs_no", "")
            newCMD.Parameters.AddWithValue("@search", txtItemDesc.Text)
            newCMD.Parameters.AddWithValue("@inout", cmbINOUT.Text)
            newCMD.Parameters.AddWithValue("@searchby1", cmbSortBy.Text)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))
            newCMD.CommandTimeout = 220

            newDR = newCMD.ExecuteReader

            Dim a(35) As String

            While newDR.Read
                a(0) = newDR.Item("dr_items_id").ToString
                a(1) = newDR.Item("dr_no").ToString
                a(2) = newDR.Item("rs_no").ToString
                If newDR.Item("dr_date").ToString = "" Then
                    a(3) = ""
                Else
                    a(3) = Format(Date.Parse(newDR.Item("dr_date").ToString), "MM/dd/yyyy")
                End If

                a(4) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_name").ToString)
                a(29) = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newDR.Item("item_desc").ToString)
                a(5) = newDR.Item("SUPP_SOURCE").ToString
                a(7) = newDR.Item("unit").ToString
                a(8) = newDR.Item("concession_ticket_no").ToString
                a(9) = newDR.Item("DRIVER").ToString
                a(10) = newDR.Item("PROJECT").ToString
                a(11) = newDR.Item("SUPPLIER").ToString 'a(7) source_wh
                a(12) = newDR.Item("checkedBy").ToString
                a(13) = newDR.Item("receivedby").ToString
                a(14) = newDR.Item("dr_info_id").ToString
                a(15) = newDR.Item("rs_id").ToString
                a(16) = newDR.Item("IN_OUT").ToString
                a(19) = newDR.Item("PO_WS_NO").ToString
                a(21) = newDR.Item("remarks").ToString 'a(11) remarks
                a(20) = newDR.Item("par_rr_item_id").ToString
                a(22) = newDR.Item("SUPPLIER").ToString
                a(23) = newDR.Item("username").ToString.ToUpper
                a(24) = newDR.Item("plate_no").ToString
                a(25) = newDR.Item("RR_NO").ToString

                If newDR.Item("unit_price").ToString = "" Then
                    a(27) = 0
                Else
                    a(27) = FormatNumber(CDbl(newDR.Item("unit_price").ToString), 2,,, TriState.True)
                End If

                a(30) = Format(Date.Parse(newDR.Item("date_request").ToString), "MM/dd/yyyy")

                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    a(6) = ""
                    a(26) = newDR.Item("qty").ToString
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(26)), 2,,, TriState.True)

                ElseIf newDR.Item("IN_OUT").ToString = "IN" Or newDR.Item("IN_OUT").ToString = "OTHERS" Then
                    a(6) = newDR.Item("qty").ToString
                    a(26) = ""
                    a(28) = FormatNumber(CDbl(a(27)) * CDbl(a(6)), 2,,, TriState.True)

                End If

                Dim lvl As New ListViewItem(a)
                FDRLIST.lvl_drList.Items.Add(lvl)

                Application.DoEvents()

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub waste_excemption()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        FWasteExcemption.lvlListOfAggregates.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            'newCMD.Parameters.AddWithValue("@n", 333)
            'newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            'newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))
            'newCMD.Parameters.AddWithValue("@Search", FDRLIST.txtSearch.Text)
            ''newCMD.Parameters.AddWithValue("@SearchItem", txtSearchItems.Text)
            'newCMD.Parameters.AddWithValue("@SearchItem", txtItemDesc.Text)

            'newCMD.Parameters.AddWithValue("@remarks", "")
            If FDRLIST.cmbSearchBy.Text = "Search by Project/Requestor" Then
                'Search by Project/Requestor
                'Search by Warehouse/Stockpile
                If cmbEnable_Disable.Text = "ENABLE" Then

                    newCMD.Parameters.AddWithValue("@n", 38)
                Else
                    newCMD.Parameters.AddWithValue("@n", 333)
                End If

            ElseIf FDRLIST.cmbSearchBy.Text = "Search by Warehouse/Stockpile" Then
                If cmbEnable_Disable.Text = "ENABLE" Then

                    newCMD.Parameters.AddWithValue("@n", 388)
                Else
                    newCMD.Parameters.AddWithValue("@n", 334)
                End If
            End If

            newCMD.Parameters.AddWithValue("@project", FDRLIST.txtSearch.Text)
            newCMD.Parameters.AddWithValue("@searchby1", cmbSortBy.Text)
            newCMD.Parameters.AddWithValue("@sortby", cmbSortBy.Text)
            newCMD.Parameters.AddWithValue("@SearchItem", "") 'item descrip.
            newCMD.Parameters.AddWithValue("@remarks", "") 'remarks
            newCMD.Parameters.AddWithValue("@inout", cmbINOUT.Text)
            newCMD.Parameters.AddWithValue("@division", cmbdivision.Text)
            newCMD.Parameters.AddWithValue("@datefrom", dtpfrom.Text)
            newCMD.Parameters.AddWithValue("@dateto", dtpto.Text)
            newCMD.Parameters.AddWithValue("@search2", txtItemDesc.Text) 'depend on what to search rs,item desc,consession etc.

            newDR = newCMD.ExecuteReader

            Dim a(10) As String

            While newDR.Read
                a(0) = newDR.Item("ITEM_DESC").ToString
                a(1) = newDR.Item("remarks").ToString

                Dim lvl As New ListViewItem(a)

                FWasteExcemption.lvlListOfAggregates.Items.Add(lvl)
            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub cmbSortBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSortBy.SelectedIndexChanged
        'If cmbSortBy.Text = "ITEM Name" Or cmbSortBy.Text = "ITEM DESC" Then
        '    'ITEM Name
        '    'ITEM DESC
        '    GroupBox1.Visible = True
        '    Me.Width = 258
        '    Me.Height = 210
        '    Label2.Text = cmbSortBy.Text & ":"
        'Else
        '    GroupBox1.Visible = False
        '    Me.Width = 258
        '    Me.Height = 133
        'End If

        If cmbSortBy.Text = "DR DATE" Then
            GroupBox2.Visible = True
            GroupBox1.Visible = False
            Me.Height = 196
        Else
            'GroupBox1.Visible = True
            'GroupBox2.Visible = False
        End If
    End Sub

    Private Sub txtItemDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub FSORTBY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbEnable_Disable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEnable_Disable.SelectedIndexChanged
        If cmbEnable_Disable.Text = "ENABLE" Then
            dtpfrom.Enabled = True
            dtpto.Enabled = True
        Else
            dtpfrom.Enabled = False
            dtpto.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class