using ProjektWWW.NET_FR_LB.Models;

namespace ProjektWWW.NET_FR_LB.Repositories
{
    public interface IWalutaRepository
    {
        Task<List<Waluta>> GetAllAsync();
        Task<Waluta?> GetByIdAsync(int id);
        Task AddAsync(Waluta waluta);
        Task UpdateAsync(Waluta waluta);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
