using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Models
{
    public class Pracownik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Haslo { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Stanowisko { get; set; }
    }

}
