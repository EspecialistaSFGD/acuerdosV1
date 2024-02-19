Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports System.IO
Imports System.Net
'Imports System.Net.Mail
'Imports System.Data
'Imports System.Data.SqlClient
'Imports System
'Imports System.Linq
'Imports System.Web.UI.WebControls
Imports SpreadsheetLight
Imports DocumentFormat.OpenXml

Public Class Form_ReportTransferencia
    Inherits System.Web.UI.Page

    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA
    Dim sw_SSFD As New SW_SSFD_DA
    Dim ssfdDT As New DataTable

    Private Sub Form_ReportTransferencia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Request.QueryString("gjXtIkEroS").ToString = "eninbWFudWNjfsdDWqWSDFsdWWaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "SSFD_TransCS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If

        SDS_P_selectRegion.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectAnio.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectPresidente.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")



        If Page.IsPostBack = False Then
            fechaCorteRDP.SelectedDate = Date.Now
        End If

    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument = "ExportaSpreed" Then
            CreateExcelFile()
        Else
            Dim datos() As String = Split(e.Argument, ",")
            If datos(0) = "canculaMenorJS" Then
                canculaMenor(datos(1).ToString)
            ElseIf datos(0) = "canculaMayorJS" Then
                canculaMayor(datos(1).ToString)
            End If
        End If
    End Sub

    Private Sub canculaMayor(val As Decimal)
        Me.mayorLB.Text = val.ToString
    End Sub

    Private Sub canculaMenor(val As Decimal)
        Me.menorLB.Text = val.ToString
    End Sub

    Protected Sub exportaB_Click(sender As Object, e As EventArgs) Handles exportaB.Click
        CreateExcelFile()
    End Sub

    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()
        Dim sl As New SLDocument()
        sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Resumido")
        sl.SetCellValue(1, 1, "UBIGEO")
        sl.SetCellValue(1, 2, "REGION")
        sl.SetCellValue(1, 3, "PROVINCIA")
        sl.SetCellValue(1, 4, "DISTRITO")
        sl.SetCellValue(1, 5, "PLIEGO")
        sl.SetCellValue(1, 6, "ALCALDESA")
        sl.SetCellValue(1, 7, "TIPO")
        sl.SetCellValue(1, 8, "TRANS_2019")
        sl.SetCellValue(1, 9, "TRANS_2020")

        Dim stilo As SLStyle = sl.CreateStyle()
        stilo.Font.FontName = "Calibri"
        stilo.Font.FontSize = 9
        stilo.Font.Bold = True
        stilo.FormatCode = "12345.678909"
        stilo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)

        sl.SetColumnWidth(1, 4, 20)
        sl.SetColumnWidth(5, 5, 45)
        sl.SetColumnWidth(6, 9, 15)

        Dim rowIndex As Integer = 2
        Dim columnIndex As Integer = 1

        Dim alcaldesa_CHB As Integer
        If alcaldezasCHB.Checked = True Then
            alcaldesa_CHB = 1
        Else
            alcaldesa_CHB = 0
        End If

        ssfdDT = sw_SSFD.P_selectGL(presidentesCB.SelectedValue, regionCB.SelectedValue, provinciaCB.SelectedValue, alcaldesa_CHB, fechaCorteRDP.SelectedDate.Value.ToString("dd/MM/yyyy"), anioCB.SelectedValue)

        If ssfdDT.Rows.Count > 0 Then
            For fil As Integer = 0 To ssfdDT.Rows.Count - 1
                For i As Integer = 0 To ssfdDT.Columns.Count - 1
                    If i > 6 Then
                        sl.SetCellValue(rowIndex, columnIndex, Convert.ToDecimal(ssfdDT.Rows(fil)(i)))
                    Else
                        sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(ssfdDT.Rows(fil)(i).ToString()))
                    End If
                    columnIndex += 1
                Next
                rowIndex += 1
                columnIndex = 1
            Next

            Dim styleNum As SLStyle = sl.CreateStyle()
            styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
            styleNum.FormatCode = "#,##0"
            sl.SetColumnStyle(8, 9, styleNum)

            Dim styleCon As SLStyle = sl.CreateStyle()
            styleCon.Font.FontSize = 9
            sl.SetColumnStyle(1, 9, styleCon)

            sl.SetRowStyle(1, 1, stilo)
        End If

        If menorTB.Text.ToString.Length > 0 And mayorTB.Text.ToString.Length > 0 Then
            'HOJA 2
            sl.AddWorksheet("Menores " & menorTB.Text.ToString)

            sl.SetCellValue(1, 1, "UBIGEO")
            sl.SetCellValue(1, 2, "REGION")
            sl.SetCellValue(1, 3, "PROVINCIA")
            sl.SetCellValue(1, 4, "DISTRITO")
            sl.SetCellValue(1, 5, "PLIEGO")
            sl.SetCellValue(1, 6, "ALCALDESA")
            sl.SetCellValue(1, 7, "TRANS_2019")
            sl.SetCellValue(1, 8, "TRANS_2020")

            sl.SetColumnWidth(1, 4, 20)
            sl.SetColumnWidth(5, 5, 45)
            sl.SetColumnWidth(6, 8, 15)

            Dim rowIndex1 As Integer = 2
            Dim columnIndex1 As Integer = 1

            ssfdDT = sw_SSFD.P_selectGLMin(menorTB.Text, anioCB.SelectedValue, alcaldesa_CHB)

            If ssfdDT.Rows.Count > 0 Then
                For fil As Integer = 0 To ssfdDT.Rows.Count - 1
                    For i As Integer = 0 To ssfdDT.Columns.Count - 1
                        If i > 5 Then
                            sl.SetCellValue(rowIndex1, columnIndex1, Convert.ToDecimal(ssfdDT.Rows(fil)(i)))
                        Else
                            sl.SetCellValue(rowIndex1, columnIndex1, Convert.ToString(ssfdDT.Rows(fil)(i).ToString()))
                        End If
                        columnIndex1 += 1
                    Next
                    rowIndex1 += 1
                    columnIndex1 = 1
                Next

                Dim styleNum As SLStyle = sl.CreateStyle()
                styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
                styleNum.FormatCode = "#,##0"
                sl.SetColumnStyle(7, 8, styleNum)

                Dim styleCon As SLStyle = sl.CreateStyle()
                styleCon.Font.FontSize = 9
                sl.SetColumnStyle(1, 8, styleCon)

                sl.SetRowStyle(1, 1, stilo)
            End If

            'HOJA 3
            sl.AddWorksheet("Entre " & menorTB.Text.ToString & " y " & mayorTB.Text.ToString)

            sl.SetCellValue(1, 1, "UBIGEO")
            sl.SetCellValue(1, 2, "REGION")
            sl.SetCellValue(1, 3, "PROVINCIA")
            sl.SetCellValue(1, 4, "DISTRITO")
            sl.SetCellValue(1, 5, "PLIEGO")
            sl.SetCellValue(1, 6, "ALCALDESA")
            sl.SetCellValue(1, 7, "TRANS_2019")
            sl.SetCellValue(1, 8, "TRANS_2020")

            sl.SetColumnWidth(1, 4, 20)
            sl.SetColumnWidth(5, 5, 45)
            sl.SetColumnWidth(6, 8, 15)

            Dim rowIndex2 As Integer = 2
            Dim columnIndex2 As Integer = 1

            ssfdDT = sw_SSFD.P_selectGLMedio(menorTB.Text, mayorTB.Text, anioCB.SelectedValue, alcaldesa_CHB)

            If ssfdDT.Rows.Count > 0 Then
                For fil As Integer = 0 To ssfdDT.Rows.Count - 1
                    For i As Integer = 0 To ssfdDT.Columns.Count - 1
                        If i > 5 Then
                            sl.SetCellValue(rowIndex2, columnIndex2, Convert.ToDecimal(ssfdDT.Rows(fil)(i)))
                        Else
                            sl.SetCellValue(rowIndex2, columnIndex2, Convert.ToString(ssfdDT.Rows(fil)(i).ToString()))
                        End If
                        columnIndex2 += 1
                    Next
                    rowIndex2 += 1
                    columnIndex2 = 1
                Next

                Dim styleNum As SLStyle = sl.CreateStyle()
                styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
                styleNum.FormatCode = "#,##0"
                sl.SetColumnStyle(7, 8, styleNum)

                Dim styleCon As SLStyle = sl.CreateStyle()
                styleCon.Font.FontSize = 9
                sl.SetColumnStyle(1, 8, styleCon)

                sl.SetRowStyle(1, 1, stilo)
            End If

            'HOJA 4
            sl.AddWorksheet("Mayor " & mayorTB.Text.ToString)

            sl.SetCellValue(1, 1, "UBIGEO")
            sl.SetCellValue(1, 2, "REGION")
            sl.SetCellValue(1, 3, "PROVINCIA")
            sl.SetCellValue(1, 4, "DISTRITO")
            sl.SetCellValue(1, 5, "PLIEGO")
            sl.SetCellValue(1, 6, "ALCALDESA")
            sl.SetCellValue(1, 7, "TRANS_2019")
            sl.SetCellValue(1, 8, "TRANS_2020")

            sl.SetColumnWidth(1, 4, 20)
            sl.SetColumnWidth(5, 5, 45)
            sl.SetColumnWidth(6, 8, 15)

            Dim rowIndex3 As Integer = 2
            Dim columnIndex3 As Integer = 1

            ssfdDT = sw_SSFD.P_selectGLMax(menorTB.Text, mayorTB.Text, anioCB.SelectedValue, alcaldesa_CHB)

            If ssfdDT.Rows.Count > 0 Then
                For fil As Integer = 0 To ssfdDT.Rows.Count - 1
                    For i As Integer = 0 To ssfdDT.Columns.Count - 1
                        If i > 5 Then
                            sl.SetCellValue(rowIndex3, columnIndex3, Convert.ToDecimal(ssfdDT.Rows(fil)(i)))
                        Else
                            sl.SetCellValue(rowIndex3, columnIndex3, Convert.ToString(ssfdDT.Rows(fil)(i).ToString()))
                        End If
                        columnIndex3 += 1
                    Next
                    rowIndex3 += 1
                    columnIndex3 = 1
                Next

                Dim styleNum As SLStyle = sl.CreateStyle()
                styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
                styleNum.FormatCode = "#,##0"
                sl.SetColumnStyle(7, 8, styleNum)

                Dim styleCon As SLStyle = sl.CreateStyle()
                styleCon.Font.FontSize = 9
                sl.SetColumnStyle(1, 8, styleCon)

                sl.SetRowStyle(1, 1, stilo)
            End If

        End If

        sl.SaveAs("C:/fichas/TransferenciasGL.xlsx")
        Dim file As New FileInfo("C:/fichas/TransferenciasGL.xlsx")

        ' guarda
        If (file.Exists) Then
            Response.Clear()
            Response.AddHeader("Content-disposition", "attachment; filename=TransferenciasGL.xlsx")
            Response.ContentType = "application/vnd.ms-excel"
            Response.WriteFile(file.ToString())
            Response.End()
        End If



    End Sub

End Class