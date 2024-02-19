Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_EntregaProductoDetalle_DA
    Public Function P_selectEntregasProductoDetalle(ByVal entregaProductoID As Integer, ByVal EntregaProductoDetalleID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectEntregasProductoDetalle")
        db.AddInParameter(cmd, "@entregaProductoID", DbType.Int32, entregaProductoID)
        db.AddInParameter(cmd, "@EntregaProductoDetalleID", DbType.Int32, EntregaProductoDetalleID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateCabeceraEntregaProducto(ByVal entregaProductoID As String, ByVal fechaEntrega As Date, ByVal trabajadorID As String,
                                                    ByVal UsuarioID As String, ByVal sucursalID As Integer, ByVal Estado As Integer,
                                                    ByVal propietarioProveedorID As String, ByVal AlmacenID As Integer,
                                                    ByVal equipoID As String, ByVal centroCostoID As String, ByVal partidaID As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateCabeceraEntregaProducto")
        db.AddInParameter(cmd, "@entregaProductoID", DbType.String, entregaProductoID)
        db.AddInParameter(cmd, "@fechaEntrega", DbType.Date, fechaEntrega)
        db.AddInParameter(cmd, "@trabajadorID", DbType.String, trabajadorID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, Estado)
        db.AddInParameter(cmd, "@propietarioProveedorID", DbType.String, propietarioProveedorID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, AlmacenID)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@centroCostoID", DbType.String, centroCostoID)
        db.AddInParameter(cmd, "@partidaID", DbType.String, partidaID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("entregaProductoIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectReportEnProductoCabecera(ByVal entregaProductoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportEnProductoCabecera")
        db.AddInParameter(cmd, "@entregaProductoID", DbType.Int32, entregaProductoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportEntregaProductoDetalle(ByVal entregaProductoID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportEntregaProductoDetalle")
        db.AddInParameter(cmd, "@entregaProductoID", DbType.Int32, entregaProductoID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
