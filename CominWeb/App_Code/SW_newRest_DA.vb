Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_newRest_DA

    Public Function P_NRtipoOcupabilidad_NR(ByVal HOTEL As Integer, sector As Integer, fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_NRtipoOcupabilidad_NR")
        db.AddInParameter(cmd, "@HOTEL", DbType.Int32, HOTEL)
        db.AddInParameter(cmd, "@SECTOR", DbType.Int32, sector)
        db.AddInParameter(cmd, "@FECHA", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_NRselectCodCliente(ByVal NIF20 As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_NRselectCodCliente")
        db.AddInParameter(cmd, "@NIF20", DbType.String, NIF20)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_NRselectUltAsignacion(ByVal clienteID As Integer, nrodoc As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_NRselectUltAsignacion")
        db.AddInParameter(cmd, "@clienteID", DbType.Int32, clienteID)
        db.AddInParameter(cmd, "@nrodoc", DbType.String, nrodoc)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_NRselectUltAsignacionDet(ByVal clienteID As Integer, nrodoc As String, productoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_NRselectUltAsignacionDet")
        db.AddInParameter(cmd, "@clienteID", DbType.Int32, clienteID)
        db.AddInParameter(cmd, "@nrodoc", DbType.String, nrodoc)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_NRselectProductoTipoCliente(ByVal productoTipoClienteID As Integer, tipoHabitacion As String, productoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_NRselectProductoTipoCliente")
        db.AddInParameter(cmd, "@productoTipoClienteID", DbType.Int32, productoTipoClienteID)
        db.AddInParameter(cmd, "@tipoHabitacion", DbType.String, tipoHabitacion)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
