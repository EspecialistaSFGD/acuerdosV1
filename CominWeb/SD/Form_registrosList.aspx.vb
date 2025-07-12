Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports SpreadsheetLight
Imports DocumentFormat.OpenXml


Public Class Form_registrosList
    Inherits System.Web.UI.Page

    Dim sw_asistente_DT As New DataTable
    Dim sw_asistente As New SW_SD_asistente_DA
    Dim SW_pedidos As New SW_pedido_DA
    Dim key As String

    Private Sub Form_registrosList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Session("usuarioLoginID") = Nothing = Request.QueryString("iacp").ToString()

        'If Session("usuarioLoginID") = Nothing Then
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"

            SDS_P_selectDistrito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectAutoridad.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectEntidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectAcreaditadosList.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("https://sesigue.miterritorio.gob.pe/sesigue")
        End If
        'Else
        '    variableGlobalConexion.nombreCadenaCnx = ""
        '    Response.Redirect("https://sesigue.miterritorio.gob.pe/sesigue")
        'End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        'Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        'tituloLB.Text = Request.QueryString("nosucp").ToString


        'If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
        '    variableGlobalConexion.nombreCadenaCnx = "SD_CS"
        '    SDS_SD_P_selectAcreaditadosList.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString

        'Else
        '    variableGlobalConexion.nombreCadenaCnx = ""
        '    Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        'End If

        If Page.IsPostBack = False Then
            'desdeRDP.SelectedDate = Date.Now.ToString("dd/MM/yyyy")
            'hastaRDP.SelectedDate = Date.Now.ToString("dd/MM/yyyy")
        End If
    End Sub

    Protected Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click
        Me.RadGrid1.Rebind()
    End Sub


    Protected Sub registroB_Click(sender As Object, e As EventArgs) Handles registroB.Click

        sw_asistente_DT = SW_pedidos.SD_P_selectEventos(cbo_evento.SelectedValue, 1)
        key = sw_asistente_DT.Rows(0).Item(8)
        Response.Redirect("~/SD/AregistroAsistencia.aspx?au=0&7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=2B6AC8BbF4ADF440005AFC42EF337555FB0008BF9770791Z&gjXtIkEroS=SD_SSFD&&iacp=" & Me.Request.QueryString("iacp").ToString & "&evId=" & cbo_evento.SelectedValue.ToString & "&key=" & key.ToString)
    End Sub

    'Protected Sub volverB_Click(sender As Object, e As EventArgs) Handles volverB.Click
    '    Response.Redirect("~/operador/Form_BienvenidoOperador.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString +
    '                            "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
    '                            "&usuaL=" + Session("usuarioLoginID").ToString +
    '                              "&nomusuaL=" + Session("NombreUsuarioLogin").ToString +
    '                              "&idsucp=" + Session("IDSucursalPrincipal").ToString +
    '                              "&nosucp=" + Session("nombreSucursalPrincipal").ToString +
    '                              "&almpri=" + Session("almacenAsignadoPrincipal").ToString +
    '                              "&essadm=" + Session("esSuperAdminUser").ToString)
    'End Sub

    Private Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.DataBound

    End Sub

    Protected Sub exportarB_Click(sender As Object, e As EventArgs) Handles exportarB.Click
        CreateExcelFile()
    End Sub


    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        cbo_provincia1.Items.Clear()
        cbo_provincia1.DataBind()

        distritoCB.Items.Clear()
        distritoCB.DataBind()

        grupoCB.SelectedValue = 0
        grupoCB.DataBind()

        hiddenFieldUbigeo.Value = cbo_departamento1.SelectedValue

        entidadCB.Items.Clear()
        entidadCB.DataBind()

    End Sub

    Protected Sub cbo_provincia1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_provincia1.SelectedIndexChanged
        distritoCB.Items.Clear()
        distritoCB.DataBind()

        hiddenFieldUbigeo.Value = cbo_provincia1.SelectedValue

        grupoCB.SelectedValue = 0
        grupoCB.DataBind()

        entidadCB.Items.Clear()
        entidadCB.DataBind()

    End Sub

    Protected Sub distritoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles distritoCB.SelectedIndexChanged

        hiddenFieldUbigeo.Value = distritoCB.SelectedValue

        grupoCB.SelectedValue = 0
        grupoCB.DataBind()

        entidadCB.Items.Clear()
        entidadCB.DataBind()

    End Sub

    Protected Sub grupoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grupoCB.SelectedIndexChanged

        distritoCB.SelectedValue = 0
        distritoCB.DataBind()

        cbo_provincia1.SelectedValue = 0
        cbo_provincia1.DataBind()

        cbo_departamento1.SelectedValue = 0
        cbo_departamento1.DataBind()

        hiddenFieldUbigeo.Value = 0

        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub


    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()

        Dim sl As New SLDocument()
        sl.SetCellValue(4, 1, "ESPACIO")
        sl.SetCellValue(4, 2, "TIPO")
        sl.SetCellValue(4, 3, "UBIGEO")
        sl.SetCellValue(4, 4, "DEPARTAMENTO")
        sl.SetCellValue(4, 5, "PROVINCIA")
        sl.SetCellValue(4, 6, "DISTRITO")
        sl.SetCellValue(4, 7, "ENTIDAD")
        sl.SetCellValue(4, 8, "GRUPO")
        sl.SetCellValue(4, 9, "CARGO")
        sl.SetCellValue(4, 10, "DNI")
        sl.SetCellValue(4, 11, "NOMBRE Y APELLIDOS")
        sl.SetCellValue(4, 12, "TELEFONO")
        sl.SetCellValue(4, 13, "EMAIL")
        sl.SetCellValue(4, 14, "DIA DE ESPACIO")
        sl.SetCellValue(4, 15, "FECHA Y HORA DE ASISTENCIA")
        sl.SetCellValue(4, 16, "ASISTENCIA")

        'emcabezado
        Dim stilo As SLStyle = sl.CreateStyle()
        stilo.Font.FontName = "Calibri"
        stilo.Font.FontSize = 9
        stilo.Font.Bold = True
        stilo.FormatCode = "12345.678909"
        stilo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)
        stilo.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)
        stilo.Border.LeftBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stilo.Border.RightBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stilo.Border.TopBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stilo.Border.BottomBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stilo.SetWrapText(True)


        'contenido
        Dim stiloCon As SLStyle = sl.CreateStyle()
        stiloCon.Font.FontName = "Calibri"
        stiloCon.Font.FontSize = 9
        stiloCon.Font.Bold = False
        stiloCon.FormatCode = "12345.678909"
        stiloCon.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)
        stiloCon.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)
        stiloCon.Border.LeftBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stiloCon.Border.RightBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stiloCon.Border.TopBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stiloCon.Border.BottomBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
        stiloCon.SetWrapText(True)

        'titulo
        Dim stiloTitulo As SLStyle = sl.CreateStyle()
        stiloTitulo.Font.FontName = "Calibri"
        stiloTitulo.Font.FontSize = 12
        stiloTitulo.Font.Bold = True
        stiloTitulo.FormatCode = "12345.678909"
        stiloTitulo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Left)
        stiloTitulo.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        'subtitulo
        Dim stiloSubTitulo As SLStyle = sl.CreateStyle()
        stiloSubTitulo.Font.FontName = "Calibri"
        stiloSubTitulo.Font.FontSize = 9
        stiloSubTitulo.Font.Bold = True
        stiloSubTitulo.FormatCode = "12345.678909"
        stiloSubTitulo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Left)
        stiloSubTitulo.SetVerticalAlignment(Spreadsheet.VerticalAlignmentValues.Center)

        sl.SetColumnWidth(1, 1, 15)
        sl.SetColumnWidth(2, 3, 9)
        sl.SetColumnWidth(4, 6, 18)
        sl.SetColumnWidth(7, 7, 50)
        sl.SetColumnWidth(8, 9, 15)
        sl.SetColumnWidth(10, 11, 35)
        sl.SetColumnWidth(12, 12, 20)
        sl.SetColumnWidth(13, 13, 30)
        sl.SetColumnWidth(14, 16, 20)
        sl.SetColumnWidth(17, 17, 20)

        Dim rowIndex As Integer = 5
        Dim columnIndex As Integer = 1

        sl.SetCellValue(1, 1, "REPORTE DE PARTICIPANTES")
        sl.SetCellValue(2, 1, "Exportado el: " & Date.Now.ToString("dd/MM/yyyy HH:mm"))
        sl.SetRowHeight(4, 1, 20)

        Dim desde, hasta As String
        If desdeRDP.IsEmpty = True Then
            desde = "01/01/2000"
        Else
            desde = desdeRDP.SelectedDate.Value.ToString("dd/MM/yyyy")
        End If


        If hastaRDP.IsEmpty = True Then
            hasta = "01/01/2000"
        Else
            hasta = hastaRDP.SelectedDate.Value.ToString("dd/MM/yyyy")
        End If

        sw_asistente_DT = sw_asistente.SD_P_selectAcreditadosListExport(0, "", cbo_evento.SelectedValue, entidadCB.SelectedValue, "", "", asistenteCB.SelectedValue, autoridadCB.SelectedValue, desde, hasta)

        sl.SetRowStyle(1, 1, stiloTitulo)
        sl.SetRowStyle(2, 2, stiloSubTitulo)
        sl.SetCellStyle(4, 1, stilo)
        sl.SetCellStyle(4, 2, stilo)
        sl.SetCellStyle(4, 3, stilo)
        sl.SetCellStyle(4, 4, stilo)
        sl.SetCellStyle(4, 5, stilo)
        sl.SetCellStyle(4, 6, stilo)
        sl.SetCellStyle(4, 7, stilo)
        sl.SetCellStyle(4, 8, stilo)
        sl.SetCellStyle(4, 9, stilo)
        sl.SetCellStyle(4, 10, stilo)
        sl.SetCellStyle(4, 11, stilo)
        sl.SetCellStyle(4, 12, stilo)
        sl.SetCellStyle(4, 13, stilo)
        sl.SetCellStyle(4, 14, stilo)
        sl.SetCellStyle(4, 15, stilo)
        sl.SetCellStyle(4, 16, stilo)
        sl.SetCellStyle(4, 17, stilo)

        If sw_asistente_DT.Rows.Count > 0 Then
            For fil As Integer = 0 To sw_asistente_DT.Rows.Count - 1
                For i As Integer = 0 To sw_asistente_DT.Columns.Count - 1
                    sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(sw_asistente_DT.Rows(fil)(i).ToString()))
                    sl.SetCellStyle(rowIndex, columnIndex, stiloCon)
                    columnIndex += 1
                Next
                rowIndex += 1
                columnIndex = 1
            Next
            sl.SaveAs("C:/fichas/Participantes_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            Dim file As New FileInfo("C:/fichas/Participantes_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            If (file.Exists) Then
                Response.Clear()
                Response.AddHeader("Content-disposition", "attachment; filename=Participantes_" & cbo_evento.SelectedItem.ToString & ".xlsx")
                Response.ContentType = "application/vnd.ms-excel"
                Response.WriteFile(file.ToString())
                Response.End()
            End If

        End If
    End Sub




End Class