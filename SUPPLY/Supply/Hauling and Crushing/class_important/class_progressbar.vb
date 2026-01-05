Public Class class_progressbar
    Private Property cProgressbar As New ProgressBar
    Public trd As Threading.Thread
    Public Sub _initialize(cbar As ProgressBar)
        cProgressbar = cbar

        trd = New Threading.Thread(AddressOf progressbar)
        trd.Name = "tr_progressbar"
        trd.Start()

    End Sub

    Private Delegate Sub delegate_progressbar()
    Private Sub progressbar()

        If cProgressbar.InvokeRequired Then
            cProgressbar.Invoke(Sub()
                                    cProgressbar.Style = ProgressBarStyle.Marquee
                                    cProgressbar.Visible = True
                                End Sub)
        Else
            cProgressbar.Style = ProgressBarStyle.Marquee
            cProgressbar.Visible = True
        End If

    End Sub
End Class
