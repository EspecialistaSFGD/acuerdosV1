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

    Private Sub AregistroAcredita_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_SD_P_selectAutoridad.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_SD_P_selectEntidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_SD_P_selectAcreaditadosList.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")

        If Page.IsPostBack = False Then
            If Me.Request.QueryString("codsector") = 0 Then
                tipoCB.SelectedValue = 2
                tipocbSub()

                cbo_departamento1.SelectedValue = Me.Request.QueryString("de").ToString
                cbo_departamento1.DataBind()

                departamentoSub()

                'Dim ub As Integer = Right("00" & Request.QueryString("ubig"), 4)

                Dim ub As Integer = Left(Right("00" & Request.QueryString("ubig"), 6), 4) & "01"

                If ub > 0 Then
                    'cbo_provincia1.Items.Clear()
                    'cbo_provincia1.DataBind()
                    cbo_provincia1.SelectedValue = ub
                    cbo_provincia1.DataBind()

                End If
                tipoCB.Enabled = False
                cbo_departamento1.Enabled = False
                cbo_provincia1.Enabled = False
                entidadCB.Enabled = False
            Else
                tipoCB.SelectedValue = 1
                tipocbSub()
                tipoCB.Enabled = False
                grupoCB.SelectedValue = Request.QueryString("codsector")
                grupocbSub()
                grupoCB.Enabled = False
                entidadCB.SelectedValue = Request.QueryString("en")
                entidadCB.Enabled = False
                'hiddenField.Value = 0
            End If
            pedidoDT = SW_pedidos.SD_P_selectEventos(0, 1)
            ViewState("eventoID") = pedidoDT.Rows(0).Item(0)
            fechaAsiRDP.MinDate = pedidoDT.Rows(0).Item(6)
            fechaAsiRDP.MaxDate = pedidoDT.Rows(0).Item(7)
            titulo2LB.Text = "REGISTRO DE ACREDITADOS PARA EL " & pedidoDT.Rows(0).Item(1)
        End If
    End Sub


    Protected Sub dniTB_TextChanged(sender As Object, e As EventArgs) Handles dniTB.TextChanged
        If dniTB.Text.ToString.Trim.Length = 8 Then
            SW_asistenciaDT = SW_Asistencia.SD_P_selectAsistente(0, dniTB.Text.ToString.Trim)
            If SW_asistenciaDT.Rows.Count = 1 Then
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
            divProv.Visible = False
            divDis.Visible = False

        ElseIf tipoCB.SelectedValue = 2 Then
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

    Private Sub grupocbSub()
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub grupoCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grupoCB.SelectedIndexChanged
        grupocbSub()
    End Sub

    Private Sub departamentoSub()
        'hiddenField.Value = cbo_departamento1.SelectedValue
        cbo_provincia1.Items.Clear()
        cbo_provincia1.DataBind()
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        departamentoSub()
    End Sub

    Private Sub provinciaSub()
        'hiddenField.Value = cbo_provincia1.SelectedValue
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub

    Protected Sub cbo_provincia1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_provincia1.SelectedIndexChanged
        provinciaSub()
    End Sub


    Protected Sub autoridadCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoridadCB.SelectedIndexChanged
        plenariaCB.Enabled = True
        plenariaCB.SelectedValue = 0
        If autoridadCB.SelectedValue = 1 Then
            cargoTB.Text = "Ministro/a"
            cargoTB.Enabled = False
            plenariaCB.SelectedValue = 1
            plenariaCB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 2 Then
            cargoTB.Text = "Congresista"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 3 Then
            cargoTB.Text = "Viceministro/a"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 4 Then
            cargoTB.Text = "Alcalde(sa) Provincial"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 5 Then
            cargoTB.Text = "Alcalde(sa) Distrital"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 6 Then
            cargoTB.Text = "Sociedad Civil"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 7 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 8 Then
            cargoTB.Text = "Prensa"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 9 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 10 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 11 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 12 Then
            cargoTB.Text = "Gobernador(a) Regional"
            cargoTB.Enabled = False
            plenariaCB.SelectedValue = 1
            plenariaCB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 13 Then
            cargoTB.Text = ""
            cargoTB.Enabled = True
        ElseIf autoridadCB.SelectedValue = 14 Then
            cargoTB.Text = "Equipo Organizador"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 15 Then
            cargoTB.Text = "Apoyo Registro"
            cargoTB.Enabled = False
        ElseIf autoridadCB.SelectedValue = 13 Then
            cargoTB.Text = "Vicegobernador Regional"
            cargoTB.Enabled = False
        End If
    End Sub

    Protected Sub generarB_Click(sender As Object, e As EventArgs) Handles generarB.Click

        SW_pedidoDT = SW_pedidos.SD_P_selectValidaAcreditadoCant(Me.Request.QueryString("codevento").ToString, Me.Request.QueryString("en"))

        If SW_pedidoDT.Rows(0).Item(0) = SW_pedidoDT.Rows(0).Item(1) Then
            mensajeJSS(SW_pedidoDT.Rows(0).Item(1).ToString & " es la cantidad maxima de acreditados")
        Else
            If dniTB.Text.ToString.Trim.Length <> 8 Then
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

    End Sub

    Protected Sub fechaAsiRDP_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles fechaAsiRDP.SelectedDateChanged
        pedidoDT = SW_Asistencia.SD_P_selectDiaEventos(ViewState("eventoID"), fechaAsiRDP.SelectedDate.Value.ToString("dd/MM/yyyy"))
        If pedidoDT.Rows(0).Item(2) = 0 Then
            plenariaCB.SelectedValue = 0
            plenariaCB.DataBind()
            plenariaCB.Enabled = False
        Else
            plenariaCB.SelectedValue = 1
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