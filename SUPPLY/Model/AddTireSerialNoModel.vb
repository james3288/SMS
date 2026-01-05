Public Class AddTireSerialNoModel

    Public cTIRE As New TIRE
    Public cDgv As DataGridView
    Public cListOfTireWithoutSerial As New List(Of TIRE)
    Public cListOfTireWithSerial As New List(Of TIRE)
    Private customDatagrid As New CustomGridview
    Private customMsg As New customMessageBox
    Private cn As New TIRE
#Region "CORE ENTITY"
    Public Class TIRE
        Public Property tire_index As Integer
        Public Property tire_details As String
        Public Property tire_qty As Double
        Public Property tire_serial_no As String
        Public Property po_det_id As Integer

    End Class
#End Region

#Region "INITIALIZE"
    Public Sub init_datagridview(dgv As DataGridView)
        cDgv = dgv
    End Sub
#End Region

#Region "BUSINESS LOGIC"
    Public Sub loadTires()

        cListOfTireWithoutSerial.Clear()
        Dim n As Integer = 1

        For i = 1 To cTIRE.tire_qty
            Dim tireDataStorage As New TIRE
            With tireDataStorage
                .tire_details = cTIRE.tire_details
                .tire_qty = 1
                .tire_index = n
            End With

            cListOfTireWithoutSerial.Add(tireDataStorage)
            n += 1

        Next

        cDgv.DataSource = cListOfTireWithoutSerial
        customizeDatagridview()

    End Sub

    Public Sub loadUpdatedTires(listOfTireWithSerial As List(Of TIRE))

        cListOfTireWithSerial = listOfTireWithSerial
        cDgv.DataSource = cListOfTireWithSerial
        customizeDatagridview()

    End Sub
#End Region

#Region "CUSTOMIZE SOMETHING"
    Private Sub customizeDatagridview()
        Try
            customDatagrid.customDatagridview(cDgv)
            customDatagrid.autoSizeColumn(cDgv, True)
            cDgv.ReadOnly = True

            'customize width
            cDgv.Columns(NameOf(cn.tire_index)).Width = 100
            cDgv.Columns(NameOf(cn.tire_details)).Width = 400
            cDgv.Columns(NameOf(cn.tire_qty)).Width = 80

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "CRUD"
    Public Sub updateSerialNo(row As TIRE)
        Try
            Dim rowIndex As Integer = cListOfTireWithoutSerial.FindIndex(Function(x)
                                                                             Return x.tire_index = row.tire_index
                                                                         End Function)

            cListOfTireWithoutSerial(rowIndex).tire_serial_no = row.tire_serial_no

            cDgv.DataSource = Nothing
            cDgv.DataSource = cListOfTireWithoutSerial

            customizeDatagridview()
            Utilities.datagridviewSpecificRowFocus(cDgv, row.tire_index, NameOf(cn.tire_index))

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub updateSerialNoEdit(row As TIRE)
        Try
            Dim rowIndex As Integer = cListOfTireWithSerial.FindIndex(Function(x)
                                                                          Return x.tire_index = row.tire_index
                                                                      End Function)

            cListOfTireWithSerial(rowIndex).tire_serial_no = row.tire_serial_no

            cDgv.DataSource = Nothing
            cDgv.DataSource = cListOfTireWithSerial

            customizeDatagridview()
            Utilities.datagridviewSpecificRowFocus(cDgv, row.tire_index, NameOf(cn.tire_index))

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "GET"
    Public ReadOnly Property get_cListOfTireWithoutSerial() As List(Of TIRE)
        Get
            Return cListOfTireWithoutSerial
        End Get
    End Property

    Public ReadOnly Property get_clistOfTireWithSerial() As List(Of TIRE)
        Get
            Return cListOfTireWithSerial
        End Get
    End Property
#End Region
End Class


