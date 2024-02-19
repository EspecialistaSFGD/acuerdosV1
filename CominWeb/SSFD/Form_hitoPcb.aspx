<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_hitoPcb.aspx.vb" Inherits="CominWeb.Form_hitoPcb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> :: Seguimiento de Hitos :: </title>
<script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
<script type ="text/javascript">

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function CerrarVentana(indicador) {
        var oWnd = GetRadWindow();
        var oArg = new Object();
        oArg.indicador = indicador;
        oWnd.close(oArg);
    }

    function mensaje(tipo, texto) {
        var n = noty({
            text: texto,
            type: tipo,
            dismissQueue: true,
            layout: 'center',
            theme: 'defaultTheme',
            modal: true
        });
        console.log('html: ' + n.options.id);
    }

    function validaDuplicadoTETdet() {
        var cod = '<%=Request.QueryString("cod")%>';
        var responsablejs = document.getElementById('<%= responsableTB.ClientId %>').value;
        var hitojs = document.getElementById('<%= hitoTb.ClientId %>').value;
        if (responsablejs.length == 0) {
            mensaje('information', 'Ingrese responsable.');
            return false;
        }
        if (hitojs == 0) {
            mensaje('information', 'Seleccione descripcion del hito.');
            return false;
        }
        else {
            $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("insertaHito");
        }
    }

</script>
</telerik:RadCodeBlock>
<style type="text/css">
    .divtableResponsable {
	    border:1px solid #8db2e3;
	    font-size:1em;
	    overflow:hidden;
	    text-align:center;
    }
        
    .divtableInterno {
	    border:1px solid #8db2e3;
	    font-size:1em;
	    overflow:hidden;
	    text-align:center;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="font-weight: bold; font-size: 9pt; color: black; width: 100%" border="0">
        <tr>
            <td align="center" colspan="4" style="width:100%">
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Skin="WebBlue" Width="100%"
                    Font-Bold="false">
                    <Items>
                        <telerik:RadToolBarButton runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White"
                            ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Update.png" Text="Guardar" onclick="validaDuplicadoTETdet();" >
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White"
                            ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Cancel.png" Text="Cancelar" onclick="CerrarVentana();" >
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
        </tr>
               <table width="100%" border="0" style="font-family: Arial, Helvetica, sans-serif; font-size:9pt" >
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0"> <%-- style="background-color:#f7f6f0; ">--%>
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Tipo&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:DropDownList ID="hitosCB" runat="server" Width="100%" TabIndex="1"
                                                DataSourceID="SDS_P_selectHitos" DataTextField="nombre" Height="25px"
                                                DataValueField="ID" Font-Size="8pt" AutoPostBack="true" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; border-left: #464646 1px solid;" >
                                            Responsable&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:TextBox ID="responsableTB" runat="server" autocomplete="off"
                                                Width="95%" Font-Size="9pt" AutoPostBack="false" TabIndex="2">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Hito&nbsp;
                                        </td>
                                        <td /style=" text-align:left; width:90%">
                                            <asp:TextBox ID="hitoTb" runat="server" autocomplete="off"
                                                Width="98%" Font-Size="9pt" AutoPostBack="false" TabIndex="15"
                                                TextMode="MultiLine" Rows="3">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0"> <%-- style="background-color:#f7f6f0; ">--%>
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            F.Inicio&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <telerik:RadDatePicker ID="fechaInicioRDP" Runat="server" Width="90%" 
                                                Culture="es-PE" MinDate="2020-01-01" MaxDate="2030-01-01"
                                                Skin="WebBlue" Font-Size="8pt" TabIndex="1" >
                                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue"></Calendar>
                                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" 
                                                    LabelWidth="40%" TabIndex="1"></DateInput>
                                                <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="1"></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; border-left: #464646 1px solid;" >
                                            F.Fin&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <telerik:RadDatePicker ID="FechaFinRDP" Runat="server" Width="90%" 
                                                Culture="es-PE" MinDate="2020-01-01" MaxDate="2030-01-01"
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
                </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="hitosCB">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="responsableTB" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="hitoTb" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="fechaInicioRDP" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="FechaFinRDP" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>

    <asp:SqlDataSource ID="SDS_P_selectHitos" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectCatalogos" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="6" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
