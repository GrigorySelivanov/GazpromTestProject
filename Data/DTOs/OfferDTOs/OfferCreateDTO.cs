using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.OfferDTOs
{
    public class OfferCreateDTO
    {
        [Required(ErrorMessage = "Добавьте марку")]
        public required string Mark { get; set; }
        [Required(ErrorMessage = "Добавьте модель")]
        public required string Model { get; set; }
        [Required(ErrorMessage = "Добавьте поставщика")]
        public required int ProviderId { get; set; }
    }
}
