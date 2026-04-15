using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kias_Kar_Kompany.Data;
using Kias_Kar_Kompany.Models;

namespace Kias_Kar_Kompany.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Kias_Kar_KompanyContext _context;

        public VehiclesController(Kias_Kar_KompanyContext context)
        {
            _context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.Include(v => v.Manufacturer).ToListAsync());
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var vehicle = await _context.Vehicles
                .Include(v => v.Manufacturer)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewBag.Manufacturers = _context.Manufacturers.ToList();
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Manufacturers = _context.Manufacturers.ToList();
            return View(vehicle);
        }

        // EDIT GET
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null) return NotFound();

            ViewBag.Manufacturers = _context.Manufacturers.ToList();
            return View(vehicle);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Manufacturers = _context.Manufacturers.ToList();
            return View(vehicle);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var vehicle = await _context.Vehicles
                .Include(v => v.Manufacturer)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }
    }
}