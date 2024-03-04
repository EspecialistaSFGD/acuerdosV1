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

            Session("sessionHitoId") = "-1"
            If Me.Request.QueryString("estReg") = 1 Then
                RadGrid1.MasterTableView.GetColumn("TemplateColumnEstado").Display = False
                RadGrid1.MasterTableView.GetColumn("TemplateColumnDelete").Display = False
            Else
                RadGrid1.MasterTableView.GetColumn("TemplateColumnEstado").Display = True
                RadGrid1.MasterTableView.GetColumn("TemplateColumnDelete").Display = True
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

                    If SW_pedidoDT.Rows(0).Item(15) = 1 Then
                        estadoLB.Text = " CULMINADO "
                        fechaLB.Text = SW_pedidoDT.Rows(0).Item(16)

                    Else
                        If Date.Now.ToString("dd/MM/yyyy") > SW_pedidoDT.Rows(0).Item(8) Then
                            estadoLB.Text = " VENCIDO "
                            estadoLB.BackColor = Color.Red
                            estadoLB.ForeColor = Color.White
                            estadoLB.Font.Size = 16
                        Else
                            estadoLB.Text = " PENDIENTE "
                        End If

                        fechaLB.Text = ""
                    End If

                    'Else

                End If
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
        'End If
    End Sub

    Protected Sub retornarB_Click(sender As Object, e As EventArgs) Handles retornarB.Click

        Response.Redirect("~/SD/AcuerdosListV.aspx?lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&ksjcmj=" & Me.Request.QueryString("ksjcmj"))

    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "actualiza" Then
            SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codigoid").ToString, 0, "", 0, 0)
            If SW_pedidoDT.Rows(0).Item(15) = 1 Then
                estadoLB.Text = " CULMINADO "
                fechaLB.Text = SW_pedidoDT.Rows(0).Item(16)

            Else
                If Date.Now.ToString("dd/MM/yyyy") > SW_pedidoDT.Rows(0).Item(8) Then
                    estadoLB.Text = " VENCIDO "
                    estadoLB.BackColor = Color.Red
                    estadoLB.ForeColor = Color.White
                    estadoLB.Font.Size = 16
                Else
                    estadoLB.Text = " PENDIENTE "
                End If
                fechaLB.Text = ""
            End If

            Me.RadGrid1.Rebind()
            Me.RadGridImagen.Rebind()
        Else

            Dim i As Integer
            Dim indicador As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            Dim cadjs As String = ""
            For i = 0 To 1
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    indicador = a(1)
                End If
            Next
            If param = "deleteAvan" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblHito set estado = 0 where hitdoId = " & indicador

                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                        Me.RadGrid1.Rebind()
                    Catch ex As Exception
                    End Try
                End If
            ElseIf param = "actualizaDet" Then
                Session("sessionHitoId") = indicador
                Me.RadGridImagen.Rebind()
            End If

        End If
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
            Dim acuerdoIDg As Integer = item("acuerdoID").Text
            Dim hitdoId As Integer = item("hitdoId").Text
            Dim estadoRegistro As Integer = item("estadoRegistro").Text
            Dim eliminaHito As ImageButton = item.FindControl("eliminaHito")
            Dim edita_img As ImageButton = item.FindControl("edita")

            Dim avance As ImageButton = item.FindControl("TCAvance")


            eliminaHito.Attributes.Add("onClick", "return deleteAvan('" + hitdoId.ToString + "','" + estadoRegistro.ToString + "');")
            edita_img.Attributes.Add("onClick", "return frmHitoN('" + hitdoId.ToString + "');")
            avance.Attributes.Add("onClick", "return frmAvanceN2('" + acuerdoIDg.ToString + "','" + hitdoId.ToString + "','" + estadoRegistro.ToString + "'); return true;")
        Next
    End Sub

    Private Sub RadGridImagen_ItemDataBound(ByVal sender As Object, e As GridItemEventArgs) Handles RadGridImagen.ItemDataBound
        For Each item As GridDataItem In RadGridImagen.Items
            Dim evidenciaurl As String = item("evidencia").Text
            Dim avanceId As Integer = item("avanceId").Text

            Dim evidencia As ImageButton = item.FindControl("TCEvidencia")

            If evidenciaurl.Length <> 0 Then
                evidencia.Attributes.Add("onClick", "return frmEvidencia('" + avanceId.ToString + "','evidencia/" + evidenciaurl.ToString + "'); return true;")
            End If
        Next
    End Sub
End Class