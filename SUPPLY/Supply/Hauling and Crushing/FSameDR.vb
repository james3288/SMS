Imports SUPPLY.spire

Public Class FSameDR



    Public cDrToRemove As New List(Of PropsFields.dr_list_props_fields)
    Private customMsg As New customMessageBox
    Private customGrid As New CustomGridview
    Private cn As New PropsFields.dr_list_props_fields
    Private Sub FSameDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            customGrid.customDatagridview(DataGridView1)
            DataGridView1.DataSource = cDrToRemove

            customizeDataGridview(DataGridView1)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub customizeDataGridview(dgv As DataGridView)
        Try

            dgv.MultiSelect = True

            'hide columns
            For Each column As DataGridViewColumn In dgv.Columns
                If column.Name = NameOf(cn.dr_item_id) Or
                    column.Name = NameOf(cn.item_desc) Or
                    column.Name = NameOf(cn.dr_no) Or
                    column.Name = NameOf(cn.rs_no) Or
                    column.Name = NameOf(cn.inout) Then

                    column.Visible = True

                Else
                    column.Visible = False
                End If
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Selected Then
                    Dim data = cDrToRemove.FirstOrDefault(Function(x)
                                                              Return x.dr_item_id = row.Cells(NameOf(cn.dr_item_id)).Value
                                                          End Function)
                    Dim remove As New RemoveAggregates
                    remove.initialize(data)
                    remove.execute()
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Class RemoveAggregates

        Private _cCustomMsg As New customMessageBox
        Private _data As New PropsFields.dr_list_props_fields
        Public Sub initialize(data As PropsFields.dr_list_props_fields)

            _data = data

        End Sub

        Public Sub execute()
            Try
                Select Case _data.inout
                    Case cInOut._OTHERS
                        MsgBox(_data.dr_item_id)
                    Case cInOut._OUT
                        MsgBox(_data.dr_item_id)
                    Case cInOut._IN
                        MsgBox(_data.dr_item_id)
                End Select
            Catch ex As Exception
                _cCustomMsg.ErrorMessage(ex)
            End Try
        End Sub
    End Class
End Class

