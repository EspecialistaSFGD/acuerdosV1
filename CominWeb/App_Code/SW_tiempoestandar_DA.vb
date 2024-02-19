Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_tiempoestandar_DA
    Public Function P_selectTiempoEstandarTrabajo(ByVal tiempoEstandarTrabajoID As Integer, ByVal codigo As String,
                                                  ByVal nombre As String, ByVal tipoSistemaID As Integer,
                                                  ByVal tipoEquipoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTiempoEstandarTrabajo")
        db.AddInParameter(cmd, "@tiempoEstandarTrabajoID", DbType.Int32, tiempoEstandarTrabajoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@tipoSistemaID", DbType.Int32, tipoSistemaID)
        db.AddInParameter(cmd, "@tipoEquipoID", DbType.Int32, tipoEquipoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
