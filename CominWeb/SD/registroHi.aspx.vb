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


Public Class registroHi
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroHi_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            'SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Page.IsPostBack = False Then
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
            Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
            If Me.Request.QueryString("codh").ToString > 0 Then
                SW_pedidoDT = SW_pedidoDA.SD_P_selectListHitos(Me.Request.QueryString("codh").ToString, 0, 0, "999")
                If SW_pedidoDT.Rows.Count > 0 Then

                    hitoTB.Text = SW_pedidoDT.Rows(0).Item(0)

                    responsableCB.SelectedValue = SW_pedidoDT.Rows(0).Item(8)
                    responsableCB.DataBind()

                    plazoRDP.SelectedDate = SW_pedidoDT.Rows(0).Item(2).ToString.Trim

                End If
            Else
                Me.plazoRDP.MinDate = Date.Now
                SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
                Me.plazoRDP.MaxDate = SW_pedidoDT.Rows(0).Item(8)

                'SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
                'If SW_pedidoDT.Rows(0).Item(8) < Date.Now Then
                '    mensajeJSS("Acuerdo Vencido")
                'Else
                '    Me.plazoRDP.MinDate = Date.Now
                '    Me.plazoRDP.MaxDate = SW_pedidoDT.Rows(0).Item(8)
                'End If

            End If
        End If
    End Sub


    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "guardar" Then
            guardar(Me.Request.QueryString("codh").ToString, Me.Request.QueryString("codigoid").ToString, hitoTB.Text.ToString.Trim, responsableCB.SelectedValue, plazoRDP.SelectedDate.Value.ToString("dd/MM/yyyy"), "")
        End If
    End Sub

    Private Sub guardar(ByVal hitdoId As Integer, acuerdoid As Integer, hito As String, responsable As Integer, plazo As String, comentario As String)

        Dim cad As String = ""
        cad = " exec SD_P_crearUpdateHito " & hitdoId.ToString & ", " & acuerdoid.ToString & ", '" & hito.ToString & "', " & responsable.ToString & ", '" & plazo & "', '" & comentario & "'"

        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
                cierraVentana(2)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub cierraVentana(ByVal id As Integer)
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " CerrarVentana(" & id.ToString & "); " &
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