Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Friend Class SW_pedido_DA

    Public Function SD_P_selectPrioridadAcuerdo(ByVal prioridadID As Integer, ByVal eventoId As Integer,
                                  ByVal grupoID As Integer, ByVal departamento As Integer,
                                  ByVal ubigeo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectPrioridadAcuerdo")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@departamento", DbType.Int32, departamento)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function SD_P_selectParametroByID(ByVal parametroId As Integer, tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectParametroByID")
        db.AddInParameter(cmd, "@parametroId", DbType.Int32, parametroId)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function SD_P_selectAutorizaByDNI(ByVal dni As String, correo As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAutorizaByDNI")
        db.AddInParameter(cmd, "@dni", DbType.String, dni)
        db.AddInParameter(cmd, "@correo", DbType.String, correo)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function SD_P_selectAcceso(ByVal accesoID As Integer, entidadId As Integer, vigente As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAcceso")
        db.AddInParameter(cmd, "@accesoID", DbType.Int32, accesoID)
        db.AddInParameter(cmd, "@entidadId", DbType.Int32, entidadId)
        db.AddInParameter(cmd, "@vigente", DbType.Int32, vigente)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_crearUpdatePrioridadAcuerdo(ByVal prioridadID As Integer, ByVal eventoId As Integer, ByVal grupoID As Integer,
                                                    ByVal ubigeo As Integer, ByVal prioridadTerritorial As String, ByVal objetivoEstrategicoTerritorial As String,
                                                    ByVal intervencionesEstrategicas As String, ByVal aspectoCriticoResolver As String,
                                                    ByVal cuis As String, accesiId As Integer) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_crearUpdatePrioridadAcuerdo")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        db.AddInParameter(cmd, "@prioridadTerritorial", DbType.String, prioridadTerritorial)
        db.AddInParameter(cmd, "@objetivoEstrategicoTerritorial", DbType.String, objetivoEstrategicoTerritorial)
        db.AddInParameter(cmd, "@intervencionesEstrategicas", DbType.String, intervencionesEstrategicas)
        db.AddInParameter(cmd, "@aspectoCriticoResolver", DbType.String, aspectoCriticoResolver)
        db.AddInParameter(cmd, "@cuis", DbType.String, cuis)
        db.AddInParameter(cmd, "@accesoId", DbType.String, accesiId)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("prioridadIdUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function SD_P_crearUpdateAcceso(ByVal entidadId As Integer, nombres As String, ByVal dni As String,
                                                    correo As String, telefono As String, accesoID As Integer) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_crearUpdateAcceso")
        db.AddInParameter(cmd, "@entidadId", DbType.Int32, entidadId)
        db.AddInParameter(cmd, "@nombres", DbType.String, nombres)
        db.AddInParameter(cmd, "@dni", DbType.String, dni)
        db.AddInParameter(cmd, "@correo", DbType.String, correo)
        db.AddInParameter(cmd, "@telefono", DbType.String, telefono)
        db.AddInParameter(cmd, "@accesoID", DbType.Int32, accesoID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("accesoID")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Function SD_P_crearUpdateHito(ByVal hitdoId As Integer, ByVal acuerdoID As Integer, hito As String, ByVal responsableID As Integer,
                                                    plazo As String, comentarioSD As String, entidadId As Integer, validado As Integer, accesoID As Integer) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_crearUpdateHito")
        db.AddInParameter(cmd, "@hitdoId", DbType.Int32, hitdoId)
        db.AddInParameter(cmd, "@acuerdoID", DbType.String, acuerdoID)
        db.AddInParameter(cmd, "@hito", DbType.String, hito)
        db.AddInParameter(cmd, "@responsableID", DbType.String, responsableID)
        db.AddInParameter(cmd, "@plazo", DbType.String, plazo)
        db.AddInParameter(cmd, "@comentarioSD", DbType.String, comentarioSD)
        db.AddInParameter(cmd, "@entidadID", DbType.Int32, entidadId)
        db.AddInParameter(cmd, "@validado", DbType.Int32, validado)
        db.AddInParameter(cmd, "@accesoID", DbType.Int32, accesoID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("hitoId")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Function SD_P_selectAcuerdosV2(ByVal acuerdoID As Integer, ByVal prioridadID As Integer,
                                  ByVal acuerdo As String, ByVal clasificacionID As Integer,
                                  ByVal responsableID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectAcuerdosV2")
        db.AddInParameter(cmd, "@acuerdoID", DbType.Int32, acuerdoID)
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@acuerdo", DbType.String, acuerdo)
        db.AddInParameter(cmd, "@clasificacionID", DbType.Int32, clasificacionID)
        db.AddInParameter(cmd, "@responsableID", DbType.Int32, responsableID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectListAcuerdoExport(ByVal prioridadID As Integer, ByVal eventoId As Integer,
                              ByVal grupoID As Integer, ByVal departamento As Integer,
                              ByVal ubigeo As Integer, codigo As String, clasificacion As Integer, responsable As Integer,
                                           acuerdoID As Integer, estadoRegistro As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectListAcuerdoExport")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@departamento", DbType.Int32, departamento)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@clasificacion", DbType.Int32, clasificacion)
        db.AddInParameter(cmd, "@responsable", DbType.Int32, responsable)
        db.AddInParameter(cmd, "@acuerdoID", DbType.Int32, acuerdoID)
        db.AddInParameter(cmd, "@estadoRegistro", DbType.String, estadoRegistro)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectPrioridadAcuerdoExport(ByVal prioridadID As Integer, ByVal eventoId As Integer,
                                  ByVal grupoID As Integer, ByVal departamento As Integer,
                                  ByVal ubigeo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectPrioridadAcuerdoExport")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@departamento", DbType.Int32, departamento)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function SD_P_selectListHitos(ByVal hitdoId As Integer, acuerdoID As Integer, ByVal responsableID As Integer,
                                  ByVal estado As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectListHitos")
        db.AddInParameter(cmd, "@hitdoId", DbType.Int32, hitdoId)
        db.AddInParameter(cmd, "@acuerdoID", DbType.Int32, acuerdoID)
        db.AddInParameter(cmd, "@responsableID", DbType.Int32, responsableID)
        db.AddInParameter(cmd, "@estado", DbType.String, estado)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectGrupos(ByVal grupoId As Integer, tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectGrupos")
        db.AddInParameter(cmd, "@grupoId", DbType.Int32, grupoId)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectEntidades(ByVal entidadId As Integer, tipo As Integer, sectorId As Integer, ubigeo As Integer, token As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectEntidades")
        db.AddInParameter(cmd, "@entidadId", DbType.Int32, entidadId)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        db.AddInParameter(cmd, "@sectorId", DbType.Int32, sectorId)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        db.AddInParameter(cmd, "@token", DbType.String, token)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectEventos(ByVal eventoId As Integer, tipo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectEventos")
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)

        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectListAcuerdoHitoExport(ByVal prioridadID As Integer, ByVal eventoId As Integer,
                              ByVal grupoID As Integer, ByVal departamento As Integer,
                              ByVal ubigeo As Integer, codigo As String, clasificacion As Integer, responsable As Integer,
                                           acuerdoID As Integer, estadoRegistro As Integer, estadoRegistroAC As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectListAcuerdoHitoExport")
        db.AddInParameter(cmd, "@prioridadID", DbType.Int32, prioridadID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@departamento", DbType.Int32, departamento)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@clasificacion", DbType.Int32, clasificacion)
        db.AddInParameter(cmd, "@responsable", DbType.Int32, responsable)
        db.AddInParameter(cmd, "@acuerdoID", DbType.Int32, acuerdoID)
        db.AddInParameter(cmd, "@estadoRegistro", DbType.Int32, estadoRegistro)
        db.AddInParameter(cmd, "@estadoRegistroAC", DbType.String, estadoRegistroAC)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectValidaPrioridadAcuerdo(ByVal eventoId As Integer, grupoID As Integer, ubigeo As Integer, eje As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectValidaPrioridadAcuerdo")
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        db.AddInParameter(cmd, "@eje", DbType.Int32, eje)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectValidaPrioridadAcuerdoSector(ByVal eventoId As Integer, grupoID As Integer, ubigeo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectValidaPrioridadAcuerdoSector")
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@grupoID", DbType.Int32, grupoID)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectValidaPedidoCant(ByVal eventoId As Integer, ubigeo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectValidaPedidoCant")
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectValidaCantSect(ByVal eventoId As Integer, ubigeo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectValidaCantSect")
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@ubigeo", DbType.Int32, ubigeo)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function


    Public Function SD_P_selectValidaAcreditadoCant(ByVal eventoId As Integer, entidadId As Integer, tipo As Integer, fecha As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectValidaAcreditadoCant")
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@entidadId", DbType.Int32, entidadId)
        db.AddInParameter(cmd, "@tipo", DbType.Int32, tipo)
        db.AddInParameter(cmd, "@fecha", DbType.String, fecha)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function SD_P_selectListReuniones(ByVal reunionID As Integer, eventoId As Integer, salaId As Integer, sectorIdGN As Integer, entidadIdGRGL As Integer, estadoRegistro As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("SD_P_selectListReuniones")
        db.AddInParameter(cmd, "@reunionID", DbType.Int32, reunionID)
        db.AddInParameter(cmd, "@eventoId", DbType.Int32, eventoId)
        db.AddInParameter(cmd, "@salaId", DbType.Int32, salaId)
        db.AddInParameter(cmd, "@sectorIdGN", DbType.Int32, sectorIdGN)
        db.AddInParameter(cmd, "@entidadIdGRGL", DbType.Int32, entidadIdGRGL)
        db.AddInParameter(cmd, "@estadoRegistro", DbType.String, estadoRegistro)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function
End Class
