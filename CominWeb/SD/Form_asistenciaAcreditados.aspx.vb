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


Public Class Form_asistenciaAcreditados
    Inherits System.Web.UI.Page

    Dim sw_asistente_DT As New DataTable
    Dim sw_mancomu_DT As New DataTable
    Dim sw_asistente As New SW_SD_asistente_DA

    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_asistenciaAcreditados_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request.QueryString("gjXtIkEroS").ToString = "SD_SSFD" Then
            variableGlobalConexion.nombreCadenaCnx = "SD_CS"
            SDS_P_SelectEventos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectGrupos.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_P_SelectDocumento.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            SDS_SD_P_selectMancomunidades.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
            mancomunidadCB.Filter = RadComboBoxFilter.Contains

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
            ' nroDocTB.Focus()
            'Me.apePaternoTB.Enabled = False
            'Me.apeMaternoTB.Enabled = False
            'Me.nombresTB.Enabled = False
            'Me.cargoTB.Enabled = False
            'Me.telefonoTB.Enabled = False
            'Me.emailTB.Enabled = False
            'Me.mancomunidadCB.Enabled = False
            'nuevoB.Enabled = False
            If Request.QueryString("EROASLKDSENIN").ToString = "8082" Then
                tituloLB.Text = "VALIDACIÓN DE ACREDITADOS"
                nuevoB.Visible = False
            Else
                nuevoB.Visible = True
                tituloLB.Text = "REGISTRO DE ACREDITADOS"
            End If

            ViewState("id") = 0
        End If
    End Sub

    'Protected Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click
    '    busca(nroDocTB.Text.ToString.Trim)
    'End Sub

    Protected Sub nuevoB_Click(sender As Object, e As EventArgs) Handles nuevoB.Click
        Dim cad As String = ""
        cad = " exec SD_P_crearUpdateAcreditado " & ViewState("id").ToString & ", " & cbo_tipoDocumento.SelectedValue.ToString & ", '" & nroDocTB.Text.ToString & "','" & apePaternoTB.Text.ToString & "','" &
                apeMaternoTB.Text.ToString & "','" & nombresTB.Text.ToString & "','" & cargoTB.Text.ToString & "'," & cbo_evento.SelectedValue & "," & mancomunidadCB.SelectedValue &
                ",'" & telefonoTB.Text & "','" & emailTB.Text & "', " & grupoCB.SelectedValue

        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
                ViewState("id") = 0
            Catch ex As Exception
            End Try
        End If
        'Me.tituloLB.ForeColor = Color.Black
        'Me.tituloLB.Text = "BIENVENIDO! " & apePaternoTB.Text.ToString & " " & apeMaternoTB.Text.ToString & " " & nombresTB.Text.ToString
        Me.apePaternoTB.Text = ""
        Me.apeMaternoTB.Text = ""
        Me.nombresTB.Text = ""
        Me.nroDocTB.Text = ""
        Me.cargoTB.Text = ""
        Me.telefonoTB.Text = ""
        Me.emailTB.Text = ""
        'Me.apePaternoTB.Enabled = False
        'Me.apeMaternoTB.Enabled = False
        'Me.nombresTB.Enabled = False
        ''nuevoB.Enabled = True
        'Me.cargoTB.Enabled = False
        'Me.mancomunidadCB.Enabled = False
        'Me.telefonoTB.Enabled = False
        'Me.emailTB.Enabled = False
        'nroDocTB.Focus()
    End Sub

    Private Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument.ToString = "buscaJQ" Then
            busca(nroDocTB.Text.ToString.Trim)
        End If
    End Sub

    Private Sub busca(ByVal num As String)
        If num.ToString.Length < 6 Then
            'Me.tituloLB.ForeColor = Color.Red
            'Me.tituloLB.Text = "INGRESE UN VALOR VALIDO"
            Me.apePaternoTB.Text = ""
            Me.apeMaternoTB.Text = ""
            Me.nombresTB.Text = ""
            Me.cargoTB.Text = ""
            Me.telefonoTB.Text = ""
            Me.emailTB.Text = ""
            'Me.apePaternoTB.Enabled = False
            'Me.apeMaternoTB.Enabled = False
            'Me.nombresTB.Enabled = False
            'Me.cargoTB.Enabled = False
            'Me.mancomunidadCB.Enabled = False
            ''nuevoB.Enabled = False
            'Me.telefonoTB.Enabled = False
            'Me.emailTB.Enabled = False
        Else
            'Me.tituloLB.ForeColor = Color.Black
            sw_asistente_DT = sw_asistente.SD_P_selectAsistentes(9, 0, num.ToString, "", 0)
            If sw_asistente_DT.Rows.Count <> 0 Then
                'Me.tituloLB.Text = "BIENVENIDO! "
                Me.apePaternoTB.Text = sw_asistente_DT.Rows(0).Item(3).ToString
                Me.apeMaternoTB.Text = sw_asistente_DT.Rows(0).Item(4).ToString
                Me.nombresTB.Text = sw_asistente_DT.Rows(0).Item(5).ToString
                Me.cargoTB.Text = sw_asistente_DT.Rows(0).Item(6).ToString
                Me.telefonoTB.Text = sw_asistente_DT.Rows(0).Item(9).ToString
                Me.emailTB.Text = sw_asistente_DT.Rows(0).Item(10).ToString
                ViewState("id") = sw_asistente_DT.Rows(0).Item(0).ToString

                sw_mancomu_DT = sw_asistente.SD_P_selectMancomunidades(0, sw_asistente_DT.Rows(0).Item(7).ToString)
                mancomunidadCB.SelectedValue = sw_mancomu_DT.Rows(0).Item(0).ToString
                mancomunidadCB.DataBind()

                grupoCB.SelectedValue = sw_asistente_DT.Rows(0).Item(11).ToString
                grupoCB.DataBind()

                Me.apePaternoTB.Enabled = True
                Me.apeMaternoTB.Enabled = True
                Me.nombresTB.Enabled = True
                Me.cargoTB.Enabled = True
                Me.mancomunidadCB.Enabled = True
                Me.telefonoTB.Enabled = True
                Me.emailTB.Enabled = True
                Me.grupoCB.Enabled = True
                'nuevoB.Enabled = True
                Dim cad As String = ""
                cad = " exec SD_P_crearUpdateAcreditadoAct " & ViewState("id")

                If cad.Length > 0 Then
                    Try
                        Me.sw_ejecutaSQL.querySQL(cad)
                    Catch ex As Exception
                    End Try
                End If

            ElseIf sw_asistente_DT.Rows.Count = 0 Then
                'Me.tituloLB.Text = "REGISTRAR NUEVO ASISTENTE"
                Me.apePaternoTB.Text = ""
                Me.apeMaternoTB.Text = ""
                Me.nombresTB.Text = ""
                Me.cargoTB.Text = ""
                Me.telefonoTB.Text = ""
                Me.emailTB.Text = ""
                mancomunidadCB.SelectedValue = 0
                mancomunidadCB.DataBind()
                Me.apePaternoTB.Enabled = True
                Me.apeMaternoTB.Enabled = True
                Me.nombresTB.Enabled = True
                Me.grupoCB.Enabled = True
                Me.cargoTB.Enabled = True
                Me.mancomunidadCB.Enabled = True
                Me.telefonoTB.Enabled = True
                Me.emailTB.Enabled = True
                apePaternoTB.Focus()
            End If
        End If
    End Sub


    'Protected Sub exportarB_Click(sender As Object, e As EventArgs) Handles exportarB.Click
    '    CreateExcelFile()
    'End Sub
    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()
        Dim sl As New SLDocument()
        sl.SetCellValue(1, 1, "EVENTO")
        sl.SetCellValue(1, 2, "DNI")
        sl.SetCellValue(1, 3, "PATERNO")
        sl.SetCellValue(1, 4, "MATERNO")
        sl.SetCellValue(1, 5, "NOMBRES")
        sl.SetCellValue(1, 6, "FECHA")
        sl.SetCellValue(1, 7, "MANCOMUNIDAD")
        sl.SetCellValue(1, 8, "TELEFONO")
        sl.SetCellValue(1, 9, "EMAIL")

        Dim stilo As SLStyle = sl.CreateStyle()
        stilo.Font.FontName = "Calibri"
        stilo.Font.FontSize = 9
        stilo.Font.Bold = True
        stilo.FormatCode = "12345.678909"
        stilo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)

        sl.SetColumnWidth(1, 9, 15)

        'Dim styleNum As SLStyle = sl.CreateStyle()
        'styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
        'styleNum.FormatCode = "#,##0.00"
        'sl.SetColumnStyle(12, 16, styleNum)

        Dim styleCon As SLStyle = sl.CreateStyle()
        styleCon.Font.FontSize = 9
        sl.SetColumnStyle(1, 9, styleCon)

        sl.SetRowStyle(1, 1, stilo)

        Dim rowIndex As Integer = 2
        Dim columnIndex As Integer = 1


        sw_asistente_DT = sw_asistente.SD_P_selectAsistentesListExport("01/01/2000", "01/01/2000", 0, "", "", cbo_evento.SelectedValue)

        If sw_asistente_DT.Rows.Count > 0 Then
            For fil As Integer = 0 To sw_asistente_DT.Rows.Count - 1
                For i As Integer = 0 To sw_asistente_DT.Columns.Count - 1
                    If i > 10 Then
                        sl.SetCellValue(rowIndex, columnIndex, Convert.ToDecimal(sw_asistente_DT.Rows(fil)(i)))
                    Else
                        sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(sw_asistente_DT.Rows(fil)(i).ToString()))
                    End If
                    columnIndex += 1
                Next
                rowIndex += 1
                columnIndex = 1
            Next
            sl.SaveAs("C:/fichas/asistentes.xlsx")
            Dim file As New FileInfo("C:/fichas/asistentes.xlsx")

            ' guarda
            If (file.Exists) Then
                Response.Clear()
                Response.AddHeader("Content-disposition", "attachment; filename=asistentes.xlsx")
                Response.ContentType = "application/vnd.ms-excel"
                Response.WriteFile(file.ToString())
                Response.End()
            End If

        End If
    End Sub

End Class