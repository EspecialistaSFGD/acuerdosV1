<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_asistenciaCargaMasiva.aspx.vb" Inherits="CominWeb.Form_asistenciaCargaMasiva" %>
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

        <%--    function procesarJS() {
                //var r = confirm("¿Desea procesar las horas ingresadas?");
                //if (r == true) {
                    var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("CreateExcelFile");
                    return false;
                //}
            }--%>

            function busca() {
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("buscaJQ");
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px">
                      <asp:Label ID="tituloLB" runat="server" Font-Size="44px" Font-Bold="true" Text="REGISTRO DE ACREDITADOS"> </asp:Label>
                </div>
          </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; padding-top:30px">
            
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:DropDownList ID="cbo_evento" runat="server" Width="90%" Font-Size="45"
                    DataSourceID="SDS_P_SelectEventos" DataTextField="nombre" 
                    DataValueField="eventoID" TabIndex="1">
                </asp:DropDownList>
            </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:TextBox ID="nombreDocumentoTB" Font-Size="45" runat="server" Width="90%" autocomplete="off" placeholder="NOMBRE DOCUMENTO"></asp:TextBox>
            </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:TextBox ID="nombreHojaTB" Font-Size="45" runat="server" Width="90%" autocomplete="off" placeholder="NOMBRE DE HOJA"></asp:TextBox>
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Button ID="nuevoB" runat="server" Text="IMPORTAR" class="styleMe" Width="90%" 
                    Height="150px" Font-Size="35" />
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12 form-group">

                <asp:Label ID="estadoLB" runat="server" Font-Size="65px" Font-Bold="true" Text="-"> </asp:Label>

            </div>
        </div>
    
        <asp:SqlDataSource ID="SDS_P_SelectEventos" runat="server" 
            SelectCommand="SD_P_selectEventos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="eventoId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
         <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
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
