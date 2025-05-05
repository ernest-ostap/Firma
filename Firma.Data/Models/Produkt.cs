using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Models
{
    public class Produkt
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(30, ErrorMessage = "Nazwa może mieć maksymalnie 30 znaków")]
        public required string Nazwa { get; set; } = string.Empty;

        [Required(ErrorMessage = "Opis jest wymagany")]
        [MaxLength(30, ErrorMessage = "Nazwa może mieć maksymalnie 30 znaków")]
        public required string Opis { get; set; } = string.Empty;

        [ForeignKey("Kategoria")]
        public int KategoriaId { get; set; }
        public Kategoria? Kategoria { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Cena za dzień")]
        public decimal CenaWypozyczenia { get; set; }

        public string? ZdjecieUrl { get; set; }

        public ICollection<Rezerwacja>? Rezerwacje { get; } = new List<Rezerwacja>();
        public ICollection<Recenzja>? Recenzje { get; } = new List<Recenzja>();
    }
}
