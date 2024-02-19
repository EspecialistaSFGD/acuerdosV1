Imports CominWeb.SW_coneccionDB
Imports System.Globalization
Imports System.Threading

Public Class Form_hitoPcb
    Inherits System.Web.UI.Page

    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA
    Dim sw_SSFD As New SW_SSFD_DA
    Dim ssfdDT As New DataTable

    Private Sub Form_hitoPcb_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Request.QueryString("gjXtIkEroS").ToString = "eninbWFudWNjfsdDWqWSDFsdWWaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "SSFD_TransCS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        SDS_P_selectHitos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        If Page.IsPostBack = False Then
            ViewState("id") = 0
            ViewState("idRes") = 0
            hitosCB.DataBind()
            cargaHitos()
        End If
    End Sub


    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "insertaHito" Then
            Dim cad As String = ""

            If FechaFinRDP.SelectedDate <= fechaInicioRDP.SelectedDate Then
                mensajeJSS("La fecha de vencimiento no puede ser menor a fecha de emision.")
                Exit Sub
            Else

                cad = " exec ssfd.P_crearUpdateHito " & ViewState("id").ToString & "," & Request.QueryString("cod").ToString &
                    ",'" & responsableTB.Text.ToString & "','" & hitoTb.Text.ToString & "','" & fechaInicioRDP.SelectedDate.Value.ToString("dd/MM/yyyy") &
                    "','" & FechaFinRDP.SelectedDate.Value.ToString("dd/MM/yyyy") & "'," & hitosCB.SelectedValue.ToString & ", 1, 1"
                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        cierraVentana()
                    Catch ex As Exception
                    End Try
                End If
            End If
            'Else
            '    Dim datos() As String = Split(e.Argument, ",")
            '    If datos(0) = "DatosTiempoEstandar" Then
            '        Session("tipoSistematf") = datos(1)
            '        DatosTiempoEstandar()
            '    End If
        End If
    End Sub

    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)
    End Sub

    Private Sub cierraVentana()
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " CerrarVentana(1); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "CerrarVentana", cadena_java.ToString, False)
    End Sub

    Protected Sub hitosCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hitosCB.SelectedIndexChanged
        cargaHitos()
    End Sub

    Private Sub cargaHitos()
        ssfdDT = sw_SSFD.P_selectHito(0, Me.Request.QueryString("cod").ToString, hitosCB.SelectedValue)
        If ssfdDT.Rows.Count > 0 Then
            ViewState("id") = ssfdDT.Rows(0).Item(0).ToString
            ViewState("idRes") = ssfdDT.Rows(0).Item(2).ToString
            hitoTb.Text = ssfdDT.Rows(0).Item(3).ToString
            responsableTB.Text = ssfdDT.Rows(0).Item(9).ToString
            fechaInicioRDP.SelectedDate = ssfdDT.Rows(0).Item(4).ToString.Trim
            FechaFinRDP.SelectedDate = ssfdDT.Rows(0).Item(5).ToString.Trim
        Else
            ViewState("id") = 0
            ViewState("idRes") = 0
            hitoTb.Text = ""
            responsableTB.Text = ""
            fechaInicioRDP.SelectedDate = Date.Now
            FechaFinRDP.SelectedDate = Date.Now
        End If
    End Sub

End Class