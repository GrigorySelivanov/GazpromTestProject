using Data.DTOs.ProviderDTOs;
using Data.Models;
using DbContext.Repository;
using System.Linq.Expressions;

namespace GazpromTestProject.Services.IServices
{
    public interface IProviderService
    {
        public Task<Provider?> GetProviderByIdAsync(int id);
        public Provider CreateProvider(ProviderCreateDTO model);
        public Task<List<Provider>> GetPopularAsync();
    }
}
