Public Class Site
    Inherits System.Web.UI.MasterPage
    Dim sw_tipocambio As New SW_TipoCambioByFecha_DA
    Dim sw_ejecutaSQL As New SW_EjecutaSQL_DA
    Dim sw_usuarioDA As New SW_usuario_DA
    Dim sw_modulosDT, sw_productoDT As New DataTable
    Dim verifiAccesosWeb, sw_tipocambio_DT, sw_EstandPreferenDT As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Page.IsPostBack = False Then
        '    Session("nombrePrincipalEmpresa") = ""
        'End If

        'INICIO SUPER ADMIN
        Dim mi_sucursales As New MenuItem("Surcusales", "", "", "~/superAdmin/sucursales/Form_sucursales.aspx")
        'FIN SUPER ADMIN
        ' ********************* CUENTAS ********************
        Me.Form_TrabajadoresLink.HRef = "~/trabajador/Form_Trabajadores.aspx"
        Me.Form_ProveedoresLink.HRef = "~/proveedores/Form_Proveedores.aspx"
        Me.Form_PropietariosLink.HRef = "~/mantenimientos/Form_Propietarios.aspx"
        Me.Form_ClientesLink.HRef = "~/mantenimientos/Form_Clientes.aspx"
        Me.Form_SubcontratistaLink.HRef = "~/mantenimientos/Form_Subcontratista.aspx"
        Me.Form_UsuariosLink.HRef = "~/usuarios/Form_Usuarios.aspx"
        Me.Form_tipoClienteLink.HRef = "~/administracion/tipoCliente/Form_tipoCliente.aspx"
        Me.Form_tipoProveedorLink.HRef = "~/administracion/tipoProveedor/Form_tipoProveedor.aspx"
        Me.Form_tipoPagoLink.HRef = "~/administracion/tipoPago/Form_tipoPago.aspx"
        ' ********************* PRODUCTOS ********************
        sw_EstandPreferenDT = sw_ejecutaSQL.P_selectParametroByID(43)
        Me.Form_ProductosLink.HRef = "~/productos/Form_Productos.aspx?tipoApp=" + sw_EstandPreferenDT.Rows(0).Item(2).ToString
        Me.Form_ProductosLinkCON.HRef = "~/ventas/Form_AgregarVentaRetail.aspx?tipoApp=" + sw_EstandPreferenDT.Rows(0).Item(2).ToString
        Me.Form_ProductosActivosLink.HRef = "~/productos/Form_ProductosActivos.aspx?tipoApp=" + sw_EstandPreferenDT.Rows(0).Item(2).ToString
        Me.Form_ubicacionProductoLink.HRef = "~/administracion/ubicacionProducto/Form_ubicacionProducto.aspx"
        Me.Form_grupoProductoLink.HRef = "~/administracion/grupoPro/Form_grupoProducto.aspx"
        Me.Form_subgrupoProductoLink.HRef = "~/administracion/subGrupoPro/Form_subgrupoProducto.aspx"
        Me.Form_grupoFuncionLink.HRef = "~/administracion/grupoFuncion/Form_grupoFuncion.aspx"
        Me.Form_unidadMedidaLink.HRef = "~/administracion/unidadMedida/Form_unidadMedida.aspx"
        Me.Form_ajusteStockLink.HRef = "~/productos/Form_ajusteStock.aspx"
        ' ********************* EQUIPOS ********************
        Me.Form_EquiposLink.HRef = "~/equipos/Form_Equipos.aspx"
        Me.Form_modeloEquipoLink.HRef = "~/administracion/modeloEquipo/Form_modeloEquipo.aspx"
        Me.Form_familiaELink.HRef = "~/administracion/familiaEquipo/Form_familiaE.aspx"
        Me.Form_tipoEquipoLink.HRef = "~/administracion/tipoEquipo/Form_tipoEquipo.aspx"
        Me.Form_tipoSistemaLink.HRef = "~/administracion/tipoSistema/Form_tipoSistema.aspx"
        ' ********************* INGRESOS ********************
        Me.Form_ListaComprasLink.HRef = "~/Compras/Form_ListaCompras.aspx?tipoApp=" + sw_EstandPreferenDT.Rows(0).Item(2).ToString + "&tipo=" + sw_EstandPreferenDT.Rows(0).Item(4).ToString
        Me.Form_OrdenesComprasLink.HRef = "~/ComprasOrdenes/Form_OrdenesCompras.aspx?tipo=" + sw_EstandPreferenDT.Rows(0).Item(4).ToString
        Me.Form_OrdenesCotEXLink.HRef = "~/OrdenServicioExt/Form_OrdenesCotEX.aspx"
        Me.Form_ListaTransferenciasLink.HRef = "~/transferencias/Form_ListaTransferencias.aspx"

        Me.Form_AlimentacionLink.HRef = "~/alimentacion/Form_Alimentacion.aspx"
        'Dim mi_combustiblesDscto As New MenuItem("Stocks", "", "", "~/Combustibles/Form_IngresoConsumo.aspx?Descuento=1")
        Me.Form_IngresoConsumoDLink.HRef = "~/Combustibles/Form_IngresoConsumo.aspx?Descuento=1"
        'Dim mi_combustiblesFactura As New MenuItem("Facturas", "", "", "~/Combustibles/Form_IngresoConsumo.aspx?Descuento=0")
        Me.Form_IngresoConsumoFLink.HRef = "~/Combustibles/Form_IngresoConsumo.aspx?Descuento=0"
        ' ********************* TRABAJOS ********************
        Me.Form_OrdenesLink.HRef = "~/ordenesdetrabajo/Form_Ordenes.aspx"
        Me.Form_OrdenesCotLink.HRef = "~/cotizacion/Form_OrdenesCot.aspx"
        Me.Form_ReporteDiarioLink.HRef = "~/reporteDiario/Form_reporteDiario.aspx"
        Me.Form_TrabajosEquipoLink.HRef = "~/trabajosequipo/Form_TrabajosEquipo.aspx"
        Form_planManttoLink.HRef = "~/planMantto/Form_planMantto.aspx?ASLKJAOhgIerLKsaSaSAS=78"
        Form_correctivosListLink.HRef = "Correctivos/Form_correctivosList.aspx"
        Form_regFallasListLink.HRef = "fallasEq/Form_regFallasList.aspx"
        Form_planificaEquipoLink.HRef = "planificacion/Form_planificaEquipo.aspx"
        Form_checkListLink.HRef = "CheckList/Form_checkList.aspx"
        Form_AsigCalendarioLink.HRef = "planificacion/Form_AsigCalendario.aspx"
        Form_ValoracionesLink.HRef = "~/Valorizaciones/Form_Valoraciones.aspx?ASLKJAOhgIerLDWERLSDNMSWEIRUPWEORIDKsaSaSAS=78"
        ' ********************* SALIDAS ********************
        If Session("verPrecioByUsuarioID") Is Nothing Then
            Me.Form_ListaVentasLink.HRef = "~/Ventas/Form_ListaVentas.aspx?kjasduwkjasnsd=kaDjFsRhFd5k6u7eUnSFn4m5p4o2iGsFGdSfDFSDFEdadf654sf8s12Sdf64f98e6dfaSASasdas51a6fe23sad2sddssd-sdsdasdda-asdSejhsbjdfhgsysmsadfaeffdsadf&tipo=" + sw_EstandPreferenDT.Rows(0).Item(4).ToString + "&css=2"
        Else
            Me.Form_ListaVentasLink.HRef = "~/Ventas/Form_ListaVentas.aspx?kjasduwkjasnsd=kaDjFsRhFd5k6u7eUnSFn4m5p4o2iGsFGdSfDFSDFEdadf654sf8s12Sdf64f98e6dfaSASasdas51a6fe23sad2sddssd-sdsdasdda-asdSejhsbjdfhgsysmsadfaeffdsadf&tipo=" + sw_EstandPreferenDT.Rows(0).Item(4).ToString + "&css=" + Session("verPrecioByUsuarioID").ToString
        End If
        Me.Form_ListaSalidaAlmacenLink.HRef = "~/salidasAlmacen/Form_ListaSalidaAlmacen.aspx"
        Me.Form_ListaGuiasLink.HRef = "~/Ventas/Form_ListaGuias.aspx"
        Me.Form_ListaVentasOLink.HRef = "~/ventaOrden/Form_ListaVentasO.aspx"
        ' ********************* ENTREGAS ********************
        Me.Form_EPPLink.HRef = "~/entregas/Form_EPP.aspx"
        Me.Form_EHerramientasLink.HRef = "~/entregas/Form_EHerramientas.aspx"
        Me.Form_EProductoLink.HRef = "~/entregas/entregaProducto/Form_EProducto.aspx"
        ' ********************* REPORTES ********************
        Me.Form_ProductoStockMinLink.HRef = "~/productos/Form_ProductoStockMin.aspx"
        Me.Form_ProductosFecCorteLink.HRef = "~/productos/Form_ProductosFecCorte.aspx"
        Me.Form_OrdenesCotAusentesLink.HRef = "~/cotizacion/Form_OrdenesCotAusentes.aspx"
        Me.Form_ProveedoresByProductosLink.HRef = "~/Compras/Form_ProveedoresByProductos.aspx"
        Me.Form_CotizaHoraEquipoLink.HRef = "~/reportes/Form_CotizaHoraEquipo.aspx"
        Me.Form_EppByProductoIntegradoLink.HRef = "~/entregas/Form_EppByProductoIntegrado.aspx"
        Me.Form_EppByTrabajadorIntegradoLink.HRef = "~/entregas/Form_EppByTrabajadorIntegrado.aspx"
        Me.Form_EppByProductoLink.HRef = "~/entregas/Form_EppByProducto.aspx"
        Me.Form_EppByTrabajadorLink.HRef = "~/entregas/Form_EppByTrabajador.aspx"
        ' ********************* MANTENIMIENTOS ********************
        Me.Form_tipoCambioLink.HRef = "~/administracion/tipoCambio/Form_tipoCambio.aspx"
        Me.Form_marcaELink.HRef = "~/administracion/marcaEquipos/Form_marcaE.aspx"
        Me.Form_cargoLink.HRef = "~/administracion/cargo/Form_cargo.aspx"
        Me.Form_tipoDocumentoLink.HRef = "~/administracion/tipoDocumento/Form_tipoDocumento.aspx"
        Me.Form_tipoServicioLink.HRef = "~/administracion/tipoServicio/Form_tipoServicio.aspx"
        Me.Form_areaLink.HRef = "~/administracion/areas/Form_area.aspx"
        Me.Form_tiempoestandartrabajoLink.HRef = "~/administracion/tiempoestandartrabajo/Form_tiempoestandartrabajo.aspx"
        Me.Form_centroCostoLink.HRef = "~/administracion/centroCosto/Form_centroCosto.aspx"
        Me.Form_PartidasLink.HRef = "~/administracion/partidas/Form_Partidas.aspx"
        Me.Form_motivoAjusteLink.HRef = "~/administracion/motivoAjuste/Form_motivoAjuste.aspx"
        Me.Form_cuentaCorrienteLink.HRef = "~/administracion/cuentaCorriente/Form_cuentaCorriente.aspx"
        Me.Form_bancoLink.HRef = "~/administracion/bancos/Form_banco.aspx"
        Me.Form_almacenesLink.HRef = "~/administracion/almacenes/Form_almacenes.aspx"
        Me.Form_lugarTrabajoLink.HRef = "~/administracion/lugarTrabajo/Form_lugarTrabajo.aspx"
        ' ********************* ADMINISTRACION ********************
        Me.Form_parametrosLink.HRef = "~/administracion/parametros/Form_parametros.aspx"
        Me.Form_sucursalLink.HRef = "~/administracion/sucursal/Form_sucursal.aspx"
        Me.Form_TransferenciaSucursalLink.HRef = "~/transferenciasSucursal/Form_TransferenciaSucursal.aspx"
        Me.Form_TransferenciaSucursalEqLink.HRef = "~/transferenciasSucursal/Form_TransferenciaSucursalEq.aspx"
        ' ********************* MANUCCI ********************
        ' ********************* PROCESOS ********************
        'Me.Form_planManttoLink.HRef = "~/planMantto/Form_planMantto.aspx?ASLKJAOhgIerLKsaSaSAS=78"






        'Dim mi_categoriaLicencia As New MenuItem("Tipo Categoria Licencia", "", "", "~/administracion/tipoCategoriaLicencia/Form_tipoCategoriaLicencia.aspx")
        Dim mi_ReportesProductosCompras As New MenuItem("Stocks", "", "", "~/productos/Form_ProductoCompra.aspx")
        Dim mi_controlSalida As New MenuItem("Registro", "", "", "~/controlSalida/Form_ControlSalida.aspx")
        Dim mi_seguimientoSalida As New MenuItem("Seguimiento", "", "", "~/controlSalida/Form_SeguimientoSalida.aspx")

        Me.fechaActualLB.Text = Date.Now.ToString("dd/MM/yyyy hh:mm tt")
        tituloLB.Text = Session("nombrePrincipalEmpresa") & " :: "
        tituloLB2.Text = Session("nombrePrincipalEmpresa") & " :: "
        If Session("usuarioLoginIDsuperAdmin") Is Nothing Then
            If Session("usuarioLoginID") Is Nothing Then
                Me.btn_desconectarme.Text = ""
                Me.tipoCambioCompra.Text = "0.00"
                Me.tipoCambioVenta.Text = "0.00"
            Else
                If Session("usuarioLoginID").ToString.Length > 0 Then
                    verifiAccesosWeb = sw_usuarioDA.P_selectAccesosWeb("ver", Session("usuarioLoginID"))
                    sw_tipocambio_DT = sw_tipocambio.P_selectTipoCambioByFecha(Date.Now)
                    If sw_tipocambio_DT.Rows.Count > 0 Then
                        Me.tipoCambioCompra.Text = sw_tipocambio_DT.Rows(0).Item(1).ToString
                        Me.tipoCambioVenta.Text = sw_tipocambio_DT.Rows(0).Item(2).ToString

                        Session("tipoCambioCompraSession") = sw_tipocambio_DT.Rows(0).Item(1).ToString
                        Session("tipoCambioVentaSession") = sw_tipocambio_DT.Rows(0).Item(2).ToString

                    Else
                        Me.tipoCambioCompra.Text = "0.00"
                        Me.tipoCambioVenta.Text = "0.00"
                        Session("tipoCambioCompraSession") = 0
                        Session("tipoCambioVentaSession") = 0
                    End If

                    Me.btn_desconectarme.Text = "Cerrar Sesion"
                    Me.tituloLB.Text = Session("nombrePrincipalEmpresa").ToString + " :: " + Session("nombreSucursalPrincipal").ToString.ToUpper
                    Me.nomUsuario.Text = Session("NombreUsuarioLogin").ToString
                    Me.nomUsuarioLeft.Text = Session("NombreUsuarioLogin").ToString

                    sw_modulosDT = sw_usuarioDA.P_selectOpcionSeguridad()
                    Session("EntregasModuloPermiso") = sw_modulosDT.Rows(0).Item(2).ToString
                    Session("EquiposModuloPermiso") = sw_modulosDT.Rows(1).Item(2).ToString
                    Session("CuentasModuloPermiso") = sw_modulosDT.Rows(2).Item(2).ToString
                    Session("TrabajosModuloPermiso") = sw_modulosDT.Rows(3).Item(2).ToString
                    Session("ProductosModuloPermiso") = sw_modulosDT.Rows(4).Item(2).ToString
                    Session("IngresosModuloPermiso") = sw_modulosDT.Rows(5).Item(2).ToString
                    Session("TablasMaestrasModuloPermiso") = sw_modulosDT.Rows(6).Item(2).ToString
                    Session("ReportesModuloPermiso") = sw_modulosDT.Rows(7).Item(2).ToString
                    Session("SalidasModuloPermiso") = sw_modulosDT.Rows(8).Item(2).ToString


                    If verifiAccesosWeb.Rows.Count > 10 Then
                        'INICIO DE MENU ----------------------
                        '----------------------------- CUENTAS

                        If Session("CuentasModuloPermiso").ToString = "R1GAMofSwz8=" Then

                            Me.cuentasMLink.Visible = True
                            If verifiAccesosWeb.Rows(6).Item(5).ToString = 1 Then
                                Form_TrabajadoresLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(7).Item(5).ToString = 1 Then
                                Me.Form_ProveedoresLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(8).Item(5).ToString = 1 Then
                                Me.Form_PropietariosLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(9).Item(5).ToString = 1 Then
                                Me.Form_ClientesLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(10).Item(5).ToString = 1 Then
                                Me.Form_SubcontratistaLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(11).Item(5).ToString = 1 Then
                                Me.Form_UsuariosLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(44).Item(5).ToString = 1 Then
                                Me.Form_tipoClienteLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(36).Item(5).ToString = 1 Then
                                Me.Form_tipoProveedorLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(37).Item(5).ToString = 1 Then
                                Me.Form_tipoPagoLink.Visible = True
                            End If
                        End If
                        '----------------------------- PRODUCTOS
                        If Session("ProductosModuloPermiso").ToString = "SywPtEIaNq/0RiSjfbGOOg==" Then
                            Me.productosMLink.Visible = True
                            If verifiAccesosWeb.Rows(14).Item(5).ToString = 1 Then
                                Me.Form_ProductosLink.Visible = True
                                Me.Form_ProductosLinkCON.Visible = True
                                Me.Form_ProductosActivosLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(18).Item(5).ToString = 1 Then
                                Me.Form_ubicacionProductoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(15).Item(5).ToString = 1 Then
                                Me.Form_grupoProductoLink.Visible = True
                                Me.Form_subgrupoProductoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(16).Item(5).ToString = 1 Then
                                Me.Form_grupoFuncionLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(17).Item(5).ToString = 1 Then
                                Me.Form_unidadMedidaLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(19).Item(5).ToString = 1 Then
                                Me.Form_ajusteStockLink.Visible = True
                            End If
                        End If
                        '----------------------------- EQUIPOS
                        If Session("EquiposModuloPermiso").ToString = "Uzp5YKqBojw=" Then
                            Me.equipoMLink.Visible = True
                            If verifiAccesosWeb.Rows(3).Item(5).ToString = 1 Then
                                Me.Form_EquiposLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(5).Item(5).ToString = 1 Then
                                Me.Form_modeloEquipoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(4).Item(5).ToString = 1 Then
                                Me.Form_tipoEquipoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(42).Item(5).ToString = 1 Then
                                Me.Form_tipoSistemaLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(49).Item(5).ToString = 1 Then
                                Me.Form_familiaELink.Visible = True
                            End If
                        End If
                        '----------------------------- INGRESOS
                        If Session("IngresosModuloPermiso").ToString = "ihyfS1/OYU4HbFSUfX3uog==" Then
                            Me.ingresosMLink.Visible = True
                            If verifiAccesosWeb.Rows(22).Item(5).ToString = 1 Then
                                Me.Form_ListaComprasLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(23).Item(5).ToString = 1 Then
                                Me.Form_OrdenesComprasLink.Visible = True
                                Me.Form_OrdenesCotEXLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(24).Item(5).ToString = 1 Then
                                Me.Form_ListaTransferenciasLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(20).Item(5).ToString = 1 Then
                                Me.Form_AlimentacionLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(21).Item(5).ToString = 1 Then
                                Me.Form_IngresoConsumoDLink.Visible = True
                                Me.Form_IngresoConsumoFLink.Visible = True
                            End If
                        End If
                        '----------------------------- TRABAJOS
                        If Session("TrabajosModuloPermiso").ToString = "HY6Uy/wRhNmno6+ouQPDYg==" Then
                            procesosMLink.Visible = True
                            Me.trabajosMLink.Visible = True
                            If verifiAccesosWeb.Rows(13).Item(5).ToString = 1 Then
                                Me.Form_OrdenesLink.Visible = True
                                Form_ReporteDiarioLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(47).Item(5).ToString = 1 Then
                                Me.Form_OrdenesCotLink.Visible = True

                            End If
                            If verifiAccesosWeb.Rows(12).Item(5).ToString = 1 Then
                                Me.Form_TrabajosEquipoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(50).Item(5).ToString = 1 Then
                                Form_planManttoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(51).Item(5).ToString = 1 Then
                                Form_correctivosListLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(52).Item(5).ToString = 1 Then
                                Form_regFallasListLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(53).Item(5).ToString = 1 Or verifiAccesosWeb.Rows(54).Item(5).ToString = 1 Then
                                asignaLink.Visible = True
                                Form_ValoracionesLink.Visible = True '------------ VALORIZACIONES
                            End If
                            If verifiAccesosWeb.Rows(53).Item(5).ToString = 1 Then
                                Form_planificaEquipoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(54).Item(5).ToString = 1 Then
                                Form_checkListLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(55).Item(5).ToString = 1 Then
                                Form_AsigCalendarioLink.Visible = True
                            End If
                            'Form_ValoracionesLink.Visible = True
                        End If
                        '----------------------------- SALIDAS
                        If Session("SalidasModuloPermiso").ToString = "t5Pgy1N9Zaw=" Then
                            Me.salidasMLink.Visible = True
                            If verifiAccesosWeb.Rows(41).Item(5).ToString = 1 Then
                                Me.Form_ListaVentasLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(46).Item(5).ToString = 1 Then
                                Me.Form_ListaVentasOLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(48).Item(5).ToString = 1 Then
                                Me.Form_ListaSalidaAlmacenLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(45).Item(5).ToString = 1 Then
                                Me.Form_ListaGuiasLink.Visible = True
                            End If

                            'If verifiAccesosWeb.Rows(39).Item(5).ToString = 1 Then
                            '    mi_salidasTM.ChildItems.Add(mi_controlSalida)
                            'End If
                            'If verifiAccesosWeb.Rows(40).Item(5).ToString = 1 Then
                            '    mi_salidasTM.ChildItems.Add(mi_seguimientoSalida)
                            'End If
                        End If
                        '----------------------------- REPORTES
                        If Session("ReportesModuloPermiso").ToString = "OtBgW2lrz114TQ46fuG06A==" Then
                            Me.reportesMLink.Visible = True
                            Me.Form_ProductoStockMinLink.Visible = True
                            'mi_ReportesProductos.ChildItems.Add(mi_ReportesProductosCompras)
                            Me.Form_ProductosFecCorteLink.Visible = True
                            Me.form_ordenescotausenteslink.Visible = True
                            Me.form_proveedoresbyproductoslink.Visible = True
                            Me.form_cotizahoraequipolink.Visible = True
                            If Session("EntregasModuloPermiso").ToString = "WavaoAxVE3qGENS0P/cBlA==" Then
                                Me.reportesasiglink.Visible = True
                                'mi_ReportesEpp.ChildItems.Add(mi_ReportesEppProductos)
                                'mi_ReportesEpp.ChildItems.Add(mi_ReportesEppTrabajadores)
                                'mi_ReportesEpp.ChildItems.Add(mi_ReportesEppProductosIntegrado)
                                'mi_ReportesEpp.ChildItems.Add(mi_ReportesEppTrabajadoresIntegrado)
                            End If
                        End If
                        '----------------------------- MANTENIMIENTOS

                        If Session("TablasMaestrasModuloPermiso").ToString = "OwLWqzmIte2SfHScqD41HQ==" Then
                            'mi_tablasMaestra.ChildItems.Add(mi_mantenimientoTM) '....MANTENIMIENTO
                            Me.mantenimientomlink.Visible = True
                            If verifiAccesosWeb.Rows(31).Item(5).ToString = 1 Then
                                Me.Form_tipoCambioLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(25).Item(5).ToString = 1 Then
                                Me.Form_marcaELink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(26).Item(5).ToString = 1 Then
                                Me.Form_cargoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(28).Item(5).ToString = 1 Then
                                Me.Form_tipoDocumentoLink.Visible = True
                                Me.Form_tipoServicioLink.Visible = True
                                Me.Form_areaLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(32).Item(5).ToString = 1 Then
                                Me.Form_tiempoestandartrabajoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(34).Item(5).ToString = 1 Then
                                Me.Form_centroCostoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(35).Item(5).ToString = 1 Then
                                Me.Form_PartidasLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(38).Item(5).ToString = 1 Then
                                Me.Form_motivoAjusteLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(43).Item(5).ToString = 1 Then
                                Me.Form_cuentaCorrienteLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(33).Item(5).ToString = 1 Then
                                Me.Form_bancoLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(30).Item(5).ToString = 1 Then
                                Me.Form_almacenesLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(27).Item(5).ToString = 1 Then
                                Me.Form_lugarTrabajoLink.Visible = True
                            End If
                            '--------------------------- LICENCIA PENDIENTE
                            'If verifiAccesosWeb.Rows(29).Item(5).ToString = 1 Then
                            '    mi_mantenimientoTM.ChildItems.Add(mi_categoriaLicencia)
                            'End If
                        End If
                        If Session("EntregasModuloPermiso").ToString = "WavaoAxVE3qGENS0P/cBlA==" Then
                            Me.asignacionMLink.Visible = True
                            If verifiAccesosWeb.Rows(0).Item(5).ToString = 1 Then
                                Me.Form_EPPLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(1).Item(5).ToString = 1 Then
                                Me.Form_EHerramientasLink.Visible = True
                            End If
                            If verifiAccesosWeb.Rows(2).Item(5).ToString = 1 Then
                                Me.Form_EProductoLink.Visible = True
                            End If
                        End If

                        If Session("EmpresaPrincipalWEB").ToString = "eninbmV3cmVzdA==" Then
                            'Me.newRestCab.Visible = True
                            Me.Form_ProductosLink.Visible = True
                            Me.Form_ListaComprasLink.Visible = True
                            Me.Form_OrdenesComprasLink.Visible = True
                            Me.Form_AsignacionPListLink.Visible = True
                            Me.Form_tipoCambioLink.Visible = True
                            Me.Form_ajusteStockLink.Visible = True
                            Me.Form_ProductosFecCorteLink.Visible = True
                        End If
                        'Form_planManttoLink.Visible = True
                    End If
                End If
            End If
        ElseIf Session("usuarioLoginIDsuperAdmin") = 1 Then
            Me.btn_desconectarme.Text = "Cerrar Sesion"
            Me.nomUsuario.Text = Session("NombreUsuarioLogin").ToString
            Me.nomUsuarioLeft.Text = Session("NombreUsuarioLogin").ToString
            Me.administradorMLink.Visible = True
            Me.Form_sucursalLink.Visible = True
            Me.Form_parametrosLink.Visible = True

            Me.Form_TransferenciaSucursalLink.Visible = True
            Me.Form_TransferenciaSucursalEqLink.Visible = True

            If sw_tipocambio_DT.Rows.Count > 0 Then
                Me.tipoCambioCompra.Text = sw_tipocambio_DT.Rows(0).Item(1).ToString
                Me.tipoCambioVenta.Text = sw_tipocambio_DT.Rows(0).Item(2).ToString
            Else
                Me.tipoCambioCompra.Text = "0.00"
                Me.tipoCambioVenta.Text = "0.00"
            End If

        End If

        If Not Session("usuarioLoginID") Is Nothing Then
            If Session("usuarioLoginID").ToString.Length > 0 Then
                If sw_tipocambio_DT.Rows.Count < 1 Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertatipocambio", "showMessage(myMessages[2]);", True)
                End If
            End If
        End If

    End Sub

    Private Sub mensajeJSS(ByVal cadena As String)
        Dim cadena_java As String
        cadena_java = "<script type='text/javascript'> " & _
                        " mensaje('information','" & cadena.ToString & "'); " & _
                        Chr(60) & "/script>"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "printMensaje", cadena_java.ToString, False)
    End Sub

    Protected Sub btn_desconectarme_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_desconectarme.Click
        Session("usuarioLoginID") = Nothing
        Session("NombreUsuarioLogin") = Nothing
        Session("IDSucursalPrincipal") = Nothing
        Session("nombreSucursalPrincipal") = Nothing
        Session("usuarioLoginIDsuperAdmin") = Nothing
        Session("almacenAsignadoPrincipal") = Nothing
        Session("esSuperAdminUser") = Nothing
        Session("tipoCambioCompraSession") = Nothing
        Session("tipoCambioVentaSession") = Nothing
        Response.Redirect("~/Bienvenida.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString)
        Me.tipoCambioCompra.Text = "0.00"
        Me.tipoCambioVenta.Text = "0.00"
    End Sub

    Protected Sub superAdminB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles superAdminB.Click
        Session("usuarioLoginID") = Nothing
        Session("NombreUsuarioLogin") = Nothing
        Session("IDSucursalPrincipal") = Nothing
        Session("nombreSucursalPrincipal") = Nothing
        Session("usuarioLoginIDsuperAdmin") = Nothing
        Session("almacenAsignadoPrincipal") = Nothing
        Session("esSuperAdminUser") = Nothing
        Session("tipoCambioCompraSession") = Nothing
        Session("tipoCambioVentaSession") = Nothing
        Response.Redirect("~/Account/Form_superAdmin.aspx")
    End Sub

    Protected Sub mecanicoB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mecanicoB.Click
        Session("usuarioLoginID") = Nothing
        Session("NombreUsuarioLogin") = Nothing
        Session("IDSucursalPrincipal") = Nothing
        Session("nombreSucursalPrincipal") = Nothing
        Session("usuarioLoginIDsuperAdmin") = Nothing
        Session("almacenAsignadoPrincipal") = Nothing
        Session("esSuperAdminUser") = Nothing
        Session("tipoCambioCompraSession") = Nothing
        Session("tipoCambioVentaSession") = Nothing
        Response.Redirect("~/Account/LoginOperador.aspx?gjXtIkEroS=" + Session("EmpresaPrincipalWEB").ToString)
    End Sub
End Class