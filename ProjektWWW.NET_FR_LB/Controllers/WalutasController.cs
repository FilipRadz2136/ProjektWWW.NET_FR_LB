using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using Microsoft.AspNetCore.Authorization;


namespace ProjektWWW.NET_FR_LB.Controllers
{ 
    public class WalutasController : Controller
    {
        private readonly Kantor1DbContext _context;

        public WalutasController(Kantor1DbContext context)
        {
            _context = context;
        }

        // GET: Walutas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Waluty.ToListAsync());
        }

        // GET: Walutas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waluta = await _context.Waluty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waluta == null)
            {
                return NotFound();
            }

            return View(waluta);
        }

        // GET: Walutas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Walutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kod,Nazwa,Symbol,Kraj")] Waluta waluta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waluta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waluta);
        }

        // GET: Walutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waluta = await _context.Waluty.FindAsync(id);
            if (waluta == null)
            {
                return NotFound();
            }
            return View(waluta);
        }

        // POST: Walutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kod,Nazwa,Symbol,Kraj")] Waluta waluta)
        {
            if (id != waluta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waluta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalutaExists(waluta.Id))
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
            return View(waluta);
        }

        // GET: Walutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waluta = await _context.Waluty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waluta == null)
            {
                return NotFound();
            }

            return View(waluta);
        }

        // POST: Walutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waluta = await _context.Waluty.FindAsync(id);
            if (waluta != null)
            {
                _context.Waluty.Remove(waluta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalutaExists(int id)
        {
            return _context.Waluty.Any(e => e.Id == id);
        }
    }
}
