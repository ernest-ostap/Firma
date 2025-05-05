using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Models
{
    public class UstawieniaPortalu
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? GodzinyPracy { get; set; }

        [MaxLength(100)]
        public string? Kontakt { get; set; }

        [MaxLength(100)]
        public string? DaneFirmy { get; set; }
    }

}
