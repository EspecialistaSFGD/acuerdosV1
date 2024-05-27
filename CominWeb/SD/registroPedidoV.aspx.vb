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

Public Class registroPedidoV
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_validaCantDT As New DataTable
    Dim SW_validaSectorDT As New DataTable
    Dim SW_validaCanSectorDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroPedidoV_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectTipoInt.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectEje.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
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

            If Me.Request.QueryString("codigoid").ToString > 0 Then
                Session("pedido") = Me.Request.QueryString("codigoid").ToString()
                SW_pedidoDT = SW_pedidoDA.SD_P_selectPrioridadAcuerdo(Me.Request.QueryString("codigoid").ToString, 0, 0, 0, 0)
                If SW_pedidoDT.Rows.Count > 0 Then

                    grupoCB.SelectedValue = SW_pedidoDT.Rows(0).Item(3)
                    grupoCB.DataBind()

                    ejeCB.SelectedValue = SW_pedidoDT.Rows(0).Item(18)
                    ejeCB.DataBind()

                    intervencionCB.SelectedValue = SW_pedidoDT.Rows(0).Item(16)
                    intervencionCB.DataBind()
                    Me.aspectoTB.Text = SW_pedidoDT.Rows(0).Item(11)
                    Me.cuisTB.Text = SW_pedidoDT.Rows(0).Item(14)

                End If
            Else

                Session("pedido") = 0
                If Me.Request.QueryString("codsector").ToString > 0 Then
                    grupoCB.SelectedValue = Me.Request.QueryString("codsector").ToString
                    grupoCB.DataBind()
                    grupoCB.Enabled = False
                Else
                    grupoCB.Enabled = True
                End If

                ejeCB.Enabled = True
                intervencionCB.Enabled = True

            End If
        End If
    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "frmguardar" Then
            frmguardar()
        Else
            Dim i As Integer
            Dim idAcuerdo As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            Dim cadJS As String = ""
            For i = 0 To 1
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    idAcuerdo = a(1)
                End If
            Next
            If param = "desactivAcuerdo" Then
                cadJS = " UPDATE SD_tblAcuerdos SET estado = 0 WHERE acuerdoID = " & idAcuerdo.ToString
                Me.sw_ejecutaSQL.querySQL(cadJS)
                'Me.RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub frmguardar()
        If Me.Request.QueryString("codigoid").ToString = "0" Then
            SW_validaCantDT = SW_pedidoDA.SD_P_selectValidaPedidoCant(Me.Request.QueryString("codevento").ToString, Me.Request.QueryString("ubig"))
            If SW_validaCantDT.Rows.Count > 0 Then
                If SW_validaCantDT.Rows(0).Item(0) < SW_validaCantDT.Rows(0).Item(2) Then

                    SW_validaSectorDT = SW_pedidoDA.SD_P_selectValidaPrioridadAcuerdoSector(Me.Request.QueryString("codevento").ToString, grupoCB.SelectedValue, Me.Request.QueryString("ubig"))

                    If SW_validaSectorDT.Rows.Count > 0 Then
                        If SW_validaSectorDT.Rows(0).Item(0) < SW_validaSectorDT.Rows(0).Item(2) Then

                            SW_pedidoDT = SW_pedidoDA.SD_P_selectValidaPrioridadAcuerdo(Me.Request.QueryString("codevento").ToString, 0, Me.Request.QueryString("ubig"), ejeCB.SelectedValue)
                            If SW_pedidoDT.Rows.Count > 0 Then
                                If SW_pedidoDT.Rows(0).Item(0) <> SW_pedidoDT.Rows(0).Item(2) Then
                                    guardax()
                                Else
                                    mensajeJSS("Límite permitido para el Eje Estratégico seleccionado")
                                End If
                            Else
                                guardax()
                            End If

                        Else
                            mensajeJSS("Límite de Pedido permitido para el Sector seleccionado")
                        End If
                    Else
                        'AQUI IRIA'SD_P_selectValidaCantSect
                        SW_validaCanSectorDT = SW_pedidoDA.SD_P_selectValidaCantSect(Me.Request.QueryString("codevento").ToString, Me.Request.QueryString("ubig"))
                        If SW_validaCanSectorDT.Rows.Count = 0 Then
                            guardax()
                        Else
                            If SW_validaCanSectorDT.Rows(0).Item(0) < SW_validaCanSectorDT.Rows(0).Item(1) Then
                                guardax()
                            Else
                                mensajeJSS("Solo puede seleccionar 5 sectores como máximo")
                            End If
                        End If

                    End If
                Else
                    mensajeJSS("Límite de Pedido permitido por el Consejo de Estado Regional")
                End If

            Else
                guardax()
            End If
        Else
            'guardax()
            SW_validaSectorDT = SW_pedidoDA.SD_P_selectValidaPrioridadAcuerdoSector(Me.Request.QueryString("codevento").ToString, grupoCB.SelectedValue, Me.Request.QueryString("ubig"))

            If SW_validaSectorDT.Rows.Count > 0 Then
                If SW_validaSectorDT.Rows(0).Item(0) < SW_validaSectorDT.Rows(0).Item(2) Then

                    SW_pedidoDT = SW_pedidoDA.SD_P_selectValidaPrioridadAcuerdo(Me.Request.QueryString("codevento").ToString, 0, Me.Request.QueryString("ubig"), ejeCB.SelectedValue)
                    If SW_pedidoDT.Rows.Count > 0 Then
                        If SW_pedidoDT.Rows(0).Item(0) <> SW_pedidoDT.Rows(0).Item(2) Then
                            guardax()
                        Else
                            mensajeJSS("Límite permitido para el Eje Estratégico seleccionado")
                        End If
                    Else
                        guardax()
                    End If

                Else
                    mensajeJSS("Límite de Pedido permitido para el Sector seleccionado")
                End If
            Else
                'AQUI IRIA'SD_P_selectValidaCantSect
                SW_validaCanSectorDT = SW_pedidoDA.SD_P_selectValidaCantSect(Me.Request.QueryString("codevento").ToString, Me.Request.QueryString("ubig"))
                If SW_validaCanSectorDT.Rows.Count = 0 Then
                    guardax()
                Else
                    If SW_validaCanSectorDT.Rows(0).Item(0) < SW_validaCanSectorDT.Rows(0).Item(1) Then
                        guardax()
                    Else
                        mensajeJSS("Solo puede seleccionar 5 sectores como máximo")
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub guardax()
        SW_pedidoDT = SW_pedidoDA.SD_P_selectEventos(Me.Request.QueryString("codevento").ToString, 0)
        Dim codigoid As String
        codigoid = ""
        If SW_pedidoDT.Rows(0).Item(4) = "R" Then
            codigoid = SW_pedidoDA.SD_P_crearUpdatePrioridadAcuerdo(Session("pedido"), Me.Request.QueryString("codevento").ToString,
                grupoCB.SelectedValue, Me.Request.QueryString("de").ToString, "", ejeCB.SelectedValue.ToString, intervencionCB.SelectedValue.ToString, aspectoTB.Text.ToString.Trim, cuisTB.Text.ToString.Trim, Request.QueryString("iacp").ToString)
        ElseIf SW_pedidoDT.Rows(0).Item(4) = "P" Then
            codigoid = SW_pedidoDA.SD_P_crearUpdatePrioridadAcuerdo(Session("pedido"), Me.Request.QueryString("codevento").ToString,
                grupoCB.SelectedValue, Me.Request.QueryString("ubig").ToString, "", ejeCB.SelectedValue.ToString, intervencionCB.SelectedValue.ToString, aspectoTB.Text.ToString.Trim, cuisTB.Text.ToString.Trim, Request.QueryString("iacp").ToString)
        End If

        'Session("pedido") = codigoid
        If codigoid <> 0 Then
            Dim cadena_java As String
            cadena_java = "<script type='text/javascript'> " &
                          " CerrarVentana(" & codigoid.ToString & "); " &
                          Chr(60) & "/script>"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "Cerrar", cadena_java.ToString, False)
        End If
    End Sub


    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub

End Class