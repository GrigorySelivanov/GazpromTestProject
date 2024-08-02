using Data.DTOs.ProviderDTOs;

namespace Data.DTOs.OfferDTOs
{
    public class OfferGetDTO
    {
        public required string Mark { get; set; }
        public required string Model { get; set; }
        public required ProviderGetDTO Provider { get; set; }
        public required string RegistrationDate { get; set; }
    }
}
