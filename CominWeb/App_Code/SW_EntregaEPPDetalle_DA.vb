Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_EntregaEPPDetalle_DA
    Public Function P_selectEntregasEppDetalle(ByVal entregaEppID As Integer, ByVal EntregaEppDetalleID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectEntregasEppDetalle")
        db.AddInParameter(cmd, "@entregaEppID", DbType.Int32, entregaEppID)
        db.AddInParameter(cmd, "@EntregaEppDetalleID", DbType.Int32, EntregaEppDetalleID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateCabeceraEntregaEPP(ByVal entregaEppID As String, ByVal fechaEntrega As Date, ByVal trabajadorID As String,
                                                    ByVal UsuarioID As String, ByVal sucursalID As Integer, ByVal Estado As Integer,
                                                    ByVal AlmacenID As Integer, ByVal centroCostoID As String, ByVal partidaID As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateCabeceraEntregaEPP")
        db.AddInParameter(cmd, "@entregaEppID", DbType.String, entregaEppID)
        db.AddInParameter(cmd, "@fechaEntrega", DbType.Date, fechaEntrega)
        db.AddInParameter(cmd, "@trabajadorID", DbType.String, trabajadorID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, Estado)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, AlmacenID)
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
            valor = fila("entregaEppIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectReportEppCabecera(ByVal entregaEppID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportEppCabecera")
        db.AddInParameter(cmd, "@entregaEppID", DbType.Int32, entregaEppID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectReportEppDetalle(ByVal entregaEppID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectReportEppDetalle")
        db.AddInParameter(cmd, "@entregaEppID", DbType.Int32, entregaEppID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


End Class
