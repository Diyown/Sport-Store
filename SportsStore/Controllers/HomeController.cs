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
        private readonly CartContext _cartContext;

        public HomeController(ILogger<HomeController> logger, StoreContext context, CartContext cartContext)
        {
            _logger = logger;
            _context = context;
            _cartContext = cartContext;
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

        public async Task<IActionResult> AddToCart(long id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                var cartItem = new Cart
                {
                    Product_ID = product.Product_ID.ToString(),
                    Product_Name = product.Product_Name,
                    Price = product.Price
                };

                _cartContext.Add(cartItem);
                await _cartContext.SaveChangesAsync();
            }
            return RedirectToAction("Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
