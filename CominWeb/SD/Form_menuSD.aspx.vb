Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports System.Net
Imports System.Net.Mail


Public Class Form_menuSD
    Inherits System.Web.UI.Page

    'Dim SW_pedidoDT As New DataTable
    'Dim SW_autorizadoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    'Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_menuSD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        'SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        'SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        'SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        'SDS_SD_P_selectEntidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")

        'Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        'tituloLB.Text = " :: SEGUIMIENTO DE ACUERDOS - 2024 :: "

        If Page.IsPostBack = False Then
            Dim sup As Integer

            If Request.QueryString("en") = 3402 Then
                sup = 2
            Else
                sup = Request.QueryString("sup")
            End If

            prioridadesBN.HRef = "prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                "&gjXtIkEroS=SD_SSFD&ksjcmj=0&hsndktumg=28251814290D25D0E43403BA1CEAC908602EAE02D3A88385&tipo=" & Request.QueryString("tipo") & "&ubig=" & Request.QueryString("ubig") &
                                "&de=" & Request.QueryString("de") & "&en=" & Request.QueryString("en") & "&sup=" & sup.ToString & "&enti=" & Request.QueryString("enti") &
                                "&codsector=" & Request.QueryString("codsector") & "&iacp=" & Request.QueryString("iacp") & "&preacuerdo=" & SW_pedidoDA.SD_P_selectParametroByID(16, 2).Rows(0).Item(3)

            listAcuerdoB.HRef = "AcuerdosListV.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" & Me.Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0") & "&gjXtIkEroS=" & Me.Request.QueryString("gjXtIkEroS") & "&ksjcmj=" & Me.Request.QueryString("ksjcmj") & "&hsndktumg=" & Me.Request.QueryString("hsndktumg") & "&tipo=" & Me.Request.QueryString("tipo") & "&ubig=" & Me.Request.QueryString("ubig") & "&de=" & Me.Request.QueryString("de") & "&en=" & Me.Request.QueryString("en") & "&sup=" & sup.ToString & "&enti=" & Me.Request.QueryString("enti") & "&iacp=" & Me.Request.QueryString("iacp")
            'href=>
            listHitosB.HRef = "AcuerdosListHitoV.aspx?lkjasdliwupqwinasndlkkjasKASNDDDWILADdASKJSdwuewue=lksajdasdwWDwdwDdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD" & "&en=" & Me.Request.QueryString("en") & "&sup=" & sup.ToString & "&iacp=" & Me.Request.QueryString("iacp")
            'divSec.Visible = False
            'divDep.Visible = False
            'divProv.Visible = False
            'divDis.Visible = False
            prioridadesBN.Visible = True
            listAcuerdoB.Visible = True

            If Request.QueryString("sup") = 2 Then

                listHitosB.Visible = True

            Else
                listHitosB.Visible = False
            End If

            'hiddenField.Value = "0216"
        End If
    End Sub


    'Protected Sub registroAsistenciaB_Click(sender As Object, e As EventArgs) Handles registroAsistenciaB.Click
    '    Response.Redirect("~/SD/Form_asistenciaEventos.aspx?gjXtIkEroS=SD_SSFD" +
    '                            "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    'End Sub

    'Protected Sub validaB_Click(sender As Object, e As EventArgs) Handles validaB.Click
    '    Response.Redirect("~/SD/Form_asistenciaValidaAcreditado.aspx?gjXtIkEroS=SD_SSFD" +
    '                            "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    'End Sub

    'Protected Sub acreditaListB_Click(sender As Object, e As EventArgs) Handles acreditaListB.Click
    '    Response.Redirect("~/SD/Form_acreditadoList.aspx?gjXtIkEroS=SD_SSFD" +
    '                            "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    'End Sub

    'Protected Sub asistenteListB_Click(sender As Object, e As EventArgs) Handles asistenteListB.Click
    '    Response.Redirect("~/SD/Form_asistenciaListOP.aspx?gjXtIkEroS=SD_SSFD" +
    '                            "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    'End Sub

    'Protected Sub importaAcreditadoB_Click(sender As Object, e As EventArgs) Handles importaAcreditadoB.Click
    '    Response.Redirect("~/SD/Form_asistenciaCargaMasiva.aspx?gjXtIkEroS=SD_SSFD" +
    '                            "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh")
    'End Sub

    'Protected Sub prioridadesB_Click(sender As Object, e As EventArgs) Handles prioridadesB.Click
    '    Response.Redirect("~/SD/prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
    '                            "&gjXtIkEroS=SD_SSFD&ksjcmj=0&hsndktumg=28251814290D25D0E43403BA1CEAC908602EAE02D3A88385&tipo=" & Request.QueryString("tipo") & "&ubig=" & Request.QueryString("ubig") &
    '                            "&de=" & Request.QueryString("de") & "&en=" & Request.QueryString("en") & "&sup=" & Request.QueryString("sup") & "&enti=" & Request.QueryString("enti") &
    '                            "&codsector=" & Request.QueryString("codsector") & "&iacp=" & Request.QueryString("iacp"))
    'End Sub

    'Protected Sub acuerdoB_Click(sender As Object, e As EventArgs) Handles acuerdoB.Click
    '    Response.Redirect("~/SD/AcuerdosListV.aspx?lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
    '                            "&gjXtIkEroS=SD_SSFD&ksjcmj=0")
    'End Sub


    'Protected Sub hitoB_Click(sender As Object, e As EventArgs) Handles hitoB.Click
    '    Response.Redirect("~/SD/AcuerdosListHitoV.aspx?lkjasdliwupqwinasndlkkjasKASNDDDWILADdASKJSdwuewue=lksajdasdwWDwdwDdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
    '                            "&gjXtIkEroS=SD_SSFD")
    'End Sub

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

    'Protected Sub generarB_Click(sender As Object, e As EventArgs) Handles generarB.Click
    '    Dim corre As String
    '    Dim URL As String
    '    Dim cad As String = ""
    '    corre = correoTB.Text.ToString.ToUpper.Trim

    '    If entidadCB.SelectedValue = 0 Then
    '        mensajeJSSA("Seleccione su entidad")
    '    ElseIf nombreTB.Text.ToString.Length = 0 Then
    '        mensajeJSSA("Ingrese Nombre")
    '    ElseIf dniTB.Text.ToString.Length <> 8 Then
    '        mensajeJSSA("Ingrese DNI válido")
    '    ElseIf correoTB.Text.ToString.Length < 6 Or correoTB.Text.ToString.Length > 50 Then
    '        mensajeJSSA("Ingrese Correo electrónico")
    '    ElseIf telefonoTB.Text.ToString.Length < 6 Or telefonoTB.Text.ToString.Length > 9 Then
    '        mensajeJSSA("Ingrese nro. de teléfono")
    '    Else



    '        Dim validaDT As New DataTable
    '        validaDT = SW_pedidoDA.SD_P_selectAcceso(0, entidadCB.SelectedValue, 1)

    '        If validaDT.Rows.Count > 0 Then
    '            mensajeJSSA(validaDT.Rows(0).Item(22).ToString)
    '        Else
    '            If SW_pedidoDA.SD_P_selectParametroByID(8, 0).Rows(0).Item(3) = entidadCB.SelectedValue Then
    '                SW_autorizadoDT = SW_pedidoDA.SD_P_selectAutorizaByDNI(dniTB.Text.ToString.Trim, "")
    '                If SW_autorizadoDT.Rows.Count > 0 Then
    '                    Try

    '                        Dim accesoid As Integer = SW_pedidoDA.SD_P_crearUpdateAcceso(entidadCB.SelectedValue, nombreTB.Text.ToString.ToUpper.Trim, dniTB.Text.ToString.Trim, correoTB.Text.ToString.ToUpper.Trim, telefonoTB.Text.ToString, 0)


    '                        If accesoid > 0 Then
    '                            If SW_autorizadoDT.Rows(0).Item(1) = 0 Then
    '                                SW_pedidoDT = SW_pedidoDA.SD_P_selectAcceso(accesoid, 0, 9)
    '                                URL = SW_pedidoDT.Rows(0).Item(19).ToString() & SW_pedidoDT.Rows(0).Item(2).ToString() & SW_pedidoDT.Rows(0).Item(9).ToString() & SW_pedidoDT.Rows(0).Item(11).ToString() &
    '                    "&hsndktumg=" & SW_pedidoDT.Rows(0).Item(2).ToString() &
    '                    "&tipo=" & SW_pedidoDT.Rows(0).Item(10).ToString() &
    '                    "&ubig=" & SW_pedidoDT.Rows(0).Item(15).ToString() & '"&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString() &
    '                    "&de=" & SW_pedidoDT.Rows(0).Item(17).ToString() & '"&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString() &
    '                    "&en=" & SW_pedidoDT.Rows(0).Item(1).ToString() &
    '                    "&sup=" & SW_pedidoDT.Rows(0).Item(18).ToString() &
    '                    "&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString()

    '                                cad = " UPDATE SD_tblAccesos SET URL = '" & URL.ToString & "' WHERE accesoID = " & accesoid.ToString
    '                                Me.sw_ejecutaSQL.querySQL(cad)

    '                                sendMailA(accesoid, 2, URL)
    '                            Else

    '                                SW_pedidoDT = SW_pedidoDA.SD_P_selectAcceso(accesoid, 0, 9)
    '                                URL = SW_pedidoDT.Rows(0).Item(20).ToString() & SW_pedidoDT.Rows(0).Item(2).ToString() & SW_pedidoDT.Rows(0).Item(9).ToString() & SW_pedidoDT.Rows(0).Item(11).ToString() &
    '                   "&hsndktumg=" & SW_pedidoDT.Rows(0).Item(2).ToString() &
    '                   "&tipo=" & SW_pedidoDT.Rows(0).Item(10).ToString() &
    '                   "&ubig=" & SW_pedidoDT.Rows(0).Item(15).ToString() & '"&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString() &
    '                   "&de=" & SW_pedidoDT.Rows(0).Item(17).ToString() & '"&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString() &
    '                   "&en=" & SW_pedidoDT.Rows(0).Item(1).ToString() &
    '                   "&sup=" & SW_pedidoDT.Rows(0).Item(18).ToString() &
    '                   "&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString()

    '                                cad = " UPDATE SD_tblAccesos SET URL = '" & URL.ToString & "' WHERE accesoID = " & accesoid.ToString
    '                                Me.sw_ejecutaSQL.querySQL(cad)

    '                                sendMailA(accesoid, 3, URL)
    '                            End If

    '                            nombreTB.Text = ""
    '                            dniTB.Text = ""
    '                            correoTB.Text = ""
    '                            telefonoTB.Text = ""
    '                            generarB.Enabled = False
    '                            mensajeJSSA("Se envio un correo a " & corre & ", con acceso a la plataforma de Seguimiento de Acuerdos ")
    '                        End If

    '                    Catch ex As Exception
    '                        mensajeJSS("Se genero un error, contactar con el Administrador")
    '                    End Try
    '                Else
    '                    mensajeJSSA("SOLICITUD RECHAZADA, SUS DATOS FUERON REGISTRADOS PARA EVALUAR UN PROCESO ADMINISTRATIVO")
    '                End If



    '            Else
    '                Try
    '                    Dim accesoid As Integer = SW_pedidoDA.SD_P_crearUpdateAcceso(entidadCB.SelectedValue, nombreTB.Text.ToString.ToUpper.Trim, dniTB.Text.ToString.Trim, correoTB.Text.ToString.ToUpper.Trim, telefonoTB.Text.ToString, 0)

    '                    If accesoid > 0 Then

    '                        SW_pedidoDT = SW_pedidoDA.SD_P_selectAcceso(accesoid, 0, 9)
    '                        URL = SW_pedidoDT.Rows(0).Item(8).ToString() & SW_pedidoDT.Rows(0).Item(2).ToString() & SW_pedidoDT.Rows(0).Item(9).ToString() & SW_pedidoDT.Rows(0).Item(11).ToString() &
    '                    "&hsndktumg=" & SW_pedidoDT.Rows(0).Item(2).ToString() &
    '                    "&tipo=" & SW_pedidoDT.Rows(0).Item(10).ToString() &
    '                    "&ubig=" & SW_pedidoDT.Rows(0).Item(15).ToString() & '"&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString() &
    '                    "&de=" & SW_pedidoDT.Rows(0).Item(17).ToString() & '"&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString() &
    '                    "&en=" & SW_pedidoDT.Rows(0).Item(1).ToString() &
    '                    "&sup=" & SW_pedidoDT.Rows(0).Item(18).ToString() &
    '                    "&enti=" & SW_pedidoDT.Rows(0).Item(16).ToString()

    '                        cad = " UPDATE SD_tblAccesos SET URL = '" & URL.ToString & "' WHERE accesoID = " & accesoid.ToString
    '                        Me.sw_ejecutaSQL.querySQL(cad)

    '                        sendMailA(accesoid, 1, URL)
    '                        nombreTB.Text = ""
    '                        dniTB.Text = ""
    '                        correoTB.Text = ""
    '                        telefonoTB.Text = ""
    '                        generarB.Enabled = False
    '                        mensajeJSSA("Se envio un correo a " & corre & ", con acceso a la plataforma de Seguimiento de Acuerdos ")
    '                    End If

    '                Catch ex As Exception
    '                    mensajeJSS("Se genero un error, contactar con el Administrador")
    '                End Try
    '            End If
    '        End If

    '    End If

    'End Sub


    'Private Sub sendMailA(ByVal accesoid As Integer, tipo As Integer, URL As String)
    '    Dim emailDT As New DataTable
    '    'Dim claveDT As New DataTable
    '    emailDT = SW_pedidoDA.SD_P_selectParametroByID(0, 2)
    '    'claveDT = SW_pedidoDA.SD_P_selectParametroByID(7)
    '    SW_pedidoDT = SW_pedidoDA.SD_P_selectAcceso(accesoid, 0, 9)


    '    Using mm As New MailMessage(emailDT.Rows(0).Item(2).ToString(), SW_pedidoDT.Rows(0).Item(5).ToString())
    '        Dim copy As MailAddress = New MailAddress(emailDT.Rows(3).Item(2).ToString())
    '        'mm.CC.Add(copy)
    '        mm.Bcc.Add(copy)
    '        mm.Subject = emailDT.Rows(2).Item(2).ToString()

    '        If tipo = 1 Then
    '            mm.Body = "<h3>" & emailDT.Rows(2).Item(2).ToString() & "</h3>" &
    '            "<p>Estimado " & SW_pedidoDT.Rows(0).Item(3).ToString() & " de la " & SW_pedidoDT.Rows(0).Item(7).ToString() & ", bienvenido al Sistema de Seguimiento de Acuerdos de la Secretaria de Descentralización de la PCM. Por favor ingresar al siguiente enlace para conocer el estado de los acuerdos de tu interés.</p>" &
    '            "<p><a style='text-decoration: none; display: inline-block;' " &
    '            "href='" & URL.ToString &
    '            "' target='_blank'>" &
    '            "<span style='background-color: #5bc500; line-height: 1; border-radius: 6px; padding: 14px 60px; color: white; display: inline-block; letter-spacing:  2.57px; font-weight: 300; font-family: Arial; font-size: 18px;'>INGRESE AQU&Iacute;</span></a></p>" &
    '            "<p><b>Puedes acceder al sistema hasta el: " & SW_pedidoDT.Rows(0).Item(6).ToString() & "</b></p>" &
    '            "<p>El sistema de correo electr&oacute;nico de la Secretaría de Descentralización de la Presidencia del Consejo de Ministros est&aacute; destinado &uacute;nicamente para fines informativos. Toda la informaci&oacute;n contenida en este mensaje es confidencial y de uso exclusivo. Su divulgaci&oacute;n, copia y/o adulteraci&oacute;n est&aacute;n prohibidas y solo debe ser conocida por la persona a quien se dirige este mensaje.</p>"
    '        ElseIf tipo = 2 Then
    '            mm.Body = "<h3>" & emailDT.Rows(2).Item(2).ToString() & "</h3>" &
    '            "<p>Estimado " & SW_pedidoDT.Rows(0).Item(3).ToString() & " de " & SW_pedidoDT.Rows(0).Item(7).ToString() & ", bienvenido al Sistema de Seguimiento de Acuerdos de la Secretaria de Descentralización de la PCM. Por favor ingresar al siguiente enlace para conocer el estado de los acuerdos de tu interés.</p>" &
    '            "<p><a style='text-decoration: none; display: inline-block;' " &
    '            "href='" & URL.ToString() &
    '            "' target='_blank'>" &
    '            "<span style='background-color: #5bc500; line-height: 1; border-radius: 6px; padding: 14px 60px; color: white; display: inline-block; letter-spacing:  2.57px; font-weight: 300; font-family: Arial; font-size: 18px;'>INGRESE AQU&Iacute;</span></a></p>" &
    '            "<p><b>Puedes acceder al sistema hasta el: " & SW_pedidoDT.Rows(0).Item(6).ToString() & "</b></p>" &
    '            "<p>El sistema de correo electr&oacute;nico de la Secretaría de Descentralización de la Presidencia del Consejo de Ministros est&aacute; destinado &uacute;nicamente para fines informativos. Toda la informaci&oacute;n contenida en este mensaje es confidencial y de uso exclusivo. Su divulgaci&oacute;n, copia y/o adulteraci&oacute;n est&aacute;n prohibidas y solo debe ser conocida por la persona a quien se dirige este mensaje.</p>"
    '        ElseIf tipo = 3 Then
    '            mm.Body = "<h3>" & emailDT.Rows(2).Item(2).ToString() & "</h3>" &
    '           "<p>Estimado " & SW_pedidoDT.Rows(0).Item(3).ToString() & " de " & SW_pedidoDT.Rows(0).Item(7).ToString() & ", bienvenido al Sistema de Seguimiento de Acuerdos de la Secretaria de Descentralización de la PCM. Por favor ingresar al siguiente enlace para conocer el estado de los acuerdos de tu interés.</p>" &
    '           "<p><a style='text-decoration: none; display: inline-block;' " &
    '           "href='" & URL.ToString() &
    '           "' target='_blank'>" &
    '           "<span style='background-color: #5bc500; line-height: 1; border-radius: 6px; padding: 14px 60px; color: white; display: inline-block; letter-spacing:  2.57px; font-weight: 300; font-family: Arial; font-size: 18px;'>INGRESE AQU&Iacute;</span></a></p>" &
    '           "<p><b>Puedes acceder al sistema hasta el: " & SW_pedidoDT.Rows(0).Item(6).ToString() & "</b></p>" &
    '           "<p>El sistema de correo electr&oacute;nico de la Secretaría de Descentralización de la Presidencia del Consejo de Ministros est&aacute; destinado &uacute;nicamente para fines informativos. Toda la informaci&oacute;n contenida en este mensaje es confidencial y de uso exclusivo. Su divulgaci&oacute;n, copia y/o adulteraci&oacute;n est&aacute;n prohibidas y solo debe ser conocida por la persona a quien se dirige este mensaje.</p>"
    '        End If

    '        mm.IsBodyHtml = True
    '        Dim smtp As New SmtpClient()
    '        smtp.Host = "smtp.gmail.com"
    '        smtp.EnableSsl = True
    '        Dim networkcred As New NetworkCredential(emailDT.Rows(0).Item(2).ToString(), emailDT.Rows(1).Item(2).ToString())
    '        smtp.UseDefaultCredentials = True
    '        smtp.Credentials = networkcred
    '        smtp.Port = 587
    '        smtp.Send(mm)
    '    End Using
    'End Sub

End Class