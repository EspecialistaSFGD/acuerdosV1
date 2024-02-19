Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_equipoDetalle_DA

    Public Function P_selectEquipoImagen(ByVal EquipoID As Integer, EquipoImagenID As Integer, tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectEquipoImagen")
        db.AddInParameter(cmd, "@equipoID", DbType.Int32, EquipoID)
        db.AddInParameter(cmd, "@equipoImagenID", DbType.Int32, EquipoImagenID)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
