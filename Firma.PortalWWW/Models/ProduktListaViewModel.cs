using Firma.Data.Models;
using System.Collections.Generic;

namespace Firma.PortalWWW.ViewModels
{
    public class ProduktListaViewModel
    {
        public List<Produkt> Produkty { get; set; } = new();
        public List<Kategoria> Kategorie { get; set; } = new();
        public int? WybranaKategoriaId { get; set; }
        public decimal? CenaMaksymalna { get; set; }

    }
}
