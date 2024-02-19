Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_ConsumoCombustible_DA
    Public Function P_selectConsumoCombustible(ByVal consumoCombustibleID As Integer, ByVal Desde As String, ByVal Hasta As String, ByVal equipoID As Integer, ByVal lugarTrabajoID As Integer, ByVal proveedorID As Integer, ByVal tipoCombustibleID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectConsumoCombustible")
        db.AddInParameter(cmd, "@consumoCombustibleID", DbType.Int32, consumoCombustibleID)
        db.AddInParameter(cmd, "@Desde", DbType.DateTime, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.DateTime, Hasta)
        db.AddInParameter(cmd, "@equipoID", DbType.Int32, equipoID)
        db.AddInParameter(cmd, "@lugarTrabajoID", DbType.Int32, lugarTrabajoID)
        db.AddInParameter(cmd, "@proveedorID", DbType.Int32, proveedorID)
        db.AddInParameter(cmd, "@tipoCombustibleID", DbType.Int32, tipoCombustibleID)
        db.AddInParameter(cmd, "@descuentoStock", DbType.Int32, 999999999)
        db.AddInParameter(cmd, "@procesado", DbType.Int32, 2)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
