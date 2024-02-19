Imports System.Data
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_SSFD_DA

    Public Function P_selectPCB(ByVal pcbId As Integer, strCU As String, strSNIP As String,
                                     strProyecto As String, strProvincia As String, strDistrito As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("ssfd.P_selectPCB")
        db.AddInParameter(cmd, "@pcbId", DbType.Int32, pcbId)
        db.AddInParameter(cmd, "@strCU", DbType.String, strCU)
        db.AddInParameter(cmd, "@strSNIP", DbType.String, strSNIP)
        db.AddInParameter(cmd, "@strProyecto", DbType.String, strProyecto)
        db.AddInParameter(cmd, "@strProvincia", DbType.String, strProvincia)
        db.AddInParameter(cmd, "@strDistrito", DbType.String, strDistrito)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectGL(ByVal presidenteId As Integer, region As String, provincia As String,
                                     alcaldesas As Integer, fechaCorte As String, anio As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("ssfd.P_selectGL")
        db.AddInParameter(cmd, "@presidenteId", DbType.Int32, presidenteId)
        db.AddInParameter(cmd, "@region", DbType.String, region)
        db.AddInParameter(cmd, "@provincia", DbType.String, provincia)
        db.AddInParameter(cmd, "@alcaldesas", DbType.Int32, alcaldesas)
        db.AddInParameter(cmd, "@fechaCorte", DbType.String, fechaCorte)
        db.AddInParameter(cmd, "@anio", DbType.Int32, anio)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectGLMin(ByVal valor1 As Decimal, anio As Integer, alcaldesas As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("ssfd.P_selectGLMin")
        db.AddInParameter(cmd, "@valor1", DbType.Decimal, valor1)
        db.AddInParameter(cmd, "@anio", DbType.Int32, anio)
        db.AddInParameter(cmd, "@alcaldesas", DbType.Int32, alcaldesas)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectGLMedio(ByVal valor1 As Decimal, valor2 As Decimal, anio As Integer, alcaldesas As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("ssfd.P_selectGLMedio")
        db.AddInParameter(cmd, "@valor1", DbType.Decimal, valor1)
        db.AddInParameter(cmd, "@valor2", DbType.Decimal, valor2)
        db.AddInParameter(cmd, "@anio", DbType.Int32, anio)
        db.AddInParameter(cmd, "@alcaldesas", DbType.Int32, alcaldesas)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectGLMax(ByVal valor1 As Decimal, valor2 As Decimal, anio As Integer, alcaldesas As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("ssfd.P_selectGLMax")
        db.AddInParameter(cmd, "@valor1", DbType.Decimal, valor1)
        db.AddInParameter(cmd, "@valor2", DbType.Decimal, valor2)
        db.AddInParameter(cmd, "@anio", DbType.Int32, anio)
        db.AddInParameter(cmd, "@alcaldesas", DbType.Int32, alcaldesas)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectHito(ByVal hitosId As Integer, pcbId As Integer, tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("ssfd.P_selectHito")
        db.AddInParameter(cmd, "@hitosId", DbType.Int32, hitosId)
        db.AddInParameter(cmd, "@pcbId", DbType.Int32, pcbId)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectPCB126(ByVal pcbId As Integer, strCU As String, strSNIP As String,
                                 strProyecto As String, strProvincia As String, strDistrito As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("ssfd.P_selectPCB126")
        db.AddInParameter(cmd, "@pcbId", DbType.Int32, pcbId)
        db.AddInParameter(cmd, "@strCU", DbType.String, strCU)
        db.AddInParameter(cmd, "@strSNIP", DbType.String, strSNIP)
        db.AddInParameter(cmd, "@strProyecto", DbType.String, strProyecto)
        db.AddInParameter(cmd, "@strProvincia", DbType.String, strProvincia)
        db.AddInParameter(cmd, "@strDistrito", DbType.String, strDistrito)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
