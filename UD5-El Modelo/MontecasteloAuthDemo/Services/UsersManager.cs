using Microsoft.EntityFrameworkCore;
using MontecasteloAuthDemo.Data;
using MontecasteloAuthDemo.Models;
using MontecasteloAuthDemo.Services.Interfaces;

namespace MontecasteloAuthDemo.Services
{
    public class UsersManager : IUsersManager
    {
        private readonly AppDbContext _db;
        public UsersManager(AppDbContext db) => _db = db;

        public IQueryable<Usuario> Query() => _db.Usuarios.AsNoTracking();

        public bool ExistsByUserName(string userName)
            => _db.Usuarios.Any(u => u.NombreUsuario == userName);

        public Usuario? FindByUserName(string userName)
            => _db.Usuarios.FirstOrDefault(u => u.NombreUsuario == userName);

        public Usuario? FindById(int id)
            => _db.Usuarios.FirstOrDefault(u => u.Id == id);

        public Usuario Create(string userName, string password, string role)
        {
            var salt = PasswordHasher.CreateSalt();
            var hash = PasswordHasher.HashPassword(password, salt);
            var user = new Usuario
            {
                NombreUsuario = userName,
                Salt = salt,
                PasswordHash = hash,
                Rol = string.IsNullOrWhiteSpace(role) ? Roles.User : role
            };
            _db.Usuarios.Add(user);
            _db.SaveChanges();
            return user;
        }

        public void ChangePassword(Usuario user, string newPassword)
        {
            var newSalt = PasswordHasher.CreateSalt();
            var newHash = PasswordHasher.HashPassword(newPassword, newSalt);
            user.Salt = newSalt;
            user.PasswordHash = newHash;
            _db.SaveChanges();
        }

        public void Update(Usuario user)
        {
            _db.Usuarios.Update(user);
            _db.SaveChanges();
        }

        public void Delete(Usuario user)
        {
            _db.Usuarios.Remove(user);
            _db.SaveChanges();
        }

        public void SaveChanges() => _db.SaveChanges();

        public (bool ok, Usuario? user) VerifyCredentials(string userName, string password)
        {
            var user = FindByUserName(userName);
            if (user is null) return (false, null);
            var ok = PasswordHasher.Verify(password, user.Salt, user.PasswordHash);
            return (ok, ok ? user : null);
        }
    }
}
