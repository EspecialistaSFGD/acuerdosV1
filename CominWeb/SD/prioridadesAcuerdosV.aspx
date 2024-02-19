<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="prioridadesAcuerdosV.aspx.vb" Inherits="CominWeb.prioridadesAcuerdosV" %>
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

            function verOrdenServicioLog(codigo, codevento, codsector, secto) {
                location.href = "registroAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + codigo + "&codevento=" + codevento + "&codsector=" + codsector + "&secto=" + secto;
                return false;
            } 

            function frmnovado() {
                var codevento = document.getElementById('<%= cbo_evento.ClientID%>').value;
                location.href = "registroAcuerdosV.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=0&codevento=" + codevento + "&codsector=" + +'<%= Me.Request.QueryString("codsector")%>' + "&secto=0";
                return false;
            }

            function openWindowPrint() {
                $('#iframereporte').hide();
                var eventoId = document.getElementById('<%= cbo_evento.ClientID%>').value;
                var grupoId = document.getElementById('<%= grupoCB.ClientID%>').value;
                var departamento = document.getElementById('<%= cbo_departamento1.ClientID%>').value;
                var ubigeo = document.getElementById('<%= cbo_provincia1.ClientID%>').value;
                /*window.open("../SD/Reportes/Form_ReportAcuerdoIDDescarga.aspx?ordenServicioIDUltimo=" + ventaIDUltimo + "&tipoCambio=" + tipoCambio + "&subtotal=" + subtotal + "&igv=" + igv + "&total=" + total + "&letras=" + letras + "&abreviatura=" + abreviatura + "&tipoReporte=" + tipoReporte);*/
                window.open("../SD/Reportes/Form_ReportAcuerdoIDDescarga.aspx?eventoId=" + eventoId + "&grupoId=" + grupoId + "&departamento=" + departamento + "&ubigeo=" + ubigeo);
                mensaje('information', 'Descargando reporte...');
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
                      LISTA DE INTERVENCIONES
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:30px">
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                ESPACIO&nbsp;
                            </td>
                            <td style="width:70%">

                                <asp:DropDownList ID="cbo_evento" runat="server" Width="100%" Font-Size="11"
                                    DataSourceID="SDS_P_SelectEventos" DataTextField="nombre" class="form-control"
                                    DataValueField="eventoID" TabIndex="1" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                SECTOR&nbsp;
                            </td>
                            <td style="width:70%">
                                <asp:DropDownList ID="grupoCB" runat="server" Width="100%" Font-Size="11pt"
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
                                            DataValueField="departamentoID" AutoPostBack="true" Width="100%" TabIndex="12" class="form-control" Font-Size="11pt"
                                            AppendDataBoundItems="True">
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
                                        DataValueField="provinciaID" Width="100%" TabIndex="13" class="form-control" Font-Size="11pt">
                                    </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
        </div>

        <div class="col-md-3 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="buscar2" runat="server" Text="BUSCAR" class="styleMe" Width="100%" Height="50px" Font-Size="13" />
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="exportarB" runat="server" Text="EXPORTAR INTERVENCIONES" class="styleMe1" Width="100%" Height="50px" Font-Size="14" />
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <button class="styleMe" style="Width:100%; Height:50px; font:16pt" onclick="openWindowPrint(); return false;">IMPRIMIR ACUERDOS</button>
        </div>
        <div class="col-md-2 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="exportarBAcu" runat="server" Text="EXPORTAR ACUERDOS" class="styleMe1" Width="100%" Height="50px" Font-Size="14" />
        </div>
        <div class="col-md-3 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <%--<asp:Button ID="nuevoB" runat="server" Text="NUEVO PEDIDO" class="styleMe" Width="100%" Height="50px" Font-Size="14" />--%>
            <button class="styleMe" style="Width:100%; Height:50px; font:16pt" onclick="frmnovado(); return false;">NUEVO ASPECTO CRITICO A RESOLVER</button>
        </div><%--Bootstrap Glow    MetroTouch  --%>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center">

                <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES"  Width="100%"
                    DataSourceID="SDS_SD_P_selectPrioridadAcuerdo" Skin="Bootstrap"  
                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top">
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="SDS_SD_P_selectPrioridadAcuerdo" NoMasterRecordsText="No existen registros." PageSize="5">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                        <HeaderStyle Width="41px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" 
                        FilterControlAltText="Filter ExpandColumn column" Created="True">
                        <HeaderStyle Width="41px" />
                    </ExpandCollapseColumn>
                    <Columns>
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
                        <telerik:GridBoundColumn DataField="REGION" FilterControlAltText="Filter REGION column" 
                            HeaderText="Departamento" SortExpression="REGION" UniqueName="REGION" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROVINCIA" FilterControlAltText="Filter PROVINCIA column" 
                            HeaderText="Provincia" SortExpression="PROVINCIA" UniqueName="PROVINCIA" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="prioridadTerritorial" FilterControlAltText="Filter prioridadTerritorial column" 
                            HeaderText="Prioridad Territorial" SortExpression="prioridadTerritorial" UniqueName="prioridadTerritorial" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="objetivoEstrategicoTerritorial" FilterControlAltText="Filter objetivoEstrategicoTerritorial column" 
                            HeaderText="Objetivo Estrategico Territorial" SortExpression="objetivoEstrategicoTerritorial" UniqueName="objetivoEstrategicoTerritorial" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="intervencionesEstrategicas" FilterControlAltText="Filter intervencionesEstrategicas column" 
                            HeaderText="Intervenciones Estrategicas" SortExpression="intervencionesEstrategicas" UniqueName="intervencionesEstrategicas" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:gridtemplatecolumn DataField="intervencionesEstrategicas" FilterControlAltText="Filter intervencionesEstrategicas column" 
                            HeaderText="Intervenciones Estrategica" SortExpression="intervencionesEstrategicas" UniqueName="intervencionesEstrategicas" 
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                            ShowFilterIcon="false" >
                            <ItemTemplate>
                                <asp:HyperLink ID="Link" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:gridtemplatecolumn>
                        <telerik:GridBoundColumn DataField="aspectoCriticoResolver" FilterControlAltText="Filter aspectoCriticoResolver column" 
                            HeaderText="Aspecto Crítico a Resolver" SortExpression="aspectoCriticoResolver" UniqueName="aspectoCriticoResolver" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
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
    
    <asp:SqlDataSource ID="SDS_SD_P_selectPrioridadAcuerdo" runat="server"  
        SelectCommand="SD_P_selectPrioridadAcuerdo" 
        SelectCommandType="StoredProcedure" >
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="prioridadID" Type="Int32" />
            <asp:ControlParameter ControlID="cbo_evento" DefaultValue="0" Name="eventoId" PropertyName="Text" Type="String" />
            <%--<asp:QueryStringParameter DefaultValue="0" Name="grupoId" QueryStringField="codsector" Type="Int32" />--%>
            
            <asp:ControlParameter ControlID="grupoCB" DefaultValue="" Name="grupoId" PropertyName="SelectedValue" Type="Int32" />

            <asp:ControlParameter ControlID="cbo_departamento1" DefaultValue="" Name="departamento" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="cbo_provincia1" DefaultValue="" Name="ubigeo" PropertyName="SelectedValue" Type="Int32" />
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

        <iframe id="iframereporte" width="1" height="1" frameborder="0"></iframe>

        
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbo_departamento1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbo_provincia1" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>


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
