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


Public Class registroHi
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroHi_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_SD_P_selectEntidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Page.IsPostBack = False Then
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
            Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
            If Me.Request.QueryString("codh").ToString > 0 Then
                SW_pedidoDT = SW_pedidoDA.SD_P_selectListHitos(Me.Request.QueryString("codh").ToString, 0, 0, "999")
                If SW_pedidoDT.Rows.Count > 0 Then
                    hitoTB.Text = SW_pedidoDT.Rows(0).Item(0)
                    responsableCB.SelectedValue = SW_pedidoDT.Rows(0).Item(8)
                    If SW_pedidoDT.Rows(0).Item(8) = 25 Then
                        hiddenTipo.Value = 2
                        hiddenEnt.Value = SW_pedidoDT.Rows(0).Item(10)
                        hiddenField.Value = -1
                    Else
                        hiddenTipo.Value = 1
                        hiddenEnt.Value = 0
                        hiddenField.Value = Me.Request.QueryString("ksjcmj").ToString
                    End If
                    responsableCB.DataBind()
                    plazoRDP.SelectedDate = SW_pedidoDT.Rows(0).Item(2).ToString.Trim
                    'entidadCB.Items.Clear()
                    'entidadCB.DataBind()
                    entidadCB.SelectedValue = SW_pedidoDT.Rows(0).Item(10)
                    entidadCB.DataBind()
                End If
            Else
                'If Request.QueryString("ubig").ToString = "0" Then
                '    responsableCB.SelectedValue = 26
                '    responsableCB.DataBind()
                '    entidadCB.Items.Clear()
                '    entidadCB.DataBind()
                'Else
                '    responsableCB.SelectedValue = 25
                '    responsableCB.DataBind()
                '    entidadCB.Items.Clear()
                '    entidadCB.DataBind()
                'End If
                'Me.plazoRDP.MinDate = Date.Now --- TEMPORAL COMO INICIO DE LA MARCHA BLANCA
                SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
                Me.plazoRDP.MaxDate = SW_pedidoDT.Rows(0).Item(8)
                'SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
                'If SW_pedidoDT.Rows(0).Item(8) < Date.Now Then
                '    mensajeJSS("Acuerdo Vencido")
                'Else
                '    Me.plazoRDP.MinDate = Date.Now
                '    Me.plazoRDP.MaxDate = SW_pedidoDT.Rows(0).Item(8)
                'End If

            End If
        End If
    End Sub


    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "guardar" Then
            guardar(Me.Request.QueryString("codh").ToString, Me.Request.QueryString("codigoid").ToString, hitoTB.Text.ToString.Trim, responsableCB.SelectedValue, plazoRDP.SelectedDate.Value.ToString("dd/MM/yyyy"), "", entidadCB.SelectedValue, Me.Request.QueryString("iacp").ToString)
        End If
    End Sub

    Private Sub guardar(ByVal hitdoId As Integer, acuerdoid As Integer, hito As String, responsable As Integer, plazo As String, comentario As String, entidad As Integer, acceso As Integer)

        Dim cad As String = ""
        cad = " exec SD_P_crearUpdateHito " & hitdoId.ToString & ", " & acuerdoid.ToString & ", '" & hito.ToString & "', " & responsable.ToString & ", '" & plazo & "', '" & comentario & "', '" & entidad & "', 0, " & acceso.ToString

        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
                SW_pedidoDT = SW_pedidoDA.SD_P_selectAcceso(0, entidadCB.SelectedValue, 1)

                If SW_pedidoDT.Rows.Count > 0 Then
                    If SW_pedidoDT.Rows(0).Item(23).ToString = "P" Then
                        sendMailA(Me.Request.QueryString("codigAcu"), SW_pedidoDT.Rows(0).Item(7).ToString, 1, SW_pedidoDT.Rows(0).Item(5).ToString, SW_pedidoDT.Rows(0).Item(24).ToString) ' 1 existe, 2 no existe
                    End If
                Else
                    SW_pedidoDT = SW_pedidoDA.SD_P_selectEntidades(entidadCB.SelectedValue, 2, 0, 0, "")
                    If SW_pedidoDT.Rows.Count > 0 Then
                        If SW_pedidoDT.Rows(0).Item(8).ToString = "P" Then
                            sendMailA(Me.Request.QueryString("codigAcu"), SW_pedidoDT.Rows(0).Item(7).ToString, 2, SW_pedidoDT.Rows(0).Item(9).ToString, "https://sesigue.miterritorio.gob.pe/sesigue") ' 1 existe, 2 no existe
                        End If
                    End If
                End If



                cierraVentana(2)
            Catch ex As Exception
            End Try
        End If

    End Sub


    Private Sub sendMailA(ByVal acuerdo As String, entidad As String, existe As Integer, correoDes As String, url As String)
        If correoDes.ToString.Length > 5 Then
            Dim emailDT As New DataTable
            'Dim claveDT As New DataTable
            emailDT = SW_pedidoDA.SD_P_selectParametroByID(0, 2)

            Using mm As New MailMessage(emailDT.Rows(0).Item(2).ToString(), correoDes)
                Dim copy As MailAddress = New MailAddress(emailDT.Rows(3).Item(2).ToString())
                'mm.CC.Add(copy)
                mm.Bcc.Add(copy)
                mm.Subject = emailDT.Rows(2).Item(2).ToString()

                If existe = 1 Then
                    mm.Body = "<h3>" & emailDT.Rows(2).Item(2).ToString() & "</h3>" &
                "<p>Estimada " & entidad.ToString() & ", se le asigno un hito en el acuerdo <b>" & acuerdo & "</b>, revisar el Sistema SESIGUE para mayor detalle.</p>" &
                "<p><a style='text-decoration: none; display: inline-block;' " &
                "href='" & url.ToString &
                "' target='_blank'>" &
                "<span style='background-color: #5bc500; line-height: 1; border-radius: 6px; padding: 14px 60px; color: white; display: inline-block; letter-spacing:  2.57px; font-weight: 300; font-family: Arial; font-size: 18px;'>INGRESE AQU&Iacute;</span></a></p>" &
                "<p><b>Puedes acceder al sistema hasta el: " & SW_pedidoDT.Rows(0).Item(6).ToString() & "</b></p>" &
                "<p>El sistema de correo electr&oacute;nico de la Secretaría de Descentralización de la Presidencia del Consejo de Ministros est&aacute; destinado &uacute;nicamente para fines informativos. Toda la informaci&oacute;n contenida en este mensaje es confidencial y de uso exclusivo. Su divulgaci&oacute;n, copia y/o adulteraci&oacute;n est&aacute;n prohibidas y solo debe ser conocida por la persona a quien se dirige este mensaje.</p>"
                Else
                    mm.Body = "<h3>" & emailDT.Rows(2).Item(2).ToString() & "</h3>" &
                "<p>Estimada " & entidad.ToString() & ", se le asigno un hito en el acuerdo <b>" & acuerdo & "</b>, revisar el Sistema SESIGUE para mayor detalle.</p>" &
                "<p>El sistema de correo electr&oacute;nico de la Secretaría de Descentralización de la Presidencia del Consejo de Ministros est&aacute; destinado &uacute;nicamente para fines informativos. Toda la informaci&oacute;n contenida en este mensaje es confidencial y de uso exclusivo. Su divulgaci&oacute;n, copia y/o adulteraci&oacute;n est&aacute;n prohibidas y solo debe ser conocida por la persona a quien se dirige este mensaje.</p>"
                End If

                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                Dim networkcred As New NetworkCredential(emailDT.Rows(0).Item(2).ToString(), emailDT.Rows(1).Item(2).ToString())
                smtp.UseDefaultCredentials = True
                smtp.Credentials = networkcred
                smtp.Port = 587
                smtp.Send(mm)
            End Using
        End If
    End Sub

    Private Sub cierraVentana(ByVal id As Integer)
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " CerrarVentana(" & id.ToString & "); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "Cerrar", cadena_java.ToString, False)
    End Sub

    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub

    Protected Sub responsableCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles responsableCB.SelectedIndexChanged
        If responsableCB.SelectedValue = 25 Then
            SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
            hiddenUbi.Value = SW_pedidoDT.Rows(0).Item(22)
            hiddenField.Value = 0
            hiddenTipo.Value = 2
            hiddenEnt.Value = 0
            'ubigeo
        ElseIf responsableCB.SelectedValue = 26 Then
            hiddenField.Value = Request.QueryString("ksjcmj")
            hiddenUbi.Value = 0
            hiddenTipo.Value = 1
            hiddenEnt.Value = 0
        ElseIf responsableCB.SelectedValue = 26 Then
            hiddenUbi.Value = -1
            hiddenTipo.Value = -1
            hiddenEnt.Value = 0
            hiddenField.Value = -1
        End If
        entidadCB.Items.Clear()
        entidadCB.DataBind()
    End Sub
End Class