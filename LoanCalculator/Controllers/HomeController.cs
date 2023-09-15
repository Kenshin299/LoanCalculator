using LoanCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LoanCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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

            // Agregar plazos desde 12 hasta 120 meses en incrementos de 6 meses.
            for (int i = 12; i <= 120; i += 6)
            {
                model.Plazos.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            model.Tasa = 22;
            return View(model);
        }

        [HttpPost]
        public ActionResult CalcularCuota(PrestamoViewModel model)
        {
            

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}