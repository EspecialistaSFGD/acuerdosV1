<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AregistroAcredita.aspx.vb" Inherits="CominWeb.AregistroAcredita" %>
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

            function delAcredita(id) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("eliminaA," + id);
                return false;
            }
            
        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server" style="width:95%">
        <div class="top_nav">
            <img id="Img2" runat="server" src="https://sesigue.com/REFERENCIASBASE/Resources/sd_cabecera_web.png" style="width:105%" />
        </div>

        <center>

        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; margin-top:10px; font-weight:bold;font-size:24px">
                  <%--<br />--%>
                      <asp:Label ID="titulo2LB" runat="server" Font-Bold="False" Font-Size="17pt" Text="" style="font-weight: 600;">REGISTRO DE ACREDITADOS</asp:Label>
                </div>
          </div>
        </div>

        <div style="width:90%" id="formLogin" runat="server">

                <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:20px; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Tipo
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="tipoCB" runat="server" Width="100%" Font-Size="12pt" Height="35px"
                            class="form-control" TabIndex="1" AppendDataBoundItems="True" AutoPostBack="true" >
                            <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            <asp:ListItem Value="1" > Gobierno Nacional </asp:ListItem>
                            <asp:ListItem Value="2" > Gobierno Regional / Local </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="divSec" runat="server" class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Sector / Ministerio
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                            <asp:DropDownList ID="grupoCB" runat="server" Width="100%" Font-Size="12pt" Height="35px"
                                    DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                                    DataValueField="grupoID" TabIndex="2" AppendDataBoundItems="True" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>

                <div id="divDep" runat="server" class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Departamento
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="cbo_departamento1" runat="server" DataSourceID="SDS_P_selectDepartamento" DataTextField="departamento"
                                DataValueField="departamentoID" AutoPostBack="true" Width="100%" TabIndex="3" class="form-control" Font-Size="12pt" Height="35px"
                                AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                                </div>

                <div id="divProv" runat="server" class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Provincia
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="cbo_provincia1" runat="server" DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" AutoPostBack="true"
                            DataValueField="provinciaID" Width="100%" TabIndex="4" class="form-control" Font-Size="12pt" Height="35px">
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="divDis" runat="server" class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Distrito
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" Font-Size="12pt" Height="35px" AutoPostBack="true"
                            class="form-control" TabIndex="5" AppendDataBoundItems="True" Enabled="false" >
                            <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            <asp:ListItem Value="1" > Gobierno Nacional </asp:ListItem>
                            <asp:ListItem Value="2" > Gobierno Local </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="divEnti" runat="server" class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Institución
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                            <asp:DropDownList ID="entidadCB" runat="server" DataSourceID="SDS_SD_P_selectEntidades" DataTextField="nombre" 
                                    DataValueField="entidadId" Width="100%" TabIndex="6" class="form-control" Font-Size="12pt" Height="35px"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            </asp:DropDownList>
                    </div>

                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:center; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Grupo
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                            <asp:DropDownList ID="autoridadCB" runat="server" DataSourceID="SDS_SD_P_selectAutoridad" DataTextField="nombre" 
                                    DataValueField="grupoID" Width="100%" TabIndex="13" class="form-control" Font-Size="12pt" Height="35px"
                                    AppendDataBoundItems="True" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            </asp:DropDownList>
                    </div>

                </div>

            
                <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        DNI
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                        <asp:TextBox ID="dniTB" Font-Size="12" runat="server" Width="100%" autocomplete="off" TabIndex="9" MaxLength="8" Height="35px"
                                placeholder="" class="form-control" onkeypress="return checkNum(event)" AutoPostBack="true" ></asp:TextBox>    
                    </div>
                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:center; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Cargo
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                        <asp:TextBox ID="cargoTB" Font-Size="14" runat="server" Width="100%" autocomplete="off" TabIndex="8" MaxLength="100" Height="35px"
                                placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                    </div>

                    
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Nombres
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                        <asp:TextBox ID="nombreTB" Font-Size="12" runat="server" Width="100%" autocomplete="off" TabIndex="10" MaxLength="100" Height="35px"
                                placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>        
                        
                    </div>
                    
                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:center; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Correo
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                        <asp:TextBox ID="correoTB" Font-Size="12" runat="server" Width="100%" autocomplete="off" TabIndex="15" MaxLength="150" Height="35px"
                                placeholder="" class="form-control" onblur="validateEmail(); return false;"></asp:TextBox>
                    </div>
                    
                </div>
            
                <div class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    
                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Apellidos
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                            <asp:TextBox ID="apellidosTB" Font-Size="12" runat="server" Width="100%" autocomplete="off" TabIndex="11" MaxLength="100" Height="35px"
                                placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                            
                    </div>

                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:center; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Fecha de Asist.
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                            <telerik:raddatepicker ID="fechaAsiRDP" runat="server" DateInput-AutoCompleteType="Disabled" TabIndex="16"
                                Width="100%" Culture="es-PE" Skin="Bootstrap" AutoPostBack="true">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Bootstrap"></Calendar>
                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Font-Size="10" AutoPostBack="True" >
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
                    </div>
                </div>
            
                <div class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    
                    
                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Teléfono
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                            <asp:TextBox ID="telefonoTB" Font-Size="12" runat="server" Width="100%" autocomplete="off" TabIndex="12" MaxLength="9" Height="35px" 
                                placeholder="" class="form-control" onkeypress="return checkNum(event)" ></asp:TextBox>
                    </div>

                    <div class="col-md-2 col-sm-2 col-xs-4 " style="text-align:center; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:11pt">
                        Asistente Plenaria
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-8 " style="text-align:left; ">
                            <asp:DropDownList ID="plenariaCB" runat="server" Width="100%" Font-Size="10pt" Height="40px"
                                class="form-control" TabIndex="3" >
                                <asp:ListItem Value="0" > NO </asp:ListItem>
                                <asp:ListItem Value="1" > SI </asp:ListItem>
                            </asp:DropDownList>
                    </div>

                </div>

                <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px;" >
                    <asp:Button ID="generarB" runat="server" class="styleMe" Text="GUARDAR" Width="50%" Height="50px" Font-Size="15" />
                </div>

            <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px;" >
            <telerik:radgrid ID="RadGrid1" runat="server" Width="100%" Culture="es-ES" DataSourceID="SDS_SD_P_selectAcreaditadosList" Skin="Bootstrap" 
                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top" Font-Bold="True">
                <GroupingSettings CaseSensitive="false" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" CellSelectionMode="None" UseClientSelectColumnOnly="True" />
                </ClientSettings>
                <MasterTableView DataSourceID="SDS_SD_P_selectAcreaditadosList" NoMasterRecordsText="No existen registros." PageSize="10"
                    DataKeyNames="asistenciaId" ClientDataKeyNames="asistenciaId" >
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" 
                    FilterControlAltText="Filter ExpandColumn column" Created="True">
                </ExpandCollapseColumn>
                <Columns>
                      <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                        HeaderText="Edit" UniqueName="TemplateColumnEstado" AllowFiltering="false" Display="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="edita" runat="server" CssClass="cursor" ToolTip="Editar Hito"
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/UpdateG.png"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
                    <%--

                    <telerik:GridTemplateColumn FilterControlAltText="Filter Llave column" HeaderTooltip="Validar Hito"
                        HeaderText="Validar" UniqueName="TCValida" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="TCValida" runat="server" CssClass="cursor" 
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/peligro_20.png"
                                    UseSubmitBehavior="False"
                                    OnClientClick="javascript: if(!confirm('¿Desea validar el HITO, una vez validado no podrá modificarse?')){return false;}"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>--%>

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
                        HeaderText="espacio" SortExpression="espacio" UniqueName="espacio" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="departamento" FilterControlAltText="Filter departamento column" 
                        HeaderText="departamento" SortExpression="departamento" UniqueName="departamento" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="provincia" FilterControlAltText="Filter provincia column" 
                        HeaderText="provincia" SortExpression="provincia" UniqueName="hito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="provincia" FilterControlAltText="Filter provincia column" 
                        HeaderText="provincia" SortExpression="provincia" UniqueName="hito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="provincia" FilterControlAltText="Filter provincia column" 
                        HeaderText="provincia" SortExpression="provincia" UniqueName="hito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="entidad" FilterControlAltText="Filter entidad column" 
                        HeaderText="ENTIDAD" SortExpression="entidad" UniqueName="entidad" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" Width="20%"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nombre" FilterControlAltText="Filter nombre column" 
                        HeaderText="GRUPO" SortExpression="nombre" UniqueName="nombre" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" Width="20%"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="cargo" FilterControlAltText="Filter cargo column" 
                        HeaderText="cargo" SortExpression="cargo" UniqueName="hito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DNI" FilterControlAltText="Filter DNI column" 
                        HeaderText="DNI" SortExpression="DNI" UniqueName="DNI" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="acreditado" FilterControlAltText="Filter acreditado column" 
                        HeaderText="ACREDITADO" SortExpression="acreditado" UniqueName="acreditado" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="telefono" FilterControlAltText="Filter telefono column" 
                        HeaderText="TELEFONO" SortExpression="telefono" UniqueName="telefono" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="email" FilterControlAltText="Filter email column" 
                        HeaderText="CORREO" SortExpression="email" UniqueName="email" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:gridboundcolumn DataField="dia_evento" DataType="System.DateTime" 
                        FilterControlAltText="Filter dia_evento column" HeaderText="FECHA" 
                        SortExpression="dia_evento" UniqueName="dia_evento"
                        DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="False" >
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Small"/>
                    </telerik:gridboundcolumn>
                    <telerik:GridBoundColumn DataField="asi_plenaria" FilterControlAltText="Filter asi_plenaria column" 
                        HeaderText="PLENARIA" SortExpression="asi_plenaria" UniqueName="asi_plenaria" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" Width="90px"/>
                        <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                        HeaderText="ELI" UniqueName="TemplateColumnDelete" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="eliminaAcreditado" runat="server" CssClass="cursor" 
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/CancelG.png"
                                    ToolTip="Eliminar Acreditado" UseSubmitBehavior="False"
                                    OnClientClick="javascript: if(!confirm('¿Desea Eliminar el acreditado?')){return false;}"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" Width="2%" />
                    </telerik:GridTemplateColumn>
<%--                    <telerik:GridTemplateColumn FilterControlAltText="Filter TCAvance column" HeaderTooltip="Crear Avance"
                        HeaderText="AV" UniqueName="TCAvance" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="TCavance" runat="server" CssClass="cursor" ToolTip="Crear Avance"
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/refresh_1.png"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
                    
                    <telerik:GridTemplateColumn FilterControlAltText="Filter reactivaHito column" 
                        HeaderText="REActiva" UniqueName="reactivaHito" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="reactivaHito" runat="server" CssClass="cursor" 
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/activo_0.png"
                                    ToolTip="Estado del Hito" UseSubmitBehavior="False"
                                    OnClientClick="javascript: if(!confirm('¿Desea retornar el estado del hito a: EN PROCESO?')){return false;}"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" Width="2%" />
                    </telerik:GridTemplateColumn>--%>
                </Columns>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:radgrid>
            </div>

       </div>
            <%--<input id="hiddenField" runat="server" type="hidden" value="0" />--%>


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
                <asp:ControlParameter ControlID="cbo_departamento1" DefaultValue="" Name="departamento" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectEntidades" runat="server" 
            SelectCommand="SD_P_selectEntidades" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="entidadId" Type="Int32" />
                <asp:ControlParameter ControlID="tipoCB" DefaultValue="3" Name="tipo" PropertyName="SelectedValue" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="0" Name="sectorId" QueryStringField="codsector" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="0" Name="ubigeo" QueryStringField="ubig" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectAutoridad" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SDS_SD_P_selectAcreaditadosList" runat="server" 
            SelectCommand="SD_P_selectAcreaditadosList" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="asistenciaId" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="nombre" Type="String" />
                <asp:QueryStringParameter DefaultValue="0" Name="eventoId" QueryStringField="codevento" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="0" Name="entidadId" QueryStringField="en" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="dni" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>


            

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>


<img src="https://sesigue.com/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

        </center>
    </form>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.com/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
    <br />
</body>
<footer>
    <img src="https://sesigue.com/REFERENCIASBASE/Resources/sd_inferior_web.png" style="width:100%" />
</footer>
</html>
