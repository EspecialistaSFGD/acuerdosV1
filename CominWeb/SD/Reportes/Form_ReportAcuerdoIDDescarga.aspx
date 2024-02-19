<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_ReportAcuerdoIDDescarga.aspx.vb" Inherits="CominWeb.Form_ReportAcuerdoIDDescarga" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="SD\Reportes\R_cotizacionEX.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SDS_SD_P_selectListAcuerdoExport" Name="DS_acuerdosExport" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SDS_SD_P_selectListAcuerdoExport" runat="server" 
            SelectCommand="SD_P_selectListAcuerdoExport" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="prioridadID" Type="Int32" />
                    <asp:QueryStringParameter DefaultValue="0" Name="eventoId" QueryStringField="eventoId" Type="Int32" />
                    <asp:QueryStringParameter DefaultValue="0" Name="grupoId" QueryStringField="grupoId" Type="Int32" />
                    <asp:QueryStringParameter DefaultValue="0" Name="departamento" QueryStringField="departamento" Type="Int32" />
                    <asp:QueryStringParameter DefaultValue="0" Name="ubigeo" QueryStringField="ubigeo" Type="Int32" />
                    <asp:Parameter DefaultValue="0" Name="codigo" Type="String" />
                    <asp:Parameter DefaultValue="0" Name="clasificacion" Type="Int32" />
                    <asp:Parameter DefaultValue="0" Name="responsable" Type="Int32" />
                    <asp:Parameter DefaultValue="0" Name="acuerdoID" Type="Int32" />
                </SelectParameters>
        </asp:SqlDataSource>
<%--                <asp:SqlDataSource ID="SDS_P_selectReportCotizacionDetalleTRA" runat="server" 
            SelectCommand="P_selectReportCotizacionDetalleTRA" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="ordenServicioID" 
                    QueryStringField="ordenServicioIDUltimo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
