Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_usuario_DA

    Public Function P_selectUsuario(ByVal UsuarioID As Integer, ByVal estado As Integer,
                                    ByVal TrabajadorID As Integer, ByVal sucursalID As String,
                                    ByVal tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectUsuario")
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@TrabajadorID", DbType.Int32, TrabajadorID)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@tipo", DbType.String, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectUsuarioEDIT(ByVal UsuarioID As Integer, ByVal estado As Integer,
                                    ByVal TrabajadorID As Integer, ByVal sucursalID As String,
                                    ByVal tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectUsuarioEDIT")
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@TrabajadorID", DbType.Int32, TrabajadorID)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@tipo", DbType.String, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectUsuarioByOpcion(ByVal permisosID As Integer, ByVal opcionSeguridadID As Integer,
                                    ByVal UsuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectUsuarioByOpcion")
        db.AddInParameter(cmd, "@permisosID", DbType.Int32, permisosID)
        db.AddInParameter(cmd, "@opcionSeguridadID", DbType.Int32, opcionSeguridadID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectAccesosWeb(ByVal codigoOpcion As String, ByVal UsuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAccesosWeb")
        db.AddInParameter(cmd, "@codigoOpcion", DbType.String, codigoOpcion)
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectOpcionSeguridad() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectOpcionSeguridad")
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
