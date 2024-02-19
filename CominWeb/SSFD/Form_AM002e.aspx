<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_AM002e.aspx.vb" Inherits="CominWeb.Form_AM002e" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <link href="http://162.248.52.148/REFERENCIASBASE/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.js"></script>
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/dropzone/dist/min/dropzone.min.css" rel="stylesheet" />
    <link type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/css/custom.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://162.248.52.148/REFERENCIASBASE/Scripts/login2019/css/main.css" />
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/dropzone/dist/min/dropzone.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/build/js/custom.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/Chart.js/dist/Chart.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/echarts/dist/echarts.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/echarts/map/js/world.js"></script>--%>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
<style type="text/css">
    .divtableResponsable {
	    border:1px solid #8db2e3;
	    font-size:1em;
	    overflow:hidden;
	    text-align:center;
    }
        
    .divtableInterno {
	    border:1px solid #8db2e3;
	    font-size:1em;
	    overflow:hidden;
	    text-align:center;
    }
</style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ValidEntero(e) {
                var key = window.Event ? e.which : e.keyCode
                return (key >= 48 && key <= 57 || key == 46)
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
            
            function CerrarVentana(e) {
                var nosucp = '<%=Request.QueryString("nosucp")%>';
                var usrin = '<%=Request.QueryString("usrin")%>'; 
                var emp = '<%=Request.QueryString("gjXtIkEroS")%>';

                location.href = "../SSFD/Form_AM001.aspx?gjXtIkEroS=" + emp +
                    "&lkjasdliwupqwinasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh" +
                    "&usrin=" + usrin +
                    "&nosucp=" + nosucp;
                return false;
            }

            function validaDet() {
                var cod = '<%=Request.QueryString("id")%>';
                //if (responsablejs.length == 0) {
                //    mensaje('information', 'Ingrese responsable.');
                //    return false;
                //}
                //if (hitojs == 0) {
                //    mensaje('information', 'Seleccione descripcion del hito.');
                //    return false;
                //}
                //else {
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("exeQform");
                //}
            }
            //window.setInterval("renewSession();", 30000);

            //function renewSession() {
            //    console.log("Renovando session...");
            //    document.getElementById('renewSession').src = '/DESARROLLO/SessionActiva.aspx?par=' + Math.random();
            //}

            //function redireccionGenerado(codigoUltimo) {
            //    mensajeXX('information', 'SE REALIZO LA VERIFICACION DEL EQUIPO: ' + codigoUltimo);
            //}

            //function mensajeXX(tipo, texto) {
            //    var n = noty({
            //        text: texto,
            //        type: tipo, // alert | error | success | information | warning | confirm
            //        dismissQueue: true,
            //        layout: 'center',
            //        theme: 'defaultTheme',
            //        modal: true,
            //        buttons: [
            //            {
            //                addClass: 'btn btn-danger', text: 'Ok', onClick: function ($noty) {
            //                    $noty.close();
            //                    window.close();
            //                    //window.location = '../ordenesdetrabajo/Form_Ordenes.aspx';
            //                }
            //            },
            //        ]
            //    });
            //    console.log('html: ' + n.options.id);
            //}

        </script>
    </telerik:RadCodeBlock>
</head>
<body style="background:#ffffff">
    <form id="form1" runat="server">
        
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Skin="WebBlue" Width="100%" style="font-weight: bold; font-size: 9pt;"
                    Font-Bold="false">
                    <Items>
                        <telerik:RadToolBarButton runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White" Font-Bold="false"
                            ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Update.png" Text="Guardar" onclick="validaDet();" >
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White" Font-Bold="false"
                            ImageUrl="http://162.248.52.148/REFERENCIASBASE/Resources/Cancel.png" Text="Cancelar" onclick="CerrarVentana();" >
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
               <table width="100%" border="0" style="font-family: Arial, Helvetica, sans-serif; font-size:9pt" >
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            &nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Width="100%"
                                                TabIndex="3" EmptyMessage="0" MaxValue="100" Enabled="false"
                                                Culture="es-PE" DbValueFactor="1" LabelWidth="40%" MinValue="0" 
                                                autocomplete="off">
                                                <EnabledStyle Font-Names="Verdana" HorizontalAlign="Right" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Region&nbsp; 
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            LORETO
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Provincia&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="provinciaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" 
                                                DataValueField="provinciaID" AutoPostBack="True" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Distrito&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="distritoCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectDistrito" DataTextField="distrito" 
                                                DataValueField="distritoID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Jerarquía&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="jerarquiaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectJerarquia" DataTextField="descripcion" 
                                                DataValueField="jerarquiaid" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Jerarquía Proy.&nbsp; 
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="jerarquiaProyCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectJerarquia" DataTextField="descripcion" 
                                                DataValueField="jerarquiaid" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Nucleo Dinamiz.&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="nucleDinaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectNucleo" DataTextField="descripcion" 
                                                DataValueField="nucleoDinamizadorId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Nro. Nucleo&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:TextBox ID="nroNucleoTB" runat="server" OnKeyPress="return ValidEntero(event)" 
                                                    Width="96%" Font-Size="8pt" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Tipo&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="tipoCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogos" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            SNIP/CU&nbsp; 
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="codUnicoLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Nivel de Gobierno&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="nivelGobiernoLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Unidad Formuladora&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="unidadFormuladoraLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Nombre&nbsp;
                                        </td>
                                        <td style=" text-align:left; ">
                                            <asp:TextBox ID="nombreTB" runat="server" Width="99.4%" Font-Size="9pt" 
                                                autocomplete="off" TextMode="MultiLine" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Sector&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="sectorLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Función&nbsp; 
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="funcionLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Div. Funcional&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="divFuncionalCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectDivisionFuncional" DataTextField="descripcion" 
                                                DataValueField="divisionFuncionalId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Grupo Funcional&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="grupoFuncionalCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectGrupoFuncional" DataTextField="descripcion" 
                                                DataValueField="grupoFuncionalId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Tema&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="temaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectTema" DataTextField="descripcion" 
                                                DataValueField="temaId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Eje&nbsp; 
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="ejeCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectEje" DataTextField="descripcion" 
                                                DataValueField="ejeId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Componente&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="componenteCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectComponente" DataTextField="descripcion" 
                                                DataValueField="componenteId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Dev. Acumulado&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="devAcumuladoLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            PIM 2020&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="pimLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Dev. 2020&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="devLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Saldo x Financiar&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="saldoFinLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Saldo Ajustado&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="saldoAjustLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            DS-145-2019&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="ds145LB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Costo Act.&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="costoLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Estado&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="estadosPiCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectEstados" DataTextField="descripcion" 
                                                DataValueField="estadoId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Gestión&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="gestionInversionCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectGestionInv" DataTextField="descripcion" 
                                                DataValueField="gestionInversionId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Prioridad&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:DropDownList ID="prioridadCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectPrioridad" DataTextField="descripcion" 
                                                DataValueField="prioridadId" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Plazo Ejecución&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="plazoEjecutaLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Modalidad Ejec.&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="modalidadEjecLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Ejecutora&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <asp:Label ID="ejecutoraLB" runat="server" Text="-" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            <%--Unidad Formuladora&nbsp;--%>
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            <%--Nivel de Gobierno&nbsp;--%>
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            <%--<asp:Label ID="nivelGobiernoLB" runat="server" Text="-" ></asp:Label>--%>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            &nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            &nbsp;
                                        </td>
                                        <td style=" text-align:left; width:15%">
                                            
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            5 cuencas&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="cincoCuencaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            (65) 4 cuencas&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="cuatroCuencaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Manseriche&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="mansericheCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Morona Shapras&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="moronaShaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Morona&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="moronaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Urarinas (Concordia)
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="urarinasCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Urarinas (Nueva Alianza)    
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="urarunasNaCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            49 priorizado&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="CuarentaNuevePriorizadosCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" BackColor="Blue"
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            4C/ 5C/ PCB&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="variosCB" runat="server" Width="100%"
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            SALUD/ MINAGRI/ MINEDU/ MIDIS&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="ministeriosCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Veredas&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="veredasCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosNum" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Embarcad&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="embarcaderosCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosNum" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Proy. Produc.&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="proyProductivoCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            FONCODES Total&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="foncodesTotalCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt"  BackColor="Blue">
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Residencia
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="residenciasCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style=" text-align:right; width:5%; font-weight: bold;">
                                            Nucleo Ejec. PNSR&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:7.5%">
                                            <asp:DropDownList ID="nucleoPnsrCB" runat="server" Width="100%" 
                                                DataSourceID="SDS_P_selectCatalogosGIT" DataTextField="nombre" 
                                                DataValueField="ID" Font-Size="8pt" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Situación&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:TextBox ID="situacionTB" runat="server" Width="100%" Font-Size="8pt" autocomplete="off"
                                                TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Situación Problematica&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:TextBox ID="situacionProbTB" runat="server" Width="98.5%" Font-Size="8pt" autocomplete="off"
                                                TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Hito 1&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:TextBox ID="hito1TB" runat="server" Width="100%" Font-Size="8pt" autocomplete="off"
                                                TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Hito 2&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:TextBox ID="hito2TB" runat="server" Width="98.5%" Font-Size="8pt" autocomplete="off"
                                                TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Hito 3&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:TextBox ID="hito3TB" runat="server" Width="100%" Font-Size="8pt" autocomplete="off"
                                                TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                        </td>
                                        <td style=" text-align:right; width:10%; font-weight: bold; " >
                                            Hito 4&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:40%">
                                            <asp:TextBox ID="hito4TB" runat="server" Width="98.5%" Font-Size="8pt" autocomplete="off"
                                                TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="divtableResponsable">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style=" text-align:right; width:10%; font-weight: bold;">
                                            Observaciones&nbsp;
                                        </td>
                                        <td style=" text-align:left; width:100%">
                                            <asp:TextBox ID="observacionTB" runat="server" autocomplete="off"
                                                Width="99.5%" Font-Size="9pt" AutoPostBack="false" TabIndex="15"
                                                TextMode="MultiLine" Rows="3">
                                            </asp:TextBox>     
                                        </td>
                                    </tr>
                                </table>
                            </dt>
                        </td>
                    </tr>
                 </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            DefaultLoadingPanelID="RadAjaxLoadingPanel1"></telerik:RadAjaxManager>
    </form>
    <asp:SqlDataSource ID="SDS_P_selectProvincia" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectProvincia" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="16" Name="departamento" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SDS_P_selectDistrito" runat="server" 
        SelectCommand="ssfd.P_selectDistrito" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="16" Name="departamento" Type="String" />
            <asp:ControlParameter ControlID="provinciaCB" Name="provincia" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SDS_P_selectJerarquia" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectJerarquia" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="jerarquiaId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectNucleo" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectNucleo" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="nucleoDinamizadorId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectCatalogos" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectCatalogos" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectTema" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectTema" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="temaId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectEje" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectEje" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="ejeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectComponente" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectComponente" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="componenteId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectGestionInv" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectGestionInv" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="gestionInversionId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectCatalogosGIT" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectCatalogos" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectPrioridad" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectPrioridad" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="prioridadId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectCatalogosNum" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectCatalogos" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="tipo" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectDivisionFuncional" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectDivisionFuncional" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="divisionFuncionalId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectGrupoFuncional" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectGrupoFuncional" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="grupoFuncionalId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDS_P_selectEstados" runat="server" 
        ProviderName="System.Data.SqlClient" SelectCommand="ssfd.P_selectEstados" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="estadoId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</body>
</html>