using Data.DTOs.OfferDTOs;
using Data.DTOs.Other;
using Data.Models;
using System.Linq.Expressions;

namespace GazpromTestProject.Services.IServices
{
    public interface IOfferService
    {
        public Task<Offer> CreateOfferAsync(OfferCreateDTO model);
        public Task<Offer?> GetOfferByIdAsync(int id);
        public Task<List<Offer>> SortByFilterAsync(SearchQuery query);
    }
}
