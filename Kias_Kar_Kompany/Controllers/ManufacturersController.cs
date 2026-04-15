using Kias_Kar_Kompany.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kias_Kar_Kompany.Models;

namespace Kias_Kar_Kompany.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly Kias_Kar_KompanyContext _context;

        public ManufacturersController(Kias_Kar_KompanyContext context)
        {
            _context = context;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manufacturers.ToListAsync());
        }

        // GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (manufacturer == null) return NotFound();

            return View(manufacturer);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null) return NotFound();

            return View(manufacturer);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (manufacturer == null) return NotFound();

            return View(manufacturer);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}