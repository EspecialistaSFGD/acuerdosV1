<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registroAcuerdosV.aspx.vb" Inherits="CominWeb.registroAcuerdosV" %>
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

            function OnClientClose1(oWnd, eventArgs) {
                var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();
                oWnd.remove_close(OnClientClose1);
            }

     <%--       function frmacuerdoNuevo() {
                var oWnd = $find("<%= RadWindow2.ClientID %>");
                var ruta_ventana_empresas = "registroAc.aspx??lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjasdhasdhurtioenmbxcvkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codac=0&codped=" + '<%= Me.Request.QueryString("codigoid")%>' + "&codclas=0&gjXtIkEroS=SD_SSFD";
                oWnd.setUrl(ruta_ventana_empresas);
                oWnd.add_close(OnClientClose1);
                oWnd.show();
                return true;
            }--%>

            function frmacuerdoN(pedi) {
                var oWnd = $find("<%= RadWindow2.ClientID %>");
                var ruta_ventana_empresas = "registroAc.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codac=0&codped=" + pedi + "&codclas=0";
                oWnd.setUrl(ruta_ventana_empresas);
                oWnd.add_close(OnClientClose1);
                oWnd.show();
                return true;
            }

            function editaAcuerdo(acuerdo, pedi) {
                var oWnd = $find("<%= RadWindow2.ClientID %>");
                var ruta_ventana_empresas = "registroAc.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codac=" + acuerdo + "&codped=" + pedi + "&codclas=0";
                oWnd.setUrl(ruta_ventana_empresas);
                oWnd.add_close(OnClientClose1);
                oWnd.show();
                return true;
            }

            function frmacuerdoNuevo() {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("frmacuerdo");
                return false;
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

            function desactivarProducto(acuerdoID) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("desactivAcuerdo," + acuerdoID);
                return false;
            }

            function checkAcuerdo(letra) {
                tecla = (document.all) ? letra.keyCode : letra.which;
                //Tecla de retroceso para borrar, y espacio siempre la permite
                if (tecla == 8 || tecla == 13) {
                    return true;
                }
                if (tecla == 14 || tecla == 32) {
                    return true;
                }
                patron = /[A-Za-z.-1234567890áéíóú,-]/;
                tecla_final = String.fromCharCode(tecla);
                return patron.test(tecla_final);
            }

            function checkCui(letra) {
                tecla = (document.all) ? letra.keyCode : letra.which;
                //Tecla de retroceso para borrar, y espacio siempre la permite
                if (tecla == 8 || tecla == 13) {
                    return true;
                }
                if (tecla == 14 || tecla == 32) {
                    return true;
                }
                patron = /[1234567890,]/;
                tecla_final = String.fromCharCode(tecla);
                return patron.test(tecla_final);
            }

        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px; padding-top:10px">
                  <%--<br />--%>
                      REGISTRO DE ACUERDOS
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:10px">
                <center>
                        <table style="width:95%" border="0">
                            <tr>
                                <td style="padding:5px; Font-Size:20px; font-weight:500" colspan="3">
                                    <table width="100%" border="0"  style="border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; width: 100%;">
                                        <tr>
                                            <td style="width:15%; padding:5px; Font-Size:14px; font-weight:500">
                                                SECTOR (*)
                                            </td>
                                            <td style="padding:5px">
                                                    <asp:DropDownList ID="grupoCB" runat="server" Width="90%" Font-Size="12pt"
                                                            DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                                                            DataValueField="grupoID" TabIndex="6" AppendDataBoundItems="True" Height="40px">
                                                            <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                                    </asp:DropDownList>
                                            </td>
                                            <td style="width:15%; padding:5px; Font-Size:14px; font-weight:500">
                                                DEPARTAMENTO (*)
                                            </td>
                                            <td style="padding:5px">
                                                    <asp:DropDownList ID="cbo_departamento1" runat="server" DataSourceID="SDS_P_selectDepartamento" DataTextField="departamento" 
                                                        DataValueField="departamentoID" AutoPostBack="true" Width="100%" TabIndex="12" class="form-control" Font-Size="12pt"
                                                        AppendDataBoundItems="True" Height="40px" >
                                                        <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                                                    </asp:DropDownList>
                                            </td>
                                            <td style="width:15%; padding:5px; Font-Size:14px; font-weight:500">
                                                PROVINCIA (*)
                                            </td>
                                            <td style="padding:5px">
                                                    <asp:DropDownList ID="cbo_provincia1" runat="server" DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" 
                                                        DataValueField="provinciaID" Width="100%" TabIndex="13" class="form-control" Font-Size="12pt" Height="40px">
                                                    </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:14px; font-weight:500">
                                    PRIORIDAD TERRITORIAL
                                </td>
                                <td style="padding:5px" >
                                        <asp:TextBox ID="prioridadTerritorialTB" Font-Size="12" runat="server" Width="100%" autocomplete="on" 
                                            placeholder="" class="form-control" Rows="2" TextMode="MultiLine" onkeypress="return checkAcuerdo(event)" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:14px; font-weight:500">
                                    OBJETIVO ESTRATEGICO TERRITORIAL
                                </td>
                                <td style="padding:5px" >
                                        <asp:TextBox ID="objetivoTB" Font-Size="12" runat="server" Width="100%" autocomplete="on" 
                                            placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:14px; font-weight:500">
                                    INTERVENCIONES ESTRATEGICAS (*)
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="intervencionTB" Font-Size="12" runat="server" Width="100%" autocomplete="on" 
                                            placeholder="" class="form-control" Rows="4" TextMode="MultiLine" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:14px; font-weight:500">
                                    CUI's (Ejem. 1234567,1234568,...)
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="cuisTB" Font-Size="12" runat="server" Width="100%" autocomplete="OFF" 
                                            placeholder="" class="form-control" onkeypress="return checkCui(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%; padding:5px; Font-Size:14px; font-weight:500">
                                    ASPECTO CRITICO A RESOLVER (*)
                                </td>
                                <td style="padding:5px">
                                        <asp:TextBox ID="aspectoTB" Font-Size="12" runat="server" Width="100%" autocomplete="on" 
                                            placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right:5px; width:20%;">
                                    <asp:Button ID="retornarB" runat="server" Text="RETORNA A LISTA" class="styleMe" Width="100%" Height="40px" Font-Size="11pt" />
                                </td>
                                <td style="padding-top:5px;padding-left:5px;" >
                                    <button class="styleMe1" style="Width:100%; Height:40px; font:16pt" onclick="frmacuerdoNuevo(); return false;">CREAR ACUERDO</button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                        <telerik:radgrid ID="RadGrid1" runat="server" Culture="es-ES" DataSourceID="SDS_SD_P_selectAcuerdos" Skin="Bootstrap" 
                                            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top" Font-Bold="True">
                                            <GroupingSettings CaseSensitive="false" />
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <MasterTableView DataSourceID="SDS_SD_P_selectAcuerdos" NoMasterRecordsText="No existen registros." PageSize="5"
                                                DataKeyNames="acuerdoID" ClientDataKeyNames="acuerdoID" >
                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Visible="True" 
                                                FilterControlAltText="Filter ExpandColumn column" Created="True">
                                            </ExpandCollapseColumn>
                                            <Columns>

                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                                                    HeaderText="Edit" UniqueName="TemplateColumnEstado" AllowFiltering="false" >
                                                    <ItemTemplate>
                                                            <asp:ImageButton ID="edita" runat="server" CssClass="cursor" ToolTip="Editar Acuerdo"
                                                                ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/UpdateG.png"/>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Large" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>





                                                <telerik:GridBoundColumn DataField="acuerdoID" FilterControlAltText="Filter acuerdoID column" 
                                                    HeaderText="acuerdoID" ReadOnly="True" SortExpression="acuerdoID" UniqueName="acuerdoID"
                                                    Display="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="prioridadID" FilterControlAltText="Filter prioridadID column" 
                                                    HeaderText="prioridadID" ReadOnly="True" SortExpression="prioridadID" UniqueName="prioridadID"
                                                    Display="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="codigo" FilterControlAltText="Filter codigo column" 
                                                    HeaderText="CODIGO" SortExpression="codigo" UniqueName="codigo" AutoPostBackOnFilter="true" 
                                                    FilterControlWidth="100%" ShowFilterIcon="false">
                                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Large" Width="150px"/>
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Medium" Font-Bold="true"/>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="acuerdo" FilterControlAltText="Filter acuerdo column" 
                                                    HeaderText="ACUERDO" SortExpression="acuerdo" UniqueName="acuerdo" AutoPostBackOnFilter="true" 
                                                    FilterControlWidth="100%" ShowFilterIcon="false">
                                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Large"/>
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Medium" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="clasificacionID" FilterControlAltText="Filter clasificacionID column" 
                                                    HeaderText="clasificacionID" ReadOnly="True" SortExpression="clasificacionID" UniqueName="clasificacionID"
                                                    Display="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="clasificacion" FilterControlAltText="Filter clasificacion column" 
                                                    HeaderText="CLASIFICACION" SortExpression="clasificacion" UniqueName="clasificacion" AutoPostBackOnFilter="true" 
                                                    FilterControlWidth="100%" ShowFilterIcon="false" >
                                                    <HeaderStyle HorizontalAlign="Center" Width="250PX" Font-Bold="true" Font-Size="Large" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Medium"/>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="responsableID" FilterControlAltText="Filter responsableID column" 
                                                    HeaderText="responsableID" ReadOnly="True" SortExpression="responsableID" UniqueName="responsableID"
                                                    Display="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="responsable" FilterControlAltText="Filter responsable column" 
                                                    HeaderText="RESPONS." SortExpression="responsable" UniqueName="responsable" AutoPostBackOnFilter="true" 
                                                    FilterControlWidth="100%" ShowFilterIcon="false" >
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" Font-Size="Large" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Medium"/>
                                                </telerik:GridBoundColumn>
                                                <telerik:gridboundcolumn DataField="plazo" DataType="System.DateTime" 
                                                    FilterControlAltText="Filter plazo column" HeaderText="PLAZO" 
                                                    SortExpression="plazo" UniqueName="plazo"
                                                    DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="False" >
                                                    <HeaderStyle HorizontalAlign="Center" Width="85PX" Font-Bold="true" Font-Size="Large" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="Medium"/>
                                                </telerik:gridboundcolumn>
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                                                    HeaderText="Eli" UniqueName="TemplateColumnEstado" AllowFiltering="false" >
                                                    <ItemTemplate>
                                                            <asp:ImageButton ID="estadoAcuerdob" runat="server" CssClass="cursor" 
                                                                ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/CancelG.png"
                                                                ToolTip="Eliminar Acuerdo" UseSubmitBehavior="False"
                                                                OnClientClick="javascript: if(!confirm('¿Desea Eliminar el acuerdo?')){return false;}"/>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Large" />
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
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
                                </td>
                            </tr>
                        </table>
                </center>
        </div>


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

        <asp:SqlDataSource ID="SDS_SD_P_selectAcuerdos" runat="server"  
            SelectCommand="SD_P_selectAcuerdos" 
            SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="acuerdoID" Type="Int32" />
                <asp:SessionParameter DefaultValue="0" Name="prioridadID" SessionField="pedido" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="acuerdo" Type="String" />
                <asp:Parameter DefaultValue="0" Name="clasificacionID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectGrupos" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
                <asp:Parameter DefaultValue="2" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>





<%--        <asp:SqlDataSource ID="SDS_SD_P_selectMancomunidades" runat="server" 
            SelectCommand="SD_P_selectMancomunidades" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="idMancomunidad" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_P_SelectEventos" runat="server" 
        SelectCommand="SD_P_selectEventos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="eventoId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SDS_P_SelectDocumento" runat="server" 
        SelectCommand="P_selectDocumento" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Tipo" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="tipoSelect" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="tipoDocumentoID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_SD_P_selectGrupos" runat="server" 
            SelectCommand="SD_P_selectGrupos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="grupoId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<img src="http://162.248.52.148/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

            <telerik:radwindowmanager ID="RadWindowManager1" runat="server" Skin="WebBlue">
                <Windows>
                    <telerik:RadWindow ID="RadWindow2" runat="server" Behavior="Move, Close" Behaviors="Move, Close" 
                        Height="600px" InitialBehavior="Move, Close" InitialBehaviors="Move, Close" Left="" Modal="True" 
                        ReloadOnShow="True" Skin="WebBlue" Style="display: none;" Top="" 
                        VisibleStatusbar="false" Width="950px" Animation="Fade">
                    </telerik:RadWindow>
                </Windows>
            </telerik:radwindowmanager>



    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbo_departamento1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbo_provincia1" 
                        LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" 
                        LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>


        </form>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
</html>
