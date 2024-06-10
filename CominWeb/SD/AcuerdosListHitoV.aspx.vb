Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports System
Imports System.IO
Imports System.Net
Imports SpreadsheetLight
Imports DocumentFormat.OpenXml

Public Class AcuerdosListHitoV
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub AcuerdosListHitoV_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Session("usuarioLoginID") = Nothing Then
        '    Response.Redirect("~/SD/Form_asistenciaListOp.aspx?gjXtIkEroS=SD_SSFD")
        'End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        'Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        'tituloLB.Text = Request.QueryString("nosucp").ToString


        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            Dim validaDT As New DataTable
            validaDT = SW_pedidoDA.SD_P_selectAcceso(0, Request.QueryString("en").ToString, 9)
            If validaDT.Rows.Count = 1 Then

                SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectClasifica.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_SD_P_selectListAcuerdoHito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                'SDS_SD_P_selectEstadoTipo.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectEstadoTipo.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            Else
                variableGlobalConexion.nombreCadenaCnx = ""
                Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
            End If
        Else
        variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If


        If Page.IsPostBack = False Then
            'Session("estadoFiltroAcuHito") = "0"
            Session("estadoFiltroAcuerdo") = "0,1,2,3,4,"
            estadoCB.ToolTip = Session("estadoTextoAcuerdo")
            If Request.QueryString("sup") = 2 Then
                grupoCB.Enabled = True
            Else
                grupoCB.Enabled = False
            End If
        End If
    End Sub

    Protected Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click
        'Session("estadoFiltroAcuHito") = ""
        'Dim collection As IList(Of RadComboBoxItem) = estadoCB.CheckedItems
        'If (collection.Count <> 0) Then
        '    For Each item As RadComboBoxItem In collection
        '        Session("estadoFiltroAcuHito") = Session("estadoFiltroAcuHito") & item.Value & ","
        '    Next
        'End If
        'If Session("estadoFiltroAcuHito").ToString.Trim.Length > 0 Then
        '    Session("estadoFiltroAcuHito") = Mid(Session("estadoFiltroAcuHito"), 1, Len(Session("estadoFiltroAcuHito")) - 1)
        'Else
        '    Session("estadoFiltroAcuHito") = "0"
        'End If

        Dim sb As New StringBuilder() '0
        Dim collection As IList(Of RadComboBoxItem) = estadoCB.CheckedItems
        If (collection.Count <> 0) Then
            Session("estadoFiltroAcuerdo") = ""
            Session("estadoTextoAcuerdo") = ""
            'sb.Append("<h3>Checked Items:</h3><ul class=""results"">") '0
            For Each item As RadComboBoxItem In collection
                Session("estadoFiltroAcuerdo") = Session("estadoFiltroAcuerdo") & item.Value & ","
                Session("estadoTextoAcuerdo") = Session("estadoTextoAcuerdo") & item.Text & ","
                'sb.Append(item.Text + ", ") '0
            Next

            'sb.Append("</ul>") '0
            'estadoCB.Text = sb.ToString() '0

            If Session("estadoFiltroAcuerdo").ToString.Trim.Length > 0 Then
                Session("estadoFiltroAcuerdo") = Mid(Session("estadoFiltroAcuerdo"), 1, Len(Session("estadoFiltroAcuerdo")) - 1)
                Session("estadoTextoAcuerdo") = Mid(Session("estadoTextoAcuerdo"), 1, Len(Session("estadoTextoAcuerdo")) - 1)
            Else
                Session("estadoFiltroAcuerdo") = "2"
                Session("estadoTextoAcuerdo") = "PENDIENTE"
            End If
            estadoCB.ToolTip = Session("estadoTextoAcuerdo")
        End If


        Me.RadGrid1.Rebind()
    End Sub




    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        For Each item As GridDataItem In RadGrid1.Items
            Dim acuerdoID As Integer = item("acuerdoID").Text
            Dim estadoRegistro As Integer = item("estadoRegistro").Text
            Dim estadoHi As Integer = item("estadoHi").Text
            Dim hitdoId As Integer = item("hitdoId").Text
            Dim evidenciaurl As String = item("evidencia").Text
            Dim avanceId As Integer = item("avanceId").Text
            Dim validaPCM As Integer = item("validaPCM").Text


            Dim comentario As ImageButton = item.FindControl("TCComentario")

            Dim currentRow As DataRowView = DirectCast(item.DataItem, DataRowView)
            Dim Link As HyperLink = item.FindControl("Link")
            Dim avance As ImageButton = item.FindControl("TCAvance")
            Dim evidencia As ImageButton = item.FindControl("TCEvidencia")

            Dim estadoRegistroInterno As Integer = item("estadoRegistroInterno").Text

            Dim valida As ImageButton = item.FindControl("TCValida")


            avance.Attributes.Add("onClick", "return frmAvanceN('" + acuerdoID.ToString + "','" + hitdoId.ToString + "','" + estadoHi.ToString + "'); return true;")

            Link.Text = currentRow.Row("codigo").ToString
            Link.Font.Bold = True
            Link.NavigateUrl = "#"
            Link.Attributes.Add("OnClick", "verHitos('" & acuerdoID.ToString.Trim & "','" & estadoRegistro.ToString & "');")

            If hitdoId = 0 Then

                comentario.Attributes.Add("onClick", "mensaje('error', 'El Acuerdo no tiene hitos creados'); return false;")
                evidencia.Attributes.Add("onClick", "mensaje('error', 'No hay evidencia'); return false;")
            Else
                If avanceId = 0 Then

                    comentario.Attributes.Add("onClick", "mensaje('error', 'El Hito no tiene avances creados por las entidad responsable'); return false;")
                    evidencia.Attributes.Add("onClick", "mensaje('error', 'No hay evidencia'); return false;")
                Else

                    If evidenciaurl.Length <> 0 Then
                        evidencia.Attributes.Add("onClick", "return frmEvidencia('" + avanceId.ToString + "','" + estadoHi.ToString + "','evidencia/" + evidenciaurl.ToString + "'); return true;")
                    End If

                    comentario.Attributes.Add("onClick", "return frmComentario('" + avanceId.ToString + "',4); return true;")
                    If validaPCM = 0 Then
                        valida.Attributes.Add("onClick", "return frmValidaAvancePCM('" + avanceId.ToString + "',999); return true;")
                    Else
                        valida.Attributes.Add("onClick", "mensaje('confirm', 'El avance ya fue validado por PCM'); return false;")
                        valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                    End If


                End If
            End If

            If estadoRegistroInterno = 3 Then
                Dim itemx As GridDataItem = CType(item, GridDataItem)
                Dim cell As TableCell = CType(itemx("NomEstadoRegistroAC"), TableCell)
                cell.BackColor = Drawing.Color.LightSalmon
            ElseIf estadoRegistroInterno = 4 Then
                Dim itemx As GridDataItem = CType(item, GridDataItem)
                Dim cell As TableCell = CType(itemx("NomEstadoRegistroAC"), TableCell)
                cell.BackColor = Drawing.Color.LightGreen
            End If
        Next
    End Sub


    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub

    Protected Sub exportarB_Click(sender As Object, e As EventArgs) Handles exportarB.Click
        CreateExcelFile()
    End Sub


    Protected Sub expHitoB_Click(sender As Object, e As EventArgs) Handles expHitoB.Click
        CreateHitoExcelFile()
    End Sub
    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateHitoExcelFile()

        Dim sb As New StringBuilder() '0
        Dim collection As IList(Of RadComboBoxItem) = estadoCB.CheckedItems
        If (collection.Count <> 0) Then
            Session("estadoFiltroAcuerdo") = ""
            Session("estadoTextoAcuerdo") = ""
            'sb.Append("<h3>Checked Items:</h3><ul class=""results"">") '0
            For Each item As RadComboBoxItem In collection
                Session("estadoFiltroAcuerdo") = Session("estadoFiltroAcuerdo") & item.Value & ","
                Session("estadoTextoAcuerdo") = Session("estadoTextoAcuerdo") & item.Text & ","
                'sb.Append(item.Text + ", ") '0
            Next

            'sb.Append("</ul>") '0
            'estadoCB.Text = sb.ToString() '0

            If Session("estadoFiltroAcuerdo").ToString.Trim.Length > 0 Then
                Session("estadoFiltroAcuerdo") = Mid(Session("estadoFiltroAcuerdo"), 1, Len(Session("estadoFiltroAcuerdo")) - 1)
                Session("estadoTextoAcuerdo") = Mid(Session("estadoTextoAcuerdo"), 1, Len(Session("estadoTextoAcuerdo")) - 1)
            Else
                Session("estadoFiltroAcuerdo") = "2"
                Session("estadoTextoAcuerdo") = "PENDIENTE"
            End If
            estadoCB.ToolTip = Session("estadoTextoAcuerdo")
        End If

        Dim sl As New SLDocument()
        sl.SetCellValue(4, 1, "ITEM")
        sl.SetCellValue(4, 2, "ESPACIO")
        sl.SetCellValue(4, 3, "SECTOR")
        sl.SetCellValue(4, 4, "UBIGEO")

        sl.SetCellValue(4, 5, "DEPARTAMENTO")
        sl.SetCellValue(4, 6, "PROVINCIA")
        sl.SetCellValue(4, 7, "INTERVENCION ESTRATÉGICAS")
        sl.SetCellValue(4, 8, "ASPECTO CRÍTICO A RESOLVER")
        sl.SetCellValue(4, 9, "CUI")
        sl.SetCellValue(4, 10, "CODIGO")
        sl.SetCellValue(4, 11, "ACUERDO")
        sl.SetCellValue(4, 12, "CLASIFICACION")
        sl.SetCellValue(4, 13, "RESPONSABLE")
        sl.SetCellValue(4, 14, "PLAZO")
        sl.SetCellValue(4, 15, "ESTADO")

        sl.SetCellValue(4, 16, "F. CUMPLIMIENTO")
        sl.SetCellValue(4, 17, "HITO")
        sl.SetCellValue(4, 18, "RESPONSABLE DE HITO")
        sl.SetCellValue(4, 19, "PLAZO DE HITO")
        sl.SetCellValue(4, 20, "ESTADO DE HITO")
        sl.SetCellValue(4, 21, "AVANCE")
        sl.SetCellValue(4, 22, "FECHA DEL AVANCE")
        sl.SetCellValue(4, 23, "COMENTARIO")
        sl.SetCellValue(4, 24, "VALIDADO SECTOR")
        sl.SetCellValue(4, 25, "VALIDADO PCM")
        sl.SetCellValue(4, 26, "FECHA REGISTRO AVANCE")
        sl.SetCellValue(4, 27, "TIPO")


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
        'stiloCon.FormatCode = "12345.678909"
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
        stiloTitulo.Font.FontSize = 14
        stiloTitulo.Font.Bold = True
        'stiloTitulo.FormatCode = "12345.678909"
        stiloTitulo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Left)

        'subtitulo
        Dim stiloSubTitulo As SLStyle = sl.CreateStyle()
        stiloSubTitulo.Font.FontName = "Calibri"
        stiloSubTitulo.Font.FontSize = 9
        stiloSubTitulo.Font.Bold = True
        'stiloSubTitulo.FormatCode = "12345.678909"
        stiloSubTitulo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Left)



        sl.SetColumnWidth(5, 6, 18)
        sl.SetColumnWidth(7, 8, 35)
        sl.SetColumnWidth(9, 10, 15)
        sl.SetColumnWidth(11, 11, 35)
        sl.SetColumnWidth(12, 12, 20)
        sl.SetColumnWidth(13, 16, 15)
        sl.SetColumnWidth(17, 17, 40)
        sl.SetColumnWidth(18, 20, 15)
        sl.SetColumnWidth(21, 21, 40)
        sl.SetColumnWidth(22, 27, 15)

        Dim rowIndex As Integer = 5
        Dim columnIndex As Integer = 1

        sl.SetCellValue(1, 1, "REPORTE DE HITOS")
        sl.SetCellValue(2, 1, "Exportado el: " & Date.Now.ToString("dd/MM/yyyy HH:mm"))

        SW_pedidoDT = SW_pedidoDA.SD_P_selectListAcuerdoHitoExport(0, cbo_evento.SelectedValue, grupoCB.SelectedValue, cbo_departamento1.SelectedValue, cbo_provincia1.SelectedValue, codigoTB.Text.ToString.Trim, clasificaCB.SelectedValue, 0, 0, estadoCBv.SelectedValue, Session("estadoFiltroAcuerdo").ToString)


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
        sl.SetCellStyle(4, 18, stilo)
        sl.SetCellStyle(4, 19, stilo)
        sl.SetCellStyle(4, 20, stilo)
        sl.SetCellStyle(4, 21, stilo)
        sl.SetCellStyle(4, 22, stilo)
        sl.SetCellStyle(4, 23, stilo)
        sl.SetCellStyle(4, 24, stilo)
        sl.SetCellStyle(4, 25, stilo)
        sl.SetCellStyle(4, 26, stilo)
        sl.SetCellStyle(4, 27, stilo)

        'sl.SetRowStyle(rowIndex, SW_pedidoDT.Rows.Count + rowIndex - 1, stiloCon)


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
            sl.SaveAs("C:/fichas/AcuerdosHitos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            Dim file As New FileInfo("C:/fichas/AcuerdosHitos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
            If (file.Exists) Then
                Response.Clear()
                Response.AddHeader("Content-disposition", "attachment; filename=AcuerdosHitos_" & cbo_evento.SelectedItem.ToString & ".xlsx")
                Response.ContentType = "application/vnd.ms-excel"
                Response.WriteFile(file.ToString())
                Response.End()
            End If

        End If
    End Sub

    Private Sub CreateExcelFile()
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


        SW_pedidoDT = SW_pedidoDA.SD_P_selectListAcuerdoExport(0, cbo_evento.SelectedValue, grupoCB.SelectedValue, cbo_departamento1.SelectedValue, cbo_provincia1.SelectedValue, "", 0, 0, 0, Session("estadoFiltroAcuerdo").ToString)

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

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "ejecutaAjax" Then

        Else

            Dim i As Integer
            Dim tip As String
            Dim indicador As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            Dim cadjs As String = ""
            For i = 0 To 1
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    indicador = a(1)
                End If
            Next
            If param = "validaPCM" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblAvance SET validaPCM = 1, fechaValidaPCM = GETDATE() WHERE avanceId = " & indicador.ToString
                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        Me.RadGrid1.Rebind()
                    Catch ex As Exception
                    End Try
                End If
            End If

        End If
    End Sub



    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        cbo_provincia1.Items.Clear()
        cbo_provincia1.DataBind()
    End Sub

    Public Function GetColor(ByVal est As String) As Drawing.Color
        Dim col As Drawing.Color
        If est = "PENDIENTE" Then
            col = Drawing.Color.Green
            'ElseIf est = "VENCIDO" Then
            '    col = Drawing.Color.Red
        ElseIf est = "CULMINADO" Then
            col = Drawing.Color.Black
        ElseIf est = "EN PROCESO" Then
            col = Drawing.Color.MediumBlue
        ElseIf est = "DESESTIMADO" Then
            col = Drawing.Color.Red
        End If
        Return col
    End Function

End Class