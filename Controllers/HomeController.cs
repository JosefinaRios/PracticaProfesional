using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticaSupervisada.Models;

namespace PracticaSupervisada.Controllers
{
    public class HomeController : Controller
    {
        private readonly PracticaPtallerContext _context;

        public HomeController(PracticaPtallerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var comentarios = _context.Comentarios.OrderByDescending(c => c.Fecha).Take(5).ToList();

            return View(comentarios);
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
