Imports System.ComponentModel

Module BackgroundWorkerChecker
    Public Function BgWorkersCheckerFn(Optional fn As subDelegates = Nothing, Optional paramBgWorker As List(Of BackgroundWorker) = Nothing) As Timer
        BgWorkersCheckerFn = New Timer
        BgWorkersCheckerFn.Start()

        AddHandler BgWorkersCheckerFn.Tick, Sub(sender, e)

                                                If paramBgWorker.Count > 0 Then
                                                    Dim counter As Integer = 0

                                                    For Each row As BackgroundWorker In paramBgWorker
                                                        If row.IsBusy = True Then
                                                            counter += 1
                                                        End If
                                                    Next

                                                    If counter = 0 Then
                                                        If Not fn Is Nothing Then
                                                            BgWorkersCheckerFn.Stop()
                                                            fn()
                                                        End If
                                                    End If
                                                End If
                                            End Sub

        Return BgWorkersCheckerFn
    End Function
End Module
