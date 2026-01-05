Public Class FReportViewer_ProgressReportRevised
    Private Sub FReportViewer_ProgressReportRevised_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim date_to_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_to_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("date_to_par", FSummarySupplyTransaction.dtpEndDate.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(date_to_par)

        'Dim issues(0) As Microsoft.Reporting.WinForms.ReportParameter
        'issues(0) = New Microsoft.Reporting.WinForms.ReportParameter("note_par", FProgressReport.txt_issues.Text.ToString)
        'ReportViewer2.LocalReport.SetParameters(issues)

        Dim Target_Major(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Major(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Major", FProgressReport.txt_TargetMajor.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Major)

        Dim Target_Minor(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Minor(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Minor", FProgressReport.txt_TargetMinor.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Minor)

        Dim Target_Equipment(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Equipment(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Equipment", FProgressReport.txt_TargetEquipment.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Equipment)

        Dim Target_Admin(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Admin(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Admin", FProgressReport.txt_TargetAdmin.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Admin)

        Dim Target_Equipment_Repair(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Equipment_Repair(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Equipment_Repair", FProgressReport.txt_TargetEquipment_Repair.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Equipment_Repair)

        Dim Target_Equipment_Rehabilitation(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Equipment_Rehabilitation(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Equipment_Rehabilitation", FProgressReport.txt_TargetEquipment_Rehabilitation.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Equipment_Rehabilitation)

        Dim Target_Equipment_Fuel(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Equipment_Fuel(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Equipment_Fuel", FProgressReport.txt_TargetEquipment_Fuel.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Equipment_Fuel)

        Dim Target_Equipment_Tires(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_Equipment_Tires(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_Equipment_Tires", FProgressReport.txt_TargetEquipment_Tires.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_Equipment_Tires)

        Dim Data_Major(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Major(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Major", FProgressReport.data_major.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Major)

        Dim Data_Minor(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Minor(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Minor", FProgressReport.data_minor.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Minor)

        Dim Data_Equipment(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Equipment(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Equipment", FProgressReport.data_equipment_maintenance.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Equipment)

        Dim Data_Equipment_Repair(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Equipment_Repair(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Equipment_Repair", FProgressReport.data_equipment_repair.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Equipment_Repair)

        Dim Data_Equipment_Rehabilitation(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Equipment_Rehabilitation(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Equipment_Rehabilitation", FProgressReport.data_equipment_rehabilitation.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Equipment_Rehabilitation)

        Dim Data_Equipment_Fuel(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Equipment_Fuel(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Equipment_Fuel", FProgressReport.data_equipment_fuel.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Equipment_Fuel)

        Dim Data_Equipment_Tires(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Equipment_Tires(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Equipment_Tires", FProgressReport.data_equipment_tires.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Equipment_Tires)

        Dim Data_Admin(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_Admin(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_Admin", FProgressReport.data_admin.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_Admin)

        Dim submmittedby(0) As Microsoft.Reporting.WinForms.ReportParameter
        submmittedby(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_submittedby", FProgressReport.txtCheckName.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(submmittedby)

        Dim par_reviewed_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_reviewed_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_reviewed_by", FProgressReport.reviewed_by.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(par_reviewed_by)

        Dim date_submitted(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_submitted(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_date_submitted", FProgressReport.dtp_dateSubmitted.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(date_submitted)

        Dim total_request(0) As Microsoft.Reporting.WinForms.ReportParameter
        total_request(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_total_request", FProgressReport.lbl_total_request.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(total_request)

        Dim total_amount(0) As Microsoft.Reporting.WinForms.ReportParameter
        total_amount(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_total_amount", FProgressReport.lbl_total_amount.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(total_amount)

        Dim other_construction_charges(0) As Microsoft.Reporting.WinForms.ReportParameter
        other_construction_charges(0) = New Microsoft.Reporting.WinForms.ReportParameter("OtherConstructionCharges", FProgressReport.target_other_construction.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(other_construction_charges)

        Dim other_equipment_charges(0) As Microsoft.Reporting.WinForms.ReportParameter
        other_equipment_charges(0) = New Microsoft.Reporting.WinForms.ReportParameter("OtherEquipmentnCharges", FProgressReport.target_equipment_charges.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(other_equipment_charges)

        Dim plantEquipment(0) As Microsoft.Reporting.WinForms.ReportParameter
        plantEquipment(0) = New Microsoft.Reporting.WinForms.ReportParameter("plantEquipment", FProgressReport.txtTargetPaf.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(plantEquipment)

        Dim data_other_con(0) As Microsoft.Reporting.WinForms.ReportParameter
        data_other_con(0) = New Microsoft.Reporting.WinForms.ReportParameter("data_other_con", FProgressReport.data_other_con.ToString)
        ReportViewer2.LocalReport.SetParameters(data_other_con)

        Dim data_other_equipment_charges(0) As Microsoft.Reporting.WinForms.ReportParameter
        data_other_equipment_charges(0) = New Microsoft.Reporting.WinForms.ReportParameter("data_other_equipment_charges", FProgressReport.data_other_equipment_charges.ToString)
        ReportViewer2.LocalReport.SetParameters(data_other_equipment_charges)

        Dim data_paf_charges(0) As Microsoft.Reporting.WinForms.ReportParameter
        data_paf_charges(0) = New Microsoft.Reporting.WinForms.ReportParameter("data_paf_charges", FProgressReport.data_paf_charges.ToString)
        ReportViewer2.LocalReport.SetParameters(data_paf_charges)

        Dim TargetProjectRequest(0) As Microsoft.Reporting.WinForms.ReportParameter
        TargetProjectRequest(0) = New Microsoft.Reporting.WinForms.ReportParameter("TargetProjectRequest", FProgressReport.target_project_request.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(TargetProjectRequest)

        Dim TargetEquipmentRequest(0) As Microsoft.Reporting.WinForms.ReportParameter
        TargetEquipmentRequest(0) = New Microsoft.Reporting.WinForms.ReportParameter("TargetEquipmentRequest", FProgressReport.target_equipment_request.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(TargetEquipmentRequest)

        Dim TargetOtherRequest(0) As Microsoft.Reporting.WinForms.ReportParameter
        TargetOtherRequest(0) = New Microsoft.Reporting.WinForms.ReportParameter("TargetOtherRequest", FProgressReport.target_other_request.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(TargetOtherRequest)


        'Data

        Dim Data_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_MAJ", FProgressReport.lvl_major.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_MAJ)

        Dim Data_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_MIN", FProgressReport.lvl_minor.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_MIN)

        Dim Data_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_PM", FProgressReport.lvl_equipment_maintenance.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_PM)

        Dim Data_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_REP", FProgressReport.lvl_equipment_repair.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_REP)

        Dim Data_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_REH", FProgressReport.lvl_equipment_rehabilitation.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_REH)

        Dim Data_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_FUEL", FProgressReport.lvl_equipment_fuel.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_FUEL)

        Dim Data_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_TIRE", FProgressReport.lvl_equipment_tires.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_TIRE)

        Dim Data_ACM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_ACM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_ACM", FProgressReport.lvl_admin.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_ACM)

        Dim DataOcon(0) As Microsoft.Reporting.WinForms.ReportParameter
        DataOcon(0) = New Microsoft.Reporting.WinForms.ReportParameter("DataOcon", FProgressReport.lvl_other_construction_charges.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DataOcon)

        Dim DataOem(0) As Microsoft.Reporting.WinForms.ReportParameter
        DataOem(0) = New Microsoft.Reporting.WinForms.ReportParameter("DataOem", FProgressReport.lvl_other_equipment_charges.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DataOem)

        Dim DataPae(0) As Microsoft.Reporting.WinForms.ReportParameter
        DataPae(0) = New Microsoft.Reporting.WinForms.ReportParameter("DataPae", FProgressReport.lvlPlantEquipments.Items(0).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DataPae)


        'TOTAL

        Dim Total_Cost_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_MAJ", FProgressReport.lvl_Total_Amount.Items(0).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_MAJ)

        Dim Total_Cost_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_MIN", FProgressReport.lvl_Total_Amount.Items(1).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_MIN)

        Dim Total_Cost_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_PM", FProgressReport.lvl_Total_Amount.Items(2).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_PM)

        Dim Total_Cost_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_REP", FProgressReport.lvl_Total_Amount.Items(3).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_REP)

        Dim Total_Cost_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_REH", FProgressReport.lvl_Total_Amount.Items(4).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_REH)

        Dim Total_Cost_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_FUEL", FProgressReport.lvl_Total_Amount.Items(5).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_FUEL)

        Dim Total_Cost_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_TIRE", FProgressReport.lvl_Total_Amount.Items(6).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_TIRE)

        Dim Total_Cost_ACM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_ACM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_ACM", FProgressReport.lvl_Total_Amount.Items(7).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_ACM)

        Dim Total_Cost_Ocon(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_Ocon(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_Ocon", FProgressReport.lvl_Total_Amount.Items(8).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_Ocon)

        Dim Total_Cost_Oem(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_Oem(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_Oem", FProgressReport.lvl_Total_Amount.Items(9).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_Oem)

        Dim Total_Cost_Pae(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total_Cost_Pae(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total_Cost_Pae", FProgressReport.lvl_Total_Amount.Items(10).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Total_Cost_Pae)

        'SERVED ON

        Dim ServedOn_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_MAJ", FProgressReport.lvl_major.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_MAJ)

        Dim ServedOn_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_MIN", FProgressReport.lvl_minor.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_MIN)

        Dim ServedOn_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_PM", FProgressReport.lvl_equipment_maintenance.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_PM)

        Dim ServedOn_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_REP", FProgressReport.lvl_equipment_repair.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_REP)

        Dim ServedOn_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_REH", FProgressReport.lvl_equipment_rehabilitation.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_REH)

        Dim ServedOn_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_FUEL", FProgressReport.lvl_equipment_fuel.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_FUEL)

        Dim ServedOn_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_TIRE", FProgressReport.lvl_equipment_tires.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_TIRE)

        Dim ServedOn_ACM(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_ACM(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_ACM", FProgressReport.lvl_admin.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_ACM)

        Dim ServedOn_Ocon(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_Ocon(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_Ocon", FProgressReport.lvl_other_construction_charges.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_Ocon)

        Dim ServedOn_Oem(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_Oem(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_Oem", FProgressReport.lvl_other_equipment_charges.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_Oem)

        Dim ServedOn_Pae(0) As Microsoft.Reporting.WinForms.ReportParameter
        ServedOn_Pae(0) = New Microsoft.Reporting.WinForms.ReportParameter("ServedOn_Pae", FProgressReport.lvlPlantEquipments.Items(1).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(ServedOn_Pae)

        'PERCENTAGE

        Dim Percentage_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_MAJ", FProgressReport.lvl_major.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_MAJ)

        Dim Percentage_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_MIN", FProgressReport.lvl_minor.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_MIN)

        Dim Percentage_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_PM", FProgressReport.lvl_equipment_maintenance.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_PM)

        Dim Percentage_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_REP", FProgressReport.lvl_equipment_repair.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_REP)

        Dim Percentage_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_REH", FProgressReport.lvl_equipment_rehabilitation.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_REH)

        Dim Percentage_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_FUEL", FProgressReport.lvl_equipment_fuel.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_FUEL)

        Dim Percentage_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_TIRE", FProgressReport.lvl_equipment_tires.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_TIRE)

        Dim Percentage_ACM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_ACM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_ACM", FProgressReport.lvl_admin.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_ACM)

        Dim Percentage_Ocon(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_Ocon(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_Ocon", FProgressReport.lvl_other_construction_charges.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_Ocon)

        Dim Percentage_Oem(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_Oem(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_Oem", FProgressReport.lvl_other_equipment_charges.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_Oem)

        Dim Percentage_Pae(0) As Microsoft.Reporting.WinForms.ReportParameter
        Percentage_Pae(0) = New Microsoft.Reporting.WinForms.ReportParameter("Percentage_Pae", FProgressReport.lvlPlantEquipments.Items(1).SubItems(3).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Percentage_Pae)

        'Pending

        Dim Pending_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_MAJ", FProgressReport.lvl_major.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_MAJ)

        Dim Pending_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_MIN", FProgressReport.lvl_minor.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_MIN)

        Dim Pending_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_PM", FProgressReport.lvl_equipment_maintenance.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_PM)

        Dim Pending_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_REP", FProgressReport.lvl_equipment_repair.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_REP)

        Dim Pending_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_REH", FProgressReport.lvl_equipment_rehabilitation.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_REH)

        Dim Pending_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_FUEL", FProgressReport.lvl_equipment_fuel.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_FUEL)

        Dim Pending_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_TIRE", FProgressReport.lvl_equipment_tires.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_TIRE)

        Dim Pending_ADM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_ADM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_ADM", FProgressReport.lvl_admin.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_ADM)

        Dim Pending_Ocon(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_Ocon(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_Ocon", FProgressReport.lvl_other_construction_charges.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_Ocon)

        Dim Pending_Oem(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_Oem(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_Oem", FProgressReport.lvl_other_equipment_charges.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_Oem)

        Dim Pending_pae(0) As Microsoft.Reporting.WinForms.ReportParameter
        Pending_pae(0) = New Microsoft.Reporting.WinForms.ReportParameter("Pending_pae", FProgressReport.lvlPlantEquipments.Items(2).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Pending_pae)

        'Delivered Late

        Dim DeliverdLate_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_MAJ", FProgressReport.lvl_major.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_MAJ)

        Dim DeliverdLate_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_MIN", FProgressReport.lvl_minor.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_MIN)

        Dim DeliverdLate_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_PM", FProgressReport.lvl_equipment_maintenance.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_PM)

        Dim DeliverdLate_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_REP", FProgressReport.lvl_equipment_repair.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_REP)

        Dim DeliverdLate_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_REH", FProgressReport.lvl_equipment_rehabilitation.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_REH)

        Dim DeliverdLate_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_FUEL", FProgressReport.lvl_equipment_fuel.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_FUEL)

        Dim DeliverdLate_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_TIRE", FProgressReport.lvl_equipment_tires.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_TIRE)

        Dim DeliverdLate_ADM(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_ADM(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_ADM", FProgressReport.lvl_admin.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_ADM)

        Dim DeliverdLate_OCON(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_OCON(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_OCON", FProgressReport.lvl_other_construction_charges.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_OCON)

        Dim DeliverdLate_OEM(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_OEM(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_OEM", FProgressReport.lvl_other_equipment_charges.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_OEM)

        Dim DeliverdLate_Pae(0) As Microsoft.Reporting.WinForms.ReportParameter
        DeliverdLate_Pae(0) = New Microsoft.Reporting.WinForms.ReportParameter("DeliverdLate_Pae", FProgressReport.lvlPlantEquipments.Items(3).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(DeliverdLate_Pae)

        'Unserved

        Dim Unserved_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_MAJ", FProgressReport.lvl_major.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_MAJ)

        Dim Unserved_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_MIN", FProgressReport.lvl_minor.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_MIN)

        Dim Unserved_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_PM", FProgressReport.lvl_equipment_maintenance.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_PM)

        Dim Unserved_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_REP", FProgressReport.lvl_equipment_repair.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_REP)

        Dim Unserved_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_REH", FProgressReport.lvl_equipment_rehabilitation.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_REH)

        Dim Unserved_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_FUEL", FProgressReport.lvl_equipment_fuel.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_FUEL)

        Dim Unserved_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_TIRE", FProgressReport.lvl_equipment_tires.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_TIRE)

        Dim Unserved_ADM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_ADM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_ADM", FProgressReport.lvl_admin.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_ADM)

        Dim Unserved_OCON(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_OCON(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_OCON", FProgressReport.lvl_other_construction_charges.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_OCON)

        Dim Unserved_OEM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_OEM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_OEM", FProgressReport.lvl_other_equipment_charges.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_OEM)

        Dim Unserved_Pae(0) As Microsoft.Reporting.WinForms.ReportParameter
        Unserved_Pae(0) = New Microsoft.Reporting.WinForms.ReportParameter("Unserved_Pae", FProgressReport.lvlPlantEquipments.Items(4).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Unserved_Pae)

        'Defective_

        Dim Defective_MAJ(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_MAJ(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_MAJ", FProgressReport.lvl_major.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_MAJ)

        Dim Defective_MIN(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_MIN(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_MIN", FProgressReport.lvl_minor.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_MIN)

        Dim Defective_PM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_PM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_PM", FProgressReport.lvl_equipment_maintenance.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_PM)

        Dim Defective_REP(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_REP(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_REP", FProgressReport.lvl_equipment_repair.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_REP)

        Dim Defective_REH(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_REH(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_REH", FProgressReport.lvl_equipment_rehabilitation.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_REH)

        Dim Defective_FUEL(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_FUEL(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_FUEL", FProgressReport.lvl_equipment_fuel.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_FUEL)

        Dim Defective_TIRE(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_TIRE(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_TIRE", FProgressReport.lvl_equipment_tires.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_TIRE)

        Dim Defective_ADM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_ADM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_ADM", FProgressReport.lvl_admin.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_ADM)

        Dim Defective_OCON(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_OCON(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_OCON", FProgressReport.lvl_other_construction_charges.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_OCON)

        Dim Defective_OEM(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_OEM(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_OEM", FProgressReport.lvl_other_equipment_charges.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_OEM)

        Dim Defective_Pae(0) As Microsoft.Reporting.WinForms.ReportParameter
        Defective_Pae(0) = New Microsoft.Reporting.WinForms.ReportParameter("Defective_Pae", FProgressReport.lvlPlantEquipments.Items(5).SubItems(2).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Defective_Pae)

        '2nd table sa RDLC PROJECT'

        Dim Data_project_request(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_project_request(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_project_request", FProgressReport.lvl_project_request.Items(0).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_project_request)

        Dim Data_project_request_OnTime(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_project_request_OnTime(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_project_request_OnTime", FProgressReport.lvl_project_request.Items(1).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_project_request_OnTime)

        Dim Data_project_request_Late(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_project_request_Late(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_project_request_Late", FProgressReport.lvl_project_request.Items(2).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_project_request_Late)

        '2nd table sa RDLC EQUIPMENT'

        Dim Data_equipment_request(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_equipment_request(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_equipment_request", FProgressReport.lvl_equipment_request.Items(0).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_equipment_request)

        Dim Data_equipment_request_OnTime(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_equipment_request_OnTime(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_equipment_request_OnTime", FProgressReport.lvl_equipment_request.Items(1).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_equipment_request_OnTime)

        Dim Data_equipment_request_Late(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_equipment_request_Late(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_equipment_request_Late", FProgressReport.lvl_equipment_request.Items(2).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_equipment_request_Late)


        '2nd table sa RDLC OTHERS'

        Dim Data_others_request(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_others_request(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_others_request", FProgressReport.lvl_other_request.Items(0).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_others_request)

        Dim Data_others_request_OnTime(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_others_request_OnTime(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_others_request_OnTime", FProgressReport.lvl_other_request.Items(1).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_others_request_OnTime)

        Dim Data_others_request_Late(0) As Microsoft.Reporting.WinForms.ReportParameter
        Data_others_request_Late(0) = New Microsoft.Reporting.WinForms.ReportParameter("Data_others_request_Late", FProgressReport.lvl_other_request.Items(2).SubItems(1).Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Data_others_request_Late)

        Dim Target_paf(0) As Microsoft.Reporting.WinForms.ReportParameter
        Target_paf(0) = New Microsoft.Reporting.WinForms.ReportParameter("Target_paf", FProgressReport.txtTargetPaf.Text.ToString)
        ReportViewer2.LocalReport.SetParameters(Target_paf)


        Me.ReportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer2.RefreshReport()

    End Sub

End Class