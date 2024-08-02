using Data.DTOs.ProviderDTOs;
using Data.Models;
using DbContext.Repository;
using System.Linq.Expressions;

namespace GazpromTestProject.Services.IServices
{
    public interface IProviderService
    {
        public Task<Provider?> GetProviderByIdAsync(int id, string? includeProp = null, bool isTraking = true);
        public Task<IEnumerable<Provider>> GetAllAsync(Expression<Func<Provider, bool>>? filter = null,
                                                       string? includeProp = null, 
                                                       bool isTraking = true);
        public Provider CreateProvider(ProviderCreateDTO model);
        public Task<List<Provider>> GetPopular();
    }
}
