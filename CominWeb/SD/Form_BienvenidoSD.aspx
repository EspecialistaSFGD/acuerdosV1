<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_BienvenidoSD.aspx.vb" Inherits="CominWeb.Form_BienvenidoSD" %>
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



        .fcc-btn {
            background-color: #199319;
            color: white;
            padding: 15px 25px;
            text-decoration: none;
            cursor: pointer;
            border: none;
        }

        .site-footer {
            background-color: #26272b;
            padding: 45px 0 20px;
            font-size: 15px;
            line-height: 24px;
            color: #737373;
        }
            .site-footer hr {
                border-top-color: #bbb;
                opacity: 0.5
            }
                .site-footer hr.small {
                    margin: 20px 0
                }
            .site-footer h6 {
                color: #fff;
                font-size: 16px;
                text-transform: uppercase;
                margin-top: 5px;
                letter-spacing: 2px
            }
            .site-footer a {
                color: #737373;
            }
                .site-footer a:hover {
                    color: #3366cc;
                    text-decoration: none;
                }
        .footer-links {
            padding-left: 0;
            list-style: none
        }
            .footer-links li {
                display: block
            }
.footer-links a
{
  color:#737373
}
.footer-links a:active,.footer-links a:focus,.footer-links a:hover
{
  color:#3366cc;
  text-decoration:none;
}
.footer-links.inline li
{
  display:inline-block
}
.site-footer .social-icons
{
  text-align:right
}
.site-footer .social-icons a
{
  width:40px;
  height:40px;
  line-height:40px;
  margin-left:6px;
  margin-right:0;
  border-radius:100%;
  background-color:#33353d
}
.copyright-text
{
  margin:0
}
@media (max-width:991px)
{
  .site-footer [class^=col-]
  {
    margin-bottom:30px
  }
}
@media (max-width:767px)
{
  .site-footer
  {
    padding-bottom:0
  }
  .site-footer .copyright-text,.site-footer .social-icons
  {
    text-align:center
  }
}
.social-icons
{
  padding-left:0;
  margin-bottom:0;
  list-style:none
}
.social-icons li
{
  display:inline-block;
  margin-bottom:4px
}
.social-icons li.title
{
  margin-right:15px;
  text-transform:uppercase;
  color:#96a2b2;
  font-weight:700;
  font-size:13px
}
.social-icons a{
  background-color:#eceeef;
  color:#818a91;
  font-size:16px;
  display:inline-block;
  line-height:44px;
  width:44px;
  height:44px;
  text-align:center;
  margin-right:8px;
  border-radius:100%;
  -webkit-transition:all .2s linear;
  -o-transition:all .2s linear;
  transition:all .2s linear
}
.social-icons a:active,.social-icons a:focus,.social-icons a:hover
{
  color:#fff;
  background-color:#29aafe
}
.social-icons.size-sm a
{
  line-height:34px;
  height:34px;
  width:34px;
  font-size:14px
}
.social-icons a.facebook:hover
{
  background-color:#3b5998
}
.social-icons a.twitter:hover
{
  background-color:#00aced
}
.social-icons a.linkedin:hover
{
  background-color:#007bb6
}
.social-icons a.dribbble:hover
{
  background-color:#ea4c89
}
@media (max-width:767px)
{
  .social-icons li.title
  {
    display:block;
    margin-right:0;
    font-weight:600
  }
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


            function checkAcuerdo(letra) 
            {
                debugger;
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

            function checkNum(e) {
                var key = window.Event ? e.which : e.keyCode
                return (key >= 48 && key <= 57 || key == 46)
            }

            function validateEmail() {
                    var email = document.getElementById('correoTB');
                    var cont = 0;
                for (var i = 0, j = email.value.length; i < j; i++) {
                    if (email.value[i] == "@") {
                        cont++;
                    }
                    } if (cont == 0) {
                        mensaje('information', 'Ingrese un correo VÁLIDO.');
                        return false;
                    }
                    else {
                        return true;
                    }
                }

            window.setInterval("renewSession();", 30000);

            function renewSession() {
                console.log("Renovando session...");
                document.getElementById('renewSession').src = 'https://sesigue.com/PROFAKTOWEB/SessionActiva.aspx?par=' + Math.random();
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
                    type: tipo, // alert | error | success | information | warning | confirm
                    dismissQueue: true,
                    layout: 'center',
                    theme: 'defaultTheme',
                    modal: true
                });
                console.log('html: ' + n.options.id);
            }

        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_nav">
        <%--<img id="Img2" runat="server" src="https://sesigue.com/REFERENCIASBASE/Resources/sd_cabecera_web.png" style="width:100%" />--%>
        <%--<img id="imagenPresentacionIMG" runat="server" src="https://sesigue.com/REFERENCIASBASE/Resources/sd_home_web.png" style="width:100%" />--%>
            <img id="Img1" runat="server" src="https://sesigue.com/REFERENCIASBASE/Resources/sd_home_cab.png" style="width:100%" />
        </div>
    <center>

        <%--<div class="col-md-12 col-sm-12 col-xs-12 form-group" style="margin-top:20px; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;"></div>--%>
        <div style="width:70%" id="formLogin" runat="server">

                <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:20px; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        TIPO
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="tipoCB" runat="server" Width="100%" Font-Size="15pt" Height="50px"
                            class="form-control" TabIndex="3" AppendDataBoundItems="True" AutoPostBack="true" >
                            <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            <asp:ListItem Value="1" > Gobierno Nacional </asp:ListItem>
                            <asp:ListItem Value="2" > Gobierno Regional / Local </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="divSec" runat="server" class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        SECTOR
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                            <asp:DropDownList ID="grupoCB" runat="server" Width="100%" Font-Size="15pt" Height="50px"
                                    DataSourceID="SDS_SD_P_selectGrupos" DataTextField="nombre" class="form-control"
                                    DataValueField="grupoID" TabIndex="6" AppendDataBoundItems="True" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>

                <div id="divDep" runat="server" class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        DEPARTAMENTO
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="cbo_departamento1" runat="server" DataSourceID="SDS_P_selectDepartamento" DataTextField="departamento" 
                                DataValueField="departamentoID" AutoPostBack="true" Width="100%" TabIndex="12" class="form-control" Font-Size="15pt" Height="50px"
                                AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                                </div>

                <div id="divProv" runat="server" class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        PROVINCIA
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="cbo_provincia1" runat="server" DataSourceID="SDS_P_selectProvincia" DataTextField="provincia" AutoPostBack="true"
                            DataValueField="provinciaID" Width="100%" TabIndex="13" class="form-control" Font-Size="15pt" Height="50px">
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="divDis" runat="server" class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        DISTRITO
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                        <asp:DropDownList ID="cbo_distrito" runat="server" DataSourceID="SDS_P_selectDistrito" DataTextField="DISTRITO" AutoPostBack="true"
                            DataValueField="distritoID" Width="100%" TabIndex="13" class="form-control" Font-Size="15pt" Height="50px">
                        </asp:DropDownList>
                    </div>
                </div>

                <div id="divEnti" runat="server" class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        ENTIDAD
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                            <asp:DropDownList ID="entidadCB" runat="server" DataSourceID="SDS_SD_P_selectEntidades" DataTextField="nombre" 
                                    DataValueField="entidadId" Width="100%" TabIndex="12" class="form-control" Font-Size="15pt" Height="50px"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" > - Seleccione - </asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>



                <div class="col-md-12 col-sm-12 col-xs-12 " style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:8px; font-size:12pt">
                        NOMBRES
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                            <asp:TextBox ID="nombreTB" Font-Size="15" runat="server" Width="100%" autocomplete="off" TabIndex="1" MaxLength="100" Height="45px"
                                placeholder="" class="form-control" onkeypress="return checkAcuerdo(event)"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        DNI
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                            <asp:TextBox ID="dniTB" Font-Size="15" runat="server" Width="100%" autocomplete="off" TabIndex="1" MaxLength="8" Height="45px"
                                placeholder="" class="form-control" onkeypress="return checkNum(event)" ></asp:TextBox>
                            
                    </div>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        CORREO
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                            <asp:TextBox ID="correoTB" Font-Size="15" runat="server" Width="100%" autocomplete="off" TabIndex="1" MaxLength="150" Height="45px"
                                placeholder="" class="form-control" onblur="validateEmail(); return false;"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12" style="margin-top:2px; padding-top:5px; padding-bottom:2px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                    <div class="col-md-2 col-sm-4 col-xs-4 " style="text-align:left; vertical-align:middle; font-weight:bold; padding-top:13px; font-size:12pt">
                        TELÉFONO
                    </div>
                    <div class="col-md-10 col-sm-8 col-xs-8 " style="text-align:left; ">
                            <asp:TextBox ID="telefonoTB" Font-Size="15" runat="server" Width="100%" autocomplete="off" TabIndex="1" MaxLength="9" Height="45px" 
                                placeholder="" class="form-control" onkeypress="return checkNum(event)" ></asp:TextBox>
                    </div>
                </div>

                

                    <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                        <asp:Button ID="generarB" runat="server" class="styleMe" Text="GENERAR URL" Width="100%" Height="50px" Font-Size="15" />
                    </div>

        </div>

                <div style="width:70%">
            <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="padding-top:30px">
                    <%--<asp:Button ID="acuerdoB" runat="server" class="styleMe" Text="LISTA DE ACUERDOS" Width="100%" Height="100px" Font-Size="20" target="_blank" />--%>
                    <a target="_blank" id="listAcuerdoB" runat="server" class="styleMe" style="width:100%; height:100px; font-size:20pt; margin-top:10px; padding-top:30px"
                        href="AcuerdosListV.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=D72E58A4A3B20314C59A69BB1ED5905F88DBBDB2AE4B7DB1&gjXtIkEroS=SD_SSFD&ksjcmj=0&hsndktumg=D72E58A4A3B20314C59A69BB1ED5905F88DBBDB2AE4B7DB1&tipo=1&ubig=0&de=&en=3384&sup=2&enti=Vista+General">                
                        LISTA DE ACUERDOS
                    </a>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="padding-top:30px">
                    <%--<asp:Button ID="hitoB" runat="server" class="styleMe" Text="LISTA DE HITOS" Width="100%" Height="100px" Font-Size="20" target="_blank"/>--%>
                    <a target="_blank" id="listHitosB" runat="server" class="styleMe" style="width:100%; height:100px; font-size:20pt; padding-top:30px"
                        href="AcuerdosListHitoV.aspx?lkjasdliwupqwinasndlkkjasKASNDDDWILADdASKJSdwuewue=lksajdasdwWDwdwDdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD">
                        LISTA DE HITOS
                    </a>
                </div>
        </div>

    </center>
   
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="padding-top:30px">
            <%--<asp:Button ID="prioridadesB" runat="server" class="styleMe" Text="LISTA DE INTERVENCIONES" Width="100%" Height="100px" Font-Size="20" Visible="true" />--%>
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
        <input id="hiddenField" runat="server" type="hidden" value="0" />
        
        
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
        <asp:SqlDataSource ID="SDS_SD_P_selectEntidades" runat="server" 
            SelectCommand="SD_P_selectEntidades" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="entidadId" Type="Int32" />
                <asp:ControlParameter ControlID="tipoCB" DefaultValue="3" Name="tipo" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="grupoCB" DefaultValue="-1" Name="sectorId" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="hiddenField" DefaultValue="0" Name="ubigeo" PropertyName="value" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SDS_P_selectDistrito" runat="server" 
            ProviderName="System.Data.SqlClient" SelectCommand="SD_P_selectDistritoSD" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbo_provincia1" DefaultValue="" Name="provincia" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="tipo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="tipoCB">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divSec" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="divDep" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="divProv" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="divEnti" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grupoCB">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="entidadCB" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="hiddenField" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbo_departamento1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbo_provincia1" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="cbo_distrito" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="hiddenField" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="entidadCB" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbo_provincia1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="hiddenField" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="cbo_distrito" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="entidadCB" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbo_distrito">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="hiddenField" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="entidadCB" LoadingPanelID="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>


        </form>
<%--    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.com/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>--%>




    </body>

<footer>
    <img src="https://sesigue.com/REFERENCIASBASE/Resources/sd_inferior_web.png" style="width:100%" />
</footer>
    
</html>