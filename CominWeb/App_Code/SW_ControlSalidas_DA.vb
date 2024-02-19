Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_ControlSalidas_DA

    Public Function P_selectControlSalida(ByVal sucursalID As Integer, ByVal Desde As Date, ByVal Hasta As Date,
                                        ByVal ControlSalidaID As String, ByVal tipoDocumentoID As String,
                                        ByVal clienteID As String, ByVal almacenID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectControlSalida")
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@Desde", DbType.Date, Desde)
        db.AddInParameter(cmd, "@Hasta", DbType.Date, Hasta)
        db.AddInParameter(cmd, "@ControlSalidaID", DbType.String, ControlSalidaID)
        db.AddInParameter(cmd, "@tipoDocumentoID", DbType.String, tipoDocumentoID)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


End Class
