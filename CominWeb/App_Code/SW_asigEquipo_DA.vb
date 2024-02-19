Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
'Imports CominWeb.SW_coneccionDB
Imports CominWeb.SW_coneccionDB

Public Class SW_asigEquipo_DA

    Public Function P_selectAsigPlan(ByVal asignacionEquipoID As Integer, equipoID As String, estadoAprob As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAsigPlan")
        db.AddInParameter(cmd, "@asignacionEquipoID", DbType.Int32, asignacionEquipoID)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@estadoAprob", DbType.Int32, estadoAprob)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectAsigPlanDet(ByVal asignacionEquipoDetalle As Integer, ByVal asignacionEquipoID As Integer, UsuarioID As Integer, equipoID As String, estadoAprob As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAsigPlanDet")
        db.AddInParameter(cmd, "@asignacionEquipoDetalle", DbType.String, asignacionEquipoDetalle)
        db.AddInParameter(cmd, "@asignacionEquipoID", DbType.Int32, asignacionEquipoID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@estadoAprob", DbType.Int32, estadoAprob)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_validaAEDetByTetID(ByVal UsuarioID As Integer, ByVal asignacionEquipoID As Integer, ByVal planManttoID As Integer, tiempoEstandarTrabajoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaAEDetByTetID")
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@asignacionEquipoID", DbType.Int32, asignacionEquipoID)
        db.AddInParameter(cmd, "@planManttoID", DbType.Int32, planManttoID)
        db.AddInParameter(cmd, "@tiempoEstandarTrabajoID", DbType.Int32, tiempoEstandarTrabajoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectAsigPlanCalendar(ByVal asignacionEquipoDetCalendarID As Integer, UsuarioID As Integer, equipoID As String, desde As String, hasta As String, prioridadID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAsigPlanCalendar")
        db.AddInParameter(cmd, "@asignacionEquipoDetCalendarID", DbType.Int32, asignacionEquipoDetCalendarID)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@Desde", DbType.String, desde)
        db.AddInParameter(cmd, "@Hasta", DbType.String, hasta)
        db.AddInParameter(cmd, "@prioridadID", DbType.String, prioridadID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectAsigCHL(ByVal checklistEquipoID As Integer, equipoID As String, estadoAprob As String, codigo As String, sucursalID As Integer, tipoCheck As Integer, sericod As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAsigCHL")
        db.AddInParameter(cmd, "@checklistEquipoID", DbType.Int32, checklistEquipoID)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@estadoAprob", DbType.String, estadoAprob)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipoCheck", DbType.Int32, tipoCheck)
        db.AddInParameter(cmd, "@sericod", DbType.String, sericod)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectAsigPlanCalendarOT(ByVal asignacionEquipoDetCalendarID As Integer, UsuarioID As Integer, equipoID As String, fecha As String, prioridadID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAsigPlanCalendarOT")
        db.AddInParameter(cmd, "@asignacionEquipoDetCalendarID", DbType.Int32, asignacionEquipoDetCalendarID)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        db.AddInParameter(cmd, "@prioridadID", DbType.String, prioridadID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
