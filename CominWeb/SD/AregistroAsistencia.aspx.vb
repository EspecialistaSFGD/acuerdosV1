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
Imports System.Windows.Forms

Public Class AregistroAsistencia
    Inherits System.Web.UI.Page

    Dim SW_asistenciaDT, pedidoDT, validaAcreditaDT, sw_asistente_DT, SW_pedidosDT As New DataTable
    Dim SW_Asistencia As New SW_SD_asistente_DA
    Dim SW_pedidos As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub AregistroAcredita_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"

            SW_pedidosDT = SW_pedidos.SD_P_selectParametroByID(5, 1)
            If SW_pedidosDT.Rows(0).Item(2) <> Me.Request.QueryString("key").ToString Then
                variableGlobalConexion.nombreCadenaCnx = ""
                Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
            End If
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_SD_P_selectAutoridad.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_SD_P_selectEntidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_SD_P_selectAsistenciaResumen.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectDistrito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")

        If Page.IsPostBack = False Then
            'If Me.Request.QueryString("codsector") = 0 Then
            '    tipoCB.SelectedValue = 2
            '    tipocbSub()

            '    cbo_departamento1.SelectedValue = Me.Request.QueryString("de").ToString
            '    cbo_departamento1.DataBind()

            '    departamentoSub()

            '    Dim ub As Integer = Right("00" & Request.QueryString("ubig"), 4)
            '    If ub > 0 Then
            '        cbo_provincia1.Items.Clear()
            '        cbo_provincia1.DataBind()
            '        cbo_provincia1.SelectedValue = Me.Request.QueryString("ubig").ToString
            '        cbo_provincia1.DataBind()
            '    End If
            '    'tipoCB.Enabled = False
            '    'cbo_departamento1.Enabled = False
            '    'cbo_provincia1.Enabled = False
            '    'entidadCB.Enabled = False
            'Else
            '    tipoCB.SelectedValue = 1
            '    tipocbSub()
            '    'tipoCB.Enabled = False
            '    grupoCB.SelectedValue = Request.QueryString("codsector")
            '    grupocbSub()
            '    'grupoCB.Enabled = False
            '    entidadCB.SelectedValue = Request.QueryString("en")
            '    'entidadCB.Enabled = False
            'End If
            'divTip.Visible = False
            'divSec.Visible = False
            'divDep.Visible = False
            'divProv.Visible = False
            'divDis.Visible = False
            'divEnti.Visible = False
            cargaIni(0)
            pedidoDT = SW_pedidos.SD_P_selectEventos(0, 1)
            ViewState("eventoID") = pedidoDT.Rows(0).Item(0)
            eveH.Value = pedidoDT.Rows(0).Item(0)
            titulo2LB.Text = "REGISTRO DE ASISTENCIA PARA EL " & pedidoDT.Rows(0).Item(1)
        End If
    End Sub


    Protected Sub dniTB_TextChanged(sender As Object, e As EventArgs) Handles dniTB.TextChanged
        If dniTB.Text.ToString.Trim.Length = 8 Then
            SW_asistenciaDT = SW_Asistencia.SD_P_selectAcreaditadosList(0, "", ViewState("eventoID"), 0, dniTB.Text.ToString.Trim, Date.Now.ToString("dd/MM/yyyy"))

            If SW_asistenciaDT.Rows.Count > 0 Then
                ViewState("asistenciaID") = SW_asistenciaDT.Rows(0).Item(0)
                tipoCB.SelectedValue = SW_asistenciaDT.Rows(0).Item(17)
                tipocbSub(SW_asistenciaDT.Rows(0).Item(17))
                If SW_asistenciaDT.Rows(0).Item(17) = 2 Then

                    cbo_departamento1.Items.Clear()
                    cbo_departamento1.DataBind()
                    cbo_departamento1.SelectedValue = CInt(Left(SW_asistenciaDT.Rows(0).Item(21), 2))
                    cbo_departamento1.DataBind()

                    departamentoSub()

                    Dim ub As Integer = Right("00" & SW_asistenciaDT.Rows(0).Item(21), 4)
                    If ub > 0 Then
                        cbo_provincia1.Items.Clear()
                        cbo_provincia1.DataBind()
                        cbo_provincia1.SelectedValue = CInt(Left(SW_asistenciaDT.Rows(0).Item(21), 4) + "01")
                        cbo_provincia1.DataBind()

                        cbo_distrito.Items.Clear()
                        cbo_distrito.DataBind()
                        cbo_distrito.SelectedValue = CInt(SW_asistenciaDT.Rows(0).Item(21))
                        cbo_distrito.DataBind()
                    Else
                        cbo_provincia1.Enabled = False
                        cbo_distrito.Enabled = False
                    End If
                    ubiH.Value = SW_asistenciaDT.Rows(0).Item(21)
                    secH.Value = 0
                Else
                    ubiH.Value = 0
                    secH.Value = SW_asistenciaDT.Rows(0).Item(18)
                    grupoCB.SelectedValue = SW_asistenciaDT.Rows(0).Item(18)
                    grupocbSub()
                End If

                nombreTB.Text = SW_asistenciaDT.Rows(0).Item(19)
                apellidosTB.Text = SW_asistenciaDT.Rows(0).Item(20)
                telefonoTB.Text = SW_asistenciaDT.Rows(0).Item(14)
                correoTB.Text = SW_asistenciaDT.Rows(0).Item(15)
                cargoTB.Text = SW_asistenciaDT.Rows(0).Item(11)

                autoridadCB.Items.Clear()
                autoridadCB.DataBind()
                autoridadCB.SelectedValue = SW_asistenciaDT.Rows(0).Item(4)
                autoridad(SW_asistenciaDT.Rows(0).Item(4))
                entidadCB.Items.Clear()
                entidadCB.DataBind()
                entidadCB.SelectedValue = SW_asistenciaDT.Rows(0).Item(3)

            Else
                ViewState("asistenciaID") = 0
                sw_asistente_DT = SW_Asistencia.SD_P_selectAsistente(0, dniTB.Text.ToString.Trim)
                If sw_asistente_DT.Rows.Count > 0 Then
                    nombreTB.Text = sw_asistente_DT.Rows(0).Item(4)
                    apellidosTB.Text = sw_asistente_DT.Rows(0).Item(3)
                    telefonoTB.Text = sw_asistente_DT.Rows(0).Item(5)
                    correoTB.Focus()
                Else
                    nombreTB.Text = ""
                    apellidosTB.Text = ""
                    correoTB.Text = ""
                    cargoTB.Text = ""
                    telefonoTB.Text = ""
                    nombreTB.Focus()
                End If

                tipoCB.SelectedValue = 0
                tipocbSub(0)

            End If
        End If

    End Sub


    Private Sub cargaIni(ByVal id As Integer)
        If id = 1 Then
            'grupoCB.Enabled = True
            'cbo_departamento1.Enabled = False
            'cbo_provincia1.Enabled = False
            divSec.Visible = True
            divDep.Visible = False
            divProv.Visible = False
            divDis.Visible = False

        ElseIf id = 2 Then
            'grupoCB.Enabled = False
            'cbo_departamento1.Enabled = True
            'cbo_provincia1.Enabled = True
            divSec.Visible = False
            divDep.Visible = True
            divProv.Visible = True
            divDis.Visible = True
        Else
            divSec.Visible = False
            divDep.Visible = False
            divProv.Visible = False
            divDis.Visible = False
        End If
    End Sub

    Private Sub tipocbSub(ByVal id As Integer)
        cargaIni(id)
        'If id = 2 Then
        '    cbo_departamento1.Items.Clear()
        '    cbo_departamento1.DataBind()
        'ElseIf id = 1 Then
        '    grupoCB.Items.Clear()
        '    grupoCB.DataBind()
        'ElseIf id = 0 Then
        cbo_departamento1.Items.Clear()
        cbo_departamento1.DataBind()
        cbo_departamento1.SelectedValue = 0

        grupoCB.Items.Clear()
        grupoCB.DataBind()
        grupoCB.SelectedValue = 0

        entidadCB.Items.Clear()
        entidadCB.DataBind()
        entidadCB.SelectedValue = 0

        autoridadCB.Items.Clear()
        autoridadCB.DataBind()
        autoridadCB.SelectedValue = 0
        'End If

    End Sub

    Protected Sub tipoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tipoCB.SelectedIndexChanged
        tipocbSub(tipoCB.SelectedValue)
    End Sub

    Private Sub grupocbSub()
        secH.Value = grupoCB.SelectedValue
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub grupoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grupoCB.SelectedIndexChanged
        grupocbSub()
    End Sub

    Private Sub departamentoSub()
        ubiH.Value = cbo_departamento1.SelectedValue
        cbo_provincia1.Items.Clear()
        cbo_provincia1.DataBind()
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        departamentoSub()
    End Sub

    Private Sub provinciaSub()
        If cbo_provincia1.SelectedValue = 0 Then
            ubiH.Value = cbo_departamento1.SelectedValue
        Else
            ubiH.Value = cbo_provincia1.SelectedValue
        End If

        cbo_distrito.Items.Clear()
        cbo_distrito.DataBind()
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub cbo_provincia1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_provincia1.SelectedIndexChanged
        provinciaSub()
    End Sub

    Protected Sub cbo_distrito_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_distrito.SelectedIndexChanged
        If cbo_distrito.SelectedValue = 0 Then
            ubiH.Value = cbo_provincia1.SelectedValue
        Else
            ubiH.Value = cbo_distrito.SelectedValue
        End If

        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Private Sub autoridad(ByVal id As Integer)
        If id = 1 Then
            cargoTB.Text = "Ministro/a"
            cargoTB.Enabled = False
        ElseIf id = 2 Then
            cargoTB.Text = "Congresista"
            cargoTB.Enabled = False
        ElseIf id = 3 Then
            cargoTB.Text = "Viceministro/a"
            cargoTB.Enabled = False
        ElseIf id = 4 Then
            cargoTB.Text = "Alcalde(sa) Provincial"
            cargoTB.Enabled = False
        ElseIf id = 5 Then
            cargoTB.Text = "Alcalde(sa) Distrital"
            cargoTB.Enabled = False
        ElseIf id = 6 Then
            cargoTB.Text = "Sociedad Civil"
            cargoTB.Enabled = False
        ElseIf id = 7 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf id = 8 Then
            cargoTB.Text = "Prensa"
            cargoTB.Enabled = False
        ElseIf id = 9 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf id = 10 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf id = 11 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf id = 12 Then
            cargoTB.Text = "Gobernador(a) Regional"
            cargoTB.Enabled = False
        ElseIf id = 13 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf id = 14 Then
            cargoTB.Text = "Equipo Organizador"
            cargoTB.Enabled = False
        ElseIf id = 15 Then
            cargoTB.Text = "Apoyo Registro"
            cargoTB.Enabled = False
        ElseIf id = 13 Then
            cargoTB.Text = "Vicegobernador Regional"
            cargoTB.Enabled = False
        Else
            cargoTB.Text = ""
            cargoTB.Enabled = True
        End If
    End Sub

    Protected Sub autoridadCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoridadCB.SelectedIndexChanged
        autoridad(autoridadCB.SelectedValue)
    End Sub

    Protected Sub generarB_Click(sender As Object, e As EventArgs) Handles generarB.Click
        'validaAcreditaDT = SW_Asistencia.SD_P_selectAcreaditadosList(0, "", ViewState("eventoID").ToString, 0, dniTB.Text.ToString.Trim)
        If dniTB.Text.ToString.Length <> 8 Then
            mensajeJSS("Ingrese DNI válido")
        ElseIf nombreTB.Text.ToString.Trim.ToString.Length < 2 Then
            mensajeJSS("Ingrese Nombre(s) válido")
        ElseIf apellidosTB.Text.ToString.Trim.ToString.Length < 4 Then
            mensajeJSS("Ingrese Apellidos válidos")
        ElseIf telefonoTB.Text.ToString.Trim.ToString.Length < 6 Then
            mensajeJSS("Ingrese Nro. de Teléfono válido")
        ElseIf entidadCB.SelectedValue = 0 Then
            mensajeJSS("Seleccione Entidad")
        Else

            Dim cad As String = ""
            cad = " EXEC SD_P_crearUpdateAsistencias " & ViewState("asistenciaID") & ", '" & dniTB.Text.ToString.Trim & "'" _
            & ", '" & nombreTB.Text.ToString.Trim & "'" _
            & ", '" & apellidosTB.Text.ToString.Trim & "'" _
            & ", '" & telefonoTB.Text.ToString.Trim & "'" _
            & ", '" & correoTB.Text.ToString.Trim & "'" _
            & ", " & entidadCB.SelectedValue & ", " & autoridadCB.SelectedValue & ", '" & cargoTB.Text.ToString.Trim & "', " _
            & ViewState("eventoID").ToString & ", " & Me.Request.QueryString("iacp")

            If cad.Length > 0 Then
                Try
                    Me.sw_ejecutaSQL.querySQL(cad)
                    RadGrid1.Rebind()
                    dniTB.Text = ""
                    nombreTB.Text = ""
                    apellidosTB.Text = ""
                    telefonoTB.Text = ""
                    correoTB.Text = ""
                    cargoTB.Text = ""
                    'cargaIni(0)
                    dniTB.Focus()
                    tipocbSub(3)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    'Private Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
    '    For Each item As GridDataItem In RadGrid1.Items
    '        Dim asistenciaId As Integer = item("asistenciaId").Text
    '        Dim eliminaAcreditado As ImageButton = item.FindControl("eliminaAcreditado")
    '        Dim edita_img As ImageButton = item.FindControl("edita")

    '        eliminaAcreditado.Attributes.Add("onClick", "return delAcredita('" + asistenciaId.ToString + "');")
    '        edita_img.Attributes.Add("onClick", "return EditAcredita('" + asistenciaId.ToString + "');")

    '    Next
    'End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "actualiza" Then
        Else

            Dim i As Integer
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

            If param = "eliminaA" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblAsistencias set estado = 0 where asistenciaId = " & indicador

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

    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub

End Class