<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registroSituacion.aspx.vb" Inherits="CominWeb.registroSituacion" %>
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

            
            function checkAcuerdo(letra) 
            {
                tecla = (document.all) ? letra.keyCode : letra.which;
                //Tecla de retroceso para borrar, y espacio siempre la permite
                if (tecla == 8 || tecla == 13) {
                    return true;
                }
                if (tecla == 14 || tecla == 32) {
                    return true;
                }
                patron = /[A-Za-z.-1234567890áéíóúÁÉÍÓÚ()°;,-]/;
                tecla_final = String.fromCharCode(tecla);
                return patron.test(tecla_final);
            }

            window.setInterval("renewSession();", 30000);

            function renewSession() {
                console.log("Renovando session...");
                document.getElementById('renewSession').src = 'https://sesigue.miterritorio.gob.pe/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            }

            function CerrarVentana(indicador) {
                var oWnd = GetRadWindow();
                var oArg = new Object();
                oArg.indicador = indicador;
                oWnd.close(oArg);
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

            function guardaJS() {
                var sit = document.getElementById('<%= situacionTB.ClientId %>').value;
                if (sit.length < 5) {
                    mensaje('information', 'Mínimo 5 caracteres');
                    return false;
                }
                if (sit.length > 300) {
                    mensaje('information', 'Máximo 300 caracteres');
                    return false;
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("guardar");
                    return true;
                }
            }

        </script>
    </telerik:RadCodeBlock>
</head>
<body style="background: #ffffff;">
    <form id="form1" runat="server">

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
                <center>
                        <table style="width:100%" border="0">
                            <tr>
                                <td style="border-right: #464646 1px solid; border-left: #464646 1px solid; border-bottom: #464646 1px solid; padding:5px" colspan="4">
                                        <asp:Label ID="inversionLB" runat="server" Font-Size="12px" Text="" style="font-weight: 500;">-</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; padding:5px; Font-Size:11px; font-weight:500; text-align:center">
                                    Fase
                                </td>
                                <td style="width:35%; padding:5px" >
                                        <asp:DropDownList ID="faseCB" runat="server" DataSourceID="SDS_SD_P_selectFaseInv" DataTextField="nombre" 
                                                DataValueField="faseID" Width="100%" TabIndex="12" class="form-control" Height="25px" Font-Size="11px" 
                                                AppendDataBoundItems="True" AutoPostBack="true">
                                                <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td style="width:15%; padding:5px; Font-Size:11px; font-weight:500; text-align:center">
                                    Etapa
                                </td>
                                <td style="width:35%; padding:5px" >
                                        <asp:DropDownList ID="etapaCB" runat="server" DataSourceID="SDS_SD_P_selectEtapaInv" DataTextField="nombre" 
                                                DataValueField="EtapaID" Width="100%" TabIndex="12" class="form-control" Height="25px" Font-Size="11px" 
                                                AppendDataBoundItems="True" AutoPostBack="true">
                                                <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; padding:5px; Font-Size:11px; font-weight:500; text-align:center">
                                    Hito
                                </td>
                                <td style="width:35%; padding:5px" >
                                        <asp:DropDownList ID="hitoCB" runat="server" DataSourceID="SDS_SD_P_selectHitoInv" DataTextField="nombre" 
                                                DataValueField="hitoId" Width="100%" TabIndex="12" class="form-control" Height="25px" Font-Size="11px" 
                                                AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td style="width:15%; padding:5px; Font-Size:11px; font-weight:500; text-align:center">
                                    Plazo
                                </td>
                                <td style="width:35%; padding:5px" >
                                        <telerik:raddatepicker ID="fechaRDP" runat="server" RenderMode="Lightweight"
                                            Width="100%" Culture="es-PE" MaxDate="2030-12-31" Height="25px" Font-Size="11px" 
                                            Skin="Metro">
                                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Metro"></Calendar>
                                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" Font-Size="11px" ></DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl="" Font-Size="11px" ></DatePopupButton>
                                        </telerik:raddatepicker>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; padding:5px; Font-Size:11px; font-weight:500; text-align:center">
                                    Tarea
                                </td>
                                <td style="padding:5px" colspan="3">
                                        <asp:TextBox ID="situacionTB" Font-Size="11px" runat="server" Width="100%" autocomplete="off" TabIndex="1" MaxLength="400"
                                            placeholder="" class="form-control" Rows="3" TextMode="MultiLine" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <button class="styleMe1" style="Width:100%; Height:40px; font:16pt" onclick="guardaJS(); return false;">GUARDAR</button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <telerik:radgrid ID="RadGrid1" runat="server" Width="100%" Culture="es-ES" DataSourceID="SDS_SD_P_selectListSituaciones" Skin="Bootstrap"
                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="false" GroupPanelPosition="Top" Font-Bold="True">
                                        <GroupingSettings CaseSensitive="false" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" CellSelectionMode="None" UseClientSelectColumnOnly="True" />
                                        </ClientSettings>
                                        <MasterTableView DataSourceID="SDS_SD_P_selectListSituaciones" NoMasterRecordsText="No existen registros." PageSize="10"
                                            DataKeyNames="situacionID" ClientDataKeyNames="situacionID" Font-Size="11px" >
                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True" 
                                            FilterControlAltText="Filter ExpandColumn column" Created="True">
                                        </ExpandCollapseColumn>
                                        <Columns>

                                            <telerik:GridBoundColumn DataField="codigoInversion" FilterControlAltText="Filter codigoInversion column" 
                                                HeaderText="Codigo" SortExpression="codigoInversion" UniqueName="codigoInversion" AutoPostBackOnFilter="true" 
                                                FilterControlWidth="100%" ShowFilterIcon="false" AllowFiltering="false" Display="false" >
                                                <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="11px" />
                                                <ItemStyle HorizontalAlign="Center" Font-Size="11px" />
                                            </telerik:GridBoundColumn>
                                            
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
                                        </Columns>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        </MasterTableView>
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                    </telerik:radgrid>
                                </td>
                            </tr>
                        </table>
                </center>
        </div>

        <asp:SqlDataSource ID="SDS_SD_P_selectFaseInv" runat="server" SelectCommand="SD_P_selectFaseInv" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="tipoInversion" QueryStringField="tinv" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectEtapaInv" runat="server" SelectCommand="SD_P_selectEtapaInv" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="faseCB" DefaultValue="" Name="faseID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectHitoInv" runat="server" SelectCommand="SD_P_selectHitoInv" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="etapaCB" DefaultValue="" Name="EtapaID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectListSituaciones" runat="server" 
            SelectCommand="SD_P_selectListSituaciones" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="codigoInversion" QueryStringField="cinv" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="faseCB">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="etapaCB" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="hitoCB" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="etapaCB">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="hitoCB" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

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
