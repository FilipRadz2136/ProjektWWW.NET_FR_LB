using Microsoft.EntityFrameworkCore;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;

namespace ProjektWWW.NET_FR_LB.Repositories
{
    public class WalutaRepository : IWalutaRepository
    {
        private readonly Kantor1DbContext _context;

        public WalutaRepository(Kantor1DbContext context)
        {
            _context = context;
        }

        public async Task<List<Waluta>> GetAllAsync()
        {
            return await _context.Waluty.ToListAsync();
        }

        public async Task<Waluta?> GetByIdAsync(int id)
        {
            return await _context.Waluty.FindAsync(id);
        }

        public async Task AddAsync(Waluta waluta)
        {
            _context.Waluty.Add(waluta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Waluta waluta)
        {
            _context.Waluty.Update(waluta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var waluta = await _context.Waluty.FindAsync(id);
            if (waluta != null)
            {
                _context.Waluty.Remove(waluta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Waluty.AnyAsync(w => w.Id == id);
        }
    }
}

