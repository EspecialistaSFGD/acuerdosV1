Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_TrabajosEquipo_DA
    Public Function P_selectTrabajosEquipos(ByVal trabajosEquipoID As Integer, ByVal desde As String,
                                            ByVal hasta As String, ByVal codigoproyecto As String,
                                            ByVal codigo As String, ByVal codigoequipo As String,
                                            ByVal sucursalID As Integer, unidadMedidaID As String, fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTrabajosEquipos")
        db.AddInParameter(cmd, "@trabajosEquipoID", DbType.Int32, trabajosEquipoID)
        db.AddInParameter(cmd, "@desde", DbType.DateTime, desde)
        db.AddInParameter(cmd, "@hasta", DbType.DateTime, hasta)
        db.AddInParameter(cmd, "@codigoproyecto", DbType.String, codigoproyecto)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@codigoequipo", DbType.String, codigoequipo)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@unidadMedidaID", DbType.String, unidadMedidaID)
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectTrabajosEquiposUno(ByVal trabajosEquipoID As Integer, ByVal desde As String,
                                            ByVal hasta As String, ByVal codigoproyecto As String,
                                            ByVal codigo As String, ByVal codigoequipo As String,
                                            ByVal sucursalID As Integer, unidadMedidaID As String, fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTrabajosEquiposUno")
        db.AddInParameter(cmd, "@trabajosEquipoID", DbType.Int32, trabajosEquipoID)
        db.AddInParameter(cmd, "@desde", DbType.DateTime, desde)
        db.AddInParameter(cmd, "@hasta", DbType.DateTime, hasta)
        db.AddInParameter(cmd, "@codigoproyecto", DbType.String, codigoproyecto)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@codigoequipo", DbType.String, codigoequipo)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@unidadMedidaID", DbType.String, unidadMedidaID)
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectTrabajosEquiposUnoValida(ByVal trabajosEquipoID As Integer, ByVal desde As String,
                                        ByVal hasta As String, ByVal codigoproyecto As String,
                                        ByVal codigo As String, ByVal codigoequipo As String,
                                        ByVal sucursalID As Integer, unidadMedidaID As String, fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTrabajosEquiposUnoValida")
        db.AddInParameter(cmd, "@trabajosEquipoID", DbType.Int32, trabajosEquipoID)
        db.AddInParameter(cmd, "@desde", DbType.DateTime, desde)
        db.AddInParameter(cmd, "@hasta", DbType.DateTime, hasta)
        db.AddInParameter(cmd, "@codigoproyecto", DbType.String, codigoproyecto)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@codigoequipo", DbType.String, codigoequipo)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@unidadMedidaID", DbType.String, unidadMedidaID)
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
