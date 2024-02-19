Imports CominWeb.SW_coneccionDB
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading
Imports SpreadsheetLight
Imports System.IO
Imports System.Net
Imports DocumentFormat.OpenXml
Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient

Public Class Form_AM001
    Inherits System.Web.UI.Page

    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA
    Dim sw_SSFD As New SW_SSFD_DA
    Dim ssfdDT As New DataTable

    Private Sub Form_AM001_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Request.QueryString("gjXtIkEroS").ToString = "eninbWFudWNjfsdDWqWSDFsdWWaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "SSFD_TransCS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        SDS_P_selectDistrito.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectProvincia.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        SDS_P_selectPCB.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        Session("usuarioID") = Request.QueryString("usrin").ToString

        If Page.IsPostBack = False Then

        End If

    End Sub


    'Protected Sub btn_desconectarme_Click(sender As Object, e As EventArgs) Handles btn_desconectarme.Click
    '    Session("usuarioLoginID") = Nothing
    '    Session("NombreUsuarioLogin") = Nothing
    '    Session("IDSucursalPrincipal") = Nothing
    '    Session("nombreSucursalPrincipal") = Nothing
    '    Session("usuarioLoginIDsuperAdmin") = Nothing
    '    Session("almacenAsignadoPrincipal") = Nothing
    '    Session("esSuperAdminUser") = Nothing
    '    Session("tipoCambioCompraSession") = Nothing
    '    Session("tipoCambioVentaSession") = Nothing
    '    Response.Redirect("~/Account/LoginOperador.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString)
    'End Sub


    'Protected Sub volverB_Click(sender As Object, e As EventArgs) Handles volverB.Click
    '    Response.Redirect("~/operador/Form_checkListOp.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString +
    '                            "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
    '                            "&usuaL=" + Session("usuarioLoginID").ToString +
    '                              "&nomusuaL=" + Session("NombreUsuarioLogin").ToString +
    '                              "&idsucp=" + Session("IDSucursalPrincipal").ToString +
    '                              "&nosucp=" + Session("nombreSucursalPrincipal").ToString +
    '                              "&almpri=" + Session("almacenAsignadoPrincipal").ToString +
    '                              "&essadm=" + Session("esSuperAdminUser").ToString)
    'End Sub

    Private Sub RadGrid1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.DataBound
        For Each item As GridDataItem In RadGrid1.Items
            Dim currentRow As DataRowView = DirectCast(item.DataItem, DataRowView)
            Dim pcbId As Integer = currentRow.Row("pcbId").ToString
            Dim Link As HyperLink = item.FindControl("LinkProyecto")


            Dim LinkSituacion As HyperLink = item.FindControl("LinkSituacion")
            Dim LinkSituacionProblema As HyperLink = item.FindControl("LinkSituacionProblema")
            Dim LinkH1 As HyperLink = item.FindControl("LinkH1")
            Dim LinkH2 As HyperLink = item.FindControl("LinkH2")
            Dim LinkH3 As HyperLink = item.FindControl("LinkH3")
            Dim LinkH4 As HyperLink = item.FindControl("LinkH4")

            Dim HId1 As String = currentRow.Row("HId1").ToString
            Dim HId2 As String = currentRow.Row("HId2").ToString
            Dim HId3 As String = currentRow.Row("HId3").ToString
            Dim HId4 As String = currentRow.Row("HId4").ToString
            Dim sitId As String = currentRow.Row("sitId").ToString
            Dim sitProId As String = currentRow.Row("sitProId").ToString
            Dim ubigeoID As String = currentRow.Row("ubigeoID").ToString

            Link.Text = currentRow.Row("nombre_proyecto").ToString
            Link.ToolTip = currentRow.Row("nombre_proyecto").ToString
            If Link.Text.Length > 30 Then
                Link.Text = Link.Text.Remove(30) + "..."
            End If
            Link.Font.Bold = True
            Link.NavigateUrl = "#"

            LinkSituacion.Text = currentRow.Row("nSituacion").ToString
            LinkSituacion.ToolTip = currentRow.Row("nSituacion").ToString
            If LinkSituacion.Text.Length > 30 Then
                LinkSituacion.Text = LinkSituacion.Text.Remove(30) + "..."
            End If
            LinkSituacion.Font.Bold = True
            LinkSituacion.NavigateUrl = "#"

            LinkSituacionProblema.Text = currentRow.Row("nSituacionProblema").ToString
            LinkSituacionProblema.ToolTip = currentRow.Row("nSituacionProblema").ToString
            If LinkSituacionProblema.Text.Length > 30 Then
                LinkSituacionProblema.Text = LinkSituacionProblema.Text.Remove(30) + "..."
            End If
            LinkSituacionProblema.Font.Bold = True
            LinkSituacionProblema.NavigateUrl = "#"

            LinkH1.Text = currentRow.Row("H1").ToString
            LinkH1.ToolTip = currentRow.Row("H1").ToString
            If LinkH1.Text.Length > 30 Then
                LinkH1.Text = LinkH1.Text.Remove(30) + "..."
            End If
            LinkH1.Font.Bold = True
            LinkH1.NavigateUrl = "#"

            LinkH2.Text = currentRow.Row("H2").ToString
            LinkH2.ToolTip = currentRow.Row("H2").ToString
            If LinkH2.Text.Length > 30 Then
                LinkH2.Text = LinkH2.Text.Remove(30) + "..."
            End If
            LinkH2.Font.Bold = True
            LinkH2.NavigateUrl = "#"

            LinkH3.Text = currentRow.Row("H3").ToString
            LinkH3.ToolTip = currentRow.Row("H3").ToString
            If LinkH3.Text.Length > 30 Then
                LinkH3.Text = LinkH3.Text.Remove(30) + "..."
            End If
            LinkH3.Font.Bold = True
            LinkH3.NavigateUrl = "#"

            LinkH4.Text = currentRow.Row("H4").ToString
            LinkH4.ToolTip = currentRow.Row("H4").ToString
            If LinkH4.Text.Length > 30 Then
                LinkH4.Text = LinkH4.Text.Remove(30) + "..."
            End If
            LinkH4.Font.Bold = True
            LinkH4.NavigateUrl = "#"

            Dim editar As Image = DirectCast(item("edita").FindControl("Editar"), Image)
            Dim situacion As Image = DirectCast(item("situacio").FindControl("situacion"), Image)
            Dim situacPro As Image = DirectCast(item("situacP").FindControl("situacPro"), Image)
            Dim hito As Image = DirectCast(item("hito").FindControl("hitos"), Image)

            editar.Attributes.Add("OnClick", "modPCB('" & pcbId & "','" & Me.Request.QueryString("gjXtIkEroS") & "','" & HId1.ToString & "','" & HId2.ToString & "','" & HId3.ToString & "','" & HId4.ToString & "','" & sitId.ToString & "','" & sitProId.ToString & "','" & ubigeoID & "')")
            situacion.Attributes.Add("OnClick", "frmsituacion('" & pcbId.ToString & "','" & Me.Request.QueryString("gjXtIkEroS") & "');")
            situacPro.Attributes.Add("OnClick", "frmsituacionproblematica('" & pcbId.ToString & "','" & Me.Request.QueryString("gjXtIkEroS") & "');")
            hito.Attributes.Add("OnClick", "frmhitos('" & pcbId.ToString & "','" & Me.Request.QueryString("gjXtIkEroS") & "');")
        Next
    End Sub

    Protected Sub provinciaCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles provinciaCB.SelectedIndexChanged
        distritoCB.DataBind()
    End Sub

    Protected Sub buscar2_Click(sender As Object, e As EventArgs) Handles buscar2.Click
        RadGrid1.Rebind()
    End Sub

    Protected Sub exp126B_Click(sender As Object, e As EventArgs) Handles exp126B.Click
        CreateExcelFile()
    End Sub


    '*************************** EXPORTAR **************************************************
    '***************************************************************************************
    Private Sub CreateExcelFile()
        Dim sl As New SLDocument()
        sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "DU_126")
        sl.SetCellValue(1, 1, "PLIEGO")
        sl.SetCellValue(1, 2, "PCBID")
        sl.SetCellValue(1, 3, "ID_DS")
        sl.SetCellValue(1, 4, "CU")
        sl.SetCellValue(1, 5, "PROYECTO")
        sl.SetCellValue(1, 6, "DU 126")
        sl.SetCellValue(1, 7, "REGION")
        sl.SetCellValue(1, 8, "PROVINCIA")
        sl.SetCellValue(1, 9, "DISTRITO")
        sl.SetCellValue(1, 10, "CCPP")
        sl.SetCellValue(1, 11, "NDD")
        sl.SetCellValue(1, 12, "PRODUCTO")
        sl.SetCellValue(1, 13, "HITO 1")
        sl.SetCellValue(1, 14, "HITO 2")
        sl.SetCellValue(1, 15, "HITO 3")
        sl.SetCellValue(1, 16, "HITO 4")
        sl.SetCellValue(1, 17, "SITUACION")
        sl.SetCellValue(1, 18, "PROBLEMATICA")

        Dim stilo As SLStyle = sl.CreateStyle()
        stilo.Font.FontName = "Calibri"
        stilo.Font.FontSize = 9
        stilo.Font.Bold = True
        stilo.FormatCode = "12345.678909"
        stilo.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Center)

        sl.SetColumnWidth(1, 4, 6)
        sl.SetColumnWidth(5, 5, 50)
        sl.SetColumnWidth(6, 7, 10)
        sl.SetColumnWidth(8, 12, 25)
        sl.SetColumnWidth(13, 18, 60)

        Dim styleNum As SLStyle = sl.CreateStyle()
        styleNum.SetHorizontalAlignment(Spreadsheet.HorizontalAlignmentValues.Right)
        styleNum.FormatCode = "#,##0.00"
        sl.SetColumnStyle(3, 4, styleNum)

        Dim styleCon As SLStyle = sl.CreateStyle()
        styleCon.Font.FontSize = 9
        sl.SetColumnStyle(1, 18, styleCon)

        sl.SetRowStyle(1, 1, stilo)

        Dim rowIndex As Integer = 2
        Dim columnIndex As Integer = 1

        ssfdDT = sw_SSFD.P_selectPCB126(0, txtCU.Text.ToString, txtSNIP.Text.ToString, txtProyecto.Text.ToString, "", "")

        If ssfdDT.Rows.Count > 0 Then
            For fil As Integer = 0 To ssfdDT.Rows.Count - 1
                For i As Integer = 0 To ssfdDT.Columns.Count - 1
                    If i = 5 Or i = 2 Or i = 1 Then
                        sl.SetCellValue(rowIndex, columnIndex, Convert.ToDecimal(ssfdDT.Rows(fil)(i)))
                    Else
                        sl.SetCellValue(rowIndex, columnIndex, Convert.ToString(ssfdDT.Rows(fil)(i).ToString()))
                    End If
                    columnIndex += 1
                Next
                rowIndex += 1
                columnIndex = 1
            Next

            sl.SaveAs("C:/fichas/DU126_" & Date.Now.ToString("dd-MM-yyyy") & ".xlsx")
            Dim file As New FileInfo("C:/fichas/DU126_" & Date.Now.ToString("dd-MM-yyyy") & ".xlsx")

            ' guarda
            If (file.Exists) Then
                Response.Clear()
                Response.AddHeader("Content-disposition", "attachment; filename=DU126_" & Date.Now.ToString("dd-MM-yyyy") & ".xlsx")
                Response.ContentType = "application/vnd.ms-excel"
                Response.WriteFile(file.ToString())
                Response.End()
            End If

        End If
    End Sub

    '*************************** EXPORTAR **************************************************
    '***************************************************************************************


End Class