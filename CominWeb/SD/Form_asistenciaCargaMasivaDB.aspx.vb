Imports CominWeb.SW_coneccionDB
Imports System.Globalization
Imports System.Threading
Imports System.Net


Public Class Form_asistenciaCargaMasivaDB
    Inherits System.Web.UI.Page

    Dim sw_asistente_DT As New DataTable
    Dim sw_mancomu_DT As New DataTable
    Dim sw_asistente As New SW_SD_asistente_DA

    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_asistenciaCargaMasivaDB_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
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
            nombreDocumentoTB.Focus()
            nuevoB.Visible = True
            tituloLB.Text = "IMPORTACION DE ACREDITADOS"
        End If
    End Sub

    Protected Sub nuevoB_Click(sender As Object, e As EventArgs) Handles nuevoB.Click

        Dim cad As String = ""
        cad = " exec SD_P_importaAcreditados '" & nombreDocumentoTB.Text.ToString.Trim & "', '" & nombreHojaTB.Text.ToString.Trim & "', " & cbo_evento.SelectedValue
        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
                Me.estadoLB.Text = "ARCHIVO PROCESADO CON ÉXITO"
            Catch ex As Exception
                Me.estadoLB.Text = "ARCHIVO CON ERRORES!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
            End Try
        End If
        'If sw_asistente_DT.Rows.Count > 0 Then
        '    estadoLB.Text = sw_asistente_DT.Rows(0).Item(5).ToString & " " & sw_asistente_DT.Rows(0).Item(3).ToString & " " & sw_asistente_DT.Rows(0).Item(4).ToString & ", CON DNI " & sw_asistente_DT.Rows(0).Item(2).ToString & ", CON CARGO " & sw_asistente_DT.Rows(0).Item(6).ToString & " - ACREDITADO ! "
        'Else
        '    estadoLB.Text = " ** NO ACREDITADO ** "
        'End If
    End Sub

    'Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
    '    If e.Argument.ToString = "buscaJQ" Then
    '        busca(nroDocTB.Text.ToString.Trim)
    '    End If
    'End Sub

End Class