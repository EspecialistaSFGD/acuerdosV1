<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registroPedidoV22.aspx.vb" Inherits="CominWeb.registroPedidoV22" %>
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
                debugger;
                var grupo = document.getElementById('<%= grupoCB.ClientID%>').value;
                var departamento = document.getElementById('<%= cbo_departamento1.ClientID%>').value;
                var interv = document.getElementById('<%= intervencionTB.ClientID%>').value;
                var aspec = document.getElementById('<%= aspectoTB.ClientID%>').value;
                var cui = document.getElementById('<%= cuisTB.ClientID%>').value;
                if (grupo == 0) {
                    mensaje('information', 'Seleecione sector');
                    return false;
                } 
                else if (departamento == 0) {
                    mensaje('information', 'Seleecione Departamento');
                    return false;
                }
                else if (interv.length < 5) {
                    mensaje('information', 'Ingrese intervención');
                    return false;
                }
                else if (cui.length != 7) {
                    mensaje('information', 'El CUI acepta 7 dígitos');
                    return false;
                }
                else if (aspec.length < 5) {
                    mensaje('information', 'Ingrese Aspecto crítico');
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
                      Crear Intervención
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
                DEPARMENTO(*)
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:right; ">
                <asp:DropDownList ID="cbo_departamento1" runat="server" DataSourceID="SDS_P_selectDepartamento" DataTextField="departamento" 
                    DataValueField="departamentoID" AutoPostBack="true" Width="100%" TabIndex="12" class="form-control" Font-Size="10pt"
                    AppendDataBoundItems="True" >
                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                PROVINCIA
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:center; ">
                <asp:DropDownList ID="cbo_provincia1" runat="server" DataSourceID="SDS_P_selectProvincia"
                    DataTextField="provincia" Font-Size="10pt" AutoPostBack="true"
                    DataValueField="provinciaID" Width="100%" TabIndex="13" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:right;padding-top:10px">
                DISTRITO
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:left;padding-top:3px">
                <asp:DropDownList ID="distritoCB" runat="server" Width="100%" DataSourceID="SDS_P_selectDistrito" DataTextField="DISTRITO" 
                    DataValueField="distritoID" class="form-control" Font-Size="10pt">
                </asp:DropDownList>
            </div>

        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                PRIORIDAD TERRITORIAL
            </div>
            <div class="col-md-10 col-sm-10 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="prioridadTerritorialTB" Font-Size="9" runat="server" Width="100%" autocomplete="on" 
                    placeholder="" class="form-control" Rows="2" TextMode="MultiLine" onkeypress="return checkAcuerdo(event)" ></asp:TextBox>
            </div>

        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                OBJETIVO ESTRAT. TERRITORIAL
            </div>
            <div class="col-md-10 col-sm-10 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="objetivoTB" Font-Size="9" runat="server" Width="100%" autocomplete="off" 
                    placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
            </div>

        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                INTERVENCIÓN
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="intervencionTB" Font-Size="9" runat="server" Width="100%" autocomplete="off" 
                    placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:right;padding-top:10px">
                CUI (Ej. 1234567)
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="cuisTB" Font-Size="9" runat="server" Width="100%" autocomplete="off" 
                    placeholder="" class="form-control" onkeypress="return checkCui(event)"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExp1" runat="server"    
                    ErrorMessage="El CUI acepta maximo 7 dígitos máximo :: " Display="None"
                    ControlToValidate="cuisTB" ValidationExpression="^[0-9]{7,7}$" />
            </div>

        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">

            <div class="col-md-2 col-sm-2 col-xs-6" style="text-align:left;padding-top:10px">
                ASPECTO CRITICO (*)
            </div>
            <div class="col-md-10 col-sm-10 col-xs-6" style="text-align:center; ">
                <asp:TextBox ID="aspectoTB" Font-Size="9" runat="server" Width="100%" autocomplete="off" 
                    placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
            </div>

        </div>
        
        <asp:ValidationSummary ID="ValidationSummary" runat="server" 
            ShowMessageBox="False" ShowSummary="True" ForeColor="#CC0000" 
            DisplayMode="SingleParagraph" Font-Names="Arial,Helvetica,sans-serif" 
            Font-Bold="True" Font-Size="9pt" Font-Italic="True" />

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
            <%--<div class="col-md-6 col-sm-6 col-xs-6" style="text-align:center;padding-top:10px">
                <asp:Button ID="retornarB" runat="server" Text="RETORNA A LISTA" class="styleMe" Width="100%" Height="40px" Font-Size="9pt" />
            </div>--%>
            <%--<div class="col-md-6 col-sm-6 col-xs-6" style="text-align:center;padding-top:10px">--%>
                <button class="styleMe1" style="Width:100%; Height:40px; font:16pt" onclick="frmGuardar(0); return false;">GUARDAR</button>
            <%--</div>--%>

        </div>

        <asp:SqlDataSource ID="SDS_P_selectDepartamento" runat="server" 
            SelectCommand="SD_P_selectDepartamentoSD_cero" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_P_selectProvincia" runat="server" 
            ProviderName="System.Data.SqlClient" SelectCommand="SD_P_selectProvinciaSD" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbo_departamento1" DefaultValue="" 
                    Name="departamento" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
       <%-- <asp:SqlDataSource ID="SDS_P_selectDistrito" runat="server" 
            SelectCommand="ssfd.P_selectDistrito" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="provinciaCB" Name="departamento" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="provinciaCB" Name="provincia" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
        <asp:SqlDataSource ID="SDS_P_selectDistrito" runat="server" 
            ProviderName="System.Data.SqlClient" SelectCommand="SD_P_selectDistritoSD" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbo_provincia1" DefaultValue="" 
                    Name="provincia" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_SD_P_selectGrupos" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                <asp:Parameter DefaultValue="2" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<img src="https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>



    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        DefaultLoadingPanelID="RadAjaxLoadingPanel1">
    </telerik:RadAjaxManager>


        </form>

</body>
</html>
