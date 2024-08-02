using Data.DTOs.OfferDTOs;
using Data.DTOs.Other;
using Data.Models;
using System.Linq.Expressions;

namespace GazpromTestProject.Services.IServices
{
    public interface IOfferService
    {
        public Task<Offer> CreateOfferAsync(OfferCreateDTO model);
        public Task<Offer?> GetOfferByIdAsync(int id, string? includeProp = null, bool isTraking = true);
        public Task<IEnumerable<Offer>> GetAllAsync(
            Expression<Func<Offer, bool>>? filter = null,
            string? includeProp = null,
            bool isTraking = true);

        public Task<List<Offer>> SortByFilterAsync(SearchQuery query);
    }
}
