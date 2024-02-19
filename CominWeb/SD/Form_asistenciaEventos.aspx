<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_asistenciaEventos.aspx.vb" Inherits="CominWeb.Form_asistenciaEventos" %>
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

            window.setInterval("renewSession();", 30000);

            function renewSession() {
                console.log("Renovando session...");
                document.getElementById('renewSession').src = 'http://162.248.52.148/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
            }

            function procesarJS() {
                //var r = confirm("¿Desea procesar las horas ingresadas?");
                //if (r == true) {
                    var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("CreateExcelFile");
                    return false;
                //}
            }
        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px">
                  <%--<br />--%>
                      MARCAR ASISTENCIA
                </div>
          </div>
        </div>



        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:30px">
            
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:DropDownList ID="cbo_evento" runat="server" Width="90%" Font-Size="18"
                    DataSourceID="SDS_P_SelectEventos" DataTextField="nombre" 
                    DataValueField="eventoID" TabIndex="1">
                </asp:DropDownList>
            </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:DropDownList ID="cbo_tipoDocumento" runat="server" Width="90%" Font-Size="18"
                    DataSourceID="SDS_P_SelectDocumento" DataTextField="nombre" 
                    DataValueField="TipoDocumentoID" TabIndex="5">
                </asp:DropDownList>
            </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:TextBox ID="nroDocTB" Font-Size="18" runat="server" Width="90%" autocomplete="off" 
                    placeholder="NRO. DOCUMENTO" TextMode="Phone"></asp:TextBox>
            </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Button ID="buscar2" runat="server" Text="BUSCAR" class="styleMe" Width="90%" Height="50px" Font-Size="14" />
            </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center">
                <asp:Label ID="tituloLB" runat="server" Font-Size="18" Text="-" Font-Bold="true"></asp:Label>&nbsp;
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center;">
        <center>
            <table style="width:90%" border="0">
                <tr>
                    <td style="width:80%">
                        <table style="width:100%" border="0">
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    A.PATERNO
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="apePaternoTB" Font-Size="18" runat="server" Width="100%" autocomplete="off" 
                                            placeholder="" BackColor="Yellow"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    A.MATERNO
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="apeMaternoTB" Font-Size="18" runat="server" Width="100%" autocomplete="off" 
                                            placeholder="" BackColor="Yellow"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    NOMBRE(S)
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="nombresTB" Font-Size="18" runat="server" Width="100%" autocomplete="off" 
                                            placeholder="" BackColor="Yellow"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    GRUPO
                                </td>
                                <td style="padding:5px">
                                        <asp:DropDownList ID="grupoCB" runat="server" Width="90%" Font-Size="18"
                                                DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" BackColor="Yellow"
                                                DataValueField="grupoID" TabIndex="6" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="0" > - SELECCIONE GRUPO - </asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    ENTIDAD
                                </td>
                                <td style="padding:5px">
                                        <telerik:RadComboBox ID="mancomunidadCB" runat="server" Culture="es-ES" Font-Size="20" RenderMode="Lightweight"
                                            DataSourceID="SDS_SD_P_selectMancomunidades" DataTextField="nombre" filter="Contains" BackColor="Yellow"
                                            DataValueField="idMancomunidad" Height="100px" AllowCustomText="true" Width="100%">
                                        </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    CARGO
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="cargoTB" Font-Size="18" runat="server" Width="100%" autocomplete="on" 
                                            placeholder="" BackColor="Yellow"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    TELEFONO
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="telefonoTB" Font-Size="18" runat="server" Width="100%" autocomplete="off" 
                                            placeholder="TELEFONO"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:20px; font-weight:500">
                                    EMAIL
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="emailTB" Font-Size="18" runat="server" Width="100%" autocomplete="off" 
                                            placeholder="EMAIL"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width:20%; text-align:center; padding:5px">
                               <asp:Button ID="nuevoB" runat="server" Text="REGISTRAR ASISTENCIA" class="styleMe" Width="100%" 
                                   Height="300px" Font-Size="14" />
                    </td>
                </tr>
            </table>
        </center>
            
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                
            </div>            
        </div>
    
        <asp:SqlDataSource ID="SDS_SD_P_selectMancomunidades" runat="server" 
            SelectCommand="SD_P_selectMancomunidades" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="idMancomunidad" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_P_SelectEventos" runat="server" 
        SelectCommand="SD_P_selectEventos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="eventoId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SDS_P_SelectDocumento" runat="server" 
        SelectCommand="P_selectDocumento" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Tipo" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="tipoSelect" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="tipoDocumentoID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectGrupos" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<img src="http://162.248.52.148/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        DefaultLoadingPanelID="">
    </telerik:RadAjaxManager>
        </form>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
</html>
