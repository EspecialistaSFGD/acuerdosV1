Public Class SessionActiva
    Inherits System.Web.UI.Page

    Shared gif As Byte() = {&H47, &H49, &H46, &H38, &H39, &H61, _
                          &H1, &H0, &H1, &H0, &H91, &H0, _
                          &H0, &H0, &H0, &H0, &H0, &H0, _
                          &H0, &H0, &H0, &H0, &H0, &H0, _
                          &H0, &H21, &HF9, &H4, &H9, &H0, _
                          &H0, &H0, &H0, &H2C, &H0, &H0, _
                          &H0, &H0, &H1, &H0, &H1, &H0, _
                          &H0, &H8, &H4, &H0, &H1, &H4, _
                          &H4, &H0, &H3B, &H0}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        InitializeComponent()
        MyBase.OnInit(e)
    End Sub

    Private Sub InitializeComponent()
        Response.AddHeader("ContentType", "image/gif")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.BinaryWrite(gif)
        Response.[End]()
    End Sub

End Class