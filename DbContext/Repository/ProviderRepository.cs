using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContext.Repository
{
    public class ProviderRepository(AppDbContext db) : Repository<Provider>(db)
    {
        public async Task<List<Provider>> GetPopularAsync(int count)
        {
            return await _db.Providers
                            .OrderByDescending(p => p.Offers.Count)
                            .Take(count)
                            .AsNoTracking()
                            .Include("Offers")
                            .ToListAsync();
        }
    }
}
