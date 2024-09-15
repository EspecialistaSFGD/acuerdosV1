Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Friend Class SW_SD_asistente_DA


    Public Function SD_P_selectAsistente(ByVal asistenteId As Integer,
                                  ByVal DNI As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAsistente")
        db.AddInParameter(cmd, "@asistenteId", DbType.Int32, asistenteId)
        db.AddInParameter(cmd, "@DNI", DbType.String, DNI)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
    Public Function SD_P_selectAcreaditadosList(ByVal asistenciaId As Integer, nombre As String,
                                   eventoId As String, entidadId As Integer, DNI As String, fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAcreaditadosList")
        db.AddInParameter(cmd, "@asistenciaId", DbType.Int32, asistenciaId)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@entidadId", DbType.Int32, entidadId)
        db.AddInParameter(cmd, "@DNI", DbType.String, DNI)
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function



    Public Function SD_P_selectAsistentes(ByVal estado As Integer, ByVal asistenteId As Integer,
                                  ByVal DNI As String, ByVal nombre As String,
                                  ByVal eventoId As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAsistentes")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@asistenteId", DbType.Int32, asistenteId)
        db.AddInParameter(cmd, "@DNI", DbType.String, DNI)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectValidaAcreditado(ByVal DNI As String, ByVal eventoId As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectValidaAcreditado")
        db.AddInParameter(cmd, "@DNI", DbType.String, DNI)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectAsistentesListExport(Desde As Date, Hasta As Date, ByVal asistenciaId As Integer,
                                  ByVal DNI As String, ByVal nombre As String,
                                  ByVal eventoId As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAsistentesListExport")
        db.AddInParameter(cmd, "@Desde", DbType.String, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.String, Hasta)
        db.AddInParameter(cmd, "@asistenciaId", DbType.Int32, asistenciaId)
        db.AddInParameter(cmd, "@DNI", DbType.String, DNI)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectAcreditadosListExport(Desde As Date, Hasta As Date, ByVal asistenciaId As Integer,
                                  ByVal DNI As String, ByVal nombre As String,
                                  ByVal eventoId As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAcreditadosListExport")
        db.AddInParameter(cmd, "@Desde", DbType.String, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.String, Hasta)
        db.AddInParameter(cmd, "@asistenciaId", DbType.Int32, asistenciaId)
        db.AddInParameter(cmd, "@DNI", DbType.String, DNI)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectMancomunidades(idMancomunidad As Integer, codigo As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectMancomunidades")
        db.AddInParameter(cmd, "@idMancomunidad", DbType.Int32, idMancomunidad)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectDiaEventos(eventoId As Integer, fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectDiaEventos")
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
