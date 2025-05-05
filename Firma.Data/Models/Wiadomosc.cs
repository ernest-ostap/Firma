using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Models
{
    public class Wiadomosc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Treść wiadomości jest wymagana")]
        [MaxLength(1000)]
        public required string Tresc { get; set; }

        [MaxLength(100)]
        public string? Temat { get; set; }

        [Required]
        public DateTime DataWiadomosci { get; set; } = DateTime.Now;

        public bool DotyczyRezerwacji { get; set; }

        [EmailAddress]
        public string? EmailNadawcy { get; set; }

        [MaxLength(100)]
        public string? ImieNazwiskoNadawcy { get; set; }
    }
}
