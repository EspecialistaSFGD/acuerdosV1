﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ToolTipProductVenta.ascx.vb" Inherits="CominWeb.ToolTipProductVenta" %>
<style>
.title
{
     color: #4f4236;
     font-weight: bold;
     font-size: 13px;
     font-family: Calibri, Arial;
}
</style>
    <table runat="server" style="width: 100%;" id="ProductWrapper" border="0" cellpadding="2"
         cellspacing="0">
         <tr>
              <td style="text-align: center;">
                    <asp:FormView ID="ProductsView" DataSourceID="SDS_P_selectOrdenesServicio" DataKeyNames="productoID"
                        runat="server" Width="100%">
                        <ItemTemplate>
                            <table style="width:100%" border="0">
                                <tr>
                                    <td style="text-align:left">
                                       Codigo&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="codProducto" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("codProducto")%></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; width:35%;">
                                        Nombre&nbsp;
                                    </td>
                                    <td style="text-align:left; width:65%;">
                                        <asp:Label ID="nombre" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("nombre")%></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        Grupo&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="nomMarca" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("nomMarca")%></asp:Label>
                                    </td>
                                </tr>
<%--                                <tr>
                                    <td style="text-align:left">
                                        SubGrupo&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="NomSubGrupo" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("NomSubGrupo")%></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td style="text-align:left">
                                        Marca&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="nomMarcaEspecifico" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("nomMarcaEspecifico")%></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        Unidad&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="nomUniMedida" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("nomUniMedida")%></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        P. Venta Unid.&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="valorVenta" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("SimboloMoneda") & " " & Eval("pUnidad") %></asp:Label>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td style="text-align:left">
                                        P. Venta Decena&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="decena" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("SimboloMoneda") & " " & Eval("pDecena")%></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        P. Venta Centena&nbsp;
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Label ID="centena" runat="server" Font-Size="8pt" Font-Bold="true"><%# Eval("SimboloMoneda") & " " & Eval("pCentena")%></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>                     
                    </asp:FormView>
              </td>
         </tr>
    </table>
    <asp:SqlDataSource ID="SDS_P_selectOrdenesServicio" runat="server"  
        SelectCommand="P_selectProdToolTipVenta" 
        SelectCommandType="StoredProcedure" >
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="estado" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="productoID" Type="String" />
            <asp:Parameter DefaultValue="0" Name="marcaID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="marcaEspecificaID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="UnidadMedidaID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="grpoFuncionID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="ubicacionID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="lineaID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="almacenID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="nombre" Type="String" />
            <asp:Parameter DefaultValue="0" Name="codproducto" Type="String" />
            <asp:SessionParameter Name="sucursalID" SessionField="IDSucursalPrincipal"
                DefaultValue="0" />
            <asp:Parameter DefaultValue="0" Name="conStock" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>