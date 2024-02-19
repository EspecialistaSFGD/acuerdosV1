Imports CominWeb.SW_coneccionDB
Imports System.IO

Public Class ToolTipProductConSinStock
    Inherits System.Web.UI.UserControl

    Public Property productoID() As String
        Get
            If ViewState("productoID") Is Nothing Then
                Return ""
            End If
            Return DirectCast(ViewState("productoID"), String)
        End Get
        Set(ByVal value As String)

            ViewState("productoID") = value
        End Set
    End Property


    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)
        Me.SDS_P_selectOrdenesServicio.SelectParameters("productoID").DefaultValue = Me.productoID
        Me.DataBind()
    End Sub


    'Protected Sub ProductsView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim image As System.Web.UI.WebControls.Image = DirectCast(ProductsView.FindControl("image"), System.Web.UI.WebControls.Image)
    '    If image Is Nothing Then
    '        Return
    '    End If
    '    If Not File.Exists(MapPath(image.ImageUrl)) Then

    '        image.ImageUrl = "FotosTrabajadores/usuario.png"
    '    End If
    'End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        SDS_P_selectOrdenesServicio.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
    End Sub
End Class