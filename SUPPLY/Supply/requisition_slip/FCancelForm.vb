Public Class FCancelForm
    Private UIremarks As New class_placeholder4
    Private customMsg As New customMessageBox
    Public cIsCancelled As Boolean = False

#Region "MOVABLE VARIABLES"
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
#End Region


#Region "DROP SHADOW EFFECT"
    ' this is code is for dropshadow on form
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get

    End Property
#End Region

#Region "MOVABLE FORM FUNCTIONS"
    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove

        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub panelHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub
#End Region

    Private Sub FCancelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = ColorTranslator.FromHtml("#16325B")

        Panel2.BackColor = ColorTranslator.FromHtml("#227B94")
        btnUpdate.BackColor = ColorTranslator.FromHtml("#16325B")

        UIremarks.king_placeholder_textbox("Remarks/Reason to cancel....", TextBox1, Nothing, Panel2, My.Resources.Access_icon, False, "White", "remarks")


        If cIsCancelled = True Then
            Dim remarks As String = FRequistionForm.getCancelledRemarks(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
            TextBox1.Text = remarks
        End If

        UIremarks.tbox.Focus()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If UIremarks.blank_textbox() Then
            Exit Sub
        End If


        If customMsg.messageYesNo("Are you sure you want to cancel this rs?", "SUPPLY INFO:") Then


            Dim insertCancelRs As New Model_King_Dynamic_Update
            With FRequistionForm
                Dim rs_id As Integer = .lvlrequisitionlist.SelectedItems(0).Text

                Dim columnValues As New Dictionary(Of String, Object)()
                columnValues.Add("trans", "RS")
                columnValues.Add("trans_id", rs_id)
                columnValues.Add("remarks", TextBox1.Text)


                If FRequistionForm.isCancelled(rs_id) Then
                    insertCancelRs.UpdateData("dbCancelledTransaction", columnValues, $"trans_id = {rs_id}")
                Else
                    insertCancelRs.InsertData("dbCancelledTransaction", columnValues)

                End If

                customMsg.message("info", "Successfully cancelled...", "SUPPLY INFO:")
                Me.Dispose()

                .btnSearch.PerformClick()
            End With
        End If
    End Sub
End Class