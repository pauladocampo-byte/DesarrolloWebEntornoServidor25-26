using CineMontecasteloMvc.Managers.Interfaces;
using CineMontecasteloMvc.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CineMontecasteloMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioManager _usuarioManager;

        public AccountController(IUsuarioManager usuarioManager)
        {
            _usuarioManager = usuarioManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl; // Guarda la URL de retorno para usarla en la vista
            return View(new LoginViewModel()); // Devuelve la vista con un modelo vacío
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model); // Si validación del modelo falla, vuelve a mostrar formulario

            var user = _usuarioManager.Authenticate(model.NombreUsuario, model.Password); // Intenta autenticar usuario
            if (user == null) // Si no se autentica
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos."); // Agrega error global
                return View(model); // Devuelve la vista con el error
            }

            var claims = new List<Claim> // Lista de claims (información sobre el usuario)
            {
                new Claim(ClaimTypes.Name, user.NombreUsuario), // Claim del nombre
                new Claim(ClaimTypes.Role, "Admin") // Claim del rol (hardcodeado)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // Crea identidad con esquema de cookies
            HttpContext.SignInAsync( // Inicia sesión del usuario creando la cookie
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity)).Wait(); // Principal con identidad; espera a que termine

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) // Si hay URL de retorno local y válida
                return Redirect(returnUrl); // Redirige a esa URL

            return RedirectToAction("Index", "Home"); // Si no hay retorno, redirige a Home/Index
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait(); // Elimina cookie de autenticación
            return RedirectToAction("Index", "Home"); // Redirige a página principal
        }
    }
}
