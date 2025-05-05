using Firma.Data.Models.Firma.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Firma.Data.Models
{
    public class Rezerwacja
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data od")]
        public DateTime DataOd { get; set; }

        [Required]
        [Display(Name = "Data do")]
        public DateTime DataDo { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Status { get; set; } = "Oczekująca";

        [ForeignKey("KlientId")]
        public int KlientId { get; set; } 
        public Klient? Klient { get; set; }

        [ForeignKey("ProduktId")]
        public int ProduktId { get; set; }

        public Produkt? Produkt { get; set; }
    }

}
