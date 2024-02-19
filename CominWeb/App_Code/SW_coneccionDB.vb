Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data

Public Class SW_coneccionDB
    Public Class variableGlobalConexion
        Public Shared nombreCadenaCnx As String = ""
    End Class

    Public Function NuevaConexion() As SqlConnection
        Dim cnx As New SqlConnection
        'cnx.ConnectionString = ConfigurationManager.ConnectionStrings("CONTRATA_DATOSConnectionString").ConnectionString
        cnx.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString
        Return cnx
    End Function

    Public Function ConexionText(ByVal SqlName As String) As SqlCommand
        Dim comando As New SqlCommand
        comando.CommandText = SqlName
        comando.CommandType = Data.CommandType.Text
        comando.Connection = NuevaConexion()
        Return comando
    End Function

    Public Function ConexionProcedure(ByVal SqlName As String) As SqlCommand
        Dim comando As New SqlCommand
        comando.CommandText = SqlName
        comando.CommandType = Data.CommandType.StoredProcedure
        comando.Connection = NuevaConexion()
        Return comando
    End Function
End Class
