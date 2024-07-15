﻿using PROYECTO_2_Juan_Davila.Module;
using System.Data;
using System.Data.SqlClient;



namespace PROYECTO_2_Juan_Davila.Comunes
{
    public class ConexionBD
    {
        public static SqlConnection conexion;

        public static SqlConnection abrirConexion()
        {
            conexion = new SqlConnection("SERVER=Juank-Davila\\LICEO;DATABASE=PROYECTO_2;Trusted_Connection=true");
            //conexion = new SqlConnection("Server=Juank-Davila\\LICEO;Database=PROYECTO_2;User Id=sa;Password=Representaciones.2024;");
            conexion.Open();
            return conexion;
        }

        public static List<Cliente> GetClientes()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_CLIENTES";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarClientes(dataSet.Tables[0]);
        }

        public static Cliente GetCliente(String cedula)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_CLIENTE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CEDULA", cedula);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarClientes(dataSet.Tables[0])[0];
        }


        public static void PostCliente(Cliente objCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_CLIENTES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CEDULA", objCliente.cedula);
            cmd.Parameters.AddWithValue("@PV_NOMBRES", objCliente.nombre);
            cmd.ExecuteNonQuery();
        }

        public static void PutCliente(string cedula, Cliente objCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_CLIENTES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CEDULA", cedula);
            cmd.Parameters.AddWithValue("@PV_NOMBRES", objCliente.nombre);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteCliente(string cedula)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_CLIENTES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CEDULA", cedula);
            cmd.ExecuteNonQuery();
        }


        private static List<Cliente> llenarClientes(DataTable dataTable)
        {
            List<Cliente> lRespuesta = new List<Cliente>();
            Cliente objeto = new Cliente();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new Cliente();
                objeto.cedula = dr["CEDULA"].ToString();
                objeto.nombre = dr["NOMBRE"].ToString();
                objeto.estado = dr["ESTADO"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }
        public static List<Producto> GetProductos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarProductos(dataSet.Tables[0]);
        }

        public static Producto GetProducto(string codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CODIGO", codigo);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarProductos(dataSet.Tables[0])[0];
        }

        public static void PostProducto(Producto objProducto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CODIGO", objProducto.codigo);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objProducto.descripcion);
            cmd.Parameters.AddWithValue("@PF_PRECIO", objProducto.precio);
            cmd.ExecuteNonQuery();
        }

        public static void PutProducto(string codigo, Producto objProducto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CODIGO", codigo);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objProducto.descripcion);
            cmd.Parameters.AddWithValue("@PF_PRECIO", objProducto.precio);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteProducto(string codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CODIGO", codigo);
            cmd.ExecuteNonQuery();
        }

        private static List<Producto> llenarProductos(DataTable dataTable)
        {
            List<Producto> lRespuesta = new List<Producto>();
            Producto objeto = new Producto();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new Producto();
                objeto.id_producto = Convert.ToInt32(dr["ID_PRODUCTO"].ToString());
                objeto.codigo = dr["CODIGO"].ToString();
                objeto.descripcion = dr["DESCRIPCION"].ToString();
                objeto.precio = Convert.ToDecimal(dr["PRECIO"].ToString());
                objeto.estado = dr["ESTADO"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }

        public static List<Promocion> GetPromociones()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_PROMOCIONES";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarPromociones(dataSet.Tables[0]);
        }
        public static Promocion GetPromocion(int id_promocion)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_PROMOCIONES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_PROMOCION", id_promocion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarPromociones(dataSet.Tables[0])[0];
        }
        public static void PostPromocion(Promocion objPromocion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_PROMOCIONES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objPromocion.descripcion);
            cmd.Parameters.AddWithValue("@PF_FECHA_INICIO", objPromocion.fecha_inicio);
            cmd.Parameters.AddWithValue("@PF_FECHA_FIN", objPromocion.fecha_fin);
            cmd.ExecuteNonQuery();
        }
        public static void PutPromocion(int id_promocion, Promocion objPromocion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_PROMOCIONES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_PROMOCION", id_promocion);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objPromocion.descripcion);
            cmd.Parameters.AddWithValue("@PF_FECHA_INICIO", objPromocion.fecha_inicio);
            cmd.Parameters.AddWithValue("@PF_FECHA_FIN", objPromocion.fecha_fin);
            cmd.ExecuteNonQuery();
        }
        public static void DeletePromocion(string codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_PROMOCION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CODIGO", codigo);
            cmd.ExecuteNonQuery();
        }


        private static List<Promocion> llenarPromociones(DataTable dataTable)
        {
            List<Promocion> lRespuesta = new List<Promocion>();
            Promocion objeto = new Promocion();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new Promocion();
                objeto.id_promocion = Convert.ToInt32(dr["ID_PROMOCION"].ToString());
                objeto.descripcion = dr["DESCRIPCION"].ToString();
                objeto.fecha_inicio = Convert.ToDateTime(dr["FECHA_INICIO"].ToString());
                objeto.fecha_fin = Convert.ToDateTime(dr["FECHA_FIN"].ToString());
                objeto.estado = dr["ESTADO"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }

    

   
    

        public static decimal GetPromocionProducto(int id_producto)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_PROMOCION_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID_PRODUCTO", id_producto);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return Convert.ToDecimal(dataSet.Tables[0].Rows[0][0].ToString());

        }


        public static decimal GetPromocionCliente(string cedula)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_PROMOCION_CLIENTE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CEDULA", cedula);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return Convert.ToDecimal(dataSet.Tables[0].Rows[0][0].ToString());

        }

        public static List<HistorialVisita> GetHistorialVisita(String cedula)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_HISTORIAL_VISITA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_CEDULA", cedula);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarHistorialVisita(dataSet.Tables[0]);
        }

        private static List<HistorialVisita> llenarHistorialVisita(DataTable dataTable)
        {
            List<HistorialVisita> lRespuesta = new List<HistorialVisita>();
            HistorialVisita objeto = new HistorialVisita();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new HistorialVisita();
                objeto.descripcion = dr["descripcion"].ToString();
                objeto.fecha_visita = Convert.ToDateTime(dr["fecha_visita"].ToString());
                objeto.nombre = dr["nombre"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }

        public static List<Tienda> GetTiendas()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_TIENDAS";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarTiendas(dataSet.Tables[0]);
        }
        public static Tienda GetTienda(int id_tienda)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_TIENDA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_ID_TIENDA", id_tienda);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarTiendas(dataSet.Tables[0])[0];
        }


        public static void PostTienda(Tienda objTienda)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_TIENDAS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_ID_TIENDA", objTienda.id_tienda);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objTienda.descripcion);
            cmd.ExecuteNonQuery();
        }

        public static void PutTienda(int id_tienda, Tienda objTienda)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_TIENDAS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_ID_TIENDA", id_tienda);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objTienda.descripcion);
            cmd.Parameters.AddWithValue("@PV_ESTADO", objTienda.estado);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteTienda(int id_tienda)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_TIENDAS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_ID_TIENDA", id_tienda);
            cmd.ExecuteNonQuery();
        }


        private static List<Tienda> llenarTiendas(DataTable dataTable)
        {
            List<Tienda> lRespuesta = new List<Tienda>();
            Tienda objeto = new Tienda();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new Tienda();
                objeto.id_tienda = Convert.ToInt32(dr["ID_TIENDA"].ToString());
                objeto.descripcion = dr["DESCRIPCION"].ToString();
                objeto.estado = dr["ESTADO"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }

    }
}
