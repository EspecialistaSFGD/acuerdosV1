Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_Graficos_DA
    Private conecc As New SW_coneccionDB

    Public Sub querySQL(ByVal cadena As String)
        Dim cmd As New SqlCommand
        cmd = conecc.ConexionText(cadena)
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
    End Sub

    Public Function P_selectGraficoFacturados(ByVal sucursalID As Integer, ByVal moneda As Integer, ByVal anio As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectGraficoFacturados")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@moneda", DbType.Int32, moneda)
        db.AddInParameter(cmd, "@anio", DbType.String, anio)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectGraficoCobrar(ByVal sucursalID As Integer, ByVal moneda As Integer, ByVal anio As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectGraficoCobrar")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@moneda", DbType.Int32, moneda)
        db.AddInParameter(cmd, "@anio", DbType.String, anio)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectGraficoPagar(ByVal sucursalID As Integer, ByVal moneda As Integer, ByVal anio As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectGraficoPagar")
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@moneda", DbType.Int32, moneda)
        db.AddInParameter(cmd, "@anio", DbType.String, anio)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_ReportEstadoOT(ByVal desde As String, ByVal hasta As String, ByVal tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_ReportEstadoOT")
        db.AddInParameter(cmd, "@desde", DbType.String, desde)
        db.AddInParameter(cmd, "@hasta", DbType.String, hasta)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
