Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Friend Class SW_pedido_DA

    Public Function SD_P_selectPrioridadAcuerdo(ByVal prioridadID As Integer, ByVal eventoId As Integer,
                                  ByVal grupoID As Integer, ByVal departamento As Integer,
                                  ByVal ubigeo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectPrioridadAcuerdo")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@departamento", DbType.Int32, departamento)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_crearUpdatePrioridadAcuerdo(ByVal prioridadID As Integer, ByVal eventoId As Integer, ByVal grupoID As Integer,
                                                    ByVal ubigeo As Integer, ByVal prioridadTerritorial As String, ByVal objetivoEstrategicoTerritorial As String,
                                                    ByVal intervencionesEstrategicas As String, ByVal aspectoCriticoResolver As String,
                                                    ByVal cuis As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_crearUpdatePrioridadAcuerdo")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        db.AddInParameter(cmd, "@prioridadTerritorial", DbType.String, prioridadTerritorial)
        db.AddInParameter(cmd, "@objetivoEstrategicoTerritorial", DbType.String, objetivoEstrategicoTerritorial)
        db.AddInParameter(cmd, "@intervencionesEstrategicas", DbType.String, intervencionesEstrategicas)
        db.AddInParameter(cmd, "@aspectoCriticoResolver", DbType.String, aspectoCriticoResolver)
        db.AddInParameter(cmd, "@cuis", DbType.String, cuis)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("prioridadIdUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function SD_P_selectAcuerdosV2(ByVal acuerdoID As Integer, ByVal prioridadID As Integer,
                                  ByVal acuerdo As String, ByVal clasificacionID As Integer,
                                  ByVal responsableID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAcuerdosV2")
        db.AddInParameter(cmd, "@acuerdoID", DbType.Int32, acuerdoID)
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@acuerdo", DbType.String, acuerdo)
        db.AddInParameter(cmd, "@clasificacionID", DbType.Int32, clasificacionID)
        db.AddInParameter(cmd, "@responsableID", DbType.Int32, responsableID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectListAcuerdoExport(ByVal prioridadID As Integer, ByVal eventoId As Integer,
                              ByVal grupoID As Integer, ByVal departamento As Integer,
                              ByVal ubigeo As Integer, codigo As String, clasificacion As Integer, responsable As Integer,
                                           acuerdoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectListAcuerdoExport")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@departamento", DbType.Int32, departamento)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@clasificacion", DbType.Int32, clasificacion)
        db.AddInParameter(cmd, "@responsable", DbType.Int32, responsable)
        db.AddInParameter(cmd, "@acuerdoID", DbType.Int32, acuerdoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectPrioridadAcuerdoExport(ByVal prioridadID As Integer, ByVal eventoId As Integer,
                                  ByVal grupoID As Integer, ByVal departamento As Integer,
                                  ByVal ubigeo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectPrioridadAcuerdoExport")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@departamento", DbType.Int32, departamento)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function SD_P_selectListHitos(ByVal hitdoId As Integer, acuerdoID As Integer, ByVal responsableID As Integer,
                                  ByVal estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectListHitos")
        db.AddInParameter(cmd, "@hitdoId", DbType.Int32, hitdoId)
        db.AddInParameter(cmd, "@acuerdoID", DbType.Int32, acuerdoID)
        db.AddInParameter(cmd, "@responsableID", DbType.Int32, responsableID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
