using Data.DTOs.OfferDTOs;
using Data.DTOs.Other;
using Data.Models;
using DbContext.Repository;
using GazpromTestProject.Services.IServices;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GazpromTestProject.Services
{
    public class OfferService(
        OfferRepository offerRepository,
        IProviderService providerService) : IOfferService
    {
        private readonly OfferRepository _offerRepository = offerRepository;
        private readonly IProviderService _providerService = providerService;


        public async Task<Offer?> GetOfferByIdAsync(int id, string? includeProp = null, bool isTraking = true) =>
            await _offerRepository.FirstOrDefaultAsync(o => o.Id == id, includeProp, isTraking);

        public async Task<IEnumerable<Offer>> GetAllAsync(Expression<Func<Offer, bool>>? filter = null,
                                                          string? includeProp = null, bool isTraking = true)
        {
            return await _offerRepository.GetAllAsync(filter: filter, includeProp: includeProp);
        }
                

        public async Task<Offer> CreateOfferAsync(OfferCreateDTO model)
        {
            var offer = new Offer()
            {
                Model = model.Model,
                Mark = model.Mark,
                RegistrationDate = TimeProvider.System.GetUtcNow(),
                Provider = await _providerService.GetProviderByIdAsync(model.ProviderId) ?? throw new KeyNotFoundException("Поставщик не найден")
            };

            _offerRepository.Add(offer);
            _offerRepository.Save();
            return offer;
        }

        public async Task<List<Offer>> SortByFilterAsync(SearchQuery query) =>
           await _offerRepository.GetByFilterAsync(query.Model, query.Mark, query.Provider);
    }
}
