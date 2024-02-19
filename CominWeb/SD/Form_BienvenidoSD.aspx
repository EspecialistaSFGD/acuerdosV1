<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_BienvenidoSD.aspx.vb" Inherits="CominWeb.Form_BienvenidoSD" %>
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
        .styleMe{
            border:1px solid #25729a; 
            -webkit-border-radius: 3px; 
            -moz-border-radius: 3px;
            border-radius: 3px;
            font-size:12px;
            font-family:arial, helvetica, sans-serif; 
            padding: 10px 10px 10px 10px; 
            text-decoration:none; 
            display:inline-block;
            text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
            font-weight:bold; 
            color: #FFFFFF;
            background-color: #3093c7; 
            background-image: linear-gradient(to bottom, #3093c7, #1c5a85);
        }

        .styleMe:hover{
            border:1px solid #1c5675;
            background-color: #26759e; 
            background-image: linear-gradient(to bottom, #26759e, #133d5b);
        }

        .styleMe1{
            border:1px solid #9a2525; 
            -webkit-border-radius: 3px; 
            -moz-border-radius: 3px;
            border-radius: 3px;
            font-size:12px;
            font-family:arial, helvetica, sans-serif; 
            padding: 7px 10px 10px 10px; 
            text-decoration:none; 
            display:inline-block;
            text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
            font-weight:bold; 
            color: #FFFFFF;
            background-color: #c73030; 
            background-image: linear-gradient(to bottom, #c73030, #851c1c);
        }

        .styleMe1:hover{
            border:1px solid #751c1c;
            background-color: #9e2626; 
            background-image: linear-gradient(to bottom, #9e2626, #5b1313);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                  <table width="100%" border="0" style="font-size:15; padding-top:7px" >
                        <tr>
                                <td style="width:65%; font-weight:bold; vertical-align:middle; text-align:left; padding-right:3px;">
                                    <asp:Label ID="tituloLB" runat="server" Font-Names="Arial, Helvetica, sans-serif"
                                        Font-Size="18pt" Font-Bold="true" ></asp:Label>
                                </td>
                                <td style="width:35%; font-family: Arial, Helvetica, sans-serif; font-size:15;
                                    font-weight:bold; vertical-align:middle; text-align:right; padding-right:3px;" >
                                    <asp:Label ID="fechaActualLB" runat="server" Font-Size="15" Text=""></asp:Label>
                                </td>
                        </tr>
                    </table>
                </div>
          </div>
    </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="padding-top:30px">
            <asp:Button ID="prioridadesB" runat="server" class="styleMe" Text="LISTA DE INTERVENCIONES" Width="100%" Height="100px" Font-Size="20" />
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="padding-top:30px">
            <asp:Button ID="acuerdoB" runat="server" class="styleMe" Text="LISTA DE ACUERDOS" Width="100%" Height="100px" Font-Size="20" />
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="padding-top:30px">
            <asp:Button ID="validaB" runat="server" class="styleMe1" Text="VALIDA ACREDITADO" Width="100%" Height="100px" Font-Size="20" Visible="false"/>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group">
            <asp:Button ID="registroAsistenciaB" runat="server" class="styleMe1" Text="REGISTRO DE ASISTENCIA" Width="100%" Height="100px" Font-Size="20" Visible="false"/>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group">  
            <asp:Button ID="asistenteListB" runat="server" class="styleMe" Text="LISTA DE ASISTENTES" Width="100%" Height="100px" Font-Size="20" Visible="false"/>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group">
            <asp:Button ID="acreditaListB" runat="server" class="styleMe1" Text="LISTA DE ACREDITADOS" Width="100%" Height="100px" Font-Size="20" Visible="false"/>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group">  
            <asp:Button ID="importaAcreditadoB" runat="server" class="styleMe" Text="IMPORTAR ACREDITADOS" Width="100%" Height="100px" Font-Size="20" Visible="false"/>
        </div>
        <%--<asp:SqlDataSource ID="SDS_P_selectPlanManttoDet" runat="server"  
            SelectCommand="P_selectPlanManttoDet" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="planManttoDetalleID" Type="String" />
                <asp:Parameter DefaultValue="24" Name="planManttoID" Type="String" />
                <asp:Parameter DefaultValue="0" Name="UsuarioID" Type="String" />
                <asp:Parameter DefaultValue="A" Name="tipo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


        </form>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="http://162.248.52.148/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://162.248.52.148/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>
</body>
</html>
