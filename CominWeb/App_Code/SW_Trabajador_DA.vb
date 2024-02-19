Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_Trabajador_DA
    Public Function P_selectTrabajador(ByVal estado As Integer, ByVal trabajadorID As Integer, ByVal sucursalID As String,
                                       ByRef tipoYcategoriaLicenciaID As Integer, ByVal cargoID As Integer,
                                       ByVal sexo As String, ByVal documento As String, ByVal nombre As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTrabajador")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@trabajadorID", DbType.Int32, trabajadorID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@tipoYcategoriaLicenciaID", DbType.Int32, tipoYcategoriaLicenciaID)
        db.AddInParameter(cmd, "@cargoID", DbType.Int32, cargoID)
        db.AddInParameter(cmd, "@sexo", DbType.String, sexo)
        db.AddInParameter(cmd, "@documento", DbType.String, documento)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectValidaTrabajador(ByVal nroDocumento As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectValidaTrabajador")
        db.AddInParameter(cmd, "@nroDocumento", DbType.String, nroDocumento)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
