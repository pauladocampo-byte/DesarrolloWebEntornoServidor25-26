using CineMontecasteloMvc.Models;

namespace CineMontecasteloMvc.Managers.Interfaces
{
    public interface IUsuarioManager
    {
        Usuario? Authenticate(string nombreUsuario, string password);
    }
}
