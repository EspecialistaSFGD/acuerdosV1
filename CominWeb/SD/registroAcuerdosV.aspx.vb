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

Public Class registroAcuerdosV
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroAcuerdosV_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_selectDepartamento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectAcuerdos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        'sectorTB.Text = Me.Request.QueryString("secto").ToString
        'Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        'tituloLB.Text = Request.QueryString("nosucp").ToString

        If Page.IsPostBack = False Then
            If Me.Request.QueryString("codigoid").ToString > 0 Then
                Session("pedido") = Me.Request.QueryString("codigoid").ToString()
                SW_pedidoDT = SW_pedidoDA.SD_P_selectPrioridadAcuerdo(Me.Request.QueryString("codigoid").ToString, 0, 0, 0, 0)
                If SW_pedidoDT.Rows.Count > 0 Then

                    grupoCB.SelectedValue = SW_pedidoDT.Rows(0).Item(3)
                    grupoCB.DataBind()

                    cbo_departamento1.SelectedValue = SW_pedidoDT.Rows(0).Item(12)
                    cbo_departamento1.DataBind()

                    cbo_provincia1.SelectedValue = SW_pedidoDT.Rows(0).Item(13)
                    cbo_provincia1.DataBind()

                    Me.prioridadTerritorialTB.Text = SW_pedidoDT.Rows(0).Item(8)
                    Me.objetivoTB.Text = SW_pedidoDT.Rows(0).Item(9)
                    Me.intervencionTB.Text = SW_pedidoDT.Rows(0).Item(10)
                    Me.aspectoTB.Text = SW_pedidoDT.Rows(0).Item(11)
                    Me.cuisTB.Text = SW_pedidoDT.Rows(0).Item(14)

                    grupoCB.Enabled = False
                    cbo_departamento1.Enabled = False
                    cbo_provincia1.Enabled = False
                    prioridadTerritorialTB.Enabled = False
                    objetivoTB.Enabled = False
                    intervencionTB.Enabled = False
                    'aspectoTB.Enabled = False

                    'Me.ultimaActualizacionLB.Text = SW_ordenesTrabajoDT.Rows(0).Item(44)
                    'Me.txtot.Text = SW_ordenesTrabajoDT.Rows(0).Item(1).ToString.Trim

                    'Me.cbo_turno.Selecte dValue = SW_ordenesTrabajoDT.Rows(0).Item(37).ToString
                    'Me.cbo_turno.DataBind()
                    'Me.fechacreacionRDP.SelectedDate = SW_ordenesTrabajoDT(0).Item(3).ToString.Trim
                    'monedaCB.SelectedValue = SW_ordenesTrabajoDT(0).Item(58)
                    'monedaCB.DataBind()
                    'tipoCambio()
                    'Me.txtnotas.Text = SW_ordenesTrabajoDT.Rows(0).Item(27).ToString.Trim

                End If
            Else
                Session("pedido") = 0
                If Me.Request.QueryString("codsector").ToString > 0 Then
                    grupoCB.SelectedValue = Me.Request.QueryString("codsector").ToString
                    grupoCB.DataBind()
                    grupoCB.Enabled = False
                Else
                    grupoCB.Enabled = True
                End If

                cbo_departamento1.Enabled = True
                cbo_provincia1.Enabled = True
                prioridadTerritorialTB.Enabled = True
                objetivoTB.Enabled = True
                intervencionTB.Enabled = True
                'aspectoTB.Enabled = True

                'Me.fechacreacionRDP.SelectedDate = Date.Now
                'tipoCambioTB.Text = "1"
                'valorTC3.Value = Session("tipoCambioVentaSession")
                'Me.horaTP.SelectedTime = Date.Now.TimeOfDay
                'generaCodigoDT = sw_ejecutaSQL.P_GeneradorCodigos(1, "COT")
                'txtot.Text = generaCodigoDT.Rows(0).Item(0)
                'clienteDefault = sw_ejecutaSQL.P_selectParametroByID(70)
                'If clienteDefault.Rows(0).Item(2) = 1 Then
                '    txtRazonSocialID.Text = clienteDefault.Rows(0).Item(3)
                '    DatosCliente()
                'End If
            End If
        End If
    End Sub

    Protected Sub retornarB_Click(sender As Object, e As EventArgs) Handles retornarB.Click
        If Session("pedido") = 0 Then
            Response.Redirect("~/SD/prioridadesAcuerdosV.aspx?lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                    "&gjXtIkEroS=SD_SSFD&codsector=" & Me.Request.QueryString("codsector").ToString)
        Else
            Dim codigoid As String = SW_pedidoDA.SD_P_crearUpdatePrioridadAcuerdo(Session("pedido"), Me.Request.QueryString("codevento").ToString,
grupoCB.SelectedValue, cbo_provincia1.SelectedValue, prioridadTerritorialTB.Text.ToString.Trim, objetivoTB.Text.ToString.Trim, intervencionTB.Text.ToString.Trim, aspectoTB.Text.ToString.Trim, cuisTB.Text.ToString.Trim)
            Response.Redirect("~/SD/prioridadesAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                                    "&gjXtIkEroS=SD_SSFD&codsector=" & Me.Request.QueryString("codsector").ToString)
            'If Session("pedido") = 0 Then
            '    Session("pedido") = codigoid
            'End If
        End If
        Try


        Catch ex As Exception
        End Try
    End Sub


    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "frmacuerdo" Then
            frmacuerdo()
        Else
            Dim i As Integer
            Dim idAcuerdo As Integer
            Dim param As String = ""
            Dim a() As String = e.Argument.Split(",")
            Dim cadJS As String = ""
            For i = 0 To 1
                If i = 0 Then
                    param = a(0)
                ElseIf i = 1 Then
                    idAcuerdo = a(1)
                End If
            Next
            If param = "desactivAcuerdo" Then
                cadJS = " UPDATE SD_tblAcuerdos SET estado = 0 WHERE acuerdoID = " & idAcuerdo.ToString
                Me.sw_ejecutaSQL.querySQL(cadJS)
                Me.RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub frmacuerdo()
        If grupoCB.SelectedValue = 0 Then
            mensajeJSS("Seleccione SECTOR")
        ElseIf cbo_provincia1.SelectedValue = 0 Then
            mensajeJSS("Seleccione PROVINCIA")
        ElseIf intervencionTB.Text.ToString.Trim.Length < 5 Then
            mensajeJSS("Ingrese INTERVENCIÓN ESTRATÉGICA")
        ElseIf aspectoTB.Text.ToString.Trim.Length < 5 Then
            mensajeJSS("Ingrese ASPECTO CRÍTICO")
        Else
            Dim codigoid As String = SW_pedidoDA.SD_P_crearUpdatePrioridadAcuerdo(Session("pedido"), Me.Request.QueryString("codevento").ToString,
            grupoCB.SelectedValue, cbo_provincia1.SelectedValue, prioridadTerritorialTB.Text.ToString.Trim, objetivoTB.Text.ToString.Trim, intervencionTB.Text.ToString.Trim, aspectoTB.Text.ToString.Trim, cuisTB.Text.ToString.Trim)
            Session("pedido") = codigoid
            If codigoid <> 0 Then
                Dim cadena_java As String
                cadena_java = "<script type='text/javascript'> " &
                                  " frmacuerdoN('" & codigoid.ToString & "'); " &
                                  Chr(60) & "/script>"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "frmacuerdoN", cadena_java.ToString, False)
            End If
        End If
    End Sub
    'Protected Sub exportarB_Click(sender As Object, e As EventArgs) Handles exportarB.Click
    '    CreateExcelFile()
    'End Sub
    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()
        'Dim sl As New SLDocument()
        'sl.SetCellValue(1, 1, "EVENTO")
        'sl.SetCellValue(1, 2, "DNI")
        'sl.SetCellValue(1, 3, "PATERNO")
        'sl.SetCellValue(1, 4, "MATERNO")
        'sl.SetCellValue(1, 5, "NOMBRES")
        'sl.SetCellValue(1, 6, "FECHA")
        'sl.SetCellValue(1, 7, "MANCOMUNIDAD")
        'sl.SetCellValue(1, 8, "TELEFONO")
        'sl.SetCellValue(1, 9, "EMAIL")

        'Dim stilo As SLStyle = sl.CreateStyle()
        'stilo.Font.FontName = "Calibri"
        'stilo.Font.FontSize = 9
        'stilo.Font.Bold = True
        'stilo.FormatCode = "12345.678909"
        'stilo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)

        'sl.SetColumnWidth(1, 9, 15)

        ''Dim styleNum As SLStyle = sl.CreateStyle()
        ''styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
        ''styleNum.FormatCode = "#,##0.00"
        ''sl.SetColumnStyle(12, 16, styleNum)

        'Dim styleCon As SLStyle = sl.CreateStyle()
        'styleCon.Font.FontSize = 9
        'sl.SetColumnStyle(1, 9, styleCon)

        'sl.SetRowStyle(1, 1, stilo)

        'Dim rowIndex As Integer = 2
        'Dim columnIndex As Integer = 1


        'sw_asistente_DT = sw_asistente.SD_P_selectAsistentesListExport("01/01/2000", "01/01/2000", 0, "", "", cbo_evento.SelectedValue)

        'If sw_asistente_DT.Rows.Count > 0 Then
        '    For fil As Integer = 0 To sw_asistente_DT.Rows.Count - 1
        '        For i As Integer = 0 To sw_asistente_DT.Columns.Count - 1
        '            If i > 10 Then
        '                sl.SetCellValue(rowIndex, columnIndex, Convert.ToDecimal(sw_asistente_DT.Rows(fil)(i)))
        '            Else
        '                sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(sw_asistente_DT.Rows(fil)(i).ToString()))
        '            End If
        '            columnIndex += 1
        '        Next
        '        rowIndex += 1
        '        columnIndex = 1
        '    Next
        '    sl.SaveAs("C:/fichas/asistentes.xlsx")
        '    Dim file As New FileInfo("C:/fichas/asistentes.xlsx")

        '    ' guarda
        '    If (file.Exists) Then
        '        Response.Clear()
        '        Response.AddHeader("Content-disposition", "attachment; filename=asistentes.xlsx")
        '        Response.ContentType = "application/vnd.ms-excel"
        '        Response.WriteFile(file.ToString())
        '        Response.End()
        '    End If

        'End If
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
            Dim prioridadID As Integer = item("prioridadID").Text
            Dim estado_img As ImageButton = item.FindControl("estadoAcuerdob")
            Dim edita_img As ImageButton = item.FindControl("edita")

            estado_img.Attributes.Add("onClick", "return desactivarProducto('" + acuerdoIDg.ToString + "');")
            edita_img.Attributes.Add("onClick", "return editaAcuerdo('" + acuerdoIDg.ToString + "','" + prioridadID.ToString + "');")
        Next
    End Sub
End Class