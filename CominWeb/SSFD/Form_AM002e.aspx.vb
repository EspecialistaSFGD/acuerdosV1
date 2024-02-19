Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading

Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient

Public Class Form_AM002e
    Inherits System.Web.UI.Page

    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA
    Dim sw_SSFD As New SW_SSFD_DA
    Dim ssfdDT As New DataTable

    Private Sub Form_AM001_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Request.QueryString("gjXtIkEroS").ToString = "eninbWFudWNjfsdDWqWSDFsdWWaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "SSFD_TransCS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectDistrito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectJerarquia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectNucleo.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectCatalogos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectTema.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectEje.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectComponente.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectGestionInv.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectCatalogosGIT.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectPrioridad.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectCatalogosNum.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectDivisionFuncional.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectGrupoFuncional.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectEstados.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub provinciaCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles provinciaCB.SelectedIndexChanged
        distritoCB.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        Session("usuarioID") = Request.QueryString("usrin").ToString

        If Request.QueryString("gjXtIkEroS").ToString = "eninbWFudWNjfsdDWqWSDFsdWWaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "SSFD_TransCS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If


        If Page.IsPostBack = False Then
            If Me.Request.QueryString("id").ToString > 0 Then
                ssfdDT = sw_SSFD.P_selectPCB(Request.QueryString("id"), "", "", "", "", "")
                provinciaCB.SelectedValue = CInt(Int(Mid(ssfdDT.Rows(0).Item(3).ToString, 3, 2)))
                provinciaCB.DataBind()
                distritoCB.SelectedValue = CInt(Int(Mid(ssfdDT.Rows(0).Item(3).ToString, 5, 2)))
                distritoCB.DataBind()
                jerarquiaCB.SelectedValue = ssfdDT.Rows(0).Item(4).ToString
                jerarquiaCB.DataBind()
                If ssfdDT.Rows(0).Item(5).ToString > 0 Then
                    jerarquiaProyCB.SelectedValue = ssfdDT.Rows(0).Item(5).ToString
                    jerarquiaProyCB.DataBind()
                End If

                nucleDinaCB.SelectedValue = ssfdDT.Rows(0).Item(6).ToString
                nucleDinaCB.DataBind()
                nroNucleoTB.Text = ssfdDT.Rows(0).Item(7).ToString
                tipoCB.SelectedValue = ssfdDT.Rows(0).Item(8).ToString
                tipoCB.DataBind()
                codUnicoLB.Text = ssfdDT.Rows(0).Item(9).ToString & "/" & ssfdDT.Rows(0).Item(10).ToString
                nivelGobiernoLB.Text = ssfdDT.Rows(0).Item(27).ToString
                unidadFormuladoraLB.Text = ssfdDT.Rows(0).Item(26).ToString
                nombreTB.Text = ssfdDT.Rows(0).Item(11).ToString
                divFuncionalCB.SelectedValue = ssfdDT.Rows(0).Item(14).ToString
                divFuncionalCB.DataBind()
                grupoFuncionalCB.SelectedValue = ssfdDT.Rows(0).Item(15).ToString
                grupoFuncionalCB.DataBind()
                estadosPiCB.SelectedValue = ssfdDT.Rows(0).Item(67).ToString
                estadosPiCB.DataBind()

                situacionTB.Text = ssfdDT.Rows(0).Item(65).ToString
                situacionProbTB.Text = ssfdDT.Rows(0).Item(66).ToString
                hito1TB.Text = ssfdDT.Rows(0).Item(68).ToString
                hito2TB.Text = ssfdDT.Rows(0).Item(69).ToString
                hito3TB.Text = ssfdDT.Rows(0).Item(70).ToString
                hito4TB.Text = ssfdDT.Rows(0).Item(71).ToString

                cincoCuencaCB.SelectedValue = ssfdDT.Rows(0).Item(31).ToString
                cincoCuencaCB.DataBind()
                cuatroCuencaCB.SelectedValue = ssfdDT.Rows(0).Item(32).ToString
                cuatroCuencaCB.DataBind()
                mansericheCB.SelectedValue = ssfdDT.Rows(0).Item(33).ToString
                mansericheCB.DataBind()
                moronaShaCB.SelectedValue = ssfdDT.Rows(0).Item(34).ToString
                moronaShaCB.DataBind()
                moronaCB.SelectedValue = ssfdDT.Rows(0).Item(35).ToString
                moronaCB.DataBind()
                urarinasCB.SelectedValue = ssfdDT.Rows(0).Item(36).ToString
                urarinasCB.DataBind()
                urarunasNaCB.SelectedValue = ssfdDT.Rows(0).Item(37).ToString
                urarunasNaCB.DataBind()
                CuarentaNuevePriorizadosCB.SelectedValue = ssfdDT.Rows(0).Item(38).ToString
                CuarentaNuevePriorizadosCB.DataBind()

                variosCB.SelectedValue = ssfdDT.Rows(0).Item(40).ToString
                variosCB.DataBind()
                ministeriosCB.SelectedValue = ssfdDT.Rows(0).Item(41).ToString
                ministeriosCB.DataBind()
                veredasCB.SelectedValue = ssfdDT.Rows(0).Item(42).ToString
                veredasCB.DataBind()
                embarcaderosCB.SelectedValue = ssfdDT.Rows(0).Item(43).ToString
                embarcaderosCB.DataBind()
                proyProductivoCB.SelectedValue = ssfdDT.Rows(0).Item(44).ToString
                proyProductivoCB.DataBind()
                'foncodesTotalCB.SelectedValue = ssfdDT.Rows(0).Item(67).ToString
                'foncodesTotalCB.DataBind()
                residenciasCB.SelectedValue = ssfdDT.Rows(0).Item(45).ToString
                residenciasCB.DataBind()
                'nucleoPnsrCB.SelectedValue = ssfdDT.Rows(0).Item(67).ToString
                'nucleoPnsrCB.DataBind()

            End If
        End If

    End Sub
    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "exeQform" Then
            Dim cad As String = ""

            'If FechaFinRDP.SelectedDate <= fechaInicioRDP.SelectedDate Then
            '    mensajeJSS("La fecha de vencimiento no puede ser menor a fecha de emision.")
            '    Exit Sub
            'Else


            cad = "Exec ssfd.P_crearUpdatePCB " & Request.QueryString("id").ToString & ",'" & Request.QueryString("ub").ToString & "'," &
                jerarquiaCB.SelectedValue.ToString & "," & jerarquiaProyCB.SelectedValue.ToString & "," & nucleDinaCB.SelectedValue.ToString &
                    ",'" & nroNucleoTB.Text.ToString & "'," & tipoCB.SelectedValue.ToString & ",'" & nombreTB.Text.ToString & "'," &
                    divFuncionalCB.SelectedValue.ToString & "," & grupoFuncionalCB.SelectedValue.ToString & "," & temaCB.SelectedValue.ToString & "," &
                    ejeCB.SelectedValue.ToString & "," & componenteCB.SelectedValue.ToString & "," & gestionInversionCB.SelectedValue.ToString & "," &
                    prioridadCB.SelectedValue.ToString & ", '', 0, " & cincoCuencaCB.SelectedValue.ToString & "," & cuatroCuencaCB.SelectedValue.ToString & "," &
                    mansericheCB.SelectedValue.ToString & "," & moronaShaCB.SelectedValue.ToString & "," & moronaCB.SelectedValue.ToString & "," &
                    urarinasCB.SelectedValue.ToString & "," & urarunasNaCB.SelectedValue.ToString & "," & variosCB.SelectedValue.ToString & "," &
                    ministeriosCB.SelectedValue.ToString & "," & veredasCB.SelectedValue.ToString & "," & embarcaderosCB.SelectedValue.ToString & "," &
                    proyProductivoCB.SelectedValue.ToString & "," & residenciasCB.SelectedValue.ToString & "," & nucleoPnsrCB.SelectedValue.ToString &
                    ", 0, '', '', 0,'" & hito1TB.Text.ToString.ToUpper & "','" & hito2TB.Text.ToString.ToUpper & "','" & hito3TB.Text.ToString.ToUpper &
                    "','" & hito4TB.Text.ToString.ToUpper & "'," & Request.QueryString("h1").ToString & "," & Request.QueryString("h2").ToString &
                    "," & Request.QueryString("h3").ToString & "," & Request.QueryString("h4").ToString & "," & Request.QueryString("usrin").ToString &
                    ",'" & situacionTB.Text.ToString.ToUpper & "'," & Request.QueryString("s").ToString & ",'" & situacionProbTB.Text.ToString.ToUpper & "'," &
                    Request.QueryString("sp").ToString

            If cad.Length > 0 Then
                Try
                    Me.sw_ejecutaSQL.querySQL(cad)
                    cierraVentana()
                Catch ex As Exception
                End Try
            End If
            'End If
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

End Class