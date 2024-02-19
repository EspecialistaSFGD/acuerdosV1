<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registroAc.aspx.vb" Inherits="CominWeb.registroAc" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
    <link href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.css" rel="stylesheet" type="text/css" />
    <link href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/css/custom.min.css" rel="stylesheet" type="text/css" />
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

            
            function checkAcuerdo(letra) 
            {
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

            window.setInterval("renewSession();", 30000);

            function renewSession() {
                console.log("Renovando session...");
                document.getElementById('renewSession').src = 'http://162.248.52.148/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
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

        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px; padding-top:10px">
                  <%--<br />--%>
                      ACUERDOS
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
                <center>
                        <table style="width:95%" border="0">
                            <tr>
                                <td style="width:15%; padding:5px; Font-Size:14px; font-weight:500">
                                    ACUERDO
                                </td>
                                <td style="padding:5px" colspan="3">
                                        <asp:TextBox ID="acuerdoTB" Font-Size="12" runat="server" Width="100%" autocomplete="on" TabIndex="1"
                                            placeholder="" class="form-control" Rows="12" TextMode="MultiLine" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; padding:5px; Font-Size:14px; font-weight:500">
                                    CLASIFICACION
                                </td>
                                <td style="padding:5px" colspan="3">
                                        <asp:DropDownList ID="clasificaCB" runat="server" Width="100%" Font-Size="11pt" Height="40px"
                                                DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                                                DataValueField="grupoID" TabIndex="2" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; padding:5px; Font-Size:14px; font-weight:500">
                                    RESPONSABLE
                                </td>
                                <td style="width:35%; padding:5px">
                                        <asp:DropDownList ID="responsableCB" runat="server" Width="100%" Font-Size="11pt" Height="40px"
                                            class="form-control" TabIndex="3" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                            <asp:ListItem Value="25" > GL </asp:ListItem>
                                            <asp:ListItem Value="26" > GN </asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td style="width:15%; padding:5px; Font-Size:14px; font-weight:500">
                                    <center>PLAZO</center>
                                </td>
                                <td style="width:35%; padding:5px">
                                        <telerik:raddatepicker ID="plazoRDP" runat="server" DateInput-AutoCompleteType="Disabled"
                                            Width="100%" Culture="es-PE" MaxDate="2030-12-31"
                                            MinDate="2024-01-01" Skin="Bootstrap">
                                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Bootstrap"></Calendar>
                                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="11" ></DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                        </telerik:raddatepicker>
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="4">
                                    <br />
                                    <asp:Button ID="buscar2" runat="server" Text="GUARDAR" class="styleMe1" Width="100%" Height="40px" Font-Size="13" />
                                </td>
                            </tr>
                        </table>
                </center>
        </div>

            <asp:SqlDataSource ID="SDS_SD_P_selectGrupos" runat="server" 
                SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                    <asp:Parameter DefaultValue="3" Name="tipo" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<img src="http://162.248.52.148/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>


        </form>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
</html>
