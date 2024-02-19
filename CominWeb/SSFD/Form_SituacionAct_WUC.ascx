<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Form_SituacionAct_WUC.ascx.vb" Inherits="CominWeb.Form_SituacionAct_WUC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table style="width: 100%; border:1px" border="0">
    <tr>
        <td style="text-align:right; width:15%; ">
            Descripcion&nbsp;
        </td>
        <td style="text-align:left; width:85%; padding:5px 0 5px 0;" rowspan="2" >
            <asp:TextBox ID="descripcionTB" runat="server" Width="90%" Rows="5" class="form-control"
                TextMode="MultiLine" placeholder="Descripción de la situación actual."></asp:TextBox>
        </td>
    </tr>
</table>
<asp:RequiredFieldValidator
    ID="RequiredFieldValidator1" runat="server" ControlToValidate="descripcionTB"
    ErrorMessage="Ingrese descripción ::" Display="None" >
</asp:RequiredFieldValidator>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
    ShowMessageBox="False" ShowSummary="True" ForeColor="#CC0000" 
    DisplayMode="SingleParagraph" Font-Names="Arial,Helvetica,sans-serif" 
    Font-Bold="True" Font-Size="9pt" Font-Italic="True" />
<div style="width: 100%; background-color: lightblue; text-align: center; padding-top:5px">
    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="PerformInsert" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Update.png"
        ToolTip="Insertar" Visible="<%# (TypeOf DataItem is Telerik.Web.UI.GridInsertionObject) %>" />&nbsp;
    <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Update" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Update.png"
        ToolTip="Actualizar" Visible="<%# Not (TypeOf DataItem is Telerik.Web.UI.GridInsertionObject) %>" />&nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Cancel"
        ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Cancel.png" ToolTip="Cancelar" />
</div>




