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
        public async Task<IActionResult> Create(Waluta waluta, IFormFile flaga)
        {
            if (waluta.Kraj == null && flaga == null)
            {
                ModelState.AddModelError("Kraj", "Proszę przesłać plik graficzny.");
            }
            else
            {
                ModelState.Remove("Kraj");
            }

            if (!ModelState.IsValid)
                return View(waluta);

            if (flaga != null && flaga.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(flaga.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await flaga.CopyToAsync(stream);
                }

                waluta.Kraj = "/uploads/" + fileName;
            }

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
        public async Task<IActionResult> Edit(int id, Waluta waluta, IFormFile flaga)
        {
            if (id != waluta.Id) return NotFound();

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            if (!ModelState.IsValid) return View(waluta);

            if (flaga != null && flaga.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(flaga.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await flaga.CopyToAsync(stream);
                }

                waluta.Kraj = "/uploads/" + fileName;
            }
            else
            {
                waluta.Kraj = existing.Kraj; // zachowaj starą flagę
            }

            await _repo.UpdateAsync(waluta);
            return RedirectToAction(nameof(Index));
        }

    }
}
