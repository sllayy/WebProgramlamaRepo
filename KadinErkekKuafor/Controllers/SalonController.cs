using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KuaforYonetimSistemi.Data;
using KuaforYonetimSistemi.Models;

namespace KadinErkekKuafor.Controllers
{
    public class SalonController : Controller
    {
        private readonly AppDbContext _context;

        public SalonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Salons
        public async Task<IActionResult> Index()
        {
              return _context.Salonlar != null ? 
                          View(await _context.Salonlar.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Salonlar'  is null.");
        }

        // GET: Salons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salonlar == null)
            {
                return NotFound();
            }

            var salon = await _context.Salonlar
                .FirstOrDefaultAsync(m => m.SalonID == id);
            if (salon == null)
            {
                return NotFound();
            }

            return View(salon);
        }

        // GET: Salons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalonID,Ad,Adres,Telefon,CalismaSaatleri")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salon);
        }

        // GET: Salons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salonlar == null)
            {
                return NotFound();
            }

            var salon = await _context.Salonlar.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }
            return View(salon);
        }

        // POST: Salons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalonID,Ad,Adres,Telefon,CalismaSaatleri")] Salon salon)
        {
            if (id != salon.SalonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalonExists(salon.SalonID))
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
            return View(salon);
        }

        // GET: Salons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salonlar == null)
            {
                return NotFound();
            }

            var salon = await _context.Salonlar
                .FirstOrDefaultAsync(m => m.SalonID == id);
            if (salon == null)
            {
                return NotFound();
            }

            return View(salon);
        }

        // POST: Salons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salonlar == null)
            {
                return Problem("Entity set 'AppDbContext.Salonlar'  is null.");
            }
            var salon = await _context.Salonlar.FindAsync(id);
            if (salon != null)
            {
                _context.Salonlar.Remove(salon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalonExists(int id)
        {
          return (_context.Salonlar?.Any(e => e.SalonID == id)).GetValueOrDefault();
        }
    }
}
