using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using System.Diagnostics;
using SportsStore.Data;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StoreContext _context;

        public HomeController(ILogger<HomeController> logger, StoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Chess()
        {
            return View(await _context.Product.Where(c => c.Product_Category == "Chess").ToListAsync());
        }

        public async Task<IActionResult> Soccer()
        {
            return View(await _context.Product.Where(c => c.Product_Category == "Soccer").ToListAsync());
        }

        public async Task<IActionResult> WaterSports()
        {
            return View(await _context.Product.Where(c => c.Product_Category == "Watersports").ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
