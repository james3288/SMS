Public Class FReportable_Data


    Private Sub FReportable_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For Each item2c As DataGridViewRow In FEquipment_monitoring.DataGridView1.Rows
        '    lvl_equipment_monitoring.Items.Add(item2c.Clone)
        'Next
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox12.Checked = True
        CheckBox13.Checked = True
        CheckBox14.Checked = True


        'lvl_equipment_monitoring.Items.Add(FEquipment_monitoring.lvl_equipment_monitoring.Items(0).Clone)
    End Sub

    Sub hide_show_column(ByVal checkbox As CheckBox, ByVal column As Integer, ByVal width As Integer)
        If checkbox.Checked Then
            lvl_equipment_monitoring.Columns(column).Width = width
        Else
            lvl_equipment_monitoring.Columns(column).Width = 0
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        hide_show_column(sender, 1, 110)
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        hide_show_column(sender, 2, 210)
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        hide_show_column(sender, 3, 210)
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        hide_show_column(sender, 4, 210)
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        hide_show_column(sender, 5, 210)
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        hide_show_column(sender, 6, 150)
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        hide_show_column(sender, 7, 150)
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        hide_show_column(sender, 8, 150)
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        hide_show_column(sender, 9, 125)
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        hide_show_column(sender, 10, 125)
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        hide_show_column(sender, 11, 120)
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        hide_show_column(sender, 12, 120)
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        hide_show_column(sender, 13, 100)
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        hide_show_column(sender, 14, 120)
    End Sub

    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        hide_show_column(sender, 15, 110)
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        hide_show_column(sender, 16, 120)
    End Sub

    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        hide_show_column(sender, 18, 100)
    End Sub

    Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        hide_show_column(sender, 19, 200)
    End Sub

    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        hide_show_column(sender, 20, 150)
    End Sub
End Class