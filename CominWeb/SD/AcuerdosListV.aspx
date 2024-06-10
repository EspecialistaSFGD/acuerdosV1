<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AcuerdosListV.aspx.vb" Inherits="CominWeb.AcuerdosListV" %>
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

            $(document).keydown(function (e) {
                if (e.keyCode == 13) {
                    refreshGrid();
                    return false;
                }
            });

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
                document.getElementById('renewSession').src = 'https://sesigue.com/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
            }

            function verHitos(codigoid, estReg, estRegInt) {
                location.href = "registroHitoV.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" + '<%= Me.Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0")%>' + "&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codigoid=" + codigoid + "&estReg=" + estReg + "&view=0&pla=0&ksjcmj=" + '<%= Me.Request.QueryString("ksjcmj")%>' + "&tipo=" + '<%= Me.Request.QueryString("tipo")%>' + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&hsndktumg=" + '<%= Me.Request.QueryString("hsndktumg")%>' + "&en=" + '<%= Me.Request.QueryString("en")%>' + "&sup=" + '<%= Me.Request.QueryString("sup")%>' + "&enti=" + '<%= Me.Request.QueryString("enti")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                return false;
            }

            function actua() {
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("actualiza");
                refreshGrid();
            }

            function refreshGrid() {
                var masterTable = $find("<%=radGrid1.clientId%>").get_masterTableView();
                masterTable.rebind();
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
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; margin-top:10px; font-weight:bold;font-size:24px">
                  <%--<br />--%>
                      <asp:Label ID="titulo2LB" runat="server" Font-Bold="False" Font-Size="17pt" Text="" style="font-weight: 600;"></asp:Label>
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%;">
                                CODIGO ACUERDO o CUI&nbsp;
                            </td>
                            <td style="width:70%">
                                    <asp:TextBox ID="codigoTB" runat="server" Width="100%" autocomplete="off" class="form-control" Height="40px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                CLASIFICACION&nbsp;
                            </td>
                            <td style="width:70%">
                                    <asp:DropDownList ID="clasificaCB" runat="server" Width="100%" Font-Size="11pt" Height="40px"
                                            DataSourceID="SDS_SD_P_selectClasifica" DataTextField="nombre" class="form-control"
                                            DataValueField="grupoID" TabIndex="2" AppendDataBoundItems="True">
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
                                TIPO&nbsp;
                            </td>
                            <td style="width:70%">
                                    <asp:DropDownList ID="responsableCB" runat="server" Width="100%" Font-Size="11pt" Height="40px"
                                        class="form-control" TabIndex="3" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                        <asp:ListItem Value="1" > ACUERDO </asp:ListItem>
                                        <asp:ListItem Value="2" > COMPROMISO </asp:ListItem>
                                    </asp:DropDownList>
                                
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                ESTADO ACUERDO&nbsp;
                            </td>
                            <td style="width:70%">
                                <telerik:RadComboBox ID="estadoCB" Runat="server" RenderMode="Lightweight"
                                        Culture="es-ES" DataSourceID="SDS_SD_P_selectEstadoTipo" 
                                        DataTextField="nombre" Font-Size="10pt"
                                        DataValueField="ID" style="margin-bottom: 0" Width="100%" 
                                        CheckBoxes="True" EnableCheckAllItemsCheckBox="true" 
                                        OnClientLoad="clientLoadHandler" LoadingMessage="Cargando..." >
                                        <Localization AllItemsCheckedString="Todos Seleccionados"  
                                            CheckAllString="TODOS" ItemsCheckedString="Elementos Seleccionados" 
                                            NoMatches="No hay Coincidencias" />                                    
                                    </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                </div>
        </div>


        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; ">
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <table width="100%">
                        <tr>
                            <td style="width:30%">
                                ESPACIO&nbsp;
                            </td>
                            <td style="width:70%">

                                <asp:DropDownList ID="cbo_evento" runat="server" Width="100%" Font-Size="11"
                                    DataSourceID="SDS_P_SelectEventos" DataTextField="nombre" class="form-control"
                                    DataValueField="eventoID" TabIndex="1" AppendDataBoundItems="True">
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

        <div class="col-md-4 col-sm-4 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="buscar2" runat="server" Text="BUSCAR" class="styleMe" Width="100%" Height="50px" Font-Size="13" />
        </div>
        <div class="col-md-4 col-sm-4 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="exportarB" runat="server" Text="EXPORTAR" class="styleMe1" Width="100%" Height="50px" Font-Size="14" />
        </div>
        <div class="col-md-4 col-sm-4 col-xs-12 form-group" style="text-align:center">
            <asp:Button ID="expHitoB" runat="server" Text="EXPORTAR HITOS" class="styleMe1" Width="100%" Height="50px" Font-Size="11" TabIndex="11" />
        </div>
        <%--Bootstrap Glow    MetroTouch  --%>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center">

                <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES" Width="100%"
                    DataSourceID="SDS_SD_P_selectListAcuerdo" Skin="Bootstrap"  
                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top">
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="SDS_SD_P_selectListAcuerdo" NoMasterRecordsText="No existen registros." PageSize="5">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                        <HeaderStyle Width="41px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" 
                        FilterControlAltText="Filter ExpandColumn column" Created="True">
                        <HeaderStyle Width="41px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="acuerdoID" FilterControlAltText="Filter acuerdoID column" 
                            HeaderText="acuerdoID" ReadOnly="True" SortExpression="acuerdoID" UniqueName="acuerdoID"
                            Display="false">
                        </telerik:GridBoundColumn>
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
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROVINCIA" FilterControlAltText="Filter PROVINCIA column" 
                            HeaderText="Provincia" SortExpression="PROVINCIA" UniqueName="PROVINCIA" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ubica" FilterControlAltText="Filter ubica column" 
                            HeaderText="Ubica" SortExpression="ubica" UniqueName="ubica" AutoPostBackOnFilter="true" 
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
                            HeaderText="Eje Estrategico" SortExpression="objetivoEstrategicoTerritorial" UniqueName="objetivoEstrategicoTerritorial" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="true">
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="intervencionesEstrategicas" FilterControlAltText="Filter intervencionesEstrategicas column" 
                            HeaderText="Tipo Intervenciones" SortExpression="intervencionesEstrategicas" UniqueName="intervencionesEstrategicas" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="aspectoCriticoResolver" FilterControlAltText="Filter aspectoCriticoResolver column" 
                            HeaderText="Pedido" SortExpression="aspectoCriticoResolver" UniqueName="aspectoCriticoResolver" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CUIS" FilterControlAltText="Filter CUIS column" 
                            HeaderText="CUI" SortExpression="CUIS" UniqueName="CUIS" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" >
                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="codigo" FilterControlAltText="Filter codigo column" 
                            HeaderText="Código" SortExpression="codigo" UniqueName="codigo" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" Font-Bold="true" />
                        </telerik:GridBoundColumn>
                        
                        <telerik:gridtemplatecolumn DataField="codigo" FilterControlAltText="Filter codigo column" 
                            HeaderText="Código" SortExpression="codigo" UniqueName="codigov" 
                            AutoPostBackOnFilter="true" FilterControlWidth="100%" 
                            ShowFilterIcon="false" >
                            <ItemTemplate>
                                <asp:HyperLink ID="Link" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" Font-Bold="true" />
                        </telerik:gridtemplatecolumn>

                        <telerik:GridBoundColumn DataField="acuerdo" FilterControlAltText="Filter acuerdo column" 
                            HeaderText="Acuerdo" SortExpression="acuerdo" UniqueName="acuerdo" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Clasificacion" FilterControlAltText="Filter Clasificacion column" 
                            HeaderText="Clasificacion" SortExpression="Clasificacion" UniqueName="Clasificacion" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="responsable" FilterControlAltText="Filter responsable column" 
                            HeaderText="Resp." SortExpression="responsable" UniqueName="responsable" AutoPostBackOnFilter="true" 
                            FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:gridboundcolumn DataField="plazo" DataType="System.DateTime" 
                            FilterControlAltText="Filter plazo column" HeaderText="Plazo" 
                            SortExpression="plazo" UniqueName="plazo"
                            DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="85px" Font-Bold="true"  />
                        </telerik:gridboundcolumn>
                        <telerik:GridBoundColumn DataField="estadoRegistro" FilterControlAltText="Filter estadoRegistro column" 
                            HeaderText="estadoRegistro" ReadOnly="True" SortExpression="estadoRegistro" UniqueName="estadoRegistro"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="estadoRegistroInterno" FilterControlAltText="Filter estadoRegistroInterno column" 
                            HeaderText="estadoRegistroInterno" ReadOnly="True" SortExpression="estadoRegistroInterno" UniqueName="estadoRegistroInterno"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="NomEstadoRegistro" HeaderText="Estado" SortExpression="NomEstadoRegistro"
                            UniqueName="NomEstadoRegistro" AllowFiltering="False">
                            <ItemTemplate>
                                <asp:Label ID="nomEstado1Label" runat="server" Font-Bold="True" ForeColor='<%# GetColor(Eval("NomEstadoRegistro")) %>' 
                                    Text='<%# Eval("NomEstadoRegistro") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="60px" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridTemplateColumn>


                        <telerik:GridBoundColumn DataField="NomEstadoRegistro" FilterControlAltText="Filter NomEstadoRegistro column" 
                            HeaderText="Estado" ReadOnly="True" SortExpression="NomEstadoRegistro" UniqueName="NomEstadoRegistro_2"
                            Display="false" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Left" Font-Bold="true" ForeColor="Red" />
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
    
    <asp:SqlDataSource ID="SDS_SD_P_selectEstadoTipo" runat="server" 
        SelectCommand="SD_P_selectEstadoTipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SDS_SD_P_selectListAcuerdo" runat="server"  
        SelectCommand="SD_P_selectListAcuerdo" 
        SelectCommandType="StoredProcedure" >
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="prioridadID" Type="Int32" />
            <asp:ControlParameter ControlID="cbo_evento" DefaultValue="0" Name="eventoId" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="grupoCB" DefaultValue="0" Name="grupoId" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="cbo_departamento1" DefaultValue="" Name="departamento" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="cbo_provincia1" DefaultValue="" Name="ubigeo" PropertyName="SelectedValue" Type="Int32" />
             <asp:ControlParameter ControlID="codigoTB" DefaultValue="0" Name="codigo" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="clasificaCB" DefaultValue="" Name="clasificacion" PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="responsable" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="acuerdoID" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="0" Name="super" QueryStringField="sup" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="0" Name="entidadId" QueryStringField="en" Type="Int32" />
            <asp:SessionParameter Name="estadoRegistro" SessionField="estadoFiltroAcuerdo" Type="String" DefaultValue="0,1,2,3,4," />
            <asp:ControlParameter ControlID="responsableCB" DefaultValue="" Name="tipoId" PropertyName="SelectedValue" Type="Int32" />
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
    <asp:SqlDataSource ID="SDS_SD_P_selectClasifica" runat="server" 
        SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


        
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbo_departamento1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbo_provincia1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--<telerik:AjaxSetting AjaxControlID="buscar2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>


<img src="https://sesigue.com/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

        </form>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.com/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
<footer>
    <img src="https://sesigue.com/REFERENCIASBASE/Resources/sd_inferior_web.png" style="width:100%" />
</footer>
</html>
