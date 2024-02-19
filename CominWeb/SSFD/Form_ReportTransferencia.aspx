<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_ReportTransferencia.aspx.vb" Inherits="CominWeb.Form_ReportTransferencia" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://162.248.52.148/REFERENCIASBASE/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.js"></script>
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/dropzone/dist/min/dropzone.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/css/custom.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/css/main.css" />
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/dropzone/dist/min/dropzone.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/js/custom.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/Chart.js/dist/Chart.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/echarts/dist/echarts.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/echarts/map/js/world.js"></script>

    <style type="text/css">
        .divResponsables {
	    border:1px solid #8db2e3;
	    padding:0.1em;
	    font-size:1em;
	    overflow:hidden;
	    width:99%;
	    text-align:center;
    }
    .divFiltros
    {
	    border:1px solid #8db2e3;
	    padding:0.2em;
	    font-size:1em;
	    overflow:hidden;
	    width:100%;
	    text-align:center;
    }
    .styleMe{
        border:1px solid #25729a; 
        -webkit-border-radius: 3px; 
        -moz-border-radius: 3px;
        border-radius: 3px;
        font-size:12px;
        font-family:arial, helvetica, sans-serif; 
        padding: 10px 10px 10px 10px; 
        text-decoration:none; 
        display:inline-block;
        text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
        font-weight:bold; 
        color: #FFFFFF;
        background-color: #3093c7; 
        background-image: linear-gradient(to bottom, #3093c7, #1c5a85);
    }

    .styleMe:hover{
        border:1px solid #1c5675;
        background-color: #26759e; 
        background-image: linear-gradient(to bottom, #26759e, #133d5b);
    }
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
<%--            function exportaJS() {
                var mayor = document.getElementById("<%= mayorTB.ClientID()%>").value;
                var menor = document.getElementById("<%= menorTB.ClientID()%>").value;
                if (parseFloat(mayor) == 0) {
                    mensaje('information', 'Ingrese Máximo.');
                    return false;
                }
                if (parseFloat(mayor) <= parseFloat(menor)) {
                    mensaje('information', 'Ingrese valor válido.');
                    return false;
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("ExportaSpreed");
                    return true;
                }
                
            }--%>
        

            function ValidEntero(e) {
                var key = window.Event ? e.which : e.keyCode
                return (key >= 48 && key <= 57 || key == 46)
            }

            function CerrarVentana(oWnd, args) {
                var arg = args.get_argument();
                if (arg) {
                    if (arg.indicador == 1) {
                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("ActualizarGrilla");
                    }
                }
            }

        //Para el mensaje
            function mensaje(tipo, texto) {
                var n = noty({
                    text: texto,
                    type: tipo, // alert | error | success | information | warning | confirm
                    dismissQueue: true,
                    layout: 'center',
                    theme: 'defaultTheme',
                    modal: true,
                    buttons: [
                        {
                            addClass: 'btn btn-danger', text: 'Ok', onClick: function ($noty) {
                                $noty.close();
                            }
                        },
                    ]
                });
                console.log('html: ' + n.options.id);
            }

            function canculaMenor() {
                var menor = document.getElementById("<%= menorTB.ClientID()%>").value;
                if (menor == 0) {
                    mensaje('information', 'Ingrese Minimo.');
                    return false;
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("canculaMenorJS," + menor);
                    return true;
                }
            }

            function canculaMayor() {
                var mayor = document.getElementById("<%= mayorTB.ClientID()%>").value;
                var menor = document.getElementById("<%= menorTB.ClientID()%>").value;
                if (parseFloat(mayor) == 0) {
                    mensaje('information', 'Ingrese Máximo.');
                    return false;
                }
                if (parseFloat(mayor) <= parseFloat(menor)) {
                    mensaje('information', 'Ingrese valor válido.');
                    return false;
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("canculaMayorJS," + mayor);
                    return true;
                }
            }
        </script>
    </telerik:RadCodeBlock>
</head>
<body style="background:#FFFFFF">
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td style="width:15%">
                    <div style=" width: 100%; ">
                        <asp:Label ID="Label11" runat="server" Font-Size="15pt" Font-Bold="true" Text=" :: TRANSF. A GL"> </asp:Label>
                    </div>
                </td>
                <td style="width:85%">
                    <table width="100%">
                        <tr>
                            <td style=" width:90%">
                                <dt class="divResponsables">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td colspan="4">
                                                <dt class="divtableInterior">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td style=" text-align:right; width:13%; font-weight: bold;" >
                                                                REGION&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <asp:DropDownList ID="regionCB" runat="server" Width="100%"
                                                                    DataSourceID="SDS_P_selectRegion" DataTextField="nombre" 
                                                                    DataValueField="ID" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style=" text-align:right; width:14%; font-weight: bold;">
                                                              PROVINCIA&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <asp:DropDownList ID="provinciaCB" runat="server" Width="100%"
                                                                    DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" 
                                                                    DataValueField="provinciaID">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style=" text-align:right; width:13%; font-weight: bold; " >
                                                                AÑO&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <asp:DropDownList ID="anioCB" runat="server" Width="100%"
                                                                    DataSourceID="SDS_P_selectAnio" DataTextField="Nombre" 
                                                                    DataValueField="ID" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dt>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <dt class="divtableInterior">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td style=" text-align:right; width:13%; font-weight: bold;" >
                                                                PRESIDENTE&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <asp:DropDownList ID="presidentesCB" runat="server" Width="100%"
                                                                    DataSourceID="SDS_P_selectPresidente" DataTextField="Nombre" 
                                                                    DataValueField="ID" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style=" text-align:right; width:14%; font-weight: bold;">
                                                              ALCALDESAS&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <asp:CheckBox ID="alcaldezasCHB" runat="server" Checked="false" />
                                                            </td>
                                                            <td style=" text-align:right; width:13%; font-weight: bold; " >
                                                                FEC. CORTE&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <telerik:RadDatePicker ID="fechaCorteRDP" Runat="server" Width="100%"
                                                                    Culture="es-PE" MinDate="2020-01-01" 
                                                                    Skin="WebBlue" Font-Size="8pt" TabIndex="1" >
                                                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue"></Calendar>
                                                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" 
                                                                        LabelWidth="40%" TabIndex="1"></DateInput>
                                                                    <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="1"></DatePopupButton>
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dt>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <dt class="divtableInterior">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td style=" text-align:right; width:13%; font-weight: bold;" >
                                                                MENOR QUE&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <asp:TextBox ID="menorTB" runat="server" OnKeyPress="return ValidEntero(event)" 
                                                                    onblur = "canculaMenor(); return false;" AutoPostBack="false" Width="100%"
                                                                    TabIndex="22" ></asp:TextBox> 
                                                            </td>
                                                            <td style=" text-align:right; width:14%; font-weight: bold;">
                                                                ENTRE&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td style="width:45%">
                                                                            <asp:Label ID="menorLB" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td style="width:10%">
                                                                            &nbsp;y&nbsp;
                                                                        </td>
                                                                        <td style="width:45%">
                                                                            <asp:TextBox ID="mayorTB" runat="server" OnKeyPress="return ValidEntero(event)" 
                                                                                onblur = "canculaMayor(); return false;" AutoPostBack="false" Width="100%"
                                                                                TabIndex="22" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style=" text-align:right; width:13%; font-weight: bold; " >
                                                                MAYOR QUE&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:20%">
                                                                <asp:Label ID="mayorLB" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dt>
                                            </td>
                                        </tr>
                                    </table>
                                </dt>        
                            </td>
                            <td style=" width:10%">
                                <asp:Button ID="exportaB" runat="server" class="styleMe" Text="EXPORTAR" Width="100%" Height="50px"/>
                                <%--<input id="guardaBi" type="button" value="GUARDAR" class="styleMe" style="height:50px; width:100%; font-size:14pt" onclick="exportaJS();" />--%>
                            </td>
                        </tr>
                    </table>   
                </td>
            </tr>
        </table>
 
    <asp:SqlDataSource ID="SDS_P_selectRegion" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectCatalogos" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="4" Name="tipo" Type="Int32" />
            <asp:ControlParameter ControlID="alcaldezasCHB" DefaultValue="0" Name="variable" 
            PropertyName="Checked" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectProvincia" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectProvincia" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="provinciaCB" Name="departamento" 
                    PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectAnio" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectCatalogos" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="5" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectPresidente" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectCatalogos" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <telerik:radajaxmanager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:ajaxupdatedcontrol ControlID="menorLB" UpdatePanelCssClass="" />
                    <telerik:ajaxupdatedcontrol ControlID="mayorLB" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanager>
    </form>
    

</body>
</html>