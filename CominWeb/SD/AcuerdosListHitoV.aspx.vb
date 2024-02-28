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


Public Class AcuerdosListHitoV
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA

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
            SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectClasifica.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_SD_P_selectListAcuerdoHito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString

        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If

        'If Page.IsPostBack = False Then
        '    desdeRDP.SelectedDate = Date.Now.ToString("dd/MM/yyyy")
        '    hastaRDP.SelectedDate = Date.Now.ToString("dd/MM/yyyy")
        'End If
    End Sub

    Protected Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click
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

            Dim currentRow As DataRowView = DirectCast(item.DataItem, DataRowView)
            Dim Link As HyperLink = item.FindControl("Link")
            Dim avance As ImageButton = item.FindControl("TCAvance")
            Dim evidencia As ImageButton = item.FindControl("TCEvidencia")

            avance.Attributes.Add("onClick", "return frmAvanceN('" + acuerdoID.ToString + "','" + hitdoId.ToString + "','" + estadoHi.ToString + "'); return true;")

            Link.Text = currentRow.Row("codigo").ToString
            Link.Font.Bold = True
            Link.NavigateUrl = "#"
            Link.Attributes.Add("OnClick", "verHitos('" & acuerdoID.ToString.Trim & "','" & estadoRegistro.ToString & "');")

            If evidenciaurl.Length <> 0 Then
                evidencia.Attributes.Add("onClick", "return frmEvidencia('" + avanceId.ToString + "','" + estadoHi.ToString + "','evidencia/" + evidenciaurl.ToString + "'); return true;")
            End If
        Next
    End Sub

    Protected Sub exportarB_Click(sender As Object, e As EventArgs) Handles exportarB.Click
        CreateExcelFile()
    End Sub
    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()
        Dim sl As New SLDocument()
        sl.SetCellValue(1, 1, "ESPACIO")
        sl.SetCellValue(1, 2, "SECTOR")
        sl.SetCellValue(1, 3, "DEPARTAMENTO")
        sl.SetCellValue(1, 4, "PROVINCIA")
        sl.SetCellValue(1, 5, "INTERVENCION ESTRATÉGICAS")
        sl.SetCellValue(1, 6, "ASPECTO CRÍTICO A RESOLVER")
        sl.SetCellValue(1, 7, "CUI")
        sl.SetCellValue(1, 8, "CODIGO")
        sl.SetCellValue(1, 9, "ACUERDO")
        sl.SetCellValue(1, 10, "CLASIFICACION")
        sl.SetCellValue(1, 11, "RESPONSABLE")
        sl.SetCellValue(1, 12, "PLAZO")

        Dim stilo As SLStyle = sl.CreateStyle()
        stilo.Font.FontName = "Calibri"
        stilo.Font.FontSize = 9
        stilo.Font.Bold = True
        stilo.FormatCode = "12345.678909"
        stilo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)

        sl.SetColumnWidth(1, 11, 15)

        Dim styleCon As SLStyle = sl.CreateStyle()
        styleCon.Font.FontSize = 9
        sl.SetColumnStyle(1, 12, styleCon)

        sl.SetRowStyle(1, 1, stilo)

        Dim rowIndex As Integer = 2
        Dim columnIndex As Integer = 1


        SW_pedidoDT = SW_pedidoDA.SD_P_selectListAcuerdoExport(0, cbo_evento.SelectedValue, grupoCB.SelectedValue, cbo_departamento1.SelectedValue, cbo_provincia1.SelectedValue, codigoTB.Text.ToString.Trim, clasificaCB.SelectedValue, responsableCB.SelectedValue, 0)

        If SW_pedidoDT.Rows.Count > 0 Then
            For fil As Integer = 0 To SW_pedidoDT.Rows.Count - 1
                For i As Integer = 0 To SW_pedidoDT.Columns.Count - 1
                    sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(SW_pedidoDT.Rows(fil)(i).ToString()))
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

    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        cbo_provincia1.Items.Clear()
        cbo_provincia1.DataBind()
    End Sub

End Class