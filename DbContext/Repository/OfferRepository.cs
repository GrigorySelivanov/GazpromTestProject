using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContext.Repository
{
    public class OfferRepository(AppDbContext db) : Repository<Offer>(db)
    {
        public async Task<List<Offer>> GetByFilterAsync(string? mark, string? model, string? provider)
        {
            var query = _db.Offers.AsNoTracking();

            if (mark != null)
                query = query.Where(o => o.Mark.ToLower().Contains(mark.ToLower()));

            if (model != null)
                query = query.Where(o => o.Model.ToLower().Contains(model.ToLower()));

            if (provider != null)
                query = query.Where(o => o.Provider.Name.ToLower().Contains(provider.ToLower()));

            return await query.Include("Provider").ToListAsync();
        }
    }
}
