Imports Telerik.Web.UI
Imports CominWeb.SW_coneccionDB

Public Class Ctrl_GrillaEmergente
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
    Dim SW_Equipo As New SW_Equipo_DA
    Dim SW_EquipoDT As New DataTable
    Dim SW_planManto As New SW_planMantto_DA

    Private Sub Ctrl_GrillaEmergente_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        SW_EjecutaSQLDT = SW_EjecutaSQLDA.P_selectParametroByID(14)
        If SW_EjecutaSQLDT.Rows(0).Item(2).ToString = 1 Then
            txt_buscar.Text = Request.QueryString("texto_digitado").ToString
        Else
            txt_buscar.Text = ""
        End If
        txt_buscar.Focus()
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
        If Me.Request.QueryString("accion") = "Productos" Or Me.Request.QueryString("accion") = "ProductosFacturacion" Or Me.Request.QueryString("accion") = "ProductosAjusteStock" Then
            RadGrid_Principal.MasterTableView.AllowFilteringByColumn = True
        End If
        'hasta aki
        'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AjustarVentana", "SizeToFit();", True)

        Select Case accion
            Case "Cargo"
                Me.Page.Title = "Seleccionar o Agregar :: Cargos "
                tabla = "tblCargo"
                columnas = "[cargoID] AS 'ID', [nombre] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[cargoID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10

                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
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
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '% nadaquebuscaraqui %') ORDER BY " & identificador.ToString & " ASC"
                Else '
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "Pais"
                Me.Page.Title = "Seleccionar o Agregar :: Pais "
                tabla = "tblPaises"
                columnas = "[paisID] AS 'ID', [nombrePais] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombrePais]"
                columna_buscar_numero = "[paisID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10

                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Marca_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar ::  Grupo"
                tabla = "tblGrupo"
                columnas = "[marcaID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[marcaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "subGrupo_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Sub Grupo "
                tabla = "tblSubGrupo"
                columnas = "[subGrupoID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[subGrupoID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "MarcaEspecifico_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Marca "
                tabla = "tblMarca"
                columnas = "[marcaID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[marcaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE tipo = 1 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipo = 1 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "raza_sin_inicio"
                tabla = "tblMarca"
                columnas = "[marcaID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[marcaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipo = 3 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipo = 3 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "especie_sin_inicio"
                tabla = "tblMarca"
                columnas = "[marcaID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[marcaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipo = 4 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipo = 4 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "colores_sin_inicio"
                tabla = "tblMarca"
                columnas = "[marcaID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[marcaID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipo = 5 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipo = 5 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & columna_mostrar.ToString & " ASC"
                End If
            Case "UnidadMedida_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Unidad de Medida "
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
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoUnidadMedidaID = 1 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoUnidadMedidaID = 1 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "GrupoFuncion_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Grupo Función "
                tabla = "tblGrupoFuncion"
                columnas = "[grupoFuncionID] AS 'ID', [codigo] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[grupoFuncionID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%')  ORDER BY codigo ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY codigo ASC"
                End If
            Case "Ubicacion_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Ubicación "
                tabla = "tblUbicacionProducto"
                columnas = "[ubicacionID] AS 'ID', [codubicacion] AS 'Codigo',[nombre] AS 'Nombre',[descripcion] AS 'Descripcion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[ubicacionID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') AND " &
                " sucursalID = " & Session("IDSucursalPrincipal").ToString.Trim &
                " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') AND " &
                " sucursalID = " & Session("IDSucursalPrincipal").ToString.Trim &
                " ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Propietario_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Propietario "
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 1 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 1 AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Proveedor_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Proveedor "
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') OR ( " &
                                   "razoncomercial COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Proveedor_sin_inicio1"
                Me.Page.Title = "Seleccionar o Agregar :: Proveedor "
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') OR ( " &
                                   "razoncomercial COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Proveedor_sin_inicio2"
                Me.Page.Title = "Seleccionar o Agregar :: Proveedor "
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Ruc"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') OR ( " &
                                   "razoncomercial COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Trabajador_sin_inicio"
                Me.Page.Title = "Seleccionar :: Trabajador "
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
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%' AND trabajadorID <> " & excluir &
                " AND tblTrabajador.estado = 0) AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR apaterno LIKE '%" & txt_buscar.Text &
                "%' OR amaterno LIKE '%" & txt_buscar.Text & "%' ) AND trabajadorID <> " & excluir &
                " AND tblTrabajador.estado = 0  AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                " ORDER BY " &
                identificador.ToString & " ASC"
                End If
            Case "Mecanico_sin_inicio"
                Me.Page.Title = "Seleccionar :: Trabajador "
                tabla = "tblTrabajador INNER JOIN tblTipoDocumento on tbltrabajador.tipoDocumentoID = tblTipoDocumento.tipoDocumentoID"
                columnas = "[trabajadorID] AS 'ID', apaterno + ' ' + amaterno + ' ' + nombres AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombres]"
                columna_buscar_numero = "[nroDocumento]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                Dim excluir As String
                If Not Request.QueryString("excluir") Is Nothing Then
                    excluir = Request.QueryString("excluir")
                Else
                    excluir = 0
                End If
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%' AND trabajadorID NOT IN (SELECT nstr FROM dbo.iter_charlist_to_table('" & excluir & "', ',') AS I)" &
                " AND tblTrabajador.estado = 0) AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR apaterno LIKE '%" & txt_buscar.Text &
                "%' OR amaterno LIKE '%" & txt_buscar.Text & "%' ) AND trabajadorID NOT IN (SELECT nstr FROM dbo.iter_charlist_to_table('" & excluir & "', ',') AS I)" &
                " AND tblTrabajador.estado = 0  AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                " ORDER BY " &
                identificador.ToString & " ASC"
                End If
            Case "eligMec_sin_inicio"
                Me.Page.Title = "Seleccionar :: Asignado "
                tabla = "tblTrabajador INNER JOIN tblTipoDocumento on tbltrabajador.tipoDocumentoID = tblTipoDocumento.tipoDocumentoID"
                columnas = "[trabajadorID] AS 'ID', apaterno + ' ' + amaterno + ' ' + nombres AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombres]"
                columna_buscar_numero = "[nroDocumento]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                Dim excluir As String
                If Not Request.QueryString("excluir") Is Nothing Then
                    excluir = Request.QueryString("excluir")
                Else
                    excluir = 0
                End If
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%' AND trabajadorID IN (SELECT nstr FROM dbo.iter_charlist_to_table('" & excluir & "', ',') AS I)" &
                " AND tblTrabajador.estado = 0) AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR apaterno LIKE '%" & txt_buscar.Text &
                "%' OR amaterno LIKE '%" & txt_buscar.Text & "%' ) AND trabajadorID IN (SELECT nstr FROM dbo.iter_charlist_to_table('" & excluir & "', ',') AS I)" &
                " AND tblTrabajador.estado = 0  AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                " ORDER BY " &
                identificador.ToString & " ASC"
                End If
            Case "Trabajador_sin_usuarios"
                Me.Page.Title = "Seleccionar :: Trabajador "
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
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') AND trabajadorID <> " &
                excluir & " AND tblTipoDocumento.estado = 0 AND tblTrabajador.trabajadorID not in (SELECT trabajadorID from tblusuarios)  " &
                " AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString & " ORDER BY apaterno ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR apaterno LIKE '%" & txt_buscar.Text &
                "%' OR amaterno LIKE '%" & txt_buscar.Text & "%' ) AND trabajadorID <> " & excluir &
                " AND tblTipoDocumento.estado = 0 AND tblTrabajador.trabajadorID not in (SELECT trabajadorID from tblusuarios) " &
                " AND tblTrabajador.sucursalID = " & Session("IDSucursalPrincipal").ToString & " ORDER BY apaterno ASC"
                End If
            Case "Equipo_sin_inicio"
                Me.Page.Title = "Seleccionar :: Equipo "
                tabla = " dbo.tblEquipo INNER JOIN" &
                      " dbo.tblModelo ON dbo.tblEquipo.modeloID = dbo.tblModelo.modeloID LEFT OUTER JOIN" &
                      " dbo.tblTipoEquipo LEFT OUTER JOIN" &
                      " dbo.tblMarca ON dbo.tblTipoEquipo.marcaID = dbo.tblMarca.marcaID ON dbo.tblModelo.tipoEquipoID = dbo.tblTipoEquipo.tipoEquipoID"
                columnas = " top 50 [equipoID] AS 'ID', tblEquipo.codigo AS 'Codigo Equipo', nroPlaca AS 'N° Placa',  dbo.tblMarca.nombre as 'Marca', " &
                    " dbo.tblTipoEquipo.nombre as 'Tipo', tblmodelo.nombre AS 'Modelo', nroSerie as 'Serie'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "tblEquipo.codigo"
                columna_buscar_numero = "tblEquipo.codigo"
                identificador = "ID"
                columna_mostrar = "Codigo Equipo"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text &
                "%' OR dbo.tblTipoEquipo.nombre LIKE '%" & txt_buscar.Text &
                "%' AND tblEquipo.estado = 0) AND tblEquipo.sucursalID = " &
                Session("IDSucursalPrincipal").ToString & " ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text &
                "%' OR dbo.tblTipoEquipo.nombre LIKE '%" & txt_buscar.Text &
                "%' AND tblEquipo.estado = 0) AND tblEquipo.sucursalID = " &
                Session("IDSucursalPrincipal").ToString & " ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "LugarTrabajo_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Lugar de Trabajo "
                tabla = "tblLugarTrabajo"
                columnas = "[lugarTrabajoID] AS 'ID', [nombre] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                columna_buscar_numero = "[lugarTrabajoID]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE  sucursalID = " & Session("IDSucursalPrincipal").ToString & " and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE  sucursalID = " & Session("IDSucursalPrincipal").ToString & " and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If

            Case "TipoCombustible"
                '0 ES FACTURAR, 1 ES STOCK
                Me.Page.Title = "Seleccionar :: Tipo de Combustible "
                If Me.Request.QueryString("descuentoID").ToString.Trim = 0 Then
                    tabla = " dbo.tblProducto INNER JOIN " &
                    " tblProductoBase ON tblProducto.productoBaseID = tblProductoBase.productoBaseID INNER JOIN " &
                    " dbo.tblGrupoFuncion ON dbo.tblProductoBase.grpoFuncionID = dbo.tblGrupoFuncion.grupoFuncionID "
                    columnas = " dbo.tblProducto.productoID AS 'ID', dbo.tblProductoBase.codproducto AS Codigo, " &
                        " dbo.tblProductoBase.nombre AS 'Nombre',dbo.tblGrupoFuncion.nombre AS 'Grupo Funcion' "
                    columnas_ocultas = "ID"
                    columna_buscar_letra = "tblProductoBase.nombre"
                    columna_buscar_numero = "[productoID]"
                    identificador = "ID"
                    columna_mostrar = "Nombre"
                    filas = 10
                    If Session("almacenAsignadoPrincipal").ToString > 0 Then
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND CAST(tblProductoBase.grupoID AS INT) = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND CAST(tblProductoBase.grupoID AS INT) = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    Else
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND CAST(tblProductoBase.grupoID AS INT) = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND CAST(tblProductoBase.grupoID AS INT) = (SELECT valor FROM tblParametros WHERE parametrogeneralID = 12 ) " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    End If
                ElseIf Me.Request.QueryString("descuentoID").ToString.Trim = 1 Then
                    tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA " &
                        " ON dbo.tblProducto.productoBaseID = PROBA.productoBaseID RIGHT OUTER JOIN " &
                        " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                    columnas = " dbo.tblProducto.productoID AS 'ID', PROBA.codproducto AS Codigo, PROBA.nombre AS " &
                        "'Nombre', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                        " SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                    columnas_ocultas = "ID"
                    columna_buscar_letra = "PROBA.nombre"
                    columna_buscar_numero = "[productoID]"
                    identificador = "ID"
                    columna_mostrar = "Nombre"
                    filas = 10
                    If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY PROBA.nombre ASC"
                        End If
                    Else
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                        "  AND(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                        " AND (PROBA.grupoID = (SELECT valor FROM dbo.tblParametros WHERE (parametroGeneralID = 12))) " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    End If
                End If
            Case "Productos"
                Me.Page.Title = "Seleccionar :: Producto "
                Dim grupoSQL As String
                SW_EjecutaSQLDT = SW_EjecutaSQLDA.P_selectParametroByID(56)
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                If SW_EjecutaSQLDT.Rows(0).Item(2) = 1 Then
                    columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    "dbo.F_nomTblMarca(PROBA.marcaID) as 'Marca', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', " &
                "dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' , SUM(dbo.tblInventarios.cantidad) AS 'Stock' "

                    grupoSQL = " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, PROBA.marcaID, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID "
                Else
                    columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', " &
                "dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' , SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                    grupoSQL = " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID "
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
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text &
                        "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY PROBA.nombre ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ProductosAjusteStock"
                Me.Page.Title = "Seleccionar :: Producto "
                Dim grupoSQL As String
                SW_EjecutaSQLDT = SW_EjecutaSQLDA.P_selectParametroByID(56)
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                If SW_EjecutaSQLDT.Rows(0).Item(2) = 1 Then
                    columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    "dbo.F_nomTblMarca(PROBA.marcaID) as 'Marca', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', " &
                "dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' , SUM(dbo.tblInventarios.cantidad) AS 'Stock' "

                    grupoSQL = " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, PROBA.marcaID, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID "
                Else
                    columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', " &
                "dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' , SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                    grupoSQL = " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID "
                End If

                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                SW_EjecutaSQLDT = SW_EjecutaSQLDA.P_selectParametroByID(60) ' VENTA SIN STOCK 0 si, 1 no
                filas = 10
                'FALTA AGREGAR UN PARAMETRO PARA CONTROLAR :: dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 
                '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                If SW_EjecutaSQLDT.Rows(0).Item(2) = 1 Then
                    If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) >= 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text &
                        "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) >= 0 " &
                        " ORDER BY PROBA.nombre ASC"
                        End If
                    Else
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) >= 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " HAVING SUM(dbo.tblInventarios.cantidad) >= 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    End If
                Else
                    If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text &
                        "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " ORDER BY PROBA.nombre ASC"
                        End If
                    Else
                        If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " ORDER BY " & identificador.ToString & " ASC"
                        Else ' busca en la coluna columna_buscar_letra
                            SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " & grupoSQL &
                        " ORDER BY " & identificador.ToString & " ASC"
                        End If
                    End If
                End If
            Case "ProductosConSinStock"
                Me.Page.Title = "Seleccionar :: Producto "
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto as 'Fabricante', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%' ) " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codigoProducto, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codigoProducto, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " ORDER BY PROBA.nombre ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.codigoProducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.codigoProducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ProductosFacturacion"
                Me.Page.Title = "Seleccionar :: Productos "
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID LEFT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                If Me.Request.QueryString("css").ToString = False Then
                    columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto, dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                " tblgrupofuncion.nombre AS 'Grupo Funcion', " &
                " ISNULL(PROBA.codigoproducto,'') as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' "
                Else
                    columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto, dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " &
                    " ISNULL(PROBA.codigoproducto,'') as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(ISNULL(dbo.tblInventarios.cantidad, 0)) AS 'Stock' "
                End If

                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY PROBA.nombre ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                    "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                End If
            Case "ProductosFacturacionNR"
                Me.Page.Title = "Seleccionar :: Productos "
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID LEFT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(ISNULL(dbo.tblInventarios.cantidad, 0)) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY PROBA.nombre ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                    "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                End If
            Case "ProductosFacturacionEQ"
                Me.Page.Title = "Seleccionar :: Productos "
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID LEFT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto, dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(ISNULL(dbo.tblInventarios.cantidad, 0)) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY PROBA.nombre ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                    "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY PROBA.codigoProducto, dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                        '" HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    End If
                End If
            Case "ProductosAll"
                Me.Page.Title = "Seleccionar :: Productos "
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID INNER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID',PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre'" &
                    ", dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', tblgrupofuncion.nombre AS 'Grupo', SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                    "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "Contenedor_sin_inicio"
                Me.Page.Title = "Seleccionar :: Contenedor "
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
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE  (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Cliente_sin_inicio"
                Me.Page.Title = "Seleccionar :: Cliente "
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "top 30 [propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 3 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 3 AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Cliente_sin_inicio2"
                Me.Page.Title = "Seleccionar :: Cliente"
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Ruc"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 3 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoSave = 3 AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Cliente_sin_inicio3"
                Me.Page.Title = "Seleccionar :: Cliente "
                tabla = "tblPropietarioProveedorClienteSubcontrata"
                columnas = "[propietarioProveedorID] AS 'ID', [razonsocial] AS 'Razon Social',[razoncomercial] AS 'Razon Comercial',[ruc] AS 'Ruc'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[razonsocial]"
                columna_buscar_numero = "[ruc]"
                identificador = "ID"
                columna_mostrar = "Razon Social"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoProveedorID = (select valor from tblParametros where parametroGeneralID = 34) and tipoSave = 2 AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE tipoProveedorID = (select valor from tblParametros where parametroGeneralID = 34) and tipoSave = 2 AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "TiempoEstandar"
                Me.Page.Title = "Seleccionar o Agregar :: Actividad"
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
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE  (" & columna_buscar_numero.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                End If
            Case "Productos1"
                Me.Page.Title = "Seleccionar :: Productos"
                tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " &
                    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" &
                    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID',tblProducto.codproducto as Codigo,tblProducto.nombre AS 'Nombre'" &
                    ", dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', tblgrupofuncion.nombre AS 'Grupo', SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "tblProducto.codproducto"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Session("almacenAsignadoPrincipal").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE dbo.tblProducto.estado = 0 and dbo.tblInventarios.almacenID = " & Session("almacenAsignadoPrincipal").ToString.Trim & " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                    " GROUP BY dbo.tblProducto.productoID, dbo.tblProducto.codproducto, dbo.tblProducto.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID " &
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ordenesCompra_sin_inicio"
                Me.Page.Title = "Seleccionar :: Ordenes de Compra "
                tabla = " dbo.tblOrdenesCompra AS OC LEFT OUTER JOIN " &
                        " dbo.tblUsuarios AS US ON OC.usuarioIDaprueba = US.usuarioID "
                columnas = " OC.OrdenCompraID AS 'ID', OC.codigo AS 'NRO. ORDEN', CONVERT(VARCHAR(10),OC.fechaOrden,103) AS 'F. ORDEN', " &
                    " UPPER(US.nombreUser) AS 'APROBADO POR', CONVERT(VARCHAR(10),OC.fechaAprobacion,103) AS 'F. APROBAC.', OC.glosaAprueba AS 'GLOSA' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "OC.codigo"
                columna_buscar_numero = "OC.OrdenCompraID"
                identificador = "ID"
                columna_mostrar = "NRO. ORDEN"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (OC.estado = 3) AND (OC.compraID IS NULL) AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                " ORDER BY OC.fechaAprobacion DESC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE (OC.estado = 3) AND (OC.compraID IS NULL) AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " &
                " ORDER BY OC.fechaAprobacion DESC"
                End If
            Case "Cotizaciones_sin_inicio"
                Me.Page.Title = "Seleccionar :: Cotización"
                tabla = " tblCotizacion "
                columnas = " Codigo, dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) 'Cliente', " &
                    " dbo.F_CodigoByEquipoID(equipoID) 'Equipo', ordenCompraCliente 'Orden de Compra', " &
                    " dbo.F_codOrdenTrabajo(ordenServicioIDRef) 'OT' "
                columna_buscar_letra = " dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) "
                columna_buscar_numero = "ordenCompraCliente"
                identificador = "Orden de Compra"
                columna_mostrar = "Codigo"
                filas = 10

                Dim estalog As Integer = SW_EjecutaSQLDA.P_selectParametroByID(62).Rows(0).Item(2).ToString
                If estalog = 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' AND dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " &
                    " ORDER BY Codigo DESC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' AND dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " &
                    " ORDER BY Codigo DESC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' " &
                    " ORDER BY Codigo DESC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' " &
                    " ORDER BY Codigo DESC"
                    End If
                End If
            Case "Contacto_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Contacto"
                tabla = "tblContacto"
                columnas = "[contactoID] AS 'ID', dbo.F_nomTblCargo(cargoID) AS 'Cargo', [nombre] AS 'Nombre'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "[nombre]"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE estado = 0 and propietarioProveedorID = " & Me.Request.QueryString("RazonSocialID").ToString &
                " AND (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY nombre ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE estado = 0 and propietarioProveedorID = " & Me.Request.QueryString("RazonSocialID").ToString &
                " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY nombre ASC"
                End If
            Case "ordenTrabajo_sin_inicio"
                Me.Page.Title = "Seleccionar :: Orden de Trabajo"
                tabla = "tblOrdenServicio"
                columnas = "top 30 [ordenServicioID] AS 'ID', codigo AS 'OT', dbo.F_CodigoByEquipoID(equipoID) AS 'Equipo', dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) AS 'Cliente'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "codigo"
                identificador = "ID"
                columna_mostrar = "OT"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE ISNULL(cotizado,0) = 0 AND estado <> 2 and " &
                    "(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' " &
                    " OR dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " &
                    " OR dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID)  LIKE '%" & txt_buscar.Text & "%' )" &
                    "ORDER BY fechaApertura DESC"
            Case "ordenTrabajoTODO_sin_inicio"
                Me.Page.Title = "Seleccionar :: Orden de Trabajo"
                tabla = "tblOrdenServicio"
                columnas = " TOP 30 [ordenServicioID] AS 'ID', codigo AS 'OT', dbo.F_CodigoByEquipoID(equipoID) AS 'Equipo', dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) AS 'Cliente'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "codigo"
                identificador = "ID"
                columna_mostrar = "OT"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
            " WHERE estado <> 2 and " &
            "(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' " &
            " OR dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " &
            " OR dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID)  LIKE '%" & txt_buscar.Text & "%' )" &
            " ORDER BY fechaApertura DESC"
                'End If
            Case "Compras_sin_inicio"
                tabla = "dbo.tblCompra AS CO INNER JOIN" &
                            " dbo.tblPropietarioProveedorClienteSubcontrata AS " &
                            " PROV ON CO.propietarioProveedorID = PROV.propietarioProveedorID "
                columnas = "TOP 20 CO.compraID, CO.codigo [Codigo], PROV.razonsocial [Cliente], " &
                        "CASE WHEN CO.monedaID = 1 THEN 'S/.' ELSE '$' END AS Moneda, " &
                        "dbo.F_nomTblTipoDocumento(CO.tipoDocumento) AS Documento, CO.nroSerieDocumento + '-' + " &
                        " CO.numeroDocumento AS Numero, convert(varchar(20),CO.fechaFacturaCompra,103) [F.Emision], " &
                        "CO.glosaCompra [Glosa], cast((CO.SubTotal * CO.tipocambio) as decimal(18,2)) as SubTotal, " &
                        "cast((CO.IGVval * CO.tipocambio) as decimal(18,2)) as IGV, " &
                        "cast((CO.SubTotal * CO.tipocambio) + (CO.IGVval * CO.tipocambio) as decimal(18,2)) AS Total "
                columnas_ocultas = "compraID"
                columna_buscar_letra = "Codigo"
                identificador = "compraID"
                columna_mostrar = "Codigo"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE CO.nroSerieDocumento + '-' + CO.numeroDocumento LIKE '%" & txt_buscar.Text & "%' ORDER BY fechaFacturaCompra DESC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE CO.nroSerieDocumento + '-' + CO.numeroDocumento LIKE '%" & txt_buscar.Text & "%' ORDER BY fechaFacturaCompra DESC"
                End If
            Case "tipoEquipo_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Tipo de Equipo"
                tabla = " dbo.tblTipoEquipo"
                columnas = "top 30 LTRIM(RTRIM(dbo.tblTipoEquipo.tipoEquipoID)) AS tipoEquipoID, dbo.tblTipoEquipo.Codigo, " &
                "dbo.tblTipoEquipo.nombre as Nombre, dbo.tblTipoEquipo.Descripcion "
                columnas_ocultas = "tipoEquipoID"
                columna_buscar_letra = "dbo.tblTipoEquipo.nombre"
                identificador = "tipoEquipoID"
                columna_mostrar = "Nombre"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE familiaID = " & Me.Request.QueryString("familia").ToString & " and dbo.tblTipoEquipo.estado = 0 and dbo.tblTipoEquipo.nombre LIKE '%" & txt_buscar.Text & "%' ORDER BY dbo.tblTipoEquipo.nombre ASC"

            Case "modeloEquipo_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Modelo de Equipo"
                tabla = " dbo.tblModelo INNER JOIN dbo.tblTipoEquipo ON dbo.tblModelo.tipoEquipoID = dbo.tblTipoEquipo.tipoEquipoID "
                columnas = " dbo.tblModelo.modeloID AS 'ID', dbo.tblTipoEquipo.nombre AS 'Tipo Equipo', dbo.tblModelo.codigo, dbo.tblModelo.nombre AS Nombre, dbo.tblModelo.descripcion "
                columnas_ocultas = "ID"
                columna_buscar_letra = "dbo.tblModelo.nombre"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
            " WHERE dbo.tblModelo.estado = 0 and dbo.tblModelo.nombre LIKE '%" & txt_buscar.Text & "%' " &
            " AND dbo.tblTipoEquipo.tipoEquipoID = '" & Me.Request.QueryString("tipoEquipo").ToString & "' ORDER BY dbo.tblModelo.nombre ASC"

            Case "familiaEquipo_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Familia Equipo "
                tabla = " dbo.tblFamiliaEquipo as fae"
                columnas = " fae.familiaID AS 'ID', fae.nombre AS 'Familia Equipo', fae.descripcion as 'Descripcion' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "fae.nombre"
                identificador = "ID"
                columna_mostrar = "Familia Equipo"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
            " WHERE fae.estado = 0 and fae.nombre LIKE '%" & txt_buscar.Text & "%' " &
            " ORDER BY fae.nombre ASC"
            Case "especialidad_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Especialidad"
                tabla = " dbo.tblEspecialidades as fae"
                columnas = " fae.especialidadID AS 'ID', fae.nombre AS 'Especialidad', fae.descripcion as 'Descripcion' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "fae.nombre"
                identificador = "ID"
                columna_mostrar = "Especialidad"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
            " WHERE fae.estado = 0 and fae.nombre LIKE '%" & txt_buscar.Text & "%' ORDER BY fae.nombre ASC"
            Case "tiposistema_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Sistema Equipo "
                SW_EquipoDT = SW_Equipo.P_selectTipoEquipo(0, 0, 0, Me.Request.QueryString("nofamilia").ToString)
                ViewState("tipoEquipoTS") = SW_EquipoDT.Rows(0).Item(0).ToString
                tabla = " tblTipoSistema TS "
                columnas = " TS.tipoSistemaID as 'ID', TS.nombre AS 'Nombre'  "
                columnas_ocultas = "ID"
                columna_buscar_letra = "TS.nombre"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
            " WHERE TS.estado = 0 and TS.nombre LIKE '%" & txt_buscar.Text & "%' and TS.tipoEquipoID = " & SW_EquipoDT.Rows(0).Item(0).ToString & " " &
            " ORDER BY TS.nombre ASC"
            Case "planManti_sin_inicio"
                guardarB.Enabled = False
                Me.Page.Title = "Seleccionar :: Plan de Mantto. "
                tabla = " dbo.tblPlanMantto AS pma INNER JOIN dbo.tblFamiliaEquipo ON pma.familiaID = dbo.tblFamiliaEquipo.familiaID"
                columnas = "pma.planManttoID 'ID', pma.codigo, dbo.tblFamiliaEquipo.nombre AS Familia, pma.nombre AS 'Nombre', pma.cantPersonas 'Personas', pma.Observaciones"
                columnas_ocultas = "ID"
                columna_buscar_letra = "fae.nombre"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE pma.planManttoID not in (select planManttoID from tblAsignacionEquipo where equipoID = " & Me.Request.QueryString("equii").ToString &
                " and estado = 0) and pma.estado = 0 and pma.nombre LIKE '%" & txt_buscar.Text & "%' " &
                " and pma.familiaID = " & Me.Request.QueryString("famiid") & " and pma.tipoPlan = " & Me.Request.QueryString("splan") &
                " ORDER BY pma.nombre ASC"
            Case "planMantiGeneral_sin_inicio"
                guardarB.Enabled = False
                Me.Page.Title = "Seleccionar :: Plan de Mantto. "
                tabla = " dbo.tblPlanMantto AS pma INNER JOIN dbo.tblFamiliaEquipo ON pma.familiaID = dbo.tblFamiliaEquipo.familiaID"
                columnas = "pma.planManttoID 'ID', pma.codigo, dbo.tblFamiliaEquipo.nombre AS Familia, pma.nombre AS 'Nombre', pma.cantPersonas 'Personas', pma.Observaciones"
                columnas_ocultas = "ID"
                columna_buscar_letra = "fae.nombre"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                Dim tipoPlan As String
                If Me.Request.QueryString("tipochl") = "CA" Then
                    tipoPlan = 2
                Else
                    tipoPlan = 1
                End If
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE pma.estado = 0 and pma.nombre LIKE '%" & txt_buscar.Text & "%' " &
                " and pma.familiaID = " & Me.Request.QueryString("famiid") & " and pma.tipoPlan = " & tipoPlan.ToString &
                " ORDER BY pma.nombre ASC"
            Case "planMantiByEq_sin_inicio"
                guardarB.Enabled = False
                Me.Page.Title = "Seleccionar :: Plan de Mantto."
                tabla = " dbo.tblPlanMantto AS pma INNER JOIN dbo.tblFamiliaEquipo ON pma.familiaID = dbo.tblFamiliaEquipo.familiaID"
                columnas = "pma.planManttoID 'ID', pma.codigo, dbo.tblFamiliaEquipo.nombre AS Familia, pma.nombre AS 'Nombre', pma.cantPersonas 'Personas', pma.Observaciones"
                columnas_ocultas = "ID"
                columna_buscar_letra = "fae.nombre"
                identificador = "ID"
                columna_mostrar = "Nombre"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE pma.planManttoID in (select planManttoID from tblAsignacionEquipo where estadoAprob = 3 and equipoID = " & Me.Request.QueryString("equii").ToString &
                " and estado = 0) and pma.estado = 0 and pma.nombre LIKE '%" & txt_buscar.Text & "%' ORDER BY pma.nombre ASC"
            Case "ProductosPlanMantto"
                Me.Page.Title = "Seleccionar :: Producto "
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " &
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " &
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " &
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto as 'Fabricante', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " &
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " &
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10

                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%' ) " &
                        " AND PROBA.grupoID = " & Me.Request.QueryString("grupohqs").ToString() &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codigoProducto, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        '" WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim &
                        " AND (" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " &
                        " AND PROBA.grupoID = " & Me.Request.QueryString("grupohqs").ToString() &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codigoProducto, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " ORDER BY PROBA.nombre ASC"
                    End If
                Else
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString &
                        " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " &
                        " AND PROBA.grupoID = " & Me.Request.QueryString("grupohqs").ToString() &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.codigoProducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT TOP 50 " & columnas.ToString & " FROM " & tabla.ToString &
                        " WHERE dbo.tblProducto.estado = 0 AND dbo.tblProducto.sucursalID =  " & Session("IDSucursalPrincipal").ToString &
                        "  AND(" & columna_buscar_letra.ToString & " COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI LIKE '%" & txt_buscar.Text & "%') " &
                        " AND PROBA.grupoID = " & Me.Request.QueryString("grupohqs").ToString() &
                        " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.codigoProducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " &
                        " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " &
                        " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "area_sin_inicio"
                Me.Page.Title = "Seleccionar o Agregar :: Area"
                tabla = " dbo.tblAreas as fae"
                columnas = " fae.areaID AS 'ID', fae.nombre AS 'Area', fae.descripcion as 'Descripcion' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "fae.nombre"
                identificador = "ID"
                columna_mostrar = "Area"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
            " WHERE fae.estado = 0 and fae.nombre LIKE '%" & txt_buscar.Text & "%' ORDER BY fae.nombre ASC"
            Case "repuestoMeca_tablesin_inicio"
                guardarB.Enabled = False
                Me.Page.Title = "Seleccionar :: Repuesto"
                tabla = " dbo.tblRegistroFallaDetalle AS RFD INNER JOIN dbo.tblUnidadMedida AS UM ON RFD.unidadMedidaID = UM.unidadMedidaID"
                columnas = "RFD.registroFallaDetalleID 'ID', RFD.codRepuesto 'Codigo', RFD.nomRepuesto 'Repuesto', UM.nombre 'UN', RFD.consideraciones 'Consideracion'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "RFD.nomRepuesto"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE RFD.registroFallaID = " & Me.Request.QueryString("regid").ToString &
                " and RFD.nomRepuesto LIKE '%" & txt_buscar.Text & "%' ORDER BY RFD.nomRepuesto ASC"
            Case "correctivo_sin_inicio"
                guardarB.Enabled = False
                Me.Page.Title = "Seleccionar :: Falla"
                tabla = " dbo.tblRegistroFalla AS ORSE INNER JOIN dbo.tblPrioridad ON ORSE.tipoFalla = dbo.tblPrioridad.prioridadID " &
                        "INNER JOIN dbo.tblTipoSistema ON ORSE.tipoSistemaID = dbo.tblTipoSistema.tipoSistemaID"
                columnas = "ORSE.registroFallaID 'ID', ORSE.Codigo, convert(varchar(10),ORSE.registroFalla,103) Fecha, dbo.tblPrioridad.nombre Tipo, " &
                        "ORSE.Componente, dbo.tblTipoSistema.nombre Sistema, ORSE.Causas, ORSE.Evaluacion, ORSE.Solucion, ORSE.Comentarios, ORSE.RequiereParar, " &
                        "convert(varchar(10),ORSE.fechaEstimada,103) + ' ' + convert(varchar(5),ORSE.horaEstimada,108) Entrega"
                columnas_ocultas = "ID"
                columna_buscar_letra = "dbo.tblTipoSistema.nombre"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                " WHERE ORSE.estado = 1 AND ORSE.equipoID = " & Me.Request.QueryString("eqID").ToString &
                " AND ORSE.Codigo LIKE '%" & txt_buscar.Text & "%' ORDER BY ORSE.registroFallaID DESC"
            Case "mantoCorrectivo_sin_inicio"
                Me.Page.Title = "Seleccionar :: Mantto. Correctivo"
                tabla = "tblManttCorrectivo"
                columnas = "top 30 manttoCorrectivoID as 'ID', codigo as 'MCO', dbo.F_CodigoByEquipoID(equipoID) AS 'Equipo', dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) AS 'Cliente'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "codigo"
                identificador = "ID"
                columna_mostrar = "MCO"
                filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE estado = 0 and " &
                    "(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' " &
                    " OR dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " &
                    " OR dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID)  LIKE '%" & txt_buscar.Text & "%' )" &
                    "ORDER BY manttoCorrectivoID DESC"
            Case "TiempoEstandar_referenciaMantto"
                Me.Page.Title = "Seleccionar :: Referencia"
                Me.tabla = "tblPlanManttoDetalle PMD  INNER JOIN tblTiempoEstandarTrabajo TT ON PMD.tiempoEstandarTrabajoID = TT.tiempoEstandarTrabajoID LEFT OUTER JOIN dbo.tblUnidadMedida ON PMD.unidadMedidaID = dbo.tblUnidadMedida.unidadMedidaID "
                Me.columnas = "PMD.planManttoDetalleID ID, TT.nombre Actividades, dbo.F_nomTblTipoSistema(TT.tipoSistemaID) Sistema, CASE PMD.regimen WHEN 1 THEN 'FECHA' WHEN 2 THEN 'LECTURA' WHEN 3 THEN 'MIXTO' END AS Regimen, Case PMD.regimen WHEN 1 THEN LTRIM(STR(PMD.frecuenciaFecha)) + ' ' + CASE PMD.periodicidadFecha WHEN 1 THEN 'DIAS' WHEN 2 THEN 'SEMANAS' WHEN 3   THEN 'MESES' WHEN 4 THEN 'AÑOS' ELSE '' END WHEN 2 THEN LTRIM(STR(PMD.frecuenciaLectura)) + ' ' + dbo.tblUnidadMedida.abreviatura WHEN 3 THEN   LTrim(Str(PMD.frecuenciaFecha)) + ' ' + CASE PMD.periodicidadFecha WHEN 1 THEN 'DIAS' WHEN 2 THEN 'SEMANAS' WHEN 3 THEN 'MESES' WHEN 4 THEN 'AÑOS' ELSE '' END + ' ó ' + LTRIM(STR(PMD.frecuenciaLectura)) + ' ' + dbo.tblUnidadMedida.abreviatura END AS Frecuencia"
                Me.columnas_ocultas = "ID"
                Me.columna_buscar_letra = "nombre"
                Me.identificador = "ID"
                Me.columna_mostrar = "Actividades"
                Me.filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE PMD.tipo = 'A' and PMD.planManttoID = " & Request.QueryString("plan").ToString & " and PMD.usuarioID = " & Session("usuarioLoginID").ToString
            Case "TiempoEstandar_referenciaManttoMCO"
                Me.Page.Title = "Seleccionar :: Referencia"
                Me.tabla = "tblPlanManttoDetalle PMD  INNER JOIN tblTiempoEstandarTrabajo TT ON PMD.tiempoEstandarTrabajoID = TT.tiempoEstandarTrabajoID LEFT OUTER JOIN dbo.tblUnidadMedida ON PMD.unidadMedidaID = dbo.tblUnidadMedida.unidadMedidaID "
                Me.columnas = "PMD.planManttoDetalleID ID, TT.nombre Actividades, dbo.F_nomTblTipoSistema(TT.tipoSistemaID) Sistema, CASE PMD.regimen WHEN 1 THEN 'FECHA' WHEN 2 THEN 'LECTURA' WHEN 3 THEN 'MIXTO' END AS Regimen, Case PMD.regimen WHEN 1 THEN LTRIM(STR(PMD.frecuenciaFecha)) + ' ' + CASE PMD.periodicidadFecha WHEN 1 THEN 'DIAS' WHEN 2 THEN 'SEMANAS' WHEN 3   THEN 'MESES' WHEN 4 THEN 'AÑOS' ELSE '' END WHEN 2 THEN LTRIM(STR(PMD.frecuenciaLectura)) + ' ' + dbo.tblUnidadMedida.abreviatura WHEN 3 THEN   LTrim(Str(PMD.frecuenciaFecha)) + ' ' + CASE PMD.periodicidadFecha WHEN 1 THEN 'DIAS' WHEN 2 THEN 'SEMANAS' WHEN 3 THEN 'MESES' WHEN 4 THEN 'AÑOS' ELSE '' END + ' ó ' + LTRIM(STR(PMD.frecuenciaLectura)) + ' ' + dbo.tblUnidadMedida.abreviatura END AS Frecuencia"
                Me.columnas_ocultas = "ID"
                Me.columna_buscar_letra = "nombre"
                Me.identificador = "ID"
                Me.columna_mostrar = "Actividades"
                Me.filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE PMD.estado = 0 and PMD.tipo = 'A' and PMD.planManttoID = " & Request.QueryString("plan").ToString
            Case "referenciaPMG_sin_inicio"
                guardarB.Enabled = False
                If Me.Request.QueryString("splanc").ToString = 1 Then
                    Me.Page.Title = " Seleccionar :: Plan de CheckList E/R :: "
                ElseIf Me.Request.QueryString("splanc").ToString = 0 Then
                    Me.Page.Title = " Seleccionar :: Plan de Mantenimiento Preventivo :: "
                Else
                    Me.Page.Title = " Seleccionar :: Plan de CheckList para Calidad :: "
                End If

                Me.tabla = "dbo.tblPlanMantto AS pma INNER JOIN dbo.tblFamiliaEquipo ON pma.familiaID = dbo.tblFamiliaEquipo.familiaID "
                Me.columnas = "pma.planManttoID ID, CASE pma.tipoPlan WHEN 0 THEN 'MANT' WHEN 1 THEN 'CHL' WHEN 2 THEN 'CHLQ' END TIPO, dbo.tblFamiliaEquipo.nombre AS FAMILIA, pma.nombre AS 'PLAN'"
                Me.columnas_ocultas = "ID"
                Me.columna_buscar_letra = "PLAN"
                Me.identificador = "ID"
                Me.columna_mostrar = "PLAN"
                Me.filas = 10
                SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString &
                    " WHERE pma.estado = 0 and pma.tipoPlan = " & Me.Request.QueryString("splanc").ToString & " and pma.sucursalID = " & Session("IDSucursalPrincipal").ToString.Trim &
                    " and (pma.nombre LIKE '%" & txt_buscar.Text & "%' or dbo.tblFamiliaEquipo.nombre like '%" & txt_buscar.Text & "%')"
        End Select
        'ElseIf ((num = &H3246E639) AndAlso (s = "TiempoEstandar_referenciaMantto")) Then
        'Me.Page.Title = "Seleccionar :: Referencia"
        'Me.tabla = "tblPlanManttoDetalle PMD  INNER JOIN tblTiempoEstandarTrabajo TT ON PMD.tiempoEstandarTrabajoID = TT.tiempoEstandarTrabajoID LEFT OUTER JOIN dbo.tblUnidadMedida ON PMD.unidadMedidaID = dbo.tblUnidadMedida.unidadMedidaID "
        'Me.columnas = "PMD.planManttoDetalleID ID, TT.nombre Actividades, dbo.F_nomTblTipoSistema(TT.tipoSistemaID) Sistema,   CASE PMD.regimen WHEN 1 THEN 'FECHA' WHEN 2 THEN 'LECTURA' WHEN 3 THEN 'MIXTO' END AS Regimen,   Case PMD.regimen WHEN 1 THEN LTRIM(STR(PMD.frecuenciaFecha)) + ' ' + CASE PMD.periodicidadFecha WHEN 1 THEN 'DIAS' WHEN 2 THEN 'SEMANAS' WHEN 3   THEN 'MESES' WHEN 4 THEN 'AÑOS' ELSE '' END WHEN 2 THEN LTRIM(STR(PMD.frecuenciaLectura)) + ' ' + dbo.tblUnidadMedida.abreviatura WHEN 3 THEN   LTrim(Str(PMD.frecuenciaFecha)) + ' ' + CASE PMD.periodicidadFecha WHEN 1 THEN 'DIAS' WHEN 2 THEN 'SEMANAS' WHEN 3 THEN 'MESES' WHEN 4 THEN                'AÑOS' ELSE '' END + ' ó ' + LTRIM(STR(PMD.frecuenciaLectura)) + ' ' + dbo.tblUnidadMedida.abreviatura END AS Frecuencia"
        'Me.columnas_ocultas = "ID"
        'Me.columna_buscar_letra = "nombre"
        'Me.identificador = "ID"
        'Me.columna_mostrar = "Actividades"
        'Me.filas = Conversions.ToString(10)
        'Dim textArray124 As String() = New String() {"SELECT ", Me.columnas.ToString, " FROM ", Me.tabla.ToString, " WHERE PMD.tipo = 'A' and PMD.planManttoID = ", MyBase.Request.QueryString("plan").ToString, " and PMD.usuarioID = ", Me.Session("usuarioLoginID").ToString}
        'Me.SqlDataSource_Grillas_Emergentes.SelectCommand = String.Concat(textArray124)
        'End If


        RadGrid_Principal.MasterTableView.DataKeyNames = New String() {identificador.ToString}
        RadGrid_Principal.MasterTableView.ClientDataKeyNames = New String() {identificador.ToString}
        RadGrid_Principal.MasterTableView.PageSize = filas
        If Page.IsPostBack = False Then
            txt_buscar.Focus()
        End If
    End Sub

    Protected Sub RadGrid_Principal_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGrid_Principal.ColumnCreated
        ColumnasOcultasArray = columnas_ocultas.Split(",")
        For i As Integer = 0 To UBound(ColumnasOcultasArray)
            If TypeOf e.Column Is GridBoundColumn AndAlso e.Column.UniqueName = ColumnasOcultasArray(i).ToString Then
                Dim column As GridBoundColumn = TryCast(e.Column, GridBoundColumn)
                column.Display = False
            End If
        Next i
        'aki debe ir un parametros
        If Me.Request.QueryString("accion") = "Productos" Then
            If e.Column.UniqueName = "Stock" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
            End If
            e.Column.FilterControlWidth = Unit.Percentage(100)
            e.Column.AutoPostBackOnFilter = True
            e.Column.ShowFilterIcon = False
            e.Column.CurrentFilterFunction = GridKnownFunction.Contains
        End If

        If Me.Request.QueryString("accion") = "ProductosAjusteStock" Then
            If e.Column.UniqueName = "Stock" Then
                e.Column.HeaderStyle.Width = Unit.Pixel(70)
            End If
            e.Column.FilterControlWidth = Unit.Percentage(100)
            e.Column.AutoPostBackOnFilter = True
            e.Column.ShowFilterIcon = False
            e.Column.CurrentFilterFunction = GridKnownFunction.Contains
        End If

        If Me.Request.QueryString("accion") = "ProductosFacturacion" Then
            e.Column.FilterControlWidth = Unit.Percentage(100)
            e.Column.AutoPostBackOnFilter = True
            e.Column.ShowFilterIcon = False
            e.Column.CurrentFilterFunction = GridKnownFunction.Contains
        End If
        'hasta aki
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(sender As Object, e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument = "actualizaGrilla" Then
            RadGrid_Principal.Rebind()
        End If
    End Sub

    Protected Sub guardarB_Click(sender As Object, e As EventArgs) Handles guardarB.Click
        Dim cad As String
        If Request.QueryString("accion").ToString = "Contacto_sin_inicio" Then
            cad = " exec P_crearUpdateContacto 0, " & Request.QueryString("RazonSocialID").ToString & ", '" &
                txt_buscar.Text.ToString & "', '', '', '', 7, " & Session("usuarioLoginID").ToString & " "
        ElseIf Request.QueryString("accion").ToString = "tipoEquipo_sin_inicio" Then
            cad = " EXEC P_crearUpdateMasivo '" & txt_buscar.Text.ToString & "', '" & Me.Request.QueryString("accion").ToString &
                                "', " & Session("IDSucursalPrincipal").ToString.Trim & ", " & Session("usuarioLoginID").ToString.Trim &
                                ", " & Me.Request.QueryString("familia").ToString
        ElseIf Request.QueryString("accion").ToString = "tiposistema_sin_inicio" Then
            cad = " EXEC P_crearUpdateMasivo '" & txt_buscar.Text.ToString & "', '" & Me.Request.QueryString("accion").ToString &
                                "', " & Session("IDSucursalPrincipal").ToString.Trim & ", " & Session("usuarioLoginID").ToString.Trim &
                                ", " & ViewState("tipoEquipoTS")
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

    Private Sub RadGrid_Principal_ItemDataBound(ByVal sender As Object, e As GridItemEventArgs) Handles RadGrid_Principal.ItemDataBound
        If Me.Request.QueryString("accion") = "ProductosConSinStock" Then
            For Each item As GridDataItem In RadGrid_Principal.Items
                Dim nomEstado As String = item("Nombre").Text
                Dim LinkEstado As HyperLink = DirectCast(item("TemplateLinkNombre").FindControl("LinkNombre"), HyperLink)
                LinkEstado.Font.Bold = True
                LinkEstado.Text = nomEstado
                LinkEstado.NavigateUrl = "#"
            Next
            Dim target As Control = e.Item.FindControl("LinkNombre")
            If Not [Object].Equals(target, Nothing) Then
                If Not [Object].Equals(Me.RadToolTipManager1, Nothing) Then
                    Me.RadToolTipManager1.TargetControls.Add(target.ClientID, (TryCast(e.Item, GridDataItem)).GetDataKeyValue("ID").ToString(), True)
                End If
            End If

            RadGrid_Principal.MasterTableView.GetColumn("Nombre").Display = False
            RadGrid_Principal.MasterTableView.GetColumn("TemplateLinkNombre").Display = True
        Else
            Try
                RadGrid_Principal.MasterTableView.GetColumn("Nombre").Display = True
            Catch ex As Exception
            End Try

            RadGrid_Principal.MasterTableView.GetColumn("TemplateLinkNombre").Display = False
        End If
    End Sub

    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub

    Private Sub UpdateToolTip(ByVal elementID As String, ByVal panel As UpdatePanel)
        Dim ctrl As Control = Page.LoadControl("ToolTipProductConSinStock.ascx")
        ctrl.ID = "UcProductDetails1"
        panel.ContentTemplateContainer.Controls.Add(ctrl)
        Dim details As ToolTipProductConSinStock = DirectCast(ctrl, ToolTipProductConSinStock)
        details.productoID = elementID
    End Sub

End Class