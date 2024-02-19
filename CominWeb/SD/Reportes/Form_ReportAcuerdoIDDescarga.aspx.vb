Imports CominWeb.SW_coneccionDB
Imports System.Threading
Imports System.Globalization
Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Net.Mail


Public Class Form_ReportAcuerdoIDDescarga
    Inherits System.Web.UI.Page
    'Dim SW_ordenesTrabajoDA As New SW_ordenesTrabajo_DA
    Dim SW_EjecutaSQLDA As New SW_EjecutaSQL_DA
    'Dim CabeceraDT, detalleDT, detalleDT2, detalleDT3, detalleDT4 As New DataTable, detalleDT5 As New DataTable

    Dim sw_asistente_DT As New DataTable
    Dim sw_acuerdo As New SW_pedido_DA

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        Call ReporteDownload()
    End Sub


    Private Sub ReporteDownload()
        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        Dim bytes As Byte()

        If Me.Request.QueryString("eventoId").ToString.Trim.Length > 0 Then
            'SW_ordenesPagoDT = SW_ordenesPagoDA.SWP_selectOrdenPagos(Me.Request.QueryString("OrdenPagoID").ToString.Trim, 0, "01/01/2000", "01/01/2000", 0, "0,1,2,3", 0, 0, 0, 0)
            sw_asistente_DT = sw_acuerdo.SD_P_selectListAcuerdoExport(0, Me.Request.QueryString("eventoId").ToString, Me.Request.QueryString("grupoId").ToString, Me.Request.QueryString("departamento").ToString, Me.Request.QueryString("ubigeo").ToString, "", 0, 0, 0)

            If Not sw_asistente_DT Is Nothing AndAlso Not sw_asistente_DT.Rows.Count = 0 Then



                Dim oReport1 As New ReportDataSource("DS_acuerdosExport", sw_asistente_DT)

                ReportViewer1.LocalReport.DataSources.Clear()

                ReportViewer1.LocalReport.DataSources.Add(oReport1)


                'ReportViewer1.LocalReport.Refresh()

                'Dim P As ReportParameter
                ''Dim P1 As ReportParameter
                ''Dim P2 As ReportParameter
                ''Dim P3 As ReportParameter
                ''Dim P4 As ReportParameter

                'P = New ReportParameter("RP_tipoCambio", CabeceraDT.Rows(0).Item(13).ToString, True)
                ''P1 = New ReportParameter("igvRP", Request.QueryString("igv"), True)
                ''P2 = New ReportParameter("montoTotalRP", Request.QueryString("total"), True)
                ''P3 = New ReportParameter("montoLetrasRP", Request.QueryString("letras"), True)
                ''P4 = New ReportParameter("abreviaturaRP", Request.QueryString("abreviatura"), True)

                'ReportViewer1.LocalReport.SetParameters(P)

                ReportViewer1.LocalReport.Refresh()

                bytes = ReportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

                Dim fs As New FileStream(("C:\fichas\Acuerdos.pdf"), FileMode.Create)
                fs.Write(bytes, 0, bytes.Length)
                fs.Close()
                Call DescargaReporte()
                ReportViewer1.Visible = False
            End If
        End If
    End Sub
    Private Sub DescargaReporte()
        Dim file As New FileInfo("C:\fichas\Acuerdos.pdf")
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
        HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString())
        HttpContext.Current.Response.ContentType = "application/octet-stream"
        HttpContext.Current.Response.WriteFile(file.FullName)
        HttpContext.Current.Response.End()
        Exit Sub
    End Sub
End Class