Imports Telerik.Web.UI
Imports CominWeb.SW_coneccionDB

Public Class Ctrl_GrillaEmergenteRespaldo
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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim accion As String = Request.QueryString("accion").ToString
        txt_buscar.Focus()
        SqlDataSource_Grillas_Emergentes.ConnectionString = ConfigurationManager.ConnectionStrings(variableGlobalConexion.nombreCadenaCnx).ConnectionString

        If Request.QueryString("toolbar") = 0 Then
            RadToolBar1.Visible = False
        Else
            RadToolBar1.Visible = True
        End If
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
                    " WHERE (" & columna_buscar_letra.ToString & " LIKE '% nadaquebuscaraqui %') ORDER BY " & identificador.ToString & " ASC"
                Else '
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
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
                " WHERE tipoSave = 1 AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
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
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') OR ( " & _
                                   "razoncomercial LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
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
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') OR ( " & _
                                   "razoncomercial LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
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
                " WHERE tipoSave = 2 AND ((" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') OR ( " & _
                                   "razoncomercial LIKE '%" & txt_buscar.Text & "%')) ORDER BY " & identificador.ToString & " ASC"
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
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR apaterno LIKE '%" & txt_buscar.Text & _
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
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " & _
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " & _
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " & _
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad' , SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    " ORDER BY PROBA.nombre ASC"
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
                    "  AND(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " HAVING SUM(dbo.tblInventarios.cantidad) > 0 " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    End If
                End If
            Case "ProductosConSinStock"
                RadGrid_Principal.MasterTableView.NoMasterRecordsText = "No existen productos en stock."
                'tabla = " dbo.tblProducto INNER JOIN dbo.tblGrupoFuncion ON dbo.tblProducto.grpoFuncionID = " & _
                '    " dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN" & _
                '    " dbo.tblInventarios ON dbo.tblProducto.productoID = dbo.tblInventarios.productoID "
                tabla = " dbo.tblProducto INNER JOIN dbo.tblProductoBase AS PROBA ON dbo.tblProducto.productoBaseID " & _
                    "= PROBA.productoBaseID LEFT OUTER JOIN dbo.tblGrupoFuncion ON PROBA.grpoFuncionID = " & _
                    "dbo.tblGrupoFuncion.grupoFuncionID RIGHT OUTER JOIN dbo.tblInventarios ON dbo.tblProducto.productoID " & _
                    "= dbo.tblInventarios.productoID "
                columnas = " tblProducto.productoID AS 'ID', PROBA.codigoProducto as 'Fabricante', dbo.F_nomTblGrupo(PROBA.grupoID) AS 'Grupo', " & _
                    " tblgrupofuncion.nombre AS 'Grupo Funcion', " & _
                    " PROBA.codproducto as Codigo,PROBA.nombre AS 'Nombre', dbo.F_nomtblUnidadMedida(PROBA.UnidadMedidaID) AS 'Unidad', SUM(dbo.tblInventarios.cantidad) AS 'Stock' "
                columnas_ocultas = "ID"
                columna_buscar_letra = "PROBA.nombre"
                columna_buscar_numero = "[productoID]"
                identificador = "ID"
                columna_mostrar = "Codigo"
                filas = 10
                If Me.Request.QueryString("almacenIDQS").ToString > 0 Then
                    If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%' ) " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codigoProducto, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY " & identificador.ToString & " ASC"
                    Else ' busca en la coluna columna_buscar_letra
                        SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                    " WHERE dbo.F_facturacionByProductoID(tblProducto.productoID) = 0 and dbo.tblProducto.estado = 0 and dbo.tblProducto.sucursalID = " & Session("IDSucursalPrincipal").ToString & _
                    " AND dbo.tblInventarios.almacenID = " & Me.Request.QueryString("almacenIDQS").ToString.Trim & _
                    " AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codproducto LIKE '%" & txt_buscar.Text & "%' or PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codigoProducto, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
                    " ORDER BY PROBA.nombre ASC"
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
                    "  AND(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
                    " GROUP BY dbo.tblProducto.productoID, PROBA.codproducto, PROBA.nombre, dbo.tblGrupoFuncion.nombre, dbo.tblInventarios.almacenID, PROBA.grupoID, PROBA.UnidadMedidaID " & _
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
                    "  AND(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%' OR PROBA.codigoProducto LIKE '%" & txt_buscar.Text & "%') " & _
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
                    "  AND(" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') " & _
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
                " WHERE tipoSave = 3 AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
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
                " WHERE tipoSave = 3 AND (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
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
                " WHERE  (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY " & identificador.ToString & " ASC"
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
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' AND dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " & _
                " ORDER BY Codigo DESC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE estado IN (1,3) AND referenciaVenta = 'PENDIENTE' AND dbo.F_CodigoByEquipoID(equipoID) LIKE '%" & txt_buscar.Text & "%' " & _
                " ORDER BY Codigo DESC"
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
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE ISNULL(cotizado,0) = 0 AND estado <> 2 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY fechaApertura DESC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE ISNULL(cotizado,0) = 0 AND estado <> 2 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY fechaApertura DESC"
                End If
            Case "ordenTrabajoTODO_sin_inicio"
                tabla = "tblOrdenServicio"
                columnas = "[ordenServicioID] AS 'ID', codigo AS 'OT', dbo.F_CodigoByEquipoID(equipoID) AS 'Equipo', dbo.F_nomtblPropietarioProveedorClienteSubcontrata(clienteID) AS 'Cliente'"
                columnas_ocultas = "ID"
                columna_buscar_letra = "codigo"
                identificador = "ID"
                columna_mostrar = "OT"
                filas = 10
                If IsNumeric(txt_buscar.Text) Then 'Si lo digitado es numerico busca en columna_buscar_numero
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE estado <> 2 and (" & columna_buscar_numero.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY fechaApertura DESC"
                Else ' busca en la coluna columna_buscar_letra
                    SqlDataSource_Grillas_Emergentes.SelectCommand = "SELECT " & columnas.ToString & " FROM " & tabla.ToString & _
                " WHERE estado <> 2 and (" & columna_buscar_letra.ToString & " LIKE '%" & txt_buscar.Text & "%') ORDER BY fechaApertura DESC"
                End If

        End Select

        'ScriptManager.RegisterStartupScript(Page, GetType(Page), "AjustarVentana", "SizeToFit();", True)
        RadGrid_Principal.MasterTableView.DataKeyNames = New String() {identificador.ToString}
        RadGrid_Principal.MasterTableView.ClientDataKeyNames = New String() {identificador.ToString}
        RadGrid_Principal.MasterTableView.PageSize = filas
    End Sub

    Private Sub RadGrid_Principal_ColumnCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridColumnCreatedEventArgs) Handles RadGrid_Principal.ColumnCreated
        ColumnasOcultasArray = columnas_ocultas.Split(",")
        For i As Integer = 0 To UBound(ColumnasOcultasArray)
            If TypeOf e.Column Is GridBoundColumn AndAlso e.Column.UniqueName = ColumnasOcultasArray(i).ToString Then
                Dim column As GridBoundColumn = TryCast(e.Column, GridBoundColumn)
                column.Display = False
            End If
        Next i
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(sender As Object, e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        If e.Argument = "actualizaGrilla" Then
            RadGrid_Principal.Rebind()
        End If
    End Sub
End Class