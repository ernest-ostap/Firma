using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Models
{
    public class StronaCMS
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Klucz jest wymagany")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość to 50 znaków")]
        public required string Klucz { get; set; } = string.Empty;

        [Required(ErrorMessage = "Treść strony jest wymagana.")]
        public required string Tresc { get; set; } = string.Empty;
    }

}
