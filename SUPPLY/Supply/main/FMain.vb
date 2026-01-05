Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FMain
    Dim iniFile As String
    Public increment_po As String
    Private customMsg As New customMessageBox

    Private Sub FMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MainMenu.Renderer = New MyRenderer()
        loginchecking()

        load_names()
    End Sub
    Public Sub loginchecking()
        Dim spl As String
        Dim sp As System.Array

        Dim supply, eus As Boolean

        Dim iniFile As String = Application.StartupPath & "\syscon.ini"
        Dim iniFile1 As String = Application.StartupPath & "\syscon1.ini"

        If FileIO.FileSystem.FileExists(iniFile) = True Then
            supply = True
        Else
            supply = False
        End If

        If FileIO.FileSystem.FileExists(iniFile1) = True Then
            'no probem for this execution
            eus = True
        Else
            'need to configure eus
            eus = False
        End If

        If eus = False Or supply = False Then
            FNetwork_Config.ShowDialog()

            For Each ctr As Control In Me.Controls
                ctr.Enabled = False
            Next
            Exit Sub
        End If

        If supply = True Then
            spl = FileIO.FileSystem.ReadAllText(iniFile)
            sp = Split(spl, ";")

            ToolStripGreeting.Text = ""
            ToolStripIpAddress.Text = ""

            With FLogin
                .txtUsername.Focus()
                .txtUsername.Clear()
                .txtPassword.Clear()

                .ShowDialog()
            End With
        End If

        Dim strHostName As String
        strHostName = System.Net.Dns.GetHostName()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        FSupplyTransaction.Activate()
        FSupplyTransaction.MdiParent = Me
        FSupplyTransaction.Dock = DockStyle.Fill
        'enable_disable_buttons_in_supptrans("0")
        FLogin.access_control_enable_disable()
        FSupplyTransaction.Show()
    End Sub

    Private Sub tlstripbtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlstripbtn1.Click
        'FWarehouseItems.Activate()
        'FWarehouseItems.MdiParent = Me
        'FWarehouseItems.Dock = DockStyle.Fill

        'FWarehouseItems.ShowDialog()

        If Utilities.isNotRestrictedTo(cDepartments.WAREHOUSING) Or
            Utilities.isNotRestrictedTo(cDepartments.EQUIPMENT_MONITORING) Or
            Utilities.isNotRestrictedTo(cDepartments.PURCHASING) Or
            Utilities.isNotRestrictedTo(cDepartments.CRUSHING_AND_HAULING) Or
            isAuthenticatedWithoutMessage(auth) Then

            FWarehouseItemsNew.Activate()
            FWarehouseItemsNew.MdiParent = Me
            FWarehouseItemsNew.Dock = DockStyle.Fill

            FWarehouseItemsNew.Show()

        Else
            customMsg.message("error", "You are not allowed to this transaction...", "SMS INFO:")
        End If

    End Sub

    Private Sub HideToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem1.Click
        PictureBox1.Hide()
        PictureBox2.Hide()
        PictureBox3.Hide()

        ToolStrip1.Hide()

    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        PictureBox1.Show()
        PictureBox2.Hide()
        PictureBox3.Hide()

        ToolStrip1.Show()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        If Utilities.isNotRestrictedTo("WAREHOUSING") Or
            Utilities.isNotRestrictedTo("CRUSHING AND HAULING") Or
            isAuthenticatedWithoutMessage(auth) Then

            FPreviousStockCard.Activate()
            FPreviousStockCard.MdiParent = Me
            FPreviousStockCard.Dock = DockStyle.Fill

            FPreviousStockCard.Show()

            FPreviousStackCardFinal.Show()
            FPreviousStockCard.lvList.Enabled = False
            FPreviousStockCard.Btn_for_PreviousStockCard.Enabled = False

            charge_to_destination = 2
            wh_item_destination = 2
        Else
            customMsg.message("error", "You are not allowed to this transaction!", "SMS INFO:")
        End If


    End Sub

    Private Sub BorrowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrowerToolStripMenuItem.Click
        public_fac_tools = "ALL"
        charge_to_destination = 3
        FFacilities_Tools.ShowDialog()

    End Sub

    Private Sub BorrowerViewingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrowerViewingToolStripMenuItem.Click
        form_active("FBorrowedDetails")
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        FRegistrationForm.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FStockCard.ShowDialog()
    End Sub

    Private Sub BorrowedItemMonitoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrowedItemMonitoringToolStripMenuItem.Click
        form_active("FBorrowed_Item_Monitoring")
    End Sub

    Private Sub AddOldFacilitiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddOldFacilitiesToolStripMenuItem.Click
        FOldFacilities.ShowDialog()
    End Sub

    Private Sub AddFacilityItemNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFacilityItemNameToolStripMenuItem.Click
        FBorrower.ShowDialog()
    End Sub

    Private Sub AdminAndOthersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminAndOthersToolStripMenuItem.Click
        If Not isAuthenticated(auth) Then
            Exit Sub
        End If

        charge_to_selection = 2
        FCharge_To.ShowDialog()
    End Sub

    Private Sub RegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterToolStripMenuItem.Click
        FRegistrationForm.ShowDialog()

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click

        'For Each frm As Form In Me.MdiChildren
        '    frm.Close()
        'Next

        'For Each ctr As Control In Me.Controls
        '    ctr.Enabled = False
        'Next

        'SupplierMaintenanceToolStripMenuItem.Enabled = False
        'loginchecking()

        'FileToolStripMenuItem.Enabled = True
        End


    End Sub

    Private Sub SupplierMaintenanceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierMaintenanceToolStripMenuItem1.Click
        If Utilities.isNotRestrictedTo("PURCHASING DEPARTMENT") Or isAuthenticatedWithoutMessage(auth) Then
            FAddSupplier.ShowDialog()
        Else
            customMsg.message("error", "You are not allowed to this transaction!", "SMS INFO:")
        End If
    End Sub

    Private Sub Form1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        form_active("Form1")

    End Sub

    Private Sub ListOfBorrowerItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfBorrowerItemsToolStripMenuItem.Click
        FListofBorrowerItem.ShowDialog()
        FListofBorrowerItem.btn_proceed.Enabled = False

    End Sub

    Private Sub DRListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DRListToolStripMenuItem1.Click
        FDRLIST.Show()

    End Sub

    Private Sub ProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectToolStripMenuItem.Click

        If Not isAuthenticated(auth) Then
            Exit Sub
        End If

        FProject_maintenance.ShowDialog()
    End Sub

    Private Sub SetItemsMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetItemsMaintenanceToolStripMenuItem.Click
        set_item.ShowDialog()

    End Sub

    Private Sub FacAndToolsMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacAndToolsMaintenanceToolStripMenuItem.Click
        FFac_Tools_maintenance.ShowDialog()

    End Sub

    Private Sub QtyTakeoffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QtyTakeoffToolStripMenuItem.Click

    End Sub

    Private Sub AccountSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountSettingsToolStripMenuItem.Click
        FEditUserInfo.ShowDialog()
    End Sub

    Private Sub ItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemsToolStripMenuItem.Click
        If MessageBox.Show("YES: WAREHOUSING AND SUPPLIES" & vbCrLf & "NO: CRUSHING AND HAULING", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            FListOfItems.cmboptions.Text = cDivision.WAREHOUSING_AND_SUPPLY
            FListOfItems.cmboptions.Enabled = False
        Else
            FListOfItems.cmboptions.Text = cDivision.CRUSHING_AND_HAULING
            FListOfItems.cmboptions.Enabled = False
        End If


        button_click_name = ItemsToolStripMenuItem.Name

        'FListOfItems.MdiParent = Me
        FListOfItems.Show()

    End Sub

    Private Sub EquipmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipmentToolStripMenuItem.Click

    End Sub

    Private Sub BulkRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BulkRequestToolStripMenuItem.Click
        FBulkRequest.ShowDialog()

    End Sub

    Private Sub HaulingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HaulingReportToolStripMenuItem.Click
        HauledReport.Show()

    End Sub

    Private Sub MainMenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MainMenu.ItemClicked

    End Sub

    Private Sub QtyTakeoffToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QtyTakeoffToolStripMenuItem1.Click
        form_active("FQty_takeoff")
        FQty_takeoff.Show()
    End Sub

    Private Sub QTOItemsMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QTOItemsMaintenanceToolStripMenuItem.Click
        FQTO_Maintenance.ShowDialog()

    End Sub

    Private Sub AggregatesRSMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggregatesRSMonitoringToolStripMenuItem.Click
        'FAggregates_General_Request.ShowDialog()
        form_active("FAggregates_General_Request")
        FAggregates_General_Request.Show()
    End Sub

    Private Sub ViewVariationOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewVariationOrderToolStripMenuItem.Click
        FVariation_Order.Show()
    End Sub

    Private Sub DRBYPROJECTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRBYPROJECTToolStripMenuItem.Click
        'FSelectedAggregates.Show()
        FStockMonitoring.ShowDialog()

    End Sub

    Private Sub EUSAndSUPPLYSYSTEMUPDATERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EUSAndSUPPLYSYSTEMUPDATERToolStripMenuItem.Click
        Dim StatusDate As String
        StatusDate = InputBox("Enter KJ's password", "Enter password:", " ")

        If StatusDate = " " Then
            MessageBox.Show("You must enter kj's password")
            Exit Sub
        ElseIf StatusDate = "12345" Then
            FEU_and_Supply_Updater.ShowDialog()
            Exit Sub
        Else
            MsgBox("password is invalid...")
        End If

    End Sub

    Private Sub DRLIST2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRLIST2ToolStripMenuItem.Click
        'form_active("FDRLIST1")
        form_active("FDRLIST2")
    End Sub

    Private Sub StockcardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockcardToolStripMenuItem.Click
        StockCard1.Show()

    End Sub

    Private Sub DemandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DemandToolStripMenuItem.Click
        FAggregates_General_Request2.Show()

    End Sub

    Private Sub TempToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TempToolStripMenuItem.Click
        FContract_Item_Name.ShowDialog()
    End Sub

    Private Sub QtyTakeoffBalancesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QtyTakeoffBalancesToolStripMenuItem.Click
        FQty_takeoff_balances.Show()
    End Sub

    Private Sub QTOPartViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QTOPartViewToolStripMenuItem.Click
        FQtyTakeOffPartView.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub

    Private Sub AggregatesBalancesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggregatesBalancesToolStripMenuItem.Click
        FAggregates_Balance.Activate()
        FAggregates_Balance.MdiParent = Me
        FAggregates_Balance.Dock = DockStyle.Fill
        FAggregates_Balance.Show()

    End Sub

    Private Sub WarehouseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseToolStripMenuItem.Click
        If Utilities.isNotRestrictedTo("WAREHOUSING") Or
            Utilities.isNotRestrictedTo("CRUSHING AND HAULING") Or
            isAuthenticatedWithoutMessage(auth) Then

            FWarehouseAreaNew.ShowDialog()
        Else
            customMsg.message("error", "you are not allowed to this transaction!", "SMS INFO:")
        End If
    End Sub

    Private Sub WithdrawalReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Fwithdrawal_kpi_report.ShowDialog()
    End Sub

    Private Sub AccountTitleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AccountTitleToolStripMenuItem1.Click
        If isNotRestrictedTo(cDepartments.FAD) Then
            formAccountTitle.ShowDialog()
            Exit Sub
        End If

        If isAuthenticated(auth) Then
            formAccountTitle.ShowDialog()
        End If

    End Sub

    Private Sub ProperNamingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProperNamingToolStripMenuItem.Click
        Try
            If Utilities.isNotRestrictedTo(cDepartments.PURCHASING) Or
                isAuthenticatedWithoutMessage(auth) Then

                FLinkToProperNaming.isCreateNewProperNames2 = True
                FLinkToProperNaming.ShowDialog()

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class
Public Class MyRenderer
    Inherits ToolStripProfessionalRenderer
    Protected Overloads Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
        Try
            Dim rc As New Rectangle(Point.Empty, e.Item.Size)
            Dim c As Color = IIf(e.Item.Selected, Color.YellowGreen, Color.Transparent)
            Using brush As New SolidBrush(c)
                e.Graphics.FillRectangle(brush, rc)
            End Using
        Catch ex As Exception

        End Try

    End Sub
End Class