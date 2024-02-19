Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports CominWeb.SW_coneccionDB

Public Class SW_productos_DA
    Public Function P_selectProducto(ByVal estado As Integer, ByVal productoID As Integer,
                                     ByVal marcaID As Integer, ByVal marcaEspecificaID As Integer,
                                     ByVal UnidadMedidaID As Integer, ByVal grpoFuncionID As Integer,
                                     ByVal ubicacionID As Integer, ByVal lineaID As Integer,
                                     ByVal almacenID As Integer, ByVal nombre As String,
                                     ByVal codproducto As String, ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectProducto")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        db.AddInParameter(cmd, "@marcaEspecificaID", DbType.Int32, marcaEspecificaID)
        db.AddInParameter(cmd, "@UnidadMedidaID", DbType.Int32, UnidadMedidaID)
        db.AddInParameter(cmd, "@grpoFuncionID", DbType.Int32, grpoFuncionID)
        db.AddInParameter(cmd, "@ubicacionID", DbType.Int32, ubicacionID)
        db.AddInParameter(cmd, "@lineaID", DbType.Int32, lineaID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@nombre", DbType.Int32, nombre)
        db.AddInParameter(cmd, "@codproducto", DbType.Int32, codproducto)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectProductoNew(ByVal estado As Integer, ByVal productoID As Integer,
                                     ByVal marcaID As Integer, ByVal marcaEspecificaID As Integer,
                                     ByVal UnidadMedidaID As Integer, ByVal grpoFuncionID As Integer,
                                     ByVal ubicacionID As Integer, ByVal lineaID As Integer,
                                     ByVal almacenID As Integer, ByVal nombre As String,
                                     ByVal codproducto As String, ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectProductoNew")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        db.AddInParameter(cmd, "@marcaEspecificaID", DbType.Int32, marcaEspecificaID)
        db.AddInParameter(cmd, "@UnidadMedidaID", DbType.Int32, UnidadMedidaID)
        db.AddInParameter(cmd, "@grpoFuncionID", DbType.Int32, grpoFuncionID)
        db.AddInParameter(cmd, "@ubicacionID", DbType.Int32, ubicacionID)
        db.AddInParameter(cmd, "@lineaID", DbType.String, lineaID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@codproducto", DbType.String, codproducto)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectProductoNewValida(ByVal estado As Integer, ByVal productoID As Integer,
                                     ByVal marcaID As Integer, ByVal marcaEspecificaID As Integer,
                                     ByVal UnidadMedidaID As Integer, ByVal grpoFuncionID As Integer,
                                     ByVal ubicacionID As Integer, ByVal lineaID As Integer,
                                     ByVal almacenID As Integer, ByVal nombre As String,
                                     ByVal codproducto As String, ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectProductoNewValida")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        db.AddInParameter(cmd, "@marcaEspecificaID", DbType.Int32, marcaEspecificaID)
        db.AddInParameter(cmd, "@UnidadMedidaID", DbType.Int32, UnidadMedidaID)
        db.AddInParameter(cmd, "@grpoFuncionID", DbType.Int32, grpoFuncionID)
        db.AddInParameter(cmd, "@ubicacionID", DbType.Int32, ubicacionID)
        db.AddInParameter(cmd, "@lineaID", DbType.String, lineaID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@codproducto", DbType.String, codproducto)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectProductoNewValida_Fab(ByVal estado As Integer, ByVal productoID As Integer,
                                 ByVal marcaID As Integer, ByVal marcaEspecificaID As Integer,
                                 ByVal UnidadMedidaID As Integer, ByVal grpoFuncionID As Integer,
                                 ByVal ubicacionID As Integer, ByVal lineaID As Integer,
                                 ByVal almacenID As Integer, ByVal nombre As String,
                                 ByVal codproducto As String, ByVal sucursalID As Integer,
                                 ByVal codFabricante As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectProductoNewValida_Fab")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        db.AddInParameter(cmd, "@marcaEspecificaID", DbType.Int32, marcaEspecificaID)
        db.AddInParameter(cmd, "@UnidadMedidaID", DbType.Int32, UnidadMedidaID)
        db.AddInParameter(cmd, "@grpoFuncionID", DbType.Int32, grpoFuncionID)
        db.AddInParameter(cmd, "@ubicacionID", DbType.Int32, ubicacionID)
        db.AddInParameter(cmd, "@lineaID", DbType.String, lineaID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@codproducto", DbType.String, codproducto)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@codFabricante", DbType.String, codFabricante)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_Report_Inventarios(ByVal estado As Integer, ByVal productoID As String,
                                     ByVal marcaID As String, ByVal marcaEspecificaID As String,
                                     ByVal UnidadMedidaID As String, ByVal grpoFuncionID As String,
                                     ByVal ubicacionID As String, ByVal lineaID As String,
                                     ByVal almacenID As String, ByVal nombre As String,
                                     ByVal codproducto As String, ByVal sucursalID As String,
                                     ByVal conStock As Integer, ByVal fechaCorte As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_Report_Inventarios")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@productoID", DbType.String, productoID)
        db.AddInParameter(cmd, "@marcaID", DbType.String, marcaID)
        db.AddInParameter(cmd, "@marcaEspecificaID", DbType.String, marcaEspecificaID)
        db.AddInParameter(cmd, "@UnidadMedidaID", DbType.String, UnidadMedidaID)
        db.AddInParameter(cmd, "@grpoFuncionID", DbType.String, grpoFuncionID)
        db.AddInParameter(cmd, "@ubicacionID", DbType.String, ubicacionID)
        db.AddInParameter(cmd, "@lineaID", DbType.String, lineaID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, almacenID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@codproducto", DbType.String, codproducto)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@conStock", DbType.Int32, conStock)
        db.AddInParameter(cmd, "@fechaCorte", DbType.String, fechaCorte)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectAlmacen(ByVal estado As Integer, ByVal almacenID As Integer,
                                    ByVal sucursalID As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectAlmacen")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_selectPorcentajeVentaLinea(ByVal precioLineaID As Integer, ByVal lineaID As Integer,
                                                 ByVal monedaID As Integer, ByVal valorr As Decimal) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectPorcentajeVentaLinea")
        db.AddInParameter(cmd, "@precioLineaID", DbType.Int32, precioLineaID)
        db.AddInParameter(cmd, "@lineaID", DbType.Int32, lineaID)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@monto", DbType.Decimal, valorr)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_crearUpdateProductos(ByVal productoID As String, ByVal nombre As String, ByVal marcaID As Integer,
                                                    ByVal marcaEspecificaID As Integer, ByVal UnidadMedidaID As Integer,
                                                    ByVal grpoFuncionID As Integer, ByVal ubicacionID As Integer,
                                                    ByVal lineaID As Integer, ByVal peso As Decimal, ByVal stockActual As Decimal,
                                                    ByVal stockMinimo As Decimal, ByVal stockMaximo As Decimal, ByVal valorVenta As Decimal,
                                                    ByVal costo As Decimal, ByVal categoriaABC As String, ByVal vidaUtil As Decimal,
                                                    ByVal medida As String, ByVal encastre As String, ByVal resistencia As String,
                                                    ByVal observaciones As String, ByVal usuarioID As Integer, sucursalID As Integer,
                                                    ByVal monedaID As Integer, ByVal codigo As String, ByVal productoBaseID As String,
                                                    ByVal porcentajeVentaUnidad As Decimal, ByVal codigoProducto As String,
                                                    ByVal valorVentaPreferencial As Decimal, ByVal porcentajeVentaUnidadPrefer As Decimal,
                                                    ByVal subGrupoID As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_crearUpdateProductos")
        db.AddInParameter(cmd, "@productoID", DbType.String, productoID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@marcaID", DbType.Int32, marcaID)
        db.AddInParameter(cmd, "@marcaEspecificaID", DbType.Int32, marcaEspecificaID)
        db.AddInParameter(cmd, "@UnidadMedidaID", DbType.Int32, UnidadMedidaID)
        db.AddInParameter(cmd, "@grpoFuncionID", DbType.Int32, grpoFuncionID)
        db.AddInParameter(cmd, "@ubicacionID", DbType.Int32, ubicacionID)
        db.AddInParameter(cmd, "@lineaID", DbType.Int32, lineaID)
        db.AddInParameter(cmd, "@peso", DbType.Decimal, peso)
        db.AddInParameter(cmd, "@stockActual", DbType.Decimal, stockActual)
        db.AddInParameter(cmd, "@stockMinimo", DbType.Decimal, stockMinimo)
        db.AddInParameter(cmd, "@stockMaximo", DbType.Decimal, stockMaximo)
        db.AddInParameter(cmd, "@valorVenta", DbType.Decimal, valorVenta)
        db.AddInParameter(cmd, "@costo", DbType.Decimal, costo)
        db.AddInParameter(cmd, "@categoriaABC", DbType.String, categoriaABC)
        db.AddInParameter(cmd, "@vidaUtil", DbType.Decimal, vidaUtil)
        db.AddInParameter(cmd, "@medida", DbType.String, medida)
        db.AddInParameter(cmd, "@encastre", DbType.String, encastre)
        db.AddInParameter(cmd, "@resistencia", DbType.String, resistencia)
        db.AddInParameter(cmd, "@observaciones", DbType.String, observaciones)
        db.AddInParameter(cmd, "@usuarioID", DbType.Int32, usuarioID)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@monedaID", DbType.Int32, monedaID)
        db.AddInParameter(cmd, "@codigo", DbType.String, codigo)
        db.AddInParameter(cmd, "@productoBaseID", DbType.String, productoBaseID)
        db.AddInParameter(cmd, "@porcentajeVentaUnidad", DbType.Decimal, porcentajeVentaUnidad)
        db.AddInParameter(cmd, "@codigoProducto", DbType.String, codigoProducto)
        db.AddInParameter(cmd, "@valorVentaPreferencial", DbType.Decimal, valorVentaPreferencial)
        db.AddInParameter(cmd, "@porcentajeVentaUnidadPrefer", DbType.Decimal, porcentajeVentaUnidadPrefer)
        db.AddInParameter(cmd, "@subGrupoID", DbType.String, subGrupoID)
        Try
            Dim valor As String
            valor = ""
            Dim ds As DataSet
            Dim tb As DataTable
            Dim fila As DataRow
            ds = db.ExecuteDataSet(cmd)
            tb = ds.Tables(0)
            fila = tb.Rows(0)
            valor = fila("productoIDUltimo")
            Return valor
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function P_selectProductoNewStockList(ByVal estado As Integer, ByVal productoID As Integer,
                                 ByVal marcaID As String, ByVal marcaEspecificaID As String,
                                 ByVal lineaID As Integer, ByVal almacenID As Integer, ByVal nombre As String,
                                 ByVal codproducto As String, ByVal sucursalID As Integer, ByVal conStock As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_selectProductoNewVenta")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@productoID", DbType.Int32, productoID)
        db.AddInParameter(cmd, "@grupo", DbType.String, marcaID)
        db.AddInParameter(cmd, "@marca", DbType.String, marcaEspecificaID)
        db.AddInParameter(cmd, "@lineaID", DbType.Int32, lineaID)
        db.AddInParameter(cmd, "@almacenID", DbType.Int32, almacenID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@codproducto", DbType.String, codproducto)
        db.AddInParameter(cmd, "@sucursalID", DbType.Int32, sucursalID)
        db.AddInParameter(cmd, "@conStock", DbType.Int32, conStock)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

    Public Function P_Report_InventariosValorado(ByVal estado As Integer, ByVal productoID As String,
                                     ByVal marcaID As String, ByVal marcaEspecificaID As String,
                                     ByVal UnidadMedidaID As String, ByVal grpoFuncionID As String,
                                     ByVal ubicacionID As String, ByVal lineaID As String,
                                     ByVal almacenID As String, ByVal nombre As String,
                                     ByVal codproducto As String, ByVal sucursalID As String,
                                     ByVal conStock As Integer, ByVal fechaCorte As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase(variableGlobalConexion.nombreCadenaCnx)
        Dim cmd As DbCommand = db.GetStoredProcCommand("P_Report_InventariosValorado")
        db.AddInParameter(cmd, "@estado", DbType.Int32, estado)
        db.AddInParameter(cmd, "@productoID", DbType.String, productoID)
        db.AddInParameter(cmd, "@marcaID", DbType.String, marcaID)
        db.AddInParameter(cmd, "@marcaEspecificaID", DbType.String, marcaEspecificaID)
        db.AddInParameter(cmd, "@UnidadMedidaID", DbType.String, UnidadMedidaID)
        db.AddInParameter(cmd, "@grpoFuncionID", DbType.String, grpoFuncionID)
        db.AddInParameter(cmd, "@ubicacionID", DbType.String, ubicacionID)
        db.AddInParameter(cmd, "@lineaID", DbType.String, lineaID)
        db.AddInParameter(cmd, "@almacenID", DbType.String, almacenID)
        db.AddInParameter(cmd, "@nombre", DbType.String, nombre)
        db.AddInParameter(cmd, "@codproducto", DbType.String, codproducto)
        db.AddInParameter(cmd, "@sucursalID", DbType.String, sucursalID)
        db.AddInParameter(cmd, "@conStock", DbType.Int32, conStock)
        db.AddInParameter(cmd, "@fechaCorte", DbType.String, fechaCorte)
        Dim ds As DataSet
        ds = db.ExecuteDataSet(cmd)
        Return ds.Tables(0)
    End Function

End Class
