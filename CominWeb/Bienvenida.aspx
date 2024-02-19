<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" Inherits="CominWeb.Bienvenida" Codebehind="Bienvenida.aspx.vb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/animsition/js/animsition.min.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/bootstrap/js/popper.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/select2/select2.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/daterangepicker/moment.min.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/vendor/countdowntime/countdowntime.js"></script>
	<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/js/main.js"></script>
	<link rel="stylesheet" type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/css/util.css" />
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

    function newLogin() {
        var claveTB = document.getElementById("claveTB").value.toString();
        var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
        $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("newlogin,admin," + claveTB);
        return false;
    }

    function clientLoadHandler(sender) {
        var combo = sender;
        var items = combo.get_items();
        var itemCount = items.get_count()
        for (var counter = 0; counter < itemCount; counter++) {
            var item = items.getItem(counter);
            item.set_checked(false);
        }
    }

    function ejecuta() {
        $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("graphicJS");
    }
</script>
</telerik:RadCodeBlock>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<br />
<br />
<br />

    <div id="divDeskAlternativo" runat="server" class="row">
        <div class="col-md-6 col-sm-12 col-xs-12 form-group">
            <div class="page-title">
                <div class="title_left">
                    <h3>
                        <asp:Label ID="titulo2LB" runat="server" Font-Bold="False" Font-Size="17pt"
                            Text="" style="padding-left:40px; font-weight: 600;">
                        </asp:Label>&nbsp;::
                    </h3>
                </div>
            </div>
            <center>
                <img id="imagenPresentacionIMG" runat="server" src="Resources/remsaPeru.jpg" style="width:400px" />
            </center>
        </div>
        <div class="col-md-6 col-sm-12 col-xs-12 form-group">
            <br />
            <br />
            <br />
            <div class="page-title">
                <div class="title_left">
                    <h3>
                        <asp:Label ID="subTitulo1LB" runat="server" Font-Size="13pt" 
                                style="color: #1f1f26; font-weight: 600;" ></asp:Label>
                    </h3>
                </div>
            </div>
            <asp:Label ID="contenidoSubTitulo1LB" runat="server" Font-Size="11pt" 
                style="color: #1f2130"></asp:Label>

            <div class="page-title">
                <div class="title_left">
                    <h3>
                        <asp:Label ID="subTitulo2LB" runat="server" Font-Size="13pt" 
                                style="color: #1f1f26; font-weight: 600;"></asp:Label>
                    </h3>
                </div>
            </div>
                            
            <asp:Label ID="contenidoSubTitulo2LB" runat="server" Font-Size="11pt" 
                style="color: #1f2130"></asp:Label>
        </div>
    </div>

<div id="tabla_loginDiv" runat="server" class="row">

            <h3>Sistema de Seguimiento</h3>

              <div class="row" >
                  <div class="tile_count">
                    <div class="col-md-2 col-sm-4 col-xs-12 tile_stats_count">
                      <span class="count_top"><i class="fa fa-wrench"></i> OT Abiertas</span>
                      <div class="count">
                          <asp:Label ID="otAbiertaLB" class="count" runat="server" Text="0"></asp:Label>
                      </div>
                        <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i><asp:Label ID="otAbierta_SecLB" class="green" runat="server" Text="0"></asp:Label>% </i> Del Total</span>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-12 tile_stats_count">
                      <span class="count_top"><i class="fa fa-clock-o"></i> Disponibilidad Mecánica</span>
                      <div class="count">123.50</div>
                      <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>3% </i> From last Week</span>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-12 tile_stats_count">
                      <span class="count_top"><i class="fa fa-user"></i> Precisión de Servicio</span>
                      <div class="count green">2,500</div>
                      <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>34% </i> From last Week</span>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-12 tile_stats_count">
                      <span class="count_top"><i class="fa fa-user"></i> Confiabilidad</span>
                      <div class="count">4,567</div>
                      <span class="count_bottom"><i class="red"><i class="fa fa-sort-desc"></i>12% </i> From last Week</span>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-12 tile_stats_count">
                      <span class="count_top"><i class="fa fa-user"></i> T. Prom. Reparación</span>
                      <div class="count">2,315</div>
                      <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>34% </i> From last Week</span>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-12 tile_stats_count">
                      <span class="count_top"><i class="fa fa-user"></i> Planificadas vs No Planif.</span>
                      <div class="count">7,325</div>
                      <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>34% </i> From last Week</span>
                    </div>
                  </div>
                </div>


            <div class="row">
              <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Disponibilidad VS Target-Camiones </h2>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <canvas id="lineChart"></canvas>
                  </div>
                </div>
              </div>

              <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Disponibilidad VS Target</h2>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <canvas id="mybarChart"></canvas>
                  </div>
                </div>
              </div>

              <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Nombre Personalizado</h2>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                      <canvas id="canvasOT"></canvas>
                  </div>
                </div>
              </div>


            <div class="col-md-8 col-sm-8 col-xs-12">
                <div class="x_panel">
                    <div class="x_content">
                    <div id="mainb" style="height:350px;"></div>
                    </div>
                </div>
            </div>

                
              <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>MTTR</h2>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <canvas id="canvasDoughnut"></canvas>
                  </div>
                </div>
              </div>
        </div>

    <div class="clearfix"></div>
    <br />



<%--       <div class="col-md-8 col-sm-12 col-xs-12" >

            <div class="row x_title">
            <div class="col-md-6" >
                <h3 style="font-weight:bold; padding: 10px 0 10px 0;">DASHBOARD :: </h3>
            </div>
            <div class="col-md-6">
                <div id="reportrange" class="pull-right" style="padding: 10px 0 0 0;">
                    <telerik:RadComboBox ID="monedaNewCB" runat="server" Culture="es-ES" 
                        DataSourceID="SDS_P_selectMoneda" DataTextField="Nombre" 
                        DataValueField="ID" Width="110px" Skin="Glow" ToolTip="Seleccionar Moneda">
                    </telerik:RadComboBox>
                    <telerik:RadComboBox ID="anioNewCB" Runat="server" Width="110px"
                        Culture="es-ES" DataSourceID="SDS_P_selectAnioGraph" 
                        DataTextField="anio" Skin="Glow" AutoPostBack="false"
                        DataValueField="anio" style="margin-bottom: 0; font-size:44px" 
                        CheckBoxes="True" EnableCheckAllItemsCheckBox="true" ToolTip="Seleccionar Años"
                        OnClientLoad="clientLoadHandler" LoadingMessage="Cargando..." >
                        <Localization AllItemsCheckedString="Todos Seleccionados" 
                            CheckAllString="Todos" ItemsCheckedString="Elementos Seleccionados" 
                            NoMatches="No hay Coincidencias" />
                    </telerik:RadComboBox>
                    <telerik:RadButton ID="actDashRB" runat="server" Text="" Skin="Glow" ToolTip="Actualizar">
                        <Icon PrimaryIconCssClass="rbRefresh"></Icon>
                    </telerik:RadButton>
                </div>
            </div>
            </div>
        <div class="x_panel">
            <div class="x_title">
            <h2>Facturados Anual :: <asp:Label ID="anio1LB" runat="server" Text="-" 
                    style="color: #000000; font-size:15px"></asp:Label></h2>  
            <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <canvas id="chartBar"></canvas>
            </div>
        </div>
        </div>
        <div class="col-md-4 col-sm-6 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>:: <asp:Label ID="anio3LB" runat="server" Text="-" 
                    style="color: #000000; font-size:15px"></asp:Label></h2>
            <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <canvas id="canvasPagar"></canvas>
            </div>
        </div>
        </div>

        <div class="col-md-4 col-sm-6 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>:: <asp:Label ID="anio2LB" runat="server" Text="-" 
                    style="color: #000000; font-size:15px"></asp:Label></h2>
            <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <canvas id="canvasPie"></canvas>
            </div>
        </div>
        </div>--%>
</div>
<asp:SqlDataSource ID="SDS_selectSucursales" runat="server" 
    SelectCommand="P_selectSucursal" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="sucursalID" Type="Int32" />
    </SelectParameters>
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

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
    DefaultLoadingPanelID="RadAjaxLoadingPanel1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="sucursalCB">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="usuarioCB" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="puntoVentaCB" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="actualizaDashB">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="chart" UpdatePanelCssClass="" 
                    LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="puntoVentaCB" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="usuarioCB" LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelCssClass="" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
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
                        <asp:DropDownList ID="sucursalCB" runat="server" DataSourceID="SDS_selectSucursales" 
                            DataTextField="nombre" DataValueField="sucursalID" Width="100%" Height="70px"
                            AutoPostBack="false" OnChange="actualizarcombo();"
                            style="padding: 0 25px 0 25px; border:1px" ></asp:DropDownList>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
                    </div>
                    <div class="wrap-input100 validate-input">
                        <asp:DropDownList ID="puntoVentaCB" runat="server" DataSourceID="SDS_P_selectPuntoVenta" 
                            DataTextField="nombre" DataValueField="sucursalID" Width="100%" Height="70px"
                            AutoPostBack="False" OnChange="actualizarcombo();"
                            style="padding: 0 25px 0 25px; border:1px" ></asp:DropDownList>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
                    </div>
					<div class="wrap-input100 validate-input">
                        <asp:DropDownList ID="usuarioCB" runat="server" Height="70px"
                            DataSourceID="SDS_P_selectUsuario" DataTextField="nombreUser" 
                            DataValueField="usuarioID" Width="100%" 
                            style="padding: 0 25px 0 25px; border:1px">
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
				</form>
                
			</div>
            
            <br />
		</div>
	</div>  

    <asp:SqlDataSource ID="SDS_P_selectMoneda" runat="server" 
        SelectCommand="P_selectMoneda" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectAnioGraph" runat="server" 
        SelectCommand="P_selectAnioGraph" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectPuntoVenta" runat="server" 
        SelectCommand="P_selectPuntoVenta" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="estado" Type="Int32" />
            <asp:ControlParameter ControlID="sucursalCB" DefaultValue="8" 
                Name="sucursalID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>