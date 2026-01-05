Public Class PO_report_view
    Private Sub PO_report_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim supplier_po(0) As Microsoft.Reporting.WinForms.ReportParameter
        supplier_po(0) = New Microsoft.Reporting.WinForms.ReportParameter("supplier_po", CreatePurchaseOrderForm.supplier_po.ToString)
        ReportViewer1.LocalReport.SetParameters(supplier_po)

        'Dim rs_no(0) As Microsoft.Reporting.WinForms.ReportParameter
        'rs_no(0) = New Microsoft.Reporting.WinForms.ReportParameter("rs_no", FPurchasedOrderList.all_rs_no.ToString)
        'ReportViewer1.LocalReport.SetParameters(rs_no)

        Dim rs_no(0) As Microsoft.Reporting.WinForms.ReportParameter
        rs_no(0) = New Microsoft.Reporting.WinForms.ReportParameter("rs_no", CreatePurchaseOrderForm.txtRsNo.Text)
        ReportViewer1.LocalReport.SetParameters(rs_no)


        Dim instruct(0) As Microsoft.Reporting.WinForms.ReportParameter
        instruct(0) = New Microsoft.Reporting.WinForms.ReportParameter("instruct", CreatePurchaseOrderForm.txtInstruction.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(instruct)

        Dim prepby(0) As Microsoft.Reporting.WinForms.ReportParameter
        prepby(0) = New Microsoft.Reporting.WinForms.ReportParameter("prepby", CreatePurchaseOrderForm.txtPreparedBy.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(prepby)

        Dim checkby(0) As Microsoft.Reporting.WinForms.ReportParameter
        checkby(0) = New Microsoft.Reporting.WinForms.ReportParameter("checkby", CreatePurchaseOrderForm.txtCheckedBy.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(checkby)

        Dim appby(0) As Microsoft.Reporting.WinForms.ReportParameter
        appby(0) = New Microsoft.Reporting.WinForms.ReportParameter("appby", CreatePurchaseOrderForm.txtApprovedBy.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(appby)

        Dim dateneed(0) As Microsoft.Reporting.WinForms.ReportParameter
        dateneed(0) = New Microsoft.Reporting.WinForms.ReportParameter("dateneed", CreatePurchaseOrderForm.dtpDateNeeded.Value.ToString("MM/dd/yyyy"))
        ReportViewer1.LocalReport.SetParameters(dateneed)


        Dim podate(0) As Microsoft.Reporting.WinForms.ReportParameter
        podate(0) = New Microsoft.Reporting.WinForms.ReportParameter("podate", CreatePurchaseOrderForm.dtpPoDate.Value.ToString("MM/dd/yyyy"))
        ReportViewer1.LocalReport.SetParameters(podate)

        Dim address(0) As Microsoft.Reporting.WinForms.ReportParameter
        address(0) = New Microsoft.Reporting.WinForms.ReportParameter("address", CreatePurchaseOrderForm.suplier_address.ToString)
        ReportViewer1.LocalReport.SetParameters(address)

        'Dim charge_tos(0) As Microsoft.Reporting.WinForms.ReportParameter
        'charge_tos(0) = New Microsoft.Reporting.WinForms.ReportParameter("charge_tos", FPOFORM.charge_tos.ToString)
        'ReportViewer1.LocalReport.SetParameters(charge_tos)

        If CreatePurchaseOrderForm.lblRsID.Text = "PERSONAL" Then
            Dim charge_tos(0) As Microsoft.Reporting.WinForms.ReportParameter
            charge_tos(0) = New Microsoft.Reporting.WinForms.ReportParameter("charge_tos", "ADFIL-PERSONAL")
            ReportViewer1.LocalReport.SetParameters(charge_tos)
        Else
            Dim charge_tos(0) As Microsoft.Reporting.WinForms.ReportParameter
            charge_tos(0) = New Microsoft.Reporting.WinForms.ReportParameter("charge_tos", CreatePurchaseOrderForm.all_charges.ToString)
            ReportViewer1.LocalReport.SetParameters(charge_tos)
        End If

        Dim terms(0) As Microsoft.Reporting.WinForms.ReportParameter
        terms(0) = New Microsoft.Reporting.WinForms.ReportParameter("terms", CreatePurchaseOrderForm.terms.ToString)
        ReportViewer1.LocalReport.SetParameters(terms)

        Dim requestor(0) As Microsoft.Reporting.WinForms.ReportParameter
        requestor(0) = New Microsoft.Reporting.WinForms.ReportParameter("requestor", CreatePurchaseOrderForm.requestor_m.ToString)
        ReportViewer1.LocalReport.SetParameters(requestor)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class