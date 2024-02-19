<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Ctrl_GrillaEmergenteCotiVenta.aspx.vb" Inherits="CominWeb.Ctrl_GrillaEmergenteCotiVenta" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
   
    div.RadToolBar .rtbUL
    {
        width: 95%;
        height: 90%;
        white-space: normal;
    }
    div.RadToolBar .rightButton
    {
        float: right;
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
<script type="text/javascript" id="telerikClientEvents1">
    var cell_valor
    var cell_id
    function RadGrid_RowSelected(sender, eventArgs) {
        var grid = sender;
        var MasterTable = grid.get_masterTableView();
        var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
        cell_valor = MasterTable.getCellByColumnUniqueName(row, "<%=  columna_mostrar %>");
        cell_id = eventArgs.getDataKeyValue("<%=  identificador %>");
        cell_valor = cell_valor.innerHTML;
        returnToParent();
    }
    function returnToParent() {
        var oArg = new Object();
        oArg.cell_valor = cell_valor;
        oArg.cell_id = cell_id;
        var oWnd = GetRadWindow();
        if (oArg.cell_valor && oArg.cell_id) {
            oWnd.close(oArg);
        }
    }
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    function Todas() {
        cell_valor = 'Todas';
        cell_id = '0';
        returnToParent();
    }
    function SizeToFit() {
        window.setTimeout(
        function () {
            var oWnd = GetRadWindow();
            oWnd.SetWidth(document.body.scrollWidth + 16);
            oWnd.SetHeight(document.body.scrollHeight + 39);
            oWnd.center();
        }, 400);
    }
    <%--        document.getElementById('<%= txt_buscar.ClientId()%>').focus();--%>
    //document.addEventListener("keydown", KeyCheck);  //or however you are calling your method
    //function KeyCheck(event) {
    //    var KeyID = event.keyCode;
    //    switch (KeyID) {
    //        case 8:
    //            alert("backspace");
    //            break;
    //        case 46:
    //            alert("delete");
    //            break;
    //        default:
    //            break;
    //    }
    //}

    document.addEventListener("keypress", KeyCheck);  //or however you are calling your method
    function KeyCheck(event) {
        
        var KeyID = event.keyCode;
        switch (KeyID) {
            case 8:
                var buscar = document.getElementById("<%= txt_buscar.ClientID%>").value;
                if (buscar.length > 0) {
                    $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("actualizaGrilla");
                    return false;
                }
                break;
        }
    }

    function buscarKeyPress(sender, args) {
        
        var buscar = document.getElementById("<%= txt_buscar.ClientID%>").value;
        if (buscar.length > 0) {
            $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("actualizaGrilla");
            return false;
        }
    }
</script> 
</telerik:RadCodeBlock>
</head>
    <%--onload="SizeToFit()"--%>
<body >
    <form id="form1" runat="server">
    <div style="min-Width:100%;">
        <table width="100%">
            <tr>
                <td style="width:20%">
                    <asp:Button ID="borrarFiltro" runat="server" Text="LIMPIAR FILTRO" 
                        CssClass="styleMe" Width="100%" />
                </td>
                <td style="width:40%">
                    <telerik:RadTextBox ID="txt_buscar" Runat="server" Skin="Windows7" Width="100%" Text="" 
                        Font-Size="16pt" Height="35px" >
                        <ClientEvents OnKeyPress="buscarKeyPress" />
                    </telerik:RadTextBox>        
                </td>
                <td style="width:20%">
                    <asp:Button ID="btn_buscar1" runat="server" Text="BUSCAR" 
                        CssClass="styleMe" Width="100%" />
                </td>
                <td style="width:20%">
                    <asp:Button ID="guardarB" runat="server" Text="GUARDAR" 
                        CssClass="styleMe" Width="100%" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center>
                    <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" Skin="WebBlue">
                        <Items>
                            <telerik:RadToolBarButton runat="server" Text="Todas" OuterCssClass="rightButton" OnClick="Todas();">
                            </telerik:RadToolBarButton>
                        </Items>
                    </telerik:RadToolBar>
                    <telerik:RadGrid ID="RadGrid_Principal" runat="server" Skin="WebBlue" Culture="es-ES" 
                        DataSourceID="SqlDataSource_Grillas_Emergentes" 
                        AutoGenerateColumns="False" Width="100%" AllowSorting="True" GroupPanelPosition="Top">
                        <ClientSettings>
                            <Selecting CellSelectionMode="None" AllowRowSelect="True" ></Selecting>
                            <ClientEvents  OnRowSelected="RadGrid_RowSelected" />
                        </ClientSettings>
                        <MasterTableView
                                DataSourceID="SqlDataSource_Grillas_Emergentes" AllowPaging="True" 
                                AutoGenerateColumns="True" Font-Size="8pt" NoMasterRecordsText="No existen registros.">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" 
                                FilterControlAltText="Filter ExpandColumn column" Created="True">
                        </ExpandCollapseColumn>
                            <Columns>
                                <%--<telerik:GridTemplateColumn UniqueName="TemplateLinkNombre" 
                                    AllowFiltering="false" HeaderText="Nombre" SortExpression="LinkNombre">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="LinkNombre" runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                            </Columns>
                        <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                    </center>
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource_Grillas_Emergentes" runat="server">
        </asp:SqlDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="btn_buscar1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Principal" />
                        <telerik:AjaxUpdatedControl ControlID="RadToolTipManager1" 
                            LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Principal" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="RadToolTipManager1" 
                            LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadToolTipManager ID="RadToolTipManager1" OffsetY="-1" HideEvent="ManualClose"
              Width="350px" Height="200px" runat="server" OnAjaxUpdate="OnAjaxUpdate" RelativeTo="Element"
              Position="MiddleRight">
         </telerik:RadToolTipManager>
    </div>
</form>
</body>
</html>
