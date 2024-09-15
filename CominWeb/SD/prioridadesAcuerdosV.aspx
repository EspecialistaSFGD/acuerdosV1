<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="prioridadesAcuerdosV.aspx.vb" Inherits="CominWeb.prioridadesAcuerdosV" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://sesigue.com/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
    <link href="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.css" rel="stylesheet" type="text/css" />
    <link href="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/build/css/custom.min.css" rel="stylesheet" type="text/css" />
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

            var default1 = "SESIGUE 1.1.2";
            var text1 = "© Copyright 2024";
            var text2 = "LIMA - PERU";
            var text3 = "SESIGUE 1.1.2";
            var changeRate = 2000; // 1000 = 1 second
            var messageNumber = 0;


            function changeStatus() {
                if (messageNumber == 0) {
                    window.status = default1;
                    document.title = default1;
                }
                else if (messageNumber == 1) {
                    window.status = text1;
                    document.title = text1;
                }
                else if (messageNumber == 2) {
                    window.status = text2;
                    document.title = text2;
                }
                else if (messageNumber == 3) {
                    window.status = text3;
                    document.title = text3;
                }
                messageNumber++;
                setTimeout("changeStatus();", changeRate);
            }

            changeStatus();

            window.setInterval("renewSession();", 30000);

            function renewSession() {
                console.log("Renovando session...");
                document.getElementById('renewSession').src = 'https://sesigue.com/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
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

            function verOrdenServicioLog(codigo, codevento, codsector, secto, preacuerdo) {
                location.href = "registroAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + codigo + "&codevento=" + codevento + "&codsector=" + codsector + "&secto=" + secto + "&enti=" + '<%= Me.Request.QueryString("enti")%>' + "&tipo=" + '<%= Me.Request.QueryString("tipo")%>' + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&sup=" + '<%= Me.Request.QueryString("sup")%>' + "&en=" + '<%= Me.Request.QueryString("en")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>' + "&preacuerdo=" + preacuerdo;
                return false;
            } 

            function frmnovado(id) {

                var enti = '<%= Me.Request.QueryString("en")%>';
                debugger;
                if (enti != 9999)
                {
                    var ambit = '<%= Me.Request.QueryString("amb")%>';
                    var ubi = '<%= Me.Request.QueryString("ubig")%>';
                    var codsector = '<%= Me.Request.QueryString("codsector")%>';

                    if (codsector == 0) {
                        var csec = '<%= Me.Request.QueryString("sup")%>';
                        if (csec != 0) {
                            mensaje('error', 'Acceso denegado');
                            return true;
                        }
                        else {

                            if (ambit == "R") {
                                if (ubi.substr(2, 3) == "000") {
                                    var oWnd = $find("<%= RadWindow2.ClientID %>");
                                    var codevento = document.getElementById('<%= cbo_evento.ClientID%>').value;
                                    var ruta_ventana_empresas = "registroPedidoV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + id + "&codevento=" + codevento + "&codsector=" + +'<%= Me.Request.QueryString("codsector")%>' + "&secto=0&ubig=" + +'<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                                    oWnd.setUrl(ruta_ventana_empresas);
                                    oWnd.add_close(OnClientClose1);
                                    oWnd.show();
                                    return false;

                                }
                                else {
                                    mensaje('error', 'Acceso denegado');
                                    return true;
                                }
                            }
                            else if (ambit == "D") {
                                if (ubi.substr(2, 3) != "000") {
                                    var oWnd = $find("<%= RadWindow2.ClientID %>");
                                    var codevento = document.getElementById('<%= cbo_evento.ClientID%>').value;
                                    var ruta_ventana_empresas = "registroPedidoV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + id + "&codevento=" + codevento + "&codsector=" + +'<%= Me.Request.QueryString("codsector")%>' + "&secto=0&ubig=" + +'<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                                    oWnd.setUrl(ruta_ventana_empresas);
                                    oWnd.add_close(OnClientClose1);
                                    oWnd.show();
                                    return false;

                                }
                                else {
                                    mensaje('error', 'Acceso denegado');
                                    return true;
                                }
                            }
                            else {
                                var oWnd = $find("<%= RadWindow2.ClientID %>");
                                var codevento = document.getElementById('<%= cbo_evento.ClientID%>').value;
                                var ruta_ventana_empresas = "registroPedidoV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + id + "&codevento=" + codevento + "&codsector=" + +'<%= Me.Request.QueryString("codsector")%>' + "&secto=0&ubig=" + +'<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                                oWnd.setUrl(ruta_ventana_empresas);
                                oWnd.add_close(OnClientClose1);
                                oWnd.show();
                                return false;
                            }



                        }
                    }
                    else {

                        var csec = '<%= Me.Request.QueryString("sup")%>';
                        if (csec == 0) {
                            mensaje('error', 'Acceso solo para el sector');
                            return true;
                        }
                        else {

                            var codevento = document.getElementById('<%= cbo_evento.ClientID%>').value;
                            location.href = "registroAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=0&codevento=" + codevento + "&codsector=" + +'<%= Me.Request.QueryString("codsector")%>' + "&secto=0&enti=" + '<%= Me.Request.QueryString("enti")%>' + "&tipo=" + '<%= Me.Request.QueryString("tipo")%>' + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&sup=" + '<%= Me.Request.QueryString("sup")%>' + "&en=" + '<%= Me.Request.QueryString("en")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>' + "&preacuerdo=" + '<%= Me.Request.QueryString("preacuerdo")%>';
                            return false;
                        }
                    }
                }
                else {
                    mensaje('error', 'Acceso denegado');
                }
                
            }

            function openWindowPrint() {
                /*mensaje('warning', "No disponible hasta el día del evento")*/
                $('#iframereporte').hide();
                var eventoId = document.getElementById('<%= cbo_evento.ClientID%>').value;
                var grupoId = document.getElementById('<%= grupoCB.ClientID%>').value;
                var departamento = document.getElementById('<%= cbo_departamento1.ClientID%>').value;
                var ubigeo = document.getElementById('<%= cbo_provincia1.ClientID%>').value;
                window.open("../SD/Reportes/Form_ReportAcuerdoIDDescarga.aspx?eventoId=" + eventoId + "&grupoId=" + grupoId + "&departamento=" + departamento + "&ubigeo=" + ubigeo);
                mensaje('information', 'Descargando reporte...');
            }

            function verPedidoLog(codigo, codevento, codsector, secto) {
                location.href = "registroPedidoV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + codigo + "&codevento=" + codevento + "&codsector=" + codsector + "&secto=" + secto + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                return false;
            }

            function verB12(cui) {
                window.open('https://ofi5.mef.gob.pe/inviertews/Repseguim/ResumF12B?codigo=' + cui, '_blank');
                return false;
            }

           <%-- function frmNewPedido(id) {
                var csec = '<%= Me.Request.QueryString("sup")%>';
                if (csec != 0) {
                    mensaje('error', 'Acceso denegado');
                    return true;
                }
                else {
                    var oWnd = $find("<%= RadWindow2.ClientID %>");
                    var codevento = document.getElementById('<%= cbo_evento.ClientID%>').value;
                    var ruta_ventana_empresas = "registroPedidoV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + id + "&codevento=" + codevento + "&codsector=" + +'<%= Me.Request.QueryString("codsector")%>' + "&secto=0&ubig=" + +'<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                    oWnd.setUrl(ruta_ventana_empresas);
                    oWnd.add_close(OnClientClose1);
                    oWnd.show();
                    return false;
                }
            }--%>

            function deleteAvan(id) {
                var ubig = '<%= Me.Request.QueryString("ubig")%>';
                var sup = '<%= Me.Request.QueryString("sup")%>';

                //if (ubig > 0) {
                //    mensaje('error', 'Acceso solo para el sector.');
                //}
                //else if (sup == 0) {
                //    mensaje('error', 'Acceso solo para el sector.');
                //}
                //else if (sup == 2) {
                //    mensaje('error', 'Acceso solo para el sector.');
                //}
                //else {
                    var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                    ajaxManager.ajaxRequest("deleteAvan," + id);
                //}
                var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();
                return false;
            }

            function OnClientClose1(oWnd, eventArgs) {
                var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();
                oWnd.remove_close(OnClientClose1);
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
                return false;
            }

            function frmValidacionPed(id) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("frmValidacionPed," + id);
                actualizaGr()
                mensaje('warning', "Se validó el Pedido")
                return false;
            }

            function actualizaGr() {
                var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();
            }

            function frmComentario(id, est) {
                debugger;
                if (est == 1) {
                    mensaje('warning', "Pedido validado, no se pueden realizar comentarios")
                }
                else {
                    var oWnd = $find("<%= RadWindow2.ClientID %>");
                    var ruta_ventana_empresas = "registroComentario.aspx?gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codAv=" + id + "&tipo=PRI";
                    oWnd.setUrl(ruta_ventana_empresas);
                    oWnd.add_close(OnClientClose1);
                    oWnd.show();
                }
                return false;
            }

        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_nav">
            <img id="Img2" runat="server" src="https://sesigue.com/REFERENCIASBASE/Resources/sd_cabecera_web.png" style="width:100%" />
        </div>
        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px">
                  <%--<br />--%>
                        <asp:Label ID="titulo2LB" runat="server" Font-Bold="False" Font-Size="17pt" Text="" style="font-weight: 600;"></asp:Label>
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:30px">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                ESPACIO&nbsp;
                            </td>
                            <td style="width:70%">

                                <asp:DropDownList ID="cbo_evento" runat="server" Width="100%" Font-Size="11" Enabled="false"
                                    DataSourceID="SDS_P_SelectEventos" DataTextField="nombre" class="form-control" Height="30px"
                                    DataValueField="eventoID" TabIndex="1" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                SECTOR&nbsp;
                            </td>
                            <td style="width:70%">
                                <asp:DropDownList ID="grupoCB" runat="server" Width="100%" Font-Size="11pt" Height="30px"
                                        DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                                        DataValueField="grupoID" TabIndex="6" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                DEPARTAMENTO&nbsp;
                            </td>
                            <td style="width:70%">
                                <asp:DropDownList ID="cbo_departamento1" runat="server" DataSourceID="SDS_P_selectDepartamento" DataTextField="departamento" 
                                            DataValueField="departamentoID" Width="100%" TabIndex="12" class="form-control" Font-Size="11pt"
                                            AppendDataBoundItems="True" Height="30px">
                                            <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                    </asp:DropDownList>
                                
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                PROVINCIA&nbsp;
                            </td>
                            <td style="width:70%">
                                <asp:DropDownList ID="cbo_provincia1" runat="server" DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" 
                                        DataValueField="provinciaID" Width="100%" TabIndex="13" class="form-control" Font-Size="11pt" Height="30px">
                                    </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                DISTRITO&nbsp;
                            </td>
                            <td style="width:70%">
                                    <asp:DropDownList ID="cbo_distrito" runat="server" DataSourceID="SDS_P_selectDistrito" DataTextField="DISTRITO" AutoPostBack="true"
                                        DataValueField="distritoID" Width="100%" TabIndex="13" class="form-control" Font-Size="11pt" Height="30px">
                                    </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
        </div>

        <div class="col-md-2 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="buscar2" runat="server" Text="BUSCAR" class="styleMe" Width="100%" Height="50px" Font-Size="10pt" />
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="exportarB" runat="server" Text="EXPORTAR PEDIDOS" class="styleMe1" Width="100%" Height="50px" Font-Size="10pt" />
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <button class="styleMe" style="Width:100%; Height:50px;" onclick="openWindowPrint(); return false;">IMPRIMIR ACUERDOS</button>
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="exportarBAcu" runat="server" Text="EXPORTAR ACUERDOS" class="styleMe1" Width="100%" Height="50px" Font-Size="10pt" />
        </div>
        <div class="col-md-4 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <button id="nPedido" runat="server" class="styleMe" style="Width:100%; Height:50px; " onclick="frmnovado(0); return false;">NUEVO PEDIDO</button>
        </div><%--Bootstrap Glow    MetroTouch  --%>


        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center">

                <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES"  Width="100%"
                    DataSourceID="SDS_SD_P_selectPrioridadAcuerdo" Skin="Bootstrap"  
                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top">
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="SDS_SD_P_selectPrioridadAcuerdo" NoMasterRecordsText="No existen registros." PageSize="10">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                        <HeaderStyle Width="41px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" 
                        FilterControlAltText="Filter ExpandColumn column" Created="True">
                        <HeaderStyle Width="41px" />
                    </ExpandCollapseColumn>
                    <Columns>

                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                            HeaderText="Edit" UniqueName="TemplateColumnEstado" AllowFiltering="false" >
                            <ItemTemplate>
                                    <asp:ImageButton ID="edita" runat="server" CssClass="cursor" ToolTip="Editar"
                                        ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/editar_grilla.png"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>


                        <telerik:GridBoundColumn DataField="prioridadID" FilterControlAltText="Filter prioridadID column" 
                            HeaderText="prioridadID" ReadOnly="True" SortExpression="prioridadID" UniqueName="prioridadID"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="eventoId" FilterControlAltText="Filter eventoId column" 
                            HeaderText="eventoId" ReadOnly="True" SortExpression="eventoId" UniqueName="eventoId"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="espacio" FilterControlAltText="Filter espacio column" 
                            HeaderText="Espacio" SortExpression="espacio" UniqueName="espacio" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sectorid" FilterControlAltText="Filter sectorid column" 
                            HeaderText="sectorid" ReadOnly="True" SortExpression="sectorid" UniqueName="sectorid"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sector" FilterControlAltText="Filter sector column" 
                            HeaderText="Sector" SortExpression="sector" UniqueName="sector" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ubigeo" FilterControlAltText="Filter ubigeo column" 
                            HeaderText="ubigeo" ReadOnly="True" SortExpression="ubigeo" UniqueName="ubigeo"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UBICA" FilterControlAltText="Filter UBICA column" 
                            HeaderText="Ubicación" SortExpression="UBICA" UniqueName="UBICA" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="true">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REGION" FilterControlAltText="Filter REGION column" 
                            HeaderText="Departamento" SortExpression="REGION" UniqueName="REGION" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROVINCIA" FilterControlAltText="Filter PROVINCIA column" 
                            HeaderText="Provincia" SortExpression="PROVINCIA" UniqueName="PROVINCIA" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="objetivoEstrategicoTerritorial" FilterControlAltText="Filter objetivoEstrategicoTerritorial column" 
                            HeaderText="Obj. Estrategico" SortExpression="objetivoEstrategicoTerritorial" UniqueName="objetivoEstrategicoTerritorial" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="intervencionesEstrategicas" FilterControlAltText="Filter intervencionesEstrategicas column" 
                            HeaderText="Intervenciones Estrategicas" SortExpression="intervencionesEstrategicas" UniqueName="intervencionesEstrategicasv1" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:gridtemplatecolumn DataField="intervencionesEstrategicas" FilterControlAltText="Filter intervencionesEstrategicas column" 
                            HeaderText="Tipo Intervención" SortExpression="intervencionesEstrategicas" UniqueName="intervencionesEstrategicas" 
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                            ShowFilterIcon="false" >
                            <ItemTemplate>
                                <asp:HyperLink ID="Link" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:gridtemplatecolumn>
                        <telerik:GridBoundColumn DataField="aspectoCriticoResolver" FilterControlAltText="Filter aspectoCriticoResolver column" 
                            HeaderText="Pedido" SortExpression="aspectoCriticoResolver" UniqueName="aspectoCriticoResolver" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cui" FilterControlAltText="Filter cui column" 
                            HeaderText="CUI" SortExpression="cui" UniqueName="cui" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="validado" FilterControlAltText="Filter validado column" 
                            HeaderText="validado" SortExpression="validado" UniqueName="validado" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                        </telerik:GridBoundColumn>
                        <%--<telerik:gridtemplatecolumn DataField="cui" FilterControlAltText="Filter cui column" 
                            HeaderText="CUI" SortExpression="cui" UniqueName="Linkcui" 
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                            ShowFilterIcon="false" >
                            <ItemTemplate>
                                <asp:HyperLink ID="Linkcui" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:gridtemplatecolumn>--%>
                        <telerik:gridtemplatecolumn DataField="ciuProy" FilterControlAltText="Filter ciuProy column" 
                            HeaderText="CUI" SortExpression="ciuProy" UniqueName="Linkcui" 
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                            ShowFilterIcon="false" >
                            <ItemTemplate>
                                <asp:HyperLink ID="Linkcui" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:gridtemplatecolumn>
                        <telerik:GridBoundColumn DataField="cantidadPreAcuerdos" FilterControlAltText="Filter cantidadPreAcuerdos column" 
                            HeaderText="Pre-Acuerdos" SortExpression="cantidadPreAcuerdos" UniqueName="cantidadPreAcuerdos" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Center" Font-Size="Large" />
                        </telerik:GridBoundColumn>
                        <telerik:gridtemplatecolumn DataField="cantidadAcuerdos" FilterControlAltText="Filter cantidadAcuerdos column" 
                            HeaderText="Acuerdos" SortExpression="cantidadAcuerdos" UniqueName="cantidadAcuerdos" 
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                            ShowFilterIcon="false" >
                            <ItemTemplate>
                                <asp:HyperLink ID="LinkCant" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Center" Font-Size="Large" />
                        </telerik:gridtemplatecolumn>
                        <telerik:GridBoundColumn DataField="comentarioPCM" FilterControlAltText="Filter comentarioPCM column" 
                            HeaderText="Comentario PCM" SortExpression="comentarioPCM" UniqueName="comentarioPCM" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                            HeaderText="Eli" UniqueName="TemplateColumnDelete" AllowFiltering="false" >
                            <ItemTemplate>
                                    <asp:ImageButton ID="eliminaP" runat="server" CssClass="cursor" 
                                        ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/CancelG.png"
                                        ToolTip="Eliminar" UseSubmitBehavior="False"
                                        OnClientClick="javascript: if(!confirm('¿Desea Eliminar el Pedido?')){return false;}"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TCComentario column" HeaderTooltip="Crear Comentario"
                            HeaderText="PCM" UniqueName="TCComentario" AllowFiltering="false" >
                            <ItemTemplate>
                                    <asp:ImageButton ID="TCComentario" runat="server" CssClass="cursor" ToolTip="Crear Comentario"
                                        ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/PCM_32_n.png"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter Llave column" HeaderTooltip="Validar Pedido"
                            HeaderText="Valida PCM" UniqueName="TCValida" AllowFiltering="false" >
                            <ItemTemplate>
                                    <asp:ImageButton ID="TCValida" runat="server" CssClass="cursor" 
                                        ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/peligro_20.png"
                                        ToolTip="Validar Acción" UseSubmitBehavior="False"
                                        OnClientClick="javascript: if(!confirm('¿Desea validar el pedido?')){return false;}"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
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
    <%--<asp:QueryStringParameter DefaultValue="0" Name="grupoId" QueryStringField="codsector" Type="Int32" />--%>
    <asp:SqlDataSource ID="SDS_SD_P_selectPrioridadAcuerdo" runat="server"  
        SelectCommand="SD_P_selectPrioridadAcuerdo" 
        SelectCommandType="StoredProcedure" >
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="prioridadID" Type="Int32" />
            <asp:ControlParameter ControlID="cbo_evento" DefaultValue="0" Name="eventoId" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="grupoCB" DefaultValue="" Name="grupoId" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="cbo_departamento1" DefaultValue="" Name="departamento" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="cbo_distrito" DefaultValue="" Name="ubigeo" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_SelectEventos" runat="server" 
        SelectCommand="SD_P_selectEventos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="eventoId" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_SD_P_selectGrupos" runat="server" 
        SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
            <asp:Parameter DefaultValue="2" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectDepartamento" runat="server" 
        SelectCommand="SD_P_selectDepartamentoSD" SelectCommandType="StoredProcedure">
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
        <asp:SqlDataSource ID="SDS_P_selectDistrito" runat="server" 
            ProviderName="System.Data.SqlClient" SelectCommand="SD_P_selectDistritoSD" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbo_provincia1" DefaultValue="" Name="provincia" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>


        <iframe id="iframereporte" width="1" height="1" frameborder="0"></iframe>

    <telerik:radwindowmanager ID="RadWindowManager1" runat="server" Skin="WebBlue">
        <Windows>
            <telerik:RadWindow ID="RadWindow2" runat="server" Behavior="Move, Close" Behaviors="Move, Close" 
                Height="650px" InitialBehavior="Move, Close" InitialBehaviors="Move, Close" Left="" Modal="True" 
                ReloadOnShow="True" Skin="Metro" Style="display: none;" Top="" Title="Crear o Modificar Pedido" 
                VisibleStatusbar="false" Width="950px" Animation="Fade">
            </telerik:RadWindow>
        </Windows>
    </telerik:radwindowmanager>
       
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="">
       <%-- <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            </AjaxSettings>--%>
      </telerik:RadAjaxManager>


<img src="https://sesigue.com/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

        </form>
<%--    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.com/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>--%>

</body>
<footer>
    <img src="https://sesigue.com/REFERENCIASBASE/Resources/sd_inferior_web.png" style="width:100%" />
</footer>
</html>
