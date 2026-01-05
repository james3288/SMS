<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAccidentReportField
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lvl_acc_report_field = New System.Windows.Forms.ListView()
        Me.acc_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cat_dam_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ar_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cat_damaged = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pro_equip_material = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.natured_damaged = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.obj_subs_inflicting_dam = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.App_cost_damage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.breakdown_days = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.driver_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sup_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.job_position = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.job_site = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.department_section = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.charge_to = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.date_incident = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.time_incident = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.date_report = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.time_report = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.witnessed_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.supervisor_info_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.injured_party_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditRootCauseAnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_input_fields = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.equip_pro_damaged_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1423, 656)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lvl_acc_report_field)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1417, 563)
        Me.Panel1.TabIndex = 0
        '
        'lvl_acc_report_field
        '
        Me.lvl_acc_report_field.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.acc_id, Me.cat_dam_name, Me.ar_no, Me.cat_damaged, Me.pro_equip_material, Me.natured_damaged, Me.obj_subs_inflicting_dam, Me.App_cost_damage, Me.breakdown_days, Me.driver_name, Me.sup_name, Me.job_position, Me.job_site, Me.department_section, Me.charge_to, Me.date_incident, Me.time_incident, Me.date_report, Me.time_report, Me.witnessed_by, Me.supervisor_info_id, Me.injured_party_id, Me.equip_pro_damaged_id})
        Me.lvl_acc_report_field.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvl_acc_report_field.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvl_acc_report_field.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_acc_report_field.FullRowSelect = True
        Me.lvl_acc_report_field.GridLines = True
        Me.lvl_acc_report_field.HideSelection = False
        Me.lvl_acc_report_field.Location = New System.Drawing.Point(0, 0)
        Me.lvl_acc_report_field.Name = "lvl_acc_report_field"
        Me.lvl_acc_report_field.Size = New System.Drawing.Size(1417, 563)
        Me.lvl_acc_report_field.TabIndex = 1
        Me.lvl_acc_report_field.UseCompatibleStateImageBehavior = False
        Me.lvl_acc_report_field.View = System.Windows.Forms.View.Details
        '
        'acc_id
        '
        Me.acc_id.Text = "Acc_id"
        '
        'cat_dam_name
        '
        Me.cat_dam_name.Text = "Category"
        Me.cat_dam_name.Width = 350
        '
        'ar_no
        '
        Me.ar_no.Text = "AR No."
        Me.ar_no.Width = 150
        '
        'cat_damaged
        '
        Me.cat_damaged.Text = "Category Damaged"
        Me.cat_damaged.Width = 150
        '
        'pro_equip_material
        '
        Me.pro_equip_material.Text = "Property / Equipment / Material"
        Me.pro_equip_material.Width = 200
        '
        'natured_damaged
        '
        Me.natured_damaged.Text = "Nature of Damage"
        Me.natured_damaged.Width = 170
        '
        'obj_subs_inflicting_dam
        '
        Me.obj_subs_inflicting_dam.Text = "Object / substance inflicting damage"
        Me.obj_subs_inflicting_dam.Width = 250
        '
        'App_cost_damage
        '
        Me.App_cost_damage.Text = "Approximate cost of damage"
        Me.App_cost_damage.Width = 150
        '
        'breakdown_days
        '
        Me.breakdown_days.Text = "Breakdown Days"
        Me.breakdown_days.Width = 120
        '
        'driver_name
        '
        Me.driver_name.Text = "Driver Name"
        Me.driver_name.Width = 150
        '
        'sup_name
        '
        Me.sup_name.Text = "Supervisor Name"
        Me.sup_name.Width = 200
        '
        'job_position
        '
        Me.job_position.Text = "Job Position"
        Me.job_position.Width = 120
        '
        'job_site
        '
        Me.job_site.Text = "Job Site"
        Me.job_site.Width = 150
        '
        'department_section
        '
        Me.department_section.Text = "Department / Section"
        Me.department_section.Width = 120
        '
        'charge_to
        '
        Me.charge_to.Text = "Charge to"
        Me.charge_to.Width = 120
        '
        'date_incident
        '
        Me.date_incident.Text = "Date of Incident"
        Me.date_incident.Width = 120
        '
        'time_incident
        '
        Me.time_incident.Text = "Time of Incident"
        Me.time_incident.Width = 120
        '
        'date_report
        '
        Me.date_report.Text = "Date of Report"
        Me.date_report.Width = 120
        '
        'time_report
        '
        Me.time_report.Text = "Time of Report"
        Me.time_report.Width = 120
        '
        'witnessed_by
        '
        Me.witnessed_by.Text = "Witnessed by"
        Me.witnessed_by.Width = 150
        '
        'supervisor_info_id
        '
        Me.supervisor_info_id.Text = "supervisor_info_id"
        '
        'injured_party_id
        '
        Me.injured_party_id.Text = "injured_party_id"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.EditRootCauseAnalysisToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(204, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.EditToolStripMenuItem.Text = "Edit Accident Report"
        '
        'EditRootCauseAnalysisToolStripMenuItem
        '
        Me.EditRootCauseAnalysisToolStripMenuItem.Name = "EditRootCauseAnalysisToolStripMenuItem"
        Me.EditRootCauseAnalysisToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.EditRootCauseAnalysisToolStripMenuItem.Text = "Edit Root Cause Analysis"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1417, 41)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1417, 41)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_input_fields)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1361, 35)
        Me.Panel4.TabIndex = 0
        '
        'btn_input_fields
        '
        Me.btn_input_fields.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_input_fields.Location = New System.Drawing.Point(-6, 4)
        Me.btn_input_fields.Name = "btn_input_fields"
        Me.btn_input_fields.Size = New System.Drawing.Size(202, 30)
        Me.btn_input_fields.TabIndex = 358
        Me.btn_input_fields.Text = "Accident Report Form"
        Me.btn_input_fields.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnExit)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(1370, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(44, 35)
        Me.Panel5.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(13, 6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 357
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblSearchByCategory)
        Me.Panel3.Controls.Add(Me.cmbSearch)
        Me.Panel3.Controls.Add(Me.txtSearch)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 619)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1417, 34)
        Me.Panel3.TabIndex = 2
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(8, 10)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(68, 15)
        Me.lblSearchByCategory.TabIndex = 364
        Me.lblSearchByCategory.Text = "Search By:"
        '
        'cmbSearch
        '
        Me.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.Items.AddRange(New Object() {"ALL", "AR NO.", "EQUIPMENT"})
        Me.cmbSearch.Location = New System.Drawing.Point(81, 4)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(151, 26)
        Me.cmbSearch.TabIndex = 362
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(238, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 26)
        Me.txtSearch.TabIndex = 363
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(506, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(131, 26)
        Me.btnSearch.TabIndex = 359
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'equip_pro_damaged_id
        '
        Me.equip_pro_damaged_id.Text = "equip_pro_damaged_id"
        '
        'FAccidentReportField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1423, 656)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FAccidentReportField"
        Me.Text = "FAccidentReportField"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lvl_acc_report_field As ListView
    Friend WithEvents acc_id As ColumnHeader
    Friend WithEvents cat_dam_name As ColumnHeader
    Friend WithEvents ar_no As ColumnHeader
    Friend WithEvents cat_damaged As ColumnHeader
    Friend WithEvents pro_equip_material As ColumnHeader
    Friend WithEvents natured_damaged As ColumnHeader
    Friend WithEvents obj_subs_inflicting_dam As ColumnHeader
    Friend WithEvents App_cost_damage As ColumnHeader
    Friend WithEvents breakdown_days As ColumnHeader
    Friend WithEvents driver_name As ColumnHeader
    Friend WithEvents sup_name As ColumnHeader
    Friend WithEvents job_position As ColumnHeader
    Friend WithEvents job_site As ColumnHeader
    Friend WithEvents department_section As ColumnHeader
    Friend WithEvents charge_to As ColumnHeader
    Friend WithEvents date_incident As ColumnHeader
    Friend WithEvents time_incident As ColumnHeader
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents date_report As ColumnHeader
    Friend WithEvents time_report As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btn_input_fields As Button
    Friend WithEvents EditRootCauseAnalysisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents witnessed_by As ColumnHeader
    Friend WithEvents supervisor_info_id As ColumnHeader
    Friend WithEvents injured_party_id As ColumnHeader
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblSearchByCategory As Label
    Friend WithEvents cmbSearch As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents equip_pro_damaged_id As ColumnHeader
End Class
