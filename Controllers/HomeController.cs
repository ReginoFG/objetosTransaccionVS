using Microsoft.AspNetCore.Mvc;
using objetosTransaccion.Models;
using System.Diagnostics;

namespace objetosTransaccion.Controllers
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
            HttpContext.Session.SetString("Nombre", "Regino");
            ViewData["vd"] = "viewdata";
            ViewBag.vb = "viewbag";
            TempData["td"] = "tempdata";
            TempData["met"] = "aMetodo";
            return View();
        }

        public IActionResult Privacy()
        {
            String nombre = (String)HttpContext.Session.GetString("Nombre");
            HttpContext.Session.SetString("Nombre2",nombre);
            String td2;
            if (TempData.ContainsKey("td"))
            {
                TempData["td2"] = TempData["td"].ToString();
            }
            String met2;
            if (TempData.ContainsKey("met"))
            {
                TempData["met2"] = TempData["met"].ToString();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}