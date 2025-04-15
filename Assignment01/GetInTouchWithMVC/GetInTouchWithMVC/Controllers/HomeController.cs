using System.Diagnostics;
using GetInTouchWithMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetInTouchWithMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult ShowProducts()
        {
            return View("Products");
        }

        public IActionResult Show(int id)
        {
            if (id == 0)
            {
                return View("Zero");
            }
            else
            {
                return View("Hello");
            }

        }

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
