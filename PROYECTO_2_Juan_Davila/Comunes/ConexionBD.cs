using PROYECTO_2_Juan_Davila.Module;
using System.Data;


namespace PROYECTO_2_Juan_Davila.Comunes
{
    public class ConexionBD
    {
        public static SqlConnection conexion;

        public static SqlConnection abrirConexion()
        {
            //conexion = new SqlConnection("Server=LT-EMANOSALVAS\\SQLEXPRESS;Database=PROYECTO_1;Trusted_Connection=True;");
            conexion = new SqlConnection("Server=Juank-Davila\\LICEO;Database=PROYECTO_2;User Id=sa;Password=Representaciones.2024;");
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
    }
}
