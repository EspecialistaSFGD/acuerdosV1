Imports System.Data
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB


Public Class SW_TransferenciasPro_DA

    Public Function P_selectTransferencias(ByVal transferenciaID As String, enviado As Integer, recepcionado As Integer,
                                    anulado As Integer, desde As Date, hasta As Date, nroGuia As String, almacenID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTransferencias")
        db.AddInParameter(cmd, "@transferenciaID", DbType.String, transferenciaID)
        db.AddInParameter(cmd, "@enviado", DbType.Int32, enviado)
        db.AddInParameter(cmd, "@recepcionado", DbType.Int32, recepcionado)
        db.AddInParameter(cmd, "@anulado", DbType.Int32, anulado)
        db.AddInParameter(cmd, "@desde", DbType.Date, desde)
        db.AddInParameter(cmd, "@hasta", DbType.Date, hasta)
        db.AddInParameter(cmd, "@nroGuia", DbType.String, nroGuia)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectTransferenciasCab(ByVal transferenciaID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTransferenciasCab")
        db.AddInParameter(cmd, "@transferenciaID", DbType.String, transferenciaID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectTransferenciasReDet(ByVal transferenciaID As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTransferenciasReDet")
        db.AddInParameter(cmd, "@transferenciaID", DbType.String, transferenciaID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateTblTransferencia(ByVal transferenciaID As String, codigo As String, ByVal fechaHoraEnviado As Date,
                                                  ByVal usuarioIDEnviado As Integer, ByVal fechaHoraRecibido As Date,
                                                  ByVal usuarioIDRecibido As Integer, ByVal fechaHoraAnulado As Date,
                                                  ByVal usuarioIDAnulado As Integer, ByVal almacenIDorigen As Integer, ByVal almacenIDdestino As Integer,
                                                  ByVal observaciones As String, ByVal estado As Integer, ByVal referenciaDevolucion As String,
                                                  ByVal usuarioID As Integer, ByVal sucursalID As Integer, ByVal sucursalIDdestino As Integer) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateTblTransferencia")
        db.AddInParameter(cmd, "@transferenciaID", DbType.String, transferenciaID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@fechaHoraEnviado", DbType.Date, fechaHoraEnviado)
        db.AddInParameter(cmd, "@usuarioIDEnviado", DbType.Int32, usuarioIDEnviado)
        db.AddInParameter(cmd, "@fechaHoraRecibido", DbType.Date, fechaHoraRecibido)
        db.AddInParameter(cmd, "@usuarioIDRecibido", DbType.Int32, usuarioIDRecibido)
        db.AddInParameter(cmd, "@fechaHoraAnulado", DbType.Date, fechaHoraAnulado)
        db.AddInParameter(cmd, "@usuarioIDAnulado", DbType.Int32, usuarioIDAnulado)
        db.AddInParameter(cmd, "@almacenIDorigen", DbType.Int32, almacenIDorigen)
        db.AddInParameter(cmd, "@almacenIDdestino", DbType.Int32, almacenIDdestino)
        db.AddInParameter(cmd, "@observaciones", DbType.String, observaciones)
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@referenciaDevolucion", DbType.String, referenciaDevolucion)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, usuarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@sucursalIDdestino", DbType.Int32, sucursalIDdestino)

        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("transferenciaIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Function P_selectTransferCorrelativoNum(ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectTransferCorrelativoNum")
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class

