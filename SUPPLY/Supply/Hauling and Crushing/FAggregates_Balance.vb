
Public Class FAggregates_Balance
    Private trd_loading As Threading.Thread
    Private trd_charges, trd_charges2, trd_done As Threading.Thread
    Private cListOfTrd As New List(Of Threading.Thread)
    Private counter As Integer

    Public rs As New class_aggregates_obj.rs_object
    Public cCountRequestor As Integer

    Private cTotalRsQty As Double
    Private cDone As Boolean = True
    Dim noofcharges As Integer
    Private cIncrement As Integer

    Private cListOfData As New List(Of ListViewItem)
    Private cListOfData2 As New List(Of ListViewItem)
    Private ListOfRs As New List(Of String)

    Structure nRs
        Dim rs_no As String
        Dim rs_qty As Double
    End Structure
    Private cListOfRs2 As New List(Of nRs)

    Private Delegate Sub del_addrow(bg_color As Color, ListItem As String(), fontcolor As Color)
    Private cListOfCharges As New List(Of String)
    Private cListOfCharges2 As New List(Of String)

    Private pl2 As New class_placeholder3
    Private Sub addrow(bg_color As Color, ListItem As String(), Optional fontcolor As Color = Nothing)

        If InvokeRequired Then
            Invoke(New del_addrow(AddressOf addrow), bg_color, ListItem, fontcolor)
            Exit Sub
        End If

        Dim lvl = New ListViewItem(ListItem)
        lvl.BackColor = bg_color
        lvl.ForeColor = fontcolor

        cListOfData.Add(lvl)

        'ListView1.Items.Add(lvl)
    End Sub


    Private Delegate Sub del_addrow2(bg_color As Color, ListItem As String(), fontcolor As Color)
    Private Sub addrow2(bg_color As Color, ListItem As String(), Optional fontcolor As Color = Nothing)

        If InvokeRequired Then
            Invoke(New del_addrow2(AddressOf addrow2), bg_color, ListItem, fontcolor)
            Exit Sub
        End If

        Dim lvl = New ListViewItem(ListItem)
        lvl.BackColor = bg_color
        lvl.ForeColor = fontcolor

        cListOfData2.Add(lvl)

        'ListView1.Items.Add(lvl)
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Select Case cmbSearchBy.Text
            Case "Search by Specific"

                If pl2.text_hint = txtSearch.Text Then
                    MessageBox.Show("unable to search if blank text...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'ListView1.Items.Clear()
                'ListView2.Items.Clear()
                'ListView3.Items.Clear()

                'searchbyspecific(txtSearch.Text)

                ListView1.Items.Clear()
                ListView2.Items.Clear()
                ListView3.Items.Clear()
                panelStatus.Controls.Clear()

                'Dim prgsbar As New ProgressBar
                'prgsbar.Style = ProgressBarStyle.Marquee
                'prgsbar.MarqueeAnimationSpeed = 100
                'prgsbar.Dock = DockStyle.Fill
                'prgsbar.BackColor = Color.LightYellow

                'panelStatus.Controls.Add(prgsbar)


                cListOfCharges2.Add(txtSearch.Text)
                Timer1.Start()


            Case "Search by All"
                FRequestorList.Show()
        End Select

    End Sub

    Private Sub ifDone()
        While cDone = False

        End While

        MsgBox("yes done..")
        cDone = False
    End Sub

    Private Sub searchbyspecific(search As String)

        ListOfRs.Clear()
        cListOfRs2.Clear()

        cListOfData.Clear()
        cListOfData2.Clear()

        cDone = False

        trd_loading = New Threading.Thread(AddressOf loading)
        trd_loading.Start()

        trd_charges = New Threading.Thread(AddressOf aggregates_balances)
        trd_charges.Start(search)
        cCountRequestor = 1

        'trd_done = New Threading.Thread(AddressOf ifDone)
        'trd_done.Start()
    End Sub


    Private Sub aggregates_balances(requestor As String)
        Dim charges As New class_aggregates_obj.charges_object
        Dim trd, trd2, trd3, trd4 As Threading.Thread

        Dim main_rs As New class_aggregates_obj.main_rs_object


        trd3 = New Threading.Thread(AddressOf main_rs._initialize)
        trd3.Start(requestor)
        trd3.Join()

        trd2 = New Threading.Thread(AddressOf charges._initialize)
        trd2.Start(requestor)
        trd2.Join()

        trd = New Threading.Thread(AddressOf checkIfDone)
        trd.Start(charges)
        trd.Join()

        trd4 = New Threading.Thread(AddressOf checkIfDone2)
        trd4.Start(main_rs)
        trd4.Join()




    End Sub

    Private Sub display(rs As class_aggregates_obj.rs_object)

        Dim myRsNo As String = ""
        Try
            Dim cAggregates As New class_aggregates_obj._AGGREGATES_
            cAggregates._initialize(rs)

            Dim ls = cAggregates.cListOfAggregates
            Dim lvl As New ListViewItem

            For Each row In ls
                If row.sorting = "A" Then
                    myRsNo = row.rs_no
                    Dim a As String() = New String() {row.rs_no, row.qty, row.sorting, "-", "-", row.items, row.requestor, row.rs_date}
                    addrow(Color.DarkGreen, a, Color.White)
                    ListOfRs.Add(row.rs_no)

                    Dim newnRs As New nRs
                    With newnRs
                        .rs_no = row.rs_no
                        .rs_qty = row.qty
                    End With
                    cListOfRs2.Add(newnRs)

                ElseIf row.sorting = "B" Then
                    Select Case row.inout
                        Case "OUT", "OTHERS", "IN"
                            Dim a As String() = New String() {row.ws_no, row.qty, row.sorting, "-", "-", row.items, "-", row.rs_date}
                            addrow(Color.LightGreen, a)

                    End Select

                ElseIf row.sorting = "C" Then
                    Dim a As String() = New String() {row.rr_no, row.qty, row.sorting, "-", "-", row.items, "-", row.rs_date}
                    addrow(Color.Pink, a)

                ElseIf row.sorting = "D" Then
                    Dim a As String() = New String() {row.dr_no, row.qty, row.sorting, row.inout, "-", row.items, "-", row.rs_date}
                    addrow(Color.LightYellow, a)

                ElseIf row.sorting = "E" Then
                    Dim a As String() = New String() {myRsNo, "-", row.inout, "DR Balance", row.total}
                    addrow(Color.Yellow, a)

                ElseIf row.sorting = "F" Then
                    Dim a As String() = New String() {myRsNo, "-", row.inout, "PO Balance", row.total}
                    addrow(Color.Purple, a, Color.White)

                ElseIf row.sorting = "G" Then
                    Dim a As String() = New String() {myRsNo, "-", row.inout, "RS Balance", row.remaining}
                    addrow(Color.White, a)

                ElseIf row.sorting = "H" Then
                    Dim a As String() = New String() {myRsNo, "-", row.inout, "RS Balance", row.remaining}
                    addrow(Color.White, a)

                ElseIf row.sorting = "EE" Then
                    Dim a As String() = New String() {myRsNo, "-", row.inout, "RS Balance", row.remaining}
                    addrow(Color.White, a)
                End If

            Next


            Dim ListRemBalance = cAggregates.cListOfRemainingBalance

            For Each row In ListRemBalance
                Dim a(10) As String
                a(0) = row.rs_no
                a(1) = row.rs_qty
                a(2) = row.ws_po_qty
                a(3) = row.rr_qty
                a(4) = row.dr_qty
                a(5) = row.balance
                a(6) = row.inout
                a(7) = row.type_of_purchasing
                a(8) = row.items
                a(9) = row.requestor

                addrow2(Color.White, a)
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & myRsNo & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub checkIfDone(charges As class_aggregates_obj.charges_object)
        While charges.done = False

        End While

        'MsgBox("done...")

        Dim listAggCharges = charges.cListOfCharges

        Dim listOfRsAgg As New List(Of class_aggregates_obj.rs_object)
        Dim listoftrdcharges As New List(Of Threading.Thread)

        For Each row In listAggCharges
            Dim dict As New Dictionary(Of String, Object)
            dict.Add("rs_id", row.rs_id)
            dict.Add("inout", row.inout)
            dict.Add("type_of_purchasing", row.TypeOfPurchasing)
            dict.Add("charges", row.charges)

            rs = New class_aggregates_obj.rs_object

            Dim trdcharges As Threading.Thread
            trdcharges = New Threading.Thread(AddressOf rs._initialize)
            trdcharges.Start(dict)

            listoftrdcharges.Add(trdcharges)
            'rs._initialize(dict)
            listOfRsAgg.Add(rs)
        Next

        For Each t In listoftrdcharges
            t.Join()
        Next

        project_to_listview(listOfRsAgg)
    End Sub

    Private Sub checkIfDone2(mainRsQty As class_aggregates_obj.main_rs_object)
        While mainRsQty.done = False

        End While

        Dim listofmainrsqty = mainRsQty.cListOfMainQty
        Dim lvl As New ListViewItem
        Dim cListofmainrsqty As New List(Of ListViewItem)

        For Each row In listofmainrsqty
            If row.main_qty > 0 Then
                get_total_rs_qty(row.rs_no)
                Dim a As String() = New String() {row.rs_no, row.main_qty, cTotalRsQty, CDbl(CDbl(row.main_qty) - CDbl(cTotalRsQty)), row.charges}
                lvl = New ListViewItem(a)
                cListofmainrsqty.Add(lvl)
                cTotalRsQty = 0
            End If
        Next

        If ListView3.InvokeRequired Then
            ListView3.Invoke(Sub()

                                 ListView3.Items.AddRange(cListofmainrsqty.ToArray)
                                 cDone = True
                             End Sub)
        End If
    End Sub
    Private Delegate Sub del_get_total_rs_qty(rs_no As String)
    Private Sub get_total_rs_qty(rs_no As String)
        If InvokeRequired Then
            Invoke(New del_get_total_rs_qty(AddressOf get_total_rs_qty), rs_no)
            Exit Sub
        End If

        For Each row As ListViewItem In ListView1.Items
            If row.Text = rs_no And row.BackColor = Color.DarkGreen Then
                cTotalRsQty += row.SubItems(1).Text
            End If
        Next


    End Sub

    Private Sub project_to_listview(listOfRsAgg As List(Of class_aggregates_obj.rs_object))

        For Each row In listOfRsAgg
            display(row)
        Next

        If ListView1.InvokeRequired Then
            ListView1.Invoke(Sub()
                                 ListView1.Items.AddRange(cListOfData.ToArray)
                                 ListView2.Items.AddRange(cListOfData2.ToArray)

                                 cListOfData.Clear()
                                 cListOfData2.Clear()

                                 counter += 1
                             End Sub)
        Else
            ListView1.Items.AddRange(cListOfData.ToArray)
            ListView2.Items.AddRange(cListOfData2.ToArray)

            cListOfData.Clear()
            cListOfData2.Clear()

            counter += 1
        End If

        If counter = cCountRequestor Then
            Try
                trd_loading.Abort()

                counter = 0
                cCountRequestor = 0
            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub loading()
        Dim floading As New Floading

        If floading.InvokeRequired Then
            floading.Invoke(Sub()
                                floading.ShowDialog()
                            End Sub)
        Else
            floading.ShowDialog()
        End If
    End Sub


    Structure _data
        Dim rs_no As String
        Dim type As String
        Dim result As String

    End Structure
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'Dim lvl As New ListViewItem


        'For Each row As ListViewItem In ListView1.Items
        '    If row.BackColor = Color.Yellow Then
        '        If row.SubItems(4).Text <> 0 Then
        '            Dim a As String() = New String() {row.Text, row.SubItems(3).Text, row.SubItems(4).Text}
        '            lvl = New ListViewItem(a)
        '            lvl.BackColor = Color.Yellow

        '            ListView2.Items.Add(lvl)
        '        End If

        '    ElseIf row.BackColor = Color.White Then
        '        If row.SubItems(4).Text <> 0 Then
        '            Dim a As String() = New String() {row.Text, row.SubItems(3).Text, row.SubItems(4).Text}
        '            lvl = New ListViewItem(a)

        '            ListView2.Items.Add(lvl)
        '        End If

        '    End If
        'Next


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FAggregates_Balance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cListOfCharges.Clear()

        Dim project As New class_requestor
        project._initialize("PROJECT")

        pl2.TextBox = txtSearch
        pl2.text_hint = "Requestor/Project"
        pl2.icon = My.Resources.search
        pl2.panel = Panel1
        pl2.mark = Me.Name
        pl2.AutoComplete = project.cListOfRequestor
        txtSearch.Text = pl2.text_hint
        pl2.Execute()

        '*********FOR COMBOBOX***********
        With clistofCombobox
            .Add(cmbSearchBy, "Select Search By")
        End With


        For Each row In clistofCombobox
            Dim pholder As New class_combobox_placeholder(row.Key, Color.White, Color.Gray, 11, "Century Gothic")
            pholder.leave(Color.White)

            AddHandler row.Key.Leave, AddressOf pholder.txt_leave
            AddHandler row.Key.GotFocus, AddressOf pholder.txt_Got_Focus
        Next
        '*********for combobox************


    End Sub


    Private Sub placeholder()
        'initialize placeholder in a specific textbox
        With cListofTextbox
            .Add(txtSearch, "Full Name")
        End With

        ''this code supress the alphabetical
        'Dim suppress As New Suppress
        'AddHandler TextBox3.KeyDown, AddressOf suppress.txt_suppress

        'this code costumize bgcolor when leave,gotfocus and add placeholder
        For Each row In cListofTextbox

            Dim pholder As New class_placeholder(row.Key, Color.White, Color.Gray, 10, "Century Gothic")
            'pholder.leave(Color.White)

            AddHandler row.Key.LostFocus, AddressOf pholder.txt_leave
            AddHandler row.Key.GotFocus, AddressOf pholder.txt_Got_Focus

        Next

        '*********FOR COMBOBOX***********
        'With clistofCombobox
        '    .Add(ComboBox1, "Equipment Type")
        'End With


        'For Each row In clistofCombobox
        '    Dim pholder As New class_combobx_placeholder(row.Key, Color.White, Color.Gray, 10, "Century Gothic")
        '    pholder.leave(Color.White)

        '    AddHandler row.Key.Leave, AddressOf pholder.txt_leave
        '    AddHandler row.Key.GotFocus, AddressOf pholder.txt_Got_Focus
        'Next
        '*********for combobox************


        '********* for textbox label ************

        Dim myLabel As New KJ_Label

        Dim listlabel_dec As New Dictionary(Of TextBox, System.Drawing.Bitmap)
        With listlabel_dec
            .Add(txtSearch, My.Resources.Access_icon)
        End With

        myLabel._initialize_textbox(listlabel_dec)

        Dim listoflabel = myLabel.cLisOfLabel
        '********* for textbox label *****************

        ''******** for combobox label *****************
        'Dim listlabel2_dic As New Dictionary(Of ComboBox, System.Drawing.Bitmap)

        'With listlabel2_dic
        '    .Add(ComboBox1, My.Resources.Access_icon)
        'End With

        'myLabel._initialize_combobox(listlabel2_dic)

        'Dim listlabel2 = myLabel.cLisOfLabel

        ''******** for combobox label ***************

        For Each lbl As Label In listoflabel
            Panel1.Controls.Add(lbl)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        Select Case cmbSearchBy.Text

            Case "Search by Specific"
                txtSearch.Enabled = True
                For Each ctr As Control In Panel1.Controls
                    If TypeOf (ctr) Is Label Then
                        If ctr.Name = "label_txtSearch" Then
                            ctr.Enabled = True
                        End If
                    End If
                Next
            Case "Search by All"
                txtSearch.Text = ""
                txtSearch.Enabled = False
                For Each ctr As Control In Panel1.Controls
                    If TypeOf (ctr) Is Label Then
                        If ctr.Name = "label_txtSearch" Then
                            ctr.Enabled = False
                        End If
                    End If
                Next
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LocateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocateToolStripMenuItem.Click
        Dim balance As String = ListView2.SelectedItems(0).SubItems(5).Text
        Dim rs_no As String = ListView2.SelectedItems(0).Text

        For Each row As ListViewItem In ListView1.Items
            If row.Text = rs_no And row.SubItems(4).Text = balance Then
                row.Selected = True
                row.EnsureVisible()
                Exit For
            End If
        Next
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If cListOfCharges2.Count = noofcharges Then
            Timer1.Stop()
            noofcharges = 0
            cListOfCharges2.Clear()
            panelStatus.Controls.Clear()

            status()
        Else
            searchbyspecific(cListOfCharges2.Item(noofcharges))
            noofcharges += 1
            Timer1.Stop()
            Timer2.Start()

        End If


    End Sub

    Private Sub status()
        Dim lblstatus As New Label
        lblstatus.Text = "Successfully Done..."
        lblstatus.Font = New Font("Century Gothic", 12, FontStyle.Bold)
        lblstatus.ForeColor = Color.Orange
        lblstatus.BackColor = Color.Transparent

        lblstatus.Dock = DockStyle.Fill
        lblstatus.TextAlign = ContentAlignment.MiddleCenter

        panelStatus.Controls.Add(lblstatus)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If cDone = True Then
            Timer1.Start()
            Timer2.Stop()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Me.Dispose()

    End Sub

    Public Sub GENERATE_BY_ALL()

        'ListView1.Items.Clear()
        'ListView2.Items.Clear()

        'ListOfRs.Clear()

        'cListOfData.Clear()
        'cListOfData2.Clear()

        'trd_loading = New Threading.Thread(AddressOf loading)
        'trd_loading.Start()

        'Dim listofcharges As New List(Of Threading.Thread)

        'For Each row As ListViewItem In FRequestorList.lvlProject.Items

        '    If row.Checked = True Then
        '        trd_charges = New Threading.Thread(AddressOf aggregates_balances)
        '        trd_charges.Start(row.Text)
        '        'listofcharges.Add(trd_charges)
        '        'trd_charges.Join()
        '    End If
        'Next

        ''For Each t In listofcharges
        ''    t.Join()
        ''Next


        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView3.Items.Clear()
        panelStatus.Controls.Clear()

        Dim prgsbar As New ProgressBar
        prgsbar.Style = ProgressBarStyle.Marquee
        prgsbar.MarqueeAnimationSpeed = 100
        prgsbar.Dock = DockStyle.Fill
        panelStatus.Controls.Add(prgsbar)

        For Each row As ListViewItem In FRequestorList.lvlProject.Items

            If row.Checked = True Then
                cListOfCharges2.Add(row.Text)
            End If
        Next

        FRequestorList.Dispose()
        Timer1.Start()

    End Sub

    Private Sub multiple_charges()

        cDone = False

        trd_loading = New Threading.Thread(AddressOf loading)
        trd_loading.Start()

        trd_charges = New Threading.Thread(AddressOf aggregates_balances)
        trd_charges.Start(txtSearch.Text)
        cCountRequestor = 1

        trd_done = New Threading.Thread(AddressOf ifDone)
        trd_done.Start()
    End Sub
End Class