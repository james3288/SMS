Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO

Module SupplyModule
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Function searchItemID(ByVal val1 As String, ByVal val2 As String) As String
        'MessageBox.Show("1 : " & val1 & ", 2 : " & val2)
        Try
            SQLcon.connection.Open()

            publicquery = "select top 1 wh_id from dbwarehouse_items where whItem = '" & val1 & "' and whItemDesc = '" & val2 & "'"
            cmd = New SqlCommand(publicquery, SQLcon.connection)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                searchItemID = sqldr.GetValue(0).ToString
            End While
        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Function

    Sub createItemImageFile(ByVal itemNumber As String)
        Dim imagedata As String = createItemImageText()
        Dim SavePath As String = System.IO.Path.Combine("c:\Supply_Folder_temp\item_Image", "item_" & itemNumber & ".text")
        If System.IO.File.Exists(SavePath) Then
        Else
            Dim filepath As String = "c:\Supply_Folder_temp\item_Image\item_" & itemNumber & ".text"
            Dim stringtowrite As String = imagedata
            File.WriteAllText(filepath, stringtowrite)
        End If
    End Sub
    'System.IO.File.Delete( FileToDelete )
    Sub updateItemImageFile(ByVal itemNumber As String)
        Dim imagedata As String = createItemImageText()
        Dim SavePath As String = System.IO.Path.Combine("c:\Supply_Folder_temp\item_Image", "item_" & itemNumber & ".text")
        If System.IO.File.Exists(SavePath) Then
            Dim filepath As String = "c:\Supply_Folder_temp\item_Image\item_" & itemNumber & ".text"
            System.IO.File.Delete(filepath)
            Dim stringtowrite As String = imagedata
            File.WriteAllText(filepath, stringtowrite)
        Else
            Dim filepath As String = "c:\Supply_Folder_temp\item_Image\item_" & itemNumber & ".text"
            'System.IO.File.Delete(filepath)
            Dim stringtowrite As String = imagedata
            File.WriteAllText(filepath, stringtowrite)
        End If
    End Sub
    Sub readItemImage(ByVal itemNumber As String)
        'MessageBox.Show(itemNumber)
        Dim image_data As String = ""
        itemNumber = itemNumber.Replace(" ", "")
        Dim image_id As String = "c:\Supply_Folder_temp\item_Image\item_" & itemNumber & ".text"
        'MessageBox.Show(image_id)
        Try


            Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(image_id)
            Dim a As String
            Do
                a = reader.ReadLine
                image_data = image_data + a
            Loop Until a Is Nothing
            reader.Close()

        Catch ex As Exception
            image_data = ""
            image_data = "/9j/4AAQSkZJRgABAQEAYABgAAD/4QBaRXhpZgAATU0AKgAAAAgABQMBAAUAAAABAAAASgMDAAEAAAABAAAAAFEQAAEAAAABAQAAAFERAAQAAAABAAAAAFESAAQAAAABAAAAAAAAAAAAAYagAACxj//bAEMACAYGBwYFCAcHBwkJCAoMFA0MCwsMGRITDxQdGh8eHRocHCAkLicgIiwjHBwoNyksMDE0NDQfJzk9ODI8LjM0Mv/bAEMBCQkJDAsMGA0NGDIhHCEyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMv/AABEIAcIBwgMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABAncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/APf6KKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAornvEniM6Tst7ZVa5cbiW5CD/GuU/4SzW8/wDH7j/tkn+FAHplFeZf8JXrf/P7/wCQk/wo/wCEr1v/AJ/f/ISf4UAem0V5l/wlet/8/v8A5CT/AAo/4SvW/wDn9/8AISf4UAem0V5l/wAJXrf/AD+/+Qk/wo/4SvW/+f3/AMhJ/hQB6bRXmX/CV63/AM/v/kJP8KP+Er1v/n9/8hJ/hQB6bRXmi+LNaDAm8DY7GJOf0rsfD2ujWbZxIoS4ixvUdCD0IoA2qKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiqWp6pbaTbefcsQCcKqjLMfasL/hOrL/n0uP8Ax3/GgDqqK5X/AITqy/59Lj/x3/Gj/hOrL/n0uP8Ax3/GgDqqK5mDxvp8kqpJDPEpON5AIH1wa6VWDKGUgqRkEd6AFpk0yW8Ek0rbY41LMfQCn1ynjbU/JtI9Pjb55vmkx2UdPzP8qAOO1G9fUNQmupOsjZA9B2H5VVoooAKKKKACiiigAooooAKKKKACtLQtSOl6tFOT+7J2SD/ZP+HX8KzaKAPZQQQCDkHoRS1z/hHU/t2kiB2zNbYQ+6/wn+n4V0FABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFVLvU7Kw/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tT/572n/AH23/wATR/wg2p/897T/AL7b/wCJr0CigDz/AP4QbU/+e9p/323/AMTR/wAINqf/AD3tP++2/wDia9AooA8//wCEG1P/AJ72n/fbf/E0f8INqf8Az3tP++2/+Jr0CigDz/8A4QbU/wDnvaf99t/8TR/wg2p/897T/vtv/ia9AooA8/8A+EG1P/nvaf8Afbf/ABNH/CDan/z3tP8Avtv/AImvQKKAPP8A/hBtT/572n/fbf8AxNH/AAg2p/8APe0/77b/AOJr0CigDz//AIQbU/8Anvaf99t/8TR/wg2p/wDPe0/77b/4mvQKKAPP/wDhBtT/AOe9p/323/xNH/CDan/z3tP++2/+Jr0CigDz/wD4QbU/+e9p/wB9t/8AE0f8INqf/Pe0/wC+2/8Aia9AooA8/wD+EG1P/nvaf99t/wDE0f8ACDan/wA97T/vtv8A4mvQKKAPP/8AhBtT/wCe9p/323/xNH/CDan/AM97T/vtv/ia9AooA8//AOEG1P8A572n/fbf/E0f8INqf/Pe0/77b/4mvQKKAOFg8C3Zf/SLuBF7+WCx/UCuq0vRrPSIilshLt9+RuWatCigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAMbX9f/sP7P/o3n+du/wCWm3GMex9avaZe/wBo6dDd+X5fmgnZuzjnHWqOv6jplh9n/tGz+0793l/ulfbjGfvHjqKs2t9af2IL6CEx2qRtII1UAgDOcAcdjQBoUVh2vivTbqGaUmWFIQNxlUc5zgDBOTxUUfjTSpJvLPnoCcb2Qbf0Of0oA6GiqF7rNhp9uk09wu2QZjCfMXHqPb3rNg8ZaVNKEYzQ5OA0iDH6E0AdDRSKwZQykFSMgg8GqGo61YaXgXM4EhGRGoyx/Dt+NAGhRXPQ+M9Kll2N58QJxudBj9CakvvFmn2FyYHSeQ7QweIKVIIyMHNAG7RRWNf+KNLsJGieVpZF6rEN2Px6UAbNFYlj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mz/4H/6G1ac9pbXQUXFvFMF+6JEDY+mafFDFBEIoY0jjXoiKAB+AoA858If8jHB/uv8A+gmrPjn/AJDcP/Xsv/oTV28OnWNvIJILO3ikHRkiVSPxApZ7CzunD3FpBM4GA0kYY49OaAMu80sat4Yt4AQJVhR4yf7wX+vSuP0/VtR8N3Elu0WATl4ZRxn1H+NelqqooVVCqowABgAVHNbQXK7Z4Y5V9HQMP1oA4a58TanrY+wWdsIzL8p2EliO/PYVS8LKU8UWqnqC4/8AHGr0aC1t7ZStvBFED1EaBf5VHFp1jDMJorO3jlHR0iUEfjigDlfH3/MP/wC2n/stZenaxqXh+CMGISWs48xA+cc+h7fSvQbiztrvb9ptoZtudvmIGxn0zS/ZoPIEHkR+SBgR7BtH4UAee6n4lv8AWoxaRxCONzzHHlmf2rp/Cuivpdm8twuLibGV/uqOg+tbMFna2xzb20MWf+ecYX+VT0AebeJf+RtuP96P/wBBWuu8TaK2r2SmHH2mEkoD/ED1FaUunWM0xmls7eSU9XeJST+OKs0Aef6Z4nvNFj+w3dqZFj4VWO109unIp934m1PWZUttNgeAk5xG2WP1PGBXcTWtvcjE8EUoHaRA386WG3ht12wwxxD0RQP5UAVdJtbm0sES8uHnuD8zszZwfQe1XqKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAP/Z"
        End Try
        Dim bytes() As Byte = Convert.FromBase64String(image_data) ' strData would come from your CSV file
        Dim MS As New System.IO.MemoryStream(bytes)
        Dim bmp As Image = Image.FromStream(MS)
        FWarehouseItems.picItemImage.Image = bmp
        ' Form2.picItemImage.Image = bmp
    End Sub
    Function createItemImageText() As String
        Dim szResult As String = ""
        Try
            Dim value As Image

            value = FWarehouseItems.picItemImage.Image
            Using ms As New MemoryStream
                value.Save(ms, ImageFormat.Jpeg)
                ms.Flush()
                ms.Position = 0
                Dim buffer = ms.ToArray
                szResult = Convert.ToBase64String(buffer)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description & vbCrLf, "PERSON INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return szResult
    End Function
    Sub readfolder()
        Dim person_directory1 = "c:\Supply_Folder_temp"
        If Not Directory.Exists(person_directory1) Then
            Dim di As DirectoryInfo = Directory.CreateDirectory(person_directory1)
            di.Attributes = FileAttributes.Hidden
        End If
        Dim person_directory = "c:\Supply_Folder_temp\item_Image"
        If Not Directory.Exists(person_directory) Then
            Dim di As DirectoryInfo = Directory.CreateDirectory(person_directory)
        End If
    End Sub
    Function po(ByVal val1 As String, ByVal val2 As String) As String
        Dim rval As String = ""
        Dim val1_1 As DateTime
        If val2 <> "" Then
            val1_1 = Convert.ToDateTime(val1)
            Dim days As Integer = DateDiff(DateInterval.Day, val1_1, DateTime.ParseExact(val2, "MM/dd/yyyy", CultureInfo.CurrentCulture))
            rval = days & " day(s)"
        Else
            rval = "WAITING"
        End If
        'If val2 <> "" Then
        '    Dim days As Integer = DateDiff(DateInterval.Day, val1, DateTime.ParseExact(val2, "MM/dd/yyyy", CultureInfo.CurrentCulture))
        '    rval = days & " day(s)"
        'Else
        '    rval = "WAITING"
        'End If
        Return rval
    End Function
    Function interval_needed_received(ByVal val1 As DateTime, ByVal val2 As String) As String
        Dim rval As String = ""
        If val2 <> "" Then
            Dim days As Integer = DateDiff(DateInterval.Day, val1, DateTime.ParseExact(val2, "MM/dd/yyyy", CultureInfo.CurrentCulture))
            rval = days
        End If
        Return rval
    End Function
    Function termsFunction(ByVal val1 As String, ByVal val2 As String, ByVal val3 As String) As String

        'get_all_rr_info_using_rs_id(rs_id, 2)
        Dim rval As String = ""
        If val1 <> "" Then
            If val2.Contains("day") Then
                Dim t() As String = val2.Split(" ")
                Dim terms1 As Integer = Convert.ToInt32(t(0))
                'MessageBox.Show(remove_last_character(get_all_rr_info_using_rs_id(rs_id, 2)))
                If remove_last_character(val3) <> "" Then
                    If remove_last_character(val3).Contains(",") Then
                        Dim dates() As String = remove_last_character(val3).Split(",")
                        For Each item As String In dates
                            Dim d As DateTime = DateTime.ParseExact(item, "MM/dd/yyyy", CultureInfo.CurrentCulture)
                            'a(31) = d.AddDays(terms)
                            Dim ndate As DateTime = d.AddDays(terms1)
                            Dim l As Integer = DateDiff(DateInterval.Day, Now, ndate)
                            If l < 0 Then
                                rval = "Expired days(s) left / " & d.AddDays(terms1)
                            Else
                                rval = l & " days(s) left / " & ndate
                            End If
                        Next
                    Else
                        Dim d As DateTime = DateTime.ParseExact(remove_last_character(val3), "MM/dd/yyyy", CultureInfo.CurrentCulture)
                        Dim ndate As DateTime = d.AddDays(terms1)
                        Dim l As Integer = DateDiff(DateInterval.Day, Now, ndate)
                        If l < 0 Then
                            rval = "Expired days(s) left / " & d.AddDays(terms1)
                        Else
                            rval = l & " days(s) left / " & ndate
                        End If
                    End If
                End If
            End If
        End If
        Return rval
    End Function

    Function proccess1(ByVal val1 As String, ByVal val2 As String) As String
        Dim rval As String = ""
        If val1 = "" Or val2 = "" Then
            rval = ""
        Else
            Dim strdate As String = ""
            If val2.Contains(",") Then
                Dim dates() As String = val2.Split(",")
                For Each item As String In dates
                    Dim days As Integer = DateDiff(DateInterval.Day, DateTime.ParseExact(val1, "MM/dd/yyyy", CultureInfo.CurrentCulture), DateTime.ParseExact(item, "MM/dd/yyyy", CultureInfo.CurrentCulture))
                    If strdate = "" Then
                        strdate = days.ToString & " day(s)"
                    Else
                        strdate = strdate & ", " & days.ToString & " day(s)"
                    End If

                Next
                rval = strdate
            Else
                Dim days As Integer = DateDiff(DateInterval.Day, DateTime.ParseExact(val1, "MM/dd/yyyy", CultureInfo.CurrentCulture), DateTime.ParseExact(val2, "MM/dd/yyyy", CultureInfo.CurrentCulture))
                rval = days & " day(s)"
            End If
        End If
        Return rval
    End Function
    Function proccess2(ByVal val1 As DateTime, ByVal val2 As String) As String
        Dim rval As String = ""
        If val2 <> "" Then
            Dim strdate As String = ""
            If val2.Contains(",") Then
                Dim dates() As String = val2.Split(",")
                For Each item As String In dates
                    Dim days As Integer = DateDiff(DateInterval.Day, val1, DateTime.ParseExact(item, "MM/dd/yyyy", CultureInfo.CurrentCulture))
                    If strdate = "" Then
                        strdate = days.ToString & " day(s)"
                    Else
                        strdate = strdate & "," & days.ToString & " day(s)"
                    End If

                Next
                rval = strdate
            Else
                Dim days As Integer = DateDiff(DateInterval.Day, val1, DateTime.ParseExact(val2, "MM/dd/yyyy", CultureInfo.CurrentCulture))
                rval = days & " day(s)"
            End If
            'MessageBox.Show(remove_last_character(get_all_rr_info_using_rs_id(rs_id, 2)))

        Else
            rval = "WAITING"
        End If
        Return rval
    End Function
    Sub load_sub(ByVal rs_no As String, ByVal item_id As String, ByVal rs_id As String)
        Dim total As Decimal = 0.0
        Dim det_error As String
        Dim SQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim cmd As SqlCommand
        Dim t(30) As String
        Try
            SQ.connection.Open()


            cmd = New SqlCommand("proc_search_summarySupply", SQ.connection)
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", 555)
            cmd.Parameters.AddWithValue("@rs_no", rs_no)
            cmd.Parameters.AddWithValue("@rr_item_id", item_id)
            cmd.Parameters.AddWithValue("@rs_id", rs_id)
            newdr = cmd.ExecuteReader

            While newdr.Read
                Dim a(30) As String
                Dim item_desc As String = newdr.Item("item_desc").ToString
                Dim qty As String = newdr.Item("qty").ToString
                Dim dates As DateTime = newdr.Item("date_received").ToString
                Dim rr_no As String = newdr.Item("rr_no").ToString
                Dim amount As String = newdr.Item("amount").ToString
                Dim unit As String = newdr.Item("unit").ToString
                total = total + CDbl(Val(amount))
                'MessageBox.Show("this : " & type_of_purchasing)

                ' If newdr.Item("UNIT_AMOUNT").ToString = "" Then : unit_amount = 0 : Else : unit_amount = newdr.Item("UNIT_AMOUNT").ToString : End If

                'charge_name = FReceivingReport.multiplecharges(dr.Item("rs_id").ToString)
                '-------end get charges ----------
                a(0) = ""
                a(1) = ""
                a(2) = ""
                a(3) = ""
                a(4) = ""
                a(6) = item_desc
                a(7) = qty
                a(11) = rr_no
                a(12) = dates
                a(13) = FormatNumber(CDbl(amount), 2)
                'a(13) = IIf(amount = "", 0, amount)
                a(5) = unit
                a(26) = ""


                FSummarySupplyTransaction.dtgSummarySupply.Rows.Add(a)
                For Each rw As DataGridViewRow In FSummarySupplyTransaction.dtgSummarySupply.Rows

                    ' If rw.Cells(26).Value.ToString = "CASH" Then
                    rw.DefaultCellStyle.BackColor = Color.LightGreen

                Next


proceedhere:
            End While
            t(0) = ""
            t(1) = ""
            t(2) = ""
            t(3) = ""
            t(4) = ""
            t(6) = "TOTAL : "
            t(13) = FormatNumber(CDbl(total), 2)
            t(26) = ""
            FSummarySupplyTransaction.dtgSummarySupply.Rows.Add(t)
            For Each rw As DataGridViewRow In FSummarySupplyTransaction.dtgSummarySupply.Rows

                ' If rw.Cells(26).Value.ToString = "CASH" Then
                rw.DefaultCellStyle.BackColor = Color.LightGreen

            Next
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & "error: " & det_error & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Public Function get_item_id(ByVal table_name As String, ByVal column_name As String, ByVal value As String) As String
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Try
            Dim query As String
            SQ.connection.Open()
            query = "SELECT top 1 rr_item_id FROM " & table_name & " WHERE " & column_name & " = '" & value & "'"

            cmd = New SqlCommand(query, SQ.connection)
            dr = cmd.ExecuteReader
            While dr.Read
                get_item_id = dr.GetValue(0).ToString
            End While
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            SQ.connection.Close()
        End Try
    End Function
End Module
