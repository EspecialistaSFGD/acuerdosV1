Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Namespace Valorizaciones.reportVal
    Public Class SW_valorizacion_DA

        Public Function P_reportValorizacionDetalle(ByVal valoriacionID As Integer) As DataTable
            Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
            Dim cmd As DbCommand = db.GetStoredProcCommand("P_reportValorizacionDetalle")
            db.AddInParameter(cmd, "@valoriacionID", DbType.Int32, valoriacionID)
            Dim ds As DataSet
            ds = db.ExecuteDataSet(cmd)
            Return ds.Tables(0)
        End Function


    End Class
End Namespace