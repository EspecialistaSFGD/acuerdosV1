Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports System
Imports System.IO
Imports System.Net
Imports SpreadsheetLight
Imports DocumentFormat.OpenXml

Public Class Form_reuniones
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_reuniones_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Session("usuarioLoginID") = Nothing Then
        '    Response.Redirect("~/SD/Form_asistenciaListOp.aspx?gjXtIkEroS=SD_SSFD")
        'End If

        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"

            Dim validaDT As New DataTable
            validaDT = SW_pedidoDA.SD_P_selectAcceso(0, Request.QueryString("en").ToString, 9)
            If validaDT.Rows.Count = 1 Then
                SDS_P_selectDistrito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectListReuniones.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectEstadoTipo.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
                SDS_SD_P_selectSalas.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            Else
                variableGlobalConexion.nombreCadenaCnx = ""
                Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
            End If
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        'Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        'tituloLB.Text = Request.QueryString("nosucp").ToString

        If Page.IsPostBack = False Then
            'Session("entidadToken") = SW_pedidoDA.SD_P_selectEntidades(0, 0, 0, 0, SW_pedidoDA.SD_P_selectParametroByID(5).Rows(0).Item(2) & Me.Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0")).Rows(0).Item(0)
            Session("estadoFiltroReunion") = "0,1,2,3,4,"
            estadoCB.ToolTip = Session("estadoTextoAcuerdo")
            titulo2LB.Text = "Programa de Reuniones "
            'If Me.Request.QueryString("ksjcmj").ToString <> 0 Then
            '    SW_pedidoDT = SW_pedidoDA.SD_P_selectGrupos(Request.QueryString("ksjcmj").ToString, 0)
            cbo_departamento1.SelectedValue = 3
            cbo_departamento1.DataBind()
            cbo_departamento1.Enabled = False
            cbo_provincia1.DataBind()

            If Me.Request.QueryString("en") = 3402 Then
                grupoCB.Enabled = True
            Else
                If Me.Request.QueryString("sup") = 3 Then
                    grupoCB.Enabled = True
                Else
                    grupoCB.Enabled = False
                End If

            End If


            'ElseIf Me.Request.QueryString("ubig").ToString <> 0 Then
            'cbo_departamento1.SelectedValue = Me.Request.QueryString("de").ToString
            '    cbo_departamento1.DataBind()

            '    Dim ub As Integer = Right("00" & Request.QueryString("ubig"), 4)
            '    If ub > 0 Then
            '        cbo_provincia1.Items.Clear()
            '        cbo_provincia1.DataBind()
            '        cbo_provincia1.SelectedValue = Left(Right("00" & Request.QueryString("ubig"), 6), 4) & "01"
            '        cbo_provincia1.DataBind()

            '        'Dim dis As Integer = Right(Request.QueryString("ubig"), 2)
            '        'If dis > 1 Then
            '        cbo_distrito.Items.Clear()
            '        cbo_distrito.DataBind()
            '        cbo_distrito.SelectedValue = Request.QueryString("ubig")
            '        cbo_distrito.DataBind()

            '        'End If

            '    End If

            '    If Me.Request.QueryString("sup") = 3 Then
            '        cbo_departamento1.Enabled = True
            '        cbo_provincia1.Enabled = True
            '        cbo_distrito.Enabled = True
            '    Else
            '        cbo_departamento1.Enabled = False
            '        cbo_provincia1.Enabled = False
            '        cbo_distrito.Enabled = False
            '    End If


            'Else
            '    grupoCB.Enabled = True
            'End If

            'Me.RadGrid1.Rebind()
        End If
    End Sub

    Protected Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click


        Dim sb As New StringBuilder() '0
        Dim collection As IList(Of RadComboBoxItem) = estadoCB.CheckedItems
        If (collection.Count <> 0) Then
            Session("estadoFiltroReunion") = ""
            Session("estadoTextoAcuerdo") = ""
            'sb.Append("<h3>Checked Items:</h3><ul class=""results"">") '0
            For Each item As RadComboBoxItem In collection
                Session("estadoFiltroReunion") = Session("estadoFiltroReunion") & item.Value & ","
                Session("estadoTextoAcuerdo") = Session("estadoTextoAcuerdo") & item.Text & ","
                'sb.Append(item.Text + ", ") '0
            Next

            'sb.Append("</ul>") '0
            'estadoCB.Text = sb.ToString() '0

            If Session("estadoFiltroReunion").ToString.Trim.Length > 0 Then
                Session("estadoFiltroReunion") = Mid(Session("estadoFiltroReunion"), 1, Len(Session("estadoFiltroReunion")) - 1)
                Session("estadoTextoAcuerdo") = Mid(Session("estadoTextoAcuerdo"), 1, Len(Session("estadoTextoAcuerdo")) - 1)
            Else
                Session("estadoFiltroReunion") = "2"
                Session("estadoTextoAcuerdo") = "PENDIENTE"
            End If
            estadoCB.ToolTip = Session("estadoTextoAcuerdo")
        End If


        Me.RadGrid1.Rebind()



        ''Session("estadoFiltroReunion") = ""
        ''Dim sb As New StringBuilder()
        ''Dim collection As IList(Of RadComboBoxItem) = estadoCB.CheckedItems
        ''If (collection.Count <> 0) Then
        ''    For Each item As RadComboBoxItem In collection
        ''        Session("estadoFiltroReunion") = Session("estadoFiltroReunion") & item.Value & ","
        ''        sb.Append("<li>" + item.Text + "</li>")
        ''    Next

        ''    sb.Append("</ul>")
        ''    estadoCB.Text = sb.ToString()
        ''End If
        ''If Session("estadoFiltroReunion").ToString.Trim.Length > 0 Then
        ''    Session("estadoFiltroReunion") = Mid(Session("estadoFiltroReunion"), 1, Len(Session("estadoFiltroReunion")) - 1)
        ''Else
        ''    Session("estadoFiltroReunion") = "9"
        ''End If

    End Sub

    Private Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.DataBound
        For Each item As GridDataItem In RadGrid1.Items
            Dim currentRow As DataRowView = DirectCast(item.DataItem, DataRowView)
            Dim reunionID As Integer = currentRow.Row("reunionID").ToString
            Dim estadoRegistro As Integer = currentRow.Row("estadoRegistro")
            Dim bloqueada As Integer = currentRow.Row("Bloqueada")
            Dim valida As ImageButton = item.FindControl("TCValida")
            If bloqueada = 1 Then
                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/close24.png"
                valida.ToolTip = "Reunión Bloqueada"
                valida.Attributes.Add("onClick", "return mensaje('error', 'Reunión Bloqueada'); return true;")
            Else
                valida.ImageUrl = "https://sesigue.com/REFERENCIASBASE/Resources/open24.png"
                valida.ToolTip = "Reunión Abierta"
                valida.Attributes.Add("onClick", "return frmBloqueaReu('" + reunionID.ToString + "'); return true;")
            End If

            Dim Link As HyperLink = item.FindControl("nomEstado1Label")
            Dim est As String
            est = currentRow.Row("NomEstadoRegistro").ToString
            Link.Text = est

            If est = "EN PROCESO" Then
                Link.ForeColor = Drawing.Color.Green
            ElseIf est = "NO INICIADO" Then
                Link.ForeColor = Drawing.Color.Red
            ElseIf est = "FINALIZADO" Then
                Link.ForeColor = Drawing.Color.Black
            ElseIf est = "CANCELADO" Then
                Link.ForeColor = Drawing.Color.MediumBlue
            End If


            Link.Font.Bold = True
            Link.NavigateUrl = "#"
            Link.Attributes.Add("OnClick", "verreu('" & reunionID.ToString.Trim & "','" & estadoRegistro.ToString & "');")
        Next

    End Sub

    Protected Sub cbo_departamento1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_departamento1.SelectedIndexChanged
        cbo_provincia1.Items.Clear()
        cbo_provincia1.DataBind()
        cbo_distrito.Items.Clear()
        cbo_distrito.DataBind()
    End Sub


    Protected Sub cbo_provincia1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_provincia1.SelectedIndexChanged
        cbo_distrito.Items.Clear()
        cbo_distrito.DataBind()
    End Sub


    Public Function GetColor(ByVal est As String) As Drawing.Color
        Dim col As Drawing.Color
        If est = "INICIADO" Then
            col = Drawing.Color.Green
        ElseIf est = "NO INICIADO" Then
            col = Drawing.Color.Red
        ElseIf est = "FINALIZADO" Then
            col = Drawing.Color.Black
        ElseIf est = "CANCELADO" Then
            col = Drawing.Color.MediumBlue
        End If
        Return col
    End Function

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "actualiza" Then
            Session("estadoFiltroReunion") = ""
            Dim collection As IList(Of RadComboBoxItem) = estadoCB.CheckedItems
            If (collection.Count <> 0) Then
                For Each item As RadComboBoxItem In collection
                    Session("estadoFiltroReunion") = Session("estadoFiltroReunion") & item.Value & ","

                Next
            End If
            If Session("estadoFiltroReunion").ToString.Trim.Length > 0 Then
                Session("estadoFiltroReunion") = Mid(Session("estadoFiltroReunion"), 1, Len(Session("estadoFiltroReunion")) - 1)
            Else
                Session("estadoFiltroReunion") = "2"
            End If

        Else
            Dim i As Integer
            Dim indicador As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            For i = 0 To 1
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    indicador = a(1)
                End If
            Next
            If param = "frmBloqueaReu" Then
                Dim cad As String = ""
                cad = " UPDATE SD_tblReuniones set bloqueada = 1, fechaModifica = getdate(), usuarioModifica_accesoID = " & Me.Request.QueryString("iacp").ToString & " where reunionID = " & indicador

                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
        Me.RadGrid1.Rebind()
    End Sub

End Class

