Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_Bono_DA
    Public Function P_selectBono(ByVal bonoID As Integer, ByVal trabajadorID As Integer, ByVal estado As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectBono")
        db.AddInParameter(cmd, "@bonoID", DbType.Int32, bonoID)
        db.AddInParameter(cmd, "@trabajadorID", DbType.Int32, trabajadorID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
