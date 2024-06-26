﻿Imports CominWeb.SW_coneccionDB
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


Public Class registroComentario
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroComentario_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")

        If Page.IsPostBack = False Then
            'If Me.Request.QueryString("codac").ToString > 0 Then
            '    SW_pedidoDT = SW_pedidoDA.SD_P_selectAcuerdosV2(Me.Request.QueryString("codac").ToString, 0, "", 0, 0)
            '    If SW_pedidoDT.Rows.Count > 0 Then

            '        acuerdoTB.Text = SW_pedidoDT.Rows(0).Item(3)

            '        'Me.ultimaActualizacionLB.Text = SW_ordenesTrabajoDT.Rows(0).Item(44)
            '        'Me.txtot.Text = SW_ordenesTrabajoDT.Rows(0).Item(1).ToString.Trim

            '        'Me.cbo_turno.Selecte dValue = SW_ordenesTrabajoDT.Rows(0).Item(37).ToString
            '        'Me.cbo_turno.DataBind()
            '        'Me.fechacreacionRDP.SelectedDate = SW_ordenesTrabajoDT(0).Item(3).ToString.Trim
            '        'monedaCB.SelectedValue = SW_ordenesTrabajoDT(0).Item(58)
            '        'monedaCB.DataBind()
            '        'tipoCambio()
            '        'Me.txtnotas.Text = SW_ordenesTrabajoDT.Rows(0).Item(27).ToString.Trim

            '    End If
            'Else
            '    Me.plazoRDP.MinDate = Date.Now
            '    'Me.ultimaActualizacionLB.Text = Date.Now.ToString("dd/MM/yyyy")
            '    'Me.fechacreacionRDP.SelectedDate = Date.Now
            '    'tipoCambioTB.Text = "1"
            '    'valorTC3.Value = Session("tipoCambioVentaSession")
            '    'Me.horaTP.SelectedTime = Date.Now.TimeOfDay
            '    'generaCodigoDT = sw_ejecutaSQL.P_GeneradorCodigos(1, "COT")
            '    'txtot.Text = generaCodigoDT.Rows(0).Item(0)
            '    'clienteDefault = sw_ejecutaSQL.P_selectParametroByID(70)
            '    'If clienteDefault.Rows(0).Item(2) = 1 Then
            '    '    txtRazonSocialID.Text = clienteDefault.Rows(0).Item(3)
            '    '    DatosCliente()
            '    'End If
            'End If
        End If
    End Sub

    Protected Sub guardaB_Click(sender As Object, e As EventArgs) Handles guardaB.Click
        If acuerdoTB.Text.ToString.Trim.Length < 5 Then
            mensajeJSS("Ingrese Comentario")
        ElseIf acuerdoTB.Text.ToString.Trim.Length > 300 Then
            mensajeJSS("El comentario no puede tener mas de 300 caracteres")
        Else
            guardar(Me.Request.QueryString("codAv").ToString, acuerdoTB.Text.ToString.Trim, Me.Request.QueryString("tic"))
        End If
    End Sub


    Private Sub guardar(ByVal Id As String, comentario As String, tipo As Integer)

        Dim cad As String = ""
        If Me.Request.QueryString("tipo").ToString = "PRI" Then
            cad = " UPDATE SD_tblPrioridadAcuerdo SET comentarioPCM = '" & comentario & "', validado = 2 WHERE prioridadID = " & Id.ToString
        ElseIf Me.Request.QueryString("tipo").ToString = "HI" Then
            cad = " exec SD_P_crearUpdateAvance " & Id.ToString & ",0,0,'','','','" & comentario & "',0,0," & tipo.ToString & "," & Request.QueryString("iacp")
        End If

        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
                cierraVentana()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub cierraVentana()
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " CerrarVentana(1); " &
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

End Class