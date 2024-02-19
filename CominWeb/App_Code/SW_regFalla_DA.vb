Imports System.Data
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_regFalla_DA

    Public Function P_crearUpdateCorrectivo(ByVal manttoCorrectivoID As Integer, codigo As String, nombre As String, equipoID As String,
                                            fechaApertura As Date, sucursalID As Integer, almacenID As Integer, cantPersonas As Integer,
                                            monedaID As Integer, clienteID As String, contactoID As String, email As String,
                                            lugarTrabajoID As String, observaciones As String, usuarioID As Integer) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateCorrectivo")
        db.AddInParameter(cmd, "@manttoCorrectivoID", DbType.Int32, manttoCorrectivoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@equipoID", DbType.String, equipoID)
        db.AddInParameter(cmd, "@fechaApertura", DbType.Date, fechaApertura)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@cantPersonas", DbType.Int32, cantPersonas)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@clienteID", DbType.String, clienteID)
        db.AddInParameter(cmd, "@contactoID", DbType.String, contactoID)
        db.AddInParameter(cmd, "@email", DbType.String, email)
        db.AddInParameter(cmd, "@lugarTrabajoID", DbType.String, lugarTrabajoID)
        db.AddInParameter(cmd, "@observaciones", DbType.String, observaciones)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, usuarioID)
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
            Return ""
        End Try
    End Function

    Public Function P_selectRegFalla(ByVal registroFallaID As Integer, tipoFalla As Integer, codEquipo As String,
                                     cliente As String, estado As String, sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectRegFalla")
        db.AddInParameter(cmd, "@registroFallaID", DbType.Int32, registroFallaID)
        db.AddInParameter(cmd, "@tipoFalla", DbType.Int32, tipoFalla)
        db.AddInParameter(cmd, "@codEquipo", DbType.String, codEquipo)
        db.AddInParameter(cmd, "@cliente", DbType.String, cliente)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectCorrect(ByVal manttoCorrectivoID As Integer, codigo As String, cliente As String,
                                 equipo As String, sucursalID As Integer, estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectCorrect")
        db.AddInParameter(cmd, "@manttoCorrectivoID", DbType.Int32, manttoCorrectivoID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@cliente", DbType.String, cliente)
        db.AddInParameter(cmd, "@equipo", DbType.String, equipo)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function P_selectCorrectDet(ByVal manttoCorrectivoDetalleID As Integer, manttoCorrectivoID As Integer, usuarioID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectCorrectDet")
        db.AddInParameter(cmd, "@manttoCorrectivoDetalleID", DbType.Int32, manttoCorrectivoDetalleID)
        db.AddInParameter(cmd, "@manttoCorrectivoID", DbType.Int32, manttoCorrectivoID)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, usuarioID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
