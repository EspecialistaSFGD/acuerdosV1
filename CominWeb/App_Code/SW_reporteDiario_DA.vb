Imports System.Data
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_reporteDiario_DA

    Public Function P_selectReporteDiarioList(ByVal reporteDiarioID As Integer, codigo As String, tipoClienteId As Integer,
                                     cliente As String, equipo As String, prioridadID As Integer,
                                              lugarTrabajoID As Integer, tipoTrabajoID As Integer,
                                              desde As String, hasta As String, sucursalID As Integer, estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioList")
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoClienteId", DbType.Int32, tipoClienteId)
        db.AddInParameter(cmd, "@cliente", DbType.String, cliente)
        db.AddInParameter(cmd, "@equipo", DbType.String, equipo)
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@lugarTrabajoID", DbType.Int32, lugarTrabajoID)
        db.AddInParameter(cmd, "@tipoTrabajoID", DbType.Int32, tipoTrabajoID)
        db.AddInParameter(cmd, "@desde", DbType.String, desde)
        db.AddInParameter(cmd, "@hasta", DbType.String, hasta)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReporteDiarioExport(ByVal reporteDiarioID As Integer, codigo As String, tipoClienteId As Integer,
                                     cliente As String, equipo As String, prioridadID As Integer,
                                              lugarTrabajoID As Integer, tipoTrabajoID As Integer,
                                              desde As String, hasta As String, sucursalID As Integer, estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioExport")
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@tipoClienteId", DbType.Int32, tipoClienteId)
        db.AddInParameter(cmd, "@cliente", DbType.String, cliente)
        db.AddInParameter(cmd, "@equipo", DbType.String, equipo)
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@lugarTrabajoID", DbType.Int32, lugarTrabajoID)
        db.AddInParameter(cmd, "@tipoTrabajoID", DbType.Int32, tipoTrabajoID)
        db.AddInParameter(cmd, "@desde", DbType.String, desde)
        db.AddInParameter(cmd, "@hasta", DbType.String, hasta)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function P_selectReporteDiarioAdjuntoList(ByVal reporteDiarioAdjuntoID As Integer, reporteDiarioID As Integer, estado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioAdjuntoList")
        db.AddInParameter(cmd, "@reporteDiarioAdjuntoID", DbType.Int32, reporteDiarioAdjuntoID)
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReporteDiarioEvidenciaList(ByVal reporteDiarioEvidenciaID As Integer, reporteDiarioID As Integer, estado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioEvidenciaList")
        db.AddInParameter(cmd, "@reporteDiarioEvidenciaID", DbType.Int32, reporteDiarioEvidenciaID)
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReporteDiarioHorometroList(ByVal reporteDiarioHorometroID As Integer, reporteDiarioID As Integer, estado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioHorometroList")
        db.AddInParameter(cmd, "@reporteDiarioHorometroID", DbType.Int32, reporteDiarioHorometroID)
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReporteDiarioLubricanteList(ByVal reporteDiarioLubricantesID As Integer, reporteDiarioID As Integer, estado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioLubricanteList")
        db.AddInParameter(cmd, "@reporteDiarioLubricantesID", DbType.Int32, reporteDiarioLubricantesID)
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReporteDiarioRegFallaList(ByVal reporteDiarioRegistroFallaID As Integer, reporteDiarioID As Integer, estado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioRegFallaList")
        db.AddInParameter(cmd, "@reporteDiarioRegistroFallaID", DbType.Int32, reporteDiarioRegistroFallaID)
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function P_selectReporteDiarioTecnicosList(ByVal reporteDiarioTecnicosID As Integer, reporteDiarioID As Integer, iLider As Integer, estado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReporteDiarioTecnicosList")
        db.AddInParameter(cmd, "@reporteDiarioTecnicosID", DbType.Int32, reporteDiarioTecnicosID)
        db.AddInParameter(cmd, "@reporteDiarioID", DbType.Int32, reporteDiarioID)
        db.AddInParameter(cmd, "@iLider", DbType.Int32, iLider)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


End Class
