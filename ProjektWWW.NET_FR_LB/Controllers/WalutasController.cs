using Microsoft.AspNetCore.Mvc;
using ProjektWWW.NET_FR_LB.Models;
using ProjektWWW.NET_FR_LB.Repositories;
using System.Threading.Tasks;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class WalutasController : Controller
    {
        private readonly IWalutaRepository _repo;

        public WalutasController(IWalutaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var waluta = await _repo.GetByIdAsync(id.Value);
            if (waluta == null) return NotFound();

            return View(waluta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kod,Nazwa,Symbol,Kraj")] Waluta waluta)
        {
            if (!ModelState.IsValid) return View(waluta);

            await _repo.AddAsync(waluta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var waluta = await _repo.GetByIdAsync(id.Value);
            if (waluta == null) return NotFound();

            return View(waluta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kod,Nazwa,Symbol,Kraj")] Waluta waluta)
        {
            if (id != waluta.Id) return NotFound();
            if (!ModelState.IsValid) return View(waluta);

            await _repo.UpdateAsync(waluta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var waluta = await _repo.GetByIdAsync(id.Value);
            if (waluta == null) return NotFound();

            return View(waluta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
