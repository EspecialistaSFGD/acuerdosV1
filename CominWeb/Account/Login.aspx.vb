Imports CominWeb.SW_coneccionDB

Public Class Login
    Inherits System.Web.UI.Page

    Dim sw_usuarioC As New SW_usuarios_DA
    Dim sw_usuarioDT As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SDS_selectSucursales.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectUsuario.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LoginButton.Click
        login()
    End Sub

    Private Sub fin()
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " & _
                          " mensaje('information','Error al ingresar la contraseña.'); " & _
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
                Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString)
            Else
                fin()
            End If
        Else
            fin()
        End If
    End Sub
End Class