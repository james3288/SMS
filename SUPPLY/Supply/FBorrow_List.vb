Public Class FBorrow_List
    Dim n As Integer
    Dim rowind As Integer
    Dim old_price_value As Double


    Private Sub dgBorrowList_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgBorrowList.CellBeginEdit
        n = CInt(dgBorrowList.Rows(Format(get_datagrid_rowindex)).Cells(0).Value)
        rowind = Format(get_datagrid_rowindex)

        old_price_value = dgBorrowList.Rows(Format(rowind)).Cells(5).Value
    End Sub

    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.dgBorrowList.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.dgBorrowList.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Private Sub dgBorrowList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBorrowList.CellEndEdit

        If Not IsNumeric(dgBorrowList.Rows(Format(rowind)).Cells(5).Value()) Then

            MessageBox.Show("Entry must numeric..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgBorrowList.Rows(Format(rowind)).Cells(5).Selected = True
            dgBorrowList.Rows(Format(rowind)).Cells(5).Value = old_price_value
        Else
            If dgBorrowList.Rows(Format(rowind)).Cells(5).Value > dgBorrowList.Rows(Format(rowind)).Cells(4).Value Then
                MessageBox.Show("Entry must not greater than actual qty..", "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dgBorrowList.Rows(Format(rowind)).Cells(5).Selected = True
                dgBorrowList.Rows(Format(rowind)).Cells(5).Value = old_price_value
            End If

        End If

    End Sub

    Private Sub FBorrow_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgBorrowList.AllowUserToAddRows = False

        For i = 0 To dgBorrowList.Rows.Count - 1

            dgBorrowList.Rows(i).Cells(0).ReadOnly = False
            dgBorrowList.Rows(i).Cells(1).ReadOnly = True
            dgBorrowList.Rows(i).Cells(2).ReadOnly = True
            dgBorrowList.Rows(i).Cells(3).ReadOnly = True
            dgBorrowList.Rows(i).Cells(4).ReadOnly = True
            dgBorrowList.Rows(i).Cells(5).ReadOnly = False

        Next
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        FBorrowerSlip.lvlFacTools.Items.Clear()
        FBorrowerSlip.lvlFacTools.Enabled = True

        Dim a(10) As String
        Dim popup As String = "ALREADY BORROWED: " & vbCrLf & vbCrLf
        For i = 0 To dgBorrowList.Rows.Count - 1


            With dgBorrowList
                If .Rows(i).Cells(0).Style.BackColor = Color.Violet Then
                    popup &= "> " & .Rows(i).Cells(2).Value & ": " & .Rows(i).Cells(3).Value & vbCrLf
                Else
                    If .Rows(i).Cells(5).Value <> 0 Then
                        a(0) = .Rows(i).Cells(1).Value
                        a(1) = .Rows(i).Cells(5).Value
                        a(2) = .Rows(i).Cells(3).Value
                        a(3) = .Rows(i).Cells(6).Value

                        Dim list As New ListViewItem(a)
                        FBorrowerSlip.lvlFacTools.Items.Add(list)

                    End If
                End If

            End With
        Next

        MessageBox.Show(popup, "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Warning)


        FBorrowerSlip.Show()
        Me.Close()


    End Sub
End Class