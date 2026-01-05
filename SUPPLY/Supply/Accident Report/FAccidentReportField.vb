Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FAccidentReportField
    Public SQ As New SQLcon
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Private Sub lvl_acc_report_field_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvl_acc_report_field.SelectedIndexChanged

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub
    Public Sub search_acc_report()
        lvl_acc_report_field.Items.Clear()
        'ListView1.Items.Clear()
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            If cmbSearch.Text = "ALL" Then
                sqlcomm.Parameters.AddWithValue("@n", 16)
            ElseIf cmbSearch.Text = "AR NO." Then
                sqlcomm.Parameters.AddWithValue("@n", 28)
                sqlcomm.Parameters.AddWithValue("@accident_report_no", CInt(txtSearch.Text))
            ElseIf cmbSearch.Text = "EQUIPMENT" Then
                sqlcomm.Parameters.AddWithValue("@n", 29)
                sqlcomm.Parameters.AddWithValue("@listProperty_equip_mat_damaged", txtSearch.Text)
            End If
            dr = sqlcomm.ExecuteReader

            While dr.Read
                Dim a(25) As String

                a(0) = dr.Item("acc_report_id").ToString
                a(1) = dr.Item("cat_damage_name").ToString
                a(2) = dr.Item("accident_report_no").ToString
                a(3) = dr.Item("cat_damaged").ToString
                a(4) = dr.Item("listProperty_equip_mat_damaged").ToString
                a(5) = dr.Item("natured_damaged").ToString
                a(6) = dr.Item("object_subs_inflicting_damaged").ToString
                a(7) = dr.Item("app_cost_damaged").ToString
                a(8) = dr.Item("breakdown_days").ToString
                a(9) = dr.Item("driver_name").ToString
                a(10) = dr.Item("investigator_name").ToString
                a(11) = dr.Item("job_position").ToString
                a(12) = dr.Item("project_desc").ToString
                a(13) = dr.Item("depart_section_name").ToString
                a(14) = dr.Item("CHARGE_TO").ToString
                a(15) = Format(Date.Parse(dr.Item("date_incident").ToString), "MM/dd/yyyy")
                a(16) = dr.Item("time_incident").ToString
                a(17) = Format(Date.Parse(dr.Item("date_report").ToString), "MM/dd/yyyy")
                a(18) = dr.Item("time_report").ToString
                a(19) = dr.Item("witnessed_by").ToString
                a(20) = dr.Item("supervisor_info_id").ToString
                a(21) = dr.Item("injured_party_id").ToString
                a(22) = dr.Item("equip_pro_dam_id").ToString

                Dim lvl As New ListViewItem(a)
                lvl_acc_report_field.Items.Add(lvl)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub FAccidentReportField_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ListView1.Items.Clear()

        'For i = 0 To 100
        '    Dim a(4) As String

        '    a(0) = i
        '    a(1) = "ian gwapo"
        '    a(2) = "mak2x love jimmy"

        '    Dim lvl As New ListViewItem(a)
        '    ListView1.Items.Add(lvl)
        'Next

        search_acc_report()

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        With FAccidentReport
            'supervisor info id
            .lblUpdate_sup_info_id.Text = lvl_acc_report_field.SelectedItems(0).SubItems(20).Text

            'injured party id
            .lblInjured_party_id.Text = lvl_acc_report_field.SelectedItems(0).SubItems(21).Text

            'equip/property damaged id
            .lblEqui_pro_dam_id.Text = lvl_acc_report_field.SelectedItems(0).SubItems(22).Text

            'accident report id
            .lblAcc_report_id.Text = lvl_acc_report_field.SelectedItems(0).SubItems(0).Text

            'AR NO.
            .txtAr_no.Text = lvl_acc_report_field.SelectedItems(0).SubItems(2).Text

            'equipment/property damage
            .cmbCategoryListPropertyDamage.Text = lvl_acc_report_field.SelectedItems(0).SubItems(3).Text
            .cmb_listProperty_Equi_Material_Damaged.Text = lvl_acc_report_field.SelectedItems(0).SubItems(4).Text
            .txtNatureDamage.Text = lvl_acc_report_field.SelectedItems(0).SubItems(5).Text
            .txtObjectInflictingDamage.Text = lvl_acc_report_field.SelectedItems(0).SubItems(6).Text
            .txtAppCostDamage.Text = lvl_acc_report_field.SelectedItems(0).SubItems(7).Text
            .txtbreakdown_day.Text = lvl_acc_report_field.SelectedItems(0).SubItems(8).Text
            .txt_driver_name.Text = lvl_acc_report_field.SelectedItems(0).SubItems(9).Text

            'supervisor contact information
            .txtInvestigatorName.Text = lvl_acc_report_field.SelectedItems(0).SubItems(10).Text
            .txtJobPosition.Text = lvl_acc_report_field.SelectedItems(0).SubItems(11).Text
            .cmbJobSite.Text = lvl_acc_report_field.SelectedItems(0).SubItems(12).Text
            .cmbDeptSectionName.Text = lvl_acc_report_field.SelectedItems(0).SubItems(13).Text
            .cmbDepartSectionValue.Text = lvl_acc_report_field.SelectedItems(0).SubItems(14).Text
            .DTPDateIncident.Text = lvl_acc_report_field.SelectedItems(0).SubItems(15).Text
            .txtTimeIncident.Text = lvl_acc_report_field.SelectedItems(0).SubItems(16).Text
            .dtp_date_report_super.Text = lvl_acc_report_field.SelectedItems(0).SubItems(17).Text
            .txtTimeOfReport.Text = lvl_acc_report_field.SelectedItems(0).SubItems(18).Text
            .txtWitnessedBy.Text = lvl_acc_report_field.SelectedItems(0).SubItems(19).Text

            'category_damage
            Dim s As String = lvl_acc_report_field.SelectedItems(0).SubItems(1).Text
            Dim words As String() = s.Split(New Char() {"/"c})

            Dim word As String
            For Each word In words
                If .chkboxInjury.Text = word Then
                    .chkboxInjury.Checked = True
                ElseIf .chkboxEquip_damaged.Text = word Then
                    .chkboxEquip_damaged.Checked = True
                ElseIf .chkboxPropertyDamage.Text = word Then
                    .chkboxPropertyDamage.Checked = True
                ElseIf .chkboxCloseCall_NearHit.Text = word Then
                    .chkboxCloseCall_NearHit.Checked = True
                End If
            Next

            ' incident description, corrective actions , follow-up progress, Closed-out Remarks
            Dim x As Integer = CInt(lvl_acc_report_field.SelectedItems(0).SubItems(0).Text)
            get_records(x)

            'Injured Party
            get_injured_party_records(CInt(lvl_acc_report_field.SelectedItems(0).SubItems(20).Text))
        End With

        FAccidentReport.btnSave_next.Text = "Update"
        FAccidentReport.Show()

    End Sub
    Public Sub get_records(ByVal x As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 17)
            sqlcomm.Parameters.AddWithValue("@acc_report_id", x)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                With FAccidentReport
                    .RichTxt_incident_desc.Text = dr.Item("incident_description").ToString
                    .txtActionPlan.Text = dr.Item("corrective_action_plan").ToString
                    .txtResponsibility.Text = dr.Item("corrective_responsibility").ToString
                    .txtTimeFrame.Text = dr.Item("corrective_timeframe").ToString
                    .txt_prepared_by.Text = dr.Item("prepared_by").ToString
                    .dtp_Date_Prepared.Text = dr.Item("date_prepared").ToString
                    .txtApporved_by.Text = dr.Item("approved_by").ToString
                    .dtpApproved_by.Text = dr.Item("date_approved").ToString
                    .txtReviewed_by.Text = dr.Item("reviewed_by").ToString
                    .dtp_date_reviewed.Text = dr.Item("date_reviewed").ToString
                    .richText_Follow_up_Progress.Text = dr.Item("followUp_progress").ToString
                    .txtFollow_up_by.Text = dr.Item("followUp_by").ToString
                    .dtp_date_follow_up.Text = dr.Item("date_follow_up").ToString
                    .rich_text_Closed_out_remarks.Text = dr.Item("closed_out_remarks").ToString
                    .txtClosed_out_by.Text = dr.Item("closed_out_by").ToString
                    .dtp_date_close_out.Text = dr.Item("date_closed_out").ToString
                End With

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Sub get_injured_party_records(ByVal x As Integer)
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 19)
            sqlcomm.Parameters.AddWithValue("@injured_party_id", x)

            dr = sqlcomm.ExecuteReader

            While dr.Read
                With FAccidentReport
                    .txtInjuredPartyName.Text = dr.Item("injured_party_name").ToString
                    .txtAge.Text = dr.Item("age").ToString
                    .txtGender.Text = dr.Item("gender").ToString
                    .txtInjuredJobPosition.Text = dr.Item("job_position").ToString
                    .txtContactInformation.Text = dr.Item("contact_information").ToString
                    .txtBodyPartInjured.Text = dr.Item("body_part_injured").ToString
                    .txtNature_illness_injured.Text = dr.Item("nature_illness_injury").ToString
                    .txttreating_facility.Text = dr.Item("treating_facility").ToString
                    .txtTreatment.Text = dr.Item("treatment_name").ToString
                    .txtTreatmentCost.Text = dr.Item("treatment_cost").ToString
                End With

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_input_fields.Click
        FAccidentReport.Show()

    End Sub

    Private Sub EditRootCauseAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRootCauseAnalysisToolStripMenuItem.Click
        get_acc_id = lvl_acc_report_field.SelectedItems(0).SubItems(0).Text
        boolean_acc_report = True
        ' MsgBox(get_acc_id)
        FAccidentReport_next_page.btnSave.Text = "Update"
        FAccidentReport_next_page.Show()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search_acc_report()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ex = MessageBox.Show("Are you sure u want to DELETE the SELECTED items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If ex = MsgBoxResult.Yes Then
            For Each row As ListViewItem In lvl_acc_report_field.SelectedItems
                Delete_Accident_report(row.SubItems(0).Text, 1)
                Delete_Accident_report(row.SubItems(19).Text, 2)
                Delete_Accident_report(row.SubItems(20).Text, 3)
                Delete_Accident_report(row.SubItems(21).Text, 4)
                Delete_Accident_report(row.SubItems(0).Text, 5)
                Delete_Accident_report(row.SubItems(0).Text, 6)
                row.Remove()
                ' MsgBox(row.SubItems(0).Text)
            Next
            MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub Delete_Accident_report(ByVal x As Integer, ByVal i As Integer)
        ' Dim i As Integer = lvlLiquidationReport.SelectedItems(0).SubItems(0).Text
        Try
            SQ.connection.Open()
            Dim sqlcomm As New SqlCommand

            sqlcomm.Connection = SQ.connection
            sqlcomm.CommandText = "sp_crud_AccidentReport"
            sqlcomm.CommandType = CommandType.StoredProcedure
            If i = 1 Then
                sqlcomm.Parameters.AddWithValue("@n", 30)
                sqlcomm.Parameters.AddWithValue("@acc_report_id", x)
            ElseIf i = 2 Then
                sqlcomm.Parameters.AddWithValue("@n", 31)
                sqlcomm.Parameters.AddWithValue("@supervisor_info_id", x)
            ElseIf i = 3 Then
                sqlcomm.Parameters.AddWithValue("@n", 32)
                sqlcomm.Parameters.AddWithValue("@injured_party_id", x)
            ElseIf i = 4 Then
                sqlcomm.Parameters.AddWithValue("@n", 33)
                sqlcomm.Parameters.AddWithValue("@equip_pro_dam_id", x)
            ElseIf i = 5 Then
                sqlcomm.Parameters.AddWithValue("@n", 24)
                sqlcomm.Parameters.AddWithValue("@acc_report_id", x)
            ElseIf i = 6 Then
                sqlcomm.Parameters.AddWithValue("@n", 23)
                sqlcomm.Parameters.AddWithValue("@acc_report_id", x)
            End If

            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) 

    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class