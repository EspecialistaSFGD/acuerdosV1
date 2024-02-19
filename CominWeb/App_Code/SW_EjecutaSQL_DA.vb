Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_EjecutaSQL_DA
    Private conecc As New SW_coneccionDB

    Public Sub querySQL(ByVal cadena As String)
        Dim cmd As New SqlCommand
        cmd = conecc.ConexionText(cadena)
        cmd.Connection.Open()
        cmd.CommandTimeout = 600000
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
    End Sub

    Public Function P_selectPoductoStockBySucursal(ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectPoductoStockBySucursal")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectParametroByID(ByVal parametroGeneralID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectParametroByID")
        db.AddInParameter(cmd, "@parametroGeneralID", DbType.Int32, parametroGeneralID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectParametros(ByVal parametroGeneralID As Integer, tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectParametros")
        db.AddInParameter(cmd, "@parametroGeneralID", DbType.Int32, parametroGeneralID)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_AccesoUsuarioByOpcionID(ByVal UsuarioID As Integer, ByVal opcionSeguridadID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_AccesoUsuarioByOpcionID")
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@opcionSeguridadID", DbType.Int32, opcionSeguridadID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectIGV(ByVal tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectIGV")
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectTipoCambioByFecha(ByVal fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTipoCambioByFecha")
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectStockByProductoID(ByVal almacenID As Integer,
                                              ByVal productoID As Integer,
                                              ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectStockByProductoID")
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_GeneradorCodigos(tipo As Integer, ByVal inicial As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_GeneradorCodigos")
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        db.AddInParameter(cmd, "@inicial", DbType.String, inicial)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectSucursal(ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectSucursal")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
