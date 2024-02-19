Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_ventas_DA
    Public Function P_selectVentas(ByVal sucursalID As Integer, Desde As Date,
                                            Hasta As Date, ventaID As String,
                                            codigo As String, tipoDocumento As String,
                                            estadoPago As Integer, anulado As Integer,
                                            nroSerieDocumento As String, numeroDocumento As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectVentas")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectVentasGuia(ByVal sucursalID As Integer, Desde As Date,
                                            Hasta As Date, ventaID As String,
                                            codigo As String, tipoDocumento As String,
                                            estadoPago As Integer, anulado As Integer,
                                            nroSerieDocumento As String, numeroDocumento As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectVentasGuia")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateVentasOrden(ByVal ventaID As String, ByVal fechaFacturaVenta As Date, ByVal clienteID As String,
                                                    ByVal AlmacenID As String, ByVal fechaRegistro As Date, ByVal tipoDocumento As Integer,
                                                    ByVal nroSerieDocumento As String, ByVal numeroDocumento As String,
                                                    ByVal fechaVencimientoFactura As Date, ByVal nroOrdenVenta As String,
                                                    ByVal glosaVenta As String, ByVal estadoPago As String, ByVal estadoVenta As String,
                                                    ByVal monedaID As Integer, ByVal fecharecepcion As Date, ByVal UsuarioID As Integer,
                                                    ByVal afectaInventario As Boolean, ByVal sucursalID As Integer, ByVal tipocambio As Decimal,
                                                    ByVal OrdenVentaID As String, ByVal centroCostoID As String, ByVal guiaRemision As String,
                                                    ByVal tipoPagoID As String, ByVal incluyeIGV As String, cotizacion As String,
                                                    ByVal puntoPartida As String, ByVal puntoLlegada As String, ByVal motivoTranslado As String,
                                                    ByVal placaConductor As String, ByVal empresaTransporteID As String,
                                                    ByVal comprobanteEnvio As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateVentasOrden")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@fechaFacturaVenta", DbType.Date, fechaFacturaVenta)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, AlmacenID)
        db.AddInParameter(cmd, "@fechaRegistro", DbType.Date, fechaRegistro)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Int32, tipoDocumento)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@fechaVencimientoFactura", DbType.Date, fechaVencimientoFactura)
        db.AddInParameter(cmd, "@nroOrdenVenta", DbType.String, nroOrdenVenta)
        db.AddInParameter(cmd, "@glosaVenta", DbType.String, glosaVenta)
        db.AddInParameter(cmd, "@estadoPago", DbType.String, estadoPago)
        db.AddInParameter(cmd, "@estadoVenta", DbType.String, estadoVenta)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@fecharecepcion", DbType.Date, fecharecepcion)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@afectaInventario", DbType.Boolean, afectaInventario)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipocambio", DbType.Decimal, tipocambio)
        db.AddInParameter(cmd, "@OrdenVentaID", DbType.String, OrdenVentaID)
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@guiaRemision", DbType.String, guiaRemision)
        db.AddInParameter(cmd, "@tipoPagoID", DbType.String, tipoPagoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.String, incluyeIGV)
        db.AddInParameter(cmd, "@nroCotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@puntoPartida", DbType.String, puntoPartida)
        db.AddInParameter(cmd, "@puntoLlegada", DbType.String, puntoLlegada)
        db.AddInParameter(cmd, "@motivoTranslado", DbType.String, motivoTranslado)
        db.AddInParameter(cmd, "@placaConductor", DbType.String, placaConductor)
        db.AddInParameter(cmd, "@empresaTransporteID", DbType.String, empresaTransporteID)
        db.AddInParameter(cmd, "@comprobanteEnvio", DbType.String, comprobanteEnvio)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("ventaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_crearUpdateVentas(ByVal ventaID As String, ByVal fechaFacturaVenta As Date, ByVal clienteID As String,
                                                    ByVal AlmacenID As String, ByVal fechaRegistro As Date, ByVal tipoDocumento As Integer,
                                                    ByVal nroSerieDocumento As String, ByVal numeroDocumento As String,
                                                    ByVal fechaVencimientoFactura As Date, ByVal nroOrdenVenta As String,
                                                    ByVal glosaVenta As String, ByVal estadoPago As String, ByVal estadoVenta As String,
                                                    ByVal monedaID As Integer, ByVal fecharecepcion As Date, ByVal UsuarioID As Integer,
                                                    ByVal afectaInventario As Boolean, ByVal sucursalID As Integer, ByVal tipocambio As Decimal,
                                                    ByVal OrdenVentaID As String, ByVal centroCostoID As String, ByVal guiaRemision As String,
                                                    ByVal tipoPagoID As String, ByVal incluyeIGV As String, cotizacion As String,
                                                    ByVal puntoPartida As String, ByVal puntoLlegada As String, ByVal motivoTranslado As String,
                                                    ByVal placaConductor As String, ByVal empresaTransporteID As String,
                                                    ByVal comprobanteEnvio As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateVentas")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@fechaFacturaVenta", DbType.Date, fechaFacturaVenta)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, AlmacenID)
        db.AddInParameter(cmd, "@fechaRegistro", DbType.Date, fechaRegistro)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Int32, tipoDocumento)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@fechaVencimientoFactura", DbType.Date, fechaVencimientoFactura)
        db.AddInParameter(cmd, "@nroOrdenVenta", DbType.String, nroOrdenVenta)
        db.AddInParameter(cmd, "@glosaVenta", DbType.String, glosaVenta)
        db.AddInParameter(cmd, "@estadoPago", DbType.String, estadoPago)
        db.AddInParameter(cmd, "@estadoVenta", DbType.String, estadoVenta)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@fecharecepcion", DbType.Date, fecharecepcion)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@afectaInventario", DbType.Boolean, afectaInventario)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipocambio", DbType.Decimal, tipocambio)
        db.AddInParameter(cmd, "@OrdenVentaID", DbType.String, OrdenVentaID)
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@guiaRemision", DbType.String, guiaRemision)
        db.AddInParameter(cmd, "@tipoPagoID", DbType.String, tipoPagoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.String, incluyeIGV)
        db.AddInParameter(cmd, "@nroCotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@puntoPartida", DbType.String, puntoPartida)
        db.AddInParameter(cmd, "@puntoLlegada", DbType.String, puntoLlegada)
        db.AddInParameter(cmd, "@motivoTranslado", DbType.String, motivoTranslado)
        db.AddInParameter(cmd, "@placaConductor", DbType.String, placaConductor)
        db.AddInParameter(cmd, "@empresaTransporteID", DbType.String, empresaTransporteID)
        db.AddInParameter(cmd, "@comprobanteEnvio", DbType.String, comprobanteEnvio)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("ventaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_crearUpdateVentasSinDscto(ByVal ventaID As String, ByVal fechaFacturaVenta As Date, ByVal clienteID As String,
                                                    ByVal AlmacenID As String, ByVal fechaRegistro As Date, ByVal tipoDocumento As Integer,
                                                    ByVal nroSerieDocumento As String, ByVal numeroDocumento As String,
                                                    ByVal fechaVencimientoFactura As Date, ByVal nroOrdenVenta As String,
                                                    ByVal glosaVenta As String, ByVal estadoPago As String, ByVal estadoVenta As String,
                                                    ByVal monedaID As Integer, ByVal fecharecepcion As Date, ByVal UsuarioID As Integer,
                                                    ByVal afectaInventario As Boolean, ByVal sucursalID As Integer, ByVal tipocambio As Decimal,
                                                    ByVal OrdenVentaID As String, ByVal centroCostoID As String, ByVal guiaRemision As String,
                                                    ByVal tipoPagoID As String, ByVal incluyeIGV As String, cotizacion As String,
                                                    ByVal puntoPartida As String, ByVal puntoLlegada As String, ByVal motivoTranslado As String,
                                                    ByVal placaConductor As String, ByVal empresaTransporteID As String,
                                                    ByVal comprobanteEnvio As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateVentasSinDscto")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@fechaFacturaVenta", DbType.Date, fechaFacturaVenta)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, AlmacenID)
        db.AddInParameter(cmd, "@fechaRegistro", DbType.Date, fechaRegistro)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Int32, tipoDocumento)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@fechaVencimientoFactura", DbType.Date, fechaVencimientoFactura)
        db.AddInParameter(cmd, "@nroOrdenVenta", DbType.String, nroOrdenVenta)
        db.AddInParameter(cmd, "@glosaVenta", DbType.String, glosaVenta)
        db.AddInParameter(cmd, "@estadoPago", DbType.String, estadoPago)
        db.AddInParameter(cmd, "@estadoVenta", DbType.String, estadoVenta)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@fecharecepcion", DbType.Date, fecharecepcion)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@afectaInventario", DbType.Boolean, afectaInventario)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipocambio", DbType.Decimal, tipocambio)
        db.AddInParameter(cmd, "@OrdenVentaID", DbType.String, OrdenVentaID)
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@guiaRemision", DbType.String, guiaRemision)
        db.AddInParameter(cmd, "@tipoPagoID", DbType.String, tipoPagoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.String, incluyeIGV)
        db.AddInParameter(cmd, "@nroCotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@puntoPartida", DbType.String, puntoPartida)
        db.AddInParameter(cmd, "@puntoLlegada", DbType.String, puntoLlegada)
        db.AddInParameter(cmd, "@motivoTranslado", DbType.String, motivoTranslado)
        db.AddInParameter(cmd, "@placaConductor", DbType.String, placaConductor)
        db.AddInParameter(cmd, "@empresaTransporteID", DbType.String, empresaTransporteID)
        db.AddInParameter(cmd, "@comprobanteEnvio", DbType.String, comprobanteEnvio)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("ventaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectReportVentaCabecera(ByVal ventaID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportVentaCabecera")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportVentaDetalle(ByVal ventaID As String, ByVal valorTipoCambio As Decimal) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportVentaDetalle")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@valorTipoCambio", DbType.Decimal, valorTipoCambio)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateGuias(ByVal ventaID As String, ByVal fechaFacturaVenta As Date, ByVal clienteID As String,
                                                    ByVal AlmacenID As String, ByVal fechaRegistro As Date, ByVal tipoDocumento As Integer,
                                                    ByVal nroSerieDocumento As String, ByVal numeroDocumento As String,
                                                    ByVal fechaVencimientoFactura As Date, ByVal nroOrdenVenta As String,
                                                    ByVal glosaVenta As String, ByVal estadoPago As String, ByVal estadoVenta As String,
                                                    ByVal monedaID As Integer, ByVal fecharecepcion As Date, ByVal UsuarioID As Integer,
                                                    ByVal afectaInventario As Boolean, ByVal sucursalID As Integer, ByVal tipocambio As Decimal,
                                                    ByVal OrdenVentaID As String, ByVal centroCostoID As String, ByVal guiaRemision As String,
                                                    ByVal tipoPagoID As String, ByVal incluyeIGV As String, cotizacion As String,
                                                    ByVal puntoPartida As String, ByVal puntoLlegada As String, ByVal motivoTranslado As String,
                                                    ByVal placaConductor As String, ByVal empresaTransporteID As String,
                                                    ByVal comprobanteEnvio As String,
                                                    ByVal certificadoInscripcion As String, ByVal licenciaConducir As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateGuias")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@fechaFacturaVenta", DbType.Date, fechaFacturaVenta)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, AlmacenID)
        db.AddInParameter(cmd, "@fechaRegistro", DbType.Date, fechaRegistro)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Int32, tipoDocumento)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@fechaVencimientoFactura", DbType.Date, fechaVencimientoFactura)
        db.AddInParameter(cmd, "@nroOrdenVenta", DbType.String, nroOrdenVenta)
        db.AddInParameter(cmd, "@glosaVenta", DbType.String, glosaVenta)
        db.AddInParameter(cmd, "@estadoPago", DbType.String, estadoPago)
        db.AddInParameter(cmd, "@estadoVenta", DbType.String, estadoVenta)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@fecharecepcion", DbType.Date, fecharecepcion)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@afectaInventario", DbType.Boolean, afectaInventario)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipocambio", DbType.Decimal, tipocambio)
        db.AddInParameter(cmd, "@OrdenVentaID", DbType.String, OrdenVentaID)
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@guiaRemision", DbType.String, guiaRemision)
        db.AddInParameter(cmd, "@tipoPagoID", DbType.String, tipoPagoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.String, incluyeIGV)
        db.AddInParameter(cmd, "@nroCotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@puntoPartida", DbType.String, puntoPartida)
        db.AddInParameter(cmd, "@puntoLlegada", DbType.String, puntoLlegada)
        db.AddInParameter(cmd, "@motivoTranslado", DbType.String, motivoTranslado)
        db.AddInParameter(cmd, "@placaConductor", DbType.String, placaConductor)
        db.AddInParameter(cmd, "@empresaTransporteID", DbType.String, empresaTransporteID)
        db.AddInParameter(cmd, "@comprobanteEnvio", DbType.String, comprobanteEnvio)
        db.AddInParameter(cmd, "@certificadoInscripcion", DbType.String, certificadoInscripcion)
        db.AddInParameter(cmd, "@licenciaConducir", DbType.String, licenciaConducir)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("ventaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectVentasCorrelativoNum(ByVal sucursalID As Integer, ByVal tipoDocumento As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectVentasCorrelativoNum")
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Decimal, tipoDocumento)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectSalidaAlmacenCorrelativoNum(ByVal sucursalID As Integer, ByVal tipoDocumento As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectSalidaAlmacenCorrelativoNum")
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Decimal, tipoDocumento)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
    Public Function P_selectSalidasAlmacen(ByVal sucursalID As Integer, Desde As Date,
                                            Hasta As Date, ventaID As String,
                                            codigo As String, tipoDocumento As String,
                                            estadoPago As Integer, anulado As Integer,
                                            nroSerieDocumento As String, numeroDocumento As String,
                                            cerradoO As Integer, abiertoO As Integer, anuladoO As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectSalidasAlmacen")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@cerradoO", DbType.String, cerradoO)
        db.AddInParameter(cmd, "@abiertoO", DbType.String, abiertoO)
        db.AddInParameter(cmd, "@anuladoO", DbType.String, anuladoO)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateSalidasAlmacen(ByVal ventaID As String, ByVal fechaFacturaVenta As Date, ByVal clienteID As String,
                                                    ByVal AlmacenID As String, ByVal fechaRegistro As Date, ByVal tipoDocumento As Integer,
                                                    ByVal nroSerieDocumento As String, ByVal numeroDocumento As String,
                                                    ByVal fechaVencimientoFactura As Date, ByVal nroOrdenVenta As String,
                                                    ByVal glosaVenta As String, ByVal estadoPago As String, ByVal estadoVenta As String,
                                                    ByVal monedaID As Integer, ByVal fecharecepcion As Date, ByVal UsuarioID As Integer,
                                                    ByVal afectaInventario As Boolean, ByVal sucursalID As Integer, ByVal tipocambio As Decimal,
                                                    ByVal OrdenVentaID As String, ByVal centroCostoID As String, ByVal guiaRemision As String,
                                                    ByVal tipoPagoID As String, ByVal incluyeIGV As String, cotizacion As String,
                                                    ByVal puntoPartida As String, ByVal puntoLlegada As String, ByVal motivoTranslado As String,
                                                    ByVal placaConductor As String, ByVal empresaTransporteID As String,
                                                    ByVal comprobanteEnvio As String, ByVal codigoOT As String,
                                                    ByVal equipoID As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateSalidasAlmacen")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@fechaFacturaVenta", DbType.Date, fechaFacturaVenta)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, AlmacenID)
        db.AddInParameter(cmd, "@fechaRegistro", DbType.Date, fechaRegistro)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Int32, tipoDocumento)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@fechaVencimientoFactura", DbType.Date, fechaVencimientoFactura)
        db.AddInParameter(cmd, "@nroOrdenVenta", DbType.String, nroOrdenVenta)
        db.AddInParameter(cmd, "@glosaVenta", DbType.String, glosaVenta)
        db.AddInParameter(cmd, "@estadoPago", DbType.String, estadoPago)
        db.AddInParameter(cmd, "@estadoVenta", DbType.String, estadoVenta)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@fecharecepcion", DbType.Date, fecharecepcion)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@afectaInventario", DbType.Boolean, afectaInventario)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipocambio", DbType.Decimal, tipocambio)
        db.AddInParameter(cmd, "@OrdenVentaID", DbType.String, OrdenVentaID)
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@guiaRemision", DbType.String, guiaRemision)
        db.AddInParameter(cmd, "@tipoPagoID", DbType.String, tipoPagoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.String, incluyeIGV)
        db.AddInParameter(cmd, "@nroCotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@puntoPartida", DbType.String, puntoPartida)
        db.AddInParameter(cmd, "@puntoLlegada", DbType.String, puntoLlegada)
        db.AddInParameter(cmd, "@motivoTranslado", DbType.String, motivoTranslado)
        db.AddInParameter(cmd, "@placaConductor", DbType.String, placaConductor)
        db.AddInParameter(cmd, "@empresaTransporteID", DbType.String, empresaTransporteID)
        db.AddInParameter(cmd, "@comprobanteEnvio", DbType.String, comprobanteEnvio)
        db.AddInParameter(cmd, "@codigoOT", DbType.String, codigoOT)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("ventaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_VentasPLE(ByVal sucursalID As Integer, Desde As Date, Hasta As Date) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_VentasPLE")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_pleVenta_1(ByVal sucursalID As Integer, Monedaid As Integer, Desde As Date, Hasta As Date) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_pleVenta_1")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Monedaid", DbType.Int32, Monedaid)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function P_selectSalidaDetalleReport(ByVal sucursalID As Integer, Desde As Date,
                                            Hasta As Date, ventaID As String,
                                            codigo As String, tipoDocumento As String,
                                            estadoPago As String, anulado As Integer,
                                            nroSerieDocumento As String, numeroDocumento As String,
                                            cerradoO As Integer, abiertoO As Integer, anuladoO As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectSalidaDetalleReport")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.String, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@cerradoO", DbType.String, cerradoO)
        db.AddInParameter(cmd, "@abiertoO", DbType.String, abiertoO)
        db.AddInParameter(cmd, "@anuladoO", DbType.String, anuladoO)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function



    Public Function P_NRcrearUpdateSalidasAlmacen(ByVal ventaID As String, ByVal fechaFacturaVenta As Date, ByVal clienteID As String,
                                                    ByVal AlmacenID As String, ByVal fechaRegistro As Date, ByVal tipoDocumento As Integer,
                                                    ByVal nroSerieDocumento As String, ByVal numeroDocumento As String,
                                                    ByVal fechaVencimientoFactura As Date, ByVal nroOrdenVenta As String,
                                                    ByVal glosaVenta As String, ByVal estadoPago As String, ByVal estadoVenta As String,
                                                    ByVal monedaID As Integer, ByVal fecharecepcion As Date, ByVal UsuarioID As Integer,
                                                    ByVal afectaInventario As Boolean, ByVal sucursalID As Integer, ByVal tipocambio As Decimal,
                                                    ByVal OrdenVentaID As String, ByVal centroCostoID As String, ByVal guiaRemision As String,
                                                    ByVal tipoPagoID As String, ByVal incluyeIGV As String, cotizacion As String,
                                                    ByVal puntoPartida As String, ByVal puntoLlegada As String, ByVal motivoTranslado As String,
                                                    ByVal placaConductor As String, ByVal empresaTransporteID As String,
                                                    ByVal comprobanteEnvio As String, ByVal codigoOT As String,
                                                    ByVal equipoID As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_NRcrearUpdateSalidasAlmacen")
        db.AddInParameter(cmd, "@ventaID", DbType.String, ventaID)
        db.AddInParameter(cmd, "@fechaFacturaVenta", DbType.Date, fechaFacturaVenta)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, AlmacenID)
        db.AddInParameter(cmd, "@fechaRegistro", DbType.Date, fechaRegistro)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.Int32, tipoDocumento)
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@fechaVencimientoFactura", DbType.Date, fechaVencimientoFactura)
        db.AddInParameter(cmd, "@nroOrdenVenta", DbType.String, nroOrdenVenta)
        db.AddInParameter(cmd, "@glosaVenta", DbType.String, glosaVenta)
        db.AddInParameter(cmd, "@estadoPago", DbType.String, estadoPago)
        db.AddInParameter(cmd, "@estadoVenta", DbType.String, estadoVenta)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@fecharecepcion", DbType.Date, fecharecepcion)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@afectaInventario", DbType.Boolean, afectaInventario)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipocambio", DbType.Decimal, tipocambio)
        db.AddInParameter(cmd, "@OrdenVentaID", DbType.String, OrdenVentaID)
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@guiaRemision", DbType.String, guiaRemision)
        db.AddInParameter(cmd, "@tipoPagoID", DbType.String, tipoPagoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.String, incluyeIGV)
        db.AddInParameter(cmd, "@nroCotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@puntoPartida", DbType.String, puntoPartida)
        db.AddInParameter(cmd, "@puntoLlegada", DbType.String, puntoLlegada)
        db.AddInParameter(cmd, "@motivoTranslado", DbType.String, motivoTranslado)
        db.AddInParameter(cmd, "@placaConductor", DbType.String, placaConductor)
        db.AddInParameter(cmd, "@empresaTransporteID", DbType.String, empresaTransporteID)
        db.AddInParameter(cmd, "@comprobanteEnvio", DbType.String, comprobanteEnvio)
        db.AddInParameter(cmd, "@codigoOT", DbType.String, codigoOT)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("ventaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectVentasExport(ByVal sucursalID As Integer, Desde As Date,
                                        Hasta As Date, codigo As String, tipoDocumento As String,
                                        estadoPago As Integer, anulado As Integer,
                                        cotizacion As String, cliente As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectVentasExport")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@cotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@cliente", DbType.String, cliente)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectVentasDetalleExport(ByVal sucursalID As Integer, Desde As Date,
                                        Hasta As Date, codigo As String, tipoDocumento As String,
                                        estadoPago As Integer, anulado As Integer,
                                        cotizacion As String, cliente As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectVentasDetalleExport")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@cotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@cliente", DbType.String, cliente)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectVentasBeneficioeExport(ByVal sucursalID As Integer, Desde As Date,
                                    Hasta As Date, codigo As String, tipoDocumento As String,
                                    estadoPago As Integer, anulado As Integer,
                                    cotizacion As String, cliente As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectVentasBeneficioeExport")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@cotizacion", DbType.String, cotizacion)
        db.AddInParameter(cmd, "@cliente", DbType.String, cliente)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
