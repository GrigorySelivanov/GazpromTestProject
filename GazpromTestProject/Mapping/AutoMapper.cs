using AutoMapper;
using Data.DTOs.OfferDTOs;
using Data.DTOs.ProviderDTOs;
using Data.Models;

namespace GazpromTestProject.Mapping
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Offer, OfferGetDTO>()
                .ForMember(u => u.RegistrationDate, x => x.MapFrom(o => o.RegistrationDate.ToLocalTime().ToString("dd.MM.yy HH.mm")));

            CreateMap<Provider, ProviderGetDTO>()
                .ForMember(u => u.CreatedDate, x => x.MapFrom(p => p.CreatedDate.ToLocalTime().ToString("dd.MM.yy HH.mm")));
            
            CreateMap<Provider, PopularProviderGetDTO>()
                .ForMember(u => u.Count, x => x.MapFrom(p => p.Offers.Count));

        }
    }
}
