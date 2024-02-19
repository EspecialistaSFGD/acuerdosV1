Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_centroCosto_DA
    Public Function P_selectCentroCosto(ByVal centroCostoID As String, sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectCentroCosto")
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
