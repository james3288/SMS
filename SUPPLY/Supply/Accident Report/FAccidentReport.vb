Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FAccidentReport
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Dim supervisor_info_id As Integer
    Dim injured_party_id As Integer
    Dim equip_pro_dam_id As Integer
    Dim acc_report_id As Integer
    Dim z As Integer
    Dim list_supervisor_info As New List(Of List(Of String))
    Dim list_equip_pro_damaged As New List(Of List(Of String))
    Dim list_txtbox_accident_report As New List(Of List(Of String))
    Dim list_txtbox_nature_illness_injured_party As New List(Of String)
    Dim list_txtbox_treatment_injured_party As New List(Of String)
    Dim list_txtbox_injured_party As New List(Of List(Of String))
    Public Sub load_job_site()
        cmbJobSite.Items.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 1)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmbJobSite.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_DeptSection_name()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 13)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmbDeptSectionName.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_charge_to(ByVal n As Integer, ByVal name As String)

        cmbDepartSectionValue.Items.Clear()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_charges_to"
            sqlcomm.CommandType = CommandType.StoredProcedure
            If n = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 1)
            ElseIf n = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 2)
            ElseIf n = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 3)
                sqlcomm.Parameters.AddWithValue("@type_name", name)
                'ElseIf n = 4 Then
                '    sqlcomm.Parameters.AddWithValue("@n", 3)
                '    sqlcomm.Parameters.AddWithValue("@type_name", "MAINOFFICE")
                'ElseIf n = 5 Then
                '    sqlcomm.Parameters.AddWithValue("@n", 3)
                '    sqlcomm.Parameters.AddWithValue("@type_name", "OTHERS")
            ElseIf n = 6 Then
                sqlcomm.Parameters.AddWithValue("@n", 4)

            End If


            dr = sqlcomm.ExecuteReader

            While dr.Read
                If n = 1 Then
                    cmbDepartSectionValue.Items.Add(dr.Item("project_desc").ToString)
                ElseIf n = 2 Then
                    cmbDepartSectionValue.Items.Add(dr.Item("plate_no").ToString)
                ElseIf n = 3 Then
                    cmbDepartSectionValue.Items.Add(dr.Item("charge_to").ToString)
                ElseIf n = 6 Then
                    cmbDepartSectionValue.Items.Add(dr.Item("wh_area").ToString)
                End If


            End While
            dr.Close()
            ' MsgBox("ian")
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_Equipment_Damaged()
        cmb_listProperty_Equi_Material_Damaged.Items.Clear()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 3)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                cmb_listProperty_Equi_Material_Damaged.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function get_id_charge_to(ByVal x As String, ByVal n As Integer) As Integer
        Dim SQ1 As New SQLcon
        Dim cmd1 As SqlCommand
        Dim dr1 As SqlDataReader
        Try
            SQ1.connection1.Open()
            Dim query As String
            If n = 1 Then
                query = "select proj_id from dbprojectdesc where project_desc = '" & x & "' "
            ElseIf n = 2 Then
                query = "select equipListID from dbequipment_list where plate_no = '" & x & "' "
            End If

            cmd1 = New SqlCommand(query, SQ1.connection1)
            dr1 = cmd1.ExecuteReader

            While dr1.Read
                get_id_charge_to = dr1.Item(0).ToString
            End While
            dr1.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ1.connection1.Close()
        End Try
    End Function
    Public Function connection_get_id_charge_to(ByVal name As String, ByVal x As String, ByVal n As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim cmd1 As SqlCommand
        Dim dr1 As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query1 As String

            If n = 1 Then
                query1 = "select wh_area_id from dbwh_area where wh_area = '" & x & "' "
            ElseIf n = 2 Then
                query1 = "select charge_to_id from dbCharge_to where charge_to = '" & x & "' and type_name = '" & name & "' "
                'ElseIf n = 3 Then
                '    query1 = "select charge_to_id from dbCharge_to where charge_to = '" & x & "' and type_name = '" & "MAINOFFICE" & "' "
                'ElseIf n = 4 Then
                '    query1 = "select charge_to_id from dbCharge_to where charge_to = '" & x & "' and type_name = '" & "OTHERS" & "' "
            End If

            cmd1 = New SqlCommand(query1, newSQ.connection)
            dr1 = cmd1.ExecuteReader

            While dr1.Read
                connection_get_id_charge_to = dr1.Item(0).ToString
            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function get_id_project_desc(ByVal x As String) As Integer
        Dim newSQ As New SQLcon
        Dim dr1 As SqlDataReader
        Try
            newSQ.connection.Open()
            Dim sqlcomm1 As New SqlCommand

            sqlcomm1.Connection = newSQ.connection
            sqlcomm1.CommandText = "sp_crud_AccidentReport"
            sqlcomm1.CommandType = CommandType.StoredProcedure
            sqlcomm1.Parameters.AddWithValue("@n", 6)
            sqlcomm1.Parameters.AddWithValue("@project_desc", x)

            dr1 = sqlcomm1.ExecuteReader
            While dr1.Read
                get_id_project_desc = dr1.Item(0).ToString
            End While
            dr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub save_Supervisor_contact_information()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 5)
            sqlcomm.Parameters.AddWithValue("@investigator_name", txtInvestigatorName.Text)
            sqlcomm.Parameters.AddWithValue("@job_position", txtJobPosition.Text)
            sqlcomm.Parameters.AddWithValue("@project_desc_id", get_id_project_desc(cmbJobSite.Text))
            sqlcomm.Parameters.AddWithValue("@depart_section_name", cmbDeptSectionName.Text)

            If cmbDeptSectionName.Text = "PROJECT" Then
                sqlcomm.Parameters.AddWithValue("@charge_to_id", get_id_charge_to(cmbDepartSectionValue.Text, 1))
            ElseIf cmbDeptSectionName.Text = "EQUIPMENT" Then
                sqlcomm.Parameters.AddWithValue("@charge_to_id", get_id_charge_to(cmbDepartSectionValue.Text, 2))
            ElseIf cmbDeptSectionName.Text = "WAREHOUSE" Then
                sqlcomm.Parameters.AddWithValue("@charge_to_id", connection_get_id_charge_to(cmbDeptSectionName.Text, cmbDepartSectionValue.Text, 1))
            Else
                sqlcomm.Parameters.AddWithValue("@charge_to_id", connection_get_id_charge_to(cmbDeptSectionName.Text, cmbDepartSectionValue.Text, 2))
            End If

            'sqlcomm.Parameters.AddWithValue("@charge_to_id", cmbDepartSectionValue.Text)
            sqlcomm.Parameters.AddWithValue("@date_incident", Date.Parse(DTPDateIncident.Text))
            sqlcomm.Parameters.AddWithValue("@time_incident", txtTimeIncident.Text)
            sqlcomm.Parameters.AddWithValue("@date_report", Date.Parse(dtp_date_report_super.Text))
            sqlcomm.Parameters.AddWithValue("@time_report", txtTimeOfReport.Text)
            sqlcomm.Parameters.AddWithValue("@witnessed_by", txtWitnessedBy.Text)

            supervisor_info_id = sqlcomm.ExecuteScalar

            ' MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_Injured_party()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 7)
            sqlcomm.Parameters.AddWithValue("@injured_party_name", txtInjuredPartyName.Text)
            sqlcomm.Parameters.AddWithValue("@nature_illness_injury", txtNature_illness_injured.Text)
            sqlcomm.Parameters.AddWithValue("@age", CInt(txtAge.Text))
            sqlcomm.Parameters.AddWithValue("@gender", txtGender.Text)
            sqlcomm.Parameters.AddWithValue("@job_position", txtInjuredJobPosition.Text)
            sqlcomm.Parameters.AddWithValue("@contact_information", txtContactInformation.Text)
            sqlcomm.Parameters.AddWithValue("@treating_facility", txttreating_facility.Text)
            sqlcomm.Parameters.AddWithValue("@body_part_injured", txtBodyPartInjured.Text)
            sqlcomm.Parameters.AddWithValue("@treatment_cost", CDec(txtTreatmentCost.Text))
            sqlcomm.Parameters.AddWithValue("@treatment_name", txtTreatment.Text)

            injured_party_id = sqlcomm.ExecuteScalar

            'MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_Equip_property_damage()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 8)
            sqlcomm.Parameters.AddWithValue("@cat_damaged", cmbCategoryListPropertyDamage.Text)
            sqlcomm.Parameters.AddWithValue("@listProperty_equip_mat_damaged", cmb_listProperty_Equi_Material_Damaged.Text)
            sqlcomm.Parameters.AddWithValue("@natured_damaged", txtNatureDamage.Text)
            sqlcomm.Parameters.AddWithValue("@object_subs_inflicting_damaged", txtObjectInflictingDamage.Text)
            sqlcomm.Parameters.AddWithValue("@app_cost_damaged", CDec(txtAppCostDamage.Text))
            sqlcomm.Parameters.AddWithValue("@breakdown_days", txtbreakdown_day.Text)
            sqlcomm.Parameters.AddWithValue("@driver_name", txt_driver_name.Text)

            equip_pro_dam_id = sqlcomm.ExecuteScalar

            'MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_Accident_report()

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 9)
            sqlcomm.Parameters.AddWithValue("@supervisor_info_id", supervisor_info_id)
            sqlcomm.Parameters.AddWithValue("@injured_party_id", injured_party_id)
            sqlcomm.Parameters.AddWithValue("@equip_pro_dam_id", equip_pro_dam_id)
            sqlcomm.Parameters.AddWithValue("@incident_description", RichTxt_incident_desc.Text)
            sqlcomm.Parameters.AddWithValue("@corrective_action_plan", txtActionPlan.Text)
            sqlcomm.Parameters.AddWithValue("@corrective_responsibility", txtResponsibility.Text)
            sqlcomm.Parameters.AddWithValue("@corrective_timeframe", txtTimeFrame.Text)
            sqlcomm.Parameters.AddWithValue("@prepared_by", txt_prepared_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_prepared", Date.Parse(dtp_Date_Prepared.Text))
            sqlcomm.Parameters.AddWithValue("@approved_by", txtApporved_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_approved", dtpApproved_by.Text)
            sqlcomm.Parameters.AddWithValue("@reviewed_by", txtReviewed_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_reviewed", Date.Parse(dtp_date_reviewed.Text))
            sqlcomm.Parameters.AddWithValue("@followUp_progress", richText_Follow_up_Progress.Text)
            sqlcomm.Parameters.AddWithValue("@followUp_by", txtFollow_up_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_follow_up", Date.Parse(dtp_date_follow_up.Text))
            sqlcomm.Parameters.AddWithValue("@closed_out_remarks", rich_text_Closed_out_remarks.Text)
            sqlcomm.Parameters.AddWithValue("@closed_out_by", txtClosed_out_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_closed_out", Date.Parse(dtp_date_close_out.Text))
            sqlcomm.Parameters.AddWithValue("@accident_report_no", txtAr_no.Text)

            acc_report_id = sqlcomm.ExecuteScalar
            get_acc_id = acc_report_id

            MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub save_multiple_cat_damaged(ByVal n As Integer, ByVal i As Integer)

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 10)
            sqlcomm.Parameters.AddWithValue("@cat_damage_id", n)
            sqlcomm.Parameters.AddWithValue("@acc_report_id", i)

            z = sqlcomm.ExecuteScalar

            ' MessageBox.Show("Successfully Saved...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub update_supervisor_info(ByVal x As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 18)
            sqlcomm.Parameters.AddWithValue("@supervisor_info_id", x)
            sqlcomm.Parameters.AddWithValue("@investigator_name", txtInvestigatorName.Text)
            sqlcomm.Parameters.AddWithValue("@job_position", txtJobPosition.Text)
            sqlcomm.Parameters.AddWithValue("@project_desc_id", get_id_project_desc(cmbJobSite.Text))
            sqlcomm.Parameters.AddWithValue("@depart_section_name", cmbDeptSectionName.Text)

            If cmbDeptSectionName.Text = "PROJECT" Then
                sqlcomm.Parameters.AddWithValue("@charge_to_id", get_id_charge_to(cmbDepartSectionValue.Text, 1))
            ElseIf cmbDeptSectionName.Text = "EQUIPMENT" Then
                sqlcomm.Parameters.AddWithValue("@charge_to_id", get_id_charge_to(cmbDepartSectionValue.Text, 2))
            ElseIf cmbDeptSectionName.Text = "WAREHOUSE" Then
                sqlcomm.Parameters.AddWithValue("@charge_to_id", connection_get_id_charge_to(cmbDeptSectionName.Text, cmbDepartSectionValue.Text, 1))
            Else
                sqlcomm.Parameters.AddWithValue("@charge_to_id", connection_get_id_charge_to(cmbDeptSectionName.Text, cmbDepartSectionValue.Text, 2))
            End If

            ' sqlcomm.Parameters.AddWithValue("@charge_to_id", cmbDepartSectionValue.Text)
            sqlcomm.Parameters.AddWithValue("@date_incident", Date.Parse(DTPDateIncident.Text))
            sqlcomm.Parameters.AddWithValue("@time_incident", txtTimeIncident.Text)
            sqlcomm.Parameters.AddWithValue("@date_report", Date.Parse(dtp_date_report_super.Text))
            sqlcomm.Parameters.AddWithValue("@time_report", txtTimeOfReport.Text)
            sqlcomm.Parameters.AddWithValue("@witnessed_by", txtWitnessedBy.Text)

            sqlcomm.ExecuteNonQuery()
            '  MessageBox.Show("Successfully updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub update_injured_party(ByVal x As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 20)
            sqlcomm.Parameters.AddWithValue("@supervisor_info_id", x)
            sqlcomm.Parameters.AddWithValue("@injured_party_name", txtInjuredPartyName.Text)
            sqlcomm.Parameters.AddWithValue("@nature_illness_injury", txtNature_illness_injured.Text)
            sqlcomm.Parameters.AddWithValue("@age", CInt(txtAge.Text))
            sqlcomm.Parameters.AddWithValue("@gender", txtGender.Text)
            sqlcomm.Parameters.AddWithValue("@job_position", txtInjuredJobPosition.Text)
            sqlcomm.Parameters.AddWithValue("@contact_information", txtContactInformation.Text)
            sqlcomm.Parameters.AddWithValue("@treating_facility", txttreating_facility.Text)
            sqlcomm.Parameters.AddWithValue("@body_part_injured", txtBodyPartInjured.Text)
            sqlcomm.Parameters.AddWithValue("@treatment_cost", txtTreatmentCost.Text)
            sqlcomm.Parameters.AddWithValue("@treatment_name", txtTreatment.Text)

            sqlcomm.ExecuteNonQuery()
            ' MessageBox.Show("Successfully updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub update_equip_pro_dam_id(ByVal x As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 21)
            sqlcomm.Parameters.AddWithValue("@equip_pro_dam_id", x)
            sqlcomm.Parameters.AddWithValue("@cat_damaged", cmbCategoryListPropertyDamage.Text)
            sqlcomm.Parameters.AddWithValue("@listProperty_equip_mat_damaged", cmb_listProperty_Equi_Material_Damaged.Text)
            sqlcomm.Parameters.AddWithValue("@natured_damaged", txtNatureDamage.Text)
            sqlcomm.Parameters.AddWithValue("@object_subs_inflicting_damaged", txtObjectInflictingDamage.Text)
            sqlcomm.Parameters.AddWithValue("@app_cost_damaged", CDec(txtAppCostDamage.Text))
            sqlcomm.Parameters.AddWithValue("@breakdown_days", txtbreakdown_day.Text)
            sqlcomm.Parameters.AddWithValue("@driver_name", txt_driver_name.Text)

            sqlcomm.ExecuteNonQuery()
            ' MessageBox.Show("Successfully updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub update_accident_report_id(ByVal x As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 22)
            sqlcomm.Parameters.AddWithValue("@acc_report_id", x)
            sqlcomm.Parameters.AddWithValue("@incident_description", RichTxt_incident_desc.Text)
            sqlcomm.Parameters.AddWithValue("@corrective_action_plan", txtActionPlan.Text)
            sqlcomm.Parameters.AddWithValue("@corrective_responsibility", txtResponsibility.Text)
            sqlcomm.Parameters.AddWithValue("@corrective_timeframe", txtTimeFrame.Text)
            sqlcomm.Parameters.AddWithValue("@prepared_by", txt_prepared_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_prepared", Date.Parse(dtp_Date_Prepared.Text))
            sqlcomm.Parameters.AddWithValue("@approved_by", txtApporved_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_approved", Date.Parse(dtpApproved_by.Text))
            sqlcomm.Parameters.AddWithValue("@reviewed_by", txtReviewed_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_reviewed", Date.Parse(dtp_date_reviewed.Text))
            sqlcomm.Parameters.AddWithValue("@followUp_progress", richText_Follow_up_Progress.Text)
            sqlcomm.Parameters.AddWithValue("@followUp_by", txtFollow_up_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_follow_up", Date.Parse(dtp_date_follow_up.Text))
            sqlcomm.Parameters.AddWithValue("@closed_out_remarks", rich_text_Closed_out_remarks.Text)
            sqlcomm.Parameters.AddWithValue("@closed_out_by", txtClosed_out_by.Text)
            sqlcomm.Parameters.AddWithValue("@date_closed_out", Date.Parse(dtp_date_close_out.Text))
            sqlcomm.Parameters.AddWithValue("@accident_report_no", txtAr_no.Text)
            sqlcomm.Parameters.AddWithValue("@date_log", Date.Now)

            sqlcomm.ExecuteNonQuery()
            ' MessageBox.Show("Successfully updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub Delete_mul_cat_damaged_data(ByVal x As Integer)
        ' Dim i As Integer = lvlLiquidationReport.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 23)
            sqlcomm.Parameters.AddWithValue("@acc_report_id", x)
            sqlcomm.ExecuteNonQuery()
            ' MsgBox("delete")
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblDepartment_section.Click

    End Sub

    Private Sub gboxInjuredParty_Enter(sender As Object, e As EventArgs) Handles gboxInjuredParty.Enter

    End Sub

    Private Sub lblDate_follow_up_Click(sender As Object, e As EventArgs) Handles lblDate_follow_up.Click

    End Sub

    Private Sub FAccidentReport_Page1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'supervisor contact information
        load_job_site()
        load_DeptSection_name()
        'root cause analysis

        'save data for textbox supervisor info
        save_data_supervisor_info()
        load_list_supervisor_info()

        'save data for textbox equipment property damaged
        save_data_equip_damaged()
        load_list_equip_pro_damaged()

        'save data for textbox accident report
        save_data_txtbox_accident_report()
        load_list_accident_report()

        'save data for textbox injured party nature illness
        save_data_txtbox_nature_illness_injured_party()
        load_list_txtbox_nature_illness_injured_party()

        'save data for textbox injured party treatment
        save_data_txtbox_treatment_injured_party()
        load_list_txtbox_treatment_injured_party()

        'save data for textbox injured part
        save_data_txtbox_injured_partyt()
        load_list_injured_party()
    End Sub

    Private Sub cmbDeptSectionName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeptSectionName.SelectedIndexChanged
        'cmbDeptSectionName.Text = ""

        If cmbDeptSectionName.Text = "EQUIPMENT" Then
            load_charge_to(2, cmbDeptSectionName.Text)

        ElseIf cmbDeptSectionName.Text = "PROJECT" Then
            load_charge_to(1, cmbDeptSectionName.Text)

        ElseIf cmbDeptSectionName.Text = "WAREHOUSE" Then
            load_charge_to(6, cmbDeptSectionName.Text)

        Else
            load_charge_to(3, cmbDeptSectionName.Text)
        End If

    End Sub

    Private Sub cmbCategoryListPropertyDamage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryListPropertyDamage.SelectedIndexChanged
        If cmbCategoryListPropertyDamage.Text = "Equipment Damaged" Then
            load_Equipment_Damaged()
        Else
            cmb_listProperty_Equi_Material_Damaged.Items.Clear()


        End If
    End Sub

    Private Sub btnSave_next_Click(sender As Object, e As EventArgs) Handles btnSave_next.Click
        If btnSave_next.Text = "Save And Next" Then
            save_Supervisor_contact_information()
            save_Injured_party()
            save_Equip_property_damage()
            save_Accident_report()

            If chkboxInjury.Checked = True Then
                save_multiple_cat_damaged(1, acc_report_id)
            End If
            If chkboxEquip_damaged.Checked = True Then
                save_multiple_cat_damaged(2, acc_report_id)
            End If
            If chkboxPropertyDamage.Checked = True Then
                save_multiple_cat_damaged(3, acc_report_id)
            End If
            If chkboxCloseCall_NearHit.Checked = True Then
                save_multiple_cat_damaged(4, acc_report_id)
            End If
            boolean_acc_report = False
            FAccidentReport_next_page.Show()

        ElseIf btnSave_next.Text = "Update" Then
            update_supervisor_info(CInt(lblUpdate_sup_info_id.Text))
            update_injured_party(CInt(lblInjured_party_id.Text))
            update_equip_pro_dam_id(CInt(lblEqui_pro_dam_id.Text))
            update_accident_report_id(CInt(lblAcc_report_id.Text))

            'delete first
            Delete_mul_cat_damaged_data(lblAcc_report_id.Text)
            'save checkbox
            If chkboxInjury.Checked = True Then
                save_multiple_cat_damaged(1, CInt(lblAcc_report_id.Text))
            End If
            If chkboxEquip_damaged.Checked = True Then
                save_multiple_cat_damaged(2, CInt(lblAcc_report_id.Text))
            End If
            If chkboxPropertyDamage.Checked = True Then
                save_multiple_cat_damaged(3, CInt(lblAcc_report_id.Text))
            End If
            If chkboxCloseCall_NearHit.Checked = True Then
                save_multiple_cat_damaged(4, CInt(lblAcc_report_id.Text))
            End If

            MessageBox.Show("Successfully updated...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
            FAccidentReportField.lvl_acc_report_field.SelectedItems.Clear()
            With FAccidentReportField
                .cmbSearch.Text = "ALL"
                .btnSearch.PerformClick()
                listfocus1(.lvl_acc_report_field, CInt(lblAcc_report_id.Text))
            End With
        End If


    End Sub
    Public Sub save_data_supervisor_info()
        Dim Row As Integer

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 25)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_supervisor_info.Add(New List(Of String))
                list_supervisor_info(Row).Add(dr.Item("investigator_name").ToString)
                list_supervisor_info(Row).Add(dr.Item("job_position").ToString)
                list_supervisor_info(Row).Add(dr.Item("time_incident").ToString)
                list_supervisor_info(Row).Add(dr.Item("time_report").ToString)
                list_supervisor_info(Row).Add(dr.Item("witnessed_by").ToString)

                Row = Row + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_supervisor_info()
        Dim row As New AutoCompleteStringCollection
        Dim row1 As New AutoCompleteStringCollection
        Dim row2 As New AutoCompleteStringCollection
        Dim row3 As New AutoCompleteStringCollection
        Dim row4 As New AutoCompleteStringCollection

        For Each item As List(Of String) In list_supervisor_info
            '' MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1))
            row.Add(item(0))
            row1.Add(item(1))
            row2.Add(item(2))
            row3.Add(item(3))
            row4.Add(item(4))
        Next
        txtInvestigatorName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtInvestigatorName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtInvestigatorName.AutoCompleteCustomSource = row

        txtJobPosition.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtJobPosition.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtJobPosition.AutoCompleteCustomSource = row1

        txtTimeIncident.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTimeIncident.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtTimeIncident.AutoCompleteCustomSource = row2

        txtTimeOfReport.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTimeOfReport.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtTimeOfReport.AutoCompleteCustomSource = row3

        txtWitnessedBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtWitnessedBy.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtWitnessedBy.AutoCompleteCustomSource = row4

    End Sub
    Public Sub save_data_equip_damaged()
        Dim Row As Integer

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 26)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_equip_pro_damaged.Add(New List(Of String))
                list_equip_pro_damaged(Row).Add(dr.Item("natured_damaged").ToString)
                list_equip_pro_damaged(Row).Add(dr.Item("object_subs_inflicting_damaged").ToString)
                list_equip_pro_damaged(Row).Add(dr.Item("app_cost_damaged").ToString)
                list_equip_pro_damaged(Row).Add(dr.Item("breakdown_days").ToString)

                Row = Row + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_equip_pro_damaged()
        Dim row As New AutoCompleteStringCollection
        Dim row1 As New AutoCompleteStringCollection
        Dim row2 As New AutoCompleteStringCollection
        Dim row3 As New AutoCompleteStringCollection

        For Each item As List(Of String) In list_equip_pro_damaged
            '' MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1))
            row.Add(item(0))
            row1.Add(item(1))
            row2.Add(item(2))
            row3.Add(item(3))
        Next

        txtNatureDamage.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtNatureDamage.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtNatureDamage.AutoCompleteCustomSource = row

        txtObjectInflictingDamage.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtObjectInflictingDamage.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtObjectInflictingDamage.AutoCompleteCustomSource = row1

        txtAppCostDamage.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtAppCostDamage.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtAppCostDamage.AutoCompleteCustomSource = row2

        txtbreakdown_day.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtbreakdown_day.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbreakdown_day.AutoCompleteCustomSource = row3

        'For Each item As List(Of String) In list_equip_pro_damaged
        '    MsgBox("test 1 : " & item(0) & " and test 2 : " & item(3))

        'Next
    End Sub
    Public Sub save_data_txtbox_accident_report()
        Dim Row As Integer

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 27)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_txtbox_accident_report.Add(New List(Of String))
                list_txtbox_accident_report(Row).Add(dr.Item("prepared_by").ToString)
                list_txtbox_accident_report(Row).Add(dr.Item("approved_by").ToString)
                list_txtbox_accident_report(Row).Add(dr.Item("reviewed_by").ToString)
                list_txtbox_accident_report(Row).Add(dr.Item("followUp_by").ToString)
                list_txtbox_accident_report(Row).Add(dr.Item("closed_out_by").ToString)

                Row = Row + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_accident_report()
        Dim row As New AutoCompleteStringCollection
        Dim row1 As New AutoCompleteStringCollection
        Dim row2 As New AutoCompleteStringCollection
        Dim row3 As New AutoCompleteStringCollection
        Dim row4 As New AutoCompleteStringCollection

        For Each item As List(Of String) In list_txtbox_accident_report
            '' MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1))
            row.Add(item(0))
            row1.Add(item(1))
            row2.Add(item(2))
            row3.Add(item(3))
            row4.Add(item(4))
        Next

        txt_prepared_by.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt_prepared_by.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_prepared_by.AutoCompleteCustomSource = row

        txtApporved_by.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtApporved_by.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtApporved_by.AutoCompleteCustomSource = row1

        txtReviewed_by.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtReviewed_by.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtReviewed_by.AutoCompleteCustomSource = row2

        txtFollow_up_by.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtFollow_up_by.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtFollow_up_by.AutoCompleteCustomSource = row3

        txtClosed_out_by.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtClosed_out_by.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtClosed_out_by.AutoCompleteCustomSource = row4

        'For Each item As List(Of String) In list_txtbox_accident_report
        '    MsgBox("test 1 : " & item(0) & " and test 2 : " & item(3))

        'Next
    End Sub
    Public Sub save_data_txtbox_nature_illness_injured_party()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 34)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_txtbox_nature_illness_injured_party.Add(dr.Item("name_injury_illness").ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_txtbox_nature_illness_injured_party()
        Dim row As New AutoCompleteStringCollection

        For Each item In list_txtbox_nature_illness_injured_party
            row.Add(item)
        Next

        txtNature_illness_injured.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtNature_illness_injured.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtNature_illness_injured.AutoCompleteCustomSource = row

    End Sub
    Public Sub save_data_txtbox_treatment_injured_party()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 35)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_txtbox_treatment_injured_party.Add(dr.Item("treatment").ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_txtbox_treatment_injured_party()
        Dim row As New AutoCompleteStringCollection

        For Each item In list_txtbox_treatment_injured_party
            row.Add(item)
        Next

        txtTreatment.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTreatment.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtTreatment.AutoCompleteCustomSource = row

    End Sub
    Public Sub save_data_txtbox_injured_partyt()
        Dim Row As Integer

        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 36)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                list_txtbox_injured_party.Add(New List(Of String))
                list_txtbox_injured_party(Row).Add(dr.Item("injured_party_name").ToString)
                list_txtbox_injured_party(Row).Add(dr.Item("gender").ToString)
                list_txtbox_injured_party(Row).Add(dr.Item("job_position").ToString)
                list_txtbox_injured_party(Row).Add(dr.Item("treating_facility").ToString)
                list_txtbox_injured_party(Row).Add(dr.Item("body_part_injured").ToString)

                Row = Row + 1
            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub load_list_injured_party()
        Dim row As New AutoCompleteStringCollection
        Dim row1 As New AutoCompleteStringCollection
        Dim row2 As New AutoCompleteStringCollection
        Dim row3 As New AutoCompleteStringCollection
        Dim row4 As New AutoCompleteStringCollection

        For Each item As List(Of String) In list_txtbox_injured_party
            '' MsgBox("test 1 : " & item(0) & " and test 2 : " & item(1))
            row.Add(item(0))
            row1.Add(item(1))
            row2.Add(item(2))
            row3.Add(item(3))
            row4.Add(item(4))
        Next

        txtInjuredPartyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtInjuredPartyName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtInjuredPartyName.AutoCompleteCustomSource = row

        txtGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtGender.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtGender.AutoCompleteCustomSource = row1

        txtInjuredJobPosition.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtInjuredJobPosition.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtInjuredJobPosition.AutoCompleteCustomSource = row2

        txttreating_facility.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txttreating_facility.AutoCompleteSource = AutoCompleteSource.CustomSource
        txttreating_facility.AutoCompleteCustomSource = row3

        txtBodyPartInjured.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtBodyPartInjured.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtBodyPartInjured.AutoCompleteCustomSource = row4

        'For Each item As List(Of String) In list_txtbox_accident_report
        '    MsgBox("test 1 : " & item(0) & " and test 2 : " & item(3))

        'Next
    End Sub

    Private Sub txtInvestigatorName_TextChanged(sender As Object, e As EventArgs) Handles txtInvestigatorName.TextChanged

    End Sub

    Private Sub txtInvestigatorName_GotFocus(sender As Object, e As EventArgs) Handles txtInvestigatorName.GotFocus, txtJobPosition.GotFocus, cmbJobSite.GotFocus, cmbDeptSectionName.GotFocus, cmbDepartSectionValue.GotFocus, DTPDateIncident.GotFocus, txtTimeIncident.GotFocus, dtp_date_report_super.GotFocus, txtTimeOfReport.GotFocus, txtWitnessedBy.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtInvestigatorName_Leave(sender As Object, e As EventArgs) Handles txtInvestigatorName.Leave, txtJobPosition.Leave, cmbJobSite.Leave, cmbDeptSectionName.Leave, cmbDepartSectionValue.Leave, DTPDateIncident.Leave, txtTimeIncident.Leave, dtp_date_report_super.Leave, txtTimeOfReport.Leave, txtWitnessedBy.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub txtInjuredPartyName_TextChanged(sender As Object, e As EventArgs) Handles txtInjuredPartyName.TextChanged

    End Sub

    Private Sub txtInjuredPartyName_GotFocus(sender As Object, e As EventArgs) Handles txtInjuredPartyName.GotFocus, txtAge.GotFocus, txtGender.GotFocus, txtInjuredJobPosition.GotFocus, txtContactInformation.GotFocus, txtBodyPartInjured.GotFocus, txtNature_illness_injured.GotFocus, txttreating_facility.GotFocus, txtTreatment.GotFocus, txtTreatmentCost.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtInjuredPartyName_Leave(sender As Object, e As EventArgs) Handles txtInjuredPartyName.Leave, txtAge.Leave, txtGender.Leave, txtInjuredJobPosition.Leave, txtContactInformation.Leave, txtBodyPartInjured.Leave, txtNature_illness_injured.Leave, txttreating_facility.Leave, txtTreatment.Leave, txtTreatmentCost.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub cmbCategoryListPropertyDamage_GotFocus(sender As Object, e As EventArgs) Handles cmbCategoryListPropertyDamage.GotFocus, cmb_listProperty_Equi_Material_Damaged.GotFocus, txtNatureDamage.GotFocus, txtObjectInflictingDamage.GotFocus, txtAppCostDamage.GotFocus, txtbreakdown_day.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub cmbCategoryListPropertyDamage_Leave(sender As Object, e As EventArgs) Handles cmbCategoryListPropertyDamage.Leave, cmb_listProperty_Equi_Material_Damaged.Leave, txtNatureDamage.Leave, txtObjectInflictingDamage.Leave, txtAppCostDamage.Leave, txtbreakdown_day.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub RichTxt_incident_desc_TextChanged(sender As Object, e As EventArgs) Handles RichTxt_incident_desc.TextChanged

    End Sub

    Private Sub RichTxt_incident_desc_GotFocus(sender As Object, e As EventArgs) Handles RichTxt_incident_desc.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub RichTxt_incident_desc_Leave(sender As Object, e As EventArgs) Handles RichTxt_incident_desc.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub txtActionPlan_TextChanged(sender As Object, e As EventArgs) Handles txtActionPlan.TextChanged

    End Sub

    Private Sub txtActionPlan_GotFocus(sender As Object, e As EventArgs) Handles txtActionPlan.GotFocus, txtResponsibility.GotFocus, txtTimeFrame.GotFocus, txt_prepared_by.GotFocus, dtp_Date_Prepared.GotFocus, txtApporved_by.GotFocus, dtpApproved_by.GotFocus, txtReviewed_by.GotFocus, dtp_date_reviewed.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub txtActionPlan_Leave(sender As Object, e As EventArgs) Handles txtActionPlan.Leave, txtResponsibility.Leave, txtTimeFrame.Leave, txt_prepared_by.Leave, dtp_Date_Prepared.Leave, txtApporved_by.Leave, dtpApproved_by.Leave, txtReviewed_by.Leave, dtp_date_reviewed.Leave
        sender.backcolor = Color.White
    End Sub

    Private Sub richText_Follow_up_Progress_TextChanged(sender As Object, e As EventArgs) Handles richText_Follow_up_Progress.TextChanged

    End Sub

    Private Sub richText_Follow_up_Progress_GotFocus(sender As Object, e As EventArgs) Handles richText_Follow_up_Progress.GotFocus, txtFollow_up_by.GotFocus, dtp_date_follow_up.GotFocus, rich_text_Closed_out_remarks.GotFocus, txtClosed_out_by.GotFocus, dtp_date_close_out.GotFocus, txtAr_no.GotFocus
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub richText_Follow_up_Progress_Leave(sender As Object, e As EventArgs) Handles richText_Follow_up_Progress.Leave, txtFollow_up_by.Leave, dtp_date_follow_up.Leave, rich_text_Closed_out_remarks.Leave, txtClosed_out_by.Leave, dtp_date_close_out.Leave, txtAr_no.Leave
        sender.backcolor = Color.White
    End Sub

End Class