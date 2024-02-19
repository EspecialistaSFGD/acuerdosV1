<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_AM001.aspx.vb" Inherits="CominWeb.Form_AM001" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://162.248.52.148/REFERENCIASBASE/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.js"></script>
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/dropzone/dist/min/dropzone.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/css/custom.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/css/main.css" />
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/dropzone/dist/min/dropzone.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/js/custom.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/Chart.js/dist/Chart.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/echarts/dist/echarts.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/echarts/map/js/world.js"></script>

    <style type="text/css">
        .divtableInterior {
	    border:1px solid #8db2e3;
	    font-size:1em;
	    overflow:hidden;
	    width:100%;
	    text-align:center;
        }

        .styleMe{
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

        .styleMe:hover{
            border:1px solid #1c5675;
            background-color: #26759e; 
            background-image: linear-gradient(to bottom, #26759e, #133d5b);
        }

    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            $(document).keydown(function (e) {
                if (e.keyCode == 13) {
                        refreshGrid();
                        return false;
                    }
            });

            function refreshGrid() {
                var masterTable = $find("<%=RadGrid1.ClientId%>").get_masterTableView();
                masterTable.rebind();
            }

            function buscarCU(e) {
                if (e.keyCode == 13) {
                    var texto = document.getElementById('<%= txtCU.ClientID%>');
                    if (texto.value.length == 0) {
                        var obj = document.getElementById("<%=radGrid1.clientID%>");
                        obj.click();
                    }
                    else if (texto.value.length < 2) {
                        texto.focus;
                        mensaje('information', 'Debe ingresar mas de 3 digitos.');
                        return false;
                    }
                    else {
                        var obj = document.getElementById("<%=buscar2.ClientID%>");
                        obj.click();
                    }
                }
            }

            function modPCB(e,a,s,r,g,y,u,j,ub) {
                var nosucp = '<%=Request.QueryString("nosucp")%>';
                var usrin = '<%=Request.QueryString("usrin")%>'; 
                var emp = '<%=Request.QueryString("gjXtIkEroS")%>';

                location.href = "../SSFD/Form_AM002e.aspx?gjXtIkEroS=" + emp +
                    "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                    "&usrin=" + usrin +
                    "&nosucp=" + nosucp +
                    "&id=" + e +
                    "&h1=" + s +
                    "&h2=" + r +
                    "&h3=" + g +
                    "&h4=" + y +
                    "&s=" + u +
                    "&sp=" + j +
                    "&ub=" + ub;
                return false;
            }

            function frmsituacion(cod,emp) {
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                var ruta_ventana_empresas = "Form_SituacionAct.aspx?gjXtIkEroS=" + emp +
                    "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                    "&cod=" + cod;
                oWnd.setUrl(ruta_ventana_empresas);
                oWnd.add_close(OnClientClose);
                oWnd.show();
                return false;
            }

            function frmsituacionproblematica(cod,emp) {
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                var ruta_ventana_empresas = "Form_SituacionProblem.aspx?gjXtIkEroS=" + emp +
                    "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                    "&cod=" + cod;
                oWnd.setUrl(ruta_ventana_empresas);
                oWnd.add_close(OnClientClose);
                oWnd.show();
                return false;
            }
            
            function frmhitos(cod,emp) {
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                var ruta_ventana_empresas = "Form_hitoPcb.aspx?gjXtIkEroS=" + emp +
                    "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                    "&cod=" + cod;
                oWnd.setUrl(ruta_ventana_empresas);
                oWnd.add_close(OnClientClose);
                oWnd.show();
                return false;
            }

            function OnClientClose1(oWnd, eventArgs) {
                oWnd.remove_close(OnClientClose1);
            }

            function OnClientClose(oWnd, eventArgs) {
                var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();
                oWnd.remove_close(OnClientClose);
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

            window.setInterval("renewSession();", 30000);

            function renewSession() {
                console.log("Renovando session...");
                document.getElementById('renewSession').src = '/DESARROLLO/SessionActiva.aspx?par=' + Math.random();
            }

            function redireccionGenerado(codigoUltimo) {
                mensajeXX('information', 'SE REALIZO LA VERIFICACION DEL EQUIPO: ' + codigoUltimo);
            }

            function mensajeXX(tipo, texto) {
                var n = noty({
                    text: texto,
                    type: tipo, // alert | error | success | information | warning | confirm
                    dismissQueue: true,
                    layout: 'center',
                    theme: 'defaultTheme',
                    modal: true,
                    buttons: [
                        {
                            addClass: 'btn btn-danger', text: 'Ok', onClick: function ($noty) {
                                $noty.close();
                                window.close();
                                //window.location = '../ordenesdetrabajo/Form_Ordenes.aspx';
                            }
                        },
                    ]
                });
                console.log('html: ' + n.options.id);
            }

            function buscarSnip(e) {
                if (e.keyCode == 13) {
                    var texto = document.getElementById('<%= txtSNIP.ClientID%>');
                    if (texto.value.length == 0) {
                        var obj = document.getElementById("<%=radGrid1.clientID%>");
                        obj.click();
                    }
                    else if (texto.value.length < 2) {
                        texto.focus;
                        mensaje('information', 'Debe ingresar mas de 3 digitos.');
                        return false;
                    }
                    else {
                        var obj = document.getElementById("<%=buscar2.ClientID%>");
                        obj.click();
                    }
                }
            }
            
            function buscarProy(e) {
                if (e.keyCode == 13) {
                    var texto = document.getElementById('<%= txtProyecto.ClientID%>');
                    if (texto.value.length == 0) {
                        var obj = document.getElementById("<%=radGrid1.clientID%>");
                        obj.click();
                    }
                    else if (texto.value.length < 2) {
                        texto.focus;
                        mensaje('information', 'Debe ingresar mas de 3 digitos.');
                        return false;
                    }
                    else {
                        var obj = document.getElementById("<%=buscar2.ClientID%>");
                        obj.click();
                    }
                }
            }
        </script>
    </telerik:RadCodeBlock>
</head>
<body style="background:#FFFFFF">
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td style="width:10%">
                    <div style=" width: 100%; ">
                        <asp:Label ID="Label11" runat="server" Font-Size="15pt" Font-Bold="true" Text="  :: PCB"> </asp:Label>
                    </div>
                </td>
                <td style="width:90%">
                    <table width="100%">
                        <tr>
                            <td style=" width:90%">
                                <dt class="divResponsables">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td colspan="4">
                                                <dt class="divtableInterior">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td style=" text-align:right; width:6%; font-weight: bold;" >
                                                                PROVINCIA&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:12%">
                                                                <asp:DropDownList ID="provinciaCB" runat="server" Width="90%" 
                                                                    DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" 
                                                                    DataValueField="provinciaID" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style=" text-align:right; width:6%; font-weight: bold;">
                                                              DISTRITO&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:17%">
                                                                <asp:DropDownList ID="distritoCB" runat="server" Width="90%" 
                                                                    DataSourceID="SDS_P_selectDistrito" DataTextField="distrito" 
                                                                    DataValueField="distritoID">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style=" text-align:right; width:6%; font-weight: bold; " >
                                                                CU&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:12%">
                                                                <asp:TextBox ID="txtCU" runat="server" Width="90%" autocomplete="off" onkeypress="return buscarCU(event)"></asp:TextBox>
                                                            </td>
                                                            <td style=" text-align:right; width:6%; font-weight: bold; " >
                                                                SNIP&nbsp; 
                                                            </td>
                                                            <td style=" text-align:left; width:12%">
                                                                <asp:TextBox ID="txtSNIP" runat="server" Width="90%" autocomplete="off" onkeypress="return buscarSnip(event)"></asp:TextBox>
                                                            </td>
                                                            <td style=" text-align:right; width:12%; font-weight: bold;">
                                                              PROYECTO&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:13%">
                                                                <asp:TextBox ID="txtProyecto" runat="server" Width="90%" autocomplete="off" onkeypress="return buscarProy(event)"></asp:TextBox>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </dt>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <dt class="divtableInterior">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td style=" text-align:right; width:18%; font-weight: bold;" >
                                                                <asp:Button ID="exp126B" runat="server" Text="DU 126" class="styleMe" Width="100%" Height="35px" />
                                                            </td>
                                                            <td style=" text-align:right; width:6%; font-weight: bold;">
                                                                XX&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:17%">
                                                                
                                                            </td>
                                                            <td style=" text-align:right; width:6%; font-weight: bold; " >
                                                                XX&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:12%">
                                                                <asp:TextBox ID="TextBox2" runat="server" Width="90%" autocomplete="off" onkeypress="return buscarGOt(event)"></asp:TextBox>
                                                            </td>
                                                            <td style=" text-align:right; width:6%; font-weight: bold; " >
                                                                XX&nbsp; 
                                                            </td>
                                                            <td style=" text-align:left; width:12%">
                                                                <asp:TextBox ID="TextBox3" runat="server" Width="90%" autocomplete="off" onkeypress="return buscarGCli(event)"></asp:TextBox>
                                                            </td>
                                                            <td style=" text-align:right; width:12%; font-weight: bold;">
                                                                XX&nbsp;
                                                            </td>
                                                            <td style=" text-align:left; width:13%">
                                                                <asp:TextBox ID="TextBox4" runat="server" Width="90%" autocomplete="off" onkeypress="return buscarGEqu(event)"></asp:TextBox>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </dt>
                                            </td>
                                        </tr>
                                    </table>
                                </dt>        
                            </td>
                            <td style=" width:10%">
                                <asp:Button ID="buscar2" runat="server" Text="Buscar" class="styleMe" Width="100%" Height="35px" />
                            </td>
                        </tr>
                    </table>   
                </td>
            </tr>
        </table>
        <telerik:radtoolbar ID="RadToolBar1" runat="server" Skin="WebBlue" Width="100%">
            <Items>
                <telerik:radtoolbarbutton runat="server" Text="Agregar Cotización" 
                    ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/agregar.png" Visible="false">
                </telerik:radtoolbarbutton>
                <telerik:radtoolbarbutton runat="server" Text="Calendario de Tareo" 
                    ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/agregar.png" Visible="false">
                </telerik:radtoolbarbutton>
                <telerik:radtoolbarbutton runat="server" Text="Agregar Cotizacion/Orden" 
                    ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/agregar.png" Visible="false">
                </telerik:radtoolbarbutton>
                <telerik:radtoolbarbutton runat="server" Text="Exportar Excel" 
                        ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/ExportToExcel.gif" >
                </telerik:radtoolbarbutton>
                <telerik:radtoolbarbutton runat="server" Text="Agregar Cotizacion" 
                    ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/agregar.png" Visible="false">
                </telerik:radtoolbarbutton>
                <telerik:radtoolbarbutton runat="server" Text="Agregar Cotizacion/MCO" 
                    ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/agregar.png" Visible="false">
                </telerik:radtoolbarbutton>
            </Items>
        </telerik:radtoolbar>
        <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES" DataSourceID="SDS_P_selectPCB" Skin="WebBlue" 
            Width="100%" AutoGenerateColumns="False" AllowFilteringByColumn="false" AllowPaging="True" >
            <GroupingSettings CaseSensitive="false" />
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="true" ScrollHeight="500px" ></Scrolling>
            </ClientSettings>
            <MasterTableView DataSourceID="SDS_P_selectPCB" Font-Size="8pt" PageSize="5" 
                NoMasterRecordsText="No existen registros." DataKeyNames="pcbId" >
            <Columns>
                <telerik:gridtemplatecolumn UniqueName="edita" AllowFiltering="false" HeaderText="Edit">
                    <ItemTemplate>
                        <asp:Image ID="editar" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/editWebBlue.gif" runat="server" ToolTip="Editar" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn UniqueName="situacio" AllowFiltering="false" HeaderText="Situac.">
                    <ItemTemplate>
                        <asp:Image ID="situacion" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/tormenta_002.png" runat="server" ToolTip="Situación Actual" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn UniqueName="situacP" AllowFiltering="false" HeaderText="Situac. Prob.">
                    <ItemTemplate>
                        <asp:Image ID="situacPro" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/tormenta_001.png" runat="server" ToolTip="Situación Problematica" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn UniqueName="hito" AllowFiltering="false" HeaderText="Hitos">
                    <ItemTemplate>
                        <asp:Image ID="hitos" ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/hito.png" runat="server" ToolTip="Hitos" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:GridBoundColumn DataField="pcbId" FilterControlAltText="Filter pcbId column" 
                    HeaderText="Cod" ReadOnly="True" SortExpression="pcbId" UniqueName="pcbId"
                    Display="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="provincia1" FilterControlAltText="Filter provincia1 column" HeaderText="Provincia" 
                    SortExpression="provincia1" UniqueName="provincia1" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="true" >
                    <HeaderStyle Width="75px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="distrito" FilterControlAltText="Filter distrito column" HeaderText="Distrito" 
                    SortExpression="distrito" UniqueName="distrito" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="true" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ubigeoID" FilterControlAltText="Filter ubigeoID column" 
                    HeaderText="ubigeoID" ReadOnly="True" SortExpression="ubigeoID" UniqueName="ubigeoID"
                    Display="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nJerarquia" FilterControlAltText="Filter nJerarquia column" HeaderText="Jerarq." 
                    SortExpression="nJerarquia" UniqueName="nJerarquia" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="true" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="jerarquiaId" FilterControlAltText="Filter jerarquiaId column" 
                    HeaderText="jerarquiaId" ReadOnly="True" SortExpression="jerarquiaId" UniqueName="jerarquiaId"
                    Display="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nNucleoDinamizador" FilterControlAltText="Filter nNucleoDinamizador column" HeaderText="Nucleo Din." 
                    SortExpression="nNucleoDinamizador" UniqueName="nNucleoDinamizador" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="true" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nucleo_dinamizador" FilterControlAltText="Filter nucleo_dinamizador column" HeaderText="nucleo_dinamizador" 
                    SortExpression="nucleo_dinamizador" UniqueName="nucleo_dinamizador" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="true" Display="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nro_nucleo_dinamizador" FilterControlAltText="Filter nro_nucleo_dinamizador column" 
                    HeaderText="Nro Nucleo" SortExpression="nro_nucleo_dinamizador" UniqueName="nro_nucleo_dinamizador" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="codigo_snip" FilterControlAltText="Filter codigo_snip column" 
                    HeaderText="SNIP" SortExpression="codigo_snip" UniqueName="codigo_snip"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="codigo_unico" FilterControlAltText="Filter codigo_unico column" 
                    HeaderText="CU" SortExpression="codigo_unico" UniqueName="codigo_unico"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
<%--                <telerik:GridBoundColumn DataField="nombre_proyecto" FilterControlAltText="Filter nombre_proyecto column" 
                    HeaderText="nombre_proyecto" SortExpression="nombre_proyecto" UniqueName="nombre_proyecto"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>--%>
                <telerik:gridtemplatecolumn DataField="nombre_proyecto" FilterControlAltText="Filter nombre_proyecto column" HeaderText="Proyecto" 
                    SortExpression="nombre_proyecto" UniqueName="nombre_proyecto" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="false" >
                    <HeaderStyle Width="300px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkProyecto" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:GridBoundColumn DataField="nTema" FilterControlAltText="Filter nTema column" 
                    HeaderText="Tema" SortExpression="nTema" UniqueName="nTema"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                    <HeaderStyle Width="100px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nComplemento" FilterControlAltText="Filter nComplemento column" 
                    HeaderText="Complemento" SortExpression="Complemento" UniqueName="nComplemento"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nGestionInversion" FilterControlAltText="Filter nGestionInversion column" 
                    HeaderText="Gestion Inv." SortExpression="nGestionInversion" UniqueName="nGestionInversion"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                    <HeaderStyle Width="130px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nEstadoFinal" FilterControlAltText="Filter nEstadoFinal column" 
                    HeaderText="Estado" SortExpression="nEstadoFinal" UniqueName="nEstadoFinal"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                    <HeaderStyle Width="80px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nEje" FilterControlAltText="Filter nEje column" 
                    HeaderText="Eje" SortExpression="nEje" UniqueName="nEje"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nDivisionFuncional" FilterControlAltText="Filter nDivisionFuncional column" 
                    HeaderText="Div. Funcional" SortExpression="nDivisionFuncional" UniqueName="nDivisionFuncional"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nGrupoFuncional" FilterControlAltText="Filter nGrupoFuncional column" 
                    HeaderText="Grupo Funcional" SortExpression="nGrupoFuncional" UniqueName="nGrupoFuncional"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="du145" DataType="System.Decimal" FilterControlAltText="Filter du145 column" 
                    HeaderText="DU 145" SortExpression="du145" UniqueName="du145">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PNSR" DataType="System.Decimal" FilterControlAltText="Filter PNSR column" 
                    HeaderText="PNSR" SortExpression="PNSR" UniqueName="PNSR">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="cinco_cuenca" FilterControlAltText="Filter cinco_cuenca column" 
                    HeaderText="5 Cuenca" SortExpression="cinco_cuenca" UniqueName="cinco_cuenca"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="cuatro_cuenca" FilterControlAltText="Filter cuatro_cuenca column" 
                    HeaderText="4 Cuenca" SortExpression="cuatro_cuenca" UniqueName="cuatro_cuenca"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="manseriche" FilterControlAltText="Filter manseriche column" 
                    HeaderText="Maseriche" SortExpression="manseriche" UniqueName="manseriche"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="morona_shapras" FilterControlAltText="Filter morona_shapras column" 
                    HeaderText="Morona Shapras" SortExpression="morona_shapras" UniqueName="morona_shapras"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="morona" FilterControlAltText="Filter morona column" 
                    HeaderText="Morona" SortExpression="morona" UniqueName="morona"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="urarina_concordia" FilterControlAltText="Filter urarina_concordia column" 
                    HeaderText="Urarina Concordia" SortExpression="urarina_concordia" UniqueName="urarina_concordia"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="urarina_nueva_alianza" FilterControlAltText="Filter urarina_nueva_alianza column" 
                    HeaderText="Urarina Nueva Alianza" SortExpression="urarina_nueva_alianza" UniqueName="urarina_nueva_alianza"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="pip_demanda" FilterControlAltText="Filter pip_demanda column" 
                    HeaderText="pip_demanda" SortExpression="pip_demanda" UniqueName="pip_demanda"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ley_2020" FilterControlAltText="Filter ley_2020 column" 
                    HeaderText="ley_2020" SortExpression="ley_2020" UniqueName="ley_2020"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="plan_selva" FilterControlAltText="Filter plan_selva column" 
                    HeaderText="plan_selva" SortExpression="plan_selva" UniqueName="ley_2020"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="salud_minagri_minedu_midis" FilterControlAltText="Filter salud_minagri_minedu_midis column" 
                    HeaderText="salud_minagri_minedu_midis" SortExpression="salud_minagri_minedu_midis" UniqueName="salud_minagri_minedu_midis"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="veredas" FilterControlAltText="Filter veredas column" 
                    HeaderText="veredas" SortExpression="veredas" UniqueName="veredas"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="embarcaderos" FilterControlAltText="Filter embarcaderos column" 
                    HeaderText="embarcaderos" SortExpression="embarcaderos" UniqueName="embarcaderos"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="proyectos_productivos" FilterControlAltText="Filter proyectos_productivos column" 
                    HeaderText="proyectos_productivos" SortExpression="proyectos_productivos" UniqueName="proyectos_productivos"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="residencias_midis" FilterControlAltText="Filter residencias_midis column" 
                    HeaderText="residencias_midis" SortExpression="residencias_midis" UniqueName="residencias_midis"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nucleo_ejecutor_PNSR" FilterControlAltText="Filter nucleo_ejecutor_PNSR column" 
                    HeaderText="nucleo_ejecutor_PNSR" SortExpression="nucleo_ejecutor_PNSR" UniqueName="nucleo_ejecutor_PNSR"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="trans_trabaja_peru" DataType="System.Decimal" FilterControlAltText="Filter trans_trabaja_peru column" 
                    HeaderText="trans_trabaja_peru" SortExpression="du145" UniqueName="trans_trabaja_peru">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="trans_trabaja_peru_rm" DataType="System.Decimal" FilterControlAltText="Filter trans_trabaja_peru_rm column" 
                    HeaderText="trans_trabaja_peru_rm" SortExpression="trans_trabaja_peru_rm" UniqueName="trans_trabaja_peru_rm">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="transferencia" DataType="System.Decimal" FilterControlAltText="Filter transferencia column" 
                    HeaderText="transferencia" SortExpression="transferencia" UniqueName="transferencia">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="du_114" DataType="System.Decimal" FilterControlAltText="Filter du_114 column" 
                    HeaderText="du_114" SortExpression="du_114" UniqueName="du_114">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="du_126" DataType="System.Decimal" FilterControlAltText="Filter du_126 column" 
                    HeaderText="du_126" SortExpression="du_126" UniqueName="du_126">
                </telerik:GridBoundColumn>
                <telerik:gridtemplatecolumn DataField="nSituacion" FilterControlAltText="Filter nSituacion column" HeaderText="Situacion" 
                    SortExpression="nSituacion" UniqueName="nSituacion" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="false" >
                    <HeaderStyle Width="300px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkSituacion" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn DataField="nSituacionProblema" FilterControlAltText="Filter nSituacionProblema column" HeaderText="nSituacionProblema" 
                    SortExpression="nSituacionProblema" UniqueName="nSituacionProblema" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="false" >
                    <HeaderStyle Width="200px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkSituacionProblema" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn DataField="H1" FilterControlAltText="Filter H1 column" HeaderText="Hito 1" 
                    SortExpression="H1" UniqueName="H1" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="false" >
                    <HeaderStyle Width="200px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkH1" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn DataField="H2" FilterControlAltText="Filter H2 column" HeaderText="Hito 2" 
                    SortExpression="H2" UniqueName="H2" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="false" >
                    <HeaderStyle Width="200px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkH2" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn DataField="H3" FilterControlAltText="Filter H3 column" HeaderText="Hito 3" 
                    SortExpression="H3" UniqueName="H3" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="false" >
                    <HeaderStyle Width="200px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkH3" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>
                <telerik:gridtemplatecolumn DataField="H4" FilterControlAltText="Filter H4 column" HeaderText="Hito 4" 
                    SortExpression="H4" UniqueName="H4" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                    ShowFilterIcon="false" >
                    <HeaderStyle Width="200px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkH4" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:gridtemplatecolumn>

                <telerik:GridBoundColumn DataField="HId1" FilterControlAltText="Filter HId1 column" 
                    HeaderText="HId1" SortExpression="HId1" UniqueName="HId1" Display="false"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HId2" FilterControlAltText="Filter HId2 column" 
                    HeaderText="HId2" SortExpression="HId2" UniqueName="HId2" Display="false"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HId3" FilterControlAltText="Filter HId3 column" 
                    HeaderText="HId3" SortExpression="HId3" UniqueName="HId3" Display="false"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HId4" FilterControlAltText="Filter HId4 column" 
                    HeaderText="HId4" SortExpression="HId4" UniqueName="HId4" Display="false"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sitId" FilterControlAltText="Filter sitId column" 
                    HeaderText="sitId" SortExpression="sitId" UniqueName="sitId" Display="false"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sitProId" FilterControlAltText="Filter sitProId column" 
                    HeaderText="sitProId" SortExpression="sitProId" UniqueName="sitProId" Display="false"
                    AutoPostBackOnFilter="true" FilterControlWidth="100%" ShowFilterIcon="false" >
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>
            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
        </telerik:radgrid>
        <asp:SqlDataSource ID="SDS_P_selectProvincia" runat="server" 
            ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectProvincia" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="16" Name="departamento" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_P_selectDistrito" runat="server" 
            SelectCommand="ssfd.P_selectDistrito" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="16" Name="departamento" Type="String" />
                <asp:ControlParameter ControlID="provinciaCB" Name="provincia" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_P_selectPCB" runat="server"  
            SelectCommand="ssfd.P_selectPCB" 
            SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="pcbId" Type="String" />
                <asp:ControlParameter ControlID="txtCU" DefaultValue="0" Name="strCU" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtSNIP" DefaultValue="0" Name="strSNIP" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtProyecto" DefaultValue="0" Name="strProyecto" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="provinciaCB" DefaultValue="0" Name="strProvincia" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="distritoCB" DefaultValue="0" Name="strDistrito" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <img src="/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

        <telerik:radwindowmanager ID="RadWindowManager1" runat="server" Skin="WebBlue">
            <Windows>
                <telerik:radwindow ID="RadWindow1" runat="server" Behavior="Move, Close" Behaviors="Move, Close" 
                    Height="450px" InitialBehavior="Move, Close" InitialBehaviors="Move, Close" Left="" Modal="True" 
                    ReloadOnShow="True" Skin="WebBlue" Style="display: none;" Top="" 
                    VisibleStatusbar="false" Width="800px" Animation="Fade" ShowContentDuringLoad="False">
                </telerik:radwindow>
            </Windows>
        </telerik:radwindowmanager>

        <telerik:radajaxmanager ID="RadAjaxManager1" runat="server" 
            DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        </telerik:radajaxmanager>
        <telerik:radajaxloadingpanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:radajaxloadingpanel>
    </form>
    

</body>
</html>