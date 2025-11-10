using Dapper;
using System.Data;

namespace DapperProject.Models
{
    public class FabricanteRepository:IFabricanteRepository
    {
        private readonly Conexion _conexion;
        public FabricanteRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public IEnumerable<Fabricante> GetFabricantes()
        {
            var query = "SELECT codigo, nombre FROM fabricante";
            using (var conexion = _conexion.ObtenerConexion())
            {

                var fabricante=  conexion.Query<Fabricante>(query);
                return fabricante;
            }
        }
        public Fabricante GetFabricante(int? codigo)
        {
            const string query = "SELECT * FROM fabricante WHERE codigo = @codigo";
            using (var connection = _conexion.ObtenerConexion())
            {
                var fabricante = connection.QueryFirst<Fabricante>(query, new { codigo });
                return fabricante;
            }
        }

        public void UpdateFabricante(Fabricante fabricante)
        {
            const string query = "UPDATE fabricante SET nombre = @nombre WHERE codigo = @codigo";

            var parameters = new DynamicParameters();
            parameters.Add("codigo", fabricante.Codigo, DbType.Int32);
            parameters.Add("nombre", fabricante.Nombre, DbType.String);

            using (var connection = _conexion.ObtenerConexion())
            {
                connection.Execute(query, parameters);
            }
        }

        public void CrearFabricante(Fabricante fabricante)
        {
            const string sql = "INSERT INTO fabricante (codigo, nombre) VALUES (@codigo, @nombre)";
            using var cn = _conexion.ObtenerConexion();
            cn.Execute(sql, new { codigo = fabricante.Codigo, nombre = fabricante.Nombre });
        }

        public void DeleteFabricante(int? codigo)
        {
            const string sql = "DELETE FROM fabricante WHERE codigo = @codigo";
            using var cn = _conexion.ObtenerConexion();
            cn.Execute(sql, new { codigo = codigo });
        }
    }
}
