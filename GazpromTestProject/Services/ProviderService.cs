using Data.DTOs.OfferDTOs;
using Data.DTOs.ProviderDTOs;
using Data.Models;
using DbContext.Repository;
using GazpromTestProject.Services.IServices;
using System.Linq.Expressions;

namespace GazpromTestProject.Services
{
    public class ProviderService(ProviderRepository providerRepository) : IProviderService
    {
        private readonly ProviderRepository _providerRepository = providerRepository;

        public async Task<Provider?> GetProviderByIdAsync(int id, string? includeProp = null, bool isTraking = true) =>
            await _providerRepository.FirstOrDefaultAsync(o => o.Id == id, includeProp, isTraking);

        public async Task<IEnumerable<Provider>> GetAllAsync(Expression<Func<Provider, bool>>? filter = null,
                                                          string? includeProp = null, bool isTraking = true)
        {
            return await _providerRepository.GetAllAsync(filter: filter, includeProp: includeProp);
        }

        public Provider CreateProvider(ProviderCreateDTO model)
        {
            var provider = new Provider()
            {
                Name = model.Name,
                CreatedDate = model.CreatedDate
            };
            _providerRepository.Add(provider);
            _providerRepository.Save();

            return provider;
        }

        public async Task<List<Provider>> GetPopular() =>
            await _providerRepository.GetPopularAsync(3);
    }
}
