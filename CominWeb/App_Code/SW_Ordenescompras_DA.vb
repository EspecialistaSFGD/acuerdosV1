Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_Ordenescompras_DA
    Public Function P_selectOrdenesDeCompras(ByVal Desde As Date, ByVal Hasta As Date,
                                        ByVal OrdenCompraID As String, ByVal codigo As String,
                                        ByVal sucursalID As String, ByVal abierto As Integer, ByVal anulado As Integer,
                                        ByVal aprobado As Integer, ByVal cerrado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOrdenesDeCompras")
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@OrdenCompraID", DbType.String, OrdenCompraID)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@abierto", DbType.String, abierto)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@aprobado", DbType.String, aprobado)
        db.AddInParameter(cmd, "@cerrado", DbType.Int32, cerrado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectOrdenesCompraDetalle(ByVal OrdenCompraDetalleID As String, ByVal OrdenCompraID As String,
                                       ByVal usuarioID As Integer, ByVal valorTipoCambio As Decimal) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOrdenesCompraDetalle")
        db.AddInParameter(cmd, "@OrdenCompraDetalleID", DbType.String, OrdenCompraDetalleID)
        db.AddInParameter(cmd, "@OrdenCompraID", DbType.String, OrdenCompraID)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, usuarioID)
        db.AddInParameter(cmd, "@valorTipoCambio", DbType.Decimal, valorTipoCambio)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
