Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_planMantto_DA

    Public Function P_selectPlanMantto(ByVal planManttoID As Integer, codigo As String, familiaID As Integer, nomFamilia As String,
                                       nombre As String, estado As Integer, sucursal As Integer, tipoPlan As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectPlanMantto")
        db.AddInParameter(cmd, "@planManttoID", DbType.Int32, planManttoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@familiaID", DbType.Int32, familiaID)
        db.AddInParameter(cmd, "@nomFamilia", DbType.String, nomFamilia)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@sucursal", DbType.Int32, sucursal)
        db.AddInParameter(cmd, "@tipoPlan", DbType.Int32, tipoPlan)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectPlanManttoDet(ByVal planManttoDetalleID As Integer, ByVal planManttoID As Integer, UsuarioID As Integer, tipo As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectPlanManttoDet")
        db.AddInParameter(cmd, "@planManttoDetalleID", DbType.String, planManttoDetalleID)
        db.AddInParameter(cmd, "@planManttoID", DbType.Int32, planManttoID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@tipo", DbType.String, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaPMdetalleByTetID(ByVal UsuarioID As Integer, ByVal planManttoID As Integer, tiempoEstandarTrabajoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaPMdetalleByTetID")
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@planManttoID", DbType.Int32, planManttoID)
        db.AddInParameter(cmd, "@tiempoEstandarTrabajoID", DbType.String, tiempoEstandarTrabajoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_ValidaEquipoAsig(equipoID As String, ByVal estadoAprob As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_ValidaEquipoAsig")
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@estadoAprob", DbType.Int32, estadoAprob)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_ValidaEquipoCHL(equipoID As String, ByVal estadoAprob As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_ValidaEquipoCHL")
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@estadoAprob", DbType.Int32, estadoAprob)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_ValidaPlanMantto(ByVal familiaID As Integer, nombre As String, sucursal As Integer, cantPersonas As Integer, almacenID As String, tipoPlan As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_ValidaPlanMantto")
        db.AddInParameter(cmd, "@familiaID", DbType.Int32, familiaID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursal)
        db.AddInParameter(cmd, "@cantPersonas", DbType.Int32, cantPersonas)
        db.AddInParameter(cmd, "@almacenID", DbType.String, almacenID)
        db.AddInParameter(cmd, "@tipoPlan", DbType.Int32, tipoPlan)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
