namespace DapperProject.Models
{
    public interface IFabricanteRepository
    {
        IEnumerable<Fabricante> GetFabricantes();
        Fabricante GetFabricante(int? codigo);
        void CrearFabricante(Fabricante fabricante);
        void UpdateFabricante(Fabricante fabricante);  
        void DeleteFabricante(int? codigo);
    }
}
