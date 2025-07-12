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

Public Class AregistroAcredita
    Inherits System.Web.UI.Page

    Dim SW_asistenciaDT, pedidoDT, validaAcreditaDT, SW_pedidoDT As New DataTable
    Dim SW_Asistencia As New SW_SD_asistente_DA
    Dim SW_pedidos As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA
    Dim ub1 As Integer
    Dim ub As Integer
    Dim ubd As Integer
    Private Sub AregistroAcredita_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectAutoridad.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectEntidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectAcreaditadosList.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDistrito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
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
            If Me.Request.QueryString("codsector") = 0 Then
                tipoCB.SelectedValue = 2
                tipocbSub()

                cbo_departamento1.SelectedValue = CInt(Right("00" & Me.Request.QueryString("de").ToString, 2))
                cbo_departamento1.DataBind()




                If Request.QueryString("ubig").ToString.Length < 5 Then
                    ub1 = Right("00" & Request.QueryString("ubig"), 4)

                    ub = Left(Right("00" & Request.QueryString("ubig"), 6), 4) & "01"
                    ubd = Left(Right("00" & Request.QueryString("ubig"), 6), 4) & "01"
                Else
                    If Request.QueryString("ubig").ToString.Length = 6 Then
                        If Right("00" & Request.QueryString("ubig"), 4) = "0000" Then
                            ub1 = Right("00" & Request.QueryString("ubig"), 4)

                            ub = Left(Right("00" & Request.QueryString("ubig"), 6), 4) & "01"
                            ubd = Left(Right("00" & Request.QueryString("ubig"), 6), 4) & "01"
                        Else
                            ub1 = Request.QueryString("ubig")
                            ub = Left(Right("00" & Request.QueryString("ubig"), 6), 4) & "01"
                            ubd = Request.QueryString("ubig")
                        End If
                    End If

                End If

                If ub1 > 100 And ub1 < 10000 Then
                    cbo_provincia1.SelectedValue = 0
                    cbo_provincia1.DataBind()
                    distritoCB.SelectedValue = 0
                    distritoCB.DataBind()
                    departamentoSub()
                ElseIf ub1 > 9999 Then
                    'cbo_provincia1.Items.Clear()
                    'cbo_provincia1.DataBind()
                    cbo_provincia1.SelectedValue = ub
                    cbo_provincia1.DataBind()
                    provinciaSub()

                    distritoCB.SelectedValue = ubd
                    distritoCB.DataBind()
                    distritoSub()

                End If

                departamentoSub()

            Else
                tipoCB.SelectedValue = 1
                tipocbSub()
                grupoCB.SelectedValue = Request.QueryString("codsector")
                grupocbSub()

                entidadCB.SelectedValue = Request.QueryString("en")

            End If

            'titulo2LB.Text = "REGISTRO DE ACREDITADOS PARA EL " & pedidoDT.Rows(0).Item(1)


            If Request.QueryString("sup") <> 2 Then
                tipoCB.Enabled = False
                cbo_departamento1.Enabled = False
                cbo_provincia1.Enabled = False
                distritoCB.Enabled = False
                grupoCB.Enabled = False
                entidadCB.Enabled = False
            End If

        End If
    End Sub


    Protected Sub dniTB_TextChanged(sender As Object, e As EventArgs) Handles dniTB.TextChanged
        If dniTB.Text.ToString.Trim.Length = 8 Then
            SW_asistenciaDT = SW_Asistencia.SD_P_selectAsistente(0, dniTB.Text.ToString.Trim)
            If SW_asistenciaDT.Rows.Count > 0 Then
                nombreTB.Text = SW_asistenciaDT.Rows(0).Item(4)
                apellidosTB.Text = SW_asistenciaDT.Rows(0).Item(3)
                telefonoTB.Text = SW_asistenciaDT.Rows(0).Item(5)
                grupoCB.Focus()
            Else
                nombreTB.Text = ""
                apellidosTB.Text = ""
                telefonoTB.Text = ""
                nombreTB.Focus()
            End If
        End If
    End Sub


    Private Sub cargaIni()
        If tipoCB.SelectedValue = 1 Then
            'grupoCB.Enabled = True
            'cbo_departamento1.Enabled = False
            'cbo_provincia1.Enabled = False
            divSec.Visible = True
            divDep.Visible = False
            divDis.Visible = False

        ElseIf tipoCB.SelectedValue = 2 Then
            'grupoCB.Enabled = False
            'cbo_departamento1.Enabled = True
            'cbo_provincia1.Enabled = True
            divSec.Visible = False
            divDep.Visible = True
            divDis.Visible = True
        Else
            divSec.Visible = False
            divDep.Visible = False
            divDis.Visible = False
        End If
    End Sub

    Private Sub tipocbSub()
        cargaIni()
        cbo_departamento1.Items.Clear()
        cbo_departamento1.DataBind()
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub tipoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tipoCB.SelectedIndexChanged
        tipocbSub()
    End Sub

    Protected Sub cbo_evento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_evento.SelectedIndexChanged
        pedidoDT = SW_pedidos.SD_P_selectEventos(cbo_evento.SelectedValue, 1)
        ViewState("eventoID") = pedidoDT.Rows(0).Item(0)
        fechaAsiRDP.MinDate = pedidoDT.Rows(0).Item(6)
        fechaAsiRDP.MaxDate = pedidoDT.Rows(0).Item(7)
        RadGrid1.Rebind()
    End Sub

    Private Sub grupocbSub()
        hiddenFieldUbigeo.Value = 0
        hiddenFieldSector.Value = Request.QueryString("codsector")
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub grupoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grupoCB.SelectedIndexChanged
        grupocbSub()
    End Sub

    Private Sub departamentoSub()



        If ub1 > 9999 Then
            hiddenFieldUbigeo.Value = ub1
        Else
            hiddenFieldUbigeo.Value = cbo_departamento1.SelectedValue
            cbo_provincia1.Items.Clear()
            cbo_provincia1.DataBind()
        End If

        hiddenFieldSector.Value = 0


        entidadCB.Items.Clear()
        If Request.QueryString("en") <> 3402 Then
            entidadCB.SelectedValue = Request.QueryString("en")
        End If
        entidadCB.DataBind()
        RadGrid1.Rebind()
    End Sub

    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        departamentoSub()

    End Sub

    Private Sub provinciaSub()
        hiddenFieldUbigeo.Value = cbo_provincia1.SelectedValue
        hiddenFieldSector.Value = 0
        entidadCB.Items.Clear()
        entidadCB.DataBind()
        RadGrid1.Rebind()
    End Sub

    Private Sub distritoSub()
        hiddenFieldUbigeo.Value = distritoCB.SelectedValue
        hiddenFieldSector.Value = 0
        entidadCB.Items.Clear()
        entidadCB.DataBind()
        RadGrid1.Rebind()
    End Sub

    Protected Sub cbo_provincia1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_provincia1.SelectedIndexChanged
        provinciaSub()
    End Sub


    Protected Sub distritoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles distritoCB.SelectedIndexChanged
        distritoSub()
    End Sub



    Protected Sub autoridadCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoridadCB.SelectedIndexChanged
        plenariaCB.Enabled = True
        plenariaCB.SelectedValue = 0
        If autoridadCB.SelectedValue = 1 Then
            cargoTB.Text = "MINISTRO/A"
            cargoTB.Enabled = False
            plenariaCB.SelectedValue = 1
            plenariaCB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 2 Then
            cargoTB.Text = "CONGRESISTA"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 3 Then
            cargoTB.Text = "VICEMINISTRO/A"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 4 Then
            cargoTB.Text = "ALCALDE(SA) PROVINCIAL"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 5 Then
            cargoTB.Text = "ALCALDE(SA) DISTRITAL"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 6 Then
            cargoTB.Text = "SOCIEDAD CIVIL"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 7 Then
            cargoTB.Text = "ESPECIALISTA"
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 8 Then
            cargoTB.Text = "PRENSA"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 9 Then
            cargoTB.Text = "OTROS"
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 10 Then
            cargoTB.Text = "ESPECIALISTA"
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 11 Then
            cargoTB.Text = "ESPECIALISTA"
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 12 Then
            cargoTB.Text = "GOBERNADOR(A) REGIONAL"
            cargoTB.Enabled = False
            plenariaCB.SelectedValue = 1
            plenariaCB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 13 Then
            cargoTB.Text = "ESPECIALISTA"
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 14 Then
            cargoTB.Text = "EQUIPO ORGANIZADOR"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 15 Then
            cargoTB.Text = "APOYO REGISTRO"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 13 Then
            cargoTB.Text = "VICEGOBERNADOR(A) REGIONAL"
            cargoTB.Enabled = False
        End If
    End Sub

    Protected Sub generarB_Click(sender As Object, e As EventArgs) Handles generarB.Click
        If cbo_evento.SelectedValue = 0 Then
            mensajeJSS("Seleccione Espacio")
        ElseIf fechaAsiRDP.IsEmpty = True Then
            mensajeJSS("Seleccione Fecha")
        Else
            SW_pedidoDT = SW_pedidos.SD_P_selectValidaAcreditadoCant(ViewState("eventoID").ToString, entidadCB.SelectedValue, 3, fechaAsiRDP.SelectedDate.Value.ToString("dd/MM/yyyy"))

            If SW_pedidoDT.Rows(0).Item(0) = SW_pedidoDT.Rows(0).Item(1) Then
                'Dim total As Integer
                'total = SW_pedidoDT.Rows(0).Item(1) - SW_pedidoDT.Rows(0).Item(2)
                mensajeJSS(SW_pedidoDT.Rows(0).Item(1).ToString & " es la cantidad maxima de acreditados para el día " & fechaAsiRDP.SelectedDate.Value.ToString("dd/MM/yyyy") & ".")
            Else

                If autoridadCB.SelectedValue = 0 Then
                    mensajeJSS("Seleccione grupo")
                ElseIf dniTB.Text.ToString.Trim.Length <> 8 Then
                    mensajeJSS("Ingrese DNI válido")
                Else

                    If telefonoTB.Text.ToString.Trim.Length < 7 Then
                        mensajeJSS("Ingrese Nro. de teléfono")
                    ElseIf nombreTB.Text.ToString.Trim.Length < 4 Then
                        mensajeJSS("Ingrese Nombres")
                    ElseIf apellidosTB.Text.ToString.Trim.Length < 4 Then
                        mensajeJSS("Ingrese Apellidos")
                    Else
                        validaAcreditaDT = SW_Asistencia.SD_P_selectAcreaditadosList(0, "", ViewState("eventoID").ToString, 0, dniTB.Text.ToString.Trim, fechaAsiRDP.SelectedDate.Value.ToString("dd/MM/yyyy"))
                        If validaAcreditaDT.Rows.Count >= 1 Then
                            mensajeJSS("El DNI ingresado ya fue acreditado")
                        Else
                            Dim cad As String = ""
                            cad = " EXEC SD_P_crearUpdateAcreditado 0, 11, '" & dniTB.Text.ToString.Trim & "', '" & apellidosTB.Text.ToString.Trim & "', '" & nombreTB.Text.ToString.Trim &
                            "', '" & cargoTB.Text.ToString.Trim & "', '" & ViewState("eventoID").ToString & "', '" & telefonoTB.Text.ToString.Trim & "', '" & correoTB.Text.ToString.Trim &
                            "'," & autoridadCB.SelectedValue & ", " & entidadCB.SelectedValue & ", " & plenariaCB.SelectedValue & ", '" & fechaAsiRDP.SelectedDate.Value.ToString("dd/MM/yyyy") & "'"

                            If cad.Length > 0 Then
                                Try
                                    Me.sw_ejecutaSQL.querySQL(cad)
                                    Me.RadGrid1.Rebind()
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                    End If

                End If
            End If
        End If



    End Sub

    Protected Sub fechaAsiRDP_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles fechaAsiRDP.SelectedDateChanged
        pedidoDT = SW_Asistencia.SD_P_selectDiaEventos(ViewState("eventoID"), fechaAsiRDP.SelectedDate.Value.ToString("dd/MM/yyyy"))
        If pedidoDT.Rows(0).Item(2) = 0 Then
            plenariaCB.SelectedValue = 0
            plenariaCB.DataBind()
            plenariaCB.Enabled = False
        Else
            plenariaCB.SelectedValue = 0
            plenariaCB.DataBind()
            plenariaCB.Enabled = True
        End If
    End Sub

    Private Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        For Each item As GridDataItem In RadGrid1.Items
            Dim asistenciaId As Integer = item("asistenciaId").Text
            Dim eliminaAcreditado As ImageButton = item.FindControl("eliminaAcreditado")
            Dim edita_img As ImageButton = item.FindControl("edita")

            eliminaAcreditado.Attributes.Add("onClick", "return delAcredita('" + asistenciaId.ToString + "');")
            edita_img.Attributes.Add("onClick", "return EditAcredita('" + asistenciaId.ToString + "');")

        Next
    End Sub

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