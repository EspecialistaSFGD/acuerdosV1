Imports CominWeb.SW_coneccionDB
Imports System.Globalization
Imports System.Threading
Imports Telerik.Web.UI
Public Class Form_SituacionProblem
    Inherits System.Web.UI.Page
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA

    Private Sub Form_SituacionProblem_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Request.QueryString("gjXtIkEroS").ToString = "eninbWFudWNjfsdDWqWSDFsdWWaQ==" Then
            variableGlobalConexion.nombreCadenaCnx = "SSFD_TransCS"
        Else
            variableGlobalConexion.nombreCadenaCnx = ""
            Response.Redirect("~/Error/Oops.aspx?Ljbq7iMESelhIUIxzrV7j78eJD/0EFUR=INTRUSO")
        End If
        SDS_P_selectSituacion.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")
        If Page.IsPostBack = False Then
        End If

    End Sub

    Private Sub mensajeJSS(ByVal varIn As String)
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " mensaje('information','" & varIn.ToString & "'); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)
    End Sub

    Private Sub cierraVentana()
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " &
                          " CerrarVentana(1); " &
                          Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "CerrarVentana", cadena_java.ToString, False)
    End Sub

    Dim descripcionV As String
    Protected Sub RadGrid1_InsertCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.InsertCommand
        Dim userControl As UserControl = CType(e.Item.FindControl(GridEditFormItem.EditFormUserControlID), UserControl)
        Dim editedItem As GridEditableItem = CType(e.Item, GridEditableItem)
        descripcionV = CType(userControl.FindControl("descripcionTB"), TextBox).Text
        sqlProcess(0, Me.Request.QueryString("cod").ToString, descripcionV.ToString, 1, "A")
    End Sub

    Protected Sub RadGrid1_UpdateCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.UpdateCommand
        Dim userControl As UserControl = CType(e.Item.FindControl(GridEditFormItem.EditFormUserControlID), UserControl)
        Dim editedItem As GridEditableItem = CType(e.Item, GridEditableItem)
        Dim situacionId As Integer = editedItem.OwnerTableView.DataKeyValues(editedItem.ItemIndex)("situacionProblematicaId").ToString()

        descripcionV = CType(userControl.FindControl("descripcionTB"), TextBox).Text
        sqlProcess(situacionId, Me.Request.QueryString("cod").ToString, descripcionV.ToString, 1, "A")
    End Sub

    Private Sub sqlProcess(ByVal situacionIdv As Integer, ByVal pcbIdv As Integer, ByVal descripcionv As String,
                       ByVal estadov As Integer, ByVal estadoSituacionv As String)
        Dim cad As String = " exec ssfd.P_crearUpdateSituacionProblem " & situacionIdv.ToString &
            ", " & pcbIdv.ToString & ", '" & descripcionv.ToString & "', " &
            estadov.ToString & ", '" & estadoSituacionv.ToString & "', " & Session("usuarioID").ToString
        If cad.Length > 0 Then
            Try
                Me.sw_ejecutaSQL.querySQL(cad)
            Catch ex As Exception
            End Try
        End If
    End Sub


    Protected Sub RadGrid1_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.DeleteCommand
        Dim userControl As UserControl = CType(e.Item.FindControl(GridEditFormItem.EditFormUserControlID), UserControl)
        Dim editedItem As GridEditableItem = CType(e.Item, GridEditableItem)
        Dim situacionId As Integer = editedItem.OwnerTableView.DataKeyValues(editedItem.ItemIndex)("situacionProblematicaId").ToString()
        sqlProcess(situacionId, Me.Request.QueryString("cod").ToString, "", 0, "999")
    End Sub
End Class