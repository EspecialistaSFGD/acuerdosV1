<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registroHitoV.aspx.vb" Inherits="CominWeb.registroHitoV" %>
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


            function OnClientClose1(oWnd, eventArgs) {
                document.getElementById('<%= hiddenField.ClientID%>').value = eventArgs.get_argument().indicador;
                var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();
                oWnd.remove_close(OnClientClose1);
            }

            function reactivaHito(id) {
                /*mensaje('error', 'procede la reactivación.' + id);*/
                ajaxManager.ajaxRequest("reactivaHito,0," + id);
            }

            function frmHitoN(id) {
                var est = '<%= Me.Request.QueryString("estReg")%>';
                var pla = '<%= Me.Request.QueryString("pla")%>';
                var ubig = '<%= Me.Request.QueryString("ubig")%>';
                var sup = '<%= Me.Request.QueryString("sup")%>';
                var codigAcu = document.getElementById("codigoLB").innerHTML;
                
                if (ubig > 0) {
                    mensaje('error', 'Acceso solo para el sector.');
                }
                else if (sup == 2) {
                    mensaje('error', 'Acceso solo para el Ministerio.');
                }
                else if (sup == 0) {
                    mensaje('error', 'Acceso solo para el Ministerio.');
                }
                else {

                    //if (pla == 1) {
                    //    mensaje('information', 'Acuerdo VENCIDO, no se puede agregar nuevos hitos.');
                    //}
                    //else {

                    if (est == 1) {
                        mensaje('information', 'Acuerdo cumplido, no se puede agregar nuevos hitos.');
                        return true;
                    }
                    else if (est == 3) {
                        mensaje('information', 'Acuerdo VENCIDO, no se puede agregar nuevos hitos.');
                        return true;
                    }
                    else if (est == 4) {
                        mensaje('information', 'Acuerdo DESESTIMADO, no se puede agregar nuevos hitos.');
                        return true;
                    }
                    else {
                        if (est == 4) {
                            mensaje('information', 'Acuerdo desestimado.');
                            return true;
                        }
                        else {
                            var oWnd = $find("<%= RadWindow2.ClientID %>");
                            var ruta_ventana_empresas = "registroHi.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codh=" + id + "&codigoid=" + '<%= Me.Request.QueryString("codigoid")%>' + "&tipo=" + '<%= Me.Request.QueryString("tipo")%>' + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&ksjcmj=" + '<%= Me.Request.QueryString("ksjcmj")%>' + "&en=" + '<%= Me.Request.QueryString("en")%>' + "&codigAcu=" + codigAcu + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                            oWnd.setUrl(ruta_ventana_empresas);
                            oWnd.add_close(OnClientClose1);
                            oWnd.show();
                            return false;
                        }

                    }
                    //}-------

                }
                <%--else if (sup == 0) {
                    mensaje('error', 'Acceso solo para el sector.');
                }
                else if (sup == 2) {

                    if (est == 1) {
                        mensaje('information', 'Acuerdo cumplido, no se puede agregar nuevos hitos.');
                        return true;
                    }
                    else if (est == 3) {
                        mensaje('information', 'Acuerdo VENCIDO, no se puede agregar nuevos hitos.');
                        return true;
                    }
                    else if (est == 4) {
                        mensaje('information', 'Acuerdo DESESTIMADO, no se puede agregar nuevos hitos.');
                        return true;
                    }
                    else {

                        var oWnd = $find("<%= RadWindow2.ClientID %>");
                        var ruta_ventana_empresas = "registroHi.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codh=" + id + "&codigoid=" + '<%= Me.Request.QueryString("codigoid")%>' + "&tipo=" + '<%= Me.Request.QueryString("tipo")%>' + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&ksjcmj=" + '<%= Me.Request.QueryString("ksjcmj")%>' + "&en=" + '<%= Me.Request.QueryString("en")%>';
                        oWnd.setUrl(ruta_ventana_empresas);
                        oWnd.add_close(OnClientClose1);
                        oWnd.show();
                        return false;
                    }
                }
                else {
                    
                    var mensaje = confirm("¿Desea desestimar el acuerdo?");
                    if (mensaje) {
                        mensaje('warning', 'Se ha enviando un email a la Secretaría de Descentralización.');
                        $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("desestima");
                        return false;
                    }
                    
                    //if (pla == 1) {
                    //    mensaje('information', 'Acuerdo VENCIDO, no se puede agregar nuevos hitos.');
                    //}
                    //else {
                }--%>
                //}-------

            }
            

            function OnClientCloseAv(oWnd, eventArgs) {
                location.href = "AcuerdosListV.aspx?7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0=" + '<%= Me.Request.QueryString("7B611A09B990B80849DBE7AF822D63E466D552839D9EC6E0")%>' + "&gjXtIkEroS=SD_SSFD&ksjcmj=" + '<%= Me.Request.QueryString("ksjcmj")%>' + "&hsndktumg=" + '<%= Me.Request.QueryString("hsndktumg")%>' + "&tipo=" + '<%= Me.Request.QueryString("tipo")%>' + "&ubig=" + '<%= Me.Request.QueryString("ubig")%>' + "&de=" + '<%= Me.Request.QueryString("de")%>' + "&en=" + '<%= Me.Request.QueryString("en")%>' + "&sup=" + '<%= Me.Request.QueryString("sup")%>' + "&enti=" + '<%= Me.Request.QueryString("enti")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                oWnd.remove_close(OnClientCloseAv);
            }

            function OnClientCloseA2(oWnd, eventArgs) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("actualiza");
                oWnd.remove_close(OnClientCloseA2);
            }

            function frmAvanceN(id) {
                var codac = document.getElementById("codigoLB").innerHTML;
                var est = '<%= Me.Request.QueryString("estReg")%>';
                var pla = '<%= Me.Request.QueryString("pla")%>';
                var ubig = '<%= Me.Request.QueryString("ubig")%>';
                var sup = '<%= Me.Request.QueryString("sup")%>';

                if (ubig > 0) {
                    mensaje('error', 'Acceso solo para el sector.');
                }
                else if (sup == 0) {
                    mensaje('error', 'Acceso solo para el sector.');
                }
                else if (sup == 2) {
                    if (pla == 1) {
                        mensaje('information', 'Acuerdo VENCIDO.');
                    }
                    else {
                        if (est == 1) {
                            mensaje('information', 'Acuerdo cumplido, no se puede agregar nuevos avances.');
                            return true;
                        }
                        else if (est == 4) {
                            mensaje('information', 'Acuerdo Desestimado');
                            return true;
                        }
                        else {

                            var oWnd = $find("<%= RadWindow2.ClientID %>");
                            var ruta_ventana_empresas = "registroAva.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codAv=" + id + "&codh=0&codigoid=" + '<%= Me.Request.QueryString("codigoid")%>' + "&tipo=1&en=" + '<%= Me.Request.QueryString("en")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                            oWnd.setUrl(ruta_ventana_empresas);
                            oWnd.add_close(OnClientCloseAv);
                            oWnd.show();
                            return true;
                        }

                    }
                }
                else {
                    var mensajex = confirm("¿Desea solicitar desestimar el acuerdo?");
                    if (mensajex) {
                        var oWnd = $find("<%= RadWindow2.ClientID %>");
                        var ruta_ventana_empresas = "registroComenDes.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codAv=" + id + "&codh=0&codigoid=" + '<%= Me.Request.QueryString("codigoid")%>' + "&tipo=1&en=" + '<%= Me.Request.QueryString("en")%>' + "&codac=" + codac + "&enti=" + '<%= Me.Request.QueryString("enti")%>' + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                        oWnd.setUrl(ruta_ventana_empresas);
                        oWnd.add_close(OnClientCloseAv);
                        oWnd.show();
                        return true;
                        <%--mensaje('warning', 'Se ha enviando un email a la Secretaría de Descentralización.');
                        $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("desestima");--%>
                    }
                }
            }

            function frmAvanceN2(id, hi, est) {
               <%-- var ubig = '< % = Me.Request.QueryString("ubig")%>';
               //var sup = '< % = Me.Request.QueryString("sup")%>';

                if (ubig > 0) {
                    mensaje('error', 'Acceso solo para el sector.');
                }
                //else if (sup == 0) {
                //    mensaje('error', 'Acceso solo para el sector.');
                //}

                else {--%>
                    if (est == 1) {
                        mensaje('information', 'Hito cumplido, no se puede agregar nuevos avances.');
                        return false;
                    }
                    else {
                        var oWnd = $find("<%= RadWindow2.ClientID %>");
                        var ruta_ventana_empresas = "registroAva.aspx?lkjasdliwupqwifgdsgdfgrgdsfgdfsgdsfoiwermzxc9rurnasndlkkjasdwuewue=lksajdlaksjdlnlnkj34lkjlk324nkjn2l3k4k567lk5786666lk76nwnbmnkjhkjh&gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codAv=0&codh=" + hi + "&codigoid=" + '<%= Me.Request.QueryString("codigoid")%>' + "&tipo=2" + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>';
                        oWnd.setUrl(ruta_ventana_empresas);
                        oWnd.add_close(OnClientCloseA2);
                        oWnd.show();
                        return false;
                    }
                //}

            }

            function eliminaAvance(id, est, ent) {
                var en = '<%= Me.Request.QueryString("en")%>';

                if (en != ent) {
                    mensaje('error', 'No corresponde a la entidad.');
                }
                else {
                    if (est == 1) {
                        mensaje('information', 'Avance cumplido, no se puede eliminar.');
                    }
                    else {
                        var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                        ajaxManager.ajaxRequest("eliminaAvance," + id + ",0");
                    }
                    return false;
                }
            }

            function frmValidacion(id, tic) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("validacion," + id + "," + tic);
                mensaje('warning', "Se validó el avance")
                mensaje('warning', "El GL podrá realizar comentarios, así el avance esté VALIDADO")
                <%--var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();--%>
                return false;
            }

            function frmValidacionHito(id, tic) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest("validacionHito," + id + "," + tic);
                mensaje('warning', "Se validó el Hito")
                mensaje('warning', "Para modificar la validación debe comunicarse con la Secretaría de Descentralización")
                return false;
                <%--var masterTable1 = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable1.rebind();--%>
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

            function RadGrid1_OnRowSelected(sender, args) {
                var hitdoId = args.getDataKeyValue("hitdoId"); 
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("actualizaDet" + "," + hitdoId + ",0");
                return false;
            }

            function frmEvidencia(id, link) {
                if (link == 'evidencia/&nbsp;') {
                    mensaje('information', 'No existe evidencia.');
                }
                else {
                    var win = window.open(link, '_blank');
                    win.focus();
                }
                return false;
            }


            function frmComentario(id, tic) {
                var oWnd = $find("<%= RadWindow2.ClientID %>");
                var ruta_ventana_empresas = "registroComentario.aspx?gjXtIkEroS=SD_SSFD&pkASIEMVadASDkwdasdmad=jasdwdNasdJasd135&codAv=" + id + "&tic=" + tic + "&iacp=" + '<%= Me.Request.QueryString("iacp")%>' + "&tipo=HI";
                oWnd.setUrl(ruta_ventana_empresas);
                oWnd.add_close(OnClientCloseA2);
                oWnd.show();
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
                      <asp:Label ID="titulo2LB" runat="server" Font-Bold="False" Font-Size="17pt" Text="" style="font-weight: 600;">GESTIÓN DE HITOS</asp:Label>
                </div>
          </div>
        </div>



        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:center; margin-right:120px; margin-left:2%; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
            <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                SECTOR
            </div>
            <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                <asp:Label ID="sectorLB" runat="server" Font-Bold="False" Font-Size="10pt" Text=".">
                </asp:Label>
            </div>
            <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                DEPARTAMENTO
            </div>
            <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                <asp:Label ID="departamentoLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="." >
                </asp:Label>
            </div>
            <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                PROVINCIA
            </div>
            <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                <asp:Label ID="provinciaLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="." Width="90%">
                </asp:Label>
            </div>
            <div class="col-md-1 col-sm-2 col-xs-4" style="text-align:left; font-weight:bold">
                CUI
            </div>
            <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                <asp:Label ID="cuiLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="3213215" >
                </asp:Label>
            </div>
        </div>

        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:left; margin-right:120px; margin-left:2%; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
            <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                INTERVENCIONES ESTRATEGICAS
            </div>
            <div class="col-md-11 col-sm-10 col-xs-8 " style="text-align:left; ">
                <asp:Label ID="intervencionLB" runat="server" Font-Bold="False" Font-Size="10pt" Text=".">
                </asp:Label>
            </div>

        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:left; margin-right:120px; margin-left:2%; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
            <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                ASPECTO CRITICO A RESOLVER
            </div>
            <div class="col-md-11 col-sm-10 col-xs-8 " style="text-align:left ; ">
                <asp:Label ID="aspectoLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="." >
                </asp:Label>
            </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:left; margin-right:120px; margin-left:2%; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
            <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                ACUERDO
            </div>
            <div class="col-md-11 col-sm-10 col-xs-8 " style="text-align:left; ">
                <asp:Label ID="acuerdoLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="." >
                </asp:Label>
            </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:left; margin-right:120px; margin-left:2%; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    CODIGO
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    <asp:Label ID="codigoLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="." >
                    </asp:Label>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    CLASIFICACIÓN
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    <asp:Label ID="clasificaLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="." >
                    </asp:Label>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    RESPONSABLE
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    <asp:Label ID="responsableLB" runat="server" Font-Bold="False" Font-Size="10pt" Text=".">
                    </asp:Label>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    PLAZO
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    <asp:Label ID="plazoLB" runat="server" Font-Bold="False" Font-Size="10pt" Text="."  >
                    </asp:Label>
                </div>
        </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group" style="text-align:left; margin-right:120px; margin-left:2%; padding-top:5px; padding-bottom:3px; border-right: #578533 1px solid; border-top: #578533 1px solid; border-left: #578533 1px solid; border-bottom: #578533 1px solid; background-color: white;">
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    ESTADO
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    <asp:Label ID="estadoLB" runat="server" Font-Bold="true" Font-Size="14pt" Text="" ForeColor="Red" >
                    </asp:Label>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    FECHA
                </div>
                <div class="col-md-2 col-sm-4 col-xs-8 " style="text-align:center; ">
                    <asp:Label ID="fechaLB" runat="server" Font-Bold="true" Font-Size="14pt" Text="" ForeColor="Red" >
                    </asp:Label><input id="hiddenField" runat="server" type="hidden" value="" /> <%-----------------------------------------------------%>
                    <%--<asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="10pt" Text="" >
                    </asp:Label>--%>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4 " style="text-align:left; font-weight:bold">
                    MOTIVO DE DESESTIMACIÓN
                </div>
                <div class="col-md-3 col-sm-8 col-xs-12 " style="text-align:center; ">
                    <asp:Label ID="motivoDesLB" runat="server" Font-Bold="true" Font-Size="14pt" Text="" ForeColor="Red" >
                    </asp:Label>
                </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:center; margin-left:2%;">
                <div class="col-md-4 col-sm-6 col-xs-12" style="text-align:center; font-weight:bold; padding-bottom:3px; padding-top:3px;">
                    <asp:Button ID="retornarB" runat="server" Text="RETORNA A LISTA" class="styleMe" Width="100%" Height="40px" Font-Size="10pt" ToolTip="Retorna a Lista de acuerdos" />
                </div>
                <div class="col-md-4 col-sm-6 col-xs-12" style="text-align:center; font-weight:bold; padding-bottom:3px; padding-top:3px;">
                    <button id="registraA" runat="server" class="styleMe1" style="Width:100%; Height:40px; font:16pt" onclick="frmAvanceN(0); return false;" >SOLICITUD PARA DESESTIMAR ACUERDO</button>
                 </div>
                <div class="col-md-4 col-sm-6 col-xs-12" style="text-align:center; font-weight:bold; padding-bottom:3px; padding-top:3px;">
                    <button id="registraH" runat="server" class="styleMe" style="Width:100%; Height:40px; font:16pt;"  onclick="frmHitoN(0); return false;">CREAR HITO</button>
                </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:center; margin-left:2%;">
            <telerik:radgrid ID="RadGrid1" runat="server" Width="100%" Culture="es-ES" DataSourceID="SDS_SD_P_selectListHitos" Skin="Bootstrap" 
                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GroupPanelPosition="Top" Font-Bold="True">
                <GroupingSettings CaseSensitive="false" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" CellSelectionMode="None" UseClientSelectColumnOnly="True" />
                    <ClientEvents OnRowSelected="RadGrid1_OnRowSelected" />
                </ClientSettings>
                <MasterTableView DataSourceID="SDS_SD_P_selectListHitos" NoMasterRecordsText="No existen registros." PageSize="10"
                    DataKeyNames="hitdoId, hito" ClientDataKeyNames="hitdoId" >
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
                                <asp:ImageButton ID="edita" runat="server" CssClass="cursor" ToolTip="Editar Hito"
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/UpdateG.png"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>

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
                    </telerik:GridTemplateColumn>

                    <telerik:GridBoundColumn DataField="hitdoId" FilterControlAltText="Filter hitdoId column" 
                        HeaderText="hitdoId" ReadOnly="True" SortExpression="hitdoId" UniqueName="hitdoId"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="acuerdoID" FilterControlAltText="Filter acuerdoID column" 
                        HeaderText="acuerdoID" ReadOnly="True" SortExpression="acuerdoID" UniqueName="acuerdoID"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="responsableID" FilterControlAltText="Filter responsableID column" 
                        HeaderText="responsableID" ReadOnly="True" SortExpression="responsableID" UniqueName="responsableID"
                        Display="false">
                    </telerik:GridBoundColumn>
                    <%-- <telerik:GridBoundColumn DataField="codigo" FilterControlAltText="Filter codigo column" 
                        HeaderText="CODIGO" SortExpression="codigo" UniqueName="codigo" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Large" Width="150px"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Medium" Font-Bold="true"/>
                    </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn DataField="hito" FilterControlAltText="Filter hito column" 
                        HeaderText="HITO" SortExpression="hito" UniqueName="hito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="responsable" FilterControlAltText="Filter responsable column" 
                        HeaderText="RESPONSABLE" SortExpression="responsable" UniqueName="hito" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="entidad" FilterControlAltText="Filter entidad column" 
                        HeaderText="ENTIDAD RESPONSABLE" SortExpression="entidad" UniqueName="entidad" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" Width="30%"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn>
                    <telerik:gridboundcolumn DataField="plazo" DataType="System.DateTime" 
                        FilterControlAltText="Filter plazo column" HeaderText="PLAZO" 
                        SortExpression="plazo" UniqueName="plazo"
                        DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="False" >
                        <HeaderStyle HorizontalAlign="Center" Width="85PX" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" Font-Size="Small"/>
                    </telerik:gridboundcolumn>
                    <telerik:GridBoundColumn DataField="estadoRegistro" FilterControlAltText="Filter estadoRegistro column" 
                        HeaderText="estadoRegistro" SortExpression="estadoRegistro" UniqueName="estadoRegistro" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="nomEstado" FilterControlAltText="Filter nomEstado column" 
                        HeaderText="ESTADO" SortExpression="nomEstado" UniqueName="nomEstado" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn> 
                    <telerik:gridboundcolumn DataField="validado" 
                        FilterControlAltText="Filter validado column" HeaderText="validado" 
                        SortExpression="validado" UniqueName="validado"
                        AllowFiltering="false" Display="false">
                    </telerik:gridboundcolumn>
                    <telerik:GridBoundColumn DataField="entidadId" FilterControlAltText="Filter entidadId column" 
                        HeaderText="entidadId" SortExpression="entidadId" UniqueName="entidadId" AutoPostBackOnFilter="true" 
                        FilterControlWidth="100%" ShowFilterIcon="false" Display="false">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small"/>
                        <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                    </telerik:GridBoundColumn> 
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TCAvance column" HeaderTooltip="Crear Avance"
                        HeaderText="AV" UniqueName="TCAvance" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="TCavance" runat="server" CssClass="cursor" ToolTip="Crear Avance"
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/refresh_1.png"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                        HeaderText="Eli" UniqueName="TemplateColumnDelete" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="eliminaHito" runat="server" CssClass="cursor" 
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/CancelG.png"
                                    ToolTip="Eliminar Hito" UseSubmitBehavior="False"
                                    OnClientClick="javascript: if(!confirm('¿Desea Eliminar el HITO?')){return false;}"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" Width="2%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column" 
                        HeaderText="REActiva" UniqueName="TemplateColumnDelete" AllowFiltering="false" >
                        <ItemTemplate>
                                <asp:ImageButton ID="reactivaHito" runat="server" CssClass="cursor" 
                                    ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/activo_0.png"
                                    ToolTip="Estado del Hito" UseSubmitBehavior="False"
                                    OnClientClick="javascript: if(!confirm('¿Desea retornar el estado del hito a: EN PROCESO?')){return false;}"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" />
                        <ItemStyle HorizontalAlign="Center" Width="2%" />
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:radgrid>

        </div>
            <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:left; margin-left:2%; margin-top:20px">
                <asp:Label ID="descripcionTB" runat="server" Font-Bold="False" Font-Size="12pt" Text="AVANCES del hito: " style="font-weight: 600; color:brown"></asp:Label>
            </div>
        <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:center; margin-left:2%;">
            <br />
                <telerik:radgrid ID="RadGridImagen" runat="server" Skin="Bootstrap" 
                    Culture="es-ES" DataSourceID="SDS_SD_P_selectListAvance" 
                    AllowSorting="True" GroupPanelPosition="Top">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="avanceId" Font-Bold="false" 
                        DataSourceID="SDS_SD_P_selectListAvance" NoMasterRecordsText="No existen registros."
                        Font-Size="8pt">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" 
                            FilterControlAltText="Filter ExpandColumn column" Created="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:gridboundcolumn DataField="avanceId" 
                                FilterControlAltText="Filter avanceId column" 
                                HeaderText="avanceId" ReadOnly="True" 
                                SortExpression="avanceId" 
                                UniqueName="avanceId"
                                Display="false">
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="hitdoId" 
                                FilterControlAltText="Filter hitdoId column" 
                                HeaderText="hitdoId" SortExpression="hitdoId" 
                                UniqueName="hitdoId"
                                Display="false">
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="fecha" DataType="System.DateTime" 
                                FilterControlAltText="Filter fecha column" HeaderText="FECHA" 
                                SortExpression="fecha" UniqueName="fecha"
                                DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="False" >
                                <HeaderStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="Small"/>
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="avance" FilterControlAltText="Filter avance column" HeaderText="AVANCE" 
                                SortExpression="avance" UniqueName="avance" AllowFiltering="false" Display="true">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="evidencia" FilterControlAltText="Filter evidencia column" HeaderText="EVIDENCIA" 
                                SortExpression="evidencia" UniqueName="evidencia" AllowFiltering="false" Display="false" >
                                <HeaderStyle HorizontalAlign="Center" Width="200px" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White"/>
                                <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                            </telerik:gridboundcolumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TCEvidencia column" HeaderTooltip="Descargar Evidencia"
                                HeaderText="Evi" UniqueName="TCEvidencia" AllowFiltering="false" >
                                <ItemTemplate>
                                        <asp:ImageButton ID="TCevidencia" runat="server" CssClass="cursor" ToolTip="Descargar Evidencia"
                                            ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/tormenta_001.png"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White"/>
                                <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                            </telerik:GridTemplateColumn>
                            
                            <telerik:gridboundcolumn DataField="comentarioSector" 
                                FilterControlAltText="Filter comentarioSector column" HeaderText="COMENTARIO SECTOR" 
                                SortExpression="comentarioSector" UniqueName="comentarioSector"
                                AllowFiltering="false" Display="true">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="comentario" 
                                FilterControlAltText="Filter comentario column" HeaderText="COMENTARIO UE O GL" 
                                SortExpression="comentario" UniqueName="comentario"
                                AllowFiltering="false" Display="true">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="comentarioSD" 
                                FilterControlAltText="Filter comentarioSD column" HeaderText="COMENTARIO PCM" 
                                SortExpression="comentarioSD" UniqueName="comentarioSD"
                                AllowFiltering="false" Display="true">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="entidadID" 
                                FilterControlAltText="Filter entidadID column" HeaderText="entidadID" 
                                SortExpression="entidadID" UniqueName="entidadID"
                                AllowFiltering="false" Display="false">
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="validado" 
                                FilterControlAltText="Filter validado column" HeaderText="validado" 
                                SortExpression="validado" UniqueName="validado"
                                AllowFiltering="false" Display="false">
                            </telerik:gridboundcolumn>
                            <telerik:gridboundcolumn DataField="estado" 
                                FilterControlAltText="Filter estado column" HeaderText="estado" 
                                SortExpression="estado" UniqueName="estado"
                                AllowFiltering="false" Display="false">
                            </telerik:gridboundcolumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TCsector column" HeaderTooltip="Comentario del Sector"
                                HeaderText="Sector" UniqueName="TCsector" AllowFiltering="false" >
                                <ItemTemplate>
                                        <asp:ImageButton ID="TCsector" runat="server" CssClass="cursor" ToolTip="Comentario del Sector"
                                            ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/report.png"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TCComentario column" HeaderTooltip="Crear Comentario"
                                HeaderText="Comentario" UniqueName="TCComentario" AllowFiltering="false" >
                                <ItemTemplate>
                                        <asp:ImageButton ID="TCComentario" runat="server" CssClass="cursor" ToolTip="Crear Comentario"
                                            ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/report_edit.png"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter Llave column" HeaderTooltip="Validar Acción"
                                HeaderText="Validar" UniqueName="TCValida" AllowFiltering="false" >
                                <ItemTemplate>
                                        <asp:ImageButton ID="TCValida" runat="server" CssClass="cursor" 
                                            ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/peligro_20.png"
                                            ToolTip="Validar Acción" UseSubmitBehavior="False"
                                            OnClientClick="javascript: if(!confirm('¿Desea validar el avance?')){return false;}"/>
                                </ItemTemplate>


                                <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>


                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumnEstado column"
                                HeaderText="Eli" UniqueName="TemplateColumnDelete" AllowFiltering="false" >
                                <ItemTemplate>
                                        <asp:ImageButton ID="eliminaHito" runat="server" CssClass="cursor" 
                                            ImageUrl="https://sesigue.com/REFERENCIASBASE/Resources/CancelG.png"
                                            ToolTip="Eliminar Avance" UseSubmitBehavior="False"
                                            OnClientClick="javascript: if(!confirm('¿Desea Eliminar el avance?')){return false;}"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="2%" Font-Bold="true" Font-Size="Small" BackColor="DarkBlue" ForeColor="White" />
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


        </div>
<%--            <input id="cantHitosHI" runat="server" type="hidden" value="0" />--%>


            <asp:SqlDataSource ID="SDS_SD_P_selectListHitos" runat="server"  
                SelectCommand="SD_P_selectListHitos" 
                SelectCommandType="StoredProcedure" >
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="hitdoId" Type="Int32" />

                    <asp:QueryStringParameter DefaultValue="0" Name="acuerdoID" QueryStringField="codigoid" Type="Int32" />
                    <asp:Parameter DefaultValue="0" Name="responsableID" Type="Int32" />
                    <asp:Parameter DefaultValue="999" Name="estado" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="SDS_SD_P_selectListAvance" runat="server"  
                SelectCommand="SD_P_selectListAvance" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="avanceId" Type="Int32" />
                    <asp:SessionParameter DefaultValue="-1" Name="hitdoId" SessionField="sessionHitoId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="" />
                    <telerik:AjaxUpdatedControl ControlID="RadGridImagen" LoadingPanelID="" />
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

<img src="https://sesigue.com/PROFAKTOWEB/SessionActiva.aspx" name="renewSession" id="renewSession" width="1px" height="1px"/>

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
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/fastclick/lib/fastclick.js"></script>
    <script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/new2019/vendors/nprogress/nprogress.js"></script>
    <script src="https://sesigue.com/REFERENCIASBASE/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://sesigue.com/REFERENCIASBASE/Scripts/noty/packaged/jquery.noty.packaged.min.js"></script>

</body>
</html>
