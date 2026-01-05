<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAccidentReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gboxSupervisorConInfo = New System.Windows.Forms.GroupBox()
        Me.cmbDeptSectionName = New System.Windows.Forms.ComboBox()
        Me.lblDepartSectionName = New System.Windows.Forms.Label()
        Me.txtWitnessedBy = New System.Windows.Forms.TextBox()
        Me.lblWitnessedBy = New System.Windows.Forms.Label()
        Me.txtTimeOfReport = New System.Windows.Forms.TextBox()
        Me.lblTimeReport = New System.Windows.Forms.Label()
        Me.dtp_date_report_super = New System.Windows.Forms.DateTimePicker()
        Me.lblDateReport = New System.Windows.Forms.Label()
        Me.txtTimeIncident = New System.Windows.Forms.TextBox()
        Me.lblTimeIncident = New System.Windows.Forms.Label()
        Me.lblDateIncident = New System.Windows.Forms.Label()
        Me.DTPDateIncident = New System.Windows.Forms.DateTimePicker()
        Me.cmbDepartSectionValue = New System.Windows.Forms.ComboBox()
        Me.lblDepartment_section = New System.Windows.Forms.Label()
        Me.cmbJobSite = New System.Windows.Forms.ComboBox()
        Me.lblJobSite = New System.Windows.Forms.Label()
        Me.txtJobPosition = New System.Windows.Forms.TextBox()
        Me.lblJobPosition = New System.Windows.Forms.Label()
        Me.txtInvestigatorName = New System.Windows.Forms.TextBox()
        Me.LblInvestigatorName = New System.Windows.Forms.Label()
        Me.Panel_Supervisor_Contact_Info = New System.Windows.Forms.Panel()
        Me.lblSupervisorContactInfo = New System.Windows.Forms.Label()
        Me.gboxInjuredParty = New System.Windows.Forms.GroupBox()
        Me.txttreating_facility = New System.Windows.Forms.TextBox()
        Me.txtTreatment = New System.Windows.Forms.TextBox()
        Me.lblBodyInjured = New System.Windows.Forms.Label()
        Me.txtBodyPartInjured = New System.Windows.Forms.TextBox()
        Me.lblTreatment = New System.Windows.Forms.Label()
        Me.txtNature_illness_injured = New System.Windows.Forms.TextBox()
        Me.lblNature_of_illness = New System.Windows.Forms.Label()
        Me.lblNameAddTreatingFal = New System.Windows.Forms.Label()
        Me.txtTreatmentCost = New System.Windows.Forms.TextBox()
        Me.lblTreatmentCost = New System.Windows.Forms.Label()
        Me.txtContactInformation = New System.Windows.Forms.TextBox()
        Me.lblContactInformation = New System.Windows.Forms.Label()
        Me.lblInjuredJobPosition = New System.Windows.Forms.Label()
        Me.txtInjuredJobPosition = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtInjuredPartyName = New System.Windows.Forms.TextBox()
        Me.lblInjuredPartyName = New System.Windows.Forms.Label()
        Me.Panel_InjuredParty = New System.Windows.Forms.Panel()
        Me.lblInjuredParty = New System.Windows.Forms.Label()
        Me.gboxEqui_Property_Damage = New System.Windows.Forms.GroupBox()
        Me.lblBreakDownDays = New System.Windows.Forms.Label()
        Me.lblAppCostDamage = New System.Windows.Forms.Label()
        Me.txtAppCostDamage = New System.Windows.Forms.TextBox()
        Me.txtObjectInflictingDamage = New System.Windows.Forms.TextBox()
        Me.lblObjectInflictingDamage = New System.Windows.Forms.Label()
        Me.lblNatureDamage = New System.Windows.Forms.Label()
        Me.txtNatureDamage = New System.Windows.Forms.TextBox()
        Me.lblNameDamage = New System.Windows.Forms.Label()
        Me.cmb_listProperty_Equi_Material_Damaged = New System.Windows.Forms.ComboBox()
        Me.cmbCategoryListPropertyDamage = New System.Windows.Forms.ComboBox()
        Me.txtbreakdown_day = New System.Windows.Forms.TextBox()
        Me.lblListProperty = New System.Windows.Forms.Label()
        Me.Panel_Equi_Property_Damage = New System.Windows.Forms.Panel()
        Me.lblEqui_Property_Damage = New System.Windows.Forms.Label()
        Me.txt_prepared_by = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSave_next = New System.Windows.Forms.Button()
        Me.txtAr_no = New System.Windows.Forms.TextBox()
        Me.lblAR_no = New System.Windows.Forms.Label()
        Me.chkboxCloseCall_NearHit = New System.Windows.Forms.CheckBox()
        Me.chkboxPropertyDamage = New System.Windows.Forms.CheckBox()
        Me.chkboxEquip_damaged = New System.Windows.Forms.CheckBox()
        Me.chkboxInjury = New System.Windows.Forms.CheckBox()
        Me.gboxFollow_up_progress = New System.Windows.Forms.GroupBox()
        Me.dtp_date_close_out = New System.Windows.Forms.DateTimePicker()
        Me.lblDate_close_out = New System.Windows.Forms.Label()
        Me.txtClosed_out_by = New System.Windows.Forms.TextBox()
        Me.lblClose_out_remarks = New System.Windows.Forms.Label()
        Me.lblClosed_out_by = New System.Windows.Forms.Label()
        Me.rich_text_Closed_out_remarks = New System.Windows.Forms.RichTextBox()
        Me.txtFollow_up_by = New System.Windows.Forms.TextBox()
        Me.lblDate_follow_up = New System.Windows.Forms.Label()
        Me.dtp_date_follow_up = New System.Windows.Forms.DateTimePicker()
        Me.lblFollow_up_by = New System.Windows.Forms.Label()
        Me.lblFollow_up_progress = New System.Windows.Forms.Label()
        Me.richText_Follow_up_Progress = New System.Windows.Forms.RichTextBox()
        Me.gboxCorrectiveActions = New System.Windows.Forms.GroupBox()
        Me.dtp_date_reviewed = New System.Windows.Forms.DateTimePicker()
        Me.lblDate_Reviewed = New System.Windows.Forms.Label()
        Me.txtReviewed_by = New System.Windows.Forms.TextBox()
        Me.lblReviewed_by = New System.Windows.Forms.Label()
        Me.dtpApproved_by = New System.Windows.Forms.DateTimePicker()
        Me.lblDate_Approved = New System.Windows.Forms.Label()
        Me.txtApporved_by = New System.Windows.Forms.TextBox()
        Me.lblApproved_by = New System.Windows.Forms.Label()
        Me.dtp_Date_Prepared = New System.Windows.Forms.DateTimePicker()
        Me.lblDate_prepared = New System.Windows.Forms.Label()
        Me.lblPrepared_by = New System.Windows.Forms.Label()
        Me.txtTimeFrame = New System.Windows.Forms.RichTextBox()
        Me.lblTimeframe = New System.Windows.Forms.Label()
        Me.lblResponsibility = New System.Windows.Forms.Label()
        Me.txtResponsibility = New System.Windows.Forms.RichTextBox()
        Me.txtActionPlan = New System.Windows.Forms.RichTextBox()
        Me.lblActionPlan = New System.Windows.Forms.Label()
        Me.Panel_CorrectiveActions = New System.Windows.Forms.Panel()
        Me.lblCorrectiveActions = New System.Windows.Forms.Label()
        Me.gboxIncidentDesc = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTxt_incident_desc = New System.Windows.Forms.RichTextBox()
        Me.Panel_IncidentDesc = New System.Windows.Forms.Panel()
        Me.lblIncidentDesc = New System.Windows.Forms.Label()
        Me.lblTitleAccidentReport = New System.Windows.Forms.Label()
        Me.lblUpdate_sup_info_id = New System.Windows.Forms.Label()
        Me.lblInjured_party_id = New System.Windows.Forms.Label()
        Me.lblEqui_pro_dam_id = New System.Windows.Forms.Label()
        Me.lblAcc_report_id = New System.Windows.Forms.Label()
        Me.lbl_driver = New System.Windows.Forms.Label()
        Me.txt_driver_name = New System.Windows.Forms.TextBox()
        Me.gboxSupervisorConInfo.SuspendLayout()
        Me.Panel_Supervisor_Contact_Info.SuspendLayout()
        Me.gboxInjuredParty.SuspendLayout()
        Me.Panel_InjuredParty.SuspendLayout()
        Me.gboxEqui_Property_Damage.SuspendLayout()
        Me.Panel_Equi_Property_Damage.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gboxFollow_up_progress.SuspendLayout()
        Me.gboxCorrectiveActions.SuspendLayout()
        Me.Panel_CorrectiveActions.SuspendLayout()
        Me.gboxIncidentDesc.SuspendLayout()
        Me.Panel_IncidentDesc.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboxSupervisorConInfo
        '
        Me.gboxSupervisorConInfo.BackColor = System.Drawing.Color.Transparent
        Me.gboxSupervisorConInfo.Controls.Add(Me.cmbDeptSectionName)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblDepartSectionName)
        Me.gboxSupervisorConInfo.Controls.Add(Me.txtWitnessedBy)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblWitnessedBy)
        Me.gboxSupervisorConInfo.Controls.Add(Me.txtTimeOfReport)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblTimeReport)
        Me.gboxSupervisorConInfo.Controls.Add(Me.dtp_date_report_super)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblDateReport)
        Me.gboxSupervisorConInfo.Controls.Add(Me.txtTimeIncident)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblTimeIncident)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblDateIncident)
        Me.gboxSupervisorConInfo.Controls.Add(Me.DTPDateIncident)
        Me.gboxSupervisorConInfo.Controls.Add(Me.cmbDepartSectionValue)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblDepartment_section)
        Me.gboxSupervisorConInfo.Controls.Add(Me.cmbJobSite)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblJobSite)
        Me.gboxSupervisorConInfo.Controls.Add(Me.txtJobPosition)
        Me.gboxSupervisorConInfo.Controls.Add(Me.lblJobPosition)
        Me.gboxSupervisorConInfo.Controls.Add(Me.txtInvestigatorName)
        Me.gboxSupervisorConInfo.Controls.Add(Me.LblInvestigatorName)
        Me.gboxSupervisorConInfo.Controls.Add(Me.Panel_Supervisor_Contact_Info)
        Me.gboxSupervisorConInfo.Location = New System.Drawing.Point(6, 25)
        Me.gboxSupervisorConInfo.Name = "gboxSupervisorConInfo"
        Me.gboxSupervisorConInfo.Size = New System.Drawing.Size(487, 316)
        Me.gboxSupervisorConInfo.TabIndex = 1
        Me.gboxSupervisorConInfo.TabStop = False
        '
        'cmbDeptSectionName
        '
        Me.cmbDeptSectionName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbDeptSectionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDeptSectionName.FormattingEnabled = True
        Me.cmbDeptSectionName.Location = New System.Drawing.Point(8, 224)
        Me.cmbDeptSectionName.Name = "cmbDeptSectionName"
        Me.cmbDeptSectionName.Size = New System.Drawing.Size(232, 24)
        Me.cmbDeptSectionName.TabIndex = 5
        '
        'lblDepartSectionName
        '
        Me.lblDepartSectionName.AutoSize = True
        Me.lblDepartSectionName.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartSectionName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartSectionName.ForeColor = System.Drawing.Color.White
        Me.lblDepartSectionName.Location = New System.Drawing.Point(9, 206)
        Me.lblDepartSectionName.Name = "lblDepartSectionName"
        Me.lblDepartSectionName.Size = New System.Drawing.Size(159, 15)
        Me.lblDepartSectionName.TabIndex = 377
        Me.lblDepartSectionName.Text = "Department/Section Name:"
        '
        'txtWitnessedBy
        '
        Me.txtWitnessedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWitnessedBy.Location = New System.Drawing.Point(250, 277)
        Me.txtWitnessedBy.Name = "txtWitnessedBy"
        Me.txtWitnessedBy.Size = New System.Drawing.Size(230, 24)
        Me.txtWitnessedBy.TabIndex = 11
        '
        'lblWitnessedBy
        '
        Me.lblWitnessedBy.AutoSize = True
        Me.lblWitnessedBy.BackColor = System.Drawing.Color.Transparent
        Me.lblWitnessedBy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWitnessedBy.ForeColor = System.Drawing.Color.White
        Me.lblWitnessedBy.Location = New System.Drawing.Point(253, 259)
        Me.lblWitnessedBy.Name = "lblWitnessedBy"
        Me.lblWitnessedBy.Size = New System.Drawing.Size(87, 15)
        Me.lblWitnessedBy.TabIndex = 375
        Me.lblWitnessedBy.Text = "Witnessed by:"
        '
        'txtTimeOfReport
        '
        Me.txtTimeOfReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeOfReport.Location = New System.Drawing.Point(250, 224)
        Me.txtTimeOfReport.Name = "txtTimeOfReport"
        Me.txtTimeOfReport.Size = New System.Drawing.Size(230, 24)
        Me.txtTimeOfReport.TabIndex = 10
        '
        'lblTimeReport
        '
        Me.lblTimeReport.AutoSize = True
        Me.lblTimeReport.BackColor = System.Drawing.Color.Transparent
        Me.lblTimeReport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeReport.ForeColor = System.Drawing.Color.White
        Me.lblTimeReport.Location = New System.Drawing.Point(247, 206)
        Me.lblTimeReport.Name = "lblTimeReport"
        Me.lblTimeReport.Size = New System.Drawing.Size(93, 15)
        Me.lblTimeReport.TabIndex = 373
        Me.lblTimeReport.Text = "Time of Report:"
        '
        'dtp_date_report_super
        '
        Me.dtp_date_report_super.CustomFormat = ""
        Me.dtp_date_report_super.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_date_report_super.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_date_report_super.Location = New System.Drawing.Point(250, 173)
        Me.dtp_date_report_super.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtp_date_report_super.Name = "dtp_date_report_super"
        Me.dtp_date_report_super.Size = New System.Drawing.Size(230, 24)
        Me.dtp_date_report_super.TabIndex = 9
        '
        'lblDateReport
        '
        Me.lblDateReport.AutoSize = True
        Me.lblDateReport.BackColor = System.Drawing.Color.Transparent
        Me.lblDateReport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateReport.ForeColor = System.Drawing.Color.White
        Me.lblDateReport.Location = New System.Drawing.Point(247, 155)
        Me.lblDateReport.Name = "lblDateReport"
        Me.lblDateReport.Size = New System.Drawing.Size(91, 15)
        Me.lblDateReport.TabIndex = 371
        Me.lblDateReport.Text = "Date of Report:"
        '
        'txtTimeIncident
        '
        Me.txtTimeIncident.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeIncident.Location = New System.Drawing.Point(248, 123)
        Me.txtTimeIncident.Name = "txtTimeIncident"
        Me.txtTimeIncident.Size = New System.Drawing.Size(232, 24)
        Me.txtTimeIncident.TabIndex = 8
        '
        'lblTimeIncident
        '
        Me.lblTimeIncident.AutoSize = True
        Me.lblTimeIncident.BackColor = System.Drawing.Color.Transparent
        Me.lblTimeIncident.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeIncident.ForeColor = System.Drawing.Color.White
        Me.lblTimeIncident.Location = New System.Drawing.Point(247, 105)
        Me.lblTimeIncident.Name = "lblTimeIncident"
        Me.lblTimeIncident.Size = New System.Drawing.Size(100, 15)
        Me.lblTimeIncident.TabIndex = 369
        Me.lblTimeIncident.Text = "Time of Incident:"
        '
        'lblDateIncident
        '
        Me.lblDateIncident.AutoSize = True
        Me.lblDateIncident.BackColor = System.Drawing.Color.Transparent
        Me.lblDateIncident.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateIncident.ForeColor = System.Drawing.Color.White
        Me.lblDateIncident.Location = New System.Drawing.Point(247, 57)
        Me.lblDateIncident.Name = "lblDateIncident"
        Me.lblDateIncident.Size = New System.Drawing.Size(98, 15)
        Me.lblDateIncident.TabIndex = 368
        Me.lblDateIncident.Text = "Date of Incident:"
        '
        'DTPDateIncident
        '
        Me.DTPDateIncident.CustomFormat = ""
        Me.DTPDateIncident.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPDateIncident.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPDateIncident.Location = New System.Drawing.Point(248, 75)
        Me.DTPDateIncident.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPDateIncident.Name = "DTPDateIncident"
        Me.DTPDateIncident.Size = New System.Drawing.Size(232, 24)
        Me.DTPDateIncident.TabIndex = 7
        '
        'cmbDepartSectionValue
        '
        Me.cmbDepartSectionValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbDepartSectionValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepartSectionValue.FormattingEnabled = True
        Me.cmbDepartSectionValue.Location = New System.Drawing.Point(7, 277)
        Me.cmbDepartSectionValue.Name = "cmbDepartSectionValue"
        Me.cmbDepartSectionValue.Size = New System.Drawing.Size(233, 24)
        Me.cmbDepartSectionValue.TabIndex = 6
        '
        'lblDepartment_section
        '
        Me.lblDepartment_section.AutoSize = True
        Me.lblDepartment_section.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartment_section.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment_section.ForeColor = System.Drawing.Color.White
        Me.lblDepartment_section.Location = New System.Drawing.Point(10, 259)
        Me.lblDepartment_section.Name = "lblDepartment_section"
        Me.lblDepartment_section.Size = New System.Drawing.Size(123, 15)
        Me.lblDepartment_section.TabIndex = 365
        Me.lblDepartment_section.Text = "Department/Section:"
        '
        'cmbJobSite
        '
        Me.cmbJobSite.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbJobSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJobSite.FormattingEnabled = True
        Me.cmbJobSite.Location = New System.Drawing.Point(8, 173)
        Me.cmbJobSite.Name = "cmbJobSite"
        Me.cmbJobSite.Size = New System.Drawing.Size(232, 24)
        Me.cmbJobSite.TabIndex = 4
        '
        'lblJobSite
        '
        Me.lblJobSite.AutoSize = True
        Me.lblJobSite.BackColor = System.Drawing.Color.Transparent
        Me.lblJobSite.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobSite.ForeColor = System.Drawing.Color.White
        Me.lblJobSite.Location = New System.Drawing.Point(15, 155)
        Me.lblJobSite.Name = "lblJobSite"
        Me.lblJobSite.Size = New System.Drawing.Size(56, 15)
        Me.lblJobSite.TabIndex = 363
        Me.lblJobSite.Text = "Job Site:"
        '
        'txtJobPosition
        '
        Me.txtJobPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobPosition.Location = New System.Drawing.Point(8, 123)
        Me.txtJobPosition.Name = "txtJobPosition"
        Me.txtJobPosition.Size = New System.Drawing.Size(232, 24)
        Me.txtJobPosition.TabIndex = 3
        '
        'lblJobPosition
        '
        Me.lblJobPosition.AutoSize = True
        Me.lblJobPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblJobPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobPosition.ForeColor = System.Drawing.Color.White
        Me.lblJobPosition.Location = New System.Drawing.Point(8, 105)
        Me.lblJobPosition.Name = "lblJobPosition"
        Me.lblJobPosition.Size = New System.Drawing.Size(80, 15)
        Me.lblJobPosition.TabIndex = 361
        Me.lblJobPosition.Text = "Job Position:"
        '
        'txtInvestigatorName
        '
        Me.txtInvestigatorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvestigatorName.Location = New System.Drawing.Point(7, 75)
        Me.txtInvestigatorName.Name = "txtInvestigatorName"
        Me.txtInvestigatorName.Size = New System.Drawing.Size(233, 24)
        Me.txtInvestigatorName.TabIndex = 2
        '
        'LblInvestigatorName
        '
        Me.LblInvestigatorName.AutoSize = True
        Me.LblInvestigatorName.BackColor = System.Drawing.Color.Transparent
        Me.LblInvestigatorName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInvestigatorName.ForeColor = System.Drawing.Color.White
        Me.LblInvestigatorName.Location = New System.Drawing.Point(4, 57)
        Me.LblInvestigatorName.Name = "LblInvestigatorName"
        Me.LblInvestigatorName.Size = New System.Drawing.Size(236, 15)
        Me.LblInvestigatorName.TabIndex = 359
        Me.LblInvestigatorName.Text = "Reporting Supervisor/Investigator Name:"
        '
        'Panel_Supervisor_Contact_Info
        '
        Me.Panel_Supervisor_Contact_Info.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line
        Me.Panel_Supervisor_Contact_Info.Controls.Add(Me.lblSupervisorContactInfo)
        Me.Panel_Supervisor_Contact_Info.Location = New System.Drawing.Point(2, 9)
        Me.Panel_Supervisor_Contact_Info.Name = "Panel_Supervisor_Contact_Info"
        Me.Panel_Supervisor_Contact_Info.Size = New System.Drawing.Size(484, 41)
        Me.Panel_Supervisor_Contact_Info.TabIndex = 1
        '
        'lblSupervisorContactInfo
        '
        Me.lblSupervisorContactInfo.AutoSize = True
        Me.lblSupervisorContactInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblSupervisorContactInfo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupervisorContactInfo.ForeColor = System.Drawing.Color.White
        Me.lblSupervisorContactInfo.Location = New System.Drawing.Point(123, 14)
        Me.lblSupervisorContactInfo.Name = "lblSupervisorContactInfo"
        Me.lblSupervisorContactInfo.Size = New System.Drawing.Size(269, 16)
        Me.lblSupervisorContactInfo.TabIndex = 377
        Me.lblSupervisorContactInfo.Text = "SUPERVISOR CONTACT INFORMATION"
        '
        'gboxInjuredParty
        '
        Me.gboxInjuredParty.BackColor = System.Drawing.Color.Transparent
        Me.gboxInjuredParty.Controls.Add(Me.txttreating_facility)
        Me.gboxInjuredParty.Controls.Add(Me.txtTreatment)
        Me.gboxInjuredParty.Controls.Add(Me.lblBodyInjured)
        Me.gboxInjuredParty.Controls.Add(Me.txtBodyPartInjured)
        Me.gboxInjuredParty.Controls.Add(Me.lblTreatment)
        Me.gboxInjuredParty.Controls.Add(Me.txtNature_illness_injured)
        Me.gboxInjuredParty.Controls.Add(Me.lblNature_of_illness)
        Me.gboxInjuredParty.Controls.Add(Me.lblNameAddTreatingFal)
        Me.gboxInjuredParty.Controls.Add(Me.txtTreatmentCost)
        Me.gboxInjuredParty.Controls.Add(Me.lblTreatmentCost)
        Me.gboxInjuredParty.Controls.Add(Me.txtContactInformation)
        Me.gboxInjuredParty.Controls.Add(Me.lblContactInformation)
        Me.gboxInjuredParty.Controls.Add(Me.lblInjuredJobPosition)
        Me.gboxInjuredParty.Controls.Add(Me.txtInjuredJobPosition)
        Me.gboxInjuredParty.Controls.Add(Me.lblGender)
        Me.gboxInjuredParty.Controls.Add(Me.txtGender)
        Me.gboxInjuredParty.Controls.Add(Me.txtAge)
        Me.gboxInjuredParty.Controls.Add(Me.lblAge)
        Me.gboxInjuredParty.Controls.Add(Me.txtInjuredPartyName)
        Me.gboxInjuredParty.Controls.Add(Me.lblInjuredPartyName)
        Me.gboxInjuredParty.Controls.Add(Me.Panel_InjuredParty)
        Me.gboxInjuredParty.Location = New System.Drawing.Point(499, 25)
        Me.gboxInjuredParty.Name = "gboxInjuredParty"
        Me.gboxInjuredParty.Size = New System.Drawing.Size(494, 316)
        Me.gboxInjuredParty.TabIndex = 45
        Me.gboxInjuredParty.TabStop = False
        '
        'txttreating_facility
        '
        Me.txttreating_facility.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttreating_facility.Location = New System.Drawing.Point(249, 173)
        Me.txttreating_facility.Name = "txttreating_facility"
        Me.txttreating_facility.Size = New System.Drawing.Size(234, 24)
        Me.txttreating_facility.TabIndex = 42
        Me.txttreating_facility.Text = "n/a"
        '
        'txtTreatment
        '
        Me.txtTreatment.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTreatment.Location = New System.Drawing.Point(249, 224)
        Me.txtTreatment.Name = "txtTreatment"
        Me.txtTreatment.Size = New System.Drawing.Size(234, 24)
        Me.txtTreatment.TabIndex = 43
        Me.txtTreatment.Text = "n/a"
        '
        'lblBodyInjured
        '
        Me.lblBodyInjured.AutoSize = True
        Me.lblBodyInjured.BackColor = System.Drawing.Color.Transparent
        Me.lblBodyInjured.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBodyInjured.ForeColor = System.Drawing.Color.White
        Me.lblBodyInjured.Location = New System.Drawing.Point(246, 57)
        Me.lblBodyInjured.Name = "lblBodyInjured"
        Me.lblBodyInjured.Size = New System.Drawing.Size(125, 15)
        Me.lblBodyInjured.TabIndex = 481
        Me.lblBodyInjured.Text = "Body Part Injured (s):"
        '
        'txtBodyPartInjured
        '
        Me.txtBodyPartInjured.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBodyPartInjured.Location = New System.Drawing.Point(249, 75)
        Me.txtBodyPartInjured.Name = "txtBodyPartInjured"
        Me.txtBodyPartInjured.Size = New System.Drawing.Size(234, 24)
        Me.txtBodyPartInjured.TabIndex = 40
        Me.txtBodyPartInjured.Text = "n/a"
        '
        'lblTreatment
        '
        Me.lblTreatment.AutoSize = True
        Me.lblTreatment.BackColor = System.Drawing.Color.Transparent
        Me.lblTreatment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTreatment.ForeColor = System.Drawing.Color.White
        Me.lblTreatment.Location = New System.Drawing.Point(249, 206)
        Me.lblTreatment.Name = "lblTreatment"
        Me.lblTreatment.Size = New System.Drawing.Size(68, 15)
        Me.lblTreatment.TabIndex = 485
        Me.lblTreatment.Text = "Treatment:"
        '
        'txtNature_illness_injured
        '
        Me.txtNature_illness_injured.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNature_illness_injured.Location = New System.Drawing.Point(249, 121)
        Me.txtNature_illness_injured.Name = "txtNature_illness_injured"
        Me.txtNature_illness_injured.Size = New System.Drawing.Size(234, 24)
        Me.txtNature_illness_injured.TabIndex = 41
        Me.txtNature_illness_injured.Text = "n/a"
        '
        'lblNature_of_illness
        '
        Me.lblNature_of_illness.AutoSize = True
        Me.lblNature_of_illness.BackColor = System.Drawing.Color.Transparent
        Me.lblNature_of_illness.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNature_of_illness.ForeColor = System.Drawing.Color.White
        Me.lblNature_of_illness.Location = New System.Drawing.Point(249, 103)
        Me.lblNature_of_illness.Name = "lblNature_of_illness"
        Me.lblNature_of_illness.Size = New System.Drawing.Size(142, 15)
        Me.lblNature_of_illness.TabIndex = 483
        Me.lblNature_of_illness.Text = "Nature of Injury / illness:"
        '
        'lblNameAddTreatingFal
        '
        Me.lblNameAddTreatingFal.AutoSize = True
        Me.lblNameAddTreatingFal.BackColor = System.Drawing.Color.Transparent
        Me.lblNameAddTreatingFal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameAddTreatingFal.ForeColor = System.Drawing.Color.White
        Me.lblNameAddTreatingFal.Location = New System.Drawing.Point(249, 155)
        Me.lblNameAddTreatingFal.Name = "lblNameAddTreatingFal"
        Me.lblNameAddTreatingFal.Size = New System.Drawing.Size(221, 15)
        Me.lblNameAddTreatingFal.TabIndex = 480
        Me.lblNameAddTreatingFal.Text = "Name & Address of Treating Dr. / facility"
        '
        'txtTreatmentCost
        '
        Me.txtTreatmentCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTreatmentCost.Location = New System.Drawing.Point(249, 277)
        Me.txtTreatmentCost.Name = "txtTreatmentCost"
        Me.txtTreatmentCost.Size = New System.Drawing.Size(234, 24)
        Me.txtTreatmentCost.TabIndex = 44
        Me.txtTreatmentCost.Text = "0"
        '
        'lblTreatmentCost
        '
        Me.lblTreatmentCost.AutoSize = True
        Me.lblTreatmentCost.BackColor = System.Drawing.Color.Transparent
        Me.lblTreatmentCost.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTreatmentCost.ForeColor = System.Drawing.Color.White
        Me.lblTreatmentCost.Location = New System.Drawing.Point(249, 257)
        Me.lblTreatmentCost.Name = "lblTreatmentCost"
        Me.lblTreatmentCost.Size = New System.Drawing.Size(97, 15)
        Me.lblTreatmentCost.TabIndex = 478
        Me.lblTreatmentCost.Text = "Treatment Cost:"
        '
        'txtContactInformation
        '
        Me.txtContactInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactInformation.Location = New System.Drawing.Point(7, 277)
        Me.txtContactInformation.Name = "txtContactInformation"
        Me.txtContactInformation.Size = New System.Drawing.Size(234, 24)
        Me.txtContactInformation.TabIndex = 39
        Me.txtContactInformation.Text = "0"
        '
        'lblContactInformation
        '
        Me.lblContactInformation.AutoSize = True
        Me.lblContactInformation.BackColor = System.Drawing.Color.Transparent
        Me.lblContactInformation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactInformation.ForeColor = System.Drawing.Color.White
        Me.lblContactInformation.Location = New System.Drawing.Point(7, 259)
        Me.lblContactInformation.Name = "lblContactInformation"
        Me.lblContactInformation.Size = New System.Drawing.Size(122, 15)
        Me.lblContactInformation.TabIndex = 382
        Me.lblContactInformation.Text = "Contact Information:"
        '
        'lblInjuredJobPosition
        '
        Me.lblInjuredJobPosition.AutoSize = True
        Me.lblInjuredJobPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblInjuredJobPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInjuredJobPosition.ForeColor = System.Drawing.Color.White
        Me.lblInjuredJobPosition.Location = New System.Drawing.Point(7, 205)
        Me.lblInjuredJobPosition.Name = "lblInjuredJobPosition"
        Me.lblInjuredJobPosition.Size = New System.Drawing.Size(80, 15)
        Me.lblInjuredJobPosition.TabIndex = 381
        Me.lblInjuredJobPosition.Text = "Job Position:"
        '
        'txtInjuredJobPosition
        '
        Me.txtInjuredJobPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInjuredJobPosition.Location = New System.Drawing.Point(8, 222)
        Me.txtInjuredJobPosition.Name = "txtInjuredJobPosition"
        Me.txtInjuredJobPosition.Size = New System.Drawing.Size(233, 24)
        Me.txtInjuredJobPosition.TabIndex = 38
        Me.txtInjuredJobPosition.Text = "n/a"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.BackColor = System.Drawing.Color.Transparent
        Me.lblGender.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.Color.White
        Me.lblGender.Location = New System.Drawing.Point(7, 154)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(51, 15)
        Me.lblGender.TabIndex = 380
        Me.lblGender.Text = "Gender:"
        '
        'txtGender
        '
        Me.txtGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGender.Location = New System.Drawing.Point(8, 172)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Size = New System.Drawing.Size(232, 24)
        Me.txtGender.TabIndex = 37
        Me.txtGender.Text = "n/a"
        '
        'txtAge
        '
        Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.Location = New System.Drawing.Point(9, 121)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(232, 24)
        Me.txtAge.TabIndex = 36
        Me.txtAge.Text = "0"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.BackColor = System.Drawing.Color.Transparent
        Me.lblAge.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.Color.White
        Me.lblAge.Location = New System.Drawing.Point(7, 103)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(32, 15)
        Me.lblAge.TabIndex = 379
        Me.lblAge.Text = "Age:"
        '
        'txtInjuredPartyName
        '
        Me.txtInjuredPartyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInjuredPartyName.Location = New System.Drawing.Point(8, 75)
        Me.txtInjuredPartyName.Name = "txtInjuredPartyName"
        Me.txtInjuredPartyName.Size = New System.Drawing.Size(232, 24)
        Me.txtInjuredPartyName.TabIndex = 35
        Me.txtInjuredPartyName.Text = "n/a"
        '
        'lblInjuredPartyName
        '
        Me.lblInjuredPartyName.AutoSize = True
        Me.lblInjuredPartyName.BackColor = System.Drawing.Color.Transparent
        Me.lblInjuredPartyName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInjuredPartyName.ForeColor = System.Drawing.Color.White
        Me.lblInjuredPartyName.Location = New System.Drawing.Point(7, 57)
        Me.lblInjuredPartyName.Name = "lblInjuredPartyName"
        Me.lblInjuredPartyName.Size = New System.Drawing.Size(128, 15)
        Me.lblInjuredPartyName.TabIndex = 377
        Me.lblInjuredPartyName.Text = "Injured Party's Name:"
        '
        'Panel_InjuredParty
        '
        Me.Panel_InjuredParty.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line
        Me.Panel_InjuredParty.Controls.Add(Me.lblInjuredParty)
        Me.Panel_InjuredParty.Location = New System.Drawing.Point(3, 9)
        Me.Panel_InjuredParty.Name = "Panel_InjuredParty"
        Me.Panel_InjuredParty.Size = New System.Drawing.Size(489, 38)
        Me.Panel_InjuredParty.TabIndex = 378
        '
        'lblInjuredParty
        '
        Me.lblInjuredParty.AutoSize = True
        Me.lblInjuredParty.BackColor = System.Drawing.Color.Transparent
        Me.lblInjuredParty.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInjuredParty.ForeColor = System.Drawing.Color.White
        Me.lblInjuredParty.Location = New System.Drawing.Point(181, 12)
        Me.lblInjuredParty.Name = "lblInjuredParty"
        Me.lblInjuredParty.Size = New System.Drawing.Size(118, 16)
        Me.lblInjuredParty.TabIndex = 377
        Me.lblInjuredParty.Text = "INJURED PARTY"
        '
        'gboxEqui_Property_Damage
        '
        Me.gboxEqui_Property_Damage.BackColor = System.Drawing.Color.Transparent
        Me.gboxEqui_Property_Damage.Controls.Add(Me.txt_driver_name)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.lbl_driver)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.lblBreakDownDays)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.lblAppCostDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.txtAppCostDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.txtObjectInflictingDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.lblObjectInflictingDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.lblNatureDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.txtNatureDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.lblNameDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.cmb_listProperty_Equi_Material_Damaged)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.cmbCategoryListPropertyDamage)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.txtbreakdown_day)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.lblListProperty)
        Me.gboxEqui_Property_Damage.Controls.Add(Me.Panel_Equi_Property_Damage)
        Me.gboxEqui_Property_Damage.Location = New System.Drawing.Point(6, 338)
        Me.gboxEqui_Property_Damage.Name = "gboxEqui_Property_Damage"
        Me.gboxEqui_Property_Damage.Size = New System.Drawing.Size(487, 228)
        Me.gboxEqui_Property_Damage.TabIndex = 12
        Me.gboxEqui_Property_Damage.TabStop = False
        '
        'lblBreakDownDays
        '
        Me.lblBreakDownDays.AutoSize = True
        Me.lblBreakDownDays.BackColor = System.Drawing.Color.Transparent
        Me.lblBreakDownDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBreakDownDays.ForeColor = System.Drawing.Color.White
        Me.lblBreakDownDays.Location = New System.Drawing.Point(248, 147)
        Me.lblBreakDownDays.Name = "lblBreakDownDays"
        Me.lblBreakDownDays.Size = New System.Drawing.Size(110, 15)
        Me.lblBreakDownDays.TabIndex = 491
        Me.lblBreakDownDays.Text = "Break Down Days:"
        '
        'lblAppCostDamage
        '
        Me.lblAppCostDamage.AutoSize = True
        Me.lblAppCostDamage.BackColor = System.Drawing.Color.Transparent
        Me.lblAppCostDamage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppCostDamage.ForeColor = System.Drawing.Color.White
        Me.lblAppCostDamage.Location = New System.Drawing.Point(249, 97)
        Me.lblAppCostDamage.Name = "lblAppCostDamage"
        Me.lblAppCostDamage.Size = New System.Drawing.Size(174, 15)
        Me.lblAppCostDamage.TabIndex = 490
        Me.lblAppCostDamage.Text = "Approximate cost of damage:"
        '
        'txtAppCostDamage
        '
        Me.txtAppCostDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAppCostDamage.Location = New System.Drawing.Point(248, 115)
        Me.txtAppCostDamage.Name = "txtAppCostDamage"
        Me.txtAppCostDamage.Size = New System.Drawing.Size(232, 24)
        Me.txtAppCostDamage.TabIndex = 17
        '
        'txtObjectInflictingDamage
        '
        Me.txtObjectInflictingDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObjectInflictingDamage.Location = New System.Drawing.Point(248, 70)
        Me.txtObjectInflictingDamage.Name = "txtObjectInflictingDamage"
        Me.txtObjectInflictingDamage.Size = New System.Drawing.Size(232, 24)
        Me.txtObjectInflictingDamage.TabIndex = 16
        '
        'lblObjectInflictingDamage
        '
        Me.lblObjectInflictingDamage.AutoSize = True
        Me.lblObjectInflictingDamage.BackColor = System.Drawing.Color.Transparent
        Me.lblObjectInflictingDamage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObjectInflictingDamage.ForeColor = System.Drawing.Color.White
        Me.lblObjectInflictingDamage.Location = New System.Drawing.Point(247, 52)
        Me.lblObjectInflictingDamage.Name = "lblObjectInflictingDamage"
        Me.lblObjectInflictingDamage.Size = New System.Drawing.Size(218, 15)
        Me.lblObjectInflictingDamage.TabIndex = 487
        Me.lblObjectInflictingDamage.Text = "Object / Substance Inflicting Damage:"
        '
        'lblNatureDamage
        '
        Me.lblNatureDamage.AutoSize = True
        Me.lblNatureDamage.BackColor = System.Drawing.Color.Transparent
        Me.lblNatureDamage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNatureDamage.ForeColor = System.Drawing.Color.White
        Me.lblNatureDamage.Location = New System.Drawing.Point(10, 147)
        Me.lblNatureDamage.Name = "lblNatureDamage"
        Me.lblNatureDamage.Size = New System.Drawing.Size(111, 15)
        Me.lblNatureDamage.TabIndex = 486
        Me.lblNatureDamage.Text = "Nature of damage:"
        '
        'txtNatureDamage
        '
        Me.txtNatureDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNatureDamage.Location = New System.Drawing.Point(7, 165)
        Me.txtNatureDamage.Name = "txtNatureDamage"
        Me.txtNatureDamage.Size = New System.Drawing.Size(233, 24)
        Me.txtNatureDamage.TabIndex = 15
        '
        'lblNameDamage
        '
        Me.lblNameDamage.AutoSize = True
        Me.lblNameDamage.BackColor = System.Drawing.Color.Transparent
        Me.lblNameDamage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameDamage.ForeColor = System.Drawing.Color.White
        Me.lblNameDamage.Location = New System.Drawing.Point(8, 97)
        Me.lblNameDamage.Name = "lblNameDamage"
        Me.lblNameDamage.Size = New System.Drawing.Size(197, 15)
        Me.lblNameDamage.TabIndex = 485
        Me.lblNameDamage.Text = "List property/equip/mat damaged:"
        '
        'cmb_listProperty_Equi_Material_Damaged
        '
        Me.cmb_listProperty_Equi_Material_Damaged.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_listProperty_Equi_Material_Damaged.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_listProperty_Equi_Material_Damaged.FormattingEnabled = True
        Me.cmb_listProperty_Equi_Material_Damaged.Items.AddRange(New Object() {"List Property Damaged", "Equipment Damaged", "Material Damaged"})
        Me.cmb_listProperty_Equi_Material_Damaged.Location = New System.Drawing.Point(7, 115)
        Me.cmb_listProperty_Equi_Material_Damaged.Name = "cmb_listProperty_Equi_Material_Damaged"
        Me.cmb_listProperty_Equi_Material_Damaged.Size = New System.Drawing.Size(233, 24)
        Me.cmb_listProperty_Equi_Material_Damaged.TabIndex = 14
        '
        'cmbCategoryListPropertyDamage
        '
        Me.cmbCategoryListPropertyDamage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoryListPropertyDamage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCategoryListPropertyDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoryListPropertyDamage.FormattingEnabled = True
        Me.cmbCategoryListPropertyDamage.Items.AddRange(New Object() {"List Property Damaged", "Equipment Damaged", "Material Damaged"})
        Me.cmbCategoryListPropertyDamage.Location = New System.Drawing.Point(7, 70)
        Me.cmbCategoryListPropertyDamage.Name = "cmbCategoryListPropertyDamage"
        Me.cmbCategoryListPropertyDamage.Size = New System.Drawing.Size(233, 24)
        Me.cmbCategoryListPropertyDamage.TabIndex = 1
        '
        'txtbreakdown_day
        '
        Me.txtbreakdown_day.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbreakdown_day.Location = New System.Drawing.Point(248, 165)
        Me.txtbreakdown_day.Name = "txtbreakdown_day"
        Me.txtbreakdown_day.Size = New System.Drawing.Size(232, 24)
        Me.txtbreakdown_day.TabIndex = 18
        '
        'lblListProperty
        '
        Me.lblListProperty.AutoSize = True
        Me.lblListProperty.BackColor = System.Drawing.Color.Transparent
        Me.lblListProperty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListProperty.ForeColor = System.Drawing.Color.White
        Me.lblListProperty.Location = New System.Drawing.Point(8, 50)
        Me.lblListProperty.Name = "lblListProperty"
        Me.lblListProperty.Size = New System.Drawing.Size(111, 15)
        Me.lblListProperty.TabIndex = 483
        Me.lblListProperty.Text = "Category Damage:"
        '
        'Panel_Equi_Property_Damage
        '
        Me.Panel_Equi_Property_Damage.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line
        Me.Panel_Equi_Property_Damage.Controls.Add(Me.lblEqui_Property_Damage)
        Me.Panel_Equi_Property_Damage.Location = New System.Drawing.Point(3, 8)
        Me.Panel_Equi_Property_Damage.Name = "Panel_Equi_Property_Damage"
        Me.Panel_Equi_Property_Damage.Size = New System.Drawing.Size(483, 38)
        Me.Panel_Equi_Property_Damage.TabIndex = 379
        '
        'lblEqui_Property_Damage
        '
        Me.lblEqui_Property_Damage.AutoSize = True
        Me.lblEqui_Property_Damage.BackColor = System.Drawing.Color.Transparent
        Me.lblEqui_Property_Damage.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEqui_Property_Damage.ForeColor = System.Drawing.Color.White
        Me.lblEqui_Property_Damage.Location = New System.Drawing.Point(122, 12)
        Me.lblEqui_Property_Damage.Name = "lblEqui_Property_Damage"
        Me.lblEqui_Property_Damage.Size = New System.Drawing.Size(244, 16)
        Me.lblEqui_Property_Damage.TabIndex = 377
        Me.lblEqui_Property_Damage.Text = "EQUIPMENT / PROPERTY DAMAGE"
        '
        'txt_prepared_by
        '
        Me.txt_prepared_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_prepared_by.Location = New System.Drawing.Point(249, 69)
        Me.txt_prepared_by.Name = "txt_prepared_by"
        Me.txt_prepared_by.Size = New System.Drawing.Size(232, 24)
        Me.txt_prepared_by.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnSave_next)
        Me.Panel1.Controls.Add(Me.txtAr_no)
        Me.Panel1.Controls.Add(Me.gboxInjuredParty)
        Me.Panel1.Controls.Add(Me.lblAR_no)
        Me.Panel1.Controls.Add(Me.chkboxCloseCall_NearHit)
        Me.Panel1.Controls.Add(Me.chkboxPropertyDamage)
        Me.Panel1.Controls.Add(Me.chkboxEquip_damaged)
        Me.Panel1.Controls.Add(Me.chkboxInjury)
        Me.Panel1.Controls.Add(Me.gboxFollow_up_progress)
        Me.Panel1.Controls.Add(Me.gboxCorrectiveActions)
        Me.Panel1.Controls.Add(Me.gboxSupervisorConInfo)
        Me.Panel1.Controls.Add(Me.gboxIncidentDesc)
        Me.Panel1.Controls.Add(Me.gboxEqui_Property_Damage)
        Me.Panel1.Location = New System.Drawing.Point(2, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1001, 918)
        Me.Panel1.TabIndex = 50
        '
        'btnSave_next
        '
        Me.btnSave_next.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave_next.Location = New System.Drawing.Point(3, 886)
        Me.btnSave_next.Name = "btnSave_next"
        Me.btnSave_next.Size = New System.Drawing.Size(196, 33)
        Me.btnSave_next.TabIndex = 39
        Me.btnSave_next.Text = "Save And Next"
        Me.btnSave_next.UseVisualStyleBackColor = True
        '
        'txtAr_no
        '
        Me.txtAr_no.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAr_no.Location = New System.Drawing.Point(714, 4)
        Me.txtAr_no.Name = "txtAr_no"
        Me.txtAr_no.Size = New System.Drawing.Size(202, 24)
        Me.txtAr_no.TabIndex = 0
        '
        'lblAR_no
        '
        Me.lblAR_no.AutoSize = True
        Me.lblAR_no.BackColor = System.Drawing.Color.Transparent
        Me.lblAR_no.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAR_no.ForeColor = System.Drawing.Color.White
        Me.lblAR_no.Location = New System.Drawing.Point(652, 9)
        Me.lblAR_no.Name = "lblAR_no"
        Me.lblAR_no.Size = New System.Drawing.Size(51, 15)
        Me.lblAR_no.TabIndex = 377
        Me.lblAR_no.Text = "AR No:"
        '
        'chkboxCloseCall_NearHit
        '
        Me.chkboxCloseCall_NearHit.AutoSize = True
        Me.chkboxCloseCall_NearHit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkboxCloseCall_NearHit.ForeColor = System.Drawing.Color.White
        Me.chkboxCloseCall_NearHit.Location = New System.Drawing.Point(433, 7)
        Me.chkboxCloseCall_NearHit.Name = "chkboxCloseCall_NearHit"
        Me.chkboxCloseCall_NearHit.Size = New System.Drawing.Size(165, 19)
        Me.chkboxCloseCall_NearHit.TabIndex = 54
        Me.chkboxCloseCall_NearHit.Text = "Close Call or Near Hit"
        Me.chkboxCloseCall_NearHit.UseVisualStyleBackColor = True
        '
        'chkboxPropertyDamage
        '
        Me.chkboxPropertyDamage.AutoSize = True
        Me.chkboxPropertyDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkboxPropertyDamage.ForeColor = System.Drawing.Color.White
        Me.chkboxPropertyDamage.Location = New System.Drawing.Point(268, 7)
        Me.chkboxPropertyDamage.Name = "chkboxPropertyDamage"
        Me.chkboxPropertyDamage.Size = New System.Drawing.Size(137, 19)
        Me.chkboxPropertyDamage.TabIndex = 53
        Me.chkboxPropertyDamage.Text = "Property Damage"
        Me.chkboxPropertyDamage.UseVisualStyleBackColor = True
        '
        'chkboxEquip_damaged
        '
        Me.chkboxEquip_damaged.AutoSize = True
        Me.chkboxEquip_damaged.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkboxEquip_damaged.ForeColor = System.Drawing.Color.White
        Me.chkboxEquip_damaged.Location = New System.Drawing.Point(94, 7)
        Me.chkboxEquip_damaged.Name = "chkboxEquip_damaged"
        Me.chkboxEquip_damaged.Size = New System.Drawing.Size(153, 19)
        Me.chkboxEquip_damaged.TabIndex = 52
        Me.chkboxEquip_damaged.Text = "Equipment Damage"
        Me.chkboxEquip_damaged.UseVisualStyleBackColor = True
        '
        'chkboxInjury
        '
        Me.chkboxInjury.AutoSize = True
        Me.chkboxInjury.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkboxInjury.ForeColor = System.Drawing.Color.White
        Me.chkboxInjury.Location = New System.Drawing.Point(6, 7)
        Me.chkboxInjury.Name = "chkboxInjury"
        Me.chkboxInjury.Size = New System.Drawing.Size(61, 19)
        Me.chkboxInjury.TabIndex = 51
        Me.chkboxInjury.Text = "Injury"
        Me.chkboxInjury.UseVisualStyleBackColor = True
        '
        'gboxFollow_up_progress
        '
        Me.gboxFollow_up_progress.Controls.Add(Me.dtp_date_close_out)
        Me.gboxFollow_up_progress.Controls.Add(Me.lblDate_close_out)
        Me.gboxFollow_up_progress.Controls.Add(Me.txtClosed_out_by)
        Me.gboxFollow_up_progress.Controls.Add(Me.lblClose_out_remarks)
        Me.gboxFollow_up_progress.Controls.Add(Me.lblClosed_out_by)
        Me.gboxFollow_up_progress.Controls.Add(Me.rich_text_Closed_out_remarks)
        Me.gboxFollow_up_progress.Controls.Add(Me.txtFollow_up_by)
        Me.gboxFollow_up_progress.Controls.Add(Me.lblDate_follow_up)
        Me.gboxFollow_up_progress.Controls.Add(Me.dtp_date_follow_up)
        Me.gboxFollow_up_progress.Controls.Add(Me.lblFollow_up_by)
        Me.gboxFollow_up_progress.Controls.Add(Me.lblFollow_up_progress)
        Me.gboxFollow_up_progress.Controls.Add(Me.richText_Follow_up_Progress)
        Me.gboxFollow_up_progress.Location = New System.Drawing.Point(498, 565)
        Me.gboxFollow_up_progress.Name = "gboxFollow_up_progress"
        Me.gboxFollow_up_progress.Size = New System.Drawing.Size(495, 320)
        Me.gboxFollow_up_progress.TabIndex = 32
        Me.gboxFollow_up_progress.TabStop = False
        '
        'dtp_date_close_out
        '
        Me.dtp_date_close_out.CustomFormat = ""
        Me.dtp_date_close_out.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_date_close_out.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_date_close_out.Location = New System.Drawing.Point(122, 272)
        Me.dtp_date_close_out.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtp_date_close_out.Name = "dtp_date_close_out"
        Me.dtp_date_close_out.Size = New System.Drawing.Size(293, 24)
        Me.dtp_date_close_out.TabIndex = 38
        '
        'lblDate_close_out
        '
        Me.lblDate_close_out.AutoSize = True
        Me.lblDate_close_out.BackColor = System.Drawing.Color.Transparent
        Me.lblDate_close_out.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate_close_out.ForeColor = System.Drawing.Color.White
        Me.lblDate_close_out.Location = New System.Drawing.Point(4, 277)
        Me.lblDate_close_out.Name = "lblDate_close_out"
        Me.lblDate_close_out.Size = New System.Drawing.Size(107, 15)
        Me.lblDate_close_out.TabIndex = 508
        Me.lblDate_close_out.Text = "Date of Close-out:"
        '
        'txtClosed_out_by
        '
        Me.txtClosed_out_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClosed_out_by.Location = New System.Drawing.Point(122, 243)
        Me.txtClosed_out_by.Name = "txtClosed_out_by"
        Me.txtClosed_out_by.Size = New System.Drawing.Size(293, 24)
        Me.txtClosed_out_by.TabIndex = 37
        '
        'lblClose_out_remarks
        '
        Me.lblClose_out_remarks.AutoSize = True
        Me.lblClose_out_remarks.BackColor = System.Drawing.Color.Transparent
        Me.lblClose_out_remarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose_out_remarks.ForeColor = System.Drawing.Color.White
        Me.lblClose_out_remarks.Location = New System.Drawing.Point(8, 181)
        Me.lblClose_out_remarks.Name = "lblClose_out_remarks"
        Me.lblClose_out_remarks.Size = New System.Drawing.Size(126, 15)
        Me.lblClose_out_remarks.TabIndex = 506
        Me.lblClose_out_remarks.Text = "Closed-out Remarks:"
        '
        'lblClosed_out_by
        '
        Me.lblClosed_out_by.AutoSize = True
        Me.lblClosed_out_by.BackColor = System.Drawing.Color.Transparent
        Me.lblClosed_out_by.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClosed_out_by.ForeColor = System.Drawing.Color.White
        Me.lblClosed_out_by.Location = New System.Drawing.Point(8, 246)
        Me.lblClosed_out_by.Name = "lblClosed_out_by"
        Me.lblClosed_out_by.Size = New System.Drawing.Size(87, 15)
        Me.lblClosed_out_by.TabIndex = 505
        Me.lblClosed_out_by.Text = "Closed-out by:"
        '
        'rich_text_Closed_out_remarks
        '
        Me.rich_text_Closed_out_remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rich_text_Closed_out_remarks.Location = New System.Drawing.Point(11, 199)
        Me.rich_text_Closed_out_remarks.Name = "rich_text_Closed_out_remarks"
        Me.rich_text_Closed_out_remarks.Size = New System.Drawing.Size(404, 38)
        Me.rich_text_Closed_out_remarks.TabIndex = 36
        Me.rich_text_Closed_out_remarks.Text = ""
        '
        'txtFollow_up_by
        '
        Me.txtFollow_up_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFollow_up_by.Location = New System.Drawing.Point(112, 77)
        Me.txtFollow_up_by.Name = "txtFollow_up_by"
        Me.txtFollow_up_by.Size = New System.Drawing.Size(298, 24)
        Me.txtFollow_up_by.TabIndex = 34
        '
        'lblDate_follow_up
        '
        Me.lblDate_follow_up.AutoSize = True
        Me.lblDate_follow_up.BackColor = System.Drawing.Color.Transparent
        Me.lblDate_follow_up.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate_follow_up.ForeColor = System.Drawing.Color.White
        Me.lblDate_follow_up.Location = New System.Drawing.Point(3, 111)
        Me.lblDate_follow_up.Name = "lblDate_follow_up"
        Me.lblDate_follow_up.Size = New System.Drawing.Size(107, 15)
        Me.lblDate_follow_up.TabIndex = 503
        Me.lblDate_follow_up.Text = "Date of Follow-up:"
        '
        'dtp_date_follow_up
        '
        Me.dtp_date_follow_up.CustomFormat = ""
        Me.dtp_date_follow_up.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_date_follow_up.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_date_follow_up.Location = New System.Drawing.Point(112, 106)
        Me.dtp_date_follow_up.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtp_date_follow_up.Name = "dtp_date_follow_up"
        Me.dtp_date_follow_up.Size = New System.Drawing.Size(298, 24)
        Me.dtp_date_follow_up.TabIndex = 35
        '
        'lblFollow_up_by
        '
        Me.lblFollow_up_by.AutoSize = True
        Me.lblFollow_up_by.BackColor = System.Drawing.Color.Transparent
        Me.lblFollow_up_by.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFollow_up_by.ForeColor = System.Drawing.Color.White
        Me.lblFollow_up_by.Location = New System.Drawing.Point(5, 80)
        Me.lblFollow_up_by.Name = "lblFollow_up_by"
        Me.lblFollow_up_by.Size = New System.Drawing.Size(80, 15)
        Me.lblFollow_up_by.TabIndex = 502
        Me.lblFollow_up_by.Text = "Follow-up by:"
        '
        'lblFollow_up_progress
        '
        Me.lblFollow_up_progress.AutoSize = True
        Me.lblFollow_up_progress.BackColor = System.Drawing.Color.Transparent
        Me.lblFollow_up_progress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFollow_up_progress.ForeColor = System.Drawing.Color.White
        Me.lblFollow_up_progress.Location = New System.Drawing.Point(10, 13)
        Me.lblFollow_up_progress.Name = "lblFollow_up_progress"
        Me.lblFollow_up_progress.Size = New System.Drawing.Size(134, 15)
        Me.lblFollow_up_progress.TabIndex = 502
        Me.lblFollow_up_progress.Text = "Follow-up of Progress:"
        '
        'richText_Follow_up_Progress
        '
        Me.richText_Follow_up_Progress.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.richText_Follow_up_Progress.Location = New System.Drawing.Point(9, 31)
        Me.richText_Follow_up_Progress.Name = "richText_Follow_up_Progress"
        Me.richText_Follow_up_Progress.Size = New System.Drawing.Size(401, 38)
        Me.richText_Follow_up_Progress.TabIndex = 33
        Me.richText_Follow_up_Progress.Text = ""
        '
        'gboxCorrectiveActions
        '
        Me.gboxCorrectiveActions.Controls.Add(Me.dtp_date_reviewed)
        Me.gboxCorrectiveActions.Controls.Add(Me.txt_prepared_by)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblDate_Reviewed)
        Me.gboxCorrectiveActions.Controls.Add(Me.txtReviewed_by)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblReviewed_by)
        Me.gboxCorrectiveActions.Controls.Add(Me.dtpApproved_by)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblDate_Approved)
        Me.gboxCorrectiveActions.Controls.Add(Me.txtApporved_by)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblApproved_by)
        Me.gboxCorrectiveActions.Controls.Add(Me.dtp_Date_Prepared)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblDate_prepared)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblPrepared_by)
        Me.gboxCorrectiveActions.Controls.Add(Me.txtTimeFrame)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblTimeframe)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblResponsibility)
        Me.gboxCorrectiveActions.Controls.Add(Me.txtResponsibility)
        Me.gboxCorrectiveActions.Controls.Add(Me.txtActionPlan)
        Me.gboxCorrectiveActions.Controls.Add(Me.lblActionPlan)
        Me.gboxCorrectiveActions.Controls.Add(Me.Panel_CorrectiveActions)
        Me.gboxCorrectiveActions.Location = New System.Drawing.Point(5, 565)
        Me.gboxCorrectiveActions.Name = "gboxCorrectiveActions"
        Me.gboxCorrectiveActions.Size = New System.Drawing.Size(487, 320)
        Me.gboxCorrectiveActions.TabIndex = 22
        Me.gboxCorrectiveActions.TabStop = False
        '
        'dtp_date_reviewed
        '
        Me.dtp_date_reviewed.CustomFormat = ""
        Me.dtp_date_reviewed.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_date_reviewed.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_date_reviewed.Location = New System.Drawing.Point(251, 289)
        Me.dtp_date_reviewed.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtp_date_reviewed.Name = "dtp_date_reviewed"
        Me.dtp_date_reviewed.Size = New System.Drawing.Size(230, 24)
        Me.dtp_date_reviewed.TabIndex = 31
        '
        'lblDate_Reviewed
        '
        Me.lblDate_Reviewed.AutoSize = True
        Me.lblDate_Reviewed.BackColor = System.Drawing.Color.Transparent
        Me.lblDate_Reviewed.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate_Reviewed.ForeColor = System.Drawing.Color.White
        Me.lblDate_Reviewed.Location = New System.Drawing.Point(250, 271)
        Me.lblDate_Reviewed.Name = "lblDate_Reviewed"
        Me.lblDate_Reviewed.Size = New System.Drawing.Size(94, 15)
        Me.lblDate_Reviewed.TabIndex = 500
        Me.lblDate_Reviewed.Text = "Date Reviewed:"
        '
        'txtReviewed_by
        '
        Me.txtReviewed_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReviewed_by.Location = New System.Drawing.Point(251, 244)
        Me.txtReviewed_by.Name = "txtReviewed_by"
        Me.txtReviewed_by.Size = New System.Drawing.Size(230, 24)
        Me.txtReviewed_by.TabIndex = 30
        '
        'lblReviewed_by
        '
        Me.lblReviewed_by.AutoSize = True
        Me.lblReviewed_by.BackColor = System.Drawing.Color.Transparent
        Me.lblReviewed_by.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReviewed_by.ForeColor = System.Drawing.Color.White
        Me.lblReviewed_by.Location = New System.Drawing.Point(250, 226)
        Me.lblReviewed_by.Name = "lblReviewed_by"
        Me.lblReviewed_by.Size = New System.Drawing.Size(81, 15)
        Me.lblReviewed_by.TabIndex = 498
        Me.lblReviewed_by.Text = "Reviewed by:"
        '
        'dtpApproved_by
        '
        Me.dtpApproved_by.CustomFormat = ""
        Me.dtpApproved_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpApproved_by.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpApproved_by.Location = New System.Drawing.Point(251, 199)
        Me.dtpApproved_by.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtpApproved_by.Name = "dtpApproved_by"
        Me.dtpApproved_by.Size = New System.Drawing.Size(230, 24)
        Me.dtpApproved_by.TabIndex = 29
        '
        'lblDate_Approved
        '
        Me.lblDate_Approved.AutoSize = True
        Me.lblDate_Approved.BackColor = System.Drawing.Color.Transparent
        Me.lblDate_Approved.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate_Approved.ForeColor = System.Drawing.Color.White
        Me.lblDate_Approved.Location = New System.Drawing.Point(250, 181)
        Me.lblDate_Approved.Name = "lblDate_Approved"
        Me.lblDate_Approved.Size = New System.Drawing.Size(93, 15)
        Me.lblDate_Approved.TabIndex = 496
        Me.lblDate_Approved.Text = "Date Approved:"
        '
        'txtApporved_by
        '
        Me.txtApporved_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApporved_by.Location = New System.Drawing.Point(251, 155)
        Me.txtApporved_by.Name = "txtApporved_by"
        Me.txtApporved_by.Size = New System.Drawing.Size(230, 24)
        Me.txtApporved_by.TabIndex = 28
        '
        'lblApproved_by
        '
        Me.lblApproved_by.AutoSize = True
        Me.lblApproved_by.BackColor = System.Drawing.Color.Transparent
        Me.lblApproved_by.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproved_by.ForeColor = System.Drawing.Color.White
        Me.lblApproved_by.Location = New System.Drawing.Point(250, 137)
        Me.lblApproved_by.Name = "lblApproved_by"
        Me.lblApproved_by.Size = New System.Drawing.Size(80, 15)
        Me.lblApproved_by.TabIndex = 494
        Me.lblApproved_by.Text = "Approved by:"
        '
        'dtp_Date_Prepared
        '
        Me.dtp_Date_Prepared.CustomFormat = ""
        Me.dtp_Date_Prepared.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Date_Prepared.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Date_Prepared.Location = New System.Drawing.Point(251, 110)
        Me.dtp_Date_Prepared.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtp_Date_Prepared.Name = "dtp_Date_Prepared"
        Me.dtp_Date_Prepared.Size = New System.Drawing.Size(230, 24)
        Me.dtp_Date_Prepared.TabIndex = 27
        '
        'lblDate_prepared
        '
        Me.lblDate_prepared.AutoSize = True
        Me.lblDate_prepared.BackColor = System.Drawing.Color.Transparent
        Me.lblDate_prepared.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate_prepared.ForeColor = System.Drawing.Color.White
        Me.lblDate_prepared.Location = New System.Drawing.Point(250, 94)
        Me.lblDate_prepared.Name = "lblDate_prepared"
        Me.lblDate_prepared.Size = New System.Drawing.Size(92, 15)
        Me.lblDate_prepared.TabIndex = 493
        Me.lblDate_prepared.Text = "Date Prepared:"
        '
        'lblPrepared_by
        '
        Me.lblPrepared_by.AutoSize = True
        Me.lblPrepared_by.BackColor = System.Drawing.Color.Transparent
        Me.lblPrepared_by.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrepared_by.ForeColor = System.Drawing.Color.White
        Me.lblPrepared_by.Location = New System.Drawing.Point(250, 51)
        Me.lblPrepared_by.Name = "lblPrepared_by"
        Me.lblPrepared_by.Size = New System.Drawing.Size(79, 15)
        Me.lblPrepared_by.TabIndex = 489
        Me.lblPrepared_by.Text = "Prepared by:"
        '
        'txtTimeFrame
        '
        Me.txtTimeFrame.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeFrame.Location = New System.Drawing.Point(8, 243)
        Me.txtTimeFrame.Name = "txtTimeFrame"
        Me.txtTimeFrame.Size = New System.Drawing.Size(234, 67)
        Me.txtTimeFrame.TabIndex = 25
        Me.txtTimeFrame.Text = ""
        '
        'lblTimeframe
        '
        Me.lblTimeframe.AutoSize = True
        Me.lblTimeframe.BackColor = System.Drawing.Color.Transparent
        Me.lblTimeframe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeframe.ForeColor = System.Drawing.Color.White
        Me.lblTimeframe.Location = New System.Drawing.Point(7, 225)
        Me.lblTimeframe.Name = "lblTimeframe"
        Me.lblTimeframe.Size = New System.Drawing.Size(72, 15)
        Me.lblTimeframe.TabIndex = 488
        Me.lblTimeframe.Text = "Timeframe:"
        '
        'lblResponsibility
        '
        Me.lblResponsibility.AutoSize = True
        Me.lblResponsibility.BackColor = System.Drawing.Color.Transparent
        Me.lblResponsibility.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsibility.ForeColor = System.Drawing.Color.White
        Me.lblResponsibility.Location = New System.Drawing.Point(10, 136)
        Me.lblResponsibility.Name = "lblResponsibility"
        Me.lblResponsibility.Size = New System.Drawing.Size(89, 15)
        Me.lblResponsibility.TabIndex = 487
        Me.lblResponsibility.Text = "Responsibility:"
        '
        'txtResponsibility
        '
        Me.txtResponsibility.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponsibility.Location = New System.Drawing.Point(8, 153)
        Me.txtResponsibility.Name = "txtResponsibility"
        Me.txtResponsibility.Size = New System.Drawing.Size(233, 68)
        Me.txtResponsibility.TabIndex = 24
        Me.txtResponsibility.Text = ""
        '
        'txtActionPlan
        '
        Me.txtActionPlan.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActionPlan.Location = New System.Drawing.Point(8, 64)
        Me.txtActionPlan.Name = "txtActionPlan"
        Me.txtActionPlan.Size = New System.Drawing.Size(233, 69)
        Me.txtActionPlan.TabIndex = 23
        Me.txtActionPlan.Text = ""
        '
        'lblActionPlan
        '
        Me.lblActionPlan.AutoSize = True
        Me.lblActionPlan.BackColor = System.Drawing.Color.Transparent
        Me.lblActionPlan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActionPlan.ForeColor = System.Drawing.Color.White
        Me.lblActionPlan.Location = New System.Drawing.Point(10, 50)
        Me.lblActionPlan.Name = "lblActionPlan"
        Me.lblActionPlan.Size = New System.Drawing.Size(74, 15)
        Me.lblActionPlan.TabIndex = 484
        Me.lblActionPlan.Text = "Action Plan:"
        '
        'Panel_CorrectiveActions
        '
        Me.Panel_CorrectiveActions.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line
        Me.Panel_CorrectiveActions.Controls.Add(Me.lblCorrectiveActions)
        Me.Panel_CorrectiveActions.Location = New System.Drawing.Point(3, 8)
        Me.Panel_CorrectiveActions.Name = "Panel_CorrectiveActions"
        Me.Panel_CorrectiveActions.Size = New System.Drawing.Size(482, 38)
        Me.Panel_CorrectiveActions.TabIndex = 382
        '
        'lblCorrectiveActions
        '
        Me.lblCorrectiveActions.AutoSize = True
        Me.lblCorrectiveActions.BackColor = System.Drawing.Color.Transparent
        Me.lblCorrectiveActions.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrectiveActions.ForeColor = System.Drawing.Color.White
        Me.lblCorrectiveActions.Location = New System.Drawing.Point(129, 10)
        Me.lblCorrectiveActions.Name = "lblCorrectiveActions"
        Me.lblCorrectiveActions.Size = New System.Drawing.Size(162, 16)
        Me.lblCorrectiveActions.TabIndex = 377
        Me.lblCorrectiveActions.Text = "CORRECTIVE ACTIONS"
        '
        'gboxIncidentDesc
        '
        Me.gboxIncidentDesc.BackColor = System.Drawing.Color.Transparent
        Me.gboxIncidentDesc.Controls.Add(Me.Label1)
        Me.gboxIncidentDesc.Controls.Add(Me.RichTxt_incident_desc)
        Me.gboxIncidentDesc.Controls.Add(Me.Panel_IncidentDesc)
        Me.gboxIncidentDesc.Location = New System.Drawing.Point(499, 338)
        Me.gboxIncidentDesc.Name = "gboxIncidentDesc"
        Me.gboxIncidentDesc.Size = New System.Drawing.Size(494, 228)
        Me.gboxIncidentDesc.TabIndex = 20
        Me.gboxIncidentDesc.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 15)
        Me.Label1.TabIndex = 492
        Me.Label1.Text = "Describe what happened."
        '
        'RichTxt_incident_desc
        '
        Me.RichTxt_incident_desc.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTxt_incident_desc.Location = New System.Drawing.Point(9, 68)
        Me.RichTxt_incident_desc.Name = "RichTxt_incident_desc"
        Me.RichTxt_incident_desc.Size = New System.Drawing.Size(474, 151)
        Me.RichTxt_incident_desc.TabIndex = 21
        Me.RichTxt_incident_desc.Text = ""
        '
        'Panel_IncidentDesc
        '
        Me.Panel_IncidentDesc.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line
        Me.Panel_IncidentDesc.Controls.Add(Me.lblIncidentDesc)
        Me.Panel_IncidentDesc.Location = New System.Drawing.Point(2, 9)
        Me.Panel_IncidentDesc.Name = "Panel_IncidentDesc"
        Me.Panel_IncidentDesc.Size = New System.Drawing.Size(491, 38)
        Me.Panel_IncidentDesc.TabIndex = 380
        '
        'lblIncidentDesc
        '
        Me.lblIncidentDesc.AutoSize = True
        Me.lblIncidentDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblIncidentDesc.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncidentDesc.ForeColor = System.Drawing.Color.White
        Me.lblIncidentDesc.Location = New System.Drawing.Point(130, 13)
        Me.lblIncidentDesc.Name = "lblIncidentDesc"
        Me.lblIncidentDesc.Size = New System.Drawing.Size(171, 16)
        Me.lblIncidentDesc.TabIndex = 377
        Me.lblIncidentDesc.Text = "INCIDENT DESCRIPTION"
        '
        'lblTitleAccidentReport
        '
        Me.lblTitleAccidentReport.AutoSize = True
        Me.lblTitleAccidentReport.BackColor = System.Drawing.Color.Transparent
        Me.lblTitleAccidentReport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleAccidentReport.ForeColor = System.Drawing.Color.White
        Me.lblTitleAccidentReport.Location = New System.Drawing.Point(369, 5)
        Me.lblTitleAccidentReport.Name = "lblTitleAccidentReport"
        Me.lblTitleAccidentReport.Size = New System.Drawing.Size(165, 19)
        Me.lblTitleAccidentReport.TabIndex = 378
        Me.lblTitleAccidentReport.Text = "ACCIDENT REPORT"
        '
        'lblUpdate_sup_info_id
        '
        Me.lblUpdate_sup_info_id.AutoSize = True
        Me.lblUpdate_sup_info_id.Location = New System.Drawing.Point(1032, 795)
        Me.lblUpdate_sup_info_id.Name = "lblUpdate_sup_info_id"
        Me.lblUpdate_sup_info_id.Size = New System.Drawing.Size(63, 13)
        Me.lblUpdate_sup_info_id.TabIndex = 379
        Me.lblUpdate_sup_info_id.Text = "Sup_info_id"
        Me.lblUpdate_sup_info_id.Visible = False
        '
        'lblInjured_party_id
        '
        Me.lblInjured_party_id.AutoSize = True
        Me.lblInjured_party_id.Location = New System.Drawing.Point(1023, 752)
        Me.lblInjured_party_id.Name = "lblInjured_party_id"
        Me.lblInjured_party_id.Size = New System.Drawing.Size(73, 13)
        Me.lblInjured_party_id.TabIndex = 380
        Me.lblInjured_party_id.Text = "injured_par_id"
        Me.lblInjured_party_id.Visible = False
        '
        'lblEqui_pro_dam_id
        '
        Me.lblEqui_pro_dam_id.AutoSize = True
        Me.lblEqui_pro_dam_id.Location = New System.Drawing.Point(1022, 705)
        Me.lblEqui_pro_dam_id.Name = "lblEqui_pro_dam_id"
        Me.lblEqui_pro_dam_id.Size = New System.Drawing.Size(88, 13)
        Me.lblEqui_pro_dam_id.TabIndex = 381
        Me.lblEqui_pro_dam_id.Text = "equi_pro_dam_id"
        Me.lblEqui_pro_dam_id.Visible = False
        '
        'lblAcc_report_id
        '
        Me.lblAcc_report_id.AutoSize = True
        Me.lblAcc_report_id.Location = New System.Drawing.Point(1022, 675)
        Me.lblAcc_report_id.Name = "lblAcc_report_id"
        Me.lblAcc_report_id.Size = New System.Drawing.Size(72, 13)
        Me.lblAcc_report_id.TabIndex = 382
        Me.lblAcc_report_id.Text = "acc_report_id"
        Me.lblAcc_report_id.Visible = False
        '
        'lbl_driver
        '
        Me.lbl_driver.AutoSize = True
        Me.lbl_driver.BackColor = System.Drawing.Color.Transparent
        Me.lbl_driver.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_driver.ForeColor = System.Drawing.Color.White
        Me.lbl_driver.Location = New System.Drawing.Point(4, 200)
        Me.lbl_driver.Name = "lbl_driver"
        Me.lbl_driver.Size = New System.Drawing.Size(44, 15)
        Me.lbl_driver.TabIndex = 492
        Me.lbl_driver.Text = "Driver:"
        '
        'txt_driver_name
        '
        Me.txt_driver_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_driver_name.Location = New System.Drawing.Point(48, 195)
        Me.txt_driver_name.Name = "txt_driver_name"
        Me.txt_driver_name.Size = New System.Drawing.Size(193, 24)
        Me.txt_driver_name.TabIndex = 19
        '
        'FAccidentReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1005, 948)
        Me.Controls.Add(Me.lblAcc_report_id)
        Me.Controls.Add(Me.lblEqui_pro_dam_id)
        Me.Controls.Add(Me.lblInjured_party_id)
        Me.Controls.Add(Me.lblUpdate_sup_info_id)
        Me.Controls.Add(Me.lblTitleAccidentReport)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FAccidentReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.gboxSupervisorConInfo.ResumeLayout(False)
        Me.gboxSupervisorConInfo.PerformLayout()
        Me.Panel_Supervisor_Contact_Info.ResumeLayout(False)
        Me.Panel_Supervisor_Contact_Info.PerformLayout()
        Me.gboxInjuredParty.ResumeLayout(False)
        Me.gboxInjuredParty.PerformLayout()
        Me.Panel_InjuredParty.ResumeLayout(False)
        Me.Panel_InjuredParty.PerformLayout()
        Me.gboxEqui_Property_Damage.ResumeLayout(False)
        Me.gboxEqui_Property_Damage.PerformLayout()
        Me.Panel_Equi_Property_Damage.ResumeLayout(False)
        Me.Panel_Equi_Property_Damage.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gboxFollow_up_progress.ResumeLayout(False)
        Me.gboxFollow_up_progress.PerformLayout()
        Me.gboxCorrectiveActions.ResumeLayout(False)
        Me.gboxCorrectiveActions.PerformLayout()
        Me.Panel_CorrectiveActions.ResumeLayout(False)
        Me.Panel_CorrectiveActions.PerformLayout()
        Me.gboxIncidentDesc.ResumeLayout(False)
        Me.gboxIncidentDesc.PerformLayout()
        Me.Panel_IncidentDesc.ResumeLayout(False)
        Me.Panel_IncidentDesc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gboxSupervisorConInfo As GroupBox
    Friend WithEvents LblInvestigatorName As Label
    Friend WithEvents lblJobSite As Label
    Friend WithEvents txtJobPosition As TextBox
    Friend WithEvents lblJobPosition As Label
    Friend WithEvents txtInvestigatorName As TextBox
    Friend WithEvents cmbJobSite As ComboBox
    Friend WithEvents cmbDepartSectionValue As ComboBox
    Friend WithEvents lblDepartment_section As Label
    Friend WithEvents txtWitnessedBy As TextBox
    Friend WithEvents lblWitnessedBy As Label
    Friend WithEvents txtTimeOfReport As TextBox
    Friend WithEvents lblTimeReport As Label
    Friend WithEvents dtp_date_report_super As DateTimePicker
    Friend WithEvents lblDateReport As Label
    Friend WithEvents txtTimeIncident As TextBox
    Friend WithEvents lblTimeIncident As Label
    Friend WithEvents lblDateIncident As Label
    Friend WithEvents DTPDateIncident As DateTimePicker
    Friend WithEvents Panel_Supervisor_Contact_Info As Panel
    Friend WithEvents lblSupervisorContactInfo As Label
    Friend WithEvents gboxInjuredParty As GroupBox
    Friend WithEvents Panel_InjuredParty As Panel
    Friend WithEvents lblInjuredParty As Label
    Friend WithEvents txtContactInformation As TextBox
    Friend WithEvents lblContactInformation As Label
    Friend WithEvents lblInjuredJobPosition As Label
    Friend WithEvents txtInjuredJobPosition As TextBox
    Friend WithEvents lblGender As Label
    Friend WithEvents txtGender As TextBox
    Friend WithEvents txtAge As TextBox
    Friend WithEvents lblAge As Label
    Friend WithEvents txtInjuredPartyName As TextBox
    Friend WithEvents lblInjuredPartyName As Label
    Friend WithEvents txtBodyPartInjured As TextBox
    Friend WithEvents lblBodyInjured As Label
    Friend WithEvents lblNameAddTreatingFal As Label
    Friend WithEvents txtTreatmentCost As TextBox
    Friend WithEvents lblTreatmentCost As Label
    Friend WithEvents gboxEqui_Property_Damage As GroupBox
    Friend WithEvents lblBreakDownDays As Label
    Friend WithEvents txt_prepared_by As TextBox
    Friend WithEvents lblAppCostDamage As Label
    Friend WithEvents txtAppCostDamage As TextBox
    Friend WithEvents txtObjectInflictingDamage As TextBox
    Friend WithEvents lblObjectInflictingDamage As Label
    Friend WithEvents lblNatureDamage As Label
    Friend WithEvents txtNatureDamage As TextBox
    Friend WithEvents lblNameDamage As Label
    Friend WithEvents cmb_listProperty_Equi_Material_Damaged As ComboBox
    Friend WithEvents cmbCategoryListPropertyDamage As ComboBox
    Friend WithEvents lblListProperty As Label
    Friend WithEvents Panel_Equi_Property_Damage As Panel
    Friend WithEvents lblEqui_Property_Damage As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gboxCorrectiveActions As GroupBox
    Friend WithEvents dtp_date_reviewed As DateTimePicker
    Friend WithEvents lblDate_Reviewed As Label
    Friend WithEvents txtReviewed_by As TextBox
    Friend WithEvents lblReviewed_by As Label
    Friend WithEvents dtpApproved_by As DateTimePicker
    Friend WithEvents lblDate_Approved As Label
    Friend WithEvents txtApporved_by As TextBox
    Friend WithEvents lblApproved_by As Label
    Friend WithEvents dtp_Date_Prepared As DateTimePicker
    Friend WithEvents lblDate_prepared As Label
    Friend WithEvents lblPrepared_by As Label
    Friend WithEvents txtbreakdown_day As TextBox
    Friend WithEvents lblTimeframe As Label
    Friend WithEvents lblResponsibility As Label
    Friend WithEvents txtTimeFrame As RichTextBox
    Friend WithEvents txtResponsibility As RichTextBox
    Friend WithEvents txtActionPlan As RichTextBox
    Friend WithEvents lblActionPlan As Label
    Friend WithEvents Panel_CorrectiveActions As Panel
    Friend WithEvents lblCorrectiveActions As Label
    Friend WithEvents gboxFollow_up_progress As GroupBox
    Friend WithEvents txtFollow_up_by As TextBox
    Friend WithEvents lblDate_follow_up As Label
    Friend WithEvents dtp_date_follow_up As DateTimePicker
    Friend WithEvents lblFollow_up_by As Label
    Friend WithEvents lblFollow_up_progress As Label
    Friend WithEvents richText_Follow_up_Progress As RichTextBox
    Friend WithEvents rich_text_Closed_out_remarks As RichTextBox
    Friend WithEvents lblClose_out_remarks As Label
    Friend WithEvents lblClosed_out_by As Label
    Friend WithEvents dtp_date_close_out As DateTimePicker
    Friend WithEvents lblDate_close_out As Label
    Friend WithEvents txtClosed_out_by As TextBox
    Friend WithEvents lblAR_no As Label
    Friend WithEvents chkboxCloseCall_NearHit As CheckBox
    Friend WithEvents chkboxPropertyDamage As CheckBox
    Friend WithEvents chkboxEquip_damaged As CheckBox
    Friend WithEvents chkboxInjury As CheckBox
    Friend WithEvents lblTitleAccidentReport As Label
    Friend WithEvents cmbDeptSectionName As ComboBox
    Friend WithEvents lblDepartSectionName As Label
    Friend WithEvents txttreating_facility As TextBox
    Friend WithEvents txtTreatment As TextBox
    Friend WithEvents lblTreatment As Label
    Friend WithEvents txtNature_illness_injured As TextBox
    Friend WithEvents lblNature_of_illness As Label
    Friend WithEvents txtAr_no As TextBox
    Friend WithEvents gboxIncidentDesc As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RichTxt_incident_desc As RichTextBox
    Friend WithEvents Panel_IncidentDesc As Panel
    Friend WithEvents lblIncidentDesc As Label
    Friend WithEvents btnSave_next As Button
    Friend WithEvents lblUpdate_sup_info_id As Label
    Friend WithEvents lblInjured_party_id As Label
    Friend WithEvents lblEqui_pro_dam_id As Label
    Friend WithEvents lblAcc_report_id As Label
    Friend WithEvents txt_driver_name As TextBox
    Friend WithEvents lbl_driver As Label
End Class
