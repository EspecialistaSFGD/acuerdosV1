Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_compras_DA

    Public Function P_selectCompras(ByVal sucursalID As Integer, ByVal Desde As Date,
                                        ByVal Hasta As Date, ByVal compraID As String,
                                        ByVal codigo As String, ByVal tipoDocumento As String,
                                        ByVal estadoPago As Integer, ByVal anulado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectCompras")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@compraID", DbType.String, compraID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_pleCompra_1(ByVal sucursalID As Integer, ByVal Monedaid As Integer, ByVal Desde As Date) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_pleCompra_1")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Monedaid", DbType.Int32, Monedaid)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaCompra(ByVal nroSerieDocumento As String,
                                   ByVal numeroDocumento As String,
                                   ByVal propietarioProveedorID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaCompra")
        db.AddInParameter(cmd, "@nroSerieDocumento", DbType.String, nroSerieDocumento)
        db.AddInParameter(cmd, "@numeroDocumento", DbType.String, numeroDocumento)
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.String, propietarioProveedorID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportCompraDetalle(ByVal sucursalID As Integer, Desde As Date,
                                    Hasta As Date, codigo As String, tipoDocumento As String,
                                    estadoPago As Integer, anulado As Integer,
                                    proveedor As String, serieNro As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportCompraDetalle")


        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoDocumento", DbType.String, tipoDocumento)
        db.AddInParameter(cmd, "@estadoPago", DbType.Int32, estadoPago)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@proveedor", DbType.String, proveedor)
        db.AddInParameter(cmd, "@serieNro", DbType.String, serieNro)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
