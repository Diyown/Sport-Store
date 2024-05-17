    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using SportsStore.Data;
    using SportsStore.Models;

    namespace SportsStore.Controllers
    {
        public class CartsController : Controller
        {
            private readonly CartContext _context;

            public CartsController(CartContext context)
            {
                _context = context;
            }

        // GET: Carts
        public async Task<IActionResult> Index()
            {
                return View(await _context.Cart.ToListAsync());
            }
        public async Task<IActionResult> Checkout()
        {

            _context.Cart.RemoveRange(_context.Cart);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home"); 
        }

        public async Task<IActionResult> Details(long? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var cart = await _context.Cart
                    .FirstOrDefaultAsync(m => m.Cart_ID == id);
                if (cart == null)
                {
                    return NotFound();
                }

                return View(cart);
            }

            // GET: Carts/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Carts/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Cart_ID,Product_ID,Product_Name,Price")] Cart cart)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(cart);
            }

            // GET: Carts/Edit/5
            public async Task<IActionResult> Edit(long? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var cart = await _context.Cart.FindAsync(id);
                if (cart == null)
                {
                    return NotFound();
                }
                return View(cart);
            }

            // POST: Carts/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(long? id, [Bind("Cart_ID,Product_ID,Product_Name,Price")] Cart cart)
            {
                if (id != cart.Cart_ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(cart);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CartExists(cart.Cart_ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(cart);
            }

            // GET: Carts/Delete/5
            public async Task<IActionResult> Delete(long? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var cart = await _context.Cart
                    .FirstOrDefaultAsync(m => m.Cart_ID == id);
                if (cart == null)
                {
                    return NotFound();
                }

                return View(cart);
            }

            // POST: Carts/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(long? id)
            {
                var cart = await _context.Cart.FindAsync(id);
                if (cart != null)
                {
                    _context.Cart.Remove(cart);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool CartExists(long? id)
            {
                return _context.Cart.Any(e => e.Cart_ID == id);
            }
        }
    }
