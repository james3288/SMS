Public Class Fwarehouse_Kpi_Preview_Report
    Private Sub Fwarehouse_Kpi_Preview_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Fwithdrawal_kpi_report.txtProjectPercent.Text = Fwithdrawal_kpi_report.txtProjectPercent.Text.Replace("%", "").Trim()
        'Fwithdrawal_kpi_report.txtEquipPercent.Text = Fwithdrawal_kpi_report.txtEquipPercent.Text.Replace("%", "").Trim()
        'Fwithdrawal_kpi_report.txtAdminPercent.Text = Fwithdrawal_kpi_report.txtAdminPercent.Text.Replace("%", "").Trim()
        'Fwithdrawal_kpi_report.txtFastMovingPercent.Text = Fwithdrawal_kpi_report.txtFastMovingPercent.Text.Replace("%", "").Trim()
        'Fwithdrawal_kpi_report.txtMediumMovingPercent.Text = Fwithdrawal_kpi_report.txtMediumMovingPercent.Text.Replace("%", "").Trim()
        'Fwithdrawal_kpi_report.txtFastMovingPercent.Text = Fwithdrawal_kpi_report.txtFastMovingPercent.Text.Replace("%", "").Trim()
        'Fwithdrawal_kpi_report.txtSlowMovingPercent.Text = Fwithdrawal_kpi_report.txtSlowMovingPercent.Text.Replace("%", "").Trim()
        merging_Data_For_Kpi_Report1()
        merging_Data_For_Kpi_Report2()


    End Sub

    Private Sub merging_Data_For_Kpi_Report1()
        lvlPreviewTypeRequestReport.Columns.Clear()
        lvlPreviewTypeRequestReport.Items.Clear()
        'Dim kpiA As Decimal = Fwithdrawal_kpi_report.txtProjectPercent.Text
        'Dim kpiB As Decimal = Fwithdrawal_kpi_report.txtEquipPercent.Text
        'Dim kpiC As Decimal = Fwithdrawal_kpi_report.txtAdminPercent.Text
        Dim sliceProjectPercent As String = Fwithdrawal_kpi_report.txtProjectPercent.Text.Replace("%", "").Trim()
        Dim sliceEquipmentPercent As String = Fwithdrawal_kpi_report.txtEquipPercent.Text.Replace("%", "").Trim()
        Dim sliceAdminPercent As String = Fwithdrawal_kpi_report.txtAdminPercent.Text.Replace("%", "").Trim()

        Dim kpiA As Decimal = If(sliceProjectPercent.Trim() = "",
                         0D,
                         CDec(sliceProjectPercent))

        Dim kpiB As Decimal = If(sliceEquipmentPercent.Trim() = "",
                         0D,
                         CDec(sliceEquipmentPercent))

        Dim kpiC As Decimal = If(sliceAdminPercent.Trim() = "",
                         0D,
                         CDec(sliceAdminPercent))




        Dim ontimeProject As Decimal = 0.0
        Dim ontimeEquip As Decimal = 0.0
        Dim ontimeAdmin As Decimal = 0.0

        Dim allRsProject As Decimal = 0.0
        Dim allRsEquip As Decimal = 0.0
        Dim allRsAdmin As Decimal = 0.0

        Dim projectRemarks As String = ""
        Dim equipRemarks As String = ""
        Dim adminRemarks As String = ""


        lvlPreviewTypeRequestReport.Columns.Add("Details", 370)
        lvlPreviewTypeRequestReport.Columns.Add("Project", 200)
        lvlPreviewTypeRequestReport.Columns.Add("Equipment", 200)
        lvlPreviewTypeRequestReport.Columns.Add("Admin", 200)


        'lvlPreviewReport.Font = New Font("Arial", 10)

        ' ========== 1st row: All ==========
        Dim rowAll(3) As String
        rowAll(0) = "Total No. of Requisition Slip:"
        rowAll(1) = If(Fwithdrawal_kpi_report.lvlProject.Items.Count > 0 AndAlso Fwithdrawal_kpi_report.lvlProject.Items(0).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlProject.Items(0).SubItems(2).Text, "")
        rowAll(2) = If(Fwithdrawal_kpi_report.lvlEquipment.Items.Count > 0 AndAlso Fwithdrawal_kpi_report.lvlEquipment.Items(0).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlEquipment.Items(0).SubItems(2).Text, "")
        rowAll(3) = If(Fwithdrawal_kpi_report.lvlAdmin.Items.Count > 0 AndAlso Fwithdrawal_kpi_report.lvlAdmin.Items(0).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlAdmin.Items(0).SubItems(2).Text, "")
        allRsProject = rowAll(1)
        allRsEquip = rowAll(2)
        allRsAdmin = rowAll(3)
        lvlPreviewTypeRequestReport.Items.Add(New ListViewItem(rowAll))

        ' ========== 2nd row: Ontime ==========
        Dim rowOntime(3) As String
        rowOntime(0) = "No. of Request Process on time:"
        rowOntime(1) = If(Fwithdrawal_kpi_report.lvlProject.Items.Count > 1 AndAlso Fwithdrawal_kpi_report.lvlProject.Items(1).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlProject.Items(1).SubItems(2).Text, "")
        rowOntime(2) = If(Fwithdrawal_kpi_report.lvlEquipment.Items.Count > 1 AndAlso Fwithdrawal_kpi_report.lvlEquipment.Items(1).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlEquipment.Items(1).SubItems(2).Text, "")
        rowOntime(3) = If(Fwithdrawal_kpi_report.lvlAdmin.Items.Count > 1 AndAlso Fwithdrawal_kpi_report.lvlAdmin.Items(1).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlAdmin.Items(1).SubItems(2).Text, "")
        ontimeProject = rowOntime(1)
        ontimeEquip = rowOntime(2)
        ontimeAdmin = rowOntime(3)
        lvlPreviewTypeRequestReport.Items.Add(New ListViewItem(rowOntime))


        Dim projectPercentResult As Decimal
        Dim equipmentPercentResult As Decimal
        Dim adminPercentResult As Decimal

        If allRsProject = 0 Then
            projectPercentResult = 0
        Else
            projectPercentResult = (Math.Truncate((ontimeProject / allRsProject) * 100 * 100) / 100).ToString("F2")
        End If

        If allRsEquip = 0 Then
            equipmentPercentResult = 0
        Else
            equipmentPercentResult = (Math.Truncate((ontimeEquip / allRsEquip) * 100 * 100) / 100).ToString("F2")
        End If

        If allRsAdmin = 0 Then
            adminPercentResult = 0
        Else
            adminPercentResult = (Math.Truncate((ontimeAdmin / allRsAdmin) * 100 * 100) / 100).ToString("F2")
        End If

        Dim a1 As String = projectPercentResult
        Dim a2 As String = equipmentPercentResult
        Dim a3 As String = adminPercentResult

        ' ========== 3rd row: Percentage ==========
        Dim rowPercent() As String = {"Percentage of Requests Process On Time", a1 + "%",
            a2 + "%",
            a3 + "%"}
        lvlPreviewTypeRequestReport.Items.Add(New ListViewItem(rowPercent))

        If (projectPercentResult >= sliceProjectPercent) Then
            projectRemarks = "Targe Achieved"
        Else
            projectRemarks = "Target Not Achieved"
        End If

        If (equipmentPercentResult >= sliceEquipmentPercent) Then
            equipRemarks = "Targe Achieved"
        Else
            equipRemarks = "Target Not Achieved"
        End If

        If (adminPercentResult >= sliceAdminPercent) Then
            adminRemarks = "Targe Achieved"
        Else
            adminRemarks = "Target Not Achieved"
        End If

        ' ========== 4th row: Remarks ==========
        Dim rowRemarks() As String = {"Remarks:", projectRemarks, equipRemarks, adminRemarks}
        lvlPreviewTypeRequestReport.Items.Add(New ListViewItem(rowRemarks))

        ' ========== 5th row: Late ==========
        Dim rowLate(3) As String
        rowLate(0) = "No. of RS Late process"
        rowLate(1) = If(Fwithdrawal_kpi_report.lvlProject.Items.Count > 2 AndAlso Fwithdrawal_kpi_report.lvlProject.Items(2).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlProject.Items(2).SubItems(2).Text, "")
        rowLate(2) = If(Fwithdrawal_kpi_report.lvlEquipment.Items.Count > 2 AndAlso Fwithdrawal_kpi_report.lvlEquipment.Items(2).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlEquipment.Items(2).SubItems(2).Text, "")
        rowLate(3) = If(Fwithdrawal_kpi_report.lvlAdmin.Items.Count > 2 AndAlso Fwithdrawal_kpi_report.lvlAdmin.Items(2).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlAdmin.Items(2).SubItems(2).Text, "")
        lvlPreviewTypeRequestReport.Items.Add(New ListViewItem(rowLate))

        lvlPreviewTypeRequestReport.OwnerDraw = True

        AddHandler lvlPreviewTypeRequestReport.DrawColumnHeader,
            Sub(s, ev)
                ev.DrawBackground()
                Using f As New Font("Bombardier", 12, FontStyle.Bold)
                    TextRenderer.DrawText(ev.Graphics, ev.Header.Text, f, ev.Bounds, Color.Black, TextFormatFlags.HorizontalCenter)
                End Using
            End Sub

        AddHandler lvlPreviewTypeRequestReport.DrawItem,
       Sub(s, ev)
           ev.DrawDefault = True
       End Sub

        AddHandler lvlPreviewTypeRequestReport.DrawSubItem,
            Sub(s, ev)
                Using f As New Font("Bombardier", 10, FontStyle.Regular)
                    TextRenderer.DrawText(ev.Graphics, ev.SubItem.Text, f, ev.Bounds, Color.Black, TextFormatFlags.Left)
                End Using
            End Sub

    End Sub



    Private Sub merging_Data_For_Kpi_Report2()
        lvlPreviewMovingCatReport.Columns.Clear()
        lvlPreviewMovingCatReport.Items.Clear()

        Dim sliceFastPercent As String = Fwithdrawal_kpi_report.txtFastMovingPercent.Text.Replace("%", "").Trim()
        Dim sliceMediumPercent As String = Fwithdrawal_kpi_report.txtMediumMovingPercent.Text.Replace("%", "").Trim()
        Dim sliceSlowPercent As String = Fwithdrawal_kpi_report.txtSlowMovingPercent.Text.Replace("%", "").Trim()

        Dim kpiA As Decimal = If(sliceFastPercent.Trim() = "",
                         0D,
                         CDec(sliceFastPercent))

        Dim kpiB As Decimal = If(sliceMediumPercent.Trim() = "",
                         0D,
                         CDec(sliceMediumPercent))

        Dim kpiC As Decimal = If(sliceSlowPercent.Trim() = "",
                         0D,
                         CDec(sliceSlowPercent))

        Dim ontimeFast As Decimal = 0.0
        Dim ontimeMedium As Decimal = 0.0
        Dim ontimeSlow As Decimal = 0.0

        Dim allRsFast As Decimal = 0.0
        Dim allRsMedium As Decimal = 0.0
        Dim allRsSlow As Decimal = 0.0

        Dim fastRemarks As String = ""
        Dim mediumRemarks As String = ""
        Dim slowRemarks As String = ""


        lvlPreviewMovingCatReport.Columns.Add("Details", 370)
        lvlPreviewMovingCatReport.Columns.Add("Fast Moving Items", 200)
        lvlPreviewMovingCatReport.Columns.Add("Medium Moving Items", 200)
        lvlPreviewMovingCatReport.Columns.Add("Slow Moving Items", 200)


        'lvlPreviewReport.Font = New Font("Arial", 10)

        ' ========== 1st row: All ==========
        Dim rowAll(3) As String
        rowAll(0) = "Total No. of Requisition Slip:"
        rowAll(1) = If(Fwithdrawal_kpi_report.lvlFastMoving.Items.Count > 0 AndAlso Fwithdrawal_kpi_report.lvlFastMoving.Items(0).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlFastMoving.Items(0).SubItems(2).Text, "")
        rowAll(2) = If(Fwithdrawal_kpi_report.lvlMediumMoving.Items.Count > 0 AndAlso Fwithdrawal_kpi_report.lvlMediumMoving.Items(0).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlMediumMoving.Items(0).SubItems(2).Text, "")
        rowAll(3) = If(Fwithdrawal_kpi_report.lvlSlowMoving.Items.Count > 0 AndAlso Fwithdrawal_kpi_report.lvlSlowMoving.Items(0).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlSlowMoving.Items(0).SubItems(2).Text, "")
        allRsFast = rowAll(1)
        allRsMedium = rowAll(2)
        allRsSlow = rowAll(3)
        lvlPreviewMovingCatReport.Items.Add(New ListViewItem(rowAll))

        ' ========== 2nd row: Ontime ==========
        Dim rowOntime(3) As String
        rowOntime(0) = "No. of Request Process on time:"
        rowOntime(1) = If(Fwithdrawal_kpi_report.lvlFastMoving.Items.Count > 1 AndAlso Fwithdrawal_kpi_report.lvlFastMoving.Items(1).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlFastMoving.Items(1).SubItems(2).Text, "")
        rowOntime(2) = If(Fwithdrawal_kpi_report.lvlMediumMoving.Items.Count > 1 AndAlso Fwithdrawal_kpi_report.lvlMediumMoving.Items(1).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlMediumMoving.Items(1).SubItems(2).Text, "")
        rowOntime(3) = If(Fwithdrawal_kpi_report.lvlSlowMoving.Items.Count > 1 AndAlso Fwithdrawal_kpi_report.lvlSlowMoving.Items(1).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlSlowMoving.Items(1).SubItems(2).Text, "")
        ontimeFast = rowOntime(1)
        ontimeMedium = rowOntime(2)
        ontimeSlow = rowOntime(3)
        lvlPreviewMovingCatReport.Items.Add(New ListViewItem(rowOntime))

        Dim fastPercentResult As Decimal
        Dim mediumPercentResult As Decimal
        Dim slowPercentResult As Decimal

        If allRsFast = 0 Then
            fastPercentResult = 0
        Else
            fastPercentResult = (Math.Truncate((ontimeFast / allRsFast) * 100 * 100) / 100).ToString("F2")
        End If

        If allRsSlow = 0 Then
            slowPercentResult = 0
        Else
            slowPercentResult = (Math.Truncate((ontimeSlow / allRsSlow) * 100 * 100) / 100).ToString("F2")
        End If

        If allRsMedium = 0 Then
            mediumPercentResult = 0
        Else
            mediumPercentResult = (Math.Truncate((ontimeMedium / allRsMedium) * 100 * 100) / 100).ToString("F2")
        End If


        Dim a1 As String = fastPercentResult
        Dim a2 As String = mediumPercentResult
        Dim a3 As String = slowPercentResult
        ' ========== 3rd row: Percentage ==========
        Dim rowPercent() As String = {"Percentage of Requests Process On Time", a1 + "%",
            a2 + "%",
            a3 + "%"}
        lvlPreviewMovingCatReport.Items.Add(New ListViewItem(rowPercent))

        If (fastPercentResult >= sliceFastPercent) Then
            fastRemarks = "Targe Achieved"
        Else
            fastRemarks = "Target Not Achieved"
        End If

        If (mediumPercentResult >= sliceMediumPercent) Then
            mediumRemarks = "Targe Achieved"
        Else
            mediumRemarks = "Target Not Achieved"
        End If

        If (slowPercentResult >= sliceSlowPercent) Then
            slowRemarks = "Targe Achieved"
        Else
            slowRemarks = "Target Not Achieved"
        End If

        ' ========== 4th row: Remarks ==========
        Dim rowRemarks() As String = {"Remarks:", fastRemarks, mediumRemarks, slowRemarks}
        lvlPreviewMovingCatReport.Items.Add(New ListViewItem(rowRemarks))

        ' ========== 5th row: Late ==========
        Dim rowLate(3) As String
        rowLate(0) = "No. of RS Late process"
        rowLate(1) = If(Fwithdrawal_kpi_report.lvlFastMoving.Items.Count > 2 AndAlso Fwithdrawal_kpi_report.lvlFastMoving.Items(2).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlFastMoving.Items(2).SubItems(2).Text, "")
        rowLate(2) = If(Fwithdrawal_kpi_report.lvlMediumMoving.Items.Count > 2 AndAlso Fwithdrawal_kpi_report.lvlMediumMoving.Items(2).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlMediumMoving.Items(2).SubItems(2).Text, "")
        rowLate(3) = If(Fwithdrawal_kpi_report.lvlSlowMoving.Items.Count > 2 AndAlso Fwithdrawal_kpi_report.lvlSlowMoving.Items(2).SubItems.Count > 2, Fwithdrawal_kpi_report.lvlSlowMoving.Items(2).SubItems(2).Text, "")
        lvlPreviewMovingCatReport.Items.Add(New ListViewItem(rowLate))

        lvlPreviewMovingCatReport.OwnerDraw = True

        AddHandler lvlPreviewMovingCatReport.DrawColumnHeader,
            Sub(s, ev)
                ev.DrawBackground()
                Using f As New Font("Bombardier", 12, FontStyle.Bold)
                    TextRenderer.DrawText(ev.Graphics, ev.Header.Text, f, ev.Bounds, Color.Black, TextFormatFlags.HorizontalCenter)
                End Using
            End Sub

        AddHandler lvlPreviewMovingCatReport.DrawItem,
       Sub(s, ev)
           ev.DrawDefault = True
       End Sub

        AddHandler lvlPreviewMovingCatReport.DrawSubItem,
            Sub(s, ev)
                Using f As New Font("Bombardier", 10, FontStyle.Regular)
                    TextRenderer.DrawText(ev.Graphics, ev.SubItem.Text, f, ev.Bounds, Color.Black, TextFormatFlags.Left)
                End Using
            End Sub

    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        preview_warehouse_kpi_report()
    End Sub


    Public Sub preview_warehouse_kpi_report()
        'Dim PrevFromDate As DateTime = DTP_PrevFrom.Value
        'Dim PrevToDate As DateTime = DTP_PrevTo.Value

        'Dim CurFromDate As DateTime = DTP_CurFrom.Value
        'Dim CurToDate As DateTime = DTP_CurTo.Value

        'Dim resultStringPrev As String = $"{PrevFromDate.ToString("MMM d", CultureInfo.InvariantCulture)}-{PrevToDate.ToString("MMM d, yyyy", CultureInfo.InvariantCulture)}"
        'lblDatePrevRange.Text = resultStringPrev

        'Dim resultStringCur As String = $"{CurFromDate.ToString("MMM d", CultureInfo.InvariantCulture)}-{CurToDate.ToString("MMM d, yyyy", CultureInfo.InvariantCulture)}"
        'lblDateCurRange.Text = resultStringCur

        Dim kpi_data As New DataTable
        Dim kpi_data2 As New DataTable
        Dim i As Integer = 0
        Dim i2 As Integer = 0

        With kpi_data
            .Columns.Add("Details")
            .Columns.Add("Project")
            .Columns.Add("Equipment")
            .Columns.Add("Admin")

        End With
        For i = 0 To lvlPreviewTypeRequestReport.Items.Count - 1
            kpi_data.Rows.Add(kpi_data.NewRow)
            kpi_data.Rows(i).Item("Details") = lvlPreviewTypeRequestReport.Items(i).SubItems(0).Text
            kpi_data.Rows(i).Item("Project") = lvlPreviewTypeRequestReport.Items(i).SubItems(1).Text
            kpi_data.Rows(i).Item("Equipment") = lvlPreviewTypeRequestReport.Items(i).SubItems(2).Text
            kpi_data.Rows(i).Item("Admin") = lvlPreviewTypeRequestReport.Items(i).SubItems(3).Text
        Next

        With kpi_data2
            .Columns.Add("Details")
            .Columns.Add("Fast")
            .Columns.Add("Medium")
            .Columns.Add("Slow")

        End With
        For i2 = 0 To lvlPreviewMovingCatReport.Items.Count - 1
            kpi_data2.Rows.Add(kpi_data2.NewRow)
            kpi_data2.Rows(i2).Item("Details") = lvlPreviewMovingCatReport.Items(i2).SubItems(0).Text
            kpi_data2.Rows(i2).Item("Fast") = lvlPreviewMovingCatReport.Items(i2).SubItems(1).Text
            kpi_data2.Rows(i2).Item("Medium") = lvlPreviewMovingCatReport.Items(i2).SubItems(2).Text
            kpi_data2.Rows(i2).Item("Slow") = lvlPreviewMovingCatReport.Items(i2).SubItems(3).Text
        Next

        Dim viewEMs As New DataView(kpi_data)
        Dim viewEMs2 As New DataView(kpi_data2)
        Fwithdrawal_kpi_report_form.ReportViewer1.LocalReport.DataSources.Item(0).Value = viewEMs
        Fwithdrawal_kpi_report_form.ReportViewer1.LocalReport.DataSources.Item(1).Value = viewEMs2
        Fwithdrawal_kpi_report_form.ShowDialog()
        Fwithdrawal_kpi_report_form.Dispose()
    End Sub
End Class