<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_acreditadoList.aspx.vb" Inherits="CominWeb.Form_acreditadoList" %>
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

        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">

        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px">
                  <%--<br />--%>
                      LISTA DE ACREDITADOS
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:30px">
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:20%">
                                <asp:Label ID="Label2" runat="server" Font-Size="14" Text="EVENTO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:80%">

                                <asp:DropDownList ID="cbo_evento" runat="server" Width="90%" Font-Size="14"
                                    DataSourceID="SDS_P_SelectEventos" DataTextField="nombre" 
                                    DataValueField="eventoID" TabIndex="1" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" > - SELECCIONE EVENTO - </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                <asp:Label ID="Label3" runat="server" Font-Size="14" Text="GRUPO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:70%">
                                <asp:DropDownList ID="grupoCB" runat="server" Width="90%" Font-Size="14"
                                        DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" 
                                        DataValueField="grupoID" TabIndex="6" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0" > - SELECCIONE GRUPO - </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:20%">
                                <asp:Label ID="Label1" runat="server" Font-Size="14" Text="DESDE"></asp:Label>&nbsp;
                            </td>
                            <td style="width:80%">
                                <telerik:raddatepicker ID="desdeRDP" runat="server" DateInput-AutoCompleteType="Disabled"
                                    Width="95%" Culture="es-PE" MaxDate="2030-12-31"
                                    MinDate="2010-01-01" Skin="WebBlue">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue"></Calendar>
                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="14" ></DateInput>
                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:raddatepicker>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                <asp:Label ID="Label4" runat="server" Font-Size="14" Text="HASTA"></asp:Label>&nbsp;
                            </td>
                            <td style="width:70%">
                                <telerik:raddatepicker ID="hastaRDP" runat="server" DateInput-AutoCompleteType="Disabled"
                                    Width="95%" Culture="es-PE" MaxDate="2030-12-31"
                                    MinDate="2010-01-01" Skin="WebBlue">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue"></Calendar>
                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="14"></DateInput>
                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:raddatepicker>
                            </td>
                        </tr>
                    </table>
                </div>
        </div>

        <div class="col-md-6 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="buscar2" runat="server" Text="BUSCAR" class="styleMe" Width="100%" Height="50px" Font-Size="13" />
        </div>
        <div class="col-md-6 col-sm-12 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="exportarB" runat="server" Text="EXPORTAR" class="styleMe1" Width="100%" Height="50px" Font-Size="14" />
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center">
                <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES" 
                    DataSourceID="SDS_SD_P_selectAcreaditadosList" Skin="MetroTouch" 
                    AutoGenerateColumns="False" AllowFilteringByColumn="true" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top">
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="SDS_SD_P_selectAcreaditadosList" NoMasterRecordsText="No existen registros.">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" 
                        FilterControlAltText="Filter ExpandColumn column" Created="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="acreditadoId" FilterControlAltText="Filter acreditadoId column" 
                            HeaderText="acreditadoId" ReadOnly="True" SortExpression="acreditadoId" UniqueName="acreditadoId"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:gridboundcolumn DataField="fecha" DataType="System.DateTime" 
                            FilterControlAltText="Filter fecha column" HeaderText="Fecha" 
                            SortExpression="fecha" UniqueName="fecha"
                            DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="85px" />
                        </telerik:gridboundcolumn>
                        <telerik:GridBoundColumn DataField="NOMBRE" FilterControlAltText="Filter NOMBRE column" 
                            HeaderText="Evento" SortExpression="NOMBRE" UniqueName="NOMBRE" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dni" FilterControlAltText="Filter dni column" 
                            HeaderText="DNI" SortExpression="dni" UniqueName="dni" Display="true" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="nomGrupo" FilterControlAltText="Filter nomGrupo column" HeaderText="Grupo" 
                            SortExpression="nomGrupo" UniqueName="nomGrupo" AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                            ShowFilterIcon="true" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ape_paterno" FilterControlAltText="Filter ape_paterno column" 
                            HeaderText="A.Paterno" SortExpression="ape_paterno" UniqueName="ape_paterno" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ape_materno" FilterControlAltText="Filter ape_materno column" 
                            HeaderText="A.Materno" SortExpression="ape_materno" UniqueName="ape_materno" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="nombres" FilterControlAltText="Filter nombres column" 
                            HeaderText="Nombres" SortExpression="nombres" UniqueName="nombres" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="entidad" FilterControlAltText="Filter entidad column" 
                            HeaderText="Entidad" SortExpression="entidad" UniqueName="entidad" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cargo" FilterControlAltText="Filter cargo column" 
                            HeaderText="Cargo" SortExpression="cargo" UniqueName="cargo" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
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
    
    <asp:SqlDataSource ID="SDS_SD_P_selectAcreaditadosList" runat="server"  
        SelectCommand="SD_P_selectAcreaditadosList" 
        SelectCommandType="StoredProcedure" >
        <SelectParameters>
            <asp:ControlParameter ControlID="desdeRDP" DefaultValue="01/01/2000" 
                Name="Desde" PropertyName="SelectedDate" Type="String" />
            <asp:ControlParameter ControlID="hastaRDP" DefaultValue="01/01/2000" 
                Name="Hasta" PropertyName="SelectedDate" Type="String" />
            
            <%--<asp:Parameter DefaultValue="01/01/2000" Name="Desde" Type="String" />
            <asp:Parameter DefaultValue="01/01/2000" Name="Hasta" Type="String" />--%>

            <asp:Parameter DefaultValue="0" Name="asistenciaId" Type="Int32" />
            
            <asp:Parameter DefaultValue="0" Name="DNI" Type="String" />
            <asp:Parameter DefaultValue="0" Name="nombre" Type="String" />
            <asp:ControlParameter ControlID="cbo_evento" DefaultValue="0" 
                Name="eventoId" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="grupoCB" DefaultValue="0" 
                Name="grupoId" PropertyName="Text" Type="String" />
            <%--<asp:ControlParameter ControlID="txtEquipo" DefaultValue="0" Name="equipoID" PropertyName="Text" Type="String" />--%>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_SelectEventos" runat="server" 
        SelectCommand="SD_P_selectEventos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="eventoId" Type="Int32" />
            <asp:Parameter DefaultValue="2" Name="tipo" Type="Int32" />
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
<img src="https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

        </form>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
</html>
