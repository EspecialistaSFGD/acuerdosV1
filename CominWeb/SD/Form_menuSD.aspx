<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form_menuSD.aspx.vb" Inherits="CominWeb.Form_menuSD" %>
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
            <img id="Img1" runat="server" src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/sd_home_cab.png" style="width:100%" />
        </div>
    <center>
        <br />
        <div class="top_nav">
          <div class="nav_menu">
              <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; font-weight:bold;font-size:24px">
                  
                        <asp:Label ID="titulo2LB" runat="server" Font-Bold="False" Font-Size="17pt" Text="" style="font-weight: 600;">
                            ACTUALMENTE REDIRIGIDO A:
                        </asp:Label>
                </div>
          </div>
        </div>
        <div style="width:70%" id="formLogin" runat="server">
            <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                <a id="asesigueBN" runat="server" class="styleMe" style="width:100%; height:60px; font-size:15pt; padding-top:15px" href="https://sesigue.miterritorio.gob.pe/sesigue">
                    sesigue.miterritorio.gob.pe/sesigue
                </a>
            </div>
<%--                    <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                        <a target="_blank" id="acreditadoBN" runat="server" class="styleMe" style="width:100%; height:60px; font-size:15pt; padding-top:15px">
                            REGISTRO DE ACREDITADOS
                        </a>
                    </div>

                    <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                        <a target="_blank" id="asistenciaBN" runat="server" class="styleMe" style="width:100%; height:60px; font-size:15pt; padding-top:15px">
                            REGISTRO DE ASISTENCIA
                        </a>
                    </div>
                    
                    <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                        <a target="_blank" id="reunionesBN" runat="server" class="styleMe" style="width:100%; height:60px; font-size:15pt; padding-top:15px">
                            PROGRAMA DE REUNIONES
                        </a>
                    </div>

                    <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                        <a target="_blank" id="prioridadesBN" runat="server" class="styleMe" style="width:100%; height:60px; font-size:15pt; margin-top:5px; padding-top:15px">
                            LISTA DE PEDIDOS
                        </a>

                    </div>        

                    <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                        <a target="_blank" id="listAcuerdoB" runat="server" class="styleMe" style="width:100%; height:60px; font-size:15pt; margin-top:5px; padding-top:15px">
                            LISTA DE ACUERDOS
                        </a>
                    </div>

                    <div class="col-md-12 col-sm-12 col-xs-12 " style="text-align:center; font-weight:bold; padding-top:20px">
                        <a target="_blank" id="listHitosB" runat="server" class="styleMe" style="width:100%; height:60px; font-size:15pt; padding-top:15px">
                            LISTA DE HITOS
                        </a>
                    </div>--%>
                    
        </div>


    </center>


        <input id="hiddenField" runat="server" type="hidden" value="0" />
        


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="">
        <AjaxSettings>           
        </AjaxSettings>
    </telerik:RadAjaxManager>


        </form>
    <br />
    </body>

<footer>
    <img src="https://sesigue.miterritorio.gob.pe/REFERENCIASBASE/Resources/sd_inferior_web.png" style="width:100%" />
</footer>
    
</html>