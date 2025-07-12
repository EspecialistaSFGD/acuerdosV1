<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_registrosInversion.aspx.vb" Inherits="CominWeb.Form_registrosInversion" %>
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
            font-size: 11px;
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
            font-size: 11px;
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

            function frmSituacion(id, inId, tinv, cinv, tip, nom) {
                var oWnd = $find("<%= RadWindow2.ClientID %>");
                var ruta_ventana = "registroTareaInv.aspx?gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codAv=" + id + "&inId=" + inId + "&iacp=3&tinv=" + tinv + "&cinv=" + cinv + "&tip=" + tip + "&nom=" + nom; <%--" + '<%= Me.Request.QueryString("iacp")%>' + "--%>
                oWnd.setUrl(ruta_ventana);
                oWnd.add_close(OnClientCloseA2);
                oWnd.show();
                return false;
            }

            function OnClientCloseA2(oWnd, eventArgs) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();
                oWnd.remove_close(OnClientCloseA2);
            }

            function verDetalle(codigoid) {
                location.href = "Form_registrosInversionDet.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" + '<%= Me.Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0")%>' + "&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + codigoid + "&view=0&pla=0&ksjcmj=" + '<%= Me.Request.QueryString("ksjcmj")%>' + "&tipo=" + '<%= Me.Request.QueryString("tipo")%>' + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&hsndktumg=" + '<%= Me.Request.QueryString("hsndktumg")%>' + "&en=" + '<%= Me.Request.QueryString("en")%>' + "&sup=" + '<%= Me.Request.QueryString("sup")%>' + "&enti=" + '<%= Me.Request.QueryString("enti")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                return false;
            }

        </script>
    </telerik:RadCodeBlock>
</head>
<body style="background: #ffffff;">
    <form id="form1" runat="server">

<%--        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:21px; padding-top:10px">
                      CARTERA TOTAL DE INVERSIONES
                </div>
          </div>
        </div>--%>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label2" runat="server" Font-Size="11px" Text="EVENTO" ></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">

                                <asp:DropDownList ID="cbo_evento" runat="server" Width="100%" class="form-control" Font-Size="11px"
                                    DataSourceID="SDS_P_SelectEventos" DataTextField="nombre" 
                                    DataValueField="eventoID" TabIndex="1" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label3" runat="server" Font-Size="11px" Text="GRUPO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">

                                <asp:DropDownList ID="autoridadCB" runat="server" DataSourceID="SDS_SD_P_selectAutoridad" DataTextField="nombre" 
                                    DataValueField="grupoID" Width="100%" TabIndex="13" class="form-control" Font-Size="11px" 
                                    AppendDataBoundItems="True" >
                                    <asp:ListItem Selected="True" Value="0" > - SELECCIONE - </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label1" runat="server" Font-Size="11px" Text="RANGO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:35%">
                                <telerik:raddatepicker ID="desdeRDP" runat="server" DateInput-AutoCompleteType="Disabled" TabIndex="16"
                                    Width="100%" Culture="es-PE" Skin="Bootstrap" AutoPostBack="true">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Bootstrap"></Calendar>
                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="11px"  >
                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                    <FocusedStyle Resize="None"></FocusedStyle>
                                    <DisabledStyle Resize="None"></DisabledStyle>
                                    <InvalidStyle Resize="None"></InvalidStyle>
                                    <HoveredStyle Resize="None"></HoveredStyle>
                                    <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>
                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:raddatepicker>    

                            </td>
                            <td style="width:5%">

                            </td>
                            <td style="width:35%">
                                <telerik:raddatepicker ID="hastaRDP" runat="server" DateInput-AutoCompleteType="Disabled" TabIndex="16"
                                    Width="100%" Culture="es-PE" Skin="Bootstrap" AutoPostBack="true">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Bootstrap"></Calendar>
                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="11px" >
                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                    <FocusedStyle Resize="None"></FocusedStyle>
                                    <DisabledStyle Resize="None"></DisabledStyle>
                                    <InvalidStyle Resize="None"></InvalidStyle>
                                    <HoveredStyle Resize="None"></HoveredStyle>
                                    <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>
                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:raddatepicker>    
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label4" runat="server" Font-Size="11px" Text="MODALIDAD"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                <asp:DropDownList ID="asistenteCB" runat="server" Width="100%" Font-Size="11px"
                                    class="form-control" TabIndex="5" AppendDataBoundItems="True" >
                                    <asp:ListItem Selected="True" Value="9" > - SELECCIONE - </asp:ListItem>
                                    <asp:ListItem Value="0" > ACREDITADO </asp:ListItem>
                                    <asp:ListItem Value="1" > ASISTENTE </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>


            </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center;">



            <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label5" runat="server" Font-Size="11px" Text="SECTOR" ></asp:Label>&nbsp;
                            </td>
                            
                            <td style="width:75%">
                                <asp:DropDownList ID="grupoCB" runat="server" Width="100%" Font-Size="11px" 
                                    DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                                    DataValueField="grupoID" TabIndex="2" AppendDataBoundItems="True" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0" > - SELECCIONE - </asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label6" runat="server" Font-Size="11px" Text="DEPARTAMENTO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                <asp:DropDownList ID="cbo_departamento1" runat="server" DataSourceID="SDS_P_selectDepartamento" DataTextField="departamento"
                                    DataValueField="departamentoID" AutoPostBack="true" Width="100%" TabIndex="3" class="form-control" Font-Size="11px" Height="35px"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" > - SELECCIONE - </asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label7" runat="server" Font-Size="11px" Text="PROVINCIA"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                 
                                <asp:DropDownList ID="cbo_provincia1" runat="server" DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" AutoPostBack="true"
                                    DataValueField="provinciaID" Width="100%" TabIndex="4" class="form-control" Font-Size="11px" Height="35px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label8" runat="server" Font-Size="11px" Text="DISTRITO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                 <asp:DropDownList ID="distritoCB" runat="server" Width="100%" DataSourceID="SDS_P_selectDistrito" DataTextField="DISTRITO" 
                                        DataValueField="distritoID" class="form-control" Font-Size="11px" AutoPostBack="true" >
                                    </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
        </div>


        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center;">

        <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:12.5%; font-weight:bold">
                                <asp:Label ID="Label9" runat="server" Font-Size="11px" Text="ENTIDAD" ></asp:Label>&nbsp;
                            </td>
                            <td style="">
                                <asp:DropDownList ID="entidadCB" runat="server" DataSourceID="SDS_SD_P_selectEntidades" DataTextField="nombre" 
                                    DataValueField="entidadId" Width="100%" TabIndex="6" class="form-control" Font-Size="11px"
                                    AppendDataBoundItems="True" Height="35px">
                                    <asp:ListItem Selected="True" Value="0" > - SELECCIONE - </asp:ListItem>
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <asp:Button ID="buscar2" runat="server" Text="BUSCAR" class="styleMe" Width="100%" Height="40px" Font-Size="10" />
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <asp:Button ID="exportarB" runat="server" Text="EXPORTAR" class="styleMe1" Width="100%" Height="40px" Font-Size="10" />
                </div>

        </div>
        
        <div class="col-md-4 col-sm-4 col-xs-12 form-group" style="text-align:center">
            
        </div>
        <div class="col-md-4 col-sm-4 col-xs-12 form-group" style="text-align:center">
            
        </div>
        <div class="col-md-4 col-sm-4 col-xs-12 form-group" style="text-align:center">
            
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <telerik:radgrid ID="RadGrid1" runat="server" Width="100%" Culture="es-ES" DataSourceID="SDS_SD_P_selectListInversiones" Skin="Bootstrap"
                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="false" GroupPanelPosition="Top" Font-Bold="True">
                <GroupingSettings CaseSensitive="false" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" CellSelectionMode="None" UseClientSelectColumnOnly="True" />
                </ClientSettings>
                <MasterTableView DataSourceID="SDS_SD_P_selectListInversiones" NoMasterRecordsText="No existen registros." PageSize="10"
                    DataKeyNames="inversionEspacioId" ClientDataKeyNames="inversionEspacioId" Font-Size="11px" >
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" 
                    FilterControlAltText="Filter ExpandColumn column" Created="True">
                </ExpandCollapseColumn>
                <Columns>

                    <telerik:GridBoundColumn DataField="inversionEspacioId" FilterControlAltText="Filter inversionEspacioId column" 
                        HeaderText="inversionEspacioId" ReadOnly="True" SortExpression="inversionEspacioId" UniqueName="inversionEspacioId"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="eventoId" FilterControlAltText="Filter eventoId column" 
                        HeaderText="eventoId" ReadOnly="True" SortExpression="eventoId" UniqueName="eventoId"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="inversionID" FilterControlAltText="Filter inversionID column" 
                        HeaderText="inversionID" ReadOnly="True" SortExpression="inversionID" UniqueName="inversionID"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="interaccionID" FilterControlAltText="Filter interaccionID column" 
                        HeaderText="interaccionID" ReadOnly="True" SortExpression="interaccionID" UniqueName="interaccionID"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="acuerdoID" FilterControlAltText="Filter acuerdoID column" 
                        HeaderText="acuerdoID" ReadOnly="True" SortExpression="acuerdoID" UniqueName="acuerdoID"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="tipoInversion" FilterControlAltText="Filter tipoInversion column" 
                        HeaderText="tipoInversion" ReadOnly="True" SortExpression="tipoInversion" UniqueName="tipoInversion"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="subTipoInversion" FilterControlAltText="Filter subTipoInversion column" 
                        HeaderText="subTipoInversion" ReadOnly="True" SortExpression="subTipoInversion" UniqueName="subTipoInversion"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="hitoID" FilterControlAltText="Filter hitoID column" 
                        HeaderText="hitoID" ReadOnly="True" SortExpression="hitoID" UniqueName="hitoID"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EtapaID" FilterControlAltText="Filter EtapaID column" 
                        HeaderText="EtapaID" ReadOnly="True" SortExpression="EtapaID" UniqueName="EtapaID"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="faseID" FilterControlAltText="Filter faseID column" 
                        HeaderText="faseID" ReadOnly="True" SortExpression="faseID" UniqueName="faseID"
                        Display="false">
                    </telerik:GridBoundColumn>


                    <telerik:GridBoundColumn DataField="descripcionTipoEvento" FilterControlAltText="Filter descripcionTipoEvento column" 
                        HeaderText="Tipo Espacio" SortExpression="descripcionTipoEvento" UniqueName="descripcionTipoEvento" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="espacio" FilterControlAltText="Filter espacio column" 
                        HeaderText="Espacio" SortExpression="espacio" UniqueName="espacio" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="codigo" FilterControlAltText="Filter codigo column" 
                        HeaderText="Acuerdo" SortExpression="codigo" UniqueName="codigo" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nomSector" FilterControlAltText="Filter nomSector column" 
                        HeaderText="Sector" SortExpression="nomSector" UniqueName="nomSector" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ubica" FilterControlAltText="Filter ubica column" 
                        HeaderText="Ubica" SortExpression="ubica" UniqueName="ubica" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="entidad" FilterControlAltText="Filter entidad column" 
                        HeaderText="Entidad" SortExpression="entidad" UniqueName="entidad" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="TipoInv" FilterControlAltText="Filter TipoInv column" 
                        HeaderText="Tipo" SortExpression="TipoInv" UniqueName="TipoInv" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SubTipoInv" FilterControlAltText="Filter SubTipoInv column" 
                        HeaderText="SubTipo" SortExpression="SubTipoInv" UniqueName="SubTipoInv" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="codigoInversion" FilterControlAltText="Filter codigoInversion column" 
                        HeaderText="Codigo" SortExpression="codigoInversion" UniqueName="codigoInversion" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Center" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nomProyecto" FilterControlAltText="Filter nomProyecto column" 
                        HeaderText="Nombre" SortExpression="nomProyecto" UniqueName="nomProyecto" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Center" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn  DataField="costoAct" FilterControlAltText="Filter costoAct column" 
                        HeaderText="Costo Act." SortExpression="costoAct" UniqueName="costoAct" AutoPostBackOnFilter="false" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" DataFormatString="{0:#,##0;(#,##0);0}" > <%--DataFormatString="{0:#,##0.0;(#,##0.0);0}"--%>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Right" Font-Size="11px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn DataField="devAcum" FilterControlAltText="Filter devAcum column" 
                        HeaderText="Dev Acum" SortExpression="devAcum" UniqueName="devAcum" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" DataFormatString="{0:#,##0;(#,##0);0}">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Right" Font-Size="11px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn DataField="pia" FilterControlAltText="Filter pia column" 
                        HeaderText="PIA" SortExpression="pia" UniqueName="pia" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" DataFormatString="{0:#,##0;(#,##0);0}">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Right" Font-Size="11px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn DataField="pim" FilterControlAltText="Filter pim column" 
                        HeaderText="PIM" SortExpression="pim" UniqueName="pim" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" DataFormatString="{0:#,##0;(#,##0);0}">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Right" Font-Size="11px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn DataField="dev" FilterControlAltText="Filter dev column" 
                        HeaderText="DEV" SortExpression="dev" UniqueName="dev" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" DataFormatString="{0:#,##0;(#,##0);0}">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Right" Font-Size="11px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn DataField="trans2025" FilterControlAltText="Filter trans2025 column" 
                        HeaderText="Transf 2025" SortExpression="trans2025" UniqueName="trans2025" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" DataFormatString="{0:#,##0;(#,##0);0}">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Right" Font-Size="11px" />
                    </telerik:GridNumericColumn>

                    <telerik:GridBoundColumn DataField="fechaSituacion" FilterControlAltText="Filter fechaSituacion column" 
                        HeaderText="Fecha" SortExpression="fechaSituacion" UniqueName="fechaSituacion" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" DataFormatString="{0:dd/MM/yyyy}" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="situacionActual" FilterControlAltText="Filter situacionActual column" 
                        HeaderText="Situación" SortExpression="situacionActual" UniqueName="situacionActual" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nomHito" FilterControlAltText="Filter nomHito column" 
                        HeaderText="Hito" SortExpression="nomHito" UniqueName="nomHito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nomEtapa" FilterControlAltText="Filter nomEtapa column" 
                        HeaderText="Etapa" SortExpression="nomEtapa" UniqueName="nomEtapa" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nomFase" FilterControlAltText="Filter nomFase column" 
                        HeaderText="Fase" SortExpression="nomFase" UniqueName="nomFase" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="11px" />
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridTemplateColumn FilterControlAltText="Filter situacionGTC column" HeaderTooltip="Estado Situacional"
                        HeaderText="Situacion" UniqueName="situacionGTC" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="situacionGTC" runat="server" CssClass="cursor" ToolTip="Estado Situacional"
                                    ImageUrl="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/report_edit.png"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                        <ItemStyle HorizontalAlign="Center" Font-Size="11px" />
                    </telerik:GridTemplateColumn>

                    <telerik:gridtemplatecolumn DataField="codigo" FilterControlAltText="Filter codigo column" 
                        HeaderText="Código" SortExpression="codigo" UniqueName="codigov" 
                        AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                        ShowFilterIcon="false" >
                        <ItemTemplate>
                            <asp:ImageButton ID="Link" runat="server" CssClass="cursor" ToolTip="Estado Situacional"
                                   ImageUrl="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/report_edit.png"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                        <ItemStyle HorizontalAlign="Left" Font-Bold="true" />
                    </telerik:gridtemplatecolumn>

                </Columns>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:radgrid>
        </div>
    
        <asp:SqlDataSource ID="SDS_SD_P_selectListInversiones" runat="server" 
            SelectCommand="SD_P_selectListInversiones" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>


<%--        <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="asistenciaId" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="nombre" Type="String" />
                <asp:ControlParameter ControlID="cbo_evento" DefaultValue="0" Name="eventoId" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="entidadCB" DefaultValue="0" Name="entidadId" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="dni" Type="String" />
                <asp:Parameter DefaultValue="0" Name="fecha" Type="String" />
                <asp:ControlParameter ControlID="asistenteCB" DefaultValue="9" Name="modalidad" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="autoridadCB" DefaultValue="9" Name="grupoid" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="desdeRDP" DefaultValue="01/01/2000" Name="desde" PropertyName="SelectedDate" Type="String" />
                <asp:ControlParameter ControlID="hastaRDP" DefaultValue="01/01/2000" Name="hasta" PropertyName="SelectedDate" Type="String" />
            </SelectParameters>--%>

        <asp:SqlDataSource ID="SDS_P_SelectEventos" runat="server" 
            SelectCommand="SD_P_selectEventos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="eventoId" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="enti" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="new" Type="Int32" />
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
            SelectCommand="SD_P_selectDepartamentoSD_cero" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_P_selectProvincia" runat="server" 
            ProviderName="System.Data.SqlClient" SelectCommand="SD_P_selectProvinciaSD" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbo_departamento1" DefaultValue="" Name="departamento" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_SD_P_selectEntidades" runat="server" 
            SelectCommand="SD_P_selectEntidadesFiltro" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="entidadId" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="tipo" Type="Int32" />
                <asp:ControlParameter ControlID="grupoCB" DefaultValue="0" Name="sectorId" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="hiddenFieldUbigeo" DefaultValue="0" Name="ubigeo" PropertyName="value" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_SD_P_selectAutoridad" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_P_selectDistrito" runat="server" 
            ProviderName="System.Data.SqlClient" SelectCommand="SD_P_selectDistritoSD" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbo_provincia1" DefaultValue="" 
                    Name="provincia" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <input id="hiddenFieldUbigeo" runat="server" type="hidden" value="0" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <img src="https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

            <telerik:radwindowmanager ID="RadWindowManager1" runat="server" Skin="Metro">
                <Windows>
                    <telerik:RadWindow ID="RadWindow2" runat="server" Behavior="Move, Close" Behaviors="Move, Close" Title=""
                        Height="400px" InitialBehavior="Move, Close" InitialBehaviors="Move, Close" Left="" Modal="True" 
                        ReloadOnShow="True" Skin="Metro" Style="display: none;" Top="" 
                        VisibleStatusbar="false" Width="800px" Animation="Fade"  >
                    </telerik:RadWindow>
                </Windows>
            </telerik:radwindowmanager>

        </form>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>



</body>
</html>
