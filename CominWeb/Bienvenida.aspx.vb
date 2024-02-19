Imports CominWeb.SW_coneccionDB
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading

Partial Class Bienvenida
    Inherits System.Web.UI.Page
    Dim sw_usuarioC As New SW_usuarios_DA
    Dim SW_EjecutaSQLDA As New SW_EjecutaSQL_DA
    Dim SW_GraficoDA As New SW_Graficos_DA
    Dim sw_usuarioDT As New DataTable, SW_EjecutaSQLDT As New DataTable, sw_igvDT As New DataTable
    Dim GraphaDemo, GraphaCobrar, GraphaPagar As New DataTable
    Dim indicaDT As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("EmpresaPrincipalWEB") = Me.Request.QueryString("gjXtIkEroS")

        Dim cadena As String
        cadena = Session("EmpresaPrincipalWEB").ToString
        If Session("EmpresaPrincipalWEB") = "COMINSAC" Then
            variableGlobalConexion.nombreCadenaCnx = "CONTRATA_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "eninAumsmyZ4/DsJU7tVSWSW6w=" Then
            variableGlobalConexion.nombreCadenaCnx = "VETERINARIA_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "eninWe1n/TkAuMHCTTWbMBlgg==" Then
            variableGlobalConexion.nombreCadenaCnx = "LIBRERIA_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "enin2hKuuS1kJ/AY7L02e2c1wg==" Then
            variableGlobalConexion.nombreCadenaCnx = "PROFAKTO_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "eninU4WBTrij5CnvCJ/LpawgZg==" Then
            variableGlobalConexion.nombreCadenaCnx = "SAUL_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "enin5QmN8eDxfBmy8giI9q16F8sdBsbLtoxzmfbIcldXZMI=" Then
            variableGlobalConexion.nombreCadenaCnx = "PAPELES_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "eninXaZ2ov79qPNmwXYioAh5JnrqP2//" Then
            variableGlobalConexion.nombreCadenaCnx = "CONTABILIDADConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "enin4DYeb/GNm5Xn9cCcztgEiA==" Then
            variableGlobalConexion.nombreCadenaCnx = "PLAYSTATION_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "enincmVtc2FwZXJ1==" Then
            variableGlobalConexion.nombreCadenaCnx = "REMSAPERU_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "eninY2xvdmVybXVsdGlz2a==" Then
            variableGlobalConexion.nombreCadenaCnx = "CLOVERMULTI_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "enindmVkaXNhZw==" Then
            variableGlobalConexion.nombreCadenaCnx = "VEDISAG_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "eninbWFudWNjaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "MANUCCI_DATOSConnectionString"
        ElseIf Session("EmpresaPrincipalWEB") = "eninbmV3cmVzdA==" Then
            variableGlobalConexion.nombreCadenaCnx = "NEWREST_CS"
        ElseIf Session("EmpresaPrincipalWEB") = "enincsssfdmVzdA==" Then
            variableGlobalConexion.nombreCadenaCnx = "SSFD_CS"
        ElseIf Session("EmpresaPrincipalWEB") = "eninY2FzYWdyYW5kZQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "CASAGRANDE_CS"
        ElseIf Session("EmpresaPrincipalWEB") = "eninPY2FEzzPYE==" Then
            variableGlobalConexion.nombreCadenaCnx = "PYE_CS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If

        SDS_selectSucursales.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectPuntoVenta.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectUsuario.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        If Page.IsPostBack = False Then
            ViewState("anioDashSess") = Date.Now.Year
            ViewState("anioDashCount") = 1
            Session("filtroPRoducto") = "perno"
            Session("nombrePrincipalEmpresa") = ""
            Session("direccionPrincipalEmpresa") = ""
            Session("RUCPrincipalEmpresa") = ""

            SW_EjecutaSQLDT = SW_EjecutaSQLDA.P_selectParametros(0, 666)
            sw_igvDT = SW_EjecutaSQLDA.P_selectIGV(0)
            If SW_EjecutaSQLDT.Rows.Count > 0 Then
                Me.titulo1LB.Text = SW_EjecutaSQLDT.Rows(0).Item(4).ToString
                Me.titulo2LB.Text = SW_EjecutaSQLDT.Rows(0).Item(4).ToString
                Me.subTitulo1LB.Text = SW_EjecutaSQLDT.Rows(1).Item(4).ToString
                Me.subTitulo2LB.Text = SW_EjecutaSQLDT.Rows(2).Item(4).ToString
                Me.contenidoSubTitulo1LB.Text = SW_EjecutaSQLDT.Rows(3).Item(4).ToString
                Me.contenidoSubTitulo2LB.Text = SW_EjecutaSQLDT.Rows(4).Item(4).ToString
                Session("nombrePrincipalEmpresa") = SW_EjecutaSQLDT.Rows(0).Item(4).ToString
                Session("direccionPrincipalEmpresa") = SW_EjecutaSQLDT.Rows(5).Item(4).ToString
                Session("RUCPrincipalEmpresa") = SW_EjecutaSQLDT.Rows(6).Item(4).ToString
                Session("IGVPrincipalEmpresa") = sw_igvDT.Rows(0).Item(1)
                Session("evidenciaAppRD") = SW_EjecutaSQLDT.Rows(63).Item(3)

                imagenPresentacionIMG.Src = "http://162.248.52.148/REFERENCIASBASE/Resources/" + SW_EjecutaSQLDT.Rows(7).Item(4).ToString.Trim
            End If

            If Session("usuarioLoginID") IsNot Nothing Then
                Me.loginNuevoDiv.Visible = False
                If Session("verDashBoardByUsuarioID") = 1 Then
                    Me.tabla_loginDiv.Visible = True
                    Me.divDeskAlternativo.Visible = False
                Else
                    Me.tabla_loginDiv.Visible = False
                    Me.divDeskAlternativo.Visible = True
                End If

                '***************************************************************
                ' SE COMENTA PARA MANNUCCI, SE DESCOMENTA PARA OTROA CLIENTES
                'SDS_P_selectMoneda.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                'SDS_P_selectAnioGraph.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                'monedaNewCB.DataBind()
                'anioNewCB.DataBind()
                '***************************************************************
                ' I -- INDICADORES
                indicaDT = SW_GraficoDA.P_ReportEstadoOT("01/01/2000", "01/01/2000", 1)
                '***************************************************************
                ' SE COMENTA PARA OTROA CLIENTES, SE DESCOMENTA PARA MANNUCCI
                otAbiertaLB.Text = indicaDT.Rows(0).Item(1).ToString
                otAbierta_SecLB.Text = Math.Round((indicaDT.Rows(0).Item(1) / indicaDT.Rows(0).Item(2)) * 100, 2).ToString
                '***************************************************************
                ' SE COMENTA PARA MANNUCCI, SE DESCOMENTA PARA OTROA CLIENTES
                'PintarGrafico(monedaNewCB.SelectedValue, ViewState("anioDashSess"), ViewState("anioDashCount"))
                '***************************************************************
            Else
                Me.tabla_loginDiv.Visible = False
                Me.divDeskAlternativo.Visible = False
                Me.loginNuevoDiv.Visible = True
            End If

        End If
    End Sub
    Private Sub PintarGrafico(monedaId, anio, filas)
        'Me.anio1LB.Text = anio
        'Me.anio2LB.Text = anio
        'Me.anio3LB.Text = anio
        GraphaDemo = SW_GraficoDA.P_selectGraficoFacturados(Session("IDSucursalPrincipal"), monedaId, anio)
        GraphaCobrar = SW_GraficoDA.P_selectGraficoCobrar(Session("IDSucursalPrincipal"), monedaId, anio)
        GraphaPagar = SW_GraficoDA.P_selectGraficoPagar(Session("IDSucursalPrincipal"), monedaId, anio)

        indicaDT = SW_GraficoDA.P_ReportEstadoOT("01/01/2000", "01/01/2000", 2)
        Dim canvas, canvas1, canvas2 As String
        canvas = "<script type='text/javascript'> " &
                    " $(document).ready(function () { " &
                        "var datos = {" &
                            "labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Setiembre', 'Octubre', 'Noviembre', 'Diciembre']," &
                            "datasets: ["
        canvas1 = ""
        For index As Integer = 0 To filas - 1

            canvas1 = canvas1 & "{" &
                            "label: '" & GraphaDemo.Rows(index).Item(0).ToString & "'," &
                            "backgroundColor: 'rgba(" & GraphaDemo.Rows(index).Item(13).ToString & ")'," &
                            "data: [" & GraphaDemo.Rows(index).Item(1).ToString & "," & GraphaDemo.Rows(index).Item(2).ToString & "," & GraphaDemo.Rows(index).Item(3).ToString & "," & GraphaDemo.Rows(index).Item(4).ToString & "," & GraphaDemo.Rows(index).Item(5).ToString & "," & GraphaDemo.Rows(index).Item(6).ToString & "," & GraphaDemo.Rows(index).Item(7).ToString & "," & GraphaDemo.Rows(index).Item(8).ToString & "," & GraphaDemo.Rows(index).Item(9).ToString & "," & GraphaDemo.Rows(index).Item(10).ToString & "," & GraphaDemo.Rows(index).Item(11).ToString & "," & GraphaDemo.Rows(index).Item(12).ToString & "]" &
                        "},"
        Next
        canvas2 = "]" &
       "};" &
       "var canvas = document.getElementById('chartBar').getContext('2d');" &
       "window.bar = new Chart(canvas, {" &
               "type: 'bar'," &
               "data: datos," &
               "options: {" &
                   "elements: {" &
                       "rectangle: {" &
                            "borderWidth : 0," &
                            "borderColor: 'rgb(42,63,84)'," &
                            "borderSkipped: 'bottom'" &
                       "}" &
                   "}," &
                   "responsive: true," &
               "}" &
       "});" &
       "$(document).ready(function(){" &
        "var datos = {" &
            "type: 'doughnut'," &
            "data : {" &
                "datasets :[{" &
                    "data : [" &
                        "" & GraphaCobrar.Rows(0).Item(2).ToString & "," &
                        "" & GraphaCobrar.Rows(1).Item(2).ToString & "," &
                    "]," &
                    "backgroundColor: [" &
                        "'#34495e'," &
                        "'#b1ca36'," &
                    "]," &
                "}]," &
                "labels : [" &
                    "'" & GraphaCobrar.Rows(0).Item(1).ToString & "'," &
                    "'" & GraphaCobrar.Rows(1).Item(1).ToString & "'," &
                "]" &
            "}," &
            "options : {" &
                "responsive : true," &
            "}" &
        "};" &
        "var canvas = document.getElementById('canvasPie').getContext('2d');" &
        "window.pie = new Chart(canvas, datos);" &
    "});" &
       "});" &
       "$(document).ready(function(){" &
        "var datos = {" &
            "type: 'doughnut'," &
            "data : {" &
                "datasets :[{" &
                    "data : [" &
                        "" & GraphaPagar.Rows(0).Item(2).ToString & "," &
                        "" & GraphaPagar.Rows(1).Item(2).ToString & "," &
                    "]," &
                    "backgroundColor: [" &
                        "'#36caab'," &
                        "'#ca3636'," &
                    "]," &
                "}]," &
                "labels : [" &
                    "'" & GraphaPagar.Rows(0).Item(1).ToString & "'," &
                    "'" & GraphaPagar.Rows(1).Item(1).ToString & "'," &
                "]" &
            "}," &
            "options : {" &
                "responsive : true," &
            "}" &
        "};" &
        "var canvas = document.getElementById('canvasPagar').getContext('2d');" &
        "window.pie = new Chart(canvas, datos);" &
    "});" &
    "$(document).ready(function(){" &
        "var datos = {" &
            "type: 'doughnut'," &
            "data : {" &
                "datasets :[{" &
                    "data : [" &
                        "" & indicaDT.Rows(0).Item(1).ToString & "," &
                        "" & indicaDT.Rows(1).Item(1).ToString & "," &
                        "" & indicaDT.Rows(2).Item(1).ToString & "," &
                        "" & indicaDT.Rows(3).Item(1).ToString & "," &
                    "]," &
                    "backgroundColor: [" &
                        "'#26b99a'," &
                        "'#03586a'," &
                        "'#3e95cd'," &
                        "'#c45850'," &
                    "]," &
                "}]," &
                "labels : [" &
                    "'" & indicaDT.Rows(0).Item(0).ToString & "'," &
                    "'" & indicaDT.Rows(1).Item(0).ToString & "'," &
                    "'" & indicaDT.Rows(2).Item(0).ToString & "'," &
                    "'" & indicaDT.Rows(3).Item(0).ToString & "'," &
                "]" &
            "}," &
            "options : {" &
                "responsive : [{
          breakpoint: 480,
          options: {
            chart: {
              width: 200
            },
            legend: {
              position: 'bottom'
            }
          }
        }]," &
            "}" &
        "};" &
        "var canvas = document.getElementById('canvasOT').getContext('2d');" &
        "window.pie = new Chart(canvas, datos);" &
    "});" &
       Chr(60) & "/script>"

        canvas = canvas & canvas1 & canvas2
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "graficos", canvas.ToString, False)
    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If (e.Argument.ToString = "ActualizarCombo") Then
            SDS_P_selectPuntoVenta.DataBind()
            puntoVentaCB.DataBind()
            SDS_P_selectUsuario.DataBind()
            usuarioCB.DataBind()
        ElseIf e.Argument.ToString = "newlogin" Then
            newlogin(0, 1)
        ElseIf e.Argument.ToString = "graphicJS" Then

            'ViewState("anioDashSess") = ""
            'ViewState("anioDashCount") = 0
            'Dim collection As IList(Of RadComboBoxItem) = anioNewCB.CheckedItems
            'ViewState("anioDashCount") = collection.Count
            'If (collection.Count <> 0) Then
            '    For Each item As RadComboBoxItem In collection
            '        ViewState("anioDashSess") = ViewState("anioDashSess") & item.Value & ","
            '    Next
            'End If
            'If ViewState("anioDashSess").ToString.Trim.Length > 0 Then
            '    ViewState("anioDashSess") = Mid(ViewState("anioDashSess"), 1, Len(ViewState("anioDashSess")) - 1)
            'Else
            '    ViewState("anioDashSess") = "0"
            'End If

            'PintarGrafico(monedaNewCB.SelectedValue, ViewState("anioDashSess"), ViewState("anioDashCount"))
        Else
            Dim datos() As String = Split(e.Argument, ",")
            If datos(0) = "newlogin" Then
                newlogin(datos(1), datos(2))
            End If
        End If
    End Sub

    Private Sub fin()
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','Error al ingresar la contraseña.'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)
        Session("usuarioLoginID") = Nothing
        Session("NombreUsuarioLogin") = Nothing
        Session("IDSucursalPrincipal") = Nothing
        Session("IDSucursalPuntoVenta") = Nothing
        Session("nombreSucursalPrincipal") = Nothing
        Session("almacenAsignadoPrincipal") = Nothing
        Session("esSuperAdminUser") = Nothing
        Session("nombrePrincipalEmpresa") = Nothing
        Session("direccionPrincipalEmpresa") = Nothing
        Session("RUCPrincipalEmpresa") = Nothing
        Session("verPrecioByUsuarioID") = Nothing
        Session("verDashBoardByUsuarioID") = Nothing
    End Sub

    Protected Sub sucursalCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles sucursalCB.SelectedIndexChanged
        SDS_P_selectPuntoVenta.DataBind()
        SDS_P_selectUsuario.DataBind()
    End Sub

    Private Sub newlogin(ByVal usuario As String, ByVal clave As String)
        sw_usuarioDT = sw_usuarioC.P_validaUsuario(Me.usuarioCB.SelectedItem.ToString.Trim, clave.ToString, Me.sucursalCB.SelectedValue)
        If sw_usuarioDT.Rows.Count > 0 Then
            If sw_usuarioDT.Rows(0).Item(0) <> -1 Then
                Session("usuarioLoginID") = sw_usuarioDT.Rows(0).Item(0).ToString.Trim
                Session("NombreUsuarioLogin") = sw_usuarioDT.Rows(0).Item(10).ToString.Trim
                Session("IDSucursalPrincipal") = sw_usuarioDT.Rows(0).Item(11).ToString.Trim
                Session("IDSucursalPuntoVenta") = puntoVentaCB.SelectedValue.ToString
                Session("nombreSucursalPrincipal") = sw_usuarioDT.Rows(0).Item(12).ToString.Trim
                Session("almacenAsignadoPrincipal") = sw_usuarioDT.Rows(0).Item(13).ToString.Trim
                Session("esSuperAdminUser") = sw_usuarioDT.Rows(0).Item(14).ToString.Trim
                Session("verPrecioByUsuarioID") = sw_usuarioDT.Rows(0).Item(15).ToString.Trim
                Session("verDashBoardByUsuarioID") = sw_usuarioDT.Rows(0).Item(16).ToString.Trim
                'Session("nombrePrincipalEmpresa") = Session("nombrePrincipalEmpresa").ToString
                'Session("direccionPrincipalEmpresa") = Session("direccionPrincipalEmpresa").ToString
                'Session("RUCPrincipalEmpresa") = Session("RUCPrincipalEmpresa").ToString
                Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString)
            Else
                fin()
            End If
        Else
            fin()
        End If
    End Sub


    'Protected Sub actDashRB_Click(sender As Object, e As EventArgs) Handles actDashRB.Click
    '    ViewState("anioDashSess") = ""
    '    ViewState("anioDashCount") = 0
    '    Dim collection As IList(Of RadComboBoxItem) = anioNewCB.CheckedItems
    '    ViewState("anioDashCount") = collection.Count
    '    If (collection.Count <> 0) Then
    '        For Each item As RadComboBoxItem In collection
    '            ViewState("anioDashSess") = ViewState("anioDashSess") & item.Value & ","
    '        Next
    '    End If
    '    If ViewState("anioDashSess").ToString.Trim.Length > 0 Then
    '        ViewState("anioDashSess") = Mid(ViewState("anioDashSess"), 1, Len(ViewState("anioDashSess")) - 1)
    '    Else
    '        ViewState("anioDashSess") = Date.Now.ToString("yyyy")
    '    End If

    '    PintarGrafico(monedaNewCB.SelectedValue, ViewState("anioDashSess"), ViewState("anioDashCount"))
    'End Sub
End Class
