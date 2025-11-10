using Microsoft.Data.SqlClient;


namespace DapperProject.Models
{
    public class Conexion
    {
        public readonly string _connectionString;

        public Conexion(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
