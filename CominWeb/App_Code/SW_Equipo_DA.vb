Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB
Public Class SW_Equipo_DA
    Public Function P_selectEquipo(ByVal estado As Integer, ByVal EquipoID As Integer,
                                   ByVal codigo As Integer, ByVal marcaID As Integer,
                                   ByVal tipoEquipoID As Integer, ByVal modeloID As Integer,
                                   ByVal propietarioID As Integer, ByVal sucursalID As Integer,
                                   ByVal serie As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectEquipo")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@EquipoID", DbType.Int32, EquipoID)
        db.AddInParameter(cmd, "@codigo", DbType.Int32, codigo)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        db.AddInParameter(cmd, "@tipoEquipoID", DbType.Int32, tipoEquipoID)
        db.AddInParameter(cmd, "@modeloID", DbType.Int32, modeloID)
        db.AddInParameter(cmd, "@propietarioID", DbType.Int32, propietarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@serie", DbType.String, serie)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectEquipoExport(ByVal estado As Integer, ByVal EquipoID As Integer,
                                   ByVal codigo As String, ByVal marcaID As Integer,
                                   ByVal tipoEquipoID As Integer, ByVal modeloID As Integer,
                                   ByVal propietarioID As Integer, ByVal sucursalID As Integer,
                                   ByVal serie As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectEquipoExport")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@EquipoID", DbType.Int32, EquipoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        db.AddInParameter(cmd, "@tipoEquipoID", DbType.Int32, tipoEquipoID)
        db.AddInParameter(cmd, "@modeloID", DbType.Int32, modeloID)
        db.AddInParameter(cmd, "@propietarioID", DbType.Int32, propietarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@serie", DbType.String, serie)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectValidaEquipo(ByVal nroSerie As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectValidaEquipo")
        db.AddInParameter(cmd, "@nroSerie", DbType.String, nroSerie)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectTipoEquipo(ByVal tipoEquipoID As Integer, marcaID As Integer, familiaID As Integer, nombre As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTipoEquipo")
        db.AddInParameter(cmd, "@tipoEquipoID", DbType.String, tipoEquipoID)
        db.AddInParameter(cmd, "@marcaID", DbType.String, marcaID)
        db.AddInParameter(cmd, "@familiaID", DbType.String, familiaID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectHoraProEq(ByVal equipoID As Integer, tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectHoraProEq")
        db.AddInParameter(cmd, "@equipoID", DbType.Int32, equipoID)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectEquipoCodigo(ByVal EquipoID As Integer, codigo As String, sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectEquipoCodigo")
        db.AddInParameter(cmd, "@EquipoID", DbType.Int32, EquipoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_InUpRegistroFalla(ByVal registroFallaID As Integer, registroFalla As Date, tipoFalla As Integer, ByVal equipoID As String, horometro As Decimal,
                                        supervisorID As Integer, clienteID As Integer, operadorID As Integer, componente As String, tipoSistemaID As String,
                                        causas As String, evaluacion As String, solucion As String, comentarios As String, requiereParar As Integer,
                                        fechaEstimada As Date, horaEstimada As Date, UsuarioID As Integer, estado As Integer, sucursalID As Integer) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_InUpRegistroFalla")
        db.AddInParameter(cmd, "@registroFallaID", DbType.Int32, registroFallaID)
        db.AddInParameter(cmd, "@registroFalla", DbType.Date, registroFalla)
        db.AddInParameter(cmd, "@tipoFalla", DbType.Int32, tipoFalla)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@horometro", DbType.Decimal, horometro)
        db.AddInParameter(cmd, "@supervisorID", DbType.Int32, supervisorID)
        db.AddInParameter(cmd, "@clienteID", DbType.Int32, clienteID)
        db.AddInParameter(cmd, "@operadorID ", DbType.Int32, operadorID)
        db.AddInParameter(cmd, "@componente", DbType.String, componente)
        db.AddInParameter(cmd, "@tipoSistemaID", DbType.String, tipoSistemaID)
        db.AddInParameter(cmd, "@causas", DbType.String, causas)
        db.AddInParameter(cmd, "@evaluacion", DbType.String, evaluacion)
        db.AddInParameter(cmd, "@solucion", DbType.String, solucion)
        db.AddInParameter(cmd, "@comentarios", DbType.String, comentarios)
        db.AddInParameter(cmd, "@requiereParar", DbType.Int32, requiereParar)
        db.AddInParameter(cmd, "@fechaEstimada", DbType.Date, fechaEstimada)
        db.AddInParameter(cmd, "@horaEstimada", DbType.Date, horaEstimada)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, UsuarioID)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("codigoUltimo")
            Return valor
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    Public Function P_selectRegFallaDetalle(ByVal registroFallaDetalleID As Integer, registroFallaID As Integer, UsuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectRegFallaDetalle")
        db.AddInParameter(cmd, "@registroFallaDetalleID", DbType.Int32, registroFallaDetalleID)
        db.AddInParameter(cmd, "@registroFallaID", DbType.Int32, registroFallaID)
        db.AddInParameter(cmd, "@UsuarioID", DbType.Int32, UsuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
