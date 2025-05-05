using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Models
{
    public class Faktura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataWystawienia { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Kwota jest wymagana")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Kwota { get; set; }

        [Required]
        public int KlientId { get; set; }
        public Klient? Klient { get; set; }

        [MaxLength(100)]
        public string? Uwagi { get; set; }
    }
}
