using CineMontecasteloMvc.Data;
using CineMontecasteloMvc.Helpers;
using CineMontecasteloMvc.Managers.Interfaces;
using CineMontecasteloMvc.Models;

namespace CineMontecasteloMvc.Managers
{
    public class UsuarioManager: IUsuarioManager
    {
        private readonly CineContext _context;
        public UsuarioManager(CineContext context)
        {
            _context = context;
        }

        public Usuario? Authenticate (string nombreUsuario, string password)
        {
            //Buscar el usuario por su nombre (solo uno)
             var user = _context.Usuarios.SingleOrDefault(u => u.NombreUsuario == nombreUsuario);
            //si no existe el usuario, autenticación fallida
            if (user == null)
                return null;

            //Si la password no coincide, autenticación fallida
            if (!PasswordHelper.VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }

            //Autenticación exitosa
            return user;
        }
    }
}
