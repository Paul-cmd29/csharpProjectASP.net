using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompStore.Models;

namespace CompStore.Controllers
{
    public class OrdercsController : Controller
    {
        //private readonly ApplicationContext _context;
        ApplicationContext _context;

        public OrdercsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Ordercs
        public async Task<IActionResult> Index()
        {
            var storeContext = _context.Ordercs.Include(o => o.Laptop);
            return View(await storeContext.ToListAsync());
        }

        // GET: Ordercs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordercs = await _context.Ordercs
                .Include(o => o.Laptop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordercs == null)
            {
                return NotFound();
            }

            return View(ordercs);
        }

        // GET: Ordercs/Create
        public IActionResult Create()
        {
            ViewData["LaptopID"] = new SelectList(_context.Laptops, "Id", "Id");
            return View();
        }

        // POST: Ordercs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,User,Address,ContactPhone,LaptopID")] Ordercs ordercs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordercs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LaptopID"] = new SelectList(_context.Laptops, "Id", "Id", ordercs.LaptopID);
            return View(ordercs);
        }

        // GET: Ordercs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordercs = await _context.Ordercs.FindAsync(id);
            if (ordercs == null)
            {
                return NotFound();
            }
            ViewData["LaptopID"] = new SelectList(_context.Laptops, "Id", "Id", ordercs.LaptopID);
            return View(ordercs);
        }

        // POST: Ordercs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,User,Address,ContactPhone,LaptopID")] Ordercs ordercs)
        {
            if (id != ordercs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordercs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdercsExists(ordercs.Id))
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
            ViewData["LaptopID"] = new SelectList(_context.Laptops, "Id", "Id", ordercs.LaptopID);
            return View(ordercs);
        }

        // GET: Ordercs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordercs = await _context.Ordercs
                .Include(o => o.Laptop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordercs == null)
            {
                return NotFound();
            }

            return View(ordercs);
        }

        // POST: Ordercs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordercs = await _context.Ordercs.FindAsync(id);
            _context.Ordercs.Remove(ordercs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdercsExists(int id)
        {
            return _context.Ordercs.Any(e => e.Id == id);
        }
    }
}
