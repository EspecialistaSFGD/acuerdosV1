Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_TrabajosEquipoDetalle_DA
    Public Function P_selectTrabajosEquiposDetalle(ByVal trabajosEquipoDetalleID As Integer, ByVal trabajosEquipoID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTrabajosEquiposDetalle")
        db.AddInParameter(cmd, "@trabajosEquipoDetalleID", DbType.Int32, trabajosEquipoDetalleID)
        db.AddInParameter(cmd, "@trabajosEquipoID", DbType.Int32, trabajosEquipoID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
