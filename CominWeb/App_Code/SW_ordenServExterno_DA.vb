Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_ordenServExterno_DA

    Public Function P_crearUpdateOrdenExterno(ByVal ordenServicioExternoID As String, ByVal codigo As String,
                                                                        ByVal fechaOrdenApertura As Date, ByVal ordenServicioID As String,
                                                    ByVal equipoID As String, ByVal proveedorID As String, contactoID As String,
                                                    tipoDocumentoID As Integer, tipoPagoID As Integer, requeridoID As String, notas As String,
                                                    monedaID As Integer, tipoCambio As Decimal, AlmacenID As Integer, referencia As String,
                                                    incluyeIGV As Integer, estado As Integer, sucursalID As Integer, UsuarioID As Integer,
                                                    fechaEntrega As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateOrdenExterno")
        db.AddInParameter(cmd, "@ordenServicioExternoID", DbType.String, ordenServicioExternoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@fechaOrdenApertura", DbType.Date, fechaOrdenApertura)
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@proveedorID", DbType.String, proveedorID)
        db.AddInParameter(cmd, "@contactoID", DbType.String, contactoID)
        db.AddInParameter(cmd, "@tipoDocumentoID", DbType.Int32, tipoDocumentoID)
        db.AddInParameter(cmd, "@tipoPagoID", DbType.Int32, tipoPagoID)
        db.AddInParameter(cmd, "@requeridoID", DbType.String, requeridoID)
        db.AddInParameter(cmd, "@notas", DbType.String, notas)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@tipoCambio", DbType.Decimal, tipoCambio)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, AlmacenID)
        db.AddInParameter(cmd, "@referencia", DbType.String, referencia)
        db.AddInParameter(cmd, "@incluyeIGV", DbType.Int32, incluyeIGV)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@fechaEntrega", DbType.String, fechaEntrega)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("ordenServicioExternoID")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectOSexterno(ByVal ordenServicioExternoID As String, codigo As String,
                                            proveedorID As String, equipoID As Integer,
                                            sucursalID As Integer, estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOSexterno")
        db.AddInParameter(cmd, "@ordenServicioExternoID", DbType.String, ordenServicioExternoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@proveedorID", DbType.String, proveedorID)
        db.AddInParameter(cmd, "@equipoID", DbType.Int32, equipoID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaOSdetalleByProID(ByVal ordenServicioID As String, productoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaOSdetalleByProID")
        db.AddInParameter(cmd, "@ordenServicioExternoID", DbType.String, ordenServicioID)
        db.AddInParameter(cmd, "@productoID", DbType.String, productoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectOSEDetalle(ByVal ordenServicioExternoID As String, ordenSeDetalleExtID As String,
                                            UsuarioID As String, RazonSocialID As Integer,
                                            tipoCambio As Integer, monedaID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOSEDetalle")
        db.AddInParameter(cmd, "@ordenServicioExternoID", DbType.String, ordenServicioExternoID)
        db.AddInParameter(cmd, "@ordenSeDetalleExtID", DbType.String, ordenSeDetalleExtID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        db.AddInParameter(cmd, "@RazonSocialID", DbType.String, RazonSocialID)
        db.AddInParameter(cmd, "@tipoCambio", DbType.String, tipoCambio)
        db.AddInParameter(cmd, "@monedaID", DbType.String, monedaID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaOSdetalleByTarID(ByVal usuarioID As Integer, ByVal ordenServicioExternoID As String, tiempoEstandarTrabajoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaOSdetalleByTarID")
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, usuarioID)
        db.AddInParameter(cmd, "@ordenServicioExternoID", DbType.String, ordenServicioExternoID)
        db.AddInParameter(cmd, "@tiempoEstandarTrabajoID", DbType.String, tiempoEstandarTrabajoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOSECabecera(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOSECabecera")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOSEDetalleTRA(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOSEDetalleTRA")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOSEDetallePRO(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOSEDetallePRO")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportOSETOTALES(ByVal ordenServicioID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportOSETOTALES")
        db.AddInParameter(cmd, "@ordenServicioID", DbType.String, ordenServicioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
