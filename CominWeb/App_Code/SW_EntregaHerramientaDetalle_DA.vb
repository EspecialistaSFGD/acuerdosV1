Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_EntregaHerramientaDetalle_DA
    Public Function P_selectEntregasHerramientaDetalle(ByVal entregaHerramientaID As Integer, ByVal EntregaHerramientaDetalleID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectEntregasHerramientaDetalle")
        db.AddInParameter(cmd, "@entregaHerramientaID", DbType.Int32, entregaHerramientaID)
        db.AddInParameter(cmd, "@EntregaHerramientaDetalleID", DbType.Int32, EntregaHerramientaDetalleID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateCabeceraEntregaHerramienta(ByVal entregaHerramientaID As String, ByVal fechaEntrega As Date, ByVal trabajadorID As String,
                                                    ByVal UsuarioID As String, ByVal sucursalID As Integer, ByVal Estado As Integer,
                                                    ByVal contenedorHerramientaID As String, ByVal AlmacenID As Integer,
                                                    ByVal centroCostoID As String, ByVal partidaID As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateCabeceraEntregaHerramienta")
        db.AddInParameter(cmd, "@entregaHerramientaID", DbType.String, entregaHerramientaID)
        db.AddInParameter(cmd, "@fechaEntrega", DbType.Date, fechaEntrega)
        db.AddInParameter(cmd, "@trabajadorID", DbType.String, trabajadorID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.String, UsuarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, Estado)
        db.AddInParameter(cmd, "@contenedorHerramientaID", DbType.String, contenedorHerramientaID)
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
            valor = fila("entregaHerramientaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class
