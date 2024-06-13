using FormularioJorge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace FormularioJorge.Controllers
{
    
    public class HomeController : Controller
    {
        private static List<Entrevistado> _Entrevistados = new List<Entrevistado>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        { 
            return View(_Entrevistados);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GuardarFormulario(string NombreEntr,string RazonSocial, string Puesto,string CorreoElectronico)
        {
            
            _Entrevistados.Add(new Entrevistado()
            {
                Nombre = NombreEntr,
                RazonSocial = RazonSocial,
                puesto = Puesto,
                correo = CorreoElectronico
            });
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
