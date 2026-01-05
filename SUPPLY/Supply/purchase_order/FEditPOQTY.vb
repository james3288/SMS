Public Class FEditPOQTY
    Dim textbox_pholder As New class_placeholder4
    Dim textbox_pholder2 As New class_placeholder4

    Private po As New CLASS_PO
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        po.units(textbox_pholder2, Label1)
        Label1.Visible = True
        textbox_pholder.king_placeholder_textbox("Qantity", txtPoQty, Nothing, Panel1, My.Resources.density, True)
        textbox_pholder2.king_placeholder_textbox("Unit", txtUnit, po.cListOfUnits, Panel1, My.Resources.username_icon)

        txtPoQty.Text = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).SubItems(7).Text
        txtUnit.Text = FPurchasedOrderList.lvlpurchasedOrderList.SelectedItems(0).SubItems(8).Text
        txtPoQty.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            'filter if textbox is blank 
            If textbox_pholder.blank_textbox = True Then
                Exit Sub
            ElseIf textbox_pholder2.blank_textbox = True Then
                Exit Sub
            End If

            Dim current_po_qty, po_qty_now As Double
            Dim current_unit, unit_now As String
            Dim po_det_id, rs_id As Integer

            With FPurchasedOrderList
                current_po_qty = CDbl(.lvlpurchasedOrderList.SelectedItems(0).SubItems(7).Text)
                po_qty_now = CDbl(txtPoQty.Text)
                unit_now = txtUnit.Text
                current_unit = .lvlpurchasedOrderList.SelectedItems(0).SubItems(8).Text
                po_det_id = .lvlpurchasedOrderList.SelectedItems(0).Text
                rs_id = .lvlpurchasedOrderList.SelectedItems(0).SubItems(20).Text
            End With

            'start update po qty and rs qty
            '1st check sa if naa nabay rr
            Dim trd As New Threading.Thread(AddressOf po.is_exist_in_rr)
            trd.Start(po_det_id)
            trd.Join()

            '2nd check sa if multiple po ba xa 
            Dim trd1 As New Threading.Thread(AddressOf po.is_multiple_po)
            trd1.Start(rs_id)
            trd1.Join()

            'CHECK IF PO WAS ALREADY RECEIVED
            If po.cListOfrrPo.Count > 0 Then
                MessageBox.Show("Unable to edit po qty, receiving # was already created.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'CHECK IF MULTIPLE PO
            For Each row In po.cListOfmultiplePo
                If row.rs_id = rs_id Then
                    If row.totalcount > 1 Then
                        MessageBox.Show("unable to edit po qty, this data had multiple po!", "SUPPY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit For
                        Exit Sub
                    End If
                End If
            Next

            'IF OK ANG TANAN SA TANAN SO PROCCEED NA DIRI DAPITA!
            Dim msg1 As String = "Warning: Your purchase order quantity exceeds the rs quantity.," & vbCrLf &
                                       "do you still want to proceed and update rs and po qty?"

            Dim msg2 As String = "Warning: Your purchase order quantity is lesser than rs qty," & vbCrLf &
                                       "do you still want to proceed and update rs and po qty?" & vbCrLf &
                                       "Yes - update rs and po qty" & vbCrLf &
                                       "No - update po qty only"

            Dim msg3 As String = "Do you want to update rs and po qty?" & vbCrLf &
                                       "Yes - update rs and po qty" & vbCrLf &
                                       "No - update po qty only"


            If MessageBox.Show("Are you sure you want to update po qty?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'CHECK RS QTY KUNG MAS DAKO PA ANG PO QTY
                If po.get_rs_qty(rs_id) < po_qty_now Then
                    If MessageBox.Show(msg1, "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'diri n function, iyang e update ang po qty
                        po.update_po_qty(po_det_id, po_qty_now, unit_now)

                        'diri na function, iyang e update ang rs qty
                        po.update_rs_qty(rs_id, po_qty_now, unit_now)
                    Else
                        Exit Sub
                    End If

                ElseIf po.get_rs_qty(rs_id) > po_qty_now Then
                    If MessageBox.Show(msg2, "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'diri n function, iyang e update ang po qty
                        po.update_po_qty(po_det_id, po_qty_now, unit_now)

                        'diri na function, iyang e update ang rs qty
                        po.update_rs_qty(rs_id, po_qty_now, unit_now)
                    Else
                        'diri n function, iyang e update ang po qty
                        po.update_po_qty(po_det_id, po_qty_now, unit_now)
                    End If

                Else
                    If MessageBox.Show(msg3, "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'diri n function, iyang e update ang po qty
                        po.update_po_qty(po_det_id, po_qty_now, unit_now)

                        'diri na function, iyang e update ang rs qty
                        po.update_rs_qty(rs_id, po_qty_now, unit_now)
                    Else
                        'diri n function, iyang e update ang po qty
                        po.update_po_qty(po_det_id, po_qty_now, unit_now)
                    End If
                End If
            End If

            Me.Close()

            With FPurchasedOrderList
                .btnSearch.PerformClick()
                listfocus(.lvlpurchasedOrderList, po_det_id)
            End With

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub update_rs_qty(rs_id As Integer)

    End Sub

End Class