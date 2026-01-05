Imports System.Web.UI.WebControls
Imports Microsoft.Office.Interop.Excel

Public Class ListOfEmployeeModel
    Implements IEmployee
    Private customMsg As New customMessageBox
    Private EmployeeModel, WhInchargeNewModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Private cListOfEmployee As New List(Of PropsFields.employee_props_fields)
    Private cListOfIncharge As New List(Of PropsFields.inchargeNew_fields)
    Private cDgv As New DataGridView
    Private cn As New PropsFields.employee_props_fields
    Private customDgv As New CustomGridview
    Private cWhAreaId As Integer

    Public ReadOnly Property getListOfEmployees() As List(Of PropsFields.employee_props_fields)
        Get
            Return cListOfEmployee
        End Get
    End Property


    Public Sub initialize(Optional dgv As DataGridView = Nothing,
                          Optional whAreaId As Integer = 0) Implements IEmployee.initialize
        Try
            cDgv = dgv
            cWhAreaId = whAreaId
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub
    Public Sub delete(id As Integer, whAreaId As Integer) Implements IEmployee.delete
        Try
            Dim cc As New ColumnValuesObj
            cc.setCondition($"incharge_id = {id} and wh_area_id = {whAreaId}")
            cc.deleteData("db_wh_area_incharge")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Function saved(whAreaData As PropsFields.employee_props_fields, Optional whAreaId As Integer = 0) As Integer Implements IEmployee.saved
        Try
            Dim cc As New ColumnValuesObj
            With whAreaData

                cc.add("wh_area_id", whAreaId)
                cc.add("incharge_id", .employee_id)

                Return cc.insertQuery_and_return_id("db_wh_area_incharge")
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function update(whAreaData As PropsFields.employee_props_fields, id As Integer) As Boolean Implements IEmployee.update
        Throw New NotImplementedException()
    End Function

    Public Function getEmployess(searchBy As String, search As String) As List(Of PropsFields.employee_props_fields) Implements IEmployee.getEmployess
        Try

            EmployeeModel.clearParameter()
            WhInchargeNewModel.clearParameter()

            Dim cv2 As New ColumnValues
            Dim cv3 As New ColumnValues
            cv3.add("crud", "8")

            _initializing(cCol.forEmployeeData,
                     cv2.getValues(),
                     EmployeeModel,
                     whAreaStockpileBgWorker)

            _initializing(cCol.forWhInchargeNew,
                          cv3.getValues(),
                          WhInchargeNewModel,
                          whAreaStockpileBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, whAreaStockpileBgWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Sub searchEmployees(search As String) Implements IEmployee.searchEmployees
        Try
            Dim datas As New List(Of PropsFields.employee_props_fields)
            datas = cListOfEmployee.Where(Function(x)
                                              Dim fullname As String = x.last_name & "," & x.first_name & " " & x.middle_name
                                              Return fullname.ToUpper().Contains(search.ToUpper())
                                          End Function).ToList()

            preview(datas)

            'x.status_name.ToUpper() = cEmployeeStatus.SEPARATED And
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyDone()
        Try
            cListOfEmployee = TryCast(EmployeeModel.cData, List(Of PropsFields.employee_props_fields))
            cListOfIncharge = TryCast(WhInchargeNewModel.cData, List(Of PropsFields.inchargeNew_fields))

            preview(cListOfEmployee)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub preview(datas As List(Of PropsFields.employee_props_fields))
        Try
            customDgv.customDatagridview(cDgv, "#011526")
            Dim employes As New List(Of PropsFields.employee_props_fields)

            For Each row In datas
                Dim _emp As New PropsFields.employee_props_fields

                Dim incharge = cListOfIncharge.Where(Function(x)
                                                         Return x.incharge_id = row.employee_id And x.wh_area_id = cWhAreaId
                                                     End Function).ToList()

                With _emp
                    .first_name = row.first_name
                    .last_name = row.last_name
                    .designation = row.designation
                    .employee = row.employee
                    .department = row.department
                    .employee_id = row.employee_id

                    If incharge.Count > 0 Then
                        .ext_name = "exist"
                    End If
                    employes.Add(_emp)
                End With
            Next

            cDgv.DataSource = employes


            customizeDagrid()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub customizeDagrid()
        Try

            For Each row As DataGridViewRow In cDgv.Rows
                If row.Cells(NameOf(cn.ext_name)).Value = "exist" Then
                    row.DefaultCellStyle.BackColor = Color.Green
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
            Next

            'hide columns
            For Each col As DataGridViewColumn In cDgv.Columns
                If col.Name = NameOf(cn.middle_name) Or
                    col.Name = NameOf(cn.status_name) Or
                    col.Name = NameOf(cn.designation) Or
                    col.Name = NameOf(cn.person_id) Or
                    col.Name = NameOf(cn.position) Or
                    col.Name = NameOf(cn.employee) Or
                     col.Name = NameOf(cn.ext_name) Or
                    col.Name = NameOf(cn.employee_id) Then

                    col.Visible = False
                Else
                    col.Visible = True
                End If
            Next
            customDgv.readonlyAllCells(cDgv)
            customDgv.autoSizeColumn(cDgv, True)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class
