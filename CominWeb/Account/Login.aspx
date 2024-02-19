<%@ Page Title="Iniciar sesión" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Login.aspx.vb" Inherits="CominWeb.Login" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script>--%>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
    <style type="text/css">

.button_example{
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

.button_example:hover{
 border:1px solid #1c5675;
 background-color: #26759e; 
 background-image: linear-gradient(to bottom, #26759e, #133d5b);
 }
</style>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
<script type ="text/javascript">
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
    function actualizarcombo() {
        var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
        ajaxManager.ajaxRequest("ActualizarCombo");
    }
    function Enviar(e) {
        if (e.keyCode == 13) {
            var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
            ajaxManager.ajaxRequest("login");
        }
        
    }
    </script>
</telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Iniciar sesión
    </h2>
        Especifique su nombre de usuario y contraseña.
    <center>
        <table width="70%" border="0px">
            <tr>
                <td style=" width:47%">
                    <center>
                        <br />
                        <br />
                        <fieldset class="login" style=" width:70%">
                            <legend>Datos del Usuario</legend>
                            <center>
                                <table width="100%" border="0px" style="text-align:center">
                                    <tr>
                                        <td>
                                            <asp:Label ID="sucursalLB" runat="server" AssociatedControlID="sucursalCB" >SUCURSAL</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="sucursalCB" runat="server" CssClass="textEntry" 
                                            DataSourceID="SDS_selectSucursales" DataTextField="nombre" 
                                            DataValueField="sucursalID" Width="320px"
                                            AutoPostBack="False" OnChange="actualizarcombo();">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="sucursalCBRequired" runat="server" ControlToValidate="sucursalCB" 
                                             CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." 
                                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="usuarioCB" >NOMBRE DE USUARIO</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="margin-left:100px">
                                            <div class="RadAjaxPanel" id="ctl00_MainContent_ctl00_MainContent_usuarioCBPanel" style="display: block;margin-left: -10px;">
                                                <asp:DropDownList ID="usuarioCB" runat="server"
                                                DataSourceID="SDS_P_selectUsuario" DataTextField="nombreUser" 
                                                DataValueField="usuarioID" Width="320px">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="claveUser">CONTRASEÑA</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="claveUser" runat="server" CssClass="passwordEntry" TextMode="Password" OnKeypress="return Enviar(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="claveUser" 
                                             CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." 
                                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </fieldset><br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="False" ShowSummary="True" ForeColor="#CC0000" 
                        DisplayMode="SingleParagraph" Font-Names="Arial,Helvetica,sans-serif" 
                        Font-Bold="True" Font-Size="9pt" Font-Italic="True" />
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                        class="button_example" Text="Iniciar Sesión" 
                        ValidationGroup="LoginUserValidationGroup" Width="200px"/>
                        <p>
                        <%--<asp:LinkButton ID="btn_conectarme" runat="server" 
                            style="text-decoration:none underline" Font-Bold="True" Font-Italic="True" 
                            Font-Overline="True" Font-Size="9pt">Recuperar Contraseña</asp:LinkButton>--%>
                        </p>
                    </center>
                </td>
            </tr>
        </table>
    </center>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:SqlDataSource ID="SDS_selectSucursales" runat="server" 
    SelectCommand="SELECT sucursalID, nombre, EmrpesaClienteID, estado FROM Sucursal WHERE estado = 0 ">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectUsuario" runat="server" 
    SelectCommand="P_selectUsuario" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="UsuarioID" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="estado" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="TrabajadorID" Type="Int32" />
            <asp:ControlParameter ControlID="sucursalCB" DefaultValue="1" Name="sucursalID" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="sucursalCB">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="usuarioCB" UpdatePanelCssClass="" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="usuarioCB" 
                        LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
<%--
    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
        <UpdatedControls>
            <telerik:AjaxUpdatedControl ControlID="usuarioCB" 
                LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelCssClass="" />
        </UpdatedControls>
    </telerik:AjaxSetting>
--%>