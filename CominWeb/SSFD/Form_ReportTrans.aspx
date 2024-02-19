<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Form_ReportTrans.aspx.vb" Inherits="CominWeb.Form_ReportTrans" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        function ExportaSpreed() {
            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("ExportaSpreed");
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
                        window.location = '../Default.aspx';
                    }
                },
                ]
            });
            console.log('html: ' + n.options.id);
        }
        
    </script>
</telerik:RadCodeBlock>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div style=" width: 100%; ">
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" Font-Size="14pt" Font-Bold="true" Text=" INVENTARIOS DE PRODUCTOS A PARTIR DE FECHA DE CORTE :: "> </asp:Label>&nbsp;
        <br />
    </div>
                <table border="0" style="width: 100%" class="divFiltros">
                    <tr>
                        <td style=" text-align:right; width:10%">
                            Region&nbsp; 
                        </td>
                        <td style=" text-align:left; width:15%">
                            <asp:DropDownList ID="regionCB" runat="server" Width="90%" 
                                DataSourceID="SDS_P_selectRegion" DataTextField="nombre" 
                                DataValueField="ID" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td style=" text-align:right; width:10%">
                            Provincia&nbsp; 
                        </td>
                        <td style=" text-align:left; width:15%">
                            <asp:DropDownList ID="provinciaCB" runat="server" Width="90%" 
                                DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" 
                                DataValueField="provinciaID">
                            </asp:DropDownList>
                        </td>
                        <td style=" text-align:right; width:10%">
                            Año&nbsp;
                        </td>
                        <td style=" text-align:left; width:15%">
                            <asp:DropDownList ID="anioCB" runat="server" Width="90%" 
                                DataSourceID="SDS_P_selectAnio" DataTextField="Nombre" 
                                DataValueField="ID" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td style=" text-align:right; width:10%">
                            Alcaldesas&nbsp; 
                        </td>
                        <td style=" text-align:left; width:15%">
                            <asp:CheckBox ID="alcaldezasCHB" runat="server" Checked="false" />
                        </td>
                    </tr>
                    <tr>
                        <td style=" text-align:right; width:10%">
                            Presidente&nbsp;
                        </td>
                        <td style=" text-align:left; width:15%">
                            <asp:DropDownList ID="presidentesCB" runat="server" Width="90%" 
                                DataSourceID="SDS_P_selectPresidente" DataTextField="Nombre" 
                                DataValueField="ID" >
                            </asp:DropDownList>
                        </td>
                        <td style=" text-align:right; width:10%">
                            &nbsp; 
                        </td>
                        <td style=" text-align:left; width:15%">
                            
                        </td>
                        <td style=" text-align:right; width:10%">
                            &nbsp; 
                        </td>
                        <td style=" text-align:left; width:15%">
                            
                        </td>
                        <td style=" text-align:right; width:10%">
                            F. Corte&nbsp; 
                        </td>
                        <td style=" text-align:left; width:15%">
                            <telerik:RadDatePicker ID="fechaCorteRDP" Runat="server" Width="90%" 
                                Culture="es-PE" MinDate="2014-01-01" 
                                Skin="WebBlue" Font-Size="8pt" TabIndex="1" >
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue"></Calendar>
                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" 
                                    LabelWidth="40%" TabIndex="1"></DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="1"></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="exportaB" runat="server" class="styleMe" Text="TRANSFERENCIAS" Width="100%" Height="50px"/>
                        </td>
                        <%--<td colspan="2">
                            <asp:Button ID="exportaCatalogoProductoB" runat="server" class="styleMe" Text="CATALOGO REPUESTOS" Width="100%" Height="50px"/>
                        </td>--%>
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
    <telerik:radajaxmanager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
<%--            <telerik:ajaxsetting AjaxControlID="sucursalCB">
                <UpdatedControls>
                    <telerik:ajaxupdatedcontrol ControlID="almacenCB" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:ajaxsetting>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:ajaxupdatedcontrol ControlID="almacenCB" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:radajaxmanager>
</asp:Content>
