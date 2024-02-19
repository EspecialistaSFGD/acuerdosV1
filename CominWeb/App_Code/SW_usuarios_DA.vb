Imports CominWeb.SW_coneccionDB
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common

Public Class SW_usuarios_DA

    Public Function P_validaUsuario(ByVal nombreUser As String, ByVal clave As String, ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_validaUsuario")
        db.AddInParameter(cmd, "@nombreUser", DbType.String, nombreUser)
        db.AddInParameter(cmd, "@clave", DbType.String, clave)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
