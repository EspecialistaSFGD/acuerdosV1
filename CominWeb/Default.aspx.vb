Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim cargaDT As New DataTable
        'Dim sqlEjecuta As New SW_EjecutaSQL_DA
        'If Page.IsPostBack = False Then
        '    cargaDT = sqlEjecuta.P_selectParametroByID(64)
        'End If

        If Session("EmpresaPrincipalWEB") = "COMINSAC" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=COMINSAC")
        ElseIf Session("EmpresaPrincipalWEB") = "eninAumsmyZ4/DsJU7tVSWSW6w=" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninAumsmyZ4/DsJU7tVSWSW6w=")
        ElseIf Session("EmpresaPrincipalWEB") = "eninWe1n/TkAuMHCTTWbMBlgg==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninWe1n/TkAuMHCTTWbMBlgg==")
        ElseIf Session("EmpresaPrincipalWEB") = "enin2hKuuS1kJ/AY7L02e2c1wg==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=enin2hKuuS1kJ/AY7L02e2c1wg==")
        ElseIf Session("EmpresaPrincipalWEB") = "eninU4WBTrij5CnvCJ/LpawgZg==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninU4WBTrij5CnvCJ/LpawgZg==")
        ElseIf Session("EmpresaPrincipalWEB") = "enin5QmN8eDxfBmy8giI9q16F8sdBsbLtoxzmfbIcldXZMI=" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=enin5QmN8eDxfBmy8giI9q16F8sdBsbLtoxzmfbIcldXZMI=")
        ElseIf Session("EmpresaPrincipalWEB") = "eninXaZ2ov79qPNmwXYioAh5JnrqP2//" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninXaZ2ov79qPNmwXYioAh5JnrqP2//")
        ElseIf Session("EmpresaPrincipalWEB") = "enin4DYeb/GNm5Xn9cCcztgEiA==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=enin4DYeb/GNm5Xn9cCcztgEiA==")
        ElseIf Session("EmpresaPrincipalWEB") = "enincmVtc2FwZXJ1==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=enincmVtc2FwZXJ1==")
        ElseIf Session("EmpresaPrincipalWEB") = "eninY2xvdmVybXVsdGlz2a==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninY2xvdmVybXVsdGlz2a==")
        ElseIf Session("EmpresaPrincipalWEB") = "eninbWFudWNjaQ==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninbWFudWNjaQ==")
        ElseIf Session("EmpresaPrincipalWEB") = "eninbmV3cmVzdA==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninbmV3cmVzdA==")
        ElseIf Session("EmpresaPrincipalWEB") = "enincsssfdmVzdA==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=enincsssfdmVzdA==")
        ElseIf Session("EmpresaPrincipalWEB") = "eninY2FzYWdyYW5kZQ==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninY2FzYWdyYW5kZQ==")
        ElseIf Session("EmpresaPrincipalWEB") = "eninPY2FEzzPYE==" Then
            Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninPY2FEzzPYE==")
        Else
            'Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=eninPY2FEzzPYE==") '    MANNUCCI
            Response.Redirect("~/SD/Form_BienvenidoSD.aspx?au=0&7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=2B6AC8BbF4ADF440005AFC42EF337555FB0008BF9770791Z&gjXtIkEroS=SD_SSFD")
        End If
    End Sub

End Class