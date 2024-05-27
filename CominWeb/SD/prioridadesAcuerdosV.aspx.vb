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


Public Class prioridadesAcuerdosV
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT, SW_acuerdoPreacuerdoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub prioridadesAcuerdosV_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Session("usuarioLoginID") = Nothing Then
        '    Response.Redirect("~/SD/Form_asistenciaListOp.aspx?gjXtIkEroS=SD_SSFD")
        'End If
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString




            SDS_SD_P_selectPrioridadAcuerdo.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString

        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        'Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        titulo2LB.Text = "LISTA DE PEDIDOS DE " & Request.QueryString("enti").ToString


        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            'SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            'SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            'SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            'SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            'SDS_SD_P_selectPrioridadAcuerdo.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            'SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString

        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If

        If Page.IsPostBack = False Then
            SW_acuerdoPreacuerdoDT = SW_pedidoDA.SD_P_selectParametroByID(16, 2)
            ViewState("acuerdoPreacuerdo") = SW_acuerdoPreacuerdoDT.Rows(0).Item(3)

            If Me.Request.QueryString("codsector") = 0 Then
                RadGrid1.MasterTableView.GetColumn("cantidadAcuerdos").Display = False

                RadGrid1.MasterTableView.GetColumn("TemplateColumnEstado").Display = True
                RadGrid1.MasterTableView.GetColumn("TemplateColumnDelete").Display = True

            Else
                RadGrid1.MasterTableView.GetColumn("cantidadAcuerdos").Display = True

                RadGrid1.MasterTableView.GetColumn("TemplateColumnEstado").Display = False
                RadGrid1.MasterTableView.GetColumn("TemplateColumnDelete").Display = False
            End If

            If Me.Request.QueryString("sup") = 2 Then
                RadGrid1.MasterTableView.GetColumn("TCComentario").Display = True
            Else
                RadGrid1.MasterTableView.GetColumn("TCComentario").Display = False
            End If


            If Me.Request.QueryString("codsector").ToString = 0 Then
                cbo_departamento1.Enabled = False
                cbo_provincia1.Enabled = False

                cbo_departamento1.SelectedValue = Me.Request.QueryString("de").ToString
                cbo_departamento1.DataBind()

                Dim ub As Integer = Right("00" & Request.QueryString("ubig"), 4)
                If ub > 0 Then
                    cbo_provincia1.SelectedValue = Me.Request.QueryString("ubig").ToString
                    cbo_provincia1.DataBind()
                End If

            Else

                If Request.QueryString("sup") = 2 Then
                    grupoCB.Enabled = True
                Else
                    grupoCB.SelectedValue = Me.Request.QueryString("codsector").ToString
                    grupoCB.DataBind()
                    grupoCB.Enabled = False
                End If
            End If
            '    desdeRDP.SelectedDate = Date.Now.ToString("dd/MM/yyyy")
            '    hastaRDP.SelectedDate = Date.Now.ToString("dd/MM/yyyy")
        End If
    End Sub

    Protected Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click
        Me.RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        'For Each item As GridDataItem In RadGrid1.Items
        '    Dim prioridadID As Integer = item("prioridadID").Text
        '    Dim eventoId As Integer = item("eventoId").Text
        '    Dim sectorid As Integer = item("sectorid").Text
        '    Dim sector As String = item("sector").Text

        '    Dim currentRow As DataRowView = DirectCast(item.DataItem, DataRowView)
        '    Dim Link As HyperLink = item.FindControl("Link")
        '    Dim LinkCant As HyperLink = item.FindControl("LinkCant")


        '    Link.Text = currentRow.Row("intervencionesEstrategicas").ToString
        '    Link.Font.Bold = True
        '    Link.NavigateUrl = "#"
        '    Link.Attributes.Add("OnClick", "verOrdenServicioLog('" & prioridadID.ToString.Trim & "','" & eventoId & "','" & sectorid & "','" & sector & "');")


        '    LinkCant.Text = currentRow.Row("cantidadAcuerdos").ToString
        '    LinkCant.Font.Bold = True
        '    LinkCant.NavigateUrl = "#"
        '    LinkCant.Attributes.Add("OnClick", "verOrdenServicioLog('" & prioridadID.ToString.Trim & "','" & eventoId & "','" & sectorid & "','" & sector & "');")
        'Next
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
        For Each item As GridDataItem In RadGrid1.Items

            Dim prioridadID As Integer = item("prioridadID").Text
            Dim eventoId As Integer = item("eventoId").Text
            Dim sectorid As Integer = item("sectorid").Text
            Dim sector As String = item("sector").Text
            Dim cui As String = item("cui").Text

            Dim validado As Integer = item("validado").Text
            Dim valida As ImageButton = item.FindControl("TCValida")

            Dim currentRow As DataRowView = DirectCast(item.DataItem, DataRowView)
            Dim Link As HyperLink = item.FindControl("Link")
            Dim LinkCant As HyperLink = item.FindControl("LinkCant")
            Dim Linkcui As HyperLink = item.FindControl("Linkcui")

            Dim edita_img As ImageButton = item.FindControl("edita")
            Dim eliminaHito As ImageButton = item.FindControl("eliminaP")

            Dim comentario As ImageButton = item.FindControl("TCComentario")

            Link.Text = currentRow.Row("intervencionesEstrategicas").ToString
            LinkCant.Text = currentRow.Row("cantidadAcuerdos").ToString
            Linkcui.Text = currentRow.Row("ciuProy").ToString

            Linkcui.Font.Bold = True
            Linkcui.NavigateUrl = "#"
            Linkcui.Attributes.Add("OnClick", "verB12('" & cui.ToString & "');")


            comentario.Attributes.Add("onClick", "return frmComentario('" + prioridadID.ToString + "','" + validado.ToString + "'); return true;")



            If Me.Request.QueryString("codsector") > 0 Then
                Link.Font.Bold = True
                Link.NavigateUrl = "#"
                Link.Attributes.Add("OnClick", "verOrdenServicioLog('" & prioridadID.ToString.Trim & "','" & eventoId & "','" & sectorid & "','" & sector & "','" & ViewState("acuerdoPreacuerdo").ToString & "');")
                LinkCant.Font.Bold = True
                LinkCant.NavigateUrl = "#"
                LinkCant.Attributes.Add("OnClick", "verOrdenServicioLog('" & prioridadID.ToString.Trim & "','" & eventoId & "','" & sectorid & "','" & sector & "','" & ViewState("acuerdoPreacuerdo").ToString & "');")



            Else
                If validado = 0 Or validado = 2 Or validado = 3 Then
                    edita_img.Attributes.Add("onClick", "return frmnovado('" + prioridadID.ToString + "');")
                    eliminaHito.Attributes.Add("onClick", "return deleteAvan('" + prioridadID.ToString + "');")
                Else
                    edita_img.Attributes.Add("onClick", "return mensaje('error', 'El Pedido ya fue validado'); return false;")
                    eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'El Pedido ya fue validado'); return true;")
                End If

            End If


            If validado = 0 Or validado = 3 Then
                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/close24.png"
                If Me.Request.QueryString("sup") = 2 Then
                    valida.Attributes.Add("onClick", "return frmValidacionPed('" + prioridadID.ToString + "'); return true;")
                Else
                    valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                End If
            ElseIf validado = 2 Then
                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/closeNaranja24.png"
                valida.ToolTip = "Pedido Observado"
                If Me.Request.QueryString("sup") = 2 Then
                    valida.Attributes.Add("onClick", "return frmValidacionPed('" + prioridadID.ToString + "'); return true;")
                Else
                    valida.Attributes.Add("onClick", "return mensaje('error', 'El Pedido esta observado'); return true;")
                End If

            Else
                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                valida.ToolTip = "Pedido validado"
                valida.Attributes.Add("onClick", "return mensaje('error', 'El Pedido ya fue validado'); return true;")
            End If


        Next
    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "desestima" Then

        Else
            Dim i As Integer
            Dim indicador As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            For i = 0 To 1
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    indicador = a(1)
                End If
            Next
            If param = "deleteAvan" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblPrioridadAcuerdo set estado = 0 where prioridadID = " & indicador

                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        Me.RadGrid1.Rebind()
                    Catch ex As Exception
                    End Try
                End If
            ElseIf param = "frmValidacionPed" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblPrioridadAcuerdo set validado = 1, comentarioPCM = '' where prioridadID = " & indicador

                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        'SDS_SD_P_selectPrioridadAcuerdo.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                        Me.RadGrid1.Rebind()
                        'mensajeJSS("Se validó el Pedido")
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub

    Protected Sub exportarB_Click(sender As Object, e As EventArgs) Handles exportarB.Click
        CreateExcelFile()
    End Sub

    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()
        Dim sl As New SLDocument()
        sl.SetCellValue(4, 1, "ITEM")
        sl.SetCellValue(4, 2, "ESPACIO")
        sl.SetCellValue(4, 3, "SECTOR")
        sl.SetCellValue(4, 4, "UBIGEO")
        sl.SetCellValue(4, 5, "DEPARTAMENTO")
        sl.SetCellValue(4, 6, "PROVINCIA")
        sl.SetCellValue(4, 7, "EJE ESTRATÉGICO")
        sl.SetCellValue(4, 8, "TIPO INTERVENCION")
        sl.SetCellValue(4, 9, "PEDIDO")
        sl.SetCellValue(4, 10, "CUI")
        sl.SetCellValue(4, 11, "VALIDADO")
        sl.SetCellValue(4, 12, "PRE-ACUERDO")




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

        sl.SetColumnWidth(1, 1, 5)
        sl.SetColumnWidth(2, 5, 15)
        sl.SetColumnWidth(6, 8, 30)
        sl.SetColumnWidth(9, 9, 60)
        sl.SetColumnWidth(10, 1, 15)

        Dim rowIndex As Integer = 5
        Dim columnIndex As Integer = 1

        sl.SetCellValue(1, 1, "REPORTE DE PEDIDOS")
        sl.SetCellValue(2, 1, "Exportado el: " & Date.Now.ToString("dd/MM/yyyy HH:mm"))


        SW_pedidoDT = SW_pedidoDA.SD_P_selectPrioridadAcuerdoExport(0, cbo_evento.SelectedValue, grupoCB.SelectedValue, cbo_departamento1.SelectedValue, cbo_provincia1.SelectedValue)

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

        If SW_pedidoDT.Rows.Count > 0 Then
            For fil As Integer = 0 To SW_pedidoDT.Rows.Count - 1
                For i As Integer = 0 To SW_pedidoDT.Columns.Count - 8
                    sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(SW_pedidoDT.Rows(fil)(i).ToString()))
                    sl.SetCellStyle(rowIndex, columnIndex, stiloCon)
                    columnIndex += 1
                Next
                rowIndex += 1
                columnIndex = 1
            Next
            sl.SaveAs("C:/fichas/Pedidos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            Dim file As New FileInfo("C:/fichas/Pedidos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            If (file.Exists) Then
                Response.Clear()
                Response.AddHeader("Content-disposition", "attachment; filename=Pedidos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
                Response.ContentType = "application/vnd.ms-excel"
                Response.WriteFile(file.ToString())
                Response.End()
            End If

        End If
    End Sub

    'Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
    '    cbo_provincia1.Items.Clear()
    '    cbo_provincia1.DataBind()
    'End Sub

    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('warning','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub

    Protected Sub exportarBAcu_Click(sender As Object, e As EventArgs) Handles exportarBAcu.Click
        CreateExcelFileAcu()
    End Sub

    Private Sub CreateExcelFileAcu()
        Dim sl As New SLDocument()

        sl.SetCellValue(4, 1, "ITEM")
        sl.SetCellValue(4, 2, "ESPACIO")
        sl.SetCellValue(4, 3, "SECTOR")
        sl.SetCellValue(4, 4, "UBIGEO")
        sl.SetCellValue(4, 5, "DEPARTAMENTO")
        sl.SetCellValue(4, 6, "PROVINCIA")
        sl.SetCellValue(4, 7, "EJE ESTRATÉGICO")
        sl.SetCellValue(4, 8, "PEDIDO")
        sl.SetCellValue(4, 9, "CUI")
        sl.SetCellValue(4, 10, "CODIGO")
        sl.SetCellValue(4, 11, "ACUERDO")
        sl.SetCellValue(4, 12, "CLASIFICACION")
        sl.SetCellValue(4, 13, "RESPONSABLE")
        sl.SetCellValue(4, 14, "PLAZO")
        sl.SetCellValue(4, 15, "ESTADO")
        sl.SetCellValue(4, 16, "TIPO")
        sl.SetCellValue(4, 17, "RESPONSABLE CUMPLIMIENTO")

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

        sl.SetColumnWidth(1, 1, 10)
        sl.SetColumnWidth(2, 7, 18)
        sl.SetColumnWidth(8, 8, 60)
        sl.SetColumnWidth(9, 10, 15)
        sl.SetColumnWidth(11, 11, 60)
        sl.SetColumnWidth(12, 16, 20)
        sl.SetColumnWidth(17, 17, 30)

        Dim rowIndex As Integer = 5
        Dim columnIndex As Integer = 1

        sl.SetCellValue(1, 1, "REPORTE DE ACUERDOS")
        sl.SetCellValue(2, 1, "Exportado el: " & Date.Now.ToString("dd/MM/yyyy HH:mm"))


        SW_pedidoDT = SW_pedidoDA.SD_P_selectListAcuerdoExport(0, cbo_evento.SelectedValue, grupoCB.SelectedValue, cbo_departamento1.SelectedValue, cbo_provincia1.SelectedValue, "", 0, 0, 0, "0")

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

        If SW_pedidoDT.Rows.Count > 0 Then
            For fil As Integer = 0 To SW_pedidoDT.Rows.Count - 1
                For i As Integer = 0 To SW_pedidoDT.Columns.Count - 1
                    sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(SW_pedidoDT.Rows(fil)(i).ToString()))
                    sl.SetCellStyle(rowIndex, columnIndex, stiloCon)
                    columnIndex += 1
                Next
                rowIndex += 1
                columnIndex = 1
            Next
            sl.SaveAs("C:/fichas/Acuerdos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            Dim file As New FileInfo("C:/fichas/Acuerdos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            If (file.Exists) Then
                Response.Clear()
                Response.AddHeader("Content-disposition", "attachment; filename=Acuerdos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
                Response.ContentType = "application/vnd.ms-excel"
                Response.WriteFile(file.ToString())
                Response.End()
            End If

        End If
    End Sub

End Class