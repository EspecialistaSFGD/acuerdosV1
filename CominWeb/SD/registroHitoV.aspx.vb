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

Public Class registroHitoV
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroHitoV_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_SD_P_selectListHitos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectListAvance.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        ''sectorTB.Text = Me.Request.QueryString("secto").ToString
        ''Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        ''tituloLB.Text = Request.QueryString("nosucp").ToString

        If Page.IsPostBack = False Then
            'hiddenField.Value = 0
            Session("sessionHitoId") = "-1"
            If Request.QueryString("sup") = 3 Then
                RadGrid1.MasterTableView.GetColumn("TemplateColumnEstado").Display = False
                RadGrid1.MasterTableView.GetColumn("TemplateColumnDelete").Display = False
                RadGrid1.MasterTableView.GetColumn("nomContacto").Display = False
                RadGrid1.MasterTableView.GetColumn("telefContacto").Display = False
                RadGrid1.MasterTableView.GetColumn("reactivaHito").Display = False
                RadGrid1.MasterTableView.GetColumn("TCAvance").Display = False

                RadGridImagen.MasterTableView.GetColumn("comentarioSector").Display = False
                RadGridImagen.MasterTableView.GetColumn("TCsector").Display = False
                RadGridImagen.MasterTableView.GetColumn("TCComentario").Display = False
                RadGridImagen.MasterTableView.GetColumn("TCValida").Display = False
                RadGridImagen.MasterTableView.GetColumn("TemplateColumnDelete").Display = False
            Else
                If Me.Request.QueryString("estReg") = 1 Then
                    RadGrid1.MasterTableView.GetColumn("TemplateColumnEstado").Display = False
                    RadGrid1.MasterTableView.GetColumn("TemplateColumnDelete").Display = False
                Else
                    RadGrid1.MasterTableView.GetColumn("TemplateColumnEstado").Display = True
                    RadGrid1.MasterTableView.GetColumn("TemplateColumnDelete").Display = True
                End If

                If Request.QueryString("sup") = 1 Or Request.QueryString("sup") = 2 Then
                    RadGrid1.MasterTableView.GetColumn("nomContacto").Display = True
                    RadGrid1.MasterTableView.GetColumn("telefContacto").Display = True
                Else
                    RadGrid1.MasterTableView.GetColumn("nomContacto").Display = False
                    RadGrid1.MasterTableView.GetColumn("telefContacto").Display = False
                End If


                If Request.QueryString("sup") = 2 Then
                    RadGrid1.MasterTableView.GetColumn("reactivaHito").Display = True
                Else
                    RadGrid1.MasterTableView.GetColumn("reactivaHito").Display = False
                End If


                If Me.Request.QueryString("ubig") Then
                    RadGridImagen.MasterTableView.GetColumn("comentarioSector").Display = False
                End If
            End If






            If Me.Request.QueryString("codigoid").ToString > 0 Then
                '        Session("pedido") = Me.Request.QueryString("codigoid").ToString()
                SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)

                If SW_pedidoDT.Rows.Count > 0 Then
                    sectorLB.Text = SW_pedidoDT.Rows(0).Item(12)
                    departamentoLB.Text = SW_pedidoDT.Rows(0).Item(13)
                    provinciaLB.Text = SW_pedidoDT.Rows(0).Item(14)
                    cuiLB.Text = SW_pedidoDT.Rows(0).Item(11)
                    intervencionLB.Text = SW_pedidoDT.Rows(0).Item(9)
                    aspectoLB.Text = SW_pedidoDT.Rows(0).Item(10)
                    acuerdoLB.Text = SW_pedidoDT.Rows(0).Item(3)
                    codigoLB.Text = SW_pedidoDT.Rows(0).Item(1)
                    clasificaLB.Text = SW_pedidoDT.Rows(0).Item(5)
                    responsableLB.Text = SW_pedidoDT.Rows(0).Item(7)
                    plazoLB.Text = SW_pedidoDT.Rows(0).Item(8)
                    If SW_pedidoDT.Rows(0).Item(17) > 0 Then
                        hiddenField.Value = "1"
                    Else
                        hiddenField.Value = "0"
                    End If

                    estadoLB.Text = SW_pedidoDT.Rows(0).Item(23)

                    If SW_pedidoDT.Rows(0).Item(23) = "VENCIDO" Then
                        estadoLB.BackColor = Color.Red
                        estadoLB.ForeColor = Color.White
                        estadoLB.Font.Size = 16
                    End If

                    If SW_pedidoDT.Rows(0).Item(23) = "CULMINADO" Then
                        fechaLB.Text = SW_pedidoDT.Rows(0).Item(16)
                    Else
                        fechaLB.Text = ""
                    End If

                    motivoDesLB.Text = SW_pedidoDT.Rows(0).Item(25)

                End If

            Else
                SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
                If SW_pedidoDT.Rows(0).Item(17) > 0 Then
                    hiddenField.Value = "1"
                Else
                    hiddenField.Value = "0"
                End If
            End If
            'If Me.Request.QueryString("view") = 0 Then
            '    RadGridImagen.Visible = False
            'Else
            '    RadGridImagen.Visible = True
        End If
    End Sub

    Protected Sub retornarB_Click(sender As Object, e As EventArgs) Handles retornarB.Click
        If Request.QueryString("sup") = 2 Then
            Response.Redirect("~/SD/AcuerdosListHitoV.aspx?lkjasdliwupqwinasndlkkjasKASNDDDWILADdASKJSdwuewue=lksajdasdwWDwdwDdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD" & "&iacp=" & Me.Request.QueryString("iacp") & "&en=" & Me.Request.QueryString("en") & "&sup=" & Me.Request.QueryString("sup"))
        Else
            Response.Redirect("~/SD/AcuerdosListV.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" & Me.Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0") & "&gjXtIkEroS=SD_SSFD&ksjcmj=" & Me.Request.QueryString("ksjcmj") & "&hsndktumg=" & Me.Request.QueryString("hsndktumg") & "&tipo=" & Me.Request.QueryString("tipo") & "&ubig=" & Me.Request.QueryString("ubig") & "&de=" & Me.Request.QueryString("de") & "&en=" & Me.Request.QueryString("en") & "&sup=" & Me.Request.QueryString("sup") & "&enti=" & Me.Request.QueryString("enti") & "&iacp=" & Me.Request.QueryString("iacp"))
        End If


    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "actualiza" Then
            SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
            If SW_pedidoDT.Rows(0).Item(15) = 1 Then
                estadoLB.Text = " CULMINADO "
                fechaLB.Text = SW_pedidoDT.Rows(0).Item(16)

            Else
                'If Date.Now.ToString("dd/MM/yyyy") > SW_pedidoDT.Rows(0).Item(8) Then
                '    estadoLB.Text = " VENCIDO "
                '    estadoLB.BackColor = Color.Red
                '    estadoLB.ForeColor = Color.White
                '    estadoLB.Font.Size = 16
                'Else
                '    estadoLB.Text = " PENDIENTE "
                'End If
                fechaLB.Text = ""
            End If

            'Me.RadGrid1.Rebind()'
            'Me.RadGridImagen.Rebind()
            actualizaGrilla()
        ElseIf e.Argument.ToString = "desestima" Then
            sendMailA(Request.QueryString("codigoid").ToString)
        Else

            Dim i As Integer
            Dim tip As String
            Dim indicador As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            Dim cadjs As String = ""
            For i = 0 To 2
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    indicador = a(1)
                ElseIf i = 2 Then
                    tip = a(2)
                End If
            Next
            If param = "eliminaAvance" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblAvance set estado = 0 where avanceId = " & indicador

                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        'Me.RadGrid1.Rebind()
                        actualizaGrilla()
                    Catch ex As Exception
                    End Try
                End If
            ElseIf param = "deleteAvan" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblHito set estado = 0 where hitdoId = " & indicador

                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        'Me.RadGrid1.Rebind()
                        actualizaGrilla()
                    Catch ex As Exception
                    End Try
                End If
            ElseIf param = "actualizaDet" Then
                Session("sessionHitoId") = indicador
                SW_pedidoDT = SW_pedidoDA.SD_P_selectListHitos(indicador, 0, 0, "999")
                descripcionTB.Text = "AVANCES del hito: " + SW_pedidoDT.Rows(0).Item(0)

                Me.RadGridImagen.Rebind()
                'actualizaGrilla()
            ElseIf param = "validacion" Then
                Dim cad As String = ""
                cad = " EXEC SD_P_crearUpdateAvance " & indicador.ToString & ",0,0,'','','','',0,0," & tip.ToString & "," & Request.QueryString("iacp")
                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        'Me.RadGridImagen.Rebind()
                        actualizaGrilla()
                    Catch ex As Exception
                    End Try
                End If
            ElseIf param = "validacionHito" Then
                Dim cad As String = ""
                cad = " EXEC SD_P_crearUpdateHito " & indicador.ToString & ",0,'',0,'','',0," & tip.ToString & "," & Request.QueryString("iacp").ToString
                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        'Me.RadGrid1.Rebind()
                        actualizaGrilla()
                    Catch ex As Exception
                    End Try
                End If
            ElseIf param = "reactivaHito" Then
                Dim cad As String = ""
                cad = " EXEC SD_P_reactivaHito " & tip.ToString & ", " & Request.QueryString("iacp").ToString
                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        'Me.RadGrid1.Rebind()
                        actualizaGrilla()
                    Catch ex As Exception
                    End Try
                End If
            End If



        End If

    End Sub

    Private Sub sendMailA(acuid)
        Dim emailDT As New DataTable
        'Dim claveDT As New DataTable
        'Dim tituloDT As New DataTable
        emailDT = SW_pedidoDA.SD_P_selectParametroByID(0, 2)
        'claveDT = SW_pedidoDA.SD_P_selectParametroByID(7)
        'tituloDT = SW_pedidoDA.SD_P_selectParametroByID(10)


        Using mm As New MailMessage(emailDT.Rows(0).Item(2).ToString(), emailDT.Rows(4).Item(2).ToString())
            Dim copy As MailAddress = New MailAddress(emailDT.Rows(3).Item(2).ToString())
            mm.CC.Add(copy)
            mm.Subject = emailDT.Rows(2).Item(2).ToString()

            mm.Body = "<h3>" & emailDT.Rows(2).Item(2).ToString() & "</h3>" &
            "<p>El " & Request.QueryString("enti").ToString() & " solicita <b>desestimar</b> el acuerdo " & codigoLB.Text.ToString & ".</p>" &
            "<p>El sistema de correo electr&oacute;nico de la Secretaría de Descentralización de la Presidencia del Consejo de Ministros est&aacute; destinado &uacute;nicamente para fines informativos. Toda la informaci&oacute;n contenida en este mensaje es confidencial y de uso exclusivo. Su divulgaci&oacute;n, copia y/o adulteraci&oacute;n est&aacute;n prohibidas y solo debe ser conocida por la persona a quien se dirige este mensaje.</p>"

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
    End Sub
    Private Sub actualizaGrilla()
        RadGrid1.Rebind()
        RadGridImagen.Rebind()
    End Sub


    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub


    'Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
    '    For Each item As GridDataItem In RadGrid1.Items
    '        Dim acuerdoIDg As Integer = item("acuerdoID").Text
    '        Dim hitdoId As Integer = item("hitdoId").Text
    '        Dim estadoRegistro As Integer = item("estadoRegistro").Text
    '        Dim enti As Integer = item("entidadId").Text
    '        Dim eliminaHito As ImageButton = item.FindControl("eliminaHito")
    '        Dim reactivaHito As ImageButton = item.FindControl("reactivaHito")

    '        Dim edita_img As ImageButton = item.FindControl("edita")
    '        Dim hito As String = item("hito").Text
    '        Dim avance As ImageButton = item.FindControl("TCAvance")

    '        Dim validado As Integer = item("validado").Text
    '        Dim valida As ImageButton = item.FindControl("TCValida")

    '        If estadoRegistro = 4 Then
    '            eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
    '            edita_img.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
    '            valida.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
    '            avance.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
    '            reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
    '            reactivaHito.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/rojo_24.png"
    '        Else

    '            If estadoRegistro = 0 Then
    '                reactivaHito.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/plomo_23.png"
    '            Else
    '                reactivaHito.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/verde_24.png"
    '            End If

    '            If validado = 0 Then
    '                eliminaHito.Attributes.Add("onClick", "return deleteAvan('" + hitdoId.ToString + "','" + estadoRegistro.ToString + "');")
    '                edita_img.Attributes.Add("onClick", "return frmHitoN('" + hitdoId.ToString + "');")
    '            Else
    '                eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'Hito validado, no se puede modificar'); return true;")
    '                edita_img.Attributes.Add("onClick", "return mensaje('error', 'Hito validado, no se puede modificar'); return true;")
    '            End If

    '            If Request.QueryString("sup") = 1 Then
    '                If validado = 0 Then
    '                    'If Request.QueryString("estReg") = 4
    '                    valida.ToolTip = "Hito pendiente de validación"
    '                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/close24.png"
    '                    valida.Attributes.Add("onClick", "return frmValidacionHito('" + hitdoId.ToString + "',999); return true;")
    '                Else
    '                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
    '                    valida.ToolTip = "Hito validado"
    '                    valida.Attributes.Add("onClick", "return mensaje('error', 'El Hito ya fue validado'); return true;")
    '                    If estadoRegistro = 1 Then
    '                        reactivaHito.Attributes.Add("onClick", "return reactivaHito('" + hitdoId.ToString + "'); return true;")
    '                    Else
    '                        reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'No aplica reactivación de Hito'); return true;")
    '                    End If

    '                End If


    '            ElseIf Request.QueryString("sup") = 0 Then
    '                valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '                reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            ElseIf Request.QueryString("sup") = 2 Then
    '                valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '                reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            End If


    '            If Me.Request.QueryString("en").ToString = enti Then
    '                If validado = 0 Then
    '                    valida.ToolTip = "Hito pendiente de validación"
    '                    avance.Attributes.Add("onClick", "return mensaje('error', 'Hito pendiente de validación'); return true;")
    '                Else
    '                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
    '                    valida.ToolTip = "Hito validado"
    '                    avance.Attributes.Add("onClick", "return frmAvanceN2('" + acuerdoIDg.ToString + "','" + hitdoId.ToString + "','" + estadoRegistro.ToString + "'); return true;")
    '                End If
    '            Else
    '                'valida.Attributes.Add("onClick", "return frmValidacion('" + avanceId.ToString + "',888); return true;")
    '                avance.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")

    '                If validado = 0 Then
    '                    valida.ToolTip = "Hito pendiente de validación"
    '                Else
    '                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
    '                    valida.ToolTip = "Hito validado"
    '                End If

    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        For Each item As GridDataItem In RadGrid1.Items
            Dim acuerdoIDg As Integer = item("acuerdoID").Text
            Dim hitdoId As Integer = item("hitdoId").Text
            Dim estadoRegistro As Integer = item("estadoRegistro").Text
            Dim enti As Integer = item("entidadId").Text
            Dim eliminaHito As ImageButton = item.FindControl("eliminaHito")
            Dim reactivaHito As ImageButton = item.FindControl("reactivaHito")

            Dim edita_img As ImageButton = item.FindControl("edita")
            Dim hito As String = item("hito").Text
            Dim avance As ImageButton = item.FindControl("TCAvance")

            Dim validado As Integer = item("validado").Text
            Dim valida As ImageButton = item.FindControl("TCValida")

            If estadoRegistro = 4 Then
                eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
                edita_img.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
                valida.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
                avance.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
                reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'Hito desestimado'); return true;")
                reactivaHito.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/rojo_24.png"
            Else

                If estadoRegistro = 0 Then
                    reactivaHito.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/plomo_23.png"
                Else
                    reactivaHito.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/verde_24.png"
                End If

                If validado = 0 Then
                    eliminaHito.Attributes.Add("onClick", "return deleteAvan('" + hitdoId.ToString + "','" + estadoRegistro.ToString + "');")
                    edita_img.Attributes.Add("onClick", "return frmHitoN('" + hitdoId.ToString + "');")
                Else
                    eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'Hito validado, no se puede modificar'); return true;")
                    edita_img.Attributes.Add("onClick", "return mensaje('error', 'Hito validado, no se puede modificar'); return true;")
                End If

                If Request.QueryString("sup") = 1 Then
                    If validado = 0 Then
                        'If Request.QueryString("estReg") = 4
                        valida.ToolTip = "Hito pendiente de validación"
                        valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/close24.png"
                        valida.Attributes.Add("onClick", "return frmValidacionHito('" + hitdoId.ToString + "',999); return true;")
                    Else
                        valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                        valida.ToolTip = "Hito validado"
                        valida.Attributes.Add("onClick", "return mensaje('error', 'El Hito ya fue validado'); return true;")
                        If Request.QueryString("en") = 3402 Then
                            reactivaHito.Attributes.Add("onClick", "return reactivaHito('" + hitdoId.ToString + "'); return true;")
                        Else
                            reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'No aplica reactivación de Hito'); return true;")
                        End If

                    End If


                ElseIf Request.QueryString("sup") = 0 Then
                    valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                    reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                ElseIf Request.QueryString("sup") = 2 Then
                    valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                    If Request.QueryString("en") = 3402 Then
                        reactivaHito.Attributes.Add("onClick", "return reactivaHito('" + hitdoId.ToString + "'); return true;")
                    Else
                        reactivaHito.Attributes.Add("onClick", "return mensaje('error', 'No aplica reactivación de Hito'); return true;")
                    End If
                End If


                If Me.Request.QueryString("en").ToString = enti Then
                    If validado = 0 Then
                        valida.ToolTip = "Hito pendiente de validación"
                        avance.Attributes.Add("onClick", "return mensaje('error', 'Hito pendiente de validación'); return true;")
                    Else
                        valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                        valida.ToolTip = "Hito validado"
                        avance.Attributes.Add("onClick", "return frmAvanceN2('" + acuerdoIDg.ToString + "','" + hitdoId.ToString + "','" + estadoRegistro.ToString + "'); return true;")
                    End If
                Else
                    'valida.Attributes.Add("onClick", "return frmValidacion('" + avanceId.ToString + "',888); return true;")
                    avance.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")

                    If validado = 0 Then
                        valida.ToolTip = "Hito pendiente de validación"
                    Else
                        valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                        valida.ToolTip = "Hito validado"
                    End If

                End If
            End If
        Next
    End Sub

    'Private Sub RadGridImagen_ItemDataBound(ByVal sender As Object, e As GridItemEventArgs) Handles RadGridImagen.ItemDataBound
    '    For Each item As GridDataItem In RadGridImagen.Items
    '        Dim evidenciaurl As String = item("evidencia").Text
    '        Dim avanceId As Integer = item("avanceId").Text
    '        Dim enti As Integer = item("entidadID").Text
    '        Dim validado As Integer = item("validado").Text

    '        Dim evidencia As ImageButton = item.FindControl("TCEvidencia")

    '        Dim sector As ImageButton = item.FindControl("TCsector")
    '        Dim comentario As ImageButton = item.FindControl("TCComentario")

    '        Dim valida As ImageButton = item.FindControl("TCValida")


    '        If evidenciaurl.Length <> 0 Then
    '            evidencia.Attributes.Add("onClick", "return frmEvidencia('" + avanceId.ToString + "','evidencia/" + evidenciaurl.ToString + "'); return true;")
    '        End If

    '        If Request.QueryString("sup") = 1 Then
    '            sector.Attributes.Add("onClick", "return frmComentario('" + avanceId.ToString + "',1); return true;")
    '            comentario.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            If validado = 0 Then
    '                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/close24.png"
    '                valida.ToolTip = "Avance pendiente de validación"
    '                valida.Attributes.Add("onClick", "return frmValidacion('" + avanceId.ToString + "',999); return true;")
    '            Else
    '                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
    '                valida.ToolTip = "Avance VALIDADO"
    '                'valida.Attributes.Add("onClick", "return frmValidacion('" + avanceId.ToString + "',888); return true;")
    '                valida.Attributes.Add("onClick", "return mensaje('error', 'El avance ya fue validado'); return true;")
    '            End If

    '        ElseIf Request.QueryString("sup") = 0 Then
    '            If validado = 1 Then
    '                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
    '            End If

    '            sector.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            comentario.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            If Request.QueryString("tipo") = 2 Then
    '                If Request.QueryString("en") = enti Then

    '                    comentario.Attributes.Add("onClick", "return mensaje('error', 'No puede realizar comentarios sobre su avance'); return true;")
    '                Else
    '                    comentario.Attributes.Add("onClick", "return frmComentario('" + avanceId.ToString + "',2); return true;")
    '                End If

    '            Else
    '                If Request.QueryString("en") = enti Then

    '                    comentario.Attributes.Add("onClick", "return mensaje('error', 'No puede realizar comentarios sobre su avance'); return true;")
    '                Else
    '                    comentario.Attributes.Add("onClick", "return frmComentario('" + avanceId.ToString + "',3); return true;")
    '                End If

    '            End If
    '        ElseIf Request.QueryString("sup") = 2 Then
    '            If validado = 1 Then
    '                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
    '            End If
    '            valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            sector.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '            comentario.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
    '        End If

    '    Next
    'End Sub
    Private Sub RadGridImagen_DataBound(ByVal sender As Object, e As GridItemEventArgs) Handles RadGridImagen.ItemDataBound
        For Each item As GridDataItem In RadGridImagen.Items
            Dim evidenciaurl As String = item("evidencia").Text
            Dim avanceId As Integer = item("avanceId").Text
            Dim enti As Integer = item("entidadID").Text
            Dim validado As Integer = item("validado").Text
            Dim estado As Integer = item("estado").Text

            Dim evidencia As ImageButton = item.FindControl("TCEvidencia")
            Dim sector As ImageButton = item.FindControl("TCsector")
            Dim comentario As ImageButton = item.FindControl("TCComentario")
            Dim valida As ImageButton = item.FindControl("TCValida")
            Dim eliminaHito As ImageButton = item.FindControl("eliminaHito")

            If evidenciaurl.Length <> 0 Then
                evidencia.Attributes.Add("onClick", "return frmEvidencia('" + avanceId.ToString + "','evidencia/" + evidenciaurl.ToString + "'); return true;")
            End If

            If Request.QueryString("sup") = 1 Then
                sector.Attributes.Add("onClick", "return frmComentario('" + avanceId.ToString + "',1); return true;")
                comentario.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                If validado = 0 Then
                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/close24.png"
                    valida.ToolTip = "Avance pendiente de validación"
                    valida.Attributes.Add("onClick", "return frmValidacion('" + avanceId.ToString + "',999); return true;")
                    eliminaHito.Attributes.Add("onClick", "return eliminaAvance('" + avanceId.ToString + "','" + validado.ToString + "','" + enti.ToString + "');")
                Else
                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                    valida.ToolTip = "Avance VALIDADO"
                    'valida.Attributes.Add("onClick", "return frmValidacion('" + avanceId.ToString + "',888); return true;")
                    valida.Attributes.Add("onClick", "return mensaje('error', 'El avance ya fue validado'); return true;")
                    eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'El avance ya fue validado'); return true;")
                End If

            ElseIf Request.QueryString("sup") = 0 Then
                If validado = 1 Then
                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                End If

                sector.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                comentario.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")

                If Request.QueryString("tipo") = 2 Then
                    If Request.QueryString("en") = enti Then

                        comentario.Attributes.Add("onClick", "return mensaje('error', 'No puede realizar comentarios sobre su avance'); return true;")
                        eliminaHito.Attributes.Add("onClick", "return eliminaAvance('" + avanceId.ToString + "','" + validado.ToString + "','" + enti.ToString + "');")
                    Else
                        comentario.Attributes.Add("onClick", "return frmComentario('" + avanceId.ToString + "',2); return true;")
                        eliminaHito.Attributes.Add("onClick", "return eliminaAvance('" + avanceId.ToString + "','" + validado.ToString + "','" + enti.ToString + "');")
                    End If

                Else
                    If Request.QueryString("en") = enti Then
                        eliminaHito.Attributes.Add("onClick", "return eliminaAvance('" + avanceId.ToString + "','" + validado.ToString + "','" + enti.ToString + "');")
                        comentario.Attributes.Add("onClick", "return mensaje('error', 'No puede realizar comentarios sobre su avance'); return true;")
                    Else
                        eliminaHito.Attributes.Add("onClick", "return eliminaAvance('" + avanceId.ToString + "','" + validado.ToString + "','" + enti.ToString + "');")
                        comentario.Attributes.Add("onClick", "return frmComentario('" + avanceId.ToString + "',3); return true;")
                    End If

                End If
            ElseIf Request.QueryString("sup") = 2 Then
                If validado = 1 Then
                    valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                    eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'No puede eliminar un avance validado'); return true;")
                End If
                eliminaHito.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                valida.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                sector.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
                comentario.Attributes.Add("onClick", "return mensaje('error', 'No corresponde a la entidad'); return true;")
            End If

        Next
    End Sub
End Class