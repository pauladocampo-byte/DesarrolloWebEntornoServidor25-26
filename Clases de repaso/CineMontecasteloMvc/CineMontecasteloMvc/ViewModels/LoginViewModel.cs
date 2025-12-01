using System.ComponentModel.DataAnnotations;

namespace CineMontecasteloMvc.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = string.Empty;
    }
}
