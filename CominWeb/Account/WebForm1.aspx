<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="CominWeb.WebForm1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/dropzone/dist/min/dropzone.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/css/custom.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/css/main.css" />
</head>
<body>
    <form id="form1" runat="server">




        <div id="loginNuevoDiv" class="limiter" runat="server">
		<div class="container-login100" style="background:#2A3F54">
			<div class="wrap-login100 p-l-35 p-r-35 p-t-35 p-b-30">
				<form class="login100-form validate-form">
					<span class="login100-form-title p-b-20">
						Ingresar a ::
					    <asp:Label ID="titulo1LB" runat="server" Text="-" Font-Bold="False" 
                            style="color: #000000; font-weight: 600;"></asp:Label>WEB
					</span>
                    <div class="wrap-input100 validate-input">
                        <%--<asp:DropDownList ID="sucursalCB" runat="server" DataSourceID="SDS_selectSucursales" 
                            DataTextField="nombre" DataValueField="sucursalID" Width="100%" Height="70px"
                            AutoPostBack="False" OnChange="actualizarcombo();"
                            style="padding: 0 25px 0 25px; border:1px" ></asp:DropDownList>--%>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
                    </div>
					<div class="wrap-input100 validate-input">
                        <%--<asp:DropDownList ID="usuarioCB" runat="server" Height="70px"
                            DataSourceID="SDS_P_selectUsuario" DataTextField="nombreUser" 
                            DataValueField="usuarioID" Width="100%" 
                            style="padding: 0 25px 0 25px; border:1px">--%>
                        </asp:DropDownList>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>
					<div class="wrap-input100 rs1 validate-input" data-validate="Ingrese contraseña">
						<input id="claveTB" class="input100" name="claveTB" type="password" placeholder="Password" />
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>
					<div class="container-login100-form-btn m-t-20">
						<button class="login100-form-btn" onclick="newLogin()">
							Iniciar Sesión</button>
					</div>
					<div class="text-center p-t-25 p-b-4">
						<span class="txt1">
							Olvidó su
						</span>
						<a href="#" class="txt2 hov1">
							Clave?
						</a>
					</div>
				</form>
                
			</div>
            
            <br />
		</div>
	</div>



        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>

    </form>
</body>
</html>
