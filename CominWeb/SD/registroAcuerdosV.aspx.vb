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

Public Class registroAcuerdosV
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroAcuerdosV_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            'SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectTipoInt.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectEje.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDistrito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectAcuerdos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
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

            SW_pedidoDT = SW_pedidoDA.SD_P_selectEventos(Me.Request.QueryString("codevento").ToString, 0)

            ViewState("tipoEvento") = SW_pedidoDT.Rows(0).Item(4)

            If SW_pedidoDT.Rows(0).Item(4) = "R" Then
                cbo_departamento1.Enabled = True
                cbo_provincia1.Enabled = False
                distritoCB.Enabled = False
            ElseIf SW_pedidoDT.Rows(0).Item(4) = "P" Then
                cbo_departamento1.Enabled = True
                cbo_provincia1.Enabled = True
                distritoCB.Enabled = False
            ElseIf SW_pedidoDT.Rows(0).Item(4) = "D" Then
                cbo_departamento1.Enabled = True
                cbo_provincia1.Enabled = True
                distritoCB.Enabled = True
            End If

            If Me.Request.QueryString("codigoid").ToString > 0 Then
                Session("pedido") = Me.Request.QueryString("codigoid").ToString()
                SW_pedidoDT = SW_pedidoDA.SD_P_selectPrioridadAcuerdo(Me.Request.QueryString("codigoid").ToString, 0, 0, 0, 0)
                If SW_pedidoDT.Rows.Count > 0 Then

                    'grupoCB.SelectedValue = SW_pedidoDT.Rows(0).Item(3)
                    'grupoCB.DataBind()

                    If ViewState("tipoEvento").ToString = "R" Then
                        cbo_departamento1.SelectedValue = SW_pedidoDT.Rows(0).Item(12)
                        cbo_departamento1.DataBind()
                        cbo_departamento1.Enabled = True
                        cbo_provincia1.Enabled = False
                        distritoCB.Enabled = False
                    ElseIf ViewState("tipoEvento").ToString = "P" Then
                        cbo_departamento1.SelectedValue = SW_pedidoDT.Rows(0).Item(12)
                        cbo_departamento1.DataBind()
                        cbo_provincia1.SelectedValue = SW_pedidoDT.Rows(0).Item(13)
                        cbo_provincia1.DataBind()
                        cbo_departamento1.Enabled = True
                        cbo_provincia1.Enabled = True
                        distritoCB.Enabled = False
                    ElseIf ViewState("tipoEvento").ToString = "D" Then
                        cbo_departamento1.SelectedValue = SW_pedidoDT.Rows(0).Item(12)
                        cbo_departamento1.DataBind()
                        cbo_provincia1.SelectedValue = SW_pedidoDT.Rows(0).Item(13)
                        cbo_provincia1.DataBind()
                        distritoCB.SelectedValue = SW_pedidoDT.Rows(0).Item(23)
                        distritoCB.DataBind()
                    End If

                    ejeCB.SelectedValue = SW_pedidoDT.Rows(0).Item(18)
                    ejeCB.DataBind()
                    'Me.intervencionTB.Text = SW_pedidoDT.Rows(0).Item(10)
                    Me.aspectoTB.Text = SW_pedidoDT.Rows(0).Item(11)
                    Me.cuisTB.Text = SW_pedidoDT.Rows(0).Item(14)

                    intervencionCB.SelectedValue = SW_pedidoDT.Rows(0).Item(16)
                    intervencionCB.DataBind()

                    'grupoCB.Enabled = False
                    cbo_departamento1.Enabled = False
                    cbo_provincia1.Enabled = False
                    distritoCB.Enabled = False
                    ejeCB.Enabled = False
                    intervencionCB.Enabled = False
                    cuisTB.Enabled = False
                    aspectoTB.Enabled = False

                    'Me.ultimaActualizacionLB.Text = SW_ordenesTrabajoDT.Rows(0).Item(44)
                    'Me.txtot.Text = SW_ordenesTrabajoDT.Rows(0).Item(1).ToString.Trim

                    'Me.cbo_turno.Selecte dValue = SW_ordenesTrabajoDT.Rows(0).Item(37).ToString
                    'Me.cbo_turno.DataBind()
                    'Me.fechacreacionRDP.SelectedDate = SW_ordenesTrabajoDT(0).Item(3).ToString.Trim
                    'monedaCB.SelectedValue = SW_ordenesTrabajoDT(0).Item(58)
                    'monedaCB.DataBind()
                    'tipoCambio()
                    'Me.txtnotas.Text = SW_ordenesTrabajoDT.Rows(0).Item(27).ToString.Trim

                End If
            Else
                Session("pedido") = 0
                'If Me.Request.QueryString("codsector").ToString > 0 Then
                '    grupoCB.SelectedValue = Me.Request.QueryString("codsector").ToString
                '    grupoCB.DataBind()
                '    grupoCB.Enabled = False
                'Else
                '    grupoCB.Enabled = True
                'End If


                ejeCB.Enabled = True
                intervencionCB.Enabled = True
                cuisTB.Enabled = True
                'aspectoTB.Enabled = True

                'Me.fechacreacionRDP.SelectedDate = Date.Now
                'tipoCambioTB.Text = "1"
                'valorTC3.Value = Session("tipoCambioVentaSession")
                'Me.horaTP.SelectedTime = Date.Now.TimeOfDay
                'generaCodigoDT = sw_ejecutaSQL.P_GeneradorCodigos(1, "COT")
                'txtot.Text = generaCodigoDT.Rows(0).Item(0)
                'clienteDefault = sw_ejecutaSQL.P_selectParametroByID(70)
                'If clienteDefault.Rows(0).Item(2) = 1 Then
                '    txtRazonSocialID.Text = clienteDefault.Rows(0).Item(3)
                '    DatosCliente()
                'End If
            End If
        End If
    End Sub

    Protected Sub retornarB_Click(sender As Object, e As EventArgs) Handles retornarB.Click
        'If Session("pedido") = 0 Then
        Response.Redirect("~/SD/prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&gjXtIkEroS=SD_SSFD&tipo=" & Me.Request.QueryString("tipo").ToString & "&ubig=" & Me.Request.QueryString("ubig").ToString +
                                "&de=" & Me.Request.QueryString("de").ToString + "&en=" & Me.Request.QueryString("en").ToString + "&sup=" & Me.Request.QueryString("sup").ToString +
                                "&enti=" & Me.Request.QueryString("enti").ToString + "&codsector=" & Me.Request.QueryString("codsector").ToString & "&iacp=" & Request.QueryString("iacp").ToString & "&preacuerdo=" & Request.QueryString("preacuerdo").ToString)

        'Else
        '            Dim codigoid As String = SW_pedidoDA.SD_P_crearUpdatePrioridadAcuerdo(Session("pedido"), Me.Request.QueryString("codevento").ToString,
        'grupoCB.SelectedValue, cbo_provincia1.SelectedValue, prioridadTerritorialTB.Text.ToString.Trim, objetivoTB.Text.ToString.Trim, intervencionTB.Text.ToString.Trim, aspectoTB.Text.ToString.Trim, cuisTB.Text.ToString.Trim)
        '            Response.Redirect("~/SD/prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
        '                                    "&gjXtIkEroS=SD_SSFD&codsector=" & Me.Request.QueryString("codsector").ToString & "&enti=" & Me.Request.QueryString("enti").ToString)
        'End If
        'Try


        'Catch ex As Exception
        'End Try
    End Sub


    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "ninguno" Then

        Else
            Dim i As Integer
            Dim idAcuerdo As String
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
                Me.RadGrid1.Rebind()
            ElseIf idAcuerdo = "A" Then
                frmacuerdo()
            ElseIf idAcuerdo = "R" Then
                retornar()
            End If
        End If
    End Sub

    Private Sub retornar()
        Dim ubi As Integer = 0

        If ViewState("tipoEvento").ToString = "R" Then
            ubi = cbo_departamento1.SelectedValue
        ElseIf ViewState("tipoEvento").ToString = "P" Then
            ubi = cbo_provincia1.SelectedValue
        ElseIf ViewState("tipoEvento").ToString = "D" Then
            ubi = distritoCB.SelectedValue
        End If

        Dim codigoid As String = SW_pedidoDA.SD_P_crearUpdatePrioridadAcuerdo(Session("pedido"), Me.Request.QueryString("codevento").ToString,
        Request.QueryString("codsector"), ubi.ToString, "", ejeCB.SelectedValue.ToString, intervencionCB.SelectedValue.ToString, aspectoTB.Text.ToString.Trim, cuisTB.Text.ToString.Trim, Request.QueryString("iacp").ToString)
        'Session("pedido") = codigoid
        If codigoid <> 0 Then

            Dim cad As String = ""
            cad = " UPDATE SD_tblPrioridadAcuerdo set validado = 1, comentarioPCM = '' where prioridadID = " & codigoid
            If cad.Length > 0 Then
                Try
                    Me.sw_ejecutaSQL.querySQL(cad)
                Catch ex As Exception
                End Try
            End If


            Response.Redirect("~/SD/prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&gjXtIkEroS=SD_SSFD&tipo=" & Me.Request.QueryString("tipo").ToString & "&ubig=" & Me.Request.QueryString("ubig").ToString +
                                "&de=" & Me.Request.QueryString("de").ToString + "&en=" & Me.Request.QueryString("en").ToString + "&sup=" & Me.Request.QueryString("sup").ToString +
                                "&enti=" & Me.Request.QueryString("enti").ToString + "&codsector=" & Me.Request.QueryString("codsector").ToString & "&iacp=" & Request.QueryString("iacp").ToString & "&preacuerdo=" & Request.QueryString("preacuerdo").ToString)
        Else
            mensajeJSS("No se guardo, comunicarse con la Secretaría de Descentralización de la PCM")
        End If
    End Sub

    Private Sub frmacuerdo()
        Dim ubi As Integer = 0

        If ViewState("tipoEvento").ToString = "R" Then
            ubi = cbo_departamento1.SelectedValue
        ElseIf ViewState("tipoEvento").ToString = "P" Then
            ubi = cbo_provincia1.SelectedValue
        ElseIf ViewState("tipoEvento").ToString = "D" Then
            ubi = distritoCB.SelectedValue
        End If

        Dim codigoid As String = SW_pedidoDA.SD_P_crearUpdatePrioridadAcuerdo(Session("pedido"), Me.Request.QueryString("codevento").ToString,
        Request.QueryString("codsector"), ubi.ToString, "", ejeCB.SelectedValue.ToString, intervencionCB.SelectedValue.ToString, aspectoTB.Text.ToString.Trim, cuisTB.Text.ToString.Trim, Request.QueryString("iacp").ToString)
        Session("pedido") = codigoid
        If codigoid <> 0 Then

            Dim cad As String = ""
            cad = " UPDATE SD_tblPrioridadAcuerdo set validado = 1, comentarioPCM = '' where prioridadID = " & codigoid
            If cad.Length > 0 Then
                Try
                    Me.sw_ejecutaSQL.querySQL(cad)
                Catch ex As Exception
                End Try
            End If

            Dim cadena_java As String
            cadena_java = "<script type='text/javascript'> " &
                                  " frmacuerdoN('" & codigoid.ToString & "'); " &
                                  Chr(60) & "/script>"
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "frmacuerdoN", cadena_java.ToString, False)
        End If
    End Sub

    'funcion publia para la visualización de alerta
    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub


    'Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
    Private Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound


        For Each item As GridDataItem In RadGrid1.Items
            Dim acuerdoIDg As Integer = item("acuerdoID").Text
            Dim prioridadID As Integer = item("prioridadID").Text
            Dim acuerdo As String = item("acuerdo").Text.ToString
            Dim estado_img As ImageButton = item.FindControl("estadoAcuerdob")
            Dim edita_img As ImageButton = item.FindControl("edita")
            Dim Link As HyperLink = item.FindControl("LinkTexto")
            Dim currentRow As DataRowView = DirectCast(item.DataItem, DataRowView)
            Link.Font.Bold = True
            Link.Text = currentRow.Row("texto").ToString
            Link.NavigateUrl = "#"

            estado_img.Attributes.Add("onClick", "return desactivarProducto('" + acuerdoIDg.ToString + "');")
            Dim con_valor As Integer
            If acuerdo.ToString.Length < 7 Then
                con_valor = 0
                Link.Attributes.Add("OnClick", "generaAcuerdo('" + acuerdoIDg.ToString + "','" + prioridadID.ToString + "','" + Request.QueryString("preacuerdo") + "');")
            Else
                con_valor = 1
                Link.Attributes.Add("onClick", "return mensaje('error', 'El ACUERDO ya fue generado'); return false;")
            End If
            edita_img.Attributes.Add("onClick", "return editaAcuerdo('" + acuerdoIDg.ToString + "','" + prioridadID.ToString + "','" + Request.QueryString("preacuerdo") + "'," + con_valor.ToString + ");")
        Next
    End Sub

    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        cbo_provincia1.Items.Clear()
        cbo_provincia1.DataBind()

        distritoCB.Items.Clear()
        distritoCB.DataBind()

    End Sub

    Protected Sub cbo_provincia1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_provincia1.SelectedIndexChanged
        distritoCB.Items.Clear()
        distritoCB.DataBind()

    End Sub

End Class