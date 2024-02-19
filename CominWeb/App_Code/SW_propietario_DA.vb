Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_propietario_DA

    Public Function P_selectPropietario(ByVal estado As Integer, ByVal propietarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectPropietario")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.Int32, propietarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectProveedor(ByVal estado As Integer, ByVal propietarioID As Integer, ByVal ruc As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectProveedor")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.Int32, propietarioID)
        db.AddInParameter(cmd, "@ruc", DbType.String, ruc)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectCliente(ByVal estado As Integer, ByVal propietarioID As Integer, ByVal ruc As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectCliente")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.Int32, propietarioID)
        db.AddInParameter(cmd, "@ruc", DbType.String, ruc)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectSubContratista(ByVal estado As Integer, ByVal propietarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectSubContratista")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.Int32, propietarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectPagoHora(ByVal pagoHoraID As Integer, ByVal tipoClienteID As Integer,
                                     ByVal activo As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectPagoHora")
        db.AddInParameter(cmd, "@pagoHoraID", DbType.Int32, pagoHoraID)
        db.AddInParameter(cmd, "@tipoClienteID", DbType.Int32, tipoClienteID)
        db.AddInParameter(cmd, "@activo", DbType.String, activo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectContacto(ByVal estado As Integer, ByVal propietarioID As Integer, ByVal contactoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectContacto")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.Int32, propietarioID)
        db.AddInParameter(cmd, "@contactoID", DbType.String, contactoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
