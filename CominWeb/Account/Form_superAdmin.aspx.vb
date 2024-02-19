Imports CominWeb.SW_coneccionDB

Public Class Form_superAdmin
    Inherits System.Web.UI.Page

    Dim sw_usuarioC As New SW_usuarios_DA
    Dim sw_usuarioDT As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SDS_selectSucursales.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LoginButton.Click
        sw_usuarioDT = sw_usuarioC.P_validaUsuario(Me.nombreUser.Text, Me.claveUser.Text, Me.sucursalCB.SelectedValue)
        If sw_usuarioDT.Rows.Count > 0 Then
            If sw_usuarioDT.Rows(0).Item(0) <> -1 Then
                Session("usuarioLoginID") = sw_usuarioDT.Rows(0).Item(0).ToString.Trim
                Session("NombreUsuarioLogin") = sw_usuarioDT.Rows(0).Item(10).ToString.Trim
                Session("IDSucursalPrincipal") = sw_usuarioDT.Rows(0).Item(11).ToString.Trim
                Session("nombreSucursalPrincipal") = sw_usuarioDT.Rows(0).Item(12).ToString.Trim
                Session("usuarioLoginIDsuperAdmin") = 1 'super Admin
                Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString)
            End If
        Else
            Session("usuarioLoginID") = Nothing
            Session("NombreUsuarioLogin") = Nothing
            Session("IDSucursalPrincipal") = Nothing
            Session("nombreSucursalPrincipal") = Nothing
            Session("usuarioLoginIDsuperAdmin") = Nothing
            Response.Redirect("~/Account/Login.aspx")
        End If
    End Sub
End Class