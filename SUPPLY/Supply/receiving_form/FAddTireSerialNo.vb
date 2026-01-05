Public Class FAddTireSerialNo

    Private ADDTIRESERIALNOMODEL As New AddTireSerialNoModel
    Private serialNoUI As New class_placeholder5
    Public isAlreadySet As Boolean
    Public isEdit As Boolean
    Private customMsg As New customMessageBox
    Private cn As New AddTireSerialNoModel.TIRE

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property
    Public ReadOnly Property GET_ADDTIRESERIALNOMODEL() As AddTireSerialNoModel
        Get
            Return ADDTIRESERIALNOMODEL
        End Get
    End Property
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub FAddTireSerialNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        serialNoUI.king_placeholder_textbox("Serial No...",
                                            txtSerialNo,
                                            Nothing,
                                            Panel5,
                                            My.Resources.received,
                                            ,
                                            serialNoUI.cCustomColor.Custom1)


        ADDTIRESERIALNOMODEL.init_datagridview(DataGridView1)

        If isAlreadySet Then
            Dim data = FCreateReceiving.GET_CREATERECEIVINGMODEL().currentReceivingSerialNo(ADDTIRESERIALNOMODEL.cTIRE.po_det_id)
            ADDTIRESERIALNOMODEL.loadUpdatedTires(data)
        Else
            ADDTIRESERIALNOMODEL.loadTires()
        End If


        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel1)
        myPanel.addPanel(Panel4)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel5.Visible = False
    End Sub

    Private Sub SETSERIALNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SETSERIALNOToolStripMenuItem.Click
        Panel5.Visible = True
        txtSerialNo.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
#Region "FILTER"
            If serialNoUI.ifBlankTexbox() Then
                customMsg.message("error", "serial no. must not be empty!", "SMS INFO:")
                Exit Sub
            End If
#End Region

            Dim selectedRow = DataGridView1.SelectedRows(0)

            Dim tireStorage As New AddTireSerialNoModel.TIRE
            With tireStorage
                .tire_index = selectedRow.Cells(NameOf(tireStorage.tire_index)).Value
                .tire_serial_no = txtSerialNo.Text
            End With

            If isEdit Then
                ADDTIRESERIALNOMODEL.updateSerialNoEdit(tireStorage)
            Else
                ADDTIRESERIALNOMODEL.updateSerialNo(tireStorage)
            End If

            Panel5.Visible = False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
#Region "FILTER"
        Dim countEmptySerialNo As Integer
        For Each row As DataGridViewRow In DataGridView1.Rows
            If String.IsNullOrEmpty(row.Cells(NameOf(cn.tire_serial_no)).Value) Then
                countEmptySerialNo += 1
            End If
        Next

        If countEmptySerialNo > 0 Then
            customMsg.message("error", "you must fill all the serial no. to proceed transaction!", "SMS INFO:")
            Exit Sub
        End If
#End Region

        If isEdit Then
            displayUpdatedSerialToCreateReceivingDatagridView()
        Else
            displayToCreateReceivingDatagridView()
        End If

        Me.Dispose()
    End Sub

    Public Sub displayToCreateReceivingDatagridView()
        FCreateReceiving.GET_CREATERECEIVINGMODEL().addSerialNo(ADDTIRESERIALNOMODEL.cListOfTireWithoutSerial,
                                                            ADDTIRESERIALNOMODEL.cTIRE.po_det_id)

        Dim rrRows = FRequesitionFormForDR.getNewDrModel().RawRrRows

        FRequesitionFormForDR.
            getNewDrModel().
            refactorAndPreviewIncludingSerialNo(rrRows,
                                                FCreateReceiving.GET_CREATERECEIVINGMODEL().getListOfReceivingSerialNo,
                                                FCreateReceiving.DataGridView1)

    End Sub

    Public Sub displayUpdatedSerialToCreateReceivingDatagridView()
        FCreateReceiving.GET_CREATERECEIVINGMODEL().updateSerialNo(ADDTIRESERIALNOMODEL.cTIRE.po_det_id,
                                                           ADDTIRESERIALNOMODEL.get_clistOfTireWithSerial)

        Dim rrRows = FRequesitionFormForDR.getNewDrModel().RawRrRows

        FRequesitionFormForDR.
            getNewDrModel().
            refactorAndPreviewIncludingSerialNo(rrRows,
                                                FCreateReceiving.GET_CREATERECEIVINGMODEL().getListOfReceivingSerialNo,
                                                FCreateReceiving.DataGridView1)


    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class