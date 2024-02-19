<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_SituacionProblem.aspx.vb" Inherits="CominWeb.Form_SituacionProblem" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> :: Situación Problematica :: </title>
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
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Skin="WebBlue" Width="100%" style="font-weight: bold; font-size: 9pt;"
                    Font-Bold="false">
                    <Items>
                        <telerik:RadToolBarButton runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White"
                            ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Cancel.png" Text="Cerrar" onclick="CerrarVentana();" >
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
                <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES" DataSourceID="SDS_P_selectSituacion" Skin="WebBlue" 
                    Width="100%" AutoGenerateColumns="False" AllowFilteringByColumn="false" AllowPaging="True" >
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="SDS_P_selectSituacion" Font-Size="8pt" PageSize="5" 
                        NoMasterRecordsText="No existen registros." DataKeyNames="situacionProblematicaId"
                        CommandItemDisplay="Top">
                    <CommandItemSettings ExportToPdfText="Export to PDF" 
                        AddNewRecordText="Agregar Nuevo" ExportToExcelText="Exportar a Excel" 
                        RefreshText="Actualizar" ShowExportToExcelButton="false"></CommandItemSettings>
                    <Columns>
                        <telerik:grideditcommandcolumn ButtonType="ImageButton" CancelText="Cancelar" EditText="Editar"
                            FilterImageToolTip="Filtrar" InsertText="Insertar" HeaderText="Edit." UniqueName="edita">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:grideditcommandcolumn>
                        <telerik:GridBoundColumn DataField="situacionProblematicaId" FilterControlAltText="Filter situacionProblematicaId column" 
                            HeaderText="situacionProblematicaId" ReadOnly="True" SortExpression="situacionId" UniqueName="situacionProblematicaId"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="pcbId" FilterControlAltText="Filter pcbId column" 
                            HeaderText="Cod" ReadOnly="True" SortExpression="pcbId" UniqueName="pcbId"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:gridboundcolumn DataField="fechaDescripcion" DataType="System.DateTime" 
                            FilterControlAltText="Filter fechaDescripcion column" HeaderText="Fecha" 
                            SortExpression="fechaDescripcion" UniqueName="fechaDescripcion"
                            DataFormatString="{0:dd/MM/yyyy}" Display="true" AllowFiltering="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="85px" />
                        </telerik:gridboundcolumn>
                        <telerik:GridBoundColumn DataField="descripcion" FilterControlAltText="Filter descripcion column" 
                            HeaderText="Situacion" SortExpression="descripcion" UniqueName="descripcion"
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="estadoSituacion" FilterControlAltText="Filter estadoSituacion column" 
                            HeaderText="estadoSituacion" ReadOnly="True" SortExpression="estadoSituacion" UniqueName="pcbId"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ESTADO_SIT" FilterControlAltText="Filter ESTADO_SIT column" 
                            HeaderText="Estado" SortExpression="ESTADO_SIT" UniqueName="ESTADO_SIT"
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                        </telerik:GridBoundColumn>
                        <telerik:gridbuttoncolumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                            ConfirmText="Esta seguro de Eliminar?" ConfirmTitle="Mensaje de Confirmación" 
                            UniqueName="columnDel" HeaderText="Elim.">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:gridbuttoncolumn>
                    </Columns>
                    <EditFormSettings EditFormType="WebUserControl" 
                        UserControlName="~/SSFD/Form_SituacionProblem_WUC.ascx">
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </MasterTableView>
                </telerik:radgrid>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="reqPararCHB">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="diasParoRNTB" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>

        <asp:SqlDataSource ID="SDS_P_selectSituacion" runat="server" 
            SelectCommand="ssfd.P_selectSituacionProblem" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="situacionProblematicaId" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="0" Name="pcbId" QueryStringField="cod" Type="String" />
                <asp:Parameter DefaultValue="X" Name="estadoSit" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
       
    </form>
</body>
</html>
