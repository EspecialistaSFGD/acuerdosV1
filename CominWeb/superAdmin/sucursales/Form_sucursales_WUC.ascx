<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Form_sucursales_WUC.ascx.vb" Inherits="CominWeb.Form_sucursales_WUC" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<center>
<table style="border-style: hidden; width: 90%"  class="FondoUC">
    <tr>
        <td align="left">
            <div style="border-right: #464646 1px solid; border-left: #464646 1px solid; border-bottom: #464646 1px solid">
                <table style="width: 100%" >
                    <tr>
                        <td style=" width:50%; vertical-align:top">
                            <table style="font-size: 9pt; width: 100%; color: #464646; font-family: Arial; background-color: #fcfcfc; text-align: center; " 
                                cellspacing="4">
                                <tr>
                                    <td style="text-align:right; width:30%">
                                        Nombre :&nbsp;
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="nombreTB" runat="server" Width="90%" Enabled="false">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right; width:30%">
                                        Descripcion :&nbsp;
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="descripcionTB" runat="server" Width="90%" BackColor="#6297BC">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border-left: #464646 1px solid; width:50%">
                            <table style="font-size: 9pt; width: 100%; color: #464646; font-family: Arial; background-color: #fcfcfc; text-align: center; " 
                                cellspacing="4">
                                <tr>
                                    <td style="text-align:right;" >
                                        Estado :&nbsp;
                                    </td>
                                    <td style="text-align:left;">
                                        <asp:CheckBox ID="estadoCHB" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;" >
                                        Confianza :&nbsp;
                                    </td>
                                    <td style="text-align:left;">
                                        
                                        <asp:CheckBox ID="confianzaCHB" runat="server" />
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <%--VALIDACIONES--%>                
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombreTB"
                    ErrorMessage="Ingrese la Razon Comercial ::" Display="None" ></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="False" ShowSummary="True" ForeColor="#CC0000" />
                
            </div>
            <div style="border-right: #464646 1px solid; border-left: #464646 1px solid; width: 100%; border-bottom: #464646 1px solid; 
                background-color: lightblue; text-align: center;">
                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="PerformInsert" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Update.png"
                    ToolTip="Insertar" Visible="<%# (TypeOf DataItem is Telerik.Web.UI.GridInsertionObject) %>" />&nbsp;
                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Update" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Update.png"
                    ToolTip="Actualizar" Visible="<%# Not (TypeOf DataItem is Telerik.Web.UI.GridInsertionObject) %>" />&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Cancel"
                    ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Cancel.png" ToolTip="Cancelar" />
            </div>
        </td>
    </tr>
</table>
</center>




