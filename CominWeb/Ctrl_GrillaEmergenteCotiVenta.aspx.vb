Imports Telerik.Web.UI
Imports CominWeb.SW_coneccionDB

Public Class Ctrl_GrillaEmergenteCotiVenta
    Inherits System.Web.UI.Page
    Dim ColumnasOcultasArray() As String
    Dim i As Integer = 0
    Dim tabla As String
    Dim columnas As String
    Dim columnas_ocultas As String = ""
    Dim columna_buscar_letra As String
    Dim columna_buscar_numero As String
    Public identificador As String
    Public columna_mostrar As String
    Dim filas As String
    Dim SW_EjecutaSQLDA As New SW_EjecutaSQL_DA
    Dim SW_EjecutaSQLDT As New DataTable

    Private Sub Ctrl_GrillaEmergente_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        SW_EjecutaSQLDT = SW_EjecutaSQLDA.P_selectParametroByID(14)
        If SW_EjecutaSQLDT.Rows(0).Item(2).ToString = 1 Then
            txt_buscar.Text = Request.QueryString("texto_digitado").ToString
        Else
            txt_buscar.Text = ""
        End If
        'txt_buscar.Focus()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim accion As String = Request.QueryString("accion").ToString
        SqlDataSource_Grillas_Emergentes.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString

        If Request.QueryString("toolbar") = 0 Then
            RadToolBar1.Visible = False
        Else
            RadToolBar1.Visible = True
        End If
        RadGrid_Principal.GroupingSettings.CaseSensitive = False
        'aki debe ir un parametros
        If Me.Request.QueryString("accion") = "Productos" Or Me.Request.QueryString("accion") = "ProductosConSinStock" _
            Or Me.Request.QueryString("accion") = "ProductosConSinStockComp" Then
            RadGrid_Principal.MasterTableView.AllowFilteringByColumn = True
        End If
        'hasta aki
        ''xxxxxxxx '' '' ''ScriptManager.RegisterStartupScript(Page, GetType(Page), "AjustarVentana", "SizeToFit();", True)

        Select Case accion
            Case "Cargo"
                tabla = "tblCargo"
                columnas = "[cargoID] AS 'ID', [nombre] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[cargoID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10

                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Empresas_sin_inicio"
                tabla = "Empresas"
                columnas = "[EmpresaID] AS 'ID', [RazonSocial] AS 'Razon Soacial',[RazonComercial] AS 'Razon Comercial',[Ruc]"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[RazonSocial]"
                columna_buscar_numero = "[Ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Soacial"
                filas = 10

                If Not IsPostBack And txt_buscar.Text = "" Then
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '% nadaquebuscaraqui %') ORDER BY " & identificador.ToString & " ASC"
                Else '
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "Pais"
                tabla = "tblPaises"
                columnas = "[paisID] AS 'ID', [nombrePais] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombrePais]"
                columna_buscar_numero = "[paisID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10

                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Marca_sin_inicio"
                tabla = "tblGrupo"
                columnas = "[marcaID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[marcaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "subGrupo_sin_inicio"
                tabla = "tblSubGrupo"
                columnas = "[subGrupoID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[subGrupoID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "MarcaEspecifico_sin_inicio"
                tabla = "tblMarca"
                columnas = "[marcaID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[marcaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipo = 1 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipo = 1 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "UnidadMedida_sin_inicio"
                tabla = "tblUnidadMedida"
                'unidadMedidaID, nombre, abreviatura, descripcion
                columnas = "[unidadMedidaID] AS 'ID', [nombre] AS 'Nombre', [abreviatura] AS 'Abreviatura',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[unidadMedidaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoUnidadMedidaID = 1 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoUnidadMedidaID = 1 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "GrupoFuncion_sin_inicio"
                tabla = "tblGrupoFuncion"
                columnas = "[grupoFuncionID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[grupoFuncionID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%')  ORDER BY codigo ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY codigo ASC"
                End If
            Case "Ubicacion_sin_inicio"
                tabla = "tblUbicacionProducto"
                columnas = "[ubicacionID] AS 'ID', [codubicacion] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[ubicacionID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') AND " & _
                " sucursalID = " & Session("IDSucursalPrincipal").ToString.Trim & _
                " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') AND " & _
                " sucursalID = " & Session("IDSucursalPrincipal").ToString.Trim & _
                " ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Propietario_sin_inicio"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 1 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 1 AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Proveedor_sin_inicio"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') OR ( " & _
                                   "razoncomercial COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Proveedor_sin_inicio1"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') OR ( " & _
                                   "razoncomercial COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Proveedor_sin_inicio2"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Ruc"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') OR ( " & _
                                   "razoncomercial COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Trabajador_sin_inicio"
                tabla = "tblTrabajador INNER JOIN tblTipoDocumento on tbltrabajador.tipoDocumentoID = tblTipoDocumento.tipoDocumentoID"
                columnas = "[trabajadorID] AS 'ID', apaterno + ' ' + amaterno + ' ' + nombres AS 'Nombre',nroPhotocheck AS 'N° PhotoCheck',tblTipoDocumento.nombre AS 'Tipo Doc.',nroDocumento AS 'N° Doc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombres]"
                columna_buscar_numero = "[nroDocumento]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                Dim excluir As Integer
                If Not Request.QueryString("excluir") Is Nothing Then
                    excluir = Request.QueryString("excluir")
                Else
                    excluir = 0
                End If
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%' AND trabajadorID <> " & excluir & _
                " AND estado = 0) AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR apaterno LIKE '%" & txt_buscar.Text & _
                "%' OR amaterno LIKE '%" & txt_buscar.Text & "%' ) AND trabajadorID <> " & excluir & _
                " AND estado = 0  AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                " ORDER BY " & _
                identificador.ToString & " ASC"
                End If
            Case "Trabajador_sin_usuarios"
                tabla = "tblTrabajador INNER JOIN tblTipoDocumento on tbltrabajador.tipoDocumentoID = tblTipoDocumento.tipoDocumentoID"
                columnas = "[trabajadorID] AS 'ID', apaterno + ' ' + amaterno + ' ' + nombres AS 'Nombre',nroPhotocheck AS 'N° PhotoCheck',tblTipoDocumento.nombre AS 'Tipo Doc.',nroDocumento AS 'N° Doc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombres]"
                columna_buscar_numero = "[nroDocumento]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                Dim excluir As Integer
                If Not Request.QueryString("excluir") Is Nothing Then
                    excluir = Request.QueryString("excluir")
                Else
                    excluir = 0
                End If
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') AND trabajadorID <> " & _
                excluir & " AND estado = 0 AND tblTrabajador.trabajadorID not in (SELECT trabajadorID from tblusuarios)  " & _
                " AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString & " ORDER BY apaterno ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR apaterno LIKE '%" & txt_buscar.Text & _
                "%' OR amaterno LIKE '%" & txt_buscar.Text & "%' ) AND trabajadorID <> " & excluir & _
                " AND estado = 0 AND tblTrabajador.trabajadorID not in (SELECT trabajadorID from tblusuarios) " & _
                " AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString & " ORDER BY apaterno ASC"
                End If
            Case "Equipo_sin_inicio"
                tabla = " dbo.tblEquipo INNER JOIN" & _
                      " dbo.tblModelo ON dbo.tblEquipo.modeloID = dbo.tblModelo.modeloID LEFT OUTER JOIN" & _
                      " dbo.tblTipoEquipo LEFT OUTER JOIN" & _
                      " dbo.tblMarca ON dbo.tblTipoEquipo.marcaID = dbo.tblMarca.marcaID ON dbo.tblModelo.tipoEquipoID = dbo.tblTipoEquipo.tipoEquipoID"
                columnas = "[equipoID] AS 'ID', tblEquipo.codigo AS 'Codigo Equipo', nroPlaca AS 'N° Placa',  dbo.tblMarca.nombre as 'Marca', " & _
                    " dbo.tblTipoEquipo.nombre as 'Tipo', tblmodelo.nombre AS 'Modelo', nroSerie as 'Serie'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "tblEquipo.codigo"
                columna_buscar_numero = "tblEquipo.codigo"
                identificador = "ID"
                columna_mostrar = "Codigo Equipo"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & _
                "%' OR nroSerie LIKE '%" & txt_buscar.Text & _
                "%' AND tblEquipo.estado = 0) AND tblEquipo.sucursalID = " & _
                Session("IDSucursalPrincipal").ToString & " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & _
                "%' OR nroSerie LIKE '%" & txt_buscar.Text & _
                "%' AND tblEquipo.estado = 0) AND tblEquipo.sucursalID = " & _
                Session("IDSucursalPrincipal").ToString & " ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "LugarTrabajo_sin_inicio"
                tabla = "tblLugarTrabajo"
                columnas = "[lugarTrabajoID] AS 'ID', [nombre] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[lugarTrabajoID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE  sucursalID = " & Session("IDSucursalPrincipal").ToString & " and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE  sucursalID = " & Session("IDSucursalPrincipal").ToString & " and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If

            Case "TipoCombustible"
                '0 ES FACTURAR, 1 ES STOCK
                If Me.Request.QueryString("descuentoID").ToString.Trim = 0 Then
                    tabla = " dbo.tblProducto INNER JOIN " & _
                    " dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = dbo.tblGrupoFuncion.grupoFuncionID "
                    columnas = " dbo.tblProducto.productoID AS 'ID', dbo.tblProducto.codproducto AS Codigo, " & _
                        " dbo.tblProducto.nombre AS 'Nombre',dbo.tblGrupoFuncion.nombre AS 'Grupo Funcion' "
                    columnas_ocultas = "ID"
                    columna_buscar_letra = "tblProducto.nombre"
                    columna_buscar_numero = "[productoID]"
                    identificador = "ID"
                    columna_mostrar = "Nombre"
                    filas = 10
                    If Session("almacenAsignadoPrincipal").ToString > 0 Then
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND tblProducto.marcaID = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND tblProducto.marcaID = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    Else
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND tblProducto.marcaID = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND tblProducto.marcaID = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    End If
                ElseIf Me.Request.QueryString("descuentoID").ToString.Trim = 1 Then
                    tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA " & _
                        " ON dbo.tblProducto.productoBaseID = PROBA.productoBaseID RIGHT OUTER JOIN " & _
                        " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                    columnas = " dbo.tblProducto.productoID AS 'ID', PROBA.codproducto AS Codigo, PROBA.nombre AS " & _
                        "'Nombre', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                        " SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                    columnas_ocultas = "ID"
                    columna_buscar_letra = "PROBA.nombre"
                    columna_buscar_numero = "[productoID]"
                    identificador = "ID"
                    columna_mostrar = "Nombre"
                    filas = 10
                    If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                        " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                        " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY PROBA.nombre ASC"
                        End If
                    Else
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString & _
                        "  AND(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    End If
                End If
            Case "Productos"
                Dim grupoSQL As String
                SW_EjecutaSQLDT = SW_EjecutaSQLDA.P_selectParametroByID(56)
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " & _
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " & _
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " & _
                    "= dbo.tblInventarios.productoID "
                If SW_EjecutaSQLDT.Rows(0).Item(2) = 1 Then
                    columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    "dbo.F_nomTblSubGrupo(PROBA.subGrupoID) AS 'Sub-Grupo', dbo.F_nomTblMarca(PROBA.marcaID) as 'Marca', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', " & _
                "dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' , SUM(dbo.tblInventarios.cantidad) AS 'Stock'," & _
                "CAST(tblProducto.valorVenta AS decimal(9,2)) 'Venta', CAST(tblProducto.ventaDecena AS decimal(9,2)) 'Decena', " & _
                "CAST(tblProducto.ventaCentena AS decimal(9,2)) 'Centena'"
                    grupoSQL = " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, PROBA.marcaID, " & _
                        "dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID," & _
                        "tblProducto.valorVenta, tblProducto.ventaDecena,tblProducto.ventaCentena,PROBA.subGrupoID"
                Else
                    columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', " & _
                "dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' , SUM(dbo.tblInventarios.cantidad) AS 'Stock'," & _
                "CAST(tblProducto.valorVenta AS decimal(9,2)) 'Venta', CAST(tblProducto.ventaDecena AS decimal(9,2)) 'Decena', " & _
                "CAST(tblProducto.ventaCentena AS decimal(9,2)) 'Centena'"
                    grupoSQL = " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre," & _
                        "dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID," & _
                        "tblProducto.valorVenta, tblProducto.ventaDecena,tblProducto.ventaCentena"
                End If

                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"

                filas = 10
                'FALTA AGREGAR UN PARAMETRO PARA CONTROLAR :: dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 
                '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & _
                        "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY PROBA.nombre ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString & _
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%'" & _
                         " OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ProductosConSinStock"
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto " & _
                    "INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID = PROBA.productoBaseID " & _
                    "RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto as 'Fabricante'," & _
                    "dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    "dbo.F_nomTblSubGrupo(PROBA.subGrupoID) AS 'Sub-Grupo', " & _
                    "dbo.F_nomTblMarca(PROBA.marcaID) 'Marca', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', " & _
                    "SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%' ) " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codigoProducto, PROBA.subGrupoID,PROBA.codproducto, PROBA.nombre, PROBA.grupoID, dbo.tblInventarios.almacenID, PROBA.UnidadMedidaID " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codigoProducto, PROBA.subGrupoID,PROBA.codproducto, PROBA.nombre, PROBA.grupoID, dbo.tblInventarios.almacenID,PROBA.UnidadMedidaID " & _
                        " ORDER BY PROBA.nombre ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codproducto, PROBA.subGrupoID,PROBA.nombre, PROBA.grupoID, dbo.tblInventarios.almacenID,PROBA.UnidadMedidaID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString & _
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codproducto, PROBA.subGrupoID,PROBA.nombre, PROBA.grupoID, dbo.tblInventarios.almacenID,PROBA.UnidadMedidaID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ProductosConSinStockComp"
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto " & _
                    "INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID = PROBA.productoBaseID " & _
                    "RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto as 'Fabricante'," & _
                    "dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    "dbo.F_nomTblSubGrupo(PROBA.subGrupoID) AS 'Sub-Grupo', " & _
                    "dbo.F_nomTblMarca(PROBA.marcaID) 'Marca', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' "
                '& _
                '                   "SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%' ) " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codigoProducto, PROBA.subGrupoID,PROBA.codproducto, PROBA.nombre, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codigoProducto, PROBA.subGrupoID,PROBA.codproducto, PROBA.nombre, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                        " ORDER BY PROBA.nombre ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codproducto, PROBA.subGrupoID,PROBA.nombre, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString & _
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " & _
                        " GROUP BY dbo.tblProducto.productoID, PROBA.marcaID, PROBA.codproducto, PROBA.subGrupoID,PROBA.nombre, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                        " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ProductosFacturacion"
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " & _
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " & _
                    "dbo.tblGrupoFuncion.grupoFuncionID LEFT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " & _
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto, dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(ISNULL(dbo.tblInventarios.cantidad, 0)) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY PROBA.nombre ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString & _
                    "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                End If
            Case "ProductosFacturacionEQ"
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " & _
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " & _
                    "dbo.tblGrupoFuncion.grupoFuncionID LEFT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " & _
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto, dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(ISNULL(dbo.tblInventarios.cantidad, 0)) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY PROBA.nombre ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString & _
                    "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                End If
            Case "ProductosAll"
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " & _
                    "= PROBA.productoBaseID INNER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " & _
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " & _
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID',PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre'" & _
                    ", dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', tblgrupofuncion.nombre AS 'Grupo', SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString & _
                    "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "Contenedor_sin_inicio"
                tabla = "tblContenedorHerramienta"
                'unidadMedidaID, nombre, abreviatura, descripcion
                columnas = "[contenedorHerramientaID] AS 'ID', [nombre] AS 'Nombre', [codigo] AS 'Codigo'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[contenedorHerramientaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE  (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Cliente_sin_inicio"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 3 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 3 AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Cliente_sin_inicio2"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Ruc"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 3 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoSave = 3 AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Cliente_sin_inicio3"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoProveedorID = (select valor from tblParametros where parametroGeneralID = 34) and tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE tipoProveedorID = (select valor from tblParametros where parametroGeneralID = 34) and tipoSave = 2 AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "TiempoEstandar"
                tabla = "tblTiempoEstandarTrabajo"
                'unidadMedidaID, nombre, abreviatura, descripcion
                columnas = "[tiempoEstandarTrabajoID] AS 'ID', [nombre] AS 'Nombre', [horas] AS 'Horas'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[codigo]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE  (" & columna_buscar_numero.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Productos1"
                tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID',tblProducto.codproducto as Codigo,tblProducto.nombre AS 'Nombre'" & _
                    ", dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', tblgrupofuncion.nombre AS 'Grupo', SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "tblProducto.codproducto"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Session("almacenAsignadoPrincipal").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ordenesCompra_sin_inicio"
                tabla = " dbo.tblOrdenesCompra AS OC LEFT OUTER JOIN " & _
                        " dbo.tblUsuarios AS US ON OC.usuarioIDaprueba = US.usuarioID "
                columnas = " OC.OrdenCompraID AS 'ID', OC.codigo AS 'NRO. ORDEN', CONVERT(VARCHAR(10),OC.fechaOrden,103) AS 'F. ORDEN', " & _
                    " UPPER(US.nombreUser) AS 'APROBADO POR', CONVERT(VARCHAR(10),OC.fechaAprobacion,103) AS 'F. APROBAC.', OC.glosaAprueba AS 'GLOSA' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "OC.codigo"
                columna_buscar_numero = "OC.OrdenCompraID"
                identificador = "ID"
                columna_mostrar = "NRO. ORDEN"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (OC.estado = 3) AND (OC.compraID IS NULL) AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                " ORDER BY OC.fechaAprobacion DESC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (OC.estado = 3) AND (OC.compraID IS NULL) AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                " ORDER BY OC.fechaAprobacion DESC"
                End If
            Case "Cotizaciones_sin_inicio"
                tabla = " tblCotizacion "
                columnas = " Codigo, dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) 'Cliente', " & _
                    " dbo.F_CodigoByEquipoID(equipoID) 'Equipo', ordenCompraCliente 'Orden de Compra', " & _
                    " dbo.F_codOrdenTrabajo(ordenServicioIDRef) 'OT' "
                columna_buscar_letra = " dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) "
                columna_buscar_numero = "ordenCompraCliente"
                identificador = "Orden de Compra"
                columna_mostrar = "Codigo"
                filas = 10

                Dim estalog As Integer = SW_EjecutaSQLDA.P_selectParametroByID(62).Rows(0).Item(2).ToString
                If estalog = 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' AND dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " & _
                    " ORDER BY Codigo DESC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' AND dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " & _
                    " ORDER BY Codigo DESC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' " & _
                    " ORDER BY Codigo DESC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' " & _
                    " ORDER BY Codigo DESC"
                    End If
                End If
            Case "Contacto_sin_inicio"
                tabla = "tblContacto"
                columnas = "[contactoID] AS 'ID', dbo.F_nomTblCargo(cargoID) AS 'Cargo', [nombre] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE propietarioProveedorID = " & Me.Request.QueryString("RazonSocialID").ToString & _
                " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY nombre ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE propietarioProveedorID = " & Me.Request.QueryString("RazonSocialID").ToString & _
                " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY nombre ASC"
                End If
            Case "ordenTrabajo_sin_inicio"
                tabla = "tblOrdenServicio"
                columnas = "[ordenServicioID] AS 'ID', codigo AS 'OT', dbo.F_CodigoByEquipoID(equipoID) AS 'Equipo', dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) AS 'Cliente'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "codigo"
                identificador = "ID"
                columna_mostrar = "OT"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
            " WHERE ISNULL(cotizado,0) = 0 AND estado <> 2 and " & _
            "(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' " & _
            " OR dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " & _
            " OR dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID)  LIKE '%" & txt_buscar.Text & "%' )" & _
            "ORDER BY fechaApertura DESC"
            Case "ordenTrabajoTODO_sin_inicio"
                tabla = "tblOrdenServicio"
                columnas = "[ordenServicioID] AS 'ID', codigo AS 'OT', dbo.F_CodigoByEquipoID(equipoID) AS 'Equipo', dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) AS 'Cliente'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "codigo"
                identificador = "ID"
                columna_mostrar = "OT"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
            " WHERE estado <> 2 and " & _
            "(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' " & _
            " OR dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " & _
            " OR dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID)  LIKE '%" & txt_buscar.Text & "%' )" & _
            " ORDER BY fechaApertura DESC"
                'End If
            Case "Compras_sin_inicio"
                tabla = "dbo.tblCompra AS CO INNER JOIN" & _
                            " dbo.tblPropietarioProveedorClienteSubcontrata AS " & _
                            " PROV ON CO.propietarioProveedorID = PROV.propietarioProveedorID "
                columnas = "TOP 20 CO.compraID, CO.codigo [Codigo], PROV.razonsocial [Cliente], " & _
                        "CASE WHEN CO.monedaID = 1 THEN 'S/.' ELSE '$' END AS Moneda, " & _
                        "dbo.F_nomTblTipoDocumento(CO.tipoDocumento) AS Documento, CO.nroSerieDocumento + '-' + " & _
                        " CO.numeroDocumento AS Numero, convert(varchar(20),CO.fechaFacturaCompra,103) [F.Emision], " & _
                        "CO.glosaCompra [Glosa], cast((CO.SubTotal * CO.tipocambio) as decimal(18,2)) as SubTotal, " & _
                        "cast((CO.IGVval * CO.tipocambio) as decimal(18,2)) as IGV, " & _
                        "cast((CO.SubTotal * CO.tipocambio) + (CO.IGVval * CO.tipocambio) as decimal(18,2)) AS Total "
                columnas_ocultas = "compraID"
                columna_buscar_letra = "Codigo"
                identificador = "compraID"
                columna_mostrar = "Codigo"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE CO.nroSerieDocumento + '-' + CO.numeroDocumento LIKE '%" & txt_buscar.Text & "%' ORDER BY fechaFacturaCompra DESC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE CO.nroSerieDocumento + '-' + CO.numeroDocumento LIKE '%" & txt_buscar.Text & "%' ORDER BY fechaFacturaCompra DESC"
                End If
            Case "tipoEquipo_sin_inicio"
                tabla = " dbo.tblTipoEquipo INNER JOIN" & _
                            " dbo.tblMarca ON dbo.tblTipoEquipo.marcaID = dbo.tblMarca.marcaID "
                columnas = " LTRIM(RTRIM(dbo.tblTipoEquipo.tipoEquipoID)) AS tipoEquipoID, dbo.tblTipoEquipo.codigo, " & _
                "dbo.tblTipoEquipo.nombre as nomEquipo, dbo.tblTipoEquipo.descripcion "
                columnas_ocultas = "tipoEquipoID"
                columna_buscar_letra = "dbo.tblTipoEquipo.nombre"
                identificador = "tipoEquipoID"
                columna_mostrar = "nomEquipo"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.tblTipoEquipo.estado = 0 and dbo.tblTipoEquipo.nombre LIKE '%" & txt_buscar.Text & "%' ORDER BY dbo.tblTipoEquipo.nombre ASC"

            Case "modeloEquipo_sin_inicio"
                tabla = " dbo.tblModelo INNER JOIN dbo.tblTipoEquipo ON dbo.tblModelo.tipoEquipoID = dbo.tblTipoEquipo.tipoEquipoID "
                columnas = " dbo.tblModelo.modeloID AS 'ID', dbo.tblTipoEquipo.nombre AS 'Tipo Equipo', dbo.tblModelo.codigo, dbo.tblModelo.nombre AS Nombre, dbo.tblModelo.descripcion "
                columnas_ocultas = "ID"
                columna_buscar_letra = "dbo.tblModelo.nombre"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
            " WHERE dbo.tblModelo.estado = 0 and dbo.tblModelo.nombre LIKE '%" & txt_buscar.Text & "%' " & _
            " AND dbo.tblTipoEquipo.tipoEquipoID = '" & Me.Request.QueryString("tipoEquipo").ToString & "' ORDER BY dbo.tblModelo.nombre ASC"
        End Select

        RadGrid_Principal.MasterTableView.DataKeyNames = New String() {identificador.ToString}
        RadGrid_Principal.MasterTableView.ClientDataKeyNames = New String() {identificador.ToString}
        RadGrid_Principal.MasterTableView.PageSize = filas
        If Page.IsPostBack = False Then
            txt_buscar.Focus()
            'Session("grupoFiltroProducto") = "0"
            'Session("marcaFiltroProducto") = "0"
        End If
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(sender As Object, e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument = "actualizaGrilla" Then
            RadGrid_Principal.Rebind()
        End If
    End Sub

    Protected Sub guardarB_Click(sender As Object, e As EventArgs) Handles guardarB.Click
        Dim cad As String
        If Request.QueryString("accion").ToString = "Contacto_sin_inicio" Then
            cad = " exec P_crearUpdateContacto 0, " & Request.QueryString("RazonSocialID").ToString & ", '" & _
                txt_buscar.Text.ToString & "', '', '', '', 7, " & Session("usuarioLoginID").ToString & " "
        Else
            Try
                cad = " EXEC P_crearUpdateMasivo '" & txt_buscar.Text.ToString & "', '" & Me.Request.QueryString("accion").ToString & _
                                "', " & Session("IDSucursalPrincipal").ToString.Trim & ", " & Session("usuarioLoginID").ToString.Trim & _
                                ", " & Me.Request.QueryString("tipoEquipo").ToString
            Catch ex As Exception
                cad = " EXEC P_crearUpdateMasivo '" & txt_buscar.Text.ToString & "', '" & Me.Request.QueryString("accion").ToString & _
                                "', " & Session("IDSucursalPrincipal").ToString.Trim & ", " & Session("usuarioLoginID").ToString.Trim & _
                                ", 0 "
            End Try

        End If

        If cad.Length > 0 Then
            Try
                Me.SW_EjecutaSQLDA.querySQL(cad)
                RadGrid_Principal.Rebind()
            Catch ex As Exception
            End Try
        End If
    End Sub


    Protected Sub RadGrid_Principal_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGrid_Principal.ColumnCreated
        'cargaFiltroSession(sender, e)
        ''Dim grupoFiltroProducto As String
        ''Dim marcaFiltroProducto As String
        ''grupoFiltroProducto = Session("grupoFiltroProducto").ToString
        ''marcaFiltroProducto = Session("marcaFiltroProducto").ToString
        ''ColumnasOcultasArray = columnas_ocultas.Split(",")
        ''For i As Integer = 0 To UBound(ColumnasOcultasArray)
        ''    If TypeOf e.Column Is GridBoundColumn AndAlso e.Column.UniqueName = ColumnasOcultasArray(i).ToString Then
        ''        Dim column As GridBoundColumn = TryCast(e.Column, GridBoundColumn)
        ''        column.Display = False
        ''    End If
        ''Next i
        ' ''aki debe ir un parametros
        ''If Me.Request.QueryString("accion") = "Productos" Then

        ''    e.Column.FilterControlWidth = Unit.Percentage(100)
        ''    e.Column.AutoPostBackOnFilter = True
        ''    e.Column.ShowFilterIcon = False
        ''    e.Column.CurrentFilterFunction = GridKnownFunction.Contains

        ''    If e.Column.UniqueName = "Stock" Then
        ''        e.Column.HeaderStyle.Width = Unit.Pixel(70)
        ''    End If

        ''    If e.Column.UniqueName = "Grupo" Then
        ''        If grupoFiltroProducto <> "0" Then
        ''            e.Column.CurrentFilterValue = grupoFiltroProducto
        ''            'Else
        ''            '    e.Column.CurrentFilterValue = ""
        ''        End If
        ''    End If

        ''    If e.Column.UniqueName = "Marca" Then
        ''        If marcaFiltroProducto <> "0" Then
        ''            e.Column.CurrentFilterValue = marcaFiltroProducto
        ''            'Else
        ''            '    e.Column.CurrentFilterValue = ""
        ''        End If
        ''    End If

        ''End If
        ' ''hasta aki
        Dim grupoFiltroProducto As String
        Dim marcaFiltroProducto As String
        grupoFiltroProducto = Session("grupoFiltroProducto").ToString
        marcaFiltroProducto = Session("marcaFiltroProducto").ToString
        'ColumnasOcultasArray = columnas_ocultas.Split(",")
        'For i As Integer = 0 To UBound(ColumnasOcultasArray)
        '    If TypeOf e.Column Is GridBoundColumn AndAlso e.Column.UniqueName = ColumnasOcultasArray(i).ToString Then
        '        Dim column As GridBoundColumn = TryCast(e.Column, GridBoundColumn)
        '        column.Display = False
        '    End If
        'Next i
        If Me.Request.QueryString("accion") = "ProductosConSinStock" Then
            e.Column.FilterControlWidth = Unit.Percentage(100)
            e.Column.AutoPostBackOnFilter = True
            e.Column.ShowFilterIcon = False
            e.Column.CurrentFilterFunction = GridKnownFunction.Contains
            If e.Column.UniqueName = "Stock" Or e.Column.UniqueName = "Venta" Or e.Column.UniqueName = "Decena" Or e.Column.UniqueName = "Centena" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right
            ElseIf e.Column.UniqueName = "Unidad" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
            End If

            If e.Column.UniqueName = "Grupo" Then
                If e.Column.CurrentFilterValue.ToString.Length > 0 Then
                    e.Column.CurrentFilterValue = e.Column.CurrentFilterValue
                ElseIf grupoFiltroProducto.Length > 1 Then
                    e.Column.CurrentFilterValue = grupoFiltroProducto
                ElseIf grupoFiltroProducto = "0" Then
                    e.Column.CurrentFilterValue = ""
                End If
            End If

            If e.Column.UniqueName = "Marca" Then
                If e.Column.CurrentFilterValue.ToString.Length > 0 Then
                    e.Column.CurrentFilterValue = e.Column.CurrentFilterValue
                ElseIf marcaFiltroProducto.Length > 1 Then
                    e.Column.CurrentFilterValue = marcaFiltroProducto
                ElseIf marcaFiltroProducto = "0" Then
                    e.Column.CurrentFilterValue = ""
                End If
            End If
        ElseIf Me.Request.QueryString("accion") = "ProductosConSinStockComp" Then
            e.Column.FilterControlWidth = Unit.Percentage(100)
            e.Column.AutoPostBackOnFilter = True
            e.Column.ShowFilterIcon = False
            e.Column.CurrentFilterFunction = GridKnownFunction.Contains
            If e.Column.UniqueName = "Stock" Or e.Column.UniqueName = "Venta" Or e.Column.UniqueName = "Decena" Or e.Column.UniqueName = "Centena" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right
            ElseIf e.Column.UniqueName = "Codigo" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
            End If

            If e.Column.UniqueName = "Grupo" Then
                If e.Column.CurrentFilterValue.ToString.Length > 0 Then
                    e.Column.CurrentFilterValue = e.Column.CurrentFilterValue
                ElseIf grupoFiltroProducto.Length > 1 Then
                    e.Column.CurrentFilterValue = grupoFiltroProducto
                ElseIf grupoFiltroProducto = "0" Then
                    e.Column.CurrentFilterValue = ""
                End If
            End If

            If e.Column.UniqueName = "Marca" Then
                If e.Column.CurrentFilterValue.ToString.Length > 0 Then
                    e.Column.CurrentFilterValue = e.Column.CurrentFilterValue
                ElseIf marcaFiltroProducto.Length > 1 Then
                    e.Column.CurrentFilterValue = marcaFiltroProducto
                ElseIf marcaFiltroProducto = "0" Then
                    e.Column.CurrentFilterValue = ""
                End If
            End If
        ElseIf Me.Request.QueryString("accion") = "Productos" Then
            e.Column.FilterControlWidth = Unit.Percentage(100)
            e.Column.AutoPostBackOnFilter = True
            e.Column.ShowFilterIcon = False
            e.Column.CurrentFilterFunction = GridKnownFunction.Contains
            If e.Column.UniqueName = "Stock" Or e.Column.UniqueName = "Venta" Or e.Column.UniqueName = "Decena" Or e.Column.UniqueName = "Centena" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right
            ElseIf e.Column.UniqueName = "Unidad" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
            End If

            If e.Column.UniqueName = "Grupo" Then
                If e.Column.CurrentFilterValue.ToString.Length > 0 Then
                    e.Column.CurrentFilterValue = e.Column.CurrentFilterValue
                ElseIf grupoFiltroProducto.Length > 1 Then
                    e.Column.CurrentFilterValue = grupoFiltroProducto
                ElseIf grupoFiltroProducto = "0" Then
                    e.Column.CurrentFilterValue = ""
                End If
            End If

            If e.Column.UniqueName = "Marca" Then
                If e.Column.CurrentFilterValue.ToString.Length > 0 Then
                    e.Column.CurrentFilterValue = e.Column.CurrentFilterValue
                ElseIf marcaFiltroProducto.Length > 1 Then
                    e.Column.CurrentFilterValue = marcaFiltroProducto
                ElseIf marcaFiltroProducto = "0" Then
                    e.Column.CurrentFilterValue = ""
                End If
            End If

        End If
        ColumnasOcultasArray = columnas_ocultas.Split(",")
        For i As Integer = 0 To UBound(ColumnasOcultasArray)
            If TypeOf e.Column Is GridBoundColumn AndAlso e.Column.UniqueName = ColumnasOcultasArray(i).ToString Then
                Dim column As GridBoundColumn = TryCast(e.Column, GridBoundColumn)
                column.Display = False
            End If
        Next i
    End Sub
    'Private Sub cargaFiltroSession(sender, e)
    '    Dim grupoFiltroProducto As String
    '    Dim marcaFiltroProducto As String
    '    grupoFiltroProducto = Session("grupoFiltroProducto").ToString
    '    marcaFiltroProducto = Session("marcaFiltroProducto").ToString
    '    ColumnasOcultasArray = columnas_ocultas.Split(",")
    '    For i As Integer = 0 To UBound(ColumnasOcultasArray)
    '        If TypeOf e.Column Is GridBoundColumn AndAlso e.Column.UniqueName = ColumnasOcultasArray(i).ToString Then
    '            Dim column As GridBoundColumn = TryCast(e.Column, GridBoundColumn)
    '            column.Display = False
    '        End If
    '    Next i
    '    'aki debe ir un parametros
    '    If Me.Request.QueryString("accion") = "Productos" Then

    '        e.Column.FilterControlWidth = Unit.Percentage(100)
    '        e.Column.AutoPostBackOnFilter = True
    '        e.Column.ShowFilterIcon = False
    '        e.Column.CurrentFilterFunction = GridKnownFunction.Contains

    '        If e.Column.UniqueName = "Stock" Then
    '            e.Column.HeaderStyle.Width = Unit.Pixel(70)
    '        End If

    '        If e.Column.UniqueName = "Grupo" Then
    '            'If grupoFiltroProducto <> "0" Then
    '            e.Column.CurrentFilterValue = grupoFiltroProducto
    '            '    'Else
    '            '    '    e.Column.CurrentFilterValue = ""
    '            'End If
    '        End If

    '        If e.Column.UniqueName = "Marca" Then
    '            'If marcaFiltroProducto <> "0" Then
    '            e.Column.CurrentFilterValue = marcaFiltroProducto
    '            '    'Else
    '            '    '    e.Column.CurrentFilterValue = ""
    '            'End If
    '        End If

    '    End If
    '    'hasta aki
    'End Sub

    'Private Sub RadGrid_Principal_ItemDataBound(ByVal sender As Object, e As GridItemEventArgs) Handles RadGrid_Principal.ItemDataBound
    '    If Me.Request.QueryString("accion") = "Productos" Then
    '        For Each item As GridDataItem In RadGrid_Principal.Items
    '            Dim nomEstado As String = item("Nombre").Text
    '            Dim LinkEstado As HyperLink = DirectCast(item("TemplateLinkNombre").FindControl("LinkNombre"), HyperLink)
    '            LinkEstado.Font.Bold = True
    '            LinkEstado.Text = nomEstado
    '            LinkEstado.NavigateUrl = "#"
    '        Next
    '        Dim target As Control = e.Item.FindControl("LinkNombre")
    '        If Not [Object].Equals(target, Nothing) Then
    '            If Not [Object].Equals(Me.RadToolTipManager1, Nothing) Then
    '                Me.RadToolTipManager1.TargetControls.Add(target.ClientID, (TryCast(e.Item, GridDataItem)).GetDataKeyValue("ID").ToString(), True)
    '            End If
    '        End If

    '        RadGrid_Principal.MasterTableView.GetColumn("Nombre").Display = False
    '        RadGrid_Principal.MasterTableView.GetColumn("TemplateLinkNombre").Display = True
    '    End If
    'End Sub

    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub

    Private Sub UpdateToolTip(ByVal elementID As String, ByVal panel As UpdatePanel)
        Dim ctrl As Control = Page.LoadControl("ToolTipProductVenta.ascx")
        ctrl.ID = "UcProductDetails1"
        panel.ContentTemplateContainer.Controls.Add(ctrl)
        Dim details As ToolTipProductVenta = DirectCast(ctrl, ToolTipProductVenta)
        details.productoID = elementID
    End Sub

    Protected Sub borrarFiltro_Click(sender As Object, e As EventArgs) Handles borrarFiltro.Click
        Session("grupoFiltroProducto") = "0"
        Session("marcaFiltroProducto") = "0"
        For Each column As GridColumn In RadGrid_Principal.MasterTableView.AutoGeneratedColumns
            column.CurrentFilterFunction = GridKnownFunction.NoFilter
            column.CurrentFilterValue = String.Empty
        Next
    End Sub

End Class