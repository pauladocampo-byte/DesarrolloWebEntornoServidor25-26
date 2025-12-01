using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CineMontecasteloMvc.ViewModels
{
    public class PeliculaEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(1000)]
        [DisplayName("Descripción")]
        public string? Descripcion { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El género es obligatorio.")]
        [DisplayName("Género")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "El año es obligatorio.")]
        [DisplayName("Año")]
        public int Anio { get; set; }

        [DisplayName("Duración")]
        [Required(ErrorMessage = "La duración obligatoria.")]
        public int Duracion { get; set; }

        [Range(0, 100)]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal Precio { get; set; }

        public List<SalaCheckboxViewModel> Salas { get; set; } = new();
    }
}
