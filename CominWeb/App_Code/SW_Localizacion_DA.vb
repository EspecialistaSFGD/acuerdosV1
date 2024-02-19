Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_Localizacion_DA

    Public Function P_selectLocalizacion(ByVal localizacionID As String, ByVal EquipoID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectLocalizacion")
        db.AddInParameter(cmd, "@localizacionID", DbType.String, localizacionID)
        db.AddInParameter(cmd, "@EquipoID", DbType.String, EquipoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


End Class
