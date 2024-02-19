Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_TransferenciaSucursal_DA

    Public Function P_selectTransferenciaSucursal(ByVal transferenciaTrabajadorID As String, ByVal Desde As Date,
                                        ByVal Hasta As Date) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTransferenciaSucursal")
        db.AddInParameter(cmd, "@transferenciaTrabajadorID", DbType.String, transferenciaTrabajadorID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectTransferenciaSucursalEQ(ByVal transferenciaTrabajadorID As String, ByVal Desde As Date,
                                            ByVal Hasta As Date) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTransferenciaSucursalEQ")
        db.AddInParameter(cmd, "@transferenciaTrabajadorID", DbType.String, transferenciaTrabajadorID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
