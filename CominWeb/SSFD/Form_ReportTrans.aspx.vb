Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System
Imports System.Linq
Imports System.Web.UI.WebControls
Imports SpreadsheetLight
Imports System.IO
Imports System.Net
Imports DocumentFormat.OpenXml

Public Class Form_ReportTrans
    Inherits System.Web.UI.Page
    'Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA
    'Dim sw_usuario As New SW_usuario_DA
    'Dim sw_usuarioDT As New DataTable, sw_inventariosDT As New DataTable
    'Dim almacenDT, sw_ejecutaSQLDT As New DataTable
    'Dim SW_productosDA As New SW_productos_DA
    'Dim crearUserDT, editarUserDT, eliminarUserDT, exportaUserDT As DataTable

    Private Sub Form_Productos_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Session("usuarioLoginID") = Nothing Then
        '    Response.Redirect("~/Default.aspx")
        'End If
        SDS_P_selectRegion.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectAnio.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectPresidente.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            'sucursalCB.SelectedValue = Session("IDSucursalPrincipal").ToString.Trim
            'sucursalCB.DataBind()
            'Me.fechaCorteRDP.SelectedDate = Date.Now
            'If Session("esSuperAdminUser") = True Then
            '    sucursalCB.Enabled = True
            'Else
            '    sucursalCB.Enabled = False
            'End If
            'permisosPage()
        End If
    End Sub

    'Public Sub permisosPage()
    '    exportaUserDT = sw_ejecutaSQL.P_AccesoUsuarioByOpcionID(Session("usuarioLoginID"), 75)
    '    ViewState("exportaUserDTClassProductos") = exportaUserDT.Rows(0).Item(0).ToString()

    '    If exportaUserDT.Rows.Count > 0 Then
    '        If exportaUserDT.Rows(0).Item(0).ToString = 0 Then
    '            Me.exportaInvetarioB.Enabled = False
    '        Else
    '            Me.exportaInvetarioB.Enabled = True
    '        End If
    '    End If
    'End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument = "ExportaSpreed" Then
            CreateExcelFile()
        End If
    End Sub

    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()
        'Dim sl As New SLDocument()
        'sl.SetCellValue(1, 1, "CODIGO")
        'sl.SetCellValue(1, 2, "NRO PARTE")
        'sl.SetCellValue(1, 3, "PRODUCTO")
        'sl.SetCellValue(1, 4, "GRUPO")
        'sl.SetCellValue(1, 5, "SUB-GRUPO")
        'sl.SetCellValue(1, 6, "MARCA")
        'sl.SetCellValue(1, 7, "UNIDAD MEDIDA")
        'sl.SetCellValue(1, 8, "GRUPO FUNCION")
        'sl.SetCellValue(1, 9, "UBICACION")
        'sl.SetCellValue(1, 10, "LINEA")
        'sl.SetCellValue(1, 11, "MONEDA")
        'sl.SetCellValue(1, 12, "STOCK")
        'sl.SetCellValue(1, 13, "COSTO")
        'sl.SetCellValue(1, 14, "TIPO CAMBIO")
        'sl.SetCellValue(1, 15, "SUB-TOTAL SOLES")
        'sl.SetCellValue(1, 16, "SUB-TOTAL DOLARES")

        'Dim stilo As SLStyle = sl.CreateStyle()
        'stilo.Font.FontName = "Calibri"
        'stilo.Font.FontSize = 9
        'stilo.Font.Bold = True
        'stilo.FormatCode = "12345.678909"
        'stilo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)

        'sl.SetColumnWidth(1, 2, 16)
        'sl.SetColumnWidth(3, 3, 50)
        'sl.SetColumnWidth(4, 7, 20)
        'sl.SetColumnWidth(8, 9, 25)
        'sl.SetColumnWidth(10, 16, 12)

        'Dim styleNum As SLStyle = sl.CreateStyle()
        'styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
        'styleNum.FormatCode = "#,##0.00"
        'sl.SetColumnStyle(12, 16, styleNum)

        'Dim styleCon As SLStyle = sl.CreateStyle()
        'styleCon.Font.FontSize = 9
        'sl.SetColumnStyle(1, 16, styleCon)

        'sl.SetRowStyle(1, 1, stilo)

        'Dim rowIndex As Integer = 2
        'Dim columnIndex As Integer = 1

        'Dim estado_CHB As Integer
        'If estadoCHB.Checked = True Then
        '    estado_CHB = 1
        'Else
        '    estado_CHB = 0
        'End If

        'sw_inventariosDT = SW_productosDA.P_Report_Inventarios(estado_CHB, "0", codMarcaTB.Text, codMarcaEspecificaTB.Text,
        '                                                           codUnidadTB.Text, codGrupoTB.Text, "0", "0", almacenCB.SelectedValue.ToString,
        '                                                           nombreTB.Text, codigoTB.Text, sucursalCB.SelectedValue.ToString, 1,
        '                                                           fechaCorteRDP.SelectedDate.Value.ToString("dd/MM/yyyy"))

        'If sw_inventariosDT.Rows.Count > 0 Then
        '    For fil As Integer = 0 To sw_inventariosDT.Rows.Count - 1
        '        For i As Integer = 0 To sw_inventariosDT.Columns.Count - 1
        '            If i > 10 Then
        '                sl.SetCellValue(rowIndex, columnIndex, Convert.ToDecimal(sw_inventariosDT.Rows(fil)(i)))
        '            Else
        '                sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(sw_inventariosDT.Rows(fil)(i).ToString()))
        '            End If
        '            columnIndex += 1
        '        Next
        '        rowIndex += 1
        '        columnIndex = 1
        '    Next
        '    sl.SaveAs("C:/fichas/Inventarios.xlsx")
        '    Dim file As New FileInfo("C:/fichas/Inventarios.xlsx")

        '    ' guarda
        '    If (file.Exists) Then
        '        Response.Clear()
        '        Response.AddHeader("Content-disposition", "attachment; filename=Inventarios.xlsx")
        '        Response.ContentType = "application/vnd.ms-excel"
        '        Response.WriteFile(file.ToString())
        '        Response.End()
        '    End If

        'End If
    End Sub

    'Protected Sub exportaInvetarioB_Click(sender As Object, e As EventArgs) Handles exportaInvetarioB.Click
    '    CreateExcelFile()
    'End Sub


End Class
