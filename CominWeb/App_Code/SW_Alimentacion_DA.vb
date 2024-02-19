Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
'Imports CominWeb.SW_coneccionDB
Imports CominWeb.SW_coneccionDB

Public Class SW_Alimentacion_DA
    Public Function P_selectAlimentacionDia(ByVal alimentoID As Integer, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAlimentacion")
        db.AddInParameter(cmd, "@alimentoID", DbType.Int32, alimentoID)
        db.AddInParameter(cmd, "@Desde", DbType.DateTime, desde)
        db.AddInParameter(cmd, "@Hasta", DbType.DateTime, hasta)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_SelectExtras() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_SelectExtras")
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function P_selectUltimoPrecioPorProveedor(ByVal propietarioProveedorID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectUltimoPrecioPorProveedor")
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.String, propietarioProveedorID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
