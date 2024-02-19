Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_Mascota_DA
    Public Function P_selectMascota(ByVal codigo As String, ByVal sucursalID As Integer,
                                   ByVal mascotaID As Integer, ByVal clienteID As Integer,
                                   ByVal estado As Integer, ByVal nroHistoriaClinita As String,
                                   ByVal nombre As String, ByVal marcaID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectMascota")
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@mascotaID", DbType.Int32, mascotaID)
        db.AddInParameter(cmd, "@clienteID", DbType.Int32, clienteID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@nroHistoriaClinita", DbType.String, nroHistoriaClinita)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
