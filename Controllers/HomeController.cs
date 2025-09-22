/*Desenvolvido por:
  
  Pedro Xavier Oliveira CB3027376
  Leandro Felix Nunes CB3026159

 */

using System.Diagnostics;
using BLContainerManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLContainerManager.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
