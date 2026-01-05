Imports SUPPLY.PropsFields

Public Class FColumnSettings
    Private customMsg As New customMessageBox
    Private cn As New PropsFields.columnSettings
    Public isFromRsForm As Boolean
    Public isFromRrForm As Boolean
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub FColumnSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'with
            DataGridView1.Columns(0).Width = 40
            DataGridView1.Columns(NameOf(cn.displayIndex)).Width = 40

            'readonly
            DataGridView1.Columns(NameOf(cn.headerText)).ReadOnly = True
            DataGridView1.Columns(NameOf(cn.headerName)).ReadOnly = True

            'restore the existing column settings
            Dim dgv = DataGridView1
            Dim listOfColumnName As New List(Of String)

            If isFromRsForm Then
                listOfColumnName = FRequesitionFormForDR.getNewDrModel().cRsColumnSettings.getListofColumnName()
            ElseIf isFromRrForm Then
                listOfColumnName = FReceivingReportListNew.getNEWRRMODEL().cRsColumnSettings.getListofColumnName()
            End If

            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim headerName As String = row.Cells(NameOf(cn.headerName)).Value
                Dim isInclude As Boolean = headerName = listOfColumnName.FirstOrDefault(Function(x) x.ToUpper() = headerName.ToUpper())

                If isInclude Then
                    row.Cells(0).Value = True
                End If
            Next

            'hide columns
            For Each column As DataGridViewColumn In dgv.Columns
                If column.Name = NameOf(cn.headerName) Then
                    column.Visible = False
                Else
                    column.Visible = True
                End If
            Next

            'movable panel
            Dim myPanel As New MovablePanel

            myPanel.addPanel(Panel2)
            myPanel.addPanel(Panel4)

            myPanel.initializeForm(Me)
            myPanel.addPanelEventHandler()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnCreateReceiving_Click(sender As Object, e As EventArgs) Handles btnCreateReceiving.Click
        If isFromRsForm Then
            Dim rscolumnSettings = FRequesitionFormForDR.getNewDrModel().cRsColumnSettings
            rscolumnSettings.setDatagridview(FRequesitionFormForDR.DataGridView1)
            rscolumnSettings.clear()

            showHideColumn(rscolumnSettings, DataGridView1)

        ElseIf isFromRrForm Then
            Dim rscolumnSettings = FReceivingReportListNew.getNEWRRMODEL().cRsColumnSettings
            rscolumnSettings.setDatagridview(FReceivingReportListNew.DataGridView1)
            rscolumnSettings.clear()

            showHideColumn(rscolumnSettings, DataGridView1)
        End If

    End Sub

    Private Sub showHideColumn(rscolumnSettings As ColumnSettingsLib, dgv As DataGridView)
        Try
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells(0).Value = False Then
                    rscolumnSettings.hideColumn(row.Cells(NameOf(cn.headerName)).Value)
                Else
                    rscolumnSettings.ShowColumn(row.Cells(NameOf(cn.headerName)).Value)
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Cells(0).Value = True
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Cells(0).Value = False
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class