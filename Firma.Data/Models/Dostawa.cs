using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Models
{
    public class Dostawa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adres dostawy jest wymagany")]
        [MaxLength(200, ErrorMessage ="Maksymalna długość")]
        public required string Adres { get; set; } = string.Empty;

        [MaxLength(30, ErrorMessage ="Maksymalna długość to 30 znaków")]
        public string? Sposob { get; set; }

        [Required(ErrorMessage = "Status dostawy jest wymagany")]
        [MaxLength(30, ErrorMessage = "Maksymalna długość to 30 znaków")]
        public required string Status { get; set; } = "W trakcie przygotowania";
    }

}
