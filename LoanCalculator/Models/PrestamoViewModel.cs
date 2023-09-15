
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanCalculator.Models
{
    public class PrestamoViewModel
    {
        public decimal Monto { get; set; }
        public string TipoPrestamo { get; set; }
        public List<SelectListItem> TiposPrestamo { get; set; }
        public int Plazo { get; set; }
        public int Tasa { get; set; }
        public List<SelectListItem> Plazos { get; set; }
        public decimal? Resultado { get; set; }
    }
}
