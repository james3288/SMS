<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HauledReport
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSearchItems = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbSearchby = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.dtp_to = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_from = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PanelPriview = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnPreview = New System.Windows.Forms.Button()
        Me.txtnoted = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrepared = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LVL_HaulingReport = New System.Windows.Forms.ListView()
        Me.withdrawn_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PROJECT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DATE_SERVED = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ITEM_NAME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.QUANTITY = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UNIT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dateOFrequest = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RS_NO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SOURCE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UNIT_PRICE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TOTAL_AMOUNT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SAND_SOURCE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.REMARKS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SORTING = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.INOUT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.WHS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_summary = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CalculateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanelPriview.SuspendLayout()
        Me.CMS_summary.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1291, 711)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1285, 44)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1248, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(34, 38)
        Me.Panel1.TabIndex = 134
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(6, 6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(23, 22)
        Me.btnExit.TabIndex = 133
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1239, 38)
        Me.Panel2.TabIndex = 135
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(596, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Withdrawal without(RS/WS/DR)"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.LightPink
        Me.PictureBox4.Location = New System.Drawing.Point(570, 11)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(801, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "DR with or without WS"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Honeydew
        Me.PictureBox3.Location = New System.Drawing.Point(775, 11)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1097, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Withdrawal without DR"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(951, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Withdrawal with DR"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Lavender
        Me.PictureBox2.Location = New System.Drawing.Point(1066, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.LightGreen
        Me.PictureBox1.Location = New System.Drawing.Point(925, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(404, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SUMMARY OF HAULED AGGREGATES"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 638)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1285, 70)
        Me.Panel3.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.btnsubmit)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtSearchItems)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.cmbSearchby)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Controls.Add(Me.dtp_to)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtp_from)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1233, 61)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(521, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(524, 35)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(167, 20)
        Me.txtRemarks.TabIndex = 11
        '
        'btnsubmit
        '
        Me.btnsubmit.BackColor = System.Drawing.Color.Transparent
        Me.btnsubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.Location = New System.Drawing.Point(1093, 31)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(127, 25)
        Me.btnsubmit.TabIndex = 7
        Me.btnsubmit.Text = "Submit"
        Me.btnsubmit.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(348, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Search Items:"
        '
        'txtSearchItems
        '
        Me.txtSearchItems.Location = New System.Drawing.Point(351, 35)
        Me.txtSearchItems.Name = "txtSearchItems"
        Me.txtSearchItems.Size = New System.Drawing.Size(167, 20)
        Me.txtSearchItems.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(175, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Type what to search:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(178, 34)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(167, 20)
        Me.txtSearch.TabIndex = 7
        '
        'cmbSearchby
        '
        Me.cmbSearchby.FormattingEnabled = True
        Me.cmbSearchby.Items.AddRange(New Object() {"WH/QUARRY AREA", "SOURCE/CLASSIFICATION", "REMARKS", "PROJECT CHARGES"})
        Me.cmbSearchby.Location = New System.Drawing.Point(9, 34)
        Me.cmbSearchby.Name = "cmbSearchby"
        Me.cmbSearchby.Size = New System.Drawing.Size(163, 21)
        Me.cmbSearchby.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Search by:"
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(972, 31)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(116, 25)
        Me.btnGenerate.TabIndex = 4
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'dtp_to
        '
        Me.dtp_to.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_to.Location = New System.Drawing.Point(830, 34)
        Me.dtp_to.Name = "dtp_to"
        Me.dtp_to.Size = New System.Drawing.Size(133, 21)
        Me.dtp_to.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(827, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "To:"
        '
        'dtp_from
        '
        Me.dtp_from.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_from.Location = New System.Drawing.Point(698, 34)
        Me.dtp_from.Name = "dtp_from"
        Me.dtp_from.Size = New System.Drawing.Size(126, 21)
        Me.dtp_from.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(695, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PanelPriview)
        Me.Panel4.Controls.Add(Me.LVL_HaulingReport)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 53)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1285, 579)
        Me.Panel4.TabIndex = 3
        '
        'PanelPriview
        '
        Me.PanelPriview.Controls.Add(Me.Button1)
        Me.PanelPriview.Controls.Add(Me.BtnPreview)
        Me.PanelPriview.Controls.Add(Me.txtnoted)
        Me.PanelPriview.Controls.Add(Me.Label4)
        Me.PanelPriview.Controls.Add(Me.txtPrepared)
        Me.PanelPriview.Controls.Add(Me.Label7)
        Me.PanelPriview.Location = New System.Drawing.Point(647, 245)
        Me.PanelPriview.Name = "PanelPriview"
        Me.PanelPriview.Size = New System.Drawing.Size(267, 171)
        Me.PanelPriview.TabIndex = 6
        Me.PanelPriview.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(230, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 22)
        Me.Button1.TabIndex = 159
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BtnPreview
        '
        Me.BtnPreview.BackColor = System.Drawing.Color.Transparent
        Me.BtnPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreview.Location = New System.Drawing.Point(13, 126)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(240, 32)
        Me.BtnPreview.TabIndex = 5
        Me.BtnPreview.Text = "Preview"
        Me.BtnPreview.UseVisualStyleBackColor = False
        '
        'txtnoted
        '
        Me.txtnoted.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnoted.Location = New System.Drawing.Point(13, 91)
        Me.txtnoted.Name = "txtnoted"
        Me.txtnoted.Size = New System.Drawing.Size(240, 26)
        Me.txtnoted.TabIndex = 158
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 16)
        Me.Label4.TabIndex = 157
        Me.Label4.Text = "Noted and Verified by:"
        '
        'txtPrepared
        '
        Me.txtPrepared.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepared.Location = New System.Drawing.Point(13, 36)
        Me.txtPrepared.Name = "txtPrepared"
        Me.txtPrepared.Size = New System.Drawing.Size(240, 26)
        Me.txtPrepared.TabIndex = 155
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 16)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "Prepared by:"
        '
        'LVL_HaulingReport
        '
        Me.LVL_HaulingReport.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.withdrawn_id, Me.PROJECT, Me.DATE_SERVED, Me.ITEM_NAME, Me.QUANTITY, Me.UNIT, Me.dateOFrequest, Me.RS_NO, Me.SOURCE, Me.UNIT_PRICE, Me.TOTAL_AMOUNT, Me.SAND_SOURCE, Me.REMARKS, Me.SORTING, Me.INOUT, Me.ColumnHeader1, Me.ColumnHeader2, Me.WHS})
        Me.LVL_HaulingReport.ContextMenuStrip = Me.CMS_summary
        Me.LVL_HaulingReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LVL_HaulingReport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVL_HaulingReport.FullRowSelect = True
        Me.LVL_HaulingReport.GridLines = True
        Me.LVL_HaulingReport.HideSelection = False
        Me.LVL_HaulingReport.Location = New System.Drawing.Point(0, 0)
        Me.LVL_HaulingReport.Name = "LVL_HaulingReport"
        Me.LVL_HaulingReport.Size = New System.Drawing.Size(1285, 579)
        Me.LVL_HaulingReport.TabIndex = 0
        Me.LVL_HaulingReport.UseCompatibleStateImageBehavior = False
        Me.LVL_HaulingReport.View = System.Windows.Forms.View.Details
        '
        'withdrawn_id
        '
        Me.withdrawn_id.Text = "wd_id"
        '
        'PROJECT
        '
        Me.PROJECT.Text = "PROJECT/DESTINATION"
        Me.PROJECT.Width = 300
        '
        'DATE_SERVED
        '
        Me.DATE_SERVED.Text = "DATE SERVED"
        Me.DATE_SERVED.Width = 120
        '
        'ITEM_NAME
        '
        Me.ITEM_NAME.Text = "ITEM NAME"
        Me.ITEM_NAME.Width = 500
        '
        'QUANTITY
        '
        Me.QUANTITY.DisplayIndex = 6
        Me.QUANTITY.Text = "QUANTITY"
        Me.QUANTITY.Width = 110
        '
        'UNIT
        '
        Me.UNIT.DisplayIndex = 7
        Me.UNIT.Text = "UNIT"
        Me.UNIT.Width = 90
        '
        'dateOFrequest
        '
        Me.dateOFrequest.DisplayIndex = 8
        Me.dateOFrequest.Text = "DATE OF REQUEST"
        Me.dateOFrequest.Width = 300
        '
        'RS_NO
        '
        Me.RS_NO.DisplayIndex = 9
        Me.RS_NO.Text = "RS NO."
        Me.RS_NO.Width = 120
        '
        'SOURCE
        '
        Me.SOURCE.DisplayIndex = 10
        Me.SOURCE.Text = "SOURCE"
        Me.SOURCE.Width = 300
        '
        'UNIT_PRICE
        '
        Me.UNIT_PRICE.DisplayIndex = 11
        Me.UNIT_PRICE.Text = "UNIT PRICE"
        Me.UNIT_PRICE.Width = 120
        '
        'TOTAL_AMOUNT
        '
        Me.TOTAL_AMOUNT.DisplayIndex = 12
        Me.TOTAL_AMOUNT.Text = "TOTAL AMOUNT"
        Me.TOTAL_AMOUNT.Width = 120
        '
        'SAND_SOURCE
        '
        Me.SAND_SOURCE.DisplayIndex = 4
        Me.SAND_SOURCE.Text = "SOURCE"
        Me.SAND_SOURCE.Width = 0
        '
        'REMARKS
        '
        Me.REMARKS.DisplayIndex = 5
        Me.REMARKS.Text = "REMARKS"
        Me.REMARKS.Width = 200
        '
        'SORTING
        '
        Me.SORTING.Text = "SORTING"
        Me.SORTING.Width = 0
        '
        'INOUT
        '
        Me.INOUT.Text = "IN/OUT"
        Me.INOUT.Width = 150
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ws_no"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DR NO"
        Me.ColumnHeader2.Width = 200
        '
        'WHS
        '
        Me.WHS.Text = "Warehouse Area"
        '
        'CMS_summary
        '
        Me.CMS_summary.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalculateToolStripMenuItem})
        Me.CMS_summary.Name = "CMS_summary"
        Me.CMS_summary.Size = New System.Drawing.Size(124, 26)
        '
        'CalculateToolStripMenuItem
        '
        Me.CalculateToolStripMenuItem.Name = "CalculateToolStripMenuItem"
        Me.CalculateToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.CalculateToolStripMenuItem.Text = "Calculate"
        '
        'HauledReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1291, 711)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "HauledReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HauledReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.PanelPriview.ResumeLayout(False)
        Me.PanelPriview.PerformLayout()
        Me.CMS_summary.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LVL_HaulingReport As ListView
    Friend WithEvents withdrawn_id As ColumnHeader
    Friend WithEvents PROJECT As ColumnHeader
    Friend WithEvents DATE_SERVED As ColumnHeader
    Friend WithEvents ITEM_NAME As ColumnHeader
    Friend WithEvents QUANTITY As ColumnHeader
    Friend WithEvents UNIT As ColumnHeader
    Friend WithEvents dateOFrequest As ColumnHeader
    Friend WithEvents RS_NO As ColumnHeader
    Friend WithEvents SOURCE As ColumnHeader
    Friend WithEvents UNIT_PRICE As ColumnHeader
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnExit As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtp_to As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtp_from As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGenerate As Button
    Friend WithEvents TOTAL_AMOUNT As ColumnHeader
    Friend WithEvents BtnPreview As Button
    Friend WithEvents PanelPriview As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents txtnoted As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPrepared As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnsubmit As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CMS_summary As ContextMenuStrip
    Friend WithEvents CalculateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SAND_SOURCE As ColumnHeader
    Friend WithEvents REMARKS As ColumnHeader
    Friend WithEvents cmbSearchby As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents SORTING As ColumnHeader
    Friend WithEvents INOUT As ColumnHeader
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSearchItems As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents WHS As ColumnHeader
End Class
