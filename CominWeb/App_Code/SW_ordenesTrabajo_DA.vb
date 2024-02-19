Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_ordenesTrabajo_DA
    Public Function P_selectOrdenesServicio(ByVal ordenServicioID As String, ByVal codigo As String,
                                   ByVal clienteID As String, ByVal EquipoID As String,
                                   ByVal sucursalID As Integer, ByVal estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOrdenesServicio")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@EquipoID", DbType.String, EquipoID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectOrdenesDetalle(ByVal ordenServicioID As String, ByVal ordenServicioDetalleID As String,
                                   ByVal UsuarioID As String, RazonSocialID As String, tipoCambio As Decimal) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOrdenesDetalle")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@ordenServicioDetalleID", DbType.String, ordenServicioDetalleID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        db.AddInParameter(cmd, "@RazonSocialID", DbType.String, RazonSocialID)
        db.AddInParameter(cmd, "@tipoCambio", DbType.Decimal, tipoCambio)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectCotizacionServicio(ByVal ordenServicioID As String, ByVal codigo As String,
                                   ByVal clienteID As String, ByVal EquipoID As String,
                                   ByVal sucursalID As Integer, ByVal estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectCotizacionServicio")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@EquipoID", DbType.String, EquipoID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectCotizacionDetalle(ByVal ordenServicioID As String, ByVal ordenServicioDetalleID As String,
                                   ByVal UsuarioID As String, RazonSocialID As String, tipoCambio As String, ByVal monedaID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectCotizacionDetalle")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@ordenServicioDetalleID", DbType.String, ordenServicioDetalleID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        db.AddInParameter(cmd, "@RazonSocialID", DbType.String, RazonSocialID)
        db.AddInParameter(cmd, "@tipoCambio", DbType.String, tipoCambio)
        db.AddInParameter(cmd, "@monedaID", DbType.String, monedaID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizacionCabecera(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizacionCabecera")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizacionDetalleTRA(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizacionDetalleTRA")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizacionDetalleTRAresu(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizacionDetalleTRAresu")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizacionDetallePRO(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizacionDetallePRO")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizaDetalleREC_PRO(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizaDetalleREC_PRO")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizacionDetalleREC(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizacionDetalleREC")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizacionDetalleRECresu(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizacionDetalleRECresu")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCotizacionTOTALES(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCotizacionTOTALES")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOTCabecera(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOTCabecera")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOTDetalleTRA(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOTDetalleTRA")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOTDetallePRO(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOTDetallePRO")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOTDetalleRecPRO(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOTDetalleRecPRO")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function P_selectReportOTDetalleREC(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOTDetalleREC")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaOTdetalleByTetID(ByVal UsuarioID As Integer, ByVal ordenServicioID As String, tiempoEstandarTrabajoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaOTdetalleByTetID")
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@tiempoEstandarTrabajoID", DbType.String, tiempoEstandarTrabajoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaOTdetalleByProID(ByVal ordenServicioID As String, productoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaOTdetalleByProID")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@productoID", DbType.String, productoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaCOTdetalleByTetID(ByVal UsuarioID As Integer, ByVal ordenServicioID As String, tiempoEstandarTrabajoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaCOTdetalleByTetID")
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@tiempoEstandarTrabajoID", DbType.String, tiempoEstandarTrabajoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaCOTdetalleByProID(ByVal ordenServicioID As String, productoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaCOTdetalleByProID")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@productoID", DbType.String, productoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateCabeceraOrden(ByVal ordenServicioID As String, ByVal codigo As String, ByVal equipoID As String, ByVal clienteID As String,
                                                    ByVal unidadMedidaID As String, ByVal horoKmInicial As Decimal, horoKmFinal As Decimal,
                                                    turnoID As String, trabajadorIDoperador As String, trabajadorIDsupervisor As String, estado As Integer,
                                                    notas As String, tipoTrabajoID As Integer, tipoServicioDetalle As String, horaServicio As Date,
                                                    usuarioCierre As Integer, fechaCierre As Date, fechaApertura As Date, usuarioApertura As Integer,
                                                    nroOrdenInterno As String, UsuarioID As Integer, sucursalID As Integer, AlmacenID As Integer,
                                                    lugarTrabajoID As String, incluyeIGV As Integer) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateCabeceraOrden")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@unidadMedidaID", DbType.String, unidadMedidaID)
        db.AddInParameter(cmd, "@horoKmInicial", DbType.Decimal, horoKmInicial)
        db.AddInParameter(cmd, "@horoKmFinal", DbType.Decimal, horoKmFinal)
        db.AddInParameter(cmd, "@turnoID", DbType.String, turnoID)
        db.AddInParameter(cmd, "@trabajadorIDoperador", DbType.String, trabajadorIDoperador)
        db.AddInParameter(cmd, "@trabajadorIDsupervisor", DbType.String, trabajadorIDsupervisor)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@notas", DbType.String, notas)
        db.AddInParameter(cmd, "@tipoTrabajoID", DbType.Int32, tipoTrabajoID)
        db.AddInParameter(cmd, "@tipoServicioDetalle", DbType.String, tipoServicioDetalle)
        db.AddInParameter(cmd, "@horaServicio", DbType.Date, horaServicio)
        db.AddInParameter(cmd, "@usuarioCierre", DbType.Int32, usuarioCierre)
        db.AddInParameter(cmd, "@fechaCierre", DbType.Date, fechaCierre)
        db.AddInParameter(cmd, "@fechaApertura", DbType.Date, fechaApertura)
        db.AddInParameter(cmd, "@usuarioApertura", DbType.Int32, usuarioApertura)
        db.AddInParameter(cmd, "@nroOrdenInterno", DbType.String, nroOrdenInterno)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, AlmacenID)
        db.AddInParameter(cmd, "@lugarTrabajoID", DbType.String, lugarTrabajoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.Int32, incluyeIGV)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("codigoUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_crearUpdateCabeceraOrdenVM(ByVal ordenServicioID As String, ByVal codigo As String, ByVal equipoID As String, ByVal clienteID As String,
                                                    ByVal unidadMedidaID As String, ByVal horoKmInicial As Decimal, horoKmFinal As Decimal,
                                                    turnoID As String, trabajadorIDoperador As String, trabajadorIDsupervisor As String, estado As Integer,
                                                    notas As String, tipoTrabajoID As Integer, tipoServicioDetalle As String, horaServicio As Date,
                                                    usuarioCierre As Integer, fechaCierre As Date, fechaApertura As Date, usuarioApertura As Integer,
                                                    nroOrdenInterno As String, UsuarioID As Integer, sucursalID As Integer, AlmacenID As Integer,
                                                    lugarTrabajoID As String, incluyeIGV As Integer, fechaEntrega As Date, horaEntrega As Date, planManttoID As Integer) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateCabeceraOrdenVM")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@unidadMedidaID", DbType.String, unidadMedidaID)
        db.AddInParameter(cmd, "@horoKmInicial", DbType.Decimal, horoKmInicial)
        db.AddInParameter(cmd, "@horoKmFinal", DbType.Decimal, horoKmFinal)
        db.AddInParameter(cmd, "@turnoID", DbType.String, turnoID)
        db.AddInParameter(cmd, "@trabajadorIDoperador", DbType.String, trabajadorIDoperador)
        db.AddInParameter(cmd, "@trabajadorIDsupervisor", DbType.String, trabajadorIDsupervisor)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@notas", DbType.String, notas)
        db.AddInParameter(cmd, "@tipoTrabajoID", DbType.Int32, tipoTrabajoID)
        db.AddInParameter(cmd, "@tipoServicioDetalle", DbType.String, tipoServicioDetalle)
        db.AddInParameter(cmd, "@horaServicio", DbType.Date, horaServicio)
        db.AddInParameter(cmd, "@usuarioCierre", DbType.Int32, usuarioCierre)
        db.AddInParameter(cmd, "@fechaCierre", DbType.Date, fechaCierre)
        db.AddInParameter(cmd, "@fechaApertura", DbType.Date, fechaApertura)
        db.AddInParameter(cmd, "@usuarioApertura", DbType.Int32, usuarioApertura)
        db.AddInParameter(cmd, "@nroOrdenInterno", DbType.String, nroOrdenInterno)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, AlmacenID)
        db.AddInParameter(cmd, "@lugarTrabajoID", DbType.String, lugarTrabajoID)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.Int32, incluyeIGV)
        db.AddInParameter(cmd, "@fechaEntrega", DbType.Date, fechaEntrega)
        db.AddInParameter(cmd, "@horaEntrega", DbType.Date, horaEntrega)
        db.AddInParameter(cmd, "@planManttoID", DbType.Int32, planManttoID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("codigoUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectOTmecanico(ByVal estado As Integer, OrdenServicioOperadoresID As Integer, ordenServicioID As String, usuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOTmecanico")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@OrdenServicioOperadoresID", DbType.Int32, OrdenServicioOperadoresID)
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, usuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
