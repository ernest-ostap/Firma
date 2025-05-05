using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Models
{
    public class Kategoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nazwa kategorii jest wymagana")]
        [MaxLength(30, ErrorMessage ="Nazwa może mieć maksymalnie 30 znaków")]
        [Display(Name = "Nazwa kategorii")]
        public required string Nazwa { get; set; } = string.Empty;

        public ICollection<Produkt> Produkty { get; } = new List<Produkt>();
    }
}
