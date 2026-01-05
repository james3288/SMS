Public Class FEditUserAccess
    Dim userAccess As New Model._Mod_User_Access
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            SaveUserAccess()
        Else
            If MessageBox.Show("Are you sure you want to update this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                UpdateUserAccess()
            End If

        End If


    End Sub
    Private Sub SaveUserAccess()
        'first get sa ang list of user access tanan

        userAccess.clear_parameter()
        userAccess.parameter("@n", 1)
        Dim userAccessData = userAccess.LISTOFUSERACCESS()


        'initialize dynamic model function
        Dim _insert_update_ As New Model_King_Dynamic_Update

        'get user access no using count 
        Dim access_no As Integer = userAccessData.Count + 1
        'get description
        Dim access_desc As String = txtUserAccessDesc.Text

        'initialize columns to insert into dynamic functions
        Dim columnValues As New Dictionary(Of String, Object)()
        columnValues.Add("access_desc", access_desc)
        columnValues.Add("access_no", access_no)

        _insert_update_.InsertData("dbaccess_desc", columnValues)
        txtUserAccessDesc.Clear()

        MessageBox.Show("Successfully Inserted!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadUserAccess()
        Me.Close()
    End Sub

    Private Sub UpdateUserAccess()

        'initialize dynamic model function
        Dim _insert_update_ As New Model_King_Dynamic_Update

        'get user access_desc_id from FRegistrationForm listview
        Dim access_no As Integer = FRegistrationForm.lvlAccess.SelectedItems(0).Text

        'get description
        Dim access_desc As String = txtUserAccessDesc.Text

        'initialize columns to update into dynamic functions
        Dim columnValues As New Dictionary(Of String, Object)()
        columnValues.Add("access_desc", access_desc)

        _insert_update_.UpdateData("dbaccess_desc", columnValues, $"access_no='{access_no}'")


        MessageBox.Show("Successfully Updated!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadUserAccess(access_no)
        Me.Close()
    End Sub
    Public Sub LoadUserAccess(Optional access_no As String = "")
        FRegistrationForm.lvlAccess.Items.Clear()

        userAccess.clear_parameter()
        userAccess.parameter("@n", 1)
        Dim userAccessData = userAccess.LISTOFUSERACCESS()
        Dim a(5) As String

        For Each row In userAccessData
            a(0) = row.access_no
            a(1) = row.access_desc

            Dim lvl As New ListViewItem(a)
            FRegistrationForm.lvlAccess.Items.Add(lvl)

        Next

    End Sub


End Class