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


Public Class registroSituacion
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroSituacion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"

            SDS_SD_P_selectFaseInv.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectEtapaInv.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectHitoInv.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectListSituaciones.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")

        If Page.IsPostBack = False Then
            'If Me.Request.QueryString("codac").ToString > 0 Then
            inversionLB.Text = Me.Request.QueryString("tip").ToString & " " & Me.Request.QueryString("cinv").ToString & ": " & Me.Request.QueryString("nom").ToString

            '    SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codac").ToString, 0, "", 0, 0)
            '    If SW_pedidoDT.Rows.Count > 0 Then

            '        acuerdoTB.Text = SW_pedidoDT.Rows(0).Item(3)

            '        'Me.ultimaActualizacionLB.Text = SW_ordenesTrabajoDT.Rows(0).Item(44)
            '        'Me.txtot.Text = SW_ordenesTrabajoDT.Rows(0).Item(1).ToString.Trim

            '        'Me.cbo_turno.Selecte dValue = SW_ordenesTrabajoDT.Rows(0).Item(37).ToString
            '        'Me.cbo_turno.DataBind()
            '        'Me.fechacreacionRDP.SelectedDate = SW_ordenesTrabajoDT(0).Item(3).ToString.Trim
            '        'monedaCB.SelectedValue = SW_ordenesTrabajoDT(0).Item(58)
            '        'monedaCB.DataBind()
            '        'tipoCambio()
            '        'Me.txtnotas.Text = SW_ordenesTrabajoDT.Rows(0).Item(27).ToString.Trim

            '    End If
            'Else
            '    Me.plazoRDP.MinDate = Date.Now
            '    'Me.ultimaActualizacionLB.Text = Date.Now.ToString("dd/MM/yyyy")
            '    'Me.fechacreacionRDP.SelectedDate = Date.Now
            '    'tipoCambioTB.Text = "1"
            '    'valorTC3.Value = Session("tipoCambioVentaSession")
            '    'Me.horaTP.SelectedTime = Date.Now.TimeOfDay
            '    'generaCodigoDT = sw_ejecutaSQL.P_GeneradorCodigos(1, "COT")
            '    'txtot.Text = generaCodigoDT.Rows(0).Item(0)
            '    'clienteDefault = sw_ejecutaSQL.P_selectParametroByID(70)
            '    'If clienteDefault.Rows(0).Item(2) = 1 Then
            '    '    txtRazonSocialID.Text = clienteDefault.Rows(0).Item(3)
            '    '    DatosCliente()
            '    'End If
            'End If
        End If
    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        Dim cad As String = ""
        If (e.Argument.ToString = "guardar") Then
            cad = " exec SD_P_crearUpdateSituacion 0, " & Request.QueryString("inId") & ", " & hitoCB.SelectedValue.ToString & ", '" & fechaRDP.SelectedDate.Value.ToString("dd/MM/yyyy") & "', '" & situacionTB.Text.ToString & "', " & Request.QueryString("iacp")


            If cad.Length > 0 Then
                Try
                    Me.sw_ejecutaSQL.querySQL(cad)
                    cierraVentana()
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub


    Protected Sub faseCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles faseCB.SelectedIndexChanged
        etapaCB.Items.Clear()
        etapaCB.DataBind()
        hitoCB.Items.Clear()
        hitoCB.DataBind()
    End Sub


    Protected Sub etapaCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles etapaCB.SelectedIndexChanged
        hitoCB.Items.Clear()
        hitoCB.DataBind()
    End Sub


    Private Sub cierraVentana()
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " CerrarVentana(1); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "Cerrar", cadena_java.ToString, False)
    End Sub

    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub


End Class