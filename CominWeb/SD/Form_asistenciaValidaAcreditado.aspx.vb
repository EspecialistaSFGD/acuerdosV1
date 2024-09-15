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


Public Class Form_asistenciaValidaAcreditado
    Inherits System.Web.UI.Page

    Dim sw_asistente_DT As New DataTable
    Dim sw_mancomu_DT As New DataTable
    Dim sw_asistente As New SW_SD_asistente_DA

    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_asistenciaValidaAcreditado_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            'SDS_P_SelectDocumento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
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
        'tituloLB.Text = Request.QueryString("nosucp").ToString

        If Page.IsPostBack = False Then
            nroDocTB.Focus()
            nuevoB.Visible = True
            tituloLB.Text = "VALIDACIÓN DE ACREDITADOS"
        End If
    End Sub

    Protected Sub nuevoB_Click(sender As Object, e As EventArgs) Handles nuevoB.Click

        If nroDocTB.Text.ToString.Trim.Length > 5 Then
            Dim cad As String = ""
            sw_asistente_DT = sw_asistente.SD_P_selectValidaAcreditado(nroDocTB.Text.ToString, cbo_evento.SelectedValue)
            If sw_asistente_DT.Rows.Count > 0 Then
                estadoLB.Text = sw_asistente_DT.Rows(0).Item(0).ToString & " " & sw_asistente_DT.Rows(0).Item(1).ToString &
                    ", CON DNI " & sw_asistente_DT.Rows(0).Item(2).ToString & ", CON CARGO " & sw_asistente_DT.Rows(0).Item(3).ToString & " - ACREDITADO ! "
                nroDocTB.Text = ""
            Else
                estadoLB.Text = " ** NO ACREDITADO ** "
                nroDocTB.Text = ""
            End If
        Else
            estadoLB.Text = " ** INGRESE DNI VÁLIDO ** "
            nroDocTB.Text = ""
        End If


        nroDocTB.Focus()
    End Sub

    'Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
    '    If e.Argument.ToString = "buscaJQ" Then
    '        busca(nroDocTB.Text.ToString.Trim)
    '    End If
    'End Sub

End Class