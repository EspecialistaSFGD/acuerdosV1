Imports CominWeb.SW_coneccionDB
Public Class Form_BienvenidoSD
    Inherits System.Web.UI.Page

    Private Sub Form_BienvenidoSD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        tituloLB.Text = " :: REGISTRO DE ACUERDOS CEMUNI I - 2024 :: "
        'SDS_P_selectPlanManttoDet.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString

    End Sub

    Protected Sub registroAsistenciaB_Click(sender As Object, e As EventArgs) Handles registroAsistenciaB.Click
        Response.Redirect("~/SD/Form_asistenciaEventos.aspx?gjXtIkEroS=SD_SSFD" +
                                "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    End Sub

    Protected Sub validaB_Click(sender As Object, e As EventArgs) Handles validaB.Click
        Response.Redirect("~/SD/Form_asistenciaValidaAcreditado.aspx?gjXtIkEroS=SD_SSFD" +
                                "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    End Sub

    Protected Sub acreditaListB_Click(sender As Object, e As EventArgs) Handles acreditaListB.Click
        Response.Redirect("~/SD/Form_acreditadoList.aspx?gjXtIkEroS=SD_SSFD" +
                                "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    End Sub

    Protected Sub asistenteListB_Click(sender As Object, e As EventArgs) Handles asistenteListB.Click
        Response.Redirect("~/SD/Form_asistenciaListOP.aspx?gjXtIkEroS=SD_SSFD" +
                                "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    End Sub

    Protected Sub importaAcreditadoB_Click(sender As Object, e As EventArgs) Handles importaAcreditadoB.Click
        Response.Redirect("~/SD/Form_asistenciaCargaMasiva.aspx?gjXtIkEroS=SD_SSFD" +
                                "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    End Sub

    Protected Sub prioridadesB_Click(sender As Object, e As EventArgs) Handles prioridadesB.Click
        Response.Redirect("~/SD/prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&gjXtIkEroS=SD_SSFD&codsector=0")
    End Sub

    Protected Sub acuerdoB_Click(sender As Object, e As EventArgs) Handles acuerdoB.Click
        Response.Redirect("~/SD/AcuerdosListV.aspx?lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&gjXtIkEroS=SD_SSFD")
    End Sub


    Protected Sub hitoB_Click(sender As Object, e As EventArgs) Handles hitoB.Click
        Response.Redirect("~/SD/AcuerdosListHitoV.aspx?lkjasdliwupqwinasndlkkjasKASNDDDWILADdASKJSdwuewue=lksajdasdwWDwdwDdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&gjXtIkEroS=SD_SSFD")
    End Sub

    'Protected Sub btn_desconectarme_Click(sender As Object, e As EventArgs) Handles btn_desconectarme.Click
    '    Session("usuarioLoginID") = Nothing
    '    Session("NombreUsuarioLogin") = Nothing
    '    Session("IDSucursalPrincipal") = Nothing
    '    Session("nombreSucursalPrincipal") = Nothing
    '    Session("usuarioLoginIDsuperAdmin") = Nothing
    '    Session("almacenAsignadoPrincipal") = Nothing
    '    Session("esSuperAdminUser") = Nothing
    '    Session("tipoCambioCompraSession") = Nothing
    '    Session("tipoCambioVentaSession") = Nothing
    '    Response.Redirect("~/Account/LoginOperador.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString)
    'End Sub
End Class