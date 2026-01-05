Public Class FRequestorList
    Private Sub FRequestorList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim project As New class_requestor
        project._initialize("PROJECT")

        Dim lr = project.cListOfRequestor

        For Each row In lr
            Dim a As String() = New String() {row.requestor_desc}
            lvlProject.Items.Add(New ListViewItem(a))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For Each row As ListViewItem In lvlProject.Items
            If row.Checked = True Then
                FAggregates_Balance.cCountRequestor += 1
            End If
        Next

        With FAggregates_Balance
            .GENERATE_BY_ALL()
        End With
    End Sub
End Class