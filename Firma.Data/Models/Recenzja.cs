using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Models
{
    public class Recenzja
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 5)]
        public int Ocena { get; set; }

        [MaxLength(500, ErrorMessage = "Maksymalnie 500 znaków")]
        public string? Komentarz { get; set; }

        public int ProduktId { get; set; }
        public Produkt? Produkt { get; set; }

        [ForeignKey("KlientId")]
        public int KlientId { get; set; }
        public Klient? Klient { get; set; }
    }

}
