using System.ComponentModel.DataAnnotations;

namespace Practica5Binding.Models
{
    public class Friend : IValidatableObject
    {
        [StringLength(30), Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 120)]
        public int Age { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public Address Address { get; set; } = new Address();

        [StringLength(20)]
        public string? Nickname { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age < 18 && string.IsNullOrWhiteSpace(Nickname))
            {
                yield return new ValidationResult(
                    "Los amigos menores de edad deben tener un apodo.",
                    new[] { nameof(Nickname) });
            }
        }
    }
}
