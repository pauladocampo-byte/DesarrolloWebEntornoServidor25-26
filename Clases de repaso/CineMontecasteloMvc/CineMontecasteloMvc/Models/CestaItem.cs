namespace CineMontecasteloMvc.Models
{
    public class CestaItem
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public decimal Total => Precio * Cantidad;
    }
}
