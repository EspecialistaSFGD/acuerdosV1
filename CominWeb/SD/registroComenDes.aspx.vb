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


Public Class registroComenDes
    Inherits System.Web.UI.Page

    Dim SW_pedidoDT As New DataTable
    Dim SW_pedidoDA As New SW_pedido_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub registroComenDes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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

        End If
    End Sub

    Protected Sub guardaB_Click(sender As Object, e As EventArgs) Handles guardaB.Click
        If acuerdoTB.Text.ToString.Trim.Length < 5 Then
            mensajeJSS("Ingrese Comentario")
        ElseIf acuerdoTB.Text.ToString.Trim.Length > 300 Then
            mensajeJSS("El comentario no puede tener mas de 300 caracteres")
        Else
            Dim path As String = Server.MapPath("~/SD/evidencia/")
            Dim fileOK As Boolean = False
            If FileUpload1.HasFile Then
                Dim fileExtension As String
                fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower()
                Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".bmp", ".pdf"}
                For i As Integer = 0 To allowedExtensions.Length - 1
                    If fileExtension = allowedExtensions(i) Then
                        fileOK = True
                    End If
                Next

                If fileOK Then
                    Try
                        FileUpload1.PostedFile.SaveAs(path & FileUpload1.FileName)
                        guardar(acuerdoTB.Text.ToString.Trim, FileUpload1.FileName.ToString, Me.Request.QueryString("codigoid"))
                    Catch ex As Exception
                        mensajeJSS("Error de Sistema, Comunicarse con el administrador")
                    End Try
                Else
                    mensajeJSS("No se acepta este tipo de archivos.")
                End If
            Else
                mensajeJSS("La evidencia es obligatoria.")
            End If



        End If

    End Sub


    Private Sub guardar(ByVal motivo As String, evidencia As String, acuerdo As Integer)

        Dim cad As String = ""
        cad = " UPDATE SD_tblAcuerdos SET fechaPedidoDesestimacion = getdate(), motivoDesestimacion = '" & motivo.ToString & "', evidenciaDesestimacion ='" & evidencia.ToString & "' where acuerdoID = " & acuerdo.ToString

        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
                sendMailA(acuerdo.ToString)
                cierraVentana()
            Catch ex As Exception
            End Try
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
            "<p>El " & Request.QueryString("enti").ToString() & " solicita <b>desestimar</b> el acuerdo " & Request.QueryString("codac").ToString() & ".</p>" &
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