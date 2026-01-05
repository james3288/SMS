Public Class MovablePanel
    Dim drag As Boolean
    Dim MouseDownX As Integer
    Dim MouseDownY As Integer

    Private dragging As Boolean = False
    Private dragOffset As Point
    Private cPanel As New Panel
    Private cForm As New Form
    Private IsFormBeingDragged As Boolean

    Private customMsg As New customMessageBox
    Private cListOfPanel As New List(Of Panel)

    Public Sub addPanel(panel As Panel)
        cListOfPanel.Add(panel)
    End Sub

    Public Sub initializeForm(form As Form)
        cForm = form
    End Sub

    Public Sub addPanelEventHandler()
        If cListOfPanel.Count > 0 Then
            For Each panel In cListOfPanel
                AddHandler panel.MouseDown, AddressOf panel_mouseDown
                AddHandler panel.MouseMove, AddressOf panel_mouseMove
                AddHandler panel.MouseUp, AddressOf panel_mouseUp
            Next
        End If

    End Sub

    Private Sub panel_mouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub panel_mouseMove(sender As Object, e As MouseEventArgs)
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = cForm.Location.X + (e.X - MouseDownX)
            temp.Y = cForm.Location.Y + (e.Y - MouseDownY)
            cForm.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub panel_mouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub


End Class
