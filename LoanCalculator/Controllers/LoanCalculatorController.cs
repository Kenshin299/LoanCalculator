using LoanCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LoanCalculator.Controllers
{
    public class LoanCalculatorController : Controller
    {
        private readonly ILogger<LoanCalculatorController> _logger;

        public LoanCalculatorController(ILogger<LoanCalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new PrestamoViewModel
            {
                TiposPrestamo = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Personal", Value = "Personal" },
                    new SelectListItem { Text = "Automóvil", Value = "Automóvil" },
                    new SelectListItem { Text = "Hipotecario", Value = "Hipotecario" }
                },
                Plazos = new List<SelectListItem>(),
            };

            for (int i = 12; i <= 120; i += 6)
            {
                model.Plazos.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            model.Tasa = 22; //Valor de la tasa del Prestamo personal que es el primero que se presenta en el select
            return View(model);
        }

        [HttpPost]
        public IActionResult Resultado(PrestamoViewModel model)
        {
            var calculo = (((model.Tasa / 100) * model.Monto) + model.Monto) / model.Plazo;
            model.Resultado = Math.Round(calculo, 2);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}