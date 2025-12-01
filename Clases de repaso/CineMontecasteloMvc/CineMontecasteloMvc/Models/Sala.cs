using System.ComponentModel.DataAnnotations;

namespace CineMontecasteloMvc.Models
{
    public class Sala
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El aforo es obligatorio.")]
        public int Aforo { get; set; }

        public int? PeliculaId { get; set; }
        public Pelicula? Pelicula { get; set; }
    }

}
