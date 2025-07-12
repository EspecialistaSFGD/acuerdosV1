<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_reunionesDetA.aspx.vb" Inherits="CominWeb.Form_reunionesDetA" %>
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

        .contactTypeRadio input{
            width:20%;
            margin-top:7px;
            border: solid thin blue;
            float: left;
        }

        .divFiltros
        {
	        border:1px solid #8db2e3;
	        padding:0.2em;
	        font-size:1em;
	        overflow:hidden;
	        width:100%;
	        text-align:center;
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

        .styleMeBueno {
            border: 1px solid #25729a;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            font-size: 12px;
            font-family: arial, helvetica, sans-serif;
            padding: 10px 10px 10px 10px;
            text-decoration: none;
            display: inline-block;
            text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
            font-weight: bold;
            color: #FFFFFF;
            background-color: #3093c7;
            background-image: linear-gradient(to bottom, #3093c7, #1c5a85);
            border-radius: 40px;
        }

        .styleMeBueno:hover {
            border: 1px solid #1c5675;
            background-color: #26759e;
            background-image: linear-gradient(to bottom, #26759e, #133d5b);
        }
        .radioB {
            border-radius: 40px;
        }

        .alinea {
            text-align:right;
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
                document.getElementById('renewSession').src = 'https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
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


            function RadGrid1_OnRowSelected(sender, args) {
               <%-- var hitdoId = args.getDataKeyValue("hitdoId"); 
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("actualizaDet" + "," + hitdoId + ",0");
                return false;--%>
            }

            function frmValidacionReunion(id) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("ValidacionAsistenteReunion," + id);
                return false;
            }

            function frmValidacionReu(id) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("ValidacionAsistenteReu," + id);
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server" style="width:95%">
        <div class="top_nav">
            <img id="Img2" runat="server" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/sd_cabecera_web.png" style="width:105%" />
        </div>

        <center>

        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; margin-top:10px; font-weight:bold;font-size:24px">
                  <%--<br />--%>
                      <asp:Label ID="titulo2LB" runat="server" Font-Bold="False" Font-Size="17pt" Text="" style="font-weight: 600;">GESTIÓN DE HITOS</asp:Label>
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:left; margin-right:120px; margin-left:2%; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold; margin-top:10px">
                    SECTOR
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; margin-top:10px">
                    <asp:Label ID="sectorLB" runat="server" Font-Bold="False" Font-Size="11pt" Text="." >
                    </asp:Label>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold; margin-top:10px">
                    ENTIDAD
                </div>
                <div class="col-md-5 col-sm-4 col-xs-8 " style="text-align:center;margin-top:10px">
                    <asp:Label ID="entidadLB" runat="server" Font-Bold="False" Font-Size="10pt" Text=".">
                    </asp:Label>
                </div>
<%--                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    
                </div>--%>
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold; margin-top:10px">
                    ESTADO
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    <asp:DropDownList ID="estadoCB" runat="server" Width="100%" Font-Size="12pt" Height="40px"
                            class="form-control" TabIndex="3" AppendDataBoundItems="True" Font-Bold="true">
                            <asp:ListItem Value="0" > NO INICIADO </asp:ListItem>
                            <asp:ListItem Value="2" > EN PROCESO </asp:ListItem>
                            <asp:ListItem Value="3" > FINALIZADO </asp:ListItem>
                            <asp:ListItem Value="4" > CANCELADO </asp:ListItem>
                    </asp:DropDownList>
                </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:center; margin-left:2%;">
                <div class="col-md-6 col-sm-6 col-xs-6" style="text-align:center; font-weight:bold; padding-bottom:3px; padding-top:3px;">
                    <asp:Button ID="retornarB" runat="server" Text="RETORNA A LISTA" class="styleMe1" Width="100%" Height="40px" Font-Size="10pt" ToolTip="Retorna a Lista de acuerdos" />
                </div>
                <div class="col-md-6 col-sm-6 col-xs-6" style="text-align:center; font-weight:bold; padding-bottom:3px; padding-top:3px;">
                    <asp:Button ID="retornaGuardaB" runat="server" Text="RETORNA Y GUARDAR A LISTA" class="styleMe" Width="100%" Height="40px" Font-Size="10pt" ToolTip="Retorna a Lista de acuerdos" />
                 </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:center; margin-left:2%;">
            <%--<telerik:radgrid ID="RadGrid2" runat="server" Culture="es-ES" Width="100%"
                    DataSourceID="SDS_SD_P_selectListReuniones" Skin="Bootstrap"  
                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top">--%>
            <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES" 
                    DataSourceID="SDS_SD_P_selectListAsisteReuniones" Skin="Bootstrap" 
                    AutoGenerateColumns="False" AllowFilteringByColumn="false" AllowPaging="false" AllowSorting="True" GroupPanelPosition="Top">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView DataSourceID="SDS_SD_P_selectListAsisteReuniones" Font-Size="13pt" NoMasterRecordsText="No existen registros.">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" 
                        FilterControlAltText="Filter ExpandColumn column" Created="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="asistenciaReunionID" FilterControlAltText="Filter asistenciaReunionID column" 
                            HeaderText="asistenciaReunionID" ReadOnly="True" SortExpression="asistenciaReunionID" UniqueName="asistenciaReunionID"
                            Display="false">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Entidad" FilterControlAltText="Filter Entidad column" 
                            HeaderText="ENTIDAD" SortExpression="Entidad" UniqueName="Entidad" >
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="asistio" FilterControlAltText="Filter asistio column" 
                            HeaderText="" SortExpression="asistio" UniqueName="asistio" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter Llave column" HeaderTooltip="Validar Hito"
                            HeaderText="ASISTENCIA" UniqueName="TCValida" AllowFiltering="false" >
                            <ItemTemplate>
                                    <asp:ImageButton ID="TCValida" runat="server" CssClass="cursor" 
                                        ImageUrl="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/peligro_20.png"
                                        UseSubmitBehavior="False"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" Font-Bold="true" Font-Size="Small" />
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

<%--            <input id="cantHitosHI" runat="server" type="hidden" value="0" />--%>


            <asp:SqlDataSource ID="SDS_SD_P_selectListAsisteReuniones" runat="server"  
                SelectCommand="SD_P_selectListAsisteReuniones" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="reunionID" QueryStringField="reid" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="hiddenField" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="estadoLB" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="fechaLB" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="descripcionTB" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <%--<telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="" />--%>
                    <telerik:AjaxUpdatedControl ControlID="RadGridImagen" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--<telerik:AjaxSetting AjaxControlID="RadGridImagen">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridImagen" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>

<img src="https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

            <telerik:radwindowmanager ID="RadWindowManager1" runat="server" Skin="WebBlue">
                <Windows>
                    <telerik:RadWindow ID="RadWindow2" runat="server" Behavior="Move, Close" Behaviors="Move, Close" 
                        Height="520px" InitialBehavior="Move, Close" InitialBehaviors="Move, Close" Left="" Modal="True" 
                        ReloadOnShow="True" Skin="WebBlue" Style="display: none;" Top="" 
                        VisibleStatusbar="false" Width="800px" Animation="Fade">
                    </telerik:RadWindow>
                </Windows>
            </telerik:radwindowmanager>





        </center>
    </form>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
</html>
