Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports System.Net
Imports System.Net.Mail


Public Class Form_menuSD
    Inherits System.Web.UI.Page

    'Dim SW_pedidoDT As New DataTable
    Dim eventoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    'Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_menuSD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            If Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0") = "D72E58A4A3B20314C59A69BB1ED5905F88DBBDB2AE4B7DB1" Then
                Response.Redirect("https://sesigue.miterritorio.gob.pe/sesigueold/SD/Form_menuSD.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=2E58A4A3B20314C59A69BB1ED5905F88DBBDB2AE4B7DB1&gjXtIkEroS=" & Me.Request.QueryString("gjXtIkEroS").ToString & "&ksjcmj=" & Me.Request.QueryString("ksjcmj").ToString & "&hsndktumg=" & Me.Request.QueryString("hsndktumg").ToString & "&tipo=" & Me.Request.QueryString("tipo").ToString & "&ubig=" & Me.Request.QueryString("ubig").ToString & "&de=" & Me.Request.QueryString("de").ToString & "&en=" & Me.Request.QueryString("en").ToString & "&sup=" & Me.Request.QueryString("sup").ToString & "&enti=" & Me.Request.QueryString("enti").ToString & "&codsector=" & Me.Request.QueryString("codsector").ToString & "&iacp=" & Me.Request.QueryString("iacp").ToString)
            End If

        Else
                variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        ''SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        ''SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        ''SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        ''SDS_SD_P_selectEntidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    'h ttps://sesigue.com/SESIGUE/SD/Form_menuSD.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=D72E58A4A3B20314C59A69BB1ED5905F88DBBDB2AE4B7DB1
    '&gjXtIkEroS=SD_SSFD
    '&ksjcmj=16
    '&hsndktumg=D72E58A4A3B20314C59A69BB1ED5905F88DBBDB2AE4B7DB1
    '&tipo=1
    '&ubig=0
    '&de=
    '&en=3384
    '&sup=1
    '&enti=Ministerio%20de%20Transportes%20y%20Comunicaciones%20(MTC)
    '&codsector=16
    '&iacp=700

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")

        'Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        'tituloLB.Text = " :: SEGUIMIENTO DE ACUERDOS - 2024 :: "

        If Page.IsPostBack = False Then
            'Dim sup As Integer

            'If Request.QueryString("en") = 3402 Then
            '    sup = 2
            'Else
            '    sup = Request.QueryString("sup")
            'End If

            'eventoDT = SW_pedidoDA.SD_P_selectEventos(0, 1)
            'Session("espacioIDFiltro") = eventoDT.Rows(0).Item(0)

            'prioridadesBN.HRef = "prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
            '                    "&gjXtIkEroS=SD_SSFD&ksjcmj=0&hsndktumg=28251814290D25D0E43403BA1CEAC908602EAE02D3A88385&tipo=" & Request.QueryString("tipo") & "&ubig=" & Request.QueryString("ubig") & "&amb=" & eventoDT.Rows(0).Item(4).ToString &
            '                    "&de=" & Request.QueryString("de") & "&en=" & Request.QueryString("en") & "&sup=" & sup.ToString & "&enti=" & Request.QueryString("enti") &
            '                    "&codsector=" & Request.QueryString("codsector") & "&iacp=" & Request.QueryString("iacp") & "&preacuerdo=" & SW_pedidoDA.SD_P_selectParametroByID(16, 2).Rows(0).Item(3)

            'listAcuerdoB.HRef = "AcuerdosListV.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" & Me.Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0") & "&gjXtIkEroS=" & Me.Request.QueryString("gjXtIkEroS") & "&ksjcmj=" & Me.Request.QueryString("ksjcmj") & "&hsndktumg=" & Me.Request.QueryString("hsndktumg") & "&tipo=" & Me.Request.QueryString("tipo") & "&ubig=" & Me.Request.QueryString("ubig") & "&de=" & Me.Request.QueryString("de") & "&en=" & Me.Request.QueryString("en") & "&sup=" & sup.ToString & "&enti=" & Me.Request.QueryString("enti") & "&iacp=" & Me.Request.QueryString("iacp")

            'listHitosB.HRef = "AcuerdosListHitoV.aspx?lkjasdliwupqwinasndlkkjasKASNDDDWILADdASKJSdwuewue=lksajdasdwWDwdwDdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD" & "&en=" & Me.Request.QueryString("en") & "&sup=" & sup.ToString & "&iacp=" & Me.Request.QueryString("iacp")

            'acreditadoBN.HRef = "AregistroAcredita.aspx?au=0&7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=2B6AC8BbF4ADF440005AFC42EF337555FB0008BF9770791Z&gjXtIkEroS=" & Me.Request.QueryString("gjXtIkEroS") & "&codevento=" & eventoDT.Rows(0).Item(0).ToString & "&ubig=" & Me.Request.QueryString("ubig") & "&de=" & Me.Request.QueryString("de") & "&en=" & Me.Request.QueryString("en") & "&codsector=" & Request.QueryString("codsector") & "&iacp=" & Me.Request.QueryString("iacp") & "&sup=" & sup.ToString

            'asistenciaBN.HRef = "AregistroAsistencia.aspx?au=0&7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=2B6AC8BbF4ADF440005AFC42EF337555FB0008BF9770791Z&gjXtIkEroS=" & Me.Request.QueryString("gjXtIkEroS") & "&ubig=" & Me.Request.QueryString("ubig") & "&de=" & Me.Request.QueryString("de") & "&en=" & Me.Request.QueryString("en") & "&codsector=" & Request.QueryString("codsector") & "&iacp=" & Me.Request.QueryString("iacp") & "&sup=" & sup.ToString
            'reunionesBN.HRef = "Form_reuniones.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=2B6AC8BF14ADF446665AFC42EF337555FB6668BF9770791Z&gjXtIkEroS=" & Me.Request.QueryString("gjXtIkEroS") & "&en=" & Me.Request.QueryString("en") & "&sup=" & sup.ToString & "&iacp=" & Me.Request.QueryString("iacp") & "&ksjcmj=" & Me.Request.QueryString("ksjcmj")

            ''acreditadoBN.Visible = True
            'If Request.QueryString("sup") = 3 Then
            '    acreditadoBN.Visible = False
            '    asistenciaBN.Visible = False
            '    listHitosB.Visible = False
            '    prioridadesBN.Visible = False
            '    reunionesBN.Visible = False
            '    prioridadesBN.Visible = True
            '    listAcuerdoB.Visible = True
            'ElseIf Request.QueryString("sup") = 2 Then
            '    prioridadesBN.Visible = True
            '    listAcuerdoB.Visible = True
            '    listHitosB.Visible = True
            '    asistenciaBN.Visible = True
            '    reunionesBN.Visible = True
            'ElseIf Request.QueryString("sup") = 1 Then
            '    listHitosB.Visible = False
            '    asistenciaBN.Visible = False
            '    acreditadoBN.Visible = True
            '    reunionesBN.Visible = False
            '    prioridadesBN.Visible = False
            '    listAcuerdoB.Visible = False
            'Else
            '    prioridadesBN.Visible = False
            '    listAcuerdoB.Visible = False
            '    acreditadoBN.Visible = True
            '    asistenciaBN.Visible = False
            '    listHitosB.Visible = False
            '    reunionesBN.Visible = False
            '    If Request.QueryString("ubig") <> "0" Then
            '        Dim ub As Integer = Right("00" & Request.QueryString("ubig"), 6)
            '        If ub > 0 Then
            '            acreditadoBN.Visible = True
            '        Else
            '            acreditadoBN.Visible = True
            '        End If
            '    End If


            'End If

        End If
    End Sub



    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('alert','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub

    Private Sub mensajeJSSA(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('warning','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub


End Class