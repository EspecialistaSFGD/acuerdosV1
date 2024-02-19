Imports CominWeb.SW_coneccionDB

Public Class LoginOperador
    Inherits System.Web.UI.Page

    Dim sw_usuarioC As New SW_usuarios_DA
    Dim sw_usuarioDT As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("EmpresaPrincipalWEB") = Me.Request.QueryString("gjXtIkEroS")

        'Dim cadena As String
        'cadena = Request.QueryString("gjXtIkEroS").ToString.ToString
        If Request.QueryString("gjXtIkEroS").ToString = "COMINSAC" Then
            variableGlobalConexion.nombreCadenaCnx = "CONTRATA_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "eninAumsmyZ4/DsJU7tVSWSW6w=" Then
            variableGlobalConexion.nombreCadenaCnx = "VETERINARIA_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "eninWe1n/TkAuMHCTTWbMBlgg==" Then
            variableGlobalConexion.nombreCadenaCnx = "LIBRERIA_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "enin2hKuuS1kJ/AY7L02e2c1wg==" Then
            variableGlobalConexion.nombreCadenaCnx = "PROFAKTO_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "eninU4WBTrij5CnvCJ/LpawgZg==" Then
            variableGlobalConexion.nombreCadenaCnx = "SAUL_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "enin5QmN8eDxfBmy8giI9q16F8sdBsbLtoxzmfbIcldXZMI=" Then
            variableGlobalConexion.nombreCadenaCnx = "PAPELES_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "eninXaZ2ov79qPNmwXYioAh5JnrqP2//" Then
            variableGlobalConexion.nombreCadenaCnx = "CONTABILIDADConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "enin4DYeb/GNm5Xn9cCcztgEiA==" Then
            variableGlobalConexion.nombreCadenaCnx = "PLAYSTATION_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "enincmVtc2FwZXJ1==" Then
            variableGlobalConexion.nombreCadenaCnx = "REMSAPERU_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "eninY2xvdmVybXVsdGlz2a==" Then
            variableGlobalConexion.nombreCadenaCnx = "CLOVERMULTI_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "enindmVkaXNhZw==" Then
            variableGlobalConexion.nombreCadenaCnx = "VEDISAG_DATOSConnectionString"
        ElseIf Request.QueryString("gjXtIkEroS").ToString = "eninbWFudWNjaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "MANUCCI_DATOSConnectionString"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        If Page.IsPostBack = False Then
            If Session("usuarioLoginID") IsNot Nothing Then

                'Response.Redirect("~/operador/Form_BienvenidoOperador.aspx?gjXtIkEroS=" + Request.QueryString("gjXtIkEroS").ToString)

                Response.Redirect("~/operador/Form_BienvenidoOperador.aspx?gjXtIkEroS=" + Request.QueryString("gjXtIkEroS").ToString +
                                "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&usuaL=" + Session("usuarioLoginID") +
                                  "&nomusuaL=" + Session("NombreUsuarioLogin") +
                                  "&idsucp=" + Session("IDSucursalPrincipal") +
                                  "&nosucp=" + Session("nombreSucursalPrincipal") +
                                  "&almpri=" + Session("almacenAsignadoPrincipal") +
                                  "&essadm=" + Session("esSuperAdminUser"))


            End If
        End If

        SDS_selectSucursales.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectUsuario.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LoginButton.Click
        login()
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
        Session("nombreSucursalPrincipal") = Nothing
        Session("almacenAsignadoPrincipal") = Nothing
        Session("esSuperAdminUser") = Nothing
    End Sub

    Protected Sub sucursalCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles sucursalCB.SelectedIndexChanged
        SDS_P_selectUsuario.DataBind()
    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If (e.Argument.ToString = "ActualizarCombo") Then
            SDS_P_selectUsuario.DataBind()
            usuarioCB.DataBind()
        ElseIf e.Argument.ToString = "login" Then
            login()
        End If
    End Sub
    Private Sub login()
        'sw_usuarioDT = sw_usuarioC.P_validaUsuario(Me.nombreUser.Text, Me.claveUser.Text, Me.sucursalCB.SelectedValue)
        sw_usuarioDT = sw_usuarioC.P_validaUsuario(Me.usuarioCB.SelectedItem.ToString.Trim, Me.claveUser.Text, Me.sucursalCB.SelectedValue)
        If sw_usuarioDT.Rows.Count > 0 Then
            If sw_usuarioDT.Rows(0).Item(0) <> -1 Then
                Session("usuarioLoginID") = sw_usuarioDT.Rows(0).Item(0).ToString.Trim
                Session("NombreUsuarioLogin") = sw_usuarioDT.Rows(0).Item(10).ToString.Trim
                Session("IDSucursalPrincipal") = sw_usuarioDT.Rows(0).Item(11).ToString.Trim
                Session("nombreSucursalPrincipal") = sw_usuarioDT.Rows(0).Item(12).ToString.Trim
                Session("almacenAsignadoPrincipal") = sw_usuarioDT.Rows(0).Item(13).ToString.Trim
                Session("esSuperAdminUser") = sw_usuarioDT.Rows(0).Item(14).ToString.Trim
                Response.Redirect("~/operador/Form_BienvenidoOperador.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString +
                                "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&usuaL=" + sw_usuarioDT.Rows(0).Item(0).ToString.Trim +
                                  "&nomusuaL=" + sw_usuarioDT.Rows(0).Item(10).ToString.Trim +
                                  "&idsucp=" + sw_usuarioDT.Rows(0).Item(11).ToString.Trim +
                                  "&nosucp=" + sw_usuarioDT.Rows(0).Item(12).ToString.Trim +
                                  "&almpri=" + sw_usuarioDT.Rows(0).Item(13).ToString.Trim +
                                  "&essadm=" + sw_usuarioDT.Rows(0).Item(14).ToString.Trim)
            Else
                fin()
            End If
        Else
            fin()
        End If
    End Sub
End Class