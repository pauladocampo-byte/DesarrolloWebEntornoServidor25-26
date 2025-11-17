using System.ComponentModel.DataAnnotations;

namespace Practica5Binding.Models
{
    public class Address
    {
        [StringLength(50), Required]
        public string Street { get; set; } = string.Empty;

        [StringLength(5)]
        public string? ZipCode { get; set; }
    }
}
