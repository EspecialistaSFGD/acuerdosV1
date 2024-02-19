Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_tipoDocumentos_DA

    Public Function P_selectDocumento(ByVal Tipo As Integer, tipoSelect As Integer, tipoDocumentoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectDocumento")
        db.AddInParameter(cmd, "@Tipo", DbType.Int32, Tipo)
        db.AddInParameter(cmd, "@tipoSelect", DbType.Int32, tipoSelect)
        db.AddInParameter(cmd, "@tipoDocumentoID", DbType.Int32, tipoDocumentoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
