<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registroPedidoV.aspx.vb" Inherits="CominWeb.registroPedidoV" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
    <link href="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.css" rel="stylesheet" type="text/css" />
    <link href="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/build/css/custom.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .divtableInterior {
	        border:1px solid #8db2e3;
	        font-size:1em;
	        overflow:hidden;
	        width:100%;
	        text-align:center;
        }

        .styleMe {
            border: 1px solid #25729a;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            font-size: 12px;
            font-family: arial, helvetica, sans-serif;
            padding: 5px 10px 10px 10px;
            text-decoration: none;
            display: inline-block;
            text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
            font-weight: bold;
            color: #FFFFFF;
            background-color: #3093c7;
            background-image: linear-gradient(to bottom, #3093c7, #1c5a85);
        }

        .styleMe:hover {
            border: 1px solid #1c5675;
            background-color: #26759e;
            background-image: linear-gradient(to bottom, #26759e, #133d5b);
        }

        .styleMe1 {
            border: 1px solid #9a2525;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            font-size: 12px;
            font-family: arial, helvetica, sans-serif;
            padding: 7px 10px 10px 10px;
            text-decoration: none;
            display: inline-block;
            text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
            font-weight: bold;
            color: #FFFFFF;
            background-color: #c73030;
            background-image: linear-gradient(to bottom, #c73030, #851c1c);
        }

        .styleMe1:hover {
            border: 1px solid #751c1c;
            background-color: #9e2626;
            background-image: linear-gradient(to bottom, #9e2626, #5b1313);
        }
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function clientLoadHandler(sender) {
                var combo = sender;
                var items = combo.get_items();
                var itemCount = items.get_count()
                for (var counter = 0; counter < itemCount; counter++) {
                    var item = items.getItem(counter);
                    item.set_checked(false);
                }
            }

            window.setInterval("renewSession();", 30000);

            function renewSession() {
                console.log("Renovando session...");
                document.getElementById('renewSession').src = 'https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
            }

            function frmGuardar(id) {
                var grupo = document.getElementById('<%= grupoCB.ClientID%>').value;
                var eje = document.getElementById('<%= ejeCB.ClientID%>').value;
                var interv = document.getElementById('<%= intervencionCB.ClientID%>').value;
                var aspec = document.getElementById('<%= aspectoTB.ClientID%>').value;
                var cui = document.getElementById('<%= cuisTB.ClientID%>').value;
                if (grupo == 0) {
                    mensaje('information', 'Seleccione sector');
                    return false;
                }
                else if (eje == 0) {
                    mensaje('information', 'Seleccione Eje estratégico');
                    return false;
                }
                else if (interv == 0) {
                    mensaje('information', 'Seleccione tipo de intervención');
                    return false;
                }
                else if (cui.length > 7) {
                    mensaje('information', 'El CUI acepta 7 dígitos como máximo');
                    return false;
                }
                else if (aspec.length < 5) {
                    mensaje('information', 'Ingrese pedido');
                    return false;
                }
                else {
                    debugger;
                    var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                    $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("frmguardar");
                    return false;
                }
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

            function desactivarProducto(acuerdoID) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("desactivAcuerdo," + acuerdoID);
                return false;
            }

            function checkAcuerdo(letra) {
                tecla = (document.all) ? letra.keyCode : letra.which;
                //Tecla de retroceso para borrar, y espacio siempre la permite
                if (tecla == 8 || tecla == 13) {
                    return true;
                }
                if (tecla == 14 || tecla == 32) {
                    return true;
                }
                patron = /[A-Za-z.-1234567890áéíóú,-]/;
                tecla_final = String.fromCharCode(tecla);
                return patron.test(tecla_final);
            }

            function checkCui(letra) {
                tecla = (document.all) ? letra.keyCode : letra.which;
                //Tecla de retroceso para borrar, y espacio siempre la permite
                if (tecla == 8 || tecla == 13) {
                    return true;
                }
                if (tecla == 14 || tecla == 32) {
                    return true;
                }
                patron = /[1234567890,]/;
                tecla_final = String.fromCharCode(tecla);
                return patron.test(tecla_final);
            }

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

        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">

        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px; padding-top:10px">
                  <%--<br />--%>
                      Crear o Modificar Pedido
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                SECTOR (*)
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:center; ">
                <asp:DropDownList ID="grupoCB" runat="server" Width="100%" Font-Size="10pt"
                    DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                    DataValueField="grupoID" TabIndex="6" AppendDataBoundItems="True" >
                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:right;padding-top:10px">
               
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:right; ">
                
            </div>

        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                OBJETIVO ESTRATÉGICO
            </div>
            <div class="col-md-10 col-sm-10 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="ObjEstrategicoTB" Font-Size="9" runat="server" Width="100%" autocomplete="off" 
                    placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
            </div>

        </div>


        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                EJE ESTRATEGICO
            </div>
            <div class="col-md-10 col-sm-10 col-xs-6" style="text-align:center; ">
                <asp:DropDownList ID="ejeCB" runat="server" Width="100%" Font-Size="10pt"
                    DataSourceID="SDS_SD_P_selectEje" DataTextField="nombre" class="form-control"
                    DataValueField="grupoID" TabIndex="6" Enabled="false"> 
                    <%--AppendDataBoundItems="True" <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>--%>
                </asp:DropDownList>
            </div>

        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                TIPO INTERVENCIÓN
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:center; ">
                <asp:DropDownList ID="intervencionCB" runat="server" Width="100%" Font-Size="10pt"
                    DataSourceID="SDS_SD_P_selectTipoInt" DataTextField="nombre" class="form-control"
                    DataValueField="grupoID" TabIndex="6" AppendDataBoundItems="True" >
                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:right;padding-top:10px">
                CUI (Ej. 1234567)
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="cuisTB" Font-Size="9" runat="server" Width="100%" autocomplete="off" MaxLength="7"
                    placeholder="" class="form-control" onkeypress="return checkCui(event)" AutoPostBack="true"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExp1" runat="server"    
                    ErrorMessage="El CUI acepta maximo 7 dígitos máximo :: " Display="None"
                    ControlToValidate="cuisTB" ValidationExpression="^[0-9]{7,7}$" />
            </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                PEDIDO (*)
            </div>
            <div class="col-md-10 col-sm-10 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="aspectoTB" Font-Size="9" runat="server" Width="100%" autocomplete="off" TextMode="MultiLine"
                    placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
            </div>
        </div>
        
        <asp:ValidationSummary ID="ValidationSummary" runat="server" 
            ShowMessageBox="False" ShowSummary="True" ForeColor="#CC0000" 
            DisplayMode="SingleParagraph" Font-Names="Arial,Helvetica,sans-serif" 
            Font-Bold="True" Font-Size="9pt" Font-Italic="True" />

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
                <button class="styleMe1" style="Width:100%; Height:40px; font:16pt" onclick="frmGuardar(0); return false;">GUARDAR</button>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px; font-size:15px; text-align:left; font-weight:bold">
            <asp:Label ID="textoCuiLB" runat="server" Font-Bold="False" Font-Size="14px" Text="" style="font-weight: 600;" ForeColor="Red" ></asp:Label>

            <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES" Width="100%"
                    DataSourceID="SDS_SD_P_selectAcuerdoxCui" Skin="Bootstrap"  
                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top">
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="SDS_SD_P_selectAcuerdoxCui" NoMasterRecordsText="No existen registros." PageSize="5" Font-Size="Smaller">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                        <HeaderStyle Width="41px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" 
                        FilterControlAltText="Filter ExpandColumn column" Created="True">
                        <HeaderStyle Width="41px" />
                    </ExpandCollapseColumn>
                    <Columns>
                         <telerik:GridBoundColumn DataField="codigo" FilterControlAltText="Filter codigo column" 
                            HeaderText="Código" SortExpression="codigo" UniqueName="codigo" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" Font-Bold=""  />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="acuerdo" FilterControlAltText="Filter acuerdo column" 
                            HeaderText="Acuerdo" ReadOnly="True" SortExpression="acuerdo" UniqueName="acuerdo">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="nomEstadoRegistro" FilterControlAltText="Filter nomEstadoRegistro column" 
                            HeaderText="Estado" ReadOnly="True" SortExpression="nomEstadoRegistro" UniqueName="nomEstadoRegistro">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" ForeColor="Red" />
                        </telerik:GridBoundColumn>
                        
                    </Columns>
                    <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:radgrid>

        </div>

        <asp:SqlDataSource ID="SDS_SD_P_selectTipoInt" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                <asp:Parameter DefaultValue="5" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectGrupos" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                <asp:Parameter DefaultValue="7" Name="tipo" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="0" Name="ubigeo" QueryStringField="ubig" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectEje" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                <asp:Parameter DefaultValue="6" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_SD_P_selectAcuerdoxCui" runat="server"  
            SelectCommand="SD_P_selectAcuerdoxCui" 
            SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="cuisTB" DefaultValue="0000" Name="cui" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<img src="https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>



    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cuisTB">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="textoCuiLB" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>


        </form>

</body>

</html>
