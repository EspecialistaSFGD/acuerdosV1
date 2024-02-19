<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Form_superAdmin.aspx.vb" Inherits="CominWeb.Form_superAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/animsition/js/animsition.min.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/bootstrap/js/popper.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/select2/select2.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/daterangepicker/moment.min.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/countdowntime/countdowntime.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/js/main.js"></script>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
	<link rel="stylesheet" type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/css/util.css" />
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style=" width: 100%;">
    &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label1" runat="server" Font-Size="15pt" Font-Bold="true" Text=" Iniciar sesión de SuperAdmin :: "> </asp:Label>&nbsp;
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="10pt"
        Text="Especifique su nombre de usuario y contraseña." Width="450px"> </asp:Label>
</div>
<br />
<center>
    <div id="loginNuevoDiv" class="limiter" runat="server" style="width:70%">
		    <div class="wrap-login100 p-l-35 p-r-35 p-t-35 p-b-30">
			    <form class="login100-form validate-form">
				    <span class="login100-form-title p-b-20">
					    Ingresar a SISCOMP
				    </span>
                    <div class="wrap-input100 validate-input">
                        <asp:DropDownList ID="sucursalCB" runat="server" Height="70px"
                            DataSourceID="SDS_selectSucursales" DataTextField="nombre" 
                            DataValueField="sucursalID" Width="100%"
                            style="padding: 0 25px 0 25px; border:1px" >
                        </asp:DropDownList>
					    <span class="focus-input100-1"></span>
					    <span class="focus-input100-2"></span>
                    </div>
				    <div class="wrap-input100 validate-input">
                        <asp:TextBox ID="nombreUser" runat="server" class="input100" placeholder="Usuario"></asp:TextBox>
					    <span class="focus-input100-1"></span>
					    <span class="focus-input100-2"></span>
				    </div>
				    <div class="wrap-input100 rs1 validate-input" data-validate="Ingrese contraseña">
                        <asp:TextBox ID="claveUser" runat="server" class="input100" TextMode="Password" placeholder="Password"></asp:TextBox>
					    <span class="focus-input100-1"></span>
					    <span class="focus-input100-2"></span>
				    </div>
				    <div class="container-login100-form-btn m-t-20">
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                            class="login100-form-btn" Text="Iniciar Sesión" 
                            ValidationGroup="LoginUserValidationGroup" />
				    </div>
			    </form>
		    </div>
    </div>
</center>
<asp:SqlDataSource ID="SDS_selectSucursales" runat="server" 
    SelectCommand="SELECT sucursalID, UPPER(nombre) nombre, EmrpesaClienteID, estado FROM Sucursal WHERE estado = 0 ">
</asp:SqlDataSource>

</asp:Content>
