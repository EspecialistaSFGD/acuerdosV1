Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms

Public Class Form_reunionesDetA
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_reunionesDetA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_SD_P_selectListAsisteReuniones.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
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

            If Me.Request.QueryString("reid").ToString > 0 Then
                SW_pedidoDT = SW_pedidoDA.SD_P_selectListReuniones(Me.Request.QueryString("reid").ToString, 0, 0, 0, 0, "0,1,2,3,4")

                If SW_pedidoDT.Rows.Count > 0 Then
                    sectorLB.Text = SW_pedidoDT.Rows(0).Item(7)
                    entidadLB.Text = SW_pedidoDT.Rows(0).Item(16)
                    '        departamentoLB.Text = SW_pedidoDT.Rows(0).Item(13)
                    '        provinciaLB.Text = SW_pedidoDT.Rows(0).Item(14)
                    '        cuiLB.Text = SW_pedidoDT.Rows(0).Item(11)
                    '        intervencionLB.Text = SW_pedidoDT.Rows(0).Item(9)
                    '        aspectoLB.Text = SW_pedidoDT.Rows(0).Item(10)
                    '        acuerdoLB.Text = SW_pedidoDT.Rows(0).Item(3)
                    '        codigoLB.Text = SW_pedidoDT.Rows(0).Item(1)
                    '        clasificaLB.Text = SW_pedidoDT.Rows(0).Item(5)
                    '        responsableLB.Text = SW_pedidoDT.Rows(0).Item(7)
                    '        plazoLB.Text = SW_pedidoDT.Rows(0).Item(8)
                    '        If SW_pedidoDT.Rows(0).Item(17) > 0 Then
                    '            hiddenField.Value = "1"
                    '        Else
                    '            hiddenField.Value = "0"
                    '        End If

                    '        estadoLB.Text = SW_pedidoDT.Rows(0).Item(23)

                    '        If SW_pedidoDT.Rows(0).Item(23) = "VENCIDO" Then
                    '            estadoLB.BackColor = Color.Red
                    '            estadoLB.ForeColor = Color.White
                    '            estadoLB.Font.Size = 16
                    '        End If

                    '        If SW_pedidoDT.Rows(0).Item(23) = "CULMINADO" Then
                    '            fechaLB.Text = SW_pedidoDT.Rows(0).Item(16)
                    '        Else
                    '            fechaLB.Text = ""
                    '        End If

                    estadoCB.SelectedValue = SW_pedidoDT.Rows(0).Item(13)
                    estadoCB.DataBind()
                    If Me.Request.QueryString("estReg") = 4 Or Me.Request.QueryString("estReg") = 3 Then
                        estadoCB.Enabled = False
                    Else
                        estadoCB.Enabled = True
                    End If
                End If

                'Else
                '    SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
                '    If SW_pedidoDT.Rows(0).Item(17) > 0 Then
                '        hiddenField.Value = "1"
                '    Else
                '        hiddenField.Value = "0"
                '    End If
            End If
        End If
    End Sub

    Protected Sub retornarB_Click(sender As Object, e As EventArgs) Handles retornarB.Click
        Response.Redirect("~/SD/Form_reunionesA.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" & Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0").ToString & "&gjXtIkEroS=SD_SSFD&en=" & Request.QueryString("en").ToString & "&sup=" & Request.QueryString("sup").ToString & "&iacp=" & Request.QueryString("iacp").ToString)
    End Sub

    Protected Sub retornaGuardaB_Click(sender As Object, e As EventArgs) Handles retornaGuardaB.Click
        Dim cad As String = ""
        If estadoCB.SelectedValue = 2 Then
            cad = " UPDATE SD_tblReuniones set estadoRegistro = " & estadoCB.SelectedValue.ToString & ", hora_Inicio_real = getdate(), fechaModifica = getdate(), usuarioModifica_accesoID = " & Me.Request.QueryString("iacp").ToString & " where reunionID = " & Me.Request.QueryString("reid").ToString
        ElseIf estadoCB.SelectedValue = 3 Then
            If Me.Request.QueryString("estReg") <> 2 Then
                mensajeJSS("Estado no permitido, previamente debe iniciar la reunión")
            Else
                cad = " UPDATE SD_tblReuniones set estadoRegistro = " & estadoCB.SelectedValue.ToString & ", hora_fin_real = getdate(), fechaModifica = getdate(), usuarioModifica_accesoID = " & Me.Request.QueryString("iacp").ToString & " where reunionID = " & Me.Request.QueryString("reid").ToString
            End If
        ElseIf estadoCB.SelectedValue = 4 Then
            cad = " UPDATE SD_tblReuniones set estadoRegistro = " & estadoCB.SelectedValue.ToString & ", fechaModifica = getdate(), usuarioModifica_accesoID = " & Me.Request.QueryString("iacp").ToString & " where reunionID = " & Me.Request.QueryString("reid").ToString
        End If
        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
                Response.Redirect("~/SD/Form_reunionesA.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" & Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0").ToString & "&gjXtIkEroS=SD_SSFD&en=" & Request.QueryString("en").ToString & "&sup=" & Request.QueryString("sup").ToString & "&iacp=" & Request.QueryString("iacp").ToString)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "actualiza" Then

        Else

            Dim i As Integer
            Dim tip As String
            Dim indicador As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            Dim cad As String = ""
            For i = 0 To 1
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    indicador = a(1)
                End If
            Next
            If param = "ValidacionAsistenteReunion" Then
                cad = " UPDATE SD_tblAsistenciaReunion set asistio = 1, fechaHora = getdate() where asistenciaReunionID = " & indicador
            ElseIf param = "ValidacionAsistenteReu" Then
                cad = " UPDATE SD_tblAsistenciaReunion set asistio = 0, fechaHora = NULL where asistenciaReunionID = " & indicador
            End If

            If cad.Length > 0 Then
                Try
                    Me.sw_ejecutaSQL.querySQL(cad)
                    actualizaGrilla()
                Catch ex As Exception
                End Try
            End If

        End If

    End Sub

    Private Sub actualizaGrilla()
        RadGrid1.Rebind()
    End Sub


    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String

        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)

    End Sub


    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        For Each item As GridDataItem In RadGrid1.Items
            Dim asistenciaReunionID As Integer = item("asistenciaReunionID").Text
            Dim result As Integer = item("asistio").Text
            Dim valida As ImageButton = item.FindControl("TCValida")

            If result = 1 Then
                valida.ImageUrl = "https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/checkOutG.png"
                valida.Attributes.Add("onClick", "return frmValidacionReu('" + asistenciaReunionID.ToString + "'); return true;")
            Else
                valida.ImageUrl = "https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/checkInG.png"
                valida.Attributes.Add("onClick", "return frmValidacionReunion('" + asistenciaReunionID.ToString + "'); return true;")
            End If

        Next
    End Sub

End Class