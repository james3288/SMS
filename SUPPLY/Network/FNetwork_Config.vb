Public Class FNetwork_Config
    Dim IsFormBeingDragged As Boolean
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer
    Public SQLcon As New SQLcon

    Dim SQ As New SQLcon

    Dim fso As New FileIO.FileSystem
    Dim iniFile As String

    'for eu
    Dim fso1 As New FileIO.FileSystem
    Dim iniFile1 As String

    ' this is code is for dropshadow on form
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get

    End Property
    Private Sub PanelBSForm_btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBSForm_btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub pboxSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxSave.Click, Label6.Click
        If cmbsource.Text = "SUPPLY" Then
            Dim thisfile As String = Application.StartupPath & "\syscon.ini"

            If FileIO.FileSystem.FileExists(thisfile) Then ' if exist
                MessageBox.Show("This source already configured...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                save(1)
            End If

        ElseIf cmbsource.Text = "EUS" Then
            Dim thisfile As String = Application.StartupPath & "\syscon1.ini"

            If FileIO.FileSystem.FileExists(thisfile) Then ' if exist
                MessageBox.Show("This source already configured...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                save(2)
            End If
        End If
    End Sub
    Public Sub save(ByVal n As Integer)
        Dim Settings As String
        Dim settings1 As String

        Try

            If n = 1 Then
                iniFile = Application.StartupPath & "\syscon.ini"

                Settings = txtServer.Text & ";" & txtDatabaseName.Text & ";" & txtUsername.Text & ";" & txtPassword.Text

                FileIO.FileSystem.WriteAllText(iniFile, Settings, True)

            ElseIf n = 2 Then
                iniFile1 = Application.StartupPath & "\syscon1.ini"
                settings1 = txtServer.Text & ";" & txtDatabaseName.Text & ";" & txtUsername.Text & ";" & txtPassword.Text

                FileIO.FileSystem.WriteAllText(iniFile1, settings1, True)

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & ex.Message & vbCrLf & vbCrLf, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        End
    End Sub
    Private Sub FNetwork_Config_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label6.BringToFront()
        Label6.Parent = pboxSave
        Label6.Location = New Point(45, 8)

        iniFile = Application.StartupPath & "\syscon.ini"

        If FileIO.FileSystem.FileExists(iniFile) Then

        Else

        End If
    End Sub

    Private Sub txtServer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServer.GotFocus, txtServer.GotFocus, txtDatabaseName.GotFocus, _
   txtPassword.GotFocus, txtUsername.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtDatabaseName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServer.Leave, txtDatabaseName.Leave, _
    txtPassword.Leave, txtUsername.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub cmbsource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsource.SelectedIndexChanged
        txtServer.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtDatabaseName.Clear()

    End Sub
End Class