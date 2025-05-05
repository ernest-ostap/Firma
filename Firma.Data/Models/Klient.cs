using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Firma.Data.Models
{
    public class Klient
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(30, ErrorMessage = "Maksymalna długość to 30 znaków")]
        public required string Imie { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(30, ErrorMessage = "Maksymalna długość to 30 znaków")]
        public required string Nazwisko { get; set; } = string.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość to 50 znaków")]
        public required string Email { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        public string? Telefon { get; set; } = string.Empty;

        public ICollection<Rezerwacja>? Rezerwacje { get; set; }
        public ICollection<Recenzja>? Recenzje { get; set; }
    }

}
