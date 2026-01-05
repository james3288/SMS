Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a(10) As String
        ListView1.Items.Clear()

        For i = 0 To 30
            a(0) = "id"
            a(1) = "file name"
            a(2) = "file description"
            a(3) = "qty"

            Dim lvl As New ListViewItem(a)
            ListView1.Items.Add(lvl)
        Next
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub
End Class