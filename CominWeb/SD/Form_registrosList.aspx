<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_registrosList.aspx.vb" Inherits="CominWeb.Form_registrosList" %>
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
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px; padding-top:5px">
                  <%--<br />--%>
                      Lista de Participantes por Espacio de Articulación
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label2" runat="server" Font-Size="9" Text="EVENTO" ></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">

                                <asp:DropDownList ID="cbo_evento" runat="server" Width="100%" class="form-control" Font-Size="9"
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
                                <asp:Label ID="Label3" runat="server" Font-Size="9" Text="GRUPO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">

                                <asp:DropDownList ID="autoridadCB" runat="server" DataSourceID="SDS_SD_P_selectAutoridad" DataTextField="nombre" 
                                    DataValueField="grupoID" Width="100%" TabIndex="13" class="form-control" Font-Size="9" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label1" runat="server" Font-Size="9" Text="RANGO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:35%">
                                <telerik:raddatepicker ID="desdeRDP" runat="server" DateInput-AutoCompleteType="Disabled" TabIndex="16"
                                    Width="100%" Culture="es-PE" Skin="Bootstrap" AutoPostBack="true">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Bootstrap"></Calendar>
                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="9"  >
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
                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="9" >
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
                                <asp:Label ID="Label4" runat="server" Font-Size="9" Text="MODALIDAD"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                <asp:DropDownList ID="asistenteCB" runat="server" Width="100%" Font-Size="9"
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
                                <asp:Label ID="Label5" runat="server" Font-Size="9" Text="SECTOR" ></asp:Label>&nbsp;
                            </td>
                            
                            <td style="width:75%">
                                <asp:DropDownList ID="grupoCB" runat="server" Width="100%" Font-Size="9" 
                                    DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                                    DataValueField="grupoID" TabIndex="2" AutoPostBack="true">
                            </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label6" runat="server" Font-Size="9" Text="DEPARTAMENTO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                <asp:DropDownList ID="cbo_departamento1" runat="server" DataSourceID="SDS_P_selectDepartamento" DataTextField="departamento"
                                    DataValueField="departamentoID" AutoPostBack="true" Width="100%" TabIndex="3" class="form-control" Font-Size="9" Height="35px">
                            </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label7" runat="server" Font-Size="9" Text="PROVINCIA"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                 
                                <asp:DropDownList ID="cbo_provincia1" runat="server" DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" AutoPostBack="true"
                                    DataValueField="provinciaID" Width="100%" TabIndex="4" class="form-control" Font-Size="9" Height="35px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:25%; font-weight:bold">
                                <asp:Label ID="Label8" runat="server" Font-Size="9" Text="DISTRITO"></asp:Label>&nbsp;
                            </td>
                            <td style="width:75%">
                                 <asp:DropDownList ID="distritoCB" runat="server" Width="100%" DataSourceID="SDS_P_selectDistrito" DataTextField="DISTRITO" 
                                        DataValueField="distritoID" class="form-control" Font-Size="9" AutoPostBack="true" >
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
                                <asp:Label ID="Label9" runat="server" Font-Size="9" Text="ENTIDAD" ></asp:Label>&nbsp;
                            </td>
                            <td style="">
                                <asp:DropDownList ID="entidadCB" runat="server" DataSourceID="SDS_SD_P_selectEntidades" DataTextField="nombre" 
                                    DataValueField="entidadId" Width="100%" TabIndex="6" class="form-control" Font-Size="9"
                                    AppendDataBoundItems="True" Height="35px">
                                    <asp:ListItem Selected="True" Value="0" > - SELECCIONE - </asp:ListItem>
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">


                    <table width="100%">
                        <tr>
                            <td style="width:48%">
                                   <asp:Button ID="registroB" runat="server" Text="REGISTRO ASISTENCIA" class="styleMe1" Width="100%" Height="40px" Font-Size="10" />
                            </td>
                            <td style="width:4%">

                            </td>
                            <td style="width:48%">
                                <asp:Button ID="buscar2" runat="server" Text="BUSCAR" class="styleMe" Width="100%" Height="40px" Font-Size="10" />
                                
                            </td>
                        </tr>
                    </table>


                    
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
            <telerik:radgrid ID="RadGrid1" runat="server" Width="100%" Culture="es-ES" DataSourceID="SDS_SD_P_selectAcreaditadosList" Skin="Bootstrap" 
                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="true" GroupPanelPosition="Top" Font-Bold="True">
                <GroupingSettings CaseSensitive="false" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" CellSelectionMode="None" UseClientSelectColumnOnly="True" />
                </ClientSettings>
                <MasterTableView DataSourceID="SDS_SD_P_selectAcreaditadosList" NoMasterRecordsText="No existen registros." PageSize="15"
                    DataKeyNames="asistenciaId" ClientDataKeyNames="asistenciaId" >
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" 
                    FilterControlAltText="Filter ExpandColumn column" Created="True">
                </ExpandCollapseColumn>
                <Columns>

                    <telerik:GridBoundColumn DataField="asistenciaId" FilterControlAltText="Filter asistenciaId column" 
                        HeaderText="asistenciaId" ReadOnly="True" SortExpression="asistenciaId" UniqueName="asistenciaId"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="eventoId" FilterControlAltText="Filter eventoId column" 
                        HeaderText="eventoId" ReadOnly="True" SortExpression="eventoId" UniqueName="eventoId"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="asistenteId" FilterControlAltText="Filter asistenteId column" 
                        HeaderText="asistenteId" ReadOnly="True" SortExpression="asistenteId" UniqueName="asistenteId"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="entidadId" FilterControlAltText="Filter entidadId column" 
                        HeaderText="entidadId" ReadOnly="True" SortExpression="entidadId" UniqueName="entidadId"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="grupoID" FilterControlAltText="Filter grupoID column" 
                        HeaderText="grupoID" ReadOnly="True" SortExpression="grupoID" UniqueName="grupoID"
                        Display="false">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="espacio" FilterControlAltText="Filter espacio column" 
                        HeaderText="ESPACIO" SortExpression="espacio" UniqueName="espacio" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nomTipo" FilterControlAltText="Filter nomTipo column" 
                        HeaderText="NIVEL" SortExpression="nomTipo" UniqueName="nomTipo" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller" Width="70px" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="departamento" FilterControlAltText="Filter departamento column" 
                        HeaderText="Departamento" SortExpression="departamento" UniqueName="departamento" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Provincia" FilterControlAltText="Filter provincia column" 
                        HeaderText="Provincia" SortExpression="provincia" UniqueName="hito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="entidad" FilterControlAltText="Filter entidad column" 
                        HeaderText="ENTIDAD" SortExpression="entidad" UniqueName="entidad" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nombre" FilterControlAltText="Filter nombre column" 
                        HeaderText="GRUPO" SortExpression="nombre" UniqueName="nombre" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="cargo" FilterControlAltText="Filter cargo column" 
                        HeaderText="cargo" SortExpression="cargo" UniqueName="cargo" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DNI" FilterControlAltText="Filter DNI column" 
                        HeaderText="DNI" SortExpression="DNI" UniqueName="DNI" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="False">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="acreditado" FilterControlAltText="Filter acreditado column" 
                        HeaderText="ACREDITADO" SortExpression="acreditado" UniqueName="acreditado" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="telefono" FilterControlAltText="Filter telefono column" 
                        HeaderText="TELEFONO" SortExpression="telefono" UniqueName="telefono" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="False">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="email" FilterControlAltText="Filter email column" 
                        HeaderText="CORREO" SortExpression="email" UniqueName="email" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="False">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                    <telerik:gridboundcolumn DataField="dia_evento" DataType="System.DateTime" 
                        FilterControlAltText="Filter dia_evento column" HeaderText="FECHA" 
                        SortExpression="dia_evento" UniqueName="dia_evento"
                        DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="False" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller"/>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Smaller"/>
                    </telerik:gridboundcolumn>
                    <telerik:GridBoundColumn DataField="asiste" FilterControlAltText="Filter asiste column" 
                        HeaderText="ASISTENCIA" SortExpression="asiste" UniqueName="asiste" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="False">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller" Width="90px"/>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Smaller" Font-Bold="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="asi_plenaria" FilterControlAltText="Filter asi_plenaria column" 
                        HeaderText="PLENARIA" SortExpression="asi_plenaria" UniqueName="asi_plenaria" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="False">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Smaller" Width="90px"/>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Smaller" />
                    </telerik:GridBoundColumn>
                </Columns>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:radgrid>
        </div>
    
        <asp:SqlDataSource ID="SDS_SD_P_selectAcreaditadosList" runat="server" 
            SelectCommand="SD_P_selectAcreaditadosList" SelectCommandType="StoredProcedure">
            <SelectParameters>
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
            </SelectParameters>
        </asp:SqlDataSource>


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

        </form>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
</html>
